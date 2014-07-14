namespace SalesOfPharmacy
{
    partial class MainForm
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
            this.menu = new System.Windows.Forms.MenuStrip();
            this.mi_Load_File = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_LastR = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_Chains = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_POS = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_Drug = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_MD = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_MD_Drugs = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_MD_POSes = new System.Windows.Forms.ToolStripMenuItem();
            this.oFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.gvResult = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rownum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_flag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.drug = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_flag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.n_flag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gvMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mi_AddPos = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_AddDrug = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvResult)).BeginInit();
            this.gvMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_Load_File,
            this.mi_LastR,
            this.mi_Chains,
            this.mi_POS,
            this.mi_Drug,
            this.mi_MD});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(871, 24);
            this.menu.TabIndex = 1;
            this.menu.Text = "menuStrip1";
            // 
            // mi_Load_File
            // 
            this.mi_Load_File.Name = "mi_Load_File";
            this.mi_Load_File.Size = new System.Drawing.Size(105, 20);
            this.mi_Load_File.Text = "Загрузить файл";
            this.mi_Load_File.Click += new System.EventHandler(this.mi_Load_File_Click);
            // 
            // mi_LastR
            // 
            this.mi_LastR.Name = "mi_LastR";
            this.mi_LastR.Size = new System.Drawing.Size(188, 20);
            this.mi_LastR.Text = "Показать последний результат";
            this.mi_LastR.Click += new System.EventHandler(this.mi_LastR_Click);
            // 
            // mi_Chains
            // 
            this.mi_Chains.Name = "mi_Chains";
            this.mi_Chains.Size = new System.Drawing.Size(101, 20);
            this.mi_Chains.Text = "Аптечные сети";
            this.mi_Chains.Click += new System.EventHandler(this.mi_Chains_Click);
            // 
            // mi_POS
            // 
            this.mi_POS.Name = "mi_POS";
            this.mi_POS.Size = new System.Drawing.Size(98, 20);
            this.mi_POS.Text = "Точки продаж";
            this.mi_POS.Click += new System.EventHandler(this.mi_POS_Click);
            // 
            // mi_Drug
            // 
            this.mi_Drug.Name = "mi_Drug";
            this.mi_Drug.Size = new System.Drawing.Size(81, 20);
            this.mi_Drug.Text = "Препараты";
            this.mi_Drug.Click += new System.EventHandler(this.mi_Drug_Click);
            // 
            // mi_MD
            // 
            this.mi_MD.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_MD_Drugs,
            this.mi_MD_POSes});
            this.mi_MD.Name = "mi_MD";
            this.mi_MD.Size = new System.Drawing.Size(116, 20);
            this.mi_MD.Text = "Ключевые фразы";
            // 
            // mi_MD_Drugs
            // 
            this.mi_MD_Drugs.Name = "mi_MD_Drugs";
            this.mi_MD_Drugs.Size = new System.Drawing.Size(163, 22);
            this.mi_MD_Drugs.Text = "Препараты";
            this.mi_MD_Drugs.Click += new System.EventHandler(this.mi_MD_Drugs_Click);
            // 
            // mi_MD_POSes
            // 
            this.mi_MD_POSes.Name = "mi_MD_POSes";
            this.mi_MD_POSes.Size = new System.Drawing.Size(163, 22);
            this.mi_MD_POSes.Text = "Торговые точки";
            this.mi_MD_POSes.Click += new System.EventHandler(this.mi_MD_POSes_Click);
            // 
            // oFileDlg
            // 
            this.oFileDlg.FileName = "openFileDialog1";
            // 
            // gvResult
            // 
            this.gvResult.AllowUserToAddRows = false;
            this.gvResult.AllowUserToDeleteRows = false;
            this.gvResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.n_flag});
            this.gvResult.ContextMenuStrip = this.gvMenu;
            this.gvResult.Location = new System.Drawing.Point(12, 27);
            this.gvResult.Name = "gvResult";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvResult.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvResult.Size = new System.Drawing.Size(847, 264);
            this.gvResult.TabIndex = 2;
            this.gvResult.Visible = false;
            this.gvResult.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.gvResult_CellContextMenuStripNeeded);
            this.gvResult.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvResult_CellMouseDown);
            this.gvResult.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.gvResult_RowPrePaint);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // rownum
            // 
            this.rownum.DataPropertyName = "rowNum";
            this.rownum.HeaderText = "№";
            this.rownum.Name = "rownum";
            // 
            // pos
            // 
            this.pos.DataPropertyName = "pos";
            this.pos.HeaderText = "Точка";
            this.pos.Name = "pos";
            // 
            // p_flag
            // 
            this.p_flag.DataPropertyName = "p_flag";
            this.p_flag.FalseValue = "0";
            this.p_flag.HeaderText = "Точ";
            this.p_flag.Name = "p_flag";
            this.p_flag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.p_flag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.p_flag.TrueValue = "1";
            // 
            // drug
            // 
            this.drug.DataPropertyName = "drug";
            this.drug.HeaderText = "Препарат";
            this.drug.Name = "drug";
            // 
            // d_flag
            // 
            this.d_flag.DataPropertyName = "d_flag";
            this.d_flag.FalseValue = "0";
            this.d_flag.HeaderText = "Пр-т";
            this.d_flag.Name = "d_flag";
            this.d_flag.TrueValue = "1";
            // 
            // num
            // 
            this.num.DataPropertyName = "num";
            this.num.HeaderText = "Количество";
            this.num.Name = "num";
            // 
            // n_flag
            // 
            this.n_flag.DataPropertyName = "n_flag";
            this.n_flag.FalseValue = "0";
            this.n_flag.HeaderText = "Кол";
            this.n_flag.Name = "n_flag";
            this.n_flag.TrueValue = "1";
            // 
            // gvMenu
            // 
            this.gvMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_AddPos,
            this.mi_AddDrug});
            this.gvMenu.Name = "gvMenu";
            this.gvMenu.Size = new System.Drawing.Size(181, 48);
            // 
            // mi_AddPos
            // 
            this.mi_AddPos.Name = "mi_AddPos";
            this.mi_AddPos.Size = new System.Drawing.Size(180, 22);
            this.mi_AddPos.Text = "Добавить точку";
            this.mi_AddPos.Click += new System.EventHandler(this.mi_AddPos_Click);
            // 
            // mi_AddDrug
            // 
            this.mi_AddDrug.Name = "mi_AddDrug";
            this.mi_AddDrug.Size = new System.Drawing.Size(180, 22);
            this.mi_AddDrug.Text = "Добавить препарат";
            this.mi_AddDrug.Click += new System.EventHandler(this.mi_AddDrug_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 303);
            this.Controls.Add(this.gvResult);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvResult)).EndInit();
            this.gvMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem mi_Load_File;
        private System.Windows.Forms.OpenFileDialog oFileDlg;
        private System.Windows.Forms.DataGridView gvResult;
        private System.Windows.Forms.ToolStripMenuItem mi_LastR;
        private System.Windows.Forms.ContextMenuStrip gvMenu;
        private System.Windows.Forms.ToolStripMenuItem mi_AddPos;
        private System.Windows.Forms.ToolStripMenuItem mi_AddDrug;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn rownum;
        private System.Windows.Forms.DataGridViewTextBoxColumn pos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn p_flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn drug;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d_flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridViewCheckBoxColumn n_flag;
        private System.Windows.Forms.ToolStripMenuItem mi_Chains;
        private System.Windows.Forms.ToolStripMenuItem mi_Drug;
        private System.Windows.Forms.ToolStripMenuItem mi_MD;
        private System.Windows.Forms.ToolStripMenuItem mi_MD_Drugs;
        private System.Windows.Forms.ToolStripMenuItem mi_MD_POSes;
        private System.Windows.Forms.ToolStripMenuItem mi_POS;
    }
}

