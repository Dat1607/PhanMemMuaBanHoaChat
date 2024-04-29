using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BD_CongNo
    {
        QLMuaBanHoaChatDataContext db = new QLMuaBanHoaChatDataContext();
        public List<CONGN> GetInvoicesByDate(string TenKH, DateTime ngayChon)
        {
            var hds = from hd in db.HoaDons
                      join ctptt in db.CTPhieuThanhToans on hd.MaHD equals ctptt.MaHD into ctGroup
                      from ctptt in ctGroup.DefaultIfEmpty()
                      join ptt in db.PhieuThanhToans on ctptt.MaPThanhToan equals ptt.MaPThanhToan into ptGroup
                      from ptt in ptGroup.DefaultIfEmpty()
                      where hd.NgayLap <= ngayChon && hd.KhachHang.MaKhachHang == TenKH
                      select new CONGN
                      {
                          MaHD = hd.MaHD,
                          NgayLapHD = hd.NgayLap,
                          TongThanhTien = hd.TongCongThanhToan,
                          ThanhToan = ptt != null ? ptt.ThanhToan : (double?)null,
                          NgayThanhToan = ptt != null ? ptt.NgayLap : (DateTime?)null
                      };
            return hds.ToList();
        }
    }
}
