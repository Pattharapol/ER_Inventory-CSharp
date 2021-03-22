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
    public partial class frmProduct : Form
    {
        DBconnection dbcon = new DBconnection();
        MySqlConnection cn = new MySqlConnection();
        MySqlCommand cm = new MySqlCommand();
        MySqlDataReader dr;
        string title = "C# dev by TIK";

        public frmProduct()
        {
            InitializeComponent();
            cn = new MySqlConnection(dbcon.myConnection());
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtBrand;
            loadBrand();
            loadGeneric();
            loadCategory();
        }


        // load Brand -- START
        private void loadBrand()
        {
            try
            {
                cn.Open();
                cm = new MySqlCommand("select * from tbl_brand order by brand ASC", cn);
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(cm);
                da.Fill(ds, "brand"); // fill dataset , sourceTable
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                for (int i = 0; i < ds.Tables[0].Rows.Count - 1; i++)
                {
                    col.Add(ds.Tables[0].Rows[i]["brand"].ToString());
                }
                txtBrand.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtBrand.AutoCompleteCustomSource = col;
                txtBrand.AutoCompleteMode = AutoCompleteMode.Suggest;
                da.Dispose();
                cm.ExecuteNonQuery();
                cn.Close();
            }
            catch
            {

            }
        }// load Brand -- END


        // load Generic -- START
        private void loadGeneric()
        {
            try
            {
                cn.Open();
                cm = new MySqlCommand("select * from tbl_generic order by generic ASC", cn);
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(cm);
                da.Fill(ds, "generic"); // fill dataset , sourceTable
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                for (int i = 0; i < ds.Tables[0].Rows.Count - 1; i++)
                {
                    col.Add(ds.Tables[0].Rows[i]["generic"].ToString());
                }
                txtGeneric.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtGeneric.AutoCompleteCustomSource = col;
                txtGeneric.AutoCompleteMode = AutoCompleteMode.Suggest;
                da.Dispose();
                cm.ExecuteNonQuery();
                cn.Close();
            }
            catch
            {

            }
        }// load Generic -- END


        // load Category -- START
        private void loadCategory()
        {
            try
            {
                cn.Open();
                cm = new MySqlCommand("select * from tbl_category order by category ASC", cn);
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(cm);
                da.Fill(ds, "category"); // fill dataset , sourceTable
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                for (int i = 0; i < ds.Tables[0].Rows.Count - 1; i++)
                {
                    col.Add(ds.Tables[0].Rows[i]["category"].ToString());
                }
                txtCategory.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtCategory.AutoCompleteCustomSource = col;
                txtCategory.AutoCompleteMode = AutoCompleteMode.Suggest;
                da.Dispose();
                cm.ExecuteNonQuery();
                cn.Close();
            }
            catch
            {

            }
        }// load Category -- END


        // load Formulation -- START
        private void loadFormulation()
        {
            try
            {
                cn.Open();
                cm = new MySqlCommand("select * from tbl_formulation order by formulation ASC", cn);
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(cm);
                da.Fill(ds, "formulation"); // fill dataset , sourceTable
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                for (int i = 0; i < ds.Tables[0].Rows.Count - 1; i++)
                {
                    col.Add(ds.Tables[0].Rows[i]["formulation"].ToString());
                }
                txtFormulation.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtFormulation.AutoCompleteCustomSource = col;
                txtFormulation.AutoCompleteMode = AutoCompleteMode.Suggest;
                da.Dispose();
                cm.ExecuteNonQuery();
                cn.Close();
            }
            catch
            {

            }
        }// load Formulation -- END
 

        // Brand Textchanged -- START
        private void TxtBrand_TextChanged_1(object sender, EventArgs e)
        {
            cn.Open();
            cm = new MySqlCommand("select * from tbl_brand where brand like @brand", cn);
            cm.Parameters.AddWithValue("@brand", txtBrand.Text);
            dr = cm.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                lblBrand.Text = dr[0].ToString();
            }
            else
            {
                lblBrand.Text = "nothing";
            }
            cm.Dispose();
            dr.Close();
            cn.Close();
        }// Brand Textchanged -- END


        // Generic Textchanged -- START
        private void TxtGeneric_TextChanged_1(object sender, EventArgs e)
        {
            cn.Open();
            cm = new MySqlCommand("select * from tbl_generic where generic like @generic", cn);
            cm.Parameters.AddWithValue("@generic", txtGeneric.Text);
            dr = cm.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                lblGeneric.Text = dr[0].ToString();
            }
            else
            {
                lblGeneric.Text = "nothing";
            }
            cm.Dispose();
            dr.Close();
            cn.Close();
        }// Generic Textchanged -- END


        // Category Textchanged -- START
        private void TxtCategory_TextChanged_1(object sender, EventArgs e)
        {
            cn.Open();
            cm = new MySqlCommand("select * from tbl_category where category like @category", cn);
            cm.Parameters.AddWithValue("@category", txtCategory.Text);
            dr = cm.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                lblCategory.Text = dr[0].ToString();
            }
            else
            {
                lblCategory.Text = "nothing";
            }
            cm.Dispose();
            dr.Close();
            cn.Close();
        }// Category Textchanged -- END


        // Formulation Textchanged -- START
        private void TxtFormulation_TextChanged_1(object sender, EventArgs e)
        {
            cn.Open();
            cm = new MySqlCommand("select * from tbl_formulation where formulation like @formulation", cn);
            cm.Parameters.AddWithValue("@formulation", txtFormulation.Text);
            dr = cm.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                lblFormulation.Text = dr[0].ToString();
            }
            else
            {
                lblFormulation.Text = "nothing";
            }
            cm.Dispose();
            dr.Close();
            cn.Close();
        }// Formulation Textchanged -- END
    }
}
