using Pharmacy.Models;

namespace Pharmacy.Extensions
{
    public static class ModelExtensions
    {
        public static string FullName(this Employee employee)
        {
            return $"{employee.LastName} {employee.FirstName} {employee.MiddleName}";
        }

        public static string PackageInfo(this MedicinePackage package)
        {
            return $"{package.PackageForm.FormName} - {package.Price:C} (остаток: {package.Quantity})";
        }
    }
}