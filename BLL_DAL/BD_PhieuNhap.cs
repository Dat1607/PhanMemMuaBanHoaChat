using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL_DAL
{
    public class BD_PhieuNhap
    {
        //QLMuaBanHoaChatDataContext db = new QLMuaBanHoaChatDataContext();
        //public List<PhieuNhap> GetData()
        //{
        //    var pns = from pn in db.PhieuNhaps select pn;
        //    return pns.ToList();
        //}
        //public List<PN> GetDataPN()
        //{
        //    var pns = from pn in db.PhieuNhaps select new PN { Mapn = pn.MaPN, NgayLap = pn.NgayLap, NguoiGiaoHang = pn.NguoiGiaoHang, BienSXGiao = pn.BienSXGiao, Sdt = pn.Sdt, TongSoLuong = pn.TongSoLuong, MaSoThueNCC = pn.MaSoThueNCC, MaNV = pn.MaNV };
        //    return pns.ToList();
        //}
        //public PNCTiet GetDataPNhap(string mapn)
        //{
        //    var pnss = from pn in db.PhieuNhaps
        //               join nv in db.NhanViens on pn.MaNV equals nv.MaNV
        //               join ncc in db.NhaCungCaps on pn.MaSoThueNCC equals ncc.MaSoThueNCC
        //               where pn.MaPN == mapn
        //               select new PNCTiet { Mapn = pn.MaPN, NgayLap = pn.NgayLap, NguoiGiaoHang = pn.NguoiGiaoHang, BienSXGiao = pn.BienSXGiao, Sdt = pn.Sdt, TongSoLuong = pn.TongSoLuong, MaSoThueNCC = pn.MaSoThueNCC, MaNV = pn.MaNV, TenNV = nv.TenNV, TenNCC = ncc.TenNCC, DiaChiNCC = ncc.DiaChiNCC };
        //    return pnss.FirstOrDefault();
        //}
        //public List<CTPN> GetDataCTPN(string mapn)
        //{
        //    var ctpnss = from ctpn in db.CTPhieuNhaps
        //                 join hh in db.HANGHOAs on ctpn.MaHangHoa equals hh.MaHangHoa
        //                 join pn in db.PhieuNhaps on ctpn.MaPN equals pn.MaPN
        //                 where ctpn.MaPN == mapn
        //                 select new CTPN { Mapn = ctpn.MaPN, MaHangHoa = ctpn.MaHangHoa, TenHangHoa = hh.TenHangHoa, SoLuongNhap = ctpn.SoLuongNhap, DonViTinh = hh.DonViTinh, TrongLuong = ctpn.TrongLuong };
        //    return ctpnss.ToList();
        //}
        //public List<CTPNCTiet> GetDataCTPNhap(string mapn)
        //{
        //    var ctpns = from ctpn in db.CTPhieuNhaps
        //                join hh in db.Khos on ctpn.MaHangHoa equals hh.MaHangHoa
        //                join pn in db.CTPhieuNhaps on ctpn.MaPN equals pn.MaPN
        //                where pn.MaPN == mapn
        //                select new CTPNCTiet { MaHangHoa = ctpn.MaHangHoa, TenHangHoa = hh.TenHangHoa, SoLuongNhap = ctpn.SoLuongNhap, DonViTinh = hh.DonViTinh, TrongLuong = ctpn.TrongLuong };
        //    return ctpns.Distinct().ToList();
        //}
        //public List<PhieuNhap> TimKiemPN(string timkiem)
        //{
        //    var pns = from pn in db.PhieuNhaps
        //              where pn.MaPN.Contains(timkiem)
        //              select pn;
        //    return pns.ToList();
        //}
        //public void themPN(string mapn, DateTime ngaylap, int tongSL, string manv, string[] mahh, int[] sol, double[] trongluong)
        //{
        //    db.PhieuNhaps.InsertOnSubmit(new PhieuNhap
        //    {
        //        MaPN = mapn,
        //        NgayLap = ngaylap,
        //        TongSoLuong = tongSL,
        //        MaNV = manv

        //    });
        //    db.SubmitChanges();

        //    for (int i = 0; i < mahh.Length; i++)
        //    {
        //        db.CTPhieuNhaps.InsertOnSubmit(new CTPhieuNhap
        //        {
        //            MaPN = mapn,
        //            MaHangHoa = mahh[i],
        //            SoLuongXuat = sol[i]
        //        });
        //        db.SubmitChanges();
        //    }
        //}
        //public void XoaPNVaCT(string mapn)
        //{
        //    var ctpnlist = db.CTPhieuNhaps.Where(t => t.MaPN == mapn).ToList();
        //    db.CTPhieuNhaps.DeleteAllOnSubmit(ctpnlist);

        //    var PhieuNhap = db.PhieuNhaps.SingleOrDefault(pn => pn.MaPN == mapn);
        //    if (PhieuNhap != null)
        //    {
        //        db.PhieuNhaps.DeleteOnSubmit(PhieuNhap);
        //    }
        //    db.SubmitChanges();
        //}
        //public List<PN> LocPhieuNhapTheoNgay(string loaiLoc)
        //{
        //    DateTime ngayBatDau, ngayKetThuc;

        //    switch (loaiLoc)
        //    {
        //        case "Ngay":
        //            ngayBatDau = DateTime.Today;
        //            ngayKetThuc = ngayBatDau.AddDays(1);
        //            break;
        //        case "Tuan":
        //            ngayBatDau = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
        //            ngayKetThuc = ngayBatDau.AddDays(7);
        //            break;
        //        case "Thang":
        //            ngayBatDau = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        //            ngayKetThuc = ngayBatDau.AddMonths(1);
        //            break;
        //        default:
        //            return null;
        //    }

        //    var result = from pn in db.PhieuNhaps
        //                 where pn.NgayLap >= ngayBatDau && pn.NgayLap < ngayKetThuc
        //                 select new PN { Mapn = pn.MaPN, NgayLap = pn.NgayLap, NguoiGiaoHang = pn.NguoiGiaoHang, BienSXGiao = pn.BienSXGiao, Sdt = pn.Sdt, TongSoLuong = pn.TongSoLuong, MaSoThueNCC = pn.MaSoThueNCC, MaNV = pn.MaNV };

        //    return result.ToList();
        //}
        //public bool KiemTraMaPN(string mapn)
        //{
        //    var pn = db.PhieuNhaps.FirstOrDefault(t => t.MaPN == mapn);
        //    return pn == null;
        //}

        //public void Backup()
        //{
        //    var backup = from pn in db.PhieuNhaps
        //                 join ctpn in db.CTPhieuNhaps on pn.MaPN equals ctpn.MaPN into details
        //                 select new
        //                 {
        //                     PhieuNhap = pn,
        //                     ChiTietPhieuNhap = details
        //                 };

        //    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
        //    {
        //        saveFileDialog.Filter = "Tệp văn bản (*.txt)|*.txt|Tất cả các tệp (*.*)|*.*";
        //        saveFileDialog.Title = "Chọn nơi lưu trữ và đặt tên tệp sao lưu";

        //        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        //        {
        //            string backupFilePath = saveFileDialog.FileName;

        //            using (StreamWriter file = new StreamWriter(backupFilePath))
        //            {
        //                foreach (var item in backup)
        //                {
        //                    var PhieuNhap = item.PhieuNhap;
        //                    file.WriteLine($"{PhieuNhap.MaPN},{PhieuNhap.NgayLap},{PhieuNhap.TongSoLuong},{PhieuNhap.MaNV}");

        //                    foreach (var chiTiet in item.ChiTietPhieuNhap)
        //                    {
        //                        file.WriteLine($"{chiTiet.MaPN},{chiTiet.MaHangHoa},{chiTiet.SoLuongXuat}");
        //                    }
        //                }
        //            }

        //            MessageBox.Show("Đã sao lưu thành công");
        //        }
        //    }
        //}
        //public void Restore()
        //{
        //    using (OpenFileDialog openFileDialog = new OpenFileDialog())
        //    {
        //        openFileDialog.Filter = "Tệp văn bản (*.txt)|*.txt|Tất cả các tệp (*.*)|*.*";
        //        openFileDialog.Title = "Chọn tệp cần khôi phục";

        //        if (openFileDialog.ShowDialog() == DialogResult.OK)
        //        {
        //            string restoreFilePath = openFileDialog.FileName;

        //            using (StreamReader file = new StreamReader(restoreFilePath))
        //            {
        //                string line;
        //                while ((line = file.ReadLine()) != null)
        //                {
        //                    var parts = line.Split(',');
        //                    if (parts.Length >= 4)
        //                    {
        //                        string MaPN = parts[0];
        //                        string NgayLap = parts[1];
        //                        string TongSoLuong = parts[2];
        //                        string MaNV = parts[3];

        //                        var existingReceipt = db.PhieuNhaps.SingleOrDefault(x => x.MaPN == MaPN);

        //                        if (existingReceipt != null)
        //                        {
        //                            existingReceipt.NgayLap = DateTime.Parse(NgayLap);
        //                            existingReceipt.TongSoLuong = int.Parse(TongSoLuong);
        //                            existingReceipt.MaNV = MaNV;
        //                        }
        //                        else
        //                        {
        //                            db.PhieuNhaps.InsertOnSubmit(new PhieuNhap
        //                            {
        //                                MaPN = MaPN,
        //                                NgayLap = DateTime.Parse(NgayLap),
        //                                TongSoLuong = int.Parse(TongSoLuong),
        //                                MaNV = MaNV
        //                            });
        //                        }
        //                    }
        //                    else if (parts.Length >= 3)
        //                    {
        //                        string MaPN = parts[0];
        //                        string MaHangHoa = parts[1];
        //                        string SoLuongXuat = parts[2];

        //                        var existingDetail = db.CTPhieuNhaps.SingleOrDefault(x => x.MaPN == MaPN);

        //                        if (existingDetail == null)
        //                        {
        //                            db.CTPhieuNhaps.InsertOnSubmit(new CTPhieuNhap
        //                            {
        //                                MaPN = MaPN,
        //                                MaHangHoa = MaHangHoa,
        //                                SoLuongXuat = int.Parse(SoLuongXuat)
        //                            });
        //                        }
        //                    }
        //                }

        //                db.SubmitChanges();
        //            }

        //            MessageBox.Show("Đã khôi phục thành công");
        //        }
        //    }
        //}
    }
}
