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

        private void fEditChain_Shown(object sender, EventArgs e)
        {
            if (context.ContainsKey("ID"))
            {
                string command = "SELECT d.id        "
                               + "     , d.name      "
                               + "  FROM tbl_drugs d "
                               + " WHERE d.id = @id  ";
                MySqlCommand cmd = new MySqlCommand(command, conn);

                cmd.Parameters.AddWithValue("@id", context["ID"]);

                MySqlDataReader myReader = cmd.ExecuteReader();

                if (myReader.Read())
                {
                    txtDrug.Text = myReader.GetString(1);
                }
                else
                {
                    MessageBox.Show("Не удалось найти запись с ID = " + context["ID"]);
                    this.Close();
                }

                // always call Close when done reading.
                myReader.Close();
            }
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
                cmd.CommandText = "UPDATE tbl_drugs SET name = @name WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", context["ID"]);
                cmd.Parameters.AddWithValue("@name", txtDrug.Text);
            }
            else
            {
                cmd.CommandText = "INSERT INTO tbl_drugs ( name ) VALUES ( @name )";
                cmd.Parameters.AddWithValue("@name", txtDrug.Text);
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
