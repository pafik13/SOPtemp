﻿namespace SalesOfPharmacy
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
            this.txtPOS = new System.Windows.Forms.TextBox();
            this.lblPOS = new System.Windows.Forms.Label();
            this.cbChain = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_mdPOS = new System.Windows.Forms.Label();
            this.cb_mdPOS = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPOS
            // 
            this.txtPOS.Location = new System.Drawing.Point(99, 12);
            this.txtPOS.Name = "txtPOS";
            this.txtPOS.Size = new System.Drawing.Size(303, 20);
            this.txtPOS.TabIndex = 0;
            // 
            // lblPOS
            // 
            this.lblPOS.AutoSize = true;
            this.lblPOS.Location = new System.Drawing.Point(12, 15);
            this.lblPOS.Name = "lblPOS";
            this.lblPOS.Size = new System.Drawing.Size(81, 13);
            this.lblPOS.TabIndex = 1;
            this.lblPOS.Text = "Точка продаж:";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Аптечная сеть:";
            // 
            // lbl_mdPOS
            // 
            this.lbl_mdPOS.AutoSize = true;
            this.lbl_mdPOS.Location = new System.Drawing.Point(12, 68);
            this.lbl_mdPOS.Name = "lbl_mdPOS";
            this.lbl_mdPOS.Size = new System.Drawing.Size(75, 13);
            this.lbl_mdPOS.TabIndex = 4;
            this.lbl_mdPOS.Text = "Мод. данные:";
            // 
            // cb_mdPOS
            // 
            this.cb_mdPOS.FormattingEnabled = true;
            this.cb_mdPOS.Location = new System.Drawing.Point(99, 65);
            this.cb_mdPOS.Name = "cb_mdPOS";
            this.cb_mdPOS.Size = new System.Drawing.Size(303, 21);
            this.cb_mdPOS.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(200, 105);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(300, 105);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // fEditPOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 140);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cb_mdPOS);
            this.Controls.Add(this.lbl_mdPOS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbChain);
            this.Controls.Add(this.lblPOS);
            this.Controls.Add(this.txtPOS);
            this.Name = "fEditPOS";
            this.Text = "fEditPOS";
            this.Shown += new System.EventHandler(this.fEditPOS_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPOS;
        private System.Windows.Forms.Label lblPOS;
        private System.Windows.Forms.ComboBox cbChain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_mdPOS;
        private System.Windows.Forms.ComboBox cb_mdPOS;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

    }
}