using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB
{
    public partial class QuaTrinhXuLy : Form
    {
        public QuaTrinhXuLy()
        {
            InitializeComponent();
        }

        private void QuaTrinhXuLy_FormClosing(object sender, FormClosingEventArgs e)
        {
            Home.form1.Show();
        }

        private void QuaTrinhXuLy_Load(object sender, EventArgs e)
        {
            cbxLoai.SelectedIndex = 0;
            updateSum();
        }

        private void cbxQuyenSo_DropDown(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Home.sqlConnect);
            conn.Open();
            string strCmd = "select distinct quyenSo from "+cbxLoai.Text+" where NOIDANGKY LIKE '%" + cbxNDK.SelectedValue + "%' ";
            SqlCommand cmd = new SqlCommand(strCmd, conn);
            SqlDataAdapter da = new SqlDataAdapter(strCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            conn.Close();
            cbxQuyenSo.DisplayMember = "quyenSo";
            cbxQuyenSo.ValueMember = "quyenSo";
            cbxQuyenSo.DataSource = ds.Tables[0];
        }

        private void cbxNDK_DropDown(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Home.sqlConnect);
            conn.Open();
            string strCmd = "SELECT * FROM HT_NOIDANGKY WHERE TenNoiDangKy LIKE N'%Quận 10%' ORDER BY TenNoiDangKy";
            SqlCommand cmd = new SqlCommand(strCmd, conn);
            SqlDataAdapter da = new SqlDataAdapter(strCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            conn.Close();
            cbxNDK.DisplayMember = "TenNoiDangKy";
            cbxNDK.ValueMember = "MaNoiDangKy";
            cbxNDK.DataSource = ds.Tables[0];
        }

        private void cbxQuyenSo_TextChanged(object sender, EventArgs e)
        {
            updateSum();
        }

        private void cbxNDK_TextChanged(object sender, EventArgs e)
        {
            updateSum();
        }

        private void cbxLoai_TextChanged(object sender, EventArgs e)
        {
            updateSum();
        }

        private void updateSum()
        {
            SqlConnection conn = new SqlConnection(Home.sqlConnect);
            conn.Open();
            lbSum.Text = new SqlCommand("select count(*) from " + cbxLoai.Text + " where NOIDANGKY LIKE '%" + cbxNDK.SelectedValue + "%' ", conn)
                .ExecuteScalar().ToString() + "";
            conn.Close();
        }
    }
}
