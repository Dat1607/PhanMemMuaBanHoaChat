using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BD_Quyen
    {
        QLMuaBanHoaChatDataContext db = new QLMuaBanHoaChatDataContext();   
        public List<Quyen> LoadQuyen()
        {
            var qs = from q in db.Quyens select q;
            return qs.ToList();
        }
        public void themQ(string tenquyen)
        {
            db.Quyens.InsertOnSubmit(new Quyen { TenQuyen = tenquyen });
            db.SubmitChanges();
        }
        public void xoaQ(string tenquyen)
        {
            Quyen qs = db.Quyens.Where(t => t.TenQuyen == tenquyen).FirstOrDefault();
            db.Quyens.DeleteOnSubmit(qs);
            db.SubmitChanges();
        }
        public bool KiemTraQ(string tenquyen)
        {
            var qs = db.PhanQuyens.FirstOrDefault(t => t.TenQuyen== tenquyen);
            return qs != null;
        }
        public bool KiemTraThemQ(string tenq)
        {
            var qs = db.Quyens.FirstOrDefault(t => t.TenQuyen == tenq);
            return qs == null;
        }
    }
}
