using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class THONGK
    {
        public DateTime? NgayLapHD { get; internal set; }
        public string MaHD { get; internal set; }
        public double? TongTien { get; internal set; }
        public double? Thue { get; internal set; }
        public double? TongThanhTien { get; internal set; }
        public string MaKH { get; internal set; }
        public string TenKH { get; internal set; }
    }
}
