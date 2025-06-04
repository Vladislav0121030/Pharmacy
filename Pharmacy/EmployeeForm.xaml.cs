using System;
using System.Windows;
using Pharmacy.Models;

namespace Pharmacy.Views
{
    public partial class EmployeeForm : Window
    {
        public Employee Employee { get; private set; }

        public EmployeeForm()
        {
            InitializeComponent();
            Employee = new Employee { IsActive = true, BirthDate = DateTime.Now.AddYears(-20) };
            DataContext = Employee;
        }

        public EmployeeForm(Employee employee)
        {
            InitializeComponent();
            Employee = employee;
            DataContext = Employee;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Employee.LastName) ||
                string.IsNullOrWhiteSpace(Employee.FirstName) ||
                string.IsNullOrWhiteSpace(Employee.Address) ||
                string.IsNullOrWhiteSpace(Employee.Position))
            {
                MessageBox.Show("Заполните все обязательные поля", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DialogResult = true;
        }
    }
}