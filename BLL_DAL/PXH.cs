using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class PXH
    {
        public string MaPXH { get; internal set; }
        public string MaKH { get; internal set; }
        public string TenKH { get; internal set; }
        public DateTime? NgayLap { get; internal set; }
        public DateTime? NgayGiao { get; internal set; }
        public double? TongThanhTien { get; internal set; }
        public string Thue { get; internal set; }
        public double? TongCongThanhToan { get; internal set; }
        public string TinhTrangPXH { get; internal set; }
        public string GhiChu { get; internal set; }
        public string MaNV { get; internal set; }
        public string TenNV { get; internal set; }
        public string DiaChiGiao { get; internal set; }
    }
}
