using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BD_DangNhap
    {
        QLMuaBanHoaChatDataContext db = new QLMuaBanHoaChatDataContext();
        public bool KiemTraDangNhap(string tendn, string mk)
        {
            var dn = db.TaiKhoans.FirstOrDefault(t => t.TenDangNhap == tendn && t.MatKhau == mk);
            return dn != null;
        }
    }
}
