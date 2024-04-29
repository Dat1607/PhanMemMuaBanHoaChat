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
    public partial class FrmCongNo : DevExpress.XtraEditors.XtraForm
    {
        BD_CongNo cn = new BD_CongNo();
        BD_KhachHang kh = new BD_KhachHang();
        private string tendn;
        public FrmCongNo()
        {
            InitializeComponent();
            LoadDataKH();
        }
        public FrmCongNo(string tendn)
        {
            InitializeComponent();
            this.tendn = tendn;
            LoadDataKH();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cbbmastkh.Text = "Chọn mã số thuế khách hàng";
            cbbmastkh.ForeColor = Color.Gray;
            txbtenkh.Text = "";
        }
        private void LoadDataKH()
        {
            var mns = kh.GetData();

            foreach (var mn in mns)
            {
                cbbmastkh.Items.Add(mn.TenKhachHang);
            }
            cbbmastkh.SelectedIndex = 0;
        }

        private void cbbmastkh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbmastkh.Text == "Chọn mã số thuế khách hàng" && cbbmastkh.SelectedIndex == 0)
            {
                cbbmastkh.ForeColor = Color.Gray;
            }
            else
            {
                cbbmastkh.ForeColor = Color.Black;
                string chonGiaTri = cbbmastkh.SelectedItem.ToString();
                string tenkh = kh.LayMaKHByTenKH(chonGiaTri);
                txbtenkh.Text = tenkh;
            }
        }

        private void cbbmastkh_DropDown(object sender, EventArgs e)
        {
            if (cbbmastkh.Text == "Chọn tên khách hàng")
            {
                cbbmastkh.Text = "";
            }
        }

        private void cbbmastkh_DropDownClosed(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbbmastkh.Text))
            {
                cbbmastkh.Text = "Chọn mã số thuế khách hàng";
                cbbmastkh.ForeColor = Color.Gray;
            }
            else
            {
                cbbmastkh.ForeColor = Color.Black;
            }
        }

        private void FrmCongNo_Load(object sender, EventArgs e)
        {
            cbbmastkh.Text = "Chọn tên khách hàng";
            cbbmastkh.ForeColor = Color.Gray;
            txbtenkh.Text = "";
        }

        private void btnLoadCN_Click(object sender, EventArgs e)
        {
            string tenKhachHang = txbtenkh.Text;
            DateTime ngayChon = dateTimePicker1.Value;

            List<CONGN> hoaDons = cn.GetInvoicesByDate(tenKhachHang, ngayChon);

            dataGridView1.DataSource = hoaDons;
            dataGridView1.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
            int columnIndex = dataGridView1.Columns[2].Index;
            int columnIndex1 = dataGridView1.Columns[3].Index;
            dataGridView1.Columns[columnIndex].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns[columnIndex1].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns[0].HeaderText = "Mã phiếu xuất hàng";
            dataGridView1.Columns[1].HeaderText = "Ngày lập";
            dataGridView1.Columns[2].HeaderText = "Tổng thành tiền";
            dataGridView1.Columns[3].HeaderText = "Thanh toán";
            dataGridView1.Columns[4].HeaderText = "Ngày thanh toán";
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            string tenKhachHang = txbtenkh.Text;
            DateTime ngayChon = dateTimePicker1.Value;
            ExcelExport ee = new ExcelExport();
            List<CONGN> list = cn.GetInvoicesByDate(tenKhachHang, ngayChon);
            try
            {
                string fileName = "BaoCao.xls";
                if (ee.ExportCongNo(list, ref fileName, true, ngayChon.Date.ToString("dd/MM/yyyy")))
                {
                    MessageBox.Show("Đã xuất thành công");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất: " + ex.Message);
            }
        }
    }
}