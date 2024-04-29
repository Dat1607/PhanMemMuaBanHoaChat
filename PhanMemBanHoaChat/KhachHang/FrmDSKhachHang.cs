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
using PhanMemBanHoaChat.ManHinhChinh;
using static System.Net.Mime.MediaTypeNames;

namespace PhanMemBanHoaChat.KhachHang
{
    public partial class FrmDSKhachHang : DevExpress.XtraEditors.XtraForm
    {
        BD_KhachHang kh = new BD_KhachHang();
        private string tendn;
        private string quyen;
        private AutoCompleteStringCollection autoCompleteCollection;
        public FrmDSKhachHang()
        {
            InitializeComponent();
            InitializeUI();
        }
        public FrmDSKhachHang(string tendn, string quyen)
        {
            InitializeComponent();
            InitializeUI();
            this.tendn = tendn;
            this.quyen = quyen;
        }
        private void InitializeUI()
        {
            autoCompleteCollection = new AutoCompleteStringCollection();
            //txbtimkiem
            txbtimkiem.AutoCompleteMode = AutoCompleteMode.Suggest;
            txbtimkiem.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txbtimkiem.AutoCompleteCustomSource = autoCompleteCollection;
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
                txbtimkiem.AutoCompleteCustomSource = autoCompleteCollection;

            }
        }
        private void FrmDSKhachHang_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = kh.LayDanhSachKhachHang(tendn, quyen);
            dataGridView1.Columns[0].HeaderText = "Mã nhân viên";
            dataGridView1.Columns[1].HeaderText = "Nhân viên quản lý";
            dataGridView1.Columns[2].HeaderText = "Mã khách hàng";
            dataGridView1.Columns[3].HeaderText = "Tên khách hàng";
            dataGridView1.Columns[4].HeaderText = "Địa chỉ";
            dataGridView1.Columns[5].HeaderText = "Mail";
            dataGridView1.Columns[6].HeaderText = "Số điện thoại";
            dataGridView1.Columns[7].HeaderText = "Người đại diện pháp lý";
            dataGridView1.Columns[8].HeaderText = "Người liên hệ mua hàng";
            dataGridView1.Columns[9].HeaderText = "Địa chỉ giao";
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txbtimkiem.Clear();
            txbmakh.Clear();
            dataGridView1.DataSource = kh.LayDanhSachKhachHang(tendn, quyen);
            dataGridView1.Columns[0].HeaderText = "Mã nhân viên";
            dataGridView1.Columns[1].HeaderText = "Nhân viên quản lý";
            dataGridView1.Columns[2].HeaderText = "Mã khách hàng";
            dataGridView1.Columns[3].HeaderText = "Tên khách hàng";
            dataGridView1.Columns[4].HeaderText = "Địa chỉ";
            dataGridView1.Columns[5].HeaderText = "Mail";
            dataGridView1.Columns[6].HeaderText = "Số điện thoại";
            dataGridView1.Columns[7].HeaderText = "Người đại diện pháp lý";
            dataGridView1.Columns[8].HeaderText = "Người liên hệ mua hàng";
            dataGridView1.Columns[9].HeaderText = "Địa chỉ giao";
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            FrmTaoKhachHang frm = new FrmTaoKhachHang(tendn);
            frm.btnLuu.Hide();
            frm.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string makh = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txbmakh.Text = makh;
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            var timKiem = kh.TimKiemKH(txbtimkiem.Text);
            if (timKiem.Count > 0)
            {
                dataGridView1.DataSource = timKiem;
               
                dataGridView1.Columns[0].HeaderText = "Mã khách hàng";
                dataGridView1.Columns[1].HeaderText = "Tên khách hàng";
                dataGridView1.Columns[2].HeaderText = "Địa chỉ";
                dataGridView1.Columns[3].HeaderText = "Mail";
                dataGridView1.Columns[4].HeaderText = "Số điện thoại";
                dataGridView1.Columns[5].HeaderText = "Người đại diện pháp lý";
                dataGridView1.Columns[6].HeaderText = "Người liên hệ mua hàng";
                dataGridView1.Columns[7].HeaderText = "Địa chỉ giao";
                dataGridView1.Columns[8].HeaderText = "Mã nhân viên";
                dataGridView1.Columns[9].Visible = false;
            }
            else
            {
                MessageBox.Show("Không tìm thấy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            FrmTaoKhachHang frm = new FrmTaoKhachHang(this);
            frm.btnThem.Hide();
            frm.Show();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (!kh.KiemTraPXH(txbmakh.Text) || !kh.KiemTraBG(txbmakh.Text) || !kh.KiemTraHD(txbmakh.Text))
            {
                if (!string.IsNullOrWhiteSpace(txbmakh.Text))
                {
                    kh.Xoakhachhang(txbmakh.Text);
                    dataGridView1.DataSource = kh.LayDanhSachKhachHang(tendn, quyen);
                    dataGridView1.Columns[0].HeaderText = "Mã nhân viên";
                    dataGridView1.Columns[1].HeaderText = "Nhân viên quản lý";
                    dataGridView1.Columns[2].HeaderText = "Mã khách hàng";
                    dataGridView1.Columns[3].HeaderText = "Tên khách hàng";
                    dataGridView1.Columns[4].HeaderText = "Địa chỉ";
                    dataGridView1.Columns[5].HeaderText = "Mail";
                    dataGridView1.Columns[6].HeaderText = "Số điện thoại";
                    dataGridView1.Columns[7].HeaderText = "Người đại diện pháp lý";
                    dataGridView1.Columns[8].HeaderText = "Người liên hệ mua hàng";
                    dataGridView1.Columns[9].HeaderText = "Địa chỉ giao";

                    txbmakh.Clear();
                }
                else
                    MessageBox.Show("Nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Khách hàng đang được liên kết . Không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            
        }

        private void btnSaoLuu_Click(object sender, EventArgs e)
        {
            try
            {
                kh.Backup();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sao lưu: " + ex.Message);
            }
        }

        private void btnKhoiPhuc_Click(object sender, EventArgs e)
        {
            try
            {
                kh.restore();
                dataGridView1.DataSource = kh.GetData();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi phục hồi dữ liệu: " + ex.Message);
            }
        }

        private void txbtimkiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrWhiteSpace(txbtimkiem.Text) && !autoCompleteCollection.Contains(txbtimkiem.Text))
                {
                    autoCompleteCollection.Add(txbtimkiem.Text);
                }
                SaveAutoCompleteData();
                txbtimkiem.AutoCompleteCustomSource = autoCompleteCollection;
            }
        }

        private void txbtimkiem_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txbtimkiem.Text))
            {
                if (!autoCompleteCollection.Contains(txbtimkiem.Text))
                {
                    autoCompleteCollection.Add(txbtimkiem.Text);
                }
                SaveAutoCompleteData();
                txbtimkiem.AutoCompleteCustomSource = autoCompleteCollection;
            }
        }
    }
}