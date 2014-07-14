namespace SalesOfPharmacy
{
    partial class fLoadNewFile
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fLoadNewFile));
            this.lblChain = new System.Windows.Forms.Label();
            this.cbChain = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblMonth = new System.Windows.Forms.Label();
            this.cbMonth = new System.Windows.Forms.ComboBox();
            this.lblFile = new System.Windows.Forms.Label();
            this.btnFile = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.oFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.il_24 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // lblChain
            // 
            this.lblChain.AutoSize = true;
            this.lblChain.Location = new System.Drawing.Point(12, 15);
            this.lblChain.Name = "lblChain";
            this.lblChain.Size = new System.Drawing.Size(83, 13);
            this.lblChain.TabIndex = 5;
            this.lblChain.Text = "Аптечная сеть:";
            // 
            // cbChain
            // 
            this.cbChain.FormattingEnabled = true;
            this.cbChain.Location = new System.Drawing.Point(101, 12);
            this.cbChain.Name = "cbChain";
            this.cbChain.Size = new System.Drawing.Size(250, 21);
            this.cbChain.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(249, 105);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 25);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(149, 105);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 25);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Загрузить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(12, 42);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(43, 13);
            this.lblMonth.TabIndex = 11;
            this.lblMonth.Text = "Месяц:";
            // 
            // cbMonth
            // 
            this.cbMonth.FormattingEnabled = true;
            this.cbMonth.Location = new System.Drawing.Point(101, 39);
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.Size = new System.Drawing.Size(250, 21);
            this.cbMonth.TabIndex = 10;
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(12, 69);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(39, 13);
            this.lblFile.TabIndex = 12;
            this.lblFile.Text = "Файл:";
            // 
            // btnFile
            // 
            this.btnFile.ImageIndex = 0;
            this.btnFile.ImageList = this.il_24;
            this.btnFile.Location = new System.Drawing.Point(71, 63);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(24, 24);
            this.btnFile.TabIndex = 13;
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(101, 66);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(250, 20);
            this.txtFile.TabIndex = 14;
            // 
            // oFileDlg
            // 
            this.oFileDlg.FileName = "openFileDialog1";
            // 
            // il_24
            // 
            this.il_24.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il_24.ImageStream")));
            this.il_24.TransparentColor = System.Drawing.Color.Transparent;
            this.il_24.Images.SetKeyName(0, "human_document_open.png");
            // 
            // fLoadNewFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 142);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.cbMonth);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblChain);
            this.Controls.Add(this.cbChain);
            this.Name = "fLoadNewFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "fLoadNewFile";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fLoadNewFile_FormClosing);
            this.Shown += new System.EventHandler(this.fLoadNewFile_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChain;
        private System.Windows.Forms.ComboBox cbChain;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.ComboBox cbMonth;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.OpenFileDialog oFileDlg;
        private System.Windows.Forms.ImageList il_24;
    }
}