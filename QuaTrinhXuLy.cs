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

        private void btnExe_Click(object sender, EventArgs e)
        {
            Thread threadDiffKS = new Thread(() =>
                {
                    using (SqlConnection con = new SqlConnection(Home.sqlConnect))
                    {
                        HT_KHAISINH tt7 = new HT_KHAISINH(), tt6 = new HT_KHAISINH(), tt5 = new HT_KHAISINH();
                        List<string> listDayDu3TrangThai = new List<string>();

                        string str = " SELECT ID, so, quyenSo, trangSo, ngayDangKy, loaiDangKy, noiDangKy, nksHoTen, nksGioiTinh, nksNgaySinh, nksDanToc, nksQuocTich, meHoTen, meNgaySinh, meDanToc, meQuocTich, meLoaiCuTru, chaHoTen, chaNgaySinh, chaDanToc, chaQuocTich, chaLoaiCuTru, TinhTrangID, TenFile, TenFileSauUpLoad, URLTapTinDinhKem, NamMoSo, DuLieuCu, NgayCapNhat, LoaiGiay, URLAnhCu, GhiChu, nksNoiSinh, meNoiCuTru, chaNoiCuTru, nycHoTen, nycQuanHe, nguoiKy, chucVuNguoiKy, NguoiThucHien, nksLoaiKhaiSinh, nksNoiSinhDVHC, nksQueQuan, nycLoaiGiayToTuyThan, nycSoGiayToTuyThan, nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan, nksNgaySinhBangChu" +
                            " FROM QTXLKS where TinhTrangID = 7 " +
                            "and id in (select id from QTXLKS where TinhTrangID = 6) and id in (select id from QTXLKS where TinhTrangID = 5) " +
                            "and NgayCapNhat between CONVERT(datetime, '" + DateTime.Parse(dtFrom.Value.ToString()) + "', 103) " +
                            "and CONVERT(datetime, '" + DateTime.Parse(dtTo.Value.ToString()) + "', 103)";


                    //tìm kiếm bản ghi có đủ 3 trạng thái
                    using (SqlCommand cmd = new SqlCommand(str, con))
                        {
                            cmd.CommandType = CommandType.Text;
                            con.Open();
                            SqlDataReader dr = cmd.ExecuteReader();
                        //duyệt từng bản ghi
                        while (dr.Read())
                            {
                                listDayDu3TrangThai.Add(dr[0].ToString());
                            }
                            con.Close();
                        }

                    //duyệt từng bản ghi có đủ 3 trạng thái
                    foreach (string s in listDayDu3TrangThai)
                        {
                        //trạng thái 7
                        string kt = " SELECT ID, so, quyenSo, trangSo, ngayDangKy, loaiDangKy, noiDangKy, nksHoTen, nksGioiTinh, nksNgaySinh, nksDanToc, nksQuocTich, meHoTen, meNgaySinh, meDanToc, meQuocTich, meLoaiCuTru, chaHoTen, chaNgaySinh, chaDanToc, chaQuocTich, chaLoaiCuTru, TinhTrangID, TenFile, TenFileSauUpLoad, URLTapTinDinhKem, NamMoSo, DuLieuCu, NgayCapNhat, LoaiGiay, URLAnhCu, GhiChu, nksNoiSinh, meNoiCuTru, chaNoiCuTru, nycHoTen, nycQuanHe, nguoiKy, chucVuNguoiKy, NguoiThucHien, nksLoaiKhaiSinh, nksNoiSinhDVHC, nksQueQuan, nycLoaiGiayToTuyThan, nycSoGiayToTuyThan, nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan, nksNgaySinhBangChu" +
                                " FROM QTXLKS where id = " + s + " and TinhTrangID = 7";

                        //trạng thái 6
                        string ktbm2 = " SELECT ID, so, quyenSo, trangSo, ngayDangKy, loaiDangKy, noiDangKy, nksHoTen, nksGioiTinh, nksNgaySinh, nksDanToc, nksQuocTich, meHoTen, meNgaySinh, meDanToc, meQuocTich, meLoaiCuTru, chaHoTen, chaNgaySinh, chaDanToc, chaQuocTich, chaLoaiCuTru, TinhTrangID, TenFile, TenFileSauUpLoad, URLTapTinDinhKem, NamMoSo, DuLieuCu, NgayCapNhat, LoaiGiay, URLAnhCu, GhiChu, nksNoiSinh, meNoiCuTru, chaNoiCuTru, nycHoTen, nycQuanHe, nguoiKy, chucVuNguoiKy, NguoiThucHien, nksLoaiKhaiSinh, nksNoiSinhDVHC, nksQueQuan, nycLoaiGiayToTuyThan, nycSoGiayToTuyThan, nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan, nksNgaySinhBangChu" +
                                " FROM QTXLKS where id = " + s + " and TinhTrangID = 6";

                        //trạng thái 5
                        string ktbm1 = " SELECT ID, so, quyenSo, trangSo, ngayDangKy, loaiDangKy, noiDangKy, nksHoTen, nksGioiTinh, nksNgaySinh, nksDanToc, nksQuocTich, meHoTen, meNgaySinh, meDanToc, meQuocTich, meLoaiCuTru, chaHoTen, chaNgaySinh, chaDanToc, chaQuocTich, chaLoaiCuTru, TinhTrangID, TenFile, TenFileSauUpLoad, URLTapTinDinhKem, NamMoSo, DuLieuCu, NgayCapNhat, LoaiGiay, URLAnhCu, GhiChu, nksNoiSinh, meNoiCuTru, chaNoiCuTru, nycHoTen, nycQuanHe, nguoiKy, chucVuNguoiKy, NguoiThucHien, nksLoaiKhaiSinh, nksNoiSinhDVHC, nksQueQuan, nycLoaiGiayToTuyThan, nycSoGiayToTuyThan, nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan, nksNgaySinhBangChu" +
                                " FROM QTXLKS where id = " + s + " and TinhTrangID = 5";

                            using (SqlCommand cmd = new SqlCommand(kt, con))
                            {
                                cmd.CommandType = CommandType.Text;
                                con.Open();
                                SqlDataReader dr = cmd.ExecuteReader();
                            //duyệt từng bản ghi
                            while (dr.Read())
                                {
                                    Type type = (new HT_KHAISINH()).GetType();

                                //lấy value theo tên thuộc tính (có get set)
                                int i = 0;
                                    foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                                    {
                                        tt7.GetType().GetProperty(property.Name).SetValue(tt7, dr[i].ToString().Trim(), null);
                                        i++;
                                    }
                                }
                                con.Close();
                            }

                            using (SqlCommand cmd = new SqlCommand(ktbm2, con))
                            {
                                cmd.CommandType = CommandType.Text;
                                con.Open();
                                SqlDataReader dr = cmd.ExecuteReader();
                            //duyệt từng bản ghi
                            while (dr.Read())
                                {
                                    Type type = (new HT_KHAISINH()).GetType();

                                //lấy value theo tên thuộc tính (có get set)
                                int i = 0;
                                    foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                                    {
                                        tt6.GetType().GetProperty(property.Name).SetValue(tt6, dr[i].ToString().Trim(), null);
                                        i++;
                                    }
                                }
                                con.Close();
                            }

                            using (SqlCommand cmd = new SqlCommand(ktbm1, con))
                            {
                                cmd.CommandType = CommandType.Text;
                                con.Open();
                                SqlDataReader dr = cmd.ExecuteReader();
                            //duyệt từng bản ghi
                            while (dr.Read())
                                {
                                    Type type = (new HT_KHAISINH()).GetType();

                                //lấy value theo tên thuộc tính (có get set)
                                int i = 0;
                                    foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                                    {
                                        tt5.GetType().GetProperty(property.Name).SetValue(tt5, dr[i].ToString().Trim(), null);
                                        i++;
                                    }
                                }
                                con.Close();
                            }

                        //so sánh 2 trạng thái nếu khác nhau thì so sánh từng cột 1 để lưu vào db
                        if (!tt7.Equals(tt6) || !tt7.Equals(tt5) || !tt6.Equals(tt5))
                            {
                                List<Diff> listDiff = new List<Diff>();

                                Type type = (new HT_KHAISINH()).GetType();

                            //lấy value theo tên thuộc tính (có get set)
                            foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                                {
                                    if (!tt7.GetType().GetProperty(property.Name).GetValue(tt7, null).ToString().ToUpper().Equals(tt6.GetType().GetProperty(property.Name).GetValue(tt6, null).ToString().ToUpper())
                                    || !tt7.GetType().GetProperty(property.Name).GetValue(tt7, null).ToString().ToUpper().Equals(tt5.GetType().GetProperty(property.Name).GetValue(tt5, null).ToString().ToUpper())
                                    || !tt6.GetType().GetProperty(property.Name).GetValue(tt6, null).ToString().ToUpper().Equals(tt5.GetType().GetProperty(property.Name).GetValue(tt5, null).ToString().ToUpper()))
                                        if (!property.Name.Equals("TinhTrangID1") && !property.Name.Equals("NgayCapNhat1"))
                                            addListDiff<HT_KHAISINH>(listDiff, tt7, tt6, tt5, property.Name);
                                }

                                foreach (Diff diff in listDiff)
                                {
                                    SqlConnection conn = new SqlConnection(Home.sqlConnect);
                                    conn.Open();
                                    SqlCommand cmd = new SqlCommand("use HoTich; if(select count(*) from Diff " +
                                        "where id = '" + diff.id + "' and so = '" + diff.so + "' and quyenSo = '" + diff.quyenSo + "' and noiDangKy = '" + diff.noiDangKy + "' " +
                                        "and ngayDangKy = '" + diff.ngayDangKy + "' and tableName = '" + diff.tableName + "' and columnName = '" + diff.columnName + "' " +
                                        "and ktbm1 = N'" + diff.ktbm1 + "' and ktbm2 = N'" + diff.ktbm2 + "' and kt = N'" + diff.kt + "') = 0 " +
                                        "insert into Diff values('" + diff.id + "', '" + diff.so + "', '" + diff.quyenSo + "'," +
                                        "'" + diff.noiDangKy + "', '" + diff.ngayDangKy + "', '" + diff.tableName + "', '" + diff.columnName + "', N'" + diff.ktbm1 + "'," +
                                        "N'" + diff.ktbm2 + "',N'" + diff.kt + "')", conn);
                                    cmd.ExecuteNonQuery();
                                    conn.Close();
                                }
                            }

                        }
                        MessageBox.Show("Đã xử lý xong KS", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                });
            threadDiffKS.Start();

            //thread xử lý KT
            Thread threadDiffKT = new Thread(() =>
            {
                using (SqlConnection con = new SqlConnection(Home.sqlConnect))
                {
                    HT_KHAITU tt7 = new HT_KHAITU(), tt6 = new HT_KHAITU(), tt5 = new HT_KHAITU();
                    List<string> listDayDu3TrangThai = new List<string>();

                    string str = " SELECT ID, So, quyenSo, trangSo, ngayDangKy, loaiDangKy, noiDangKy, nktHoTen, nktGioiTinh, nktNgaySinh, nktDanToc, nktQuocTich, nktLoaiCuTru, nktLoaiGiayToTuyThan, nktSoGiayToTuyThan, nktNgayChet, TinhTrangID, TenFile, TenFileSauUpload, URLTapTinDinhKem, NamMoSo, LoaiGiay, DuLieuCu, NgayCapNhat, urlAnhCu, GhiChu, nktGioPhutChet, nktNoiChet, nktNguyenNhanChet, nktNoiCuTru, nycHoTen, nycQuanHe, nguoiKy, chucVuNguoiKy, nguoiThucHien, nktNgayCapGiayToTuyThan, nktNoiCapGiayToTuyThan, gbtLoai, gbtSo, gbtNgay, gbtCoQuanCap, nycLoaiGiayToTuyThan, nycSoGiayToTuyThan, nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan" +
                        " FROM QTXLKT where TinhTrangID = 7 " +
                        "and id in (select id from QTXLKT where TinhTrangID = 6) and id in (select id from QTXLKT where TinhTrangID = 5) " +
                        "and NgayCapNhat between CONVERT(datetime, '" + DateTime.Parse(dtFrom.Value.ToString()) + "', 103) " +
                        "and CONVERT(datetime, '" + DateTime.Parse(dtTo.Value.ToString()) + "', 103)";


                //tìm kiếm bản ghi có đủ 3 trạng thái
                using (SqlCommand cmd = new SqlCommand(str, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                    //duyệt từng bản ghi
                    while (dr.Read())
                        {
                            listDayDu3TrangThai.Add(dr[0].ToString());
                        }
                        con.Close();
                    }

                //duyệt từng bản ghi có đủ 3 trạng thái
                foreach (string s in listDayDu3TrangThai)
                    {
                    //trạng thái 7
                    string kt = " SELECT ID, So, quyenSo, trangSo, ngayDangKy, loaiDangKy, noiDangKy, nktHoTen, nktGioiTinh, nktNgaySinh, nktDanToc, nktQuocTich, nktLoaiCuTru, nktLoaiGiayToTuyThan, nktSoGiayToTuyThan, nktNgayChet, TinhTrangID, TenFile, TenFileSauUpload, URLTapTinDinhKem, NamMoSo, LoaiGiay, DuLieuCu, NgayCapNhat, urlAnhCu, GhiChu, nktGioPhutChet, nktNoiChet, nktNguyenNhanChet, nktNoiCuTru, nycHoTen, nycQuanHe, nguoiKy, chucVuNguoiKy, nguoiThucHien, nktNgayCapGiayToTuyThan, nktNoiCapGiayToTuyThan, gbtLoai, gbtSo, gbtNgay, gbtCoQuanCap, nycLoaiGiayToTuyThan, nycSoGiayToTuyThan, nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan" +
                            " FROM QTXLKT where id = " + s + " and TinhTrangID = 7";

                    //trạng thái 6
                    string ktbm2 = " SELECT ID, So, quyenSo, trangSo, ngayDangKy, loaiDangKy, noiDangKy, nktHoTen, nktGioiTinh, nktNgaySinh, nktDanToc, nktQuocTich, nktLoaiCuTru, nktLoaiGiayToTuyThan, nktSoGiayToTuyThan, nktNgayChet, TinhTrangID, TenFile, TenFileSauUpload, URLTapTinDinhKem, NamMoSo, LoaiGiay, DuLieuCu, NgayCapNhat, urlAnhCu, GhiChu, nktGioPhutChet, nktNoiChet, nktNguyenNhanChet, nktNoiCuTru, nycHoTen, nycQuanHe, nguoiKy, chucVuNguoiKy, nguoiThucHien, nktNgayCapGiayToTuyThan, nktNoiCapGiayToTuyThan, gbtLoai, gbtSo, gbtNgay, gbtCoQuanCap, nycLoaiGiayToTuyThan, nycSoGiayToTuyThan, nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan" +
                            " FROM QTXLKT where id = " + s + " and TinhTrangID = 6";

                    //trạng thái 5
                    string ktbm1 = " SELECT ID, So, quyenSo, trangSo, ngayDangKy, loaiDangKy, noiDangKy, nktHoTen, nktGioiTinh, nktNgaySinh, nktDanToc, nktQuocTich, nktLoaiCuTru, nktLoaiGiayToTuyThan, nktSoGiayToTuyThan, nktNgayChet, TinhTrangID, TenFile, TenFileSauUpload, URLTapTinDinhKem, NamMoSo, LoaiGiay, DuLieuCu, NgayCapNhat, urlAnhCu, GhiChu, nktGioPhutChet, nktNoiChet, nktNguyenNhanChet, nktNoiCuTru, nycHoTen, nycQuanHe, nguoiKy, chucVuNguoiKy, nguoiThucHien, nktNgayCapGiayToTuyThan, nktNoiCapGiayToTuyThan, gbtLoai, gbtSo, gbtNgay, gbtCoQuanCap, nycLoaiGiayToTuyThan, nycSoGiayToTuyThan, nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan" +
                            " FROM QTXLKT where id = " + s + " and TinhTrangID = 5";

                        using (SqlCommand cmd = new SqlCommand(kt, con))
                        {
                            cmd.CommandType = CommandType.Text;
                            con.Open();
                            SqlDataReader dr = cmd.ExecuteReader();
                        //duyệt từng bản ghi
                        while (dr.Read())
                            {
                                Type type = (new HT_KHAITU()).GetType();

                            //lấy value theo tên thuộc tính (có get set)
                            int i = 0;
                                foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                                {
                                    tt7.GetType().GetProperty(property.Name).SetValue(tt7, dr[i].ToString().Trim(), null);
                                    i++;
                                }
                            }
                            con.Close();
                        }

                        using (SqlCommand cmd = new SqlCommand(ktbm2, con))
                        {
                            cmd.CommandType = CommandType.Text;
                            con.Open();
                            SqlDataReader dr = cmd.ExecuteReader();
                        //duyệt từng bản ghi
                        while (dr.Read())
                            {
                                Type type = (new HT_KHAITU()).GetType();

                            //lấy value theo tên thuộc tính (có get set)
                            int i = 0;
                                foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                                {
                                    tt6.GetType().GetProperty(property.Name).SetValue(tt6, dr[i].ToString().Trim(), null);
                                    i++;
                                }
                            }
                            con.Close();
                        }

                        using (SqlCommand cmd = new SqlCommand(ktbm1, con))
                        {
                            cmd.CommandType = CommandType.Text;
                            con.Open();
                            SqlDataReader dr = cmd.ExecuteReader();
                        //duyệt từng bản ghi
                        while (dr.Read())
                            {
                                Type type = (new HT_KHAITU()).GetType();

                            //lấy value theo tên thuộc tính (có get set)
                            int i = 0;
                                foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                                {
                                    tt5.GetType().GetProperty(property.Name).SetValue(tt5, dr[i].ToString().Trim(), null);
                                    i++;
                                }
                            }
                            con.Close();
                        }

                    //so sánh 2 trạng thái nếu khác nhau thì so sánh từng cột 1 để lưu vào db
                    if (!tt7.Equals(tt6) || !tt7.Equals(tt5) || !tt6.Equals(tt5))
                        {
                            List<Diff> listDiff = new List<Diff>();

                            Type type = (new HT_KHAITU()).GetType();

                        //lấy value theo tên thuộc tính (có get set)
                        foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                            {
                                if (!tt7.GetType().GetProperty(property.Name).GetValue(tt7, null).ToString().ToUpper().Equals(tt6.GetType().GetProperty(property.Name).GetValue(tt6, null).ToString().ToUpper())
                                || !tt7.GetType().GetProperty(property.Name).GetValue(tt7, null).ToString().ToUpper().Equals(tt5.GetType().GetProperty(property.Name).GetValue(tt5, null).ToString().ToUpper())
                                || !tt6.GetType().GetProperty(property.Name).GetValue(tt6, null).ToString().ToUpper().Equals(tt5.GetType().GetProperty(property.Name).GetValue(tt5, null).ToString().ToUpper()))
                                    if (!property.Name.Equals("TinhTrangID1") && !property.Name.Equals("NgayCapNhat1"))
                                        addListDiff<HT_KHAITU>(listDiff, tt7, tt6, tt5, property.Name);
                            }

                            foreach (Diff diff in listDiff)
                            {
                                SqlConnection conn = new SqlConnection(Home.sqlConnect);
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("use HoTich; if(select count(*) from Diff " +
                                    "where id = '" + diff.id + "' and so = '" + diff.so + "' and quyenSo = '" + diff.quyenSo + "' and noiDangKy = '" + diff.noiDangKy + "' " +
                                    "and ngayDangKy = '" + diff.ngayDangKy + "' and tableName = '" + diff.tableName + "' and columnName = '" + diff.columnName + "' " +
                                    "and ktbm1 = N'" + diff.ktbm1 + "' and ktbm2 = N'" + diff.ktbm2 + "' and kt = N'" + diff.kt + "') = 0 " +
                                    "insert into Diff values('" + diff.id + "', '" + diff.so + "', '" + diff.quyenSo + "'," +
                                    "'" + diff.noiDangKy + "', '" + diff.ngayDangKy + "', '" + diff.tableName + "', '" + diff.columnName + "', N'" + diff.ktbm1 + "'," +
                                    "N'" + diff.ktbm2 + "',N'" + diff.kt + "')", conn);
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                        }

                    }

                    MessageBox.Show("Đã xử lý xong KT", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            });
            threadDiffKT.Start();

            //thread xử lý KH
            Thread threadDiffKH = new Thread(() =>
            {
                using (SqlConnection con = new SqlConnection(Home.sqlConnect))
                {
                    HT_KETHON tt7 = new HT_KETHON(), tt6 = new HT_KETHON(), tt5 = new HT_KETHON();
                    List<string> listDayDu3TrangThai = new List<string>();

                    string str = " SELECT ID, So, quyenSo, trangSo, ngayDangKy, loaiDangKy, noiDangKy, chongHoTen, chongNgaySinh, chongDanToc, chongQuocTich, chongLoaiCuTru, chongLoaiGiayToTuyThan, chongSoGiayToTuyThan, voHoTen, voNgaySinh, voDanToc, voQuocTich, voLoaiCuTru, voLoaiGiayToTuyThan, voSoGiayToTuyThan, TinhTrangID, TenFile, TenFileSauUpLoad, URLTapTinDinhKem, NamMoSo, LoaiGiay, DuLieuCu, NgayCapNhat, urlAnhCu, GhiChu, chongNoiCuTru, voNoiCuTru, nguoiKy, chucVuNguoiKy, nguoiThucHien, chongNgayCapGiayToTuyThan, chongNoiCapGiayToTuyThan, voNgayCapGiayToTuyThan, voNoiCapGiayToTuyThan" +
                        " FROM QTXLKH where TinhTrangID = 7 " +
                        "and id in (select id from QTXLKH where TinhTrangID = 6) and id in (select id from QTXLKH where TinhTrangID = 5) " +
                        "and NgayCapNhat between CONVERT(datetime, '" + DateTime.Parse(dtFrom.Value.ToString()) + "', 103) " +
                        "and CONVERT(datetime, '" + DateTime.Parse(dtTo.Value.ToString()) + "', 103)";


                //tìm kiếm bản ghi có đủ 3 trạng thái
                using (SqlCommand cmd = new SqlCommand(str, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                    //duyệt từng bản ghi
                    while (dr.Read())
                        {
                            listDayDu3TrangThai.Add(dr[0].ToString());
                        }
                        con.Close();
                    }

                //duyệt từng bản ghi có đủ 3 trạng thái
                foreach (string s in listDayDu3TrangThai)
                    {
                    //trạng thái 7
                    string kt = " SELECT ID, So, quyenSo, trangSo, ngayDangKy, loaiDangKy, noiDangKy, chongHoTen, chongNgaySinh, chongDanToc, chongQuocTich, chongLoaiCuTru, chongLoaiGiayToTuyThan, chongSoGiayToTuyThan, voHoTen, voNgaySinh, voDanToc, voQuocTich, voLoaiCuTru, voLoaiGiayToTuyThan, voSoGiayToTuyThan, TinhTrangID, TenFile, TenFileSauUpLoad, URLTapTinDinhKem, NamMoSo, LoaiGiay, DuLieuCu, NgayCapNhat, urlAnhCu, GhiChu, chongNoiCuTru, voNoiCuTru, nguoiKy, chucVuNguoiKy, nguoiThucHien, chongNgayCapGiayToTuyThan, chongNoiCapGiayToTuyThan, voNgayCapGiayToTuyThan, voNoiCapGiayToTuyThan" +
                            " FROM QTXLKH where id = " + s + " and TinhTrangID = 7";

                    //trạng thái 6
                    string ktbm2 = " SELECT ID, So, quyenSo, trangSo, ngayDangKy, loaiDangKy, noiDangKy, chongHoTen, chongNgaySinh, chongDanToc, chongQuocTich, chongLoaiCuTru, chongLoaiGiayToTuyThan, chongSoGiayToTuyThan, voHoTen, voNgaySinh, voDanToc, voQuocTich, voLoaiCuTru, voLoaiGiayToTuyThan, voSoGiayToTuyThan, TinhTrangID, TenFile, TenFileSauUpLoad, URLTapTinDinhKem, NamMoSo, LoaiGiay, DuLieuCu, NgayCapNhat, urlAnhCu, GhiChu, chongNoiCuTru, voNoiCuTru, nguoiKy, chucVuNguoiKy, nguoiThucHien, chongNgayCapGiayToTuyThan, chongNoiCapGiayToTuyThan, voNgayCapGiayToTuyThan, voNoiCapGiayToTuyThan" +
                            " FROM QTXLKH where id = " + s + " and TinhTrangID = 6";

                    //trạng thái 5
                    string ktbm1 = " SELECT ID, So, quyenSo, trangSo, ngayDangKy, loaiDangKy, noiDangKy, chongHoTen, chongNgaySinh, chongDanToc, chongQuocTich, chongLoaiCuTru, chongLoaiGiayToTuyThan, chongSoGiayToTuyThan, voHoTen, voNgaySinh, voDanToc, voQuocTich, voLoaiCuTru, voLoaiGiayToTuyThan, voSoGiayToTuyThan, TinhTrangID, TenFile, TenFileSauUpLoad, URLTapTinDinhKem, NamMoSo, LoaiGiay, DuLieuCu, NgayCapNhat, urlAnhCu, GhiChu, chongNoiCuTru, voNoiCuTru, nguoiKy, chucVuNguoiKy, nguoiThucHien, chongNgayCapGiayToTuyThan, chongNoiCapGiayToTuyThan, voNgayCapGiayToTuyThan, voNoiCapGiayToTuyThan" +
                            " FROM QTXLKH where id = " + s + " and TinhTrangID = 5";

                        using (SqlCommand cmd = new SqlCommand(kt, con))
                        {
                            cmd.CommandType = CommandType.Text;
                            con.Open();
                            SqlDataReader dr = cmd.ExecuteReader();
                        //duyệt từng bản ghi
                        while (dr.Read())
                            {
                                Type type = (new HT_KETHON()).GetType();

                            //lấy value theo tên thuộc tính (có get set)
                            int i = 0;
                                foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                                {
                                    tt7.GetType().GetProperty(property.Name).SetValue(tt7, dr[i].ToString().Trim(), null);
                                    i++;
                                }
                            }
                            con.Close();
                        }

                        using (SqlCommand cmd = new SqlCommand(ktbm2, con))
                        {
                            cmd.CommandType = CommandType.Text;
                            con.Open();
                            SqlDataReader dr = cmd.ExecuteReader();
                        //duyệt từng bản ghi
                        while (dr.Read())
                            {
                                Type type = (new HT_KETHON()).GetType();

                            //lấy value theo tên thuộc tính (có get set)
                            int i = 0;
                                foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                                {
                                    tt6.GetType().GetProperty(property.Name).SetValue(tt6, dr[i].ToString().Trim(), null);
                                    i++;
                                }
                            }
                            con.Close();
                        }

                        using (SqlCommand cmd = new SqlCommand(ktbm1, con))
                        {
                            cmd.CommandType = CommandType.Text;
                            con.Open();
                            SqlDataReader dr = cmd.ExecuteReader();
                        //duyệt từng bản ghi
                        while (dr.Read())
                            {
                                Type type = (new HT_KETHON()).GetType();

                            //lấy value theo tên thuộc tính (có get set)
                            int i = 0;
                                foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                                {
                                    tt5.GetType().GetProperty(property.Name).SetValue(tt5, dr[i].ToString().Trim(), null);
                                    i++;
                                }
                            }
                            con.Close();
                        }

                    //so sánh 2 trạng thái nếu khác nhau thì so sánh từng cột 1 để lưu vào db
                    if (!tt7.Equals(tt6) || !tt7.Equals(tt5) || !tt6.Equals(tt5))
                        {
                            List<Diff> listDiff = new List<Diff>();

                            Type type = (new HT_KETHON()).GetType();

                        //lấy value theo tên thuộc tính (có get set)
                        foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                            {
                                if (!tt7.GetType().GetProperty(property.Name).GetValue(tt7, null).ToString().ToUpper().Equals(tt6.GetType().GetProperty(property.Name).GetValue(tt6, null).ToString().ToUpper())
                                || !tt7.GetType().GetProperty(property.Name).GetValue(tt7, null).ToString().ToUpper().Equals(tt5.GetType().GetProperty(property.Name).GetValue(tt5, null).ToString().ToUpper())
                                || !tt6.GetType().GetProperty(property.Name).GetValue(tt6, null).ToString().ToUpper().Equals(tt5.GetType().GetProperty(property.Name).GetValue(tt5, null).ToString().ToUpper()))
                                    if (!property.Name.Equals("TinhTrangID1") && !property.Name.Equals("NgayCapNhat1"))
                                        addListDiff<HT_KETHON>(listDiff, tt7, tt6, tt5, property.Name);
                            }

                            foreach (Diff diff in listDiff)
                            {
                                SqlConnection conn = new SqlConnection(Home.sqlConnect);
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("use HoTich; if(select count(*) from Diff " +
                                    "where id = '" + diff.id + "' and so = '" + diff.so + "' and quyenSo = '" + diff.quyenSo + "' and noiDangKy = '" + diff.noiDangKy + "' " +
                                    "and ngayDangKy = '" + diff.ngayDangKy + "' and tableName = '" + diff.tableName + "' and columnName = '" + diff.columnName + "' " +
                                    "and ktbm1 = N'" + diff.ktbm1 + "' and ktbm2 = N'" + diff.ktbm2 + "' and kt = N'" + diff.kt + "') = 0 " +
                                    "insert into Diff values('" + diff.id + "', '" + diff.so + "', '" + diff.quyenSo + "'," +
                                    "'" + diff.noiDangKy + "', '" + diff.ngayDangKy + "', '" + diff.tableName + "', '" + diff.columnName + "', N'" + diff.ktbm1 + "'," +
                                    "N'" + diff.ktbm2 + "',N'" + diff.kt + "')", conn);
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                        }

                    }

                    MessageBox.Show("Đã xử lý xong KH", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            });
            threadDiffKH.Start();

            //thread xử lý CMC
            Thread threadDiffCMC = new Thread(() =>
            {
                using (SqlConnection con = new SqlConnection(Home.sqlConnect))
                {
                    HT_NHANCHAMECON tt7 = new HT_NHANCHAMECON(), tt6 = new HT_NHANCHAMECON(), tt5 = new HT_NHANCHAMECON();
                    List<string> listDayDu3TrangThai = new List<string>();

                    string str = " SELECT ID, So, quyenSo, trangSo, quyetDinhSo, ngayDangKy, loaiDangKy, " +
                        "loaiXacNhan, noiDangKy, cmHoTen, cmNgaySinh, cmDanToc, cmQuocTich, cmLoaiCuTru, " +
                        "cmLoaiGiayToTuyThan, cmSoGiayToTuyThan, ncHoTen, ncNgaySinh, ncDanToc, ncQuocTich, " +
                        "ncLoaiCuTru, ncLoaiGiayToTuyThan, ncSoGiayToTuyThan, TinhTrangID, TenFile, " +
                        "TenFileSauUpload, URLTapTinDinhKem, NamMoSo, LoaiGiay, DuLieuCu, NgayCapNhat, " +
                        "GhiChu, cmNoiCuTru, ncNoiCuTru, nycHoTen, nycQHNguoiDuocNhan, nguoiKy, chucVuNguoiKy, " +
                        "nguoiThucHien, cmQueQuan, cmNgayCapGiayToTuyThan, cmNoiCapGiayToTuyThan, ncQueQuan, " +
                        "ncNgayCapGiayToTuyThan, ncNoiCapGiayToTuyThan, nycLoaiGiayToTuyThan, nycSoGiayToTuyThan, " +
                        "nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan" +
                        " FROM QTXLCMC where TinhTrangID = 7 " +
                        "and id in (select id from QTXLCMC where TinhTrangID = 6) " +
                        "and id in (select id from QTXLCMC where TinhTrangID = 5) " +
                        "and NgayCapNhat between CONVERT(datetime, '" + DateTime.Parse(dtFrom.Value.ToString()) + "', 103) " +
                        "and CONVERT(datetime, '" + DateTime.Parse(dtTo.Value.ToString()) + "', 103)";


                //tìm kiếm bản ghi có đủ 3 trạng thái
                using (SqlCommand cmd = new SqlCommand(str, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                    //duyệt từng bản ghi
                    while (dr.Read())
                        {
                            listDayDu3TrangThai.Add(dr[0].ToString());
                        }
                        con.Close();
                    }

                //duyệt từng bản ghi có đủ 3 trạng thái
                foreach (string s in listDayDu3TrangThai)
                    {
                    //trạng thái 7
                    string kt = " SELECT ID, So, quyenSo, trangSo, quyetDinhSo, ngayDangKy, loaiDangKy, " +
                            "loaiXacNhan, noiDangKy, cmHoTen, cmNgaySinh, cmDanToc, cmQuocTich, cmLoaiCuTru, " +
                            "cmLoaiGiayToTuyThan, cmSoGiayToTuyThan, ncHoTen, ncNgaySinh, ncDanToc, ncQuocTich, " +
                            "ncLoaiCuTru, ncLoaiGiayToTuyThan, ncSoGiayToTuyThan, TinhTrangID, TenFile, " +
                            "TenFileSauUpload, URLTapTinDinhKem, NamMoSo, LoaiGiay, DuLieuCu, NgayCapNhat, " +
                            "GhiChu, cmNoiCuTru, ncNoiCuTru, nycHoTen, nycQHNguoiDuocNhan, nguoiKy, chucVuNguoiKy, " +
                            "nguoiThucHien, cmQueQuan, cmNgayCapGiayToTuyThan, cmNoiCapGiayToTuyThan, ncQueQuan, " +
                            "ncNgayCapGiayToTuyThan, ncNoiCapGiayToTuyThan, nycLoaiGiayToTuyThan, nycSoGiayToTuyThan, " +
                            "nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan" +
                            " FROM QTXLCMC where id = " + s + " and TinhTrangID = 7";

                        using (SqlCommand cmd = new SqlCommand(kt, con))
                        {
                            cmd.CommandType = CommandType.Text;
                            con.Open();
                            SqlDataReader dr = cmd.ExecuteReader();
                        //duyệt từng bản ghi
                        while (dr.Read())
                            {
                                Type type = (new HT_NHANCHAMECON()).GetType();

                            //lấy value theo tên thuộc tính (có get set)
                            int i = 0;
                                foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                                {
                                    tt7.GetType().GetProperty(property.Name).SetValue(tt7, dr[i].ToString().Trim(), null);
                                    i++;
                                }
                            }
                            con.Close();
                        }

                    //trạng thái 6
                    string ktbm2 = " SELECT ID, So, quyenSo, trangSo, quyetDinhSo, ngayDangKy, loaiDangKy, " +
                            "loaiXacNhan, noiDangKy, cmHoTen, cmNgaySinh, cmDanToc, cmQuocTich, cmLoaiCuTru, " +
                            "cmLoaiGiayToTuyThan, cmSoGiayToTuyThan, ncHoTen, ncNgaySinh, ncDanToc, ncQuocTich, " +
                            "ncLoaiCuTru, ncLoaiGiayToTuyThan, ncSoGiayToTuyThan, TinhTrangID, TenFile, " +
                            "TenFileSauUpload, URLTapTinDinhKem, NamMoSo, LoaiGiay, DuLieuCu, NgayCapNhat, " +
                            "GhiChu, cmNoiCuTru, ncNoiCuTru, nycHoTen, nycQHNguoiDuocNhan, nguoiKy, chucVuNguoiKy, " +
                            "nguoiThucHien, cmQueQuan, cmNgayCapGiayToTuyThan, cmNoiCapGiayToTuyThan, ncQueQuan, " +
                            "ncNgayCapGiayToTuyThan, ncNoiCapGiayToTuyThan, nycLoaiGiayToTuyThan, nycSoGiayToTuyThan, " +
                            "nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan" +
                            " FROM QTXLCMC where id = " + s + " and TinhTrangID = 6";

                        using (SqlCommand cmd = new SqlCommand(ktbm2, con))
                        {
                            cmd.CommandType = CommandType.Text;
                            con.Open();
                            SqlDataReader dr = cmd.ExecuteReader();
                        //duyệt từng bản ghi
                        while (dr.Read())
                            {
                                Type type = (new HT_NHANCHAMECON()).GetType();

                            //lấy value theo tên thuộc tính (có get set)
                            int i = 0;
                                foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                                {
                                    tt6.GetType().GetProperty(property.Name).SetValue(tt6, dr[i].ToString().Trim(), null);
                                    i++;
                                }
                            }
                            con.Close();
                        }

                    //trạng thái 5
                    string ktbm1 = " SELECT ID, So, quyenSo, trangSo, quyetDinhSo, ngayDangKy, loaiDangKy, " +
                            "loaiXacNhan, noiDangKy, cmHoTen, cmNgaySinh, cmDanToc, cmQuocTich, cmLoaiCuTru, " +
                            "cmLoaiGiayToTuyThan, cmSoGiayToTuyThan, ncHoTen, ncNgaySinh, ncDanToc, ncQuocTich, " +
                            "ncLoaiCuTru, ncLoaiGiayToTuyThan, ncSoGiayToTuyThan, TinhTrangID, TenFile, " +
                            "TenFileSauUpload, URLTapTinDinhKem, NamMoSo, LoaiGiay, DuLieuCu, NgayCapNhat, " +
                            "GhiChu, cmNoiCuTru, ncNoiCuTru, nycHoTen, nycQHNguoiDuocNhan, nguoiKy, chucVuNguoiKy, " +
                            "nguoiThucHien, cmQueQuan, cmNgayCapGiayToTuyThan, cmNoiCapGiayToTuyThan, ncQueQuan, " +
                            "ncNgayCapGiayToTuyThan, ncNoiCapGiayToTuyThan, nycLoaiGiayToTuyThan, nycSoGiayToTuyThan, " +
                            "nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan" +
                            " FROM QTXLCMC where id = " + s + " and TinhTrangID = 5";

                        using (SqlCommand cmd = new SqlCommand(ktbm1, con))
                        {
                            cmd.CommandType = CommandType.Text;
                            con.Open();
                            SqlDataReader dr = cmd.ExecuteReader();
                        //duyệt từng bản ghi
                        while (dr.Read())
                            {
                                Type type = (new HT_NHANCHAMECON()).GetType();

                            //lấy value theo tên thuộc tính (có get set)
                            int i = 0;
                                foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                                {
                                    tt5.GetType().GetProperty(property.Name).SetValue(tt5, dr[i].ToString().Trim(), null);
                                    i++;
                                }
                            }
                            con.Close();
                        }

                    //so sánh 2 trạng thái nếu khác nhau thì so sánh từng cột 1 để lưu vào db
                    if (!tt7.Equals(tt6) || !tt7.Equals(tt5) || !tt6.Equals(tt5))
                        {
                            List<Diff> listDiff = new List<Diff>();

                            Type type = (new HT_NHANCHAMECON()).GetType();

                        //lấy value theo tên thuộc tính (có get set)
                        foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                            {
                                if (!tt7.GetType().GetProperty(property.Name).GetValue(tt7, null).ToString().ToUpper().Equals(tt6.GetType().GetProperty(property.Name).GetValue(tt6, null).ToString().ToUpper())
                                || !tt7.GetType().GetProperty(property.Name).GetValue(tt7, null).ToString().ToUpper().Equals(tt5.GetType().GetProperty(property.Name).GetValue(tt5, null).ToString().ToUpper())
                                || !tt6.GetType().GetProperty(property.Name).GetValue(tt6, null).ToString().ToUpper().Equals(tt5.GetType().GetProperty(property.Name).GetValue(tt5, null).ToString().ToUpper()))
                                    if (!property.Name.Equals("TinhTrangID1") && !property.Name.Equals("NgayCapNhat1"))
                                        addListDiff<HT_NHANCHAMECON>(listDiff, tt7, tt6, tt5, property.Name);
                            }

                            foreach (Diff diff in listDiff)
                            {
                                SqlConnection conn = new SqlConnection(Home.sqlConnect);
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("use HoTich; if(select count(*) from Diff " +
                                    "where id = '" + diff.id + "' and so = '" + diff.so + "' and quyenSo = '" + diff.quyenSo + "' and noiDangKy = '" + diff.noiDangKy + "' " +
                                    "and ngayDangKy = '" + diff.ngayDangKy + "' and tableName = '" + diff.tableName + "' and columnName = '" + diff.columnName + "' " +
                                    "and ktbm1 = N'" + diff.ktbm1 + "' and ktbm2 = N'" + diff.ktbm2 + "' and kt = N'" + diff.kt + "') = 0 " +
                                    "insert into Diff values('" + diff.id + "', '" + diff.so + "', '" + diff.quyenSo + "'," +
                                    "'" + diff.noiDangKy + "', '" + diff.ngayDangKy + "', '" + diff.tableName + "', '" + diff.columnName + "', N'" + diff.ktbm1 + "'," +
                                    "N'" + diff.ktbm2 + "',N'" + diff.kt + "')", conn);
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                        }

                    }

                    MessageBox.Show("Đã xử lý xong CMC", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            });
            threadDiffCMC.Start();
        }

        private void QuaTrinhXuLy_Load(object sender, EventArgs e)
        {

        }

        private void addListDiff<T>(List<Diff> listDiff, T tt7, T tt6, T tt5, string columnName)
        {
            Diff diff = new Diff();
            diff.id = tt7.GetType().GetProperty("ID1").GetValue(tt7, null)+"";
            diff.so = tt7.GetType().GetProperty("So1").GetValue(tt7, null) + "";
            diff.quyenSo = tt7.GetType().GetProperty("QuyenSo").GetValue(tt7, null) + "";
            diff.noiDangKy = tt7.GetType().GetProperty("NoiDangKy").GetValue(tt7, null) + "";
            diff.ngayDangKy = tt7.GetType().GetProperty("NgayDangKy").GetValue(tt7, null) + "";

            diff.tableName = tt7.GetType().Name + "";

            diff.columnName = columnName;
            diff.ktbm1 = tt5.GetType().GetProperty(columnName).GetValue(tt5, null) + "";
            diff.ktbm2 = tt6.GetType().GetProperty(columnName).GetValue(tt6, null) + "";
            diff.kt = tt7.GetType().GetProperty(columnName).GetValue(tt7, null) + "";
            listDiff.Add(diff);
        }
    }
}
