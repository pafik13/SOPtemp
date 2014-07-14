namespace SalesOfPharmacy
{
    partial class fListDrugs
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gvDrugs = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mi_AddDrug = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_EditDrug = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_DelDrug = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gvDrugs)).BeginInit();
            this.gvMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvDrugs
            // 
            this.gvDrugs.AllowUserToAddRows = false;
            this.gvDrugs.AllowUserToDeleteRows = false;
            this.gvDrugs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvDrugs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvDrugs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDrugs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name});
            this.gvDrugs.ContextMenuStrip = this.gvMenu;
            this.gvDrugs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvDrugs.Location = new System.Drawing.Point(0, 0);
            this.gvDrugs.Name = "gvDrugs";
            this.gvDrugs.ReadOnly = true;
            this.gvDrugs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvDrugs.Size = new System.Drawing.Size(284, 262);
            this.gvDrugs.TabIndex = 1;
            this.gvDrugs.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.gvDrugs_CellContextMenuStripNeeded);
            this.gvDrugs.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvDrugs_CellMouseDown);
            this.gvDrugs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gvDrugs_MouseDown);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 43;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "Наименование";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 108;
            // 
            // gvMenu
            // 
            this.gvMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_AddDrug,
            this.mi_EditDrug,
            this.mi_DelDrug});
            this.gvMenu.Name = "gvMenu";
            this.gvMenu.Size = new System.Drawing.Size(209, 70);
            // 
            // mi_AddDrug
            // 
            this.mi_AddDrug.Name = "mi_AddDrug";
            this.mi_AddDrug.Size = new System.Drawing.Size(208, 22);
            this.mi_AddDrug.Text = "Добавить препарат";
            this.mi_AddDrug.Click += new System.EventHandler(this.mi_AddChain_Click);
            // 
            // mi_EditDrug
            // 
            this.mi_EditDrug.Name = "mi_EditDrug";
            this.mi_EditDrug.Size = new System.Drawing.Size(208, 22);
            this.mi_EditDrug.Text = "Редактировать препарат";
            this.mi_EditDrug.Click += new System.EventHandler(this.mi_EditChain_Click);
            // 
            // mi_DelDrug
            // 
            this.mi_DelDrug.Name = "mi_DelDrug";
            this.mi_DelDrug.Size = new System.Drawing.Size(208, 22);
            this.mi_DelDrug.Text = "Удалить препарат";
            this.mi_DelDrug.Click += new System.EventHandler(this.mi_DelDrug_Click);
            // 
            // fListDrugs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.gvDrugs);
            this.Name = "fListDrugs";
            this.Text = "fListDrugs";
            this.Shown += new System.EventHandler(this.fListChains_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gvDrugs)).EndInit();
            this.gvMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvDrugs;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.ContextMenuStrip gvMenu;
        private System.Windows.Forms.ToolStripMenuItem mi_AddDrug;
        private System.Windows.Forms.ToolStripMenuItem mi_EditDrug;
        private System.Windows.Forms.ToolStripMenuItem mi_DelDrug;
    }
}