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
    public partial class FrmDSPhieuTT : DevExpress.XtraEditors.XtraForm
    {
        BD_PhieuThanhToan ptt = new BD_PhieuThanhToan();
        private string tendn;
        private AutoCompleteStringCollection autoCompleteCollection;
        public FrmDSPhieuTT()
        {
            InitializeComponent();
            InitializeUI();
            dataGridView1.DataSource = ptt.GetDataPTT();
            int columnIndex = dataGridView1.Columns[4].Index;
            dataGridView1.Columns[columnIndex].DefaultCellStyle.Format = "N0";
        }
        public FrmDSPhieuTT(string tendn)
        {
            InitializeComponent();
            InitializeUI();
            this.tendn = tendn;
            dataGridView1.DataSource = ptt.GetDataPTT();
            int columnIndex = dataGridView1.Columns[4].Index;
            dataGridView1.Columns[columnIndex].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            dataGridView1.Columns[0].HeaderText = "Mã phiếu thanh toán";
            dataGridView1.Columns[1].HeaderText = "Mã khách hàng";
            dataGridView1.Columns[2].HeaderText = "Tên khách hàng";
            dataGridView1.Columns[3].HeaderText = "Ngày lập";
            dataGridView1.Columns[4].HeaderText = "Thanh toán";
            dataGridView1.Columns[5].HeaderText = "Mã nhân viên";
            
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
            txbmaptt.Clear();
            txbtimkiem.Clear();
            dataGridView1.DataSource = ptt.GetDataPTT();
            int columnIndex = dataGridView1.Columns[4].Index;
            dataGridView1.Columns[columnIndex].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            dataGridView1.Columns[0].HeaderText = "Mã phiếu thanh toán";
            dataGridView1.Columns[1].HeaderText = "Mã khách hàng";
            dataGridView1.Columns[2].HeaderText = "Tên khách hàng";
            dataGridView1.Columns[3].HeaderText = "Ngày lập";
            dataGridView1.Columns[4].HeaderText = "Thanh toán";
            dataGridView1.Columns[5].HeaderText = "Mã nhân viên";
        }

        private void btnThemThanhToan_Click(object sender, EventArgs e)
        {
            FrmTaoMoiPhieuTT frm = new FrmTaoMoiPhieuTT(tendn);
            frm.Show();
            frm.cbbmahd.Text = "Chọn mã hóa đơn";
            frm.cbbmahd.ForeColor = Color.Gray;
            frm.txbmastkh.Text = "";
            frm.txbtenkh.Text = "";
            frm.txbdckh.Text = "";
            frm.txbtongtienthanhtoan.Text = "";
            frm.btnLuu.Hide();
            frm.btnXuatHoaDon.Hide();
            frm.btnXuatIn.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maptt = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txbmaptt.Text = maptt;

            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maPTT = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                LoadCTHD(maPTT);
            }
        }
        private void LoadCTHD(string maPTT)
        {
            List<CTPTT> ctpttList = ptt.GetDataCTPTT(maPTT);
            dataGridView2.DataSource = ctpttList;
            int columnIndex = dataGridView2.Columns[2].Index;
            dataGridView2.Columns[columnIndex].DefaultCellStyle.Format = "N0";
            dataGridView2.Columns[0].HeaderText = "Mã phiếu thanh toán";
            dataGridView2.Columns[1].HeaderText = "Mã hóa đơn";
            dataGridView2.Columns[2].HeaderText = "Tổng cộng thanh toán";
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string maPTT = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                FrmTaoMoiPhieuTT frm = new FrmTaoMoiPhieuTT(tendn);
                frm.ChonHangFromDataGridView(maPTT);
                frm.Show();
                frm.btnTao.Hide();
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            var timKiem = ptt.TimKiemPTT(txbtimkiem.Text);
            if (timKiem.Count > 0)
            {
                dataGridView1.DataSource = timKiem;
            }
            else
            {
                MessageBox.Show("Không tìm thấy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string maPhieuThanhToan = txbmaptt.Text;
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa phiếu xuất và chi tiết phiếu xuất có mã {maPhieuThanhToan}", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ptt.XoaPTTVaCT(maPhieuThanhToan);
                dataGridView1.DataSource = ptt.GetDataPTT();
            }
        }

        private void btnSaoLuu_Click(object sender, EventArgs e)
        {
            try
            {
                ptt.backup();
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
                ptt.restore();
                dataGridView1.DataSource = ptt.GetDataPTT();
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
                dataGridView1.DataSource = ptt.LocPTTTheoNgay(loaiLoc);
            }
        }

        private void FrmDSPhieuTT_Load(object sender, EventArgs e)
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