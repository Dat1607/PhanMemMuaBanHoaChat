using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BD_PhieuXuatKho
    {
        QLMuaBanHoaChatDataContext db = new QLMuaBanHoaChatDataContext();
        public List<PX> GetDataPX()
        {
            var PXs = from PX in db.PhieuXuats
                      join nv in db.NhanViens on PX.MaNV equals nv.MaNhanVien
                      select new PX { MaPX = PX.MaPX, NgayLap = PX.NgayLap, TongSoLuong = PX.TongSoLuong, MaNV = PX.MaNV, TenNV = nv.TenNhanVien };
            return PXs.ToList();
        }
        public PXCTiet GetDataPXuat(string maPX)
        {
            var PXss = from PX in db.PhieuXuats
                       join nv in db.NhanViens on PX.MaNV equals nv.MaNhanVien
                       where PX.MaPX == maPX
                       select new PXCTiet { MaPX = PX.MaPX, NgayLap = PX.NgayLap, TongSoLuong = PX.TongSoLuong, MaNV = PX.MaNV, TenNV = nv.TenNhanVien };
            return PXss.FirstOrDefault();
        }
        public List<CTPX> GetDataCTPX(string maPX)
        {
            var ctPXss = from ctPX in db.CTPhieuXuats
                         join hh in db.Khos on ctPX.MaHangHoa equals hh.MaHangHoa
                         join PX in db.PhieuXuats on ctPX.MaPX equals PX.MaPX
                         where ctPX.MaPX == maPX
                         select new CTPX { MaPX = ctPX.MaPX, MaHangHoa = ctPX.MaHangHoa, TenHangHoa = hh.TenHangHoa, SoLuongNhap = ctPX.SoLuongXuat, DonViTinh = hh.DonViTinh };
            return ctPXss.ToList();
        }
        public List<CTPXCTiet> GetDataCTPXuat(string maPX)
        {
            var ctPXs = from ctPX in db.CTPhieuXuats
                        join hh in db.Khos on ctPX.MaHangHoa equals hh.MaHangHoa
                        join PX in db.CTPhieuXuats on ctPX.MaPX equals PX.MaPX
                        where PX.MaPX == maPX
                        select new CTPXCTiet { MaHangHoa = ctPX.MaHangHoa, TenHangHoa = hh.TenHangHoa, SoLuongNhap = ctPX.SoLuongXuat, DonViTinh = hh.DonViTinh };
            return ctPXs.Distinct().ToList();
        }
        public List<PX> TimKiemPX(string timkiem)
        {
            var PXs = from PX in db.PhieuXuats
                      join nv in db.NhanViens on PX.MaNV equals nv.MaNhanVien
                      where nv.TenNhanVien.Contains(timkiem)
                      select new PX { MaPX = PX.MaPX, NgayLap = PX.NgayLap, TongSoLuong = PX.TongSoLuong, MaNV = PX.MaNV, TenNV = nv.TenNhanVien };
            return PXs.ToList();
        }
        public void themPX(string maPX, DateTime ngaylap, int tongSL, string manv, string[] mahh, int[] sol)
        {
            db.PhieuXuats.InsertOnSubmit(new PhieuXuat
            {
                MaPX = maPX,
                NgayLap = ngaylap,
                TongSoLuong = tongSL,
                MaNV = manv

            });
            db.SubmitChanges();

            for (int i = 0; i < mahh.Length; i++)
            {
                db.CTPhieuXuats.InsertOnSubmit(new CTPhieuXuat
                {
                    MaPX = maPX,
                    MaHangHoa = mahh[i],
                    SoLuongXuat = sol[i]
                });
                db.SubmitChanges();

            }
        }
        public List<PX> LocPhieuXuatHangTheoNgay(string loaiLoc)
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

            var result = from PX in db.PhieuXuats
                         join nv in db.NhanViens on PX.MaNV equals nv.MaNhanVien
                         where PX.NgayLap >= ngayBatDau && PX.NgayLap < ngayKetThuc
                         select new PX { MaPX = PX.MaPX, NgayLap = PX.NgayLap, TongSoLuong = PX.TongSoLuong, MaNV = PX.MaNV, TenNV = nv.TenNhanVien };

            return result.ToList();
        }
    }
}
