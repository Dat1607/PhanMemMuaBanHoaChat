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

namespace PhanMemBanHoaChat.PhanQuyen
{
    public partial class FrmQuyen : DevExpress.XtraEditors.XtraForm
    {
        BD_Quyen q = new BD_Quyen();
        private string tendn;
        public FrmQuyen(string tendn)
        {
            InitializeComponent();
            this.tendn = tendn;
        }

        private void FrmQuyen_Load(object sender, EventArgs e)
        {
            SetPlaceholder("Nhập tên quyền", txbTenQ);
            dataGridView1.DataSource = q.LoadQuyen();
            dataGridView1.Columns[0].HeaderText = "Tên quyền";
            btnXoa.Hide();
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
            if (textBox.Text == "Nhập tên quyền")
            {
                textBox.Text = "";
                textBox.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txbTenQ.Clear();
            btnThem.Show();
            btnXoa.Hide();
        }

        private void txbTenQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbTenQ_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txbTenQ);
        }

        private void txbTenQ_Leave(object sender, EventArgs e)
        {
            if (txbTenQ.Text.Length < 5 || txbTenQ.Text.Length > 30)
            {
                MessageBox.Show("Vui lòng nhập từ 5 đến 30 ký tự");
            }
            else if (txbTenQ.Text.Contains("  "))
            {
                MessageBox.Show("Vui lòng chỉ nhập một khoảng trắng giữa các ký tự");
            }
            SetPlaceholder("Nhập tên quyền", txbTenQ);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string tenq = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txbTenQ.Text = tenq;
            }
            btnThem.Hide();
            btnXoa.Show();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txbTenQ.Text))
            {
                if (!q.KiemTraThemQ(txbTenQ.Text))
                {
                    q.themQ(txbTenQ.Text);
                    dataGridView1.DataSource = q.LoadQuyen();
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                    txbTenQ.Clear();
                }
                else
                {
                    MessageBox.Show("Quyền này đã được thêm", "Thông báo", MessageBoxButtons.OK);
                }

            }
            else
                MessageBox.Show("Nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!q.KiemTraQ(txbTenQ.Text))
            {
                if (!string.IsNullOrWhiteSpace(txbTenQ.Text))
                {
                    q.xoaQ(txbTenQ.Text);
                    dataGridView1.DataSource = q.LoadQuyen();
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                    txbTenQ.Clear();
                }
                else
                    MessageBox.Show("Nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Quyền đang được phân quyền. Không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}