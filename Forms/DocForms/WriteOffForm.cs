using EquipmentManagement.Forms;
using EquipmentManagement.Model;
using EquipmentManagement.Model.Catalogs;
using EquipmentManagement.Model.Documents;
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
    public partial class WriteOffForm : Form {
        bool IsNew = false;
        bool IsCopy = false;
        int DocID = 0;
        WriteOff ThisDoc;

        public WriteOffForm(int ElementID = -1, bool NeedCopy = false) {
            IsCopy = NeedCopy;
            if (ElementID == -1 || NeedCopy) {
                IsNew = true;
            }
            if (ElementID != -1) {
                DocID = ElementID;
            }
            InitializeComponent();
            var Users = GetCtalogList<User>();
            AuthorCB.DataSource = Users;
            if (IsNew) {
                DocDateDTP.Value = DateTime.Now;
                AuthorCB.SelectedItem = Users.Where(p => p.Id == Settings.CurrentSettings.CurrentUserId).FirstOrDefault();
            } else { 

            }
        }

        void LoadDoc() {
            LoadTable();
        }

        List<T> GetCtalogList<T>() where T:Catalog {
            var ctx = new EMContext();
            var Result = ctx.Set<T>().AsQueryable().LoadRelated().AsNoTracking().ToList();
            ctx.Dispose();
            return Result;
        }
            
        void LoadTable() {
            var ctx = new EMContext();
            //var query = ctx.Set<TypeEntity>().AsQueryable();
            //var MyList = query.ToList();
            //MainListDGV.DataSource = MyList;
            //PrepareDGV(ref MainListDGV, MyList);
            SetTablesStyle();
            ctx.Dispose();
            MainListDGV.ColumnsResize();
        }

        private void MainListDGV_KeyDown(object sender, KeyEventArgs e) {
            //if (e.KeyCode == Keys.Insert) {
            //    var NewElementForm = new ElementForm<TypeEntity>();
            //    NewElementForm.MdiParent = this.MdiParent;
            //    NewElementForm.FormClosed += new FormClosedEventHandler(OnChildFormClosed);
            //    NewElementForm.Show();
            //}
            //if (e.KeyCode == Keys.Enter) {
            //    if (MainListDGV.SelectedCells != null && MainListDGV.SelectedCells.Count > 0) {
            //        var MyCell = MainListDGV.SelectedCells[0];
            //        int Id = (int)MainListDGV.Rows[MyCell.RowIndex].Cells["Id"].Value;

            //        var NewElementForm = new ElementForm<TypeEntity>(Id);
            //        NewElementForm.MdiParent = this.MdiParent;
            //        NewElementForm.FormClosed += new FormClosedEventHandler(OnChildFormClosed);
            //        NewElementForm.Show();
            //    }
            //}
        }

        void OnChildFormClosed(object sender, FormClosedEventArgs e) {
            LoadTable();
            //Form frm = (Form)sender;
        }

        void PrepareDGV<T>(ref MyDGV MyDataGridView, List<T> DataSource) {
            MyDataGridView.RowHeadersVisible = false;
            MyDataGridView.DataSource = DataSource;
            MyDataGridView.Columns["Id"].Visible = false;
            if (MyDataGridView.Columns.Contains("IsMarkedForDeletion") && !MyDataGridView.Columns.Contains("StausColumn")) {
                MyDataGridView.Columns["IsMarkedForDeletion"].Visible = false;
                var StausColumn = new DataGridViewImageColumn();
                StausColumn.Name = "StausColumn";
                StausColumn.HeaderText = "";
                MyDataGridView.Columns.Insert(0, StausColumn);
                MyDataGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(MyDataGridView_CellFormatting);
            }
            if (MyDataGridView.Columns.Contains("Held")) {
                MyDataGridView.Columns["Held"].Visible = false;
            }
                
            Utils.TranslateColumnHeaders<T>(ref MyDataGridView);
        }

        void MyDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (e.RowIndex > -1 && e.ColumnIndex == ((MyDGV)sender).Columns["StausColumn"].Index) {
                if (((MyDGV)sender)["IsMarkedForDeletion", e.RowIndex].Value != null) {
                    bool IsMarked = (bool)(((MyDGV)sender)["IsMarkedForDeletion", e.RowIndex].Value);
                    if (IsMarked) {
                        e.Value = Properties.Resources.Delete;
                    } else {
                        if (((MyDGV)sender).Columns.Contains("Held")) {
                            bool IsHeld = (bool)(((MyDGV)sender)["Held", e.RowIndex].Value);
                            if (IsHeld) {
                                e.Value = Properties.Resources.Held;
                            } else {
                                e.Value = Properties.Resources.Doc;
                            }
                        } else {
                            e.Value = Properties.Resources.Doc;
                        } 
                    }
                }
            }
        }

        public void SetTablesStyle() {
            foreach (var control in Controls) {
                if (control.GetType() == typeof(DataGridView) || control.GetType() == typeof(MyDGV)) {
                    var DGV = (DataGridView)control;
                    if (Settings.CurrentSettings.TableFont != null) {
                        DGV.DefaultCellStyle.Font = Settings.CurrentSettings.TableFont;
                        //DGV.ColumnHeadersDefaultCellStyle.Font = DGV.DefaultCellStyle.Font;
                    }
                    if (Settings.CurrentSettings.EvenForeColor != null) {
                        DGV.DefaultCellStyle.ForeColor = Settings.CurrentSettings.EvenForeColor;
                    }
                    if (Settings.CurrentSettings.EvenBackColor != null) {
                        DGV.DefaultCellStyle.BackColor = Settings.CurrentSettings.EvenBackColor;
                    }
                    if (Settings.CurrentSettings.OddForeColor != null) {
                        DGV.AlternatingRowsDefaultCellStyle.ForeColor = Settings.CurrentSettings.OddForeColor;
                    }
                    if (Settings.CurrentSettings.OddBackColor != null) {
                        DGV.AlternatingRowsDefaultCellStyle.BackColor = Settings.CurrentSettings.OddBackColor;
                    }
                }
            }
        }
    }
}
