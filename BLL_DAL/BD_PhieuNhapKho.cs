using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BD_PhieuNhapKho
    {
        QLMuaBanHoaChatDataContext db = new QLMuaBanHoaChatDataContext();
        public List<PN> GetDataPN()
        {
            var pns = from pn in db.PhieuNhaps
                      join nv in db.NhanViens on pn.MaNV equals nv.MaNhanVien
                      select new PN { Mapn = pn.MaPN, NgayLap = pn.NgayLap, TongSoLuong = pn.TongSoLuong, MaNV = pn.MaNV, TenNV = nv.TenNhanVien };
            return pns.ToList();
        }
        public PNCTiet GetDataPNhap(string mapn)
        {
            var pnss = from pn in db.PhieuNhaps
                       join nv in db.NhanViens on pn.MaNV equals nv.MaNhanVien
                       where pn.MaPN == mapn
                       select new PNCTiet { Mapn = pn.MaPN, NgayLap = pn.NgayLap, TongSoLuong = pn.TongSoLuong, MaNV = pn.MaNV, TenNV = nv.TenNhanVien };
            return pnss.FirstOrDefault();
        }
        public List<CTPN> GetDataCTPN(string mapn)
        {
            var ctpnss = from ctpn in db.CTPhieuNhaps
                         join hh in db.Khos on ctpn.MaHangHoa equals hh.MaHangHoa
                         join pn in db.PhieuNhaps on ctpn.MaPN equals pn.MaPN
                         where ctpn.MaPN == mapn
                         select new CTPN { Mapn = ctpn.MaPN, MaHangHoa = ctpn.MaHangHoa, TenHangHoa = hh.TenHangHoa, SoLuongNhap = ctpn.SoLuongXuat, DonViTinh = hh.DonViTinh };
            return ctpnss.ToList();
        }
        public List<CTPNCTiet> GetDataCTPNhap(string mapn)
        {
            var ctpns = from ctpn in db.CTPhieuNhaps
                        join hh in db.Khos on ctpn.MaHangHoa equals hh.MaHangHoa
                        join pn in db.CTPhieuNhaps on ctpn.MaPN equals pn.MaPN
                        where pn.MaPN == mapn
                        select new CTPNCTiet { MaHangHoa = ctpn.MaHangHoa, TenHangHoa = hh.TenHangHoa, SoLuongNhap = ctpn.SoLuongXuat, DonViTinh = hh.DonViTinh };
            return ctpns.Distinct().ToList();
        }
        public List<PN> TimKiemPN(string timkiem)
        {
            var pns = from pn in db.PhieuNhaps
                      join nv in db.NhanViens on pn.MaNV equals nv.MaNhanVien
                      where nv.TenNhanVien.Contains(timkiem)
                      select new PN { Mapn = pn.MaPN, NgayLap = pn.NgayLap, TongSoLuong = pn.TongSoLuong, MaNV = pn.MaNV, TenNV = nv.TenNhanVien };
            return pns.ToList();
        }
        public void themPN(string mapn, DateTime ngaylap, int tongSL, string manv, string[] mahh, int[] sol)
        {
            db.PhieuNhaps.InsertOnSubmit(new PhieuNhap
            {
                MaPN = mapn,
                NgayLap = ngaylap,
                TongSoLuong = tongSL,
                MaNV = manv

            });
            db.SubmitChanges();

            for (int i = 0; i < mahh.Length; i++)
            {
                db.CTPhieuNhaps.InsertOnSubmit(new CTPhieuNhap
                {
                    MaPN = mapn,
                    MaHangHoa = mahh[i],
                    SoLuongXuat = sol[i]
                });
                db.SubmitChanges();

            }
        }
        public List<PN> LocPhieuNhapTheoNgay(string loaiLoc)
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

            var result = from pn in db.PhieuNhaps
                         join nv in db.NhanViens on pn.MaNV equals nv.MaNhanVien
                         where pn.NgayLap >= ngayBatDau && pn.NgayLap < ngayKetThuc
                         select new PN { Mapn = pn.MaPN, NgayLap = pn.NgayLap, TongSoLuong = pn.TongSoLuong, MaNV = pn.MaNV, TenNV = nv.TenNhanVien };

            return result.ToList();
        }
    }
}
