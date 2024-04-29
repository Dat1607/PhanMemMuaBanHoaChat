using BLL_DAL;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemBanHoaChat.BaoCao
{
    public partial class FrmDoanhThuTheoSP : DevExpress.XtraEditors.XtraForm
    {
        BD_DoanhThuSP dt = new BD_DoanhThuSP();
        BD_ThongKe tk = new BD_ThongKe();
        private string tendn;
        public FrmDoanhThuTheoSP()
        {
            InitializeComponent();
        }
        public FrmDoanhThuTheoSP(string tendn)
        {
            InitializeComponent();
            this.tendn = tendn;
        }

        private void FrmDoanhThuTheoSP_Load(object sender, EventArgs e)
        {
            txbdvb.Text = "CÔNG TY TNHH TM DV ĐẦU TƯ VÀ PHÁT TRIỂN PHÚC THỊNH VINA";
            txbmast.Text = "0315745341";
        }
        private void btnloadDT_Click(object sender, EventArgs e)
        {
        }
        private void CalculateTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                decimal thanhTienValue;
                if (decimal.TryParse(row.Cells[8].Value?.ToString(), out thanhTienValue))
                {
                    total += thanhTienValue;
                }
            }
            txbtongtt.Text = total.ToString("N0", CultureInfo.InvariantCulture);
        }
        private void CalculateTotalDonGia()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                decimal thueValue;
                if (decimal.TryParse(row.Cells[6].Value?.ToString(), out thueValue))
                {
                    total += thueValue;
                }
            }
            txbdgia.Text = total.ToString("N0", CultureInfo.InvariantCulture);
        }
        private void btnLoadDT_Click_1(object sender, EventArgs e)
        {
            DateTime tuNgay = dateTimePicker1.Value;
            DateTime denNgay = dateTimePicker2.Value;

            List<DoanhThuSP> hoaDons = dt.GetInvoicesByDate(tuNgay, denNgay);

            dataGridView1.DataSource = hoaDons;
            dataGridView1.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";
            int columnIndex = dataGridView1.Columns[6].Index;
            int columnIndex1 = dataGridView1.Columns[8].Index;
            dataGridView1.Columns[columnIndex].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns[columnIndex1].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns[0].HeaderText = "Mã khách hàng";
            dataGridView1.Columns[1].HeaderText = "Ngày lập hóa đơn";
            dataGridView1.Columns[2].HeaderText = "Mã hóa đơn";
            dataGridView1.Columns[3].HeaderText = "Tên khách hàng";
            dataGridView1.Columns[4].HeaderText = "Tên hàng hóa";
            dataGridView1.Columns[5].HeaderText = "Đơn vị tính";
            dataGridView1.Columns[6].HeaderText = "Đơn giá";
            dataGridView1.Columns[7].HeaderText = "Số lượng";
            dataGridView1.Columns[8].HeaderText = "Thành tiền";
            CalculateTotal();
            CalculateTotalDonGia();
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dateTimePicker1.Value;
            DateTime denNgay = dateTimePicker2.Value;

            List<DoanhThuSP> list = dt.GetInvoicesByDate(tuNgay, denNgay);
            ExcelExport ee = new ExcelExport();
            try
            {
                string fileName = "BaoCao.xls";
                if (ee.ExportDoanhThuSP(list, ref fileName, true, tuNgay.Date.ToString("dd/MM/yyyy"), denNgay.Date.ToString("dd/MM/yyyy"), txbdgia.Text, txbtongtt.Text))
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