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
                Settings.CurrentSettings.CurrentUserId = SelectedUser.Id;
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
            while (count == 0) {
                MessageBox.Show("Не обнаружено ни одного пользователя.\nДля работы в программе неодходимо создать пользователя!");
                var NewForm = new UserForm();
                NewForm.ShowDialog();
                NewForm.Dispose();
                count = db.Users.ToList().Count();
            }
            UserNameCB.DataSource = db.Users.ToList();
            db.Dispose();
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
