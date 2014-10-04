namespace SalesOfPharmacy
{
    partial class fList_MD_Drugs
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
            this.gv_MD_Drugs = new System.Windows.Forms.DataGridView();
            this.gvMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mi_Add_MD_Drug = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_Edit_MD_Drug = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_Del_MD_Drug = new System.Windows.Forms.ToolStripMenuItem();
            this.id = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.name = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.model_name = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.drug_id = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gv_MD_Drugs)).BeginInit();
            this.gvMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gv_MD_Drugs
            // 
            this.gv_MD_Drugs.AllowUserToAddRows = false;
            this.gv_MD_Drugs.AllowUserToDeleteRows = false;
            this.gv_MD_Drugs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gv_MD_Drugs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gv_MD_Drugs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_MD_Drugs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.model_name,
            this.drug_id});
            this.gv_MD_Drugs.ContextMenuStrip = this.gvMenu;
            this.gv_MD_Drugs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv_MD_Drugs.Location = new System.Drawing.Point(0, 0);
            this.gv_MD_Drugs.Name = "gv_MD_Drugs";
            this.gv_MD_Drugs.ReadOnly = true;
            this.gv_MD_Drugs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gv_MD_Drugs.Size = new System.Drawing.Size(514, 307);
            this.gv_MD_Drugs.TabIndex = 0;
            this.gv_MD_Drugs.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.gv_MD_Drugs_CellContextMenuStripNeeded);
            this.gv_MD_Drugs.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gv_MD_Drugs_CellMouseDown);
            this.gv_MD_Drugs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gv_MD_Drugs_MouseDown);
            // 
            // gvMenu
            // 
            this.gvMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_Add_MD_Drug,
            this.mi_Edit_MD_Drug,
            this.mi_Del_MD_Drug});
            this.gvMenu.Name = "gvMenu";
            this.gvMenu.Size = new System.Drawing.Size(334, 70);
            // 
            // mi_Add_MD_Drug
            // 
            this.mi_Add_MD_Drug.Name = "mi_Add_MD_Drug";
            this.mi_Add_MD_Drug.Size = new System.Drawing.Size(333, 22);
            this.mi_Add_MD_Drug.Text = "Добавить ключевую фразу для препарата";
            this.mi_Add_MD_Drug.Click += new System.EventHandler(this.mi_Add_MD_Drug_Click);
            // 
            // mi_Edit_MD_Drug
            // 
            this.mi_Edit_MD_Drug.Name = "mi_Edit_MD_Drug";
            this.mi_Edit_MD_Drug.Size = new System.Drawing.Size(333, 22);
            this.mi_Edit_MD_Drug.Text = "Редактировать ключевую фразу для препарата";
            this.mi_Edit_MD_Drug.Click += new System.EventHandler(this.mi_Edit_MD_Drug_Click);
            // 
            // mi_Del_MD_Drug
            // 
            this.mi_Del_MD_Drug.Name = "mi_Del_MD_Drug";
            this.mi_Del_MD_Drug.Size = new System.Drawing.Size(333, 22);
            this.mi_Del_MD_Drug.Text = "Удалить ключевую фразу для препарата";
            this.mi_Del_MD_Drug.Click += new System.EventHandler(this.mi_Del_MD_Drug_Click);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.id.Width = 64;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "Наименование";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.name.Width = 129;
            // 
            // model_name
            // 
            this.model_name.DataPropertyName = "model_name";
            this.model_name.HeaderText = "Ключевая фраза";
            this.model_name.Name = "model_name";
            this.model_name.ReadOnly = true;
            this.model_name.Width = 128;
            // 
            // drug_id
            // 
            this.drug_id.DataPropertyName = "drug_id";
            this.drug_id.HeaderText = "drug_id";
            this.drug_id.Name = "drug_id";
            this.drug_id.ReadOnly = true;
            this.drug_id.Width = 88;
            // 
            // fList_MD_Drugs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 307);
            this.Controls.Add(this.gv_MD_Drugs);
            this.Name = "fList_MD_Drugs";
            this.Text = "fList_MD_Drugs";
            this.Shown += new System.EventHandler(this.fList_MD_Drugs_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gv_MD_Drugs)).EndInit();
            this.gvMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gv_MD_Drugs;
        private System.Windows.Forms.ContextMenuStrip gvMenu;
        private System.Windows.Forms.ToolStripMenuItem mi_Add_MD_Drug;
        private System.Windows.Forms.ToolStripMenuItem mi_Edit_MD_Drug;
        private System.Windows.Forms.ToolStripMenuItem mi_Del_MD_Drug;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn id;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn name;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn model_name;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn drug_id;
    }
}