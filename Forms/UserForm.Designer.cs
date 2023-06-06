
using System.Windows.Forms;

namespace EquipmentManagement.Forms {
    partial class UserForm:Form {
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
            this.SaveBtn = new System.Windows.Forms.Button();
            this.SaveAndExit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Password2Tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Password1Tb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.NameTb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SaveBtn
            // 
            this.SaveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.SaveBtn.Location = new System.Drawing.Point(5, 177);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(160, 24);
            this.SaveBtn.TabIndex = 5;
            this.SaveBtn.Text = "Сохранить";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // SaveAndExit
            // 
            this.SaveAndExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.SaveAndExit.Location = new System.Drawing.Point(171, 177);
            this.SaveAndExit.Name = "SaveAndExit";
            this.SaveAndExit.Size = new System.Drawing.Size(160, 24);
            this.SaveAndExit.TabIndex = 4;
            this.SaveAndExit.Text = "Сохранить и выйти";
            this.SaveAndExit.UseVisualStyleBackColor = true;
            this.SaveAndExit.Click += new System.EventHandler(this.SaveAndExit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(1, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Пароль";
            // 
            // Password2Tb
            // 
            this.Password2Tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Password2Tb.Location = new System.Drawing.Point(6, 145);
            this.Password2Tb.Name = "Password2Tb";
            this.Password2Tb.PasswordChar = '*';
            this.Password2Tb.Size = new System.Drawing.Size(324, 26);
            this.Password2Tb.TabIndex = 3;
            this.Password2Tb.TextChanged += new System.EventHandler(this.Password1Tb_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(1, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Пароль";
            // 
            // Password1Tb
            // 
            this.Password1Tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Password1Tb.Location = new System.Drawing.Point(6, 93);
            this.Password1Tb.Name = "Password1Tb";
            this.Password1Tb.PasswordChar = '*';
            this.Password1Tb.Size = new System.Drawing.Size(324, 26);
            this.Password1Tb.TabIndex = 2;
            this.Password1Tb.TextChanged += new System.EventHandler(this.Password1Tb_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(2, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Имя пользователя";
            // 
            // NameTb
            // 
            this.NameTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameTb.Location = new System.Drawing.Point(7, 32);
            this.NameTb.Name = "NameTb";
            this.NameTb.Size = new System.Drawing.Size(324, 26);
            this.NameTb.TabIndex = 1;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 215);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NameTb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Password1Tb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Password2Tb);
            this.Controls.Add(this.SaveAndExit);
            this.Controls.Add(this.SaveBtn);
            this.Name = "UserForm";
            this.Text = "Пользователь";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button SaveAndExit;
        private Label label2;
        private TextBox Password2Tb;
        private Label label1;
        private TextBox Password1Tb;
        private Label label3;
        private TextBox NameTb;
    }
}