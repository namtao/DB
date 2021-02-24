using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    class HT_KETHON
    {
        public string ID, So, quyenSo, trangSo, ngayDangKy, loaiDangKy, noiDangKy, chongHoTen, chongNgaySinh, chongDanToc, chongQuocTich, chongLoaiCuTru, chongLoaiGiayToTuyThan, chongSoGiayToTuyThan, voHoTen, voNgaySinh, voDanToc, voQuocTich, voLoaiCuTru, voLoaiGiayToTuyThan, voSoGiayToTuyThan, TinhTrangID, TenFile, TenFileSauUpLoad, URLTapTinDinhKem, NamMoSo, LoaiGiay, DuLieuCu, NgayCapNhat, urlAnhCu, GhiChu, chongNoiCuTru, voNoiCuTru, nguoiKy, chucVuNguoiKy, nguoiThucHien, chongNgayCapGiayToTuyThan, chongNoiCapGiayToTuyThan, voNgayCapGiayToTuyThan, voNoiCapGiayToTuyThan;
        public HT_KETHON(string iD, string so, string quyenSo, string trangSo, string ngayDangKy, string loaiDangKy, string noiDangKy, string chongHoTen, string chongNgaySinh, string chongDanToc, string chongQuocTich, string chongLoaiCuTru, string chongLoaiGiayToTuyThan, string chongSoGiayToTuyThan, string voHoTen, string voNgaySinh, string voDanToc, string voQuocTich, string voLoaiCuTru, string voLoaiGiayToTuyThan, string voSoGiayToTuyThan, string tinhTrangID, string tenFile, string tenFileSauUpLoad, string uRLTapTinDinhKem, string namMoSo, string loaiGiay, string duLieuCu, string ngayCapNhat, string urlAnhCu, string ghiChu, string chongNoiCuTru, string voNoiCuTru, string nguoiKy, string chucVuNguoiKy, string nguoiThucHien, string chongNgayCapGiayToTuyThan, string chongNoiCapGiayToTuyThan, string voNgayCapGiayToTuyThan, string voNoiCapGiayToTuyThan)
        {
            ID = iD;
            So = so;
            this.quyenSo = quyenSo;
            this.trangSo = trangSo;
            this.ngayDangKy = ngayDangKy;
            this.loaiDangKy = loaiDangKy;
            this.noiDangKy = noiDangKy;
            this.chongHoTen = chongHoTen;
            this.chongNgaySinh = chongNgaySinh;
            this.chongDanToc = chongDanToc;
            this.chongQuocTich = chongQuocTich;
            this.chongLoaiCuTru = chongLoaiCuTru;
            this.chongLoaiGiayToTuyThan = chongLoaiGiayToTuyThan;
            this.chongSoGiayToTuyThan = chongSoGiayToTuyThan;
            this.voHoTen = voHoTen;
            this.voNgaySinh = voNgaySinh;
            this.voDanToc = voDanToc;
            this.voQuocTich = voQuocTich;
            this.voLoaiCuTru = voLoaiCuTru;
            this.voLoaiGiayToTuyThan = voLoaiGiayToTuyThan;
            this.voSoGiayToTuyThan = voSoGiayToTuyThan;
            TinhTrangID = tinhTrangID;
            TenFile = tenFile;
            TenFileSauUpLoad = tenFileSauUpLoad;
            URLTapTinDinhKem = uRLTapTinDinhKem;
            NamMoSo = namMoSo;
            LoaiGiay = loaiGiay;
            DuLieuCu = duLieuCu;
            NgayCapNhat = ngayCapNhat;
            this.urlAnhCu = urlAnhCu;
            GhiChu = ghiChu;
            this.chongNoiCuTru = chongNoiCuTru;
            this.voNoiCuTru = voNoiCuTru;
            this.nguoiKy = nguoiKy;
            this.chucVuNguoiKy = chucVuNguoiKy;
            this.nguoiThucHien = nguoiThucHien;
            this.chongNgayCapGiayToTuyThan = chongNgayCapGiayToTuyThan;
            this.chongNoiCapGiayToTuyThan = chongNoiCapGiayToTuyThan;
            this.voNgayCapGiayToTuyThan = voNgayCapGiayToTuyThan;
            this.voNoiCapGiayToTuyThan = voNoiCapGiayToTuyThan;
        }

        public HT_KETHON()
        {
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;

            var kh = (HT_KETHON)obj;

            return ID == kh.ID &&
                   So == kh.So &&
                   quyenSo == kh.quyenSo &&
                   trangSo == kh.trangSo &&
                   ngayDangKy == kh.ngayDangKy &&
                   loaiDangKy == kh.loaiDangKy &&
                   noiDangKy == kh.noiDangKy &&
                   chongHoTen == kh.chongHoTen &&
                   chongNgaySinh == kh.chongNgaySinh &&
                   chongDanToc == kh.chongDanToc &&
                   chongQuocTich == kh.chongQuocTich &&
                   chongLoaiCuTru == kh.chongLoaiCuTru &&
                   chongLoaiGiayToTuyThan == kh.chongLoaiGiayToTuyThan &&
                   chongSoGiayToTuyThan == kh.chongSoGiayToTuyThan &&
                   voHoTen == kh.voHoTen &&
                   voNgaySinh == kh.voNgaySinh &&
                   voDanToc == kh.voDanToc &&
                   voQuocTich == kh.voQuocTich &&
                   voLoaiCuTru == kh.voLoaiCuTru &&
                   voLoaiGiayToTuyThan == kh.voLoaiGiayToTuyThan &&
                   voSoGiayToTuyThan == kh.voSoGiayToTuyThan &&
                   TinhTrangID == kh.TinhTrangID &&
                   TenFile == kh.TenFile &&
                   TenFileSauUpLoad == kh.TenFileSauUpLoad &&
                   URLTapTinDinhKem == kh.URLTapTinDinhKem &&
                   NamMoSo == kh.NamMoSo &&
                   LoaiGiay == kh.LoaiGiay &&
                   DuLieuCu == kh.DuLieuCu &&
                   NgayCapNhat == kh.NgayCapNhat &&
                   urlAnhCu == kh.urlAnhCu &&
                   GhiChu == kh.GhiChu &&
                   chongNoiCuTru == kh.chongNoiCuTru &&
                   voNoiCuTru == kh.voNoiCuTru &&
                   nguoiKy == kh.nguoiKy &&
                   chucVuNguoiKy == kh.chucVuNguoiKy &&
                   nguoiThucHien == kh.nguoiThucHien &&
                   chongNgayCapGiayToTuyThan == kh.chongNgayCapGiayToTuyThan &&
                   chongNoiCapGiayToTuyThan == kh.chongNoiCapGiayToTuyThan &&
                   voNgayCapGiayToTuyThan == kh.voNgayCapGiayToTuyThan &&
                   voNoiCapGiayToTuyThan == kh.voNoiCapGiayToTuyThan;
        }
    }
}
