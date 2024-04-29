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
    public partial class FrmPhanQuyen : DevExpress.XtraEditors.XtraForm
    {
        BD_PhanQuyen pq = new BD_PhanQuyen();
        BD_Quyen q = new BD_Quyen();
        private string tendn;
        public FrmPhanQuyen(string tendn)
        {
            InitializeComponent();
            this.tendn = tendn;
            LoadData();
        }

        private void FrmPhanQuyen_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = pq.LoadTaiKhoan();
            dataGridView1.Columns[0].HeaderText = "Tên đăng nhập";
            dataGridView1.Columns[1].HeaderText = "Mật khẩu";
            dataGridView2.DataSource = pq.LoadQuyenTK();
            dataGridView2.Columns[0].HeaderText = "Tên đăng nhập";
            dataGridView2.Columns[1].HeaderText = "Tên quyền";
            cbbquyen.Text = "Chọn quyền";
            cbbquyen.ForeColor = Color.Gray;
            btnSua.Hide();
            btnXoa.Hide();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txbtenDN.Clear();
            cbbquyen.Text = "Chọn quyền";
            cbbquyen.ForeColor = Color.Gray;
            btnThem.Show();
            btnSua.Hide();
            btnXoa.Hide();
        }
        private void LoadData()
        {
            var qs = q.LoadQuyen();

            foreach (var q in qs)
            {
                cbbquyen.Items.Add(q.TenQuyen);
            }

            cbbquyen.SelectedIndex = 0;
        }

        private void cbbquyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbquyen.Text == "Chọn quyền" && cbbquyen.SelectedIndex == 0)
            {
                cbbquyen.ForeColor = Color.Gray;
            }
            else
            {
                cbbquyen.ForeColor = Color.Black;
            }
        }

        private void cbbquyen_DropDown(object sender, EventArgs e)
        {
            if (cbbquyen.Text == "Chọn quyền")
            {
                cbbquyen.Text = "";
            }
        }

        private void cbbquyen_DropDownClosed(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbbquyen.Text))
            {
                cbbquyen.Text = "Chọn quyền";
                cbbquyen.ForeColor = Color.Gray;
            }
            else
            {
                cbbquyen.ForeColor = Color.Black;
            }
        }

        private void dataGridView1_CellBorderStyleChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string tendn = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txbtenDN.Text = tendn;
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string tendn = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                string tenquyen = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                txbtenDN.Text = tendn;
                cbbquyen.Text = tenquyen;
            }
            btnThem.Hide();
            btnXoa.Show();
            btnSua.Show();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txbtenDN.Text) && cbbquyen.SelectedItem != null)
            {
                if (!pq.KiemTraXetQuyen(txbtenDN.Text))
                {
                    MessageBox.Show("Đã được xét quyền", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    pq.themPQ(txbtenDN.Text, cbbquyen.Text);
                    dataGridView2.DataSource = pq.LoadQuyenTK();
                    txbtenDN.Clear();
                    cbbquyen.Text = "Chọn quyền";
                    cbbquyen.ForeColor = Color.Gray;
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
                MessageBox.Show("Nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            pq.suaPQ(txbtenDN.Text, cbbquyen.Text);
            dataGridView2.DataSource = pq.LoadQuyenTK();
            MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            pq.xoaPQ(txbtenDN.Text);
            dataGridView2.DataSource = pq.LoadQuyenTK();
            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
        }
    }
}