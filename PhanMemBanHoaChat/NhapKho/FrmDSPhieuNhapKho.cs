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
using PhanMemBanHoaChat.Phieu;

namespace PhanMemBanHoaChat.NhapKho
{
    public partial class FrmDSPhieuNhapKho : DevExpress.XtraEditors.XtraForm
    {
        BD_PhieuNhapKho pn = new BD_PhieuNhapKho();
        private string tendn;
        private AutoCompleteStringCollection autoCompleteCollection;
        public FrmDSPhieuNhapKho()
        {
            InitializeComponent();
            InitializeUI();
        }
        public FrmDSPhieuNhapKho(string tendn)
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
        private void FrmDSPhieuNhapKho_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = pn.GetDataPN();
            dataGridView1.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns[0].HeaderText = "Mã phiếu nhập";
            dataGridView1.Columns[1].HeaderText = "Ngày lập";
            dataGridView1.Columns[2].HeaderText = "Tổng số lượng";
            dataGridView1.Columns[3].HeaderText = "Mã nhân viên";
            dataGridView1.Columns[4].HeaderText = "Tên nhân viên";
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
            txbmapn.Clear();
            txbtimkiem.Clear();
            dataGridView1.DataSource = pn.GetDataPN();
            dataGridView1.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns[0].HeaderText = "Mã phiếu nhập";
            dataGridView1.Columns[1].HeaderText = "Ngày lập";
            dataGridView1.Columns[2].HeaderText = "Tổng số lượng";
            dataGridView1.Columns[3].HeaderText = "Mã nhân viên";
            dataGridView1.Columns[4].HeaderText = "Tên nhân viên";
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            var timKiem = pn.TimKiemPN(txbtimkiem.Text);
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
                string mahd = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txbmapn.Text = mahd;

            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maPhieuNhap = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                LoadCTPN(maPhieuNhap);
            }
        }
        private void LoadCTPN(string maPhieuNhap)
        {
            List<CTPN> cthdList = pn.GetDataCTPN(maPhieuNhap);
            dataGridView2.DataSource = cthdList;
            dataGridView2.Columns[0].HeaderText = "Mã phiếu nhập";
            dataGridView2.Columns[1].HeaderText = "Mã hàng hóa";
            dataGridView2.Columns[2].HeaderText = "Tên hàng hóa";
            dataGridView2.Columns[3].HeaderText = "Số lượng nhập";
            dataGridView2.Columns[4].HeaderText = "Đơn vị tính";
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string maPhieuNhap = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                FrmTaoPhieuNhapKho frm = new FrmTaoPhieuNhapKho();
                frm.ChonHangFromDataGridView(maPhieuNhap);
                frm.Show();
                frm.cbbtenhh.Text = "Chọn hàng hóa";
                frm.cbbtenhh.ForeColor = Color.Gray;
                frm.txbmahh.Text = "";
                frm.txbdonVT.Text = "";
                frm.lbngayl.Show();
                frm.lbhienngayl.Show();
                frm.btnTao.Hide();
                this.Hide();
            }
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            FrmTaoPhieuNhapKho frm = new FrmTaoPhieuNhapKho(tendn);
            frm.Show();
            frm.cbbtenhh.Text = "Chọn hàng hóa";
            frm.cbbtenhh.ForeColor = Color.Gray;
            frm.txbmahh.Text = "";
            frm.txbdonVT.Text = "";
            frm.lbngayl.Hide();
            frm.lbhienngayl.Hide();
            frm.btnLuu.Hide();
            frm.btnXuatHoaDon.Hide();
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
                dataGridView1.DataSource = pn.LocPhieuNhapTheoNgay(loaiLoc);
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