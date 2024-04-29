using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL_DAL
{
    public class BD_HoaDon
    {
        QLMuaBanHoaChatDataContext db = new QLMuaBanHoaChatDataContext();
        public List<HoaDon> GetData()
        {
            var hds = from hd in db.HoaDons select hd;
            return hds.ToList();
        }
        public List<HDCTiet> GetDataHD()
        {
            var hds = from hd in db.HoaDons
                      join nv in db.NhanViens on hd.MaNV equals nv.MaNhanVien
                      join kh in db.KhachHangs on hd.MaKH equals kh.MaKhachHang
                      select new HDCTiet { MaHD = hd.MaHD, MaKH = hd.MaKH, TenKH = kh.TenKhachHang, NgayLap = hd.NgayLap, TongThanhTien = hd.TongThanhTien, Thue = hd.Thue, TongCongThanhToan = hd.TongCongThanhToan, HinhThucThanhToan = hd.HinhThucThanhToan, MaNV = hd.MaNV, TenNV = nv.TenNhanVien};
            return hds.ToList();
        }
        public HDCTiet GetDataHDon(string mahd)
        {
            var hdss = from hd in db.HoaDons
                       join nv in db.NhanViens on hd.MaNV equals nv.MaNhanVien
                       join kh in db.KhachHangs on hd.MaKH equals kh.MaKhachHang
                       where hd.MaHD == mahd
                       select new HDCTiet { MaHD = hd.MaHD, NgayLap = hd.NgayLap, TongThanhTien = hd.TongThanhTien, Thue = hd.Thue, TongCongThanhToan = hd.TongCongThanhToan, HinhThucThanhToan = hd.HinhThucThanhToan, MaNV = hd.MaNV, MaKH = hd.MaKH, TenNV = nv.TenNhanVien, TenKH = kh.TenKhachHang, DiaChiKH = kh.DiaChi };
            return hdss.FirstOrDefault();
        }
        public List<CTHD> GetDataCTHD(string mahd)
        {
            var cthdss = from cthd in db.CTHoaDons
                         join hh in db.Khos on cthd.MaHangHoa equals hh.MaHangHoa
                         join hd in db.HoaDons on cthd.MaHD equals hd.MaHD
                         where cthd.MaHD == mahd
                         select new CTHD { MaHD = cthd.MaHD, MaHangHoa = cthd.MaHangHoa, TenHangHoa = hh.TenHangHoa, SoLuong = cthd.SoLuong, DonGia = cthd.DonGia, ThanhTien = cthd.ThanhTien };
            return cthdss.ToList();
        }
        public List<CTHDCTiet> GetDataCTHDon(string mahd)
        {
            var cthds = from cthd in db.CTHoaDons
                        join hh in db.Khos on cthd.MaHangHoa equals hh.MaHangHoa
                        join hd in db.HoaDons on cthd.MaHD equals hd.MaHD
                        where hd.MaHD == mahd
                        select new CTHDCTiet { MaHangHoa = cthd.MaHangHoa, TenHangHoa = hh.TenHangHoa, SoLuong = cthd.SoLuong, DonGia = cthd.DonGia, ThanhTien = cthd.ThanhTien };
            return cthds.ToList();
        }
        public List<HDCTiet> TimKiemHD(string timkiem)
        {
            var hds = from hd in db.HoaDons
                      join nv in db.NhanViens on hd.MaNV equals nv.MaNhanVien
                      join kh in db.KhachHangs on hd.MaKH equals kh.MaKhachHang
                      where kh.TenKhachHang.Contains(timkiem)
                       select new HDCTiet { MaHD = hd.MaHD, MaKH = hd.MaKH, TenKH = kh.TenKhachHang, NgayLap = hd.NgayLap, TongThanhTien = hd.TongThanhTien, Thue = hd.Thue, TongCongThanhToan = hd.TongCongThanhToan, HinhThucThanhToan = hd.HinhThucThanhToan, MaNV = hd.MaNV, TenNV = nv.TenNhanVien };
            return hds.ToList();
        }
        public void themHD(string mahd, DateTime ngaylap, double tongtt, string thue, double tongcongtt, string hinhthuctt, string manv, string makh, string[] mahh, double[] dg, int[] sol, double[] thanhtien)
        {
            db.HoaDons.InsertOnSubmit(new HoaDon
            {
                MaHD = mahd,
                NgayLap = ngaylap,
                TongThanhTien = tongtt,
                Thue = thue,
                TongCongThanhToan = tongcongtt,
                HinhThucThanhToan = hinhthuctt,
                MaNV = manv,
                MaKH = makh
            });
            db.SubmitChanges();

            for (int i = 0; i < mahh.Length; i++)
            {
                db.CTHoaDons.InsertOnSubmit(new CTHoaDon
                {
                    MaHD = mahd,
                    MaHangHoa = mahh[i],
                    DonGia = dg[i],
                    SoLuong = sol[i],
                    ThanhTien = thanhtien[i]
                });
                db.SubmitChanges();
            }

        }
        public double? LayTCTTByMaHD(string mahd)
        {
            HoaDon hd = db.HoaDons.FirstOrDefault(s => s.MaHD == mahd);
            return hd != null ? (double?)hd.TongCongThanhToan : null;
        }
        public void XoaHDVaCT(string mahd)
        {
            var cthdlist = db.CTHoaDons.Where(t => t.MaHD == mahd).ToList();
            db.CTHoaDons.DeleteAllOnSubmit(cthdlist);

            var HoaDon = db.HoaDons.SingleOrDefault(hd => hd.MaHD == mahd);
            if (HoaDon != null)
            {
                db.HoaDons.DeleteOnSubmit(HoaDon);
            }
            db.SubmitChanges();
        }
        public List<HD> LocHoaDonTheoNgay(string loaiLoc)
        {
            DateTime ngayBatDau, ngayKetThuc;

            switch (loaiLoc)
            {
                case "Ngay":
                    ngayBatDau = DateTime.Today;
                    ngayKetThuc = ngayBatDau.AddDays(1);
                    break;
                case "Tuan":
                    ngayBatDau = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
                    ngayKetThuc = ngayBatDau.AddDays(7);
                    break;
                case "Thang":
                    ngayBatDau = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    ngayKetThuc = ngayBatDau.AddMonths(1);
                    break;
                case "Quy1":
                    ngayBatDau = new DateTime(DateTime.Today.Year, 1, 1);
                    ngayKetThuc = new DateTime(DateTime.Today.Year, 3, 31).AddDays(1);
                    break;
                case "Quy2":
                    ngayBatDau = new DateTime(DateTime.Today.Year, 4, 1);
                    ngayKetThuc = new DateTime(DateTime.Today.Year, 6, 30).AddDays(1);
                    break;
                case "Quy3":
                    ngayBatDau = new DateTime(DateTime.Today.Year, 7, 1);
                    ngayKetThuc = new DateTime(DateTime.Today.Year, 9, 30).AddDays(1);
                    break;
                case "Quy4":
                    ngayBatDau = new DateTime(DateTime.Today.Year, 10, 1);
                    ngayKetThuc = new DateTime(DateTime.Today.Year, 12, 31).AddDays(1);
                    break;
                case "NuaNam1":
                    ngayBatDau = new DateTime(DateTime.Today.Year, 1, 1);
                    ngayKetThuc = new DateTime(DateTime.Today.Year, 6, 30).AddDays(1);
                    break;
                case "NuaNam2":
                    ngayBatDau = new DateTime(DateTime.Today.Year, 7, 1);
                    ngayKetThuc = new DateTime(DateTime.Today.Year, 12, 31).AddDays(1);
                    break;
                case "CaNam":
                    ngayBatDau = new DateTime(DateTime.Today.Year, 1, 1);
                    ngayKetThuc = new DateTime(DateTime.Today.Year, 12, 31).AddDays(1);
                    break;
                default:
                    return null;
            }

            var result = from hd in db.HoaDons
                         where hd.NgayLap >= ngayBatDau && hd.NgayLap < ngayKetThuc
                         select new HD { MaHD = hd.MaHD, NgayLap = hd.NgayLap, TongThanhTien = hd.TongThanhTien, Thue = hd.Thue, TongCongThanhToan = hd.TongCongThanhToan, HinhThucThanhToan = hd.HinhThucThanhToan, MaNV = hd.MaNV, MaKH = hd.MaKH };

            return result.ToList();
        }
        public bool KiemTraMaHD(string mahd)
        {
            var hd = db.HoaDons.FirstOrDefault(t => t.MaHD == mahd);
            return hd == null;
        }
        public void suaHD(string mahd, DateTime ngaylap, double tongtt, string thue, double tongcongtt, string hinhthuctt, string manv, string makh, string[] mahh, int[] sol, double[] thanhtien)
        {
            HoaDon HoaDon = db.HoaDons.SingleOrDefault(hd => hd.MaHD == mahd);
            if (HoaDon != null)
            {
                HoaDon.NgayLap = ngaylap;
                HoaDon.TongThanhTien = tongtt;
                HoaDon.Thue = thue;
                HoaDon.TongCongThanhToan = tongcongtt;
                HoaDon.HinhThucThanhToan = hinhthuctt;
                HoaDon.MaNV = manv;
                HoaDon.MaKH = makh;

                for (int i = 0; i < mahh.Length; i++)
                {
                    CTHoaDon chitiet = db.CTHoaDons.SingleOrDefault(ct => ct.MaHD == mahd && ct.MaHangHoa == mahh[i]);
                    if (chitiet != null)
                    {
                        chitiet.MaHangHoa = mahh[i];
                        chitiet.SoLuong = sol[i];
                        chitiet.ThanhTien = thanhtien[i];
                    }
                    else
                    {
                        db.CTHoaDons.InsertOnSubmit(new CTHoaDon
                        {
                            MaHD = mahd,
                            MaHangHoa = mahh[i],
                            SoLuong = sol[i],
                            ThanhTien = thanhtien[i]
                        });
                    }
                }
                db.SubmitChanges();
            }
        }
        public void Backup()
        {
            var backup = from hh in db.HoaDons
                         join ct in db.CTHoaDons on hh.MaHD equals ct.MaHD into details
                         select new
                         {
                             HoaDon = hh,
                             ChiTietHoaDon = details
                         };

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Tệp văn bản (*.txt)|*.txt|Tất cả các tệp (*.*)|*.*";
                saveFileDialog.Title = "Chọn nơi lưu trữ và đặt tên tệp sao lưu";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string backupFilePath = saveFileDialog.FileName;

                    using (StreamWriter file = new StreamWriter(backupFilePath))
                    {
                        foreach (var item in backup)
                        {
                            var HoaDon = item.HoaDon;
                            file.WriteLine($"{HoaDon.MaHD},{HoaDon.NgayLap},{HoaDon.TongThanhTien},{HoaDon.Thue},{HoaDon.TongCongThanhToan},{HoaDon.HinhThucThanhToan},{HoaDon.MaNV},{HoaDon.MaKH}");

                            foreach (var chiTiet in item.ChiTietHoaDon)
                            {
                                file.WriteLine($"{chiTiet.MaHD},{chiTiet.MaHangHoa},{chiTiet.SoLuong},{chiTiet.DonGia},{chiTiet.ThanhTien}");
                            }
                        }
                    }

                    MessageBox.Show("Đã sao lưu thành công");
                }
            }
        }
        public void restore()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Tệp văn bản (*.txt)|*.txt|Tất cả các tệp (*.*)|*.*";
                openFileDialog.Title = "Chọn tệp cần khôi phục";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string restoreFilePath = openFileDialog.FileName;

                    using (StreamReader file = new StreamReader(restoreFilePath))
                    {
                        string line;
                        while ((line = file.ReadLine()) != null)
                        {
                            var parts = line.Split(',');
                            if (parts.Length >= 8)
                            {
                                string MaHD = parts[0];
                                string NgayLap = parts[1];
                                string TongThanhTien = parts[2];
                                string Thue = parts[3];
                                string TongCongThanhToan = parts[4];
                                string HinhThucThanhToan = parts[5];
                                string MaNV = parts[6];
                                string MaKH = parts[7];

                                var existingInvoice = db.HoaDons.SingleOrDefault(x => x.MaHD == MaHD);

                                if (existingInvoice != null)
                                {
                                    existingInvoice.NgayLap = DateTime.Parse(NgayLap);
                                    existingInvoice.TongThanhTien = double.Parse(TongThanhTien);
                                    existingInvoice.Thue = Thue;
                                    existingInvoice.TongCongThanhToan = double.Parse(TongCongThanhToan);
                                    existingInvoice.HinhThucThanhToan = HinhThucThanhToan;
                                    existingInvoice.MaNV = MaNV;
                                    existingInvoice.MaKH = MaKH;
                                }
                                else
                                {
                                    db.HoaDons.InsertOnSubmit(new HoaDon
                                    {
                                        MaHD = MaHD,
                                        NgayLap = DateTime.Parse(NgayLap),
                                        TongThanhTien = double.Parse(TongThanhTien),
                                        Thue = Thue,
                                        TongCongThanhToan = double.Parse(TongCongThanhToan),
                                        HinhThucThanhToan = HinhThucThanhToan,
                                        MaNV = MaNV,
                                        MaKH = MaKH
                                    });
                                }
                            }
                            else if (parts.Length >= 5)
                            {
                                string MaHD = parts[0];
                                string MaHangHoa = parts[1];
                                string SoLuong = parts[2];
                                string DonGia = parts[3];
                                string ThanhTien = parts[4];

                                var existingDetail = db.CTHoaDons.SingleOrDefault(x => x.MaHD == MaHD);

                                if (existingDetail == null)
                                {
                                    db.CTHoaDons.InsertOnSubmit(new CTHoaDon
                                    {
                                        MaHD = MaHD,
                                        MaHangHoa = MaHangHoa,
                                        SoLuong = int.Parse(SoLuong),
                                        DonGia = double.Parse(DonGia),
                                        ThanhTien = double.Parse(ThanhTien)
                                    });
                                }
                            }
                        }

                        db.SubmitChanges();
                    }

                    MessageBox.Show("Đã khôi phục thành công");
                }
            }
        }
    }
}
