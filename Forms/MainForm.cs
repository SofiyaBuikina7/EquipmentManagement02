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
            
            OpenTableForm< Equipment>();
        }

        private void подразделенияToolStripMenuItem_Click(object sender, EventArgs e) {
            
            //OpenTableForm(db.Equipment.ToList());
        }

        private void MainForm_Load(object sender, EventArgs e) {

        }

        private void пользователиToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenTableForm<User>();
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e) {
            var SettingsFrm = new SettingsForm();
            SettingsFrm.ShowDialog();
        }
    }
}
