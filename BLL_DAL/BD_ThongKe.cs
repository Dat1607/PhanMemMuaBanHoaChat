using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BD_ThongKe
    {
        QLMuaBanHoaChatDataContext db = new QLMuaBanHoaChatDataContext();

        public List<THONGK> GetInvoicesByDate(DateTime ngayDau, DateTime ngayCuoi)
        {
            var hds = (from hd in db.HoaDons
                       join kh in db.KhachHangs on hd.MaKH equals kh.MaKhachHang
                       where SqlMethods.DateDiffDay(ngayDau, hd.NgayLap) > -1 && SqlMethods.DateDiffDay(hd.NgayLap, ngayCuoi) > -1
                       select new
                       {
                           hd.NgayLap,
                           hd.MaHD,
                           hd.TongThanhTien,
                           hd.Thue,
                           hd.TongCongThanhToan,
                           hd.MaKH,
                           kh.TenKhachHang
                       }).ToList() // Load data into memory
               .Select(hd => new THONGK
               {
                   NgayLapHD = hd.NgayLap,
                   MaHD = hd.MaHD,
                   TongTien = hd.TongThanhTien,
                   Thue = hd.TongThanhTien * CalculateThue(hd.Thue),
                   TongThanhTien = hd.TongCongThanhToan,
                   MaKH = hd.MaKH,
                   TenKH = hd.TenKhachHang
               }).ToList();

            return hds;
        }
        private double CalculateThue(string vatString)
        {
            vatString = vatString.Trim().TrimEnd('%');

            if (double.TryParse(vatString, out double vatPercentage))
            {
                return vatPercentage / 100;
            }
            else
            {
                throw new ArgumentException("Sai định dạng của VAT", nameof(vatString));
            }
        }

        public double SumTongThanhTien(double[] tongcongthanhtoans)
        {
            double s = 0;

            foreach (double item in tongcongthanhtoans)
                s += item;

            return s;
        }

        public double SumTongThanhTienInDate(DateTime date)
        {
            var table = (from a in db.HoaDons where SqlMethods.DateDiffDay(a.NgayLap, date) == 0 select a.TongCongThanhToan).Cast<double>().ToArray();

            return SumTongThanhTien(table);
        }

        public int DateDiffDay(DateTime begin, DateTime end)
        {
            return SqlMethods.DateDiffDay(begin, end);
        }

        public int DateDiffMonth(DateTime begin, DateTime end)
        {
            return SqlMethods.DateDiffMonth(begin, end);
        }

        public DataTable GetThongKeData_SanPham(DateTime begin, DateTime end)
        {
            var query = (from hd in db.HoaDons
                         join cthd in db.CTHoaDons on hd.MaHD equals cthd.MaHD
                         join hh in db.Khos on cthd.MaHangHoa equals hh.MaHangHoa
                         where SqlMethods.DateDiffDay(begin, hd.NgayLap) > -1 && SqlMethods.DateDiffDay(hd.NgayLap, end) > -1
                         group new { hh, cthd } by new { hh.MaHangHoa, hh.TenHangHoa } into g1
                         select new { TenHangHoa = g1.Key.TenHangHoa, SoLuong = g1.Sum(a => a.cthd.SoLuong), ThanhTien = g1.Sum(a => a.cthd.ThanhTien) });

            DataTable table = new DataTable();
            table.Columns.Add("TenHangHoa");
            table.Columns["TenHangHoa"].DataType = typeof(string);
            table.Columns.Add("SoLuong");
            table.Columns["SoLuong"].DataType = typeof(int);
            table.Columns.Add("ThanhTien");
            table.Columns["ThanhTien"].DataType = typeof(double);

            foreach (var item in query)
            {
                var row = table.NewRow();

                row["TenHangHoa"] = item.TenHangHoa;
                row["SoLuong"] = item.SoLuong;
                row["ThanhTien"] = item.ThanhTien;

                table.Rows.Add(row);
            }

            return table;
        }
    }
}
