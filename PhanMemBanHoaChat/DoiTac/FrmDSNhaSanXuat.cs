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
    public partial class FrmDSNhaSanXuat : DevExpress.XtraEditors.XtraForm
    {
        BD_NSX qlnsx = new BD_NSX();
        private string tendn;
        private AutoCompleteStringCollection autoCompleteStringCollection;
        public FrmDSNhaSanXuat()
        {
            InitializeComponent();
            dataGridView1.DataSource = qlnsx.GetData();
            dataGridView1.Columns[0].HeaderText = "Mã nhà sản xuất";
            dataGridView1.Columns[1].HeaderText = "Tên nhà sản xuất";
            dataGridView1.Columns[2].HeaderText = "Địa chỉ";
        }
        public FrmDSNhaSanXuat(string tendn)
        {
            InitializeComponent();
            dataGridView1.DataSource = qlnsx.GetData();
            dataGridView1.Columns[0].HeaderText = "Mã nhà sản xuất";
            dataGridView1.Columns[1].HeaderText = "Tên nhà sản xuất";
            dataGridView1.Columns[2].HeaderText = "Địa chỉ";
            this.tendn = tendn;

            autoCompleteStringCollection = new AutoCompleteStringCollection();
            LoadAutoCompleteData();
            txbtimkiem.AutoCompleteMode = AutoCompleteMode.Suggest;
            txbtimkiem.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txbtimkiem.AutoCompleteCustomSource = autoCompleteStringCollection;

            txbmansx.AutoCompleteMode = AutoCompleteMode.Suggest;
            txbmansx.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txbmansx.AutoCompleteCustomSource = autoCompleteStringCollection;
        }
        private void LoadAutoCompleteData()
        {
            var query = from data in qlnsx.GetData()
                        select data.MaSoThue;

            autoCompleteStringCollection.AddRange(query.ToArray());
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txbtimkiem.Clear();
            dataGridView1.DataSource = qlnsx.GetData();
            dataGridView1.Columns[0].HeaderText = "Mã nhà sản xuất";
            dataGridView1.Columns[1].HeaderText = "Tên nhà sản xuất";
            dataGridView1.Columns[2].HeaderText = "Địa chỉ";
        }

        private void btnThemNSX_Click(object sender, EventArgs e)
        {
            FrmTaoNhaSanXuat frm = new FrmTaoNhaSanXuat();
            frm.btnLuu.Hide();
            frm.Show();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            qlnsx.XoaNSX(txbmansx.Text);
            dataGridView1.DataSource = qlnsx.GetData();
            dataGridView1.Columns[0].HeaderText = "Mã nhà sản xuất";
            dataGridView1.Columns[1].HeaderText = "Tên nhà sản xuất";
            dataGridView1.Columns[2].HeaderText = "Địa chỉ";
            txbmansx.Clear();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            FrmTaoNhaSanXuat frm = new FrmTaoNhaSanXuat(this);
            frm.btnThem.Hide();
            frm.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string mansx = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txbmansx.Text = mansx;
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            var timKiem = qlnsx.TimKiemNSX(txbtimkiem.Text);
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
                qlnsx.Backup();
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
                qlnsx.restore();
                dataGridView1.DataSource = qlnsx.GetData();
                dataGridView1.Columns[0].HeaderText = "Mã nhà sản xuất";
                dataGridView1.Columns[1].HeaderText = "Tên nhà sản xuất";
                dataGridView1.Columns[2].HeaderText = "Địa chỉ";
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi phục hồi dữ liệu: " + ex.Message);
            }
        }
    }
}