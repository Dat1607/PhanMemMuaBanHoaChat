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
using Tools;

namespace PhanMemBanHoaChat.DatHang
{
    public partial class FrmDatHang : DevExpress.XtraEditors.XtraForm
    {
        BD_DonDatHang ddh = new BD_DonDatHang();
        BD_NhaCC ncc = new BD_NhaCC();
        BD_HangHoa hh = new BD_HangHoa();
        BD_NhanVien nv = new BD_NhanVien();
        private string tendn;
        private AutoCompleteStringCollection autoCompleteCollection;
        public FrmDatHang()
        {
            InitializeComponent();
            LoadDataKH();
            LoadDataHH();
            InitializeUI();
        }
        public FrmDatHang(string tendn)
        {
            InitializeComponent();
            this.tendn = tendn;
            LoadDataKH();
            this.tendn = tendn;
            string tenNhanVien = nv.LayTenNhanVienTuTenDangNhap(tendn);
            txbtennv.Text = tenNhanVien;
            string maNV = nv.LayMaNhanVienTuTenDangNhap(tendn);
            txbmanv.Text = maNV;
            LoadDataHH();
            InitializeUI();
        }
        private void InitializeUI()
        {
            autoCompleteCollection = new AutoCompleteStringCollection();
            //txbmast
            txbmast.AutoCompleteMode = AutoCompleteMode.Suggest;
            txbmast.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txbmast.AutoCompleteCustomSource = autoCompleteCollection;
            //txbdckh
            txbdckh.AutoCompleteMode = AutoCompleteMode.Suggest;
            txbdckh.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txbdckh.AutoCompleteCustomSource = autoCompleteCollection;
            LoadAutoCompleteData();
        }
        private void SaveAutoCompleteData()
        {
            Properties.Settings.Default.AutoCompleteData = autoCompleteCollection;
            Properties.Settings.Default.Save();
        }
        private void LoadAutoCompleteData()
        {
            if (Properties.Settings.Default.AutoCompleteData != null)
            {
                autoCompleteCollection = Properties.Settings.Default.AutoCompleteData;
                txbmast.AutoCompleteCustomSource = autoCompleteCollection;
                txbdckh.AutoCompleteCustomSource = autoCompleteCollection;

            }
        }
        public void ChonHangFromDataGridView(string maDDH)
        {
            DDHCTiet donDH = ddh.GetDataDDHang(maDDH);

            // Hiển thị thông tin hóa đơn lên các TextBox và ComboBox trên Form2
            if (donDH != null)
            {
                lbmaddh.Text = donDH.Maddh;
                txbmast.Text = donDH.MaNCC;
                //cbbtenkh.Text = donDH.TenNCC;
                //cbbtenkh.ForeColor = Color.Black;
                txbdckh.Text = donDH.DiaChiNCC;
                txbTongSL.Text = donDH.TongSL.ToString();
                txbtongtt.Text = donDH.TongThanhTien.Value.ToString("#,##0");
                List<CTDDHCTiet> ctddhList = ddh.GetDataCTDDHang(maDDH);
                if (ctddhList != null)
                {

                    dataGridView2.DataSource = ctddhList;
                    int columnIndex = dataGridView2.Columns[3].Index;
                    int columnIndex1 = dataGridView2.Columns[4].Index;
                    dataGridView2.Columns[columnIndex].DefaultCellStyle.Format = "N0";
                    dataGridView2.Columns[columnIndex1].DefaultCellStyle.Format = "N0";
                    dataGridView2.Columns[0].HeaderText = "Mã hàng hóa";
                    dataGridView2.Columns[1].HeaderText = "Tên hàng hóa";
                    dataGridView2.Columns[2].HeaderText = "Số lượng";
                    dataGridView2.Columns[3].HeaderText = "Đơn giá";
                    dataGridView2.Columns[4].HeaderText = "Thành tiền";
                }
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
        private void SoLuongTotal()
        {
            int totalSL = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int soLuongValue;
                if (int.TryParse(row.Cells[3].Value?.ToString(), out soLuongValue))
                {
                    totalSL += soLuongValue;
                }
            }
            txbTongSL.Text = totalSL.ToString();
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
            if (cbbtenhh.Text == "Chọn tên hàng hóa" && cbbtenhh.SelectedIndex == 0)
            {
                cbbtenhh.ForeColor = Color.Gray;
            }
            else
            {
                cbbtenhh.ForeColor = Color.Black;
                string chonGiaTri = cbbtenhh.SelectedItem.ToString();
                string tenhh = hh.LayTenHHByMaHH(chonGiaTri);
                txbmahh.Text = tenhh;
            }
        }

        private void cbbtenhh_DropDown(object sender, EventArgs e)
        {
            if (cbbtenhh.Text == "Chọn tên hàng hóa")
            {
                cbbtenhh.Text = "";
            }
        }

        private void cbbtenhh_DropDownClosed(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbbtenhh.Text))
            {
                cbbtenhh.Text = "Chọn tên hàng hóa";
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
                    dataGridView1.Rows.Add(mahh, tenhh, donG, sl, thanht);
                    int columnIndex = dataGridView1.Columns[2].Index;
                    dataGridView1.Columns[columnIndex].DefaultCellStyle.Format = "N0";
                    CalculateTotal();
                    SoLuongTotal();
                    cbbtenhh.Text = "Chọn tên hàng hóa";
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
                    int columnIndex1 = dataGridView1.Columns[4].Index;
                    dataGridView1.Columns[columnIndex1].DefaultCellStyle.Format = "N0";
                    CalculateTotal();
                    SoLuongTotal();
                    cbbtenhh.Text = "Chọn tên hàng hóa";
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
                int soLuongToDelete;
                if (decimal.TryParse(dataGridView1.SelectedRows[0].Cells[4].Value?.ToString(), out thanhTienToDelete) && int.TryParse(dataGridView1.SelectedRows[0].Cells[3].Value?.ToString(), out soLuongToDelete))
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                        UpdateTotal(-thanhTienToDelete);
                        UpdateTotalSL(-soLuongToDelete);
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
        private void UpdateTotalSL(int amount)
        {
            int currentTotal;
            if (int.TryParse(txbTongSL.Text, out currentTotal))
            {
                txbTongSL.Text = (currentTotal + amount).ToString("N0", CultureInfo.InvariantCulture);
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

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cbbtenhh.Text = "Chọn tên hàng hóa";
            cbbtenhh.ForeColor = Color.Gray;
            txbmahh.Clear();
            txbdonG.Clear();
            txbSL.Clear();
            txbtt.Clear();
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            DateTime ngayD = DateTime.Now;
            string maKhachHang = txbmast.Text;
            string baSoDau = maKhachHang.Substring(0, 3);
            Random random = new Random();
            int randomNumber = random.Next(10, 99);
            string maDonDatHang = "DDH" + baSoDau + randomNumber;
            string tinhtrangdon = "Yêu cầu đặt hàng";
            FrmDSDatHang frm = new FrmDSDatHang();
            List<string> maHangHoaList = new List<string>();
            List<int> soLuongList = new List<int>();
            List<double> dgList = new List<double>();
            List<double> ttList = new List<double>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    string maHangHoa = row.Cells[0].Value.ToString();
                    double dongia = Convert.ToDouble(row.Cells[2].Value);
                    int soLuong = Convert.ToInt32(row.Cells[3].Value);
                    double thanhT = Convert.ToDouble(row.Cells[4].Value);

                    maHangHoaList.Add(maHangHoa);
                    soLuongList.Add(soLuong);
                    dgList.Add(dongia);
                    ttList.Add(thanhT);
                }
            }
            if (dataGridView1.RowCount > 1 || (dataGridView1.RowCount == 1 && dataGridView1.Rows[0].Cells[0].Value != null))
            {
                // Tiếp tục kiểm tra và thêm đơn đặt hàng
                if (!string.IsNullOrWhiteSpace(txbmast.Text)  && !string.IsNullOrWhiteSpace(txbdckh.Text))
                {
                    if (!ncc.KiemTraMaNCC(txbmast.Text))
                    {
                        ddh.themDDH(maDonDatHang, Convert.ToInt32(txbTongSL.Text), Convert.ToDouble(txbtongtt.Text), ngayD, txbmast.Text, tinhtrangdon, tendn, maHangHoaList.ToArray(), soLuongList.ToArray(), dgList.ToArray(), ttList.ToArray());
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        ncc.ThemNCC(txbmast.Text, cbbtenkh.Text, txbdckh.Text);
                        ddh.themDDH(maDonDatHang, Convert.ToInt32(txbTongSL.Text), Convert.ToDouble(txbtongtt.Text), ngayD, txbmast.Text, tinhtrangdon, tendn, maHangHoaList.ToArray(), soLuongList.ToArray(), dgList.ToArray(), ttList.ToArray());
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else
                    MessageBox.Show("Chọn và nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không có hàng hóa để đặt hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            ExcelExport ee = new ExcelExport();
            List<CTDDHCTiet> list = new List<CTDDHCTiet>(ddh.GetDataCTDDHang(lbmaddh.Text));
            try
            {
                string fileName = "BaoCao.xls";
                if (ee.ExportDonDatHang(list, ref fileName, true, lbmaddh.Text, txbmast.Text, cbbtenkh.Text, txbdckh.Text, txbTongSL.Text, txbtongtt.Text, dtpNgayd.Text)) ;
                {
                    MessageBox.Show("Đã xuất thành công");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất: " + ex.Message);
            }
        }

        private void btnXuatIn_Click(object sender, EventArgs e)
        {
            List<string> maHHList = ddh.GetMaHH(lbmaddh.Text);
            List<string> tenHHList = ddh.GetTenHH(lbmaddh.Text);
            List<int?> soLuongList = ddh.GetSoLuong(lbmaddh.Text);
            List<double?> donGiaList = ddh.GetDonGia(lbmaddh.Text);
            List<double?> thanhTienList = ddh.GetThanhTien(lbmaddh.Text);
            WordExport w = new WordExport();
            try
            {
                if (w.XuatDonDatHang(DateTime.Now.Day.ToString(),
                            DateTime.Now.Month.ToString(),
                            DateTime.Now.Year.ToString(),
                            lbmaddh.Text, txbmast.Text, lbmaddh.Text, txbdckh.Text, txbTongSL.Text, txbtongtt.Text, dtpNgayd.Text,
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

        private void FrmDatHang_Load(object sender, EventArgs e)
        {
            cbbtenkh.SelectedIndex = 0;
            cbbtenkh.Text = "Chọn khách hàng";
            cbbtenkh.ForeColor = Color.Gray;

        }

        private void txbtenkh_TextChanged(object sender, EventArgs e)
        {
            //string maKH = txbtenkh.Text;
            //string tenKH = kh.LayTenKHByMaKH(maKH);
            //string diaChiKH = kh.LayDiaCKHByMaKH(maKH);
            //string sdtKH = kh.LaySDTKHByMaKH(maKH);
            //string ngDaiDienPL = kh.LayNGDDPLKHByMaKH(maKH);
            //string ngLienHeMuaH = kh.LayNGLHMUAKHByMaKH(maKH);
            //string diaChiGiao = kh.LayDCGiaoKHByMaKH(maKH);
            //string mail = kh.LayMailKHByMaKH(maKH);
            //txbmast.Text = tenKH;
            //txbdckh.Text = diaChiKH;
            //txbsdt.Text = sdtKH;
            //txbNgDDPhapLy.Text = ngDaiDienPL;
            //txbNgLHMua.Text = ngLienHeMuaH;
            //txbDCGiao.Text = diaChiGiao;
            //txbmail.Text = mail;
        }

        private void txbtenkh_Leave(object sender, EventArgs e)
        {
        }

        private void txbtenkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbdckh_Leave(object sender, EventArgs e)
        {
            if (txbdckh.Text.Length < 5 || txbdckh.Text.Length > 50)
            {
                MessageBox.Show("Vui lòng nhập từ 5 đến 50 ký tự");
            }
            else if (txbdckh.Text.Contains("  "))
            {
                MessageBox.Show("Vui lòng chỉ nhập một khoảng trắng giữa các ký tự");
            }
            if (!string.IsNullOrWhiteSpace(txbdckh.Text))
            {
                if (!autoCompleteCollection.Contains(txbdckh.Text))
                {
                    autoCompleteCollection.Add(txbdckh.Text);
                }
                SaveAutoCompleteData();
                txbdckh.AutoCompleteCustomSource = autoCompleteCollection;
            }
        }

        private void txbNgDDPhapLy_Leave(object sender, EventArgs e)
        {
            
        }

        private void txbNgDDPhapLy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbNgLHMua_Leave(object sender, EventArgs e)
        {
           
        }

        private void txbNgLHMua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbDCGiao_Leave(object sender, EventArgs e)
        {
        }

        private void txbmast_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txbmast.Text))
            {
                if (!autoCompleteCollection.Contains(txbmast.Text))
                {
                    autoCompleteCollection.Add(txbmast.Text);
                }
                SaveAutoCompleteData();
                txbmast.AutoCompleteCustomSource = autoCompleteCollection;
            }
        }

        private void txbmast_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbsdt_Leave(object sender, EventArgs e)
        {
        }

        private void txbsdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbmast_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrWhiteSpace(txbmast.Text) && !autoCompleteCollection.Contains(txbmast.Text))
                {
                    autoCompleteCollection.Add(txbmast.Text);
                }
                SaveAutoCompleteData();
                txbmast.AutoCompleteCustomSource = autoCompleteCollection;
            }
        }

        private void txbtenkh_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void txbdckh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrWhiteSpace(txbdckh.Text) && !autoCompleteCollection.Contains(txbdckh.Text))
                {
                    autoCompleteCollection.Add(txbdckh.Text);
                }
                SaveAutoCompleteData();
                txbdckh.AutoCompleteCustomSource = autoCompleteCollection;
            }
        }

        private void txbsdt_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void txbNgDDPhapLy_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void txbNgLHMua_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void txbDCGiao_KeyDown(object sender, KeyEventArgs e)
        {
        }
        private void LoadDataKH()
        {
            var mns = ncc.GetData();

            foreach (var mn in mns)
            {
                cbbtenkh.Items.Add(mn.TenNCC);
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
                string mancc = ncc.LayMaNCCByTenncc(chonGiaTri);
                string diaChincc = ncc.LayDiaCNCCByTenncc(chonGiaTri);
                txbmast.Text = mancc;
                txbdckh.Text = diaChincc;
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
    }
}