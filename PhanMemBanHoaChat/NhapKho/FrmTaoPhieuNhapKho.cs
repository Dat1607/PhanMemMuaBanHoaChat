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
using WinFormsTextBox = System.Windows.Forms.TextBox;
using BLL_DAL;
using PhanMemBanHoaChat.BaoGia;
using PhanMemBanHoaChat.Kho;
using System.Globalization;
using DevExpress.XtraPrinting.Native;

namespace PhanMemBanHoaChat.NhapKho
{
    public partial class FrmTaoPhieuNhapKho : DevExpress.XtraEditors.XtraForm
    {
        BD_PhieuNhapKho pn = new BD_PhieuNhapKho();
        BD_HangHoa hh = new BD_HangHoa();
        BD_NhanVien nv = new BD_NhanVien();
        private string tendn;
        public FrmTaoPhieuNhapKho()
        {
            InitializeComponent();
        }
        public FrmTaoPhieuNhapKho(string tendn)
        {
            InitializeComponent();
            LoadDataHH();
            this.tendn = tendn;
            string tenNhanVien = nv.LayTenNhanVienTuTenDangNhap(tendn);
            txbtennv.Text = tenNhanVien;
            string maNV = nv.LayMaNhanVienTuTenDangNhap(tendn);
            txbmanv.Text = maNV;
            txbmapn.Text = TaoRandomMaPN();
        }

        private void FrmTaoPhieuNhapKho_Load(object sender, EventArgs e)
        {
            txbdvb.Text = "CÔNG TY TNHH TM DV ĐẦU TƯ VÀ PHÁT TRIỂN PHÚC THỊNH VINA";
            txbmast.Text = "0315745341";
            txbdiachi.Text = "Lầu 2, Số 170N Nơ Trang Long, Phường 12, Quận Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam";
            txbemail.Text = "ptvina2023@gmail.com";
            SetPlaceholder("Nhập số lượng", txbSL);
        }
        public void ChonHangFromDataGridView(string mapn)
        {
            PNCTiet phieuNhap = pn.GetDataPNhap(mapn);

            if (phieuNhap != null)
            {
                txbmapn.Text = phieuNhap.Mapn;
                DateTime ngayLap = Convert.ToDateTime(phieuNhap.NgayLap);
                lbhienngayl.Text = ngayLap.ToString("dd/MM/yyyy");
                txbtennv.Text = phieuNhap.TenNV;
                txbmanv.Text = phieuNhap.MaNV;
                txbTongSL.Text = phieuNhap.TongSoLuong.ToString();
                List<CTPNCTiet> ctpnList = pn.GetDataCTPNhap(mapn);
                if (ctpnList != null && ctpnList.Any())
                {
                    foreach (CTPNCTiet ctpnItem in ctpnList)
                    {
                        string maHH = ctpnItem.MaHangHoa;
                        string tenHH = ctpnItem.TenHangHoa;
                        string dvt = ctpnItem.DonViTinh;
                        int? sl = ctpnItem.SoLuongNhap;
                        dataGridView1.Rows.Add(maHH, tenHH, dvt, sl);
                    }
                }
            }
        }
        private void SetPlaceholder(string placeholder, WinFormsTextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholder;
                textBox.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void RemovePlaceholder(WinFormsTextBox textBox)
        {
            if (textBox.Text == "Nhập số lượng")
            {
                textBox.Text = "";
                textBox.ForeColor = System.Drawing.Color.Black;
            }
        }
        private string TaoRandomMaPN()
        {
            Random random = new Random();
            int randomValue;
            string maPN;
            do
            {
                randomValue = random.Next(0, 1000);
                maPN = "PN" + randomValue.ToString("000");
            } while (KiemTraTrungMaPN(maPN));

            return maPN;
        }

        private bool KiemTraTrungMaPN(string maPN)
        {
            return false;
        }
        private void LoadDataHH()
        {
            var mns = hh.GetData();

            foreach (var mn in mns)
            {
                cbbtenhh.Items.Add(mn.TenHangHoa);
            }
            cbbtenhh.SelectedIndex = 0;
        }

        private void cbbtenhh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbtenhh.Text == "Chọn hàng hóa" && cbbtenhh.SelectedIndex == 0)
            {
                cbbtenhh.ForeColor = Color.Gray;
            }
            else
            {
                cbbtenhh.ForeColor = Color.Black;
                string chonGiaTri = cbbtenhh.SelectedItem.ToString();
                string mahh = hh.LayMaHHByTenHH(chonGiaTri);
                string dvt = hh.LayDVTByTenHH(chonGiaTri);
                txbmahh.Text = mahh;
                txbdonVT.Text = dvt;
            }
        }

        private void cbbtenhh_DropDown(object sender, EventArgs e)
        {
            if (cbbtenhh.Text == "Chọn hàng hóa")
            {
                cbbtenhh.Text = "";
            }
        }

        private void cbbtenhh_DropDownClosed(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbbtenhh.Text))
            {
                cbbtenhh.Text = "Chọn hàng hóa";
                cbbtenhh.ForeColor = Color.Gray;
            }
            else
            {
                cbbtenhh.ForeColor = Color.Black;
            }
        }
        private void SoLuongTotal()
        {
            int totalSL = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int soLuongValue;
                if (int.TryParse(row.Cells[3].Value?.ToString(), out soLuongValue))
                {
                    totalSL += soLuongValue;
                }
            }
            txbTongSL.Text = totalSL.ToString();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbSL.Text))
            {
                MessageBox.Show("Vui lòng không để trống");
            }
            else
            {
                string tenhh = cbbtenhh.Text;
                string mahh = txbmahh.Text;
                string dvt = txbdonVT.Text;
                string soL = txbSL.Text;
                dataGridView1.Rows.Add(mahh, tenhh, dvt, soL);
                cbbtenhh.Text = "Chọn hàng hóa";
                cbbtenhh.ForeColor = Color.Gray;
                SoLuongTotal();
                txbmahh.Clear();
                txbdonVT.Clear();
                txbSL.Clear();
                SetPlaceholder("Nhập số lượng", txbSL);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (string.IsNullOrEmpty(txbSL.Text))
                {
                    MessageBox.Show("Vui lòng không để trống");
                }
                else
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                    string tenhh = cbbtenhh.Text;
                    string mahh = txbmahh.Text;
                    string dvt = txbdonVT.Text;
                    string sl = txbSL.Text;

                    selectedRow.Cells[0].Value = mahh;
                    selectedRow.Cells[1].Value = tenhh;
                    selectedRow.Cells[2].Value = dvt;
                    selectedRow.Cells[3].Value = sl;

                    SoLuongTotal();
                    cbbtenhh.Text = "Chọn hàng hóa";
                    cbbtenhh.ForeColor = Color.Gray;
                    txbmahh.Clear();
                    txbdonVT.Clear();
                    txbSL.Clear();
                    SetPlaceholder("Nhập số lượng", txbSL);
                }
            }
            else
            {
                MessageBox.Show("Chọn hàng hóa cần sửa");
            }
        }
        private void UpdateTotalSL(int amount)
        {
            int currentTotal;
            if (int.TryParse(txbTongSL.Text, out currentTotal))
            {
                txbTongSL.Text = (currentTotal + amount).ToString("N0", CultureInfo.InvariantCulture);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int soLuongToDelete;
                if (int.TryParse(dataGridView1.SelectedRows[0].Cells[3].Value?.ToString(), out soLuongToDelete))
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                        UpdateTotalSL(-soLuongToDelete);
                    }
                }
            }
            else
            {
                MessageBox.Show("Chọn hàng hóa để xóa");
            }
        }

        private void txbSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbSL_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txbSL);
        }

        private void txbSL_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbSL.Text))
            {
                MessageBox.Show("Vui lòng không để trống");
            }
            SetPlaceholder("Nhập số lượng", txbSL);
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            List<string> maHangHoaList = new List<string>();
            List<int> soLuongList = new List<int>();
            DateTime ngayL = DateTime.Now;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    string maHangHoa = row.Cells[0].Value.ToString();
                    int soLuong = Convert.ToInt32(row.Cells[3].Value);

                    maHangHoaList.Add(maHangHoa);
                    soLuongList.Add(soLuong);
                }
            }
            string thongbaoketqua = string.Empty;
            int kqcapnhat = hh.CapNhatSoLuong(maHangHoaList.ToArray(), soLuongList.ToArray());
            if (dataGridView1.RowCount > 1 || (dataGridView1.RowCount == 1 && dataGridView1.Rows[0].Cells[0].Value != null))
            {
                if (kqcapnhat == 1)
                {
                    pn.themPN(txbmapn.Text, ngayL, Convert.ToInt16(txbTongSL.Text), txbmanv.Text, maHangHoaList.ToArray(), soLuongList.ToArray());
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    thongbaoketqua = "Không thể cập nhật số lượng\n";

                    MessageBox.Show(thongbaoketqua + "Thêm thất bại", "Thông báo", MessageBoxButtons.OK);
                }
                
            }
            else
            {
                MessageBox.Show("Không có hàng hóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell clickedCell = (DataGridViewCell)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (clickedCell.Value == null || string.IsNullOrWhiteSpace(clickedCell.Value.ToString()))
                {
                    MessageBox.Show("Chọn hàng hóa");
                }
                else
                {
                    string mahh = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string tenhh = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string donVT = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    string sl = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    string tl = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    txbmahh.Text = mahh;
                    cbbtenhh.Text = tenhh;
                    txbdonVT.Text = donVT;
                    txbSL.Text = sl;
                }
            }
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            ExcelExport ee = new ExcelExport();
            List<CTPNCTiet> ctpnList = new List<CTPNCTiet>(pn.GetDataCTPNhap(txbmapn.Text));
            try
            {
                string fileName = "BaoCao.xls";
                if (ee.ExportPhieuNhap(ctpnList, ref fileName, true, txbdvb.Text, txbdiachi.Text, txbemail.Text, txbmapn.Text, txbTongSL.Text))
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