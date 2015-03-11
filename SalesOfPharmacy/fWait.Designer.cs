namespace SalesOfPharmacy
{
    partial class fWait
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
            this.picLoad = new System.Windows.Forms.PictureBox();
            this.lblWait = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLoad)).BeginInit();
            this.SuspendLayout();
            // 
            // picLoad
            // 
            this.picLoad.BackColor = System.Drawing.SystemColors.Control;
            this.picLoad.Image = global::SalesOfPharmacy.Properties.Resources.sbl_load;
            this.picLoad.Location = new System.Drawing.Point(12, 12);
            this.picLoad.Name = "picLoad";
            this.picLoad.Size = new System.Drawing.Size(66, 66);
            this.picLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoad.TabIndex = 1;
            this.picLoad.TabStop = false;
            // 
            // lblWait
            // 
            this.lblWait.AutoSize = true;
            this.lblWait.BackColor = System.Drawing.Color.Transparent;
            this.lblWait.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWait.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblWait.Location = new System.Drawing.Point(92, 37);
            this.lblWait.Name = "lblWait";
            this.lblWait.Size = new System.Drawing.Size(322, 20);
            this.lblWait.TabIndex = 2;
            this.lblWait.Text = "Идет сбор информации. Ожидайте...";
            // 
            // fWait
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackgroundImage = global::SalesOfPharmacy.Properties.Resources.sbl_load_background;
            this.ClientSize = new System.Drawing.Size(424, 96);
            this.Controls.Add(this.lblWait);
            this.Controls.Add(this.picLoad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fWait";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fWait";
            ((System.ComponentModel.ISupportInitialize)(this.picLoad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picLoad;
        private System.Windows.Forms.Label lblWait;
    }
}