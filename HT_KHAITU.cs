using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    class HT_KHAITU
    {
        public string ID, So, quyenSo, trangSo, ngayDangKy, loaiDangKy, noiDangKy, nktHoTen, nktGioiTinh, nktNgaySinh, nktDanToc, nktQuocTich, nktLoaiCuTru, nktLoaiGiayToTuyThan, nktSoGiayToTuyThan, nktNgayChet, TinhTrangID, TenFile, TenFileSauUpload, URLTapTinDinhKem, NamMoSo, LoaiGiay, DuLieuCu, NgayCapNhat, urlAnhCu, GhiChu, nktGioPhutChet, nktNoiChet, nktNguyenNhanChet, nktNoiCuTru, nycHoTen, nycQuanHe, nguoiKy, chucVuNguoiKy, nguoiThucHien, nktNgayCapGiayToTuyThan, nktNoiCapGiayToTuyThan, gbtLoai, gbtSo, gbtNgay, gbtCoQuanCap, nycLoaiGiayToTuyThan, nycSoGiayToTuyThan, nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan;

        public HT_KHAITU(string iD, string so, string quyenSo, string trangSo, string ngayDangKy, string loaiDangKy, string noiDangKy, string nktHoTen, string nktGioiTinh, string nktNgaySinh, string nktDanToc, string nktQuocTich, string nktLoaiCuTru, string nktLoaiGiayToTuyThan, string nktSoGiayToTuyThan, string nktNgayChet, string tinhTrangID, string tenFile, string tenFileSauUpload, string uRLTapTinDinhKem, string namMoSo, string loaiGiay, string duLieuCu, string ngayCapNhat, string urlAnhCu, string ghiChu, string nktGioPhutChet, string nktNoiChet, string nktNguyenNhanChet, string nktNoiCuTru, string nycHoTen, string nycQuanHe, string nguoiKy, string chucVuNguoiKy, string nguoiThucHien, string nktNgayCapGiayToTuyThan, string nktNoiCapGiayToTuyThan, string gbtLoai, string gbtSo, string gbtNgay, string gbtCoQuanCap, string nycLoaiGiayToTuyThan, string nycSoGiayToTuyThan, string nycNgayCapGiayToTuyThan, string nycNoiCapGiayToTuyThan)
        {
            ID = iD;
            So = so;
            this.quyenSo = quyenSo;
            this.trangSo = trangSo;
            this.ngayDangKy = ngayDangKy;
            this.loaiDangKy = loaiDangKy;
            this.noiDangKy = noiDangKy;
            this.nktHoTen = nktHoTen;
            this.nktGioiTinh = nktGioiTinh;
            this.nktNgaySinh = nktNgaySinh;
            this.nktDanToc = nktDanToc;
            this.nktQuocTich = nktQuocTich;
            this.nktLoaiCuTru = nktLoaiCuTru;
            this.nktLoaiGiayToTuyThan = nktLoaiGiayToTuyThan;
            this.nktSoGiayToTuyThan = nktSoGiayToTuyThan;
            this.nktNgayChet = nktNgayChet;
            TinhTrangID = tinhTrangID;
            TenFile = tenFile;
            TenFileSauUpload = tenFileSauUpload;
            URLTapTinDinhKem = uRLTapTinDinhKem;
            NamMoSo = namMoSo;
            LoaiGiay = loaiGiay;
            DuLieuCu = duLieuCu;
            NgayCapNhat = ngayCapNhat;
            this.urlAnhCu = urlAnhCu;
            GhiChu = ghiChu;
            this.nktGioPhutChet = nktGioPhutChet;
            this.nktNoiChet = nktNoiChet;
            this.nktNguyenNhanChet = nktNguyenNhanChet;
            this.nktNoiCuTru = nktNoiCuTru;
            this.nycHoTen = nycHoTen;
            this.nycQuanHe = nycQuanHe;
            this.nguoiKy = nguoiKy;
            this.chucVuNguoiKy = chucVuNguoiKy;
            this.nguoiThucHien = nguoiThucHien;
            this.nktNgayCapGiayToTuyThan = nktNgayCapGiayToTuyThan;
            this.nktNoiCapGiayToTuyThan = nktNoiCapGiayToTuyThan;
            this.gbtLoai = gbtLoai;
            this.gbtSo = gbtSo;
            this.gbtNgay = gbtNgay;
            this.gbtCoQuanCap = gbtCoQuanCap;
            this.nycLoaiGiayToTuyThan = nycLoaiGiayToTuyThan;
            this.nycSoGiayToTuyThan = nycSoGiayToTuyThan;
            this.nycNgayCapGiayToTuyThan = nycNgayCapGiayToTuyThan;
            this.nycNoiCapGiayToTuyThan = nycNoiCapGiayToTuyThan;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;

            var kt = (HT_KHAITU)obj;

            return ID.Equals(kt.ID) &&
                    So.Equals(kt.So) &&
                    quyenSo.Equals(kt.quyenSo) &&
                    trangSo.Equals(kt.trangSo) &&
                    ngayDangKy.Equals(kt.ngayDangKy) &&
                    loaiDangKy.Equals(kt.loaiDangKy) &&
                    noiDangKy.Equals(kt.noiDangKy) &&
                    nktHoTen.Equals(kt.nktHoTen) &&
                    nktGioiTinh.Equals(kt.nktGioiTinh) &&
                    nktNgaySinh.Equals(kt.nktNgaySinh) &&
                    nktDanToc.Equals(kt.nktDanToc) &&
                    nktQuocTich.Equals(kt.nktQuocTich) &&
                    nktLoaiCuTru.Equals(kt.nktLoaiCuTru) &&
                    nktLoaiGiayToTuyThan.Equals(kt.nktLoaiGiayToTuyThan) &&
                    nktSoGiayToTuyThan.Equals(kt.nktSoGiayToTuyThan) &&
                    nktNgayChet.Equals(kt.nktNgayChet) &&
                    TinhTrangID.Equals(kt.TinhTrangID) &&
                    TenFile.Equals(kt.TenFile) &&
                    TenFileSauUpload.Equals(kt.TenFileSauUpload) &&
                    URLTapTinDinhKem.Equals(kt.URLTapTinDinhKem) &&
                    NamMoSo.Equals(kt.NamMoSo) &&
                    LoaiGiay.Equals(kt.LoaiGiay) &&
                    DuLieuCu.Equals(kt.DuLieuCu) &&
                    NgayCapNhat.Equals(kt.NgayCapNhat) &&
                    urlAnhCu.Equals(kt.urlAnhCu) &&
                    GhiChu.Equals(kt.GhiChu) &&
                    nktGioPhutChet.Equals(kt.nktGioPhutChet) &&
                    nktNoiChet.Equals(kt.nktNoiChet) &&
                    nktNguyenNhanChet.Equals(kt.nktNguyenNhanChet) &&
                    nktNoiCuTru.Equals(kt.nktNoiCuTru) &&
                    nycHoTen.Equals(kt.nycHoTen) &&
                    nycQuanHe.Equals(kt.nycQuanHe) &&
                    nguoiKy.Equals(kt.nguoiKy) &&
                    chucVuNguoiKy.Equals(kt.chucVuNguoiKy) &&
                    nguoiThucHien.Equals(kt.nguoiThucHien) &&
                    nktNgayCapGiayToTuyThan.Equals(kt.nktNgayCapGiayToTuyThan) &&
                    nktNoiCapGiayToTuyThan.Equals(kt.nktNoiCapGiayToTuyThan) &&
                    gbtLoai.Equals(kt.gbtLoai) &&
                    gbtSo.Equals(kt.gbtSo) &&
                    gbtNgay.Equals(kt.gbtNgay) &&
                    gbtCoQuanCap.Equals(kt.gbtCoQuanCap) &&
                    nycLoaiGiayToTuyThan.Equals(kt.nycLoaiGiayToTuyThan) &&
                    nycSoGiayToTuyThan.Equals(kt.nycSoGiayToTuyThan) &&
                    nycNgayCapGiayToTuyThan.Equals(kt.nycNgayCapGiayToTuyThan) &&
                    nycNoiCapGiayToTuyThan.Equals(kt.nycNoiCapGiayToTuyThan);
        }

        public override int GetHashCode()
        {
            int hashCode = 1059255516;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ID);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(So);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(quyenSo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(trangSo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ngayDangKy);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(loaiDangKy);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(noiDangKy);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nktHoTen);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nktGioiTinh);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nktNgaySinh);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nktDanToc);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nktQuocTich);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nktLoaiCuTru);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nktLoaiGiayToTuyThan);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nktSoGiayToTuyThan);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nktNgayChet);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TinhTrangID);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TenFile);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TenFileSauUpload);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(URLTapTinDinhKem);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NamMoSo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LoaiGiay);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DuLieuCu);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NgayCapNhat);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(urlAnhCu);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GhiChu);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nktGioPhutChet);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nktNoiChet);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nktNguyenNhanChet);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nktNoiCuTru);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nycHoTen);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nycQuanHe);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nguoiKy);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(chucVuNguoiKy);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nguoiThucHien);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nktNgayCapGiayToTuyThan);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nktNoiCapGiayToTuyThan);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(gbtLoai);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(gbtSo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(gbtNgay);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(gbtCoQuanCap);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nycLoaiGiayToTuyThan);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nycSoGiayToTuyThan);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nycNgayCapGiayToTuyThan);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nycNoiCapGiayToTuyThan);
            return hashCode;
        }
    }
}
