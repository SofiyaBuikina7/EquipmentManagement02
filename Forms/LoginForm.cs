using EquipmentManagement.Model;
using EquipmentManagement.Model.Catalogs;
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
        }

        private void OKBtn_Click(object sender, EventArgs e) {
            if (CheckPassword()) {
                this.DialogResult = DialogResult.OK;
            }
        }

        public Boolean CheckPassword() {
            User SelectedUser = (User)UserNameCB.SelectedItem;
            if (Utils.CreateMD5(PasswordTB.Text) == SelectedUser.PasswordMD5) {
                return true;
            } else {
                MessageBox.Show("Пароль не верен!");
                return false;
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }

        private void LoginForm_Load(object sender, EventArgs e) {
            var db = new EMContext();
            var count = db.Users.ToList().Count();
            if (count == 0) {
                //this.DialogResult = DialogResult.OK;
                var NewForm = new UserForm();
                if (NewForm.ShowDialog() == DialogResult.OK) {
                    UserNameCB.DataSource = db.Users.ToList();
                }
            } else {
                UserNameCB.DataSource = db.Users.ToList();
            }
        }

        private void PasswordTB_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                if (CheckPassword()) {
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
