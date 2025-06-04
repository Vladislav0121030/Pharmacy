using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Pharmacy.Models;

namespace Pharmacy.Data
{
    public class PharmacyDbContext : DbContext
    {
        public PharmacyDbContext() : base("PharmacyConnection")
        {
            Database.SetInitializer(new PharmacyDbInitializer());
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTransfer> EmployeeTransfers { get; set; }
        public DbSet<PackageForm> PackageForms { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<MedicinePackage> MedicinePackages { get; set; }
        public DbSet<MedicineSubstitute> MedicineSubstitutes { get; set; }
        public DbSet<MedicineRequest> MedicineRequests { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Configure many-to-many relationship for MedicineSubstitute
            modelBuilder.Entity<Medicine>()
                .HasMany(m => m.OriginalMedicines)
                .WithRequired(ms => ms.OriginalMedicine)
                .HasForeignKey(ms => ms.OriginalMedicineId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Medicine>()
                .HasMany(m => m.SubstituteMedicines)
                .WithRequired(ms => ms.SubstituteMedicine)
                .HasForeignKey(ms => ms.SubstituteMedicineId)
                .WillCascadeOnDelete(false);
        }
    }
}