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
using WinFormsTextBox = System.Windows.Forms.TextBox;
using System.Text.RegularExpressions;

namespace PhanMemBanHoaChat.NhanVien
{
    public partial class FrmTaoNhanVien : DevExpress.XtraEditors.XtraForm
    {
        BD_NhanVien nv = new BD_NhanVien();
        BD_PhanQuyen pq = new BD_PhanQuyen();
        private FrmDSNhanVien frm;
        private string tendn;
        public FrmTaoNhanVien()
        {
            InitializeComponent();
            LoadData();
        }
        public FrmTaoNhanVien(FrmDSNhanVien frm)
        {
            InitializeComponent();
            this.frm = frm;
            DisplayDataFromDataGridView();
            LoadData();
        }
        private void DisplayDataFromDataGridView()
        {
            int selectedRowIndex = frm.dataGridView1.CurrentCell.RowIndex;

            if (selectedRowIndex >= 0 && selectedRowIndex < frm.dataGridView1.Rows.Count)
            {
                string manv = frm.dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString();
                string tennv = frm.dataGridView1.Rows[selectedRowIndex].Cells[1].Value.ToString();
                string ngaysinh = frm.dataGridView1.Rows[selectedRowIndex].Cells[2].Value.ToString();
                string cccd = frm.dataGridView1.Rows[selectedRowIndex].Cells[3].Value.ToString();
                string email = frm.dataGridView1.Rows[selectedRowIndex].Cells[4].Value.ToString();
                string sdt = frm.dataGridView1.Rows[selectedRowIndex].Cells[5].Value.ToString();
                string tencv = frm.dataGridView1.Rows[selectedRowIndex].Cells[6].Value.ToString();
                string luongcs = frm.dataGridView1.Rows[selectedRowIndex].Cells[7].Value.ToString();
                string hsl = frm.dataGridView1.Rows[selectedRowIndex].Cells[8].Value.ToString();
                string phucap = frm.dataGridView1.Rows[selectedRowIndex].Cells[9].Value.ToString();
                string tienthuong = frm.dataGridView1.Rows[selectedRowIndex].Cells[10].Value.ToString();
                string luongcb = frm.dataGridView1.Rows[selectedRowIndex].Cells[11].Value.ToString();
                string tk = frm.dataGridView1.Rows[selectedRowIndex].Cells[12].Value.ToString();
                txtMaNV.Text = manv;
                txtTenNV.Text = tennv;
                dtpNgaySinh.Text = ngaysinh;
                txtCCCD.Text = cccd;
                txbEmail.Text = email;
                txbSdt.Text = sdt;
                txbchucvu.Text = tencv;
                btnThem.Hide();
                btnLuu.Show();
                if (decimal.TryParse(luongcs, out decimal giaTien))
                {
                    string giaTienFormatted = giaTien.ToString("#,##0");
                    txbLuongCS.Text = giaTienFormatted;
                }
                txbHeSoLuong.Text = hsl;
                if (decimal.TryParse(phucap, out decimal giaTien2))
                {
                    string giaTienFormatted = giaTien2.ToString("#,##0");
                    txbPhuCap.Text = giaTienFormatted;
                }
                if (decimal.TryParse(tienthuong, out decimal giaTien3))
                {
                    string giaTienFormatted = giaTien3.ToString("#,##0");
                    txbTienThuong.Text = giaTienFormatted;
                }
                if (decimal.TryParse(luongcb, out decimal giaTien5))
                {
                    string giaTienFormatted = giaTien5.ToString("#,##0");
                    txbluongcb.Text = giaTienFormatted;
                }
                cbbtkhoan.Text = tk;

            }
        }

        private void FrmTaoNhanVien_Load(object sender, EventArgs e)
        {
            SetPlaceholder("Nhập tên nhân viên", txtTenNV);
            SetPlaceholder("Nhập cccd", txtCCCD);
            SetPlaceholder("Nhập email", txbEmail);
            SetPlaceholder("Nhập số điện thoại", txbSdt);
            SetPlaceholder("Nhập chức vụ", txbchucvu);
            SetPlaceholder("Nhập lương cơ sở", txbLuongCS);
            SetPlaceholder("Nhập hệ số lương", txbHeSoLuong);
            SetPlaceholder("Nhập phụ cấp", txbPhuCap);
            SetPlaceholder("Nhập tiền thưởng", txbTienThuong);
            cbbtkhoan.Text = "Chọn tài khoản";
            cbbtkhoan.ForeColor = Color.Gray;
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
            if (textBox.Text == "Nhập tên nhân viên" || textBox.Text == "Nhập cccd" || textBox.Text == "Nhập email" || textBox.Text == "Nhập số điện thoại" || textBox.Text == "Nhập chức vụ" || textBox.Text == "Nhập lương cơ sở" || textBox.Text == "Nhập hệ số lương" || textBox.Text == "Nhập phụ cấp" || textBox.Text == "Nhập tiền thưởng")
            {
                textBox.Text = "";
                textBox.ForeColor = System.Drawing.Color.Black;
            }
        }
        private void LoadData()
        {
            var mns = pq.LoadTaiKhoan();
            foreach (var mn in mns)
            {
                cbbtkhoan.Items.Add(mn.TenDangNhap);
            }
            cbbtkhoan.SelectedIndex = 0;
        }

        private void cbbtkhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbtkhoan.Text == "Chọn tài khoản" && cbbtkhoan.SelectedIndex == 0)
            {
                cbbtkhoan.ForeColor = Color.Gray;
            }
            else
            {
                cbbtkhoan.ForeColor = Color.Black;
            }
        }

        private void cbbtkhoan_DropDown(object sender, EventArgs e)
        {
            if (cbbtkhoan.Text == "Chọn tài khoản")
            {
                cbbtkhoan.Text = "";
            }
        }

        private void cbbtkhoan_DropDownClosed(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbbtkhoan.Text))
            {
                cbbtkhoan.Text = "Chọn tài khoản";
                cbbtkhoan.ForeColor = Color.Gray;
            }
            else
            {
                cbbtkhoan.ForeColor = Color.Black;
            }
        }
        private string TaoRandomMaNV()
        {
            Random random = new Random();
            int randomValue;
            string manv;
            do
            {
                randomValue = random.Next(0, 1000);
                manv = "NV" + randomValue.ToString("000");
            } while (KiemTraTrungMaNV(manv));

            return manv;
        }
        private bool KiemTraTrungMaNV(string manv)
        {
            return false;
        }

        private void txtTenNV_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txtTenNV);
        }

        private void txtTenNV_Leave(object sender, EventArgs e)
        {
            if (txtTenNV.Text.Length < 5 || txtTenNV.Text.Length > 50)
            {
                MessageBox.Show("Vui lòng nhập từ 5 đến 50 ký tự");
            }
            else if (txtTenNV.Text.Contains("  "))
            {
                MessageBox.Show("Vui lòng chỉ nhập một khoảng trắng giữa các ký tự");
            }
            SetPlaceholder("Nhập tên nhân viên", txtTenNV);
        }

        private void txtCCCD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCCCD_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txtCCCD);
        }

        private void txtCCCD_Leave(object sender, EventArgs e)
        {
            if (txtCCCD.Text.Length != 12)
            {
                MessageBox.Show("Vui lòng nhập đúng 12 số");
            }
            SetPlaceholder("Nhập cccd", txtCCCD);
        }

        private void txbEmail_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txbEmail);
        }

        private void txbEmail_Leave(object sender, EventArgs e)
        {
            string dinhDangMail = @"^[a-zA-Z0-9!@#\$%\^&*\(\)_\-\+=\[\]\{\};:'"",<>./?\\|]+@gmail\.com$";
            if (Regex.IsMatch(txbEmail.Text, dinhDangMail))
            {
            }
            else
            {
                MessageBox.Show("Email không hợp lệ. Vui lòng thử lại");
                txbEmail.Clear();
            }
            SetPlaceholder("Nhập email", txbEmail);
        }

        private void txbSdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbSdt_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txbSdt);
        }

        private void txbSdt_Leave(object sender, EventArgs e)
        {
            if (txbSdt.Text.Length != 10)
            {
                MessageBox.Show("Vui lòng nhập đúng 10 số");
            }
            SetPlaceholder("Nhập số điện thoại", txbSdt);
        }

        private void txbchucvu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbchucvu_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txbchucvu);
        }

        private void txbchucvu_Leave(object sender, EventArgs e)
        {
            if (txbchucvu.Text.Length < 5 || txbchucvu.Text.Length > 50)
            {
                MessageBox.Show("Vui lòng nhập từ 5 đến 50 ký tự");
            }
            else if (txbchucvu.Text.Contains("  "))
            {
                MessageBox.Show("Vui lòng chỉ nhập một khoảng trắng giữa các ký tự");
            }
            SetPlaceholder("Nhập chức vụ", txbchucvu);
        }

        private void txbLuongCS_Leave(object sender, EventArgs e)
        {
            SetPlaceholder("Nhập lương cơ sở", txbLuongCS);
        }

        private void txbLuongCS_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txbLuongCS);
        }

        private void txbHeSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txbHeSoLuong_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txbHeSoLuong);
        }

        private void txbHeSoLuong_Leave(object sender, EventArgs e)
        {
            SetPlaceholder("Nhập hệ số lương", txbHeSoLuong);
        }

        private void txbPhuCap_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txbPhuCap);
        }

        private void txbPhuCap_Leave(object sender, EventArgs e)
        {
            SetPlaceholder("Nhập phụ cấp", txbPhuCap);
        }

        private void txbTienThuong_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txbTienThuong);
        }

        private void txbTienThuong_Leave(object sender, EventArgs e)
        {
            SetPlaceholder("Nhập tiền thưởng", txbTienThuong);
        }

        private void txbLuongCS_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txbLuongCS.Text, out double number))
            {
                txbLuongCS.Text = number.ToString("N0");
                txbLuongCS.SelectionStart = txbLuongCS.Text.Length;
            }
            TinhToan();
        }

        private void txbHeSoLuong_TextChanged(object sender, EventArgs e)
        {
            TinhToan();
        }

        private void txbPhuCap_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txbPhuCap.Text, out double number))
            {
                txbPhuCap.Text = number.ToString("N0");
                txbPhuCap.SelectionStart = txbPhuCap.Text.Length;
            }
            TinhToan();
        }

        private void txbTienThuong_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txbTienThuong.Text, out double number))
            {
                txbTienThuong.Text = number.ToString("N0");
                txbTienThuong.SelectionStart = txbTienThuong.Text.Length;
            }
            TinhToan();
        }
        private void TinhToan()
        {
            if (double.TryParse(txbLuongCS.Text, out double value1) && double.TryParse(txbHeSoLuong.Text, out double value2) && double.TryParse(txbPhuCap.Text, out double value3) && double.TryParse(txbTienThuong.Text, out double value4))
            {
                double kq = value1 * value2 + (value3 + value4);

                txbluongcb.Text = kq.ToString("N0");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaNV.Text = TaoRandomMaNV();
            DateTime ngayht = DateTime.Now;
            DateTime ngaysinh = dtpNgaySinh.Value;
            if (!string.IsNullOrWhiteSpace(txtMaNV.Text) && !string.IsNullOrWhiteSpace(txtTenNV.Text) && !string.IsNullOrWhiteSpace(txtCCCD.Text) && !string.IsNullOrWhiteSpace(txbEmail.Text) && !string.IsNullOrWhiteSpace(txbSdt.Text) && !string.IsNullOrWhiteSpace(txbchucvu.Text) && !string.IsNullOrWhiteSpace(txbLuongCS.Text) && !string.IsNullOrWhiteSpace(txbHeSoLuong.Text) && !string.IsNullOrWhiteSpace(txbPhuCap.Text) && !string.IsNullOrWhiteSpace(txbTienThuong.Text) && !string.IsNullOrWhiteSpace(txbluongcb.Text) && cbbtkhoan.SelectedItem != null)
            {

                if (ngaysinh < ngayht)
                {
                    FrmDSNhanVien frm = new FrmDSNhanVien();
                    nv.ThemNhanVien(txtMaNV.Text, txtTenNV.Text, DateTime.Parse(dtpNgaySinh.Text), txtCCCD.Text, txbEmail.Text, txbSdt.Text, txbchucvu.Text, Convert.ToDouble(txbLuongCS.Text), Convert.ToDouble(txbHeSoLuong.Text), Convert.ToDouble(txbPhuCap.Text), Convert.ToDouble(txbTienThuong.Text), Convert.ToDouble(txbluongcb.Text), cbbtkhoan.Text);
                    frm.dataGridView1.DataSource = nv.LoadNhanVien();
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                    txtMaNV.Clear();
                    txtTenNV.Clear();
                    txtCCCD.Clear();
                    txbEmail.Clear();
                    txbSdt.Clear();
                    txbchucvu.Clear();
                    txbLuongCS.Clear();
                    txbHeSoLuong.Clear();
                    txbPhuCap.Clear();
                    txbTienThuong.Clear();
                    txbluongcb.Clear();
                    SetPlaceholder("Nhập tên nhân viên", txtTenNV);
                    SetPlaceholder("Nhập cccd", txtCCCD);
                    SetPlaceholder("Nhập email", txbEmail);
                    SetPlaceholder("Nhập số điện thoại", txbSdt);
                    SetPlaceholder("Nhập chức vụ", txbchucvu);
                    SetPlaceholder("Nhập lương cơ sở", txbLuongCS);
                    SetPlaceholder("Nhập hệ số lương", txbHeSoLuong);
                    SetPlaceholder("Nhập phụ cấp", txbPhuCap);
                    SetPlaceholder("Nhập tiền thưởng", txbTienThuong);
                    cbbtkhoan.Text = "Chọn tài khoản";
                    cbbtkhoan.ForeColor = Color.Gray;
                }
                else
                {
                    MessageBox.Show("Ngày sinh phải nhỏ hơn ngày hiện tại", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
                MessageBox.Show("Chọn và nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DateTime ngayht = DateTime.Now;
            DateTime ngaysinh = dtpNgaySinh.Value;
            if (!string.IsNullOrWhiteSpace(txtMaNV.Text) && !string.IsNullOrWhiteSpace(txtTenNV.Text) && !string.IsNullOrWhiteSpace(txtCCCD.Text) && !string.IsNullOrWhiteSpace(txbEmail.Text) && !string.IsNullOrWhiteSpace(txbSdt.Text) && !string.IsNullOrWhiteSpace(txbchucvu.Text) && !string.IsNullOrWhiteSpace(txbLuongCS.Text) && !string.IsNullOrWhiteSpace(txbHeSoLuong.Text) && !string.IsNullOrWhiteSpace(txbPhuCap.Text) && !string.IsNullOrWhiteSpace(txbTienThuong.Text) && !string.IsNullOrWhiteSpace(txbluongcb.Text) && cbbtkhoan.SelectedItem != null)
            {

                if (ngaysinh < ngayht)
                {
                    FrmDSNhanVien frm = new FrmDSNhanVien();
                    nv.SuaNhanVien(txtMaNV.Text, txtTenNV.Text, DateTime.Parse(dtpNgaySinh.Text), txtCCCD.Text, txbEmail.Text, txbSdt.Text, txbchucvu.Text, Convert.ToDouble(txbLuongCS.Text), Convert.ToDouble(txbHeSoLuong.Text), Convert.ToDouble(txbPhuCap.Text), Convert.ToDouble(txbTienThuong.Text), Convert.ToDouble(txbluongcb.Text), cbbtkhoan.Text);
                    frm.dataGridView1.DataSource = nv.LoadNhanVien();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ngày sinh phải nhỏ hơn ngày hiện tại", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
                MessageBox.Show("Chọn và nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}