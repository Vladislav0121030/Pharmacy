using System.Linq;
using System.Windows;
using Pharmacy.Models;

namespace Pharmacy.Views
{
    public partial class MedicineForm : Window
    {
        public Medicine Medicine { get; private set; }

        public MedicineForm(System.Collections.Generic.List<Medicine> allMedicines)
        {
            InitializeComponent();
            Medicine = new Medicine();
            DataContext = this;
        }

        public MedicineForm(Medicine medicine, System.Collections.Generic.List<Medicine> allMedicines)
        {
            InitializeComponent();
            Medicine = medicine;
            DataContext = this;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Medicine.MedicineName))
            {
                MessageBox.Show("Введите название лекарства", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DialogResult = true;
        }
    }
}