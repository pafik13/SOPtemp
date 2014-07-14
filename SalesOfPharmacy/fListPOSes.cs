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
    public partial class fListPOSes : Form
    {
        Dictionary<string, string> context;
        private MySqlConnection conn = null;

        private int currentRow = -1;

        public fListPOSes()
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

        private void fListPOSes_Shown(object sender, EventArgs e)
        {
            LoadPOSes();
        }

        private void LoadPOSes()
        {
            string command = " SELECT tp.id,             " +
                             "        tp.name,           " +
                             "        tp.chain_id,       " +
                             "        tc.name chain_name " +
                             "   FROM tbl_poses tp       " +
                             "   JOIN tbl_chains tc      " +
                             "     ON tp.chain_id = tc.id";

            MySqlCommand cmd = new MySqlCommand(command, conn);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            if (dataset.Tables.Count > 0)
                gvPOSes.DataSource = dataset.Tables[0];
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
                gvPOSes.CurrentCell = gvPOSes.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void mi_DelDrug_Click(object sender, EventArgs e)
        {
            if (currentRow != -1)
            {
                string command = "DELETE FROM dbsop.tbl_poses WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(command, conn);

                cmd.Parameters.AddWithValue("@id", gvPOSes.Rows[currentRow].Cells[0].Value);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Deleted!");
                    LoadPOSes();
                }
                else
                {
                    MessageBox.Show("Not deleted! Try again!");
                }
            }
        }


        private void gvDrugs_MouseDown(object sender, MouseEventArgs e)
        {
            if (gvPOSes.RowCount == 0)
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
            fEditPOS edt = new fEditPOS();
            edt.AddContext(conn);
            if (edt.ShowDialog() == DialogResult.OK)
            {
                LoadPOSes();
                gvPOSes.CurrentCell = gvPOSes.Rows[gvPOSes.RowCount - 1].Cells[1];
            }
        }

        private void mi_EditChain_Click(object sender, EventArgs e)
        {
            fEditPOS edt = new fEditPOS();
            edt.AddContext(conn);
            if (currentRow != -1) { edt.AddContext("ID", gvPOSes.Rows[currentRow].Cells[0].Value.ToString()); }
            if (edt.ShowDialog() == DialogResult.OK)
            {
                LoadPOSes();
                gvPOSes.CurrentCell = gvPOSes.Rows[currentRow].Cells[1];
            }
        }
    }
}
