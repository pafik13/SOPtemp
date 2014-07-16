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
    public partial class fEdit_MD_POS : Form
    {
        Dictionary<string, string> context;
        private MySqlConnection conn = null;

        private List<int> chains = null;
        private List<int> POSes = null;

        public fEdit_MD_POS()
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

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, string> kvp in context)
            {
                MessageBox.Show(String.Format("Key : {0}; Val : {1}", kvp.Key, kvp.Value));
                // do something
            }
        }

        private void fEditPOS_Shown(object sender, EventArgs e)
        {
            LoadChains();
            if (context.ContainsKey("ID"))
            {
                string command = "SELECT mdop.id, mdop.model_name, p.id, p.chain_id FROM tbl_model_data_of_poses mdop JOIN vw_poses p ON mdop.pos_id = p.id WHERE mdop.id = @id";
                MySqlCommand cmd = new MySqlCommand(command, conn);

                cmd.Parameters.AddWithValue("@id", context["ID"]);

                MySqlDataReader myReader = cmd.ExecuteReader();

                if (myReader.Read())
                {
                    txt_MD_POS.Text = myReader.GetString(1);

                    int chain_id = myReader.GetInt32(3);
                    int pos_id = myReader.GetInt32(2);

                    // always call Close when done reading.
                    myReader.Close();

                    cbChain.SelectedIndex = chains.IndexOf(chain_id);

                    cbPOS.SelectedIndex = POSes.IndexOf(pos_id);
                }
                else
                {
                    myReader.Close();

                    MessageBox.Show("Не удалось найти запись с ID = " + context["ID"]);
                    this.Close();
                }
            }
            else
            {
                txt_MD_POS.Text = context["POS"];
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbChain_TextChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(String.Format("tEXT : SelectedIndex = {0}", cbChain.SelectedIndex));
            if (cbChain.SelectedIndex > -1)
            {
                //MessageBox.Show(String.Format("SelectedID = {0}", chains[cbChain.SelectedIndex]));
                LoadPOSes();
            }
        }

        public void LoadPOSes()
        {
            cbPOS.Text = "";
            cbPOS.Items.Clear();

            string command = "SELECT p.id, p.name FROM dbsop.tbl_poses p WHERE p.chain_id = @chain_id";
            MySqlCommand cmd = new MySqlCommand(command, conn);

            cmd.Parameters.AddWithValue("@chain_id", chains[cbChain.SelectedIndex]);

            MySqlDataReader myReader = cmd.ExecuteReader();

            POSes = new List<int>();

            // Always call Read before accessing data.
            while (myReader.Read())
            {
                //MessageBox.Show(myReader.GetInt32(0) + ", " + myReader.GetString(1));
                POSes.Add(myReader.GetInt32(0));
                cbPOS.Items.Add(myReader.GetString(1));
            }
            // always call Close when done reading.
            myReader.Close();

            if (POSes.Count > 0)
            {
                cbPOS.Enabled = true;
            }
            else
            {
                cbPOS.Enabled = false;
            }
        }

        private void cbChain_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back)
              ||(e.KeyCode == Keys.Delete)) 
            {
                cbChain.SelectedIndex = -1;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;

            if (context.ContainsKey("ID"))
            {
                cmd.CommandText = "UPDATE dbsop.tbl_model_data_of_poses SET model_name = @model_name, pos_id = @pos_id WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", context["ID"]);
            }
            else
            {
                cmd.CommandText = "INSERT INTO dbsop.tbl_model_data_of_poses ( model_name, pos_id ) VALUES ( @model_name, @pos_id )";
            }

            cmd.Parameters.AddWithValue("@model_name", txt_MD_POS.Text);
            cmd.Parameters.AddWithValue("@pos_id", POSes[cbPOS.SelectedIndex]);

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
