using CrystalDecisions.CrystalReports.Engine;
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
    public partial class frmStockInReport : Form
    {
        DBconnection dbcon = new DBconnection();
        MySqlConnection cn = new MySqlConnection();
        MySqlCommand cm = new MySqlCommand();
        MySqlDataReader dr;
        string title = "C# dev by TIK";
        ReportDocument report = new ReportDocument();

        public frmStockInReport()
        {
            InitializeComponent();
            cn = new MySqlConnection(dbcon.myConnection());
            crystalReportViewer2.RefreshReport();
        }

        private void FrmStockInReport_Load(object sender, EventArgs e)
        {
            frmStockIn frm = new frmStockIn();
            string sdate1 = frm.dt1.Value.ToString("dd/MM/yyyy");
            DataSet ds = new DataSet();
            MySqlDataAdapter da;
            cn.Open();
            report.Load(Application.StartupPath + @"\Report2\CrystalReport1.rpt");

            da = new MySqlDataAdapter("select * from tbl_stockin where sdate like '" + sdate1 + "'  ", cn);
            da.Fill(ds, "tbl_stockin");
            report.SetDataSource(ds);
            crystalReportViewer2.ReportSource = report;
            crystalReportViewer2.Refresh();
            crystalReportViewer2.RefreshReport();
            ds.Dispose();
            da.Dispose();
            cn.Close();
        }
    }
}
