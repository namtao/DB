using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Office.Interop;
using System.IO;
using System.Net;
using DB;

namespace DB
{
    public partial class Home : Form
    {
        public string database = "";
        public static string sqlConnect;
        public static Home form1;
        public static string dbName = "USE HoTich;\n";
        string hoten = null;
        string ngaySinh = null;
        string strCommandSql = null;
        string exe = null;
        string table = null;
        SqlConnection conn;

        public Home()
        {
            InitializeComponent();
            form1 = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(sqlConnect);
                conn.Open();
                lbKS.Text = "Khai sinh: " + new SqlCommand("SELECT COUNT(*) FROM HT_KHAISINH", conn).ExecuteScalar().ToString();
                lbKT.Text = "Khai Tử: " + new SqlCommand("SELECT COUNT(*) FROM HT_KHAITU", conn).ExecuteScalar().ToString();
                lbKH.Text = "Kết hôn: " + new SqlCommand("SELECT COUNT(*) FROM HT_KETHON", conn).ExecuteScalar().ToString();
                lbCMC.Text = "Nhận cha mẹ con: " + new SqlCommand("SELECT COUNT(*) FROM HT_NHANCHAMECON", conn).ExecuteScalar().ToString();
                //lb1Ngay.Text = "Số lượng/ngày: " + new SqlCommand("SELECT COUNT(DISTINCT OBJECTID) FROM HT_XULY " +
                //"WHERE CONVERT(DATE, NGAYXULY, 103) = CONVERT(DATE, GETDATE(), 103)", conn).ExecuteScalar().ToString();
                lbTong.Text = "Tổng: " + (Convert.ToInt32(new SqlCommand("SELECT COUNT(*) FROM HT_KHAISINH", conn).ExecuteScalar()) +
                    Convert.ToInt32(new SqlCommand("SELECT COUNT(*) FROM HT_KHAITU", conn).ExecuteScalar()) +
                    Convert.ToInt32(new SqlCommand("SELECT COUNT(*) FROM HT_KETHON", conn).ExecuteScalar()) +
                    Convert.ToInt32(new SqlCommand("SELECT COUNT(*) FROM HT_NHANCHAMECON", conn).ExecuteScalar())).ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        /*
                private void btnConnect_Click(object sender, EventArgs e)
                {
                    try
                    {
                        SqlConnection conn = getConnect();
                        conn.Open();
                        string strCmd = "SELECT NAME FROM SYS.DATABASES ORDER BY NAME";
                        SqlCommand cmd = new SqlCommand(strCmd, conn);
                        SqlDataAdapter da = new SqlDataAdapter(strCmd, conn);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        cbxDB.DisplayMember = "NAME";
                        cbxDB.ValueMember = "NAME";
                        cbxDB.DataSource = ds.Tables[0];
                    }catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                private void cbxDB_SelectedValueChanged(object sender, EventArgs e)
                {

                }

                private void cbxDB_SelectedIndexChanged(object sender, EventArgs e)
                {
                    SqlConnection conn = getConnect();
                    conn.Open();
                    database = cbxDB.SelectedValue.ToString();
                    string strCmd = "SELECT TABLE_NAME FROM " + database + ".INFORMATION_SCHEMA.TABLES ORDER BY TABLE_NAME";
                    SqlCommand cmd = new SqlCommand(strCmd, conn);
                    SqlDataAdapter da = new SqlDataAdapter(strCmd, conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    cbxTables.DisplayMember = "TABLE_NAME";
                    cbxTables.ValueMember = "TABLE_NAME";
                    cbxTables.DataSource = ds.Tables[0];
                }
        */



        public void fillDgv(string sqlQuery)
        {
            SqlConnection conn = new SqlConnection(sqlConnect);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            conn.Close();
            datagrid.DataSource = ds.Tables[0];
        }

        private void btnExe_Click(object sender, EventArgs e)
        {
            try
            {
                //strCommandSql = rtbSQL.Text;
                if (rdnOther.Checked) strCommandSql = rtbSQL.Text;
                datagrid.Visible = true;
                fillDgv(strCommandSql);
                lbCount.Text = (datagrid.Rows.Count - 1).ToString() + " Rows";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConnectDB.connect.Show();
        }

        private void btnClone_Click(object sender, EventArgs e)
        {
            Clone form3 = new Clone();
            form3.Show();
            this.Hide();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            // Lấy về nguồn dữ liệu cần Export là 1 DataTable
            // DataTable này mỗi bạn lấy mỗi khác. 
            // Ở đây tôi dùng BindingSouce có tên bs nên tôi ép kiểu như sau:
            // Bạn nào gán trực tiếp vào DataGridView thì ép kiểu DataSource của
            // DataGridView nhé 
            DataTable dt = (DataTable)datagrid.DataSource;
            Utils.Export(dt, "Kiểm tra", "Kiểm tra trước khi up");
        }

        private void rdnLoiTrangSo_CheckedChanged(object sender, EventArgs e)
        {
            xuLyLenh();
        }

        private void rdnTrung_CheckedChanged(object sender, EventArgs e)
        {
            xuLyLenh();
        }

        private void rdnId7_CheckedChanged(object sender, EventArgs e)
        {
            xuLyLenh();
        }

        private void rdnFormat_CheckedChanged(object sender, EventArgs e)
        {
            xuLyLenh();
        }

        private void rdnOther_CheckedChanged(object sender, EventArgs e)
        {
            xuLyLenh();
        }

        private void rdnChuanHoa_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rdnKS_CheckedChanged(object sender, EventArgs e)
        {
            xuLyLoai();
        }

        private void rdnKT_CheckedChanged(object sender, EventArgs e)
        {
            xuLyLoai();
        }

        private void rdnKH_CheckedChanged(object sender, EventArgs e)
        {
            xuLyLoai();
        }

        private void rdnCMC_CheckedChanged(object sender, EventArgs e)
        {
            xuLyLoai();
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            if ((txtYear.Text != "" && Utils.IsNumber(txtYear.Text) && txtYear.Text.Length == 4))
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                //txtNdk.Enabled = true;
                //rtbSQL.Enabled = true;
                //btnClone.Enabled = true;
                btnExe.Enabled = true;
                btnExportExcel.Enabled = true;
                rdnKS.Checked = true;
                rdnLoiTrangSo.Checked = true;
                rtbSQL.Text = strCommandSql;
                //datagrid.Visible = true;
            }
            else
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                rtbSQL.Enabled = false;
                //btnClone.Enabled = false;
                btnExe.Enabled = false;
                btnExportExcel.Enabled = false;
                rdnKS.Checked = false;
                rdnLoiTrangSo.Checked = false;
                rtbSQL.Text = "";
                datagrid.Visible = false;
            }
        }

        private void txtNdk_TextChanged(object sender, EventArgs e)
        {
            if (txtNdk.Text != "")
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                //txtNdk.Enabled = true;
                //rtbSQL.Enabled = true;
                //btnClone.Enabled = true;
                btnExe.Enabled = true;
                btnExportExcel.Enabled = true;
                rdnKS.Checked = true;
                rdnLoiTrangSo.Checked = true;
                rtbSQL.Text = strCommandSql;
                //datagrid.Visible = true;
            }
            else
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                rtbSQL.Enabled = false;
                //btnClone.Enabled = false;
                btnExe.Enabled = false;
                btnExportExcel.Enabled = false;
                rdnKS.Checked = false;
                rdnLoiTrangSo.Checked = false;
                rtbSQL.Text = "";
                datagrid.Visible = false;
            }
            xuLyLenh();
        }

        private void txtNdk_DropDown(object sender, EventArgs e)
        {
            conn.Open();
            string strCmd = "SELECT * FROM HT_NOIDANGKY WHERE TenNoiDangKy LIKE N'%Quận 10%' ORDER BY TenNoiDangKy";
            SqlCommand cmd = new SqlCommand(strCmd, conn);
            SqlDataAdapter da = new SqlDataAdapter(strCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            conn.Close();
            txtNdk.DisplayMember = "TenNoiDangKy";
            txtNdk.ValueMember = "MaNoiDangKy";
            txtNdk.DataSource = ds.Tables[0];
            //txtNdk.Text = "";
            //txtNdk.SelectedIndex = -1;
        }

        private void xuLyLoai()
        {
            try
            {
                if (rdnKS.Checked)
                {
                    hoten = "NKSHOTEN";
                    table = "HT_KHAISINH";
                    ngaySinh = "OR LEN(NKSNGAYSINH) NOT IN('', 4, 10)  " +
                                    "OR (LEN(MENGAYSINH) NOT IN('', 4, 10) AND CHARINDEX('T', LOWER(MENGAYSINH), 0) = 0)  " +
                                    "OR (LEN(CHANGAYSINH) NOT IN('', 4, 10) AND CHARINDEX('T', LOWER(CHANGAYSINH), 0) = 0) ";
                }
                else if (rdnKT.Checked)
                {
                    hoten = "NKTHOTEN";
                    table = "HT_KHAITU";
                    ngaySinh = "or (len(nktNgaySinh) not in ('',4,10) and CHARINDEX('t',lower(nktNgaySinh),0)=0) " +
                            "or(len(nktNgayChet) not in ('', 4, 10) and CHARINDEX('t', lower(nktNgayChet), 0) = 0)";
                }
                else if (rdnKH.Checked)
                {
                    hoten = "CHONGHOTEN , VOHOTEN";
                    table = "HT_KETHON";
                    ngaySinh = "or (len(chongNgaySinh) not in ('',4,10) and CHARINDEX('t',lower(chongNgaySinh),0)=0) " +
                            "or(len(voNgaySinh) not in ('', 4, 10) and CHARINDEX('t', lower(voNgaySinh), 0) = 0)";
                }
                else
                {
                    hoten = "CMHOTEN";
                    table = "HT_NHANCHAMECON";
                    ngaySinh = "or (len(cmNgaySinh) not in ('',4,10) and CHARINDEX('t',lower(cmNgaySinh),0)=0)" +
                            " or(len(ncNgaySinh) not in ('', 4, 10) and CHARINDEX('t', lower(ncNgaySinh), 0) = 0)";
                }

                rtbSQL.Text = strCommandSql;
                rdnLoiTrangSo.Checked = false;
                rdnTrung.Checked = false;
                rdnId7.Checked = false;
                rdnFormat.Checked = false;
                rdnOther.Checked = false;
                rdnLoiTrangSo.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void xuLyLenh()
        {
            if (rdnLoiTrangSo.Checked)
            {
                strCommandSql = dbName + "SELECT SO, QUYENSO, TENNOIDANGKY, " + hoten + ", TRANGSO, TINHTRANGID, TENFILESAUUPLOAD FROM " + table +
                    " KT JOIN HT_NOIDANGKY NDK ON KT.NOIDANGKY = NDK.MANOIDANGKY WHERE ISNUMERIC(TRANGSO) != 1 " +
                    "AND TRANGSO IS NOT NULL AND TRANGSO !='' AND QUYENSO LIKE '%" + txtYear.Text.Trim() + "%' AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%'";

            }
            else if (rdnTrung.Checked)
            {
                strCommandSql = dbName + "SELECT SO , QUYENSO, TENNOIDANGKY, COUNT(*) AS 'SL TRUNG' FROM " + table + " KT JOIN HT_NOIDANGKY NDK ON KT.NOIDANGKY = NDK.MANOIDANGKY " +
                    "WHERE(QUYENSO LIKE '%" + txtYear.Text.Trim() + "%') AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%' GROUP BY TENNOIDANGKY,QUYENSO,SO HAVING COUNT(*) >= 2 ORDER BY TENNOIDANGKY, QUYENSO";
            }
            else if (rdnId7.Checked)
            {
                strCommandSql = dbName + "SELECT SO, QUYENSO , TENNOIDANGKY, TRANGSO, " +
                            hoten + ", TINHTRANGID, TENFILESAUUPLOAD" +
                            " FROM " + table + " KT JOIN HT_NOIDANGKY NDK ON KT.NOIDANGKY = NDK.MANOIDANGKY " +
                            "WHERE QUYENSO LIKE '%" + txtYear.Text.Trim() + "%' AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%'" +
                            " AND(TINHTRANGID != 7 OR TINHTRANGID IS NULL) " +
                            "ORDER BY NOIDANGKY, QUYENSO, SO";
            }
            else if (rdnFormat.Checked)
            {
                strCommandSql = dbName + "SELECT SO, QUYENSO, TENNOIDANGKY, " + hoten +
                            " , TENFILESAUUPLOAD FROM " + table + " KS JOIN HT_NOIDANGKY NDK ON KS.NOIDANGKY = NDK.MANOIDANGKY " +
                            "WHERE(SO = ''  OR  NGAYDANGKY = '' OR CHARINDEX('/', SO, 0) = 0 " +
                            "OR CHARINDEX('/', QUYENSO, 0) = 0  OR CHARINDEX('.', NGAYDANGKY, 0) = 0  " +
                            "OR LEN(NGAYDANGKY) <> 10  " + ngaySinh +
                            "OR RIGHT(SO, 4) <> RIGHT(NGAYDANGKY, 4)   OR (ISNUMERIC(TRANGSO) != 1 AND TRANGSO IS NOT NULL AND TRANGSO !=''))  " +
                            "AND TINHTRANGID IN(7)  AND (QUYENSO LIKE '%" + txtYear.Text.Trim() + "%') " +
                            "AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%'" +
                            "ORDER BY NOIDANGKY, QUYENSO; ";
            }
            else if (rdnBM.Checked)
            {
                strCommandSql = dbName + "update " + table + " " +
                    "set TinhTrangID = 1 " +
                    "where  (ISNUMERIC(TRANGSO) = 1 or TRANGSO IS NULL or TRANGSO ='') AND " +
                    "QUYENSO LIKE '%" + txtYear.Text.Trim() + "%' AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%'; \n" +
                    "update xl set TinhTrangID = 1 " +
                    "from HT_KHAISINH ks join HT_XULY xl " +
                    "on ks.ID = xl.ObjectID" +
                    " where (ISNUMERIC(TRANGSO) = 1 or TRANGSO IS NULL or TRANGSO ='') AND " +
                    " QUYENSO LIKE '%" + txtYear.Text.Trim() + "%' AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%'; \n" +
                    "select so, quyenSo, " + hoten + ", noiDangKy, TinhTrangID from " + table + " " +
                    "where QUYENSO LIKE '%" + txtYear.Text.Trim() + "%' AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%';  ";
            }
            else if (rdnKTBM1.Checked)
            {
                strCommandSql = dbName + "update " + table + " " +
                    "set TinhTrangID = 5 " +
                    "where  (ISNUMERIC(TRANGSO) = 1 or TRANGSO IS NULL or TRANGSO ='') AND " +
                    "QUYENSO LIKE '%" + txtYear.Text.Trim() + "%' AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%'; \n" +
                    "update xl set TinhTrangID = 5 " +
                    "from HT_KHAISINH ks join HT_XULY xl " +
                    "on ks.ID = xl.ObjectID" +
                    " where  (ISNUMERIC(TRANGSO) = 1 or TRANGSO IS NULL or TRANGSO ='') AND " +
                    "QUYENSO LIKE '%" + txtYear.Text.Trim() + "%' AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%'; \n" +
                    "select so, quyenSo, " + hoten + ", noiDangKy, TinhTrangID from " + table + " " +
                    "where QUYENSO LIKE '%" + txtYear.Text.Trim() + "%' AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%';  ";
            }
            else if (rdnKetThuc.Checked)
            {
                strCommandSql = dbName + "update " + table + " " +
                    "set TinhTrangID = 7 " +
                    "where  (ISNUMERIC(TRANGSO) = 1 or TRANGSO IS NULL or TRANGSO ='') AND " +
                    "QUYENSO LIKE '%" + txtYear.Text.Trim() + "%' AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%'; \n" +
                    "update xl set TinhTrangID = 7 " +
                    "from HT_KHAISINH ks join HT_XULY xl " +
                    "on ks.ID = xl.ObjectID" +
                    " where  (ISNUMERIC(TRANGSO) = 1 or TRANGSO IS NULL or TRANGSO ='') AND " +
                    "QUYENSO LIKE '%" + txtYear.Text.Trim() + "%' AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%'; \n" +
                    "select so, quyenSo, " + hoten + ", noiDangKy, TinhTrangID from " + table + " " +
                    "where QUYENSO LIKE '%" + txtYear.Text.Trim() + "%' AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%';  ";
            }
            else if (rdnOther.Checked) rtbSQL.Enabled = true;
            if (!rdnOther.Checked) rtbSQL.Enabled = false;

            rtbSQL.Text = strCommandSql;
        }

        private void rdnBM_CheckedChanged(object sender, EventArgs e)
        {
            xuLyLenh();
        }

        private void rdnKTBM1_CheckedChanged(object sender, EventArgs e)
        {
            xuLyLenh();
        }

        private void rdnKetThuc_CheckedChanged(object sender, EventArgs e)
        {
            xuLyLenh();
        }

        private void lbKS_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void btnGetSources_Click(object sender, EventArgs e)
        {
            GetSources getSources = new GetSources();
            getSources.getSources();
        }
    }
}
