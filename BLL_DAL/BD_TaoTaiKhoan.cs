using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BD_TaoTaiKhoan
    {
        QLMuaBanHoaChatDataContext db = new QLMuaBanHoaChatDataContext();
        public List<TaiKhoan> LoadTK()
        {
            var tks = from tk in db.TaiKhoans select tk;
            return tks.ToList();
        }

        public void TaoTk(string tendk, string mk)
        {
            db.TaiKhoans.InsertOnSubmit(new TaiKhoan { TenDangNhap = tendk, MatKhau = mk });
            db.SubmitChanges();
        }
        public bool KiemTraTrungTenDK(string tendk)
        {
            var dk = db.TaiKhoans.FirstOrDefault(t => t.TenDangNhap == tendk);
            return dk == null;
        }
    }
}
