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

        public static void CreateMovement(Requirement document) {
            EMContext ctx = new EMContext();
            Requirement Requirement = ctx.Set<Requirement>().Where(t => t.Id == document.Id).FirstOrDefault();
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

        public static void GetLeftovers(DateTime dateTime) {
            EMContext ctx = new EMContext();
            var EquipmentRrequirements = ctx.Set<EquipmentRrequirement>().
                Where(t => t.MovementMoment <= dateTime).
                Select(s => new { Quantity = s.Direction * s.Quantity, s.Equipment, s.InstallationLocation}).
                GroupBy(g => new { g.Equipment, g.InstallationLocation}).
                Select(x => new { Equipment = x.Key.Equipment, 
                    InstallationLocation = x.Key.InstallationLocation, 
                    Leftover = x.Sum(y => y.Quantity)}).
                ToList();
        }
    }
}
