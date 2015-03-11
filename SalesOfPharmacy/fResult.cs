using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
//using System.Windowss
using MySql.Data.MySqlClient;

namespace SalesOfPharmacy
{
    public partial class fResult : Form
    {
        Dictionary<string, string> context;
        DataSet dataset;
        private MySqlConnection conn = null;

        private int currentRow = -1;
        private int numOfDrugs = 0;

        public fResult()
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

        private void fResult_Shown(object sender, EventArgs e)
        {
            gvResult.DataSource = new BindingSource();
            if (conn.State == ConnectionState.Open)
            {
                gvMenu.Enabled = true;

                if (dataset != null)
                {
                    if (dataset.Tables.Count > 0)
                    {
                        ((BindingSource)gvResult.DataSource).DataSource = dataset.Tables[0];
                    }
                }

            }
            else
            {
                gvMenu.Enabled = false;
            }
        }

        public void LoadResults()
        {
            if (context.ContainsKey("FILE_ID"))
            {
 //               gvResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                string command = "SELECT @rn := @rn + 1 AS rowNum                       "
                               + "     , r.*                                            "
                               + "     , (3 - r.p_flag - r.d_flag  - r.n_flag) AS num_oe"                  
                               + "  FROM vw_results r                                   "
                               + "     , (select @rn := 0) rn                           "
                               + " WHERE r.fr_id = @fr_id                               ";

                MySqlCommand cmd = new MySqlCommand(command, conn);

                cmd.Parameters.AddWithValue("@fr_id", context["FILE_ID"]);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dataset);

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

            if (gvResult.RowCount == 0)
            {
                mi_Add_POS.Enabled = false;
                mi_Add_MD_POS.Enabled = false;
                mi_Add_MD_Drug.Enabled = false;
            }
            else if (gvResult.SelectedRows.Count > 1)
            {
                mi_Add_POS.Enabled = true;
                mi_Add_POS.Text = "Добавить аптеки";
                mi_Add_MD_POS.Enabled = false;
                mi_Add_MD_Drug.Enabled = false;
            }
            else
            {
                mi_Add_POS.Enabled = true;
                mi_Add_POS.Text = "Добавить аптеку";
                mi_Add_MD_POS.Enabled = true;
                mi_Add_MD_Drug.Enabled = true;
            }
        }

        private void gvResult_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Right) && (gvResult.SelectedRows.Count < 2) && (e.RowIndex > -1) && (e.ColumnIndex > -1))
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
                        string command = "DELETE FROM tbl_poses WHERE id = @id";
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

        private void gvMenu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void mi_Add_POS_Click(object sender, EventArgs e)
        {
            int countOfNewPoses = 0;
            if (currentRow != -1)
            {
                if (MessageBox.Show("Хотите добавить аптеки с ключевыми фразами?", "Добавление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in gvResult.SelectedRows)
                    {
                        string command = "SELECT count(*) FROM vw_md_pos WHERE model_name = @name AND chain_id = @chain_id";
                        MySqlCommand cmd = new MySqlCommand(command, conn);

                        cmd.Parameters.AddWithValue("@name", row.Cells["pos"].Value);
                        cmd.Parameters.AddWithValue("@chain_id", row.Cells["chain_id"].Value);

                        if (int.Parse(cmd.ExecuteScalar().ToString()) == 0)
                        {

                            MySqlTransaction trans = conn.BeginTransaction();
                            try
                            {
                                cmd.CommandText = "INSERT INTO tbl_poses(name, chain_id) VALUES(@name, @chain_id)";
                                cmd.Transaction = trans;

                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@name", row.Cells["pos"].Value);
                                cmd.Parameters.AddWithValue("@chain_id", row.Cells["chain_id"].Value);

                                if (cmd.ExecuteNonQuery() == 1)
                                {
                                    string command2 = "INSERT INTO tbl_model_data_of_poses(model_name, pos_id) VALUES(@model_name, @pos_id)";
                                    MySqlCommand cmd2 = new MySqlCommand(command2, conn, trans);

                                    cmd2.Parameters.AddWithValue("@model_name", row.Cells["pos"].Value);
                                    cmd2.Parameters.AddWithValue("@pos_id", cmd.LastInsertedId);

                                    if (cmd2.ExecuteNonQuery() == 1)
                                    {
                                        countOfNewPoses = countOfNewPoses + 1;
                                        try
                                        {
                                            trans.Commit();
                                        }
                                        catch (MySqlException exc)
                                        {
                                            MessageBox.Show("Произошла ошибка сохранения транзакции! Текст ошибки: \n {0}", exc.Message);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Ошибки добавления записей - попробуйте еще!");
                                        try
                                        {
                                            trans.Rollback();
                                        }
                                        catch (MySqlException exc)
                                        {
                                            MessageBox.Show("Произошла ошибка отката транзакции! Текст ошибки: \n {0}", exc.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Ошибки добавления записей - попробуйте еще!");
                                    try
                                    {
                                        trans.Rollback();
                                    }
                                    catch (MySqlException exc)
                                    {
                                        MessageBox.Show("Произошла ошибка отката транзакции! Текст ошибки: \n {0}", exc.Message);
                                    }
                                }
                            }
                            catch (MySqlException mysqlExc)
                            {
                                trans.Rollback();
                                MessageBox.Show(mysqlExc.Message, mysqlExc.ErrorCode.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    MessageBox.Show(String.Format("Было добавлено {0} записей!", countOfNewPoses));
                    LoadResults();
                    gvResult.Rows[currentRow].Selected = true;
                    gvResult.FirstDisplayedScrollingRowIndex = currentRow;
                }
            }
        }

        private void gvResult_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void gvResult_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                foreach (DataGridViewColumn column in this.gvResult.Columns)
                {
                    gvResult.Sort(gvResult.Columns["id"], ListSortDirection.Ascending);
                }
            }
        }
    }
}
