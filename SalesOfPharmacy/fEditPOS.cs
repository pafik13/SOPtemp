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
    public partial class fEditPOS : Form
    {
        Dictionary<string, string> context;
        private MySqlConnection conn = null;

        List<int> chains = null;
        List<int> areas = null;

        public fEditPOS()
        {
            InitializeComponent();

            context = new Dictionary<string, string>();

            context.Add("Errors", String.Empty);
        }

        internal void AddContext(string key, string value)
        {
            context.Add(key, value);
        }

        internal void AddContext(MySqlConnection connection)
        {
            conn = connection;
        }

        private void fEditPOS_Shown(object sender, EventArgs e)
        {
            LoadChains();
            LoadAreas();
            if (context.ContainsKey("ID"))
            {
                string command = "SELECT p.id, p.name, p.chain_id, p.b_no, p.b_area FROM dbsop.tbl_poses p WHERE p.id = @id";
                MySqlCommand cmd = new MySqlCommand(command, conn);

                cmd.Parameters.AddWithValue("@id", context["ID"]);

                MySqlDataReader myReader = cmd.ExecuteReader();

                if (myReader.Read())
                {
                    txtPOS.Text = myReader.GetString(1);
                    cbChain.SelectedIndex = chains.IndexOf(myReader.GetInt32(2));

                    if (!myReader.IsDBNull(3))
                    {
                        txtB_No.Text = myReader.GetString(3);
                    }
                    else
                    {
                        txtB_No.Text = string.Empty;
                    }

                    if (!myReader.IsDBNull(4))
                    {
                        cbB_Area.SelectedIndex = areas.IndexOf(myReader.GetInt32(4));
                    }
                    else
                    {
                        cbB_Area.SelectedIndex = -1;
                    }
                }
                else
                {
                    MessageBox.Show("Не удалось найти запись с ID = " + context["ID"]);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }

                // always call Close when done reading.
                myReader.Close();
            }
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

        private void LoadAreas()
        {
            string command = "SELECT a.id, a.name FROM dbsop.tbl_areas a ORDER BY a.name";
            MySqlCommand cmd = new MySqlCommand(command, conn);

            MySqlDataReader myReader = cmd.ExecuteReader();

            areas = new List<int>();

            // Always call Read before accessing data.
            while (myReader.Read())
            {
                //MessageBox.Show(myReader.GetInt32(0) + ", " + myReader.GetString(1));
                areas.Add(myReader.GetInt32(0));
                cbB_Area.Items.Add(myReader.GetString(1));
            }
            // always call Close when done reading.
            myReader.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            context["Errors"] = string.Empty;
        }

        private bool CheckParams()
        {
            context["Errors"] = string.Empty;

            if (String.IsNullOrEmpty(txtPOS.Text))
            {
                context["Errors"] = context["Errors"] + "  - Не заполнена Точка продаж; \n";
            }

            if (cbChain.SelectedIndex == -1)
            {
                context["Errors"] = context["Errors"] + "  - Не выбрана Аптечная сеть; \n";
            }

            if (String.IsNullOrEmpty(txtB_No.Text))
            {
                context["Errors"] = context["Errors"] + "  - Не заполнен Номер из выгрузки; \n";
            }
            else
            {
                int number;
                if (!int.TryParse(txtB_No.Text, out number))
                {
                    context["Errors"] = context["Errors"] + "  - Номер из выгрузки должен быть целым числом; \n";
                }
            }

            if (cbB_Area.SelectedIndex == -1)
            {
                context["Errors"] = context["Errors"] + "  - Не выбран Город/Округ; \n";
            }

            return string.IsNullOrEmpty(context["Errors"]);
        }

        private void SaveRecord()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                if (context.ContainsKey("ID"))
                {
                    cmd.CommandText = "UPDATE dbsop.tbl_poses SET name = @name, chain_id = @chain_id, b_no = @b_no, b_area = @b_area WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", context["ID"]);
                }
                else
                {
                    cmd.CommandText = "INSERT INTO dbsop.tbl_poses ( name, chain_id, b_no, b_area ) VALUES ( @name, @chain_id, @b_no, @b_area )";
                }

                cmd.Parameters.AddWithValue("@name", txtPOS.Text);
                cmd.Parameters.AddWithValue("@chain_id", chains[cbChain.SelectedIndex]);
                cmd.Parameters.AddWithValue("@b_no", txtB_No.Text);
                cmd.Parameters.AddWithValue("@b_area", areas[cbB_Area.SelectedIndex]);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Successful!");
                    //this.Close();
                }
                else
                {
                    MessageBox.Show("Not success!");
                }
            }
            catch (MySqlException mysqlExc)
            {
                context["Errors"] = context["Errors"] + String.Format("  - Ошибка вставки в Базу Данных: {0}; \n", mysqlExc.Message); 
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckParams())
            {
                SaveRecord();
            }
        }

        private void fEditPOS_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrEmpty(context["Errors"]))
            {
                MessageBox.Show("Обнаружены следующие ошибки: \n" + context["Errors"], "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void cbChain_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back)
             || (e.KeyCode == Keys.Delete))
            {
                cbChain.SelectedIndex = -1;
            }
        }

        private void cbB_Area_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back)
             || (e.KeyCode == Keys.Delete))
            {
                cbChain.SelectedIndex = -1;
            }
        }
    }
}
