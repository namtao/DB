using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Office.Interop;

namespace DBInteractive
{
    public partial class Home : Form
    {
        public string database = "";
        public static string sqlConnect;
        public static Home form1;
        public static string dbName= "USE HoTich;\n";
        string hoten = null;
        string ngaySinh = null;
        string strCommandSql = null;
        string exe = null;
        string table = null;

        public Home()
        {
            InitializeComponent();
            form1 = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(sqlConnect);
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

        public void Export(DataTable dt, string sheetName, string title)
        {

            //Tạo các đối tượng Excel

            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel.Workbooks oBooks;

            Microsoft.Office.Interop.Excel.Sheets oSheets;

            Microsoft.Office.Interop.Excel.Workbook oBook;

            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            //Tạo mới một Excel WorkBook 

            oExcel.Visible = true;

            oExcel.DisplayAlerts = false;

            oExcel.Application.SheetsInNewWorkbook = 1;

            oBooks = oExcel.Workbooks;

            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));

            oSheets = oBook.Worksheets;

            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

            oSheet.Name = sheetName;

            // Tạo tiêu đề cột 
/*
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");

            cl1.Value2 = "Số";

            cl1.ColumnWidth = 13.5;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

            cl2.Value2 = "Quyển số";

            cl2.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");

            cl3.Value2 = "Nơi đăng ký";

            cl3.ColumnWidth = 40.0;*/

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "C3");

            //rowHead.Font.Bold = true;

            // Kẻ viền

            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Thiết lập màu nền

            //rowHead.Interior.ColorIndex = 15;

            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo mảng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,

            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.

            object[,] arr = new object[dt.Rows.Count, dt.Columns.Count];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng

            for (int r = 0; r < dt.Rows.Count; r++)

            {

                DataRow dr = dt.Rows[r];

                for (int c = 0; c < dt.Columns.Count; c++)

                {
                    arr[r, c] = dr[c];
                }
            }

            //Thiết lập vùng điền dữ liệu

            int rowStart = 3;

            int columnStart = 1;

            int rowEnd = rowStart + dt.Rows.Count - 1;

            int columnEnd = dt.Columns.Count;


            // Tạo phần đầu nếu muốn

            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range((Microsoft.Office.Interop.Excel.Range)oSheet.Cells[1, columnStart], (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[1, columnEnd]);

            head.MergeCells = true;

            head.Value2 = title;

            head.Font.Bold = true;

            head.Font.Name = "Tahoma";

            head.Font.Size = "15";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Ô bắt đầu điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

            // Ô kết thúc điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

            // Lấy về vùng điền dữ liệu

            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            //định dạng text
            range.NumberFormat = "@";

            //auto witdh

            //Điền dữ liệu vào vùng đã thiết lập

            range.Value2 = arr;

            // Kẻ viền

            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Căn giữa cột STT

            Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];

            Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);

            oSheet.get_Range(c3, c4).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            range.Columns.AutoFit();
        }
    
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            // Lấy về nguồn dữ liệu cần Export là 1 DataTable
            // DataTable này mỗi bạn lấy mỗi khác. 
            // Ở đây tôi dùng BindingSouce có tên bs nên tôi ép kiểu như sau:
            // Bạn nào gán trực tiếp vào DataGridView thì ép kiểu DataSource của
            // DataGridView nhé 
            DataTable dt = (DataTable)datagrid.DataSource;
            Export(dt, "Kiểm tra", "Kiểm tra trước khi up");
        }

        private void rdnLoiTrangSo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdnLoiTrangSo.Checked)
            {
                strCommandSql = dbName + "SELECT SO, QUYENSO, TENNOIDANGKY, " + hoten + ", TRANGSO, TINHTRANGID, TENFILESAUUPLOAD FROM " + table +
                    " KT JOIN HT_NOIDANGKY NDK ON KT.NOIDANGKY = NDK.MANOIDANGKY WHERE ISNUMERIC(TRANGSO) != 1 AND TRANGSO IS NOT NULL AND TRANGSO !='' AND QUYENSO LIKE '%" + txtYear.Text.Trim() + "%'";

            }

            rtbSQL.Text = strCommandSql;
        }

        private void rdnTrung_CheckedChanged(object sender, EventArgs e)
        {
            if (rdnTrung.Checked)
            {
                strCommandSql = dbName + "SELECT SO , QUYENSO, TENNOIDANGKY, COUNT(*) AS 'SL TRUNG' FROM " + table + " KT JOIN HT_NOIDANGKY NDK ON KT.NOIDANGKY = NDK.MANOIDANGKY " +
                    "WHERE(QUYENSO LIKE '%" + txtYear.Text.Trim() + "%') GROUP BY TENNOIDANGKY,QUYENSO,SO HAVING COUNT(*) >= 2 ORDER BY TENNOIDANGKY, QUYENSO";
            }

            rtbSQL.Text = strCommandSql;
        }

        private void rdnId7_CheckedChanged(object sender, EventArgs e)
        {
            if (rdnId7.Checked)
            {
                strCommandSql = dbName + "SELECT SO, QUYENSO , TENNOIDANGKY, TRANGSO, " +
                            hoten + ", TINHTRANGID, TENFILESAUUPLOAD" +
                            " FROM " + table + " KT JOIN HT_NOIDANGKY NDK ON KT.NOIDANGKY = NDK.MANOIDANGKY WHERE QUYENSO LIKE '%" + txtYear.Text.Trim() + "%' " +
                            " AND(TINHTRANGID != 7 OR TINHTRANGID IS NULL) " +
                            "ORDER BY NOIDANGKY, QUYENSO, SO";
            }

            rtbSQL.Text = strCommandSql;
        }

        private void rdnFormat_CheckedChanged(object sender, EventArgs e)
        {
            if (rdnFormat.Checked)
            {
                strCommandSql = dbName + "SELECT SO, QUYENSO, TENNOIDANGKY, " + hoten +
                            " , TENFILESAUUPLOAD FROM " + table + " KS JOIN HT_NOIDANGKY NDK ON KS.NOIDANGKY = NDK.MANOIDANGKY " +
                            "WHERE(SO = ''  OR  NGAYDANGKY = '' OR CHARINDEX('/', SO, 0) = 0 " +
                            "OR CHARINDEX('/', QUYENSO, 0) = 0  OR CHARINDEX('.', NGAYDANGKY, 0) = 0  " +
                            "OR LEN(NGAYDANGKY) <> 10  " + ngaySinh +
                            "OR RIGHT(SO, 4) <> RIGHT(NGAYDANGKY, 4)   OR (ISNUMERIC(TRANGSO) != 1 AND TRANGSO IS NOT NULL AND TRANGSO !=''))  " +
                            "AND TINHTRANGID IN(7)  AND (QUYENSO LIKE '%" + txtYear.Text.Trim() + "%') " +
                            "ORDER BY NOIDANGKY, QUYENSO; ";
            }

            rtbSQL.Text = strCommandSql;
        }

        private void rdnOther_CheckedChanged(object sender, EventArgs e)
        {
            rtbSQL.Text = strCommandSql;
            rtbSQL.Enabled = true;
        }

        private void rdnChuanHoa_CheckedChanged(object sender, EventArgs e)
        {
            strCommandSql = exe;
        }

        private void rdnKS_CheckedChanged(object sender, EventArgs e)
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
                    if (Int32.Parse(txtYear.Text) <= 1975)
                        exe = dbName + "exec kstruoc1975 '" + txtYear.Text.Trim() + "', '" + txtNdk.Text.Trim() + "'";
                    else exe = dbName + "exec ks20102015 '" + txtYear.Text.Trim() + "', '" + txtNdk.Text.Trim() + "'";
                }

                rdnLoiTrangSo.Checked = false;
                rdnTrung.Checked = false;
                rdnId7.Checked = false;
                rdnFormat.Checked = false;
                rdnChuanHoa.Checked = false;
                rdnOther.Checked = false;
                rdnLoiTrangSo.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rdnKT_CheckedChanged(object sender, EventArgs e)
        {
            if (rdnKT.Checked)
            {
                hoten = "NKTHOTEN";
                table = "HT_KHAITU";
                ngaySinh = "or (len(nktNgaySinh) not in ('',4,10) and CHARINDEX('t',lower(nktNgaySinh),0)=0) " +
                        "or(len(nktNgayChet) not in ('', 4, 10) and CHARINDEX('t', lower(nktNgayChet), 0) = 0)";
                if (Int32.Parse(txtYear.Text) <= 1975)
                    exe = dbName + "exec kttruoc1975 '" + txtYear.Text.Trim() + "', '" + txtNdk.Text.Trim() + "'";
                else exe = dbName + "exec kt20102015 '" + txtYear.Text.Trim() + "', '" + txtNdk.Text.Trim() + "'";
                rtbSQL.Text = strCommandSql;
                rdnLoiTrangSo.Checked = false;
                rdnTrung.Checked = false;
                rdnId7.Checked = false;
                rdnFormat.Checked = false;
                rdnChuanHoa.Checked = false;
                rdnOther.Checked = false;
                rdnLoiTrangSo.Checked = true;
            }
        }

        private void rdnKH_CheckedChanged(object sender, EventArgs e)
        {
            if (rdnKH.Checked)
            {
                hoten = "CHONGHOTEN , VOHOTEN";
                table = "HT_KETHON";
                ngaySinh = "or (len(chongNgaySinh) not in ('',4,10) and CHARINDEX('t',lower(chongNgaySinh),0)=0) " +
                        "or(len(voNgaySinh) not in ('', 4, 10) and CHARINDEX('t', lower(voNgaySinh), 0) = 0)";
                if (Int32.Parse(txtYear.Text) <= 1975)
                    exe = dbName + "exec khtruoc1975 '" + txtYear.Text.Trim() + "', '" + txtNdk.Text.Trim() + "'";
                else exe = dbName + "exec kh20102015 '" + txtYear.Text.Trim() + "', '" + txtNdk.Text.Trim() + "'";
                rtbSQL.Text = strCommandSql;
                rdnLoiTrangSo.Checked = false;
                rdnTrung.Checked = false;
                rdnId7.Checked = false;
                rdnFormat.Checked = false;
                rdnChuanHoa.Checked = false;
                rdnOther.Checked = false;
                rdnLoiTrangSo.Checked = true;
            }
        }

        private void rdnCMC_CheckedChanged(object sender, EventArgs e)
        {
            if(rdnCMC.Checked){
                hoten = "CMHOTEN";
                table = "HT_NHANCHAMECON";
                ngaySinh = "or (len(cmNgaySinh) not in ('',4,10) and CHARINDEX('t',lower(cmNgaySinh),0)=0)" +
                        " or(len(ncNgaySinh) not in ('', 4, 10) and CHARINDEX('t', lower(ncNgaySinh), 0) = 0)";
                if (Int32.Parse(txtYear.Text) <= 1975)
                    exe = dbName + "exec cmctruoc1975 '" + txtYear.Text.Trim() + "', '" + txtNdk.Text.Trim() + "'";
                else exe = dbName + "exec cmc20102015 '" + txtYear.Text.Trim() + "', '" + txtNdk.Text.Trim() + "'";
                rtbSQL.Text = strCommandSql;
                rdnLoiTrangSo.Checked = false;
                rdnTrung.Checked = false;
                rdnId7.Checked = false;
                rdnFormat.Checked = false;
                rdnChuanHoa.Checked = false;
                rdnOther.Checked = false;
                rdnLoiTrangSo.Checked = true;
            }
        }

        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            if (txtYear.Text != "" && IsNumber(txtYear.Text))
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                //txtNdk.Enabled = true;
                //rtbSQL.Enabled = true;
                btnClone.Enabled = true;
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
                txtNdk.Enabled = false;
                rtbSQL.Enabled = false;
                btnClone.Enabled = false;
                btnExe.Enabled = false;
                btnExportExcel.Enabled = false;
                rdnKS.Checked = false;
                rdnLoiTrangSo.Checked = false;
                rtbSQL.Text = "";
                datagrid.Visible = true;
            }
        }

        private void txtNdk_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
