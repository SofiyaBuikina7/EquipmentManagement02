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
            this.MainListDGV = new EquipmentManagement.Forms.MyDGV();
            ((System.ComponentModel.ISupportInitialize)(this.MainListDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // MainListDGV
            // 
            this.MainListDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainListDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainListDGV.Location = new System.Drawing.Point(0, 35);
            this.MainListDGV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MainListDGV.Name = "MainListDGV";
            this.MainListDGV.RowHeadersWidth = 51;
            this.MainListDGV.Size = new System.Drawing.Size(1067, 519);
            this.MainListDGV.TabIndex = 0;
            this.MainListDGV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainListDGV_KeyDown);
            // 
            // ElementsTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.MainListDGV);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ElementsTableForm";
            this.Text = "Need";
            ((System.ComponentModel.ISupportInitialize)(this.MainListDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MyDGV MainListDGV;
    }
}