using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Model.Catalogs {
    public class ResponsiblePerson:Catalog {
        
        public string Patronymic { get; set; }
        public string Surname { get; set; }

        public override string ToString() {
            return Surname + " " + Name + " " + Patronymic;
        }
    }
}
