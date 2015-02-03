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

        private Form FindForm(Type formType)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == formType)
                {
                    return form;
                }
            }
            return null;
        }

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
            gvChains.DataSource = new BindingSource();
            if (conn.State == ConnectionState.Open)
            {
                gvMenu.Enabled = true;
                LoadChains();
            }
            else
            {
                gvMenu.Enabled = false;
            }
        }

        private void LoadChains()
        {

            string command = "SELECT c.id, c.name FROM dbsop.tbl_chains c ORDER BY c.name";
            MySqlCommand cmd = new MySqlCommand(command, conn);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            if (dataset.Tables.Count > 0)
            {
                ((BindingSource)gvChains.DataSource).DataSource = dataset.Tables[0];
            }

        }

        private void gvChains_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if (e.RowIndex > -1) {
                currentRow = e.RowIndex;
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
                string command = "DELETE FROM dbsop.tbl_chains WHERE id = @id";
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


        private void gvChains_MouseDown(object sender, MouseEventArgs e)
        {
            if (gvChains.RowCount == 0) {
                EditChain.Enabled = false;
                DelChain.Enabled  = false;
                ShowPOSes.Enabled = false;
            } else {
                EditChain.Enabled = true;
                DelChain.Enabled  = true;
                ShowPOSes.Enabled = true;
            }
        }

        private void AddChain_Click(object sender, EventArgs e)
        {
            fEditChain edt = new fEditChain();
            edt.AddContext(conn);
            if (edt.ShowDialog() == DialogResult.OK)
            {
                LoadChains();
                gvChains.CurrentCell = gvChains.Rows[gvChains.RowCount - 1].Cells[1];
                gvChains.FirstDisplayedScrollingRowIndex = gvChains.RowCount - 1;
            }
        }

        private void EditChain_Click(object sender, EventArgs e)
        {
            fEditChain edt = new fEditChain();
            edt.AddContext(conn);
            if (currentRow != -1) { edt.AddContext("ID", gvChains.Rows[currentRow].Cells[0].Value.ToString()); }
            if (edt.ShowDialog() == DialogResult.OK)
            {
                LoadChains();
                gvChains.CurrentCell = gvChains.Rows[currentRow].Cells[1];
                gvChains.FirstDisplayedScrollingRowIndex = currentRow;
            }
        }

        private void ShowPOSes_Click(object sender, EventArgs e)
        {
            fListPOSes lst = (fListPOSes)FindForm(typeof(fListPOSes));
            if (lst != null)
            {
                lst.Close();
            }

            lst = new fListPOSes();
            lst.MdiParent = this.MdiParent;
            lst.AddContext(conn);
            lst.AddContext("CHAIN_ID", gvChains.Rows[currentRow].Cells[0].Value.ToString());
            lst.Text = "Список аптек аптечной сети - " + gvChains.Rows[currentRow].Cells[1].Value.ToString();
            lst.Show();
        }
    }
}
