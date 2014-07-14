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
    public partial class fList_MD_POSes : Form
    {
        Dictionary<string, string> context;
        private MySqlConnection conn = null;

        private int currentRow = -1;

        public fList_MD_POSes()
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

        private void fList_MD_POSes_Shown(object sender, EventArgs e)
        {
            Load_MD_POSes();
        }

        private void Load_MD_POSes()
        {
            string command = "SELECT tmdod.id                       "
                           + "     , tmdod.model_name               "
                           + "     , tmdod.drug_id                  "
                           //+ "     , td.id                          "
                           + "     , td.name                        "
                           + "  FROM tbl_model_data_of_drugs tmdod  "
                           + "  JOIN tbl_drugs td                   "
                           + "    ON ( td.id = tmdod.drug_id )      "
                           + " ORDER                                "
                           + "    BY td.name                        ";
            MySqlCommand cmd = new MySqlCommand(command, conn);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            if (dataset.Tables.Count > 0)
                gv_MD_POSes.DataSource = dataset.Tables[0];
        }

        private void gv_MD_Drugs_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if (e.RowIndex > -1) {
                currentRow = e.RowIndex;
            }
        }

        private void gv_MD_Drugs_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Right) && (e.RowIndex > -1))
            {
                // Add this
                gv_MD_POSes.CurrentCell = gv_MD_POSes.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void mi_Del_MD_Drug_Click(object sender, EventArgs e)
        {
            if (currentRow != -1)
            {
                string command = "DELETE FROM dbsop.tbl_model_data_of_poses WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(command, conn);

                cmd.Parameters.AddWithValue("@id", gv_MD_POSes.Rows[currentRow].Cells[0].Value);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Deleted!");
                    Load_MD_POSes();
                }
                else
                {
                    MessageBox.Show("Not deleted! Try again!");
                }
            }
        }


        private void gv_MD_Drugs_MouseDown(object sender, MouseEventArgs e)
        {
            if (gv_MD_POSes.RowCount == 0) {
                mi_Edit_MD_Drug.Enabled = false;
                mi_Del_MD_Drug.Enabled  = false;
            } else {
                mi_Edit_MD_Drug.Enabled = true;
                mi_Del_MD_Drug.Enabled  = true;
            }
        }

        private void mi_Add_MD_Drug_Click(object sender, EventArgs e)
        {
            fEdit_MD_Drug edt = new fEdit_MD_Drug();
            edt.AddContext(conn);
            if (edt.ShowDialog() == DialogResult.OK)
            {
                Load_MD_POSes();
                gv_MD_POSes.CurrentCell = gv_MD_POSes.Rows[gv_MD_POSes.RowCount - 1].Cells[1];
            }
        }

        private void mi_Edit_MD_Drug_Click(object sender, EventArgs e)
        {
            fEdit_MD_Drug edt = new fEdit_MD_Drug();
            edt.AddContext(conn);
            if (currentRow != -1) { edt.AddContext("ID", gv_MD_POSes.Rows[currentRow].Cells[0].Value.ToString()); }
            if (edt.ShowDialog() == DialogResult.OK)
            {
                Load_MD_POSes();
                gv_MD_POSes.CurrentCell = gv_MD_POSes.Rows[currentRow].Cells[1];
            }
        }
    }
}
