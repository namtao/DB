using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
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
                foreach(string s in listDayDu3TrangThai)
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
                        " FROM QTXLCMC where id = "+s+" and TinhTrangID = 7";

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
                        " FROM QTXLCMC where id = "+s+" and TinhTrangID = 6";

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

                MessageBox.Show("XONG", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void QuaTrinhXuLy_Load(object sender, EventArgs e)
        {

        }
    }
}
