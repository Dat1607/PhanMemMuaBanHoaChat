using BLL_DAL;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsTextBox = System.Windows.Forms.TextBox;

namespace PhanMemBanHoaChat.Phieu
{
    public partial class FrmTaoPhieuNhanHang : DevExpress.XtraEditors.XtraForm
    {
        BD_PhieuNhanHang pnh = new BD_PhieuNhanHang();
        BD_NhaCC ncc = new BD_NhaCC();
        BD_HangHoa hh = new BD_HangHoa();
        BD_NhanVien nv = new BD_NhanVien();
        private string tendn;
        private string maPNH;
        public FrmTaoPhieuNhanHang()
        {
            InitializeComponent();
        }
        public FrmTaoPhieuNhanHang(string tendn)
        {
            InitializeComponent();
            LoadDataNCC();
            LoadDataHH();
            this.tendn = tendn;
            string tenNhanVien = nv.LayTenNhanVienTuTenDangNhap(tendn);
            txbtennv.Text = tenNhanVien;
            string maNV = nv.LayMaNhanVienTuTenDangNhap(tendn);
            txbmanv.Text = maNV;
            txbmapnh.Text = TaoRandomMaPNH();
        }

        private void FrmTaoPhieuNhanHang_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            txbdvb.Text = "CÔNG TY TNHH TM DV ĐẦU TƯ VÀ PHÁT TRIỂN PHÚC THỊNH VINA";
            txbmast.Text = "0315745341";
            txbdiachi.Text = "Lầu 2, Số 170N Nơ Trang Long, Phường 12, Quận Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam";
            txbemail.Text = "ptvina2023@gmail.com";
            SetPlaceholder("Nhập quy cách", txbQC);
            SetPlaceholder("Nhập đơn giá", txbdonG);
            SetPlaceholder("Nhập số lượng", txbSL);
        }
        public void ChonHangFromDataGridView(string maPNH)
        {
            PNHCTiet PNH = pnh.GetDataPNHang(maPNH);

            if (PNH != null)
            {
                txbmapnh.Text = PNH.MaPNH;
                DateTime ngayLap = Convert.ToDateTime(PNH.NgayLap);
                lbhienngayl.Text = ngayLap.ToString("dd/MM/yyyy");
                dtpNgayG.Value = Convert.ToDateTime(PNH.NgayGiao);
                txbtennv.Text = PNH.TenNV;
                txbmanv.Text = PNH.MaNV;
                cbbtenncc.Text = PNH.TenNCC;
                cbbtenncc.ForeColor = Color.Black;
                txbmancc.Text = PNH.MaNCC;
                txbdcncc.Text = PNH.DiaChiGiao;
                txbtongtt.Text = PNH.TongThanhTien.Value.ToString("#,##0");
                txbvat.Text = PNH.Thue.Trim().TrimEnd('%');
                txbtongtientt.Text = PNH.TongCongThanhToan.Value.ToString("#,##0");
                txbghichu.Text = PNH.GhiChu;
                List<CTPNHCTiet> ctPNHList = pnh.GetDataCTPNHang(maPNH);
                if (ctPNHList != null && ctPNHList.Any())
                {
                    foreach (CTPNHCTiet ctPNHItem in ctPNHList)
                    {
                        string maHH = ctPNHItem.MaHangHoa;
                        string tenHH = ctPNHItem.TenHangHoa;
                        string dvt = ctPNHItem.DonViTinh;
                        int? sl = ctPNHItem.SoLuong;
                        string quyC = ctPNHItem.QuyCach;
                        string donG = ctPNHItem.DonGia.HasValue ? ctPNHItem.DonGia.Value.ToString("#,##0") : "";
                        string thanhT = ctPNHItem.ThanhTien.HasValue ? ctPNHItem.ThanhTien.Value.ToString("#,##0") : "";
                        dataGridView1.Rows.Add(maHH, tenHH, dvt, sl, quyC, donG, thanhT);
                    }
                    int columnIndex = dataGridView1.Columns[5].Index;
                    dataGridView1.Columns[columnIndex].DefaultCellStyle.Format = "N0";
                    int columnIndex1 = dataGridView1.Columns[6].Index;
                    dataGridView1.Columns[columnIndex1].DefaultCellStyle.Format = "N0";
                }
            }
        }
        private void SetPlaceholder(string placeholder, WinFormsTextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholder;
                textBox.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void RemovePlaceholder(WinFormsTextBox textBox)
        {
            if (textBox.Text == "Nhập quy cách" || textBox.Text == "Nhập đơn giá" || textBox.Text == "Nhập số lượng")
            {
                textBox.Text = "";
                textBox.ForeColor = System.Drawing.Color.Black;
            }
        }
        private string TaoRandomMaPNH()
        {
            Random random = new Random();
            int randomValue;
            string maPNH;
            do
            {
                randomValue = random.Next(0, 1000);
                maPNH = "PNH" + randomValue.ToString("000");
            } while (KiemTraTrungMaPNH(maPNH));

            return maPNH;
        }

        private bool KiemTraTrungMaPNH(string maPNH)
        {
            return false;
        }
        private void LoadDataNCC()
        {
            var mns = ncc.GetData();

            foreach (var mn in mns)
            {
                cbbtenncc.Items.Add(mn.TenNCC);
            }
            cbbtenncc.SelectedIndex = 0;
        }

        private void cbbtenncc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbtenncc.Text == "Chọn nhà cung cấp" && cbbtenncc.SelectedIndex == 0)
            {
                cbbtenncc.ForeColor = Color.Gray;
            }
            else
            {
                cbbtenncc.ForeColor = Color.Black;
                string chonGiaTri = cbbtenncc.SelectedItem.ToString();
                string mancc = ncc.LayMaNCCByTenncc(chonGiaTri);
                string diachiNCC = ncc.LayDiaCNCCByTenncc(chonGiaTri);
                txbmancc.Text = mancc;
                txbdcncc.Text = diachiNCC;

            }
        }

        private void cbbtenncc_DropDown(object sender, EventArgs e)
        {
            if (cbbtenhh.Text == "Chọn hàng hóa")
            {
                cbbtenhh.Text = "";
            }
        }

        private void cbbtenncc_DropDownClosed(object sender, EventArgs e)
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
        private void LoadDataHH()
        {
            var mns = hh.GetData();

            foreach (var mn in mns)
            {
                cbbtenhh.Items.Add(mn.TenHangHoa);
            }
            cbbtenhh.SelectedIndex = 0;
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
            if (decimal.TryParse(txbvat.Text, out decimal vatPercent))
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
        private void CalculateTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                decimal thanhTienValue;
                if (decimal.TryParse(row.Cells[6].Value?.ToString(), out thanhTienValue))
                {
                    total += thanhTienValue;
                }
            }
            txbtongtt.Text = total.ToString("N0", CultureInfo.InvariantCulture);
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbSL.Text) && string.IsNullOrEmpty(txbdonG.Text) && string.IsNullOrEmpty(txbQC.Text))
            {
                MessageBox.Show("Vui lòng nccông để trống");
            }
            else
            {
                string tenhh = cbbtenhh.Text;
                string mahh = txbmahh.Text;
                string dvt = txbdvt.Text;
                int sl = Convert.ToInt16(txbSL.Text);
                string quyc = txbQC.Text;
                double donG = Convert.ToDouble(txbdonG.Text);
                double thanht = Convert.ToDouble(txbtt.Text);
                dataGridView1.Rows.Add(mahh, tenhh, dvt, sl, quyc, donG, thanht);
                int columnIndex = dataGridView1.Columns[5].Index;
                dataGridView1.Columns[columnIndex].DefaultCellStyle.Format = "N0";
                int columnIndex1 = dataGridView1.Columns[6].Index;
                dataGridView1.Columns[columnIndex1].DefaultCellStyle.Format = "N0";
                CalculateTotal();
                cbbtenhh.Text = "Chọn hàng hóa";
                cbbtenhh.ForeColor = Color.Gray;
                txbmahh.Clear();
                txbdvt.Clear();
                txbSL.Clear();
                txbQC.Clear();
                txbdonG.Clear();
                txbtt.Clear();
                SetPlaceholder("Nhập quy cách", txbQC);
                SetPlaceholder("Nhập đơn giá", txbdonG);
                SetPlaceholder("Nhập số lượng", txbSL);

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (string.IsNullOrEmpty(txbSL.Text) && string.IsNullOrEmpty(txbdonG.Text) && string.IsNullOrEmpty(txbQC.Text))
                {
                    MessageBox.Show("Vui lòng nccông để trống");
                }
                else
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                    string tenhh = cbbtenhh.Text;
                    string mahh = txbmahh.Text;
                    string dvt = txbdvt.Text;
                    string sl = txbSL.Text;
                    string qc = txbQC.Text;
                    string donG = txbdonG.Text;
                    string thanht = txbtt.Text;

                    selectedRow.Cells[0].Value = mahh;
                    selectedRow.Cells[1].Value = tenhh;
                    selectedRow.Cells[2].Value = dvt;
                    selectedRow.Cells[3].Value = sl;
                    selectedRow.Cells[4].Value = qc;
                    selectedRow.Cells[5].Value = donG;
                    selectedRow.Cells[6].Value = thanht;

                    int columnIndex = dataGridView1.Columns[5].Index;
                    dataGridView1.Columns[columnIndex].DefaultCellStyle.Format = "N0";
                    int columnIndex1 = dataGridView1.Columns[6].Index;
                    dataGridView1.Columns[columnIndex1].DefaultCellStyle.Format = "N0";
                    CalculateTotal();
                    cbbtenhh.Text = "Chọn hàng hóa";
                    cbbtenhh.ForeColor = Color.Gray;
                    txbmahh.Clear();
                    txbdvt.Clear();
                    txbSL.Clear();
                    txbQC.Clear();
                    txbdonG.Clear();
                    txbtt.Clear();
                }
            }
            else
            {
                MessageBox.Show("Chọn hàng hóa cần sửa");
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
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
                    string tenhh = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string mahh = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string dvt = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    string sl = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    string quyc = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    string donG = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    string tt = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                    cbbtenhh.Text = tenhh;
                    txbmahh.Text = mahh;
                    txbdvt.Text = dvt;
                    txbSL.Text = sl;
                    txbQC.Text = quyc;
                    txbdonG.Text = donG;
                    txbtt.Text = tt;
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cbbtenhh.Text = "Chọn hàng hóa";
            cbbtenhh.ForeColor = Color.Gray;
            txbmahh.Clear();
            txbdonG.Clear();
            txbQC.Clear();
            txbtt.Clear();
            txbSL.Clear();
            txbdvt.Clear();
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            FrmDSPhieuNhanHang frm = new FrmDSPhieuNhanHang();
            List<string> maHangHoaList = new List<string>();
            List<int> soLuongList = new List<int>();
            List<string> quycList = new List<string>();
            List<double> dgList = new List<double>();
            List<double> ttList = new List<double>();
            string VAT = txbvat.Text + lbphantram.Text;
            DateTime ngayL = DateTime.Now;
            DateTime ngayG = dtpNgayG.Value;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    string maHangHoa = row.Cells[0].Value.ToString();
                    int soLuong = Convert.ToInt32(row.Cells[3].Value);
                    string quycach = row.Cells[4].Value.ToString();
                    double donG = Convert.ToDouble(row.Cells[5].Value);
                    double tt = Convert.ToDouble(row.Cells[6].Value);
                    maHangHoaList.Add(maHangHoa);
                    soLuongList.Add(soLuong);
                    quycList.Add(quycach);
                    dgList.Add(donG);
                    ttList.Add(tt);

                }
            }
            if (dataGridView1.RowCount > 1 || (dataGridView1.RowCount == 1 && dataGridView1.Rows[0].Cells[0].Value != null))
            {
                if (cbbtenncc.SelectedItem != null)
                {
                        pnh.themPNH(txbmapnh.Text, ngayL, DateTime.Parse(dtpNgayG.Text), Convert.ToDouble(txbtongtt.Text), VAT, Convert.ToDouble(txbtongtientt.Text), txbmancc.Text, txbmanv.Text, txbghichu.Text, maHangHoaList.ToArray(), soLuongList.ToArray(), quycList.ToArray(), dgList.ToArray(), ttList.ToArray());
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                        txbmapnh.Text = TaoRandomMaPNH();
                        cbbtenncc.Text = "Chọn tên nhà cung cấp";
                        cbbtenncc.ForeColor = Color.Gray;
                        txbmancc.Clear(); 
                }
                else
                    MessageBox.Show("Chọn và nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Không có hàng hóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txbQC_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txbQC);
        }

        private void txbQC_Leave(object sender, EventArgs e)
        {
            if (txbQC.Text.Length < 5 || txbQC.Text.Length > 50)
            {
                MessageBox.Show("Vui lòng nhập từ 5 đến 50 ký tự");
            }
            else if (txbQC.Text.Contains("  "))
            {
                MessageBox.Show("Vui lòng chỉ nhập một khoảng trắng giữa các ký tự");
            }
            SetPlaceholder("Nhập quy cách", txbQC);
        }

        private void txbdonG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbdonG_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txbdonG);
        }

        private void txbdonG_Leave(object sender, EventArgs e)
        {
            SetPlaceholder("Nhập đơn giá", txbdonG);
        }

        private void txbSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbSL_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txbSL);
        }

        private void txbSL_Leave(object sender, EventArgs e)
        {
            SetPlaceholder("Nhập số lượng", txbSL);
        }

        private void txbvat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
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
                string dvt = hh.LayDVTByTenHH(chonGiaTri);
                txbmahh.Text = mahh;
                txbdvt.Text = dvt;

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

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            ExcelExport ee = new ExcelExport();
            List<CTPNHCTiet> List = new List<CTPNHCTiet>(pnh.GetDataCTPNHang(txbmapnh.Text));
            try
            {
                string fileName = "BaoCao.xls";
                if (ee.ExportPhieuNhapHang(List, ref fileName, true, txbdvb.Text, txbdiachi.Text, txbemail.Text, txbmapnh.Text, cbbtenncc.Text, txbdcncc.Text, txbmancc.Text, dtpNgayG.Text, txbtongtt.Text, txbvatdatinh.Text, txbtongtientt.Text))
                {
                    MessageBox.Show("Đã xuất thành công");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất: " + ex.Message);
            }
        }
    }
}