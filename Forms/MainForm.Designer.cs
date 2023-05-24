
namespace EquipmentManagement {
    partial class MainForm {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.документыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.потребностьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закупкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списаниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.категорииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оборудываниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ответственныеЗаТехникуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.местаРасположенияТехникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.единицыИзмеренияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.пользователиToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.документыToolStripMenuItem,
            this.справочникToolStripMenuItem,
            this.настройкиToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(593, 24);
            this.MainMenu.TabIndex = 2;
            this.MainMenu.Text = "menuStrip1";
            // 
            // документыToolStripMenuItem
            // 
            this.документыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.потребностьToolStripMenuItem,
            this.закупкаToolStripMenuItem,
            this.списаниеToolStripMenuItem});
            this.документыToolStripMenuItem.Name = "документыToolStripMenuItem";
            this.документыToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.документыToolStripMenuItem.Text = "Документы";
            // 
            // потребностьToolStripMenuItem
            // 
            this.потребностьToolStripMenuItem.Name = "потребностьToolStripMenuItem";
            this.потребностьToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.потребностьToolStripMenuItem.Text = "Потребность";
            this.потребностьToolStripMenuItem.Click += new System.EventHandler(this.потребностьToolStripMenuItem_Click);
            // 
            // закупкаToolStripMenuItem
            // 
            this.закупкаToolStripMenuItem.Name = "закупкаToolStripMenuItem";
            this.закупкаToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.закупкаToolStripMenuItem.Text = "Закупка";
            this.закупкаToolStripMenuItem.Click += new System.EventHandler(this.закупкаToolStripMenuItem_Click);
            // 
            // списаниеToolStripMenuItem
            // 
            this.списаниеToolStripMenuItem.Name = "списаниеToolStripMenuItem";
            this.списаниеToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.списаниеToolStripMenuItem.Text = "Списание";
            this.списаниеToolStripMenuItem.Click += new System.EventHandler(this.списаниеToolStripMenuItem_Click);
            // 
            // справочникToolStripMenuItem
            // 
            this.справочникToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.категорииToolStripMenuItem,
            this.оборудываниеToolStripMenuItem,
            this.ответственныеЗаТехникуToolStripMenuItem,
            this.местаРасположенияТехникиToolStripMenuItem,
            this.единицыИзмеренияToolStripMenuItem});
            this.справочникToolStripMenuItem.Name = "справочникToolStripMenuItem";
            this.справочникToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.справочникToolStripMenuItem.Text = "Справочник";
            // 
            // категорииToolStripMenuItem
            // 
            this.категорииToolStripMenuItem.Name = "категорииToolStripMenuItem";
            this.категорииToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.категорииToolStripMenuItem.Text = "Категории";
            this.категорииToolStripMenuItem.Click += new System.EventHandler(this.категорииToolStripMenuItem_Click);
            // 
            // оборудываниеToolStripMenuItem
            // 
            this.оборудываниеToolStripMenuItem.Name = "оборудываниеToolStripMenuItem";
            this.оборудываниеToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.оборудываниеToolStripMenuItem.Text = "Оборудование";
            this.оборудываниеToolStripMenuItem.Click += new System.EventHandler(this.оборудываниеToolStripMenuItem_Click);
            // 
            // ответственныеЗаТехникуToolStripMenuItem
            // 
            this.ответственныеЗаТехникуToolStripMenuItem.Name = "ответственныеЗаТехникуToolStripMenuItem";
            this.ответственныеЗаТехникуToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.ответственныеЗаТехникуToolStripMenuItem.Text = "Ответственные за технику";
            this.ответственныеЗаТехникуToolStripMenuItem.Click += new System.EventHandler(this.ответственныеЗаТехникуToolStripMenuItem_Click);
            // 
            // местаРасположенияТехникиToolStripMenuItem
            // 
            this.местаРасположенияТехникиToolStripMenuItem.Name = "местаРасположенияТехникиToolStripMenuItem";
            this.местаРасположенияТехникиToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.местаРасположенияТехникиToolStripMenuItem.Text = "Места расположения техники";
            this.местаРасположенияТехникиToolStripMenuItem.Click += new System.EventHandler(this.местаРасположенияТехникиToolStripMenuItem_Click);
            // 
            // единицыИзмеренияToolStripMenuItem
            // 
            this.единицыИзмеренияToolStripMenuItem.Name = "единицыИзмеренияToolStripMenuItem";
            this.единицыИзмеренияToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.единицыИзмеренияToolStripMenuItem.Text = "Единицы измерения";
            this.единицыИзмеренияToolStripMenuItem.Click += new System.EventHandler(this.единицыИзмеренияToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиToolStripMenuItem1,
            this.пользователиToolStripMenuItem1});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // настройкиToolStripMenuItem1
            // 
            this.настройкиToolStripMenuItem1.Name = "настройкиToolStripMenuItem1";
            this.настройкиToolStripMenuItem1.Size = new System.Drawing.Size(203, 22);
            this.настройкиToolStripMenuItem1.Text = "Настройки программы";
            this.настройкиToolStripMenuItem1.Click += new System.EventHandler(this.настройкиToolStripMenuItem1_Click);
            // 
            // пользователиToolStripMenuItem1
            // 
            this.пользователиToolStripMenuItem1.Name = "пользователиToolStripMenuItem1";
            this.пользователиToolStripMenuItem1.Size = new System.Drawing.Size(203, 22);
            this.пользователиToolStripMenuItem1.Text = "Пользователи";
            this.пользователиToolStripMenuItem1.Click += new System.EventHandler(this.пользователиToolStripMenuItem1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 450);
            this.Controls.Add(this.MainMenu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem потребностьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закупкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списаниеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справочникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem категорииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оборудываниеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem документыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ответственныеЗаТехникуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem пользователиToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem местаРасположенияТехникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem единицыИзмеренияToolStripMenuItem;
    }
}

