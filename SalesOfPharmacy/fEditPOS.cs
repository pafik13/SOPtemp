﻿using System;
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

        private void fEditPOS_Shown(object sender, EventArgs e)
        {
            LoadChains();
            if (context.ContainsKey("ID"))
            {
                string command = "SELECT p.id, p.name, p.chain_id FROM dbsop.tbl_poses p WHERE p.id = @id";
                MySqlCommand cmd = new MySqlCommand(command, conn);

                cmd.Parameters.AddWithValue("@id", context["ID"]);

                MySqlDataReader myReader = cmd.ExecuteReader();

                if (myReader.Read())
                {
                    txtPOS.Text = myReader.GetString(1);
                    cbChain.SelectedIndex = chains.IndexOf(myReader.GetInt32(2));
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;

            if (context.ContainsKey("ID"))
            {
                cmd.CommandText = "UPDATE dbsop.tbl_poses SET name = @name, chain_id = @chain_id WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", context["ID"]);
            }
            else
            {
                cmd.CommandText = "INSERT INTO dbsop.tbl_poses ( name, chain_id ) VALUES ( @name, @chain_id )";
            }

            cmd.Parameters.AddWithValue("@name", txtPOS.Text);
            cmd.Parameters.AddWithValue("@chain_id", chains[cbChain.SelectedIndex]);

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
