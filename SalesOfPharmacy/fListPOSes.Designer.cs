namespace SalesOfPharmacy
{
    partial class fListPOSes
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
            this.gvPOSes = new System.Windows.Forms.DataGridView();
            this.gvMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mi_AddDrug = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_EditDrug = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_DelDrug = new System.Windows.Forms.ToolStripMenuItem();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chain_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chain_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvPOSes)).BeginInit();
            this.gvMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvPOSes
            // 
            this.gvPOSes.AllowUserToAddRows = false;
            this.gvPOSes.AllowUserToDeleteRows = false;
            this.gvPOSes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvPOSes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvPOSes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPOSes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.chain_id,
            this.chain_name});
            this.gvPOSes.ContextMenuStrip = this.gvMenu;
            this.gvPOSes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvPOSes.Location = new System.Drawing.Point(0, 0);
            this.gvPOSes.Name = "gvPOSes";
            this.gvPOSes.ReadOnly = true;
            this.gvPOSes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvPOSes.Size = new System.Drawing.Size(284, 262);
            this.gvPOSes.TabIndex = 1;
            this.gvPOSes.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.gvDrugs_CellContextMenuStripNeeded);
            this.gvPOSes.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvDrugs_CellMouseDown);
            this.gvPOSes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gvDrugs_MouseDown);
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
            this.name.HeaderText = "Наименование точки продаж";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 130;
            // 
            // chain_id
            // 
            this.chain_id.DataPropertyName = "chain_id";
            this.chain_id.HeaderText = "CHAIN_ID";
            this.chain_id.Name = "chain_id";
            this.chain_id.ReadOnly = true;
            this.chain_id.Visible = false;
            this.chain_id.Width = 82;
            // 
            // chain_name
            // 
            this.chain_name.DataPropertyName = "chain_name";
            this.chain_name.HeaderText = "Наименование аптечной сети";
            this.chain_name.Name = "chain_name";
            this.chain_name.ReadOnly = true;
            this.chain_name.Width = 146;
            // 
            // fListPOSes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.gvPOSes);
            this.Name = "fListPOSes";
            this.Text = "fListDrugs";
            this.Shown += new System.EventHandler(this.fListPOSes_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gvPOSes)).EndInit();
            this.gvMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvPOSes;
        private System.Windows.Forms.ContextMenuStrip gvMenu;
        private System.Windows.Forms.ToolStripMenuItem mi_AddDrug;
        private System.Windows.Forms.ToolStripMenuItem mi_EditDrug;
        private System.Windows.Forms.ToolStripMenuItem mi_DelDrug;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn chain_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn chain_name;
    }
}