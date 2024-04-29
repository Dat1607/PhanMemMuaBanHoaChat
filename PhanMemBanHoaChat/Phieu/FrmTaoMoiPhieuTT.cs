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
using Tools;

namespace PhanMemBanHoaChat.Phieu
{
    public partial class FrmTaoMoiPhieuTT : DevExpress.XtraEditors.XtraForm
    {
        BD_PhieuThanhToan ptt = new BD_PhieuThanhToan();
        BD_NhanVien nv = new BD_NhanVien();
        BD_HoaDon hd = new BD_HoaDon();
        private string tendn;
        public FrmTaoMoiPhieuTT(string tendn)
        {
            InitializeComponent();
            LoadDataHD();
            this.tendn = tendn;
            string tenNhanVien = nv.LayTenNhanVienTuTenDangNhap(tendn);
            txbtennv.Text = tenNhanVien;
            string maNV = nv.LayMaNhanVienTuTenDangNhap(tendn);
            txbmanv.Text = maNV;
        }
        public void ChonHangFromDataGridView(string maPTT)
        {
            PTTCTiet ptToan = ptt.GetDataPTToan(maPTT);
            if (ptToan != null)
            {
                lbmaptt.Text = ptToan.MaPhieuThanhToan;
                dtpNgayl.Value = Convert.ToDateTime(ptToan.NgayLap);
                txbmanv.Text = ptToan.MaNV;
                txbtennv.Text = ptToan.TenNV;
                txbmastkh.Text = ptToan.MaKH;
                txbtenkh.Text = ptToan.TenKH;
                txbdckh.Text = ptToan.DiaChiKH;
                txbthanhtoan.Text = ptToan.ThanhToan.Value.ToString("#,##0");
                CTPTTCTiet ctptt = ptt.GetDataCTPTToan(maPTT);
                if (ctptt != null)
                {
                    cbbmahd.Text = ctptt.MaHoaDon;
                    cbbmahd.ForeColor = Color.Black;
                    txbtongtienthanhtoan.Text = ctptt.TongThanhToan.Value.ToString("#,##0");
                }
            }
        }

        private void cbbmanv_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        private void LoadDataHD()
        {
            var mns = hd.GetData();

            foreach (var mn in mns)
            {
                cbbmahd.Items.Add(mn.MaHD);
            }
            cbbmahd.SelectedIndex = 0;
        }

        private void cbbmahd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbmahd.Text == "Chọn mã hóa đơn" && cbbmahd.SelectedIndex == 0)
            {
                cbbmahd.ForeColor = Color.Gray;
            }
            else
            {
                cbbmahd.ForeColor = Color.Black;
                string chonGiaTri = cbbmahd.SelectedItem.ToString();
                double? tctt = hd.LayTCTTByMaHD(chonGiaTri);
                if (tctt.HasValue)
                {
                    string dinhDangTien = tctt.Value.ToString("#,##0");
                    txbtongtienthanhtoan.Text = dinhDangTien;
                }
                BLL_DAL.KhachHang kh = ptt.LayTTKHByMaptt(chonGiaTri);
                txbmastkh.Text = kh.MaKhachHang;
                txbtenkh.Text = kh.TenKhachHang;
                txbdckh.Text = kh.DiaChi;
            }
        }

        private void cbbmahd_DropDown(object sender, EventArgs e)
        {
            if (cbbmahd.Text == "Chọn mã hóa đơn")
            {
                cbbmahd.Text = "";
            }
        }

        private void cbbmahd_DropDownClosed(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbbmahd.Text))
            {
                cbbmahd.Text = "Chọn mã hóa đơn";
                cbbmahd.ForeColor = Color.Gray;
            }
            else
            {
                cbbmahd.ForeColor = Color.Black;
            }
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            string maptt = "PTT" + cbbmahd.Text;
            DateTime ngayL = DateTime.Now;
            ptt.themPTT(maptt, ngayL, Convert.ToDouble(txbthanhtoan.Text), txbmanv.Text, txbmastkh.Text, cbbmahd.Text);
            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
        }

        private void btnXuatIn_Click(object sender, EventArgs e)
        {
            WordExport w = new WordExport();
            try
            {
                if (w.XuatPhieuThanhToan(DateTime.Now.Day.ToString(),
                            DateTime.Now.Month.ToString(),
                            DateTime.Now.Year.ToString(),
                            lbmaptt.Text,
                            cbbmahd.SelectedItem.ToString(),
                            txbtenkh.Text,
                            txbmastkh.Text,
                            txbdckh.Text,
                            txbtongtienthanhtoan.Text,
                            txbthanhtoan.Text,
                            dtpNgayl.Text))
                {
                    MessageBox.Show("Đã xuất thành công");
                }


            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất: " + ex.Message);
            }
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            ExcelExport ee = new ExcelExport();
            try
            {
                string fileName = "BaoCao.xls";
                if (ee.ExportPhieuThanhToan(ref fileName, true, lbmaptt.Text, cbbmahd.SelectedItem.ToString(), txbtenkh.Text, txbmastkh.Text, txbdckh.Text, txbtongtienthanhtoan.Text, txbthanhtoan.Text, dtpNgayl.Text))
                {
                    MessageBox.Show("Đã xuất thành công");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất: " + ex.Message);
            }
        }

        private void txbthanhtoan_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txbthanhtoan.Text, out double number))
            {
                txbthanhtoan.Text = number.ToString("N0");
                txbthanhtoan.SelectionStart = txbthanhtoan.Text.Length;
            }
        }
    }
}