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
    public partial class fEditDrug : Form
    {
        Dictionary<string, string> context;
        private MySqlConnection conn = null;
        private List<int> mdDrug = null;

        public fEditDrug()
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
            txtDrug.Text = context["Drug"];
            LoadDrugs();
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
                MessageBox.Show(myReader.GetInt32(0) + ", " + myReader.GetString(1));
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
            string command = "INSERT INTO dbsop.tbl_model_data_of_drugs ( model_name, drug_id ) VALUES ( @mdname, @drug_id )";
            MySqlCommand cmd = new MySqlCommand(command, conn);

            cmd.Parameters.AddWithValue("@mdname", txtDrug.Text);
            cmd.Parameters.AddWithValue("@drug_id", mdDrug[cb_mdDrug.SelectedIndex]);

            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Saved!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Not saved! Try again!");
            }

        }
    }
}
