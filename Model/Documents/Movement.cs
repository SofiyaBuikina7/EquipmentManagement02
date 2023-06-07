using EquipmentManagement.Model.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Model.Documents {
    public class Movement:Document {
        public string Reason { get; set; }
        public InstallationLocation From { get; set; }
        public InstallationLocation To { get; set; }
        public ResponsiblePerson ResponsiblePersonFrom { get; set; }
        public ResponsiblePerson ResponsiblePersonTo { get; set; }
        public List<MovementRow> Rows { get; set; }
    }
}
