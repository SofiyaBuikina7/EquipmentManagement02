using EquipmentManagement.Model.Catalogs;
using EquipmentManagement.Model.Documents;
using EquipmentManagement.Model.Registry;
using System.Data.Entity;


namespace EquipmentManagement.Model {
    public class EMContext: DbContext {
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<InstallationLocation> InstallationLocations { get; set; }
        public DbSet<ResponsiblePerson> ResponsiblePersons { get; set; }

        public DbSet<Rrequirement> Rrequirements { get; set; }
        public DbSet<Purchasing> Purchasings { get; set; }
        public DbSet<Movement> Movements { get; set; }
        public DbSet<WriteOff> WriteOffs { get; set; }

        public DbSet<EquipmentMovement> EquipmentMovements { get; set; }
        public DbSet<EquipmentRrequirement> EquipmentRrequirement { get; set; }

        public EMContext() : base() {
            if (Settings.CreateDB) {
                Database.SetInitializer(new CreateDatabaseIfNotExists<EMContext>());
            } else {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<EMContext, Migrations.Configuration>());
            }
        }
    }
}
