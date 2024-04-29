using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL_DAL
{
    public class BD_NSX
    {
        QLMuaBanHoaChatDataContext db = new QLMuaBanHoaChatDataContext();
        public List<NhaSanXuat> GetDataNSX()
        {
            var nsxs = from nsx in db.NhaSanXuats select nsx;
            return nsxs.ToList();
        }
        public string LayMaNSXByTenNSX(string tennsx)
        {
            NhaSanXuat nsx = db.NhaSanXuats.FirstOrDefault(s => s.TenNSX == tennsx);
            return nsx != null ? nsx.MaNSX : null;
        }
        public List<NSX> GetData()
        {
            var nsxs = from nsx in db.NhaSanXuats select new NSX { MaSoThue = nsx.MaNSX, TenNSX = nsx.TenNSX, DiaChiNSX = nsx.DiaChiNSX };
            return nsxs.ToList();
        }
        public void ThemNSX(string mansx, string tennsx, string diachi)
        {
            db.NhaSanXuats.InsertOnSubmit(new NhaSanXuat
            {
                MaNSX = mansx,
                TenNSX = tennsx,
                DiaChiNSX = diachi
            });
            db.SubmitChanges();
        }
        public void XoaNSX(string mansx)
        {
            NhaSanXuat nsx = db.NhaSanXuats.Where(t => t.MaNSX == mansx).FirstOrDefault();
            db.NhaSanXuats.DeleteOnSubmit(nsx);
            db.SubmitChanges();
        }
        public void SuaNSX(string mansx, string tennsx, string diachi)
        {
            NhaSanXuat nsx = db.NhaSanXuats.Where(t => t.MaNSX == mansx).FirstOrDefault();
            nsx.TenNSX = tennsx; nsx.DiaChiNSX = diachi;
            db.SubmitChanges();
        }
        public List<NhaSanXuat> TimKiemNSX(string timkiem)
        {
            var nsxs = from nsx in db.NhaSanXuats
                       where nsx.MaNSX.ToString().Contains(timkiem) ||
                             nsx.TenNSX.Contains(timkiem)
                       select nsx;
            return nsxs.ToList();
        }
        public string LayTenNSXByMaNSX(string mansx)
        {
            NhaSanXuat nsx = db.NhaSanXuats.FirstOrDefault(s => s.MaNSX == mansx);
            return nsx != null ? nsx.TenNSX : null;
        }
        public bool KiemTraMaNSX(string mansx)
        {
            var nsx = db.NhaSanXuats.FirstOrDefault(t => t.MaNSX == mansx);
            return nsx == null;
        }
        public void Backup()
        {
            var backup = from nsx in db.NhaSanXuats select nsx;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Tệp văn bản (*.txt)|*.txt|Tất cả các tệp (*.*)|*.*";
                saveFileDialog.Title = "Chọn nơi lưu trữ và đặt tên tệp sao lưu";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string backupFilePath = saveFileDialog.FileName;

                    using (StreamWriter file = new StreamWriter(backupFilePath))
                    {
                        foreach (var nsx in backup)
                        {
                            file.WriteLine($"{nsx.MaNSX},{nsx.TenNSX},{nsx.DiaChiNSX}");
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
                                string MaNSX = parts[0];
                                string TenNSX = parts[1];
                                string DiaChiNSX = parts[2];

                                var existingRecord = db.NhaSanXuats.SingleOrDefault(x => x.MaNSX == MaNSX);

                                if (existingRecord != null)
                                {
                                    existingRecord.TenNSX = TenNSX;
                                    existingRecord.DiaChiNSX = DiaChiNSX;
                                }
                                else
                                {
                                    db.NhaSanXuats.InsertOnSubmit(new NhaSanXuat
                                    {
                                        MaNSX = MaNSX,
                                        TenNSX = TenNSX,
                                        DiaChiNSX = DiaChiNSX
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
    }
}
