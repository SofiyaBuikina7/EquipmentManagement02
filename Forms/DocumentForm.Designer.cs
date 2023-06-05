using EquipmentManagement.Forms;

namespace EquipmentManagement
{
    partial class DocumentForm<TypeEntity>
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
        public void InitializeComponent()
        {
            this.MainListDGV = new EquipmentManagement.Forms.MyDGV();
            this.DocDateDTP = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DocNoTB = new System.Windows.Forms.TextBox();
            this.AuthorCB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MainListDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // MainListDGV
            // 
            this.MainListDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainListDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainListDGV.Location = new System.Drawing.Point(0, 143);
            this.MainListDGV.Name = "MainListDGV";
            this.MainListDGV.RowHeadersWidth = 51;
            this.MainListDGV.Size = new System.Drawing.Size(800, 307);
            this.MainListDGV.TabIndex = 0;
            this.MainListDGV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainListDGV_KeyDown);
            // 
            // DocDateDTP
            // 
            this.DocDateDTP.CustomFormat = "dd.MMMM.yyyy hh:mm:ss";
            this.DocDateDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DocDateDTP.Location = new System.Drawing.Point(113, 10);
            this.DocDateDTP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DocDateDTP.Name = "DocDateDTP";
            this.DocDateDTP.Size = new System.Drawing.Size(212, 20);
            this.DocDateDTP.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Дата документа";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Номер документа";
            // 
            // DocNoTB
            // 
            this.DocNoTB.Location = new System.Drawing.Point(113, 35);
            this.DocNoTB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DocNoTB.Name = "DocNoTB";
            this.DocNoTB.Size = new System.Drawing.Size(212, 20);
            this.DocNoTB.TabIndex = 4;
            // 
            // AuthorCB
            // 
            this.AuthorCB.FormattingEnabled = true;
            this.AuthorCB.Location = new System.Drawing.Point(422, 8);
            this.AuthorCB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AuthorCB.Name = "AuthorCB";
            this.AuthorCB.Size = new System.Drawing.Size(261, 21);
            this.AuthorCB.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(328, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Автор";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(422, 33);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(261, 20);
            this.textBox1.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(328, 36);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Коментарий";
            // 
            // DocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AuthorCB);
            this.Controls.Add(this.DocNoTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DocDateDTP);
            this.Controls.Add(this.MainListDGV);
            this.Name = "DocumentForm";
            this.Text = "Document";
            ((System.ComponentModel.ISupportInitialize)(this.MainListDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker DocDateDTP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DocNoTB;
        private System.Windows.Forms.ComboBox AuthorCB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        public MyDGV MainListDGV;
    }
}