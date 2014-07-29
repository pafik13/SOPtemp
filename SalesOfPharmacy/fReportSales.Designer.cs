namespace SalesOfPharmacy
{
    partial class fReportSales
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
            this.tv_Periods = new System.Windows.Forms.TreeView();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tv_Periods
            // 
            this.tv_Periods.CheckBoxes = true;
            this.tv_Periods.Location = new System.Drawing.Point(12, 12);
            this.tv_Periods.Name = "tv_Periods";
            this.tv_Periods.Size = new System.Drawing.Size(351, 219);
            this.tv_Periods.TabIndex = 0;
            this.tv_Periods.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tv_Periods_AfterCheck);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(12, 237);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(91, 35);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "Сформировать";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // fReportSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 284);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.tv_Periods);
            this.Name = "fReportSales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "fReportSales";
            this.Shown += new System.EventHandler(this.fReportSales_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tv_Periods;
        private System.Windows.Forms.Button btnGenerate;
    }
}