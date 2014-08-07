using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Threading;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;

namespace SalesOfPharmacy
{
    public partial class fReportSales : Form
    {
        private Dictionary<string, string> context;
        private Dictionary<string, string> pcontext = null;

        private MySqlConnection conn = null;

        private Excel.Application excelApp = null;

        private StringBuilder log = null;

        public fReportSales()
        {
            InitializeComponent();

            context = new Dictionary<string, string>();
            context.Add("Errors", "");

            log = new StringBuilder();
        }

        internal void AddContext(string key, string value)
        {
            context.Add(key, value);
        }

        internal void AddContext(MySqlConnection connection)
        {
            conn = connection;
        }

        internal void AddContext(Dictionary<string, string> parentContext)
        {
            pcontext = parentContext;
        }

        private void fReportSales_Shown(object sender, EventArgs e)
        {
            string command = "SELECT p.year_id, p.year, p.month_id, p.month FROM vw_periods p";
            
            MySqlCommand cmd = new MySqlCommand(command, conn);

            MySqlDataReader myReader = cmd.ExecuteReader();

            // Always call Read before accessing data.
            while (myReader.Read()) 
            {
                string yearID  = myReader.GetString(0);
                string year    = myReader.GetString(1);
                string monthID = myReader.GetString(2);
                string month   = myReader.GetString(3);

                //TreeNode nParent;

                if (tv_Periods.Nodes.ContainsKey(yearID)){
                    TreeNode[] tn = tv_Periods.Nodes.Find(yearID, false);
                    tn[0].Nodes.Add(monthID, month);
                } else {
                    TreeNode nParent = tv_Periods.Nodes.Add(yearID, year);
                    nParent.Nodes.Add(monthID, month);
                }
            }

            myReader.Close();
            //tv_Periods.Nodes.ContainsKey(
            //tn = tv_Periods.Nodes.Find("2004", true);
            //if (tn.GetLength(0) == 0)
            //{
            //    tv_Periods.Nodes.Add("2004", "2004");
            //}

            //tn = tv_Periods.Nodes.Find("2004", true);
            //if (tn.GetLength(0) == 0)
            //{
            //    tv_Periods.Nodes.Add("2004", "2004");
            //}
        }

        private void tv_Periods_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                tv_Periods.AfterCheck -= tv_Periods_AfterCheck;
                foreach (TreeNode node in e.Node.Nodes)
                {
                    node.Checked = e.Node.Checked;
                }
                tv_Periods.AfterCheck += tv_Periods_AfterCheck;
            }
            else
            {
                tv_Periods.AfterCheck -= tv_Periods_AfterCheck;
                if (e.Node.Checked)
                {
                    e.Node.Parent.Checked = true;
                }
                else
                {
                    bool hasCheckedChild = false;
                    foreach (TreeNode node in e.Node.Parent.Nodes)
                    {
                        hasCheckedChild = hasCheckedChild || node.Checked;
                    }
                    if (!hasCheckedChild)
                    {
                        e.Node.Parent.Checked = false;
                    }
                }
                tv_Periods.AfterCheck += tv_Periods_AfterCheck;
            }
        }

        private void WriteDetailInfo(string baseCell, int chainID, Excel.Worksheet wS, List<PeriodRecord> periods, List<DrugRecord> drugs)
        {
            Excel.Range r;

            List<POSRecord> posRecords = GetPOSes(chainID);

            foreach (POSRecord pos in posRecords)
            {
                r = wS.get_Range(baseCell).get_Offset(pos.order + 1, 0);
                r.Value2 = pos.name;
                r.HorizontalAlignment = Excel.Constants.xlCenter;
                r.VerticalAlignment = Excel.Constants.xlCenter;
                r.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                r.Borders.Weight = Excel.XlBorderWeight.xlThin;
            }
            
            wS.Rows[wS.get_Range(baseCell).Row].NumberFormat = "МММ.ГГ"; //"dd-mmm-yy";
            wS.Rows[wS.get_Range(baseCell).Row + 1].RowHeight = 30;

            for (int i = 0; i < periods.Count; i++)
            {
                List<SaleRecord> saleRecords = GetSales(chainID, periods[i].year_id, periods[i].month_id);

                r = wS.get_Range(wS.get_Range(baseCell).get_Offset(0, i * drugs.Count + 1).Cells.Address
                                , wS.get_Range(baseCell).get_Offset(0, (i + 1) * drugs.Count).Cells.Address
                                );
                r.Merge();
                r.Value2 = DateTime.Parse(string.Format("01.0{0}.{1}", periods[i].month_id, periods[i].year));
                //r.HorizontalAlignment = Excel.Constants.xlCenter;
                //r.VerticalAlignment = Excel.Constants.xlCenter;
                //r.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                //r.Borders.Weight = Excel.XlBorderWeight.xlThin;


                foreach (SaleRecord s in saleRecords)
                {
                    r = wS.get_Range(baseCell).get_Offset(s.order + 1, i * drugs.Count + s.drug_id);
                    r.Value2 = s.num;
                    //r.HorizontalAlignment = Excel.Constants.xlCenter;
                    //r.VerticalAlignment = Excel.Constants.xlCenter;
                    //r.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    //r.Borders.Weight = Excel.XlBorderWeight.xlThin;
                }


                foreach (DrugRecord d in drugs)
                {
                    r = wS.get_Range(baseCell).get_Offset(1, i * drugs.Count + d.id);
                    //r.HorizontalAlignment = Excel.Constants.xlCenter;
                    //r.VerticalAlignment = Excel.Constants.xlCenter;
                    //r.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    //r.Borders.Weight = Excel.XlBorderWeight.xlThin;
                    r.WrapText = true;
                    wS.Columns[r.Column].ColumnWidth = 10;
                    r.Interior.Color = d.color;
                    r.Value2 = d.name;
                    r.EntireColumn.AutoFit();
                }

                /* All Data Range */
                r = wS.get_Range(wS.get_Range(baseCell).get_Offset(0, i * drugs.Count + 1).Cells.Address
                                , wS.get_Range(baseCell).get_Offset(1 + posRecords.Count, (i + 1) * drugs.Count).Cells.Address
                                );
                r.Select();

                /* Inner Thin lines */
                r.HorizontalAlignment = Excel.Constants.xlCenter;
                r.VerticalAlignment = Excel.Constants.xlCenter;
                //r.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                //r.Borders.Weight = Excel.XlBorderWeight.xlThin;

                /* Outer Thick lines */
                r.Borders[Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Excel.Constants.xlNone;
                r.Borders[Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Excel.Constants.xlNone;

                r.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                r.Borders[Excel.XlBordersIndex.xlEdgeLeft].ColorIndex = 0;
                r.Borders[Excel.XlBordersIndex.xlEdgeLeft].TintAndShade = 0;
                r.Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlMedium;

                r.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
                r.Borders[Excel.XlBordersIndex.xlEdgeTop].ColorIndex = 0;
                r.Borders[Excel.XlBordersIndex.xlEdgeTop].TintAndShade = 0;
                r.Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlMedium;

                r.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                r.Borders[Excel.XlBordersIndex.xlEdgeBottom].ColorIndex = 0;
                r.Borders[Excel.XlBordersIndex.xlEdgeBottom].TintAndShade = 0;
                r.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlMedium;

                r.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                r.Borders[Excel.XlBordersIndex.xlEdgeRight].ColorIndex = 0;
                r.Borders[Excel.XlBordersIndex.xlEdgeRight].TintAndShade = 0;
                r.Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlMedium;

                r.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
                r.Borders[Excel.XlBordersIndex.xlInsideVertical].ColorIndex = 0;
                r.Borders[Excel.XlBordersIndex.xlInsideVertical].TintAndShade = 0;
                r.Borders[Excel.XlBordersIndex.xlInsideVertical].Weight = Excel.XlBorderWeight.xlThin;

                r.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlContinuous;
                r.Borders[Excel.XlBordersIndex.xlInsideHorizontal].ColorIndex = 0;
                r.Borders[Excel.XlBordersIndex.xlInsideHorizontal].TintAndShade = 0;
                r.Borders[Excel.XlBordersIndex.xlInsideHorizontal].Weight = Excel.XlBorderWeight.xlThin;

                wS.get_Range(baseCell).EntireColumn.AutoFit();
            }
        }

        private List<PeriodRecord> GetPeriods()
        {
            List<PeriodRecord> result = new List<PeriodRecord>();

            foreach (TreeNode pnode in tv_Periods.Nodes)
            {
                foreach (TreeNode cnode in pnode.Nodes)
                {
                    if (cnode.Checked)
                    {
                        //MessageBox.Show("Parent Name: " + pnode.Name + "\n Child Name : " + cnode.Name);
                        result.Add(new PeriodRecord { year_id = pnode.Name
                                                    , year = pnode.Text
                                                    , month_id = cnode.Name
                                                    , month = cnode.Text
                                                    }
                                  );
                    }
                }
            }

            return result;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            List<ChainRecord> chainRecords = GetChains();
            List<PeriodRecord> periodRecords = GetPeriods();
            List<DrugRecord> drugRecords = GetDrugs();

            if ((chainRecords.Count > 0) && (periodRecords.Count > 0) && (drugRecords.Count > 0))
            {

                excelApp = new Excel.Application();
                excelApp.DisplayAlerts = true;
                excelApp.SheetsInNewWorkbook = chainRecords.Count;
                excelApp.Workbooks.Add(Type.Missing);

                excelApp.Visible = true;

                try
                {
                    for (int chainI = 0; chainI < chainRecords.Count; chainI++)
                    {
                        Excel.Worksheet wS = excelApp.Worksheets.get_Item(chainI + 1);
                        wS.Name = chainRecords[chainI].name;
                        wS.Select();
                        string bRange = "A2";

                        WriteDetailInfo(bRange, chainRecords[chainI].id, wS, periodRecords, drugRecords);
                            

                            //List<ReportRecord> reportRecords = GetReportRecords(chainRecords[chainI].id);


                            //Excel.Range r;
                            
                            //wS.Rows[wS.get_Range(bRange).Row].RowHeight = 30;

                            //int j = 0;
                            //foreach (DrugRecord dr in drugRecords)
                            //{
                            //    j++;
                            //    r = wS.get_Range(bRange).get_Offset(0, dr.id);
                            //    r.Value2 = dr.name;
                            //    wS.Rows[r.Column].ColumnWidth = 12;
                            //    r.HorizontalAlignment = Excel.Constants.xlCenter;
                            //    r.VerticalAlignment = Excel.Constants.xlCenter;
                            //    r.WrapText = true;
                            //    r.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            //    r.Borders.Weight = Excel.XlBorderWeight.xlThin;
                            //    r.Interior.Color = dr.color;
                            //}

                            //wS.Columns[1].NumberFormat = "МММ.ГГ"; //"dd-mmm-yy";

                            //int m_id = 0;
                            //int y_id = 0;
                            //int i = 1;

                            //foreach (ReportRecord rr in reportRecords)
                            //{
                            //    if ((m_id != rr.month_id)
                            //      || (y_id != rr.year_id))
                            //    {
                            //        i++;
                            //        m_id = rr.month_id;
                            //        y_id = rr.year_id;
                            //        r = wS.get_Range(bRange).get_Offset(i, 0);
                            //        r.Value2 = DateTime.Parse(string.Format("01.0{0}.{1}", rr.month_id, rr.year));
                            //        r.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            //        r.Borders.Weight = Excel.XlBorderWeight.xlThin;
                            //    }
                            //    r = wS.get_Range(bRange).get_Offset(i, rr.drug_id);
                            //    r.Value2 = rr.num;
                            //    r.NumberFormat = "0.00";
                            //    r.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            //    r.Borders.Weight = Excel.XlBorderWeight.xlThin;
                            //}

                            //for (int k = 1; k <= j; k++)
                            //{
                            //    r = wS.get_Range(bRange).Offset[1, k];
                            //    r.Select();
                            //    r.Formula = "=SUM(R[1]C:R[" + (i - 1).ToString() + "]C)";
                            //    r.NumberFormat = "0.00";
                            //}

                            //for (int k = 2; k <= i; k++)
                            //{
                            //    r = wS.get_Range(bRange).Offset[k, j + 1];
                            //    r.Select();
                            //    r.Formula = "=SUM(RC[-" + (j).ToString() + "]:RC[-1])";
                            //    r.NumberFormat = "0.00";
                            //}

                            //Excel.Range sourceCells = wS.Range[bRange, wS.get_Range(bRange).get_Offset(i, j)];

                            //Excel.ChartObjects xlCharts = (Excel.ChartObjects)wS.ChartObjects(Type.Missing);
                            //Excel.ChartObject myChart;
                            //Excel.Chart chartPage;

                            ///**/
                            //myChart = (Excel.ChartObject)xlCharts.Add(sourceCells.Left + sourceCells.Width + wS.get_Range(bRange).Width + 10, sourceCells.Top, 450, 375);
                            //chartPage = myChart.Chart;
                            //chartPage.ChartType = Excel.XlChartType.xlLineMarkers;
                            //chartPage.SetSourceData(sourceCells, Excel.XlRowCol.xlColumns);
                            //chartPage.ApplyDataLabels();

                            ///**/
                            //myChart = (Excel.ChartObject)xlCharts.Add(sourceCells.Left + sourceCells.Width + wS.get_Range(bRange).Width + 10, myChart.Top + myChart.Height + 10, 450, 375);
                            //chartPage = myChart.Chart;
                            //chartPage.ChartType = Excel.XlChartType.xlColumnStacked;
                            //chartPage.SetSourceData(sourceCells, Excel.XlRowCol.xlColumns);
                            //chartPage.ApplyDataLabels();

                        //---------------------------------------------//

                            //excelApp.Workbooks.Close();

                            //excelApp.Quit();

                            // Clean up references to all COM objects
                            // As per above, you're just using a Workbook and Excel Application instance, so release them:

                            //Marshal.FinalReleaseComObject(wS);
                            //Marshal.FinalReleaseComObject(sourceCells);
                            //Marshal.FinalReleaseComObject(myChart);
                            //Marshal.FinalReleaseComObject(chartPage);

                        }

                    }
                finally
                {
                    // Garbage collecting
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    Marshal.FinalReleaseComObject(excelApp);

                    using (StreamWriter outfile = new StreamWriter(@"sql_log.txt"))
                    {
                        outfile.Write(log.ToString());
                    }
                }
            }


                //List<ReportRecord> rr = new List<ReportRecord>();

            // wS.get_Range(bRange).get_Offset(i, 0).Value2 = string.Format("01.0{0}.{1}", myReader.GetString("month_id"), myReader.GetString("year"));

                ////Excel.Range r = wS.get_Range("A1");

                //int i = 0;

                //int m_id = 0;
                //int y_id = 0;



                
            //    // Garbage collecting
            //    GC.Collect();
            //    GC.WaitForPendingFinalizers();

            //    excelApp.Workbooks.Close();

            //    excelApp.Quit();

            //    // Clean up references to all COM objects
            //    // As per above, you're just using a Workbook and Excel Application instance, so release them:
            //    //Marshal.FinalReleaseComObject(workbook);
            //    Marshal.FinalReleaseComObject(excelApp);
            //}
        }

        private List<SaleRecord> GetSales(int chainID, string yearID, string monthID)
        {
            string command = "SELECT                                        "
                           + "    p_d.drug_id,                              "
                           + "    p_d.rowNum,                               "
                           + "    SUM(rsbp.NUM) AS NUM                      "
                           + "  FROM (SELECT                                "
                           + "      d.id AS drug_id,                        "
                           + "      d.name AS drug_name,                    "
                           + "      pos.pos_id,                             "
                           + "      pos.rowNum,                             "
                           + "      pos.pos_name                            "
                           + "    FROM tbl_drugs d                          "
                           + "      JOIN (SELECT                            "
                           + "          @rn := @rn + 1 AS rowNum,           "
                           + "          p.id AS pos_id,                     "
                           + "          p.name AS pos_name                  "
                           + "        FROM tbl_poses p,                     "
                           + "             (SELECT                          "
                           + "                 @rn := 0) rn                 "
                           + "        WHERE p.chain_id = " + chainID.ToString()
                           + "           ) AS pos) AS p_d "
                           + "    LEFT JOIN (                               "
                           + "      SELECT *                                "
                           + "        FROM vw_report_sales_by_poses         "
                           + "       WHERE year_id = " + yearID
                           + "         AND month_id = " + monthID
                           + "       GROUP                                  "
                           + "          BY drug_id,                         "
                           + "             pos_id                           "
                           + "       ) AS rsbp                              "
                           + "      ON rsbp.pos_id = p_d.pos_id             "
                           + "      AND rsbp.drug_id = p_d.drug_id          ";


            MySqlCommand cmd = new MySqlCommand(command, conn);

            MySqlDataReader myReader = cmd.ExecuteReader();

            List<SaleRecord> result = new List<SaleRecord>();

            while (myReader.Read())
            {
                result.Add(new SaleRecord() { order = myReader.GetInt32("rowNum")
                                            , drug_id = myReader.GetInt32("drug_id")
                                            , num = myReader.GetInt32("num")
                                            }
                          );
            }

            myReader.Close();

            log.AppendLine("----------------- GetSales ----------------------");

            log.AppendLine(command);

            log.AppendLine("----------------- GetSales ----------------------");

            return result;
        }

        private List<POSRecord> GetPOSes(int chainID)
        {
            string command = "SELECT @rn := @rn + 1 AS rowNum "
                           + "     , p.id                     "
                           + "     , p.name                   "
                           + "     , p.chain_id               "
                           + "  FROM tbl_poses p              "
                           + "     , (select @rn := 0) rn     " 
                           + " WHERE p.chain_id = " + chainID.ToString();

            MySqlCommand cmd = new MySqlCommand(command, conn);

            MySqlDataReader myReader = cmd.ExecuteReader();

            List<POSRecord> result = new List<POSRecord>();

            while (myReader.Read())
            {
                result.Add(new POSRecord() { id = myReader.GetInt32("id")
                                           , name = myReader.GetString("name")
                                           , chain_id = myReader.GetInt32("chain_id")
                                           , order = myReader.GetInt32("rowNum")
                                           }
                          );
            }

            myReader.Close();

            return result;
        }

        private List<ChainRecord> GetChains()
        {
            string command = "SELECT c.id, c.name FROM tbl_chains c";

            MySqlCommand cmd = new MySqlCommand(command, conn);

            MySqlDataReader myReader = cmd.ExecuteReader();

            List<ChainRecord> result = new List<ChainRecord>();

            while (myReader.Read())
            {
                result.Add(new ChainRecord() { id = myReader.GetInt32("id")
                                             , name = myReader.GetString("name")
                                             }
                          );
            }

            myReader.Close();

            return result;
        }

        private List<DrugRecord> GetDrugs ()
        {
            string command = "SELECT d.id, d.name, d.color FROM tbl_drugs d";

            MySqlCommand cmd = new MySqlCommand(command, conn);

            MySqlDataReader myReader = cmd.ExecuteReader();

            List<DrugRecord> result = new List<DrugRecord>();

            while (myReader.Read())
            {
                result.Add(new DrugRecord() {   id = myReader.GetInt32("id")
                                            ,   name = myReader.GetString("name")
                                            ,   color = myReader.GetInt32("color")
                                            }
                          );
            }

            myReader.Close();

            return result;
        }

        private List<ReportRecord> GetReportRecords(int id = 0)
        {
            MySqlCommand cmd = new MySqlCommand(GenerateReportSQL(id), conn);

            MySqlDataReader myReader = cmd.ExecuteReader();

            List<ReportRecord> result = new List<ReportRecord>();  

            while (myReader.Read())
            {
                result.Add( new ReportRecord () { drug_id  = myReader.GetInt32("drug_id")
                                                , month    = myReader.GetString("month")
                                                , month_id = myReader.GetInt32("month_id")
                                                , name     = myReader.GetString("name")
                                                , num      = myReader.GetInt32("num")
                                                , year     = myReader.GetString("year")
                                                , year_id  = myReader.GetInt32("year_id")
                                                }
                          );
            }

            myReader.Close();

            return result;
        }

        private string GenerateReportSQL (int id)
        {
            //string yearInExpr = "";
            string result = "SELECT rs.* FROM vw_report_sales rs WHERE ";
            string cnainIDexpr = (id > 0) ? " rs.chain_id = " + id.ToString() : " 1 = 1 ";
            string orderBYexpr = " ORDER BY rs.year, rs.month_id ";

            List<string> exprs = new List<string>();

            foreach (TreeNode pnode in tv_Periods.Nodes)
            {
                foreach (TreeNode cnode in pnode.Nodes)
                {
                    if (cnode.Checked)
                    {
                        //MessageBox.Show("Parent Name: " + pnode.Name + "\n Child Name : " + cnode.Name);
                        exprs.Add(" (rs.year_id = " + pnode.Name + " AND rs.month_id = " + cnode.Name + ") ");
                    }
                }
            }

            string monthYEARexpr = string.Empty;

            foreach (string expr in exprs)
            {
                monthYEARexpr = (expr != exprs[exprs.Count - 1]) ? String.Concat(monthYEARexpr, expr, " OR ") : String.Concat(monthYEARexpr, expr);
            }

            log.AppendLine("---------------------------------------");

            result = result + cnainIDexpr + " AND ( " + monthYEARexpr + " ) " + orderBYexpr;

            log.AppendLine(result);

            log.AppendLine("---------------------------------------");

            return result;
        }
    }

    public class ReportRecord
    {
        public int drug_id { get; set; }
        public string name { get; set; }
        public int year_id { get; set; }
        public string year { get; set; }
        public int month_id { get; set; }
        public string month { get; set; }
        public int num { get; set; }
    }

    public class DrugRecord
    {
        public int id { get; set; }
        public string name { get; set; }
        public int color { get; set; }
    }

    public class ChainRecord
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class POSRecord
    {
        public int id { get; set; }
        public string name { get; set; }
        public int chain_id { get; set; }
        public int order { get; set; }
    }

    public class PeriodRecord
    {
        public string year_id  { get; set; }
        public string year     { get; set; }
        public string month_id { get; set; }
        public string month    { get; set; }
    }

    public class SaleRecord
    {
        public int order { get; set; }
        public int drug_id { get; set; }
        public int num { get; set; }
    }
}
