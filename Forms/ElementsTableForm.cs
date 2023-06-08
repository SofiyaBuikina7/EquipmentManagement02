using EquipmentManagement.Forms;
using EquipmentManagement.Model;
using EquipmentManagement.Model.Catalogs;
using EquipmentManagement.Model.Documents;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Windows.Forms;

namespace EquipmentManagement {
    public partial class ElementsTableForm<TypeEntity> : Form where TypeEntity : TableElement, new() {
        public ElementsTableForm() {
            InitializeComponent();
            this.Text = Utils.GetTableNameTranslation<TypeEntity>();
            LoadTable();
        }

        void LoadTable() {
            var ctx = new EMContext();
            IQueryable<TypeEntity> query;
            List<TypeEntity> MyList;

            query = ctx.Set<TypeEntity>().AsQueryable().LoadRelated();
            MyList = query.ToList();

            MainListDGV.DataSource = MyList;
            PrepareDGV(ref MainListDGV, MyList);
            SetTablesStyle();
            ctx.Dispose();
            MainListDGV.ColumnsResize();
        }

        private void MainListDGV_KeyDown(object sender, KeyEventArgs e) {
            Form NewForm = null;
            bool SetFormProperties = false;
            if (e.KeyCode == Keys.Insert) {
                if (typeof(TypeEntity).IsSubclassOf(typeof(Document))) {
                    NewForm = new DocumentForm<TypeEntity>();
                } else if (typeof(TypeEntity) == typeof(User)) {
                    NewForm = new UserForm();
                } else {
                    NewForm = new ElementForm<TypeEntity>();
                }
                SetFormProperties = true;
            }
    
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.F9) {
                if (MainListDGV.SelectedCells != null && MainListDGV.SelectedCells.Count > 0) {
                    var MyCell = MainListDGV.SelectedCells[0];
                    int Id = (int)MainListDGV.Rows[MyCell.RowIndex].Cells["Id"].Value;
                    bool NeedCopy = false;
                    if (e.KeyCode == Keys.F9) {
                        NeedCopy = true;
                    }

                    if (typeof(TypeEntity).IsSubclassOf(typeof(Document))) {
                        NewForm = new DocumentForm<TypeEntity>(Id, NeedCopy);
                    } else if (typeof(TypeEntity) == typeof(User)) {
                        NewForm = new UserForm(Id, NeedCopy);
                    } else {
                        NewForm = new ElementForm<TypeEntity>(Id, NeedCopy);
                    }
                    SetFormProperties = true;
                }
            }

            if (e.KeyCode == Keys.Delete) {
                if (MainListDGV.SelectedCells != null && MainListDGV.SelectedCells.Count > 0) {
                    var MyCell = MainListDGV.SelectedCells[0];
                    int Id = (int)MainListDGV.Rows[MyCell.RowIndex].Cells["Id"].Value;
                    var ctx = new EMContext();
                    var Element = ctx.Set<TypeEntity>().AsQueryable().Where(p => p.Id == Id).FirstOrDefault();
                    var QuestionString = "Пометить на удаление?";
                    if (Element.IsMarkedForDeletion) {
                        QuestionString = "Снять пометку на удаление?";
                    }

                    if (MessageBox.Show(this, QuestionString, QuestionString, MessageBoxButtons.YesNoCancel) == DialogResult.Yes) {
                        Element.IsMarkedForDeletion = !Element.IsMarkedForDeletion;
                        ctx.SaveChanges();
                    }
                    ctx.Dispose();
                    LoadTable();
                }
            }
                
            if (SetFormProperties) {
                NewForm.MdiParent = this.MdiParent;
                NewForm.FormClosed += new FormClosedEventHandler(OnChildFormClosed);
                NewForm.Show();
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
            if (MyDataGridView.Columns.Contains("PasswordMD5")) {
                MyDataGridView.Columns["PasswordMD5"].Visible = false;
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
