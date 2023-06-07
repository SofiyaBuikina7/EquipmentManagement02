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
    public partial class ElementForm<TypeEntity> : Form where TypeEntity :TableElement, new(){
        TableElement MyElement;
        EMContext ctx = new EMContext();
        public ElementForm(int ElementID = -1, bool NeedCopy = false) {
            

            InitializeComponent();
            this.Text = Utils.GetTableNameTranslation<TypeEntity>(); 
            
            if (ElementID == -1) {
                MyElement = new TypeEntity();
            } else {
                var query = ctx.Set<TypeEntity>().AsQueryable();
                MyElement = (TableElement)query.Where(t => t.Id == ElementID).FirstOrDefault();
            }
            int offset = 5;
            int Y = PatternLb.Top;
            var Props = MyElement.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            for (int i = Props.Length - 1; i >= 0; i--) {
                var Prop = Props[i];
                if (!(Prop.Name.Equals("Id") || Prop.Name.Equals("IsMarkedForDeletion"))) {
                    Control PropTb = null;

                    if (Props[i].PropertyType.BaseType == typeof(Catalog)) {
                        PropTb = PatternCb.Clone();
                        var Value = Prop.GetValue(MyElement);
                        if (Props[i].PropertyType == typeof(Unit)) {
                            ((ComboBox)PropTb).DataSource = ctx.Units.ToList();
                            
                        }
                        if (Props[i].PropertyType == typeof(Category)) {
                            ((ComboBox)PropTb).DataSource = ctx.Categorys.ToList();
                        }

                        ((ComboBox)PropTb).SelectedItem = Prop.GetValue(MyElement);
                    } else {
                        PropTb = PatternTb.Clone();
                        var Text = Prop.GetValue(MyElement);
                        if (Text != null) {
                            PropTb.Text = Prop.GetValue(MyElement).ToString();
                        }
                    }

                    var PropLb = PatternLb.Clone();
                    
                    PropTb.Name = Prop.Name + "Tb";
                    PropLb.Top = Y;
                    PropTb.Top = Y;

                    PropLb.Text = Utils.GetColumnTranslation<TypeEntity>(Prop.Name);

                    Y += PatternTb.Height + offset;
                    PropLb.Visible = true;
                    PropTb.Visible = true;
                    this.Controls.Add(PropLb);
                    this.Controls.Add(PropTb);
                }
            }
            PatternLb.Visible = false;
            PatternTb.Visible = false;
            if (NeedCopy) {
                ctx.Dispose();
                ctx = new EMContext();
                ElementID = -1;
                MyElement = new TypeEntity();
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e) {
            Save();
        }

        private void Save() {
            var Props = MyElement.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            for (int i = Props.Length - 1; i >= 0; i--) {
                var Prop = Props[i];
                if (Props[i].PropertyType.BaseType == typeof(Catalog)) {
                    if (Props[i].PropertyType == typeof(Unit)) {
                        Prop.SetValue(MyElement, ((ComboBox)Controls[Prop.Name + "Tb"]).SelectedItem);
                    }
                    if (Props[i].PropertyType == typeof(Category)) {
                        Prop.SetValue(MyElement, ((ComboBox)Controls[Prop.Name + "Tb"]).SelectedItem);
                    }
                } else {
                    if (!(Prop.Name.Equals("Id") || Prop.Name.Equals("IsMarkedForDeletion"))) {
                        Prop.SetValue(MyElement, Controls[Prop.Name + "Tb"].Text);
                    }
                }
            }

            if (MyElement.Id == 0) {
                ctx.Set<TypeEntity>().Add((TypeEntity)MyElement);
            }
            ctx.SaveChanges();
        }

        private void SaveAndExit_Click(object sender, EventArgs e) {
            Save();
            this.Close();
        }
    }
}
