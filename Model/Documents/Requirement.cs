using EquipmentManagement.Model.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Model.Documents {
    public class Requirement:Document {
        public string Reason { get; set; }
        public InstallationLocation InstallationLocation { get; set; }
        [Include]
        public List<RrequirementRow> Rows { get; set; }
    }
}
