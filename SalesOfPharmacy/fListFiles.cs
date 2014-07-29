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
    public partial class fListFiles : Form
    {
        Dictionary<string, string> context;
        Dictionary<string, string> pcontext;

        private MySqlConnection conn = null;

        private int currentRow = -1;

        public fListFiles()
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

        internal void AddContext(Dictionary<string, string> parentContext)
        {
            pcontext = parentContext;
        }

        private void LoadFiles()
        {
            string command = "SELECT f.* FROM vw_files f";
            MySqlCommand cmd = new MySqlCommand(command, conn);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            if (dataset.Tables.Count > 0)
                gvFiles.DataSource = dataset.Tables[0];
        }

        private void fListFiles_Shown(object sender, EventArgs e)
        {
            LoadFiles();
        }

        private void gvFiles_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                currentRow = e.RowIndex;
                gvFiles.CurrentCell = gvFiles.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void mi_LoadFile_Click(object sender, EventArgs e)
        {
            fLoadNewFile lFile = new fLoadNewFile();
            lFile.AddContext(conn);
            lFile.AddContext(context);

            if (lFile.ShowDialog(this) == DialogResult.OK)
            {
                LoadFiles();
                gvFiles.CurrentCell = gvFiles.Rows[gvFiles.RowCount - 1].Cells[1];
            }

            lFile.Dispose();
        }

        private void mi_ViewResult_Click(object sender, EventArgs e)
        {
            if (currentRow != -1)
            {
                fResult fRes = new fResult();
                fRes.AddContext(conn);
                fRes.AddContext("FILE_ID", gvFiles.Rows[currentRow].Cells[0].Value.ToString());
                fRes.MdiParent = this.MdiParent;
                fRes.Show();
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
                        string command = "DELETE FROM tbl_file_raw WHERE id = @id";
                        MySqlCommand cmd = new MySqlCommand(command, conn);

                        cmd.Parameters.AddWithValue("@id", gvFiles.Rows[currentRow].Cells[0].Value);

                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Deleted!");
                            LoadFiles();
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


    }
}
