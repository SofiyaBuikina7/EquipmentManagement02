﻿using EquipmentManagement.Forms;
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
            this.Text = Utils.GetTableNameTranslation<TypeEntity>();
            LoadTable();
            //MainListDGV.DataSource = list;
        }

        void LoadTable() {
            var ctx = new EMContext();
            var query = ctx.Set<TypeEntity>().AsQueryable();
            var MyList = query.ToList();
            MainListDGV.DataSource = MyList;
            PrepareDGV(ref MainListDGV, MyList);
            SetTablesStyle();
            ctx.Dispose();
            MainListDGV.ColumnsResize();
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