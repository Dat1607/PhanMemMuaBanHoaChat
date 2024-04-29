using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL_DAL
{
    public class BD_NhanVien
    {
        QLMuaBanHoaChatDataContext db = new QLMuaBanHoaChatDataContext();
        public List<NV> LoadNhanVien()
        {
            var nhanviens = from nhanvien in db.NhanViens
                            join tk in db.TaiKhoans on nhanvien.TaiKhoan equals tk.TenDangNhap
                            select new NV { MaNhanVien = nhanvien.MaNhanVien, TenNhanVien = nhanvien.TenNhanVien, NgaySinh = nhanvien.NgaySinh, CanCuocCongDan = nhanvien.CanCuocCongDan, Email = nhanvien.Email, SoDienThoai = nhanvien.SoDienThoai, TenChucVu = nhanvien.TenChucVu, LuongCS = nhanvien.LuongCoSo, HeSL = nhanvien.HeSoLuong, PhuCap = nhanvien.PhuCap, TienThuong = nhanvien.TienThuong, LuongCB = nhanvien.LuongCoBan, TaiKhoan = nhanvien.TaiKhoan, MatKhau = tk.MatKhau };
            return nhanviens.ToList();
        }
        public void ThemNhanVien(string manv, string tennv, DateTime ngaysinh, string cccd, string email, string sdt, string tencv, double luongcs, double hsl, double phucap, double tienthuong, double luongcb, string taikhoan)
        {
            db.NhanViens.InsertOnSubmit(new NhanVien
            {
                MaNhanVien = manv,
                TenNhanVien = tennv,
                NgaySinh = ngaysinh,
                CanCuocCongDan = cccd,
                Email = email,
                SoDienThoai = sdt,
                TenChucVu = tencv,
                LuongCoSo = luongcs,
                HeSoLuong = hsl,
                PhuCap = phucap,
                TienThuong = tienthuong,
                LuongCoBan = luongcb,
                TaiKhoan = taikhoan,
            });
            db.SubmitChanges();
        }
        public void XoaNhanVien(string manv)
        {

            NhanVien nv = db.NhanViens.Where(t => t.MaNhanVien == manv).FirstOrDefault();
            db.NhanViens.DeleteOnSubmit(nv);
            db.SubmitChanges();
        }
        public void SuaNhanVien(string manv, string tennv, DateTime ngaysinh, string cccd, string email, string sdt, string tencv, double luongcs, double hsl, double phucap, double tienthuong, double luongcb, string taikhoan)
        {
            NhanVien nv = db.NhanViens.Where(t => t.MaNhanVien == manv).FirstOrDefault();

            nv.TenNhanVien = tennv;
            nv.NgaySinh = ngaysinh;
            nv.CanCuocCongDan = cccd;
            nv.Email = email;
            nv.SoDienThoai = sdt;
            nv.TenChucVu = tencv;
            nv.LuongCoSo = luongcs;
            nv.HeSoLuong = hsl;
            nv.PhuCap = phucap;
            nv.TienThuong = tienthuong;
            nv.LuongCoBan = luongcb;
            nv.TaiKhoan = taikhoan;

            db.SubmitChanges();
        }
        public List<NV> TimKiemNV(string timkiem)
        {
            var nhanviens = from nhanvien in db.NhanViens
                            join tk in db.TaiKhoans on nhanvien.TaiKhoan equals tk.TenDangNhap
                            where nhanvien.MaNhanVien.Contains(timkiem) ||
                            nhanvien.TenNhanVien.Contains(timkiem) ||
                            nhanvien.CanCuocCongDan.Contains(timkiem) ||
                            nhanvien.Email.Contains(timkiem) ||
                            nhanvien.SoDienThoai.Contains(timkiem)
                            select new NV { MaNhanVien = nhanvien.MaNhanVien, TenNhanVien = nhanvien.TenNhanVien, NgaySinh = nhanvien.NgaySinh, CanCuocCongDan = nhanvien.CanCuocCongDan, Email = nhanvien.Email, SoDienThoai = nhanvien.SoDienThoai, TenChucVu = nhanvien.TenChucVu, LuongCS = nhanvien.LuongCoSo, HeSL = nhanvien.HeSoLuong, PhuCap = nhanvien.PhuCap, TienThuong = nhanvien.TienThuong, LuongCB = nhanvien.LuongCoBan, TaiKhoan = nhanvien.TaiKhoan, MatKhau = tk.MatKhau };
            
            return nhanviens.ToList();
        }
        public void Backup()
        {
            var backup = from nv in db.NhanViens select nv;
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
                            file.WriteLine($"{nv.MaNhanVien},{nv.TenNhanVien},{nv.NgaySinh},{nv.CanCuocCongDan},{nv.Email},{nv.SoDienThoai},{nv.LuongCoSo},{nv.HeSoLuong},{nv.PhuCap},{nv.TienThuong},{nv.LuongCoBan},{nv.TenChucVu},{nv.TaiKhoan}");
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
                            if (parts.Length >= 13)
                            {
                                string MaNhanVien = parts[0];
                                string TenNhanVien = parts[1];
                                string NgaySinh = parts[2];
                                string CanCuocCongDan = parts[3];
                                string Email = parts[4];
                                string SoDienThoai = parts[5];
                                string LuongCoSo = parts[6];
                                string HeSoLuong = parts[7];
                                string PhuCap = parts[8];
                                string TienThuong = parts[9];
                                string LuongCoBan = parts[10];
                                string TenChuCVu = parts[11];
                                string TaiKhoan = parts[12];

                                var existingRecord = db.NhanViens.SingleOrDefault(x => x.MaNhanVien == MaNhanVien);

                                if (existingRecord != null)
                                {
                                    existingRecord.TenNhanVien = TenNhanVien;
                                    existingRecord.NgaySinh = DateTime.Parse(NgaySinh);
                                    existingRecord.CanCuocCongDan = CanCuocCongDan;
                                    existingRecord.Email = Email;
                                    existingRecord.SoDienThoai = SoDienThoai;
                                    existingRecord.LuongCoSo = double.Parse(LuongCoSo);
                                    existingRecord.HeSoLuong = double.Parse(HeSoLuong);
                                    existingRecord.PhuCap = double.Parse(PhuCap);
                                    existingRecord.TienThuong = double.Parse(TienThuong);
                                    existingRecord.LuongCoBan = double.Parse(LuongCoBan);
                                    existingRecord.TenChucVu = TenChuCVu;
                                    existingRecord.TaiKhoan = TaiKhoan;
                                }
                                else
                                {
                                    db.NhanViens.InsertOnSubmit(new NhanVien
                                    {
                                        MaNhanVien = MaNhanVien,
                                        TenNhanVien = TenNhanVien,
                                        NgaySinh = DateTime.Parse(NgaySinh),
                                        CanCuocCongDan = CanCuocCongDan,
                                        Email = Email,
                                        SoDienThoai = SoDienThoai,
                                        LuongCoSo = double.Parse(LuongCoSo),
                                        HeSoLuong = double.Parse(HeSoLuong),
                                        PhuCap = double.Parse(PhuCap),
                                        TienThuong = double.Parse(TienThuong),
                                        LuongCoBan = double.Parse(LuongCoBan),
                                        TenChucVu = TenChuCVu,
                                        TaiKhoan = TaiKhoan

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
        public string LayTenNhanVienTuTenDangNhap(string tenDangNhap)
        {
            var nhanVien = db.NhanViens.FirstOrDefault(nv => nv.TaiKhoan == tenDangNhap);

            if (nhanVien != null)
            {
                return nhanVien.TenNhanVien;
            }

            return string.Empty;
        }
        public string LayMaNhanVienTuTenDangNhap(string tenDangNhap)
        {
            var nhanVien = db.NhanViens.FirstOrDefault(nv => nv.TaiKhoan == tenDangNhap);

            if (nhanVien != null)
            {
                return nhanVien.MaNhanVien;
            }

            return string.Empty;
        }
        public bool KiemTraBG(string manv)
        {
            var qs = db.BaoGias.FirstOrDefault(t => t.MaNhanVien == manv);
            return qs != null;
        }
        public bool KiemTraHD(string manv)
        {
            var qs = db.HoaDons.FirstOrDefault(t => t.MaNV == manv);
            return qs != null;
        }
        public bool KiemTraPNH(string manv)
        {
            var qs = db.PhieuNhanHangs.FirstOrDefault(t => t.MaNhanVien == manv);
            return qs != null;
        }
        public bool KiemTraPN(string manv)
        {
            var qs = db.PhieuNhaps.FirstOrDefault(t => t.MaNV == manv);
            return qs != null;
        }
        public bool KiemTraPTT(string manv)
        {
            var qs = db.PhieuThanhToans.FirstOrDefault(t => t.MaNV == manv);
            return qs != null;
        }
        public bool KiemTraPX(string manv)
        {
            var qs = db.PhieuXuats.FirstOrDefault(t => t.MaNV == manv);
            return qs != null;
        }
        public bool KiemTraPXH(string manv)
        {
            var qs = db.PhieuXuatHangs.FirstOrDefault(t => t.MaNV == manv);
            return qs != null;
        }
    }
}
