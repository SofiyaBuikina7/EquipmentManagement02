using EquipmentManagement.Model.Catalogs;
using EquipmentManagement.Model.Documents;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Model {
    public class EMContext: DbContext {
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Rrequirement> Rrequirements { get; set; }


        public EMContext() : base() {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EMContext, Migrations.Configuration>());
        }
    }
}
