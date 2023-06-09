﻿using EquipmentManagement.Model.Catalogs;

namespace EquipmentManagement.Model.Registry {
    public class EquipmentMovement:Registry {
        public Equipment Equipment { get; set; }
        public InstallationLocation InstallationLocation { get; set; }
        public ResponsiblePerson Person { get; set; }

        public int Quantity { get; set; }
    }
}
