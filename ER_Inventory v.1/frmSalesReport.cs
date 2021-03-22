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
using Microsoft.Reporting.WinForms;
using DGVPrinterHelper;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text;
using CrystalDecisions.CrystalReports.Engine;

namespace ER_Inventory_v._1
{
    public partial class frmSalesReport : Form
    {
        DBconnection dbcon = new DBconnection();
        MySqlConnection cn = new MySqlConnection();
        MySqlCommand cm = new MySqlCommand();
        MySqlDataReader dr;
        string title = "C# dev by TIK";
        ReportDocument report = new ReportDocument();


        public frmSalesReport()
        {
            cn = new MySqlConnection(dbcon.myConnection());
            InitializeComponent();
            crystalReportViewer1.RefreshReport();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }

        private void FrmSalesReport_Load(object sender, EventArgs e)
        {
            //loadUser();
        }


        // load USer -- START
        private void loadUser()
        {
            //try
            //{
            //    cboUser.Items.Clear();
            //    cn.Open();
            //    cm = new MySqlCommand("select name from tbl_user", cn);
            //    dr = cm.ExecuteReader();
            //    while (dr.Read())
            //    {
            //        cboUser.Items.Add(dr["name"].ToString());
            //    }
            //    dr.Close();
            //    cn.Close();
            //}
            //catch
            //{

            //}
            
        }// load USer -- END


        // load Report -- START
        private void loadReport(string sql)
        {
            //try
            //{
            //    this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\Report1.rdlc";
            //    //AppDomain.CurrentDomain.BaseDirectory + "Report2.rdlc";
            //    this.reportViewer1.LocalReport.DataSources.Clear();

            //    ReportDataSource reportDataSource;
            //    DataSet1 ds = new DataSet1();
            //    MySqlDataAdapter da = new MySqlDataAdapter();

            //    cn.Open();
            //    da.SelectCommand = new MySqlCommand(sql, cn);
            //    da.Fill(ds.Tables["dtSales"]);
            //    cn.Close();

            //    //ReportParameter pDate = new ReportParameter("pDate", "Date covered : (" + sdate1 + " - " + sdate2 + ")" );
            //    //reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pDate });
            //    reportDataSource = new ReportDataSource();
            //    reportDataSource.Name = "DataSet1";
            //    reportDataSource.Value = ds.Tables["dtSales"];
            //    reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            //    reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            //    reportViewer1.ZoomMode = ZoomMode.Percent;
            //    reportViewer1.ZoomPercent = 80;
            //    reportViewer1.RefreshReport();


            //    //// Must match the DataSet in the RDLC
            //    //reportDataSource.Name = "dtSales";
            //    //reportDataSource.Value = ds.Tables[0];
            //    //this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            //    //this.reportViewer1.RefreshReport();
            //}
            //catch
            //{
            //    cn.Close();
            //    MessageBox.Show("Error", title);
            //}


        }// load Report -- END



        // load Sales Report -- START
        private void BtnShowReport_Click(object sender, EventArgs e)
        {
            string sdate1 = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            string sdate2 = dateTimePicker2.Value.ToString("dd/MM/yyyy");
            MySqlDataAdapter da;
            DataSet ds = new DataSet();
            cn.Open();
            report.Load(Application.StartupPath + @"\Reports\my_rpt.rpt");

            da = new MySqlDataAdapter("select * from tbl_sale where sdate between '" + sdate1 + "' and '" + sdate2 + "' ", cn);
            da.Fill(ds, "tbl_sale");
            report.SetDataSource(ds);
            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();
            crystalReportViewer1.RefreshReport();
            ds.Dispose();
            da.Dispose();
            cn.Close();
           
        }// load Sales Report -- END

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        // Generate PDF file -- START
        private void BtnPDF_Click(object sender, EventArgs e)
        {
            //string fileName = string.Empty;
            //DateTime fileCreationDatetime = DateTime.Now;

            //if (dgvSalesReport.Rows.Count > 0)
            //{
            //    SaveFileDialog sfd = new SaveFileDialog();
            //    sfd.Filter = "PDF File |*.pdf";
            //    sfd.FileName = string.Format("{0}.pdf", fileCreationDatetime.ToString(@"yyyyMMdd") + "_" + fileCreationDatetime.ToString(@"HHmmss"));
            //    sfd.ShowDialog();
            //    bool fileError = false;
            //    if (!fileError)
            //    {
            //        try
            //        {
            //            PdfPTable pdfPTable = new PdfPTable(dgvSalesReport.Columns.Count);
            //            pdfPTable.DefaultCell.Padding = 0;
            //            pdfPTable.WidthPercentage = 100;
            //            pdfPTable.HorizontalAlignment = 2;

            //            foreach (DataGridViewColumn column in dgvSalesReport.Columns)
            //            {
            //                PdfPCell cell = new PdfPCell(new iTextSharp.text.Phrase(column.HeaderText));
            //                pdfPTable.AddCell(cell);
            //            }

            //            foreach (DataGridViewRow row in dgvSalesReport.Rows)
            //            {
            //                foreach (DataGridViewCell cell in row.Cells)
            //                {
            //                    pdfPTable.AddCell(cell.Value.ToString());
            //                }
            //            }

            //            using (FileStream stream = new FileStream(sfd.FileName, mode: FileMode.Create))
            //            {
            //                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
            //                PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, stream);
            //                iTextSharp.text.Font font = FontFactory.GetFont("Arial", 10f, iTextSharp.text.BaseColor.BLACK);

            //                pdfDoc.Open();
            //                float[] widths = new float[] { 10f, 10f, 6f, 4f, 2f, 3f, 4f }; // size per column
            //                pdfPTable.SetWidths(widths);
            //                pdfDoc.Add(pdfPTable);
            //                pdfDoc.Close();
            //                stream.Close();
            //            }

            //            MessageBox.Show("Data Exported Successfully !!", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.Message);
            //        }
            //    }
            //}
        }// Generate PDF file -- END

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnEXCEL_Click(object sender, EventArgs e)
        {

        }
    }
}
