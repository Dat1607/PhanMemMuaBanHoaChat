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

namespace PhanMemBanHoaChat.TaiKhoan
{
    public partial class FrmTaoTaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        BD_TaoTaiKhoan ttk = new BD_TaoTaiKhoan();
        private string tendn;
        public FrmTaoTaiKhoan(string tendn)
        {
            InitializeComponent();
            this.tendn = tendn;
        }

        private void FrmTaoTaiKhoan_Load(object sender, EventArgs e)
        {
            SetPlaceholder("Nhập tên đăng nhập", txbTenDK);
            SetPlaceholder("Nhập mật khẩu", txbMKDK);
            SetPlaceholder("Nhập mật khẩu", txbXNMK);
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
            if (textBox.Text == "Nhập tên đăng nhập" || textBox.Text == "Nhập mật khẩu" || textBox.Text == "Nhập xác nhận mật khẩu")
            {
                textBox.Text = "";
                textBox.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txbTenDK.Clear();
            txbTenDK.Focus();
            txbMKDK.Clear();
            txbXNMK.Clear();
        }

        private void txbTenDK_KeyPress(object sender, KeyPressEventArgs e)
        {
            string kyTuandSo = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            if (!kyTuandSo.Contains(e.KeyChar.ToString()) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbTenDK_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txbTenDK);
        }

        private void txbTenDK_Leave(object sender, EventArgs e)
        {
            if (txbTenDK.Text.Length < 5 || txbTenDK.Text.Length > 50)
            {
                MessageBox.Show("Vui lòng nhập từ 5 đến 50 ký tự");
                txbTenDK.Focus();
            }
            else if (txbTenDK.Text.Contains(" "))
            {
                MessageBox.Show("Vui lòng không nhập khoảng trắng giữa các ký tự");
                txbTenDK.Focus();
            }
            SetPlaceholder("Nhập tên đăng nhập", txbTenDK);
        }

        private void txbMKDK_Leave(object sender, EventArgs e)
        {
            string dinhDangMK = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^a-zA-Z\\d]).+$";
            if (txbMKDK.Text.Length < 5 || txbMKDK.Text.Length > 50)
            {
                MessageBox.Show("Vui lòng nhập từ 5 đến 50 ký tự");
                txbMKDK.Focus();
            }
            else if (Regex.IsMatch(txbMKDK.Text, dinhDangMK))
            {
            }
            else
            {
                MessageBox.Show("Mật khẩu không hợp lệ (Ít nhất 1 ký tự hoa, 1 ký tự thường, 1 số, 1 ký tự đặc biệt. Vui lòng thử lại");
                txbMKDK.Clear();
                txbMKDK.Focus();
            }
            SetPlaceholder("Nhập mật khẩu", txbMKDK);
        }

        private void txbXNMK_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txbXNMK);
        }

        private void txbXNMK_Leave(object sender, EventArgs e)
        {
            SetPlaceholder("Nhập mật khẩu", txbXNMK);
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (!ttk.KiemTraTrungTenDK(txbTenDK.Text))
            {
                MessageBox.Show("Tên đăng ký đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbTenDK.Focus();
                return;
            }
            if (txbMKDK.Text != txbXNMK.Text)
            {
                MessageBox.Show("Xác nhận mật khẩu không chính xác", "Vui lòng thử lại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbXNMK.Focus();
            }
            else
            {
                ttk.TaoTk(txbTenDK.Text, txbMKDK.Text);
                MessageBox.Show("Tài khoản đã được tạo thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbTenDK.Clear();
                txbMKDK.Clear();
                txbXNMK.Clear();
            }
        }

        private void txbMKDK_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txbMKDK);
        }
    }
}