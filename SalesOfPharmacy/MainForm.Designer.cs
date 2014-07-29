namespace SalesOfPharmacy
{
    partial class MainForm
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
            this.menu = new System.Windows.Forms.MenuStrip();
            this.mi_Files = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_Chains = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_POS = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_Drug = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_MD = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_MD_Drugs = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_MD_POSes = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_Reports = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_Report_Sales = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_Window = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_Files,
            this.mi_Chains,
            this.mi_POS,
            this.mi_Drug,
            this.mi_MD,
            this.mi_Reports,
            this.mi_Window});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.MdiWindowListItem = this.mi_Window;
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(871, 24);
            this.menu.TabIndex = 1;
            this.menu.Text = "menuStrip1";
            // 
            // mi_Files
            // 
            this.mi_Files.Name = "mi_Files";
            this.mi_Files.Size = new System.Drawing.Size(105, 20);
            this.mi_Files.Text = "Список файлов";
            this.mi_Files.Click += new System.EventHandler(this.mi_Files_Click);
            // 
            // mi_Chains
            // 
            this.mi_Chains.Name = "mi_Chains";
            this.mi_Chains.Size = new System.Drawing.Size(101, 20);
            this.mi_Chains.Text = "Аптечные сети";
            this.mi_Chains.Click += new System.EventHandler(this.mi_Chains_Click);
            // 
            // mi_POS
            // 
            this.mi_POS.Name = "mi_POS";
            this.mi_POS.Size = new System.Drawing.Size(98, 20);
            this.mi_POS.Text = "Точки продаж";
            this.mi_POS.Click += new System.EventHandler(this.mi_POS_Click);
            // 
            // mi_Drug
            // 
            this.mi_Drug.Name = "mi_Drug";
            this.mi_Drug.Size = new System.Drawing.Size(81, 20);
            this.mi_Drug.Text = "Препараты";
            this.mi_Drug.Click += new System.EventHandler(this.mi_Drug_Click);
            // 
            // mi_MD
            // 
            this.mi_MD.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_MD_Drugs,
            this.mi_MD_POSes});
            this.mi_MD.Name = "mi_MD";
            this.mi_MD.Size = new System.Drawing.Size(116, 20);
            this.mi_MD.Text = "Ключевые фразы";
            // 
            // mi_MD_Drugs
            // 
            this.mi_MD_Drugs.Name = "mi_MD_Drugs";
            this.mi_MD_Drugs.Size = new System.Drawing.Size(163, 22);
            this.mi_MD_Drugs.Text = "Препараты";
            this.mi_MD_Drugs.Click += new System.EventHandler(this.mi_MD_Drugs_Click);
            // 
            // mi_MD_POSes
            // 
            this.mi_MD_POSes.Name = "mi_MD_POSes";
            this.mi_MD_POSes.Size = new System.Drawing.Size(163, 22);
            this.mi_MD_POSes.Text = "Торговые точки";
            this.mi_MD_POSes.Click += new System.EventHandler(this.mi_MD_POSes_Click);
            // 
            // mi_Reports
            // 
            this.mi_Reports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_Report_Sales});
            this.mi_Reports.Name = "mi_Reports";
            this.mi_Reports.Size = new System.Drawing.Size(60, 20);
            this.mi_Reports.Text = "Отчеты";
            // 
            // mi_Report_Sales
            // 
            this.mi_Report_Sales.Name = "mi_Report_Sales";
            this.mi_Report_Sales.Size = new System.Drawing.Size(125, 22);
            this.mi_Report_Sales.Text = "Продажи";
            this.mi_Report_Sales.Click += new System.EventHandler(this.mi_Report_Sales_Click);
            // 
            // mi_Window
            // 
            this.mi_Window.Name = "mi_Window";
            this.mi_Window.Size = new System.Drawing.Size(48, 20);
            this.mi_Window.Text = "Окно";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 303);
            this.Controls.Add(this.menu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menu;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem mi_Files;
        private System.Windows.Forms.ToolStripMenuItem mi_Chains;
        private System.Windows.Forms.ToolStripMenuItem mi_Drug;
        private System.Windows.Forms.ToolStripMenuItem mi_MD;
        private System.Windows.Forms.ToolStripMenuItem mi_MD_Drugs;
        private System.Windows.Forms.ToolStripMenuItem mi_MD_POSes;
        private System.Windows.Forms.ToolStripMenuItem mi_POS;
        private System.Windows.Forms.ToolStripMenuItem mi_Reports;
        private System.Windows.Forms.ToolStripMenuItem mi_Report_Sales;
        private System.Windows.Forms.ToolStripMenuItem mi_Window;
    }
}

