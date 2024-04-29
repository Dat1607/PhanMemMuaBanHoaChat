using Syncfusion.XlsIO.Parser.Biff_Records.Formula;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL_DAL
{
    public class BD_PhieuThanhToan
    {
        QLMuaBanHoaChatDataContext db = new QLMuaBanHoaChatDataContext();
        public List<PhieuThanhToan> GetData()
        {
            var tts = from tt in db.PhieuThanhToans select tt;
            return tts.ToList();
        }
        public List<PTT> GetDataPTT()
        {
            var ptts = from ptt in db.PhieuThanhToans
                       join kh in db.KhachHangs on ptt.MaKH equals kh.MaKhachHang
                       select new PTT { Maptt = ptt.MaPThanhToan, NgayLap = ptt.NgayLap, Thanhtoan = ptt.ThanhToan, MaNV = ptt.MaNV, MaKH = ptt.MaKH, TenKH = kh.TenKhachHang };
            return ptts.ToList();
        }
        public PTTCTiet GetDataPTToan(string maptt)
        {
            var pttss = from ptt in db.PhieuThanhToans
                        join nv in db.NhanViens on ptt.MaNV equals nv.MaNhanVien
                        join kh in db.KhachHangs on ptt.MaKH equals kh.MaKhachHang
                        where ptt.MaPThanhToan == maptt
                        select new PTTCTiet { MaPhieuThanhToan = ptt.MaPThanhToan, NgayLap = ptt.NgayLap, ThanhToan = ptt.ThanhToan, MaNV = ptt.MaNV, MaKH = ptt.MaKH, TenNV = nv.TenNhanVien, TenKH = kh.TenKhachHang, DiaChiKH = kh.DiaChi };
            return pttss.FirstOrDefault();
        }
        public List<CTPTT> GetDataCTPTT(string maptt)
        {
            var ctpttss = from ctptt in db.CTPhieuThanhToans
                          join hd in db.HoaDons on ctptt.MaHD equals hd.MaHD
                          join ptt in db.PhieuThanhToans on ctptt.MaPThanhToan equals ptt.MaPThanhToan
                          where ctptt.MaPThanhToan == maptt
                          select new CTPTT { MaPhieuThanhToan = ctptt.MaPThanhToan, MaHD = ctptt.MaHD, TongThanhToan = hd.TongCongThanhToan };
            return ctpttss.ToList();
        }
        public CTPTTCTiet GetDataCTPTToan(string maptt)
        {
            var ctpttss = from ctptt in db.CTPhieuThanhToans
                          join hd in db.HoaDons on ctptt.MaHD equals hd.MaHD
                          where ctptt.MaPThanhToan == maptt
                          select new CTPTTCTiet { MaHoaDon = ctptt.MaPThanhToan, TongThanhToan = hd.TongCongThanhToan };
            return ctpttss.FirstOrDefault();
        }
        public void themPTT(string maptt, DateTime ngaylap, double tt, string manv, string makh, string mahd)
        {
            db.PhieuThanhToans.InsertOnSubmit(new PhieuThanhToan
            {
                MaPThanhToan = maptt,
                NgayLap = ngaylap,
                ThanhToan = tt,
                MaNV = manv,
                MaKH = makh
            });
            db.SubmitChanges();

            db.CTPhieuThanhToans.InsertOnSubmit(new CTPhieuThanhToan
            {
                MaPThanhToan = maptt,
                MaHD = mahd
            });
            db.SubmitChanges();
        }
        public List<PTT> TimKiemPTT(string timkiem)
        {
            var ptts = from ptt in db.PhieuThanhToans
                       join kh in db.KhachHangs on ptt.MaKH equals kh.MaKhachHang
                       where kh.TenKhachHang.Contains(timkiem)
                       select new PTT { Maptt = ptt.MaPThanhToan, NgayLap = ptt.NgayLap, Thanhtoan = ptt.ThanhToan, MaNV = ptt.MaNV, MaKH = ptt.MaKH, TenKH = kh.TenKhachHang };
            
            return ptts.ToList();
        }
        public KhachHang LayTTKHByMaptt(string mahd)
        {
            var khs = from ptt in db.HoaDons
                      join kh in db.KhachHangs on ptt.MaKH equals kh.MaKhachHang
                      where ptt.MaHD == mahd
                      select ptt.KhachHang;

            return khs.FirstOrDefault();
        }
        public void backup()
        {
            var backup = from pt in db.PhieuThanhToans
                         join ctp in db.CTPhieuThanhToans on pt.MaPThanhToan equals ctp.MaPThanhToan into details
                         select new
                         {
                             PhieuThanhToan = pt,
                             ChiTietPhieuThanhToan = details
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
                            var PhieuThanhToan = item.PhieuThanhToan;
                            file.WriteLine($"{PhieuThanhToan.MaPThanhToan},{PhieuThanhToan.NgayLap},{PhieuThanhToan.ThanhToan},{PhieuThanhToan.MaNV},{PhieuThanhToan.MaKH}");

                            foreach (var chiTiet in item.ChiTietPhieuThanhToan)
                            {
                                file.WriteLine($"{chiTiet.MaPThanhToan},{chiTiet.MaHD}");
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
                            if (parts.Length >= 5)
                            {
                                string MaPThanhToan = parts[0];
                                string NgayLap = parts[1];
                                string ThanhToan = parts[2];
                                string MaNV = parts[3];
                                string MaKH = parts[4];

                                var existingPayment = db.PhieuThanhToans.SingleOrDefault(x => x.MaPThanhToan == MaPThanhToan);

                                if (existingPayment != null)
                                {
                                    existingPayment.NgayLap = DateTime.Parse(NgayLap);
                                    existingPayment.ThanhToan = double.Parse(ThanhToan);
                                    existingPayment.MaNV = MaNV;
                                    existingPayment.MaKH = MaKH;
                                }
                                else
                                {
                                    db.PhieuThanhToans.InsertOnSubmit(new PhieuThanhToan
                                    {
                                        MaPThanhToan = MaPThanhToan,
                                        NgayLap = DateTime.Parse(NgayLap),
                                        ThanhToan = double.Parse(ThanhToan),
                                        MaNV = MaNV,
                                        MaKH = MaKH
                                    });
                                }
                            }
                            else if (parts.Length >= 2)
                            {
                                string MaPThanhToan = parts[0];
                                string MaHD = parts[1];

                                var existingDetail = db.CTPhieuThanhToans.SingleOrDefault(x => x.MaPThanhToan == MaPThanhToan);

                                if (existingDetail == null)
                                {
                                    db.CTPhieuThanhToans.InsertOnSubmit(new CTPhieuThanhToan
                                    {
                                        MaPThanhToan = MaPThanhToan,
                                        MaHD = MaHD
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
        public void XoaPTTVaCT(string maptt)
        {
            var ctpttlist = db.CTPhieuThanhToans.Where(t => t.MaPThanhToan == maptt).ToList();
            db.CTPhieuThanhToans.DeleteAllOnSubmit(ctpttlist);

            var PhieuThanhToan = db.PhieuThanhToans.SingleOrDefault(ptt => ptt.MaPThanhToan == maptt);
            if (PhieuThanhToan != null)
            {
                db.PhieuThanhToans.DeleteOnSubmit(PhieuThanhToan);
            }
            db.SubmitChanges();
        }
        public List<PTT> LocPTTTheoNgay(string loaiLoc)
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

            var result = from ptt in db.PhieuThanhToans
                         where ptt.NgayLap >= ngayBatDau && ptt.NgayLap < ngayKetThuc
                         select new PTT { Maptt = ptt.MaPThanhToan, NgayLap = ptt.NgayLap, Thanhtoan = ptt.ThanhToan, MaNV = ptt.MaNV, MaKH = ptt.MaKH };

            return result.ToList();
        }
    }
}
