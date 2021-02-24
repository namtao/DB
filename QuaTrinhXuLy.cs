using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
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
            //thread xử lý CMC
            Thread threadXuLyCMC = new Thread(() =>
            {
                using (SqlConnection con = new SqlConnection(Home.sqlConnect))
                {
                    HT_NHANCHAMECON tt7 = null, tt6 = null;
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

                        //so sánh 2 trạng thái nếu khác nhau thì so sánh từng cột 1 để lưu vào db
                        if (!tt7.Equals(tt6))
                        {
                            List<Diff> listDiff = new List<Diff>();

                            if (!tt7.So.Equals(tt6.So))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "So";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.So;
                                diff.kt = tt7.So;
                                listDiff.Add(diff);
                            }
                            if (!tt7.quyenSo.Equals(tt6.quyenSo))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "quyenSo";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.quyenSo;
                                diff.kt = tt7.quyenSo;
                                listDiff.Add(diff);
                            }
                            if (!tt7.quyetDinhSo.Equals(tt6.quyetDinhSo))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "quyetDinhSo";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.quyetDinhSo;
                                diff.kt = tt7.quyetDinhSo;
                                listDiff.Add(diff);
                            }
                            if (!tt7.ngayDangKy.Equals(tt6.ngayDangKy))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "ngayDangKy";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.ngayDangKy;
                                diff.kt = tt7.ngayDangKy;
                                listDiff.Add(diff);
                            }
                            if (!tt7.loaiDangKy.Equals(tt6.loaiDangKy))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "loaiDangKy";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.loaiDangKy;
                                diff.kt = tt7.loaiDangKy;
                                listDiff.Add(diff);
                            }
                            if (!tt7.loaiXacNhan.Equals(tt6.loaiXacNhan))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "loaiXacNhan";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.loaiXacNhan;
                                diff.kt = tt7.loaiXacNhan;
                                listDiff.Add(diff);
                            }
                            if (!tt7.noiDangKy.Equals(tt6.noiDangKy))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "noiDangKy";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.noiDangKy;
                                diff.kt = tt7.noiDangKy;
                                listDiff.Add(diff);
                            }
                            if (!tt7.cmHoTen.Equals(tt6.cmHoTen))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "cmHoTen";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.cmHoTen;
                                diff.kt = tt7.cmHoTen;
                                listDiff.Add(diff);
                            }
                            if (!tt7.cmNgaySinh.Equals(tt6.cmNgaySinh))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "cmNgaySinh";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.cmNgaySinh;
                                diff.kt = tt7.cmNgaySinh;
                                listDiff.Add(diff);
                            }
                            if (!tt7.cmDanToc.Equals(tt6.cmDanToc))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "cmDanToc";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.cmDanToc;
                                diff.kt = tt7.cmDanToc;
                                listDiff.Add(diff);
                            }
                            if (!tt7.cmQuocTich.Equals(tt6.cmQuocTich))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "cmQuocTich";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.cmQuocTich;
                                diff.kt = tt7.cmQuocTich;
                                listDiff.Add(diff);
                            }
                            if (!tt7.cmLoaiCuTru.Equals(tt6.cmLoaiCuTru))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "cmLoaiCuTru";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.cmLoaiCuTru;
                                diff.kt = tt7.cmLoaiCuTru;
                                listDiff.Add(diff);
                            }
                            if (!tt7.cmLoaiGiayToTuyThan.Equals(tt6.cmLoaiGiayToTuyThan))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "cmLoaiGiayToTuyThan";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.cmLoaiGiayToTuyThan;
                                diff.kt = tt7.cmLoaiGiayToTuyThan;
                                listDiff.Add(diff);
                            }
                            if (!tt7.cmSoGiayToTuyThan.Equals(tt6.cmSoGiayToTuyThan))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "cmSoGiayToTuyThan";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.cmSoGiayToTuyThan;
                                diff.kt = tt7.cmSoGiayToTuyThan;
                                listDiff.Add(diff);
                            }
                            if (!tt7.ncHoTen.Equals(tt6.ncHoTen))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "ncHoTen";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.ncHoTen;
                                diff.kt = tt7.ncHoTen;
                                listDiff.Add(diff);
                            }
                            if (!tt7.ncNgaySinh.Equals(tt6.ncNgaySinh))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "ncNgaySinh";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.ncNgaySinh;
                                diff.kt = tt7.ncNgaySinh;
                                listDiff.Add(diff);
                            }
                            if (!tt7.ncDanToc.Equals(tt6.ncDanToc))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "ncDanToc";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.ncDanToc;
                                diff.kt = tt7.ncDanToc;
                                listDiff.Add(diff);
                            }
                            if (!tt7.ncQuocTich.Equals(tt6.ncQuocTich))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "ncQuocTich";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.ncQuocTich;
                                diff.kt = tt7.ncQuocTich;
                                listDiff.Add(diff);
                            }
                            if (!tt7.ncLoaiCuTru.Equals(tt6.ncLoaiCuTru))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "ncLoaiCuTru";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.ncLoaiCuTru;
                                diff.kt = tt7.ncLoaiCuTru;
                                listDiff.Add(diff);
                            }
                            if (!tt7.ncLoaiGiayToTuyThan.Equals(tt6.ncLoaiGiayToTuyThan))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "ncLoaiGiayToTuyThan";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.ncLoaiGiayToTuyThan;
                                diff.kt = tt7.ncLoaiGiayToTuyThan;
                                listDiff.Add(diff);
                            }
                            if (!tt7.ncSoGiayToTuyThan.Equals(tt6.ncSoGiayToTuyThan))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "ncSoGiayToTuyThan";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.ncSoGiayToTuyThan;
                                diff.kt = tt7.ncSoGiayToTuyThan;
                                listDiff.Add(diff);
                            }
                            if (!tt7.GhiChu.Equals(tt6.GhiChu))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "GhiChu";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.GhiChu;
                                diff.kt = tt7.GhiChu;
                                listDiff.Add(diff);
                            }
                            if (!tt7.cmNoiCuTru.Equals(tt6.cmNoiCuTru))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "cmNoiCuTru";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.cmNoiCuTru;
                                diff.kt = tt7.cmNoiCuTru;
                                listDiff.Add(diff);
                            }
                            if (!tt7.ncNoiCuTru.Equals(tt6.ncNoiCuTru))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "ncNoiCuTru";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.ncNoiCuTru;
                                diff.kt = tt7.ncNoiCuTru;
                                listDiff.Add(diff);
                            }
                            if (!tt7.nycHoTen.Equals(tt6.nycHoTen))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "nycHoTen";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nycHoTen;
                                diff.kt = tt7.nycHoTen;
                                listDiff.Add(diff);
                            }
                            if (!tt7.nycQHNguoiDuocNhan.Equals(tt6.nycQHNguoiDuocNhan))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "nycQHNguoiDuocNhan";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nycQHNguoiDuocNhan;
                                diff.kt = tt7.nycQHNguoiDuocNhan;
                                listDiff.Add(diff);
                            }
                            if (!tt7.nguoiKy.Equals(tt6.nguoiKy))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "nguoiKy";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nguoiKy;
                                diff.kt = tt7.nguoiKy;
                                listDiff.Add(diff);
                            }
                            if (!tt7.chucVuNguoiKy.Equals(tt6.chucVuNguoiKy))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "chucVuNguoiKy";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.chucVuNguoiKy;
                                diff.kt = tt7.chucVuNguoiKy;
                                listDiff.Add(diff);
                            }
                            if (!tt7.nguoiThucHien.Equals(tt6.nguoiThucHien))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "nguoiThucHien";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nguoiThucHien;
                                diff.kt = tt7.nguoiThucHien;
                                listDiff.Add(diff);
                            }
                            if (!tt7.cmQueQuan.Equals(tt6.cmQueQuan))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "cmQueQuan";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.loaiXacNhan;
                                diff.kt = tt7.loaiXacNhan;
                                listDiff.Add(diff);
                            }
                            if (!tt7.cmNgayCapGiayToTuyThan.Equals(tt6.cmNgayCapGiayToTuyThan))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "cmNgayCapGiayToTuyThan";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.cmNgayCapGiayToTuyThan;
                                diff.kt = tt7.cmNgayCapGiayToTuyThan;
                                listDiff.Add(diff);
                            }
                            if (!tt7.cmNoiCapGiayToTuyThan.Equals(tt6.cmNoiCapGiayToTuyThan))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "cmNoiCapGiayToTuyThan";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.cmNoiCapGiayToTuyThan;
                                diff.kt = tt7.cmNoiCapGiayToTuyThan;
                                listDiff.Add(diff);
                            }
                            if (!tt7.ncQueQuan.Equals(tt6.ncQueQuan))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "ncQueQuan";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.ncQueQuan;
                                diff.kt = tt7.ncQueQuan;
                                listDiff.Add(diff);
                            }
                            if (!tt7.ncNgayCapGiayToTuyThan.Equals(tt6.ncNgayCapGiayToTuyThan))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "ncNgayCapGiayToTuyThan";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.ncNgayCapGiayToTuyThan;
                                diff.kt = tt7.ncNgayCapGiayToTuyThan;
                                listDiff.Add(diff);
                            }
                            if (!tt7.ncNoiCapGiayToTuyThan.Equals(tt6.ncNoiCapGiayToTuyThan))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "ncNoiCapGiayToTuyThan";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.ncNoiCapGiayToTuyThan;
                                diff.kt = tt7.ncNoiCapGiayToTuyThan;
                                listDiff.Add(diff);
                            }
                            if (!tt7.nycLoaiGiayToTuyThan.Equals(tt6.nycLoaiGiayToTuyThan))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "nycLoaiGiayToTuyThan";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nycLoaiGiayToTuyThan;
                                diff.kt = tt7.nycLoaiGiayToTuyThan;
                                listDiff.Add(diff);
                            }
                            if (!tt7.nycSoGiayToTuyThan.Equals(tt6.nycSoGiayToTuyThan))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "nycSoGiayToTuyThan";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nycSoGiayToTuyThan;
                                diff.kt = tt7.nycSoGiayToTuyThan;
                                listDiff.Add(diff);
                            }
                            if (!tt7.nycNgayCapGiayToTuyThan.Equals(tt6.nycNgayCapGiayToTuyThan))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "nycNgayCapGiayToTuyThan";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nycNgayCapGiayToTuyThan;
                                diff.kt = tt7.nycNgayCapGiayToTuyThan;
                                listDiff.Add(diff);
                            }
                            if (!tt7.nycNoiCapGiayToTuyThan.Equals(tt6.nycNoiCapGiayToTuyThan))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_NHANCHAMECON";

                                diff.columnName = "nycNoiCapGiayToTuyThan";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nycNoiCapGiayToTuyThan;
                                diff.kt = tt7.nycNoiCapGiayToTuyThan;
                                listDiff.Add(diff);
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

            //thread xử lý KS
            Thread threadXuLyKS = new Thread(() =>
            {
                using (SqlConnection con = new SqlConnection(Home.sqlConnect))
                {
                    HT_KHAISINH tt7 = null, tt6 = null;
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

                        //so sánh 2 trạng thái nếu khác nhau thì so sánh từng cột 1 để lưu vào db
                        if (!tt7.Equals(tt6))
                        {
                            List<Diff> listDiff = new List<Diff>();

                            if (!tt7.so.Equals(tt6.so))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.so;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAISINH";

                                diff.columnName = "so";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.so;
                                diff.kt = tt7.so;
                                listDiff.Add(diff);
                            }

                            if (!tt7.quyenSo.Equals(tt6.quyenSo))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.quyenSo;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAISINH";

                                diff.columnName = "quyenSo";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.quyenSo;
                                diff.kt = tt7.quyenSo;
                                listDiff.Add(diff);
                            }

                            if (!tt7.ngayDangKy.Equals(tt6.ngayDangKy))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.ngayDangKy;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAISINH";

                                diff.columnName = "ngayDangKy";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.ngayDangKy;
                                diff.kt = tt7.ngayDangKy;
                                listDiff.Add(diff);
                            }

                            if (!tt7.loaiDangKy.Equals(tt6.loaiDangKy))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.loaiDangKy;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAISINH";

                                diff.columnName = "loaiDangKy";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.loaiDangKy;
                                diff.kt = tt7.loaiDangKy;
                                listDiff.Add(diff);
                            }

                            if (!tt7.noiDangKy.Equals(tt6.noiDangKy))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.noiDangKy;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAISIH";

                                diff.columnName = "noiDangKy";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.noiDangKy;
                                diff.kt = tt7.noiDangKy;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nksHoTen.Equals(tt6.nksHoTen))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.nksHoTen;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAISINH";

                                diff.columnName = "nksHoTen";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nksHoTen;
                                diff.kt = tt7.nksHoTen;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nksGioiTinh.Equals(tt6.nksGioiTinh))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.nksGioiTinh;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAISINH";

                                diff.columnName = "nksGioiTinh";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nksGioiTinh;
                                diff.kt = tt7.nksGioiTinh;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nksNgaySinh.Equals(tt6.nksNgaySinh))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.nksNgaySinh;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAISINH";

                                diff.columnName = "nksNgaySinh";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nksNgaySinh;
                                diff.kt = tt7.nksNgaySinh;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nksDanToc.Equals(tt6.nksDanToc))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.nksDanToc;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAISINH";

                                diff.columnName = "nksDanToc";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nksDanToc;
                                diff.kt = tt7.nksDanToc;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nksQuocTich.Equals(tt6.nksQuocTich))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.nksQuocTich;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAISINH";

                                diff.columnName = "nksQuocTich";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nksQuocTich;
                                diff.kt = tt7.nksQuocTich;
                                listDiff.Add(diff);
                            }

                            if (!tt7.meHoTen.Equals(tt6.meHoTen))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.meHoTen;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAISINH";

                                diff.columnName = "meHoTen";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.meHoTen;
                                diff.kt = tt7.meHoTen;
                                listDiff.Add(diff);
                            }

                            if (!tt7.meNgaySinh.Equals(tt6.meNgaySinh))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.meNgaySinh;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAISINH";

                                diff.columnName = "meNgaySinh";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.meNgaySinh;
                                diff.kt = tt7.meNgaySinh;
                                listDiff.Add(diff);
                            }

                            if (!tt7.meDanToc.Equals(tt6.meDanToc))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.meDanToc;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAISINH";

                                diff.columnName = "meDanToc";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.meDanToc;
                                diff.kt = tt7.meDanToc;
                                listDiff.Add(diff);
                            }

                            if (!tt7.meQuocTich.Equals(tt6.meQuocTich))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.meQuocTich;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAISINH";

                                diff.columnName = "meQuocTich";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.meQuocTich;
                                diff.kt = tt7.meQuocTich;
                                listDiff.Add(diff);
                            }

                            if (!tt7.meLoaiCuTru.Equals(tt6.meLoaiCuTru))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.meLoaiCuTru;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAISINH";

                                diff.columnName = "meLoaiCuTru";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.meLoaiCuTru;
                                diff.kt = tt7.meLoaiCuTru;
                                listDiff.Add(diff);
                            }

                            if (!tt7.chaHoTen.Equals(tt6.chaHoTen))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.chaHoTen;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAISINH";

                                diff.columnName = "chaHoTen";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.chaHoTen;
                                diff.kt = tt7.chaHoTen;
                                listDiff.Add(diff);
                            }

                            if (!tt7.chaNgaySinh.Equals(tt6.chaNgaySinh))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.chaNgaySinh;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAISINH";

                                diff.columnName = "chaNgaySinh";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.chaNgaySinh;
                                diff.kt = tt7.chaNgaySinh;
                                listDiff.Add(diff);
                            }

                            if (!tt7.chaDanToc.Equals(tt6.chaDanToc))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.chaDanToc;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAISINH";

                                diff.columnName = "chaDanToc";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.chaDanToc;
                                diff.kt = tt7.chaDanToc;
                                listDiff.Add(diff);
                            }

                            if (!tt7.chaQuocTich.Equals(tt6.chaQuocTich))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.chaQuocTich;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAISINH";

                                diff.columnName = "chaQuocTich";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.chaQuocTich;
                                diff.kt = tt7.chaQuocTich;
                                listDiff.Add(diff);
                            }

                            if (!tt7.chaLoaiCuTru.Equals(tt6.chaLoaiCuTru))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.chaLoaiCuTru;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAISINH";

                                diff.columnName = "chaLoaiCuTru";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.chaLoaiCuTru;
                                diff.kt = tt7.chaLoaiCuTru;
                                listDiff.Add(diff);
                            }

                            if (!tt7.GhiChu.Equals(tt6.GhiChu))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.GhiChu;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAISINH";

                                diff.columnName = "GhiChu";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.GhiChu;
                                diff.kt = tt7.GhiChu;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nksNoiSinh.Equals(tt6.nksNoiSinh))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.nksNoiSinh;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAISINH";

                                diff.columnName = "nksNoiSinh";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nksNoiSinh;
                                diff.kt = tt7.nksNoiSinh;
                                listDiff.Add(diff);
                            }

                            if (!tt7.meNoiCuTru.Equals(tt6.meNoiCuTru))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.meNoiCuTru;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAISINH";

                                diff.columnName = "meNoiCuTru";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.meNoiCuTru;
                                diff.kt = tt7.meNoiCuTru;
                                listDiff.Add(diff);
                            }

                            if (!tt7.chaNoiCuTru.Equals(tt6.chaNoiCuTru))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.chaNoiCuTru;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAISINH";

                                diff.columnName = "chaNoiCuTru";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.chaNoiCuTru;
                                diff.kt = tt7.chaNoiCuTru;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nycHoTen.Equals(tt6.nycHoTen))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.nycHoTen;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAISINH";

                                diff.columnName = "nycHoTen";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nycHoTen;
                                diff.kt = tt7.nycHoTen;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nycQuanHe.Equals(tt6.nycQuanHe))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.nycQuanHe;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAISINH";

                                diff.columnName = "nycQuanHe";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nycQuanHe;
                                diff.kt = tt7.nycQuanHe;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nguoiKy.Equals(tt6.nguoiKy))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.nguoiKy;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAISINH";

                                diff.columnName = "nguoiKy";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nguoiKy;
                                diff.kt = tt7.nguoiKy;
                                listDiff.Add(diff);
                            }

                            if (!tt7.chucVuNguoiKy.Equals(tt6.chucVuNguoiKy))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.chucVuNguoiKy;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAISINH";

                                diff.columnName = "chucVuNguoiKy";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.chucVuNguoiKy;
                                diff.kt = tt7.chucVuNguoiKy;
                                listDiff.Add(diff);
                            }

                            if (!tt7.NguoiThucHien.Equals(tt6.NguoiThucHien))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.NguoiThucHien;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAISINH";

                                diff.columnName = "NguoiThucHien";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.NguoiThucHien;
                                diff.kt = tt7.NguoiThucHien;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nksLoaiKhaiSinh.Equals(tt6.nksLoaiKhaiSinh))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.nksLoaiKhaiSinh;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAISINH";

                                diff.columnName = "nksLoaiKhaiSinh";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nksLoaiKhaiSinh;
                                diff.kt = tt7.nksLoaiKhaiSinh;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nksNoiSinhDVHC.Equals(tt6.nksNoiSinhDVHC))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.nksNoiSinhDVHC;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAISINH";

                                diff.columnName = "nksNoiSinhDVHC";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nksNoiSinhDVHC;
                                diff.kt = tt7.nksNoiSinhDVHC;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nksQueQuan.Equals(tt6.nksQueQuan))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.nksQueQuan;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAISINH";

                                diff.columnName = "nksQueQuan";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nksQueQuan;
                                diff.kt = tt7.nksQueQuan;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nycLoaiGiayToTuyThan.Equals(tt6.nycLoaiGiayToTuyThan))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.nycLoaiGiayToTuyThan;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAISINH";

                                diff.columnName = "nycLoaiGiayToTuyThan";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nycLoaiGiayToTuyThan;
                                diff.kt = tt7.nycLoaiGiayToTuyThan;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nycSoGiayToTuyThan.Equals(tt6.nycSoGiayToTuyThan))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.nycSoGiayToTuyThan;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAISINH";

                                diff.columnName = "nycSoGiayToTuyThan";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nycSoGiayToTuyThan;
                                diff.kt = tt7.nycSoGiayToTuyThan;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nycNgayCapGiayToTuyThan.Equals(tt6.nycNgayCapGiayToTuyThan))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.nycNgayCapGiayToTuyThan;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAISINH";

                                diff.columnName = "nycNgayCapGiayToTuyThan";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nycNgayCapGiayToTuyThan;
                                diff.kt = tt7.nycNgayCapGiayToTuyThan;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nycNoiCapGiayToTuyThan.Equals(tt6.nycNoiCapGiayToTuyThan))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.nycNoiCapGiayToTuyThan;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAISINH";

                                diff.columnName = "nycNoiCapGiayToTuyThan";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nycNoiCapGiayToTuyThan;
                                diff.kt = tt7.nycNoiCapGiayToTuyThan;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nksNgaySinhBangChu.Equals(tt6.nksNgaySinhBangChu))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.nksNgaySinhBangChu;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAISINH";

                                diff.columnName = "nksNgaySinhBangChu";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nksNgaySinhBangChu;
                                diff.kt = tt7.nksNgaySinhBangChu;
                                listDiff.Add(diff);
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
                    HT_KHAITU tt7 = null, tt6 = null;
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

                        //so sánh 2 trạng thái nếu khác nhau thì so sánh từng cột 1 để lưu vào db
                        if (!tt7.Equals(tt6))
                        {
                            List<Diff> listDiff = new List<Diff>();

                            if (!tt7.So.Equals(tt6.So))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAITU";

                                diff.columnName = "So";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.So;
                                diff.kt = tt7.So;
                                listDiff.Add(diff);
                            }

                            if (!tt7.quyenSo.Equals(tt6.quyenSo))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAITU";

                                diff.columnName = "quyenSo";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.quyenSo;
                                diff.kt = tt7.quyenSo;
                                listDiff.Add(diff);
                            }

                            if (!tt7.ngayDangKy.Equals(tt6.ngayDangKy))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAITU";

                                diff.columnName = "ngayDangKy";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.ngayDangKy;
                                diff.kt = tt7.ngayDangKy;
                                listDiff.Add(diff);
                            }

                            if (!tt7.loaiDangKy.Equals(tt6.loaiDangKy))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAITU";

                                diff.columnName = "loaiDangKy";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.loaiDangKy;
                                diff.kt = tt7.loaiDangKy;
                                listDiff.Add(diff);
                            }

                            if (!tt7.noiDangKy.Equals(tt6.noiDangKy))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAITU";

                                diff.columnName = "noiDangKy";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.noiDangKy;
                                diff.kt = tt7.noiDangKy;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nktHoTen.Equals(tt6.nktHoTen))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAITU";

                                diff.columnName = "nktHoTen";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nktHoTen;
                                diff.kt = tt7.nktHoTen;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nktGioiTinh.Equals(tt6.nktGioiTinh))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAITU";

                                diff.columnName = "nktGioiTinh";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nktGioiTinh;
                                diff.kt = tt7.nktGioiTinh;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nktNgaySinh.Equals(tt6.nktNgaySinh))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAITU";

                                diff.columnName = "nktNgaySinh";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nktNgaySinh;
                                diff.kt = tt7.nktNgaySinh;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nktDanToc.Equals(tt6.nktDanToc))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAITU";

                                diff.columnName = "nktDanToc";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nktDanToc;
                                diff.kt = tt7.nktDanToc;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nktQuocTich.Equals(tt6.nktQuocTich))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAITU";

                                diff.columnName = "nktQuocTich";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nktQuocTich;
                                diff.kt = tt7.nktQuocTich;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nktLoaiCuTru.Equals(tt6.nktLoaiCuTru))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAITU";

                                diff.columnName = "nktLoaiCuTru";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nktLoaiCuTru;
                                diff.kt = tt7.nktLoaiCuTru;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nktLoaiGiayToTuyThan.Equals(tt6.nktLoaiGiayToTuyThan))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAITU";

                                diff.columnName = "nktLoaiGiayToTuyThan";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nktLoaiGiayToTuyThan;
                                diff.kt = tt7.nktLoaiGiayToTuyThan;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nktSoGiayToTuyThan.Equals(tt6.nktSoGiayToTuyThan))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAITU";

                                diff.columnName = "nktSoGiayToTuyThan";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nktSoGiayToTuyThan;
                                diff.kt = tt7.nktSoGiayToTuyThan;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nktNgayChet.Equals(tt6.nktNgayChet))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAITU";

                                diff.columnName = "nktNgayChet";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nktNgayChet;
                                diff.kt = tt7.nktNgayChet;
                                listDiff.Add(diff);
                            }

                            if (!tt7.GhiChu.Equals(tt6.GhiChu))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAITU";

                                diff.columnName = "GhiChu";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.GhiChu;
                                diff.kt = tt7.GhiChu;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nktGioPhutChet.Equals(tt6.nktGioPhutChet))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAITU";

                                diff.columnName = "nktGioPhutChet";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nktGioPhutChet;
                                diff.kt = tt7.nktGioPhutChet;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nktNoiChet.Equals(tt6.nktNoiChet))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAITU";

                                diff.columnName = "nktNoiChet";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nktNoiChet;
                                diff.kt = tt7.nktNoiChet;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nktNguyenNhanChet.Equals(tt6.nktNguyenNhanChet))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAITU";

                                diff.columnName = "nktNguyenNhanChet";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nktNguyenNhanChet;
                                diff.kt = tt7.nktNguyenNhanChet;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nktNoiCuTru.Equals(tt6.nktNoiCuTru))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAITU";

                                diff.columnName = "nktNoiCuTru";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nktNoiCuTru;
                                diff.kt = tt7.nktNoiCuTru;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nycHoTen.Equals(tt6.nycHoTen))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAITU";

                                diff.columnName = "nycHoTen";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nycHoTen;
                                diff.kt = tt7.nycHoTen;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nycQuanHe.Equals(tt6.nycQuanHe))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAITU";

                                diff.columnName = "nycQuanHe";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nycQuanHe;
                                diff.kt = tt7.nycQuanHe;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nguoiKy.Equals(tt6.nguoiKy))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAITU";

                                diff.columnName = "nguoiKy";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nguoiKy;
                                diff.kt = tt7.nguoiKy;
                                listDiff.Add(diff);
                            }

                            if (!tt7.chucVuNguoiKy.Equals(tt6.chucVuNguoiKy))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAITU";

                                diff.columnName = "chucVuNguoiKy";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.chucVuNguoiKy;
                                diff.kt = tt7.chucVuNguoiKy;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nguoiThucHien.Equals(tt6.nguoiThucHien))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAITU";

                                diff.columnName = "nguoiThucHien";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nguoiThucHien;
                                diff.kt = tt7.nguoiThucHien;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nktNgayCapGiayToTuyThan.Equals(tt6.nktNgayCapGiayToTuyThan))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAITU";

                                diff.columnName = "nktNgayCapGiayToTuyThan";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nktNgayCapGiayToTuyThan;
                                diff.kt = tt7.nktNgayCapGiayToTuyThan;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nktNoiCapGiayToTuyThan.Equals(tt6.nktNoiCapGiayToTuyThan))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAITU";

                                diff.columnName = "nktNoiCapGiayToTuyThan";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nktNoiCapGiayToTuyThan;
                                diff.kt = tt7.nktNoiCapGiayToTuyThan;
                                listDiff.Add(diff);
                            }

                            if (!tt7.gbtLoai.Equals(tt6.gbtLoai))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAITU";

                                diff.columnName = "gbtLoai";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.gbtLoai;
                                diff.kt = tt7.gbtLoai;
                                listDiff.Add(diff);
                            }

                            if (!tt7.gbtSo.Equals(tt6.gbtSo))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAITU";

                                diff.columnName = "gbtSo";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.gbtSo;
                                diff.kt = tt7.gbtSo;
                                listDiff.Add(diff);
                            }

                            if (!tt7.gbtNgay.Equals(tt6.gbtNgay))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAITU";

                                diff.columnName = "gbtNgay";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.gbtNgay;
                                diff.kt = tt7.gbtNgay;
                                listDiff.Add(diff);
                            }

                            if (!tt7.gbtCoQuanCap.Equals(tt6.gbtCoQuanCap))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAITU";

                                diff.columnName = "gbtCoQuanCap";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.gbtCoQuanCap;
                                diff.kt = tt7.gbtCoQuanCap;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nycLoaiGiayToTuyThan.Equals(tt6.nycLoaiGiayToTuyThan))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAITU";

                                diff.columnName = "nycLoaiGiayToTuyThan";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nycLoaiGiayToTuyThan;
                                diff.kt = tt7.nycLoaiGiayToTuyThan;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nycSoGiayToTuyThan.Equals(tt6.nycSoGiayToTuyThan))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAITU";

                                diff.columnName = "nycSoGiayToTuyThan";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nycSoGiayToTuyThan;
                                diff.kt = tt7.nycSoGiayToTuyThan;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nycNgayCapGiayToTuyThan.Equals(tt6.nycNgayCapGiayToTuyThan))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAITU";

                                diff.columnName = "nycNgayCapGiayToTuyThan";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nycNgayCapGiayToTuyThan;
                                diff.kt = tt7.nycNgayCapGiayToTuyThan;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nycNoiCapGiayToTuyThan.Equals(tt6.nycNoiCapGiayToTuyThan))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KHAITU";

                                diff.columnName = "nycNoiCapGiayToTuyThan";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nycNoiCapGiayToTuyThan;
                                diff.kt = tt7.nycNoiCapGiayToTuyThan;
                                listDiff.Add(diff);
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
                    HT_KETHON tt7 = null, tt6 = null;
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

                        //so sánh 2 trạng thái nếu khác nhau thì so sánh từng cột 1 để lưu vào db
                        if (!tt7.Equals(tt6))
                        {
                            List<Diff> listDiff = new List<Diff>();

                            if (!tt7.So.Equals(tt6.So))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KETHON";

                                diff.columnName = "So";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.So;
                                diff.kt = tt7.So;
                                listDiff.Add(diff);
                            }

                            if (!tt7.quyenSo.Equals(tt6.quyenSo))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KETHON";

                                diff.columnName = "quyenSo";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.quyenSo;
                                diff.kt = tt7.quyenSo;
                                listDiff.Add(diff);
                            }

                            if (!tt7.ngayDangKy.Equals(tt6.ngayDangKy))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KETHON";

                                diff.columnName = "ngayDangKy";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.ngayDangKy;
                                diff.kt = tt7.ngayDangKy;
                                listDiff.Add(diff);
                            }

                            if (!tt7.loaiDangKy.Equals(tt6.loaiDangKy))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KETHON";

                                diff.columnName = "loaiDangKy";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.loaiDangKy;
                                diff.kt = tt7.loaiDangKy;
                                listDiff.Add(diff);
                            }

                            if (!tt7.noiDangKy.Equals(tt6.noiDangKy))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KETHON";

                                diff.columnName = "noiDangKy";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.noiDangKy;
                                diff.kt = tt7.noiDangKy;
                                listDiff.Add(diff);
                            }

                            if (!tt7.chongHoTen.Equals(tt6.chongHoTen))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KETHON";

                                diff.columnName = "chongHoTen";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.chongHoTen;
                                diff.kt = tt7.chongHoTen;
                                listDiff.Add(diff);
                            }

                            if (!tt7.chongNgaySinh.Equals(tt6.chongNgaySinh))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KETHON";

                                diff.columnName = "chongNgaySinh";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.chongNgaySinh;
                                diff.kt = tt7.chongNgaySinh;
                                listDiff.Add(diff);
                            }

                            if (!tt7.chongDanToc.Equals(tt6.chongDanToc))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KETHON";

                                diff.columnName = "chongDanToc";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.chongDanToc;
                                diff.kt = tt7.chongDanToc;
                                listDiff.Add(diff);
                            }

                            if (!tt7.chongQuocTich.Equals(tt6.chongQuocTich))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KETHON";

                                diff.columnName = "chongQuocTich";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.chongQuocTich;
                                diff.kt = tt7.chongQuocTich;
                                listDiff.Add(diff);
                            }

                            if (!tt7.chongLoaiCuTru.Equals(tt6.chongLoaiCuTru))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KETHON";

                                diff.columnName = "chongLoaiCuTru";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.chongLoaiCuTru;
                                diff.kt = tt7.chongLoaiCuTru;
                                listDiff.Add(diff);
                            }

                            if (!tt7.chongLoaiGiayToTuyThan.Equals(tt6.chongLoaiGiayToTuyThan))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KETHON";

                                diff.columnName = "chongLoaiGiayToTuyThan";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.chongLoaiGiayToTuyThan;
                                diff.kt = tt7.chongLoaiGiayToTuyThan;
                                listDiff.Add(diff);
                            }

                            if (!tt7.chongSoGiayToTuyThan.Equals(tt6.chongSoGiayToTuyThan))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KETHON";

                                diff.columnName = "chongSoGiayToTuyThan";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.chongSoGiayToTuyThan;
                                diff.kt = tt7.chongSoGiayToTuyThan;
                                listDiff.Add(diff);
                            }

                            if (!tt7.voHoTen.Equals(tt6.voHoTen))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KETHON";

                                diff.columnName = "voHoTen";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.voHoTen;
                                diff.kt = tt7.voHoTen;
                                listDiff.Add(diff);
                            }

                            if (!tt7.voNgaySinh.Equals(tt6.voNgaySinh))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KETHON";

                                diff.columnName = "voNgaySinh";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.voNgaySinh;
                                diff.kt = tt7.voNgaySinh;
                                listDiff.Add(diff);
                            }

                            if (!tt7.voDanToc.Equals(tt6.voDanToc))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KETHON";

                                diff.columnName = "voDanToc";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.voDanToc;
                                diff.kt = tt7.voDanToc;
                                listDiff.Add(diff);
                            }

                            if (!tt7.voQuocTich.Equals(tt6.voQuocTich))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KETHON";

                                diff.columnName = "voQuocTich";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.voQuocTich;
                                diff.kt = tt7.voQuocTich;
                                listDiff.Add(diff);
                            }

                            if (!tt7.voLoaiCuTru.Equals(tt6.voLoaiCuTru))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KETHON";

                                diff.columnName = "voLoaiCuTru";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.voLoaiCuTru;
                                diff.kt = tt7.voLoaiCuTru;
                                listDiff.Add(diff);
                            }

                            if (!tt7.voLoaiGiayToTuyThan.Equals(tt6.voLoaiGiayToTuyThan))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KETHON";

                                diff.columnName = "voLoaiGiayToTuyThan";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.voLoaiGiayToTuyThan;
                                diff.kt = tt7.voLoaiGiayToTuyThan;
                                listDiff.Add(diff);
                            }

                            if (!tt7.voSoGiayToTuyThan.Equals(tt6.voSoGiayToTuyThan))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KETHON";

                                diff.columnName = "voSoGiayToTuyThan";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.voSoGiayToTuyThan;
                                diff.kt = tt7.voSoGiayToTuyThan;
                                listDiff.Add(diff);
                            }

                            if (!tt7.GhiChu.Equals(tt6.GhiChu))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KETHON";

                                diff.columnName = "GhiChu";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.GhiChu;
                                diff.kt = tt7.GhiChu;
                                listDiff.Add(diff);
                            }

                            if (!tt7.chongNoiCuTru.Equals(tt6.chongNoiCuTru))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KETHON";

                                diff.columnName = "chongNoiCuTru";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.chongNoiCuTru;
                                diff.kt = tt7.chongNoiCuTru;
                                listDiff.Add(diff);
                            }

                            if (!tt7.voNoiCuTru.Equals(tt6.voNoiCuTru))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KETHON";

                                diff.columnName = "voNoiCuTru";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.voNoiCuTru;
                                diff.kt = tt7.voNoiCuTru;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nguoiKy.Equals(tt6.nguoiKy))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KETHON";

                                diff.columnName = "nguoiKy";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nguoiKy;
                                diff.kt = tt7.nguoiKy;
                                listDiff.Add(diff);
                            }

                            if (!tt7.chucVuNguoiKy.Equals(tt6.chucVuNguoiKy))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KETHON";

                                diff.columnName = "chucVuNguoiKy";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.chucVuNguoiKy;
                                diff.kt = tt7.chucVuNguoiKy;
                                listDiff.Add(diff);
                            }

                            if (!tt7.nguoiThucHien.Equals(tt6.nguoiThucHien))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KETHON";

                                diff.columnName = "nguoiThucHien";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.nguoiThucHien;
                                diff.kt = tt7.nguoiThucHien;
                                listDiff.Add(diff);
                            }

                            if (!tt7.chongNgayCapGiayToTuyThan.Equals(tt6.chongNgayCapGiayToTuyThan))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KETHON";

                                diff.columnName = "chongNgayCapGiayToTuyThan";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.chongNgayCapGiayToTuyThan;
                                diff.kt = tt7.chongNgayCapGiayToTuyThan;
                                listDiff.Add(diff);
                            }

                            if (!tt7.chongNoiCapGiayToTuyThan.Equals(tt6.chongNoiCapGiayToTuyThan))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KETHON";

                                diff.columnName = "chongNoiCapGiayToTuyThan";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.chongNoiCapGiayToTuyThan;
                                diff.kt = tt7.chongNoiCapGiayToTuyThan;
                                listDiff.Add(diff);
                            }

                            if (!tt7.voNgayCapGiayToTuyThan.Equals(tt6.voNgayCapGiayToTuyThan))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KETHON";

                                diff.columnName = "voNgayCapGiayToTuyThan";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.voNgayCapGiayToTuyThan;
                                diff.kt = tt7.voNgayCapGiayToTuyThan;
                                listDiff.Add(diff);
                            }

                            if (!tt7.voNoiCapGiayToTuyThan.Equals(tt6.voNoiCapGiayToTuyThan))
                            {
                                Diff diff = new Diff();
                                diff.id = tt7.ID;
                                diff.so = tt7.So;
                                diff.quyenSo = tt7.quyenSo;
                                diff.noiDangKy = tt7.noiDangKy;
                                diff.ngayDangKy = tt7.ngayDangKy;

                                diff.tableName = "HT_KETHON";

                                diff.columnName = "voNoiCapGiayToTuyThan";
                                diff.ktbm1 = "";
                                diff.ktbm2 = tt6.voNoiCapGiayToTuyThan;
                                diff.kt = tt7.voNoiCapGiayToTuyThan;
                                listDiff.Add(diff);
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

        }

        private void QuaTrinhXuLy_Load(object sender, EventArgs e)
        {

        }
    }
}
