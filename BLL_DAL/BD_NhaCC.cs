using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL_DAL
{
    public class BD_NhaCC
    {
        QLMuaBanHoaChatDataContext db = new QLMuaBanHoaChatDataContext();
        public List<NCC> GetData()
        {
            var NCCs = from NCC in db.NhaCungCaps select new NCC { MaNCC = NCC.MaNCC, TenNCC = NCC.TenNCC, DiaChiNCC = NCC.DiaChiNCC };
            return NCCs.ToList();
        }
        public void ThemNCC(string maNCC, string tenNCC, string diachi)
        {
            db.NhaCungCaps.InsertOnSubmit(new NhaCungCap
            {
                MaNCC = maNCC,
                TenNCC = tenNCC,
                DiaChiNCC = diachi
            });
            db.SubmitChanges();
        }
        public void XoaNCC(string maNCC)
        {
            NhaCungCap NCC = db.NhaCungCaps.Where(t => t.MaNCC == maNCC).FirstOrDefault();
            db.NhaCungCaps.DeleteOnSubmit(NCC);
            db.SubmitChanges();
        }
        public void SuaNCC(string maNCC, string tenNCC, string diachi)
        {
            NhaCungCap NCC = db.NhaCungCaps.Where(t => t.MaNCC == maNCC).FirstOrDefault();
            NCC.TenNCC = tenNCC; NCC.DiaChiNCC = diachi;
            db.SubmitChanges();
        }
        public List<NhaCungCap> TimKiemNCC(string timkiem)
        {
            var NCCs = from NCC in db.NhaCungCaps
                       where NCC.MaNCC.ToString().Contains(timkiem) ||
                             NCC.TenNCC.Contains(timkiem)
                       select NCC;
            return NCCs.ToList();
        }
        public string LayTenNCCByMaNCC(string mancc)
        {
            NhaCungCap ncc = db.NhaCungCaps.FirstOrDefault(s => s.MaNCC == mancc);
            return ncc != null ? ncc.DiaChiNCC : null;
        }
        public string LayDiaCNCCByMaNCC(string mancc)
        {
            NhaCungCap ncc = db.NhaCungCaps.FirstOrDefault(s => s.MaNCC == mancc);
            return ncc != null ? ncc.DiaChiNCC : null;
        }
        public bool KiemTraMaNCC(string mancc)
        {
            var ncc = db.NhaCungCaps.FirstOrDefault(t => t.MaNCC == mancc);
            return ncc == null;
        }
        public void Backup()
        {
            var backup = from hh in db.NhaCungCaps select hh;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Tệp văn bản (*.txt)|*.txt|Tất cả các tệp (*.*)|*.*";
                saveFileDialog.Title = "Chọn nơi lưu trữ và đặt tên tệp sao lưu";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string backupFilePath = saveFileDialog.FileName;

                    using (StreamWriter file = new StreamWriter(backupFilePath))
                    {
                        foreach (var hh in backup)
                        {
                            file.WriteLine($"{hh.MaNCC},{hh.TenNCC},{hh.DiaChiNCC}");
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
                            if (parts.Length >= 3)
                            {
                                string MaNCC = parts[0];
                                string TenNCC = parts[1];
                                string DiaChiNCC = parts[2];

                                var existingRecord = db.NhaCungCaps.SingleOrDefault(x => x.MaNCC == MaNCC);

                                if (existingRecord != null)
                                {
                                    existingRecord.TenNCC = TenNCC;
                                    existingRecord.DiaChiNCC = DiaChiNCC;
                                }
                                else
                                {
                                    db.NhaCungCaps.InsertOnSubmit(new NhaCungCap
                                    {
                                        MaNCC = MaNCC,
                                        TenNCC = TenNCC,
                                        DiaChiNCC = DiaChiNCC
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
        public string LayMaNCCByTenncc(string tenncc)
        {
            NhaCungCap ncc = db.NhaCungCaps.FirstOrDefault(s => s.TenNCC == tenncc);
            return ncc != null ? ncc.MaNCC : null;
        }
        public string LayDiaCNCCByTenncc(string tenncc)
        {
            NhaCungCap ncc = db.NhaCungCaps.FirstOrDefault(s => s.TenNCC == tenncc);
            return ncc != null ? ncc.DiaChiNCC : null;
        }
        public bool KiemTraDDH(string mancc)
        {
            var qs = db.DonDatHangs.FirstOrDefault(t => t.MaNCC == mancc);
            return qs != null;
        }
        public bool KiemTraPNH(string mancc)
        {
            var qs = db.PhieuNhanHangs.FirstOrDefault(t => t.MaNCC == mancc);
            return qs != null;
        }
    }
}
