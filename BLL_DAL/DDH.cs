using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class DDH
    {
        public string MaDDH { get; internal set; }
        public int? TongSL { get; internal set; }
        public double? TongThanhTien { get; internal set; }
        public DateTime? NgayDat { get; internal set; }
        public string TinhTrangDonDatHang { get; internal set; }
        public string MaNCC { get; internal set; }

    }
}
