﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Model {
    public class TableElement {
        public int Id { get; set; }
        public bool IsMarkedForDeletion { get; set; }
    }
}
