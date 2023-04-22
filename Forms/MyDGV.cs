using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipmentManagement.Forms {
    public class MyDGV : DataGridView {
        public void ColumnsResize() {
            for (int i = 0; i < ColumnCount; i++) {
                HandledMouseEventArgs me = new HandledMouseEventArgs(MouseButtons.Left, 1, 0, 0, 0);
                DataGridViewColumnDividerDoubleClickEventArgs e = new DataGridViewColumnDividerDoubleClickEventArgs(i, me);
                base.OnColumnDividerDoubleClick(e);
            }
        }
    }
}
