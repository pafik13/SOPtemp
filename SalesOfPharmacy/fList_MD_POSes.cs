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
        DataSet dataset = null;

        private int currentRow = -1;

        public fList_MD_POSes()
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

        private void fList_MD_POSes_Shown(object sender, EventArgs e)
        {
            gv_MD_POSes.DataSource = new BindingSource();
            if (conn.State == ConnectionState.Open)
            {
                gvMenu.Enabled = true;
                if (dataset.Tables.Count > 0)
                {
                    ((BindingSource)gv_MD_POSes.DataSource).DataSource = dataset.Tables[0];
                }
            }
            else
            {
                MessageBox.Show("Нет соединения с базой данных. Проверьте работоспособность БД.", "Отсутствует соединение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gvMenu.Enabled = false;
            }
        }

        public void Load_MD_POSes()
        {
            if (conn.State == ConnectionState.Open)
            {
                string command = "SELECT mdop.id           AS mn_id    "
                               + "     , mdop.model_name               "
                               + "     , p.id              AS pos_id   "
                               + "     , p.name            AS pos_name "
                               + "     , p.chain_id                    "
                               + "     , p.chain_name                  "
                               + "  FROM tbl_model_data_of_poses mdop  "
                               + "  JOIN vw_poses p                    "
                               + "    ON ( mdop.pos_id = p.id )        "
                               + " ORDER                               "
                               + "    BY p.chain_name, p.name          ";
                MySqlCommand cmd = new MySqlCommand(command, conn);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dataset);
            }
        }

        private void gv_MD_POSes_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if (e.RowIndex > -1) {
                currentRow = e.RowIndex;
            }
        }

        private void gv_MD_POSes_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Right) && (e.RowIndex > -1))
            {
                // Add this
                gv_MD_POSes.CurrentCell = gv_MD_POSes.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void mi_Del_MD_POS_Click(object sender, EventArgs e)
        {
            if (currentRow != -1)
            {
                string command = "DELETE FROM tbl_model_data_of_poses WHERE id = @id";
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


        private void gv_MD_POSes_MouseDown(object sender, MouseEventArgs e)
        {
            if (gv_MD_POSes.RowCount == 0) {
                mi_Edit_MD_POS.Enabled = false;
                mi_Del_MD_POS.Enabled  = false;
            } else {
                mi_Edit_MD_POS.Enabled = true;
                mi_Del_MD_POS.Enabled  = true;
            }
        }

        private void mi_Add_MD_POS_Click(object sender, EventArgs e)
        {
            fEdit_MD_POS edt = new fEdit_MD_POS();
            edt.AddContext(conn);
            edt.Text = "Добавление кл. слов к аптеке";
            edt.AddContext("POS", "");
            if (edt.ShowDialog() == DialogResult.OK)
            {
                Load_MD_POSes();
                gv_MD_POSes.CurrentCell = gv_MD_POSes.Rows[gv_MD_POSes.RowCount - 1].Cells[1];
            }
            edt.Dispose();
        }

        private void mi_Edit_MD_POS_Click(object sender, EventArgs e)
        {
            fEdit_MD_POS edt = new fEdit_MD_POS();
            edt.AddContext(conn);
            edt.Text = "Редактирование кл. слов";
            if (currentRow != -1) { edt.AddContext("ID", gv_MD_POSes.Rows[currentRow].Cells[0].Value.ToString()); }
            if (edt.ShowDialog() == DialogResult.OK)
            {
                Load_MD_POSes();
                gv_MD_POSes.CurrentCell = gv_MD_POSes.Rows[currentRow].Cells[1];
            }
            edt.Dispose();
        }
    }
}
