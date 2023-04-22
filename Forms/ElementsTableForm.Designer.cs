using EquipmentManagement.Forms;

namespace EquipmentManagement
{
    partial class ElementsTableForm<TypeEntity>
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainListDGV = new MyDGV();
            ((System.ComponentModel.ISupportInitialize)(this.MainListDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // MainListDGV
            // 
            this.MainListDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainListDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainListDGV.Location = new System.Drawing.Point(0, 0);
            this.MainListDGV.Name = "MainListDGV";
            this.MainListDGV.Size = new System.Drawing.Size(800, 450);
            this.MainListDGV.TabIndex = 0;
            this.MainListDGV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainListDGV_KeyDown);
            // 
            // ElementsTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainListDGV);
            this.Name = "ElementsTableForm";
            this.Text = "Need";
            ((System.ComponentModel.ISupportInitialize)(this.MainListDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MyDGV MainListDGV;
    }
}