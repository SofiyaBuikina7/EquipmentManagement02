
namespace EquipmentManagement.Forms {
    partial class RemoveMarkedForm {
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
            this.ConsoleRTB = new System.Windows.Forms.RichTextBox();
            this.RemoveBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ConsoleRTB
            // 
            this.ConsoleRTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConsoleRTB.Location = new System.Drawing.Point(-6, 1);
            this.ConsoleRTB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ConsoleRTB.Name = "ConsoleRTB";
            this.ConsoleRTB.Size = new System.Drawing.Size(461, 421);
            this.ConsoleRTB.TabIndex = 14;
            this.ConsoleRTB.Text = "";
            // 
            // RemoveBtn
            // 
            this.RemoveBtn.Location = new System.Drawing.Point(3, 427);
            this.RemoveBtn.Name = "RemoveBtn";
            this.RemoveBtn.Size = new System.Drawing.Size(452, 25);
            this.RemoveBtn.TabIndex = 15;
            this.RemoveBtn.Text = "Удалить помеченные на удаление объекты";
            this.RemoveBtn.UseVisualStyleBackColor = true;
            this.RemoveBtn.Click += new System.EventHandler(this.RemoveBtn_Click);
            // 
            // RemoveMarkedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 450);
            this.Controls.Add(this.RemoveBtn);
            this.Controls.Add(this.ConsoleRTB);
            this.Name = "RemoveMarkedForm";
            this.Text = "RemoveMarkedForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox ConsoleRTB;
        private System.Windows.Forms.Button RemoveBtn;
    }
}