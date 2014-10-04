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
    public partial class fResult : Form
    {
        Dictionary<string, string> context;
        private MySqlConnection conn = null;

        private int currentRow = -1;
        private int numOfDrugs = 0;

        public fResult()
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

        private void fResult_Shown(object sender, EventArgs e)
        {
            LoadResults();
        }

        private void LoadResults()
        {
            if (context.ContainsKey("FILE_ID"))
            {
                gvResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                string command = "SELECT @rn := @rn + 1 AS rowNum, r.* FROM vw_results r, (select @rn := 0) rn WHERE r.fr_id = @fr_id";

                MySqlCommand cmd = new MySqlCommand(command, conn);

                cmd.Parameters.AddWithValue("@fr_id", context["FILE_ID"]);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);

                if (dataset.Tables.Count > 0)
                {
                    gvResult.DataSource = new BindingSource() { DataSource = dataset.Tables[0] };
                }

                gvResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            }
            else
            {
                MessageBox.Show("Не найден параметр [FILE_ID]!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void gvResult_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {

            if ((Convert.ToInt32(gvResult.Rows[e.RowIndex].Cells[3].Value) == 0)
               || (Convert.ToInt32(gvResult.Rows[e.RowIndex].Cells[5].Value) == 0)
               || (Convert.ToInt32(gvResult.Rows[e.RowIndex].Cells[7].Value) == 0)
               )
            {
                gvResult.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightPink;
            }
        }

        private void gvResult_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                currentRow = e.RowIndex;
            }
        }

        private void gvResult_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Right) && (e.RowIndex > -1))
            {
                // Add this
                gvResult.CurrentCell = gvResult.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void mi_DelDrug_Click(object sender, EventArgs e)
        {
            if (currentRow != -1)
            {
                if (MessageBox.Show("Хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        string command = "DELETE FROM dbsop.tbl_poses WHERE id = @id";
                        MySqlCommand cmd = new MySqlCommand(command, conn);

                        cmd.Parameters.AddWithValue("@id", gvResult.Rows[currentRow].Cells[0].Value);

                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Deleted!");
                            LoadResults();
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


        private void gvDrugs_MouseDown(object sender, MouseEventArgs e)
        {
            if (gvResult.RowCount == 0)
            {
                mi_Add_MD_POS.Enabled = false;
                mi_Add_MD_Drug.Enabled = false;
            }
            else
            {
                mi_Add_MD_POS.Enabled = true;
                mi_Add_MD_Drug.Enabled = true;
            }
        }

        private void Locate(string col, string val)
        {
            if (!string.IsNullOrEmpty(val))
            {
                foreach (DataGridViewRow row in gvResult.Rows)
                {
                    if (row.Cells[col].Value.ToString().Equals(val))
                    {
                        row.Selected = true;
                        gvResult.FirstDisplayedScrollingRowIndex = row.Index;
                        break;
                    }
                }
            }
        }

        private void mi_Add_MD_POS_Click(object sender, EventArgs e)
        {
            fEdit_MD_POS edt = new fEdit_MD_POS();
            edt.AddContext("POS", gvResult.Rows[currentRow].Cells["pos"].Value.ToString());
            edt.AddContext("chain_id", gvResult.Rows[currentRow].Cells["chain_id"].Value.ToString());
            edt.AddContext(conn);
            if (edt.ShowDialog(this) == DialogResult.OK)
            {
                LoadResults();
                gvResult.Rows[currentRow].Selected = true;
                gvResult.FirstDisplayedScrollingRowIndex = currentRow;
                //Locate(currentRow.ToString());
            };
            edt.Dispose();
        }

        private void mi_Add_MD_Drug_Click(object sender, EventArgs e)
        {
            fEdit_MD_Drug edt = new fEdit_MD_Drug();
            edt.AddContext("Drug", gvResult.Rows[currentRow].Cells["drug"].Value.ToString());
            edt.AddContext(conn);
            if (edt.ShowDialog(this) == DialogResult.OK)
            {
                LoadResults();
                gvResult.Rows[currentRow].Selected = true;
                gvResult.FirstDisplayedScrollingRowIndex = currentRow;
                //Locate(currentRow.ToString());
            };
            edt.Dispose();
        }

        private void mi_Refresh_Click(object sender, EventArgs e)
        {
            LoadResults();
        }

        private void gvResult_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            numOfDrugs = 0;

            for (int i = 0; i < gvResult.Rows.Count; i++)
            {
                int number = 0;
                if (int.TryParse(gvResult.Rows[i].Cells["num"].Value.ToString(), out number))
                {
                    numOfDrugs = numOfDrugs + number;
                }
            }

            gvResult.Columns["num"].HeaderText = "Количество [" + numOfDrugs.ToString() + "] ";
        }
    }
}
