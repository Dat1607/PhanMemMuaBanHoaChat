using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BD_BaoGia
    {
        QLMuaBanHoaChatDataContext db = new QLMuaBanHoaChatDataContext();
        public List<BaoGia> GetData()
        {
            var bgs = from bg in db.BaoGias select bg;
            return bgs.ToList();
        }
        public List<BG> GetDataBG()
        {
            var bgs = from bg in db.BaoGias
                      join nv in db.NhanViens on bg.MaNhanVien equals nv.MaNhanVien
                      join kh in db.KhachHangs on bg.MaKhachHang equals kh.MaKhachHang
                      select new BG { MaBG = bg.MaPhieuBaoGia, MaKH = bg.MaKhachHang, TenKH = kh.TenKhachHang, NgayLap = bg.NgayLap, MaNV = bg.MaNhanVien, TenNV = nv.TenNhanVien };
            return bgs.ToList();
        }
        public BGCTiet GetDataBGia(string mabg)
        {
            var bgss = from bg in db.BaoGias
                       join nv in db.NhanViens on bg.MaNhanVien equals nv.MaNhanVien
                       join kh in db.KhachHangs on bg.MaKhachHang equals kh.MaKhachHang
                       where bg.MaPhieuBaoGia == mabg
                       select new BGCTiet { MaBG = bg.MaPhieuBaoGia, MaKH = bg.MaKhachHang, TenKH = kh.TenKhachHang, NgayLap = bg.NgayLap, MaNV = bg.MaNhanVien, TenNV = nv.TenNhanVien };
            return bgss.FirstOrDefault();
        }
        public List<CTBG> GetDataCTBG(string mabg)
        {
            var ctbgss = from ctbg in db.CTBaoGias
                         join hh in db.Khos on ctbg.MaHangHoa equals hh.MaHangHoa
                         join bg in db.BaoGias on ctbg.MaPhieuBaoGia equals bg.MaPhieuBaoGia
                         where ctbg.MaPhieuBaoGia == mabg
                         select new CTBG { MaBG = ctbg.MaPhieuBaoGia, MaHangHoa = ctbg.MaHangHoa, TenHangHoa = hh.TenHangHoa, QuyCach = ctbg.QuyCach, DonGia = ctbg.DonGia, XuatXu = hh.XuatXu, GhiChu = ctbg.GhiChu };
            return ctbgss.ToList();
        }
        public List<CTBGCTiet> GetDataCTBGia(string mabg)
        {
            var ctbgs = from ctbg in db.CTBaoGias
                        join hh in db.Khos on ctbg.MaHangHoa equals hh.MaHangHoa
                        join bg in db.BaoGias on ctbg.MaPhieuBaoGia equals bg.MaPhieuBaoGia
                        where bg.MaPhieuBaoGia == mabg
                        select new CTBGCTiet { MaHangHoa = ctbg.MaHangHoa, TenHangHoa = hh.TenHangHoa, QuyCach = ctbg.QuyCach, DonGia = ctbg.DonGia, XuatXu = hh.XuatXu, GhiChu = ctbg.GhiChu };
            return ctbgs.ToList();
        }
        public List<BG> TimKiemBG(string timkiem)
        {
            var bgs = from bg in db.BaoGias
                      join nv in db.NhanViens on bg.MaNhanVien equals nv.MaNhanVien
                      join kh in db.KhachHangs on bg.MaKhachHang equals kh.MaKhachHang
                      where kh.TenKhachHang.Contains(timkiem)
                      select new BG { MaBG = bg.MaPhieuBaoGia, MaKH = bg.MaKhachHang, TenKH = kh.TenKhachHang, NgayLap = bg.NgayLap, MaNV = bg.MaNhanVien, TenNV = nv.TenNhanVien };
            return bgs.ToList();
        }
        public void themBG(string mabg, DateTime ngaylap, string makh, string manv, string[] mahh, string[] quycach, double[] dongia, string[] ghichu)
        {
            db.BaoGias.InsertOnSubmit(new BaoGia
            {
                MaPhieuBaoGia = mabg,
                NgayLap = ngaylap,
                MaKhachHang = makh,
                MaNhanVien = manv
            });
            db.SubmitChanges();

            for (int i = 0; i < mahh.Length; i++)
            {
                db.CTBaoGias.InsertOnSubmit(new CTBaoGia
                {
                    MaPhieuBaoGia = mabg,
                    MaHangHoa = mahh[i],
                    QuyCach = quycach[i],
                    DonGia = dongia[i],
                    GhiChu = ghichu[i]
                });
                db.SubmitChanges();
            }
        }
        public List<BG> LocBaoGiaTheoNgay(string loaiLoc)
        {
            DateTime ngayBatDau, ngayKetThuc;

            switch (loaiLoc)
            {
                case "Ngay":
                    ngayBatDau = DateTime.Today;
                    ngayKetThuc = ngayBatDau.AddDays(1);
                    break;
                case "Tuan":
                    ngayBatDau = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
                    ngayKetThuc = ngayBatDau.AddDays(7);
                    break;
                case "Thang":
                    ngayBatDau = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    ngayKetThuc = ngayBatDau.AddMonths(1);
                    break;
                case "Quy1":
                    ngayBatDau = new DateTime(DateTime.Today.Year, 1, 1);
                    ngayKetThuc = new DateTime(DateTime.Today.Year, 3, 31).AddDays(1);
                    break;
                case "Quy2":
                    ngayBatDau = new DateTime(DateTime.Today.Year, 4, 1);
                    ngayKetThuc = new DateTime(DateTime.Today.Year, 6, 30).AddDays(1);
                    break;
                case "Quy3":
                    ngayBatDau = new DateTime(DateTime.Today.Year, 7, 1);
                    ngayKetThuc = new DateTime(DateTime.Today.Year, 9, 30).AddDays(1);
                    break;
                case "Quy4":
                    ngayBatDau = new DateTime(DateTime.Today.Year, 10, 1);
                    ngayKetThuc = new DateTime(DateTime.Today.Year, 12, 31).AddDays(1);
                    break;
                case "NuaNam1":
                    ngayBatDau = new DateTime(DateTime.Today.Year, 1, 1);
                    ngayKetThuc = new DateTime(DateTime.Today.Year, 6, 30).AddDays(1);
                    break;
                case "NuaNam2":
                    ngayBatDau = new DateTime(DateTime.Today.Year, 7, 1);
                    ngayKetThuc = new DateTime(DateTime.Today.Year, 12, 31).AddDays(1);
                    break;
                case "CaNam":
                    ngayBatDau = new DateTime(DateTime.Today.Year, 1, 1);
                    ngayKetThuc = new DateTime(DateTime.Today.Year, 12, 31).AddDays(1);
                    break;
                default:
                    return null;
            }

            var result = from bg in db.BaoGias
                         join nv in db.NhanViens on bg.MaNhanVien equals nv.MaNhanVien
                         join kh in db.KhachHangs on bg.MaKhachHang equals kh.MaKhachHang
                         where bg.NgayLap >= ngayBatDau && bg.NgayLap < ngayKetThuc
                         select new BG { MaBG = bg.MaPhieuBaoGia, MaKH = bg.MaKhachHang, TenKH = kh.TenKhachHang, NgayLap = bg.NgayLap, MaNV = bg.MaNhanVien, TenNV = nv.TenNhanVien };

            return result.ToList();
        }
    }
}
