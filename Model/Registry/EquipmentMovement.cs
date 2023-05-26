using EquipmentManagement.Model.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Model.Registry {
    public class EquipmentMovement:Registry {
        public Equipment Equipment { get; set; }
        public int Quantity { get; set; }
        public Unit Unit { get; set; }
        public ResponsiblePerson Person { get; set; }
    }
}
