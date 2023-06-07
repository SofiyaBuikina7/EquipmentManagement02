using EquipmentManagement.Model;
using EquipmentManagement.Model.Catalogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipmentManagement.Forms {
    public partial class UserForm :Form{
        User MyElement;
        EMContext ctx = new EMContext();
        bool PasswordChanges = false;
        public UserForm(int ElementID = -1, bool NeedCopy = false) {
            InitializeComponent();
            
            if (ElementID == -1) {
                MyElement = new User();
            } else {
                var query = ctx.Set<User>().AsQueryable();
                MyElement = query.Where(t => t.Id == ElementID).FirstOrDefault();
            }
            NameTb.Text = MyElement.Name;
            if (NeedCopy) {
                ctx.Dispose();
                ctx = new EMContext();
                ElementID = -1;
                MyElement = new User();
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e) {
            Save();
        }

        private Boolean Save() {
            if (string.IsNullOrEmpty(NameTb.Text) || string.IsNullOrEmpty(NameTb.Text.Trim())) {
                MessageBox.Show("Имя пользователя не может быть пустым!");
                return false;
            }
            MyElement.Name = NameTb.Text;
            if (PasswordChanges || MyElement.Id == 0) {
                if (!string.IsNullOrEmpty(Password1Tb.Text) || !string.IsNullOrEmpty(Password2Tb.Text)) {
                    if (!Password1Tb.Text.Equals(Password2Tb.Text)) {
                        MessageBox.Show("Пароли не совпадают!");
                        return false;
                    }
                }
                MyElement.PasswordMD5 = Utils.CreateMD5(Password1Tb.Text);
            }

            if (MyElement.Id == 0) {
                ctx.Set<User>().Add(MyElement);
            }
            ctx.SaveChanges();
            return true;

        }

        private void SaveAndExit_Click(object sender, EventArgs e) {
            if (Save()) {
                this.Close();
            }
        }

        private void Password1Tb_TextChanged(object sender, EventArgs e) {
            PasswordChanges = true;
        }
    }
}
