using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

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

        private void MergeAndCenterPos(Excel.Range range, Excel.Worksheet workSh)
        {
            range = workSh.get_Range(range.Address, range.get_Offset(1, 0).Address);
            range.Merge();
            range.HorizontalAlignment = Excel.Constants.xlCenter;
            range.VerticalAlignment = Excel.Constants.xlCenter;
        }

        private string WriteDetailInfo(string baseCell, int chainID, Excel.Worksheet wS, List<PeriodRecord> periods, List<DrugRecord> drugs)
        {
            Excel.Range r;

            string bCellForDrug = wS.get_Range(baseCell).get_Offset(1, 5).Address;

            int posCount = GetPOSCount(chainID);
//            List<POSRecord> posRecords = GetPOSes(chainID);

            string[,] subtotal = new string[posCount, 1];
            for (int p = 0; p < posCount; p++)
            {
                subtotal[p, 0] = "=SUBTOTAL(9,RC[-1]:RC[" + (-drugs.Count + 1).ToString() + "])";
            }

            /* Colors*/
            r = wS.get_Range(baseCell, wS.get_Range(baseCell).get_Offset(3, 4).Address);
            r.Interior.Color = 13434828;

            r = wS.get_Range(baseCell);
            r.Value2 = "Аптека";
            wS.Columns[r.Column].ColumnWidth = 35;
            MergeAndCenterPos(r, wS);
            r = wS.get_Range(baseCell).get_Offset(0, 1);
            r.Value2 = "Адрес";
            wS.Columns[r.Column].ColumnWidth = 20.71;
            MergeAndCenterPos(r, wS);
            r = wS.get_Range(baseCell).get_Offset(0, 2);
            r.Value2 = "ID";
            MergeAndCenterPos(r, wS);
            r = wS.get_Range(baseCell).get_Offset(0, 3);
            r.Value2 = "Аптечная сеть";
            MergeAndCenterPos(r, wS);
            r = wS.get_Range(baseCell).get_Offset(0, 4);
            r.Value2 = "Округ";
            MergeAndCenterPos(r, wS);


            /* Всего продано */
            r = wS.get_Range( wS.get_Range(baseCell).get_Offset(1, 0).Address
                            , wS.get_Range(baseCell).get_Offset(1, 1).Address);
            r.Merge();
            r.Value2 = "Всего продано";

            /* Количество аптек с продажами	*/
            r = wS.get_Range(wS.get_Range(baseCell).get_Offset(2, 0).Address
                            , wS.get_Range(baseCell).get_Offset(2, 1).Address);
            r.Merge();
            r.Value2 = "Количество аптек с продажами";
            r.RowHeight = 9;

            /* Aligmnents */
            r = wS.get_Range(wS.get_Range(baseCell).get_Offset(1, 0).Address
                            , wS.get_Range(baseCell).get_Offset(2, 1).Address);
            r.HorizontalAlignment = Excel.Constants.xlRight;
            r.VerticalAlignment = Excel.Constants.xlCenter;

            //foreach (POSRecord pos in posRecords)
            //{
            //    r = wS.get_Range(baseCell).get_Offset(pos.order + 2, 0);
            //    r.Value2 = pos.name;

            //    r = wS.get_Range(baseCell).get_Offset(pos.order + 2, 1);
            //    r.Value2 = pos.address;

            //    r = wS.get_Range(baseCell).get_Offset(pos.order + 2, 2);
            //    r.Value2 = pos.id;

            //    r = wS.get_Range(baseCell).get_Offset(pos.order + 2, 3);
            //    r.Value2 = pos.chain_name;

            //    r = wS.get_Range(baseCell).get_Offset(pos.order + 2, 4);
            //    r.Value2 = pos.area;
            //}

            /* Borders */
            r = wS.Range[ baseCell
                        , wS.get_Range(baseCell).get_Offset(posCount + 2, 4).Address
                        ];
            r.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            r.Borders.Weight = Excel.XlBorderWeight.xlThin;

            /* Alignments */
            r = wS.Range[ wS.get_Range(baseCell).get_Offset(3, 0).Address
                        , wS.get_Range(baseCell).get_Offset(posCount + 2, 4).Address
                        ];
            r.HorizontalAlignment = Excel.Constants.xlLeft;
            r.VerticalAlignment = Excel.Constants.xlCenter;

            r.Value2 = GetPOSes(chainID, posCount);


            /* ---------- */
            /* Sales Data */
            /* ---------- */
            wS.Rows[wS.get_Range(bCellForDrug).Row - 1].NumberFormat = "МММ.ГГ"; //"dd-mmm-yy";
            wS.Rows[wS.get_Range(bCellForDrug).Row - 1].RowHeight = 15;


            wS.Rows[wS.get_Range(bCellForDrug).Row].RowHeight = 112.5;

            for (int i = 0; i < periods.Count; i++)
            {
                //List<SaleRecord> saleRecords = GetSales(chainID, periods[i].year_id, periods[i].month_id);

                //foreach (SaleRecord s in saleRecords)
                //{
                //    r = wS.get_Range(bCellForDrug).get_Offset(s.order + 2, i * drugs.Count + s.drug_id - 1);
                //    r.Value2 = s.num;
                //    //r.HorizontalAlignment = Excel.Constants.xlCenter;
                //    //r.VerticalAlignment = Excel.Constants.xlCenter;
                //    //r.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                //    //r.Borders.Weight = Excel.XlBorderWeight.xlThin;
                //}

                foreach (DrugRecord d in drugs)
                {
                    if (d.name != "Итого")
                    {

                        r = wS.get_Range(bCellForDrug).get_Offset(0, i * drugs.Count + d.id - 1);
                        r.HorizontalAlignment = Excel.Constants.xlCenter;
                        r.VerticalAlignment = Excel.Constants.xlBottom;
                        r.Orientation = 90;
                        wS.Columns[r.Column].ColumnWidth = 4.57;
                        r.Interior.Color = 10092543;//d.color;
                        r.Value2 = d.name;

                        r = r.get_Offset(1, 0);
                        r.Formula = "=SUBTOTAL(9,R[2]C:R[" + (posCount + 2).ToString() + "]C)";
                        r.Interior.Color = 10092543;

                        r = r.get_Offset(1, 0);
                        r.Formula = "=SUBTOTAL(2,R[1]C:R[" + (posCount + 1).ToString() + "]C)";
                        r.Interior.Color = 10092543;

                        r = wS.get_Range( wS.get_Range(bCellForDrug).get_Offset(3, i * drugs.Count + d.id - 1).Address
                                        , wS.get_Range(bCellForDrug).get_Offset(posCount + 2, i * drugs.Count + d.id - 1).Address
                                        );
                        r.Select();

                        r.Value2 = GetSales(chainID, d.id, posCount, periods[i].year_id, periods[i].month_id);
                    }
                    else
                    {
                        r = wS.get_Range(bCellForDrug).get_Offset(0, i * drugs.Count + d.id - 1);
                        r.HorizontalAlignment = Excel.Constants.xlCenter;
                        r.VerticalAlignment = Excel.Constants.xlBottom;
                        r.Orientation = 90;
                        wS.Columns[r.Column].ColumnWidth = 4.57;
                        r.Value2 = d.name;
                        r.Font.Size = 18;

                        r = r.get_Offset(1, 0);
                        r.Formula = "=SUM(R[2]C:R[" + (posCount + 1).ToString() + "]C)";

                        r = r.get_Offset(1, 0);
                        r.Formula = "=COUNT(R[1]C:R[" + posCount.ToString() + "]C)";

                        /* Formulas */
                       // foreach (POSRecord pos in posRecords)
                       // {
                           // r = wS.get_Range(bCellForDrug).get_Offset(pos.order + 2, i * drugs.Count + d.id - 1);
                           // r = wS.get_Range(bCellForDrug).get_Offset(p + 2, i * drugs.Count + d.id - 1);
                           // r.Formula = "=SUBTOTAL(9,RC[-1]:RC[" + (-d.order + 1).ToString() + "])";
                       // }

                        /* Colors */
                        r = wS.get_Range( wS.get_Range(bCellForDrug).get_Offset(0, i * drugs.Count + d.id - 1).Cells.Address
                                        , wS.get_Range(bCellForDrug).get_Offset(posCount + 2, i * drugs.Count + d.id - 1).Cells.Address
                                        );
                        r.Interior.Color = 13434828;

                        r = wS.get_Range(wS.get_Range(bCellForDrug).get_Offset(3, i * drugs.Count + d.id - 1).Cells.Address
                                        , wS.get_Range(bCellForDrug).get_Offset(posCount + 2, i * drugs.Count + d.id - 1).Cells.Address
                                        );
                        r.set_Value(Type.Missing, subtotal); // thanks HeinrichStack
                        r.Formula = r.Value; //<--- Boom baby, all 'formula as text' turns into bona fide excel formula
                    }
                }

                //r.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                //r.Borders.Weight = Excel.XlBorderWeight.xlThin;

                /* All Data Range */
                r = wS.get_Range(wS.get_Range(bCellForDrug).get_Offset(-1, i * drugs.Count).Cells.Address
                , wS.get_Range(bCellForDrug).get_Offset(posCount + 2, (i + 1) * drugs.Count - 1).Cells.Address
                );
                r.Select();

                /* Lines */
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

                r = wS.get_Range(wS.get_Range(bCellForDrug).get_Offset(3, i * drugs.Count).Cells.Address
                , wS.get_Range(bCellForDrug).get_Offset(posCount + 2, (i + 1) * drugs.Count - 1).Cells.Address
                );
                r.Select();

                /* Alignments */
                r.HorizontalAlignment = Excel.Constants.xlCenter;
                r.VerticalAlignment = Excel.Constants.xlCenter;
                //r.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                //r.Borders.Weight = Excel.XlBorderWeight.xlThin;
                //wS.get_Range(baseCell).EntireColumn.AutoFit();

                /* Date */
                
                r = wS.get_Range(wS.get_Range(bCellForDrug).get_Offset(-1, i * drugs.Count).Cells.Address
                , wS.get_Range(bCellForDrug).get_Offset(-1, (i + 1) * drugs.Count - 1).Cells.Address
                );
                r.Merge();
                r.HorizontalAlignment = Excel.Constants.xlCenter;
                r.VerticalAlignment = Excel.Constants.xlCenter;
                r.Interior.Color = 13434828;
                r.Value2 = DateTime.Parse(string.Format("01.0{0}.{1}", periods[i].month_id, periods[i].year));
            }

            r = wS.get_Range( wS.get_Range(bCellForDrug).get_Offset(1, -1).Cells.Address
                            , wS.get_Range(bCellForDrug).get_Offset(1, drugs.Count * periods.Count - 1).Cells.Address
                            );
            r.Activate();
            r.Select();
            r.HorizontalAlignment = Excel.Constants.xlLeft;
            r.VerticalAlignment = Excel.Constants.xlCenter;
            r.Font.Size = 8;

            r = wS.get_Range( wS.get_Range(bCellForDrug).get_Offset(2, -2).Cells.Address
                            , wS.get_Range(bCellForDrug).get_Offset(2, drugs.Count * periods.Count - 1).Cells.Address
                            );
            r.Activate();
            r.Select();
            r.HorizontalAlignment = Excel.Constants.xlLeft;
            r.VerticalAlignment = Excel.Constants.xlCenter;
            r.Font.Size = 7;
            r.AutoFilter(1, 
                    Type.Missing, 
                    Excel.XlAutoFilterOperator.xlAnd, 
                    Type.Missing, 
                    true);

            return wS.get_Range(bCellForDrug).get_Offset(0, drugs.Count * periods.Count + 2).Address;
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

        public void WriteGroupingInfo(string bRange, int chainID, Excel.Worksheet wS, List<PeriodRecord> periods, List<DrugRecord> drugs)
        {
            List<ReportRecord> reportRecords = GetReportRecords(chainID);

            Excel.Range r;

            int j = 0;
            foreach (DrugRecord dr in drugs)
            {
                j++;
                r = wS.get_Range(bRange).get_Offset(0, dr.id);
                r.Value2 = dr.name;
                r.Orientation = 90;
                r.HorizontalAlignment = Excel.Constants.xlCenter;
                r.VerticalAlignment = Excel.Constants.xlBottom;
                r.WrapText = true;
                r.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                r.Borders.Weight = Excel.XlBorderWeight.xlThin;
                r.Interior.Color = dr.color; //10092543;
            }

            wS.Range[wS.get_Range(bRange).get_Offset(1, 0).Address
                    ,wS.get_Range(bRange).get_Offset(reportRecords.Count, 0).Address].NumberFormat = "MMM.YY"; //"dd-mmm-yy";

            int m_id = 0;
            int y_id = 0;
            int i = 2;

            foreach (ReportRecord rr in reportRecords)
            {
                if ((m_id != rr.month_id)
                  || (y_id != rr.year_id))
                {
                    i++;
                    m_id = rr.month_id;
                    y_id = rr.year_id;
                    r = wS.get_Range(bRange).get_Offset(i, 0);
                    r.Value2 = DateTime.Parse(string.Format("01.0{0}.{1}", rr.month_id, rr.year));
                    r.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    r.Borders.Weight = Excel.XlBorderWeight.xlThin;
                }
                r = wS.get_Range(bRange).get_Offset(i, rr.drug_id);
                r.Value2 = rr.num;
                r.NumberFormat = "0.00";
            }

            r = wS.get_Range(wS.get_Range(bRange).get_Offset(3, 0).Address
                            , wS.get_Range(bRange).get_Offset(i, j - 1).Address
                            );
            r.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            r.Borders.Weight = Excel.XlBorderWeight.xlThin;

            for (int k = 1; k <= j; k++)
            {
                r = wS.get_Range(bRange).Offset[1, k];
                r.Select();
                r.Formula = "=SUM(R[2]C:R[" + (i - 1).ToString() + "]C)";
                r.NumberFormat = "0.00";
            }

            for (int k = 3; k <= i; k++)
            {
                r = wS.get_Range(bRange).Offset[k, j];
                r.Select();
                r.Formula = "=SUM(RC[-" + (j - 1).ToString() + "]:RC[-1])";
                r.NumberFormat = "0.00";
            }

            Excel.Range sourceCells = wS.Range[bRange, wS.get_Range(bRange).get_Offset(i, j)];

            Excel.ChartObjects xlCharts = (Excel.ChartObjects)wS.ChartObjects(Type.Missing);
            Excel.ChartObject myChart;
            Excel.Chart chartPage;

            /**/
            r = wS.get_Range(bRange).get_Offset(3, drugs.Count + 1);
            double left = r.Left + r.Width;
            double top = r.Top + r.Height;
            myChart = (Excel.ChartObject)xlCharts.Add(left, top, 450, 375);
            chartPage = myChart.Chart;
            chartPage.ChartType = Excel.XlChartType.xlLineMarkers;
            chartPage.SetSourceData(sourceCells, Excel.XlRowCol.xlColumns);
            chartPage.ApplyDataLabels();

            /**/
            myChart = (Excel.ChartObject)xlCharts.Add(myChart.Left, myChart.Top + myChart.Height + 10, 450, 375);
            chartPage = myChart.Chart;
            chartPage.ChartType = Excel.XlChartType.xlColumnStacked;
            chartPage.SetSourceData(sourceCells, Excel.XlRowCol.xlColumns);
            chartPage.ApplyDataLabels();

            //---------------------------------------------//

            //excelApp.Workbooks.Close();

            //excelApp.Quit();

             //Clean up references to all COM objects
             //As per above, you're just using a Workbook and Excel Application instance, so release them:

            Marshal.FinalReleaseComObject(sourceCells);
            Marshal.FinalReleaseComObject(myChart);
            Marshal.FinalReleaseComObject(chartPage);

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

                excelApp.Visible = false;

                try
                {
                    DateTime dStart = DateTime.Now;

                    for (int chainI = 0; chainI < chainRecords.Count; chainI++)
                    {
                        Excel.Worksheet wS = excelApp.Worksheets.get_Item(chainI + 1);
                        wS.Name = chainRecords[chainI].name;
                        wS.Select();

                        wS.Application.ActiveWindow.SplitRow = 5;
                        wS.Application.ActiveWindow.SplitColumn = 5;
                        wS.Application.ActiveWindow.FreezePanes = true;

                        string bRange = "A2";

                        string posOffset = WriteDetailInfo(bRange, chainRecords[chainI].id, wS, periodRecords, drugRecords);

                        WriteGroupingInfo(posOffset, chainRecords[chainI].id, wS, periodRecords, drugRecords);

                        Excel.Range r = wS.Rows[1];
                        r.Hidden = true;

                        r = wS.Columns[3];
                        r.Hidden = true;
                    }

                    MessageBox.Show("Report is done. Total_mi:" + (DateTime.Now - dStart).TotalMinutes.ToString());
                    excelApp.Visible = true;
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
        }

        private object [,] GetSales(int chainID, int drugID, int posCount, string yearID, string monthID)
        {
            string command = "SELECT                                        "
                           + "    p_d.drug_id,                              "
                           + "    p_d.rowNum,                               "
                           + "    IFNULL( IF(rsbp.num=0,NULL, rsbp.num)     "
                           + "          , '''') AS NUM      			    "
                           + "  FROM (SELECT                                "
                           + "          @rn := @rn + 1 AS rowNum,           "
                           + "          p.id AS pos_id,                     "
                           + "      " + drugID.ToString() + " AS drug_id,   "
                           + "          p.name AS pos_name                  "
                           + "        FROM tbl_poses p,                     "
                           + "             (SELECT                          "
                           + "                 @rn := 0) rn                 "
                           + "        WHERE ( " + chainID.ToString() + " = p.chain_id "
                           + "             OR " + chainID.ToString() + " = 0 )        "
                           + "        ORDER                                 "
                           + "           BY p.id) AS p_d 			        "
                           + "    LEFT JOIN (                               "
                           + "      SELECT pos_id							"
                           + "           , drug_id							"
                           + "           , SUM(num) AS NUM                  "
                           + "        FROM vw_report_sales_by_poses         "
                           + "       WHERE year_id = " + yearID
                           + "         AND month_id = " + monthID
                           + "       GROUP                                  "
                           + "          BY pos_id,                          "
                           + "             drug_id                          "
                           + "       ) AS rsbp                              "
                           + "      ON rsbp.pos_id = p_d.pos_id             "
                           + "      AND rsbp.drug_id = p_d.drug_id          ";

            MySqlCommand cmd = new MySqlCommand(command, conn);

            DateTime start = DateTime.Now;

            MySqlDataReader myReader = cmd.ExecuteReader();

            double queryExecTime = (DateTime.Now - start).TotalMilliseconds;

            object [,] result = new object [posCount, 1];

            int i = 0; 
            
            while (myReader.Read())
            {
                result[i, 0] = myReader.GetString("num");
                i++;
            }

            myReader.Close();

            log.AppendLine("----------------- GetSales ----------------------");

            log.AppendLine(command);

            log.AppendFormat("##########  {0} ##########", queryExecTime.ToString());

            log.AppendLine("----------------- GetSales ----------------------");

            return result;
        }

        private List<SaleRecord> GetSales(int chainID, string yearID, string monthID)
        {
            string command = "SELECT                                        "
                           + "    p_d.drug_id,                              "
                           + "    p_d.rowNum,                               "
                           + "    IFNULL( IF(rsbp.num=0,NULL, rsbp.num)     "
                           + "          , '''') AS NUM      			    "
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
                           + "        WHERE ( " + chainID.ToString() + " = p.chain_id " 
                           + "             OR " + chainID.ToString() + " = 0 )        "
                           + "        ORDER                                 "
                           + "           BY p.id) AS pos) AS p_d 			"
                           + "    LEFT JOIN (                               "
                           + "      SELECT pos_id							"
                           + "           , drug_id							"
                           + "           , SUM(num) AS NUM                  "
                           + "        FROM vw_report_sales_by_poses         "
                           + "       WHERE year_id = " + yearID
                           + "         AND month_id = " + monthID
                           + "       GROUP                                  "
                           + "          BY pos_id,                          "
                           + "             drug_id                          "
                           + "       ) AS rsbp                              "
                           + "      ON rsbp.pos_id = p_d.pos_id             "
                           + "      AND rsbp.drug_id = p_d.drug_id          ";

            MySqlCommand cmd = new MySqlCommand(command, conn);

            DateTime start = DateTime.Now;

            MySqlDataReader myReader = cmd.ExecuteReader();

            double queryExecTime = (DateTime.Now - start).TotalMilliseconds;

            List<SaleRecord> result = new List<SaleRecord>();

            while (myReader.Read())
            {
                result.Add(new SaleRecord() { order = myReader.GetInt32("rowNum")
                                            , drug_id = myReader.GetInt32("drug_id")
                                            , num = myReader.GetString("num")
                                            }
                          );
            }

            myReader.Close();

            log.AppendLine("----------------- GetSales ----------------------");

            log.AppendLine(command);

            log.AppendFormat("##########  {0} ##########", queryExecTime.ToString());

            log.AppendLine("----------------- GetSales ----------------------");

            return result;
        }

        private int GetPOSCount(int chainID)
        {
            string command = "SELECT COUNT(p.id)                                "
                           + "  FROM vw_poses p                                 "
                           + " WHERE (" + chainID.ToString() + " = p.chain_id   "
                           + "     OR " + chainID.ToString() + " = 0)           "
                           ;

            MySqlCommand cmd = new MySqlCommand(command, conn);

            return int.Parse(cmd.ExecuteScalar().ToString());
        }

        private object[,] GetPOSes(int chainID, int posCount)
        {
            string command = "SELECT @rn := @rn + 1 AS rowNum                 "
                           + "     , p.id                                     "
                           + "     , IFNULL(p.name, '''') as name             "
                           + "     , IFNULL(p.address, '''') as address       "
                           + "     , p.area_id                                "
                           + "     , IFNULL(p.area_name, '''') as area        "
                           + "     , p.chain_id                               "
                           + "     , IFNULL(p.chain_name, '''') as chain_name "
                           + "  FROM vw_poses p                               "
                           + "     , (select @rn := 0) rn                     "
                           + " WHERE (" + chainID.ToString() + " = p.chain_id   "
                           + "     OR " + chainID.ToString() + " = 0)           "
                           ;

            MySqlCommand cmd = new MySqlCommand(command, conn);

            DateTime start = DateTime.Now;

            MySqlDataReader myReader = cmd.ExecuteReader();

            double queryExecTime = (DateTime.Now - start).TotalMilliseconds;

            object[,] result = new object[posCount,5];

            int i = 0;

            while (myReader.Read())
            {
                result[i, 0] = myReader.GetString("name");
                result[i, 1] = myReader.GetString("address");
                result[i, 2] = myReader.GetInt32("id");
                result[i, 3] = myReader.GetString("chain_name");
                result[i, 4] = myReader.GetString("area");
                i++;
            }

            myReader.Close();

            log.AppendLine("----------------- GetPOSes ----------------------");

            log.AppendLine(command);

            log.AppendFormat("##########  {0} ##########", queryExecTime.ToString());

            log.AppendLine("----------------- GetPOSes ----------------------");

            return result;
        }

        private List<POSRecord> GetPOSes(int chainID)
        {
            string command = "SELECT @rn := @rn + 1 AS rowNum                 "
                           + "     , p.id                                     "
                           + "     , IFNULL(p.name, '''') as name             "
                           + "     , IFNULL(p.address, '''') as address       "
                           + "     , p.area_id                                "
                           + "     , IFNULL(p.area_name, '''') as area        "
                           + "     , p.chain_id                               "
                           + "     , IFNULL(p.chain_name, '''') as chain_name "
                           + "  FROM vw_poses p                               "
                           + "     , (select @rn := 0) rn                     " 
                           + " WHERE ("+ chainID.ToString() +" = p.chain_id   " 
                           + "     OR "+ chainID.ToString() +" = 0)           "
                           ;

            MySqlCommand cmd = new MySqlCommand(command, conn);

            DateTime start = DateTime.Now;

            MySqlDataReader myReader = cmd.ExecuteReader();

            double queryExecTime = (DateTime.Now - start).TotalMilliseconds;

            List<POSRecord> result = new List<POSRecord>();

            while (myReader.Read())
            {
                result.Add(new POSRecord() { id = myReader.GetInt32("id")
                                           , name = myReader.GetString("name")
                                           , address = myReader.GetString("address")
                                           , area = myReader.GetString("area")
                                           , chain_id = myReader.GetInt32("chain_id")
                                           , chain_name = myReader.GetString("chain_name")
                                           , order = myReader.GetInt32("rowNum")
                                           }
                          );
            }

            myReader.Close();

            log.AppendLine("----------------- GetPOSes ----------------------");

            log.AppendLine(command);

            log.AppendFormat("##########  {0} ##########", queryExecTime.ToString());

            log.AppendLine("----------------- GetPOSes ----------------------");

            return result;
        }

        private List<ChainRecord> GetChains()
        {
            string command = "SELECT c.id          "
                           + "     , c.name        "
                           + "  FROM tbl_chains c  "
                           + " WHERE c.isd = '0'   "
                           + " UNION               "
                           + "SELECT 0, 'ВСЕ СЕТИ' ";

            MySqlCommand cmd = new MySqlCommand(command, conn);

            DateTime start = DateTime.Now;

            MySqlDataReader myReader = cmd.ExecuteReader();

            double queryExecTime = (DateTime.Now - start).TotalMilliseconds;

            List<ChainRecord> result = new List<ChainRecord>();

            while (myReader.Read())
            {
                result.Add(new ChainRecord() { id = myReader.GetInt32("id")
                                             , name = myReader.GetString("name")
                                             }
                          );
            }

            myReader.Close();

            log.AppendLine("----------------- GetChains ----------------------");

            log.AppendLine(command);

            log.AppendFormat("##########  {0} ##########", queryExecTime.ToString());

            log.AppendLine("----------------- GetChains ----------------------");

            return result;
        }

        private List<DrugRecord> GetDrugs ()
        {
            string command = "SELECT d.id, d.name, d.color, @rn := @rn + 1 as \"order\" FROM tbl_drugs d, (SELECT @rn := 0) rn";

            MySqlCommand cmd = new MySqlCommand(command, conn);

            DateTime start = DateTime.Now;

            MySqlDataReader myReader = cmd.ExecuteReader();

            double queryExecTime = (DateTime.Now - start).TotalMilliseconds;

            List<DrugRecord> result = new List<DrugRecord>();

            while (myReader.Read())
            {
                result.Add(new DrugRecord() {   id = myReader.GetInt32("id")
                                            ,   name = myReader.GetString("name")
                                            ,   color = myReader.GetInt32("color")
                                            ,   order = myReader.GetInt32("order")
                                            }
                          );
            }

            myReader.Close();

            result.Add(new DrugRecord() {   id = result[result.Count - 1].id + 1
                                        ,   name = "Итого"
                                        ,   color = 13434828
                                        ,   order = result[result.Count - 1].order + 1
                                        }
                      );

            return result;
        }

        private List<ReportRecord> GetReportRecords(int id = 0)
        {
            MySqlCommand cmd = new MySqlCommand(GenerateReportSQL(id), conn);

            DateTime start = DateTime.Now;

            MySqlDataReader myReader = cmd.ExecuteReader();

            double queryExecTime = (DateTime.Now - start).TotalMilliseconds;

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

            log.AppendLine("------------------GenerateReportSQL---------------------");

            log.AppendLine(cmd.CommandText);

            log.AppendFormat("##########  {0} ##########", queryExecTime.ToString());

            log.AppendLine("------------------GenerateReportSQL---------------------");

            return result;
        }

        private string GenerateReportSQL (int id)
        {
            //string yearInExpr = "";
            string result = "SELECT						"
                          + "   rs.drug_id,				"
                          + "   rs.name,				"
                          + "   rs.chain_id,			"
                          + "   rs.year_id,				"
                          + "   rs.year,				"
                          + "   rs.month_id,			"
                          + "   rs.month,				"
                          + "  SUM(rs.num) AS num		"
                          + "FROM vw_report_sales rs	"
                          + "WHERE ";
            string cnainIDexpr = (id > 0) ? " rs.chain_id = " + id.ToString() : " 1 = 1 ";
            string groupBYexpr = "GROUP BY rs.drug_id, rs.YEAR, rs.month_id ";
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

            result = result + cnainIDexpr + " AND (" + monthYEARexpr + ") " + groupBYexpr + orderBYexpr;

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
        public int order { get; set; }
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
        public string address { get; set; }
        public string area { get; set; }
        public int chain_id { get; set; }
        public string chain_name { get; set; }
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
        public string num { get; set; }
    }
}
