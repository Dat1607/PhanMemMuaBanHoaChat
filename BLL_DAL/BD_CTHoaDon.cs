using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BD_CTHoaDon
    {
        QLMuaBanHoaChatDataContext db = new QLMuaBanHoaChatDataContext();
        public List<string> GetMaHH(string maHD)
        {
            var mahhs = from hh in db.Khos
                        join cthd in db.CTHoaDons on hh.MaHangHoa equals cthd.MaHangHoa
                        where cthd.MaHD == maHD
                        select hh.MaHangHoa;
            return mahhs.ToList();
        }
        public List<string> GetTenHH(string maHD)
        {
            var tenhhs = from hh in db.Khos
                         join cthd in db.CTHoaDons on hh.MaHangHoa equals cthd.MaHangHoa
                         where cthd.MaHD == maHD
                         select hh.TenHangHoa;
            return tenhhs.ToList();
        }

        public List<int?> GetSoLuong(string maHD)
        {
            var soluong = from hh in db.Khos
                          join cthd in db.CTHoaDons on hh.MaHangHoa equals cthd.MaHangHoa
                          where cthd.MaHD == maHD
                          select cthd.SoLuong;
            return soluong.ToList();
        }
        public List<float?> GetDonGia(string maHD)
        {
            var dongias = from hh in db.Khos
                          join cthd in db.CTHoaDons on hh.MaHangHoa equals cthd.MaHangHoa
                          where cthd.MaHD == maHD
                          select cthd.DonGia;
            List<float?> dg = dongias.Select(x => (float?)x).ToList();
            return dg;
        }
        public List<float?> GetThanhTien(string maHD)
        {
            var thanhtiens = from hh in db.Khos
                             join cthd in db.CTHoaDons on hh.MaHangHoa equals cthd.MaHangHoa
                             where cthd.MaHD == maHD
                             select cthd.ThanhTien;
            List<float?> tt = thanhtiens.Select(x => (float?)x).ToList();
            return tt;
        }
        public List<CTHD> GetDataCTHD(string mahd)
        {
            var cthdss = from cthd in db.CTHoaDons
                         join hh in db.Khos on cthd.MaHangHoa equals hh.MaHangHoa
                         join hd in db.HoaDons on cthd.MaHD equals hd.MaHD
                         where cthd.MaHD == mahd
                         select new CTHD { MaHD = cthd.MaHD, MaHangHoa = cthd.MaHangHoa, TenHangHoa = hh.TenHangHoa, SoLuong = cthd.SoLuong, DonGia = cthd.DonGia, ThanhTien = cthd.ThanhTien };
            return cthdss.Distinct().ToList();
        }
    }
}
