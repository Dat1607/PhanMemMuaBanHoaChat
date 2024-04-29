using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BD_DoanhThuSP
    {
        QLMuaBanHoaChatDataContext db = new QLMuaBanHoaChatDataContext();
        public List<DoanhThuSP> GetInvoicesByDate(DateTime ngayDau, DateTime ngayCuoi)
        {
            var hds = (from hd in db.HoaDons
                       join kh in db.KhachHangs on hd.MaKH equals kh.MaKhachHang
                       join cthd in db.CTHoaDons on hd.MaHD equals cthd.MaHD
                       join hh in db.Khos on cthd.MaHangHoa equals hh.MaHangHoa
                       where hd.NgayLap >= ngayDau && hd.NgayLap <= ngayCuoi
                       select new
                       {
                           hd.MaKH,
                           hd.NgayLap,
                           hd.MaHD,
                           kh.TenKhachHang,
                           hh.TenHangHoa,
                           hh.DonViTinh,
                           cthd.DonGia,
                           cthd.SoLuong,
                           cthd.ThanhTien
                       }).ToList()
               .Select(hd => new DoanhThuSP
               {
                   MaKH = hd.MaKH,
                   NgayLapHD = hd.NgayLap,
                   MaHD = hd.MaHD,
                   TenKH = hd.TenKhachHang,
                   TenHH = hd.TenHangHoa,
                   DonVT = hd.DonViTinh,
                   DonGia = hd.DonGia,
                   SoLuong = hd.SoLuong,
                   ThanhTien = hd.ThanhTien,
               }).ToList();

            return hds;
        }
    }
}


