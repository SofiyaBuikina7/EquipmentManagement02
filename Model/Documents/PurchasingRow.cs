using EquipmentManagement.Model.Catalogs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Model.Documents {
    public class PurchasingRow:DocumentRow {
        public Equipment Equipment { get; set; }
        public int Quantity { get; set; }
        public Unit ForUnit { get; set; }
        public ResponsiblePerson ForResponsiblePerson { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }
    }
}
