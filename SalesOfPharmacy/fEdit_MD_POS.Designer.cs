namespace SalesOfPharmacy
{
    partial class fEdit_MD_POS
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
            this.txt_MD_POS = new System.Windows.Forms.TextBox();
            this.lbl_MD_POS = new System.Windows.Forms.Label();
            this.cbChain = new System.Windows.Forms.ComboBox();
            this.lblChain = new System.Windows.Forms.Label();
            this.lblPOS = new System.Windows.Forms.Label();
            this.cbPOS = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_MD_POS
            // 
            this.txt_MD_POS.Location = new System.Drawing.Point(99, 12);
            this.txt_MD_POS.Name = "txt_MD_POS";
            this.txt_MD_POS.Size = new System.Drawing.Size(303, 20);
            this.txt_MD_POS.TabIndex = 0;
            // 
            // lbl_MD_POS
            // 
            this.lbl_MD_POS.AutoSize = true;
            this.lbl_MD_POS.Location = new System.Drawing.Point(12, 15);
            this.lbl_MD_POS.Name = "lbl_MD_POS";
            this.lbl_MD_POS.Size = new System.Drawing.Size(74, 13);
            this.lbl_MD_POS.TabIndex = 1;
            this.lbl_MD_POS.Text = "Ключ. фраза:";
            // 
            // cbChain
            // 
            this.cbChain.FormattingEnabled = true;
            this.cbChain.Location = new System.Drawing.Point(99, 38);
            this.cbChain.Name = "cbChain";
            this.cbChain.Size = new System.Drawing.Size(303, 21);
            this.cbChain.TabIndex = 2;
            this.cbChain.TextChanged += new System.EventHandler(this.cbChain_TextChanged);
            // 
            // lblChain
            // 
            this.lblChain.AutoSize = true;
            this.lblChain.Location = new System.Drawing.Point(12, 41);
            this.lblChain.Name = "lblChain";
            this.lblChain.Size = new System.Drawing.Size(83, 13);
            this.lblChain.TabIndex = 3;
            this.lblChain.Text = "Аптечная сеть:";
            // 
            // lblPOS
            // 
            this.lblPOS.AutoSize = true;
            this.lblPOS.Location = new System.Drawing.Point(12, 68);
            this.lblPOS.Name = "lblPOS";
            this.lblPOS.Size = new System.Drawing.Size(81, 13);
            this.lblPOS.TabIndex = 4;
            this.lblPOS.Text = "Точка продаж:";
            // 
            // cbPOS
            // 
            this.cbPOS.FormattingEnabled = true;
            this.cbPOS.Location = new System.Drawing.Point(99, 65);
            this.cbPOS.Name = "cbPOS";
            this.cbPOS.Size = new System.Drawing.Size(303, 21);
            this.cbPOS.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(200, 105);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 25);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(300, 105);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 25);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // fEdit_MD_POS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 140);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbPOS);
            this.Controls.Add(this.lblPOS);
            this.Controls.Add(this.lblChain);
            this.Controls.Add(this.cbChain);
            this.Controls.Add(this.lbl_MD_POS);
            this.Controls.Add(this.txt_MD_POS);
            this.Name = "fEdit_MD_POS";
            this.Text = "fEdit_MD_POS";
            this.Shown += new System.EventHandler(this.fEditPOS_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_MD_POS;
        private System.Windows.Forms.Label lbl_MD_POS;
        private System.Windows.Forms.ComboBox cbChain;
        private System.Windows.Forms.Label lblChain;
        private System.Windows.Forms.Label lblPOS;
        private System.Windows.Forms.ComboBox cbPOS;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

    }
}