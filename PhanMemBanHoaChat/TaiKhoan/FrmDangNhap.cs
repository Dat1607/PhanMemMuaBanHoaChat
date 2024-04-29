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
using System.Text.RegularExpressions;
using PhanMemBanHoaChat.ManHinhChinh;

namespace PhanMemBanHoaChat.TaiKhoan
{
    public partial class FrmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        BD_DangNhap dn = new BD_DangNhap();
        private AutoCompleteStringCollection autoCompleteCollection;
        public FrmDangNhap()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
            SetPlaceholder("Nhập tên đăng nhập", txbtenDN);
            SetPlaceholder("Nhập mật khẩu", txbMatKhau);
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
            if (textBox.Text == "Nhập tên đăng nhập" || textBox.Text == "Nhập mật khẩu")
            {
                textBox.Text = "";
                textBox.ForeColor = System.Drawing.Color.Black;
            }
        }
        private void InitializeUI()
        {
            autoCompleteCollection = new AutoCompleteStringCollection();
            txbtenDN.AutoCompleteMode = AutoCompleteMode.Suggest;
            txbtenDN.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txbtenDN.AutoCompleteCustomSource = autoCompleteCollection;
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
                txbtenDN.AutoCompleteCustomSource = autoCompleteCollection;

            }
        }

        private void txbtenDN_KeyPress(object sender, KeyPressEventArgs e)
        {
            string kyTuandSo = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            if (!kyTuandSo.Contains(e.KeyChar.ToString()) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbtenDN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrWhiteSpace(txbtenDN.Text) && !autoCompleteCollection.Contains(txbtenDN.Text))
                {
                    autoCompleteCollection.Add(txbtenDN.Text);
                }
                SaveAutoCompleteData();
                txbtenDN.AutoCompleteCustomSource = autoCompleteCollection;
            }
        }

        private void txbtenDN_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txbtenDN);
        }

        private void txbtenDN_Leave(object sender, EventArgs e)
        {
            if (txbtenDN.Text.Length < 5 || txbtenDN.Text.Length > 50)
            {
                MessageBox.Show("Vui lòng nhập từ 5 đến 50 ký tự");
                txbtenDN.Focus();
            }
            else if (txbtenDN.Text.Contains(" "))
            {
                MessageBox.Show("Vui lòng không nhập khoảng trắng giữa các ký tự");
                txbtenDN.Focus();
            }
            if (!string.IsNullOrWhiteSpace(txbtenDN.Text))
            {
                if (!autoCompleteCollection.Contains(txbtenDN.Text))
                {
                    autoCompleteCollection.Add(txbtenDN.Text);
                }
                SaveAutoCompleteData();
                txbtenDN.AutoCompleteCustomSource = autoCompleteCollection;
            }
            SetPlaceholder("Nhập tên đăng nhập", txbtenDN);
        }

        private void txbMatKhau_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txbMatKhau);
        }

        private void txbMatKhau_Leave(object sender, EventArgs e)
        {
            string dinhDangMK = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^a-zA-Z\\d]).+$";
            if (txbMatKhau.Text.Length < 5 || txbMatKhau.Text.Length > 50)
            {
                MessageBox.Show("Vui lòng nhập từ 5 đến 50 ký tự");
                txbMatKhau.Focus();
            }
            else if (Regex.IsMatch(txbMatKhau.Text, dinhDangMK))
            {
            }
            else
            {
                MessageBox.Show("Mật khẩu không hợp lệ (Ít nhất 1 ký tự hoa, 1 ký tự thường, 1 số, 1 ký tự đặc biệt. Vui lòng thử lại");
                txbMatKhau.Clear();
                txbMatKhau.Focus();
            }
            SetPlaceholder("Nhập mật khẩu", txbMatKhau);
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            bool ktDangNhap = dn.KiemTraDangNhap(txbtenDN.Text, txbMatKhau.Text);
            if (ktDangNhap)
            {
                FrmMain frm = new FrmMain(txbtenDN.Text);
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng", "Lỗi Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txbtenDN_TextChanged(object sender, EventArgs e)
        {
        }
    }
}