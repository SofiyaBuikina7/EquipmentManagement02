using EquipmentManagement.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipmentManagement.Forms {
    public partial class ElementForm<TypeEntity> : Form where TypeEntity :TableElement, new(){
        TableElement MyElement;
        public ElementForm(int ElementID = -1) {
            InitializeComponent();
            var ctx = new EMContext();
            
            if (ElementID == -1) {
                MyElement = new TypeEntity();
            } else {
                var query = ctx.Set<TypeEntity>().AsQueryable();
                MyElement = (TableElement)query.Where(t => t.Id == ElementID);
            }
        }
    }
}
