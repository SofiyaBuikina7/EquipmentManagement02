﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Model.Catalogs {
    public class Category {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString() {
            return Name;
        }
    }
}
