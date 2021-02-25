using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            //thread xử lý KS
            Thread threadXuLyKS = new Thread(() =>
            {
                using (SqlConnection con = new SqlConnection(Home.sqlConnect))
                {
                    HT_KHAISINH tt7 = null, tt6 = null, tt5 = null;
                    List<string> listDayDu3TrangThai = new List<string>();

                    string str = " SELECT ID, so, quyenSo, trangSo, ngayDangKy, loaiDangKy, noiDangKy, nksHoTen, nksGioiTinh, nksNgaySinh, nksDanToc, nksQuocTich, meHoTen, meNgaySinh, meDanToc, meQuocTich, meLoaiCuTru, chaHoTen, chaNgaySinh, chaDanToc, chaQuocTich, chaLoaiCuTru, TinhTrangID, TenFile, TenFileSauUpLoad, URLTapTinDinhKem, NamMoSo, DuLieuCu, NgayCapNhat, LoaiGiay, URLAnhCu, GhiChu, nksNoiSinh, meNoiCuTru, chaNoiCuTru, nycHoTen, nycQuanHe, nguoiKy, chucVuNguoiKy, NguoiThucHien, nksLoaiKhaiSinh, nksNoiSinhDVHC, nksQueQuan, nycLoaiGiayToTuyThan, nycSoGiayToTuyThan, nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan, nksNgaySinhBangChu" +
                        " FROM QTXLKS where TinhTrangID = 7 " +
                        "and id in (select id from QTXLKS where TinhTrangID = 6) and id in (select id from QTXLKS where TinhTrangID = 5)";


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
                                tt7 = new HT_KHAISINH(dr["ID"].ToString().Trim(),
                                            dr["so"].ToString().Trim(),
                                            dr["quyenSo"].ToString().Trim(),
                                            dr["trangSo"].ToString().Trim(),
                                            dr["ngayDangKy"].ToString().Trim(),
                                            dr["loaiDangKy"].ToString().Trim(),
                                            dr["noiDangKy"].ToString().Trim(),
                                            dr["nksHoTen"].ToString().Trim(),
                                            dr["nksGioiTinh"].ToString().Trim(),
                                            dr["nksNgaySinh"].ToString().Trim(),
                                            dr["nksDanToc"].ToString().Trim(),
                                            dr["nksQuocTich"].ToString().Trim(),
                                            dr["meHoTen"].ToString().Trim(),
                                            dr["meNgaySinh"].ToString().Trim(),
                                            dr["meDanToc"].ToString().Trim(),
                                            dr["meQuocTich"].ToString().Trim(),
                                            dr["meLoaiCuTru"].ToString().Trim(),
                                            dr["chaHoTen"].ToString().Trim(),
                                            dr["chaNgaySinh"].ToString().Trim(),
                                            dr["chaDanToc"].ToString().Trim(),
                                            dr["chaQuocTich"].ToString().Trim(),
                                            dr["chaLoaiCuTru"].ToString().Trim(),
                                            dr["TinhTrangID"].ToString().Trim(),
                                            dr["TenFile"].ToString().Trim(),
                                            dr["TenFileSauUpLoad"].ToString().Trim(),
                                            dr["URLTapTinDinhKem"].ToString().Trim(),
                                            dr["NamMoSo"].ToString().Trim(),
                                            dr["DuLieuCu"].ToString().Trim(),
                                            dr["NgayCapNhat"].ToString().Trim(),
                                            dr["LoaiGiay"].ToString().Trim(),
                                            dr["URLAnhCu"].ToString().Trim(),
                                            dr["GhiChu"].ToString().Trim(),
                                            dr["nksNoiSinh"].ToString().Trim(),
                                            dr["meNoiCuTru"].ToString().Trim(),
                                            dr["chaNoiCuTru"].ToString().Trim(),
                                            dr["nycHoTen"].ToString().Trim(),
                                            dr["nycQuanHe"].ToString().Trim(),
                                            dr["nguoiKy"].ToString().Trim(),
                                            dr["chucVuNguoiKy"].ToString().Trim(),
                                            dr["NguoiThucHien"].ToString().Trim(),
                                            dr["nksLoaiKhaiSinh"].ToString().Trim(),
                                            dr["nksNoiSinhDVHC"].ToString().Trim(),
                                            dr["nksQueQuan"].ToString().Trim(),
                                            dr["nycLoaiGiayToTuyThan"].ToString().Trim(),
                                            dr["nycSoGiayToTuyThan"].ToString().Trim(),
                                            dr["nycNgayCapGiayToTuyThan"].ToString().Trim(),
                                            dr["nycNoiCapGiayToTuyThan"].ToString().Trim(),
                                            dr["nksNgaySinhBangChu"].ToString().Trim());
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
                                tt6 = new HT_KHAISINH(dr["ID"].ToString().Trim(),
                                                    dr["so"].ToString().Trim(),
                                                    dr["quyenSo"].ToString().Trim(),
                                                    dr["trangSo"].ToString().Trim(),
                                                    dr["ngayDangKy"].ToString().Trim(),
                                                    dr["loaiDangKy"].ToString().Trim(),
                                                    dr["noiDangKy"].ToString().Trim(),
                                                    dr["nksHoTen"].ToString().Trim(),
                                                    dr["nksGioiTinh"].ToString().Trim(),
                                                    dr["nksNgaySinh"].ToString().Trim(),
                                                    dr["nksDanToc"].ToString().Trim(),
                                                    dr["nksQuocTich"].ToString().Trim(),
                                                    dr["meHoTen"].ToString().Trim(),
                                                    dr["meNgaySinh"].ToString().Trim(),
                                                    dr["meDanToc"].ToString().Trim(),
                                                    dr["meQuocTich"].ToString().Trim(),
                                                    dr["meLoaiCuTru"].ToString().Trim(),
                                                    dr["chaHoTen"].ToString().Trim(),
                                                    dr["chaNgaySinh"].ToString().Trim(),
                                                    dr["chaDanToc"].ToString().Trim(),
                                                    dr["chaQuocTich"].ToString().Trim(),
                                                    dr["chaLoaiCuTru"].ToString().Trim(),
                                                    dr["TinhTrangID"].ToString().Trim(),
                                                    dr["TenFile"].ToString().Trim(),
                                                    dr["TenFileSauUpLoad"].ToString().Trim(),
                                                    dr["URLTapTinDinhKem"].ToString().Trim(),
                                                    dr["NamMoSo"].ToString().Trim(),
                                                    dr["DuLieuCu"].ToString().Trim(),
                                                    dr["NgayCapNhat"].ToString().Trim(),
                                                    dr["LoaiGiay"].ToString().Trim(),
                                                    dr["URLAnhCu"].ToString().Trim(),
                                                    dr["GhiChu"].ToString().Trim(),
                                                    dr["nksNoiSinh"].ToString().Trim(),
                                                    dr["meNoiCuTru"].ToString().Trim(),
                                                    dr["chaNoiCuTru"].ToString().Trim(),
                                                    dr["nycHoTen"].ToString().Trim(),
                                                    dr["nycQuanHe"].ToString().Trim(),
                                                    dr["nguoiKy"].ToString().Trim(),
                                                    dr["chucVuNguoiKy"].ToString().Trim(),
                                                    dr["NguoiThucHien"].ToString().Trim(),
                                                    dr["nksLoaiKhaiSinh"].ToString().Trim(),
                                                    dr["nksNoiSinhDVHC"].ToString().Trim(),
                                                    dr["nksQueQuan"].ToString().Trim(),
                                                    dr["nycLoaiGiayToTuyThan"].ToString().Trim(),
                                                    dr["nycSoGiayToTuyThan"].ToString().Trim(),
                                                    dr["nycNgayCapGiayToTuyThan"].ToString().Trim(),
                                                    dr["nycNoiCapGiayToTuyThan"].ToString().Trim(),
                                                    dr["nksNgaySinhBangChu"].ToString().Trim());
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
                                tt5 = new HT_KHAISINH(dr["ID"].ToString().Trim(),
                                            dr["so"].ToString().Trim(),
                                            dr["quyenSo"].ToString().Trim(),
                                            dr["trangSo"].ToString().Trim(),
                                            dr["ngayDangKy"].ToString().Trim(),
                                            dr["loaiDangKy"].ToString().Trim(),
                                            dr["noiDangKy"].ToString().Trim(),
                                            dr["nksHoTen"].ToString().Trim(),
                                            dr["nksGioiTinh"].ToString().Trim(),
                                            dr["nksNgaySinh"].ToString().Trim(),
                                            dr["nksDanToc"].ToString().Trim(),
                                            dr["nksQuocTich"].ToString().Trim(),
                                            dr["meHoTen"].ToString().Trim(),
                                            dr["meNgaySinh"].ToString().Trim(),
                                            dr["meDanToc"].ToString().Trim(),
                                            dr["meQuocTich"].ToString().Trim(),
                                            dr["meLoaiCuTru"].ToString().Trim(),
                                            dr["chaHoTen"].ToString().Trim(),
                                            dr["chaNgaySinh"].ToString().Trim(),
                                            dr["chaDanToc"].ToString().Trim(),
                                            dr["chaQuocTich"].ToString().Trim(),
                                            dr["chaLoaiCuTru"].ToString().Trim(),
                                            dr["TinhTrangID"].ToString().Trim(),
                                            dr["TenFile"].ToString().Trim(),
                                            dr["TenFileSauUpLoad"].ToString().Trim(),
                                            dr["URLTapTinDinhKem"].ToString().Trim(),
                                            dr["NamMoSo"].ToString().Trim(),
                                            dr["DuLieuCu"].ToString().Trim(),
                                            dr["NgayCapNhat"].ToString().Trim(),
                                            dr["LoaiGiay"].ToString().Trim(),
                                            dr["URLAnhCu"].ToString().Trim(),
                                            dr["GhiChu"].ToString().Trim(),
                                            dr["nksNoiSinh"].ToString().Trim(),
                                            dr["meNoiCuTru"].ToString().Trim(),
                                            dr["chaNoiCuTru"].ToString().Trim(),
                                            dr["nycHoTen"].ToString().Trim(),
                                            dr["nycQuanHe"].ToString().Trim(),
                                            dr["nguoiKy"].ToString().Trim(),
                                            dr["chucVuNguoiKy"].ToString().Trim(),
                                            dr["NguoiThucHien"].ToString().Trim(),
                                            dr["nksLoaiKhaiSinh"].ToString().Trim(),
                                            dr["nksNoiSinhDVHC"].ToString().Trim(),
                                            dr["nksQueQuan"].ToString().Trim(),
                                            dr["nycLoaiGiayToTuyThan"].ToString().Trim(),
                                            dr["nycSoGiayToTuyThan"].ToString().Trim(),
                                            dr["nycNgayCapGiayToTuyThan"].ToString().Trim(),
                                            dr["nycNoiCapGiayToTuyThan"].ToString().Trim(),
                                            dr["nksNgaySinhBangChu"].ToString().Trim());
                            }
                            con.Close();
                        }

                        //so sánh 2 trạng thái nếu khác nhau thì so sánh từng cột 1 để lưu vào db
                        if (!tt7.Equals(tt6)||!tt7.Equals(tt5))
                        {
                            List<Diff> listDiff = new List<Diff>();

                            Type type = (new HT_KHAISINH()).GetType();

                            //lấy value theo tên thuộc tính (có get set)
                            foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                            {
                                MessageBox.Show(property.Name + "");
                                if (!tt7.GetType().GetProperty(property.Name).GetValue(tt7, null).Equals(tt6.GetType().GetProperty(property.Name).GetValue(tt6, null)))
                                    if (!property.Name.Equals("TinhTrangID1")) 
                                        addListDiffKS(listDiff, tt7, tt6, tt5, property.Name);
                            }

                            foreach (Diff diff in listDiff)
                            {
                                SqlConnection conn = new SqlConnection(Home.sqlConnect);
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("use HoTich; if(select count(*) from Diff " +
                                    "where id = '" + diff.id + "' and so = '" + diff.so + "' and quyenSo = '" + diff.quyenSo + "' and noiDangKy = '" + diff.noiDangKy + "' " +
                                    "and ngayDangKy = '" + diff.ngayDangKy + "' and tableName = '" + diff.tableName + "' and columnName = '" + diff.columnName + "' " +
                                    "and ktbm1 = '" + diff.ktbm1 + "' and ktbm2 = '" + diff.ktbm2 + "' and kt = '" + diff.kt + "') = 0 insert into Diff values('" + diff.id + "', '" + diff.so + "', '" + diff.quyenSo + "'," +
                                    "'" + diff.noiDangKy + "', '" + diff.ngayDangKy + "', '" + diff.tableName + "', '" + diff.columnName + "', '" + diff.ktbm1 + "'," +
                                    "'" + diff.ktbm2 + "','" + diff.kt + "')", conn);
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                        }

                    }

                    MessageBox.Show("Đã xử lý xong KS", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            });
            threadXuLyKS.Start();

            //thread xử lý KT
            Thread threadXuLyKT = new Thread(() =>
            {
                using (SqlConnection con = new SqlConnection(Home.sqlConnect))
                {
                    HT_KHAITU tt7 = null, tt6 = null, tt5 = null;
                    List<string> listDayDu3TrangThai = new List<string>();

                    string str = " SELECT ID, So, quyenSo, trangSo, ngayDangKy, loaiDangKy, noiDangKy, nktHoTen, nktGioiTinh, nktNgaySinh, nktDanToc, nktQuocTich, nktLoaiCuTru, nktLoaiGiayToTuyThan, nktSoGiayToTuyThan, nktNgayChet, TinhTrangID, TenFile, TenFileSauUpload, URLTapTinDinhKem, NamMoSo, LoaiGiay, DuLieuCu, NgayCapNhat, urlAnhCu, GhiChu, nktGioPhutChet, nktNoiChet, nktNguyenNhanChet, nktNoiCuTru, nycHoTen, nycQuanHe, nguoiKy, chucVuNguoiKy, nguoiThucHien, nktNgayCapGiayToTuyThan, nktNoiCapGiayToTuyThan, gbtLoai, gbtSo, gbtNgay, gbtCoQuanCap, nycLoaiGiayToTuyThan, nycSoGiayToTuyThan, nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan" +
                        " FROM QTXLKT where TinhTrangID = 7 " +
                        "and id in (select id from QTXLKT where TinhTrangID = 6) and id in (select id from QTXLKT where TinhTrangID = 5)";


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
                                tt7 = new HT_KHAITU(dr["ID"].ToString().Trim(),
                                                        dr["So"].ToString().Trim(),
                                                        dr["quyenSo"].ToString().Trim(),
                                                        dr["trangSo"].ToString().Trim(),
                                                        dr["ngayDangKy"].ToString().Trim(),
                                                        dr["loaiDangKy"].ToString().Trim(),
                                                        dr["noiDangKy"].ToString().Trim(),
                                                        dr["nktHoTen"].ToString().Trim(),
                                                        dr["nktGioiTinh"].ToString().Trim(),
                                                        dr["nktNgaySinh"].ToString().Trim(),
                                                        dr["nktDanToc"].ToString().Trim(),
                                                        dr["nktQuocTich"].ToString().Trim(),
                                                        dr["nktLoaiCuTru"].ToString().Trim(),
                                                        dr["nktLoaiGiayToTuyThan"].ToString().Trim(),
                                                        dr["nktSoGiayToTuyThan"].ToString().Trim(),
                                                        dr["nktNgayChet"].ToString().Trim(),
                                                        dr["TinhTrangID"].ToString().Trim(),
                                                        dr["TenFile"].ToString().Trim(),
                                                        dr["TenFileSauUpload"].ToString().Trim(),
                                                        dr["URLTapTinDinhKem"].ToString().Trim(),
                                                        dr["NamMoSo"].ToString().Trim(),
                                                        dr["LoaiGiay"].ToString().Trim(),
                                                        dr["DuLieuCu"].ToString().Trim(),
                                                        dr["NgayCapNhat"].ToString().Trim(),
                                                        dr["urlAnhCu"].ToString().Trim(),
                                                        dr["GhiChu"].ToString().Trim(),
                                                        dr["nktGioPhutChet"].ToString().Trim(),
                                                        dr["nktNoiChet"].ToString().Trim(),
                                                        dr["nktNguyenNhanChet"].ToString().Trim(),
                                                        dr["nktNoiCuTru"].ToString().Trim(),
                                                        dr["nycHoTen"].ToString().Trim(),
                                                        dr["nycQuanHe"].ToString().Trim(),
                                                        dr["nguoiKy"].ToString().Trim(),
                                                        dr["chucVuNguoiKy"].ToString().Trim(),
                                                        dr["nguoiThucHien"].ToString().Trim(),
                                                        dr["nktNgayCapGiayToTuyThan"].ToString().Trim(),
                                                        dr["nktNoiCapGiayToTuyThan"].ToString().Trim(),
                                                        dr["gbtLoai"].ToString().Trim(),
                                                        dr["gbtSo"].ToString().Trim(),
                                                        dr["gbtNgay"].ToString().Trim(),
                                                        dr["gbtCoQuanCap"].ToString().Trim(),
                                                        dr["nycLoaiGiayToTuyThan"].ToString().Trim(),
                                                        dr["nycSoGiayToTuyThan"].ToString().Trim(),
                                                        dr["nycNgayCapGiayToTuyThan"].ToString().Trim(),
                                                        dr["nycNoiCapGiayToTuyThan"].ToString().Trim());
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
                                tt6 = new HT_KHAITU(dr["ID"].ToString().Trim(),
                                                        dr["So"].ToString().Trim(),
                                                        dr["quyenSo"].ToString().Trim(),
                                                        dr["trangSo"].ToString().Trim(),
                                                        dr["ngayDangKy"].ToString().Trim(),
                                                        dr["loaiDangKy"].ToString().Trim(),
                                                        dr["noiDangKy"].ToString().Trim(),
                                                        dr["nktHoTen"].ToString().Trim(),
                                                        dr["nktGioiTinh"].ToString().Trim(),
                                                        dr["nktNgaySinh"].ToString().Trim(),
                                                        dr["nktDanToc"].ToString().Trim(),
                                                        dr["nktQuocTich"].ToString().Trim(),
                                                        dr["nktLoaiCuTru"].ToString().Trim(),
                                                        dr["nktLoaiGiayToTuyThan"].ToString().Trim(),
                                                        dr["nktSoGiayToTuyThan"].ToString().Trim(),
                                                        dr["nktNgayChet"].ToString().Trim(),
                                                        dr["TinhTrangID"].ToString().Trim(),
                                                        dr["TenFile"].ToString().Trim(),
                                                        dr["TenFileSauUpload"].ToString().Trim(),
                                                        dr["URLTapTinDinhKem"].ToString().Trim(),
                                                        dr["NamMoSo"].ToString().Trim(),
                                                        dr["LoaiGiay"].ToString().Trim(),
                                                        dr["DuLieuCu"].ToString().Trim(),
                                                        dr["NgayCapNhat"].ToString().Trim(),
                                                        dr["urlAnhCu"].ToString().Trim(),
                                                        dr["GhiChu"].ToString().Trim(),
                                                        dr["nktGioPhutChet"].ToString().Trim(),
                                                        dr["nktNoiChet"].ToString().Trim(),
                                                        dr["nktNguyenNhanChet"].ToString().Trim(),
                                                        dr["nktNoiCuTru"].ToString().Trim(),
                                                        dr["nycHoTen"].ToString().Trim(),
                                                        dr["nycQuanHe"].ToString().Trim(),
                                                        dr["nguoiKy"].ToString().Trim(),
                                                        dr["chucVuNguoiKy"].ToString().Trim(),
                                                        dr["nguoiThucHien"].ToString().Trim(),
                                                        dr["nktNgayCapGiayToTuyThan"].ToString().Trim(),
                                                        dr["nktNoiCapGiayToTuyThan"].ToString().Trim(),
                                                        dr["gbtLoai"].ToString().Trim(),
                                                        dr["gbtSo"].ToString().Trim(),
                                                        dr["gbtNgay"].ToString().Trim(),
                                                        dr["gbtCoQuanCap"].ToString().Trim(),
                                                        dr["nycLoaiGiayToTuyThan"].ToString().Trim(),
                                                        dr["nycSoGiayToTuyThan"].ToString().Trim(),
                                                        dr["nycNgayCapGiayToTuyThan"].ToString().Trim(),
                                                        dr["nycNoiCapGiayToTuyThan"].ToString().Trim());
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
                                tt5 = new HT_KHAITU(dr["ID"].ToString().Trim(),
                                                        dr["So"].ToString().Trim(),
                                                        dr["quyenSo"].ToString().Trim(),
                                                        dr["trangSo"].ToString().Trim(),
                                                        dr["ngayDangKy"].ToString().Trim(),
                                                        dr["loaiDangKy"].ToString().Trim(),
                                                        dr["noiDangKy"].ToString().Trim(),
                                                        dr["nktHoTen"].ToString().Trim(),
                                                        dr["nktGioiTinh"].ToString().Trim(),
                                                        dr["nktNgaySinh"].ToString().Trim(),
                                                        dr["nktDanToc"].ToString().Trim(),
                                                        dr["nktQuocTich"].ToString().Trim(),
                                                        dr["nktLoaiCuTru"].ToString().Trim(),
                                                        dr["nktLoaiGiayToTuyThan"].ToString().Trim(),
                                                        dr["nktSoGiayToTuyThan"].ToString().Trim(),
                                                        dr["nktNgayChet"].ToString().Trim(),
                                                        dr["TinhTrangID"].ToString().Trim(),
                                                        dr["TenFile"].ToString().Trim(),
                                                        dr["TenFileSauUpload"].ToString().Trim(),
                                                        dr["URLTapTinDinhKem"].ToString().Trim(),
                                                        dr["NamMoSo"].ToString().Trim(),
                                                        dr["LoaiGiay"].ToString().Trim(),
                                                        dr["DuLieuCu"].ToString().Trim(),
                                                        dr["NgayCapNhat"].ToString().Trim(),
                                                        dr["urlAnhCu"].ToString().Trim(),
                                                        dr["GhiChu"].ToString().Trim(),
                                                        dr["nktGioPhutChet"].ToString().Trim(),
                                                        dr["nktNoiChet"].ToString().Trim(),
                                                        dr["nktNguyenNhanChet"].ToString().Trim(),
                                                        dr["nktNoiCuTru"].ToString().Trim(),
                                                        dr["nycHoTen"].ToString().Trim(),
                                                        dr["nycQuanHe"].ToString().Trim(),
                                                        dr["nguoiKy"].ToString().Trim(),
                                                        dr["chucVuNguoiKy"].ToString().Trim(),
                                                        dr["nguoiThucHien"].ToString().Trim(),
                                                        dr["nktNgayCapGiayToTuyThan"].ToString().Trim(),
                                                        dr["nktNoiCapGiayToTuyThan"].ToString().Trim(),
                                                        dr["gbtLoai"].ToString().Trim(),
                                                        dr["gbtSo"].ToString().Trim(),
                                                        dr["gbtNgay"].ToString().Trim(),
                                                        dr["gbtCoQuanCap"].ToString().Trim(),
                                                        dr["nycLoaiGiayToTuyThan"].ToString().Trim(),
                                                        dr["nycSoGiayToTuyThan"].ToString().Trim(),
                                                        dr["nycNgayCapGiayToTuyThan"].ToString().Trim(),
                                                        dr["nycNoiCapGiayToTuyThan"].ToString().Trim());
                            }
                            con.Close();
                        }

                        //so sánh 2 trạng thái nếu khác nhau thì so sánh từng cột 1 để lưu vào db
                        if (!tt7.Equals(tt6))
                        {
                            List<Diff> listDiff = new List<Diff>();

                            Type type = (new HT_KHAITU()).GetType();

                            //lấy value theo tên thuộc tính (có get set)
                            foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                            {
                                MessageBox.Show(property.Name + "");
                                if (!tt7.GetType().GetProperty(property.Name).GetValue(tt7, null).Equals(tt6.GetType().GetProperty(property.Name).GetValue(tt6, null)))
                                    if (!property.Name.Equals("TinhTrangID1"))  
                                        addListDiffKT(listDiff, tt7, tt6, tt5, property.Name);
                            }

                            foreach (Diff diff in listDiff)
                            {
                                SqlConnection conn = new SqlConnection(Home.sqlConnect);
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("use HoTich; if(select count(*) from Diff " +
                                    "where id = '" + diff.id + "' and so = '" + diff.so + "' and quyenSo = '" + diff.quyenSo + "' and noiDangKy = '" + diff.noiDangKy + "' " +
                                    "and ngayDangKy = '" + diff.ngayDangKy + "' and tableName = '" + diff.tableName + "' and columnName = '" + diff.columnName + "' " +
                                    "and ktbm1 = '" + diff.ktbm1 + "' and ktbm2 = '" + diff.ktbm2 + "' and kt = '" + diff.kt + "') = 0 insert into Diff values('" + diff.id + "', '" + diff.so + "', '" + diff.quyenSo + "'," +
                                    "'" + diff.noiDangKy + "', '" + diff.ngayDangKy + "', '" + diff.tableName + "', '" + diff.columnName + "', '" + diff.ktbm1 + "'," +
                                    "'" + diff.ktbm2 + "','" + diff.kt + "')", conn);
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                        }

                    }

                    MessageBox.Show("Đã xử lý xong KT", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            });
            threadXuLyKT.Start();

            //thread xử lý KH
            Thread threadXuLyKH = new Thread(() =>
            {
                using (SqlConnection con = new SqlConnection(Home.sqlConnect))
                {
                    HT_KETHON tt7 = null, tt6 = null, tt5 = null;
                    List<string> listDayDu3TrangThai = new List<string>();

                    string str = " SELECT ID, So, quyenSo, trangSo, ngayDangKy, loaiDangKy, noiDangKy, chongHoTen, chongNgaySinh, chongDanToc, chongQuocTich, chongLoaiCuTru, chongLoaiGiayToTuyThan, chongSoGiayToTuyThan, voHoTen, voNgaySinh, voDanToc, voQuocTich, voLoaiCuTru, voLoaiGiayToTuyThan, voSoGiayToTuyThan, TinhTrangID, TenFile, TenFileSauUpLoad, URLTapTinDinhKem, NamMoSo, LoaiGiay, DuLieuCu, NgayCapNhat, urlAnhCu, GhiChu, chongNoiCuTru, voNoiCuTru, nguoiKy, chucVuNguoiKy, nguoiThucHien, chongNgayCapGiayToTuyThan, chongNoiCapGiayToTuyThan, voNgayCapGiayToTuyThan, voNoiCapGiayToTuyThan" +
                        " FROM QTXLKH where TinhTrangID = 7 " +
                        "and id in (select id from QTXLKH where TinhTrangID = 6) and id in (select id from QTXLKH where TinhTrangID = 5)";


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
                                tt7 = new HT_KETHON(dr["ID"].ToString().Trim(),
                                                        dr["So"].ToString().Trim(),
                                                        dr["quyenSo"].ToString().Trim(),
                                                        dr["trangSo"].ToString().Trim(),
                                                        dr["ngayDangKy"].ToString().Trim(),
                                                        dr["loaiDangKy"].ToString().Trim(),
                                                        dr["noiDangKy"].ToString().Trim(),
                                                        dr["chongHoTen"].ToString().Trim(),
                                                        dr["chongNgaySinh"].ToString().Trim(),
                                                        dr["chongDanToc"].ToString().Trim(),
                                                        dr["chongQuocTich"].ToString().Trim(),
                                                        dr["chongLoaiCuTru"].ToString().Trim(),
                                                        dr["chongLoaiGiayToTuyThan"].ToString().Trim(),
                                                        dr["chongSoGiayToTuyThan"].ToString().Trim(),
                                                        dr["voHoTen"].ToString().Trim(),
                                                        dr["voNgaySinh"].ToString().Trim(),
                                                        dr["voDanToc"].ToString().Trim(),
                                                        dr["voQuocTich"].ToString().Trim(),
                                                        dr["voLoaiCuTru"].ToString().Trim(),
                                                        dr["voLoaiGiayToTuyThan"].ToString().Trim(),
                                                        dr["voSoGiayToTuyThan"].ToString().Trim(),
                                                        dr["TinhTrangID"].ToString().Trim(),
                                                        dr["TenFile"].ToString().Trim(),
                                                        dr["TenFileSauUpLoad"].ToString().Trim(),
                                                        dr["URLTapTinDinhKem"].ToString().Trim(),
                                                        dr["NamMoSo"].ToString().Trim(),
                                                        dr["LoaiGiay"].ToString().Trim(),
                                                        dr["DuLieuCu"].ToString().Trim(),
                                                        dr["NgayCapNhat"].ToString().Trim(),
                                                        dr["urlAnhCu"].ToString().Trim(),
                                                        dr["GhiChu"].ToString().Trim(),
                                                        dr["chongNoiCuTru"].ToString().Trim(),
                                                        dr["voNoiCuTru"].ToString().Trim(),
                                                        dr["nguoiKy"].ToString().Trim(),
                                                        dr["chucVuNguoiKy"].ToString().Trim(),
                                                        dr["nguoiThucHien"].ToString().Trim(),
                                                        dr["chongNgayCapGiayToTuyThan"].ToString().Trim(),
                                                        dr["chongNoiCapGiayToTuyThan"].ToString().Trim(),
                                                        dr["voNgayCapGiayToTuyThan"].ToString().Trim(),
                                                        dr["voNoiCapGiayToTuyThan"].ToString().Trim());
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
                                tt6 = new HT_KETHON(dr["ID"].ToString().Trim(),
                                                        dr["So"].ToString().Trim(),
                                                        dr["quyenSo"].ToString().Trim(),
                                                        dr["trangSo"].ToString().Trim(),
                                                        dr["ngayDangKy"].ToString().Trim(),
                                                        dr["loaiDangKy"].ToString().Trim(),
                                                        dr["noiDangKy"].ToString().Trim(),
                                                        dr["chongHoTen"].ToString().Trim(),
                                                        dr["chongNgaySinh"].ToString().Trim(),
                                                        dr["chongDanToc"].ToString().Trim(),
                                                        dr["chongQuocTich"].ToString().Trim(),
                                                        dr["chongLoaiCuTru"].ToString().Trim(),
                                                        dr["chongLoaiGiayToTuyThan"].ToString().Trim(),
                                                        dr["chongSoGiayToTuyThan"].ToString().Trim(),
                                                        dr["voHoTen"].ToString().Trim(),
                                                        dr["voNgaySinh"].ToString().Trim(),
                                                        dr["voDanToc"].ToString().Trim(),
                                                        dr["voQuocTich"].ToString().Trim(),
                                                        dr["voLoaiCuTru"].ToString().Trim(),
                                                        dr["voLoaiGiayToTuyThan"].ToString().Trim(),
                                                        dr["voSoGiayToTuyThan"].ToString().Trim(),
                                                        dr["TinhTrangID"].ToString().Trim(),
                                                        dr["TenFile"].ToString().Trim(),
                                                        dr["TenFileSauUpLoad"].ToString().Trim(),
                                                        dr["URLTapTinDinhKem"].ToString().Trim(),
                                                        dr["NamMoSo"].ToString().Trim(),
                                                        dr["LoaiGiay"].ToString().Trim(),
                                                        dr["DuLieuCu"].ToString().Trim(),
                                                        dr["NgayCapNhat"].ToString().Trim(),
                                                        dr["urlAnhCu"].ToString().Trim(),
                                                        dr["GhiChu"].ToString().Trim(),
                                                        dr["chongNoiCuTru"].ToString().Trim(),
                                                        dr["voNoiCuTru"].ToString().Trim(),
                                                        dr["nguoiKy"].ToString().Trim(),
                                                        dr["chucVuNguoiKy"].ToString().Trim(),
                                                        dr["nguoiThucHien"].ToString().Trim(),
                                                        dr["chongNgayCapGiayToTuyThan"].ToString().Trim(),
                                                        dr["chongNoiCapGiayToTuyThan"].ToString().Trim(),
                                                        dr["voNgayCapGiayToTuyThan"].ToString().Trim(),
                                                        dr["voNoiCapGiayToTuyThan"].ToString().Trim());
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
                                tt5 = new HT_KETHON(dr["ID"].ToString().Trim(),
                                                        dr["So"].ToString().Trim(),
                                                        dr["quyenSo"].ToString().Trim(),
                                                        dr["trangSo"].ToString().Trim(),
                                                        dr["ngayDangKy"].ToString().Trim(),
                                                        dr["loaiDangKy"].ToString().Trim(),
                                                        dr["noiDangKy"].ToString().Trim(),
                                                        dr["chongHoTen"].ToString().Trim(),
                                                        dr["chongNgaySinh"].ToString().Trim(),
                                                        dr["chongDanToc"].ToString().Trim(),
                                                        dr["chongQuocTich"].ToString().Trim(),
                                                        dr["chongLoaiCuTru"].ToString().Trim(),
                                                        dr["chongLoaiGiayToTuyThan"].ToString().Trim(),
                                                        dr["chongSoGiayToTuyThan"].ToString().Trim(),
                                                        dr["voHoTen"].ToString().Trim(),
                                                        dr["voNgaySinh"].ToString().Trim(),
                                                        dr["voDanToc"].ToString().Trim(),
                                                        dr["voQuocTich"].ToString().Trim(),
                                                        dr["voLoaiCuTru"].ToString().Trim(),
                                                        dr["voLoaiGiayToTuyThan"].ToString().Trim(),
                                                        dr["voSoGiayToTuyThan"].ToString().Trim(),
                                                        dr["TinhTrangID"].ToString().Trim(),
                                                        dr["TenFile"].ToString().Trim(),
                                                        dr["TenFileSauUpLoad"].ToString().Trim(),
                                                        dr["URLTapTinDinhKem"].ToString().Trim(),
                                                        dr["NamMoSo"].ToString().Trim(),
                                                        dr["LoaiGiay"].ToString().Trim(),
                                                        dr["DuLieuCu"].ToString().Trim(),
                                                        dr["NgayCapNhat"].ToString().Trim(),
                                                        dr["urlAnhCu"].ToString().Trim(),
                                                        dr["GhiChu"].ToString().Trim(),
                                                        dr["chongNoiCuTru"].ToString().Trim(),
                                                        dr["voNoiCuTru"].ToString().Trim(),
                                                        dr["nguoiKy"].ToString().Trim(),
                                                        dr["chucVuNguoiKy"].ToString().Trim(),
                                                        dr["nguoiThucHien"].ToString().Trim(),
                                                        dr["chongNgayCapGiayToTuyThan"].ToString().Trim(),
                                                        dr["chongNoiCapGiayToTuyThan"].ToString().Trim(),
                                                        dr["voNgayCapGiayToTuyThan"].ToString().Trim(),
                                                        dr["voNoiCapGiayToTuyThan"].ToString().Trim());
                            }
                            con.Close();
                        }

                        //so sánh 2 trạng thái nếu khác nhau thì so sánh từng cột 1 để lưu vào db
                        if (!tt7.Equals(tt6))
                        {
                            List<Diff> listDiff = new List<Diff>();

                            Type type = (new HT_KETHON()).GetType();

                            //lấy value theo tên thuộc tính (có get set)
                            foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                            {
                                MessageBox.Show(property.Name + "");
                                if (!tt7.GetType().GetProperty(property.Name).GetValue(tt7, null).Equals(tt6.GetType().GetProperty(property.Name).GetValue(tt6, null)))
                                    if (!property.Name.Equals("TinhTrangID1"))  
                                        addListDiffKH(listDiff, tt7, tt6, tt5, property.Name);
                            }

                            foreach (Diff diff in listDiff)
                            {
                                SqlConnection conn = new SqlConnection(Home.sqlConnect);
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("use HoTich; if(select count(*) from Diff " +
                                    "where id = '" + diff.id + "' and so = '" + diff.so + "' and quyenSo = '" + diff.quyenSo + "' and noiDangKy = '" + diff.noiDangKy + "' " +
                                    "and ngayDangKy = '" + diff.ngayDangKy + "' and tableName = '" + diff.tableName + "' and columnName = '" + diff.columnName + "' " +
                                    "and ktbm1 = '" + diff.ktbm1 + "' and ktbm2 = '" + diff.ktbm2 + "' and kt = '" + diff.kt + "') = 0 insert into Diff values('" + diff.id + "', '" + diff.so + "', '" + diff.quyenSo + "'," +
                                    "'" + diff.noiDangKy + "', '" + diff.ngayDangKy + "', '" + diff.tableName + "', '" + diff.columnName + "', '" + diff.ktbm1 + "'," +
                                    "'" + diff.ktbm2 + "','" + diff.kt + "')", conn);
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                        }

                    }

                    MessageBox.Show("Đã xử lý xong KH", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            });
            threadXuLyKH.Start();

            //thread xử lý CMC
            Thread threadXuLyCMC = new Thread(() =>
            {
                using (SqlConnection con = new SqlConnection(Home.sqlConnect))
                {
                    HT_NHANCHAMECON tt7 = null, tt6 = null, tt5 = null;
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
                        "and id in (select id from QTXLCMC where TinhTrangID = 6) and id in (select id from QTXLCMC where TinhTrangID = 5)";


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
                                tt7 = new HT_NHANCHAMECON(dr["ID"].ToString().Trim(),
                                                        dr["So"].ToString().Trim(),
                                                        dr["quyenSo"].ToString().Trim(),
                                                        dr["trangSo"].ToString().Trim(),
                                                        dr["quyetDinhSo"].ToString().Trim(),
                                                        dr["ngayDangKy"].ToString().Trim(),
                                                        dr["loaiDangKy"].ToString().Trim(),
                                                        dr["loaiXacNhan"].ToString().Trim(),
                                                        dr["noiDangKy"].ToString().Trim(),
                                                        dr["cmHoTen"].ToString().Trim(),
                                                        dr["cmNgaySinh"].ToString().Trim(),
                                                        dr["cmDanToc"].ToString().Trim(),
                                                        dr["cmQuocTich"].ToString().Trim(),
                                                        dr["cmLoaiCuTru"].ToString().Trim(),
                                                        dr["cmLoaiGiayToTuyThan"].ToString().Trim(),
                                                        dr["cmSoGiayToTuyThan"].ToString().Trim(),
                                                        dr["ncHoTen"].ToString().Trim(),
                                                        dr["ncNgaySinh"].ToString().Trim(),
                                                        dr["ncDanToc"].ToString().Trim(),
                                                        dr["ncQuocTich"].ToString().Trim(),
                                                        dr["ncLoaiCuTru"].ToString().Trim(),
                                                        dr["ncLoaiGiayToTuyThan"].ToString().Trim(),
                                                        dr["ncSoGiayToTuyThan"].ToString().Trim(),
                                                        dr["TinhTrangID"].ToString().Trim(),
                                                        dr["TenFile"].ToString().Trim(),
                                                        dr["TenFileSauUpload"].ToString().Trim(),
                                                        dr["URLTapTinDinhKem"].ToString().Trim(),
                                                        dr["NamMoSo"].ToString().Trim(),
                                                        dr["LoaiGiay"].ToString().Trim(),
                                                        dr["DuLieuCu"].ToString().Trim(),
                                                        dr["NgayCapNhat"].ToString().Trim(),
                                                        dr["GhiChu"].ToString().Trim(),
                                                        dr["cmNoiCuTru"].ToString().Trim(),
                                                        dr["ncNoiCuTru"].ToString().Trim(),
                                                        dr["nycHoTen"].ToString().Trim(),
                                                        dr["nycQHNguoiDuocNhan"].ToString().Trim(),
                                                        dr["nguoiKy"].ToString().Trim(),
                                                        dr["chucVuNguoiKy"].ToString().Trim(),
                                                        dr["nguoiThucHien"].ToString().Trim(),
                                                        dr["cmQueQuan"].ToString().Trim(),
                                                        dr["cmNgayCapGiayToTuyThan"].ToString().Trim(),
                                                        dr["cmNoiCapGiayToTuyThan"].ToString().Trim(),
                                                        dr["ncQueQuan"].ToString().Trim(),
                                                        dr["ncNgayCapGiayToTuyThan"].ToString().Trim(),
                                                        dr["ncNoiCapGiayToTuyThan"].ToString().Trim(),
                                                        dr["nycLoaiGiayToTuyThan"].ToString().Trim(),
                                                        dr["nycSoGiayToTuyThan"].ToString().Trim(),
                                                        dr["nycNgayCapGiayToTuyThan"].ToString().Trim(),
                                                        dr["nycNoiCapGiayToTuyThan"].ToString().Trim());
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
                                tt6 = new HT_NHANCHAMECON(dr["ID"].ToString().Trim(),
                                                        dr["So"].ToString().Trim(),
                                                        dr["quyenSo"].ToString().Trim(),
                                                        dr["trangSo"].ToString().Trim(),
                                                        dr["quyetDinhSo"].ToString().Trim(),
                                                        dr["ngayDangKy"].ToString().Trim(),
                                                        dr["loaiDangKy"].ToString().Trim(),
                                                        dr["loaiXacNhan"].ToString().Trim(),
                                                        dr["noiDangKy"].ToString().Trim(),
                                                        dr["cmHoTen"].ToString().Trim(),
                                                        dr["cmNgaySinh"].ToString().Trim(),
                                                        dr["cmDanToc"].ToString().Trim(),
                                                        dr["cmQuocTich"].ToString().Trim(),
                                                        dr["cmLoaiCuTru"].ToString().Trim(),
                                                        dr["cmLoaiGiayToTuyThan"].ToString().Trim(),
                                                        dr["cmSoGiayToTuyThan"].ToString().Trim(),
                                                        dr["ncHoTen"].ToString().Trim(),
                                                        dr["ncNgaySinh"].ToString().Trim(),
                                                        dr["ncDanToc"].ToString().Trim(),
                                                        dr["ncQuocTich"].ToString().Trim(),
                                                        dr["ncLoaiCuTru"].ToString().Trim(),
                                                        dr["ncLoaiGiayToTuyThan"].ToString().Trim(),
                                                        dr["ncSoGiayToTuyThan"].ToString().Trim(),
                                                        dr["TinhTrangID"].ToString().Trim(),
                                                        dr["TenFile"].ToString().Trim(),
                                                        dr["TenFileSauUpload"].ToString().Trim(),
                                                        dr["URLTapTinDinhKem"].ToString().Trim(),
                                                        dr["NamMoSo"].ToString().Trim(),
                                                        dr["LoaiGiay"].ToString().Trim(),
                                                        dr["DuLieuCu"].ToString().Trim(),
                                                        dr["NgayCapNhat"].ToString().Trim(),
                                                        dr["GhiChu"].ToString().Trim(),
                                                        dr["cmNoiCuTru"].ToString().Trim(),
                                                        dr["ncNoiCuTru"].ToString().Trim(),
                                                        dr["nycHoTen"].ToString().Trim(),
                                                        dr["nycQHNguoiDuocNhan"].ToString().Trim(),
                                                        dr["nguoiKy"].ToString().Trim(),
                                                        dr["chucVuNguoiKy"].ToString().Trim(),
                                                        dr["nguoiThucHien"].ToString().Trim(),
                                                        dr["cmQueQuan"].ToString().Trim(),
                                                        dr["cmNgayCapGiayToTuyThan"].ToString().Trim(),
                                                        dr["cmNoiCapGiayToTuyThan"].ToString().Trim(),
                                                        dr["ncQueQuan"].ToString().Trim(),
                                                        dr["ncNgayCapGiayToTuyThan"].ToString().Trim(),
                                                        dr["ncNoiCapGiayToTuyThan"].ToString().Trim(),
                                                        dr["nycLoaiGiayToTuyThan"].ToString().Trim(),
                                                        dr["nycSoGiayToTuyThan"].ToString().Trim(),
                                                        dr["nycNgayCapGiayToTuyThan"].ToString().Trim(),
                                                        dr["nycNoiCapGiayToTuyThan"].ToString().Trim());
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
                                tt5 = new HT_NHANCHAMECON(dr["ID"].ToString().Trim(),
                                                        dr["So"].ToString().Trim(),
                                                        dr["quyenSo"].ToString().Trim(),
                                                        dr["trangSo"].ToString().Trim(),
                                                        dr["quyetDinhSo"].ToString().Trim(),
                                                        dr["ngayDangKy"].ToString().Trim(),
                                                        dr["loaiDangKy"].ToString().Trim(),
                                                        dr["loaiXacNhan"].ToString().Trim(),
                                                        dr["noiDangKy"].ToString().Trim(),
                                                        dr["cmHoTen"].ToString().Trim(),
                                                        dr["cmNgaySinh"].ToString().Trim(),
                                                        dr["cmDanToc"].ToString().Trim(),
                                                        dr["cmQuocTich"].ToString().Trim(),
                                                        dr["cmLoaiCuTru"].ToString().Trim(),
                                                        dr["cmLoaiGiayToTuyThan"].ToString().Trim(),
                                                        dr["cmSoGiayToTuyThan"].ToString().Trim(),
                                                        dr["ncHoTen"].ToString().Trim(),
                                                        dr["ncNgaySinh"].ToString().Trim(),
                                                        dr["ncDanToc"].ToString().Trim(),
                                                        dr["ncQuocTich"].ToString().Trim(),
                                                        dr["ncLoaiCuTru"].ToString().Trim(),
                                                        dr["ncLoaiGiayToTuyThan"].ToString().Trim(),
                                                        dr["ncSoGiayToTuyThan"].ToString().Trim(),
                                                        dr["TinhTrangID"].ToString().Trim(),
                                                        dr["TenFile"].ToString().Trim(),
                                                        dr["TenFileSauUpload"].ToString().Trim(),
                                                        dr["URLTapTinDinhKem"].ToString().Trim(),
                                                        dr["NamMoSo"].ToString().Trim(),
                                                        dr["LoaiGiay"].ToString().Trim(),
                                                        dr["DuLieuCu"].ToString().Trim(),
                                                        dr["NgayCapNhat"].ToString().Trim(),
                                                        dr["GhiChu"].ToString().Trim(),
                                                        dr["cmNoiCuTru"].ToString().Trim(),
                                                        dr["ncNoiCuTru"].ToString().Trim(),
                                                        dr["nycHoTen"].ToString().Trim(),
                                                        dr["nycQHNguoiDuocNhan"].ToString().Trim(),
                                                        dr["nguoiKy"].ToString().Trim(),
                                                        dr["chucVuNguoiKy"].ToString().Trim(),
                                                        dr["nguoiThucHien"].ToString().Trim(),
                                                        dr["cmQueQuan"].ToString().Trim(),
                                                        dr["cmNgayCapGiayToTuyThan"].ToString().Trim(),
                                                        dr["cmNoiCapGiayToTuyThan"].ToString().Trim(),
                                                        dr["ncQueQuan"].ToString().Trim(),
                                                        dr["ncNgayCapGiayToTuyThan"].ToString().Trim(),
                                                        dr["ncNoiCapGiayToTuyThan"].ToString().Trim(),
                                                        dr["nycLoaiGiayToTuyThan"].ToString().Trim(),
                                                        dr["nycSoGiayToTuyThan"].ToString().Trim(),
                                                        dr["nycNgayCapGiayToTuyThan"].ToString().Trim(),
                                                        dr["nycNoiCapGiayToTuyThan"].ToString().Trim());
                            }
                            con.Close();
                        }

                        //so sánh 2 trạng thái nếu khác nhau thì so sánh từng cột 1 để lưu vào db
                        if (!tt7.Equals(tt6))
                        {
                            List<Diff> listDiff = new List<Diff>();

                            Type type = (new HT_NHANCHAMECON()).GetType();

                            //lấy value theo tên thuộc tính (có get set)
                            foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                            {
                                if (!tt7.GetType().GetProperty(property.Name).GetValue(tt7, null).Equals(tt6.GetType().GetProperty(property.Name).GetValue(tt6, null))) 
                                    if (!property.Name.Equals("TinhTrangID1"))
                                        addListDiffCMC(listDiff, tt7, tt6, tt5, property.Name);
                            }

                            foreach (Diff diff in listDiff)
                            {
                                SqlConnection conn = new SqlConnection(Home.sqlConnect);
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("use HoTich; if(select count(*) from Diff " +
                                    "where id = '" + diff.id + "' and so = '" + diff.so + "' and quyenSo = '" + diff.quyenSo + "' and noiDangKy = '" + diff.noiDangKy + "' " +
                                    "and ngayDangKy = '" + diff.ngayDangKy + "' and tableName = '" + diff.tableName + "' and columnName = '" + diff.columnName + "' " +
                                    "and ktbm1 = '" + diff.ktbm1 + "' and ktbm2 = '" + diff.ktbm2 + "' and kt = '" + diff.kt + "') = 0 insert into Diff values('" + diff.id + "', '" + diff.so + "', '" + diff.quyenSo + "'," +
                                    "'" + diff.noiDangKy + "', '" + diff.ngayDangKy + "', '" + diff.tableName + "', '" + diff.columnName + "', '" + diff.ktbm1 + "'," +
                                    "'" + diff.ktbm2 + "','" + diff.kt + "')", conn);
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                        }

                    }

                    MessageBox.Show("Đã xử lý xong CMC", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            });
            threadXuLyCMC.Start();
        }

        private void QuaTrinhXuLy_Load(object sender, EventArgs e)
        {

        }

        private void addListDiffKS(List<Diff> listDiff, HT_KHAISINH tt7, HT_KHAISINH tt6, HT_KHAISINH tt5, string columnName)
        {
            Diff diff = new Diff();
            diff.id = tt7.ID1;
            diff.so = tt7.So;
            diff.quyenSo = tt7.QuyenSo;
            diff.noiDangKy = tt7.NoiDangKy;
            diff.ngayDangKy = tt7.NgayDangKy;

            diff.tableName = "HT_KHAISINH";

            diff.columnName = columnName;
            diff.ktbm1 = tt7.GetType().GetProperty(columnName).GetValue(tt7, null)+"";
            diff.ktbm2 = tt6.GetType().GetProperty(columnName).GetValue(tt6, null) + "";
            diff.kt = tt5.GetType().GetProperty(columnName).GetValue(tt5, null) + "";
            listDiff.Add(diff);

        }

        private void addListDiffKT(List<Diff> listDiff, HT_KHAITU tt7, HT_KHAITU tt6, HT_KHAITU tt5, string columnName)
        {
            Diff diff = new Diff();
            diff.id = tt7.ID1;
            diff.so = tt7.So1;
            diff.quyenSo = tt7.QuyenSo;
            diff.noiDangKy = tt7.NoiDangKy;
            diff.ngayDangKy = tt7.NgayDangKy;

            diff.tableName = "HT_KHAITU";

            diff.columnName = columnName;
            diff.ktbm1 = tt7.GetType().GetProperty(columnName).GetValue(tt7, null) + "";
            diff.ktbm2 = tt6.GetType().GetProperty(columnName).GetValue(tt6, null) + "";
            diff.kt = tt5.GetType().GetProperty(columnName).GetValue(tt5, null) + "";
            listDiff.Add(diff);

        }

        private void addListDiffKH(List<Diff> listDiff, HT_KETHON tt7, HT_KETHON tt6, HT_KETHON tt5, string columnName)
        {
            Diff diff = new Diff();
            diff.id = tt7.ID1;
            diff.so = tt7.So1;
            diff.quyenSo = tt7.QuyenSo;
            diff.noiDangKy = tt7.NoiDangKy;
            diff.ngayDangKy = tt7.NgayDangKy;

            diff.tableName = "HT_KETHON";

            diff.columnName = columnName;
            diff.ktbm1 = tt7.GetType().GetProperty(columnName).GetValue(tt7, null) + "";
            diff.ktbm2 = tt6.GetType().GetProperty(columnName).GetValue(tt6, null) + "";
            diff.kt = tt5.GetType().GetProperty(columnName).GetValue(tt5, null) + "";
            listDiff.Add(diff);

        }

        private void addListDiffCMC(List<Diff> listDiff, HT_NHANCHAMECON tt7, HT_NHANCHAMECON tt6, HT_NHANCHAMECON tt5, string columnName)
        {
            Diff diff = new Diff();
            diff.id = tt7.ID1;
            diff.so = tt7.So1;
            diff.quyenSo = tt7.QuyenSo;
            diff.noiDangKy = tt7.NoiDangKy;
            diff.ngayDangKy = tt7.NgayDangKy;

            diff.tableName = "HT_NHANCHAMECON";

            diff.columnName = columnName;
            diff.ktbm1 = tt7.GetType().GetProperty(columnName).GetValue(tt7, null) + "";
            diff.ktbm2 = tt6.GetType().GetProperty(columnName).GetValue(tt6, null) + "";
            diff.kt = tt5.GetType().GetProperty(columnName).GetValue(tt5, null) + "";
            listDiff.Add(diff);

        }
    }
}
