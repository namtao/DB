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
            lbSum.Text = new SqlCommand("select count(*) from " + cbxLoai.Text + " where NOIDANGKY LIKE '%" + cbxNDK.SelectedValue + "%' " +
                "and quyenSo like '%" + cbxQuyenSo.Text + "%' ", conn)
                .ExecuteScalar().ToString() + "";
            conn.Close();
        }

        private void btnDiff_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Home.sqlConnect);
            conn.Open();
            string sqlQuery = "SELECT ID, so as N'Số', quyenSo as N'Quyển số', " +
                "noiDangKy as N'Nơi đăng ký', ngayDangKy as N'Ngày đăng ký', " +
                "tableName as N'Loại', columnName as N'Trường', ktbm1 as N'Biên mục', " +
                "ktbm2 as N'Kiểm tra 1', kt as N'Kiểm tra 2'" +
                " FROM Diff where quyenSo like '%"+cbxQuyenSo.Text+"%' " +
                "and noiDangKy LIKE '%"+cbxNDK.SelectedValue+"%' and tableName = '"+cbxLoai.Text+"'";
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            lbSumData.Text = new SqlCommand("select count(*) from Diff where quyenSo like '%" + cbxQuyenSo.Text + "%' " +
                "and noiDangKy LIKE '%" + cbxNDK.SelectedValue + "%' and tableName = '" + cbxLoai.Text + "'", conn)
                .ExecuteScalar().ToString() + "";
            conn.Close();
            datagrid.DataSource = ds.Tables[0];
            datagrid.Visible = true;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)datagrid.DataSource;
            if (datagrid.Rows.Count != 0 && datagrid.Rows != null)
            {
                Utils.Export(dt, datagrid, "So sánh", "So sánh biên mục");
            }
            else MessageBox.Show("Không có dữ liệu để lưu vào excel, vui lòng kiểm tra lại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
