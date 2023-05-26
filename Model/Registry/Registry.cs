using EquipmentManagement.Model.Catalogs;
using EquipmentManagement.Model.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Model.Registry {
    public class Registry {
        public int Id { get; set; }
        public int Direction { get; set; }
        public int RegistratorId { get; set; }
        public string RegistratorType { get; set; }
    }
}
