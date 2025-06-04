using System;
using System.Windows;
using Pharmacy.Models;

namespace Pharmacy.Views
{
    public partial class EmployeeTransferForm : Window
    {
        public Employee Employee { get; private set; }
        public EmployeeTransfer Transfer { get; private set; }

        public EmployeeTransferForm(Employee employee)
        {
            InitializeComponent();
            Employee = employee;
            Transfer = new EmployeeTransfer
            {
                EmployeeId = employee.EmployeeId,
                PreviousPosition = employee.Position,
                OrderDate = DateTime.Today,
                TransferDate = DateTime.Today
            };
            DataContext = this;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Transfer.NewPosition) ||
                string.IsNullOrWhiteSpace(Transfer.TransferReason) ||
                string.IsNullOrWhiteSpace(Transfer.OrderNumber))
            {
                MessageBox.Show("Заполните все обязательные поля", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DialogResult = true;
        }
    }
}