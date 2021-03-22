﻿using MySql.Data.MySqlClient;
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
    public partial class frmChangePass : Form
    {
        DBconnection dbcon = new DBconnection();
        MySqlConnection cn = new MySqlConnection();
        MySqlCommand cm = new MySqlCommand();
        MySqlDataReader dr;
        string title = "C# dev by TIK";
        string strOldpass;
        frmMain frmMain = new frmMain();
        frmSecurity frmSecurity = new frmSecurity();


        public frmChangePass()
        {
            InitializeComponent();
            cn = new MySqlConnection(dbcon.myConnection());
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void FrmChangePass_Load(object sender, EventArgs e)
        {

        }


        // Save New Password -- START
        private void BtnSave_Click(object sender, EventArgs e)
        {

            if (txtNewpass.Text == string.Empty)
            {
                MessageBox.Show("กรุณาใส่รหัสผ่านใหม่ที่ต้องการ...", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtConfirmNew.Text == string.Empty)
            {
                MessageBox.Show("กรุณาใส่ยืนยันรหัสผ่านใหม่ที่ต้องการ...", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (txtNewpass.Text != txtConfirmNew.Text)
            {
                MessageBox.Show("รหัสผ่านกับรหัสยืนยัน ไม่ตรงกัน!!", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("คุณต้องการเปลี่ยนรหัสผ่าน ใช่หรือไม่?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cn.Open();
                cm = new MySqlCommand("update tbl_user set password = @password where username like @username", cn);
                cm.Parameters.AddWithValue("@password", txtNewpass.Text);
                cm.Parameters.AddWithValue("@username", txtUsername.Text);
                cm.ExecuteNonQuery();
                cn.Close();
                frmMain.lblPass.Text = txtNewpass.Text;
                MessageBox.Show("คุณได้ทำการเปลี่ยนรหัสผ่านเรียบร้อยแล้ว", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            
        }// Save New Password -- END

        private void clearData()
        {
            txtConfirmNew.Clear();
            txtNewpass.Clear();
            txtNewpass.Focus();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            clearData();
        }
    }
}
