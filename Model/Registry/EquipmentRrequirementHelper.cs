using EquipmentManagement.Model.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Model.Registry {
    public class EquipmentRrequirementHelper:RegistryHelper {
        public void CreateMovement(Purchasing document) {
            EMContext ctx = new EMContext();
            List<PurchasingRow> Rows = ctx.Set<Purchasing>().Where(t => t.Id == document.Id).FirstOrDefault().Rows.ToList();
            foreach (var Row in Rows) {
                EquipmentRrequirement registry = new EquipmentRrequirement();
                registry.RegistratorId = document.Id;
                registry.RegistratorType = document.GetType().Name;
                registry.Direction = -1;
                registry.Equipment = Row.Equipment;
                registry.InstallationLocation = Row.InstallationLocation;
                registry.Quantity = Row.Quantity; 
                ctx.Set<EquipmentRrequirement>().Add(registry);
            }
            ctx.SaveChanges();
        }

        public static void CreateMovement(WriteOff document) {
            EMContext ctx = new EMContext();
            List<WriteOffRow> Rows = ctx.Set<WriteOff>().Where(t => t.Id == document.Id).FirstOrDefault().Rows.ToList();
            foreach (var Row in Rows) {
                EquipmentRrequirement registry = new EquipmentRrequirement();
                registry.RegistratorId = document.Id;
                registry.RegistratorType = document.GetType().Name;
                registry.Direction = 1;
                registry.Equipment = Row.Equipment;
                registry.InstallationLocation = Row.InstallationLocation;
                registry.Quantity = Row.Quantity;
                ctx.Set<EquipmentRrequirement>().Add(registry);
            }
            ctx.SaveChanges();
        }

        public static void CreateMovement(Rrequirement document) {
            EMContext ctx = new EMContext();
            Rrequirement Requirement = ctx.Set<Rrequirement>().Where(t => t.Id == document.Id).FirstOrDefault();
            List<RrequirementRow> Rows = Requirement.Rows.ToList();
            foreach (var Row in Rows) {
                EquipmentRrequirement registry = new EquipmentRrequirement();
                registry.RegistratorId = document.Id;
                registry.RegistratorType = document.GetType().Name;
                registry.Direction = 1;
                registry.Equipment = Row.Equipment;
                registry.InstallationLocation = Requirement.InstallationLocation;
                registry.Quantity = Row.Quantity;
                ctx.Set<EquipmentRrequirement>().Add(registry);
            }
            ctx.SaveChanges();
        }

    }
}
