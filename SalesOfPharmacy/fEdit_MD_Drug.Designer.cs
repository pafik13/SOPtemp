namespace SalesOfPharmacy
{
    partial class fEdit_MD_Drug
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
            this.cb_mdDrug = new System.Windows.Forms.ComboBox();
            this.lbl_mdDrug = new System.Windows.Forms.Label();
            this.lblDrug = new System.Windows.Forms.Label();
            this.txt_MD_Drug = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cb_mdDrug
            // 
            this.cb_mdDrug.FormattingEnabled = true;
            this.cb_mdDrug.Location = new System.Drawing.Point(99, 38);
            this.cb_mdDrug.Name = "cb_mdDrug";
            this.cb_mdDrug.Size = new System.Drawing.Size(300, 21);
            this.cb_mdDrug.TabIndex = 9;
            // 
            // lbl_mdDrug
            // 
            this.lbl_mdDrug.AutoSize = true;
            this.lbl_mdDrug.Location = new System.Drawing.Point(12, 41);
            this.lbl_mdDrug.Name = "lbl_mdDrug";
            this.lbl_mdDrug.Size = new System.Drawing.Size(59, 13);
            this.lbl_mdDrug.TabIndex = 8;
            this.lbl_mdDrug.Text = "Препарат:";
            // 
            // lblDrug
            // 
            this.lblDrug.AutoSize = true;
            this.lblDrug.Location = new System.Drawing.Point(12, 15);
            this.lblDrug.Name = "lblDrug";
            this.lblDrug.Size = new System.Drawing.Size(74, 13);
            this.lblDrug.TabIndex = 7;
            this.lblDrug.Text = "Ключ. фраза:";
            // 
            // txt_MD_Drug
            // 
            this.txt_MD_Drug.Location = new System.Drawing.Point(99, 12);
            this.txt_MD_Drug.Name = "txt_MD_Drug";
            this.txt_MD_Drug.Size = new System.Drawing.Size(300, 20);
            this.txt_MD_Drug.TabIndex = 6;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(300, 67);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(200, 67);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // fEdit_MD_Drug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 92);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cb_mdDrug);
            this.Controls.Add(this.lbl_mdDrug);
            this.Controls.Add(this.lblDrug);
            this.Controls.Add(this.txt_MD_Drug);
            this.MaximumSize = new System.Drawing.Size(600, 130);
            this.MinimumSize = new System.Drawing.Size(430, 130);
            this.Name = "fEdit_MD_Drug";
            this.Text = "fEditDrug";
            this.Shown += new System.EventHandler(this.fEditDrug_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_mdDrug;
        private System.Windows.Forms.Label lbl_mdDrug;
        private System.Windows.Forms.Label lblDrug;
        private System.Windows.Forms.TextBox txt_MD_Drug;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}