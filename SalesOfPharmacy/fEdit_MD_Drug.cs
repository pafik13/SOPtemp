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
        private List<int> mdDrug = null;

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
                string command = "SELECT tmdod.id, tmdod.model_name, tmdod.drug_id FROM dbsop.tbl_model_data_of_drugs tmdod WHERE tmdod.id = @id";
                MySqlCommand cmd = new MySqlCommand(command, conn);

                cmd.Parameters.AddWithValue("@id", context["ID"]);

                MySqlDataReader myReader = cmd.ExecuteReader();

                if (myReader.Read())
                {
                    txt_MD_Drug.Text = myReader.GetString(1);
                    cb_mdDrug.SelectedIndex = mdDrug.IndexOf(myReader.GetInt32(2));
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
                txt_MD_Drug.Text = context["Drug"];
            }
            
        }

        private void LoadDrugs()
        {
            string command = "SELECT d.id, d.name FROM dbsop.tbl_drugs d";
            MySqlCommand cmd = new MySqlCommand(command, conn);

            MySqlDataReader myReader = cmd.ExecuteReader();

            mdDrug = new List<int>();

            // Always call Read before accessing data.
            while (myReader.Read())
            {
                //MessageBox.Show(myReader.GetInt32(0) + ", " + myReader.GetString(1));
                mdDrug.Add(myReader.GetInt32(0));
                cb_mdDrug.Items.Add(myReader.GetString(1));
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
                cmd.CommandText = "UPDATE dbsop.tbl_chains SET name = @name WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", context["ID"]);
                cmd.Parameters.AddWithValue("@mdname", txt_MD_Drug.Text);
                cmd.Parameters.AddWithValue("@drug_id", mdDrug[cb_mdDrug.SelectedIndex]);
            }
            else
            {
                cmd.CommandText = "INSERT INTO dbsop.tbl_model_data_of_drugs ( model_name, drug_id ) VALUES ( @mdname, @drug_id )";
                cmd.Parameters.AddWithValue("@mdname", txt_MD_Drug.Text);
                cmd.Parameters.AddWithValue("@drug_id", mdDrug[cb_mdDrug.SelectedIndex]);
            }

            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Successful!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Not success!");
            }

        }
    }
}
