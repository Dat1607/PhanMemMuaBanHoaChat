using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL_DAL
{
    public class BD_DonDatHang
    {
        QLMuaBanHoaChatDataContext db = new QLMuaBanHoaChatDataContext();
        public List<DonDatHang> GetData()
        {
            var ddhs = from ddh in db.DonDatHangs select ddh;
            return ddhs.ToList();
        }
        public List<DDHCTiet> GetDataDDH()
        {
            var ddhss = from ddh in db.DonDatHangs
                        join ncc in db.NhaCungCaps on ddh.MaNCC equals ncc.MaNCC
                        select new DDHCTiet { Maddh = ddh.MaDDH, TongSL = ddh.TongSoLuong, TongThanhTien = ddh.TongThanhTien, NgayDat = ddh.NgayDatHang, TinhTrangDonDatHang = ddh.TinhTrangDonHang, MaNCC = ddh.MaNCC, TenNCC = ncc.TenNCC, DiaChiNCC = ncc.DiaChiNCC};
            return ddhss.ToList();
        }
        public DDHCTiet GetDataDDHang(string maddh)
        {
            var ddhss = from ddh in db.DonDatHangs
                        join kh in db.NhaCungCaps on ddh.MaNCC equals kh.MaNCC
                        where ddh.MaDDH == maddh
                        select new DDHCTiet { Maddh = ddh.MaDDH, TongSL = ddh.TongSoLuong, TongThanhTien = ddh.TongThanhTien, NgayDat = ddh.NgayDatHang, TinhTrangDonDatHang = ddh.TinhTrangDonHang};
            return ddhss.FirstOrDefault();
        }
        public List<CTDDH> GetDataCTDDH(string maddh)
        {
            var ctddhs = from ctddh in db.CTDonDatHangs
                         join hh in db.Khos on ctddh.MaHangHoa equals hh.MaHangHoa
                         join ddh in db.DonDatHangs on ctddh.MaDDH equals ddh.MaDDH
                         where ctddh.MaDDH == maddh
                         select new CTDDH { Maddh = ctddh.MaDDH, MaHangHoa = ctddh.MaHangHoa, TenHangHoa = hh.TenHangHoa, SoLuong = ctddh.SoLuong, DonGia = ctddh.DonGia, ThanhTien = ctddh.ThanhTien };
            return ctddhs.ToList();
        }
        public List<CTDDHCTiet> GetDataCTDDHang(string maddh)
        {
            var ctddhs = from ctddh in db.CTDonDatHangs
                         join hh in db.Khos on ctddh.MaHangHoa equals hh.MaHangHoa
                         join ddh in db.DonDatHangs on ctddh.MaDDH equals ddh.MaDDH
                         where ddh.MaDDH == maddh
                         select new CTDDHCTiet { MaHangHoa = ctddh.MaHangHoa, TenHangHoa = hh.TenHangHoa, SoLuong = ctddh.SoLuong, DonGia = ctddh.DonGia, ThanhTien = ctddh.ThanhTien };
            return ctddhs.ToList();
        }
        public List<DonDatHang> TimKiemDDH(string timkiem)
        {
            var ddhs = from ddh in db.DonDatHangs
                       where ddh.MaDDH.Contains(timkiem) ||
                       ddh.MaNCC.Contains(timkiem)
                       select ddh;
            return ddhs.ToList();
        }
        public void themDDH(string maddh, int tongsl, double tongtt, DateTime ngaydathang, string mancc, string tinhtrangdon, string taik, string[] mahh, int[] sol, double[] dg, double[] thanhtien)
        {
            db.DonDatHangs.InsertOnSubmit(new DonDatHang
            {
                MaDDH = maddh,
                TongSoLuong = tongsl,
                TongThanhTien = tongtt,
                NgayDatHang = ngaydathang,
                MaNCC = mancc,
                TinhTrangDonHang = tinhtrangdon,
                TaiKhoan = taik
            });
            db.SubmitChanges();

            for (int i = 0; i < mahh.Length; i++)
            {
                db.CTDonDatHangs.InsertOnSubmit(new CTDonDatHang
                {
                    MaDDH = maddh,
                    MaHangHoa = mahh[i],
                    SoLuong = sol[i],
                    DonGia = dg[i],
                    ThanhTien = thanhtien[i]
                });
                db.SubmitChanges();
            }
        }
        public List<string> GetMaHH(string maddh)
        {
            var mahhs = from ctddh in db.CTDonDatHangs
                        join hh in db.Khos on ctddh.MaHangHoa equals hh.MaHangHoa
                        join ddh in db.DonDatHangs on ctddh.MaDDH equals ddh.MaDDH
                        where ddh.MaDDH == maddh
                        select hh.MaHangHoa;
            return mahhs.ToList();
        }
        public List<string> GetTenHH(string maddh)
        {
            var tenhhs = from ctddh in db.CTDonDatHangs
                         join hh in db.Khos on ctddh.MaHangHoa equals hh.MaHangHoa
                         join ddh in db.DonDatHangs on ctddh.MaDDH equals ddh.MaDDH
                         where ddh.MaDDH == maddh
                         select hh.TenHangHoa;
            return tenhhs.ToList();
        }

        public List<int?> GetSoLuong(string maddh)
        {
            var soluong = from ctddh in db.CTDonDatHangs
                          join hh in db.Khos on ctddh.MaHangHoa equals hh.MaHangHoa
                          join ddh in db.DonDatHangs on ctddh.MaDDH equals ddh.MaDDH
                          where ddh.MaDDH == maddh
                          select ctddh.SoLuong;
            return soluong.ToList();
        }
        public List<double?> GetDonGia(string maddh)
        {
            var dongias = from ctddh in db.CTDonDatHangs
                          join hh in db.Khos on ctddh.MaHangHoa equals hh.MaHangHoa
                          join ddh in db.DonDatHangs on ctddh.MaDDH equals ddh.MaDDH
                          where ddh.MaDDH == maddh
                          select ctddh.DonGia;
            List<double?> dg = dongias.Select(x => (double?)x).ToList();
            return dg;
        }
        public List<double?> GetThanhTien(string maddh)
        {
            var thanhtiens = from ctddh in db.CTDonDatHangs
                             join hh in db.Khos on ctddh.MaHangHoa equals hh.MaHangHoa
                             join ddh in db.DonDatHangs on ctddh.MaDDH equals ddh.MaDDH
                             where ddh.MaDDH == maddh
                             select ctddh.ThanhTien;
            List<double?> tt = thanhtiens.Select(x => (double?)x).ToList();
            return tt;
        }
        public bool XoaDDHVaCT(string maddh)
        {
            var ddh = db.DonDatHangs.SingleOrDefault(pn => pn.MaDDH == maddh && pn.TinhTrangDonHang != null && pn.TinhTrangDonHang == "Khách hàng đã hủy đơn");

            if (ddh != null)
            {
                var ctpnlist = db.CTDonDatHangs.Where(t => t.MaDDH == maddh).ToList();
                db.CTDonDatHangs.DeleteAllOnSubmit(ctpnlist);

                db.DonDatHangs.DeleteOnSubmit(ddh);

                db.SubmitChanges();

                return true; // Xóa thành công
            }
            else
            {
                return false; // Không thể xóa
            }
        }
        public void CapNhatTTDon(string maddh)
        {

            DonDatHang ddhs = db.DonDatHangs.Where(t => t.MaDDH == maddh).FirstOrDefault();
            ddhs.TinhTrangDonHang = "Đơn đặt hàng đã được xác nhận";
            db.SubmitChanges();
        }
        public List<DDH> LocDonDatHangTheoNgay(string loaiLoc)
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

            var result = from ddh in db.DonDatHangs
                         where ddh.NgayDatHang >= ngayBatDau && ddh.NgayDatHang < ngayKetThuc
                         select new DDH { MaDDH = ddh.MaDDH, TongSL = ddh.TongSoLuong, TongThanhTien = ddh.TongThanhTien, NgayDat = ddh.NgayDatHang, TinhTrangDonDatHang = ddh.TinhTrangDonHang, MaNCC = ddh.MaNCC };

            return result.ToList();
        }
        public List<DDH> GetDataDDHByTenDN(string taik)
        {
            var ddhs = from ddh in db.DonDatHangs
                       join tk in db.TaiKhoans on ddh.TaiKhoan equals tk.TenDangNhap
                       where ddh.TaiKhoan == taik
                       select new DDH { MaDDH = ddh.MaDDH, TongSL = ddh.TongSoLuong, TongThanhTien = ddh.TongThanhTien, NgayDat = ddh.NgayDatHang, TinhTrangDonDatHang = ddh.TinhTrangDonHang, MaNCC = ddh.MaNCC };
            return ddhs.ToList();
        }
        public bool CapNhatHuyTTDon(string maddh)
        {
            DonDatHang ddh = db.DonDatHangs.Where(t => t.MaDDH == maddh).FirstOrDefault();
            TimeSpan thoiGianTuDauDenHienTai = (TimeSpan)(DateTime.Now - ddh.NgayDatHang);
            if (thoiGianTuDauDenHienTai.TotalHours <= 2)
            {
                ddh.TinhTrangDonHang = "Khách hàng đã hủy đơn";

                db.SubmitChanges();

                return true;
            }
            else
            {
                return false;
            }
        }
        public bool KiemTraMaDDH(string maddh)
        {
            var ddh = db.DonDatHangs.FirstOrDefault(t => t.MaDDH == maddh);
            return ddh == null;
        }
        public void Backup()
        {
            var backup = from ddh in db.DonDatHangs
                         join ctdh in db.CTDonDatHangs on ddh.MaDDH equals ctdh.MaDDH into details
                         select new
                         {
                             DonDatHang = ddh,
                             ChiTietDonDatHang = details
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
                            var DonDatHang = item.DonDatHang;
                            file.WriteLine($"{DonDatHang.MaDDH},{DonDatHang.TongSoLuong},{DonDatHang.TongThanhTien},{DonDatHang.NgayDatHang},{DonDatHang.MaNCC},{DonDatHang.TinhTrangDonHang},{DonDatHang.TaiKhoan}");

                            foreach (var chiTiet in item.ChiTietDonDatHang)
                            {
                                file.WriteLine($"{chiTiet.MaDDH},{chiTiet.MaHangHoa},{chiTiet.SoLuong},{chiTiet.ThanhTien}");
                            }
                        }
                    }

                    MessageBox.Show("Đã sao lưu thành công");
                }
            }
        }
        public void Restore()
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
                            if (parts.Length >= 7)
                            {
                                string MaDDH = parts[0];
                                string TongSoLuong = parts[1];
                                string TongThanhTien = parts[2];
                                string NgayDatHang = parts[3];
                                string MaNCC = parts[4];
                                string TinhTrangDonHang = parts[5];
                                string TaiKhoan = parts[6];

                                var existingOrder = db.DonDatHangs.SingleOrDefault(x => x.MaDDH == MaDDH);

                                if (existingOrder != null)
                                {
                                    existingOrder.TongSoLuong = int.Parse(TongSoLuong);
                                    existingOrder.TongThanhTien = double.Parse(TongThanhTien);
                                    existingOrder.NgayDatHang = DateTime.Parse(NgayDatHang);
                                    existingOrder.MaNCC = MaNCC;
                                    existingOrder.TinhTrangDonHang = TinhTrangDonHang;
                                    existingOrder.TaiKhoan = TaiKhoan;
                                }
                                else
                                {
                                    db.DonDatHangs.InsertOnSubmit(new DonDatHang
                                    {
                                        MaDDH = MaDDH,
                                        TongSoLuong = int.Parse(TongSoLuong),
                                        TongThanhTien = double.Parse(TongThanhTien),
                                        NgayDatHang = DateTime.Parse(NgayDatHang),
                                        MaNCC = MaNCC,
                                        TinhTrangDonHang = TinhTrangDonHang,
                                        TaiKhoan = TaiKhoan
                                    });
                                }
                            }
                            else if (parts.Length >= 4)
                            {
                                string MaDDH = parts[0];
                                string MaHangHoa = parts[1];
                                string SoLuong = parts[2];
                                string ThanhTien = parts[3];

                                var existingDetail = db.CTDonDatHangs.SingleOrDefault(x => x.MaDDH == MaDDH);

                                if (existingDetail == null)
                                {
                                    db.CTDonDatHangs.InsertOnSubmit(new CTDonDatHang
                                    {
                                        MaDDH = MaDDH,
                                        MaHangHoa = MaHangHoa,
                                        SoLuong = int.Parse(SoLuong),
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
