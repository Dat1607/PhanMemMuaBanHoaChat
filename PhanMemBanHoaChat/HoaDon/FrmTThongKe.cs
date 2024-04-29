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

namespace PhanMemBanHoaChat.HoaDon
{
    public partial class FrmTThongKe : DevExpress.XtraEditors.XtraForm
    {
        BD_ThongKe tk = new BD_ThongKe();
        private string tendn;
        public FrmTThongKe()
        {
            InitializeComponent();
        }
        public FrmTThongKe(string tendn)
        {
            InitializeComponent();
            this.tendn = tendn;

            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
        }

        private void FrmTThongKe_Load(object sender, EventArgs e)
        {
            txbdvb.Text = "CÔNG TY TNHH TM DV ĐẦU TƯ VÀ PHÁT TRIỂN PHÚC THỊNH VINA";
            txbmast.Text = "0315745341";
        }
        private void CalculateTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                decimal thanhTienValue;
                if (decimal.TryParse(row.Cells[4].Value?.ToString(), out thanhTienValue))
                {
                    total += thanhTienValue;
                }
            }
            txbtongtt.Text = total.ToString("N0", CultureInfo.InvariantCulture);
        }
        private void CalculateTotalTTHang()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                decimal ttHangValue;
                if (decimal.TryParse(row.Cells[2].Value?.ToString(), out ttHangValue))
                {
                    total += ttHangValue;
                }
            }
            txbtthang.Text = total.ToString("N0", CultureInfo.InvariantCulture);
        }
        private void CalculateTotalThue()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                decimal thueValue;
                if (decimal.TryParse(row.Cells[3].Value?.ToString(), out thueValue))
                {
                    total += thueValue;
                }
            }
            txbtthue.Text = total.ToString("N0", CultureInfo.InvariantCulture);
        }
        private void btnLoadDT_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dateTimePicker1.Value;

            DateTime denNgay = dateTimePicker2.Value;

            List<THONGK> hoaDons = tk.GetInvoicesByDate(tuNgay, denNgay);

            dataGridView1.DataSource = hoaDons;
            dataGridView1.Columns[0].DefaultCellStyle.Format = "dd/MM/yyyy";
            int columnIndex = dataGridView1.Columns[2].Index;
            int columnIndex1 = dataGridView1.Columns[3].Index;
            int columnIndex2 = dataGridView1.Columns[4].Index;
            dataGridView1.Columns[columnIndex].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns[columnIndex1].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns[columnIndex2].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns[0].HeaderText = "Ngày lập hóa đơn";
            dataGridView1.Columns[1].HeaderText = "Mã hóa đơn";
            dataGridView1.Columns[2].HeaderText = "Tổng tiền hàng";
            dataGridView1.Columns[3].HeaderText = "Thuế";
            dataGridView1.Columns[4].HeaderText = "Tổng thành tiền";
            dataGridView1.Columns[5].HeaderText = "Mã khách hàng";
            dataGridView1.Columns[6].HeaderText = "Tên khách hàng";
            CalculateTotal();
            CalculateTotalTTHang();
            CalculateTotalThue();
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dateTimePicker1.Value;
            DateTime denNgay = dateTimePicker2.Value;

            List<THONGK> list = tk.GetInvoicesByDate(tuNgay, denNgay);
            ExcelExport ee = new ExcelExport();
            try
            {
                string fileName = "BaoCao.xls";
                if (ee.ExportDoanhThu(list, ref fileName, true, tuNgay.Date.ToString("dd/MM/yyyy"), denNgay.Date.ToString("dd/MM/yyyy"), txbtthang.Text, txbtthue.Text, txbtongtt.Text))
                {
                    MessageBox.Show("Đã xuất thành công");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất: " + ex.Message);
            }
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dateTimePicker1.Value;

            DateTime denNgay = dateTimePicker2.Value;

            FrmThongKeChiTiet tkct = new FrmThongKeChiTiet(tuNgay, denNgay);
            tkct.ShowDialog(this);
        }
    }
}