using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL_DAL
{
    public class BD_KhachHang
    {
        QLMuaBanHoaChatDataContext db = new QLMuaBanHoaChatDataContext();
        BD_PhanQuyen pq = new BD_PhanQuyen();
        public List<KH> GetData()
        {
            var khs = from kh in db.KhachHangs
                      join nv in db.NhanViens on kh.NhanVienQuanLy equals nv.MaNhanVien
                      select new KH { MaNhanVien = kh.NhanVienQuanLy, NhanVienQL = nv.TenNhanVien, MaKhachHang = kh.MaKhachHang, TenKhachHang = kh.TenKhachHang, DiaChi = kh.DiaChi, Mail = kh.Mail, Sdt = kh.SoDienThoai, NguoiDaiDienPL = kh.NguoiDaiDienPhapLy, NguoiLienHeMH = kh.NguoiLienHeMuaHang, DiaChiGiao = kh.DiaChiGiao };
            return khs.ToList();
        }
        public void Themkhachhang(string makh, string tenkh, string diachi, string mail, string sdt, string ngdaidienphaply, string nglienhemua, string diachigiaohang, string nhanvienql)
        {
            db.KhachHangs.InsertOnSubmit(new KhachHang
            {
                MaKhachHang = makh,
                TenKhachHang = tenkh,
                DiaChi = diachi,
                Mail = mail,
                SoDienThoai = sdt,
                NguoiDaiDienPhapLy = ngdaidienphaply,
                NguoiLienHeMuaHang = nglienhemua,
                DiaChiGiao = diachigiaohang,
                NhanVienQuanLy = nhanvienql
            });
            db.SubmitChanges();
        }
        public void Xoakhachhang(string makh)
        {
            KhachHang kh = db.KhachHangs.Where(t => t.MaKhachHang == makh).FirstOrDefault();
            db.KhachHangs.DeleteOnSubmit(kh);
            db.SubmitChanges();
        }
        public void SuaKhachHang(string makh, string tenkh, string diachi, string mail, string sdt, string ngdaidienphaply, string nglienhemua, string diachigiaohang)
        {
            KhachHang kh = db.KhachHangs.Where(t => t.MaKhachHang == makh).FirstOrDefault();
            kh.TenKhachHang = tenkh; kh.DiaChi = diachi; kh.Mail = mail; kh.SoDienThoai = sdt; kh.NguoiDaiDienPhapLy = ngdaidienphaply; kh.NguoiLienHeMuaHang = nglienhemua; kh.DiaChiGiao = diachigiaohang;

            db.SubmitChanges();
        }
        public List<KH> TimKiemKH(string timkiem)
        {
            var khs = from kh in db.KhachHangs
                      join nv in db.NhanViens on kh.NhanVienQuanLy equals nv.MaNhanVien
                      where kh.MaKhachHang.Contains(timkiem) ||
                            kh.TenKhachHang.Contains(timkiem) ||
                            kh.DiaChi.Contains(timkiem) ||
                            kh.SoDienThoai.Contains(timkiem)
                      select new KH { MaNhanVien = kh.NhanVienQuanLy, NhanVienQL = nv.TenNhanVien, MaKhachHang = kh.MaKhachHang, TenKhachHang = kh.TenKhachHang, DiaChi = kh.DiaChi, Mail = kh.Mail, Sdt = kh.SoDienThoai, NguoiDaiDienPL = kh.NguoiDaiDienPhapLy, NguoiLienHeMH = kh.NguoiLienHeMuaHang, DiaChiGiao = kh.DiaChiGiao };
            
            return khs.ToList();
        }
        public bool KiemTraMaKH(string mast)
        {
            var kh = db.KhachHangs.FirstOrDefault(t => t.MaKhachHang == mast);
            return kh == null;
        }
        public void Backup()
        {
            var backup = from kh in db.KhachHangs select kh;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Tệp văn bản (*.txt)|*.txt|Tất cả các tệp (*.*)|*.*";
                saveFileDialog.Title = "Chọn nơi lưu trữ và đặt tên tệp sao lưu";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string backupFilePath = saveFileDialog.FileName;

                    using (StreamWriter file = new StreamWriter(backupFilePath))
                    {
                        foreach (var kh in backup)
                        {
                            file.WriteLine($"{kh.NhanVienQuanLy},{kh.MaKhachHang},{kh.TenKhachHang},{kh.DiaChi},{kh.Mail},{kh.SoDienThoai},{kh.NguoiDaiDienPhapLy},{kh.NguoiLienHeMuaHang},{kh.DiaChiGiao}");
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
                            if (parts.Length >= 9)
                            {

                                string MaKhachHang = parts[0];
                                string TenKhachHang = parts[1];
                                string DiaChi = parts[2];
                                string Mail = parts[3];
                                string SoDienThoai = parts[4];
                                string NguoiDaiDienPhapLy = parts[5];
                                string NguoiLienHeMuaHang = parts[6];
                                string DiaChiGiao = parts[7];
                                string NhanVienQuanLy = parts[8];

                                var existingRecord = db.KhachHangs.SingleOrDefault(x => x.MaKhachHang == MaKhachHang);
                                if (existingRecord != null)
                                {
                                    existingRecord.MaKhachHang = MaKhachHang;
                                    existingRecord.TenKhachHang = TenKhachHang;
                                    existingRecord.DiaChi = DiaChi;
                                    existingRecord.Mail = Mail;
                                    existingRecord.SoDienThoai = SoDienThoai;
                                    existingRecord.NguoiDaiDienPhapLy = NguoiDaiDienPhapLy;
                                    existingRecord.NguoiLienHeMuaHang = NguoiLienHeMuaHang;
                                    existingRecord.DiaChiGiao = DiaChiGiao;
                                    existingRecord.NhanVienQuanLy = NhanVienQuanLy;
                                }
                                else
                                {
                                    db.KhachHangs.InsertOnSubmit(new KhachHang
                                    {
                                        MaKhachHang = MaKhachHang,
                                        TenKhachHang = TenKhachHang,
                                        DiaChi = DiaChi,
                                        Mail = Mail,
                                        SoDienThoai = SoDienThoai,
                                        NguoiDaiDienPhapLy = NguoiDaiDienPhapLy,
                                        NguoiLienHeMuaHang = NguoiLienHeMuaHang,
                                        DiaChiGiao = DiaChiGiao,
                                        NhanVienQuanLy = NhanVienQuanLy,
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
        public List<KH> LayDanhSachKhachHang(string tenDangNhap, string quyen)
        {
            string maNhanVien = db.NhanViens
                                    .Where(nv => nv.TaiKhoan == tenDangNhap)
                                    .Select(nv => nv.MaNhanVien)
                                    .FirstOrDefault();

            if (maNhanVien != null)
            {
                if (pq.KiemTraQuyen(tenDangNhap, quyen))
                {
                    var khs = from kh in db.KhachHangs
                              join nv in db.NhanViens on kh.NhanVienQuanLy equals nv.MaNhanVien
                              select new KH { MaNhanVien = kh.NhanVienQuanLy, NhanVienQL = nv.TenNhanVien, MaKhachHang = kh.MaKhachHang, TenKhachHang = kh.TenKhachHang, DiaChi = kh.DiaChi, Mail = kh.Mail, Sdt = kh.SoDienThoai, NguoiDaiDienPL = kh.NguoiDaiDienPhapLy, NguoiLienHeMH = kh.NguoiLienHeMuaHang, DiaChiGiao = kh.DiaChiGiao };
                    return khs.ToList();
                }
                else
                {
                    var khs = from kh in db.KhachHangs
                              join nv in db.NhanViens on kh.NhanVienQuanLy equals nv.MaNhanVien
                              select new KH { MaNhanVien = kh.NhanVienQuanLy, NhanVienQL = nv.TenNhanVien, MaKhachHang = kh.MaKhachHang, TenKhachHang = kh.TenKhachHang, DiaChi = kh.DiaChi, Mail = kh.Mail, Sdt = kh.SoDienThoai, NguoiDaiDienPL = kh.NguoiDaiDienPhapLy, NguoiLienHeMH = kh.NguoiLienHeMuaHang, DiaChiGiao = kh.DiaChiGiao };
                    return khs.Where(kh => kh.MaNhanVien == maNhanVien).ToList();
                }
            }
            else
            {
                return new List<KH>();
            }
        }
        public string LayDiaCKHByMaKH(string makh)
        {
            KhachHang kh = db.KhachHangs.FirstOrDefault(s => s.TenKhachHang == makh);
            return kh != null ? kh.DiaChi : null;
        }
        public string LayTenKHByMaKH(string makh)
        {
            KhachHang kh = db.KhachHangs.FirstOrDefault(s => s.TenKhachHang == makh);
            return kh != null ? kh.MaKhachHang : null;
        }
        public string LayMaKHByTenKH(string tenkh)
        {
            KhachHang kh = db.KhachHangs.FirstOrDefault(s => s.TenKhachHang == tenkh);
            return kh != null ? kh.MaKhachHang : null;
        }
        public string LayDiaCGByTenKH(string tenkh)
        {
            KhachHang kh = db.KhachHangs.FirstOrDefault(s => s.TenKhachHang == tenkh);
            return kh != null ? kh.DiaChiGiao : null;
        }
        public string LaySDTKHByMaKH(string makh)
        {
            KhachHang kh = db.KhachHangs.FirstOrDefault(s => s.TenKhachHang == makh);
            return kh != null ? kh.SoDienThoai : null;
        }
        public string LayNGDDPLKHByMaKH(string makh)
        {
            KhachHang kh = db.KhachHangs.FirstOrDefault(s => s.TenKhachHang == makh);
            return kh != null ? kh.NguoiDaiDienPhapLy : null;
        }
        public string LayNGLHMUAKHByMaKH(string makh)
        {
            KhachHang kh = db.KhachHangs.FirstOrDefault(s => s.TenKhachHang == makh);
            return kh != null ? kh.NguoiLienHeMuaHang : null;
        }
        public string LayDCGiaoKHByMaKH(string makh)
        {
            KhachHang kh = db.KhachHangs.FirstOrDefault(s => s.TenKhachHang == makh);
            return kh != null ? kh.DiaChiGiao : null;
        }
        public string LayMailKHByMaKH(string makh)
        {
            KhachHang kh = db.KhachHangs.FirstOrDefault(s => s.TenKhachHang == makh);
            return kh != null ? kh.Mail : null;
        }
        public bool KiemTraPXH(string makh)
        {
            var qs = db.PhieuXuatHangs.FirstOrDefault(t => t.MaKH == makh);
            return qs != null;
        }
        public bool KiemTraBG(string makh)
        {
            var qs = db.BaoGias.FirstOrDefault(t => t.MaKhachHang == makh);
            return qs != null;
        }
        public bool KiemTraHD(string makh)
        {
            var qs = db.HoaDons.FirstOrDefault(t => t.MaKH == makh);
            return qs != null;
        }
    }
}
