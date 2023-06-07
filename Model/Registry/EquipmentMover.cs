using EquipmentManagement.Model.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Model.Registry {
    public class EquipmentMover {
        public void CreateMovement(Purchasing document) {
            EMContext ctx = new EMContext();
            List<PurchasingRow> Rows = ctx.Set<Purchasing>().Where(t => t.Id == document.Id).FirstOrDefault().Rows.ToList();
            foreach (var Row in Rows) {
                EquipmentMovement registry = new EquipmentMovement();
                registry.RegistratorId = document.Id;
                registry.RegistratorType = document.GetType().Name;
                registry.Direction = 1;
                registry.Equipment = Row.Equipment;
                registry.InstallationLocation = Row.InstallationLocation;
                registry.Person = Row.ForResponsiblePerson;
                registry.Quantity = Row.Quantity; 
                ctx.Set<EquipmentMovement>().Add(registry);
            }
            ctx.SaveChanges();
        }

        public void CreateMovement(WriteOff document) {
            EMContext ctx = new EMContext();
            List<WriteOffRow> Rows = ctx.Set<WriteOff>().Where(t => t.Id == document.Id).FirstOrDefault().Rows.ToList();
            foreach (var Row in Rows) {
                EquipmentMovement registry = new EquipmentMovement();
                registry.RegistratorId = document.Id;
                registry.RegistratorType = document.GetType().Name;
                registry.Direction = -1;
                registry.Equipment = Row.Equipment;
                registry.InstallationLocation = Row.InstallationLocation;
                registry.Person = Row.FromResponsiblePerson;
                registry.Quantity = Row.Quantity;
                ctx.Set<EquipmentMovement>().Add(registry);
            }
            ctx.SaveChanges();

        }

        public void DeleteMovement(Document document)  {
            EMContext ctx = new EMContext();
            List<EquipmentMovement> RowsToDelete = ctx.Set<EquipmentMovement>().Where(t => t.RegistratorType == document.GetType().Name && t.RegistratorId == document.Id).ToList();
            foreach (var Row in RowsToDelete) {
                ctx.Set<EquipmentMovement>().Remove(Row);
            }
            ctx.SaveChanges();
        }
    }
}
