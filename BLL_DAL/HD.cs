using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class HD
    {
        public string MaHD { get; internal set; }
        public DateTime? NgayLap { get; internal set; }
        public double? TongThanhTien { get; internal set; }
        public string Thue { get; internal set; }
        public double? TongCongThanhToan { get; internal set; }
        public string HinhThucThanhToan { get; internal set; }
        public string MaNV { get; internal set; }
        public string MaKH { get; internal set; }
    }
}
