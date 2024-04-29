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

namespace PhanMemBanHoaChat.BaoGia
{
    public partial class FrmDSBaoGia : DevExpress.XtraEditors.XtraForm
    {
        BD_BaoGia bg = new BD_BaoGia();
        private string tendn;
        private AutoCompleteStringCollection autoCompleteCollection;
        public FrmDSBaoGia()
        {
            InitializeComponent();
            InitializeUI();
        }
        public FrmDSBaoGia(string tendn)
        {
            InitializeComponent();
            this.tendn = tendn;
            InitializeUI();
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
        private void FrmDSBaoGia_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bg.GetDataBG();
            dataGridView1.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns[0].HeaderText = "Mã báo giá";
            dataGridView1.Columns[1].HeaderText = "Mã khách hàng";
            dataGridView1.Columns[2].HeaderText = "Tên khách hàng";
            dataGridView1.Columns[3].HeaderText = "Ngày lập";
            dataGridView1.Columns[4].HeaderText = "Mã nhân viên";
            dataGridView1.Columns[5].HeaderText = "Tên nhân viên";
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
            txbmabg.Clear();
            txbtimkiem.Clear();
            dataGridView1.DataSource = bg.GetDataBG();
            dataGridView1.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns[0].HeaderText = "Mã báo giá";
            dataGridView1.Columns[1].HeaderText = "Mã khách hàng";
            dataGridView1.Columns[2].HeaderText = "Tên khách hàng";
            dataGridView1.Columns[3].HeaderText = "Ngày lập";
            dataGridView1.Columns[4].HeaderText = "Mã nhân viên";
            dataGridView1.Columns[5].HeaderText = "Tên nhân viên";
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            FrmTaoBaoGia frm = new FrmTaoBaoGia(tendn);
            frm.Show();
            frm.cbbtenkh.Text = "Chọn khách hàng";
            frm.cbbtenkh.ForeColor = Color.Gray;
            frm.txbmakh.Text = "";
            frm.cbbtenhh.Text = "Chọn hàng hóa";
            frm.cbbtenhh.ForeColor = Color.Gray;
            frm.txbmahh.Text = "";
            frm.txbxuatxu.Text = "";
            frm.lbngayl.Hide();
            frm.lbhienngayl.Hide();
            frm.btnLuu.Hide();
            frm.btnXuatHoaDon.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string mabg = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txbmabg.Text = mabg;

            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maBaoGia = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                LoadCTBG(maBaoGia);
            }
        }
        private void LoadCTBG(string maBaoGia)
        {
            List<CTBG> cthdList = bg.GetDataCTBG(maBaoGia);
            dataGridView2.DataSource = cthdList;
            int columnIndex = dataGridView2.Columns[4].Index;
            dataGridView2.Columns[columnIndex].DefaultCellStyle.Format = "N0";
            dataGridView2.Columns[0].HeaderText = "Mã báo giá";
            dataGridView2.Columns[1].HeaderText = "Mã hàng hóa";
            dataGridView2.Columns[2].HeaderText = "Tên hàng hóa";
            dataGridView2.Columns[3].HeaderText = "Quy cách";
            dataGridView2.Columns[4].HeaderText = "Đơn giá";
            dataGridView2.Columns[5].HeaderText = "Xuất xứ";
            dataGridView2.Columns[6].HeaderText = "Ghi chú";
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            var timKiem = bg.TimKiemBG(txbtimkiem.Text);
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
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string maHoaDon = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                FrmTaoBaoGia frm = new FrmTaoBaoGia();
                frm.ChonHangFromDataGridView(maHoaDon);
                frm.Show();
                frm.cbbtenhh.Text = "Chọn mã hàng hóa";
                frm.cbbtenhh.ForeColor = Color.Gray;
                frm.txbmahh.Text = "";
                frm.txbxuatxu.Text = "";
                frm.lbngayl.Show();
                frm.lbhienngayl.Show();
                frm.btnTao.Hide();
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
                dataGridView1.DataSource = bg.LocBaoGiaTheoNgay(loaiLoc);
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