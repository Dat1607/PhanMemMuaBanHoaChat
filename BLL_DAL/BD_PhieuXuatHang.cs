using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL_DAL
{
    public class BD_PhieuXuatHang
    {
        QLMuaBanHoaChatDataContext db = new QLMuaBanHoaChatDataContext();
        public List<BaoGia> GetData()
        {
            var PXHs = from PXH in db.BaoGias select PXH;
            return PXHs.ToList();
        }
        public List<PXH> GetDataPXH()
        {
            var PXHs = from PXH in db.PhieuXuatHangs
                       join nv in db.NhanViens on PXH.MaNV equals nv.MaNhanVien
                       join kh in db.KhachHangs on PXH.MaKH equals kh.MaKhachHang
                       select new PXH { MaPXH = PXH.MaPXH, MaKH = PXH.MaKH, TenKH = kh.TenKhachHang, NgayLap = PXH.NgayLap, NgayGiao = PXH.NgayGiao, TongThanhTien = PXH.TongThanhTien, Thue = PXH.Thue, TongCongThanhToan = PXH.TongCongThanhToan, TinhTrangPXH = PXH.TinhTrangXuatHang, GhiChu = PXH.GhiChu, MaNV = PXH.MaNV, TenNV = nv.TenNhanVien, DiaChiGiao = kh.DiaChiGiao };
            return PXHs.ToList();
        }
        public PXHCTiet GetDataPXHang(string maPXH)
        {
            var PXHss = from PXH in db.PhieuXuatHangs
                        join nv in db.NhanViens on PXH.MaNV equals nv.MaNhanVien
                        join kh in db.KhachHangs on PXH.MaKH equals kh.MaKhachHang
                        where PXH.MaPXH == maPXH
                        select new PXHCTiet { MaPXH = PXH.MaPXH, MaKH = PXH.MaKH, TenKH = kh.TenKhachHang, NgayLap = PXH.NgayLap, NgayGiao = PXH.NgayGiao, TongThanhTien = PXH.TongThanhTien, Thue = PXH.Thue, TongCongThanhToan = PXH.TongCongThanhToan, TinhTrangPXH = PXH.TinhTrangXuatHang, GhiChu = PXH.GhiChu, MaNV = PXH.MaNV, TenNV = nv.TenNhanVien, DiaChiGiao = kh.DiaChiGiao };
            return PXHss.FirstOrDefault();
        }
        public List<CTPXH> GetDataCTPXH(string maPXH)
        {
            var ctPXHss = from ctPXH in db.CTPhieuXuatHangs
                          join hh in db.Khos on ctPXH.MaHangHoa equals hh.MaHangHoa
                          join PXH in db.PhieuXuatHangs on ctPXH.MaPXH equals PXH.MaPXH
                          where ctPXH.MaPXH == maPXH
                          select new CTPXH { MaPXH = ctPXH.MaPXH, MaHangHoa = ctPXH.MaHangHoa, TenHangHoa = hh.TenHangHoa, DonViTinh = hh.DonViTinh, SoLuong = ctPXH.SoLuong, QuyCach = ctPXH.QuyCach, DonGia = ctPXH.DonGia, ThanhTien = ctPXH.ThanhTien };
            return ctPXHss.ToList();
        }
        public List<CTPXHCTiet> GetDataCTPXHang(string maPXH)
        {
            var ctPXHs = from ctPXH in db.CTPhieuXuatHangs
                         join hh in db.Khos on ctPXH.MaHangHoa equals hh.MaHangHoa
                         join PXH in db.PhieuXuatHangs on ctPXH.MaPXH equals PXH.MaPXH
                         where PXH.MaPXH == maPXH
                         select new CTPXHCTiet { MaHangHoa = ctPXH.MaHangHoa, TenHangHoa = hh.TenHangHoa, DonViTinh = hh.DonViTinh, SoLuong = ctPXH.SoLuong, QuyCach = ctPXH.QuyCach, DonGia = ctPXH.DonGia, ThanhTien = ctPXH.ThanhTien };
            return ctPXHs.ToList();
        }
        public List<PXH> TimKiemPXH(string timkiem)
        {
            var PXHs = from PXH in db.PhieuXuatHangs
                       join nv in db.NhanViens on PXH.MaNV equals nv.MaNhanVien
                       join kh in db.KhachHangs on PXH.MaKH equals kh.MaKhachHang
                       where kh.TenKhachHang.Contains(timkiem)
                       select new PXH { MaPXH = PXH.MaPXH, MaKH = PXH.MaKH, TenKH = kh.TenKhachHang, NgayLap = PXH.NgayLap, NgayGiao = PXH.NgayGiao, TongThanhTien = PXH.TongThanhTien, Thue = PXH.Thue, TongCongThanhToan = PXH.TongCongThanhToan, TinhTrangPXH = PXH.TinhTrangXuatHang, GhiChu = PXH.GhiChu, MaNV = PXH.MaNV, TenNV = nv.TenNhanVien };
            return PXHs.ToList();
        }
        public void themPXH(string maPXH, DateTime ngaylap, DateTime ngayGiao, double tongtt, string thue, double tongcongtt, string ttXuatHang, string ghichu, string makh, string manv, string[] mahh, int[] soL, string[] quycach, double[] dongia, double[] thanhtien)
        {
            db.PhieuXuatHangs.InsertOnSubmit(new PhieuXuatHang
            {
                MaPXH = maPXH,
                NgayLap = ngaylap,
                NgayGiao = ngayGiao,
                TongThanhTien = tongtt,
                Thue = thue,
                TongCongThanhToan = tongcongtt,
                TinhTrangXuatHang = ttXuatHang,
                GhiChu = ghichu,
                MaKH = makh,
                MaNV = manv
            });
            db.SubmitChanges();

            for (int i = 0; i < mahh.Length; i++)
            {
                db.CTPhieuXuatHangs.InsertOnSubmit(new CTPhieuXuatHang
                {
                    MaPXH = maPXH,
                    MaHangHoa = mahh[i],
                    SoLuong = soL[i],
                    QuyCach = quycach[i],
                    DonGia = dongia[i],
                    ThanhTien = thanhtien[i]
                });
                db.SubmitChanges();
            }
        }
        public double? LayTCTTByMaHD(string mahd)
        {
            PhieuXuatHang hd = db.PhieuXuatHangs.FirstOrDefault(s => s.MaPXH == mahd);
            return hd != null ? (double?)hd.TongCongThanhToan : null;
        }
        public void XoaPXHVaCT(string mapxh)
        {
            var ctpxhlist = db.CTPhieuXuatHangs.Where(t => t.MaPXH == mapxh).ToList();
            db.CTPhieuXuatHangs.DeleteAllOnSubmit(ctpxhlist);

            var PhieuXuatHang = db.PhieuXuatHangs.SingleOrDefault(hd => hd.MaPXH == mapxh);
            if (PhieuXuatHang != null)
            {
                db.PhieuXuatHangs.DeleteOnSubmit(PhieuXuatHang);
            }
            db.SubmitChanges();
        }
        public void Backup()
        {
            var backup = from hh in db.PhieuXuatHangs
                         join ct in db.CTPhieuXuatHangs on hh.MaPXH equals ct.MaPXH into details
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
                            file.WriteLine($"{HoaDon.MaPXH},{HoaDon.NgayLap},{HoaDon.NgayGiao},{HoaDon.TongThanhTien},{HoaDon.Thue},{HoaDon.TongCongThanhToan},{HoaDon.TinhTrangXuatHang},{HoaDon.GhiChu},{HoaDon.MaNV},{HoaDon.MaKH}");

                            foreach (var chiTiet in item.ChiTietHoaDon)
                            {
                                file.WriteLine($"{chiTiet.MaPXH},{chiTiet.MaHangHoa},{chiTiet.SoLuong},{chiTiet.QuyCach},{chiTiet.DonGia},{chiTiet.ThanhTien}");
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
                            if (parts.Length >= 10)
                            {
                                string MaPXH = parts[0];
                                string NgayLap = parts[1];
                                string NgayGiao = parts[2];
                                string TongThanhTien = parts[3];
                                string Thue = parts[4];
                                string TongCongThanhToan = parts[5];
                                string TinhTrangXuatHang = parts[6];
                                string GhiChu = parts[7];
                                string MaNV = parts[8];
                                string MaKH = parts[9];

                                var existingInvoice = db.PhieuXuatHangs.SingleOrDefault(x => x.MaPXH == MaPXH);

                                if (existingInvoice != null)
                                {
                                    existingInvoice.NgayLap = DateTime.Parse(NgayLap);
                                    existingInvoice.NgayGiao = DateTime.Parse(NgayGiao);
                                    existingInvoice.TongThanhTien = double.Parse(TongThanhTien);
                                    existingInvoice.Thue = Thue;
                                    existingInvoice.TongCongThanhToan = double.Parse(TongCongThanhToan);
                                    existingInvoice.TinhTrangXuatHang = TinhTrangXuatHang;
                                    existingInvoice.GhiChu = GhiChu;
                                    existingInvoice.MaNV = MaNV;
                                    existingInvoice.MaKH = MaKH;
                                }
                                else
                                {
                                    db.PhieuXuatHangs.InsertOnSubmit(new PhieuXuatHang
                                    {
                                        MaPXH = MaPXH,
                                        NgayLap = DateTime.Parse(NgayLap),
                                        NgayGiao = DateTime.Parse(NgayGiao),
                                        TongThanhTien = double.Parse(TongThanhTien),
                                        Thue = Thue,
                                        TongCongThanhToan = double.Parse(TongCongThanhToan),
                                        TinhTrangXuatHang = TinhTrangXuatHang,
                                        GhiChu = GhiChu,
                                        MaNV = MaNV,
                                        MaKH = MaKH
                                    });
                                }
                            }
                            else if (parts.Length >= 6)
                            {
                                string MaPXH = parts[0];
                                string MaHangHoa = parts[1];
                                string SoLuong = parts[2];
                                string QuyCach = parts[3];
                                string DonGia = parts[4];
                                string ThanhTien = parts[5];

                                var existingDetail = db.CTPhieuXuatHangs.SingleOrDefault(x => x.MaPXH == MaPXH);

                                if (existingDetail == null)
                                {
                                    db.CTPhieuXuatHangs.InsertOnSubmit(new CTPhieuXuatHang
                                    {
                                        MaPXH = MaPXH,
                                        MaHangHoa = MaHangHoa,
                                        SoLuong = int.Parse(SoLuong),
                                        QuyCach = QuyCach,
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
        public List<PXH> LocPhieuXuatHangTheoNgay(string loaiLoc)
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

            var result = from PXH in db.PhieuXuatHangs
                         join nv in db.NhanViens on PXH.MaNV equals nv.MaNhanVien
                         join kh in db.KhachHangs on PXH.MaKH equals kh.MaKhachHang
                         where PXH.NgayLap >= ngayBatDau && PXH.NgayLap < ngayKetThuc
                         select new PXH { MaPXH = PXH.MaPXH, MaKH = PXH.MaKH, TenKH = kh.TenKhachHang, NgayLap = PXH.NgayLap, NgayGiao = PXH.NgayGiao, TongThanhTien = PXH.TongThanhTien, Thue = PXH.Thue, TongCongThanhToan = PXH.TongCongThanhToan, TinhTrangPXH = PXH.TinhTrangXuatHang, GhiChu = PXH.GhiChu, MaNV = PXH.MaNV, TenNV = nv.TenNhanVien, DiaChiGiao = kh.DiaChiGiao };

            return result.ToList();
        }
    }
}
