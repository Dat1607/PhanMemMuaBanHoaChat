using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_DAL;
using System.Globalization;
using Tools;

namespace PhanMemBanHoaChat.HoaDon
{
    public partial class FrmTaoMoiHoaDon : DevExpress.XtraEditors.XtraForm
    {
        BD_HoaDon hd = new BD_HoaDon();
        BD_NhanVien nv = new BD_NhanVien();
        BD_KhachHang kh = new BD_KhachHang();
        BD_HangHoa hh = new BD_HangHoa();
        BD_CTHoaDon cthd = new BD_CTHoaDon();
        //private FrmDSHoaDon frm;
        private string maHD;
        private string tendn;
        public FrmTaoMoiHoaDon(string tendn)
        {
            InitializeComponent();
            LoadDataKH();
            LoadDataHH();

            this.tendn = tendn;
            string tenNhanVien = nv.LayTenNhanVienTuTenDangNhap(tendn);
            txbtennv.Text = tenNhanVien;
            string maNV = nv.LayMaNhanVienTuTenDangNhap(tendn);
            txbmanv.Text = maNV;

        }
        //public FrmTaoMoiHoaDon(string maHD)
        //{
        //    InitializeComponent();
        //    LoadDataKH();
        //    LoadDataHH();
        //    //this.frm = frm;
            
        //    this.maHD = maHD;
        //}
        public void ChonHangFromDataGridView(string maHD)
        {
            HDCTiet hoaDon = hd.GetDataHDon(maHD);

            // Hiển thị thông tin hóa đơn lên các TextBox và ComboBox trên Form2
            if (hoaDon != null)
            {
                lblmahd.Text = hoaDon.MaHD;
                dtpNgayl.Value = Convert.ToDateTime(hoaDon.NgayLap);
                txbmanv.Text = hoaDon.MaNV;
                txbtennv.Text = hoaDon.TenNV;
                txbmastkh.Text = hoaDon.MaKH;
                cbbtenkh.Text = hoaDon.TenKH;
                cbbtenkh.ForeColor = Color.Black;
                txbdckh.Text = hoaDon.DiaChiKH;
                txbtongtt.Text = hoaDon.TongThanhTien.Value.ToString("#,##0");
                txtvat.Text = hoaDon.Thue.Trim().TrimEnd('%');
                txbtongtientt.Text = hoaDon.TongCongThanhToan.Value.ToString("#,##0");
                cbbhinhthuctt.Text = hoaDon.HinhThucThanhToan;
                cbbhinhthuctt.ForeColor = Color.Black;
                List<CTHDCTiet> cthdList = hd.GetDataCTHDon(maHD);
                if (cthdList != null && cthdList.Any())
                {
                    foreach (CTHDCTiet cthdItem in cthdList)
                    {
                        string maHH = cthdItem.MaHangHoa;
                        string tenHH = cthdItem.TenHangHoa;
                        int? soL = cthdItem.SoLuong;
                        string donG = cthdItem.DonGia.HasValue ? cthdItem.DonGia.Value.ToString("#,##0") : "";
                        string thanhT = cthdItem.DonGia.HasValue ? cthdItem.ThanhTien.Value.ToString("#,##0") : "";
                        dataGridView1.Rows.Insert(0, maHH, tenHH, donG, soL, thanhT);
                    }
                    int columnIndex = dataGridView1.Columns[3].Index;
                    int columnIndex1 = dataGridView1.Columns[4].Index;
                    dataGridView1.Columns[columnIndex].DefaultCellStyle.Format = "N0";
                    dataGridView1.Columns[columnIndex1].DefaultCellStyle.Format = "N0";
                }
            }
        }

        private void FrmTaoMoiHoaDon_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            txbdvb.Text = "CÔNG TY TNHH TM DV ĐẦU TƯ VÀ PHÁT TRIỂN PHÚC THỊNH VINA";
            txbmast.Text = "0315745341";
            txbdiachi.Text = "Lầu 2, Số 170N Nơ Trang Long, Phường 12, Quận Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam";
            txbemail.Text = "ptvina2023@gmail.com";
            txbmahd.Text = TaoRandomMaHD();
        }
        private string TaoRandomMaHD()
        {
            Random random = new Random();
            int randomValue;
            string maHD;
            do
            {
                randomValue = random.Next(0, 1000);
                maHD = "HD" + randomValue.ToString("000");
            } while (KiemTraTrungMaHD(maHD));

            return maHD;
        }

        private bool KiemTraTrungMaHD(string maHD)
        {
            return false;
        }
        private void LoadDataKH()
        {
            var mns = kh.GetData();

            foreach (var mn in mns)
            {
                cbbtenkh.Items.Add(mn.TenKhachHang);
            }
            cbbtenkh.SelectedIndex = 0;
        }

        private void cbbtenkh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbtenkh.Text == "Chọn khách hàng" && cbbtenkh.SelectedIndex == 0)
            {
                cbbtenkh.ForeColor = Color.Gray;
            }
            else
            {
                cbbtenkh.ForeColor = Color.Black;
                string chonGiaTri = cbbtenkh.SelectedItem.ToString();
                string makh = kh.LayMaKHByTenKH(chonGiaTri);
                string dcg = kh.LayDiaCGByTenKH(chonGiaTri);
                txbmastkh.Text = makh;
                txbdckh.Text = dcg;
            }
        }

        private void cbbtenkh_DropDown(object sender, EventArgs e)
        {
            if (cbbtenkh.Text == "Chọn khách hàng")
            {
                cbbtenkh.Text = "";
            }
        }

        private void cbbtenkh_DropDownClosed(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbbtenkh.Text))
            {
                cbbtenkh.Text = "Chọn khách hàng";
                cbbtenkh.ForeColor = Color.Gray;
            }
            else
            {
                cbbtenkh.ForeColor = Color.Black;
            }
        }
        private void ThanhTien(object sender, EventArgs e)
        {
            if (decimal.TryParse(txbdonG.Text, out decimal donGia) && decimal.TryParse(txbSL.Text, out decimal soLuong))
            {
                txbdonG.Text = donGia.ToString("N0");
                txbdonG.SelectionStart = txbdonG.Text.Length;
                decimal tt = donGia * soLuong;
                txbtt.Text = tt.ToString("N0", CultureInfo.InvariantCulture);
            }
        }

        private void TinhVAT(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtvat.Text, out decimal vatPercent))
            {
                decimal total;
                if (decimal.TryParse(txbtongtt.Text, out total))
                {
                    decimal totalVAT = total * (vatPercent / 100);
                    txbvatdatinh.Text = totalVAT.ToString("N0", CultureInfo.InvariantCulture);
                    decimal tongCongTT = total + totalVAT;
                    txbtongtientt.Text = tongCongTT.ToString("N0", CultureInfo.InvariantCulture);
                    return;
                }
            }
        }
        private void LoadDataHH()
        {
            var mns = hh.GetData();

            foreach (var mn in mns)
            {
                cbbtenhh.Items.Add(mn.TenHangHoa);
            }
            cbbtenhh.SelectedIndex = 0;
        }

        private void cbbtenhh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbtenhh.Text == "Chọn hàng hóa" && cbbtenhh.SelectedIndex == 0)
            {
                cbbtenhh.ForeColor = Color.Gray;
            }
            else
            {
                cbbtenhh.ForeColor = Color.Black;
                string chonGiaTri = cbbtenhh.SelectedItem.ToString();
                string mahh = hh.LayMaHHByTenHH(chonGiaTri);
                txbmahh.Text = mahh;
            }
        }

        private void cbbtenhh_DropDown(object sender, EventArgs e)
        {
            if (cbbtenhh.Text == "Chọn hàng hóa")
            {
                cbbtenhh.Text = "";
            }
        }

        private void cbbtenhh_DropDownClosed(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbbtenhh.Text))
            {
                cbbtenhh.Text = "Chọn hàng hóa";
                cbbtenhh.ForeColor = Color.Gray;
            }
            else
            {
                cbbtenhh.ForeColor = Color.Black;
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (hh.CheckMaHHTrung(txbmahh.Text, dataGridView1))
            {
                if (string.IsNullOrEmpty(txbSL.Text))
                {
                    MessageBox.Show("Vui lòng không để trống");
                }
                else
                {
                    string mahh = txbmahh.Text;
                    string tenhh = cbbtenhh.Text;
                    string donG = txbdonG.Text;
                    string sl = txbSL.Text;
                    string thanht = txbtt.Text;
                    dataGridView1.Rows.Insert(0, mahh, tenhh, donG, sl, thanht);
                    int columnIndex = dataGridView1.Columns[2].Index;
                    dataGridView1.Columns[columnIndex].DefaultCellStyle.Format = "N0";
                    CalculateTotal();
                    cbbtenhh.Text = "Chọn mã hàng hóa";
                    cbbtenhh.ForeColor = Color.Gray;
                    txbmahh.Clear();
                    txbdonG.Clear();
                    txbSL.Clear();
                    txbtt.Clear();

                }
            }
            else
            {
                MessageBox.Show("Bạn đã chọn hàng hóa này rồi", "Thông báo", MessageBoxButtons.OK);
            }
        }
        private void CalculateTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                decimal thanhTienValue;
                if (decimal.TryParse(row.Cells[4].Value?.ToString(), out thanhTienValue))
                {
                    total += thanhTienValue;
                }
            }
            txbtongtt.Text = total.ToString("N0", CultureInfo.InvariantCulture);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (string.IsNullOrEmpty(txbSL.Text))
                {
                    MessageBox.Show("Vui lòng không để trống");
                }
                else
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                    string mahh = txbmahh.Text;
                    string tenhh = cbbtenhh.Text;
                    string donG = txbdonG.Text;
                    string sl = txbSL.Text;
                    string thanht = txbtt.Text;

                    selectedRow.Cells[0].Value = mahh;
                    selectedRow.Cells[1].Value = tenhh;
                    selectedRow.Cells[2].Value = donG;
                    selectedRow.Cells[3].Value = sl;
                    selectedRow.Cells[4].Value = thanht;

                    int columnIndex = dataGridView1.Columns[2].Index;
                    dataGridView1.Columns[columnIndex].DefaultCellStyle.Format = "N0";
                    CalculateTotal();
                    cbbtenhh.Text = "Chọn mã hàng hóa";
                    cbbtenhh.ForeColor = Color.Gray;
                    txbmahh.Clear();
                    txbdonG.Clear();
                    txbSL.Clear();
                    txbtt.Clear();
                }
            }
            else
            {
                MessageBox.Show("Chọn hàng hóa cần sửa");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                decimal thanhTienToDelete;
                if (decimal.TryParse(dataGridView1.SelectedRows[0].Cells[4].Value?.ToString(), out thanhTienToDelete))
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                        UpdateTotal(-thanhTienToDelete);
                    }
                }
            }
            else
            {
                MessageBox.Show("Chọn hàng hóa để xóa");
            }
        }
        private void UpdateTotal(decimal amount)
        {
            decimal currentTotal;
            if (decimal.TryParse(txbtongtt.Text, out currentTotal))
            {
                txbtongtt.Text = (currentTotal + amount).ToString("N0", CultureInfo.InvariantCulture);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell clickedCell = (DataGridViewCell)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (clickedCell.Value == null || string.IsNullOrWhiteSpace(clickedCell.Value.ToString()))
                {
                    MessageBox.Show("Chọn hàng hóa");
                }
                else
                {
                    string mahh = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string tenhh = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string donG = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    string sl = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    string thanht = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    txbmahh.Text = mahh;
                    cbbtenhh.Text = tenhh;
                    txbdonG.Text = donG;
                    txbSL.Text = sl;
                    txbtt.Text = thanht;
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            cbbtenhh.Text = "Chọn tên hàng hóa";
            cbbtenhh.ForeColor = Color.Gray;
            txbmahh.Clear();
            txbdonG.Clear();
            txbSL.Clear();
            txbtt.Clear();
        }

        private void cbbhinhthuctt_Leave(object sender, EventArgs e)
        {

        }

        private void cbbhinhthuctt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbhinhthuctt.Text == "Chọn hình thức thanh toán" && cbbhinhthuctt.SelectedIndex == 0)
            {
                cbbhinhthuctt.ForeColor = Color.Gray;
            }
            else
            {
                cbbhinhthuctt.ForeColor = Color.Black;
            }
        }

        private void cbbhinhthuctt_DropDown(object sender, EventArgs e)
        {
            if (cbbhinhthuctt.Text == "Chọn hình thức thanh toán")
            {
                cbbhinhthuctt.Text = "";
            }
        }

        private void cbbhinhthuctt_DropDownClosed(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbbhinhthuctt.Text))
            {
                cbbhinhthuctt.Text = "Chọn hình thức thanh toán";
                cbbhinhthuctt.ForeColor = Color.Gray;
            }
            else
            {
                cbbhinhthuctt.ForeColor = Color.Black;
            }
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            ExcelExport ee = new ExcelExport();
            List<CTHD> list = new List<CTHD>(cthd.GetDataCTHD(lblmahd.Text));
            try
            {
                string fileName = "BaoCao.xls";
                if (ee.ExportHoaDon(list, ref fileName, true, lblmahd.Text, txbmast.Text, txbemail.Text, cbbtenkh.SelectedItem.ToString(), txbmastkh.Text, txbdckh.Text, txbtongtt.Text, txbvatdatinh.Text, txbtongtientt.Text, txbdvb.Text, cbbhinhthuctt.Text))
                {
                    MessageBox.Show("Đã xuất thành công");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất: " + ex.Message);
            }
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            frmDSHoaDon frm = new frmDSHoaDon();
            List<string> maHangHoaList = new List<string>();
            List<int> soLuongList = new List<int>();
            List<double> dgList = new List<double>();
            List<double> ttList = new List<double>();
            string VAT = txtvat.Text + lbphantram.Text;
            DateTime ngayl = DateTime.Now;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    string maHangHoa = row.Cells[0].Value.ToString();
                    double dg = Convert.ToDouble(row.Cells[2].Value);
                    int soLuong = Convert.ToInt32(row.Cells[3].Value);
                    double thanhT = Convert.ToDouble(row.Cells[4].Value);

                    maHangHoaList.Add(maHangHoa);
                    dgList.Add(dg);
                    soLuongList.Add(soLuong);
                    ttList.Add(thanhT);
                }
            }
            if (dataGridView1.RowCount > 1 || (dataGridView1.RowCount == 1 && dataGridView1.Rows[0].Cells[0].Value != null))
            {
                if (cbbhinhthuctt.SelectedItem != null && txbmanv.Text != null && txbmastkh.Text != null && !string.IsNullOrWhiteSpace(txbmahd.Text) && !string.IsNullOrWhiteSpace(txtvat.Text))
                {
                    hd.themHD(txbmahd.Text, ngayl, Convert.ToDouble(txbtongtt.Text), VAT, Convert.ToDouble(txbtongtientt.Text), cbbhinhthuctt.Text, txbmanv.Text, txbmastkh.Text, maHangHoaList.ToArray(), dgList.ToArray(), soLuongList.ToArray(), ttList.ToArray());
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                }
                else
                    MessageBox.Show("Chọn và nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không có hàng hóa để tạo hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXuatIn_Click(object sender, EventArgs e)
        {
            BD_CTHoaDon db = new BD_CTHoaDon();
            List<string> maHHList = db.GetMaHH(lblmahd.Text);
            List<string> tenHHList = db.GetTenHH(lblmahd.Text);
            List<int?> soLuongList = db.GetSoLuong(lblmahd.Text);
            List<float?> donGiaList = db.GetDonGia(lblmahd.Text);
            List<float?> thanhTienList = db.GetThanhTien(lblmahd.Text);
            WordExport w = new WordExport();
            try
            {
                if (w.XuatHoaDon(DateTime.Now.Day.ToString(),
                            DateTime.Now.Month.ToString(),
                            DateTime.Now.Year.ToString(),
                            lblmahd.Text,
                            cbbtenkh.SelectedIndex.ToString(),
                            txbdiachi.Text,
                            txbmastkh.Text,
                            txbtongtt.Text,
                            txbvatdatinh.Text,
                            txbtongtientt.Text,
                            cbbhinhthuctt.Text,
                            maHHList,
                            tenHHList,
                            soLuongList,
                            donGiaList,
                            thanhTienList))
                {
                    MessageBox.Show("Đã xuất thành công");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất: " + ex.Message);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            frmDSHoaDon frm = new frmDSHoaDon();
            List<string> maHangHoaList = new List<string>();
            List<int> soLuongList = new List<int>();
            List<double> ttList = new List<double>();
            string VAT = txtvat.Text + lbphantram.Text;
            DateTime ngayl = DateTime.Now;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    string maHangHoa = row.Cells[0].Value.ToString();
                    int soLuong = Convert.ToInt32(row.Cells[3].Value);
                    double thanhT = Convert.ToDouble(row.Cells[4].Value);

                    maHangHoaList.Add(maHangHoa);
                    soLuongList.Add(soLuong);
                    ttList.Add(thanhT);
                }
            }
            if (dataGridView1.RowCount > 1 || (dataGridView1.RowCount == 1 && dataGridView1.Rows[0].Cells[0].Value != null))
            {
                hd.suaHD(txbmahd.Text, ngayl, Convert.ToDouble(txbtongtt.Text), VAT, Convert.ToDouble(txbtongtientt.Text), cbbhinhthuctt.Text, txbmanv.Text, txbmastkh.Text, maHangHoaList.ToArray(), soLuongList.ToArray(), ttList.ToArray());
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Vui lòng thêm hàng hóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}