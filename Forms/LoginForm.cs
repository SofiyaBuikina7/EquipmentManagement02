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
    public partial class LoginForm : Form {
        public LoginForm() {
            InitializeComponent();
            var db = new EMContext();
            var count = db.Users.ToList().Count();
            if (count == 0) {
                this.DialogResult = DialogResult.OK;
            } else {
                UserNameCB.DataSource = db.Users.ToList();
            }
        }

        private void OKBtn_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
        }

        private void CancelBtn_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
