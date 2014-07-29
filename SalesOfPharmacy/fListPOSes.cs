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

        private void fListChains_Shown(object sender, EventArgs e)
        {
            LoadPOSes();
        }

        private void LoadPOSes()
        {
            string command = "SELECT * FROM vw_poses";
            MySqlCommand cmd = new MySqlCommand(command, conn);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            if (dataset.Tables.Count > 0)
                gvPOSes.DataSource = dataset.Tables[0];
        }

        private void gvPOSes_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                currentRow = e.RowIndex;
                gvPOSes.CurrentCell = gvPOSes.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void mi_DelPOS_Click(object sender, EventArgs e)
        {
            if (currentRow != -1)
            {
                if (MessageBox.Show("Хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        string command = "DELETE FROM tbl_poses WHERE id = @id";
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
                    catch (MySqlException mysqlExc)
                    {
                        MessageBox.Show(mysqlExc.Message, mysqlExc.ErrorCode.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void gvPOSes_MouseDown(object sender, MouseEventArgs e)
        {
            if (gvPOSes.RowCount == 0)
            {
                mi_EditPOS.Enabled = false;
                mi_DelPOS.Enabled = false;
            }
            else
            {
                mi_EditPOS.Enabled = true;
                mi_DelPOS.Enabled = true;
            }
        }

        private void mi_AddPOS_Click(object sender, EventArgs e)
        {
            fEditPOS edt = new fEditPOS();
            edt.AddContext(conn);
            if (edt.ShowDialog() == DialogResult.OK)
            {
                LoadPOSes();
                gvPOSes.CurrentCell = gvPOSes.Rows[gvPOSes.RowCount - 1].Cells[1];
                gvPOSes.FirstDisplayedScrollingRowIndex = gvPOSes.RowCount - 1;
            }
        }

        private void mi_EditPOS_Click(object sender, EventArgs e)
        {
            fEditPOS edt = new fEditPOS();
            edt.AddContext(conn);
            if (currentRow != -1) { edt.AddContext("ID", gvPOSes.Rows[currentRow].Cells[0].Value.ToString()); }
            if (edt.ShowDialog() == DialogResult.OK)
            {
                LoadPOSes();
                gvPOSes.CurrentCell = gvPOSes.Rows[currentRow].Cells[1];
                gvPOSes.FirstDisplayedScrollingRowIndex = currentRow;
            }
        }
    }
}
