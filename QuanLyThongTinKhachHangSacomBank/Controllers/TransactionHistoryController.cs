using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Views.Customer;
using QuanLyThongTinKhachHangSacomBank.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class TransactionHistoryController
    {
        private readonly IFormTransactionHistoryView view;
        private readonly AccountModel currentAccount;
        private readonly DatabaseContext dbContext;
        private List<TransactionDisplayModel> currentTransactions; // Lưu trữ danh sách giao dịch hiện tại

        public TransactionHistoryController(IFormTransactionHistoryView view, AccountModel currentAccount, DatabaseContext dbContext)
        {
            this.view = view;
            this.currentAccount = currentAccount;
            this.dbContext = dbContext;
            this.currentTransactions = new List<TransactionDisplayModel>(); // Khởi tạo danh sách

            // Đăng ký các sự kiện từ view
            view.FilterChanged += LoadTransactions;
            view.ExportPDFRequested += ExportPDF;
            view.ExportExcelRequested += ExportExcel;
            view.ExportCSVRequested += ExportCSV;
        }

        public void OpenTransactionHistory()
        {
            try
            {
                view.SetAccountID(currentAccount.AccountID.ToString());
                view.SetAccountName(currentAccount.AccountName);

                // Tải dữ liệu ban đầu
                LoadTransactions(this, EventArgs.Empty);

                view.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở FormTransactionHistory: {ex.Message}\nStackTrace: {ex.StackTrace}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTransactions(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = dbContext.GetConnection())
                {
                    connection.Open();

                    // Truy vấn SQL để lấy dữ liệu giao dịch
                    string query = @"
                        SELECT 
                            t.TransactionID,
                            t.Amount,
                            t.TransactionDate,
                            t.TransactionDescription,
                            t.AccountID,
                            t.ReceiverAccountID,
                            tt.TransactionTypeName,
                            a.AccountName AS SenderAccountName,
                            r.AccountName AS ReceiverAccountName
                        FROM [TRANSACTION] t
                        JOIN TRANSACTION_TYPE tt ON t.TransactionTypeID = tt.TransactionTypeID
                        JOIN ACCOUNT a ON t.AccountID = a.AccountID
                        LEFT JOIN ACCOUNT r ON t.ReceiverAccountID = r.AccountID
                        WHERE (t.AccountID = @AccountID OR t.ReceiverAccountID = @AccountID)
                        AND t.TransactionDate BETWEEN @FromDate AND @ToDate";

                    // Lọc theo loại giao dịch nếu không chọn "Không áp dụng"
                    if (view.TransactionTypeNameFilter != "Không áp dụng")
                    {
                        query += " AND tt.TransactionTypeName = @TransactionTypeName";
                    }

                    query += " ORDER BY t.TransactionDate DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AccountID", currentAccount.AccountID);
                        command.Parameters.AddWithValue("@FromDate", view.DateFrom.Date);
                        command.Parameters.AddWithValue("@ToDate", view.DateTo.Date.AddDays(1).AddSeconds(-1)); // Đến cuối ngày

                        if (view.TransactionTypeNameFilter != "Không áp dụng")
                        {
                            command.Parameters.AddWithValue("@TransactionTypeName", view.TransactionTypeNameFilter);
                        }

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<TransactionDisplayModel> transactions = new List<TransactionDisplayModel>();

                            while (reader.Read())
                            {
                                string transactionType = reader["TransactionTypeName"].ToString();
                                decimal amount = Convert.ToDecimal(reader["Amount"]);
                                string formattedAmount;
                                string accountNameToShow = currentAccount.AccountName; // Mặc định là tên tài khoản người đăng nhập
                                string serviceId = "NULL"; // Mặc định là NULL cho Nạp tiền, Rút tiền, Chuyển tiền
                                string fromAccount = "";
                                string toAccount = "";

                                // Định dạng số tiền và xác định AccountName, FromAccount, ToAccount theo loại giao dịch
                                if (transactionType == "Nạp tiền")
                                {
                                    formattedAmount = $"+ {amount:N0} VND"; // + 200,000 VND
                                    fromAccount = "NGAN HANG TMCP SAI GON THUONG TIN";
                                    toAccount = reader["SenderAccountName"].ToString();
                                }
                                else if (transactionType == "Rút tiền")
                                {
                                    formattedAmount = $"- {amount:N0} VND"; // - 200,000 VND
                                    fromAccount = reader["SenderAccountName"].ToString();
                                    toAccount = "NGAN HANG TMCP SAI GON THUONG TIN";
                                }
                                else if (transactionType == "Chuyển tiền")
                                {
                                    int accountId = Convert.ToInt32(reader["AccountID"]);
                                    if (accountId == currentAccount.AccountID)
                                    {
                                        // Tài khoản hiện tại là người chuyển
                                        formattedAmount = $"- {amount:N0} VND"; // - 200,000 VND
                                        accountNameToShow = currentAccount.AccountName;
                                        fromAccount = reader["SenderAccountName"].ToString();
                                        toAccount = reader["ReceiverAccountName"].ToString();
                                    }
                                    else
                                    {
                                        // Tài khoản hiện tại là người nhận
                                        formattedAmount = $"+ {amount:N0} VND"; // + 200,000 VND
                                        accountNameToShow = reader["SenderAccountName"].ToString();
                                        fromAccount = reader["SenderAccountName"].ToString();
                                        toAccount = reader["ReceiverAccountName"].ToString();
                                    }
                                }
                                else if (transactionType == "Thanh toán")
                                {
                                    formattedAmount = $"{amount:N0} VND"; // 200,000 VND
                                    serviceId = "DV" + reader["TransactionID"].ToString(); // Giả lập ServiceID cho Thanh toán
                                    accountNameToShow = currentAccount.AccountName;
                                    fromAccount = reader["SenderAccountName"].ToString();
                                    toAccount = "NGAN HANG TMCP SAI GON THUONG TIN";
                                }
                                else
                                {
                                    formattedAmount = $"{amount:N0} VND"; // Các loại giao dịch khác
                                    accountNameToShow = currentAccount.AccountName;
                                    fromAccount = reader["SenderAccountName"].ToString();
                                    toAccount = "NULL";
                                }

                                transactions.Add(new TransactionDisplayModel
                                {
                                    TransactionID = Convert.ToInt32(reader["TransactionID"]),
                                    TransactionTypeName = transactionType,
                                    ServiceID = serviceId,
                                    Amount = formattedAmount,
                                    TransactionDate = Convert.ToDateTime(reader["TransactionDate"]).ToString("dd/MM/yyyy HH:mm:ss"),
                                    TransactionDescription = reader["TransactionDescription"]?.ToString(),
                                    FromAccount = fromAccount,
                                    ToAccount = toAccount
                                });
                            }

                            // Lưu danh sách giao dịch hiện tại
                            currentTransactions = transactions;

                            // Truyền dữ liệu đã xử lý vào view
                            view.DisplayTransactions(transactions);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải lịch sử giao dịch: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportPDF(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF files (*.pdf)|*.pdf",
                    FileName = "TransactionHistory.pdf"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Document document = new Document(PageSize.A4.Rotate(), 36, 36, 36, 36); // Xoay ngang để hiển thị 8 cột
                    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));
                    document.Open();

                    // Thiết lập font tiếng Việt
                    BaseFont baseFontNormal = BaseFont.CreateFont(@"Resources/fonts/ARIAL.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    BaseFont baseFontBold = BaseFont.CreateFont(@"Resources/fonts/ARIALBD.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font vietnameseFont = new iTextSharp.text.Font(baseFontNormal, 10);
                    iTextSharp.text.Font vietnameseFontBold = new iTextSharp.text.Font(baseFontBold, 10);
                    iTextSharp.text.Font headerFont = new iTextSharp.text.Font(baseFontBold, 18, iTextSharp.text.Font.ITALIC, new BaseColor(0, 102, 204));
                    iTextSharp.text.Font subHeaderFont = new iTextSharp.text.Font(baseFontBold, 12);
                    iTextSharp.text.Font footerHighlightFont = new iTextSharp.text.Font(baseFontBold, 10, iTextSharp.text.Font.NORMAL, new BaseColor(255, 147, 0));

                    // Header
                    document.Add(new Paragraph("Sacombank", headerFont)
                    {
                        Alignment = Element.ALIGN_LEFT
                    });

                    document.Add(new Paragraph("LỊCH SỬ GIAO DỊCH", subHeaderFont)
                    {
                        Alignment = Element.ALIGN_LEFT
                    });

                    document.Add(new Paragraph($"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}", vietnameseFont)
                    {
                        Alignment = Element.ALIGN_LEFT
                    });

                    // Thêm đường kẻ ngang màu xanh dưới header
                    PdfPTable lineTable = new PdfPTable(1);
                    lineTable.WidthPercentage = 100;
                    PdfPCell lineCell = new PdfPCell() { Border = PdfPCell.BOTTOM_BORDER, BorderColor = new BaseColor(0, 102, 204), FixedHeight = 5f };
                    lineTable.AddCell(lineCell);
                    document.Add(lineTable);

                    document.Add(new Paragraph("\n"));

                    // Bảng dữ liệu
                    PdfPTable pdfTable = new PdfPTable(8); // 8 cột
                    pdfTable.WidthPercentage = 100;
                    pdfTable.SetWidths(new float[] { 1f, 1.5f, 1f, 1.5f, 1.5f, 2f, 2f, 2f }); // Tỷ lệ cột hợp lý

                    // Thêm tiêu đề cột với màu nền
                    string[] headers = { "Mã giao dịch", "Loại giao dịch", "Mã dịch vụ", "Số tiền", "Ngày giao dịch", "Nội dung", "Từ", "Đến" };
                    foreach (var header in headers)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(header, vietnameseFontBold))
                        {
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            BackgroundColor = new BaseColor(200, 220, 255),
                            Padding = 5f
                        };
                        pdfTable.AddCell(cell);
                    }

                    // Thêm dữ liệu từ danh sách currentTransactions
                    foreach (var transaction in currentTransactions)
                    {
                        pdfTable.AddCell(new Phrase($"GD{transaction.TransactionID}", vietnameseFont));
                        pdfTable.AddCell(new Phrase(transaction.TransactionTypeName, vietnameseFont));
                        pdfTable.AddCell(new Phrase(transaction.ServiceID, vietnameseFont));
                        pdfTable.AddCell(new Phrase(transaction.Amount, vietnameseFont));
                        pdfTable.AddCell(new Phrase(transaction.TransactionDate, vietnameseFont));
                        pdfTable.AddCell(new Phrase(transaction.TransactionDescription ?? "", vietnameseFont));
                        pdfTable.AddCell(new Phrase(transaction.FromAccount, vietnameseFont));
                        pdfTable.AddCell(new Phrase(transaction.ToAccount, vietnameseFont));
                    }

                    document.Add(pdfTable);

                    // Footer
                    document.Add(new Paragraph("\n\n"));
                    PdfPTable footerTable = new PdfPTable(1);
                    footerTable.WidthPercentage = 100;
                    PdfPCell footerCell = new PdfPCell();
                    footerCell.Border = PdfPCell.NO_BORDER;
                    footerCell.HorizontalAlignment = Element.ALIGN_LEFT;

                    footerCell.AddElement(new Paragraph("NGÂN HÀNG THƯƠNG MẠI CỔ PHẦN SÀI GÒN THƯƠNG TÍN", footerHighlightFont)
                    {
                        Alignment = Element.ALIGN_LEFT
                    });
                    footerCell.AddElement(new Paragraph("•  266 - 268 Nam Kỳ Khởi Nghĩa, Q.3, TP.HCM", vietnameseFont)
                    {
                        Alignment = Element.ALIGN_LEFT
                    });
                    footerCell.AddElement(new Paragraph("•  1800 5858 88/+84 28 3526 6060", vietnameseFont)
                    {
                        Alignment = Element.ALIGN_LEFT
                    });
                    footerCell.AddElement(new Paragraph("•  sacombank.com.vn/ask@sacombank.com", vietnameseFont)
                    {
                        Alignment = Element.ALIGN_LEFT
                    });

                    footerTable.AddCell(footerCell);
                    document.Add(footerTable);

                    document.Close();
                    MessageBox.Show("Xuất PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất PDF: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportExcel(object sender, EventArgs e)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    FileName = "TransactionHistory.xlsx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Khởi tạo ứng dụng Excel
                    excelApp = new Excel.Application();
                    if (excelApp == null)
                    {
                        throw new Exception("Không thể khởi tạo ứng dụng Excel. Vui lòng kiểm tra cài đặt Microsoft Excel trên máy.");
                    }

                    excelApp.Visible = false; // Không hiển thị Excel khi chạy
                    excelApp.DisplayAlerts = false; // Tắt các cảnh báo của Excel

                    // Tạo workbook và worksheet mới
                    workbook = excelApp.Workbooks.Add();
                    worksheet = (Excel.Worksheet)workbook.Sheets[1];
                    worksheet.Name = "TransactionHistory";

                    // Header "Sacombank" màu đỏ đậm, in nghiêng, font lớn, gộp ô (2 hàng, 2 cột), không có border
                    Excel.Range headerRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[2, 2]];
                    headerRange.Merge();
                    headerRange.Value = "Sacombank";
                    headerRange.Font.Name = "Arial";
                    headerRange.Font.Bold = true; // Arial Bold
                    headerRange.Font.Size = 16;
                    headerRange.Font.Color = System.Drawing.Color.DarkRed.ToArgb(); // Màu đỏ đậm
                    headerRange.Font.Italic = true;
                    headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter; // Căn giữa
                    headerRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter; // Căn giữa theo chiều dọc

                    // Tiêu đề "LỊCH SỬ GIAO DỊCH" (hàng 3)
                    Excel.Range subHeaderRange = worksheet.Range[worksheet.Cells[3, 1], worksheet.Cells[3, 2]];
                    subHeaderRange.Merge();
                    subHeaderRange.Value = "LỊCH SỬ GIAO DỊCH";
                    subHeaderRange.Font.Name = "Arial";
                    subHeaderRange.Font.Bold = true;
                    subHeaderRange.Font.Size = 12;
                    subHeaderRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                    // Ngày xuất (hàng 4)
                    Excel.Range dateRange = worksheet.Range[worksheet.Cells[4, 1], worksheet.Cells[4, 2]];
                    dateRange.Merge();
                    dateRange.Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
                    dateRange.Font.Name = "Arial";
                    dateRange.Font.Size = 10;
                    dateRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                    // Tiêu đề cột (bắt đầu từ hàng 6)
                    string[] headers = { "Mã giao dịch", "Loại giao dịch", "Mã dịch vụ", "Số tiền", "Ngày giao dịch", "Nội dung", "Từ", "Đến" };
                    for (int i = 0; i < headers.Length; i++)
                    {
                        Excel.Range headerCell = worksheet.Cells[6, i + 1];
                        headerCell.Value = headers[i];
                        headerCell.Font.Bold = true; // In đậm chữ
                        headerCell.Interior.Color = System.Drawing.Color.FromArgb(252, 186, 3).ToArgb(); // Tô màu nền
                        headerCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous; // Thêm border
                        headerCell.Borders.Weight = Excel.XlBorderWeight.xlThin;
                    }

                    // Thêm dữ liệu từ danh sách currentTransactions (bắt đầu từ hàng 7)
                    for (int i = 0; i < currentTransactions.Count; i++)
                    {
                        var transaction = currentTransactions[i];
                        Excel.Range rowRange = worksheet.Range[worksheet.Cells[i + 7, 1], worksheet.Cells[i + 7, 8]];
                        worksheet.Cells[i + 7, 1] = $"GD{transaction.TransactionID}";
                        worksheet.Cells[i + 7, 2] = transaction.TransactionTypeName;
                        worksheet.Cells[i + 7, 3] = transaction.ServiceID;
                        worksheet.Cells[i + 7, 4] = transaction.Amount;
                        worksheet.Cells[i + 7, 5] = transaction.TransactionDate;
                        worksheet.Cells[i + 7, 6] = transaction.TransactionDescription;
                        worksheet.Cells[i + 7, 7] = transaction.FromAccount;
                        worksheet.Cells[i + 7, 8] = transaction.ToAccount;

                        // Thêm border cho các ô dữ liệu
                        rowRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        rowRange.Borders.Weight = Excel.XlBorderWeight.xlThin;
                    }

                    // Footer (thêm vào sau dữ liệu)
                    int lastRow = currentTransactions.Count + 8; // +8 để cách 1 dòng sau dữ liệu
                    Excel.Range footerRange1 = worksheet.Cells[lastRow, 1];
                    footerRange1.Value = "NGÂN HÀNG THƯƠNG MẠI CỔ PHẦN SÀI GÒN THƯƠNG TÍN";
                    footerRange1.Font.Name = "Arial";
                    footerRange1.Font.Bold = true;
                    footerRange1.Font.Size = 10;
                    footerRange1.Font.Color = System.Drawing.Color.FromArgb(255, 147, 0).ToArgb(); // Màu cam

                    Excel.Range footerRange2 = worksheet.Cells[lastRow + 1, 1];
                    footerRange2.Value = "•  266 - 268 Nam Kỳ Khởi Nghĩa, Q.3, TP.HCM";
                    footerRange2.Font.Name = "Arial";
                    footerRange2.Font.Size = 10;

                    Excel.Range footerRange3 = worksheet.Cells[lastRow + 2, 1];
                    footerRange3.Value = "•  1800 5858 88/+84 28 3526 6060";
                    footerRange3.Font.Name = "Arial";
                    footerRange3.Font.Size = 10;

                    Excel.Range footerRange4 = worksheet.Cells[lastRow + 3, 1];
                    footerRange4.Value = "•  sacombank.com.vn/ask@sacombank.com";
                    footerRange4.Font.Name = "Arial";
                    footerRange4.Font.Size = 10;

                    // Autosize cột dựa trên dữ liệu
                    for (int i = 1; i <= 8; i++) // Từ cột 1 đến cột 8
                    {
                        worksheet.Columns[i].AutoFit();
                    }

                    // Lưu file
                    workbook.SaveAs(saveFileDialog.FileName, Excel.XlFileFormat.xlOpenXMLWorkbook);
                    MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đóng workbook và Excel
                if (worksheet != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                }
                if (workbook != null)
                {
                    workbook.Close(false);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                }
                if (excelApp != null)
                {
                    excelApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                }
            }
        }

        private void ExportCSV(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv",
                    FileName = "TransactionHistory.csv"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder csvContent = new StringBuilder();

                    // Tiêu đề cột
                    string[] headers = { "Mã giao dịch", "Loại giao dịch", "Mã dịch vụ", "Số tiền", "Ngày giao dịch", "Nội dung", "Từ", "Đến" };
                    csvContent.AppendLine(string.Join(",", headers.Select(h => $"\"{h}\"")));

                    // Thêm dữ liệu từ danh sách currentTransactions
                    foreach (var transaction in currentTransactions)
                    {
                        // Thoát các ký tự đặc biệt (như dấu nháy kép) trong dữ liệu
                        string transactionDescription = transaction.TransactionDescription?.Replace("\"", "\"\"") ?? "";
                        string fromAccount = transaction.FromAccount?.Replace("\"", "\"\"") ?? "";
                        string toAccount = transaction.ToAccount?.Replace("\"", "\"\"") ?? "";
                        string transactionTypeName = transaction.TransactionTypeName?.Replace("\"", "\"\"") ?? "";
                        string serviceId = transaction.ServiceID?.Replace("\"", "\"\"") ?? "";
                        string amount = transaction.Amount?.Replace("\"", "\"\"") ?? "";
                        string transactionDate = transaction.TransactionDate?.Replace("\"", "\"\"") ?? "";

                        string[] rowData = new string[]
                        {
                            $"GD{transaction.TransactionID}",
                            transactionTypeName,
                            serviceId,
                            amount,
                            transactionDate,
                            transactionDescription,
                            fromAccount,
                            toAccount
                        };
                        // Bao quanh mỗi giá trị bằng dấu nháy kép để tránh lỗi định dạng
                        csvContent.AppendLine(string.Join(",", rowData.Select(d => $"\"{d}\"")));
                    }

                    // Sử dụng UTF-16 LE (Unicode) để đảm bảo Excel hiển thị tiếng Việt đúng
                    var utf16Le = new UnicodeEncoding(false, true); // UTF-16 LE với BOM
                    File.WriteAllBytes(saveFileDialog.FileName, utf16Le.GetBytes(csvContent.ToString()));
                    MessageBox.Show("Xuất CSV thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất CSV: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}