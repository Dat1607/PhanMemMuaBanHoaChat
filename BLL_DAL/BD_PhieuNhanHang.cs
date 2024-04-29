using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BD_PhieuNhanHang
    {
        QLMuaBanHoaChatDataContext db = new QLMuaBanHoaChatDataContext();
        public List<PNH> GetDataPNH()
        {
            var PNHs = from PNH in db.PhieuNhanHangs
                       join ncc in db.NhaCungCaps on PNH.MaNCC equals ncc.MaNCC
                       join nv in db.NhanViens on PNH.MaNhanVien equals nv.MaNhanVien
                       select new PNH { MaPNH = PNH.MaPhieuNhanHang, MaNCC = PNH.MaNCC, TenNCC = ncc.TenNCC, NgayLap = PNH.NgayLap, NgayGiao = PNH.NgayGiao, TongThanhTien = PNH.TongThanhTien, Thue = PNH.Thue, TongCongThanhToan = PNH.TongCongThanhToan, GhiChu = PNH.GhiChu, MaNV = PNH.MaNhanVien, TenNV = nv.TenNhanVien, DiaChiGiao = ncc.DiaChiNCC };
            return PNHs.ToList();
        }
        public PNHCTiet GetDataPNHang(string maPNH)
        {
            var PNHss = from PNH in db.PhieuNhanHangs
                        join nv in db.NhanViens on PNH.MaNhanVien equals nv.MaNhanVien
                        join ncc in db.NhaCungCaps on PNH.MaNCC equals ncc.MaNCC
                        where PNH.MaPhieuNhanHang == maPNH
                        select new PNHCTiet { MaPNH = PNH.MaPhieuNhanHang, MaNCC = PNH.MaNCC, TenNCC = ncc.TenNCC, NgayLap = PNH.NgayLap, NgayGiao = PNH.NgayGiao, TongThanhTien = PNH.TongThanhTien, Thue = PNH.Thue, TongCongThanhToan = PNH.TongCongThanhToan, GhiChu = PNH.GhiChu, MaNV = PNH.MaNhanVien, TenNV = nv.TenNhanVien, DiaChiGiao = ncc.DiaChiNCC };
            return PNHss.FirstOrDefault();
        }
        public List<CTPNH> GetDataCTPNH(string maPNH)
        {
            var ctPNHss = from ctPNH in db.CTPhieuNhanHangs
                          join hh in db.Khos on ctPNH.MaHangHoa equals hh.MaHangHoa
                          join PNH in db.PhieuNhanHangs on ctPNH.MaPhieuNhanHang equals PNH.MaPhieuNhanHang
                          where ctPNH.MaPhieuNhanHang == maPNH
                          select new CTPNH { MaPNH = ctPNH.MaPhieuNhanHang, MaHangHoa = ctPNH.MaHangHoa, TenHangHoa = hh.TenHangHoa, DonViTinh = hh.DonViTinh, SoLuong = ctPNH.SoLuong, QuyCach = ctPNH.QuyCach, DonGia = ctPNH.DonGia, ThanhTien = ctPNH.ThanhTien };
            return ctPNHss.ToList();
        }
        public List<CTPNHCTiet> GetDataCTPNHang(string maPNH)
        {
            var ctPNHs = from ctPNH in db.CTPhieuNhanHangs
                         join hh in db.Khos on ctPNH.MaHangHoa equals hh.MaHangHoa
                         join PNH in db.PhieuNhanHangs on ctPNH.MaPhieuNhanHang equals PNH.MaPhieuNhanHang
                         where PNH.MaPhieuNhanHang == maPNH
                         select new CTPNHCTiet { MaHangHoa = ctPNH.MaHangHoa, TenHangHoa = hh.TenHangHoa, DonViTinh = hh.DonViTinh, SoLuong = ctPNH.SoLuong, QuyCach = ctPNH.QuyCach, DonGia = ctPNH.DonGia, ThanhTien = ctPNH.ThanhTien };
            return ctPNHs.ToList();
        }
        public List<PNH> TimKiemPNH(string timkiem)
        {
            var PNHs = from PNH in db.PhieuNhanHangs
                       join nv in db.NhanViens on PNH.MaNhanVien equals nv.MaNhanVien
                       join ncc in db.NhaCungCaps on PNH.MaNCC equals ncc.MaNCC
                       where ncc.TenNCC.Contains(timkiem)
                       select new PNH { MaPNH = PNH.MaPhieuNhanHang, MaNCC = PNH.MaNCC, TenNCC = ncc.TenNCC, NgayLap = PNH.NgayLap, NgayGiao = PNH.NgayGiao, TongThanhTien = PNH.TongThanhTien, Thue = PNH.Thue, TongCongThanhToan = PNH.TongCongThanhToan, GhiChu = PNH.GhiChu, MaNV = PNH.MaNhanVien, TenNV = nv.TenNhanVien };
            return PNHs.ToList();
        }
        public void themPNH(string maPNH, DateTime ngaylap, DateTime ngayGiao, double tongtt, string thue, double tongcongtt, string mancc, string manv, string ghichu, string[] mahh, int[] soL, string[] quycach, double[] dongia, double[] thanhtien)
        {
            db.PhieuNhanHangs.InsertOnSubmit(new PhieuNhanHang
            {
                MaPhieuNhanHang = maPNH,
                NgayLap = ngaylap,
                NgayGiao = ngayGiao,
                TongThanhTien = tongtt,
                Thue = thue,
                TongCongThanhToan = tongcongtt,
                MaNCC = mancc,
                MaNhanVien = manv,
                GhiChu = ghichu
            });
            db.SubmitChanges();

            for (int i = 0; i < mahh.Length; i++)
            {
                db.CTPhieuNhanHangs.InsertOnSubmit(new CTPhieuNhanHang
                {
                    MaPhieuNhanHang = maPNH,
                    MaHangHoa = mahh[i],
                    SoLuong = soL[i],
                    QuyCach = quycach[i],
                    DonGia = dongia[i],
                    ThanhTien = thanhtien[i]
                });
                db.SubmitChanges();
            }
        }
        public List<PNH> LocPhieuNhanHangTheoNgay(string loaiLoc)
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

            var result = from PNH in db.PhieuNhanHangs
                         join ncc in db.NhaCungCaps on PNH.MaNCC equals ncc.MaNCC
                         join nv in db.NhanViens on PNH.MaNhanVien equals nv.MaNhanVien
                         where PNH.NgayLap >= ngayBatDau && PNH.NgayLap < ngayKetThuc
                         select new PNH { MaPNH = PNH.MaPhieuNhanHang, MaNCC = PNH.MaNCC, TenNCC = ncc.TenNCC, NgayLap = PNH.NgayLap, NgayGiao = PNH.NgayGiao, TongThanhTien = PNH.TongThanhTien, Thue = PNH.Thue, TongCongThanhToan = PNH.TongCongThanhToan, GhiChu = PNH.GhiChu, MaNV = PNH.MaNhanVien, TenNV = nv.TenNhanVien, DiaChiGiao = ncc.DiaChiNCC };

            return result.ToList();
        }
        
        }
}
