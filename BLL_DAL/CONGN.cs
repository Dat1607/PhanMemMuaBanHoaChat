using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class CONGN
    {
        public string MaHD { get; internal set; }
        public DateTime? NgayLapHD { get; internal set; }
        public double? TongThanhTien { get; internal set; }
        public double? ThanhToan { get; internal set; }
        public DateTime? NgayThanhToan { get; internal set; }
    }
}
