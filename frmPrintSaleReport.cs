using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ER_Inventory_v._1
{
    public partial class frmPrintSaleReport : Form
    {
       
        DBconnection dbcon = new DBconnection();
        MySqlConnection cn = new MySqlConnection();
        MySqlCommand cm = new MySqlCommand();
        MySqlDataReader dr;
        MySqlDataAdapter da;
        string title = "C# dev by TIK";
        frmSalesReport frmSalesReport = new frmSalesReport();
        DataSet ds = new DataSet();
        public frmPrintSaleReport()
        {
            InitializeComponent();
            cn = new MySqlConnection(dbcon.myConnection());
            
            string sdate1 = frmSalesReport.dateTimePicker1.Value.ToString("dd/MM/yyyy");
            string sdate2 = frmSalesReport.dateTimePicker2.Value.ToString("dd/MM/yyyy");

            try
            {
                //string date1 = frmSalesReport.dateTimePicker1.Value.ToShortDateString().Trim();
                //string date2 = frmSalesReport.dateTimePicker1.Value.ToShortDateString().Trim();
                //my_rpt objRpt = new my_rpt();
                //// Creating object of our report.
                //cn.Open();
                //da = new MySqlDataAdapter("select * from tbl_sale", cn);
                //DataSet ds = new DataSet();
                //da.Fill(ds, "tbl_sale");
                //if (ds.Tables[0].Rows.Count == 0)
                //{
                //    MessageBox.Show("No data Found", title);
                //    return;
                //}
                //// Setting data source of our report object
                //objRpt.SetDataSource(ds);
                //CrystalDecisions.CrystalReports.Engine.TextObject root;
                //root = (CrystalDecisions.CrystalReports.Engine.TextObject)
                //     objRpt.ReportDefinition.ReportObjects["txt_header"];
                //root.Text = "Sample Report By Using Data Table!!";

                //// Binding the crystalReportViewer with our report object. 
                //crystalReportViewer1.ReportSource = objRpt;
                //crystalReportViewer1.Refresh();
                //crystalReportViewer1.RefreshReport();
                //da.Dispose();
                //ds.Clear();
                //cn.Close();

                


                //cn.Open();
                //report.Load(@"C:\Users\IT\source\repos\ER_Inventory v.1\ER_Inventory v.1\my_rpt.rpt");
                
                //da = new MySqlDataAdapter("select * from tbl_sale where sdate between '" + sdate1 + "' and '" + sdate2 + "' ", cn);
                //da.Fill(ds, "tbl_sale");
                //report.SetDataSource(ds);
                //crystalReportViewer1.ReportSource = report;
                //crystalReportViewer1.Refresh();
                //crystalReportViewer1.RefreshReport();
                //ds.Dispose();
                //da.Dispose();
                //cn.Close();
                
            }
            catch
            {
                MessageBox.Show("Cant Print Report!!", title);
            }
        }   


        private void FrmPrintSaleReport_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    //string date1 = frmSalesReport.dateTimePicker1.Value.ToShortDateString().Trim();
            //    //string date2 = frmSalesReport.dateTimePicker1.Value.ToShortDateString().Trim();
            //    //my_rpt objRpt = new my_rpt();
            //    //// Creating object of our report.
            //    //cn.Open();
            //    //da = new MySqlDataAdapter("select * from tbl_sale", cn);
            //    //DataSet ds = new DataSet();
            //    //da.Fill(ds, "tbl_sale");
            //    //if (ds.Tables[0].Rows.Count == 0)
            //    //{
            //    //    MessageBox.Show("No data Found", title);
            //    //    return;
            //    //}
            //    //// Setting data source of our report object
            //    //objRpt.SetDataSource(ds);
            //    //CrystalDecisions.CrystalReports.Engine.TextObject root;
            //    //root = (CrystalDecisions.CrystalReports.Engine.TextObject)
            //    //     objRpt.ReportDefinition.ReportObjects["txt_header"];
            //    //root.Text = "Sample Report By Using Data Table!!";

            //    //// Binding the crystalReportViewer with our report object. 
            //    //crystalReportViewer1.ReportSource = objRpt;
            //    //crystalReportViewer1.Refresh();
            //    //crystalReportViewer1.RefreshReport();
            //    //da.Dispose();
            //    //ds.Clear();
            //    //cn.Close();

            //    crystalReportViewer1.RefreshReport();
            //    string sdate1 = frmSalesReport.dateTimePicker1.Value.ToString("yyyy-MM-dd");
            //    string sdate2 = frmSalesReport.dateTimePicker2.Value.ToString("yyyy-MM-dd");


            //    cn.Open();
                
            //    report.Load(@"C:\Users\IT\source\repos\ER_Inventory v.1\ER_Inventory v.1\my_rpt.rpt");
            //    DataSet ds = new DataSet();
            //    da = new MySqlDataAdapter("select * from tbl_sale where sdate between '"+sdate1+"' and '"+sdate2+"' ", cn);
            //    da.Fill(ds, "tbl_sale");
            //    report.SetDataSource(ds);
            //    crystalReportViewer1.ReportSource = report;
            //    crystalReportViewer1.Refresh();
            //    crystalReportViewer1.RefreshReport();
            //    //ds.Dispose();
            //    da.Dispose();
            //    cn.Close();

            //}
            //catch
            //{
            //    MessageBox.Show("Cant Print Report!!", title);
            //}
           
            
        }
    }
}
