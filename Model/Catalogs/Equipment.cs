using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Model.Catalogs {
    public class Equipment:Catalog {
        public Category Category { get; set; }

        public override string ToString() {
            return Category + @"\" + Name;
        }
    }
}
