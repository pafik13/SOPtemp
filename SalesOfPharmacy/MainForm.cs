using System;
using System.IO;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections;
using System.Collections.Generic;
//using System.ComponentModel;
using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing;
//using System.Drawing;
//using System.Linq;
//using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Threading;

namespace SalesOfPharmacy
{
    public partial class MainForm : Form
    {
        private Dictionary<string, string> context;
        private MySqlConnection conn = null;
        private Excel.Application excelApp = null;

        private List<string> POSes; //= new List<string>();
        private List<string> drugs;//= new List<string>();
        private List<string> nums; //= new List<string>();

        private int currentRow = -1;

        public MainForm()
        {
            InitializeComponent();

            context = new Dictionary<string, string>();

            conn = new MySqlConnection(ConfigurationManager.AppSettings["connString"]);
            try
            {
              conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            if ((conn.State != ConnectionState.Closed) && bool.Parse(ConfigurationManager.AppSettings["isShowConnectionInfo"])) {
                MessageBox.Show( "   ServerVersion : " + conn.ServerVersion
                               + "\n Connection State : " + conn.State.ToString());
            }

            excelApp = new Excel.Application();

            context.Add("SHOW", "-1");
        }

        void Test()
        {
            string sAttr;

            // Read a particular key from the config file            
            sAttr = ConfigurationManager.AppSettings["connString"];
            MessageBox.Show("The value of Key0: " + sAttr);

            // Read all the keys from the config file
            NameValueCollection sAll;
            sAll = ConfigurationManager.AppSettings;

            foreach (string s in sAll.AllKeys)
                MessageBox.Show("Key: " + s + " Value: " + sAll.Get(s));
        }

        private bool GetInfoFromExcel(string filePath, int chain_id = 0)
        {
            excelApp.Workbooks.Open(filePath,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing
                );
            
            excelApp.Visible = true;
            excelApp.UserControl = false;

            POSes = new List<string>();
            drugs = new List<string>();
            nums = new List<string>();

            for (int i = 1; i <= excelApp.Worksheets.Count; i++) {
                Excel.Worksheet workSheet = excelApp.Worksheets.get_Item(i);

                workSheet.Select(Type.Missing);

                POSes.AddRange(GetValues("Точки", workSheet));
                drugs.AddRange(GetValues("Препараты", workSheet));
                nums.AddRange(GetValues("Количество", workSheet));

                //pointOfSales = GetValues("Точки", wS);
                //drugs = GetValues("Препараты", wS);
                //numbers = GetValues("Количество", wS);

                //Thread.Sleep(3000);

                //workSheet.Range["Препараты"].Select();

                //Thread.Sleep(3000);

                //workSheet.Range["Количество"].Select();

                //Thread.Sleep(3000);

            }

            excelApp.Workbooks.Close();

            excelApp.Quit();

            return ((POSes.Count == drugs.Count) && (nums.Count == drugs.Count));
        }

        private List<string> GetValues(string rangeName, Excel.Worksheet wSheet)
        {
            try
            {
                Excel.Range r = wSheet.get_Range(rangeName, Type.Missing);
                r.Select();
                object[,] obj = r.Value;
                List<string> list = new List<string>();
                IEnumerable array = obj as IEnumerable;
                if (array != null)
                {
                    foreach (object item in array)
                    {
                        list.Add(item.ToString());
                    }
                }

                Thread.Sleep(3000);
                
                return list;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return new List<string>();
            }
        }

        private bool InsertSalesToDB(MySqlCommand cmd, string fr_id)
        {
            int insertedRows = 0;
            try
            {
                cmd.CommandText = "INSERT INTO dbsop.tbl_file_data ( pos, drug, num, fr_id ) VALUES ( @pos, @drug, @num, @fr_id )";
                for (int i = 0; i < POSes.Count; i++)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@pos", POSes[i]);
                    cmd.Parameters.AddWithValue("@drug", drugs[i]);
                    cmd.Parameters.AddWithValue("@num", nums[i]);
                    cmd.Parameters.AddWithValue("@fr_id", fr_id);
                    insertedRows = insertedRows + cmd.ExecuteNonQuery();
                    
                }

                MessageBox.Show(String.Format("Count : {0} \n Inserted : {1}", POSes.Count, insertedRows));

                return (POSes.Count == insertedRows);
            }
            catch (MySqlException exc)
            {
                MessageBox.Show(exc.Message);
                return false;
            }
        }

        private void ShowResult(string fr_id)
        {

            string command = "SELECT @rn := @rn + 1 AS rowNum, r.* FROM dbsop.vw_results r, (select @rn := 0) rn WHERE r.fr_id = @fr_id";

            MySqlCommand cmd = new MySqlCommand(command, conn);
            cmd.Parameters.AddWithValue("@fr_id", fr_id);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            gvResult.Visible = true;
            if (dataset.Tables.Count > 0)
                gvResult.DataSource = dataset.Tables[0];

        //    for (int i = 0; i < gvResult.Columns.Count; i ++) {
        //        DataGridViewColumn col = gvResult.Columns[i];
        //        if (col.DataPropertyName == "rowNum")
        //        {
        //            col.HeaderText = "№";
        //        } 
        //        //if (col.DataPropertyName == "d_flag")
        //        //{
        //        //    col.
        //        //}
                    
        //        //MessageBox.Show("DataPropertyName : " + col.DataPropertyName);
        //    }
        //     //GetFirstColumn(DataGridViewElementStates.Visible);
        //    //conn.Close();
        //
        }

        private void mi_Load_File_Click(object sender, EventArgs e)
        {
            if (gvResult.Visible) { gvResult.Visible = false; }

            fLoadNewFile lFile = new fLoadNewFile();
            lFile.AddContext(conn);
            lFile.AddContext(context);

            if (lFile.ShowDialog(this) == DialogResult.OK)
            {
                if (!gvResult.Visible) { gvResult.Visible = true; }
                MessageBox.Show(String.Format("SHOW parameter = {0}", context["SHOW"]));
                ShowResult(context["SHOW"]);
            }

            lFile.Dispose();
            //if (oFileDlg.ShowDialog() == DialogResult.OK)
            //{
            //    if (GetInfoFromExcel(oFileDlg.FileName))
            //    {
            //        byte[] file = File.ReadAllBytes(oFileDlg.FileName);

            //        MySqlTransaction trans = conn.BeginTransaction();

            //        string command = "INSERT INTO dbsop.tbl_file_raw ( bFile, file_name ) VALUES ( @bFile, @file_name )";

            //        MySqlCommand cmd = new MySqlCommand(command, conn, trans);

            //        MySqlParameter pFile = new MySqlParameter("@bFile", MySqlDbType.Blob, file.Length);
            //        MySqlParameter pName = new MySqlParameter("@file_name", MySqlDbType.String, oFileDlg.FileName.Length);

            //        pFile.Value = file;
            //        pName.Value = Path.GetFileName(oFileDlg.FileName);

            //        cmd.Parameters.Add(pFile);
            //        cmd.Parameters.Add(pName);

            //        try
            //        {
            //            if (cmd.ExecuteNonQuery() == 1)
            //            {
            //                cmd.CommandText = "SELECT LAST_INSERT_ID()";
            //                string file_id = cmd.ExecuteScalar().ToString();

            //                if (InsertSalesToDB(cmd, file_id))
            //                {
            //                    switch (MessageBox.Show("Сохранить изменения?", "Сохранить изменения?", MessageBoxButtons.YesNo))
            //                    {
            //                        case DialogResult.Yes: trans.Commit(); ShowResult(file_id); break;
            //                        case DialogResult.No: trans.Rollback(); break;
            //                    }
            //                }
            //                else
            //                {
            //                    MessageBox.Show("Не удалось сохранить информацию о продажах!");
            //                    try
            //                    {
            //                        trans.Rollback();
            //                    }
            //                    catch (MySqlException exc)
            //                    {
            //                        MessageBox.Show("Произошла ошибка отката транзакции! Текст ошибки: \n {0}", exc.Message);
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                MessageBox.Show("Не удалось сохранить файл!");
            //                try
            //                {
            //                    trans.Rollback();
            //                }
            //                catch (MySqlException exc)
            //                {
            //                    MessageBox.Show("Произошла ошибка отката транзакции! Текст ошибки: \n {0}", exc.Message);
            //                }
            //            }
            //        }
            //        catch (MySqlException exc)
            //        {
            //            MessageBox.Show("Произошла выполнения запроса к базе данных! Текст ошибки: \n {0}", exc.Message);
            //        }
            //    }
            //}

        }

        private void mi_LastR_Click(object sender, EventArgs e)
        {
            ShowResult(context["SHOW"]);
        }

        private void gvResult_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (  (Convert.ToInt32(gvResult.Rows[e.RowIndex].Cells[3].Value) == 0)
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

        private void mi_AddPos_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(String.Format("Row : {0} \n Text : {1}", currentRow, gvResult.Rows[currentRow].Cells[2].Value));

            fEdit_MD_POS edt = new fEdit_MD_POS();
            edt.AddContext("POS", gvResult.Rows[currentRow].Cells[2].Value.ToString());
            edt.AddContext(conn);
            if (edt.ShowDialog(this) == DialogResult.OK)
            {
                ShowResult(context["SHOW"]);
            };
            edt.Dispose();
        }

        private void gvResult_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ( (e.Button == MouseButtons.Right) && (e.RowIndex > -1) )
            {
                // Add this
                gvResult.CurrentCell = gvResult.Rows[e.RowIndex].Cells[e.ColumnIndex];
                //// Can leave these here - doesn't hurt
                //gvResult.Rows[e.RowIndex].Selected = true;
                //gvResult.Focus();
            }
        }

        private void mi_AddDrug_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(String.Format("Row : {0} \n Text : {1}", currentRow, gvResult.Rows[currentRow].Cells[4].Value));

            fEdit_MD_Drug edt = new fEdit_MD_Drug();
            edt.AddContext("Drug", gvResult.Rows[currentRow].Cells[4].Value.ToString());
            edt.AddContext(conn);
            if (edt.ShowDialog(this) == DialogResult.OK)
            {
                ShowResult(context["SHOW"]);
            };
            edt.Dispose();
        }

        private void mi_Chains_Click(object sender, EventArgs e)
        {
            fListChains lst = new fListChains();
            lst.AddContext(conn);
            lst.Show();
        }

        private void mi_Drug_Click(object sender, EventArgs e)
        {
            fListDrugs lst = new fListDrugs();
            lst.AddContext(conn);
            lst.Show();
        }

        private void mi_MD_Drugs_Click(object sender, EventArgs e)
        {
            fList_MD_Drugs lst = new fList_MD_Drugs();
            lst.AddContext(conn);
            lst.Show();
        }

        private void mi_MD_POSes_Click(object sender, EventArgs e)
        {
            fList_MD_POSes lst = new fList_MD_POSes();
            lst.AddContext(conn);
            lst.Show(this);
        }

        private void mi_POS_Click(object sender, EventArgs e)
        {
            fListPOSes lst = new fListPOSes();
            lst.AddContext(conn);
            lst.Show();
        }

    }
}
