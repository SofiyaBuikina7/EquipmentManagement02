
namespace EquipmentManagement.Forms {
    partial class ElementForm<TypeEntity> {
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
            this.PatternTb = new System.Windows.Forms.TextBox();
            this.PatternLb = new System.Windows.Forms.Label();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.SaveAndExit = new System.Windows.Forms.Button();
            this.PatternCb = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // PatternTb
            // 
            this.PatternTb.Location = new System.Drawing.Point(165, 12);
            this.PatternTb.Name = "PatternTb";
            this.PatternTb.Size = new System.Drawing.Size(202, 20);
            this.PatternTb.TabIndex = 0;
            // 
            // PatternLb
            // 
            this.PatternLb.AutoSize = true;
            this.PatternLb.Location = new System.Drawing.Point(12, 15);
            this.PatternLb.Name = "PatternLb";
            this.PatternLb.Size = new System.Drawing.Size(35, 13);
            this.PatternLb.TabIndex = 1;
            this.PatternLb.Text = "label1";
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(139, 175);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveBtn.TabIndex = 2;
            this.SaveBtn.Text = "Сохранить";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // SaveAndExit
            // 
            this.SaveAndExit.Location = new System.Drawing.Point(220, 175);
            this.SaveAndExit.Name = "SaveAndExit";
            this.SaveAndExit.Size = new System.Drawing.Size(147, 23);
            this.SaveAndExit.TabIndex = 3;
            this.SaveAndExit.Text = "Сохранить и выйти";
            this.SaveAndExit.UseVisualStyleBackColor = true;
            this.SaveAndExit.Click += new System.EventHandler(this.SaveAndExit_Click);
            // 
            // PatternCb
            // 
            this.PatternCb.FormattingEnabled = true;
            this.PatternCb.Location = new System.Drawing.Point(165, 38);
            this.PatternCb.Name = "PatternCb";
            this.PatternCb.Size = new System.Drawing.Size(202, 21);
            this.PatternCb.TabIndex = 4;
            this.PatternCb.Visible = false;
            // 
            // ElementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 215);
            this.Controls.Add(this.PatternCb);
            this.Controls.Add(this.SaveAndExit);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.PatternLb);
            this.Controls.Add(this.PatternTb);
            this.Name = "ElementForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PatternTb;
        private System.Windows.Forms.Label PatternLb;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button SaveAndExit;
        private System.Windows.Forms.ComboBox PatternCb;
    }
}