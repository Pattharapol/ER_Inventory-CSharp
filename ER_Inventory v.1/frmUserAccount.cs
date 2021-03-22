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
    public partial class frmUserAccount : Form
    {
        DBconnection dbcon = new DBconnection();
        MySqlConnection cn = new MySqlConnection();
        MySqlCommand cm = new MySqlCommand();
        MySqlDataReader dr;
        string title = "C# dev by TIK";
        public frmUserAccount()
        {
            cn = new MySqlConnection(dbcon.myConnection());
            InitializeComponent();
            this.ActiveControl = txtSearch;
        }

        public void loadUserList()
        {
            try
            {
                dgvUser.Rows.Clear();
                int i = 0;
                cn.Open();
                cm = new MySqlCommand("select * from tbl_user ", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    dgvUser.Rows.Add(i, dr["username"].ToString(), dr["user_type"].ToString(), dr["name"].ToString(), dr["status"].ToString(), "ChangePassword");
                }
                dr.Close();
                cn.Close();
                lblCount2.Text = dgvUser.RowCount + " record(s) found";
            }
            catch
            {

            }
        }

        private void FrmUserAccount_Load(object sender, EventArgs e)
        {
            loadUserList();
        }

       
        private void DgvUserList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvUser.Columns[e.ColumnIndex].Name;
            if (colName == "status")
            {
                if (dgvUser.Rows[e.RowIndex].Cells[4].Value.ToString() == "Active")
                {
                    if (MessageBox.Show("คุณต้องการปิดการใช้งานของ "+ dgvUser.Rows[e.RowIndex].Cells[3].Value.ToString() + " ใช่หรือไม่?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new MySqlCommand("update tbl_user set status = 'Inactive' where username like '" + dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString() + "' ", cn);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("สถานะการใช้งานของ " + dgvUser.Rows[e.RowIndex].Cells[3].Value.ToString()+ " ถูกปิดสำเร็จแล้ว", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (dgvUser.Rows[e.RowIndex].Cells[4].Value.ToString() == "Inactive")
                {
                    if (MessageBox.Show("คุณต้องการเปิดการใช้งานของ " + dgvUser.Rows[e.RowIndex].Cells[3].Value.ToString() +  " ใช่หรือไม่", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new MySqlCommand("update tbl_user set status = 'Active' where username like '" + dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString() + "' ", cn);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("เปิดสถานะการทำงานของ" + dgvUser.Rows[e.RowIndex].Cells[3].Value.ToString() + "สำเร็จแล้ว", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if (colName == "Change")
            {
                frmChangePass frmChangePass = new frmChangePass();
                frmChangePass.txtUsername.Text = dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                frmChangePass.Show();
            }
            loadUserList();
        }

        private void CreateUser_Click(object sender, EventArgs e)
        {
            frmUser frm = new frmUser();
            frm.Show();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvUser.Rows.Clear();
                int i = 0;
                cn.Open();
                cm = new MySqlCommand("select * from tbl_user where username like '%" + txtSearch.Text + "%' or name like '%" +txtSearch.Text+"%' ", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    dgvUser.Rows.Add(i, dr["username"].ToString(), dr["user_type"].ToString(), dr["name"].ToString(), dr["status"].ToString(), "ChangePassword");
                }
                dr.Close();
                cn.Close();
                lblCount2.Text = "ข้อมูลทั้งหมด" + dgvUser.RowCount + " รายการ";
            }
            catch
            {

            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            loadUserList();
        }
    }
}
