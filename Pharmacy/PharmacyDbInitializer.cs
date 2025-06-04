using System;
using System.Collections.Generic;
using System.Data.Entity;
using Pharmacy.Models;

namespace Pharmacy.Data
{
    public class PharmacyDbInitializer : DropCreateDatabaseIfModelChanges<PharmacyDbContext>
    {
        protected override void Seed(PharmacyDbContext context)
        {
            // Seed initial data
            var packageForms = new List<PackageForm>
            {
                new PackageForm { FormName = "Таблетки", Description = "Упаковка таблеток" },
                new PackageForm { FormName = "Капсулы", Description = "Упаковка капсул" },
                new PackageForm { FormName = "Сироп", Description = "Флакон сиропа" },
                new PackageForm { FormName = "Мазь", Description = "Туба мази" },
                new PackageForm { FormName = "Ампулы", Description = "Упаковка ампул" }
            };
            context.PackageForms.AddRange(packageForms);

            var employees = new List<Employee>
            {
                new Employee {
                    LastName = "Иванов",
                    FirstName = "Иван",
                    MiddleName = "Иванович",
                    Address = "ул. Ленина, 10",
                    BirthDate = new DateTime(1980, 5, 15),
                    Position = "Фармацевт",
                    Salary = 35000m
                },
                new Employee {
                    LastName = "Петрова",
                    FirstName = "Мария",
                    MiddleName = "Сергеевна",
                    Address = "ул. Гагарина, 25",
                    BirthDate = new DateTime(1985, 7, 22),
                    Position = "Провизор",
                    Salary = 45000m
                }
            };
            context.Employees.AddRange(employees);

            var medicines = new List<Medicine>
            {
                new Medicine { MedicineName = "Парацетамол", Description = "Жаропонижающее средство" },
                new Medicine { MedicineName = "Ибупрофен", Description = "Противовоспалительное средство" },
                new Medicine { MedicineName = "Аспирин", Description = "Обезболивающее средство" },
                new Medicine { MedicineName = "Ношпа", Description = "Спазмолитик" }
            };
            context.Medicines.AddRange(medicines);

            context.SaveChanges();

            var medicinePackages = new List<MedicinePackage>
            {
                new MedicinePackage {
                    MedicineId = 1,
                    PackageFormId = 1,
                    Price = 50.50m,
                    Quantity = 100
                },
                new MedicinePackage {
                    MedicineId = 1,
                    PackageFormId = 3,
                    Price = 120.00m,
                    Quantity = 30
                },
                new MedicinePackage {
                    MedicineId = 2,
                    PackageFormId = 1,
                    Price = 75.25m,
                    Quantity = 80
                },
                new MedicinePackage {
                    MedicineId = 3,
                    PackageFormId = 2,
                    Price = 65.00m,
                    Quantity = 50
                }
            };
            context.MedicinePackages.AddRange(medicinePackages);

            var substitutes = new List<MedicineSubstitute>
            {
                new MedicineSubstitute {
                    OriginalMedicineId = 1,
                    SubstituteMedicineId = 2
                },
                new MedicineSubstitute {
                    OriginalMedicineId = 1,
                    SubstituteMedicineId = 3
                },
                new MedicineSubstitute {
                    OriginalMedicineId = 2,
                    SubstituteMedicineId = 1
                }
            };
            context.MedicineSubstitutes.AddRange(substitutes);

            var transfers = new List<EmployeeTransfer>
            {
                new EmployeeTransfer {
                    EmployeeId = 1,
                    PreviousPosition = null,
                    NewPosition = "Фармацевт",
                    TransferReason = "Прием на работу",
                    OrderNumber = "123",
                    OrderDate = new DateTime(2020, 1, 10)
                },
                new EmployeeTransfer {
                    EmployeeId = 2,
                    PreviousPosition = "Фармацевт",
                    NewPosition = "Провизор",
                    TransferReason = "Повышение",
                    OrderNumber = "124",
                    OrderDate = new DateTime(2021, 3, 15)
                }
            };
            context.EmployeeTransfers.AddRange(transfers);

            context.SaveChanges();
        }
    }
}