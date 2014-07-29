namespace SalesOfPharmacy
{
    partial class fEditPOS
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
            this.lblPOS = new System.Windows.Forms.Label();
            this.txtPOS = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblChain = new System.Windows.Forms.Label();
            this.cbChain = new System.Windows.Forms.ComboBox();
            this.lblB_Area = new System.Windows.Forms.Label();
            this.cbB_Area = new System.Windows.Forms.ComboBox();
            this.lblB_No = new System.Windows.Forms.Label();
            this.txtB_No = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblPOS
            // 
            this.lblPOS.AutoSize = true;
            this.lblPOS.Location = new System.Drawing.Point(12, 15);
            this.lblPOS.Name = "lblPOS";
            this.lblPOS.Size = new System.Drawing.Size(81, 13);
            this.lblPOS.TabIndex = 3;
            this.lblPOS.Text = "Точка продаж:";
            // 
            // txtPOS
            // 
            this.txtPOS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPOS.Location = new System.Drawing.Point(101, 12);
            this.txtPOS.Name = "txtPOS";
            this.txtPOS.Size = new System.Drawing.Size(350, 20);
            this.txtPOS.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(350, 119);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 25);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(250, 119);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 25);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblChain
            // 
            this.lblChain.AutoSize = true;
            this.lblChain.Location = new System.Drawing.Point(12, 41);
            this.lblChain.Name = "lblChain";
            this.lblChain.Size = new System.Drawing.Size(83, 13);
            this.lblChain.TabIndex = 11;
            this.lblChain.Text = "Аптечная сеть:";
            // 
            // cbChain
            // 
            this.cbChain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbChain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChain.FormattingEnabled = true;
            this.cbChain.Location = new System.Drawing.Point(101, 38);
            this.cbChain.Name = "cbChain";
            this.cbChain.Size = new System.Drawing.Size(350, 21);
            this.cbChain.TabIndex = 10;
            this.cbChain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbChain_KeyDown);
            // 
            // lblB_Area
            // 
            this.lblB_Area.AutoSize = true;
            this.lblB_Area.Location = new System.Drawing.Point(12, 93);
            this.lblB_Area.Name = "lblB_Area";
            this.lblB_Area.Size = new System.Drawing.Size(75, 13);
            this.lblB_Area.TabIndex = 15;
            this.lblB_Area.Text = "Город/Округ:";
            // 
            // cbB_Area
            // 
            this.cbB_Area.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbB_Area.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbB_Area.FormattingEnabled = true;
            this.cbB_Area.Location = new System.Drawing.Point(101, 90);
            this.cbB_Area.Name = "cbB_Area";
            this.cbB_Area.Size = new System.Drawing.Size(350, 21);
            this.cbB_Area.TabIndex = 14;
            this.cbB_Area.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbB_Area_KeyDown);
            // 
            // lblB_No
            // 
            this.lblB_No.AutoSize = true;
            this.lblB_No.Location = new System.Drawing.Point(12, 67);
            this.lblB_No.Name = "lblB_No";
            this.lblB_No.Size = new System.Drawing.Size(87, 13);
            this.lblB_No.TabIndex = 13;
            this.lblB_No.Text = "№ из выгрузки:";
            // 
            // txtB_No
            // 
            this.txtB_No.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtB_No.Location = new System.Drawing.Point(101, 64);
            this.txtB_No.Name = "txtB_No";
            this.txtB_No.Size = new System.Drawing.Size(350, 20);
            this.txtB_No.TabIndex = 12;
            // 
            // fEditPOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 153);
            this.Controls.Add(this.lblB_Area);
            this.Controls.Add(this.cbB_Area);
            this.Controls.Add(this.lblB_No);
            this.Controls.Add(this.txtB_No);
            this.Controls.Add(this.lblChain);
            this.Controls.Add(this.cbChain);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblPOS);
            this.Controls.Add(this.txtPOS);
            this.MinimumSize = new System.Drawing.Size(390, 38);
            this.Name = "fEditPOS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fEditDrug";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fEditPOS_FormClosing);
            this.Shown += new System.EventHandler(this.fEditPOS_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPOS;
        private System.Windows.Forms.TextBox txtPOS;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblChain;
        private System.Windows.Forms.ComboBox cbChain;
        private System.Windows.Forms.Label lblB_Area;
        private System.Windows.Forms.ComboBox cbB_Area;
        private System.Windows.Forms.Label lblB_No;
        private System.Windows.Forms.TextBox txtB_No;
    }
}