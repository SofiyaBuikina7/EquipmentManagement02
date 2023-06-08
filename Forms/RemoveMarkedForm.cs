using EquipmentManagement.Model;
using EquipmentManagement.Model.Documents;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.Entity;
using System.Windows.Forms;
using System.Drawing;
using EquipmentManagement.Model.Catalogs;

namespace EquipmentManagement.Forms {
    public partial class RemoveMarkedForm : Form {
        public RemoveMarkedForm() {
            InitializeComponent();
        }

        private void RemoveBtn_Click(object sender, EventArgs e) {
            if (MessageBox.Show(this, "Удалить помеченные на удаление объекты из базы данных?", "Удалить помеченные на удаление объекты из базы данных?", MessageBoxButtons.YesNoCancel) == DialogResult.Yes) {
                RemoveMarked();
            }
        }

        void RemoveMarked() {
            TextToConsoleRTB("Начато удаление помеченных документов", Color.Red);
            RemoveDocs();
            TextToConsoleRTB("Начато удаление помеченых элементов справочников", Color.Red);
            RemoveCatalogs();
        }
            
        public void TextToConsoleRTB(string Text, Color color) {
            if (!this.IsHandleCreated || this.IsDisposed) return;

            // Invoke an anonymous method on the thread of the form.
            this.Invoke((MethodInvoker)delegate {
                if (!this.IsHandleCreated || this.IsDisposed) return;

                // Invoke an anonymous method on the thread of the form.
                this.Invoke((MethodInvoker)delegate {
                    ConsoleRTB.SelectionStart = ConsoleRTB.TextLength;
                    ConsoleRTB.SelectionLength = 0;
                    ConsoleRTB.SelectionColor = color;
                    ConsoleRTB.AppendText(Text + "\n");
                    ConsoleRTB.SelectionColor = ConsoleRTB.ForeColor;
                    ConsoleRTB.ScrollToCaret();
                });
            });
        }

        void RemoveDocs() {
            int RemovedCount = 0;
            RemovedCount += RemoveElements<WriteOff>();
            RemovedCount += RemoveElements<Movement>();
            RemovedCount += RemoveElements<Purchasing>();
            RemovedCount += RemoveElements<Requirement>();

            TextToConsoleRTB("Удалено документов " + RemovedCount.ToString(), Color.Black);
        }
        
        int RemoveElements<DocType>() where DocType : TableElement {
            var ctx = new EMContext();
            int RemovedCount = 0;
            var ListToRemove = ctx.Set<DocType>().AsQueryable().Where(s => s.IsMarkedForDeletion).ToList();
            

            foreach (var item in ListToRemove) {
                ctx.Set<DocType>().Remove(item);
                try {
                    ctx.SaveChanges();
                    RemovedCount += ListToRemove.Count;
                } catch (Exception e) {
                    TextToConsoleRTB("Ошибка удвления " + item.ToString(), Color.Red);
                }
            }
            return RemovedCount;
        }

        void RemoveCatalogs() {
            int RemovedCount = 0;
            RemovedCount += RemoveElements<Equipment>();
            
            RemovedCount += RemoveElements<Category>();
            RemovedCount += RemoveElements<Unit>();
            RemovedCount += RemoveElements<InstallationLocation>();
            RemovedCount += RemoveElements<ResponsiblePerson>();
            RemovedCount += RemoveElements<User>();

            TextToConsoleRTB("Удалено помеченых элементов справочников " + RemovedCount.ToString(), Color.Black);
        }

        //Old Deletion
        //var Rrequirements = ctx.Requirements.Where(s => s.IsMarkedForDeletion).Include(p => p.Rows).ToList();
        //RemovedCount += Rrequirements.Count;
        //ctx.Requirements.RemoveRange(Rrequirements);

    }
}
