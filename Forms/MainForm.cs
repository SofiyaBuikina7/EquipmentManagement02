using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EquipmentManagement.Forms;
using EquipmentManagement.Model;
using EquipmentManagement.Model.Catalogs;
using EquipmentManagement.Model.Documents;

namespace EquipmentManagement {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }
       
        void OpenTableForm<T>() where T : TableElement, new () {
            var TableForm = new ElementsTableForm<T>();
            TableForm.MdiParent = this;
            TableForm.Show();
        }

        private void потребностьToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenTableForm<Rrequirement>();
        }

        private void категорииToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenTableForm<Category>();
        }


        private void оборудываниеToolStripMenuItem_Click(object sender, EventArgs e) {
            
            OpenTableForm<Equipment>();
        }

        private void подразделенияToolStripMenuItem_Click(object sender, EventArgs e) {
            
            //OpenTableForm(db.Equipment.ToList());
        }

        private void MainForm_Load(object sender, EventArgs e) {

        }


        private void пользователиToolStripMenuItem1_Click(object sender, EventArgs e) {
            OpenTableForm<User>();
        }

        private void настройкиToolStripMenuItem1_Click(object sender, EventArgs e) {
            var SettingsFrm = new SettingsForm();
            SettingsFrm.ShowDialog();

        }

        private void единицыИзмеренияToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenTableForm<Unit>();
        }

        private void местаРасположенияТехникиToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenTableForm<InstallationLocation>();
        }

        private void ответственныеЗаТехникуToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenTableForm<ResponsiblePerson>();
        }

        private void закупкаToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenTableForm<Purchasing>();
        }

        private void списаниеToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenTableForm<WriteOff>();
        }

        private void MainForm_Resize(object sender, EventArgs e) {
            foreach (var form in this.MdiChildren) {
                var X = form.Left;
                var Y = form.Top;
                var Width = form.Width;
                var Height = form.Height;
                if ((X + Width) > this.Width){
                    if (X >= 0) {
                        X = 0;
                        if ((X + Width) > this.Width) {
                            Width = this.Width - 40;
                        }
                    }
                    form.Left = X;
                    form.Width = Width;
                }
                //if ((Y + Height) > this.Height) {
                //    if (Y >= 0) {
                //        Y = 0;
                //        if ((Y + Height) > this.Height) {
                //            Height = this.Height - 120;
                //        }
                //    }
                //    form.Top = Y;
                //    form.Height = Height;
                //}

            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (MessageBox.Show(this, "Вы уверенны что хотите выйти?", "Вы уверенны что хотите выйти?", MessageBoxButtons.YesNo) != DialogResult.Yes) {
                e.Cancel = true;
            }
        }
    }
}
