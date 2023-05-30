using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Model.Documents {
    public class WriteOff:Document {
        public string Reason { get; set; }
        public List<WriteOffRow> WriteOffRows { get; set; }
    }
}
