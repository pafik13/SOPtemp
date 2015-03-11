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
            this.gvMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mi_Add_MD_POS = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_Edit_MD_POS = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_Del_MD_POS = new System.Windows.Forms.ToolStripMenuItem();
            this.pos_id = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.pos_name = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.chain_id = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.chain_name = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.mn_id = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.model_name = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gv_MD_POSes)).BeginInit();
            this.gvMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gv_MD_POSes
            // 
            this.gv_MD_POSes.AllowUserToAddRows = false;
            this.gv_MD_POSes.AllowUserToDeleteRows = false;
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
            this.pos_id,
            this.pos_name,
            this.chain_id,
            this.chain_name,
            this.mn_id,
            this.model_name});
            this.gv_MD_POSes.ContextMenuStrip = this.gvMenu;
            this.gv_MD_POSes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv_MD_POSes.Location = new System.Drawing.Point(0, 0);
            this.gv_MD_POSes.Name = "gv_MD_POSes";
            this.gv_MD_POSes.ReadOnly = true;
            this.gv_MD_POSes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gv_MD_POSes.Size = new System.Drawing.Size(514, 307);
            this.gv_MD_POSes.TabIndex = 0;
            this.gv_MD_POSes.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.gv_MD_POSes_CellContextMenuStripNeeded);
            this.gv_MD_POSes.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gv_MD_POSes_CellMouseDown);
            // 
            // gvMenu
            // 
            this.gvMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_Add_MD_POS,
            this.mi_Edit_MD_POS,
            this.mi_Del_MD_POS});
            this.gvMenu.Name = "gvMenu";
            this.gvMenu.Size = new System.Drawing.Size(363, 70);
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
            // pos_id
            // 
            this.pos_id.DataPropertyName = "pos_id";
            this.pos_id.HeaderText = "ID";
            this.pos_id.Name = "pos_id";
            this.pos_id.ReadOnly = true;
            this.pos_id.Width = 60;
            // 
            // pos_name
            // 
            this.pos_name.DataPropertyName = "pos_name";
            this.pos_name.HeaderText = "Аптека";
            this.pos_name.Name = "pos_name";
            this.pos_name.ReadOnly = true;
            this.pos_name.Width = 118;
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
            this.chain_name.HeaderText = "Сеть";
            this.chain_name.Name = "chain_name";
            this.chain_name.ReadOnly = true;
            this.chain_name.Width = 117;
            // 
            // mn_id
            // 
            this.mn_id.DataPropertyName = "mn_id";
            this.mn_id.HeaderText = "MN_ID";
            this.mn_id.Name = "mn_id";
            this.mn_id.ReadOnly = true;
            this.mn_id.Visible = false;
            this.mn_id.Width = 66;
            // 
            // model_name
            // 
            this.model_name.DataPropertyName = "model_name";
            this.model_name.HeaderText = "Связанная кл. фраза";
            this.model_name.Name = "model_name";
            this.model_name.ReadOnly = true;
            this.model_name.Width = 118;
            // 
            // fList_MD_POSes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 307);
            this.Controls.Add(this.gv_MD_POSes);
            this.Name = "fList_MD_POSes";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "СВЯЗИ - Аптеки";
            this.Shown += new System.EventHandler(this.fList_MD_POSes_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gv_MD_POSes)).EndInit();
            this.gvMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gv_MD_POSes;
        private System.Windows.Forms.ContextMenuStrip gvMenu;
        private System.Windows.Forms.ToolStripMenuItem mi_Add_MD_POS;
        private System.Windows.Forms.ToolStripMenuItem mi_Edit_MD_POS;
        private System.Windows.Forms.ToolStripMenuItem mi_Del_MD_POS;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn pos_id;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn pos_name;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn chain_id;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn chain_name;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn mn_id;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn model_name;
    }
}