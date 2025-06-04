using System;
using System.Linq;
using System.Windows;
using Pharmacy.Models;

namespace Pharmacy.Views
{
    public partial class SaleForm : Window
    {
        public Sale Sale { get; private set; }

        public SaleForm(MedicinePackage package, System.Collections.Generic.List<Employee> employees)
        {
            InitializeComponent();
            Sale = new Sale
            {
                PackageId = package.PackageId,
                SaleDate = DateTime.Now,
                Quantity = 1
            };
            DataContext = this;
            EmployeeComboBox.ItemsSource = employees;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите сотрудника", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(QuantityTextBox.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Введите корректное количество", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Sale.Quantity = quantity;
            Sale.EmployeeId = ((Employee)EmployeeComboBox.SelectedItem).EmployeeId;

            DialogResult = true;
        }
    }
}