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

namespace PhanMemBanHoaChat.DoiTac
{
    public partial class FrmDSNhaCC : DevExpress.XtraEditors.XtraForm
    {
        BD_NhaCC qlncc = new BD_NhaCC();
        private string tendn;
        private AutoCompleteStringCollection autoCompleteCollection;
        public FrmDSNhaCC()
        {
            InitializeComponent();
            InitializeUI();
            dataGridView1.DataSource = qlncc.GetData();
            dataGridView1.Columns[0].HeaderText = "Mã nhà cung cấp";
            dataGridView1.Columns[1].HeaderText = "Tên nhà cung cấp";
            dataGridView1.Columns[2].HeaderText = "Địa chỉ";
        }
        public FrmDSNhaCC(string tendn)
        {
            InitializeComponent();
            InitializeUI();
            dataGridView1.DataSource = qlncc.GetData();
            dataGridView1.Columns[0].HeaderText = "Mã nhà cung cấp";
            dataGridView1.Columns[1].HeaderText = "Tên nhà cung cấp";
            dataGridView1.Columns[2].HeaderText = "Địa chỉ";
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

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txbtimkiem.Clear();
            dataGridView1.DataSource = qlncc.GetData();
            dataGridView1.Columns[0].HeaderText = "Mã nhà cung cấp";
            dataGridView1.Columns[1].HeaderText = "Tên nhà cung cấp";
            dataGridView1.Columns[2].HeaderText = "Địa chỉ";
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            FrmTaoNhaCungCap frm = new FrmTaoNhaCungCap();
            frm.btnLuu.Hide();
            frm.Show();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
           
            if (!qlncc.KiemTraDDH(txbmancc.Text) || !qlncc.KiemTraPNH(txbmancc.Text))
            {
                if (!string.IsNullOrWhiteSpace(txbmancc.Text))
                {
                    qlncc.XoaNCC(txbmancc.Text);
                    dataGridView1.DataSource = qlncc.GetData();
                    dataGridView1.Columns[0].HeaderText = "Mã nhà cung cấp";
                    dataGridView1.Columns[1].HeaderText = "Tên nhà cung cấp";
                    dataGridView1.Columns[2].HeaderText = "Địa chỉ";
                    txbmancc.Clear();
                }
                else
                    MessageBox.Show("Nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Nhà cung cấp đang được liên kết . Không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            FrmTaoNhaCungCap frm = new FrmTaoNhaCungCap(this);
            frm.btnThem.Hide();
            frm.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string mancc = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txbmancc.Text = mancc;
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            var timKiem = qlncc.TimKiemNCC(txbtimkiem.Text);
            if (timKiem.Count > 0)
            {
                dataGridView1.DataSource = timKiem;
            }
            else
            {
                MessageBox.Show("Không tìm thấy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSaoLuu_Click(object sender, EventArgs e)
        {
            try
            {
                qlncc.Backup();
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
                qlncc.restore();
                dataGridView1.DataSource = qlncc.GetData();
                dataGridView1.Columns[0].HeaderText = "Mã nhà cung cấp";
                dataGridView1.Columns[1].HeaderText = "Tên nhà cung cấp";
                dataGridView1.Columns[2].HeaderText = "Địa chỉ";
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
    }
}