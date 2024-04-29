using BLL_DAL;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemBanHoaChat.KhachHang
{
    public partial class FrmTaoKhachHang : DevExpress.XtraEditors.XtraForm
    {
        BD_KhachHang kh = new BD_KhachHang();
        BD_NhanVien nv = new BD_NhanVien();
        private FrmDSKhachHang frm;
        private string tendn;

        public FrmTaoKhachHang(string tendn)
        {
            InitializeComponent();
            this.tendn = tendn;
            string tenNhanVien = nv.LayTenNhanVienTuTenDangNhap(tendn);
            txbNVQL.Text = tenNhanVien;
            string maNV = nv.LayMaNhanVienTuTenDangNhap(tendn);
            txbMaNV.Text = maNV;
        }
        public FrmTaoKhachHang(FrmDSKhachHang frm)
        {
            InitializeComponent();
            this.frm = frm;
            DisplayDataFromDataGridView();
        }
        private void DisplayDataFromDataGridView()
        {
            int selectedRowIndex = frm.dataGridView1.CurrentCell.RowIndex;

            if (selectedRowIndex >= 0 && selectedRowIndex < frm.dataGridView1.Rows.Count)
            {
                string manv = frm.dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString();
                string nvql = frm.dataGridView1.Rows[selectedRowIndex].Cells[1].Value.ToString();
                string makh = frm.dataGridView1.Rows[selectedRowIndex].Cells[2].Value.ToString();
                string tenkh = frm.dataGridView1.Rows[selectedRowIndex].Cells[3].Value.ToString();
                string diachi = frm.dataGridView1.Rows[selectedRowIndex].Cells[4].Value.ToString();
                string mail = frm.dataGridView1.Rows[selectedRowIndex].Cells[5].Value.ToString();
                string sdt = frm.dataGridView1.Rows[selectedRowIndex].Cells[6].Value.ToString();
                string ngddpl = frm.dataGridView1.Rows[selectedRowIndex].Cells[7].Value.ToString();
                string nglhmh = frm.dataGridView1.Rows[selectedRowIndex].Cells[8].Value.ToString();
                string diachigiao = frm.dataGridView1.Rows[selectedRowIndex].Cells[9].Value.ToString();

                txbMaNV.Text = manv;
                txbNVQL.Text = nvql;
                txbMaKH.Text = makh;
                txbTenKH.Text = tenkh;
                txbdchi.Text = diachi;
                txbMail.Text = mail;
                txbsdt.Text = sdt;
                txbNgDDPhapLy.Text = ngddpl;
                txbNgLHMua.Text = nglhmh;
                txbDCGiao.Text = diachigiao;
                
                txbMaKH.ReadOnly = true;
            }
        }

        private void FrmTaoKhachHang_Load(object sender, EventArgs e)
        {
           
            SetPlaceholder("Nhập mã khách hàng", txbMaKH);
            SetPlaceholder("Nhập tên khách hàng", txbTenKH);
            SetPlaceholder("Nhập địa chỉ", txbdchi);
            SetPlaceholder("Nhập mail", txbMail);
            SetPlaceholder("Nhập số điện thoại", txbsdt);
            SetPlaceholder("Nhập người đại diện pháp lý", txbNgDDPhapLy);
            SetPlaceholder("Nhập người liên hệ mua hàng", txbNgLHMua);
            SetPlaceholder("Nhập địa chỉ giao hàng", txbDCGiao);
        }
        private void SetPlaceholder(string placeholder, TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholder;
                textBox.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void RemovePlaceholder(TextBox textBox)
        {
            if (textBox.Text == "Nhập mã khách hàng" || textBox.Text == "Nhập tên khách hàng" || textBox.Text == "Nhập địa chỉ" || textBox.Text == "Nhập mail" || textBox.Text == "Nhập số điện thoại" || textBox.Text == "Nhập người đại diện pháp lý" || textBox.Text == "Nhập người liên hệ mua hàng" || textBox.Text == "Nhập địa chỉ giao hàng")
            {
                textBox.Text = "";
                textBox.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txbMaKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbMaKH_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txbMaKH);
        }

        private void txbMaKH_Leave(object sender, EventArgs e)
        {
            SetPlaceholder("Nhập mã khách hàng", txbMaKH);
        }

        private void txbTenKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbTenKH_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txbTenKH);
        }

        private void txbTenKH_Leave(object sender, EventArgs e)
        {
            if (txbTenKH.Text.Length < 5 || txbTenKH.Text.Length > 50)
            {
                MessageBox.Show("Vui lòng nhập từ 5 đến 50 ký tự");
            }
            else if (txbTenKH.Text.Contains("  "))
            {
                MessageBox.Show("Vui lòng chỉ nhập một khoảng trắng giữa các ký tự");
            }
            SetPlaceholder("Nhập tên khách hàng", txbTenKH);
        }

        private void txbdchi_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txbdchi);
        }

        private void txbdchi_Leave(object sender, EventArgs e)
        {
            if (txbdchi.Text.Length < 5 || txbdchi.Text.Length > 50)
            {
                MessageBox.Show("Vui lòng nhập từ 5 đến 50 ký tự");
            }
            else if (txbdchi.Text.Contains("  "))
            {
                MessageBox.Show("Vui lòng chỉ nhập một khoảng trắng giữa các ký tự");
            }
            SetPlaceholder("Nhập địa chỉ", txbdchi);
        }

        private void txbMail_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txbMail);
        }

        private void txbMail_Leave(object sender, EventArgs e)
        {
            string dinhDangMail = @"^[a-zA-Z0-9!@#\$%\^&*\(\)_\-\+=\[\]\{\};:'"",<>./?\\|]+@gmail\.com$";
            if (Regex.IsMatch(txbMail.Text, dinhDangMail))
            {
            }
            else
            {
                MessageBox.Show("Email không hợp lệ. Vui lòng thử lại");
                txbMail.Clear();
            }
            SetPlaceholder("Nhập mail", txbMail);
        }

        private void txbsdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbsdt_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txbsdt);
        }

        private void txbsdt_Leave(object sender, EventArgs e)
        {
            if (txbsdt.Text.Length != 10)
            {
                MessageBox.Show("Vui lòng nhập đúng 10 số");
            }
            SetPlaceholder("Nhập số điện thoại", txbsdt);
        }

        private void txbNgDDPhapLy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbNgDDPhapLy_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txbNgDDPhapLy);
        }

        private void txbNgDDPhapLy_Leave(object sender, EventArgs e)
        {
            if (txbNgDDPhapLy.Text.Length < 5 || txbNgDDPhapLy.Text.Length > 50)
            {
                MessageBox.Show("Vui lòng nhập từ 5 đến 50 ký tự");
            }
            else if (txbNgDDPhapLy.Text.Contains("  "))
            {
                MessageBox.Show("Vui lòng chỉ nhập một khoảng trắng giữa các ký tự");
            }
            SetPlaceholder("Nhập người đại diện pháp lý", txbNgDDPhapLy);
        }

        private void txbNgLHMua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbNgLHMua_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txbNgLHMua);
        }

        private void txbNgLHMua_Leave(object sender, EventArgs e)
        {
            if (txbNgLHMua.Text.Length < 5 || txbNgLHMua.Text.Length > 50)
            {
                MessageBox.Show("Vui lòng nhập từ 5 đến 50 ký tự");
            }
            else if (txbNgLHMua.Text.Contains("  "))
            {
                MessageBox.Show("Vui lòng chỉ nhập một khoảng trắng giữa các ký tự");
            }
            SetPlaceholder("Nhập người liên hệ mua hàng", txbNgLHMua);
        }

        private void txbDCGiao_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txbDCGiao);
        }

        private void txbDCGiao_Leave(object sender, EventArgs e)
        {
            if (txbDCGiao.Text.Length < 5 || txbDCGiao.Text.Length > 50)
            {
                MessageBox.Show("Vui lòng nhập từ 5 đến 50 ký tự");
            }
            else if (txbDCGiao.Text.Contains("  "))
            {
                MessageBox.Show("Vui lòng chỉ nhập một khoảng trắng giữa các ký tự");
            }
            SetPlaceholder("Nhập địa chỉ giao hàng", txbDCGiao);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txbMaKH.Text) && !string.IsNullOrWhiteSpace(txbTenKH.Text) && !string.IsNullOrWhiteSpace(txbdchi.Text) && !string.IsNullOrWhiteSpace(txbMail.Text) && !string.IsNullOrWhiteSpace(txbsdt.Text) && !string.IsNullOrWhiteSpace(txbNgDDPhapLy.Text) && !string.IsNullOrWhiteSpace(txbNgLHMua.Text) && !string.IsNullOrWhiteSpace(txbDCGiao.Text))
            {
                if (kh.KiemTraMaKH(txbMaKH.Text))
                {
                    FrmDSKhachHang frm = new FrmDSKhachHang();
                    kh.Themkhachhang(txbMaKH.Text, txbTenKH.Text, txbdchi.Text, txbMail.Text, txbsdt.Text, txbNgDDPhapLy.Text, txbNgLHMua.Text, txbDCGiao.Text, txbMaNV.Text);
                    frm.dataGridView1.DataSource = kh.GetData();
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                    txbMaKH.Clear();
                    txbTenKH.Clear();
                    txbdchi.Clear();
                    txbMail.Clear();
                    txbsdt.Clear();
                    txbNgDDPhapLy.Clear();
                    txbNgLHMua.Clear();
                    txbDCGiao.Clear();
                    SetPlaceholder("Nhập mã khách hàng", txbMaKH);
                    SetPlaceholder("Nhập tên khách hàng", txbTenKH);
                    SetPlaceholder("Nhập địa chỉ", txbdchi);
                    SetPlaceholder("Nhập mail", txbMail);
                    SetPlaceholder("Nhập số điện thoại", txbsdt);
                    SetPlaceholder("Nhập người đại diện pháp lý", txbNgDDPhapLy);
                    SetPlaceholder("Nhập người liên hệ mua hàng", txbNgLHMua);
                    SetPlaceholder("Nhập địa chỉ giao hàng", txbDCGiao);
                }
                else
                {
                    MessageBox.Show("Mã khách hàng đã có trong danh sách", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
                MessageBox.Show("Chọn và nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txbMaKH.Text) && !string.IsNullOrWhiteSpace(txbTenKH.Text) && !string.IsNullOrWhiteSpace(txbdchi.Text) && !string.IsNullOrWhiteSpace(txbMail.Text) && !string.IsNullOrWhiteSpace(txbsdt.Text) && !string.IsNullOrWhiteSpace(txbNgDDPhapLy.Text) && !string.IsNullOrWhiteSpace(txbNgLHMua.Text) && !string.IsNullOrWhiteSpace(txbDCGiao.Text))
            {
                FrmDSKhachHang frm = new FrmDSKhachHang();
                kh.SuaKhachHang(txbMaKH.Text, txbTenKH.Text, txbdchi.Text, txbMail.Text, txbsdt.Text, txbNgDDPhapLy.Text, txbNgLHMua.Text, txbDCGiao.Text);
                frm.dataGridView1.DataSource = kh.GetData();
                this.Close();
            }
            else
                MessageBox.Show("Chọn và nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}