﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Model.Catalogs {
    public class User:Catalog {
        public string PasswordMD5 { get; set; }
    }
}
