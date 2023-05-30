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
            List<PurchasingRow> purchasingRows = ctx.Set<Purchasing>().Where(t => t.Id == document.Id).FirstOrDefault().PurchasingRows.ToList();
            foreach (var Row in purchasingRows) {
                EquipmentMovement registry = new EquipmentMovement();
                registry.RegistratorId = document.Id;
                registry.RegistratorType = document.GetType().Name;
                registry.Direction = 1;
                registry.Equipment = Row.Equipment;
                registry.Unit = Row.ForUnit;
                registry.Person = Row.ForResponsiblePerson;
                registry.Quantity = Row.Quantity; 
                ctx.Set<EquipmentMovement>().Add(registry);
            }
            ctx.SaveChanges();
        }

        public void CreateMovement(WriteOff document) {
            EMContext ctx = new EMContext();
            List<WriteOffRow> purchasingRows = ctx.Set<WriteOff>().Where(t => t.Id == document.Id).FirstOrDefault().WriteOffRows.ToList();
            foreach (var Row in purchasingRows) {
                EquipmentMovement registry = new EquipmentMovement();
                registry.RegistratorId = document.Id;
                registry.RegistratorType = document.GetType().Name;
                registry.Direction = -1;
                registry.Equipment = Row.Equipment;
                registry.Unit = Row.FromUnit;
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
