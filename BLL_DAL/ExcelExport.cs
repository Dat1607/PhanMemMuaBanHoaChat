using BLL_DAL;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;

namespace BLL_DAL
{
    public class ExcelExport
    {
        #region ---- Constants ----

        private const int ROW_MAXIMUM = 200;
        private const int COL_MAXIMUM = 256;

        private const string FONT_NAME = "Arial";
        private const int HEADER_FONT_SIZE = 16;
        private const int SUBHEADER_FONT_SIZE = 13;
        private const int CAPTION_FONT_SIZE = 10;
        private const int CONTENT_FONT_SIZE = 10;

        #endregion

        #region ---- Member variables ----

        private IWorkbook _workBook;

        #endregion

        #region ---- Constructors ----
        public ExcelExport()
        {

        }

        #endregion

        #region ---- Private methods ----

        private void WriteColumHeader(IWorksheet xlsSheet, int startRow, int startCol, string[] arrColName, int[] arrColWidth, int rowHeight)
        {
            for (int i = 0; i < arrColName.Length; i++)
            {
                xlsSheet.Range[startRow, startCol + i].Text = arrColName[i];
                xlsSheet.Range[startRow, startCol + i].ColumnWidth = arrColWidth[i];
            }

            xlsSheet.Range[startRow, 1].RowHeight = rowHeight;
            CellStyle(xlsSheet, startRow, startCol, startRow, startCol + arrColName.Length, FONT_NAME, CAPTION_FONT_SIZE, true, false);
            xlsSheet.Range[startRow, startCol, startRow, startCol + arrColName.Length].HorizontalAlignment = ExcelHAlign.HAlignCenter;
            xlsSheet.Range[startRow, startCol, startRow, startCol + arrColName.Length].VerticalAlignment = ExcelVAlign.VAlignCenter;
            xlsSheet.Range[startRow, startCol, startRow, startCol + arrColName.Length].WrapText = true;
        }

        private void DrawTableBorder(IWorksheet xlsSheet, int startRow, int startCol, int endRow, int endCol, ExcelLineStyle lineStyle)
        {
            xlsSheet.IsGridLinesVisible = false;

            xlsSheet[startRow, startCol, endRow, endCol].CellStyle.Borders.LineStyle = lineStyle;
            xlsSheet[startRow, startCol, endRow, endCol].CellStyle.Borders[ExcelBordersIndex.DiagonalDown].ShowDiagonalLine = false;
            xlsSheet[startRow, startCol, endRow, endCol].CellStyle.Borders[ExcelBordersIndex.DiagonalUp].ShowDiagonalLine = false;
            xlsSheet[startRow, startCol, endRow, endCol].CellStyle.Borders.ColorRGB = Color.Black;

            xlsSheet.Range[startRow, startCol, endRow, endCol].WrapText = true;
        }

        #region ---- Format -----

        private void ColsAlighment(IWorksheet xlsSheet, int[] cols, ExcelHAlign HAlight)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                ColAlighment(xlsSheet, cols[i], HAlight);
            }
        }

        private void ColAlighment(IWorksheet xlsSheet, int col, ExcelHAlign HAlight)
        {
            xlsSheet.Range[1, col, ROW_MAXIMUM, col].CellStyle.HorizontalAlignment = HAlight;
            xlsSheet.Range[1, col, ROW_MAXIMUM, col].CellStyle.VerticalAlignment = ExcelVAlign.VAlignCenter;
        }

        private void CellAlighment(IWorksheet xlsSheet, int startRow, int startCol, int endRow, int endCol, ExcelHAlign HAlight, ExcelVAlign VAlight)
        {
            xlsSheet.Range[startRow, startCol, endRow, endCol].CellStyle.HorizontalAlignment = HAlight;
            xlsSheet.Range[startRow, startCol, endRow, endCol].CellStyle.VerticalAlignment = VAlight;
        }

        private void CellStyle(IWorksheet xlsSheet, int startRow, int startCol, int endRow, int endCol, bool isBold)
        {
            xlsSheet.Range[startRow, startCol, endRow, endCol].CellStyle.Font.Bold = isBold;
        }

        private void CellStyle(IWorksheet xlsSheet, int startRow, int startCol, int endRow, int endCol, bool isBold, bool isItalic)
        {
            CellStyle(xlsSheet, startRow, startCol, endRow, endCol, isBold);
            xlsSheet.Range[startRow, startCol, endRow, endCol].CellStyle.Font.Italic = isItalic;
        }

        private void CellStyle(IWorksheet xlsSheet, int startRow, int startCol, int endRow, int endCol, ExcelKnownColors color)
        {
            xlsSheet.Range[startRow, startCol, endRow, endCol].CellStyle.Font.Color = color;
        }

        private void CellStyle(IWorksheet xlsSheet, int startRow, int startCol, int endRow, int endCol, bool isBold, ExcelKnownColors color)
        {
            CellStyle(xlsSheet, startRow, startCol, endRow, endCol, isBold);
            CellStyle(xlsSheet, startRow, startCol, endRow, endCol, color);
        }

        private void CellStyle(IWorksheet xlsSheet, int startRow, int startCol, int endRow, int endCol, bool isBold, bool isItalic, ExcelKnownColors color)
        {
            CellStyle(xlsSheet, startRow, startCol, endRow, endCol, isBold, isItalic);
            CellStyle(xlsSheet, startRow, startCol, endRow, endCol, color);
        }

        private void CellStyle(IWorksheet xlsSheet, int startRow, int startCol, int endRow, int endCol, string fontName, int fontSize, bool isBold, bool isItalic)
        {
            xlsSheet.Range[startRow, startCol, endRow, endCol].CellStyle.Font.FontName = fontName;
            xlsSheet.Range[startRow, startCol, endRow, endCol].CellStyle.Font.Size = fontSize;
            CellStyle(xlsSheet, startRow, startCol, endRow, endCol, isBold, isItalic);
        }

        private void CellStyleBackGround(IWorksheet xlsSheet, int startRow, int startCol, int endRow, int endCol)
        {
            xlsSheet.Range[startRow, startCol, endRow, endCol].CellStyle.ColorIndex = ExcelKnownColors.Grey_25_percent;
        }

        #endregion ---- Format -----

        private void PageSetup(IWorksheet xlsSheet, ExcelPageOrientation PageOrientation, bool isSmall)
        {
            // Setting the file name in the Footer
            xlsSheet.PageSetup.RightFooter = "&P";
            // Setting Page Number
            xlsSheet.PageSetup.AutoFirstPageNumber = false;
            xlsSheet.PageSetup.FirstPageNumber = 1;
            // Setting Page Margins
            xlsSheet.PageSetup.TopMargin = 0.35;
            xlsSheet.PageSetup.BottomMargin = 0.5;
            xlsSheet.PageSetup.LeftMargin = 0.35;
            xlsSheet.PageSetup.RightMargin = 0.2;

            xlsSheet.PageSetup.HeaderMargin = 0.3;
            xlsSheet.PageSetup.FooterMargin = 0.5;
            // Setting the Paper Type
            if (isSmall)
            {
                xlsSheet.PageSetup.PaperSize = ExcelPaperSize.PaperA5;
            }
            else
            {
                xlsSheet.PageSetup.PaperSize = ExcelPaperSize.PaperA4;
            }

            // Setting the Page Orientation as Portrait or Landscape
            xlsSheet.PageSetup.Orientation = PageOrientation;
        }

        private string SaveExcel(ExcelEngine xslEngine, bool isPrint, string defaultName = "", bool usingStyle = false)
        {
            string result = string.Empty;

            try
            {
                if (isPrint)
                {
                    result = Path.GetTempFileName() + ".xls";
                    _workBook.SaveAs(result);
                }
                else
                {
                    string extension = "xsl";
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Files(*.xls)|*.xls";
                    saveFileDialog.AddExtension = true;
                    saveFileDialog.DefaultExt = "." + extension;
                    saveFileDialog.FileName = defaultName;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK && saveFileDialog.CheckPathExists)
                    {
                        _workBook.Version = (ExcelVersion.Excel97to2003);
                        _workBook.SaveAs(saveFileDialog.FileName);
                        if (MessageBox.Show("Mở file vừa xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process proc = new System.Diagnostics.Process();
                            proc.StartInfo.FileName = saveFileDialog.FileName;

                            result = saveFileDialog.FileName;

                            proc.Start();
                        }
                    }
                }

                _workBook.Close();
            }
            catch
            { }
            finally
            {
                xslEngine.Dispose();
            }

            return result;
        }

        #endregion

        #region ---- Export Excel Template ----

        #region ---- Constants ----

        #region ---- Name Template ----

        // Tuyen Dung
        public const string T_KeHoachTuyenDung = "KeHoachTD";
        // Khai báo trùng với tên đặt trong file cần điền dữ liệu ra
        public const string T_BieuMau = "BieuMau";
        public const string T_DanhMucKhoa = "DanhMucHoaDon";
        public const string T_BCDoanhThuTheoSP = "DoanhThuSP";
        public const string T_PhieuNhapKho = "PhieuNhapKho";
        public const string T_PhieuXuatKho = "PhieuXuatKho";
        public const string T_PhieuThanhToan = "PhieuThanhToan";
        public const string T_DonDatHang = "DonDatHang";
        public const string T_CongNo = "CongNo";
        public const string T_DoanhThu = "DoanhThu";
        public const string T_Kho = "Kho";
        public const string T_BaoGia = "BaoGia";
        public const string T_PhieuNhapHang = "PhieuNhapHang";
        public const string T_PhieuXuatHang = "PhieuXuatHang";
        #endregion

        #region ---- Variables ----

        // Utility                        
        private const string TMP_SHEET = "TMP";
        private const string TMP_ROW = "[TMP]";

        private const string V_PHONGBAN = "%PhongBan";
        private const string V_QUY = "%Quy";
        private const string V_NAM = "%Nam";

        private const string V_TONGSO = "%TongSo";
        private const string V_NGAYTHANGANAM = "%NgayThangNam";

        // ke Hoach thu viec
        private const string V_HOTEN = "%HoTen";
        private const string V_CHUCVU = "%ChucVu";
        private const string V_NGAYTHUVIEC = "%NgayThuViec";
        private const string V_NGUOIQUANLY = "%NguoiQuanLy";
        private const string V_QUANLYCV = "%QuanLyCV";
        private const string V_THUVIECDENNGAY = "%ThuViecDenNgay";


        // Phieu yeu cau
        private const string V_NOIDUNGYEUCAU = "%NoiDungYeuCau";
        private const string V_TENCHUCDANH = "%TenChucDanh";
        private const string V_SOLUONG = "%SoLuong";
        private const string V_TRINHDO = "%TenTrinhDo";
        private const string V_SOLUONGNAM = "%SoLuongNam";
        private const string V_TUOITU = "%TuoiTu";
        private const string V_CHUYENNGANH = "%TenChuyenNganh";
        private const string V_KINHNGHIEMLAMVIEC = "%SoNamKinhNghiem";
        private const string V_NGAYCANNHANSU = "%NgayCanNhanSu";
        private const string V_LYDO = "%TenLyDo";
        private const string V_NGOAINGU = "%TenNgoaiNgu";
        private const string V_TINHOC = "%TenTrinhDoTinHoc";
        private const string V_YEUCAUCANTHIET = "%YeuCauCanThiet";
        private const string V_YEUCAUSUCKHOE = "%YeuCauSucKhoe";
        private const string V_TINHTRANGHONNHAN = "%TenTinhTrangHonNhan";
        private const string V_YEUCAUKHAC = "%YeuCauKhac";
        private const string V_GHICHU = "%GhiChu";
        #endregion

        #endregion

        #region ---- Private methods ----

        private string SaveFile(bool pIsPrint = true)
        {

            string result = string.Empty;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = Constants.FILTER_EXCEL;
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = Constants.FILE_EXT_XLS;


            if (!pIsPrint && saveFileDialog.ShowDialog() == DialogResult.OK && saveFileDialog.CheckPathExists)
            {
                result = saveFileDialog.FileName;
            }

            return result;
        }
        public void OpenFile(string pPathFile)
        {
            if (string.IsNullOrEmpty(pPathFile))
            {
                return;
            }

            if (MessageBox.Show("Bạn muốn mở file", "Thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = pPathFile;
                proc.Start();
            }
        }
        private static void Replace(IWorksheet workSheet, string findValue, string replaceValue)
        {
            if (workSheet != null && !string.IsNullOrEmpty(findValue))
            {
                IRange[] cells = workSheet.Range.Cells;
                IRange range = null;
                for (int i = 0; i < cells.Count(); i++)
                {
                    range = cells[i];
                    if (range != null && range.DisplayText.Contains(findValue))
                    {
                        range.Text = range.Text.Replace(findValue, replaceValue);
                        break;
                    }
                }
            }
        }
        public static void PrintExcel(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return;
            }

            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wb = null;

            try
            {
                wb = excelApp.Workbooks.Open(fileName);

                if (wb != null)
                {
                    excelApp.Visible = true;
                    wb.PrintPreview(true);
                }
            }
            catch (Exception ex)
            {
                //ShowMessage
            }
            //finally
            //{
            //    // Cleanup:
            //    GC.Collect();
            //    GC.WaitForPendingFinalizers();

            //    wb.Close(false, Type.Missing, Type.Missing);
            //    Marshal.FinalReleaseComObject(wb);

            //    excelApp.Quit();
            //    Marshal.FinalReleaseComObject(excelApp);
            //}
        }
        private void BuildReplacerHoaDon(ref Dictionary<string, string> pReplacer, string MaHD, string MaSoThue, string Email, string TenKH, string MaSoThueKH, string DiaChiKH, string TongThanhTien, string VAT, string TongThanhToan, string DVB, string HinhThucTT)
        {
            if (pReplacer != null)
            {
                DateTime currentDate = DateTime.Now;
                string ngay = "Ngày " + currentDate.Day + " tháng " + currentDate.Month + " năm " + currentDate.Year;
                pReplacer.Add("%NgayThangNam", ngay);
                pReplacer.Add("%MaHD", MaHD);
                pReplacer.Add("%MaSoThue", MaSoThue);
                pReplacer.Add("%Email", Email);
                pReplacer.Add("%TenKH", TenKH);
                pReplacer.Add("%MaSoThueKH", MaSoThueKH);
                pReplacer.Add("%DiaChiKH", DiaChiKH);
                pReplacer.Add("%TongThanhTien", TongThanhTien);
                pReplacer.Add("%VAT", VAT);
                pReplacer.Add("%TongThanhToan", TongThanhToan);
                pReplacer.Add("%DonViBH", DVB);
                pReplacer.Add("%HinhThucTT", HinhThucTT);
            }
        }
        private void BuildReplacerPhieuNhap(ref Dictionary<string, string> pReplacer, string TenDonVi, string DiaChi, string Email, string SoLenhNhap, string TongCong)
        {
            if (pReplacer != null)
            {
                DateTime currentDate = DateTime.Now;
                string ngay = "Ngày " + currentDate.Day + " tháng " + currentDate.Month + " năm " + currentDate.Year;
                pReplacer.Add("%NgayThangNam", ngay);
                pReplacer.Add("%TenDonVi", TenDonVi);
                pReplacer.Add("%DiaChi", DiaChi);
                pReplacer.Add("%Email", Email);
                pReplacer.Add("%SoLenhNhap", SoLenhNhap);
                pReplacer.Add("%TongCong", TongCong);
            }
        }
        private void BuildReplacerPhieuXuat(ref Dictionary<string, string> pReplacer, string TenDonVi, string DiaChi, string Email, string SoLenhXuat, string TongCong)
        {
            if (pReplacer != null)
            {
                DateTime currentDate = DateTime.Now;
                string ngay = "Ngày " + currentDate.Day + " tháng " + currentDate.Month + " năm " + currentDate.Year;
                pReplacer.Add("%NgayThangNam", ngay);
                pReplacer.Add("%TenDonVi", TenDonVi);
                pReplacer.Add("%DiaChi", DiaChi);
                pReplacer.Add("%Email", Email);
                pReplacer.Add("%SoLenhXuat", SoLenhXuat);
                pReplacer.Add("%TongCong", TongCong);
            }
        }
        private void BuildReplacerPhieuNhapHang(ref Dictionary<string, string> pReplacer, string TenDonVi, string DiaChi, string Email, string SoLenhNhap, string DonViKH, string DiaChiKH, string MaST, string NgayGiao, string TongTT, string VAT, string TongThanhToan)
        {
            if (pReplacer != null)
            {
                DateTime currentDate = DateTime.Now;
                string ngay = "Ngày " + currentDate.Day + " tháng " + currentDate.Month + " năm " + currentDate.Year;
                pReplacer.Add("%NgayThangNam", ngay);
                pReplacer.Add("%TenDonVi", TenDonVi);
                pReplacer.Add("%DiaChi", DiaChi);
                pReplacer.Add("%Email", Email);
                pReplacer.Add("%SoLenhNhap", SoLenhNhap);
                pReplacer.Add("%DonViKH", DonViKH);
                pReplacer.Add("%DiaChiKH", DiaChiKH);
                pReplacer.Add("%MaST", MaST);
                pReplacer.Add("%NgayGiao", NgayGiao);
                pReplacer.Add("%TongTT", TongTT);
                pReplacer.Add("%VAT", VAT);
                pReplacer.Add("%TongThanhToan", TongThanhToan);
            }
        }
        private void BuildReplacerPhieuXuatHang(ref Dictionary<string, string> pReplacer, string TenDonVi, string DiaChi, string Email, string SoLenhXuat, string DonViKH, string DiaChiKH, string MaST, string NgayGiao,string TongTT, string VAT, string TongThanhToan)
        {
            if (pReplacer != null)
            {
                DateTime currentDate = DateTime.Now;
                string ngay = "Ngày " + currentDate.Day + " tháng " + currentDate.Month + " năm " + currentDate.Year;
                pReplacer.Add("%NgayThangNam", ngay);
                pReplacer.Add("%TenDonVi", TenDonVi);
                pReplacer.Add("%DiaChi", DiaChi);
                pReplacer.Add("%Email", Email);
                pReplacer.Add("%SoLenhXuat", SoLenhXuat);
                pReplacer.Add("%DonViKH", DonViKH);
                pReplacer.Add("%DiaChiKH", DiaChiKH);
                pReplacer.Add("%MaST", MaST);
                pReplacer.Add("%NgayGiao", NgayGiao);
                pReplacer.Add("%TongTT", TongTT);
                pReplacer.Add("%VAT", VAT);
                pReplacer.Add("%TongThanhToan", TongThanhToan);
            }
        }
        private void BuildReplacerPhieuThanhToan(ref Dictionary<string, string> pReplacer, string MaPTT, string MaHD, string TenKH, string MaSoThue, string DiaChi, string TongTienTT, string KHThanhToan, string NgayLap)
        {
            if (pReplacer != null)
            {
                DateTime currentDate = DateTime.Now;
                string ngay = "Ngày " + currentDate.Day + " tháng " + currentDate.Month + " năm " + currentDate.Year;
                pReplacer.Add("%NgayThangNam", ngay);
                pReplacer.Add("%MaPTT", MaPTT);
                pReplacer.Add("%MaHD", MaHD);
                pReplacer.Add("%TenKH", TenKH);
                pReplacer.Add("%MaSoThue", MaSoThue);
                pReplacer.Add("%DiaChi", DiaChi);
                pReplacer.Add("%TongTienTT", TongTienTT);
                pReplacer.Add("%KHThanhToan", KHThanhToan);
                pReplacer.Add("%NgayLap", NgayLap);
            }
        }
        private void BuildReplacerDonDatHang(ref Dictionary<string, string> pReplacer, string MaDDH, string MaSoThue, string TenKH, string DiaChi, string TongSL, string ThanhTien, string NgayDat)
        {
            if (pReplacer != null)
            {
                DateTime currentDate = DateTime.Now;
                string ngay = "Ngày " + currentDate.Day + " tháng " + currentDate.Month + " năm " + currentDate.Year;
                pReplacer.Add("%NgayThangNam", ngay);
                pReplacer.Add("%MaDDH", MaDDH);
                pReplacer.Add("%MaSoThue", MaSoThue);
                pReplacer.Add("%TenKH", TenKH);
                pReplacer.Add("%DiaChi", DiaChi);
                pReplacer.Add("%TongSL", TongSL);
                pReplacer.Add("%ThanhTien", ThanhTien);
                pReplacer.Add("%NgayDat", NgayDat);

            }
        }
        private void BuildReplacerCongNo(ref Dictionary<string, string> pReplacer, string NgayLap)
        {
            if (pReplacer != null)
            {
                DateTime currentDate = DateTime.Now;
                string ngay = "Ngày " + currentDate.Day + " tháng " + currentDate.Month + " năm " + currentDate.Year;
                pReplacer.Add("%NgayThangNam", ngay);
                pReplacer.Add("%NgayLap", NgayLap);
            }
        }
        private void BuildReplacerDoanhThu(ref Dictionary<string, string> pReplacer, string NgayBatDau, string NgayKetThuc, string tthang, string ttthue, string tongtt)
        {
            if (pReplacer != null)
            {
                DateTime currentDate = DateTime.Now;
                string ngay = "Ngày " + currentDate.Day + " tháng " + currentDate.Month + " năm " + currentDate.Year;
                pReplacer.Add("%NgayThangNam", ngay);
                pReplacer.Add("%NgayBatDau", NgayBatDau);
                pReplacer.Add("%NgayKetThuc", NgayKetThuc);
                pReplacer.Add("%TTHang", tthang);
                pReplacer.Add("%TTThue", ttthue);
                pReplacer.Add("%TongTT", tongtt);

            }
        }
        private void BuildReplacerDoanhThuSP(ref Dictionary<string, string> pReplacer, string NgayBatDau, string NgayKetThuc, string dg, string tongtt)
        {
            if (pReplacer != null)
            {
                DateTime currentDate = DateTime.Now;
                string ngay = "Ngày " + currentDate.Day + " tháng " + currentDate.Month + " năm " + currentDate.Year;
                pReplacer.Add("%NgayThangNam", ngay);
                pReplacer.Add("%NgayBatDau", NgayBatDau);
                pReplacer.Add("%NgayKetThuc", NgayKetThuc);
                pReplacer.Add("%DonGia", dg);
                pReplacer.Add("%TongTT", tongtt);

            }
        }
        private void BuildReplacerKho(ref Dictionary<string, string> pReplacer, string NgayBatDau, string NgayKetThuc)
        {
            if (pReplacer != null)
            {
                DateTime currentDate = DateTime.Now;
                string ngay = "Ngày " + currentDate.Day + " tháng " + currentDate.Month + " năm " + currentDate.Year;
                pReplacer.Add("%NgayThangNam", ngay);
                pReplacer.Add("%NgayBatDau", NgayBatDau);
                pReplacer.Add("%NgayKetThuc", NgayKetThuc);
            }
        }
        private void BuildReplacerBaoGia(ref Dictionary<string, string> pReplacer, string MaBG, string TenKH)
        {
            if (pReplacer != null)
            {
                DateTime currentDate = DateTime.Now;
                string ngay = "Ngày " + currentDate.Day + " tháng " + currentDate.Month + " năm " + currentDate.Year;
                pReplacer.Add("%NgayThangNam", ngay);
                pReplacer.Add("%MaBG", MaBG);
                pReplacer.Add("%TenKH", TenKH);
            }
        }
        private bool OutSimpleReportHoaDon<T>(List<T> dataSource, Dictionary<string, string> replaceValues, string viewName, bool isPrintPreview, ref string fileName)
        {
            bool result = false;
            MemoryStream stream = GetTemplateStream(viewName);

            if (stream == null)
            {
                return false;
            }
            ExcelEngine engine = new ExcelEngine();
            IWorkbook workBook = engine.Excel.Workbooks.Open(stream);

            IWorksheet workSheet = workBook.Worksheets[0];
            ITemplateMarkersProcessor markProcessor = workSheet.CreateTemplateMarkersProcessor();

            if (replaceValues != null && replaceValues.Count > 0)
            {
                foreach (KeyValuePair<string, string> replacer in replaceValues)
                {
                    Replace(workSheet, replacer.Key, replacer.Value);
                }
            }
            markProcessor.AddVariable(viewName, dataSource);
            int startRow = 13;
            int rowNumber = startRow;

            foreach (var dataItem in dataSource)
            {
                int columnIndex = 1;
                int serialNumber = rowNumber - startRow + 1;
                Console.WriteLine($"Setting value at Row: {rowNumber}, Column: {columnIndex}, Serial Number: {serialNumber}");

                workSheet.SetValue(rowNumber, columnIndex, serialNumber.ToString());
                rowNumber++;
            }
            markProcessor.ApplyMarkers(UnknownVariableAction.ReplaceBlank);

            IRange range = workSheet.FindFirst(TMP_ROW, ExcelFindType.Text);

            if (range != null)
            {
                workSheet.DeleteRow(range.Row);
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = Constants.FILTER_EXCEL;
                saveFileDialog.AddExtension = true;
                saveFileDialog.DefaultExt = Constants.FILE_EXT_XLS;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog.FileName;
                    if (!FileCommon.IsFileOpenOrReadOnly(fileName))
                    {
                        workBook.SaveAs(fileName);
                        result = true;
                    }
                }
            }
            workBook.Close();
            engine.Dispose();
            if (result && isPrintPreview)
            {
                PrintExcel(fileName);
            }

            return result;
        }
        private bool OutSimpleReportPhieuNhap<T>(List<T> dataSource, Dictionary<string, string> replaceValues, string viewName, bool isPrintPreview, ref string fileName)
        {
            bool result = false;
            MemoryStream stream = GetTemplateStream(viewName);

            if (stream == null)
            {
                return false;
            }
            ExcelEngine engine = new ExcelEngine();
            IWorkbook workBook = engine.Excel.Workbooks.Open(stream);

            IWorksheet workSheet = workBook.Worksheets[0];
            ITemplateMarkersProcessor markProcessor = workSheet.CreateTemplateMarkersProcessor();

            if (replaceValues != null && replaceValues.Count > 0)
            {
                foreach (KeyValuePair<string, string> replacer in replaceValues)
                {
                    Replace(workSheet, replacer.Key, replacer.Value);
                }
            }
            markProcessor.AddVariable(viewName, dataSource);
            int startRow = 11;
            int rowNumber = startRow;

            foreach (var dataItem in dataSource)
            {
                int columnIndex = 1;
                int serialNumber = rowNumber - startRow + 1;
                Console.WriteLine($"Setting value at Row: {rowNumber}, Column: {columnIndex}, Serial Number: {serialNumber}");

                workSheet.SetValue(rowNumber, columnIndex, serialNumber.ToString());
                rowNumber++;
            }
            markProcessor.ApplyMarkers(UnknownVariableAction.ReplaceBlank);

            IRange range = workSheet.FindFirst(TMP_ROW, ExcelFindType.Text);

            if (range != null)
            {
                workSheet.DeleteRow(range.Row);
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = Constants.FILTER_EXCEL;
                saveFileDialog.AddExtension = true;
                saveFileDialog.DefaultExt = Constants.FILE_EXT_XLS;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog.FileName;
                    if (!FileCommon.IsFileOpenOrReadOnly(fileName))
                    {
                        workBook.SaveAs(fileName);
                        result = true;
                    }
                }
            }
            workBook.Close();
            engine.Dispose();
            if (result && isPrintPreview)
            {
                PrintExcel(fileName);
            }

            return result;
        }
        private bool OutSimpleReportPhieuNhapHang<T>(List<T> dataSource, Dictionary<string, string> replaceValues, string viewName, bool isPrintPreview, ref string fileName)
        {
            bool result = false;
            MemoryStream stream = GetTemplateStream(viewName);

            if (stream == null)
            {
                return false;
            }
            ExcelEngine engine = new ExcelEngine();
            IWorkbook workBook = engine.Excel.Workbooks.Open(stream);

            IWorksheet workSheet = workBook.Worksheets[0];
            ITemplateMarkersProcessor markProcessor = workSheet.CreateTemplateMarkersProcessor();

            if (replaceValues != null && replaceValues.Count > 0)
            {
                foreach (KeyValuePair<string, string> replacer in replaceValues)
                {
                    Replace(workSheet, replacer.Key, replacer.Value);
                }
            }
            markProcessor.AddVariable(viewName, dataSource);
            int startRow = 18;
            int rowNumber = startRow;

            foreach (var dataItem in dataSource)
            {
                int columnIndex = 1;
                int serialNumber = rowNumber - startRow + 1;
                Console.WriteLine($"Setting value at Row: {rowNumber}, Column: {columnIndex}, Serial Number: {serialNumber}");

                workSheet.SetValue(rowNumber, columnIndex, serialNumber.ToString());
                rowNumber++;
            }
            markProcessor.ApplyMarkers(UnknownVariableAction.ReplaceBlank);

            IRange range = workSheet.FindFirst(TMP_ROW, ExcelFindType.Text);

            if (range != null)
            {
                workSheet.DeleteRow(range.Row);
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = Constants.FILTER_EXCEL;
                saveFileDialog.AddExtension = true;
                saveFileDialog.DefaultExt = Constants.FILE_EXT_XLS;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog.FileName;
                    if (!FileCommon.IsFileOpenOrReadOnly(fileName))
                    {
                        workBook.SaveAs(fileName);
                        result = true;
                    }
                }
            }
            workBook.Close();
            engine.Dispose();
            if (result && isPrintPreview)
            {
                PrintExcel(fileName);
            }

            return result;
        }
        private bool OutSimpleReportPhieuXuat<T>(List<T> dataSource, Dictionary<string, string> replaceValues, string viewName, bool isPrintPreview, ref string fileName)
        {
            bool result = false;
            MemoryStream stream = GetTemplateStream(viewName);

            if (stream == null)
            {
                return false;
            }
            ExcelEngine engine = new ExcelEngine();
            IWorkbook workBook = engine.Excel.Workbooks.Open(stream);

            IWorksheet workSheet = workBook.Worksheets[0];
            ITemplateMarkersProcessor markProcessor = workSheet.CreateTemplateMarkersProcessor();

            if (replaceValues != null && replaceValues.Count > 0)
            {
                foreach (KeyValuePair<string, string> replacer in replaceValues)
                {
                    Replace(workSheet, replacer.Key, replacer.Value);
                }
            }
            markProcessor.AddVariable(viewName, dataSource);
            int startRow = 11;
            int rowNumber = startRow;

            foreach (var dataItem in dataSource)
            {
                int columnIndex = 1;
                int serialNumber = rowNumber - startRow + 1;
                Console.WriteLine($"Setting value at Row: {rowNumber}, Column: {columnIndex}, Serial Number: {serialNumber}");

                workSheet.SetValue(rowNumber, columnIndex, serialNumber.ToString());
                rowNumber++;
            }
            markProcessor.ApplyMarkers(UnknownVariableAction.ReplaceBlank);

            IRange range = workSheet.FindFirst(TMP_ROW, ExcelFindType.Text);

            if (range != null)
            {
                workSheet.DeleteRow(range.Row);
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = Constants.FILTER_EXCEL;
                saveFileDialog.AddExtension = true;
                saveFileDialog.DefaultExt = Constants.FILE_EXT_XLS;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog.FileName;
                    if (!FileCommon.IsFileOpenOrReadOnly(fileName))
                    {
                        workBook.SaveAs(fileName);
                        result = true;
                    }
                }
            }
            workBook.Close();
            engine.Dispose();
            if (result && isPrintPreview)
            {
                PrintExcel(fileName);
            }

            return result;
        }
        private bool OutSimpleReportPhieuXuatHang<T>(List<T> dataSource, Dictionary<string, string> replaceValues, string viewName, bool isPrintPreview, ref string fileName)
        {
            bool result = false;
            MemoryStream stream = GetTemplateStream(viewName);

            if (stream == null)
            {
                return false;
            }
            ExcelEngine engine = new ExcelEngine();
            IWorkbook workBook = engine.Excel.Workbooks.Open(stream);

            IWorksheet workSheet = workBook.Worksheets[0];
            ITemplateMarkersProcessor markProcessor = workSheet.CreateTemplateMarkersProcessor();

            if (replaceValues != null && replaceValues.Count > 0)
            {
                foreach (KeyValuePair<string, string> replacer in replaceValues)
                {
                    Replace(workSheet, replacer.Key, replacer.Value);
                }
            }
            markProcessor.AddVariable(viewName, dataSource);
            int startRow = 18;
            int rowNumber = startRow;

            foreach (var dataItem in dataSource)
            {
                int columnIndex = 1;
                int serialNumber = rowNumber - startRow + 1;
                Console.WriteLine($"Setting value at Row: {rowNumber}, Column: {columnIndex}, Serial Number: {serialNumber}");

                workSheet.SetValue(rowNumber, columnIndex, serialNumber.ToString());
                rowNumber++;
            }
            markProcessor.ApplyMarkers(UnknownVariableAction.ReplaceBlank);

            IRange range = workSheet.FindFirst(TMP_ROW, ExcelFindType.Text);

            if (range != null)
            {
                workSheet.DeleteRow(range.Row);
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = Constants.FILTER_EXCEL;
                saveFileDialog.AddExtension = true;
                saveFileDialog.DefaultExt = Constants.FILE_EXT_XLS;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog.FileName;
                    if (!FileCommon.IsFileOpenOrReadOnly(fileName))
                    {
                        workBook.SaveAs(fileName);
                        result = true;
                    }
                }
            }
            workBook.Close();
            engine.Dispose();
            if (result && isPrintPreview)
            {
                PrintExcel(fileName);
            }

            return result;
        }
        private bool OutSimpleReportPhieuThanhToan(Dictionary<string, string> replaceValues, string viewName, bool isPrintPreview, ref string fileName)
        {
            bool result = false;
            MemoryStream stream = GetTemplateStream(viewName);

            if (stream == null)
            {
                return false;
            }
            ExcelEngine engine = new ExcelEngine();
            IWorkbook workBook = engine.Excel.Workbooks.Open(stream);

            IWorksheet workSheet = workBook.Worksheets[0];
            ITemplateMarkersProcessor markProcessor = workSheet.CreateTemplateMarkersProcessor();

            if (replaceValues != null && replaceValues.Count > 0)
            {
                foreach (KeyValuePair<string, string> replacer in replaceValues)
                {
                    Replace(workSheet, replacer.Key, replacer.Value);
                }
            }
            
            markProcessor.ApplyMarkers(UnknownVariableAction.ReplaceBlank);

            IRange range = workSheet.FindFirst(TMP_ROW, ExcelFindType.Text);

            if (range != null)
            {
                workSheet.DeleteRow(range.Row);
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = Constants.FILTER_EXCEL;
                saveFileDialog.AddExtension = true;
                saveFileDialog.DefaultExt = Constants.FILE_EXT_XLS;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog.FileName;
                    if (!FileCommon.IsFileOpenOrReadOnly(fileName))
                    {
                        workBook.SaveAs(fileName);
                        result = true;
                    }
                }
            }
            workBook.Close();
            engine.Dispose();
            if (result && isPrintPreview)
            {
                PrintExcel(fileName);
            }

            return result;
        }

        
        private bool OutSimpleReportDonDatHang<T>(List<T> dataSource, Dictionary<string, string> replaceValues, string viewName, bool isPrintPreview, ref string fileName)
        {
            bool result = false;
            MemoryStream stream = GetTemplateStream(viewName);

            if (stream == null)
            {
                return false;
            }
            ExcelEngine engine = new ExcelEngine();
            IWorkbook workBook = engine.Excel.Workbooks.Open(stream);

            IWorksheet workSheet = workBook.Worksheets[0];
            ITemplateMarkersProcessor markProcessor = workSheet.CreateTemplateMarkersProcessor();

            if (replaceValues != null && replaceValues.Count > 0)
            {
                foreach (KeyValuePair<string, string> replacer in replaceValues)
                {
                    Replace(workSheet, replacer.Key, replacer.Value);
                }
            }
            markProcessor.AddVariable(viewName, dataSource);
            int startRow = 17;
            int rowNumber = startRow;

            foreach (var dataItem in dataSource)
            {
                int columnIndex = 1;
                int serialNumber = rowNumber - startRow + 1;
                Console.WriteLine($"Setting value at Row: {rowNumber}, Column: {columnIndex}, Serial Number: {serialNumber}");

                workSheet.SetValue(rowNumber, columnIndex, serialNumber.ToString());
                rowNumber++;
            }
            markProcessor.ApplyMarkers(UnknownVariableAction.ReplaceBlank);

            IRange range = workSheet.FindFirst(TMP_ROW, ExcelFindType.Text);

            if (range != null)
            {
                workSheet.DeleteRow(range.Row);
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = Constants.FILTER_EXCEL;
                saveFileDialog.AddExtension = true;
                saveFileDialog.DefaultExt = Constants.FILE_EXT_XLS;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog.FileName;
                    if (!FileCommon.IsFileOpenOrReadOnly(fileName))
                    {
                        workBook.SaveAs(fileName);
                        result = true;
                    }
                }
            }
            workBook.Close();
            engine.Dispose();
            if (result && isPrintPreview)
            {
                PrintExcel(fileName);
            }

            return result;
        }
        private bool OutSimpleReportCongNo<T>(List<T> dataSource, Dictionary<string, string> replaceValues, string viewName, bool isPrintPreview, ref string fileName)
        {
            bool result = false;
            MemoryStream stream = GetTemplateStream(viewName);

            if (stream == null)
            {
                return false;
            }
            ExcelEngine engine = new ExcelEngine();
            IWorkbook workBook = engine.Excel.Workbooks.Open(stream);

            IWorksheet workSheet = workBook.Worksheets[0];
            ITemplateMarkersProcessor markProcessor = workSheet.CreateTemplateMarkersProcessor();

            if (replaceValues != null && replaceValues.Count > 0)
            {
                foreach (KeyValuePair<string, string> replacer in replaceValues)
                {
                    Replace(workSheet, replacer.Key, replacer.Value);
                }
            }
            markProcessor.AddVariable(viewName, dataSource);
            int startRow = 11;
            int rowNumber = startRow;

            foreach (var dataItem in dataSource)
            {
                int columnIndex = 3;

                // Xuất chuỗi cụ thể "Tiền hàng + VAT"
                string totalPriceWithVATText = "Tiền hàng + VAT";

                Console.WriteLine($"Setting value at Row: {rowNumber}, Column: {columnIndex}, Total Price + VAT: {totalPriceWithVATText}");

                workSheet.SetValue(rowNumber, columnIndex, totalPriceWithVATText);

                rowNumber++;
            }
            markProcessor.ApplyMarkers(UnknownVariableAction.ReplaceBlank);

            IRange range = workSheet.FindFirst(TMP_ROW, ExcelFindType.Text);

            if (range != null)
            {
                workSheet.DeleteRow(range.Row);
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = Constants.FILTER_EXCEL;
                saveFileDialog.AddExtension = true;
                saveFileDialog.DefaultExt = Constants.FILE_EXT_XLS;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog.FileName;
                    if (!FileCommon.IsFileOpenOrReadOnly(fileName))
                    {
                        workBook.SaveAs(fileName);
                        result = true;
                    }
                }
            }
            workBook.Close();
            engine.Dispose();
            if (result && isPrintPreview)
            {
                PrintExcel(fileName);
            }

            return result;
        }
        private bool OutSimpleReportDoanhThu<T>(List<T> dataSource, Dictionary<string, string> replaceValues, string viewName, bool isPrintPreview, ref string fileName)
        {
            bool result = false;
            MemoryStream stream = GetTemplateStream(viewName);

            if (stream == null)
            {
                return false;
            }
            ExcelEngine engine = new ExcelEngine();
            IWorkbook workBook = engine.Excel.Workbooks.Open(stream);
            workBook.StandardFont = "Arial";

            IWorksheet workSheet = workBook.Worksheets[0];
            ITemplateMarkersProcessor markProcessor = workSheet.CreateTemplateMarkersProcessor();

            if (replaceValues != null && replaceValues.Count > 0)
            {
                foreach (KeyValuePair<string, string> replacer in replaceValues)
                {
                    Replace(workSheet, replacer.Key, replacer.Value);
                }
            }


            IStyle khStyle = workBook.Styles.Add("khStyle");
            khStyle.Font.Bold = true;
            khStyle.Color = Color.FromArgb(208, 204, 204);

            int i = 11;
            //Get danh sach khach hang dat hoa don distinct (select distinct)
            List<THONGK> ds = dataSource.Cast<THONGK>().ToList();
            var maList = (from d in ds
                          select new { d.MaKH, d.TenKH }).Distinct().ToList();
            //Duyet tung khach hang -> insert kh style, lay danh sach hoa don cua nguoi do -> duyet tung cai va insert theo rowstyle
            foreach (var s in maList)
            {
                string r = "A" + i + ":G" + i;
                workSheet.Range[r].CellStyle = khStyle;
                workSheet.Range[r].BorderAround();
                workSheet.Range[r].Merge();

                workSheet["A" + i].Text = "Mã số thuế : " + s.MaKH + " Khách hàng: " + s.TenKH.ToUpper();
                i++;

                List<THONGK> khTKList = ds.Where(a => a.MaKH == s.MaKH).ToList();
                string r2 = "A" + i + ":G" + (i + khTKList.Count() - 1);

                workSheet.Range[r2].CellStyle.Font.FontName = "Arial";
                workSheet.Range[r2].BorderAround();
                workSheet.Range[r2].BorderInside();
                workSheet.Range[r2].WrapText = true;
                workSheet.Range[r2].VerticalAlignment = ExcelVAlign.VAlignCenter;

                foreach (var item in khTKList)
                {
                    workSheet["A" + i].Text = "" + item.NgayLapHD.Value.ToShortDateString();
                    workSheet.Range["A" + i].HorizontalAlignment = ExcelHAlign.HAlignCenter;

                    workSheet["C" + i].Text = "" + item.MaHD;
                    workSheet.Range["C" + i].HorizontalAlignment = ExcelHAlign.HAlignCenter;

                    var test = Math.Floor(item.TongTien.Value);

                    workSheet["D" + i].Text = "" + item.TongTien.Value.ToString("##,#");
                    workSheet.Range["D" + i].HorizontalAlignment = ExcelHAlign.HAlignRight;

                    workSheet["E" + i].Text = "" + item.Thue.Value.ToString("##,#");
                    workSheet.Range["E" + i].HorizontalAlignment = ExcelHAlign.HAlignRight;

                    workSheet["F" + i].Text = "" + item.TongThanhTien.Value.ToString("##,#");
                    workSheet.Range["F" + i].HorizontalAlignment = ExcelHAlign.HAlignRight;

                    i++;
                }

                workSheet.Range[r2].AutofitRows();
            }

            IRange range = workSheet.FindFirst(TMP_ROW, ExcelFindType.Text);

            if (range != null)
            {
                workSheet.DeleteRow(range.Row);
            }

            string url = fileName;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = Constants.FILTER_EXCEL;
                saveFileDialog.AddExtension = true;
                saveFileDialog.DefaultExt = Constants.FILE_EXT_XLS;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog.FileName;
                    url = Path.GetFullPath(fileName);

                    if (!FileCommon.IsFileOpenOrReadOnly(fileName))
                    {
                        workBook.SaveAs(fileName);
                        result = true;
                    }
                }
            }
            workBook.Close();
            engine.Dispose();
            if (result && isPrintPreview)
            {
                PrintExcel(url);
            }

            return result;
        }
        private bool OutSimpleReportDoanhThuSP<T>(List<T> dataSource, Dictionary<string, string> replaceValues, string viewName, bool isPrintPreview, ref string fileName)
        {
            bool result = false;
            MemoryStream stream = GetTemplateStream(viewName);

            if (stream == null)
            {
                return false;
            }
            ExcelEngine engine = new ExcelEngine();
            IWorkbook workBook = engine.Excel.Workbooks.Open(stream);
            workBook.StandardFont = "Arial";

            IWorksheet workSheet = workBook.Worksheets[0];
            ITemplateMarkersProcessor markProcessor = workSheet.CreateTemplateMarkersProcessor();

            if (replaceValues != null && replaceValues.Count > 0)
            {
                foreach (KeyValuePair<string, string> replacer in replaceValues)
                {
                    Replace(workSheet, replacer.Key, replacer.Value);
                }
            }


            IStyle khStyle = workBook.Styles.Add("khStyle");
            khStyle.Font.Bold = true;
            khStyle.Color = Color.FromArgb(208, 204, 204);

            int i = 11;
            //Get danh sach khach hang dat hoa don distinct (select distinct)
            List<DoanhThuSP> ds = dataSource.Cast<DoanhThuSP>().ToList();
            var maList = (from d in ds
                          select new { d.TenHH, d.DonVT }).Distinct().ToList();
            //Duyet tung khach hang -> insert kh style, lay danh sach hoa don cua nguoi do -> duyet tung cai va insert theo rowstyle
            foreach (var s in maList)
            {
                string r = "A" + i + ":K" + i;
                workSheet.Range[r].CellStyle = khStyle;
                workSheet.Range[r].BorderAround();
                workSheet.Range[r].Merge();

                var Cell = workSheet["A" + i].Text = "Tên sản phẩm: " + s.TenHH + " Đơn vị tính: " + s.DonVT;
                i++;

                List<DoanhThuSP> khTKList = ds.Where(a => a.TenHH == s.TenHH).ToList();
                string r2 = "A" + i + ":K" + (i + khTKList.Count() - 1);

                workSheet.Range[r2].CellStyle.Font.FontName = "Arial";
                workSheet.Range[r2].BorderAround();
                workSheet.Range[r2].BorderInside();
                workSheet.Range[r2].WrapText = true;
                workSheet.Range[r2].VerticalAlignment = ExcelVAlign.VAlignCenter;
                workSheet.Range[r2].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;

                foreach (var item in khTKList)
                {
                    workSheet["B" + i].Text = "" + item.MaKH;
                    workSheet.Range["B" + i].HorizontalAlignment = ExcelHAlign.HAlignCenter;

                    workSheet["C" + i].Text = "" + item.NgayLapHD.Value.ToShortDateString();
                    workSheet.Range["C" + i].HorizontalAlignment = ExcelHAlign.HAlignCenter;

                    workSheet["F" + i].Text = "" + item.MaHD;
                    workSheet.Range["F" + i].HorizontalAlignment = ExcelHAlign.HAlignRight;

                    workSheet["G" + i].Text = "" + item.TenKH;
                    workSheet.Range["G" + i].HorizontalAlignment = ExcelHAlign.HAlignRight;

                    workSheet["H" + i].Text = "" + item.DonGia.Value.ToString("##,#");
                    workSheet.Range["H" + i].HorizontalAlignment = ExcelHAlign.HAlignRight;

                    workSheet["I" + i].Text = "" + item.SoLuong.Value.ToString("##,#");
                    workSheet.Range["I" + i].HorizontalAlignment = ExcelHAlign.HAlignRight;

                    workSheet["J" + i].Text = "" + item.ThanhTien.Value.ToString("##,#");
                    workSheet.Range["J" + i].HorizontalAlignment = ExcelHAlign.HAlignRight;
                    i++;
                }

                workSheet.Range[r2].AutofitRows();
            }

            IRange range = workSheet.FindFirst(TMP_ROW, ExcelFindType.Text);

            if (range != null)
            {
                workSheet.DeleteRow(range.Row);
            }

            string url = fileName;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = Constants.FILTER_EXCEL;
                saveFileDialog.AddExtension = true;
                saveFileDialog.DefaultExt = Constants.FILE_EXT_XLS;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog.FileName;
                    url = Path.GetFullPath(fileName);

                    if (!FileCommon.IsFileOpenOrReadOnly(fileName))
                    {
                        workBook.SaveAs(fileName);
                        result = true;
                    }
                }
            }
            workBook.Close();
            engine.Dispose();
            if (result && isPrintPreview)
            {
                PrintExcel(url);
            }

            return result;
        }
        private bool OutSimpleReportKho<T>(List<T> dataSource, Dictionary<string, string> replaceValues, string viewName, bool isPrintPreview, ref string fileName)
        {
            bool result = false;
            MemoryStream stream = GetTemplateStream(viewName);

            if (stream == null)
            {
                return false;
            }
            ExcelEngine engine = new ExcelEngine();
            IWorkbook workBook = engine.Excel.Workbooks.Open(stream);

            IWorksheet workSheet = workBook.Worksheets[0];
            ITemplateMarkersProcessor markProcessor = workSheet.CreateTemplateMarkersProcessor();

            if (replaceValues != null && replaceValues.Count > 0)
            {
                foreach (KeyValuePair<string, string> replacer in replaceValues)
                {
                    Replace(workSheet, replacer.Key, replacer.Value);
                }
            }
            markProcessor.AddVariable(viewName, dataSource);

            markProcessor.ApplyMarkers(UnknownVariableAction.ReplaceBlank);

            IRange range = workSheet.FindFirst(TMP_ROW, ExcelFindType.Text);

            if (range != null)
            {
                workSheet.DeleteRow(range.Row);
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = Constants.FILTER_EXCEL;
                saveFileDialog.AddExtension = true;
                saveFileDialog.DefaultExt = Constants.FILE_EXT_XLS;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog.FileName;
                    if (!FileCommon.IsFileOpenOrReadOnly(fileName))
                    {
                        workBook.SaveAs(fileName);
                        result = true;
                    }
                }
            }
            workBook.Close();
            engine.Dispose();
            if (result && isPrintPreview)
            {
                PrintExcel(fileName);
            }

            return result;
        }
        private bool OutSimpleReportBaoGia<T>(List<T> dataSource, Dictionary<string, string> replaceValues, string viewName, bool isPrintPreview, ref string fileName)
        {
            bool result = false;
            MemoryStream stream = GetTemplateStream(viewName);

            if (stream == null)
            {
                return false;
            }
            ExcelEngine engine = new ExcelEngine();
            IWorkbook workBook = engine.Excel.Workbooks.Open(stream);

            IWorksheet workSheet = workBook.Worksheets[0];
            ITemplateMarkersProcessor markProcessor = workSheet.CreateTemplateMarkersProcessor();

            if (replaceValues != null && replaceValues.Count > 0)
            {
                foreach (KeyValuePair<string, string> replacer in replaceValues)
                {
                    Replace(workSheet, replacer.Key, replacer.Value);
                }
            }
            markProcessor.AddVariable(viewName, dataSource);
            int startRow = 18;
            int rowNumber = startRow;

            foreach (var dataItem in dataSource)
            {
                int columnIndex = 1;
                int serialNumber = rowNumber - startRow + 1;
                Console.WriteLine($"Setting value at Row: {rowNumber}, Column: {columnIndex}, Serial Number: {serialNumber}");

                workSheet.SetValue(rowNumber, columnIndex, serialNumber.ToString());
                rowNumber++;
            }
            
            markProcessor.ApplyMarkers(UnknownVariableAction.ReplaceBlank);

            IRange range = workSheet.FindFirst(TMP_ROW, ExcelFindType.Text);

            if (range != null)
            {
                workSheet.DeleteRow(range.Row);
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = Constants.FILTER_EXCEL;
                saveFileDialog.AddExtension = true;
                saveFileDialog.DefaultExt = Constants.FILE_EXT_XLS;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog.FileName;
                    if (!FileCommon.IsFileOpenOrReadOnly(fileName))
                    {
                        workBook.SaveAs(fileName);
                        result = true;
                    }
                }
            }
            workBook.Close();
            engine.Dispose();
            if (result && isPrintPreview)
            {
                PrintExcel(fileName);
            }

            return result;
        }
        private bool OutGroupReport<T>(List<IGrouping<int, T>> groupData, Dictionary<string, string> replaceValues,
                                        string groupBox, string viewName, bool isPrintPreview, ref string fileName, string groupName)
        {
            string file = string.Empty;
            bool result = false;

            // Get template stream
            MemoryStream stream = GetTemplateStream(viewName);

            // Check if data is null
            if (stream == null)
            {
                return false;
            }

            // Create excel engine
            ExcelEngine engine = new ExcelEngine();
            IWorkbook workBook = engine.Excel.Workbooks.Open(stream);

            // Get sheets
            IWorksheet workSheet = workBook.Worksheets[0];
            IWorksheet tmpSheet = workBook.Worksheets.Create(TMP_SHEET);

            // Copy template of group to temporary sheet
            IRange range = workSheet.Range[groupBox];
            int rowCount = range.Rows.Count();
            IRange tmpRange = tmpSheet.Range[groupBox];
            range.CopyTo(tmpRange, ExcelCopyRangeOptions.All);

            // Replace value
            if (replaceValues != null && replaceValues.Count > 0)
            {
                // Find and replace values
                foreach (KeyValuePair<string, string> replacer in replaceValues)
                {
                    Replace(workSheet, replacer.Key, replacer.Value);
                }
            }

            // Loop data
            for (int i = groupData.Count - 1; i >= 0; i--)
            {
                IGrouping<int, T> group = groupData[i];
                List<T> listMember = group.ToList();

                // Create template maker
                ITemplateMarkersProcessor markProcess = workSheet.CreateTemplateMarkersProcessor();

                // Fill data into templates
                if (listMember.Count > 0)
                {
                    //markProcess.AddVariable(groupName,CacheData.GetTenChucDanh(group.Key));
                    //  Replace(workSheet, groupName, CacheData.GetTenChucDanh(group.Key));
                    markProcess.AddVariable(viewName, listMember);
                    markProcess.ApplyMarkers(UnknownVariableAction.ReplaceBlank);
                }
                else
                {
                    markProcess.AddVariable(groupName, string.Empty);
                    markProcess.ApplyMarkers(UnknownVariableAction.Skip);
                }

                // Insert template rows
                if (i > 0)
                {
                    workSheet.InsertRow(range.Row, rowCount);
                    tmpRange.CopyTo(workSheet.Range[groupBox], ExcelCopyRangeOptions.All);
                }
            }

            // Find row
            IRange[] rowSet = workSheet.FindAll(TMP_ROW, ExcelFindType.Text);

            //// Delete row
            for (int i = rowSet.Count() - 1; i >= 0; i--)
            {
                range = rowSet[i];

                // Delete
                if (range != null)
                {
                    workSheet.DeleteRow(range.Row);
                }
            }


            fileName = Path.GetTempFileName() + Constants.FILE_EXT_XLS;


            // Remove temporary sheet
            workBook.Worksheets.Remove(tmpSheet);

            // Output file
            if (!FileCommon.IsFileOpenOrReadOnly(fileName))
            {
                workBook.SaveAs(fileName);
                result = true;
            }

            // Close
            workBook.Close();
            engine.Dispose();

            // Print preview
            if (result && isPrintPreview)
            {
                PrintExcel(fileName);
                File.Delete(fileName);
            }

            return result;
        }
        private bool OutReport<T>(List<IGrouping<string, T>> groupData, Dictionary<string, string> replaceValues,
                                    string groupBox, string viewName, bool isPrintPreview, string fileName)
        {
            string file = string.Empty;
            bool result = false;

            // Get template stream
            MemoryStream stream = GetTemplateStream(viewName);

            // Check if data is null
            if (stream == null)
            {
                return false;
            }

            // Create excel engine
            ExcelEngine engine = new ExcelEngine();
            IWorkbook workBook = engine.Excel.Workbooks.Open(stream);

            // Get sheets
            IWorksheet workSheet = workBook.Worksheets[0];
            IWorksheet tmpSheet = workBook.Worksheets.Create(TMP_SHEET);

            // Copy template of group to temporary sheet
            IRange range = workSheet.Range[groupBox];
            int rowCount = range.Rows.Count();
            IRange tmpRange = tmpSheet.Range[groupBox];
            range.CopyTo(tmpRange, ExcelCopyRangeOptions.All);

            // Replace value
            if (replaceValues != null && replaceValues.Count > 0)
            {
                // Find and replace values
                foreach (KeyValuePair<string, string> replacer in replaceValues)
                {
                    Replace(workSheet, replacer.Key, replacer.Value);
                }
            }

            // Loop data
            for (int i = groupData.Count - 1; i >= 0; i--)
            {
                IGrouping<string, T> group = groupData[i];
                List<T> listMember = group.ToList();

                // Create template maker
                ITemplateMarkersProcessor markProcess = workSheet.CreateTemplateMarkersProcessor();

                // Fill data into templates
                if (listMember.Count > 0)
                {
                    markProcess.AddVariable(viewName, listMember);
                    markProcess.ApplyMarkers();
                }
                else
                {
                    markProcess.ApplyMarkers(UnknownVariableAction.Skip);
                }

                // Insert template rows
                if (i > 0)
                {
                    workSheet.InsertRow(range.Row, rowCount);
                    tmpRange.CopyTo(workSheet.Range[groupBox], ExcelCopyRangeOptions.All);
                }
            }

            // Find row
            IRange[] rowSet = workSheet.FindAll(TMP_ROW, ExcelFindType.Text);

            // Delete row
            for (int i = rowSet.Count() - 1; i >= 0; i--)
            {
                range = rowSet[i];

                // Delete
                if (range != null)
                {
                    workSheet.DeleteRow(range.Row);
                }
            }

            // Get file name
            if (isPrintPreview)
            {
                file = Path.GetTempFileName() + Constants.FILE_EXT_XLS;
            }
            else
            {
                file = fileName;
            }

            // Remove temporary sheet
            workBook.Worksheets.Remove(tmpSheet);

            // Output file
            if (!FileCommon.IsFileOpenOrReadOnly(file))
            {
                workBook.SaveAs(file);
                result = true;
            }

            // Close
            workBook.Close();
            engine.Dispose();

            // Print preview
            if (result && isPrintPreview)
            {
                PrintExcel(file);
                File.Delete(file);
            }

            return result;
        }
        private MemoryStream GetTemplateStream(string viewName)
        {
            MemoryStream stream = null;
            byte[] arrByte = new byte[0];

            //Create Temp Folder if it does not exist
            if (!Directory.Exists(Global.AppPath + Constants.FOLDER_TEMPLATES))
            {
                Directory.CreateDirectory(Global.AppPath + Constants.FOLDER_TEMPLATES);
            }
            switch (viewName)
            {
                #region ---- Lấy file report----
                case T_BieuMau:
                    arrByte = File.ReadAllBytes("BieuMau.xls").ToArray();
                    break;

                case T_DanhMucKhoa:
                    arrByte = File.ReadAllBytes("HoaDon.xls").ToArray();
                    break;
                case T_BCDoanhThuTheoSP:
                    arrByte = File.ReadAllBytes("DoanhThuSP.xls").ToArray();
                    break;
                case T_PhieuNhapKho:
                    arrByte = File.ReadAllBytes("PhieuNhap.xls").ToArray();
                    break;
                case T_PhieuXuatKho:
                    arrByte = File.ReadAllBytes("PhieuXuat.xls").ToArray();
                    break;
                case T_PhieuThanhToan:
                    arrByte = File.ReadAllBytes("PhieuThanhToan.xls").ToArray();
                    break;
                case T_DonDatHang:
                    arrByte = File.ReadAllBytes("DonDatHang.xls").ToArray();
                    break;
                case T_CongNo:
                    arrByte = File.ReadAllBytes("CongNo.xls").ToArray();
                    break;
                case T_DoanhThu:
                    arrByte = File.ReadAllBytes("DoanhThu.xls").ToArray();
                    break;
                case T_Kho:
                    arrByte = File.ReadAllBytes("Kho.xls").ToArray();
                    break;
                case T_BaoGia:
                    arrByte = File.ReadAllBytes("BaoGia.xls").ToArray();
                    break;
                case T_PhieuNhapHang:
                    arrByte = File.ReadAllBytes("PhieuNhapKho.xls").ToArray();
                    break;
                case T_PhieuXuatHang:
                    arrByte = File.ReadAllBytes("PhieuXuatKho.xls").ToArray();
                    break;
                    #endregion
            }
            // Get stream
            if (arrByte.Count() > 0)
            {
                stream = new MemoryStream(arrByte);
            }

            return stream;
        }

        private bool ReplaceDataWorkSheet(Dictionary<string, string> replaceValues, string viewName, bool isPrintPreview, ref string fileName)
        {
            string file = string.Empty;
            bool result = false;
            MemoryStream stream = GetTemplateStream(viewName);
            if (stream == null)
            {
                return false;
            }
            ExcelEngine engine = new ExcelEngine();
            IWorkbook workBook = engine.Excel.Workbooks.Open(stream);
            IWorksheet workSheet = workBook.Worksheets[0];
            ITemplateMarkersProcessor markProcessor = workSheet.CreateTemplateMarkersProcessor();
            if (replaceValues != null && replaceValues.Count > 0)
            {
                foreach (KeyValuePair<string, string> replacer in replaceValues)
                {
                    Replace(workSheet, replacer.Key, replacer.Value);
                }
            }
            file = Path.GetTempFileName() + Constants.FILE_EXT_XLS;
            fileName = file;
            if (!FileCommon.IsFileOpenOrReadOnly(file))
            {
                workBook.SaveAs(file);
                result = true;
            }
            workBook.Close();
            engine.Dispose();
            if (result && isPrintPreview)
            {
                PrintExcel(file);
                File.Delete(file);
            }
            return result;
        }
        #endregion


        public bool ExportHoaDon(List<CTHD> dataSource, ref string fileName, bool isPrintPreview, string MaHD, string MaSoThue, string Email, string TenKH, string MaSoThueKH, string DiaChiKH, string TongThanhTien, string VAT, string TongThanhToan, string DVB, string HinhThuctt)
        {
            if (dataSource == null || (dataSource != null && dataSource.Count == 0))
            {
                return false;
            }
            Dictionary<string, string> replacer = new Dictionary<string, string>();
            ExcelEngine engine = new ExcelEngine();
            BuildReplacerHoaDon(ref replacer, MaHD, MaSoThue, Email, TenKH, MaSoThueKH, DiaChiKH, TongThanhTien, VAT, TongThanhToan, DVB, HinhThuctt);
            return OutSimpleReportHoaDon(dataSource, replacer, "DanhMucHoaDon", isPrintPreview, ref fileName);

        }

        public bool ExportPhieuNhap(List<CTPNCTiet> dataSource, ref string fileName, bool isPrintPreview, string TenDonVi, string DiaChi, string Email, string SoLenhNhap, string TongCong)
        {
            if (dataSource == null || (dataSource != null && dataSource.Count == 0))
            {
                return false;
            }
            Dictionary<string, string> replacer = new Dictionary<string, string>();
            ExcelEngine engine = new ExcelEngine();
            BuildReplacerPhieuNhap(ref replacer, TenDonVi, DiaChi, Email, SoLenhNhap, TongCong);
            return OutSimpleReportPhieuNhap(dataSource, replacer, "PhieuNhapKho", isPrintPreview, ref fileName);

        }

        public bool ExportPhieuXuat(List<CTPXCTiet> dataSource, ref string fileName, bool isPrintPreview, string TenDonVi, string DiaChi, string Email, string SoLenhXuat, string TongCong)
        {
            if (dataSource == null || (dataSource != null && dataSource.Count == 0))
            {
                return false;
            }
            Dictionary<string, string> replacer = new Dictionary<string, string>();
            ExcelEngine engine = new ExcelEngine();
            BuildReplacerPhieuXuat(ref replacer, TenDonVi, DiaChi, Email, SoLenhXuat, TongCong);
            return OutSimpleReportPhieuXuat(dataSource, replacer, "PhieuXuatKho", isPrintPreview, ref fileName);

        }
        public bool ExportPhieuThanhToan(ref string fileName, bool isPrintPreview, string MaPTT, string MaHD, string TenKH, string MaSoThue, string DiaChi, string TongTienTT, string KHThanhToan, string NgayLap)
        {
            Dictionary<string, string> replacer = new Dictionary<string, string>();
            ExcelEngine engine = new ExcelEngine();
            BuildReplacerPhieuThanhToan(ref replacer, MaPTT, MaHD, TenKH, MaSoThue, DiaChi, TongTienTT, KHThanhToan, NgayLap);
            return OutSimpleReportPhieuThanhToan(replacer, "PhieuThanhToan", isPrintPreview, ref fileName);

        }
        public bool ExportDonDatHang(List<CTDDHCTiet> dataSource, ref string fileName, bool isPrintPreview, string MaDDH, string MaSoThue, string TenKH, string DiaChi, string TongSL, string ThanhTien, string NgayDat)
        {
            if (dataSource == null || (dataSource != null && dataSource.Count == 0))
            {
                return false;
            }
            Dictionary<string, string> replacer = new Dictionary<string, string>();
            ExcelEngine engine = new ExcelEngine();
            BuildReplacerDonDatHang(ref replacer, MaDDH, MaSoThue, TenKH, DiaChi, TongSL, ThanhTien, NgayDat);
            return OutSimpleReportDonDatHang(dataSource, replacer, "DonDatHang", isPrintPreview, ref fileName);

        }
        public bool ExportCongNo(List<CONGN> dataSource, ref string fileName, bool isPrintPreview, string NgayLap)
        {
            if (dataSource == null || (dataSource != null && dataSource.Count == 0))
            {
                return false;
            }
            Dictionary<string, string> replacer = new Dictionary<string, string>();
            ExcelEngine engine = new ExcelEngine();
            BuildReplacerCongNo(ref replacer, NgayLap);
            return OutSimpleReportCongNo(dataSource, replacer, "CongNo", isPrintPreview, ref fileName);

        }
        public bool ExportDoanhThu(List<THONGK> dataSource, ref string fileName, bool isPrintPreview, string NgayBatDau, string NgayKetThuc, string tthang, string ttthue, string tongtt)
        {
            if (dataSource == null || (dataSource != null && dataSource.Count == 0))
            {
                return false;
            }
            Dictionary<string, string> replacer = new Dictionary<string, string>();
            ExcelEngine engine = new ExcelEngine();
            BuildReplacerDoanhThu(ref replacer, NgayBatDau, NgayKetThuc, tthang, ttthue, tongtt);
            return OutSimpleReportDoanhThu(dataSource, replacer, "DoanhThu", isPrintPreview, ref fileName);

        }
        public bool ExportKho(List<KhoSL> dataSource, ref string fileName, bool isPrintPreview, string NgayBatDau, string NgayKetThuc)
        {
            if (dataSource == null || (dataSource != null && dataSource.Count == 0))
            {
                return false;
            }
            Dictionary<string, string> replacer = new Dictionary<string, string>();
            ExcelEngine engine = new ExcelEngine();
            BuildReplacerKho(ref replacer, NgayBatDau, NgayKetThuc);
            return OutSimpleReportKho(dataSource, replacer, "Kho", isPrintPreview, ref fileName);

        }
        public bool ExportBaoGia(List<CTBGCTiet> dataSource, ref string fileName, bool isPrintPreview, string MaBG, string TenKH)
        {
            if (dataSource == null || (dataSource != null && dataSource.Count == 0))
            {
                return false;
            }
            Dictionary<string, string> replacer = new Dictionary<string, string>();
            ExcelEngine engine = new ExcelEngine();
            BuildReplacerBaoGia(ref replacer, MaBG, TenKH);
            return OutSimpleReportBaoGia(dataSource, replacer, "BaoGia", isPrintPreview, ref fileName);

        }
        public bool ExportPhieuNhapHang(List<CTPNHCTiet> dataSource, ref string fileName, bool isPrintPreview, string TenDonVi, string DiaChi, string Email, string SoLenhNhap, string DonViKH, string DiaChiKH, string MaST, string NgayGiao, string TongTT, string VAT, string TongThanhToan)
        {
            if (dataSource == null || (dataSource != null && dataSource.Count == 0))
            {
                return false;
            }
            Dictionary<string, string> replacer = new Dictionary<string, string>();
            ExcelEngine engine = new ExcelEngine();
            BuildReplacerPhieuNhapHang(ref replacer, TenDonVi, DiaChi, Email, SoLenhNhap, DonViKH, DiaChiKH, MaST, NgayGiao, TongTT, VAT, TongThanhToan);
            return OutSimpleReportPhieuNhapHang(dataSource, replacer, "PhieuNhapHang", isPrintPreview, ref fileName);

        }

        public bool ExportPhieuXuatHang(List<CTPXHCTiet> dataSource, ref string fileName, bool isPrintPreview, string TenDonVi, string DiaChi, string Email, string SoLenhXuat, string DonViKH, string DiaChiKH, string MaST, string NgayGiao, string TongTT, string VAT, string TongThanhToan)
        {
            if (dataSource == null || (dataSource != null && dataSource.Count == 0))
            {
                return false;
            }
            Dictionary<string, string> replacer = new Dictionary<string, string>();
            ExcelEngine engine = new ExcelEngine();
            BuildReplacerPhieuNhapHang(ref replacer, TenDonVi, DiaChi, Email, SoLenhXuat, DonViKH, DiaChiKH, MaST, NgayGiao, TongTT, VAT, TongThanhToan);
            return OutSimpleReportPhieuNhapHang(dataSource, replacer, "PhieuXuatHang", isPrintPreview, ref fileName);

        }
        public bool ExportDoanhThuSP(List<DoanhThuSP> dataSource, ref string fileName, bool isPrintPreview, string NgayBatDau, string NgayKetThuc, string DonGia, string tt)
        {
            if (dataSource == null || (dataSource != null && dataSource.Count == 0))
            {
                return false;
            }
            Dictionary<string, string> replacer = new Dictionary<string, string>();
            ExcelEngine engine = new ExcelEngine();
            BuildReplacerDoanhThuSP(ref replacer, NgayBatDau, NgayKetThuc, DonGia, tt);
            return OutSimpleReportDoanhThuSP(dataSource, replacer, "DoanhThuSP", isPrintPreview, ref fileName);

        }
        #endregion
    }
}
