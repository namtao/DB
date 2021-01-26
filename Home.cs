using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.Json;
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
        string table = null;
        SqlConnection conn;
        int ksDuoi16 = 0, ksTren16 = 0;
        int ktDuoi16 = 0, ktTren16 = 0;
        int khDuoi16 = 0, khTren16 = 0;
        int cmcDuoi16 = 0, cmcTren16 = 0;
        Thread threadKS, threadKT, threadKH, threadCMC;
        int ag = 0;
        Thread threadAG, threadAG1, threadAG2;
        DataTable dt;

        public void AG()
        {
                //thread An Giang
                threadAG = new Thread(() =>
                {
                    using (SqlConnection con = new SqlConnection(sqlConnect))
                    {
                        string sql = "use UBND_Tp_Long_Xuyen_tinh_An_Giang_1975_2011; " +
                        "SELECT TENDONVIPHATHANH, NGAYLAP, HOSOSO, KYHIEU, TRICHYEU, TOSO, TIEUDE, " +
                        "THOIHANBAOQUAN, THOIGIANBATDAU,  vb.THOIGIANKETTHUC, hs.THOIGIANKETTHUC," +
                        "vb.GHICHU1, vb.GHICHU2, hs.GHICHU1, hs.GHICHU2, SOTO, TENLOAIVANBAN, TENPHONG " +
                        "FROM VANBAN vb " +
                        "left join DONVIPHATHANH dvph on vb.MADONVIPHATHANH = dvph.MADONVIPHATHANH " +
                        "left join HOSO hs on vb.MAHOSO = hs.MAHOSO " +
                        "left join LOAIVANBAN lvb on vb.MALOAIVANBAN = lvb.MALOAIVANBAN " +
                        "left join PHONG p on hs.MAPHONG = p.MAPHONG";
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
                                    if (dr[i].ToString().Trim().Length > 0 && dr[i] != null && !dr[i].ToString().Trim().Equals(""))
                                        ag++;
                                }
                            }
                            MessageBox.Show(ag + "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            con.Close();
                        }
                    }

                });
                threadAG.Start();


                threadAG1 = new Thread(() =>
                {
                    using (SqlConnection con = new SqlConnection(sqlConnect))
                    {
                        string sql = "use ADDJ_AnGiang; " +
                        "select top(178456) METADATA from meta order by METADATA asc";
                        using (SqlCommand cmd = new SqlCommand(sql, con))
                        {
                            cmd.CommandType = CommandType.Text;
                            con.Open();
                            SqlDataReader dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                if (dr[0].ToString().Trim().Length > 0 && dr[0] != null && !dr[0].ToString().Trim().Equals(""))
                                {
                                    string tieuDe = "", trichYeu = "" , kyHieu = "";

                                    JsonDocument doc = JsonDocument.Parse(dr[0].ToString());
                                    JsonElement root = doc.RootElement;
                                    for(int i = 0; i < root.GetArrayLength(); i++)
                                    {
                                        //đếm số trường
                                        var indexName = root[i].GetProperty("indexName").ToString().Trim();
                                        var indexValue = root[i].GetProperty("indexValue").ToString().Trim();
                                        var indexValue2 = root[i].GetProperty("indexValue2").ToString().Trim();
                                        var indexValueQC = root[i].GetProperty("indexValueQC").ToString().Trim();

                                        if((indexValue != null && indexValue != "")
                                            || (indexValue2 != null && indexValue2 != "")
                                            || (indexValueQC != null && indexValueQC != ""))
                                        {
                                            ag++;

                                            //lọc bản ghi
                                            if (indexName.ToString().Trim().Equals("TENHOSO"))
                                            {
                                                if(indexValue!=null && indexValue !="") tieuDe = indexValue.ToString().Trim();
                                                else if(indexValue2 != null && indexValue2 != "") tieuDe = indexValue2.ToString().Trim();
                                                else tieuDe = indexValueQC.ToString().Trim();
                                            }

                                            if (indexName.ToString().Trim().Equals("SOKYHIEU"))
                                            {
                                                if (indexValue != null && indexValue != "") kyHieu = indexValue.ToString().Trim();
                                                else if (indexValue2 != null && indexValue2 != "") kyHieu = indexValue2.ToString().Trim();
                                                else kyHieu = indexValueQC.ToString().Trim();
                                            }

                                            if (indexName.ToString().Trim().Equals("TRICHYEU"))
                                            {
                                                if (indexValue != null && indexValue != "") trichYeu = indexValue.ToString().Trim();
                                                else if (indexValue2 != null && indexValue2 != "") kyHieu = indexValue2.ToString().Trim();
                                                else tieuDe = indexValueQC.ToString().Trim();
                                            }

                                            if (!tieuDe.Equals("") && !kyHieu.Equals("") && !trichYeu.Equals(""))
                                            {
                                                tieuDe = Utils.format(tieuDe);
                                                kyHieu = Utils.format(kyHieu);
                                                trichYeu = Utils.format(trichYeu);

                                                SqlConnection sqlConnection = new SqlConnection(sqlConnect);
                                                sqlConnection.Open();
                                                string sqlQuery = "use  UBND_tinh_An_Giang; " +
                                                "insert into ThongKe " +
                                                "select TENDONVIPHATHANH, NGAYLAP, HOSOSO, KYHIEU, TRICHYEU, " +
                                                "TOSO, TIEUDE, THOIHANBAOQUAN, THOIGIANBATDAU, vb.NGAYKY, " +
                                                "hs.THOIGIANKETTHUC as 'ThoiGianKetThucHS', vb.GHICHU1 as 'GhiChuVB1', vb.GHICHU2 as 'GhiChuVB2', " +
                                                "hs.GHICHU1 as 'GhiChuHS1', hs.GHICHU2 as 'GhiChuHS2', SOTO, TENLOAIVANBAN, TENPHONG, HOPSO " +
                                                "from VANBAN vb left join DONVIPHATHANH dvph on vb.MADONVIPHATHANH = dvph.MADONVIPHATHANH " +
                                                "left join HOSO hs on vb.MAHOSO = hs.MAHOSO left join LOAIVANBAN lvb on vb.MALOAIVANBAN = lvb.MALOAIVANBAN " +
                                                "left join PHONG p on hs.MAPHONG = p.MAPHONG " +
                                                "where TIEUDE like N'%" + tieuDe.Substring(5, tieuDe.Length -5) + "%' and KYHIEU like '%" + kyHieu + "%'";
                                                SqlCommand cmd2 = new SqlCommand(sqlQuery, sqlConnection);
                                                cmd2.ExecuteNonQuery();
                                                sqlConnection.Close();
                                                tieuDe = "";
                                                trichYeu = "";
                                                kyHieu = "";
                                            }
                                        }

                                    }
                                }
                            }
                            //MessageBox.Show("Có " +ag + " trường thông tin"+ "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            con.Close();
                        }
                    }

                });
                threadAG1.Start();

                threadAG2 = new Thread(() =>
                {
                    using (SqlConnection con = new SqlConnection(sqlConnect))
                    {
                        string sql = "use ADDJ_AnGiang; " +
                        "select top(180000) METADATA from meta order by METADATA desc";
                        using (SqlCommand cmd = new SqlCommand(sql, con))
                        {
                            cmd.CommandType = CommandType.Text;
                            con.Open();
                            SqlDataReader dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                if (dr[0].ToString().Trim().Length > 0 && dr[0] != null && !dr[0].ToString().Trim().Equals(""))
                                {
                                    string tieuDe = "", trichYeu = "", kyHieu = "";

                                    JsonDocument doc = JsonDocument.Parse(dr[0].ToString());
                                    JsonElement root = doc.RootElement;
                                    for (int i = 0; i < root.GetArrayLength(); i++)
                                    {
                                        //đếm số trường
                                        var indexName = root[i].GetProperty("indexName").ToString().Trim();
                                        var indexValue = root[i].GetProperty("indexValue").ToString().Trim();
                                        var indexValue2 = root[i].GetProperty("indexValue2").ToString().Trim();
                                        var indexValueQC = root[i].GetProperty("indexValueQC").ToString().Trim();

                                        if ((indexValue != null && indexValue != "")
                                            || (indexValue2 != null && indexValue2 != "")
                                            || (indexValueQC != null && indexValueQC != ""))
                                        {
                                            ag++;

                                            //lọc bản ghi
                                            if (indexName.ToString().Trim().Equals("TENHOSO"))
                                            {
                                                if (indexValue != null && indexValue != "") tieuDe = indexValue.ToString().Trim();
                                                else if (indexValue2 != null && indexValue2 != "") tieuDe = indexValue2.ToString().Trim();
                                                else tieuDe = indexValueQC.ToString().Trim();
                                            }

                                            if (indexName.ToString().Trim().Equals("SOKYHIEU"))
                                            {
                                                if (indexValue != null && indexValue != "") kyHieu = indexValue.ToString().Trim();
                                                else if (indexValue2 != null && indexValue2 != "") kyHieu = indexValue2.ToString().Trim();
                                                else kyHieu = indexValueQC.ToString().Trim();
                                            }

                                            if (indexName.ToString().Trim().Equals("TRICHYEU"))
                                            {
                                                if (indexValue != null && indexValue != "") trichYeu = indexValue.ToString().Trim();
                                                else if (indexValue2 != null && indexValue2 != "") kyHieu = indexValue2.ToString().Trim();
                                                else tieuDe = indexValueQC.ToString().Trim();
                                            }

                                            if (!tieuDe.Equals("") && !kyHieu.Equals("") && !trichYeu.Equals(""))
                                            {
                                                tieuDe = Utils.format(tieuDe);
                                                kyHieu = Utils.format(kyHieu);
                                                trichYeu = Utils.format(trichYeu);

                                                SqlConnection sqlConnection = new SqlConnection(sqlConnect);
                                                sqlConnection.Open();
                                                string sqlQuery = "use UBND_tinh_An_Giang; " +
                                                "insert into ThongKe " +
                                                "select TENDONVIPHATHANH, NGAYLAP, HOSOSO, KYHIEU, TRICHYEU, " +
                                                "TOSO, TIEUDE, THOIHANBAOQUAN, THOIGIANBATDAU, vb.NGAYKY, " +
                                                "hs.THOIGIANKETTHUC as 'ThoiGianKetThucHS', vb.GHICHU1 as 'GhiChuVB1', vb.GHICHU2 as 'GhiChuVB2', " +
                                                "hs.GHICHU1 as 'GhiChuHS1', hs.GHICHU2 as 'GhiChuHS2', SOTO, TENLOAIVANBAN, TENPHONG, HOPSO " +
                                                "from VANBAN vb left join DONVIPHATHANH dvph on vb.MADONVIPHATHANH = dvph.MADONVIPHATHANH " +
                                                "left join HOSO hs on vb.MAHOSO = hs.MAHOSO left join LOAIVANBAN lvb on vb.MALOAIVANBAN = lvb.MALOAIVANBAN " +
                                                "left join PHONG p on hs.MAPHONG = p.MAPHONG " +
                                                "where TIEUDE like N'%" + tieuDe.Substring(5, tieuDe.Length - 5) + "%' and KYHIEU like '%" + kyHieu + "%'";
                                                SqlCommand cmd2 = new SqlCommand(sqlQuery, sqlConnection);
                                                cmd2.ExecuteNonQuery();
                                                sqlConnection.Close();
                                                tieuDe = "";
                                                trichYeu = "";
                                                kyHieu = "";
                                            }
                                        }

                                    }
                                }
                            }
                            MessageBox.Show("Có " + ag + " trường thông tin" + "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            con.Close();
                        }
                    }

                });
                threadAG2.Start();
        }

        public Home()
        {
            InitializeComponent();
            form1 = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // thread khai sinh
                threadKS = new Thread(() =>
                {
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
                            MessageBox.Show("Sẵn sàng thống kê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            con.Close();
                        }
                    }

                });

                //thread khai tử
                threadKT = new Thread(() =>
                {
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

                            con.Close();
                        }
                    }
                });

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

                            con.Close();
                        }
                    }
                });

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
                            con.Close();
                        }
                    }
                });
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
                lbCount.Visible = true;
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
            //ConnectDB.connect.Show();
            if (threadKS.ThreadState == ThreadState.Running) threadKS.Abort();
            if (threadKT.ThreadState == ThreadState.Running) threadKT.Abort();
            if (threadKH.ThreadState == ThreadState.Running) threadKH.Abort();
            if (threadCMC.ThreadState == ThreadState.Running) threadCMC.Abort();
            Application.Exit();
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
                groupBox1.Visible = true;
                groupBox2.Visible = true;
                btnExe.Visible = true;
                rdnKS.Checked = true;
                rdnLoiTrangSo.Checked = true;
                rtbSQL.Text = strCommandSql.ToLower();
                rtbSQL.Visible = true;
                //lbCount.Visible = true;
            }
            else
            {
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                rtbSQL.Visible = false;
                btnExe.Visible = false;
                rdnKS.Checked = false;
                rdnLoiTrangSo.Checked = false;
                rtbSQL.Text = "";
                datagrid.Visible = false;
                rtbSQL.Visible = false;
                lbCount.Visible = false;
            }
        }

        private void txtNdk_TextChanged(object sender, EventArgs e)
        {
            if (txtNdk.Text != "")
            {
                rtbSQL.Visible = true;
                groupBox1.Visible = true;
                groupBox2.Visible = true;
                btnExe.Visible = true;
                rdnKS.Checked = true;
                rdnLoiTrangSo.Checked = true;
                rtbSQL.Text = strCommandSql.ToLower(); ;
                //lbCount.Visible = true;
            }
            else
            {
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                rtbSQL.Visible = false;
                //btnClone.Visible = false;
                btnExe.Visible = false;
                rdnKS.Checked = false;
                rdnLoiTrangSo.Checked = false;
                rtbSQL.Text = "";
                datagrid.Visible = false;
                rtbSQL.Visible = false;
                lbCount.Visible = false;
            }
            xuLyLenh();
        }

        private void txtNdk_DropDown(object sender, EventArgs e)
        {
            conn = new SqlConnection(sqlConnect);
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

                rdnLoiTrangSo.Checked = false;
                rdnTrung.Checked = false;
                rdnId7.Checked = false;
                rdnFormat.Checked = false;
                rdnOther.Checked = false;
                rdnLoiTrangSo.Checked = true;
                rtbSQL.Text = strCommandSql.ToLower();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dt = (DataTable)datagrid.DataSource;
            if (datagrid.Rows.Count != 0 && datagrid.Rows != null)
            {
                Utils.Export(dt, datagrid, "SHEET 1", "CAPTION");
            }
            else MessageBox.Show("Không có dữ liệu để lưu vào excel, vui lòng kiểm tra lại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void clonePDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clone form3 = new Clone();
            form3.Show();
            this.Hide();
        }

        private void rdnKTBM2_CheckedChanged(object sender, EventArgs e)
        {
            xuLyLenh();
        }

        private void txtYear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                dt = (DataTable)datagrid.DataSource;
                if (datagrid.Rows.Count != 0 && datagrid.Rows != null)
                {
                    Utils.Export(dt, datagrid, "SHEET 1", "CAPTION");
                }
                else MessageBox.Show("Không có dữ liệu để lưu vào excel, vui lòng kiểm tra lại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtNdk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                dt = (DataTable)datagrid.DataSource;
                if (datagrid.Rows.Count != 0 && datagrid.Rows != null)
                {
                    Utils.Export(dt, datagrid, "SHEET 1", "CAPTION");
                }
                else MessageBox.Show("Không có dữ liệu để lưu vào excel, vui lòng kiểm tra lại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void tổngHợpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (threadCMC.ThreadState == ThreadState.Running ||
                threadKS.ThreadState == ThreadState.Running ||
                threadKT.ThreadState == ThreadState.Running ||
                threadKH.ThreadState == ThreadState.Running)
            {
                MessageBox.Show("Đang chạy, xin vui lòng chờ trong giây lát!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else

            if (threadCMC.ThreadState == ThreadState.Stopped &&
                threadKS.ThreadState == ThreadState.Stopped &&
                threadKT.ThreadState == ThreadState.Stopped &&
                threadKH.ThreadState == ThreadState.Stopped)
            {
                //gán dữ liệu vào datagridview
                datagrid.Visible = true;
                datagrid.Visible = true;
                //btnExportExcel.Visible = true;

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
            }
            else
            {
                threadKS.Start();
                threadKT.Start();
                threadKH.Start();
                threadCMC.Start();
                MessageBox.Show("Đang chạy, xin vui lòng chờ trong giây lát!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void rdnQuyenSo_CheckedChanged(object sender, EventArgs e)
        {
            xuLyLenh();
        }

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void rdnTKQuyenSo_CheckedChanged(object sender, EventArgs e)
        {
            xuLyLenh();
        }

        private void rdnDelete_CheckedChanged(object sender, EventArgs e)
        {
            xuLyLenh();
        }

        private void sốBảnGhiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mess = "";
            conn = new SqlConnection(sqlConnect);
            conn.Open();
            mess = mess + "Khai sinh: " + new SqlCommand(dbName + "SELECT COUNT(*) FROM HT_KHAISINH", conn).ExecuteScalar().ToString() + "\n";
            mess = mess + "Khai Tử: " + new SqlCommand(dbName + "SELECT COUNT(*) FROM HT_KHAITU", conn).ExecuteScalar().ToString() + "\n";
            mess = mess + "Kết hôn: " + new SqlCommand(dbName + "SELECT COUNT(*) FROM HT_KETHON", conn).ExecuteScalar().ToString() + "\n";
            mess = mess + "Nhận cha mẹ con: " + new SqlCommand(dbName + "SELECT COUNT(*) FROM HT_NHANCHAMECON", conn).ExecuteScalar().ToString() + "\n";
            mess = mess + "Tổng: " + (Convert.ToInt32(new SqlCommand(dbName + "SELECT COUNT(*) FROM HT_KHAISINH", conn).ExecuteScalar()) +
                Convert.ToInt32(new SqlCommand(dbName + "SELECT COUNT(*) FROM HT_KHAITU", conn).ExecuteScalar()) +
                Convert.ToInt32(new SqlCommand(dbName + "SELECT COUNT(*) FROM HT_KETHON", conn).ExecuteScalar()) +
                Convert.ToInt32(new SqlCommand(dbName + "SELECT COUNT(*) FROM HT_NHANCHAMECON", conn).ExecuteScalar())).ToString() + "\n";
            conn.Close();
            MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void xuLyLenh()
        {
            if (rdnLoiTrangSo.Checked)
            {
                strCommandSql = dbName + "SELECT SO, QUYENSO, TENNOIDANGKY, " + hoten + ", TRANGSO, TINHTRANGID, TENFILESAUUPLOAD " + "\n" + "FROM " + table +
                    " KT JOIN HT_NOIDANGKY NDK ON KT.NOIDANGKY = NDK.MANOIDANGKY " + "\n" + "WHERE ISNUMERIC(TRANGSO) != 1 " +
                    "AND TRANGSO IS NOT NULL AND TRANGSO !='' AND QUYENSO LIKE '%" + txtYear.Text.Trim() + "%' AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%'";

            }
            else if (rdnTrung.Checked)
            {
                strCommandSql = dbName + "SELECT SO , QUYENSO, TENNOIDANGKY, COUNT(*) AS 'SL TRUNG' " + "\n" + "FROM " + table + " KT JOIN HT_NOIDANGKY NDK ON KT.NOIDANGKY = NDK.MANOIDANGKY \n" +
                    "WHERE(QUYENSO LIKE '%" + txtYear.Text.Trim() + "%') AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%' GROUP BY TENNOIDANGKY,QUYENSO,SO HAVING COUNT(*) >= 2 ORDER BY TENNOIDANGKY, QUYENSO";
            }
            else if (rdnId7.Checked)
            {
                strCommandSql = dbName + "SELECT SO, QUYENSO , TENNOIDANGKY, TRANGSO, " +
                            hoten + ", TINHTRANGID, TENFILESAUUPLOAD\n" +
                            " FROM " + table + " KT JOIN HT_NOIDANGKY NDK ON KT.NOIDANGKY = NDK.MANOIDANGKY \n" +
                            "WHERE QUYENSO LIKE '%" + txtYear.Text.Trim() + "%' AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%'" +
                            " AND(TINHTRANGID != 7 OR TINHTRANGID IS NULL) " +
                            "ORDER BY NOIDANGKY, QUYENSO, SO";
            }
            else if (rdnFormat.Checked)
            {
                strCommandSql = dbName + "SELECT SO, QUYENSO, TENNOIDANGKY, " + hoten +
                            " , TENFILESAUUPLOAD\n FROM " + table + " KS JOIN HT_NOIDANGKY NDK ON KS.NOIDANGKY = NDK.MANOIDANGKY \n" +
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
                    "set TinhTrangID = 1 \n" +
                    "where  (ISNUMERIC(TRANGSO) = 1 or TRANGSO IS NULL or TRANGSO ='') AND " +
                    "QUYENSO LIKE '%" + txtYear.Text.Trim() + "%' AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%'; \n" +
                    "update xl set TinhTrangID = 1 \n" +
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
                    "set TinhTrangID = 5 \n" +
                    "where  (ISNUMERIC(TRANGSO) = 1 or TRANGSO IS NULL or TRANGSO ='') AND " +
                    "QUYENSO LIKE '%" + txtYear.Text.Trim() + "%' AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%'; \n" +
                    "update xl set TinhTrangID = 5 \n" +
                    "from HT_KHAISINH ks join HT_XULY xl " +
                    "on ks.ID = xl.ObjectID" +
                    " where  (ISNUMERIC(TRANGSO) = 1 or TRANGSO IS NULL or TRANGSO ='') AND " +
                    "QUYENSO LIKE '%" + txtYear.Text.Trim() + "%' AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%'; \n" +
                    "select so, quyenSo, " + hoten + ", noiDangKy, TinhTrangID from " + table + " " +
                    "where QUYENSO LIKE '%" + txtYear.Text.Trim() + "%' AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%';  ";
            }
            else if (rdnKTBM2.Checked)
            {
                strCommandSql = dbName + "update " + table + " " +
                    "set TinhTrangID = 6 \n" +
                    "where  (ISNUMERIC(TRANGSO) = 1 or TRANGSO IS NULL or TRANGSO ='') AND " +
                    "QUYENSO LIKE '%" + txtYear.Text.Trim() + "%' AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%'; \n" +
                    "update xl set TinhTrangID = 6 \n" +
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
                    "set TinhTrangID = 7 \n" +
                    "where  (ISNUMERIC(TRANGSO) = 1 or TRANGSO IS NULL or TRANGSO ='') AND " +
                    "QUYENSO LIKE '%" + txtYear.Text.Trim() + "%' AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%'; \n" +
                    "update xl set TinhTrangID = 7 \n" +
                    "from HT_KHAISINH ks join HT_XULY xl " +
                    "on ks.ID = xl.ObjectID" +
                    " where  (ISNUMERIC(TRANGSO) = 1 or TRANGSO IS NULL or TRANGSO ='') AND " +
                    "QUYENSO LIKE '%" + txtYear.Text.Trim() + "%' AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%'; \n" +
                    "select so, quyenSo, " + hoten + ", noiDangKy, TinhTrangID from " + table + " " +
                    "where QUYENSO LIKE '%" + txtYear.Text.Trim() + "%' AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%';  ";
            }
            else if (rdnTKQuyenSo.Checked)
            {
                strCommandSql = dbName + "select TenNoiDangKy, quyenSo, count(*) as N'Sum'\n" +
                    "from "+ table+ " kt join HT_NOIDANGKY ndk on kt.noiDangKy = ndk.MaNoiDangKy \n" +
                    "where quyenSo like '%" + txtYear.Text.Trim() + "%' and noiDangKy LIKE '%" + txtNdk.SelectedValue + "%' \n" +
                    "group by TenNoiDangKy, quyenSo \n" +
                    "order by TenNoiDangKy, quyenSo";
            }
            else if (rdnQuyenSo.Checked)
            {
                strCommandSql = dbName + "SELECT SO, QUYENSO, noiDangKy, " + hoten +
                    " , TENFILESAUUPLOAD\n FROM " + table + " " +
                    "\nwhere so is null or so ='' or quyenSo is null or quyenSo = '' or noiDangKy is null or noiDangKy = ''";            
            }
            else if (rdnDelete.Checked)
            {
                strCommandSql = dbName + "delete from " + table +
                    " \nwhere quyenSo like '%" + txtYear.Text.Trim() + "%' and noiDangKy LIKE '%" + txtNdk.SelectedValue + "%' \n";
            }
            else if (rdnOther.Checked)
            {
                rtbSQL.ReadOnly = false;
            }
            if (!rdnOther.Checked) rtbSQL.ReadOnly = true;

            rtbSQL.Text = strCommandSql.ToLower();
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
