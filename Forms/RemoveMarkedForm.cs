using EquipmentManagement.Model;
using EquipmentManagement.Model.Documents;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.Entity;
using System.Windows.Forms;
using System.Drawing;

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
                    ConsoleRTB.AppendText(Text);
                    ConsoleRTB.SelectionColor = ConsoleRTB.ForeColor;
                    ConsoleRTB.ScrollToCaret();
                });
            });
        }

        void RemoveDocs() {
            var ctx = new EMContext();
            int DocsCount = 0;
            var WriteOffs = ctx.WriteOffs.Where(s => s.IsMarkedForDeletion).Include(p => p.Rows).ToList();
            DocsCount += WriteOffs.Count;
            ctx.WriteOffs.RemoveRange(WriteOffs);

            var Movements = ctx.Movements.Where(s => s.IsMarkedForDeletion).Include(p => p.Rows).ToList();
            DocsCount += Movements.Count;
            ctx.Movements.RemoveRange(Movements);

            var Purchasings = ctx.Purchasings.Where(s => s.IsMarkedForDeletion).Include(p => p.Rows).ToList();
            DocsCount += Purchasings.Count;
            ctx.Purchasings.RemoveRange(Purchasings);

            var Rrequirements = ctx.Requirements.Where(s => s.IsMarkedForDeletion).Include(p => p.Rows).ToList();
            DocsCount += Rrequirements.Count;
            ctx.Requirements.RemoveRange(Rrequirements);

            ctx.SaveChanges();
            ctx.Dispose();
            TextToConsoleRTB("Удалено документов " + DocsCount.ToString(), Color.Black);
        }
        void RemoveCatalogs() {
            var ctx = new EMContext();
            int DocsCount = 0;
            
            ctx.SaveChanges();
            ctx.Dispose();
            TextToConsoleRTB("Удалено помеченых элементов справочников " + DocsCount.ToString(), Color.Black);
        }

    }
}
