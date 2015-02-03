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

        private int currentRow = -1;

        public fListDrugs()
        {
            InitializeComponent();

            context = new Dictionary<string, string>();
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
                LoadDrugs();
            }
            else
            {
                gvMenu.Enabled = false;
            }
        }

        private void LoadDrugs()
        {
            string command = "SELECT d.id, d.name FROM dbsop.tbl_drugs d";
            MySqlCommand cmd = new MySqlCommand(command, conn);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            if (dataset.Tables.Count > 0)
            {
                ((BindingSource)gvDrugs.DataSource).DataSource = dataset.Tables[0];
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
                string command = "DELETE FROM dbsop.tbl_drugs WHERE id = @id";
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
