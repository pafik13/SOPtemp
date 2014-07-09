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
    public partial class fListChains : Form
    {
        Dictionary<string, string> context;
        private MySqlConnection conn = null;

        private int currentRow = -1;

        public fListChains()
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
            LoadChains();
        }

        private void LoadChains()
        {
            string command = "SELECT c.id, c.name FROM dbsop.tbl_chains c";
            MySqlCommand cmd = new MySqlCommand(command, conn);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            if (dataset.Tables.Count > 0)
                gvChains.DataSource = dataset.Tables[0];
        }

        private void gvChains_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if (gvChains.RowCount == 0) {
                EditChain.Enabled = false;
                DelChain.Enabled = false;

            } else {
                EditChain.Enabled = true;
                DelChain.Enabled = true;
                if (e.RowIndex > -1) {
                    currentRow = e.RowIndex;
                }
            }
        }

        private void gvChains_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Right) && (e.RowIndex > -1))
            {
                // Add this
                gvChains.CurrentCell = gvChains.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void DelChain_Click(object sender, EventArgs e)
        {
            if (currentRow != -1)
            {
                string command = "DELETE FROM dbsop.tbl_chains c WHERE c.id = @id";
                MySqlCommand cmd = new MySqlCommand(command, conn);

                cmd.Parameters.AddWithValue("@id", gvChains.Rows[currentRow].Cells[0].Value);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Deleted!");
                    LoadChains();
                }
                else
                {
                    MessageBox.Show("Not deleted! Try again!");
                }
            }
        }
    }
}
