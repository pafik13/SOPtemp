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
    public partial class fEdit_MD_Drug : Form
    {
        Dictionary<string, string> context;
        private MySqlConnection conn = null;
        private List<int> drugs = null;

        public fEdit_MD_Drug()
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

        private void fEditDrug_Shown(object sender, EventArgs e)
        {
            LoadDrugs();
            if (context.ContainsKey("ID"))
            {
                string command = "SELECT tmdod.id, tmdod.model_name, tmdod.drug_id FROM tbl_model_data_of_drugs tmdod WHERE tmdod.id = @id";
                MySqlCommand cmd = new MySqlCommand(command, conn);

                cmd.Parameters.AddWithValue("@id", context["ID"]);

                MySqlDataReader myReader = cmd.ExecuteReader();

                if (myReader.Read())
                {
                    txt_MD_Drug.Text = myReader.GetString(1);
                    cbDrug.SelectedIndex = drugs.IndexOf(myReader.GetInt32(2));
                }
                else
                {
                    MessageBox.Show("Не удалось найти запись с ID = " + context["ID"]);
                    this.Close();
                }

                // always call Close when done reading.
                myReader.Close();
            }
            else
            {
                if (context.ContainsKey("Drug"))
                {
                    txt_MD_Drug.Text = context["Drug"];
                }
            }
            
        }

        private void LoadDrugs()
        {
            string command = "SELECT d.id, d.name FROM tbl_drugs d";
            MySqlCommand cmd = new MySqlCommand(command, conn);

            MySqlDataReader myReader = cmd.ExecuteReader();

            drugs = new List<int>();

            // Always call Read before accessing data.
            while (myReader.Read())
            {
                //MessageBox.Show(myReader.GetInt32(0) + ", " + myReader.GetString(1));
                drugs.Add(myReader.GetInt32(0));
                cbDrug.Items.Add(myReader.GetString(1));
            }
            // always call Close when done reading.
            myReader.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;

            if (context.ContainsKey("ID"))
            {
                cmd.CommandText = "UPDATE tbl_model_data_of_drugs SET model_name = @mdname, drug_id = @drug_id WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", context["ID"]);
            }
            else
            {
                cmd.CommandText = "INSERT INTO tbl_model_data_of_drugs ( model_name, drug_id ) VALUES ( @mdname, @drug_id )";
            }

            cmd.Parameters.AddWithValue("@mdname", txt_MD_Drug.Text);
            cmd.Parameters.AddWithValue("@drug_id", drugs[cbDrug.SelectedIndex]);

            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Successful!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Not success! \n " + cmd.CommandText);
            }

        }
    }
}
