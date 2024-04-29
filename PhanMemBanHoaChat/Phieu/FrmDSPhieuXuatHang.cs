using BLL_DAL;
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

namespace PhanMemBanHoaChat.Phieu
{
    public partial class FrmDSPhieuXuatHang : DevExpress.XtraEditors.XtraForm
    {
        BD_PhieuXuatHang pxh = new BD_PhieuXuatHang();
        private string tendn;
        private AutoCompleteStringCollection autoCompleteCollection;
        public FrmDSPhieuXuatHang()
        {
            InitializeComponent();
            InitializeUI();
        }
        public FrmDSPhieuXuatHang(string tendn)
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
        private void FrmDSPhieuXuatHang_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = pxh.GetDataPXH();
            dataGridView1.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
            int columnIndex = dataGridView1.Columns[5].Index;
            int columnIndex1 = dataGridView1.Columns[7].Index;
            dataGridView1.Columns[columnIndex].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns[columnIndex1].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns[0].HeaderText = "Mã phiếu xuất hàng";
            dataGridView1.Columns[1].HeaderText = "Mã khách hàng";
            dataGridView1.Columns[2].HeaderText = "Tên khách hàng";
            dataGridView1.Columns[3].HeaderText = "Ngày lập";
            dataGridView1.Columns[4].HeaderText = "Ngày giao";
            dataGridView1.Columns[5].HeaderText = "Tổng thành tiền";
            dataGridView1.Columns[6].HeaderText = "Thuế";
            dataGridView1.Columns[7].HeaderText = "Tổng cộng thanh toán";
            dataGridView1.Columns[8].HeaderText = "Tình trạng xuất hàng";
            dataGridView1.Columns[9].HeaderText = "Ghi chú";
            dataGridView1.Columns[10].HeaderText = "Mã nhân viên";
            dataGridView1.Columns[11].HeaderText = "Tên nhân viên";
            dataGridView1.Columns[12].HeaderText = "Địa chỉ giao";
            comboBox1.Text = "Chọn thời gian lọc";
            comboBox1.ForeColor = Color.Gray;
            comboBox1.Items.Add("Ngay");
            comboBox1.Items.Add("Tuan");
            comboBox1.Items.Add("Thang");
            comboBox1.Items.Add("Quy1");
            comboBox1.Items.Add("Quy2");
            comboBox1.Items.Add("Quy3");
            comboBox1.Items.Add("Quy4");
            comboBox1.Items.Add("NuaNam1");
            comboBox1.Items.Add("NuaNam2");
            comboBox1.Items.Add("CaNam");
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txbmapxh.Clear();
            txbtimkiem.Clear();
            dataGridView1.DataSource = pxh.GetDataPXH();
            dataGridView1.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
            int columnIndex = dataGridView1.Columns[5].Index;
            int columnIndex1 = dataGridView1.Columns[7].Index;
            dataGridView1.Columns[columnIndex].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns[columnIndex1].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns[0].HeaderText = "Mã phiếu xuất hàng";
            dataGridView1.Columns[1].HeaderText = "Mã khách hàng";
            dataGridView1.Columns[2].HeaderText = "Tên khách hàng";
            dataGridView1.Columns[3].HeaderText = "Ngày lập";
            dataGridView1.Columns[4].HeaderText = "Ngày giao";
            dataGridView1.Columns[5].HeaderText = "Tổng thành tiền";
            dataGridView1.Columns[6].HeaderText = "Thuế";
            dataGridView1.Columns[7].HeaderText = "Tổng cộng thanh toán";
            dataGridView1.Columns[8].HeaderText = "Tình trạng xuất hàng";
            dataGridView1.Columns[9].HeaderText = "Ghi chú";
            dataGridView1.Columns[10].HeaderText = "Mã nhân viên";
            dataGridView1.Columns[11].HeaderText = "Tên nhân viên";
            dataGridView1.Columns[12].HeaderText = "Địa chỉ giao";
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            FrmTaoPhieuXuatHang frm = new FrmTaoPhieuXuatHang(tendn);
            frm.Show();
            frm.cbbtenkh.Text = "Chọn khách hàng";
            frm.cbbtenkh.ForeColor = Color.Gray;
            frm.txbmakh.Text = "";
            frm.txbdcgkh.Text = "";
            frm.txbvat.Text = "0";
            frm.cbbtenhh.Text = "Chọn hàng hóa";
            frm.cbbtenhh.ForeColor = Color.Gray;
            frm.txbmahh.Text = "";
            frm.txbdvt.Text = "";
            frm.lbngayl.Hide();
            frm.lbhienngayl.Hide();
            frm.btnLuu.Hide();
            frm.btnXuatHoaDon.Hide();
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            var timKiem = pxh.TimKiemPXH(txbtimkiem.Text);
            if (timKiem.Count > 0)
            {
                dataGridView1.DataSource = timKiem;
            }
            else
            {
                MessageBox.Show("Không tìm thấy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string mapxh = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txbmapxh.Text = mapxh;

            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maPXH = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                LoadCTPXH(maPXH);
            }
        }
        private void LoadCTPXH(string maPXH)
        {
            List<CTPXH> ctpxhList = pxh.GetDataCTPXH(maPXH);
            dataGridView2.DataSource = ctpxhList;
            int columnIndex = dataGridView2.Columns[6].Index;
            dataGridView2.Columns[columnIndex].DefaultCellStyle.Format = "N0";
            int columnIndex1 = dataGridView2.Columns[7].Index;
            dataGridView2.Columns[columnIndex1].DefaultCellStyle.Format = "N0";
            dataGridView2.Columns[0].HeaderText = "Mã phiếu xuất hàng";
            dataGridView2.Columns[1].HeaderText = "Mã hàng hóa";
            dataGridView2.Columns[2].HeaderText = "Tên hàng hóa";
            dataGridView2.Columns[3].HeaderText = "Đơn vị tính";
            dataGridView2.Columns[4].HeaderText = "Số lượng";
            dataGridView2.Columns[5].HeaderText = "Quy cách";
            dataGridView2.Columns[6].HeaderText = "Đơn giá";
            dataGridView2.Columns[7].HeaderText = "Thành tiền";
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string maPXH = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                FrmTaoPhieuXuatHang frm = new FrmTaoPhieuXuatHang();
                frm.ChonHangFromDataGridView(maPXH);
                frm.Show();
                frm.cbbtenhh.Text = "Chọn hàng hóa";
                frm.cbbtenhh.ForeColor = Color.Gray;
                frm.txbmahh.Text = "";
                frm.txbdvt.Text = "";
                frm.lbngayl.Show();
                frm.lbhienngayl.Show();
                frm.btnTao.Hide();
                this.Hide();
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string maPhieuXuatHang = txbmapxh.Text;
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa phiếu xuất hàng và chi tiết phiếu xuất hàng có mã {maPhieuXuatHang}", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                pxh.XoaPXHVaCT(maPhieuXuatHang);
                dataGridView1.DataSource = pxh.GetDataPXH();
            }
        }

        private void btnSaoLuu_Click(object sender, EventArgs e)
        {
            try
            {
                pxh.Backup();
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
                pxh.restore();
                dataGridView1.DataSource = pxh.GetDataPXH();
                dataGridView1.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridView1.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
                int columnIndex = dataGridView1.Columns[5].Index;
                int columnIndex1 = dataGridView1.Columns[7].Index;
                dataGridView1.Columns[columnIndex].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns[columnIndex1].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns[0].HeaderText = "Mã phiếu xuất hàng";
                dataGridView1.Columns[1].HeaderText = "Mã khách hàng";
                dataGridView1.Columns[2].HeaderText = "Tên khách hàng";
                dataGridView1.Columns[3].HeaderText = "Ngày lập";
                dataGridView1.Columns[4].HeaderText = "Ngày giao";
                dataGridView1.Columns[5].HeaderText = "Tổng thành tiền";
                dataGridView1.Columns[6].HeaderText = "Thuế";
                dataGridView1.Columns[7].HeaderText = "Tổng cộng thanh toán";
                dataGridView1.Columns[8].HeaderText = "Tình trạng xuất hàng";
                dataGridView1.Columns[9].HeaderText = "Ghi chú";
                dataGridView1.Columns[10].HeaderText = "Mã nhân viên";
                dataGridView1.Columns[11].HeaderText = "Tên nhân viên";
                dataGridView1.Columns[12].HeaderText = "Địa chỉ giao";
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi phục hồi dữ liệu: " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Chọn thời gian lọc" && comboBox1.SelectedIndex == 0)
            {
                comboBox1.ForeColor = Color.Gray;
            }
            else
            {
                string loaiLoc = comboBox1.SelectedItem.ToString();
                dataGridView1.DataSource = pxh.LocPhieuXuatHangTheoNgay(loaiLoc);
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Chọn thời gian lọc")
            {
                comboBox1.Text = "";
            }
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                comboBox1.Text = "Chọn thời gian lọc";
                comboBox1.ForeColor = Color.Gray;
            }
            else
            {
                comboBox1.ForeColor = Color.Black;
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
    }
}