using DevExpress.XtraBars;
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
using PhanMemBanHoaChat.TaiKhoan;
using PhanMemBanHoaChat.PhanQuyen;
using PhanMemBanHoaChat.KhachHang;
using PhanMemBanHoaChat.NhanVien;
using PhanMemBanHoaChat.DoiTac;
using PhanMemBanHoaChat.Kho;
using PhanMemBanHoaChat.Phieu;
using PhanMemBanHoaChat.BaoGia;
using PhanMemBanHoaChat.HoaDon;
using PhanMemBanHoaChat.DatHang;
using PhanMemBanHoaChat.NhapKho;
using PhanMemBanHoaChat.XuatKho;
using PhanMemBanHoaChat.BaoCao;

namespace PhanMemBanHoaChat.ManHinhChinh
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        BD_PhanQuyen pq = new BD_PhanQuyen();
        private string tendn;
        private string quyen;
        public FrmMain(string tendn)
        {
            InitializeComponent();
            this.tendn = tendn;
            TenTaiKhoan.TenDN = tendn;
            HienThiTheoQuyen();
            this.quyen = "Quản lý"; 

        }
        public void CloseAllTab()
        {
            for (int i = xtraTabbedMdiManager1.Pages.Count - 1; i >= 0; i--)
            {
                xtraTabbedMdiManager1.Pages[i].MdiChild.Close();
            }
        }
        private void HienThiTheoQuyen()
        {
            if (pq.KiemTraQuyen(tendn, "Quản lý"))
            {
            }
            else if (pq.KiemTraQuyen(tendn, "Nhân viên bán hàng"))
            {
                tabQLNhanSu.Visible = false;
                tabDoiTac.Visible = false;
                tabQLTaiKhoan.Visible = false;
                tabPhieu.Visible = false;
            }
            else if (pq.KiemTraQuyen(tendn, "Nhân viên kho"))
            {
                tabHoaDon.Visible = false;
                tabDoiTac.Visible = false;
                tabQLTaiKhoan.Visible = false;
                tabPhieu.Visible = false;
                tabBaoCao.Visible = false;
                tabKhachHang.Visible = false;
                tabQLNhanSu.Visible = false;
            }
            else
            {
                MessageBox.Show("Tài khoản không có quyền hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        private void btnTaoTK_ItemClick(object sender, ItemClickEventArgs e)
        {
            int width = 0;
            int height = 0;
            FrmTaoTaiKhoan frm = new FrmTaoTaiKhoan(tendn);

            width = frm.Size.Width;
            height = frm.Size.Height;
            frm.MdiParent = this;
            frm.Show();
            this.ClientSize = new Size(width, height + 195);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            lbltk.Caption = tendn;
        }

        private void btnDangXuatKH_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
            FrmDangNhap frm = new FrmDangNhap();
            frm.Show();
        }

        private void btnThoatKH_ItemClick(object sender, ItemClickEventArgs e)
        {
            CloseAllTab();
        }

        private void btnDangXuatHH_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
            FrmDangNhap frm = new FrmDangNhap();
            frm.Show();
        }

        private void btnThoatHH_ItemClick(object sender, ItemClickEventArgs e)
        {
            CloseAllTab();
        }

        private void btnDangXuatHD_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
            FrmDangNhap frm = new FrmDangNhap();
            frm.Show();
        }

        private void btnThoatHD_ItemClick(object sender, ItemClickEventArgs e)
        {
            CloseAllTab();
        }

        private void btnDangXuatBC_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
            FrmDangNhap frm = new FrmDangNhap();
            frm.Show();
        }

        private void btnThoatBC_ItemClick(object sender, ItemClickEventArgs e)
        {
            CloseAllTab();
        }

        private void btnDangXuatNS_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
            FrmDangNhap frm = new FrmDangNhap();
            frm.Show();
        }

        private void btnThoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            CloseAllTab();
        }

        private void btnDangXuatDT_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
            FrmDangNhap frm = new FrmDangNhap();
            frm.Show();
        }

        private void btnThoatDT_ItemClick(object sender, ItemClickEventArgs e)
        {
            CloseAllTab();
        }

        private void btnDangXuatTK_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
            FrmDangNhap frm = new FrmDangNhap();
            frm.Show();
        }

        private void btnThoatTK_ItemClick(object sender, ItemClickEventArgs e)
        {
            CloseAllTab();
        }

        private void btnQuyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            int width = 0;
            int height = 0;
            FrmQuyen frm = new FrmQuyen(tendn);

            width = frm.Size.Width;
            height = frm.Size.Height;
            frm.MdiParent = this;
            frm.Show();
            this.ClientSize = new Size(width, height + 195);
        }

        private void btnPhanQuyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            int width = 0;
            int height = 0;
            FrmPhanQuyen frm = new FrmPhanQuyen(tendn);

            width = frm.Size.Width;
            height = frm.Size.Height;
            frm.MdiParent = this;
            frm.Show();
            this.ClientSize = new Size(width, height + 195);
        }

        private void btnDSKhachHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            int width = 0;
            int height = 0;
            FrmDSKhachHang frm = new FrmDSKhachHang(tendn, quyen);

            width = frm.Size.Width;
            height = frm.Size.Height;
            frm.MdiParent = this;
            frm.Show();
            this.ClientSize = new Size(width, height + 195);
        }

        private void btnDSNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            int width = 0;
            int height = 0;
            FrmDSNhanVien frm = new FrmDSNhanVien(tendn);

            width = frm.Size.Width;
            height = frm.Size.Height;
            frm.MdiParent = this;
            frm.Show();
            this.ClientSize = new Size(width, height + 195);
        }

        private void btnNCC_ItemClick(object sender, ItemClickEventArgs e)
        {
            int width = 0;
            int height = 0;
            FrmDSNhaCC frm = new FrmDSNhaCC(tendn);

            width = frm.Size.Width;
            height = frm.Size.Height;
            frm.MdiParent = this;
            frm.Show();
            this.ClientSize = new Size(width, height + 195);
        }

        private void btnNSX_ItemClick(object sender, ItemClickEventArgs e)
        {
            int width = 0;
            int height = 0;
            FrmDSNhaSanXuat frm = new FrmDSNhaSanXuat(tendn);

            width = frm.Size.Width;
            height = frm.Size.Height;
            frm.MdiParent = this;
            frm.Show();
            this.ClientSize = new Size(width, height + 195);
        }

        private void btnDSHangHoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            int width = 0;
            int height = 0;
            FrmDSHangHoa frm = new FrmDSHangHoa(tendn);

            width = frm.Size.Width;
            height = frm.Size.Height;
            frm.MdiParent = this;
            frm.Show();
            this.ClientSize = new Size(width, height + 195);
        }

        private void btnPhieuNhapHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            int width = 0;
            int height = 0;
            FrmDSPhieuNhanHang frm = new FrmDSPhieuNhanHang(tendn);

            width = frm.Size.Width;
            height = frm.Size.Height;
            frm.MdiParent = this;
            frm.Show();
            this.ClientSize = new Size(width, height + 195);
        }

        private void btnPhieuXuatHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            int width = 0;
            int height = 0;
            FrmDSPhieuXuatHang frm = new FrmDSPhieuXuatHang(tendn);

            width = frm.Size.Width;
            height = frm.Size.Height;
            frm.MdiParent = this;
            frm.Show();
            this.ClientSize = new Size(width, height + 195);
        }

        private void btnBaoGia_ItemClick(object sender, ItemClickEventArgs e)
        {
            int width = 0;
            int height = 0;
            FrmDSBaoGia frm = new FrmDSBaoGia(tendn);

            width = frm.Size.Width;
            height = frm.Size.Height;
            frm.MdiParent = this;
            frm.Show();
            this.ClientSize = new Size(width, height + 195);
        }

        private void btnPhieuTT_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnPhieuThanhToanb_ItemClick(object sender, ItemClickEventArgs e)
        {
            int width = 0;
            int height = 0;
            FrmDSPhieuTT frm = new FrmDSPhieuTT(tendn);

            width = frm.Size.Width;
            height = frm.Size.Height;
            frm.MdiParent = this;
            frm.Show();
            this.ClientSize = new Size(width, height + 195);
        }

        private void btnCongNo_ItemClick(object sender, ItemClickEventArgs e)
        {
            int width = 0;
            int height = 0;
            FrmCongNo frm = new FrmCongNo(tendn);

            width = frm.Size.Width;
            height = frm.Size.Height;
            frm.MdiParent = this;
            frm.Show();
            this.ClientSize = new Size(width, height + 195);
        }

        private void btnTKDoanhThu_ItemClick(object sender, ItemClickEventArgs e)
        {
            int width = 0;
            int height = 0;
            FrmTThongKe frm = new FrmTThongKe(tendn);

            width = frm.Size.Width;
            height = frm.Size.Height;
            frm.MdiParent = this;
            frm.Show();
            this.ClientSize = new Size(width, height + 195);
        }

        private void btnDSHoaDon_ItemClick(object sender, ItemClickEventArgs e)
        {
            int width = 0;
            int height = 0;
            frmDSHoaDon frm = new frmDSHoaDon(tendn);

            width = frm.Size.Width;
            height = frm.Size.Height;
            frm.MdiParent = this;
            frm.Show();
            this.ClientSize = new Size(width, height + 195);
        }

        private void btnDatHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            int width = 0;
            int height = 0;
            FrmDatHang frm = new FrmDatHang(tendn);



            width = frm.Size.Width;
            height = frm.Size.Height;
            frm.lbma.Hide();
            frm.lbmaddh.Hide();
            //frm.txbtenkh.Text = "";
            frm.txbmast.Text = "";
            frm.txbdckh.Text = "";
            frm.txbdckh.Text = "";
            frm.cbbtenhh.Text = "Chọn tên hàng hóa";
            frm.cbbtenhh.ForeColor = Color.Gray;
            frm.txbmahh.Text = "";
            frm.txbdonG.Text = "";
            frm.dataGridView2.Hide();
            frm.btnXuatHoaDon.Hide();
            frm.btnXuatIn.Hide();
            frm.Show();
            frm.MdiParent = this;
            this.ClientSize = new Size(width, height + 230);
        }

        private void btnDSDatHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            int width = 0;
            int height = 0;
            FrmDSDatHang frm = new FrmDSDatHang(tendn);

            width = frm.Size.Width;
            height = frm.Size.Height;
            frm.MdiParent = this;
            frm.Show();
            this.ClientSize = new Size(width, height + 195);
        }

        private void btnPhieuNhapKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            int width = 0;
            int height = 0;
            FrmDSPhieuNhapKho frm = new FrmDSPhieuNhapKho(tendn);

            width = frm.Size.Width;
            height = frm.Size.Height;
            frm.MdiParent = this;
            frm.Show();
            this.ClientSize = new Size(width, height + 195);
        }

        private void btnPhieuXuatKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            int width = 0;
            int height = 0;
            FrmDSPhieuXuatKho frm = new FrmDSPhieuXuatKho(tendn);

            width = frm.Size.Width;
            height = frm.Size.Height;
            frm.MdiParent = this;
            frm.Show();
            this.ClientSize = new Size(width, height + 195);
        }

        private void btnTKSanPham_ItemClick(object sender, ItemClickEventArgs e)
        {
            int width = 0;
            int height = 0;
            FrmDoanhThuTheoSP frm = new FrmDoanhThuTheoSP(tendn);

            width = frm.Size.Width;
            height = frm.Size.Height;
            frm.MdiParent = this;
            frm.Show();
            this.ClientSize = new Size(width, height + 195);
        }

        private void btnDangXuatPhieu_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
            FrmDangNhap frm = new FrmDangNhap();
            frm.Show();
        }

        private void btnThoatPhieu_ItemClick(object sender, ItemClickEventArgs e)
        {
            CloseAllTab();
        }
    }
}