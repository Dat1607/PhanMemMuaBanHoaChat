using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class CTPNH
    {
        public string MaPNH { get; internal set; }
        public string MaHangHoa { get; internal set; }
        public string TenHangHoa { get; internal set; }
        public string DonViTinh { get; internal set; }
        public int? SoLuong { get; internal set; }
        public string QuyCach { get; internal set; }
        public double? DonGia { get; internal set; }
        public double? ThanhTien { get; internal set; }
    }
}
