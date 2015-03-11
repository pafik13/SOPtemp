namespace SalesOfPharmacy
{
    partial class fResult
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gvResult = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rownum = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.pos = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.p_flag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.drug = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.d_flag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.num = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.n_flag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chain_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fr_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.month_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.year_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num_oe = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.gvMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mi_Add_POS = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mi_Add_MD_POS = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_Add_MD_Drug = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mi_Refresh = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gvResult)).BeginInit();
            this.gvMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvResult
            // 
            this.gvResult.AllowUserToAddRows = false;
            this.gvResult.AllowUserToDeleteRows = false;
            this.gvResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.rownum,
            this.pos,
            this.p_flag,
            this.drug,
            this.d_flag,
            this.num,
            this.n_flag,
            this.chain_id,
            this.fr_id,
            this.month_id,
            this.year_id,
            this.num_oe});
            this.gvResult.ContextMenuStrip = this.gvMenu;
            this.gvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvResult.Location = new System.Drawing.Point(0, 0);
            this.gvResult.Name = "gvResult";
            this.gvResult.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvResult.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvResult.Size = new System.Drawing.Size(862, 311);
            this.gvResult.TabIndex = 4;
            this.gvResult.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.gvResult_CellContextMenuStripNeeded);
            this.gvResult.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvResult_CellMouseDown);
            this.gvResult.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvResult_ColumnHeaderMouseClick);
            this.gvResult.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvResult_RowHeaderMouseClick);
            this.gvResult.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.gvResult_RowPrePaint);
            this.gvResult.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.gvResult_RowsAdded);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.id.Width = 21;
            // 
            // rownum
            // 
            this.rownum.DataPropertyName = "rowNum";
            this.rownum.HeaderText = "№";
            this.rownum.Name = "rownum";
            this.rownum.ReadOnly = true;
            this.rownum.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.rownum.Width = 59;
            // 
            // pos
            // 
            this.pos.DataPropertyName = "pos";
            this.pos.HeaderText = "Точка";
            this.pos.Name = "pos";
            this.pos.ReadOnly = true;
            this.pos.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.pos.Width = 78;
            // 
            // p_flag
            // 
            this.p_flag.DataPropertyName = "p_flag";
            this.p_flag.FalseValue = "0";
            this.p_flag.HeaderText = "Точ";
            this.p_flag.Name = "p_flag";
            this.p_flag.ReadOnly = true;
            this.p_flag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.p_flag.TrueValue = "1";
            this.p_flag.Width = 31;
            // 
            // drug
            // 
            this.drug.DataPropertyName = "drug";
            this.drug.HeaderText = "Препарат";
            this.drug.Name = "drug";
            this.drug.ReadOnly = true;
            this.drug.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.drug.Width = 97;
            // 
            // d_flag
            // 
            this.d_flag.DataPropertyName = "d_flag";
            this.d_flag.FalseValue = "0";
            this.d_flag.HeaderText = "Пр-т";
            this.d_flag.Name = "d_flag";
            this.d_flag.ReadOnly = true;
            this.d_flag.TrueValue = "1";
            this.d_flag.Width = 35;
            // 
            // num
            // 
            this.num.DataPropertyName = "num";
            this.num.HeaderText = "Количество";
            this.num.Name = "num";
            this.num.ReadOnly = true;
            this.num.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.num.Width = 107;
            // 
            // n_flag
            // 
            this.n_flag.DataPropertyName = "n_flag";
            this.n_flag.FalseValue = "0";
            this.n_flag.HeaderText = "Кол";
            this.n_flag.Name = "n_flag";
            this.n_flag.ReadOnly = true;
            this.n_flag.TrueValue = "1";
            this.n_flag.Width = 32;
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
            // fr_id
            // 
            this.fr_id.DataPropertyName = "fr_id";
            this.fr_id.HeaderText = "FR_ID";
            this.fr_id.Name = "fr_id";
            this.fr_id.ReadOnly = true;
            this.fr_id.Visible = false;
            this.fr_id.Width = 63;
            // 
            // month_id
            // 
            this.month_id.DataPropertyName = "month_id";
            this.month_id.HeaderText = "MONTH_ID";
            this.month_id.Name = "month_id";
            this.month_id.ReadOnly = true;
            this.month_id.Visible = false;
            this.month_id.Width = 89;
            // 
            // year_id
            // 
            this.year_id.DataPropertyName = "year_id";
            this.year_id.HeaderText = "YEAR_ID";
            this.year_id.Name = "year_id";
            this.year_id.ReadOnly = true;
            this.year_id.Visible = false;
            this.year_id.Width = 78;
            // 
            // num_oe
            // 
            this.num_oe.DataPropertyName = "num_oe";
            this.num_oe.HeaderText = "Ошибки";
            this.num_oe.Name = "num_oe";
            this.num_oe.ReadOnly = true;
            this.num_oe.Width = 88;
            // 
            // gvMenu
            // 
            this.gvMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_Add_POS,
            this.toolStripSeparator2,
            this.mi_Add_MD_POS,
            this.mi_Add_MD_Drug,
            this.toolStripSeparator1,
            this.mi_Refresh});
            this.gvMenu.Name = "gvMenu";
            this.gvMenu.Size = new System.Drawing.Size(250, 104);
            this.gvMenu.Opening += new System.ComponentModel.CancelEventHandler(this.gvMenu_Opening);
            // 
            // mi_Add_POS
            // 
            this.mi_Add_POS.Name = "mi_Add_POS";
            this.mi_Add_POS.Size = new System.Drawing.Size(249, 22);
            this.mi_Add_POS.Text = "Добавить точку";
            this.mi_Add_POS.Click += new System.EventHandler(this.mi_Add_POS_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(246, 6);
            // 
            // mi_Add_MD_POS
            // 
            this.mi_Add_MD_POS.Name = "mi_Add_MD_POS";
            this.mi_Add_MD_POS.Size = new System.Drawing.Size(249, 22);
            this.mi_Add_MD_POS.Text = "Добавить кл. слова к аптеке";
            this.mi_Add_MD_POS.Click += new System.EventHandler(this.mi_Add_MD_POS_Click);
            // 
            // mi_Add_MD_Drug
            // 
            this.mi_Add_MD_Drug.Name = "mi_Add_MD_Drug";
            this.mi_Add_MD_Drug.Size = new System.Drawing.Size(249, 22);
            this.mi_Add_MD_Drug.Text = "Добавить кл. слова к препарату";
            this.mi_Add_MD_Drug.Click += new System.EventHandler(this.mi_Add_MD_Drug_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(246, 6);
            // 
            // mi_Refresh
            // 
            this.mi_Refresh.Name = "mi_Refresh";
            this.mi_Refresh.Size = new System.Drawing.Size(249, 22);
            this.mi_Refresh.Text = "Обновить данные";
            this.mi_Refresh.Click += new System.EventHandler(this.mi_Refresh_Click);
            // 
            // fResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 311);
            this.Controls.Add(this.gvResult);
            this.Name = "fResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "fResult";
            this.Shown += new System.EventHandler(this.fResult_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gvResult)).EndInit();
            this.gvMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvResult;
        private System.Windows.Forms.ContextMenuStrip gvMenu;
        private System.Windows.Forms.ToolStripMenuItem mi_Add_MD_POS;
        private System.Windows.Forms.ToolStripMenuItem mi_Add_MD_Drug;
        private System.Windows.Forms.ToolStripMenuItem mi_Refresh;
        private System.Windows.Forms.ToolStripMenuItem mi_Add_POS;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn rownum;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn pos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn p_flag;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn drug;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d_flag;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn num;
        private System.Windows.Forms.DataGridViewCheckBoxColumn n_flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn chain_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fr_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn month_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn year_id;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn num_oe;
    }
}