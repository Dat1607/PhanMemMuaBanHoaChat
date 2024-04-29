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

namespace PhanMemBanHoaChat.NhanVien
{
    public partial class FrmDSNhanVien : DevExpress.XtraEditors.XtraForm
    {
        BD_NhanVien nv = new BD_NhanVien();
        private string tendn;
        private AutoCompleteStringCollection autoCompleteCollection;
        public FrmDSNhanVien()
        {
            InitializeComponent();
            InitializeUI();
        }
        public FrmDSNhanVien(string tendn)
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
        private void FrmDSNhanVien_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = nv.LoadNhanVien();
            dataGridView1.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
            int columnIndex = dataGridView1.Columns[7].Index;
            int columnIndex1 = dataGridView1.Columns[9].Index;
            int columnIndex2 = dataGridView1.Columns[10].Index;
            int columnIndex3 = dataGridView1.Columns[11].Index;
            dataGridView1.Columns[columnIndex].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns[columnIndex1].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns[columnIndex2].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns[columnIndex3].DefaultCellStyle.Format = "N0";
            DataGridViewTextBoxColumn decimalColumn = (DataGridViewTextBoxColumn)dataGridView1.Columns[8];
            decimalColumn.DefaultCellStyle.Format = "N2";
            dataGridView1.Columns[0].HeaderText = "Mã nhân viên";
            dataGridView1.Columns[1].HeaderText = "Tên nhân viên";
            dataGridView1.Columns[2].HeaderText = "Ngày sinh";
            dataGridView1.Columns[3].HeaderText = "Căn cước công dân";
            dataGridView1.Columns[4].HeaderText = "Email";
            dataGridView1.Columns[5].HeaderText = "Số điện thoại";
            dataGridView1.Columns[6].HeaderText = "Tên chức vụ";
            dataGridView1.Columns[7].HeaderText = "Lương cơ sở";
            dataGridView1.Columns[8].HeaderText = "Hệ số lương";
            dataGridView1.Columns[9].HeaderText = "Phụ cấp";
            dataGridView1.Columns[10].HeaderText = "Tiền thưởng";
            dataGridView1.Columns[11].HeaderText = "Lương cơ bản";
            dataGridView1.Columns[12].HeaderText = "Tài khoản";
            dataGridView1.Columns[13].HeaderText = "Mật khẩu";
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txbtimkiem.Clear();
            txbmanv.Clear();
            dataGridView1.DataSource = nv.LoadNhanVien();
            dataGridView1.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
            int columnIndex = dataGridView1.Columns[7].Index;
            int columnIndex1 = dataGridView1.Columns[9].Index;
            int columnIndex2 = dataGridView1.Columns[10].Index;
            int columnIndex3 = dataGridView1.Columns[11].Index;
            dataGridView1.Columns[columnIndex].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns[columnIndex1].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns[columnIndex2].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns[columnIndex3].DefaultCellStyle.Format = "N0";
            DataGridViewTextBoxColumn decimalColumn = (DataGridViewTextBoxColumn)dataGridView1.Columns[8];
            decimalColumn.DefaultCellStyle.Format = "N2";
            dataGridView1.Columns[0].HeaderText = "Mã nhân viên";
            dataGridView1.Columns[1].HeaderText = "Tên nhân viên";
            dataGridView1.Columns[2].HeaderText = "Ngày sinh";
            dataGridView1.Columns[3].HeaderText = "Căn cước công dân";
            dataGridView1.Columns[4].HeaderText = "Email";
            dataGridView1.Columns[5].HeaderText = "Số điện thoại";
            dataGridView1.Columns[6].HeaderText = "Tên chức vụ";
            dataGridView1.Columns[7].HeaderText = "Lương cơ sở";
            dataGridView1.Columns[8].HeaderText = "Hệ số lương";
            dataGridView1.Columns[9].HeaderText = "Phụ cấp";
            dataGridView1.Columns[10].HeaderText = "Tiền thưởng";
            dataGridView1.Columns[11].HeaderText = "Lương cơ bản";
            dataGridView1.Columns[12].HeaderText = "Tài khoản";
            dataGridView1.Columns[13].HeaderText = "Mật khẩu";
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            FrmTaoNhanVien frm = new FrmTaoNhanVien();
            frm.btnLuu.Hide();  
            frm.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string manv = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txbmanv.Text = manv;
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            var timKiem = nv.TimKiemNV(txbtimkiem.Text);
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
            FrmTaoNhanVien frm = new FrmTaoNhanVien(this);
            frm.btnThem.Hide();
            frm.Show();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (!nv.KiemTraBG(txbmanv.Text) || !nv.KiemTraPNH(txbmanv.Text) || !nv.KiemTraHD(txbmanv.Text) || !nv.KiemTraPN(txbmanv.Text) || !nv.KiemTraPTT(txbmanv.Text) || !nv.KiemTraPX(txbmanv.Text) || !nv.KiemTraPXH(txbmanv.Text))
            {
                if (!string.IsNullOrWhiteSpace(txbmanv.Text))
                {
                    nv.XoaNhanVien(txbmanv.Text);
                    dataGridView1.DataSource = nv.LoadNhanVien();
                    dataGridView1.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
                    int columnIndex = dataGridView1.Columns[7].Index;
                    int columnIndex1 = dataGridView1.Columns[9].Index;
                    int columnIndex2 = dataGridView1.Columns[10].Index;
                    int columnIndex3 = dataGridView1.Columns[11].Index;
                    dataGridView1.Columns[columnIndex].DefaultCellStyle.Format = "N0";
                    dataGridView1.Columns[columnIndex1].DefaultCellStyle.Format = "N0";
                    dataGridView1.Columns[columnIndex2].DefaultCellStyle.Format = "N0";
                    dataGridView1.Columns[columnIndex3].DefaultCellStyle.Format = "N0";
                    DataGridViewTextBoxColumn decimalColumn = (DataGridViewTextBoxColumn)dataGridView1.Columns[8];
                    decimalColumn.DefaultCellStyle.Format = "N2";
                    dataGridView1.Columns[0].HeaderText = "Mã nhân viên";
                    dataGridView1.Columns[1].HeaderText = "Tên nhân viên";
                    dataGridView1.Columns[2].HeaderText = "Ngày sinh";
                    dataGridView1.Columns[3].HeaderText = "Căn cước công dân";
                    dataGridView1.Columns[4].HeaderText = "Email";
                    dataGridView1.Columns[5].HeaderText = "Số điện thoại";
                    dataGridView1.Columns[6].HeaderText = "Tên chức vụ";
                    dataGridView1.Columns[7].HeaderText = "Lương cơ sở";
                    dataGridView1.Columns[8].HeaderText = "Hệ số lương";
                    dataGridView1.Columns[9].HeaderText = "Phụ cấp";
                    dataGridView1.Columns[10].HeaderText = "Tiền thưởng";
                    dataGridView1.Columns[11].HeaderText = "Lương cơ bản";
                    dataGridView1.Columns[12].HeaderText = "Tài khoản";
                    dataGridView1.Columns[13].HeaderText = "Mật khẩu";
                    txbmanv.Clear();
                }
                else
                    MessageBox.Show("Nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Nhân viên đang được liên kết . Không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            
        }

        private void btnSaoLuu_Click(object sender, EventArgs e)
        {
            try
            {
                nv.Backup();
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
                nv.restore();
                dataGridView1.DataSource = nv.LoadNhanVien();
                dataGridView1.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
                int columnIndex = dataGridView1.Columns[7].Index;
                int columnIndex1 = dataGridView1.Columns[9].Index;
                int columnIndex2 = dataGridView1.Columns[10].Index;
                int columnIndex3 = dataGridView1.Columns[11].Index;
                dataGridView1.Columns[columnIndex].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns[columnIndex1].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns[columnIndex2].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns[columnIndex3].DefaultCellStyle.Format = "N0";
                DataGridViewTextBoxColumn decimalColumn = (DataGridViewTextBoxColumn)dataGridView1.Columns[8];
                decimalColumn.DefaultCellStyle.Format = "N2";
                dataGridView1.Columns[0].HeaderText = "Mã nhân viên";
                dataGridView1.Columns[1].HeaderText = "Tên nhân viên";
                dataGridView1.Columns[2].HeaderText = "Ngày sinh";
                dataGridView1.Columns[3].HeaderText = "Căn cước công dân";
                dataGridView1.Columns[4].HeaderText = "Email";
                dataGridView1.Columns[5].HeaderText = "Số điện thoại";
                dataGridView1.Columns[6].HeaderText = "Tên chức vụ";
                dataGridView1.Columns[7].HeaderText = "Lương cơ sở";
                dataGridView1.Columns[8].HeaderText = "Hệ số lương";
                dataGridView1.Columns[9].HeaderText = "Phụ cấp";
                dataGridView1.Columns[10].HeaderText = "Tiền thưởng";
                dataGridView1.Columns[11].HeaderText = "Lương cơ bản";
                dataGridView1.Columns[12].HeaderText = "Tài khoản";
                dataGridView1.Columns[13].HeaderText = "Mật khẩu";
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