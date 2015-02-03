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
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chain_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.area_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.adress = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.nearest_station = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.telephon = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.legal_name = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.legal_owner = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.chain_name = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.b_no = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.area_name = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.post_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mi_AddPOS = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_EditPOS = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_DelPOS = new System.Windows.Forms.ToolStripMenuItem();
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
            this.chain_id,
            this.area_id,
            this.name,
            this.adress,
            this.nearest_station,
            this.telephon,
            this.legal_name,
            this.legal_owner,
            this.chain_name,
            this.b_no,
            this.area_name,
            this.post_code,
            this.tin});
            this.gvPOSes.ContextMenuStrip = this.gvMenu;
            this.gvPOSes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvPOSes.Location = new System.Drawing.Point(0, 0);
            this.gvPOSes.Name = "gvPOSes";
            this.gvPOSes.ReadOnly = true;
            this.gvPOSes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvPOSes.Size = new System.Drawing.Size(627, 393);
            this.gvPOSes.TabIndex = 1;
            this.gvPOSes.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.gvPOSes_CellContextMenuStripNeeded);
            this.gvPOSes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gvPOSes_MouseDown);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 43;
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
            // area_id
            // 
            this.area_id.DataPropertyName = "area_id";
            this.area_id.HeaderText = "AREA_ID";
            this.area_id.Name = "area_id";
            this.area_id.ReadOnly = true;
            this.area_id.Visible = false;
            this.area_id.Width = 78;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "Наименование";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 129;
            // 
            // adress
            // 
            this.adress.DataPropertyName = "address";
            this.adress.HeaderText = "Адрес";
            this.adress.Name = "adress";
            this.adress.ReadOnly = true;
            this.adress.Width = 84;
            // 
            // nearest_station
            // 
            this.nearest_station.DataPropertyName = "nearest_station";
            this.nearest_station.HeaderText = "Ближайшее метро";
            this.nearest_station.Name = "nearest_station";
            this.nearest_station.ReadOnly = true;
            this.nearest_station.Width = 135;
            // 
            // telephon
            // 
            this.telephon.DataPropertyName = "telephon";
            this.telephon.HeaderText = "Телефон";
            this.telephon.Name = "telephon";
            this.telephon.ReadOnly = true;
            this.telephon.Width = 98;
            // 
            // legal_name
            // 
            this.legal_name.DataPropertyName = "legal_name";
            this.legal_name.HeaderText = "Юр. наименование";
            this.legal_name.Name = "legal_name";
            this.legal_name.ReadOnly = true;
            this.legal_name.Width = 137;
            // 
            // legal_owner
            // 
            this.legal_owner.DataPropertyName = "legal_owner";
            this.legal_owner.HeaderText = "Юр. владелец";
            this.legal_owner.Name = "legal_owner";
            this.legal_owner.ReadOnly = true;
            this.legal_owner.Width = 93;
            // 
            // chain_name
            // 
            this.chain_name.DataPropertyName = "chain_name";
            this.chain_name.HeaderText = "Аптечная сеть";
            this.chain_name.Name = "chain_name";
            this.chain_name.ReadOnly = true;
            this.chain_name.Width = 96;
            // 
            // b_no
            // 
            this.b_no.DataPropertyName = "b_no";
            this.b_no.HeaderText = "№ в выгрузке";
            this.b_no.Name = "b_no";
            this.b_no.ReadOnly = true;
            this.b_no.Width = 95;
            // 
            // area_name
            // 
            this.area_name.DataPropertyName = "area_name";
            this.area_name.HeaderText = "Район в выгрузке";
            this.area_name.Name = "area_name";
            this.area_name.ReadOnly = true;
            this.area_name.Width = 113;
            // 
            // post_code
            // 
            this.post_code.DataPropertyName = "post_code";
            this.post_code.HeaderText = "Почтовый индекс";
            this.post_code.Name = "post_code";
            this.post_code.ReadOnly = true;
            this.post_code.Width = 111;
            // 
            // tin
            // 
            this.tin.DataPropertyName = "tin";
            this.tin.HeaderText = "ИНН";
            this.tin.Name = "tin";
            this.tin.ReadOnly = true;
            this.tin.Width = 56;
            // 
            // gvMenu
            // 
            this.gvMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_AddPOS,
            this.mi_EditPOS,
            this.mi_DelPOS});
            this.gvMenu.Name = "gvMenu";
            this.gvMenu.Size = new System.Drawing.Size(234, 70);
            // 
            // mi_AddPOS
            // 
            this.mi_AddPOS.Name = "mi_AddPOS";
            this.mi_AddPOS.Size = new System.Drawing.Size(233, 22);
            this.mi_AddPOS.Text = "Добавить точку продаж";
            this.mi_AddPOS.Click += new System.EventHandler(this.mi_AddPOS_Click);
            // 
            // mi_EditPOS
            // 
            this.mi_EditPOS.Name = "mi_EditPOS";
            this.mi_EditPOS.Size = new System.Drawing.Size(233, 22);
            this.mi_EditPOS.Text = "Редактировать точку продаж";
            this.mi_EditPOS.Click += new System.EventHandler(this.mi_EditPOS_Click);
            // 
            // mi_DelPOS
            // 
            this.mi_DelPOS.Name = "mi_DelPOS";
            this.mi_DelPOS.Size = new System.Drawing.Size(233, 22);
            this.mi_DelPOS.Text = "Удалить точку продаж";
            this.mi_DelPOS.Click += new System.EventHandler(this.mi_DelPOS_Click);
            // 
            // fListPOSes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 393);
            this.Controls.Add(this.gvPOSes);
            this.Name = "fListPOSes";
            this.Text = "Точки продаж";
            this.Activated += new System.EventHandler(this.fListPOSes_Activated);
            this.Shown += new System.EventHandler(this.fListChains_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gvPOSes)).EndInit();
            this.gvMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvPOSes;
        private System.Windows.Forms.ContextMenuStrip gvMenu;
        private System.Windows.Forms.ToolStripMenuItem mi_AddPOS;
        private System.Windows.Forms.ToolStripMenuItem mi_EditPOS;
        private System.Windows.Forms.ToolStripMenuItem mi_DelPOS;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn chain_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn area_id;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn name;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn adress;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn nearest_station;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn telephon;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn legal_name;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn legal_owner;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn chain_name;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn b_no;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn area_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn post_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn tin;
    }
}