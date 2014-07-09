namespace SalesOfPharmacy
{
    partial class fListChains
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
            this.gvChains = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddChain = new System.Windows.Forms.ToolStripMenuItem();
            this.EditChain = new System.Windows.Forms.ToolStripMenuItem();
            this.DelChain = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gvChains)).BeginInit();
            this.gvMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvChains
            // 
            this.gvChains.AllowUserToAddRows = false;
            this.gvChains.AllowUserToDeleteRows = false;
            this.gvChains.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvChains.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvChains.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvChains.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name});
            this.gvChains.ContextMenuStrip = this.gvMenu;
            this.gvChains.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvChains.Location = new System.Drawing.Point(0, 0);
            this.gvChains.Name = "gvChains";
            this.gvChains.ReadOnly = true;
            this.gvChains.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvChains.Size = new System.Drawing.Size(514, 307);
            this.gvChains.TabIndex = 0;
            this.gvChains.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.gvChains_CellContextMenuStripNeeded);
            this.gvChains.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvChains_CellMouseDown);
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
            this.AddChain,
            this.EditChain,
            this.DelChain});
            this.gvMenu.Name = "gvMenu";
            this.gvMenu.Size = new System.Drawing.Size(238, 92);
            // 
            // AddChain
            // 
            this.AddChain.Name = "AddChain";
            this.AddChain.Size = new System.Drawing.Size(237, 22);
            this.AddChain.Text = "Добавить аптечную сеть";
            // 
            // EditChain
            // 
            this.EditChain.Name = "EditChain";
            this.EditChain.Size = new System.Drawing.Size(237, 22);
            this.EditChain.Text = "Редактировать аптечную сеть";
            // 
            // DelChain
            // 
            this.DelChain.Name = "DelChain";
            this.DelChain.Size = new System.Drawing.Size(237, 22);
            this.DelChain.Text = "Удалить аптечную сеть";
            this.DelChain.Click += new System.EventHandler(this.DelChain_Click);
            // 
            // fListChains
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 307);
            this.Controls.Add(this.gvChains);
            this.Name = "fListChains";
            this.Text = "fListChains";
            this.Shown += new System.EventHandler(this.fListChains_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gvChains)).EndInit();
            this.gvMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvChains;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.ContextMenuStrip gvMenu;
        private System.Windows.Forms.ToolStripMenuItem AddChain;
        private System.Windows.Forms.ToolStripMenuItem EditChain;
        private System.Windows.Forms.ToolStripMenuItem DelChain;
    }
}