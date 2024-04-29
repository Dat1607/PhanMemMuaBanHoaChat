using BLL_DAL;
using DevExpress.XtraEditors;
using PhanMemBanHoaChat.NhapKho;
using PhanMemBanHoaChat.XuatKho;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemBanHoaChat.Kho
{
    public partial class FrmDSHangHoa : DevExpress.XtraEditors.XtraForm
    {
        BD_HangHoa hh = new BD_HangHoa();
        BD_PhanQuyen pq = new BD_PhanQuyen();
        private string tendn;
        private AutoCompleteStringCollection autoCompleteCollection;
        public FrmDSHangHoa()
        {
            InitializeComponent();
            InitializeUI();
        }
        public FrmDSHangHoa(string tendn)
        {
            InitializeComponent();
            InitializeUI();
            this.tendn = tendn;
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
        private void FrmDSHangHoa_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = hh.GetData();
            int columnIndex1 = dataGridView1.Columns[7].Index;
            dataGridView1.Columns[columnIndex1].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns[0].HeaderText = "Số thứ tự";
            dataGridView1.Columns[1].HeaderText = "Mã hàng hóa";
            dataGridView1.Columns[2].HeaderText = "Tên hàng hóa";
            dataGridView1.Columns[3].HeaderText = "Số lượng";
            dataGridView1.Columns[4].HeaderText = "Đơn vị tính";
            dataGridView1.Columns[5].HeaderText = "Nhà sản xuất";
            dataGridView1.Columns[6].HeaderText = "Xuất xứ";
            dataGridView1.Columns[7].HeaderText = "Đơn Giá";

            if (pq.KiemTraQuyen(tendn, "Quản lý"))
            {
            }
            else if (pq.KiemTraQuyen(tendn, "Nhân viên bán hàng"))
            {
                dataGridView1.Columns[7].Visible = false;
            }
            else if (pq.KiemTraQuyen(tendn, "Nhân viên kho"))
            {
                dataGridView1.Columns[7].Visible = false;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txbtimkiem.Clear();
            txbmahh.Clear();
            dataGridView1.DataSource = hh.GetData();
            int columnIndex1 = dataGridView1.Columns[7].Index;
            dataGridView1.Columns[columnIndex1].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns[0].HeaderText = "Số thứ tự";
            dataGridView1.Columns[1].HeaderText = "Mã hàng hóa";
            dataGridView1.Columns[2].HeaderText = "Tên hàng hóa";
            dataGridView1.Columns[3].HeaderText = "Số lượng";
            dataGridView1.Columns[4].HeaderText = "Đơn vị tính";
            dataGridView1.Columns[5].HeaderText = "Nhà sản xuất";
            dataGridView1.Columns[6].HeaderText = "Xuất xứ";
            dataGridView1.Columns[7].HeaderText = "Đơn Giá";

            if (pq.KiemTraQuyen(tendn, "Quản lý"))
            {
            }
            else if (pq.KiemTraQuyen(tendn, "Nhân viên bán hàng"))
            {
                dataGridView1.Columns[7].Visible = false;
            }
            else if (pq.KiemTraQuyen(tendn, "Nhân viên kho"))
            {
                dataGridView1.Columns[7].Visible = false;
            }
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            FrmTaoHangHoa frm = new FrmTaoHangHoa(tendn);
            frm.btnLuu.Hide();
            frm.Show();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string mahh = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txbmahh.Text = mahh;
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            var timKiem = hh.TimKiemHH(txbtimkiem.Text);
            if (timKiem.Count > 0)
            {
                dataGridView1.DataSource = timKiem;

            }
            else
            {
                MessageBox.Show("Không tìm thấy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            FrmTaoHangHoa frm = new FrmTaoHangHoa(this);
            frm.btnThem.Hide();
            frm.Show();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (!hh.KiemTraCTBaoGia(txbmahh.Text) || !hh.KiemTraCTDDH(txbmahh.Text) || !hh.KiemTraCTHD(txbmahh.Text) || !hh.KiemTraCTPNH(txbmahh.Text) || !hh.KiemTraCTPN(txbmahh.Text) || !hh.KiemTraCTPX(txbmahh.Text) || !hh.KiemTraCTPXH(txbmahh.Text))
            {
                if (!string.IsNullOrWhiteSpace(txbmahh.Text))
                {
                    hh.XoaHANGHOA(txbmahh.Text);
                    dataGridView1.DataSource = hh.GetData();
                    int columnIndex1 = dataGridView1.Columns[7].Index;
                    dataGridView1.Columns[columnIndex1].DefaultCellStyle.Format = "N0";
                    dataGridView1.Columns[0].HeaderText = "Số thứ tự";
                    dataGridView1.Columns[1].HeaderText = "Mã hàng hóa";
                    dataGridView1.Columns[2].HeaderText = "Tên hàng hóa";
                    dataGridView1.Columns[3].HeaderText = "Số lượng";
                    dataGridView1.Columns[4].HeaderText = "Đơn vị tính";
                    dataGridView1.Columns[5].HeaderText = "Nhà sản xuất";
                    dataGridView1.Columns[6].HeaderText = "Xuất xứ";
                    dataGridView1.Columns[7].HeaderText = "Đơn Giá";
                    txbmahh.Clear();
                }
                else
                    MessageBox.Show("Nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Hàng hóa này đang được liên kết . Không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSaoLuu_Click(object sender, EventArgs e)
        {

        }

        private void btnKhoiPhuc_Click(object sender, EventArgs e)
        {

        }

        private void btnSaoLuu_Click_1(object sender, EventArgs e)
        {
            try
            {
                hh.Backup();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sao lưu: " + ex.Message);
            }
        }

        private void btnKhoiPhuc_Click_1(object sender, EventArgs e)
        {
            try
            {
                hh.restore();
                dataGridView1.DataSource = hh.GetData();
                dataGridView1.Columns[0].HeaderText = "Số thứ tự";
                dataGridView1.Columns[1].HeaderText = "Mã hàng hóa";
                dataGridView1.Columns[2].HeaderText = "Tên hàng hóa";
                dataGridView1.Columns[3].HeaderText = "Số lượng";
                dataGridView1.Columns[4].HeaderText = "Đơn vị tính";
                dataGridView1.Columns[5].HeaderText = "Nhà sản xuất";
                dataGridView1.Columns[6].HeaderText = "Xuất xứ";
                dataGridView1.Columns[7].HeaderText = "Đơn Giá";
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi phục hồi dữ liệu: " + ex.Message);
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

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            FrmTaoPhieuNhapKho frm = new FrmTaoPhieuNhapKho(tendn);
            frm.Show();
            frm.cbbtenhh.Text = "Chọn hàng hóa";
            frm.cbbtenhh.ForeColor = Color.Gray;
            frm.txbmahh.Text = "";
            frm.txbdonVT.Text = "";
            frm.lbngayl.Hide();
            frm.btnLuu.Hide();
            frm.btnXuatHoaDon.Hide();
        }

        private void btnXuatKho_Click(object sender, EventArgs e)
        {
            FrmTaoPhieuXuatKho frm = new FrmTaoPhieuXuatKho(tendn);
            frm.Show();
            frm.cbbtenhh.Text = "Chọn hàng hóa";
            frm.cbbtenhh.ForeColor = Color.Gray;
            frm.txbmahh.Text = "";
            frm.txbdonVT.Text = "";
            frm.lbngayl.Hide();
            frm.btnLuu.Hide();
            frm.btnXuatHoaDon.Hide();
        }
    }
}