using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Model.Documents {
    public class Purchasing: Document{
        public string Provider { get; set; }
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }
        public List<PurchasingRow> PurchasingRows { get; set; }
    }
}
