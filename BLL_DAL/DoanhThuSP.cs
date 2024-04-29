using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class DoanhThuSP
    {
        public string MaKH { get; internal set; }
        public DateTime? NgayLapHD { get; internal set; }
        public string MaHD { get; internal set; }
        public string TenKH { get; internal set; }
        public string TenHH { get; internal set; }
        public string DonVT { get; internal set; }
        public double? DonGia { get; internal set; }
        public int? SoLuong { get; internal set; }
        public double? ThanhTien { get; internal set; }
    }
}
