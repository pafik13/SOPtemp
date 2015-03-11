using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SalesOfPharmacy
{
    public partial class fListDrugs : Form
    {
        Dictionary<string, string> context;
        private MySqlConnection conn = null;
        DataSet dataset = null;

        private int currentRow = -1;

        public fListDrugs()
        {
            InitializeComponent();

            context = new Dictionary<string, string>();
            dataset = new DataSet();
        }

        internal void AddContext(string key, string value)
        {
            context.Add(key, value);
        }

        internal void AddContext(MySqlConnection connection)
        {
            conn = connection;
        }

        private void fListChains_Shown(object sender, EventArgs e)
        {
            gvDrugs.DataSource = new BindingSource();
            if (conn.State == ConnectionState.Open)
            {
                if (dataset.Tables.Count > 0)
                {
                    ((BindingSource)gvDrugs.DataSource).DataSource = dataset.Tables[0];
                }
            }
            else
            {
                MessageBox.Show("Нет соединения с базой данных. Проверьте работоспособность БД.", "Отсутствует соединение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gvMenu.Enabled = false;
            }
        }

        public void LoadDrugs()
        {
            if (conn.State == ConnectionState.Open)
            {
                string command = "SELECT d.id, d.name FROM tbl_drugs d ORDER BY d.name";
                MySqlCommand cmd = new MySqlCommand(command, conn);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dataset);
            }
        }

        private void gvDrugs_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                currentRow = e.RowIndex;
            }
        }

        private void gvDrugs_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Right) && (e.RowIndex > -1))
            {
                // Add this
                gvDrugs.CurrentCell = gvDrugs.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void mi_DelDrug_Click(object sender, EventArgs e)
        {
            if (currentRow != -1)
            {
                string command = "DELETE FROM tbl_drugs WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(command, conn);

                cmd.Parameters.AddWithValue("@id", gvDrugs.Rows[currentRow].Cells[0].Value);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Deleted!");
                    LoadDrugs();
                }
                else
                {
                    MessageBox.Show("Not deleted! Try again!");
                }
            }
        }


        private void gvDrugs_MouseDown(object sender, MouseEventArgs e)
        {
            if (gvDrugs.RowCount == 0)
            {
                mi_EditDrug.Enabled = false;
                mi_DelDrug.Enabled = false;
            }
            else
            {
                mi_EditDrug.Enabled = true;
                mi_DelDrug.Enabled = true;
            }
        }

        private void mi_AddChain_Click(object sender, EventArgs e)
        {
            fEditDrug edt = new fEditDrug();
            edt.Text = "Добавление препарата";
            edt.AddContext(conn);
            if (edt.ShowDialog() == DialogResult.OK)
            {
                LoadDrugs();
                gvDrugs.CurrentCell = gvDrugs.Rows[gvDrugs.RowCount - 1].Cells[1];
            }
        }

        private void mi_EditChain_Click(object sender, EventArgs e)
        {
            fEditDrug edt = new fEditDrug();
            edt.Text = "Редактирование препарата";
            edt.AddContext(conn);
            if (currentRow != -1) { edt.AddContext("ID", gvDrugs.Rows[currentRow].Cells[0].Value.ToString()); }
            if (edt.ShowDialog() == DialogResult.OK)
            {
                LoadDrugs();
                gvDrugs.CurrentCell = gvDrugs.Rows[currentRow].Cells[1];
            }
        }
    }
}
