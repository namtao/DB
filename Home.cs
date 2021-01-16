using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

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
        int ksDuoi16 = 0, ksTren16 = 0;
        int ktDuoi16 = 0, ktTren16 = 0;
        int khDuoi16 = 0, khTren16 = 0;
        int cmcDuoi16 = 0, cmcTren16 = 0;
        Thread threadKS, threadKT, threadKH, threadCMC;

        public Home()
        {
            InitializeComponent();
            form1 = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //thread khai sinh
            threadKS = new Thread(() =>
            {

                //Khai sinh
                using (SqlConnection con = new SqlConnection(sqlConnect))
                {
                    string sql = "SELECT so, quyenSo, trangSo, ngayDangKy, TenLoaiDangKy, " +
                        "TenNoiDangKy, nksHoTen, TenGioiTinh, nksNgaySinh, dt.TenDanToc, qt.TenQuocTich, " +
                        "meHoTen, meNgaySinh, dtm.TenDanToc, qtm.TenQuocTich, lctm.TenLoaiCuTru, chaHoTen, " +
                        "chaNgaySinh, dtc.TenDanToc, qtc.TenQuocTich, lctc.TenLoaiCuTru, GhiChu, nksNoiSinh, " +
                        "meNoiCuTru, chaNoiCuTru, nycHoTen, nycQuanHe, nguoiKy, chucVuNguoiKy, NguoiThucHien, " +
                        "lgt.TenLoaiGiayTo, nsdvhc.ten, nksQueQuan, lgtnk.TenLoaiGiayTo, nycSoGiayToTuyThan, " +
                        "nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan, nksNgaySinhBangChu FROM HT_KHAISINH " +
                        "ks left join  HT_KS_LOAIDANGKY ldk on ks.loaiDangKy = ldk.MaLoaiDangKy " +
                        "left join  DM_GIOITINH gt on  ks.nksGioiTinh = gt.MaGioiTinh " +
                        "left join  DM_DANTOC dt on ks.nksDanToc = dt.MaDanToc " +
                        "left join  DM_DANTOC dtm on ks.meDanToc = dtm.MaDanToc " +
                        "left join  DM_DANTOC dtc on ks.chaDanToc = dtc.MaDanToc " +
                        "left join  DM_QUOCTICH qt on ks.nksQuocTich = qt.MaQuocTich " +
                        "left join  DM_QUOCTICH qtm on ks.meQuocTich = qtm.MaQuocTich " +
                        "left join  DM_QUOCTICH qtc on ks.chaQuocTich = qtc.MaQuocTich " +
                        "left join  HT_NOIDANGKY ndk on ks.noiDangKy = ndk.MaNoiDangKy " +
                        "left join  DM_LOAICUTRU lctm on ks.meLoaiCuTru = lctm.MaLoaiCuTru " +
                        "left join  DM_LOAICUTRU lctc on ks.chaLoaiCuTru = lctc.MaLoaiCuTru " +
                        "left join  HT_LOAIGIAYTO lgt on ks.nycLoaiGiayToTuyThan = lgt.MaLoaiGiayTo " +
                        "left join  HT_LOAIGIAYTO lgtnk on ks.nycLoaiGiayToTuyThan = lgtnk.MaLoaiGiayTo " +
                        "left join  HT_Tinh_NoiSinh nsdvhc on ks.nksNoiSinhDVHC = nsdvhc.Ma " +
                        "WHERE quyenSo NOT LIKE '%2016' AND quyenSo NOT LIKE '%2017' AND quyenSo NOT LIKE '%2018' AND quyenSo NOT LIKE '%2019'";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            for (int i = 0; i < sql.Split(new string[] { "FROM" }, StringSplitOptions.None)[0].
                                Split(new string[] { "SELECT" }, StringSplitOptions.None)[1].Trim().Split(',').Length; i++)
                            {

                                if (dr[i].ToString().Trim().Length >= 16)
                                    ksTren16++;
                                else if (dr[i].ToString().Trim().Length > 0 && dr[i] != null && !dr[i].ToString().Trim().Equals(""))
                                    ksDuoi16++;

                            }
                        }
                        MessageBox.Show("Khai sinh xong!", "Thông báo");
                        con.Close();
                    }
                }

            });
            threadKS.Start();

            //thread khai tử
            threadKT = new Thread(() =>
            {
                //thread khai tử
                using (SqlConnection con = new SqlConnection(sqlConnect))
                {
                    string sql = "SELECT So, quyenSo, trangSo, ngayDangKy, TenLoaiDangKy, TenNoiDangKy, nktHoTen,  TenGioiTinh, " +
                        "nktNgaySinh, dt.TenDanToc, qt.TenQuocTich, TenLoaiCuTru, lgt.TenLoaiGiayTo,  nktSoGiayToTuyThan, " +
                        "nktNgayChet, GhiChu, nktGioPhutChet, nktNoiChet, nktNguyenNhanChet,  nktNoiCuTru, nycHoTen, nycQuanHe, " +
                        "nguoiKy, chucVuNguoiKy, nguoiThucHien,  nktNgayCapGiayToTuyThan, nktNoiCapGiayToTuyThan, gbt.TenLoai, " +
                        "gbtSo, gbtNgay,  gbtCoQuanCap, lgtnk.TenLoaiGiayTo, nycSoGiayToTuyThan, nycNgayCapGiayToTuyThan, " +
                        "nycNoiCapGiayToTuyThan FROM HT_KHAITU kt  left join HT_KT_LOAIDANGKY ldk on kt.loaiDangKy = ldk.MaLoaiDangKy " +
                        "left join HT_NOIDANGKY ndk on kt.noiDangKy = ndk.MaNoiDangKy " +
                        "left join DM_GIOITINH gt on kt.nktGioiTinh = gt.MaGioiTinh " +
                        "left join DM_DANTOC dt on kt.nktDanToc = dt.MaDanToc " +
                        "left join DM_QUOCTICH qt on kt.nktQuocTich = qt.MaQuocTich " +
                        "left join DM_LOAICUTRU lct on kt.nktLoaiCuTru = lct.MaLoaiCuTru " +
                        "left join HT_LOAIGIAYTO lgt on kt.nktLoaiGiayToTuyThan = lgt.MaLoaiGiayTo " +
                        "left join HT_KT_LOAI_GIAY_BAO_TU gbt on kt.gbtLoai = gbt.MaLoai " +
                        "left join HT_LOAIGIAYTO lgtnk on kt.nktLoaiGiayToTuyThan = lgtnk.MaLoaiGiayTo " +
                        "WHERE quyenSo NOT LIKE '%2016' AND quyenSo NOT LIKE '%2017' AND quyenSo NOT LIKE '%2018' AND quyenSo NOT LIKE '%2019'";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            for (int i = 0; i < sql.Split(new string[] { "FROM" }, StringSplitOptions.None)[0].
                                Split(new string[] { "SELECT" }, StringSplitOptions.None)[1].Trim().Split(',').Length; i++)
                            {

                                if (dr[i].ToString().Trim().Length >= 16)
                                    ktTren16++;
                                else if (dr[i].ToString().Trim().Length > 0 && dr[i] != null && !dr[i].ToString().Trim().Equals(""))
                                    ktDuoi16++;

                            }
                        }

                        MessageBox.Show("Khai tử xong!", "Thông báo");
                        con.Close();
                    }
                }
            });
            threadKT.Start();

            //thread kết hôn
            threadKH = new Thread(() =>
            {
                using (SqlConnection con = new SqlConnection(sqlConnect))
                {
                    string sql = "SELECT So, quyenSo, trangSo, ngayDangKy, TenLoaiDangKy, TenNoiDangKy, chongHoTen,  " +
                        "chongNgaySinh, dtc.TenDanToc, qtc.TenQuocTich, lctc.TenLoaiCuTru, lgtc.TenLoaiGiayTo, " +
                        " chongSoGiayToTuyThan, voHoTen, voNgaySinh, dtv.TenDanToc, qtv.TenQuocTich, lctv.TenLoaiCuTru,  " +
                        "lgtv.TenLoaiGiayTo, voSoGiayToTuyThan, GhiChu, chongNoiCuTru, voNoiCuTru, nguoiKy,  chucVuNguoiKy, " +
                        "nguoiThucHien, chongNgayCapGiayToTuyThan, chongNoiCapGiayToTuyThan,  voNgayCapGiayToTuyThan, voNoiCapGiayToTuyThan " +
                        "FROM HT_KETHON kh left join HT_KH_LOAIDANGKY ldk on kh.loaiDangKy = ldk.MaLoaiDangKy " +
                        "left join HT_NOIDANGKY ndk on kh.noiDangKy = ndk.MaNoiDangKy " +
                        "left join DM_DANTOC dtc on kh.chongDanToc = dtc.MaDanToc " +
                        "left join DM_QUOCTICH qtc on kh.chongQuocTich = qtc.MaQuocTich " +
                        "left join DM_LOAICUTRU lctc on kh.chongLoaiCuTru = lctc.MaLoaiCuTru " +
                        "left join HT_LOAIGIAYTO lgtc on kh.chongLoaiGiayToTuyThan = lgtc.MaLoaiGiayTo " +
                        "left join DM_DANTOC dtv on kh.voDanToc = dtv.MaDanToc " +
                        "left join DM_QUOCTICH qtv on kh.voQuocTich = qtv.MaQuocTich " +
                        "left join DM_LOAICUTRU lctv on kh.voLoaiCuTru = lctv.MaLoaiCuTru " +
                        "left join HT_LOAIGIAYTO lgtv on kh.voLoaiGiayToTuyThan = lgtv.MaLoaiGiayTo " +
                        "WHERE quyenSo NOT LIKE '%2016' AND quyenSo NOT LIKE '%2017' AND quyenSo NOT LIKE '%2018' AND quyenSo NOT LIKE '%2019'";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            for (int i = 0; i < sql.Split(new string[] { "FROM" }, StringSplitOptions.None)[0].
                                Split(new string[] { "SELECT" }, StringSplitOptions.None)[1].Trim().Split(',').Length; i++)
                            {

                                if (dr[i].ToString().Trim().Length >= 16)
                                    khTren16++;
                                else if (dr[i].ToString().Trim().Length > 0 && dr[i] != null && !dr[i].ToString().Trim().Equals(""))
                                    khDuoi16++;

                            }
                        }

                        MessageBox.Show("Kết hôn xong!", "Thông báo");
                        con.Close();
                    }
                }
            });
            threadKH.Start();

            //thread cha mẹ con
            threadCMC = new Thread(() =>
            {
                using (SqlConnection con = new SqlConnection(sqlConnect))
                {
                    string sql = "SELECT So, quyenSo, trangSo, quyetDinhSo, ngayDangKy, TenLoaiDangKy, " +
                        "TenLoaiXacNhan,  TenNoiDangKy, cmHoTen, cmNgaySinh, dtcm.TenDanToc, qtcm.TenQuocTich, " +
                        "lctcm.TenLoaiCuTru, lgtcm.TenLoaiGiayTo,  cmSoGiayToTuyThan, ncHoTen, ncNgaySinh, " +
                        "dtnc.TenDanToc, qtnc.TenQuocTich, lctnc.TenLoaiCuTru, lgtnc.TenLoaiGiayTo,  " +
                        "ncSoGiayToTuyThan, GhiChu, cmNoiCuTru, ncNoiCuTru, nycHoTen, nycQHNguoiDuocNhan,  " +
                        "nguoiKy, chucVuNguoiKy, nguoiThucHien, cmQueQuan, cmNgayCapGiayToTuyThan,  " +
                        "cmNoiCapGiayToTuyThan, ncQueQuan, ncNgayCapGiayToTuyThan, ncNoiCapGiayToTuyThan,  " +
                        "lgtnk.TenLoaiGiayTo, nycSoGiayToTuyThan, nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan " +
                        "FROM HT_NHANCHAMECON cmc left join HT_NCM_LOAIDANGKY ldk on cmc.loaiDangKy = ldk.MaLoaiDangKy " +
                        "left join DM_LOAIXACNHAN lxn on cmc.loaiXacNhan = lxn.MaLoaiXacNhan " +
                        "left join HT_NOIDANGKY ndk on cmc.noiDangKy = ndk.MaNoiDangKy " +
                        "left join DM_DANTOC dtcm on cmc.cmDanToc = dtcm.MaDanToc " +
                        "left join DM_QUOCTICH qtcm on cmc.cmQuocTich = qtcm.MaQuocTich " +
                        "left join DM_LOAICUTRU lctcm on cmc.cmLoaiCuTru = lctcm.MaLoaiCuTru " +
                        "left join HT_LOAIGIAYTO lgtcm on cmc.cmLoaiGiayToTuyThan = lgtcm.MaLoaiGiayTo " +
                        "left join DM_DANTOC dtnc on cmc.ncDanToc = dtnc.MaDanToc " +
                        "left join DM_QUOCTICH qtnc on cmc.ncQuocTich = qtnc.MaQuocTich " +
                        "left join DM_LOAICUTRU lctnc on cmc.ncLoaiCuTru = lctnc.MaLoaiCuTru " +
                        "left join HT_LOAIGIAYTO lgtnc on cmc.ncLoaiGiayToTuyThan = lgtnc.MaLoaiGiayTo " +
                        "left join HT_LOAIGIAYTO lgtnk on cmc.nycLoaiGiayToTuyThan = lgtnk.MaLoaiGiayTo " +
                        "WHERE quyenSo NOT LIKE '%2016' AND quyenSo NOT LIKE '%2017' AND quyenSo NOT LIKE '%2018' AND quyenSo NOT LIKE '%2019'";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            for (int i = 0; i < sql.Split(new string[] { "FROM" }, StringSplitOptions.None)[0].
                                Split(new string[] { "SELECT" }, StringSplitOptions.None)[1].Trim().Split(',').Length; i++)
                            {

                                if (dr[i].ToString().Trim().Length >= 16)
                                    cmcTren16++;
                                else if (dr[i].ToString().Trim().Length > 0 && dr[i] != null && !dr[i].ToString().Trim().Equals(""))
                                    cmcDuoi16++;

                            }
                        }
                        MessageBox.Show("Cha mẹ con xong!", "Thông báo");
                        con.Close();
                    }
                }
            });
            threadCMC.Start();


            try
            {
                conn = new SqlConnection(sqlConnect);
                conn.Open();
                lbKS.Text = "Khai sinh: " + new SqlCommand(dbName + "SELECT COUNT(*) FROM HT_KHAISINH", conn).ExecuteScalar().ToString();
                lbKT.Text = "Khai Tử: " + new SqlCommand(dbName + "SELECT COUNT(*) FROM HT_KHAITU", conn).ExecuteScalar().ToString();
                lbKH.Text = "Kết hôn: " + new SqlCommand(dbName + "SELECT COUNT(*) FROM HT_KETHON", conn).ExecuteScalar().ToString();
                lbCMC.Text = "Nhận cha mẹ con: " + new SqlCommand(dbName + "SELECT COUNT(*) FROM HT_NHANCHAMECON", conn).ExecuteScalar().ToString();
                //lb1Ngay.Text = "Số lượng/ngày: " + new SqlCommand("SELECT COUNT(DISTINCT OBJECTID) FROM HT_XULY " +
                //"WHERE CONVERT(DATE, NGAYXULY, 103) = CONVERT(DATE, GETDATE(), 103)", conn).ExecuteScalar().ToString();
                lbTong.Text = "Tổng: " + (Convert.ToInt32(new SqlCommand(dbName + "SELECT COUNT(*) FROM HT_KHAISINH", conn).ExecuteScalar()) +
                    Convert.ToInt32(new SqlCommand(dbName + "SELECT COUNT(*) FROM HT_KHAITU", conn).ExecuteScalar()) +
                    Convert.ToInt32(new SqlCommand(dbName + "SELECT COUNT(*) FROM HT_KETHON", conn).ExecuteScalar()) +
                    Convert.ToInt32(new SqlCommand(dbName + "SELECT COUNT(*) FROM HT_NHANCHAMECON", conn).ExecuteScalar())).ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void fillDgv(string sqlQuery)
        {
            SqlConnection conn = new SqlConnection(sqlConnect);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
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
            Utils.Export(dt, datagrid, "Kiểm tra", "Kiểm tra trước khi up");
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

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (threadCMC.ThreadState == ThreadState.Stopped &&
                threadKS.ThreadState == ThreadState.Stopped &&
                threadKT.ThreadState == ThreadState.Stopped &&
                threadKH.ThreadState == ThreadState.Stopped)
            {
                //gán dữ liệu vào datagridview
                datagrid.Enabled = true;
                datagrid.Visible = true;
                //btnExportExcel.Enabled = true;

                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn(" ", typeof(string)));
                dt.Columns.Add(new DataColumn("Khai sinh", typeof(int)));
                dt.Columns.Add(new DataColumn("Khai tử", typeof(int)));
                dt.Columns.Add(new DataColumn("Kết hôn", typeof(int)));
                dt.Columns.Add(new DataColumn("Cha mẹ con", typeof(int)));
                dt.Columns.Add(new DataColumn("Tổng", typeof(int)));

                //Thêm dữ liệu
                dt.Rows.Add("Dưới 16 ký tự", ksDuoi16, ktDuoi16, ksDuoi16, cmcDuoi16, ksDuoi16 + ktDuoi16 + khDuoi16 + cmcDuoi16);
                dt.Rows.Add("Trên 16 ký tự", ksTren16, ktTren16, khTren16, cmcTren16, ksTren16 + ktTren16 + khTren16 + cmcTren16);
                dt.Rows.Add("Tổng số trường", ksTren16 + ksDuoi16, ktDuoi16 + ktTren16, khTren16 + khDuoi16, cmcDuoi16 + cmcTren16,
                    ksDuoi16 + ktDuoi16 + khDuoi16 + cmcDuoi16 + ksTren16 + ktTren16 + khTren16 + cmcTren16);

                conn = new SqlConnection(sqlConnect);
                conn.Open();
                dt.Rows.Add("Số bản ghi", new SqlCommand(dbName + "SELECT COUNT(*) FROM HT_KHAISINH", conn).ExecuteScalar(),
                    new SqlCommand(dbName + "SELECT COUNT(*) FROM HT_KHAITU", conn).ExecuteScalar(),
                    new SqlCommand(dbName + "SELECT COUNT(*) FROM HT_KETHON", conn).ExecuteScalar(),
                    new SqlCommand(dbName + "SELECT COUNT(*) FROM HT_NHANCHAMECON", conn).ExecuteScalar(),
                    (Convert.ToInt32(new SqlCommand(dbName + "SELECT COUNT(*) FROM HT_KHAISINH", conn).ExecuteScalar()) +
                        Convert.ToInt32(new SqlCommand(dbName + "SELECT COUNT(*) FROM HT_KHAITU", conn).ExecuteScalar()) +
                        Convert.ToInt32(new SqlCommand(dbName + "SELECT COUNT(*) FROM HT_KETHON", conn).ExecuteScalar()) +
                        Convert.ToInt32(new SqlCommand(dbName + "SELECT COUNT(*) FROM HT_NHANCHAMECON", conn).ExecuteScalar())));
                conn.Close();
                datagrid.DataSource = dt;
                //export excel
                Utils.Export(dt, datagrid, "Thống kê dữ liệu", "Thống kê trường thông tin");
            }
            else MessageBox.Show("Xin chờ trong giây lát!!!", "Thông báo");
        }
    }
}
