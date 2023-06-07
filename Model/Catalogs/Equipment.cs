using static EquipmentManagement.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Model.Catalogs {
    public class Equipment:Catalog {
        [Include]
        public Category Category { get; set; }
        [Include]
        public Unit Unit { get; set; }

        public override string ToString() {
            return Category + @"\" + Name;
        }
    }
}
