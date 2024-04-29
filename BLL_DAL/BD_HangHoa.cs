using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL_DAL
{
    public class BD_HangHoa
    {
        QLMuaBanHoaChatDataContext db = new QLMuaBanHoaChatDataContext();
        public List<HangHoa> GetData()
        {
            var hanghoas = from hanghoa in db.Khos
                           join nsx in db.NhaSanXuats on hanghoa.NhaSanXuat equals nsx.MaNSX
                           select new HangHoa { STT = hanghoa.STT, MaHangHoa = hanghoa.MaHangHoa, TenHangHoa = hanghoa.TenHangHoa, SoLuong = hanghoa.SoLuong, DonViTinh = hanghoa.DonViTinh, TenNSX = nsx.TenNSX, XuatXu = hanghoa.XuatXu, DonGia = hanghoa.DonGia };
            return hanghoas.ToList();
        }
        public void ThemHANGHOA(int stt, string mahh, string tenhh, int soluong, string dvt, string mansx, string xuatxu, double dongia)
        {
            db.Khos.InsertOnSubmit(new Kho
            {
                STT = stt,
                MaHangHoa = mahh,
                TenHangHoa = tenhh,
                SoLuong = soluong,
                DonViTinh = dvt,
                NhaSanXuat = mansx,
                XuatXu = xuatxu,
                DonGia = dongia
            });
            db.SubmitChanges();
            CapNhatStt();
        }
        public void XoaHANGHOA(string mahh)
        {
            Kho hh = db.Khos.Where(t => t.MaHangHoa == mahh).FirstOrDefault();
            db.Khos.DeleteOnSubmit(hh);
            db.SubmitChanges();
            CapNhatStt();

        }
        private void CapNhatStt()
        {
            var hangHoas = db.Khos.OrderBy(hh => hh.STT).ToList();
            var sortedHangHoas = hangHoas.OrderBy(hh => hh.STT).ToList();

            for (int i = 0; i < sortedHangHoas.Count; i++)
            {
                sortedHangHoas[i].STT = i + 1;
            }
            db.SubmitChanges();
        }
        public void SuaHANGHOA(string mahh, string tenhh, int soluong, string dvt, string mansx, string xuatxu, double dongia)
        {
            Kho hh = db.Khos.Where(t => t.MaHangHoa == mahh).FirstOrDefault();

            hh.TenHangHoa = tenhh;
            hh.SoLuong = soluong;
            hh.DonViTinh = dvt;
            hh.NhaSanXuat = mansx;
            hh.XuatXu = xuatxu;
            hh.DonGia = dongia;

            db.SubmitChanges();
            CapNhatStt();
        }
        public List<HangHoa> TimKiemHH(string timkiem)
        {
            var hanghoas = from hanghoa in db.Khos
                           join nsx in db.NhaSanXuats on hanghoa.NhaSanXuat equals nsx.MaNSX
                           where hanghoa.TenHangHoa.Contains(timkiem) || hanghoa.XuatXu.Contains(timkiem)
                           select new HangHoa { STT = hanghoa.STT, MaHangHoa = hanghoa.MaHangHoa, TenHangHoa = hanghoa.TenHangHoa, SoLuong = hanghoa.SoLuong, DonViTinh = hanghoa.DonViTinh, TenNSX = nsx.TenNSX, XuatXu = hanghoa.XuatXu, DonGia = hanghoa.DonGia };
            
            return hanghoas.ToList();
        }
        //public List<HangHoa> LocDonGia(double giaMin, double giaMax)
        //{
        //    var result = from hanghoa in db.Khos
        //                 join nsx in db.NhaSanXuats on hanghoa.NhaSanXuat equals nsx.MaNSX
        //                 where hanghoa.DonGia >= giaMin && hanghoa.DonGia <= giaMax
        //                 select new HangHoa { STT = hanghoa.STT, MaHangHoa = hanghoa.MaHangHoa, TenHangHoa = hanghoa.TenHangHoa, SoLuong = hanghoa.SoLuong, DonViTinh = hanghoa.DonViTinh, TenNSX = nsx.TenNSX, XuatXu = hanghoa.XuatXu };
        //    return result.ToList();
        //}
        public bool KiemTraMaHH(string mahh)
        {
            var hh = db.Khos.FirstOrDefault(t => t.MaHangHoa == mahh);
            return hh == null;
        }
        public string LayTenHHByMaHH(string mahh)
        {
            Kho hh = db.Khos.FirstOrDefault(s => s.TenHangHoa == mahh);
            return hh != null ? hh.MaHangHoa : null;
        }
        
        public bool CheckMaHHTrung(string ma, DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    string maTrongGridView = row.Cells[0].Value.ToString();

                    if (ma.Equals(maTrongGridView, StringComparison.OrdinalIgnoreCase))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public string LayMaHHByTenHH(string tenhh)
        {
            Kho hh = db.Khos.FirstOrDefault(s => s.TenHangHoa == tenhh);
            return hh != null ? hh.MaHangHoa : null;
        }
        public string LayXuatXHHByTenHH(string tenhh)
        {
            Kho hh = db.Khos.FirstOrDefault(s => s.TenHangHoa == tenhh);
            return hh != null ? hh.XuatXu : null;
        }
        public string LayDVTByTenHH(string tenhh)
        {
            Kho hh = db.Khos.FirstOrDefault(s => s.TenHangHoa == tenhh);
            return hh != null ? hh.DonViTinh : null;
        }
        public string LayDiaCGByTenKH(string tenkh)
        {
            KhachHang kh = db.KhachHangs.FirstOrDefault(s => s.TenKhachHang == tenkh);
            return kh != null ? kh.DiaChiGiao : null;
        }
        public void Backup()
        {
            var backup = from nv in db.Khos select nv;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Tệp văn bản (*.txt)|*.txt|Tất cả các tệp (*.*)|*.*";
                saveFileDialog.Title = "Chọn nơi lưu trữ và đặt tên tệp sao lưu";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string backupFilePath = saveFileDialog.FileName;

                    using (StreamWriter file = new StreamWriter(backupFilePath))
                    {
                        foreach (var nv in backup)
                        {
                            file.WriteLine($"{nv.STT},{nv.MaHangHoa},{nv.TenHangHoa},{nv.SoLuong},{nv.DonViTinh},{nv.NhaSanXuat},{nv.XuatXu}");
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
                            if (parts.Length >= 7)
                            {
                                string STT = parts[0];
                                string MaHangHoa = parts[1];
                                string TenHangHoa = parts[2];
                                string SoLuong = parts[3];
                                string DonViTinh = parts[4];
                                string NhaSanXuat = parts[5];
                                string XuatXu = parts[6];

                                var existingRecord = db.Khos.SingleOrDefault(x => x.MaHangHoa == MaHangHoa);

                                if (existingRecord != null)
                                {
                                    existingRecord.STT = int.Parse(STT);
                                    existingRecord.MaHangHoa = MaHangHoa;
                                    existingRecord.TenHangHoa = TenHangHoa;
                                    existingRecord.SoLuong = int.Parse(SoLuong);
                                    existingRecord.DonViTinh = DonViTinh;
                                    existingRecord.NhaSanXuat = NhaSanXuat;
                                    existingRecord.XuatXu = XuatXu;
                                }
                                else
                                {
                                    db.Khos.InsertOnSubmit(new Kho
                                    {
                                        STT = int.Parse(STT),
                                        MaHangHoa = MaHangHoa,
                                        TenHangHoa = TenHangHoa,
                                        SoLuong = int.Parse(SoLuong),
                                        DonViTinh = DonViTinh,
                                        NhaSanXuat = NhaSanXuat,
                                        XuatXu = XuatXu

                                    });
                                }

                                db.SubmitChanges();
                            }
                        }
                    }
                    MessageBox.Show("Đã sao lưu thành công");
                }
            }
        }
        public int CapNhatSoLuong(string[] mahhs, int[] soluongs)//-1: Xuat, còn lại là Nhap
        {
            BD_HangHoa dal_HH = new BD_HangHoa();

            try
            {
                for (int i = 0; i < mahhs.Length; i++)
                {
                    if (db.Khos.Where(a => a.MaHangHoa == mahhs[i]).Count() == 0)
                    {
                        db.Khos.InsertOnSubmit(new Kho { MaHangHoa = mahhs[i], SoLuong = 0 });
                        db.SubmitChanges();
                    }

                    var hangtrongkho = db.Khos.Where(a => a.MaHangHoa == mahhs[i]).First();

                    hangtrongkho.SoLuong += soluongs[i];

                    db.SubmitChanges();
                }

                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public int CapNhatSoLuong(string[] mahhs, int[] soluongs, out string mahh_loi)//-1: Xuat, còn lại là Nhap
        {
            BD_HangHoa dal_HH = new BD_HangHoa();

            try
            {
                for (int i = 0; i < mahhs.Length; i++)
                {
                    if (db.Khos.Where(a => a.MaHangHoa == mahhs[i]).Count() == 0)
                    {
                        db.Khos.InsertOnSubmit(new Kho { MaHangHoa = mahhs[i], SoLuong = 0 });
                        db.SubmitChanges();
                    }

                    var hangtrongkho = db.Khos.Where(a => a.MaHangHoa == mahhs[i]).First();

                    if (hangtrongkho.SoLuong < soluongs[i])
                    {
                        throw new HangTonAmException(mahhs[i]);
                    }

                    hangtrongkho.SoLuong -= soluongs[i];

                    db.SubmitChanges();
                }

                mahh_loi = null;
                return 1;
            }
            catch (HangTonAmException e)
            {
                mahh_loi = e.Mahh_loi;
                return -1;
            }
            catch (Exception)
            {
                mahh_loi = null;
                return 0;
            }
        }
        public bool KiemTraCTBaoGia(string mahh)
        {
            var qs = db.CTBaoGias.FirstOrDefault(t => t.MaHangHoa == mahh);
            return qs != null;
        }
        public bool KiemTraCTDDH(string mahh)
        {
            var qs = db.CTDonDatHangs.FirstOrDefault(t => t.MaHangHoa == mahh);
            return qs != null;
        }
        public bool KiemTraCTHD(string mahh)
        {
            var qs = db.CTHoaDons.FirstOrDefault(t => t.MaHangHoa == mahh);
            return qs != null;
        }
        public bool KiemTraCTPNH(string mahh)
        {
            var qs = db.CTPhieuNhanHangs.FirstOrDefault(t => t.MaHangHoa == mahh);
            return qs != null;
        }
        public bool KiemTraCTPN(string mahh)
        {
            var qs = db.CTPhieuNhaps.FirstOrDefault(t => t.MaHangHoa == mahh);
            return qs != null;
        }
        public bool KiemTraCTPX(string mahh)
        {
            var qs = db.CTPhieuXuats.FirstOrDefault(t => t.MaHangHoa == mahh);
            return qs != null;
        }
        public bool KiemTraCTPXH(string mahh)
        {
            var qs = db.CTPhieuNhanHangs.FirstOrDefault(t => t.MaHangHoa == mahh);
            return qs != null;
        }
    }
}
