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

namespace PhanMemBanHoaChat.DatHang
{
    public partial class FrmDSDatHang : DevExpress.XtraEditors.XtraForm
    {
        BD_DonDatHang ddh = new BD_DonDatHang();
        private string tendn;
        private AutoCompleteStringCollection autoCompleteCollection;
        public FrmDSDatHang()
        {
            InitializeComponent();
            InitializeUI();
            dataGridView1.DataSource = ddh.GetDataDDH();
            int columnIndex = dataGridView1.Columns[2].Index;
            dataGridView1.Columns[columnIndex].DefaultCellStyle.Format = "N0";
        }
        private void InitializeUI()
        {
            autoCompleteCollection = new AutoCompleteStringCollection();
            //txbtimkiem
            txbtimkiem.AutoCompleteMode = AutoCompleteMode.Suggest;
            txbtimkiem.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txbtimkiem.AutoCompleteCustomSource = autoCompleteCollection;
        }
        public FrmDSDatHang(string tendn)
        {
            InitializeComponent();
            InitializeUI();
            this.tendn = tendn;
            dataGridView1.DataSource = ddh.GetDataDDH();
            dataGridView1.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            int columnIndex = dataGridView1.Columns[4].Index;
            dataGridView1.Columns[columnIndex].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns[0].HeaderText = "Mã đơn đặt hàng";
            dataGridView1.Columns[1].HeaderText = "Mã nhà cung cấp";
            dataGridView1.Columns[2].HeaderText = "Tên nhà cung cấp";
            dataGridView1.Columns[3].HeaderText = "Tổng số lượng";
            dataGridView1.Columns[4].HeaderText = "Tổng thành tiền";
            dataGridView1.Columns[5].HeaderText = "Ngày đặt";
            dataGridView1.Columns[6].HeaderText = "Tình trạng đơn đặt hàng";
            dataGridView1.Columns[7].Visible = false;
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
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ddh.GetDataDDH();
            dataGridView1.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            int columnIndex = dataGridView1.Columns[4].Index;
            dataGridView1.Columns[columnIndex].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns[0].HeaderText = "Mã đơn đặt hàng";
            dataGridView1.Columns[1].HeaderText = "Mã nhà cung cấp";
            dataGridView1.Columns[2].HeaderText = "Tên nhà cung cấp";
            dataGridView1.Columns[3].HeaderText = "Tổng số lượng";
            dataGridView1.Columns[4].HeaderText = "Tổng thành tiền";
            dataGridView1.Columns[5].HeaderText = "Ngày đặt";
            dataGridView1.Columns[6].HeaderText = "Tình trạng đơn đặt hàng";
            dataGridView1.Columns[7].Visible = false;
            txbmaddh.Clear();
            txbtimkiem.Clear();
            //rdbhomnay.Checked = false;
            //rdb7ngay.Checked = false;
            //rdbthangnay.Checked = false;
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            var timKiem = ddh.TimKiemDDH(txbtimkiem.Text);
            if (timKiem.Count > 0)
            {
                dataGridView1.DataSource = timKiem;
            }
            else
            {
                MessageBox.Show("Không tìm thấy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void LoadCTDDH(string maDDHang)
        {
            List<CTDDH> ctddhList = ddh.GetDataCTDDH(maDDHang);
            dataGridView2.DataSource = ctddhList;
            int columnIndex = dataGridView2.Columns[4].Index;
            int columnIndex1 = dataGridView2.Columns[5].Index;
            dataGridView2.Columns[columnIndex].DefaultCellStyle.Format = "N0";
            dataGridView2.Columns[columnIndex1].DefaultCellStyle.Format = "N0";
            dataGridView2.Columns[0].HeaderText = "Mã đơn đặt hàng";
            dataGridView2.Columns[1].HeaderText = "Mã hàng hóa";
            dataGridView2.Columns[2].HeaderText = "Tên hàng hóa";
            dataGridView2.Columns[3].HeaderText = "Số lượng";
            dataGridView2.Columns[4].HeaderText = "Đơn giá";
            dataGridView2.Columns[5].HeaderText = "Thành tiền";
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string maDonDHang = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                FrmDatHang frm = new FrmDatHang(/*maHoaDon*/);
                frm.ChonHangFromDataGridView(maDonDHang);
                frm.Show();
                //frm.txbmast.ReadOnly = true;
                //frm.txbdckh.ReadOnly = true;
                frm.cbbtenhh.Text = "Chọn mã hàng hóa";
                frm.cbbtenhh.ForeColor = Color.Gray;
                frm.txbmahh.Text = "";
                frm.txbdonG.Text = "";
                frm.dataGridView1.Hide();
                //frm.btnchonhang.Hide();
                frm.btnthem.Hide();
                frm.btnUpdate.Hide();
                frm.btnXoa.Hide();
                frm.btnTao.Hide();
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string maDDH = txbmaddh.Text;
            bool xoaThanhCong = ddh.XoaDDHVaCT(maDDH);

            if (xoaThanhCong)
            {
                MessageBox.Show($"Đã xóa đơn đặt hàng và chi tiết phiếu nhập có mã {maDDH}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = ddh.GetDataDDH();
            }
            else
            {
                MessageBox.Show($"Do tình trạng đơn hàng không phải là 'Hủy' nên không thể xóa đơn đặt hàng với mã {maDDH}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnxacnhan_Click(object sender, EventArgs e)
        {
            string ttddh = "Đơn đặt hàng được xác nhận";
            DialogResult result = MessageBox.Show("Xác nhận yêu cầu đơn đặt hàng", "Xác nhận đơn đặt hàng", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                ddh.CapNhatTTDon(txbmaddh.Text);
                dataGridView1.DataSource = ddh.GetDataDDH();
                dataGridView1.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                int columnIndex = dataGridView1.Columns[4].Index;
                dataGridView1.Columns[columnIndex].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns[0].HeaderText = "Mã đơn đặt hàng";
                dataGridView1.Columns[1].HeaderText = "Mã nhà cung cấp";
                dataGridView1.Columns[2].HeaderText = "Tên nhà cung cấp";
                dataGridView1.Columns[3].HeaderText = "Tổng số lượng";
                dataGridView1.Columns[4].HeaderText = "Tổng thành tiền";
                dataGridView1.Columns[5].HeaderText = "Ngày đặt";
                dataGridView1.Columns[6].HeaderText = "Tình trạng đơn đặt hàng";
                dataGridView1.Columns[7].Visible = false;

            }
        }
        private void UpdateDataGridView()
        {
            //string loaiLoc = "";

            //if (rdbhomnay.Checked)
            //{
            //    loaiLoc = "Ngay";
            //}
            //else if (rdb7ngay.Checked)
            //{
            //    loaiLoc = "Tuan";
            //}
            //else if (rdbthangnay.Checked)
            //{
            //    loaiLoc = "Thang";
            //}

            //dataGridView1.DataSource = ddh.LocDonDatHangTheoNgay(loaiLoc);
        }

        private void radioBtn(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string mahd = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txbmaddh.Text = mahd;

            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maDDHang = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                LoadCTDDH(maDDHang);
            }
        }

        private void btnSaoLuu_Click(object sender, EventArgs e)
        {
            try
            {
                ddh.Backup();
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
                ddh.Restore();
                dataGridView1.DataSource = ddh.GetDataDDH();
                dataGridView1.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                int columnIndex = dataGridView1.Columns[4].Index;
                dataGridView1.Columns[columnIndex].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns[0].HeaderText = "Mã đơn đặt hàng";
                dataGridView1.Columns[1].HeaderText = "Mã nhà cung cấp";
                dataGridView1.Columns[2].HeaderText = "Tên nhà cung cấp";
                dataGridView1.Columns[3].HeaderText = "Tổng số lượng";
                dataGridView1.Columns[4].HeaderText = "Tổng thành tiền";
                dataGridView1.Columns[5].HeaderText = "Ngày đặt";
                dataGridView1.Columns[6].HeaderText = "Tình trạng đơn đặt hàng";
                dataGridView1.Columns[7].Visible = false;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi phục hồi dữ liệu: " + ex.Message);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Xác nhận yêu cầu đơn đặt hàng", "Xác nhận đơn đặt hàng", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                if (ddh.CapNhatHuyTTDon(txbmaddh.Text))
                {
                    MessageBox.Show("Đơn đặt hàng đã được hủy thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không thể hủy đơn đặt hàng sau 2 tiếng kể từ thời điểm đặt.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                dataGridView1.DataSource = ddh.GetDataDDH();
                dataGridView1.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                dataGridView1.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                int columnIndex = dataGridView1.Columns[4].Index;
                dataGridView1.Columns[columnIndex].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns[0].HeaderText = "Mã đơn đặt hàng";
                dataGridView1.Columns[1].HeaderText = "Mã nhà cung cấp";
                dataGridView1.Columns[2].HeaderText = "Tên nhà cung cấp";
                dataGridView1.Columns[3].HeaderText = "Tổng số lượng";
                dataGridView1.Columns[4].HeaderText = "Tổng thành tiền";
                dataGridView1.Columns[5].HeaderText = "Ngày đặt";
                dataGridView1.Columns[6].HeaderText = "Tình trạng đơn đặt hàng";
                dataGridView1.Columns[7].Visible = false;
            }
        }

        private void FrmDSDatHang_Load(object sender, EventArgs e)
        {
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Chọn thời gian lọc" && comboBox1.SelectedIndex == 0)
            {
                comboBox1.ForeColor = Color.Gray;
            }
            else
            {
                string loaiLoc = comboBox1.SelectedItem.ToString();
                dataGridView1.DataSource = ddh.LocDonDatHangTheoNgay(loaiLoc);
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