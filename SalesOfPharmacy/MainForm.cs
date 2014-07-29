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

        }

        private Form FindForm(Type formType)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == formType)
                {
                    return form;
                }
            }
            return null;
        }

        private void mi_Chains_Click(object sender, EventArgs e)
        {
            fListChains lst = (fListChains) FindForm(typeof(fListChains));
            if (lst != null)
            {
                lst.Activate();
            }
            else
            {
                lst = new fListChains();
                lst.MdiParent = this;
                lst.AddContext(conn);
                lst.Show();
            }
        }

        private void mi_Drug_Click(object sender, EventArgs e)
        {

            fListDrugs lst = new fListDrugs();
            lst.MdiParent = this;
            lst.AddContext(conn);
            lst.Show();
        }

        private void mi_MD_Drugs_Click(object sender, EventArgs e)
        {
            fList_MD_Drugs lst = new fList_MD_Drugs();
            lst.MdiParent = this;
            lst.AddContext(conn);
            lst.Show();
        }

        private void mi_MD_POSes_Click(object sender, EventArgs e)
        {
            fList_MD_POSes lst = new fList_MD_POSes();
            lst.MdiParent = this;
            lst.AddContext(conn);
            lst.Show();
        }

        private void mi_POS_Click(object sender, EventArgs e)
        {
            fListPOSes lst = new fListPOSes();
            lst.MdiParent = this;
            lst.AddContext(conn);
            lst.Show();
        }

        private void mi_Report_Sales_Click(object sender, EventArgs e)
        {
            fReportSales rSales = new fReportSales();
            rSales.AddContext(conn);
            rSales.ShowDialog(this);
        }

        private void mi_Files_Click(object sender, EventArgs e)
        {
            fListFiles lst = (fListFiles)FindForm(typeof(fListFiles));
            if (lst != null)
            {
                lst.Activate();
            }
            else
            {
                lst = new fListFiles();
                lst.MdiParent = this;
                lst.AddContext(conn);
                lst.Show();
            }
        }

    }
}
