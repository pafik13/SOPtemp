namespace SalesOfPharmacy
{
    partial class fList_MD_POSes
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
            this.gv_MD_POSes = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mi_Add_MD_POS = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_Edit_MD_POS = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_Del_MD_POS = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gv_MD_POSes)).BeginInit();
            this.gvMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gv_MD_POSes
            // 
            this.gv_MD_POSes.AllowUserToAddRows = false;
            this.gv_MD_POSes.AllowUserToDeleteRows = false;
            this.gv_MD_POSes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gv_MD_POSes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gv_MD_POSes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_MD_POSes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name});
            this.gv_MD_POSes.ContextMenuStrip = this.gvMenu;
            this.gv_MD_POSes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv_MD_POSes.Location = new System.Drawing.Point(0, 0);
            this.gv_MD_POSes.Name = "gv_MD_POSes";
            this.gv_MD_POSes.ReadOnly = true;
            this.gv_MD_POSes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gv_MD_POSes.Size = new System.Drawing.Size(514, 307);
            this.gv_MD_POSes.TabIndex = 0;
            this.gv_MD_POSes.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.gv_MD_Drugs_CellContextMenuStripNeeded);
            this.gv_MD_POSes.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gv_MD_Drugs_CellMouseDown);
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
            this.mi_Add_MD_POS,
            this.mi_Edit_MD_POS,
            this.mi_Del_MD_POS});
            this.gvMenu.Name = "gvMenu";
            this.gvMenu.Size = new System.Drawing.Size(363, 92);
            // 
            // mi_Add_MD_POS
            // 
            this.mi_Add_MD_POS.Name = "mi_Add_MD_POS";
            this.mi_Add_MD_POS.Size = new System.Drawing.Size(362, 22);
            this.mi_Add_MD_POS.Text = "Добавить ключевую фразу для торговой точки";
            this.mi_Add_MD_POS.Click += new System.EventHandler(this.mi_Add_MD_POS_Click);
            // 
            // mi_Edit_MD_POS
            // 
            this.mi_Edit_MD_POS.Name = "mi_Edit_MD_POS";
            this.mi_Edit_MD_POS.Size = new System.Drawing.Size(362, 22);
            this.mi_Edit_MD_POS.Text = "Редактировать ключевую фразу для торговой точки";
            this.mi_Edit_MD_POS.Click += new System.EventHandler(this.mi_Edit_MD_POS_Click);
            // 
            // mi_Del_MD_POS
            // 
            this.mi_Del_MD_POS.Name = "mi_Del_MD_POS";
            this.mi_Del_MD_POS.Size = new System.Drawing.Size(362, 22);
            this.mi_Del_MD_POS.Text = "Удалить ключевую фразу для торговой точки";
            this.mi_Del_MD_POS.Click += new System.EventHandler(this.mi_Del_MD_POS_Click);
            // 
            // fList_MD_POSes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 307);
            this.Controls.Add(this.gv_MD_POSes);
            this.Name = "fList_MD_POSes";
            this.Text = "fList_MD_Drugs";
            this.Shown += new System.EventHandler(this.fList_MD_POSes_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gv_MD_POSes)).EndInit();
            this.gvMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gv_MD_POSes;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.ContextMenuStrip gvMenu;
        private System.Windows.Forms.ToolStripMenuItem mi_Add_MD_POS;
        private System.Windows.Forms.ToolStripMenuItem mi_Edit_MD_POS;
        private System.Windows.Forms.ToolStripMenuItem mi_Del_MD_POS;
    }
}