namespace Курсовой_по_ОПП
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.играToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.стопToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.стартToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.начатьНовуюИгруToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выборУровняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.уровень1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.уровень2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.уровень3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.уровень4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Beige;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.играToolStripMenuItem,
            this.выборУровняToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(543, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // играToolStripMenuItem
            // 
            this.играToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.стопToolStripMenuItem,
            this.стартToolStripMenuItem,
            this.начатьНовуюИгруToolStripMenuItem});
            this.играToolStripMenuItem.Name = "играToolStripMenuItem";
            this.играToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.играToolStripMenuItem.Text = "Игра";
            // 
            // стопToolStripMenuItem
            // 
            this.стопToolStripMenuItem.Name = "стопToolStripMenuItem";
            this.стопToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.стопToolStripMenuItem.Text = "Стоп";
            this.стопToolStripMenuItem.Click += new System.EventHandler(this.стопToolStripMenuItem_Click);
            // 
            // стартToolStripMenuItem
            // 
            this.стартToolStripMenuItem.Name = "стартToolStripMenuItem";
            this.стартToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.стартToolStripMenuItem.Text = "Старт";
            this.стартToolStripMenuItem.Click += new System.EventHandler(this.стартToolStripMenuItem_Click);
            // 
            // начатьНовуюИгруToolStripMenuItem
            // 
            this.начатьНовуюИгруToolStripMenuItem.Name = "начатьНовуюИгруToolStripMenuItem";
            this.начатьНовуюИгруToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.начатьНовуюИгруToolStripMenuItem.Text = "Начать новую игру";
            this.начатьНовуюИгруToolStripMenuItem.Click += new System.EventHandler(this.начатьНовуюИгруToolStripMenuItem_Click);
            // 
            // выборУровняToolStripMenuItem
            // 
            this.выборУровняToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.уровень1ToolStripMenuItem,
            this.уровень2ToolStripMenuItem,
            this.уровень3ToolStripMenuItem,
            this.уровень4ToolStripMenuItem});
            this.выборУровняToolStripMenuItem.Name = "выборУровняToolStripMenuItem";
            this.выборУровняToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.выборУровняToolStripMenuItem.Text = "Выбор уровня";
            // 
            // уровень1ToolStripMenuItem
            // 
            this.уровень1ToolStripMenuItem.Name = "уровень1ToolStripMenuItem";
            this.уровень1ToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.уровень1ToolStripMenuItem.Text = "Уровень 1";
            this.уровень1ToolStripMenuItem.Click += new System.EventHandler(this.уровень1ToolStripMenuItem_Click);
            // 
            // уровень2ToolStripMenuItem
            // 
            this.уровень2ToolStripMenuItem.Name = "уровень2ToolStripMenuItem";
            this.уровень2ToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.уровень2ToolStripMenuItem.Text = "Уровень 2";
            this.уровень2ToolStripMenuItem.Click += new System.EventHandler(this.уровень2ToolStripMenuItem_Click);
            // 
            // уровень3ToolStripMenuItem
            // 
            this.уровень3ToolStripMenuItem.Name = "уровень3ToolStripMenuItem";
            this.уровень3ToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.уровень3ToolStripMenuItem.Text = "Уровень 3";
            this.уровень3ToolStripMenuItem.Click += new System.EventHandler(this.уровень3ToolStripMenuItem_Click);
            // 
            // уровень4ToolStripMenuItem
            // 
            this.уровень4ToolStripMenuItem.Name = "уровень4ToolStripMenuItem";
            this.уровень4ToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.уровень4ToolStripMenuItem.Text = "Уровень 4";
            this.уровень4ToolStripMenuItem.Click += new System.EventHandler(this.уровень4ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(543, 644);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(232, 323);
            this.Name = "Form1";
            this.Text = "Тетрис";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem играToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem стопToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem стартToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выборУровняToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem уровень1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem уровень2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem уровень3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem уровень4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem начатьНовуюИгруToolStripMenuItem;
    }
}

