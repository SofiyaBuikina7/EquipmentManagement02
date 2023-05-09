
namespace EquipmentManagement.Forms {
    partial class SettingsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.ApplyLicenseBtn = new System.Windows.Forms.Button();
            this.EvenRowDisplayTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ChoseFontBtn = new System.Windows.Forms.Button();
            this.EvenForeColorTb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.EvenBackColorTb = new System.Windows.Forms.TextBox();
            this.OddBackColorTb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.OddForeColorTb = new System.Windows.Forms.TextBox();
            this.OddRowDisplayTb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ApplyLicenseBtn
            // 
            this.ApplyLicenseBtn.Location = new System.Drawing.Point(432, 207);
            this.ApplyLicenseBtn.Name = "ApplyLicenseBtn";
            this.ApplyLicenseBtn.Size = new System.Drawing.Size(75, 23);
            this.ApplyLicenseBtn.TabIndex = 4;
            this.ApplyLicenseBtn.Text = "Сохранить";
            this.ApplyLicenseBtn.UseVisualStyleBackColor = true;
            this.ApplyLicenseBtn.Click += new System.EventHandler(this.ApplyLicenseBtn_Click);
            // 
            // EvenRowDisplayTb
            // 
            this.EvenRowDisplayTb.BackColor = System.Drawing.Color.White;
            this.EvenRowDisplayTb.Location = new System.Drawing.Point(83, 12);
            this.EvenRowDisplayTb.Name = "EvenRowDisplayTb";
            this.EvenRowDisplayTb.ReadOnly = true;
            this.EvenRowDisplayTb.Size = new System.Drawing.Size(393, 20);
            this.EvenRowDisplayTb.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-2, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Шрифт таблиц";
            // 
            // ChoseFontBtn
            // 
            this.ChoseFontBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChoseFontBtn.Location = new System.Drawing.Point(474, 10);
            this.ChoseFontBtn.Name = "ChoseFontBtn";
            this.ChoseFontBtn.Size = new System.Drawing.Size(33, 23);
            this.ChoseFontBtn.TabIndex = 8;
            this.ChoseFontBtn.Text = "...";
            this.ChoseFontBtn.UseVisualStyleBackColor = true;
            this.ChoseFontBtn.Click += new System.EventHandler(this.ChoseFontBtn_Click);
            // 
            // EvenForeColorTb
            // 
            this.EvenForeColorTb.BackColor = System.Drawing.Color.White;
            this.EvenForeColorTb.Location = new System.Drawing.Point(115, 109);
            this.EvenForeColorTb.Name = "EvenForeColorTb";
            this.EvenForeColorTb.ReadOnly = true;
            this.EvenForeColorTb.Size = new System.Drawing.Size(34, 20);
            this.EvenForeColorTb.TabIndex = 9;
            this.EvenForeColorTb.DoubleClick += new System.EventHandler(this.EvenForeColorTb_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-2, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Цвета нечетных строк";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(112, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Текст";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(152, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Фон";
            // 
            // EvenBackColorTb
            // 
            this.EvenBackColorTb.BackColor = System.Drawing.Color.White;
            this.EvenBackColorTb.Location = new System.Drawing.Point(155, 109);
            this.EvenBackColorTb.Name = "EvenBackColorTb";
            this.EvenBackColorTb.ReadOnly = true;
            this.EvenBackColorTb.Size = new System.Drawing.Size(34, 20);
            this.EvenBackColorTb.TabIndex = 12;
            this.EvenBackColorTb.DoubleClick += new System.EventHandler(this.EvenBackColorTb_DoubleClick);
            // 
            // OddBackColorTb
            // 
            this.OddBackColorTb.BackColor = System.Drawing.Color.White;
            this.OddBackColorTb.Location = new System.Drawing.Point(155, 133);
            this.OddBackColorTb.Name = "OddBackColorTb";
            this.OddBackColorTb.ReadOnly = true;
            this.OddBackColorTb.Size = new System.Drawing.Size(34, 20);
            this.OddBackColorTb.TabIndex = 16;
            this.OddBackColorTb.DoubleClick += new System.EventHandler(this.OddBackColorTb_DoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-2, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Цвета четных строк";
            // 
            // OddForeColorTb
            // 
            this.OddForeColorTb.BackColor = System.Drawing.Color.White;
            this.OddForeColorTb.Location = new System.Drawing.Point(115, 133);
            this.OddForeColorTb.Name = "OddForeColorTb";
            this.OddForeColorTb.ReadOnly = true;
            this.OddForeColorTb.Size = new System.Drawing.Size(34, 20);
            this.OddForeColorTb.TabIndex = 14;
            this.OddForeColorTb.DoubleClick += new System.EventHandler(this.OddForeColorTb_DoubleClick);
            // 
            // OddRowDisplayTb
            // 
            this.OddRowDisplayTb.BackColor = System.Drawing.Color.White;
            this.OddRowDisplayTb.Location = new System.Drawing.Point(83, 56);
            this.OddRowDisplayTb.Name = "OddRowDisplayTb";
            this.OddRowDisplayTb.ReadOnly = true;
            this.OddRowDisplayTb.Size = new System.Drawing.Size(393, 20);
            this.OddRowDisplayTb.TabIndex = 17;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 238);
            this.Controls.Add(this.OddRowDisplayTb);
            this.Controls.Add(this.OddBackColorTb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.OddForeColorTb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.EvenBackColorTb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EvenForeColorTb);
            this.Controls.Add(this.ChoseFontBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EvenRowDisplayTb);
            this.Controls.Add(this.ApplyLicenseBtn);
            this.Name = "SettingsForm";
            this.Text = "Настройки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ApplyLicenseBtn;
        private System.Windows.Forms.TextBox EvenRowDisplayTb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ChoseFontBtn;
        private System.Windows.Forms.TextBox EvenForeColorTb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox EvenBackColorTb;
        private System.Windows.Forms.TextBox OddBackColorTb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox OddForeColorTb;
        private System.Windows.Forms.TextBox OddRowDisplayTb;
    }
}