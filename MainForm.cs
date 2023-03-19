using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EquipmentManagement.Model;

namespace EquipmentManagement {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }
        Form EmployeeRequests;
        private void button1_Click(object sender, EventArgs e) {
            using (var ctx = new EMConext()) {
                //"Data Source=(localdb)\\mssqllocaldb;Initial Catalog=EquipmentManagement.Model.EMConext;Integrated Security=True;MultipleActiveResultSets=True"
                //var TestCat = new Category() { Name = "Comps", Id = 10 };
                var cats =  ctx.Categorys.ToList();
                foreach (var Categ in cats) {
                    MessageBox.Show("" + Categ);
                }
                //ctx.SaveChanges();
            }
        }


        void OpenTableForm(object TableName)
        {
            var TableForm = new ElementsTableForm(TableName);
            TableForm.MdiParent = this;
            TableForm.Show();
        }

        private void потребностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void категорииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var db = new EMConext();
            OpenTableForm(db.Categorys.ToList());
        }
        

        private void оборудываниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var db = new EMConext();
            OpenTableForm(db.Equipment.ToList());
        }
    }
}
