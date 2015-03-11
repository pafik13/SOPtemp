using System;
using System.Configuration;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace SalesOfPharmacy
{
    public partial class MainForm : Form
    {
        private Dictionary<string, string> context;
        private MySqlConnection conn = null;

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
                               + "\n Connection State : " + conn.State.ToString()
                               + "\n DataBase : " + conn.Database);
            }

            //excelApp = new Excel.Application();

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
                Program.DoWithWait(lst.LoadFiles);
                lst.Show();
            }
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
                Program.DoWithWait(lst.LoadChains);
                lst.Show();
            }
        }

        private void mi_POS_Click(object sender, EventArgs e)
        {
            fListPOSes lst = (fListPOSes)FindForm(typeof(fListPOSes));
            if (lst != null)
            {
                lst.Activate();
            }
            else
            {
                lst = new fListPOSes();
                lst.MdiParent = this;
                lst.AddContext(conn);
                lst.Show();
            }
        }

        private void mi_Drug_Click(object sender, EventArgs e)
        {
            fListDrugs lst = (fListDrugs)FindForm(typeof(fListDrugs));
            if (lst != null)
            {
                lst.Activate();
            }
            else
            {
                lst = new fListDrugs();
                lst.MdiParent = this;
                lst.AddContext(conn);
                Program.DoWithWait(lst.LoadDrugs);
                lst.Show();
            }
        }

        private void mi_MD_Drugs_Click(object sender, EventArgs e)
        {
            fList_MD_Drugs lst = (fList_MD_Drugs)FindForm(typeof(fList_MD_Drugs));
            if (lst != null)
            {
                lst.Activate();
            }
            else
            {
                lst = new fList_MD_Drugs();
                lst.MdiParent = this;
                lst.AddContext(conn);
                Program.DoWithWait(lst.Load_MD_Drugs);
                lst.Show();
            }
        }

        private void mi_MD_POSes_Click(object sender, EventArgs e)
        {
            fList_MD_POSes lst = (fList_MD_POSes)FindForm(typeof(fList_MD_POSes));
            if (lst != null)
            {
                lst.Activate();
            }
            else
            {
                lst = new fList_MD_POSes();
                lst.MdiParent = this;
                lst.AddContext(conn);
                Program.DoWithWait(lst.Load_MD_POSes);
                lst.Show();
            }
        }

        private void mi_Report_Sales_Click(object sender, EventArgs e)
        {
            fReportSales rSales = new fReportSales();
            rSales.AddContext(conn);
            rSales.ShowDialog(this);
        }

    }
}
