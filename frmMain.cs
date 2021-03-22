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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            customizeDesign();
        }

        // ShowsubMenu func -- START
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }// ShowsubMenu func -- END


        // check if submenu is showing -- START
        private void hideSubMenu()
        {
            if (panelSubMenu.Visible == true)
                panelSubMenu.Visible = false;
        }// check if submenu is showing -- END


        // ซ่อน subpanel -- START
        private void customizeDesign()
        {
            panelSubMenu.Visible = false;
        }// ซ่อน subpanel -- END

        private void BtnMaintainance_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenu);
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnCategory_Click(object sender, EventArgs e)
        {
            frmCategoryList frmCategoryList = new frmCategoryList();
            frmCategoryList.TopLevel = false;
            panelMain.Controls.Add(frmCategoryList);
            frmCategoryList.BringToFront();
            frmCategoryList.btnUpdate.Hide();
            frmCategoryList.btnCancel.Hide();
            frmCategoryList.Show();
            this.ActiveControl = frmCategoryList.txtCategory;
        }

        private void BtnBrand_Click(object sender, EventArgs e)
        {
            frmBrandList frmBrandList = new frmBrandList();
            frmBrandList.TopLevel = false;
            panelMain.Controls.Add(frmBrandList);
            frmBrandList.BringToFront();
            frmBrandList.btnCancel.Hide();
            frmBrandList.btnUpdate.Hide();
            frmBrandList.Show();
            this.ActiveControl = frmBrandList.txtBrand;
        }

        private void BtnGeneric_Click(object sender, EventArgs e)
        {
            frmGeneric frmGeneric = new frmGeneric();
            frmGeneric.TopLevel = false;
            panelMain.Controls.Add(frmGeneric);
            frmGeneric.BringToFront();
            frmGeneric.btnCancel.Hide();
            frmGeneric.btnUpdate.Hide();
            frmGeneric.Show();
            this.ActiveControl = frmGeneric.txtGeneric;
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            frmUnit frmUnit = new frmUnit();
            frmUnit.TopLevel = false;
            panelMain.Controls.Add(frmUnit);
            frmUnit.BringToFront();
            frmUnit.btnCancel.Hide();
            frmUnit.btnUpdate.Hide();
            frmUnit.Show();
            this.ActiveControl = frmUnit.txtUnit;
        }

        private void BtnFormulation_Click(object sender, EventArgs e)
        {
            frmFormulation frmFormulation = new frmFormulation();
            frmFormulation.TopLevel = false;
            panelMain.Controls.Add(frmFormulation);
            frmFormulation.BringToFront();
            frmFormulation.btnCancel.Hide();
            frmFormulation.btnUpdate.Hide();
            frmFormulation.Show();
            this.ActiveControl = frmFormulation.txtformulation;
        }

        private void BtnProduct_Click(object sender, EventArgs e)
        {
            frmProductList frmProductList = new frmProductList();
            frmProductList.TopLevel = false;
            panelMain.Controls.Add(frmProductList);
            frmProductList.BringToFront();
            frmProductList.btnCancel.Hide();
            frmProductList.btnUpdate.Hide();
            frmProductList.Show();
        }

        private void btnStockIn_Click(object sender, EventArgs e)
        {
            frmStockIn frmstockin = new frmStockIn();
            frmstockin.TopLevel = false;
            panelMain.Controls.Add(frmstockin);
            frmstockin.BringToFront();
            frmstockin.Show();
        }

        private void BtnSales_Click(object sender, EventArgs e)
        {
            frmSales frmSales = new frmSales();
            frmSales.TopLevel = false;
            panelMain.Controls.Add(frmSales);
            frmSales.BringToFront();
            frmSales.Show();
        }

        private void btnRecords_Click(object sender, EventArgs e)
        {
            frmRecords frmRecord = new frmRecords();
            frmRecord.TopLevel = false;
            panelMain.Controls.Add(frmRecord);
            frmRecord.BringToFront();
            frmRecord.Show();
        }

        private void BtnAccount_Click(object sender, EventArgs e)
        {
            frmUserAccount frm = new frmUserAccount();
            frm.TopLevel = false;
            panelMain.Controls.Add(frm);
            frm.loadUserList();
            frm.BringToFront();
            frm.Show();

        }

        private void BtnSaleReport_Click(object sender, EventArgs e)
        {
            frmSalesReport frmSalesReport = new frmSalesReport();
            frmSalesReport.TopLevel = false;
            panelMain.Controls.Add(frmSalesReport);
            frmSalesReport.BringToFront();
            frmSalesReport.Show();
        }
    }
}
