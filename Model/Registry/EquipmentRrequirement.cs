using EquipmentManagement.Model.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Model.Registry {
    public class EquipmentRrequirement : Registry {
        public Equipment Equipment { get; set; }
        public InstallationLocation InstallationLocation { get; set; }

        public int Quantity { get; set; }
    }
}
