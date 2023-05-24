using EquipmentManagement.Model.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Model.Documents {
    public class WriteOffRow:DocumentRow {
        public Equipment Equipment { get; set; }
        public int Quantity { get; set; }
        public Unit FromUnit { get; set; }
        public ResponsiblePerson FromResponsiblePerson { get; set; }
    }
}
