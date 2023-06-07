using EquipmentManagement.Model.Documents;
using System.Collections.Generic;
using System.Linq;


namespace EquipmentManagement.Model.Registry {
    public class RegistryHelper {
        public static void DeleteMovement(Document document) {
            EMContext ctx = new EMContext();
            List<EquipmentMovement> RowsToDelete = ctx.Set<EquipmentMovement>().Where(t => t.RegistratorType == document.GetType().Name && t.RegistratorId == document.Id).ToList();
            foreach (var Row in RowsToDelete) {
                ctx.Set<EquipmentMovement>().Remove(Row);
            }
            ctx.SaveChanges();
        }
    }
}
