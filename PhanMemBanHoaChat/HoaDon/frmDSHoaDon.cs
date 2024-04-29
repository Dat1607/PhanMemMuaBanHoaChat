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

namespace PhanMemBanHoaChat.HoaDon
{
    public partial class frmDSHoaDon : DevExpress.XtraEditors.XtraForm
    {
        BD_HoaDon hd = new BD_HoaDon();
        private string tendn;

        private AutoCompleteStringCollection autoCompleteCollection;
        public frmDSHoaDon()
        {
            InitializeComponent();
            InitializeUI();
            dataGridView1.DataSource = hd.GetDataHD();
            dataGridView1.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            int columnIndex = dataGridView1.Columns[4].Index;
            int columnIndex1 = dataGridView1.Columns[6].Index;
            dataGridView1.Columns[columnIndex].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns[columnIndex1].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns[0].HeaderText = "Mã hóa đơn";
            dataGridView1.Columns[1].HeaderText = "Mã khách hàng";
            dataGridView1.Columns[2].HeaderText = "Tên khách hàng";
            dataGridView1.Columns[3].HeaderText = "Ngày lập";
            dataGridView1.Columns[4].HeaderText = "Tổng thành tiền";
            dataGridView1.Columns[5].HeaderText = "Thuế";
            dataGridView1.Columns[6].HeaderText = "Tổng cộng thanh toán";
            dataGridView1.Columns[7].HeaderText = "Hình thức thanh toán";
            dataGridView1.Columns[8].HeaderText = "Mã nhân viên";
            dataGridView1.Columns[9].HeaderText = "Tên nhân viên";
            dataGridView1.Columns[10].Visible = false;
        }
        public frmDSHoaDon(string tendn)
        {
            InitializeComponent();
            InitializeUI();
            this.tendn = tendn;
            dataGridView1.DataSource = hd.GetDataHD();
            dataGridView1.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            int columnIndex = dataGridView1.Columns[4].Index;
            int columnIndex1 = dataGridView1.Columns[6].Index;
            dataGridView1.Columns[columnIndex].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns[columnIndex1].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns[0].HeaderText = "Mã hóa đơn";
            dataGridView1.Columns[1].HeaderText = "Mã khách hàng";
            dataGridView1.Columns[2].HeaderText = "Tên khách hàng";
            dataGridView1.Columns[3].HeaderText = "Ngày lập";
            dataGridView1.Columns[4].HeaderText = "Tổng thành tiền";
            dataGridView1.Columns[5].HeaderText = "Thuế";
            dataGridView1.Columns[6].HeaderText = "Tổng cộng thanh toán";
            dataGridView1.Columns[7].HeaderText = "Hình thức thanh toán";
            dataGridView1.Columns[8].HeaderText = "Mã nhân viên";
            dataGridView1.Columns[9].HeaderText = "Tên nhân viên";
            dataGridView1.Columns[10].Visible = false;
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
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = hd.GetDataHD();
            dataGridView1.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            int columnIndex = dataGridView1.Columns[4].Index;
            int columnIndex1 = dataGridView1.Columns[6].Index;
            dataGridView1.Columns[columnIndex].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns[columnIndex1].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns[0].HeaderText = "Mã hóa đơn";
            dataGridView1.Columns[1].HeaderText = "Mã khách hàng";
            dataGridView1.Columns[2].HeaderText = "Tên khách hàng";
            dataGridView1.Columns[3].HeaderText = "Ngày lập";
            dataGridView1.Columns[4].HeaderText = "Tổng thành tiền";
            dataGridView1.Columns[5].HeaderText = "Thuế";
            dataGridView1.Columns[6].HeaderText = "Tổng cộng thanh toán";
            dataGridView1.Columns[7].HeaderText = "Hình thức thanh toán";
            dataGridView1.Columns[8].HeaderText = "Mã nhân viên";
            dataGridView1.Columns[9].HeaderText = "Tên nhân viên";
            dataGridView1.Columns[10].Visible = false;
            txbmahd.Clear();
            txbtimkiem.Clear();
            dataGridView1.DataSource = hd.GetDataHD();
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            FrmTaoMoiHoaDon frm = new FrmTaoMoiHoaDon(tendn);
            frm.Show();
            frm.cbbtenkh.Text = "Chọn mã số thuế khách hàng";
            frm.cbbtenkh.ForeColor = Color.Gray;
            frm.txbmastkh.Text = "";
            frm.txbdckh.Text = "";
            frm.cbbtenhh.Text = "Chọn mã hàng hóa";
            frm.cbbtenhh.ForeColor = Color.Gray;
            frm.txbmahh.Text = "";
            frm.txbdonG.Text = "";
            frm.txtvat.Text = "0";
            frm.cbbhinhthuctt.Items.Add("Tiền mặt");
            frm.cbbhinhthuctt.Items.Add("Thẻ ngân hàng");
            frm.cbbhinhthuctt.Text = "Chọn hình thức thanh toán";
            frm.cbbhinhthuctt.ForeColor = Color.Gray;
            frm.dataGridView2.Hide();
            frm.btnLuu.Hide();
            frm.btnXuatHoaDon.Hide();
            frm.btnXuatIn.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string mahd = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txbmahd.Text = mahd;

            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            var timKiem = hd.TimKiemHD(txbtimkiem.Text);
            if (timKiem.Count > 0)
            {
                dataGridView1.DataSource = timKiem;
            }
            else
            {
                MessageBox.Show("Không tìm thấy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maHoaDon = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                LoadCTHD(maHoaDon);
            }
        }
        private void LoadCTHD(string maHoaDon)
        {
            List<CTHD> cthdList = hd.GetDataCTHD(maHoaDon);
            dataGridView2.DataSource = cthdList;
            int columnIndex = dataGridView2.Columns[4].Index;
            int columnIndex1 = dataGridView2.Columns[5].Index;
            dataGridView2.Columns[columnIndex].DefaultCellStyle.Format = "N0";
            dataGridView2.Columns[columnIndex1].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns[0].HeaderText = "Mã hóa đơn";
            dataGridView1.Columns[1].HeaderText = "Mã hàng hóa";
            dataGridView1.Columns[2].HeaderText = "Tên hàng hóa";
            dataGridView1.Columns[3].HeaderText = "Số lượng";
            dataGridView1.Columns[4].HeaderText = "Đơn giá";
            dataGridView1.Columns[5].HeaderText = "Thành tiền";
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string maHoaDon = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                FrmTaoMoiHoaDon frm = new FrmTaoMoiHoaDon(tendn);
                frm.ChonHangFromDataGridView(maHoaDon);
                frm.Show();
                frm.cbbtenhh.Text = "Chọn mã hàng hóa";
                frm.cbbtenhh.ForeColor = Color.Gray;
                frm.txbmahh.Text = "";
                frm.txbdonG.Text = "";
                frm.dataGridView2.Hide();
                frm.btnTao.Hide();
                this.Hide();
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string maHoaDon = txbmahd.Text;
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa hóa đơn và chi tiết hóa đơn có mã {maHoaDon}", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                hd.XoaHDVaCT(maHoaDon);
                dataGridView1.DataSource = hd.GetDataHD();
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

            //dataGridView1.DataSource = hd.LocHoaDonTheoNgay(loaiLoc);
        }

        private void RadioBtn(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void btnSaoLuu_Click(object sender, EventArgs e)
        {
            try
            {
                hd.Backup();
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
                hd.restore();
                dataGridView1.DataSource = hd.GetData();
                dataGridView1.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";
                int columnIndex = dataGridView1.Columns[2].Index;
                int columnIndex1 = dataGridView1.Columns[4].Index;
                dataGridView1.Columns[columnIndex].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns[columnIndex1].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns[0].HeaderText = "Mã hóa đơn";
                dataGridView1.Columns[1].HeaderText = "Ngày lập";
                dataGridView1.Columns[2].HeaderText = "Tổng thành tiền";
                dataGridView1.Columns[3].HeaderText = "Thuế";
                dataGridView1.Columns[4].HeaderText = "Tổng cộng thanh toán";
                dataGridView1.Columns[5].HeaderText = "Hình thức thanh toán";
                dataGridView1.Columns[6].HeaderText = "Mã nhân viên";
                dataGridView1.Columns[7].HeaderText = "Mã khách hàng";
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
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
                dataGridView1.DataSource = hd.LocHoaDonTheoNgay(loaiLoc);
            }
           
        }

        private void frmDSHoaDon_Load(object sender, EventArgs e)
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