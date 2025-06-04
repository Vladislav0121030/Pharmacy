using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;
using Pharmacy.Data;
using Pharmacy.Models;
using Pharmacy.Views;

namespace Pharmacy
{
    public partial class MainWindow : Window
    {
        private PharmacyDbContext _context;

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Months { get; set; }
        public Func<double, string> Formatter { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            _context = new PharmacyDbContext();

            SeriesCollection = new SeriesCollection();
            Formatter = value => value.ToString("N0");

            DataContext = this;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                _context.Employees.Include(e => e.Transfers).Load();
                EmployeesGrid.ItemsSource = _context.Employees.Local;

                _context.Medicines
                    .Include(m => m.Packages.Select(p => p.PackageForm))
                    .Include(m => m.OriginalMedicines.Select(s => s.SubstituteMedicine))
                    .Load();
                MedicinesGrid.ItemsSource = _context.Medicines.Local;

                MedicineComboBox.ItemsSource = _context.Medicines.Local;
                YearComboBox.SelectedIndex = 2;
                RefreshInventory();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EmployeesGrid_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            if (EmployeesGrid.SelectedItem is Employee selectedEmployee)
            {
                _context.Entry(selectedEmployee).Collection(emp => emp.Transfers).Load();
                TransfersGrid.ItemsSource = selectedEmployee.Transfers;
            }
        }

        private void MedicinesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MedicinesGrid.SelectedItem is Medicine selectedMedicine)
            {
                _context.Entry(selectedMedicine).Collection(m => m.Packages).Query().Include(p => p.PackageForm).Load();
                PackagesGrid.ItemsSource = selectedMedicine.Packages;

                _context.Entry(selectedMedicine).Collection(m => m.OriginalMedicines).Query().Include(s => s.SubstituteMedicine).Load();
                SubstitutesGrid.ItemsSource = selectedMedicine.OriginalMedicines.Select(s => s.SubstituteMedicine).ToList();
            }
        }

        private void UpdateChart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MedicineComboBox.SelectedItem is Medicine selectedMedicine &&
                    YearComboBox.SelectedItem is ComboBoxItem selectedYearItem &&
                    int.TryParse(selectedYearItem.Content.ToString(), out int selectedYear))
                {
                    var requests = _context.MedicineRequests
                        .Where(r => r.MedicineId == selectedMedicine.MedicineId &&
                                    r.RequestDate.Year == selectedYear)
                        .GroupBy(r => r.RequestDate.Month)
                        .Select(g => new { Month = g.Key, Count = g.Count() })
                        .OrderBy(g => g.Month)
                        .ToList();

                    SeriesCollection.Clear();
                    SeriesCollection.Add(new ColumnSeries
                    {
                        Title = "Запросы",
                        Values = new ChartValues<int>(requests.Select(r => r.Count)),
                        Fill = System.Windows.Media.Brushes.DodgerBlue
                    });

                    Months = requests.Select(r =>
                        new DateTime(selectedYear, r.Month, 1).ToString("MMM")).ToArray();

                    RequestsChart.AxisX[0].Labels = Months;
                    RequestsChart.AxisY[0].Title = "Количество запросов";

                    RequestsChart.Update();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления графика: {ex.Message}", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RefreshInventory()
        {
            try
            {
                var inventory = _context.MedicinePackages
                    .Include(p => p.Medicine)
                    .Include(p => p.PackageForm)
                    .Where(p => p.Quantity > 0)
                    .Select(p => new
                    {
                        MedicineName = p.Medicine.MedicineName,
                        FormName = p.PackageForm.FormName,
                        p.Price,
                        p.Quantity
                    })
                    .ToList();

                InventoryGrid.ItemsSource = inventory;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления инвентаря: {ex.Message}", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            var form = new EmployeeForm();
            if (form.ShowDialog() == true)
            {
                try
                {
                    _context.Employees.Add(form.Employee);
                    _context.SaveChanges();
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка добавления сотрудника: {ex.Message}", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void EditEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeesGrid.SelectedItem is Employee selectedEmployee)
            {
                var form = new EmployeeForm(selectedEmployee);
                if (form.ShowDialog() == true)
                {
                    try
                    {
                        _context.SaveChanges();
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка сохранения изменений: {ex.Message}", "Ошибка",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для редактирования", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void TransferEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeesGrid.SelectedItem is Employee selectedEmployee)
            {
                var form = new EmployeeTransferForm(selectedEmployee);
                if (form.ShowDialog() == true)
                {
                    try
                    {
                        _context.EmployeeTransfers.Add(form.Transfer);
                        selectedEmployee.Position = form.Transfer.NewPosition;
                        _context.SaveChanges();
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка перевода сотрудника: {ex.Message}", "Ошибка",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для перевода", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void AddMedicine_Click(object sender, RoutedEventArgs e)
        {
            var form = new MedicineForm(_context.Medicines.ToList());
            if (form.ShowDialog() == true)
            {
                try
                {
                    _context.Medicines.Add(form.Medicine);
                    _context.SaveChanges();
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка добавления лекарства: {ex.Message}", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void EditMedicine_Click(object sender, RoutedEventArgs e)
        {
            if (MedicinesGrid.SelectedItem is Medicine selectedMedicine)
            {
                var form = new MedicineForm(selectedMedicine, _context.Medicines.ToList());
                if (form.ShowDialog() == true)
                {
                    try
                    {
                        _context.SaveChanges();
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка сохранения изменений: {ex.Message}", "Ошибка",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите лекарство для редактирования", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void SellMedicine_Click(object sender, RoutedEventArgs e)
        {
            if (PackagesGrid.SelectedItem is MedicinePackage selectedPackage)
            {
                if (selectedPackage.Quantity <= 0)
                {
                    MessageBox.Show("Выбранный товар отсутствует на складе", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var form = new SaleForm(selectedPackage, _context.Employees.Where(emp => emp.IsActive).ToList());
                if (form.ShowDialog() == true)
                {
                    try
                    {
                        _context.Sales.Add(form.Sale);
                        selectedPackage.Quantity -= form.Sale.Quantity;

                        _context.MedicineRequests.Add(new MedicineRequest
                        {
                            MedicineId = selectedPackage.MedicineId,
                            PackageId = selectedPackage.PackageId,
                            RequestDate = DateTime.Now,
                            Quantity = form.Sale.Quantity,
                            IsSubstitute = false
                        });

                        _context.SaveChanges();

                        PackagesGrid.Items.Refresh();
                        RefreshInventory();

                        MessageBox.Show("Продажа успешно оформлена", "Успех",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка оформления продажи: {ex.Message}", "Ошибка",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите упаковку для продажи", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            _context?.Dispose();
        }
    }
}