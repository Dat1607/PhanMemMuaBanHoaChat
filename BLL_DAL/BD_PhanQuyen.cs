using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BD_PhanQuyen
    {
        QLMuaBanHoaChatDataContext db = new QLMuaBanHoaChatDataContext();
        public List<TaiKhoan> LoadTaiKhoan()
        {
            var tks = from tk in db.TaiKhoans select tk;
            return tks.ToList();
        }
        public List<QuyenTaiKhoan> LoadQuyenTK()
        {
            var pqs = from pq in db.PhanQuyens select new QuyenTaiKhoan { TenDangNhap = pq.TenDangNhap, TenQuyen = pq.TenQuyen};
            return pqs.ToList();
        }
        public void themPQ(string tentk, string tenq)
        {
            db.PhanQuyens.InsertOnSubmit(new PhanQuyen { TenDangNhap = tentk, TenQuyen = tenq });
            db.SubmitChanges();
        }
        public void xoaPQ(string tentk)
        {
            PhanQuyen pqs = db.PhanQuyens.Where(t => t.TenDangNhap == tentk).FirstOrDefault();
            db.PhanQuyens.DeleteOnSubmit(pqs);
            db.SubmitChanges();
        }
        public void suaPQ(string tentk, string tenq)
        {
            PhanQuyen pqs = db.PhanQuyens.Where(t => t.TenDangNhap == tentk).FirstOrDefault();
            pqs.TenQuyen = tenq;
            db.SubmitChanges();
        }
        public bool KiemTraXetQuyen(string tentk)
        {
            var pqs = db.PhanQuyens.FirstOrDefault(t => t.TenDangNhap == tentk);
            return pqs == null;
        }
        public bool KiemTraQuyen(string tentk, string tenquyen)
        {
            var pqs = db.PhanQuyens.Any(pq => pq.TenDangNhap == tentk && pq.TenQuyen == tenquyen);
            return pqs;
        }
    }
}
