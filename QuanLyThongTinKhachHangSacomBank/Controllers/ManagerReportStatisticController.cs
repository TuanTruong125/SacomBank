using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using QuanLyThongTinKhachHangSacomBank.Views.Manager;
using QuanLyThongTinKhachHangSacomBank.Data;
using Microsoft.Extensions.Configuration;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class ManagerReportStatisticController
    {
        private readonly IReportStatisticView view;
        private readonly DatabaseContext dbContext;
        private readonly IConfiguration configuration;

        public ManagerReportStatisticController(IReportStatisticView view, DatabaseContext dbContext, IConfiguration configuration)
        {
            this.view = view;
            this.dbContext = dbContext;
            this.configuration = configuration;
        }



        // Tải dữ liệu từ cơ sở dữ liệu và cập nhật giao diện
        public void LoadData(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var revenues = LoadRevenues(fromDate, toDate);
                var expenses = LoadExpenses(fromDate, toDate);
                var profits = LoadProfits(fromDate, toDate);

                // Tính toán các chỉ số tổng hợp
                decimal totalRevenue = profits.Sum(p => decimal.Parse(p.TotalRevenue.Replace(",", "")));
                decimal totalExpense = profits.Sum(p => decimal.Parse(p.TotalExpense.Replace(",", "")));
                decimal netProfit = profits.Sum(p => decimal.Parse(p.NetProfit.Replace(",", "")));

                decimal maxRevenue = CalculateMaxRevenue(revenues);
                decimal maxExpense = CalculateMaxExpense(expenses);
                decimal maxNetProfit = profits.Any() ? profits.Max(p => decimal.Parse(p.NetProfit.Replace(",", ""))) : 0;

                // Cập nhật giao diện
                view.UpdateRevenueDataGridView(revenues);
                view.UpdateExpenseDataGridView(expenses);
                view.UpdateProfitDataGridView(profits);
                view.UpdateSummaryLabels(totalRevenue, totalExpense, netProfit, maxRevenue, maxExpense, maxNetProfit);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // Tải dữ liệu doanh thu từ cơ sở dữ liệu
        private List<RevenueDisplayModel> LoadRevenues(DateTime fromDate, DateTime toDate)
        {
            var revenues = new List<RevenueDisplayModel>();
            using (SqlConnection connection = dbContext.GetConnection())
            {
                connection.Open();
                string query = @"
                    SELECT 
                        lp.PayLoanCode, r.RevenueCode, r.PrincipalAmount, r.InterestAmount, r.LateFee, r.TotalAmount, r.RevenueDate
                    FROM REVENUE r
                    LEFT JOIN LOAN_PAYMENT lp ON r.PayLoanID = lp.PayLoanID
                    WHERE CAST(r.RevenueDate AS DATE) BETWEEN @FromDate AND @ToDate
                    ORDER BY r.RevenueDate DESC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FromDate", fromDate);
                    command.Parameters.AddWithValue("@ToDate", toDate);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var revenue = new RevenueDisplayModel
                            {
                                PayLoanCode = reader.IsDBNull(0) ? "" : reader.GetString(0),
                                RevenueCode = reader.GetString(1),
                                PrincipalAmount = reader.GetDecimal(2).ToString("N0"),
                                InterestAmount = reader.GetDecimal(3).ToString("N0"),
                                LateFee = reader.GetDecimal(4).ToString("N0"),
                                TotalAmount = reader.GetDecimal(5).ToString("N0"),
                                RevenueDate = reader.GetDateTime(6).ToString("dd/MM/yyyy HH:mm:ss")
                            };
                            revenues.Add(revenue);
                        }
                    }
                }
            }
            return revenues;
        }



        // Tải dữ liệu chi phí từ cơ sở dữ liệu
        private List<ExpenseDisplayModel> LoadExpenses(DateTime fromDate, DateTime toDate)
        {
            var expenses = new List<ExpenseDisplayModel>();
            using (SqlConnection connection = dbContext.GetConnection())
            {
                connection.Open();
                string query = @"
                    SELECT 
                        sp.PaySavingsCode, e.ExpenseCode, e.InterestPaid, e.EmployeeSalary, e.SystemMaintenanceFee, e.ExpenseDate
                    FROM EXPENSE e
                    LEFT JOIN SAVINGS_PAYMENT sp ON e.PaySavingsID = sp.PaySavingsID
                    WHERE CAST(e.ExpenseDate AS DATE) BETWEEN @FromDate AND @ToDate
                    ORDER BY e.ExpenseDate DESC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FromDate", fromDate);
                    command.Parameters.AddWithValue("@ToDate", toDate);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var expense = new ExpenseDisplayModel
                            {
                                PaySavingsCode = reader.IsDBNull(0) ? "" : reader.GetString(0),
                                ExpenseCode = reader.GetString(1),
                                InterestPaid = reader.IsDBNull(2) ? "0" : reader.GetDecimal(2).ToString("N0"),
                                EmployeeSalary = reader.IsDBNull(3) ? "0" : reader.GetDecimal(3).ToString("N0"),
                                SystemMaintenanceFee = reader.IsDBNull(4) ? "0" : reader.GetDecimal(4).ToString("N0"),
                                ExpenseDate = reader.GetDateTime(5).ToString("dd/MM/yyyy HH:mm:ss")
                            };
                            expenses.Add(expense);
                        }
                    }
                }
            }
            return expenses;
        }



        // Tải dữ liệu lợi nhuận từ cơ sở dữ liệu
        private List<ProfitDisplayModel> LoadProfits(DateTime fromDate, DateTime toDate)
        {
            var profits = new List<ProfitDisplayModel>();
            using (SqlConnection connection = dbContext.GetConnection())
            {
                connection.Open();
                string query = @"
                    SELECT 
                        p.ProfitCode, p.TotalRevenue, p.TotalExpense, p.NetProfit, p.ProfitDate
                    FROM PROFIT p
                    WHERE p.ProfitDate BETWEEN @FromDate AND @ToDate
                    ORDER BY p.ProfitDate DESC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FromDate", fromDate);
                    command.Parameters.AddWithValue("@ToDate", toDate);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var profit = new ProfitDisplayModel
                            {
                                ProfitCode = reader.GetString(0),
                                TotalRevenue = reader.GetDecimal(1).ToString("N0"),
                                TotalExpense = reader.GetDecimal(2).ToString("N0"),
                                NetProfit = reader.GetDecimal(3).ToString("N0"),
                                ProfitDate = reader.GetDateTime(4).ToString("dd/MM/yyyy")
                            };
                            profits.Add(profit);
                        }
                    }
                }
            }
            return profits;
        }



        // Tính doanh thu lớn nhất
        private decimal CalculateMaxRevenue(List<RevenueDisplayModel> revenues)
        {
            if (!revenues.Any()) return 0;

            return revenues.Max(r => decimal.Parse(r.TotalAmount.Replace(",", "")));
        }



        // Tính chi phí lớn nhất
        private decimal CalculateMaxExpense(List<ExpenseDisplayModel> expenses)
        {
            if (!expenses.Any()) return 0;

            decimal maxExpense = 0;
            foreach (var expense in expenses)
            {
                decimal interestPaid = decimal.Parse(expense.InterestPaid.Replace(",", ""));
                decimal employeeSalary = decimal.Parse(expense.EmployeeSalary.Replace(",", ""));
                decimal systemMaintenanceFee = decimal.Parse(expense.SystemMaintenanceFee.Replace(",", ""));

                decimal combined = employeeSalary + systemMaintenanceFee;
                decimal currentMax = Math.Max(interestPaid, combined);

                if (currentMax > maxExpense)
                {
                    maxExpense = currentMax;
                }
            }
            return maxExpense;
        }



        // Xuất dữ liệu ra file PDF
        public void ExportToPDF()
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF files (*.pdf)|*.pdf",
                    FileName = "ReportStatistics.pdf"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Document document = new Document(PageSize.A4.Rotate(), 36, 36, 36, 36);
                    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));
                    document.Open();

                    // Thiết lập font tiếng Việt
                    BaseFont baseFontNormal = BaseFont.CreateFont(@"Resources/fonts/ARIAL.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    BaseFont baseFontBold = BaseFont.CreateFont(@"Resources/fonts/ARIALBD.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font vietnameseFont = new iTextSharp.text.Font(baseFontNormal, 10);
                    iTextSharp.text.Font vietnameseFontBold = new iTextSharp.text.Font(baseFontBold, 10);
                    iTextSharp.text.Font headerFont = new iTextSharp.text.Font(baseFontBold, 18, iTextSharp.text.Font.ITALIC, new BaseColor(0, 102, 204));
                    iTextSharp.text.Font subHeaderFont = new iTextSharp.text.Font(baseFontBold, 12);
                    iTextSharp.text.Font cardTitleFont = new iTextSharp.text.Font(baseFontBold, 14, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                    iTextSharp.text.Font footerHighlightFont = new iTextSharp.text.Font(baseFontBold, 10, iTextSharp.text.Font.NORMAL, new BaseColor(255, 147, 0));

                    // Header
                    document.Add(new Paragraph("Sacombank", headerFont)
                    {
                        Alignment = Element.ALIGN_LEFT
                    });

                    document.Add(new Paragraph("BÁO CÁO THỐNG KÊ", subHeaderFont)
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

                    // Thời gian từ dateTimePickerFrom đến dateTimePickerTo (căn giữa)
                    DateTime fromDate = view.GetDateFrom();
                    DateTime toDate = view.GetDateTo();
                    string dateRangeText = fromDate == toDate
                        ? fromDate.ToString("dd/MM/yyyy")
                        : $"{fromDate.ToString("dd/MM/yyyy")} - {toDate.ToString("dd/MM/yyyy")}";
                    document.Add(new Paragraph(dateRangeText, vietnameseFontBold)
                    {
                        Alignment = Element.ALIGN_CENTER
                    });

                    document.Add(new Paragraph("\n"));

                    // Thêm 3 thẻ card (Doanh thu, Chi phí, Lợi nhuận)
                    PdfPTable cardTable = new PdfPTable(3);
                    cardTable.WidthPercentage = 100;
                    cardTable.SetWidths(new float[] { 1f, 1f, 1f });
                    cardTable.SpacingBefore = 10f;
                    cardTable.SpacingAfter = 10f;

                    // Card 1: Doanh thu
                    PdfPCell revenueCard = new PdfPCell();
                    revenueCard.Border = iTextSharp.text.Rectangle.BOX; // Chỉ định rõ ràng iTextSharp.text.Rectangle
                    revenueCard.BorderColor = new BaseColor(0, 102, 204);
                    revenueCard.BackgroundColor = new BaseColor(240, 248, 255);
                    // Xóa RoundedBorderRadius vì không được hỗ trợ
                    revenueCard.Padding = 10f;

                    revenueCard.AddElement(new Paragraph("DOANH THU", cardTitleFont)
                    {
                        Alignment = Element.ALIGN_CENTER
                    });
                    revenueCard.AddElement(new Paragraph($"Tổng doanh thu: {view.GetTotalRevenue()}", vietnameseFont)
                    {
                        Alignment = Element.ALIGN_CENTER
                    });
                    revenueCard.AddElement(new Paragraph($"Doanh thu lớn nhất: {view.GetMaxRevenueAmount()}", vietnameseFont)
                    {
                        Alignment = Element.ALIGN_CENTER
                    });
                    cardTable.AddCell(revenueCard);

                    // Card 2: Chi phí
                    PdfPCell expenseCard = new PdfPCell();
                    expenseCard.Border = iTextSharp.text.Rectangle.BOX;
                    expenseCard.BorderColor = new BaseColor(0, 102, 204);
                    expenseCard.BackgroundColor = new BaseColor(240, 248, 255);
                    // Xóa RoundedBorderRadius vì không được hỗ trợ
                    expenseCard.Padding = 10f;

                    expenseCard.AddElement(new Paragraph("CHI PHÍ", cardTitleFont)
                    {
                        Alignment = Element.ALIGN_CENTER
                    });
                    expenseCard.AddElement(new Paragraph($"Tổng chi phí: {view.GetTotalExpense()}", vietnameseFont)
                    {
                        Alignment = Element.ALIGN_CENTER
                    });
                    expenseCard.AddElement(new Paragraph($"Chi phí lớn nhất: {view.GetMaxExpenseAmount()}", vietnameseFont)
                    {
                        Alignment = Element.ALIGN_CENTER
                    });
                    cardTable.AddCell(expenseCard);

                    // Card 3: Lợi nhuận
                    PdfPCell profitCard = new PdfPCell();
                    profitCard.Border = iTextSharp.text.Rectangle.BOX;
                    profitCard.BorderColor = new BaseColor(0, 102, 204);
                    profitCard.BackgroundColor = new BaseColor(240, 248, 255);
                    // Xóa RoundedBorderRadius vì không được hỗ trợ
                    profitCard.Padding = 10f;

                    profitCard.AddElement(new Paragraph("LỢI NHUẬN", cardTitleFont)
                    {
                        Alignment = Element.ALIGN_CENTER
                    });
                    profitCard.AddElement(new Paragraph($"Tổng lợi nhuận: {view.GetNetProfit()}", vietnameseFont)
                    {
                        Alignment = Element.ALIGN_CENTER
                    });
                    profitCard.AddElement(new Paragraph($"Lợi nhuận lớn nhất: {view.GetMaxNetProfit()}", vietnameseFont)
                    {
                        Alignment = Element.ALIGN_CENTER
                    });
                    cardTable.AddCell(profitCard);

                    document.Add(cardTable);
                    document.Add(new Paragraph("\n"));

                    // Xuất dữ liệu từ DataGridView
                    // 1. Bảng Doanh thu
                    document.Add(new Paragraph("DỮ LIỆU DOANH THU", subHeaderFont)
                    {
                        Alignment = Element.ALIGN_CENTER
                    });

                    PdfPTable lineTableRevenue = new PdfPTable(1);
                    lineTableRevenue.WidthPercentage = 100;
                    PdfPCell lineCellRevenue = new PdfPCell() { Border = PdfPCell.BOTTOM_BORDER, BorderColor = new BaseColor(0, 102, 204), FixedHeight = 5f };
                    lineTableRevenue.AddCell(lineCellRevenue);
                    document.Add(lineTableRevenue);

                    document.Add(new Paragraph("\n"));

                    PdfPTable revenueTable = new PdfPTable(7);
                    revenueTable.WidthPercentage = 100;
                    revenueTable.SetWidths(new float[] { 1f, 1f, 1f, 1f, 1f, 1f, 1f });

                    string[] revenueHeaders = { "Mã thanh toán", "Mã doanh thu", "Tiền gốc", "Tiền lãi", "Phí trễ hạn", "Tổng tiền", "Ngày doanh thu" };
                    foreach (var header in revenueHeaders)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(header, vietnameseFontBold))
                        {
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            BackgroundColor = new BaseColor(200, 220, 255),
                            Padding = 5f
                        };
                        revenueTable.AddCell(cell);
                    }

                    var revenues = view.GetRevenueData();
                    foreach (var revenue in revenues)
                    {
                        revenueTable.AddCell(new Phrase(revenue.PayLoanCode, vietnameseFont));
                        revenueTable.AddCell(new Phrase(revenue.RevenueCode, vietnameseFont));
                        revenueTable.AddCell(new Phrase(revenue.PrincipalAmount, vietnameseFont));
                        revenueTable.AddCell(new Phrase(revenue.InterestAmount, vietnameseFont));
                        revenueTable.AddCell(new Phrase(revenue.LateFee, vietnameseFont));
                        revenueTable.AddCell(new Phrase(revenue.TotalAmount, vietnameseFont));
                        revenueTable.AddCell(new Phrase(revenue.RevenueDate, vietnameseFont));
                    }
                    document.Add(revenueTable);
                    document.Add(new Paragraph("\n"));

                    // 2. Bảng Chi phí
                    document.Add(new Paragraph("DỮ LIỆU CHI PHÍ", subHeaderFont)
                    {
                        Alignment = Element.ALIGN_CENTER
                    });

                    PdfPTable lineTableExpense = new PdfPTable(1);
                    lineTableExpense.WidthPercentage = 100;
                    PdfPCell lineCellExpense = new PdfPCell() { Border = PdfPCell.BOTTOM_BORDER, BorderColor = new BaseColor(0, 102, 204), FixedHeight = 5f };
                    lineTableExpense.AddCell(lineCellExpense);
                    document.Add(lineTableExpense);

                    document.Add(new Paragraph("\n"));

                    PdfPTable expenseTable = new PdfPTable(6);
                    expenseTable.WidthPercentage = 100;
                    expenseTable.SetWidths(new float[] { 1f, 1f, 1f, 1f, 1f, 1f });

                    string[] expenseHeaders = { "Mã thanh toán", "Mã chi phí", "Lãi đã trả", "Lương nhân viên", "Phí bảo trì", "Ngày chi phí" };
                    foreach (var header in expenseHeaders)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(header, vietnameseFontBold))
                        {
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            BackgroundColor = new BaseColor(200, 220, 255),
                            Padding = 5f
                        };
                        expenseTable.AddCell(cell);
                    }

                    var expenses = view.GetExpenseData();
                    foreach (var expense in expenses)
                    {
                        expenseTable.AddCell(new Phrase(expense.PaySavingsCode, vietnameseFont));
                        expenseTable.AddCell(new Phrase(expense.ExpenseCode, vietnameseFont));
                        expenseTable.AddCell(new Phrase(expense.InterestPaid, vietnameseFont));
                        expenseTable.AddCell(new Phrase(expense.EmployeeSalary, vietnameseFont));
                        expenseTable.AddCell(new Phrase(expense.SystemMaintenanceFee, vietnameseFont));
                        expenseTable.AddCell(new Phrase(expense.ExpenseDate, vietnameseFont));
                    }
                    document.Add(expenseTable);
                    document.Add(new Paragraph("\n"));

                    // 3. Bảng Lợi nhuận
                    document.Add(new Paragraph("DỮ LIỆU LỢI NHUẬN", subHeaderFont)
                    {
                        Alignment = Element.ALIGN_CENTER
                    });

                    PdfPTable lineTableProfit = new PdfPTable(1);
                    lineTableProfit.WidthPercentage = 100;
                    PdfPCell lineCellProfit = new PdfPCell() { Border = PdfPCell.BOTTOM_BORDER, BorderColor = new BaseColor(0, 102, 204), FixedHeight = 5f };
                    lineTableProfit.AddCell(lineCellProfit);
                    document.Add(lineTableProfit);

                    document.Add(new Paragraph("\n"));

                    PdfPTable profitTable = new PdfPTable(5);
                    profitTable.WidthPercentage = 100;
                    profitTable.SetWidths(new float[] { 1f, 1f, 1f, 1f, 1f });

                    string[] profitHeaders = { "Mã lợi nhuận", "Tổng doanh thu", "Tổng chi phí", "Lợi nhuận ròng", "Ngày lợi nhuận" };
                    foreach (var header in profitHeaders)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(header, vietnameseFontBold))
                        {
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            BackgroundColor = new BaseColor(200, 220, 255),
                            Padding = 5f
                        };
                        profitTable.AddCell(cell);
                    }

                    var profits = view.GetProfitData();
                    foreach (var profit in profits)
                    {
                        profitTable.AddCell(new Phrase(profit.ProfitCode, vietnameseFont));
                        profitTable.AddCell(new Phrase(profit.TotalRevenue, vietnameseFont));
                        profitTable.AddCell(new Phrase(profit.TotalExpense, vietnameseFont));
                        profitTable.AddCell(new Phrase(profit.NetProfit, vietnameseFont));
                        profitTable.AddCell(new Phrase(profit.ProfitDate, vietnameseFont));
                    }
                    document.Add(profitTable);

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



        // Xuất dữ liệu ra file Excel
        public void ExportToExcel()
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    FileName = "ReportStatistics.xlsx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Khởi tạo ứng dụng Excel
                    excelApp = new Excel.Application();
                    if (excelApp == null)
                    {
                        throw new Exception("Không thể khởi tạo ứng dụng Excel. Vui lòng kiểm tra cài đặt Microsoft Excel trên máy.");
                    }

                    excelApp.Visible = false;
                    excelApp.DisplayAlerts = false;

                    // Tạo workbook và worksheet mới
                    workbook = excelApp.Workbooks.Add();
                    worksheet = (Excel.Worksheet)workbook.Sheets[1];
                    worksheet.Name = "ReportStatistics";

                    // Header "Sacombank" màu đỏ đậm, in nghiêng, font lớn, gộp ô (2 hàng, 2 cột), không có border
                    Excel.Range headerRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[2, 2]];
                    headerRange.Merge();
                    headerRange.Value = "Sacombank";
                    headerRange.Font.Name = "Arial";
                    headerRange.Font.Bold = true;
                    headerRange.Font.Size = 16;
                    headerRange.Font.Color = System.Drawing.Color.DarkRed.ToArgb();
                    headerRange.Font.Italic = true;
                    headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    headerRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    // Tiêu đề "BÁO CÁO THỐNG KÊ" (hàng 3)
                    Excel.Range subHeaderRange = worksheet.Range[worksheet.Cells[3, 1], worksheet.Cells[3, 2]];
                    subHeaderRange.Merge();
                    subHeaderRange.Value = "BÁO CÁO THỐNG KÊ";
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

                    // Thời gian từ dateTimePickerFrom đến dateTimePickerTo (hàng 5, căn giữa)
                    DateTime fromDate = view.GetDateFrom();
                    DateTime toDate = view.GetDateTo();
                    string dateRangeText = fromDate == toDate
                        ? fromDate.ToString("dd/MM/yyyy")
                        : $"{fromDate.ToString("dd/MM/yyyy")} - {toDate.ToString("dd/MM/yyyy")}";
                    Excel.Range dateFilterRange = worksheet.Range[worksheet.Cells[5, 1], worksheet.Cells[5, 7]];
                    dateFilterRange.Merge();
                    dateFilterRange.Value = dateRangeText;
                    dateFilterRange.Font.Name = "Arial";
                    dateFilterRange.Font.Bold = true;
                    dateFilterRange.Font.Size = 10;
                    dateFilterRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    // Xuất dữ liệu từ DataGridView
                    int rowIndex = 7;

                    // 1. Bảng Doanh thu
                    Excel.Range revenueTitleRange = worksheet.Range[worksheet.Cells[rowIndex, 1], worksheet.Cells[rowIndex, 7]];
                    revenueTitleRange.Merge();
                    revenueTitleRange.Value = "DỮ LIỆU DOANH THU";
                    revenueTitleRange.Font.Name = "Arial";
                    revenueTitleRange.Font.Bold = true;
                    revenueTitleRange.Font.Size = 12;
                    revenueTitleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    rowIndex++;

                    // Thanh ngang
                    Excel.Range lineRangeRevenue = worksheet.Range[worksheet.Cells[rowIndex, 1], worksheet.Cells[rowIndex, 7]];
                    lineRangeRevenue.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    lineRangeRevenue.Borders[Excel.XlBordersIndex.xlEdgeBottom].Color = System.Drawing.Color.FromArgb(0, 102, 204).ToArgb();
                    lineRangeRevenue.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlMedium;
                    rowIndex++;

                    string[] revenueHeaders = { "Mã thanh toán", "Mã doanh thu", "Tiền gốc", "Tiền lãi", "Phí trễ hạn", "Tổng tiền", "Ngày doanh thu" };
                    for (int i = 0; i < revenueHeaders.Length; i++)
                    {
                        Excel.Range headerCell = worksheet.Cells[rowIndex, i + 1];
                        headerCell.Value = revenueHeaders[i];
                        headerCell.Font.Bold = true;
                        headerCell.Interior.Color = System.Drawing.Color.FromArgb(252, 186, 3).ToArgb();
                        headerCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        headerCell.Borders.Weight = Excel.XlBorderWeight.xlThin;
                    }
                    rowIndex++;

                    var revenues = view.GetRevenueData();
                    foreach (var revenue in revenues)
                    {
                        Excel.Range rowRange = worksheet.Range[worksheet.Cells[rowIndex, 1], worksheet.Cells[rowIndex, 7]];
                        worksheet.Cells[rowIndex, 1] = revenue.PayLoanCode;
                        worksheet.Cells[rowIndex, 2] = revenue.RevenueCode;
                        worksheet.Cells[rowIndex, 3] = revenue.PrincipalAmount;
                        worksheet.Cells[rowIndex, 4] = revenue.InterestAmount;
                        worksheet.Cells[rowIndex, 5] = revenue.LateFee;
                        worksheet.Cells[rowIndex, 6] = revenue.TotalAmount;
                        worksheet.Cells[rowIndex, 7] = revenue.RevenueDate;
                        rowRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        rowRange.Borders.Weight = Excel.XlBorderWeight.xlThin;
                        rowIndex++;
                    }
                    rowIndex++;

                    // 2. Bảng Chi phí
                    Excel.Range expenseTitleRange = worksheet.Range[worksheet.Cells[rowIndex, 1], worksheet.Cells[rowIndex, 6]];
                    expenseTitleRange.Merge();
                    expenseTitleRange.Value = "DỮ LIỆU CHI PHÍ";
                    expenseTitleRange.Font.Name = "Arial";
                    expenseTitleRange.Font.Bold = true;
                    expenseTitleRange.Font.Size = 12;
                    expenseTitleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    rowIndex++;

                    // Thanh ngang
                    Excel.Range lineRangeExpense = worksheet.Range[worksheet.Cells[rowIndex, 1], worksheet.Cells[rowIndex, 6]];
                    lineRangeExpense.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    lineRangeExpense.Borders[Excel.XlBordersIndex.xlEdgeBottom].Color = System.Drawing.Color.FromArgb(0, 102, 204).ToArgb();
                    lineRangeExpense.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlMedium;
                    rowIndex++;

                    string[] expenseHeaders = { "Mã thanh toán", "Mã chi phí", "Lãi đã trả", "Lương nhân viên", "Phí bảo trì", "Ngày chi phí" };
                    for (int i = 0; i < expenseHeaders.Length; i++)
                    {
                        Excel.Range headerCell = worksheet.Cells[rowIndex, i + 1];
                        headerCell.Value = expenseHeaders[i];
                        headerCell.Font.Bold = true;
                        headerCell.Interior.Color = System.Drawing.Color.FromArgb(252, 186, 3).ToArgb();
                        headerCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        headerCell.Borders.Weight = Excel.XlBorderWeight.xlThin;
                    }
                    rowIndex++;

                    var expenses = view.GetExpenseData();
                    foreach (var expense in expenses)
                    {
                        Excel.Range rowRange = worksheet.Range[worksheet.Cells[rowIndex, 1], worksheet.Cells[rowIndex, 6]];
                        worksheet.Cells[rowIndex, 1] = expense.PaySavingsCode;
                        worksheet.Cells[rowIndex, 2] = expense.ExpenseCode;
                        worksheet.Cells[rowIndex, 3] = expense.InterestPaid;
                        worksheet.Cells[rowIndex, 4] = expense.EmployeeSalary;
                        worksheet.Cells[rowIndex, 5] = expense.SystemMaintenanceFee;
                        worksheet.Cells[rowIndex, 6] = expense.ExpenseDate;
                        rowRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        rowRange.Borders.Weight = Excel.XlBorderWeight.xlThin;
                        rowIndex++;
                    }
                    rowIndex++;

                    // 3. Bảng Lợi nhuận
                    Excel.Range profitTitleRange = worksheet.Range[worksheet.Cells[rowIndex, 1], worksheet.Cells[rowIndex, 5]];
                    profitTitleRange.Merge();
                    profitTitleRange.Value = "DỮ LIỆU LỢI NHUẬN";
                    profitTitleRange.Font.Name = "Arial";
                    profitTitleRange.Font.Bold = true;
                    profitTitleRange.Font.Size = 12;
                    profitTitleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    rowIndex++;

                    // Thanh ngang
                    Excel.Range lineRangeProfit = worksheet.Range[worksheet.Cells[rowIndex, 1], worksheet.Cells[rowIndex, 5]];
                    lineRangeProfit.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    lineRangeProfit.Borders[Excel.XlBordersIndex.xlEdgeBottom].Color = System.Drawing.Color.FromArgb(0, 102, 204).ToArgb();
                    lineRangeProfit.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlMedium;
                    rowIndex++;

                    string[] profitHeaders = { "Mã lợi nhuận", "Tổng doanh thu", "Tổng chi phí", "Lợi nhuận ròng", "Ngày lợi nhuận" };
                    for (int i = 0; i < profitHeaders.Length; i++)
                    {
                        Excel.Range headerCell = worksheet.Cells[rowIndex, i + 1];
                        headerCell.Value = profitHeaders[i];
                        headerCell.Font.Bold = true;
                        headerCell.Interior.Color = System.Drawing.Color.FromArgb(252, 186, 3).ToArgb();
                        headerCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        headerCell.Borders.Weight = Excel.XlBorderWeight.xlThin;
                    }
                    rowIndex++;

                    var profits = view.GetProfitData();
                    foreach (var profit in profits)
                    {
                        Excel.Range rowRange = worksheet.Range[worksheet.Cells[rowIndex, 1], worksheet.Cells[rowIndex, 5]];
                        worksheet.Cells[rowIndex, 1] = profit.ProfitCode;
                        worksheet.Cells[rowIndex, 2] = profit.TotalRevenue;
                        worksheet.Cells[rowIndex, 3] = profit.TotalExpense;
                        worksheet.Cells[rowIndex, 4] = profit.NetProfit;
                        worksheet.Cells[rowIndex, 5] = profit.ProfitDate;
                        rowRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        rowRange.Borders.Weight = Excel.XlBorderWeight.xlThin;
                        rowIndex++;
                    }

                    // Footer
                    rowIndex++;
                    Excel.Range footerRange1 = worksheet.Cells[rowIndex, 1];
                    footerRange1.Value = "NGÂN HÀNG THƯƠNG MẠI CỔ PHẦN SÀI GÒN THƯƠNG TÍN";
                    footerRange1.Font.Name = "Arial";
                    footerRange1.Font.Bold = true;
                    footerRange1.Font.Size = 10;
                    footerRange1.Font.Color = System.Drawing.Color.FromArgb(255, 147, 0).ToArgb();

                    Excel.Range footerRange2 = worksheet.Cells[rowIndex + 1, 1];
                    footerRange2.Value = "•  266 - 268 Nam Kỳ Khởi Nghĩa, Q.3, TP.HCM";
                    footerRange2.Font.Name = "Arial";
                    footerRange2.Font.Size = 10;

                    Excel.Range footerRange3 = worksheet.Cells[rowIndex + 2, 1];
                    footerRange3.Value = "•  1800 5858 88/+84 28 3526 6060";
                    footerRange3.Font.Name = "Arial";
                    footerRange3.Font.Size = 10;

                    Excel.Range footerRange4 = worksheet.Cells[rowIndex + 3, 1];
                    footerRange4.Value = "•  sacombank.com.vn/ask@sacombank.com";
                    footerRange4.Font.Name = "Arial";
                    footerRange4.Font.Size = 10;

                    // Tự động điều chỉnh kích thước cột
                    for (int i = 1; i <= 7; i++)
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
    }
}