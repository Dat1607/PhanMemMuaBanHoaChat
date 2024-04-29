using BLL_DAL;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools
{
    public class WordExport
    {
        #region ---- Constants & Enum -----


        private const string FILE_QUYETDINHKHENTHUONG = "BM11";


        #endregion

        #region --- Member Variables ----

        private bool _IsPringPriview = false;

        #endregion

        #region --- Private medthods ---

        private void PrinPriview(string fileToPrint)
        {
            object missing = System.Type.Missing;
            object objFile = fileToPrint;
            object readOnly = true;
            object addToRecentOpen = false;

            Microsoft.Office.Interop.Word._Application wordApplication = new Microsoft.Office.Interop.Word.Application();
            try
            {
                Microsoft.Office.Interop.Word._Document wordDocument = wordApplication.Documents.Open(ref objFile, ref missing, ref readOnly, ref addToRecentOpen);

                wordApplication.Options.SaveNormalPrompt = false;

                if (wordDocument != null)
                {
                    wordApplication.Visible = true;
                    wordDocument.PrintPreview();
                    wordDocument.Activate();
                    while (!_IsPringPriview)
                    {
                        wordDocument.ActiveWindow.View.Magnifier = true;
                        Thread.Sleep(500);
                    }

                    wordDocument.Close(ref missing, ref missing, ref missing);
                    wordDocument = null;
                }
            }
            catch
            {
            }
        }
        private void WordExport_DocumentBeforeClose(Microsoft.Office.Interop.Word.Document Doc, ref bool Cancel)
        {
            _IsPringPriview = false;
        }
        private void Merge(string[] filesToMerge, string outputFilename, bool insertPageBreaks)
        {
            string fileTempate = Global.AppPath + Constants.FOLDER_TEMPLATES +
                                 Constants.CHAR_FLASH + Constants.FILE_NORMAL_DOT;
            Merge(filesToMerge, outputFilename, insertPageBreaks, fileTempate);
        }

        private void Merge(string[] filesToMerge, string outputFilename, bool insertPageBreaks, string documentTemplate)
        {
            object defaultTemplate = documentTemplate;
            object missing = System.Type.Missing;
            object pageBreak = Microsoft.Office.Interop.Word.WdBreakType.wdPageBreak;
            object outputFile = outputFilename;

            Microsoft.Office.Interop.Word._Application wordApplication = new Microsoft.Office.Interop.Word.Application();
            if (filesToMerge.Count() == 1)
                pageBreak = false;
            try
            {
                Microsoft.Office.Interop.Word._Document wordDocument = wordApplication.Documents.Add(ref defaultTemplate, ref missing, ref missing, ref missing);

                Microsoft.Office.Interop.Word.Selection selection = wordApplication.Selection;

                int index = 0;

                foreach (string file in filesToMerge)
                {
                    selection.InsertFile(file, ref missing, ref missing, ref missing, ref missing);

                    if (insertPageBreaks && index != filesToMerge.Count() - 1)
                    {
                        selection.InsertBreak(ref pageBreak);
                    }

                    index++;
                }

                wordDocument.SaveAs(ref outputFile, ref missing, ref missing, ref missing, ref missing,
                                     ref missing, ref missing, ref missing, ref missing, ref missing,
                                     ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

                // Clean up!
                wordDocument.Close(ref missing, ref missing, ref missing);
                wordDocument = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                wordApplication.Quit(ref missing, ref missing, ref missing);
            }
        }
        private void PageSetup(ref WordDocument document)
        {
            foreach (WSection section in document.Sections)
            {
                section.PageSetup.Margins.Top = 72f;
                section.PageSetup.Margins.Bottom = 90f;
                section.PageSetup.Margins.Left = 72f;
                section.PageSetup.Margins.Right = 72f;

                section.PageSetup.HeaderDistance = 1;
                section.PageSetup.FooterDistance = 1;

                section.PageSetup.PageSize = PageSize.A4;

                section.PageSetup.Orientation = PageOrientation.Landscape;
            }
        }

        #endregion

        public bool XuatHoaDon(string pNgay, string pThang, string pNam, string pMaHD, string pTenKH, string pDiaChi, string pMaSoThue, string pTongThanhTien, string pVAT, string pTongThanhToan, string pHinhThucThanhToan, List<string> pMaHH, List<string> pTenHH, List<int?> pSoLuong, List<float?> pDonGia, List<float?> pThanhTien)
        {
            CultureInfo vietnam = new CultureInfo(1066);
            NumberFormatInfo vnfi = vietnam.NumberFormat;
            vnfi.CurrencySymbol = Constants.VN_UNIT;
            vnfi.CurrencyDecimalSeparator = Constants.CHAR_COMMA;
            vnfi.CurrencyDecimalDigits = 0;

            if (!Directory.Exists(Global.AppPath + Constants.FOLDER_TEMP))
            {
                Directory.CreateDirectory(Global.AppPath + Constants.FOLDER_TEMP);
            }

            string fileBoNhiem = string.Empty;

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Word Documents (*.docx)|*.docx";
                saveFileDialog.DefaultExt = "docx";
                saveFileDialog.AddExtension = true;
                saveFileDialog.InitialDirectory = Global.AppPath + Constants.FOLDER_TEMP;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileBoNhiem = saveFileDialog.FileName;

                    try
                    {
                        using (MemoryStream mStream = new MemoryStream(File.ReadAllBytes("HoaDon.docx")))
                        {
                            WordDocument document = new WordDocument(mStream);
                            string[] fields = new string[] { "Ngay", "Thang", "Nam", "MaHD", "TenKH", "DiaChi", "MaSoThue", "TongThanhTien", "VAT", "TongThanhToan", "HinhThucThanhToan", };
                            string[] values = new string[] { pNgay, pThang, pNam, pMaHD, pTenKH, pDiaChi, pMaSoThue, pTongThanhTien, pVAT, pTongThanhToan, pHinhThucThanhToan };


                            document.MailMerge.Execute(fields, values);

                            // MaHangHoa
                            WTable table = document.LastSection.Tables[0] as WTable;

                            int requiredRows = pMaHH.Count + 2;
                            while (table.Rows.Count < requiredRows)
                            {
                                table.AddRow(true);
                            }

                            for (int rowIndex = 2; rowIndex < requiredRows; rowIndex++)
                            {
                                WTableRow row = table.Rows[rowIndex];
                                row.Cells[0].AddParagraph().AppendText(pMaHH[rowIndex - 2]);
                            }
                            // TenHangHoa
                            WTable table1 = document.LastSection.Tables[0] as WTable;

                            int requiredRows1 = pTenHH.Count + 2;
                            while (table1.Rows.Count < requiredRows1)
                            {
                                table1.AddRow(true);
                            }

                            for (int rowIndex = 2; rowIndex < requiredRows1; rowIndex++)
                            {
                                WTableRow row = table1.Rows[rowIndex];
                                row.Cells[1].AddParagraph().AppendText(pTenHH[rowIndex - 2]);
                            }
                            // SoLuong
                            WTable table2 = document.LastSection.Tables[0] as WTable;

                            int requiredRows2 = pSoLuong.Count + 2;
                            while (table2.Rows.Count < requiredRows2)
                            {
                                table2.AddRow(true);
                            }

                            for (int rowIndex = 2; rowIndex < requiredRows2; rowIndex++)
                            {
                                WTableRow row = table2.Rows[rowIndex];
                                string sl = pSoLuong[rowIndex - 2]?.ToString() ?? "";
                                row.Cells[2].AddParagraph().AppendText(sl);
                            }
                            // DonGia
                            WTable table3 = document.LastSection.Tables[0] as WTable;

                            int requiredRows3 = pDonGia.Count + 2;
                            while (table3.Rows.Count < requiredRows3)
                            {
                                table3.AddRow(true);
                            }

                            for (int rowIndex = 2; rowIndex < requiredRows3; rowIndex++)
                            {
                                WTableRow row = table2.Rows[rowIndex];
                                string dg = pDonGia[rowIndex - 2]?.ToString() ?? "";

                                var paragraph = new WParagraph(document);
                                if (float.TryParse(dg, out float parsedValue))
                                {
                                    paragraph.AppendText(parsedValue.ToString("#,##0"));
                                }
                                else
                                {
                                    paragraph.AppendText(dg);
                                }
                                row.Cells[3].Paragraphs.Add(paragraph);
                            }
                            // ThanhTien
                            WTable table4 = document.LastSection.Tables[0] as WTable;

                            int requiredRows4 = pThanhTien.Count + 2;
                            while (table4.Rows.Count < requiredRows4)
                            {
                                table4.AddRow(true);
                            }

                            for (int rowIndex = 2; rowIndex < requiredRows4; rowIndex++)
                            {
                                WTableRow row = table4.Rows[rowIndex];
                                string tt = pThanhTien[rowIndex - 2]?.ToString() ?? "";

                                var paragraph = new WParagraph(document);
                                if (float.TryParse(tt, out float parsedValue))
                                {
                                    paragraph.AppendText(parsedValue.ToString("#,##0"));
                                }
                                else
                                {
                                    paragraph.AppendText(tt);
                                }
                                paragraph.ParagraphFormat.RightIndent = 0;
                                row.Cells[4].Paragraphs.Add(paragraph);
                            }


                            document.Save(fileBoNhiem, FormatType.Docx);
                            this.PrinPriview(fileBoNhiem);
                            document.Close();
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return false;
        }


        public bool XuatPhieuNhap(string pNgay, string pThang, string pNam, string pSoLenhNhap, string pDonViKH, string pTenKH, string pSDT, string pBienSXGH, string pTongCong, List<string> pMaHH, List<string> pTenHH, List<int?> pSoLuong, List<string> pDVT, List<double?> pTrongLuong)
        {
            CultureInfo vietnam = new CultureInfo(1066);
            NumberFormatInfo vnfi = vietnam.NumberFormat;
            vnfi.CurrencySymbol = Constants.VN_UNIT;
            vnfi.CurrencyDecimalSeparator = Constants.CHAR_COMMA;
            vnfi.CurrencyDecimalDigits = 0;

            if (!Directory.Exists(Global.AppPath + Constants.FOLDER_TEMP))
            {
                Directory.CreateDirectory(Global.AppPath + Constants.FOLDER_TEMP);
            }

            string fileBoNhiem = string.Empty;

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Word Documents (*.docx)|*.docx";
                saveFileDialog.DefaultExt = "docx";
                saveFileDialog.AddExtension = true;
                saveFileDialog.InitialDirectory = Global.AppPath + Constants.FOLDER_TEMP;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileBoNhiem = saveFileDialog.FileName;

                    try
                    {
                        using (MemoryStream mStream = new MemoryStream(File.ReadAllBytes("PhieuNhap.docx")))
                        {
                            WordDocument document = new WordDocument(mStream);
                            string[] fields = new string[] { "Ngay", "Thang", "Nam", "SoLenhNhap", "DonViKH", "TenKH", "BienSXGH", "SDT", "TongCong", };
                            string[] values = new string[] { pNgay, pThang, pNam, pSoLenhNhap, pDonViKH, pTenKH, pBienSXGH, pSDT, pTongCong };


                            document.MailMerge.Execute(fields, values);

                            // MaHangHoa
                            WTable table = document.LastSection.Tables[0] as WTable;

                            int requiredRows = pMaHH.Count+2;
                            while (table.Rows.Count < requiredRows)
                            {
                                table.AddRow(true);
                            }

                            for (int rowIndex = 2; rowIndex < requiredRows; rowIndex++)
                            {
                                WTableRow row = table.Rows[rowIndex];
                                row.Cells[0].AddParagraph().AppendText(pMaHH[rowIndex - 2]);
                            }
                            // TenHangHoa
                            WTable table1 = document.LastSection.Tables[0] as WTable;

                            int requiredRows1 = pTenHH.Count + 2;
                            while (table1.Rows.Count < requiredRows1)
                            {
                                table1.AddRow(true);
                            }

                            for (int rowIndex = 2; rowIndex < requiredRows1; rowIndex++)
                            {
                                WTableRow row = table1.Rows[rowIndex];
                                row.Cells[1].AddParagraph().AppendText(pTenHH[rowIndex - 2]);
                            }
                            // SoLuong
                            WTable table2 = document.LastSection.Tables[0] as WTable;

                            int requiredRows2 = pSoLuong.Count + 2;
                            while (table2.Rows.Count < requiredRows2)
                            {
                                table2.AddRow(true);
                            }

                            for (int rowIndex = 2; rowIndex < requiredRows2; rowIndex++)
                            {
                                WTableRow row = table2.Rows[rowIndex];
                                string sl = pSoLuong[rowIndex - 2]?.ToString() ?? "";
                                row.Cells[3].AddParagraph().AppendText(sl);
                            }
                            // DVT
                            WTable table3 = document.LastSection.Tables[0] as WTable;

                            int requiredRows3 = pDVT.Count + 2;
                            while (table3.Rows.Count < requiredRows3)
                            {
                                table3.AddRow(true);
                            }

                            for (int rowIndex = 2; rowIndex < requiredRows3; rowIndex++)
                            {
                                WTableRow row = table3.Rows[rowIndex];
                                row.Cells[2].AddParagraph().AppendText(pDVT[rowIndex - 2]);
                            }
                            // ThanhTien
                            WTable table4 = document.LastSection.Tables[0] as WTable;

                            int requiredRows4 = pTrongLuong.Count + 2;
                            while (table4.Rows.Count < requiredRows4)
                            {
                                table4.AddRow(true);
                            }

                            for (int rowIndex = 2; rowIndex < requiredRows4; rowIndex++)
                            {
                                WTableRow row = table4.Rows[rowIndex];
                                string tl = pTrongLuong[rowIndex - 2]?.ToString() ?? "";

                                var paragraph = new WParagraph(document);
                                if (double.TryParse(tl, out double parsedValue))
                                {
                                    paragraph.AppendText(parsedValue.ToString("#,##0"));
                                }
                                else
                                {
                                    paragraph.AppendText(tl);
                                }
                                paragraph.ParagraphFormat.RightIndent = 0;
                                row.Cells[4].Paragraphs.Add(paragraph);
                            }


                            document.Save(fileBoNhiem, FormatType.Docx);
                            this.PrinPriview(fileBoNhiem);
                            document.Close();
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return false;
        }


        public bool XuatPhieuXuat(string pNgay, string pThang, string pNam, string pSoLenhXuat, string pDonViKH, string pTenKH, string pSDT, string pBienSXGH, string pTongCong, List<string> pMaHH, List<string> pTenHH, List<int?> pSoLuong, List<string> pDVT, List<double?> pTrongLuong)
        {
            CultureInfo vietnam = new CultureInfo(1066);
            NumberFormatInfo vnfi = vietnam.NumberFormat;
            vnfi.CurrencySymbol = Constants.VN_UNIT;
            vnfi.CurrencyDecimalSeparator = Constants.CHAR_COMMA;
            vnfi.CurrencyDecimalDigits = 0;

            if (!Directory.Exists(Global.AppPath + Constants.FOLDER_TEMP))
            {
                Directory.CreateDirectory(Global.AppPath + Constants.FOLDER_TEMP);
            }

            string fileBoNhiem = string.Empty;

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Word Documents (*.docx)|*.docx";
                saveFileDialog.DefaultExt = "docx";
                saveFileDialog.AddExtension = true;
                saveFileDialog.InitialDirectory = Global.AppPath + Constants.FOLDER_TEMP;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileBoNhiem = saveFileDialog.FileName;

                    try
                    {
                        using (MemoryStream mStream = new MemoryStream(File.ReadAllBytes("PhieuXuat.docx")))
                        {
                            WordDocument document = new WordDocument(mStream);
                            string[] fields = new string[] { "Ngay", "Thang", "Nam", "SoLenhXuat", "DonViKH", "TenKH", "BienSXGH", "SDT", "TongCong", };
                            string[] values = new string[] { pNgay, pThang, pNam, pSoLenhXuat, pDonViKH, pTenKH, pBienSXGH, pSDT, pTongCong };


                            document.MailMerge.Execute(fields, values);

                            // MaHangHoa
                            WTable table = document.LastSection.Tables[0] as WTable;

                            int requiredRows = pMaHH.Count + 2;
                            while (table.Rows.Count < requiredRows)
                            {
                                table.AddRow(true);
                            }

                            for (int rowIndex = 2; rowIndex < requiredRows; rowIndex++)
                            {
                                WTableRow row = table.Rows[rowIndex];
                                row.Cells[0].AddParagraph().AppendText(pMaHH[rowIndex - 2]);
                            }
                            // TenHangHoa
                            WTable table1 = document.LastSection.Tables[0] as WTable;

                            int requiredRows1 = pTenHH.Count + 2;
                            while (table1.Rows.Count < requiredRows1)
                            {
                                table1.AddRow(true);
                            }

                            for (int rowIndex = 2; rowIndex < requiredRows1; rowIndex++)
                            {
                                WTableRow row = table1.Rows[rowIndex];
                                row.Cells[1].AddParagraph().AppendText(pTenHH[rowIndex - 2]);
                            }
                            // SoLuong
                            WTable table2 = document.LastSection.Tables[0] as WTable;

                            int requiredRows2 = pSoLuong.Count + 2;
                            while (table2.Rows.Count < requiredRows2)
                            {
                                table2.AddRow(true);
                            }

                            for (int rowIndex = 2; rowIndex < requiredRows2; rowIndex++)
                            {
                                WTableRow row = table2.Rows[rowIndex];
                                string sl = pSoLuong[rowIndex - 2]?.ToString() ?? "";
                                row.Cells[3].AddParagraph().AppendText(sl);
                            }
                            // DVT
                            WTable table3 = document.LastSection.Tables[0] as WTable;

                            int requiredRows3 = pDVT.Count + 2;
                            while (table3.Rows.Count < requiredRows3)
                            {
                                table3.AddRow(true);
                            }

                            for (int rowIndex = 2; rowIndex < requiredRows3; rowIndex++)
                            {
                                WTableRow row = table3.Rows[rowIndex];
                                row.Cells[2].AddParagraph().AppendText(pDVT[rowIndex - 2]);
                            }
                            // ThanhTien
                            WTable table4 = document.LastSection.Tables[0] as WTable;

                            int requiredRows4 = pTrongLuong.Count + 2;
                            while (table4.Rows.Count < requiredRows4)
                            {
                                table4.AddRow(true);
                            }

                            for (int rowIndex = 2; rowIndex < requiredRows4; rowIndex++)
                            {
                                WTableRow row = table4.Rows[rowIndex];
                                string tl = pTrongLuong[rowIndex - 2]?.ToString() ?? "";

                                var paragraph = new WParagraph(document);
                                if (double.TryParse(tl, out double parsedValue))
                                {
                                    paragraph.AppendText(parsedValue.ToString("#,##0"));
                                }
                                else
                                {
                                    paragraph.AppendText(tl);
                                }
                                paragraph.ParagraphFormat.RightIndent = 0;
                                row.Cells[4].Paragraphs.Add(paragraph);
                            }


                            document.Save(fileBoNhiem, FormatType.Docx);
                            this.PrinPriview(fileBoNhiem);
                            document.Close();

                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return false;
        }
        public bool XuatPhieuThanhToan(string pNgay, string pThang, string pNam, string pMaPTT, string pMaHD, string pTenKH, string pMaSoThue, string pDiaChi, string pTongTienTT, string pKHThanhToan, string pNgayLap)
        {
            CultureInfo vietnam = new CultureInfo(1066);
            NumberFormatInfo vnfi = vietnam.NumberFormat;
            vnfi.CurrencySymbol = Constants.VN_UNIT;
            vnfi.CurrencyDecimalSeparator = Constants.CHAR_COMMA;
            vnfi.CurrencyDecimalDigits = 0;

            if (!Directory.Exists(Global.AppPath + Constants.FOLDER_TEMP))
            {
                Directory.CreateDirectory(Global.AppPath + Constants.FOLDER_TEMP);
            }

            string fileBoNhiem = string.Empty;

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Word Documents (*.docx)|*.docx";
                saveFileDialog.DefaultExt = "docx";
                saveFileDialog.AddExtension = true;
                saveFileDialog.InitialDirectory = Global.AppPath + Constants.FOLDER_TEMP;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileBoNhiem = saveFileDialog.FileName;

                    try
                    {
                        using (MemoryStream mStream = new MemoryStream(File.ReadAllBytes("PhieuThanhToan.docx")))
                        {
                            WordDocument document = new WordDocument(mStream);
                            string[] fields = new string[] { "Ngay", "Thang", "Nam", "MaPTT", "MaHD", "TenKH", "MaSoThue", "DiaChi", "TongTienTT", "KHThanhToan", "pNgayLap" };
                            string[] values = new string[] { pNgay, pThang, pNam, pMaPTT, pMaHD, pTenKH, pMaSoThue, pDiaChi, pTongTienTT, pKHThanhToan, pNgayLap };


                            document.MailMerge.Execute(fields, values);
                            document.Save(fileBoNhiem, FormatType.Docx);
                            this.PrinPriview(fileBoNhiem);
                            document.Close();

                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return false;
        }

        public bool XuatDonDatHang(string pNgay, string pThang, string pNam, string pMaDDH, string pMaSoThue, string pTenKH, string pDiaChi, string pTongSoLuong, string pTongThanhTien, string pNgayDat, List<string> pMaHH, List<string> pTenHH, List<int?> pSoLuong, List<double?>pDonGia, List<double?> pThanhTien)
        {
            CultureInfo vietnam = new CultureInfo(1066);
            NumberFormatInfo vnfi = vietnam.NumberFormat;
            vnfi.CurrencySymbol = Constants.VN_UNIT;
            vnfi.CurrencyDecimalSeparator = Constants.CHAR_COMMA;
            vnfi.CurrencyDecimalDigits = 0;

            if (!Directory.Exists(Global.AppPath + Constants.FOLDER_TEMP))
            {
                Directory.CreateDirectory(Global.AppPath + Constants.FOLDER_TEMP);
            }

            string fileBoNhiem = string.Empty;

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Word Documents (*.docx)|*.docx";
                saveFileDialog.DefaultExt = "docx";
                saveFileDialog.AddExtension = true;
                saveFileDialog.InitialDirectory = Global.AppPath + Constants.FOLDER_TEMP;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileBoNhiem = saveFileDialog.FileName;

                    try
                    {
                        using (MemoryStream mStream = new MemoryStream(File.ReadAllBytes("DonDatHang.docx")))
                        {
                            WordDocument document = new WordDocument(mStream);
                            string[] fields = new string[] { "Ngay", "Thang", "Nam", "MaDDH", "MaSoThue", "TenKH", "DiaChi", "TongSoLuong", "ThanhTien", "NgayDat" };
                            string[] values = new string[] { pNgay, pThang, pNam, pMaDDH, pMaSoThue, pTenKH, pDiaChi, pTongSoLuong, pTongThanhTien, pNgayDat };


                            document.MailMerge.Execute(fields, values);

                            // MaHangHoa
                            WTable table = document.LastSection.Tables[0] as WTable;

                            int requiredRows = pMaHH.Count + 2;
                            while (table.Rows.Count < requiredRows)
                            {
                                table.AddRow(true);
                            }

                            for (int rowIndex = 2; rowIndex < requiredRows; rowIndex++)
                            {
                                WTableRow row = table.Rows[rowIndex];
                                row.Cells[0].AddParagraph().AppendText(pMaHH[rowIndex - 2]);
                            }
                            // TenHangHoa
                            WTable table1 = document.LastSection.Tables[0] as WTable;

                            int requiredRows1 = pTenHH.Count + 2;
                            while (table1.Rows.Count < requiredRows1)
                            {
                                table1.AddRow(true);
                            }

                            for (int rowIndex = 2; rowIndex < requiredRows1; rowIndex++)
                            {
                                WTableRow row = table1.Rows[rowIndex];
                                row.Cells[1].AddParagraph().AppendText(pTenHH[rowIndex - 2]);
                            }
                            // SoLuong
                            WTable table2 = document.LastSection.Tables[0] as WTable;

                            int requiredRows2 = pSoLuong.Count + 2;
                            while (table2.Rows.Count < requiredRows2)
                            {
                                table2.AddRow(true);
                            }

                            for (int rowIndex = 2; rowIndex < requiredRows2; rowIndex++)
                            {
                                WTableRow row = table2.Rows[rowIndex];
                                string sl = pSoLuong[rowIndex - 2]?.ToString() ?? "";
                                row.Cells[2].AddParagraph().AppendText(sl);
                            }
                            // DonGia
                            WTable table3 = document.LastSection.Tables[0] as WTable;

                            int requiredRows3 = pDonGia.Count + 2;
                            while (table3.Rows.Count < requiredRows3)
                            {
                                table3.AddRow(true);
                            }

                            for (int rowIndex = 2; rowIndex < requiredRows3; rowIndex++)
                            {
                                WTableRow row = table3.Rows[rowIndex];
                                string tl = pDonGia[rowIndex - 2]?.ToString() ?? "";

                                var paragraph = new WParagraph(document);
                                if (double.TryParse(tl, out double parsedValue))
                                {
                                    paragraph.AppendText(parsedValue.ToString("#,##0"));
                                }
                                else
                                {
                                    paragraph.AppendText(tl);
                                }
                                paragraph.ParagraphFormat.RightIndent = 0;
                                row.Cells[3].Paragraphs.Add(paragraph);
                            }
                            // ThanhTien
                            WTable table4 = document.LastSection.Tables[0] as WTable;

                            int requiredRows4 = pThanhTien.Count + 2;
                            while (table4.Rows.Count < requiredRows4)
                            {
                                table4.AddRow(true);
                            }

                            for (int rowIndex = 2; rowIndex < requiredRows4; rowIndex++)
                            {
                                WTableRow row = table4.Rows[rowIndex];
                                string tl = pThanhTien[rowIndex - 2]?.ToString() ?? "";

                                var paragraph = new WParagraph(document);
                                if (double.TryParse(tl, out double parsedValue))
                                {
                                    paragraph.AppendText(parsedValue.ToString("#,##0"));
                                }
                                else
                                {
                                    paragraph.AppendText(tl);
                                }
                                paragraph.ParagraphFormat.RightIndent = 0;
                                row.Cells[4].Paragraphs.Add(paragraph);
                            }


                            document.Save(fileBoNhiem, FormatType.Docx);
                            this.PrinPriview(fileBoNhiem);
                            document.Close();

                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return false;
        }
    }
}
