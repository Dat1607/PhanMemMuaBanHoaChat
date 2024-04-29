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
using WinFormsTextBox = System.Windows.Forms.TextBox;

namespace PhanMemBanHoaChat.BaoGia
{
    public partial class FrmTaoBaoGia : DevExpress.XtraEditors.XtraForm
    {
        BD_BaoGia bg = new BD_BaoGia();
        BD_KhachHang kh = new BD_KhachHang();
        BD_HangHoa hh = new BD_HangHoa();
        BD_NhanVien nv = new BD_NhanVien();
        private string tendn;
        private string maBG;
        public FrmTaoBaoGia()
        {
            InitializeComponent();
        }
        public FrmTaoBaoGia(string tendn)
        {
            InitializeComponent();
            LoadDataKH();
            LoadDataHH();
            this.tendn = tendn;
            string tenNhanVien = nv.LayTenNhanVienTuTenDangNhap(tendn);
            txbtennv.Text = tenNhanVien;
            string maNV = nv.LayMaNhanVienTuTenDangNhap(tendn);
            txbmanv.Text = maNV;
            txbmabg.Text = TaoRandomMaBG();
        }

        private void FrmTaoBaoGia_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            txbdvb.Text = "CÔNG TY TNHH TM DV ĐẦU TƯ VÀ PHÁT TRIỂN PHÚC THỊNH VINA";
            txbmast.Text = "0315745341";
            txbdiachi.Text = "Lầu 2, Số 170N Nơ Trang Long, Phường 12, Quận Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam";
            txbemail.Text = "ptvina2023@gmail.com";
            SetPlaceholder("Nhập quy cách", txbQC);
            SetPlaceholder("Nhập đơn giá", txbdonG);
            SetPlaceholder("Nhập ghi chú", txbghichu);
        }
        public void ChonHangFromDataGridView(string maBG)
        {
            BGCTiet baoGia = bg.GetDataBGia(maBG);

            if (baoGia != null)
            {
                txbmabg.Text = baoGia.MaBG;
                DateTime ngayLap = Convert.ToDateTime(baoGia.NgayLap);
                lbhienngayl.Text = ngayLap.ToString("dd/MM/yyyy");
                txbtennv.Text = baoGia.TenNV;
                txbmanv.Text = baoGia.MaNV;
                cbbtenkh.Text = baoGia.TenKH;
                cbbtenkh.ForeColor = Color.Black;
                txbmakh.Text = baoGia.MaKH;
                List<CTBGCTiet> ctbgList = bg.GetDataCTBGia(maBG);
                if (ctbgList != null && ctbgList.Any())
                {
                    foreach (CTBGCTiet ctbgItem in ctbgList)
                    {
                        string maHH = ctbgItem.MaHangHoa;
                        string tenHH = ctbgItem.TenHangHoa;
                        string quyC = ctbgItem.QuyCach;
                        string donG = ctbgItem.DonGia.HasValue ? ctbgItem.DonGia.Value.ToString("#,##0") : "";
                        string xuatX = ctbgItem.XuatXu;
                        string ghichu = ctbgItem.GhiChu;
                        dataGridView1.Rows.Add(maHH, tenHH, quyC, donG, xuatX, ghichu);
                    }
                    int columnIndex = dataGridView1.Columns[3].Index;
                    dataGridView1.Columns[columnIndex].DefaultCellStyle.Format = "N0";
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
            if (textBox.Text == "Nhập quy cách" || textBox.Text == "Nhập đơn giá" || textBox.Text == "Nhập ghi chú")
            {
                textBox.Text = "";
                textBox.ForeColor = System.Drawing.Color.Black;
            }
        }
        private string TaoRandomMaBG()
        {
            Random random = new Random();
            int randomValue;
            string maBG;
            do
            {
                randomValue = random.Next(0, 1000);
                maBG = "BG" + randomValue.ToString("000");
            } while (KiemTraTrungMaBG(maBG));

            return maBG;
        }

        private bool KiemTraTrungMaBG(string maBG)
        {
            return false;
        }
        private void LoadDataKH()
        {
            var mns = kh.GetData();

            foreach (var mn in mns)
            {
                cbbtenkh.Items.Add(mn.TenKhachHang);
            }
            cbbtenkh.SelectedIndex = 0;
        }

        private void cbbtenkh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbtenkh.Text == "Chọn khách hàng" && cbbtenkh.SelectedIndex == 0)
            {
                cbbtenkh.ForeColor = Color.Gray;
            }
            else
            {
                cbbtenkh.ForeColor = Color.Black;
                string chonGiaTri = cbbtenkh.SelectedItem.ToString();
                string makh = kh.LayMaKHByTenKH(chonGiaTri);
                txbmakh.Text = makh;
            }
        }

        private void cbbtenkh_DropDown(object sender, EventArgs e)
        {
            if (cbbtenkh.Text == "Chọn khách hàng")
            {
                cbbtenkh.Text = "";
            }
        }

        private void cbbtenkh_DropDownClosed(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbbtenkh.Text))
            {
                cbbtenkh.Text = "Chọn khách hàng";
                cbbtenkh.ForeColor = Color.Gray;
            }
            else
            {
                cbbtenkh.ForeColor = Color.Black;
            }
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
                string xuatx = hh.LayXuatXHHByTenHH(chonGiaTri);
                txbmahh.Text = mahh;
                txbxuatxu.Text = xuatx;
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

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbQC.Text) && string.IsNullOrEmpty(txbdonG.Text))
            {
                MessageBox.Show("Vui lòng không để trống");
            }
            else
            {
                string tenhh = cbbtenhh.Text;
                string mahh = txbmahh.Text;
                string quycach = txbQC.Text;
                double donG = Convert.ToDouble(txbdonG.Text);
                string xuatxu = txbxuatxu.Text;
                string ghichu = txbghichu.Text;
                dataGridView1.Rows.Add(mahh, tenhh, quycach, donG, xuatxu, ghichu);
                int columnIndex = dataGridView1.Columns[3].Index;
                dataGridView1.Columns[columnIndex].DefaultCellStyle.Format = "N0";
                cbbtenhh.Text = "Chọn hàng hóa";
                cbbtenhh.ForeColor = Color.Gray;
                txbmahh.Clear();
                txbdonG.Clear();
                txbQC.Clear();
                txbxuatxu.Clear();
                txbghichu.Clear();
                SetPlaceholder("Nhập quy cách", txbQC);
                SetPlaceholder("Nhập đơn giá", txbdonG);
                SetPlaceholder("Nhập ghi chú", txbghichu);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (string.IsNullOrEmpty(txbQC.Text) && string.IsNullOrEmpty(txbdonG.Text))
                {
                    MessageBox.Show("Vui lòng không để trống");
                }
                else
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                    string tenhh = cbbtenhh.Text;
                    string mahh = txbmahh.Text;
                    string qc = txbQC.Text;
                    string donG = txbdonG.Text;
                    string xxu = txbxuatxu.Text;
                    string ghichu = txbghichu.Text;

                    selectedRow.Cells[0].Value = tenhh;
                    selectedRow.Cells[1].Value = mahh;
                    selectedRow.Cells[2].Value = qc;
                    selectedRow.Cells[3].Value = donG;
                    selectedRow.Cells[4].Value = xxu;
                    selectedRow.Cells[5].Value = ghichu;
                    int columnIndex = dataGridView1.Columns[3].Index;
                    dataGridView1.Columns[columnIndex].DefaultCellStyle.Format = "N0";
                    cbbtenhh.Text = "Chọn hàng hóa";
                    cbbtenhh.ForeColor = Color.Gray;
                    txbmahh.Clear();
                    txbdonG.Clear();
                    txbQC.Clear();
                    txbxuatxu.Clear();
                    txbghichu.Clear();
                    SetPlaceholder("Nhập quy cách", txbQC);
                    SetPlaceholder("Nhập đơn giá", txbdonG);
                    SetPlaceholder("Nhập ghi chú", txbghichu);
                }
            }
            else
            {
                MessageBox.Show("Chọn hàng hóa cần sửa");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                }
            }
            else
            {
                MessageBox.Show("Chọn hàng hóa để xóa");
            }
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            FrmDSBaoGia frm = new FrmDSBaoGia();
            List<string> maHangHoaList = new List<string>();
            List<string> quycList = new List<string>();
            List<double> dgList = new List<double>();
            List<string> gcList = new List<string>();
            DateTime ngayL = DateTime.Now;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    string maHangHoa = row.Cells[0].Value.ToString();
                    string quycach = row.Cells[2].Value.ToString();
                    double donG = Convert.ToDouble(row.Cells[3].Value);
                    string ghichu = row.Cells[5].Value.ToString();
                    maHangHoaList.Add(maHangHoa);
                    quycList.Add(quycach);
                    dgList.Add(donG);
                    gcList.Add(ghichu);

                }
            }
            if (dataGridView1.RowCount > 1 || (dataGridView1.RowCount == 1 && dataGridView1.Rows[0].Cells[0].Value != null))
            {
                if (cbbtenkh.SelectedItem != null)
                {
                    bg.themBG(txbmabg.Text, ngayL, txbmakh.Text, txbmanv.Text, maHangHoaList.ToArray(), quycList.ToArray(), dgList.ToArray(), gcList.ToArray());
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                    txbmabg.Text = TaoRandomMaBG();
                    cbbtenkh.Text = "Chọn khách hàng";
                    cbbtenkh.ForeColor = Color.Gray;
                    txbmakh.Clear();

                }
                else
                    MessageBox.Show("Chọn và nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Không có hàng hóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cbbtenhh.Text = "Chọn hàng hóa";
            cbbtenhh.ForeColor = Color.Gray;
            txbmahh.Clear();
            txbdonG.Clear();
            txbQC.Clear();
            txbxuatxu.Clear();
            txbghichu.Clear();
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
                    string tenhh = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string mahh = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string quyc = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    string donG = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    string xuatx = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    string ghichu = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    cbbtenhh.Text = tenhh;
                    txbmahh.Text = mahh;
                    txbQC.Text = quyc;
                    txbdonG.Text = donG;
                    txbxuatxu.Text = xuatx;
                    txbghichu.Text = ghichu;
                }
            }
        }

        private void txbQC_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txbQC);
        }

        private void txbQC_Leave(object sender, EventArgs e)
        {
            if (txbQC.Text.Length < 5 || txbQC.Text.Length > 50)
            {
                MessageBox.Show("Vui lòng nhập từ 5 đến 50 ký tự");
            }
            else if (txbQC.Text.Contains("  "))
            {
                MessageBox.Show("Vui lòng chỉ nhập một khoảng trắng giữa các ký tự");
            }
            SetPlaceholder("Nhập quy cách", txbQC);
        }

        private void txbdonG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbdonG_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txbdonG);
        }

        private void txbdonG_Leave(object sender, EventArgs e)
        {
            SetPlaceholder("Nhập đơn giá", txbdonG);
        }

        private void txbdonG_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txbdonG.Text, out double number))
            {
                txbdonG.Text = number.ToString("N0");
                txbdonG.SelectionStart = txbdonG.Text.Length;
            }
        }

        private void txbghichu_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txbghichu);
        }

        private void txbghichu_Leave(object sender, EventArgs e)
        {
            if (txbghichu.Text.Length < 5 || txbghichu.Text.Length > 50)
            {
                MessageBox.Show("Vui lòng nhập từ 5 đến 50 ký tự");
            }
            else if (txbghichu.Text.Contains("  "))
            {
                MessageBox.Show("Vui lòng chỉ nhập một khoảng trắng giữa các ký tự");
            }
            SetPlaceholder("Nhập ghi chú", txbghichu);
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            string tenKhachHang = cbbtenkh.Text;
            string mabg = txbmabg.Text;
            ExcelExport ee = new ExcelExport();
            List<CTBGCTiet> list = bg.GetDataCTBGia(mabg);
            try
            {
                string fileName = "BaoCao.xls";
                if (ee.ExportBaoGia(list, ref fileName, true, mabg, tenKhachHang))
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