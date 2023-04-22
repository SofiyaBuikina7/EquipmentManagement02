using EquipmentManagement.Forms;
using EquipmentManagement.Model;
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

namespace EquipmentManagement
{
    public partial class ElementsTableForm<TypeEntity>: Form where TypeEntity : TableElement, new() {
        public ElementsTableForm(){
            InitializeComponent();
            this.Text = typeof(TypeEntity).Name + "s";
            LoadTable();
            //MainListDGV.DataSource = list;
        }

        void LoadTable() {
            var ctx = new EMContext();
            var query = ctx.Set<TypeEntity>().AsQueryable();
            var MyList = query.ToList();
            MainListDGV.DataSource = MyList;
            PrepareDGV(ref MainListDGV, MyList);
            ctx.Dispose();
        }

        private void MainListDGV_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Insert) {
                var NewElementForm = new ElementForm<TypeEntity>();
                NewElementForm.MdiParent = this.MdiParent;
                NewElementForm.FormClosed += new FormClosedEventHandler(OnChildFormClosed);
                NewElementForm.Show();
            }
            if (e.KeyCode == Keys.Enter) {
                if (MainListDGV.SelectedCells != null && MainListDGV.SelectedCells.Count > 0) {
                    var MyCell = MainListDGV.SelectedCells[0];
                    int Id = (int)MainListDGV.Rows[MyCell.RowIndex].Cells["Id"].Value;

                    var NewElementForm = new ElementForm<TypeEntity>(Id);
                    NewElementForm.MdiParent = this.MdiParent;
                    NewElementForm.FormClosed += new FormClosedEventHandler(OnChildFormClosed);
                    NewElementForm.Show();
                }
            }
        }

        void OnChildFormClosed(object sender, FormClosedEventArgs e) {
            LoadTable();
            //Form frm = (Form)sender;
        }

        void PrepareDGV<T>(ref MyDGV MyDataGridView, List<T> DataSource) {
            MyDataGridView.RowHeadersVisible = false;
            MyDataGridView.DataSource = DataSource;
            MyDataGridView.Columns["Id"].Visible = false;
            Utils.TranslateColumnHeaders<T>(ref MyDataGridView);
        }



        //public static object GetPropertyValue(object source, string propertyName)
        //{
        //    PropertyInfo property = source.GetType().GetProperty(propertyName);
        //    return property.GetValue(source, null);
        //}

        //public static IQueryable Set(DbContext context, Type T) {
        //    // Get the generic type definition
        //    MethodInfo method = typeof(DbContext).GetMethod(nameof(DbContext.Set), BindingFlags.Public | BindingFlags.Instance);

        //    // Build a method with the specific type argument you're interested in
        //    method = method.MakeGenericMethod(T);

        //    return method.Invoke(context, null) as IQueryable;
        //}

        //public static IQueryable<T> Set<T>(EMConext context) {
        //    // Get the generic type definition 
        //    MethodInfo method = typeof(EMConext).GetMethod(nameof(EMConext.Set), BindingFlags.Public | BindingFlags.Instance);

        //    // Build a method with the specific type argument you're interested in 
        //    method = method.MakeGenericMethod(typeof(T));

        //    return method.Invoke(context, null) as IQueryable<T>;
        //}
    }
}
