namespace SalesOfPharmacy
{
    partial class fListFiles
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
            this.gvFiles = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chain_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.month_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.month = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.year_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mi_LoadFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_ViewResult = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_DelDrug = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gvFiles)).BeginInit();
            this.gvMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvFiles
            // 
            this.gvFiles.AllowUserToAddRows = false;
            this.gvFiles.AllowUserToDeleteRows = false;
            this.gvFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvFiles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.chain_id,
            this.chain,
            this.month_id,
            this.month,
            this.year_id,
            this.year});
            this.gvFiles.ContextMenuStrip = this.gvMenu;
            this.gvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvFiles.Location = new System.Drawing.Point(0, 0);
            this.gvFiles.Name = "gvFiles";
            this.gvFiles.ReadOnly = true;
            this.gvFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvFiles.Size = new System.Drawing.Size(525, 389);
            this.gvFiles.TabIndex = 2;
            this.gvFiles.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.gvFiles_CellContextMenuStripNeeded);
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
            this.name.DataPropertyName = "file_name";
            this.name.HeaderText = "Наименование";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 108;
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
            // chain
            // 
            this.chain.DataPropertyName = "chain";
            this.chain.HeaderText = "Аптечная сеть";
            this.chain.Name = "chain";
            this.chain.ReadOnly = true;
            this.chain.Width = 96;
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
            // month
            // 
            this.month.DataPropertyName = "month";
            this.month.HeaderText = "Месяц";
            this.month.Name = "month";
            this.month.ReadOnly = true;
            this.month.Width = 65;
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
            // year
            // 
            this.year.DataPropertyName = "year";
            this.year.HeaderText = "Год";
            this.year.Name = "year";
            this.year.ReadOnly = true;
            this.year.Width = 50;
            // 
            // gvMenu
            // 
            this.gvMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_LoadFile,
            this.mi_ViewResult,
            this.mi_DelDrug});
            this.gvMenu.Name = "gvMenu";
            this.gvMenu.Size = new System.Drawing.Size(215, 70);
            // 
            // mi_LoadFile
            // 
            this.mi_LoadFile.Name = "mi_LoadFile";
            this.mi_LoadFile.Size = new System.Drawing.Size(214, 22);
            this.mi_LoadFile.Text = "Загрузить файл";
            this.mi_LoadFile.Click += new System.EventHandler(this.mi_LoadFile_Click);
            // 
            // mi_ViewResult
            // 
            this.mi_ViewResult.Name = "mi_ViewResult";
            this.mi_ViewResult.Size = new System.Drawing.Size(214, 22);
            this.mi_ViewResult.Text = "Посмотреть содержимое";
            this.mi_ViewResult.Click += new System.EventHandler(this.mi_ViewResult_Click);
            // 
            // mi_DelDrug
            // 
            this.mi_DelDrug.Name = "mi_DelDrug";
            this.mi_DelDrug.Size = new System.Drawing.Size(214, 22);
            this.mi_DelDrug.Text = "Удалить файл";
            this.mi_DelDrug.Click += new System.EventHandler(this.mi_DelDrug_Click);
            // 
            // fListFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 389);
            this.Controls.Add(this.gvFiles);
            this.Name = "fListFiles";
            this.Text = "fListFiles";
            this.Shown += new System.EventHandler(this.fListFiles_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gvFiles)).EndInit();
            this.gvMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvFiles;
        private System.Windows.Forms.ContextMenuStrip gvMenu;
        private System.Windows.Forms.ToolStripMenuItem mi_LoadFile;
        private System.Windows.Forms.ToolStripMenuItem mi_ViewResult;
        private System.Windows.Forms.ToolStripMenuItem mi_DelDrug;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn chain_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn chain;
        private System.Windows.Forms.DataGridViewTextBoxColumn month_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn month;
        private System.Windows.Forms.DataGridViewTextBoxColumn year_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn year;
    }
}