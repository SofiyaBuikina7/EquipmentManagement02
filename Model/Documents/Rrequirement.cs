﻿using EquipmentManagement.Model.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Model.Documents {
    public class Rrequirement:Document {
        public Unit Unit { get; set; }
        public List<RrequirementRow> RrequirementRows { get; set; }
    }
}
