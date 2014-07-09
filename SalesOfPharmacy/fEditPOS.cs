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
        private List<int> chains = null;

        public fEditPOS()
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
            txtPOS.Text = context["POS"];
            LoadChains();
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
                MessageBox.Show(myReader.GetInt32(0) + ", " + myReader.GetString(1));
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
            MessageBox.Show(String.Format("SelectedIndex = {0}", cbChain.SelectedIndex));
            if (cbChain.SelectedIndex > -1)
            {
                MessageBox.Show(String.Format("SelectedID = {0}", chains[cbChain.SelectedIndex]));
            }
        }
    }
}
