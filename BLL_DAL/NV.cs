using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class NV
    {
        public string MaNhanVien { get; internal set; }
        public object TenNhanVien { get; internal set; }
        public DateTime? NgaySinh { get; internal set; }
        public object CanCuocCongDan { get; internal set; }
        public string Email { get; internal set; }
        public object SoDienThoai { get; internal set; }
        public string TenChucVu { get; internal set; }
        public double? LuongCS { get; internal set; }
        public double? HeSL { get; internal set; }
        public double? PhuCap { get; internal set; }
        public double? TienThuong { get; internal set; }
        public double? LuongCB { get; internal set; }
        public string TaiKhoan { get; internal set; }
        public string MatKhau { get; internal set; }
    }
}
