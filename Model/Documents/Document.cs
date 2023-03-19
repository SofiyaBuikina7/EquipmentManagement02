using EquipmentManagement.Model.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Model.Documents {
    public class Document {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string No { get; set; }
        public User Author { get; set; }
    }
}
