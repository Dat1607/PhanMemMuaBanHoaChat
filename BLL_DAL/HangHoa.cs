using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class HangHoa
    {
        public int STT { get; internal set; }
        public string MaHangHoa { get; internal set; }
        public string TenHangHoa { get; internal set; }
        public int? SoLuong { get; internal set; }
        public string DonViTinh { get; internal set; }
        public string TenNSX { get; internal set; }
        public string XuatXu { get; internal set; }
        public double? DonGia { get; internal set; }
    }
}
