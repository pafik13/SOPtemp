using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Threading;
using MySql.Data.MySqlClient;

namespace SalesOfPharmacy
{
    public partial class fLoadNewFile : Form
    {
        private Dictionary<string, string> context;
        private Dictionary<string, string> pcontext = null;

        private MySqlConnection conn = null;

        private List<int> chains = null;
        private List<int> months = null;

        private Excel.Application excelApp = null;

        private List<string> POSes; //= new List<string>();
        private List<string> drugs;//= new List<string>();
        private List<string> nums; //= new List<string>();

        private string filePath = "";

        public fLoadNewFile()
        {
            InitializeComponent();

            context = new Dictionary<string, string>();
            context.Add("Errors", "");

            excelApp = new Excel.Application();
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

        private void fLoadNewFile_Shown(object sender, EventArgs e)
        {
            LoadChains();
            LoadMonths();
        }

        private void LoadChains()
        {
            string command = "SELECT c.id, c.name FROM dbsop.tbl_chains c";
            MySqlCommand cmd = new MySqlCommand(command, conn);

            MySqlDataReader myReader = cmd.ExecuteReader();

            chains = new List<int>();

            // Always call Read before accessing data.
            while (myReader.Read())
            {
                //MessageBox.Show(myReader.GetInt32(0) + ", " + myReader.GetString(1));
                chains.Add(myReader.GetInt32(0));
                cbChain.Items.Add(myReader.GetString(1));
            }
            // always call Close when done reading.
            myReader.Close();
        }

        private void LoadMonths()
        {
            string command = "SELECT m.id, m.name FROM dbsop.tbl_months m";
            MySqlCommand cmd = new MySqlCommand(command, conn);

            MySqlDataReader myReader = cmd.ExecuteReader();

            months = new List<int>();

            // Always call Read before accessing data.
            while (myReader.Read())
            {
                //MessageBox.Show(myReader.GetInt32(0) + ", " + myReader.GetString(1));
                months.Add(myReader.GetInt32(0));
                cbMonth.Items.Add(myReader.GetString(1));
            }
            // always call Close when done reading.
            myReader.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool canProcess = true;
            pcontext["Errors"] = "";

            if (cbChain.SelectedIndex == -1)
            {
                pcontext["Errors"] = pcontext["Errors"] + "  - Не выбрана Аптечная сеть; \n";
                //MessageBox.Show("Необходимо выбрать Аптечную сеть", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //canProcess = false;
            }
            if (cbMonth.SelectedIndex == -1)
            {
                //MessageBox.Show("Необходимо выбрать Аптечную сеть", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //canProcess = false;
                pcontext["Errors"] = pcontext["Errors"] + "  - Не выбран Месяц; \n";
            }
            if (filePath == "")
            {
                pcontext["Errors"] = pcontext["Errors"] + "  - Не выбран Файл; \n";
            }

            if (pcontext["Errors"] != "")
            {
                MessageBox.Show("Обнаружены следующие ошибки: \n" + pcontext["Errors"], "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                if (GetInfoFromExcel(filePath))
                {
                    byte[] file = File.ReadAllBytes(filePath);

                    MySqlTransaction trans = conn.BeginTransaction();

                    string command = "INSERT INTO dbsop.tbl_file_raw ( bFile, file_name, chain_id, month_id ) VALUES ( @bFile, @file_name, @chain_id, @month_id )";

                    MySqlCommand cmd = new MySqlCommand(command, conn, trans);

                    MySqlParameter pFile = new MySqlParameter("@bFile", MySqlDbType.Blob, file.Length);
                    MySqlParameter pName = new MySqlParameter("@file_name", MySqlDbType.String, txtFile.Text.Length);
                    MySqlParameter pChain = new MySqlParameter("@chain_id", MySqlDbType.Int32);
                    MySqlParameter pMonth = new MySqlParameter("@month_id", MySqlDbType.Int32);

                    pFile.Value = file;
                    pName.Value = txtFile.Text;
                    pChain.Value = chains[cbChain.SelectedIndex];
                    pMonth.Value = months[cbMonth.SelectedIndex];

                    cmd.Parameters.Add(pFile);
                    cmd.Parameters.Add(pName);
                    cmd.Parameters.Add(pChain);
                    cmd.Parameters.Add(pMonth);

                    try
                    {
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            cmd.CommandText = "SELECT LAST_INSERT_ID()";
                            string file_id = cmd.ExecuteScalar().ToString();

                            if (InsertSalesToDB(cmd, file_id))
                            {
                                switch (MessageBox.Show("Сохранить изменения?", "Сохранить изменения?", MessageBoxButtons.YesNo))
                                {
                                    case DialogResult.Yes: trans.Commit(); pcontext.Add("SHOW", file_id); break;
                                    case DialogResult.No: trans.Rollback(); break;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Не удалось сохранить информацию о продажах!");
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
                            MessageBox.Show("Не удалось сохранить файл!");
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
                    catch (MySqlException exc)
                    {
                        MessageBox.Show("Произошла выполнения запроса к базе данных! Текст ошибки: \n {0}", exc.Message);
                    }
                }
            }
            //pcontext.Add("SHOW", cbChain.Text);
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

            for (int i = 1; i <= excelApp.Worksheets.Count; i++)
            {
                excelApp.Visible = true;

                Excel.Worksheet workSheet = excelApp.Worksheets.get_Item(i);

                workSheet.Select(Type.Missing);

                POSes.AddRange(GetValues("Точки", workSheet, excelApp));
                drugs.AddRange(GetValues("Препараты", workSheet, excelApp));
                nums.AddRange(GetValues("Количество", workSheet, excelApp));

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

        private List<string> GetValues(string rangeName, Excel.Worksheet wSheet, Excel.Application app)
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
                app.Visible = false;
                MessageBox.Show(String.Format("Не найдена область '{0}' на листе '{1}';\nОшибка Excel: {2}", rangeName, wSheet.Name, exc.Message));
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

        private void btnFile_Click(object sender, EventArgs e)
        {
            if (oFileDlg.ShowDialog(this) == DialogResult.OK)
            {
                filePath = oFileDlg.FileName;
                txtFile.Text = Path.GetFileName(oFileDlg.FileName);
            }
        }

        private void fLoadNewFile_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((this.DialogResult == DialogResult.OK) && (pcontext["Errors"] != ""))
            {
                e.Cancel = true;
            }
        }
    }
}
