using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Views.Employee;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Extensions.Configuration;
using System.Text;
using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Deposit;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Withdraw;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Transfer;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Pay;
using System.Windows.Forms;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    public class EmployeeTransactionManagementController
    {
        private readonly ITransactionManagementView view;
        private readonly EmployeeModel currentEmployee;
        private readonly DatabaseContext dbContext;
        private readonly IConfiguration configuration;
        private List<TransactionManagementDisplayModel> transactions;
        private TransactionManagementDisplayModel selectedTransaction;

        // Biến để lưu trữ thông tin ServiceID, PayLoanID và RemainingDebt
        private string serviceId;
        private string payLoanId;
        private decimal remainingDebt;

        public EmployeeTransactionManagementController(ITransactionManagementView view, EmployeeModel currentEmployee, DatabaseContext dbContext, IConfiguration configuration)
        {
            this.view = view;
            this.currentEmployee = currentEmployee;
            this.dbContext = dbContext;
            this.configuration = configuration;
            transactions = new List<TransactionManagementDisplayModel>();
            selectedTransaction = null;

            serviceId = "N/A";
            payLoanId = "N/A";
            remainingDebt = 0;

            // Đăng ký các sự kiện từ view
            view.SearchRequested += SearchTransactions;
            view.FilterChanged += (s, e) => LoadTransactions(view.GetFromDate(), view.GetToDate(), view.GetTransactionTypeFilter(), view.GetStatusFilter());
            view.ViewDetailRequested += HandleViewDetail;
            view.ExportToPDFRequested += ExportToPDF;
            view.ExportToExcelRequested += ExportToExcel;
            view.ExportToCSVRequested += ExportToCSV;
        }

        public void InitializeControlState()
        {
            view.EnableDetailButton(false);
        }

        public void LoadInitialData()
        {
            try
            {
                // Load dữ liệu giao dịch với bộ lọc mặc định (tất cả giao dịch)
                DateTime toDate = DateTime.Now;
                DateTime fromDate = DateTime.Now; // Một ngày xa để bao gồm tất cả giao dịch
                view.SetDateFilter(fromDate, toDate);
                LoadTransactions(fromDate, toDate, "Không áp dụng", "Không áp dụng");
            }
            catch (Exception ex)
            {
                view.ShowError($"Lỗi khi load dữ liệu ban đầu: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadTransactions(DateTime fromDate, DateTime toDate, string transactionTypeFilter, string statusFilter)
        {
            try
            {
                transactions.Clear();
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    string query = @"
                        SELECT 
                            c.CustomerCode AS CustomerID,
                            a.AccountCode AS AccountID,
                            a.AccountName,
                            tt.TransactionTypeName,
                            t.TransactionCode AS TransactionID,
                            ra.AccountName AS ReceiverAccountName,
                            ra.AccountCode AS ReceiverAccountID,
                            t.Amount,
                            t.TransactionDescription,
                            t.TransactionDate,
                            t.TransactionMethod,
                            e.EmployeeName AS HandledBy,
                            t.TransactionStatus
                        FROM [TRANSACTION] t
                        JOIN ACCOUNT a ON t.AccountID = a.AccountID
                        JOIN CUSTOMER c ON a.CustomerID = c.CustomerID
                        JOIN TRANSACTION_TYPE tt ON t.TransactionTypeID = tt.TransactionTypeID
                        LEFT JOIN ACCOUNT ra ON t.ReceiverAccountID = ra.AccountID
                        LEFT JOIN EMPLOYEE e ON t.HandledBy = e.EmployeeID
                        WHERE t.TransactionDate BETWEEN @FromDate AND @ToDate";

                    if (transactionTypeFilter != "Không áp dụng")
                        query += " AND tt.TransactionTypeName = @TransactionTypeFilter";
                    if (statusFilter != "Không áp dụng")
                        query += " AND t.TransactionStatus = @StatusFilter";

                    query += " ORDER BY t.TransactionDate DESC";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FromDate", fromDate);
                        command.Parameters.AddWithValue("@ToDate", toDate);
                        if (transactionTypeFilter != "Không áp dụng")
                            command.Parameters.AddWithValue("@TransactionTypeFilter", transactionTypeFilter);
                        if (statusFilter != "Không áp dụng")
                            command.Parameters.AddWithValue("@StatusFilter", statusFilter);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                transactions.Add(new TransactionManagementDisplayModel
                                {
                                    CustomerID = reader.GetString(0),
                                    AccountID = reader.GetString(1),
                                    AccountName = reader.GetString(2),
                                    TransactionTypeName = reader.GetString(3),
                                    TransactionID = reader.GetString(4),
                                    ReceiverAccountName = reader.IsDBNull(5) ? "" : reader.GetString(5),
                                    ReceiverAccountID = reader.IsDBNull(6) ? "" : reader.GetString(6),
                                    Amount = reader.GetDecimal(7),
                                    TransactionDescription = reader.GetString(8),
                                    TransactionDate = reader.GetDateTime(9).ToString("dd/MM/yyyy HH:mm:ss"),
                                    TransactionMethod = reader.GetString(10),
                                    HandledBy = reader.IsDBNull(11) ? "" : reader.GetString(11),
                                    TransactionStatus = reader.GetString(12)
                                });
                            }
                        }
                    }
                }
                view.LoadTransactions(transactions);
            }
            catch (Exception ex)
            {
                view.ShowError($"Lỗi khi load giao dịch: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SearchTransactions(object sender, EventArgs e)
        {
            try
            {
                string searchText = view.GetSearchText().ToLower();
                if (string.IsNullOrEmpty(searchText))
                {
                    LoadTransactions(view.GetFromDate(), view.GetToDate(), view.GetTransactionTypeFilter(), view.GetStatusFilter());
                    return;
                }

                transactions.Clear();
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    string query = @"
                SELECT 
                    c.CustomerCode AS CustomerID,
                    a.AccountCode AS AccountID,
                    a.AccountName,
                    tt.TransactionTypeName,
                    t.TransactionCode AS TransactionID,
                    ra.AccountName AS ReceiverAccountName,
                    ra.AccountCode AS ReceiverAccountID,
                    t.Amount,
                    t.TransactionDescription,
                    t.TransactionDate,
                    t.TransactionMethod,
                    e.EmployeeName AS HandledBy,
                    t.TransactionStatus
                FROM [TRANSACTION] t
                JOIN ACCOUNT a ON t.AccountID = a.AccountID
                JOIN CUSTOMER c ON a.CustomerID = c.CustomerID
                JOIN TRANSACTION_TYPE tt ON t.TransactionTypeID = tt.TransactionTypeID
                LEFT JOIN ACCOUNT ra ON t.ReceiverAccountID = ra.AccountID
                LEFT JOIN EMPLOYEE e ON t.HandledBy = e.EmployeeID
                WHERE t.TransactionDate BETWEEN @FromDate AND @ToDate
                AND (
                    LOWER(c.CustomerCode) LIKE @SearchText OR
                    LOWER(a.AccountCode) LIKE @SearchText OR
                    LOWER(a.AccountName) LIKE @SearchText OR
                    LOWER(tt.TransactionTypeName) LIKE @SearchText OR
                    LOWER(t.TransactionCode) LIKE @SearchText OR
                    LOWER(ra.AccountName) LIKE @SearchText OR
                    LOWER(ra.AccountCode) LIKE @SearchText OR
                    CONVERT(nvarchar, t.TransactionDate, 103) LIKE @SearchText OR
                    LOWER(t.TransactionMethod) LIKE @SearchText OR
                    LOWER(e.EmployeeName) LIKE @SearchText OR
                    LOWER(t.TransactionStatus) LIKE @SearchText
                )";

                    string typeFilter = view.GetTransactionTypeFilter();
                    string statusFilter = view.GetStatusFilter();

                    if (typeFilter != "Không áp dụng")
                        query += " AND tt.TransactionTypeName = @TransactionTypeFilter";
                    if (statusFilter != "Không áp dụng")
                        query += " AND t.TransactionStatus = @StatusFilter";

                    query += " ORDER BY t.TransactionDate DESC";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FromDate", view.GetFromDate());
                        command.Parameters.AddWithValue("@ToDate", view.GetToDate());
                        command.Parameters.AddWithValue("@SearchText", $"%{searchText}%");
                        if (typeFilter != "Không áp dụng")
                            command.Parameters.AddWithValue("@TransactionTypeFilter", typeFilter);
                        if (statusFilter != "Không áp dụng")
                            command.Parameters.AddWithValue("@StatusFilter", statusFilter);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                transactions.Add(new TransactionManagementDisplayModel
                                {
                                    CustomerID = reader.GetString(0),
                                    AccountID = reader.GetString(1),
                                    AccountName = reader.GetString(2),
                                    TransactionTypeName = reader.GetString(3),
                                    TransactionID = reader.GetString(4),
                                    ReceiverAccountName = reader.IsDBNull(5) ? "" : reader.GetString(5),
                                    ReceiverAccountID = reader.IsDBNull(6) ? "" : reader.GetString(6),
                                    Amount = reader.GetDecimal(7),
                                    TransactionDescription = reader.GetString(8),
                                    TransactionDate = reader.GetDateTime(9).ToString("dd/MM/yyyy HH:mm:ss"),
                                    TransactionMethod = reader.GetString(10),
                                    HandledBy = reader.IsDBNull(11) ? "" : reader.GetString(11),
                                    TransactionStatus = reader.GetString(12)
                                });
                            }
                        }
                    }
                }
                view.LoadTransactions(transactions);
            }
            catch (Exception ex)
            {
                view.ShowError($"Lỗi khi tìm kiếm giao dịch: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleViewDetail(object sender, EventArgs e)
        {
            try
            {
                var dataGridView = view.GetDataGridView();
                if (dataGridView.SelectedRows.Count == 0)
                {
                    view.ShowError("Vui lòng chọn một giao dịch để xem chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedRow = dataGridView.SelectedRows[0];
                if (selectedRow.IsNewRow)
                {
                    view.ShowError("Hàng được chọn không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy CustomerID và TransactionID gốc từ cơ sở dữ liệu
                string customerCode = selectedRow.Cells["CustomerID"].Value.ToString();
                string transactionCode = selectedRow.Cells["TransactionID"].Value.ToString();
                string customerId;
                string transactionId;

                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    // Lấy CustomerID từ CustomerCode
                    using (var command = new SqlCommand("SELECT CustomerID FROM CUSTOMER WHERE CustomerCode = @CustomerCode", connection))
                    {
                        command.Parameters.AddWithValue("@CustomerCode", customerCode);
                        customerId = command.ExecuteScalar().ToString();
                    }

                    // Lấy TransactionID từ TransactionCode
                    using (var command = new SqlCommand("SELECT TransactionID FROM [TRANSACTION] WHERE TransactionCode = @TransactionCode", connection))
                    {
                        command.Parameters.AddWithValue("@TransactionCode", transactionCode);
                        transactionId = command.ExecuteScalar().ToString();
                    }
                }

                selectedTransaction = new TransactionManagementDisplayModel
                {
                    CustomerID = customerId,
                    AccountID = selectedRow.Cells["AccountID"].Value.ToString(),
                    AccountName = selectedRow.Cells["AccountName"].Value.ToString(),
                    TransactionTypeName = selectedRow.Cells["TransactionTypeName"].Value.ToString(),
                    TransactionID = transactionId,
                    ReceiverAccountName = selectedRow.Cells["ReceiverAccountName"].Value?.ToString() ?? "",
                    ReceiverAccountID = selectedRow.Cells["ReceiverAccountID"].Value?.ToString() ?? "",
                    Amount = decimal.Parse(selectedRow.Cells["Amount"].Value.ToString().Replace(",", "")),
                    TransactionDescription = selectedRow.Cells["TransactionDescription"].Value.ToString(),
                    TransactionDate = selectedRow.Cells["TransactionDate"].Value.ToString(),
                    TransactionMethod = selectedRow.Cells["TransactionMethod"].Value.ToString(),
                    HandledBy = selectedRow.Cells["HandledBy"].Value?.ToString() ?? "",
                    TransactionStatus = selectedRow.Cells["TransactionStatus"].Value.ToString()
                };

                switch (selectedTransaction.TransactionTypeName)
                {
                    case "Nạp tiền":
                        ShowDepositDetail();
                        break;
                    case "Rút tiền":
                        ShowWithdrawDetail();
                        break;
                    case "Chuyển tiền":
                        ShowTransferDetail();
                        break;
                    case "Thanh toán khoản vay":
                        ShowPayDetail();
                        break;
                    default:
                        view.ShowError("Loại giao dịch không được hỗ trợ xem chi tiết!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
            catch (Exception ex)
            {
                view.ShowError($"Lỗi khi xem chi tiết: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowDepositDetail()
        {
            FormDeposit form = new FormDeposit();
            UC_SuccessfulDeposit uc = new UC_SuccessfulDeposit();
            form.LoadUserControl(uc);

            uc.Amount = $"+ {selectedTransaction.Amount.ToString("#,##0")} VND";
            uc.CustomerName = selectedTransaction.AccountName;
            uc.CustomerAccountID = selectedTransaction.AccountID;
            uc.AccountBalance = GetAccountBalance(selectedTransaction.AccountID).ToString("#,##0") + " VND";
            uc.TransactionDate = selectedTransaction.TransactionDate;
            uc.EmployeeName = selectedTransaction.HandledBy == "" ? currentEmployee?.EmployeeName : selectedTransaction.HandledBy;
            uc.TransactionDescription = selectedTransaction.TransactionDescription;

            // Đăng ký sự kiện
            uc.DoneClicked += (s, e) =>
            {
                form.DialogResult = DialogResult.OK;
                form.Close();
            };
            uc.InvoiceClicked += (s, e) => ExportDetailToPDF();

            form.ShowDialog();
        }

        private void ShowWithdrawDetail()
        {
            FormWithdraw form = new FormWithdraw();
            UC_SuccessfulWithdraw uc = new UC_SuccessfulWithdraw();
            form.LoadUserControl(uc);

            uc.Amount = $"- {selectedTransaction.Amount.ToString("#,##0")} VND";
            uc.CustomerName = selectedTransaction.AccountName;
            uc.CustomerAccountID = selectedTransaction.AccountID;
            uc.AccountBalance = GetAccountBalance(selectedTransaction.AccountID).ToString("#,##0") + " VND";
            uc.TransactionDate = selectedTransaction.TransactionDate;
            uc.EmployeeName = selectedTransaction.HandledBy == "" ? currentEmployee?.EmployeeName : selectedTransaction.HandledBy;
            uc.TransactionDescription = selectedTransaction.TransactionDescription;

            // Đăng ký sự kiện
            uc.DoneClicked += (s, e) =>
            {
                form.DialogResult = DialogResult.OK;
                form.Close();
            };
            uc.InvoiceClicked += (s, e) => ExportDetailToPDF();

            form.ShowDialog();
        }

        private void ShowTransferDetail()
        {
            FormTransfer form = new FormTransfer();
            UC_SuccessfulTransfer uc = new UC_SuccessfulTransfer();
            form.LoadUserControl(uc);

            uc.Amount = $"{selectedTransaction.Amount.ToString("#,##0")} VND";
            uc.CustomerName = selectedTransaction.AccountName;
            uc.CustomerAccountID = selectedTransaction.AccountID;
            uc.AccountBalance = GetAccountBalance(selectedTransaction.AccountID).ToString("#,##0") + " VND";
            uc.ReceiverName = selectedTransaction.ReceiverAccountName;
            uc.ReceiverAccountID = selectedTransaction.ReceiverAccountID;
            uc.ReceiverBank = "Sacombank";
            uc.TransactionDate = selectedTransaction.TransactionDate;
            uc.EmployeeName = selectedTransaction.HandledBy == "" ? "Tự động" : selectedTransaction.HandledBy;
            uc.TransactionDescription = selectedTransaction.TransactionDescription;

            // Đăng ký sự kiện
            uc.DoneClicked += (s, e) =>
            {
                form.DialogResult = DialogResult.OK;
                form.Close();
            };
            uc.InvoiceClicked += (s, e) => ExportDetailToPDF();

            form.ShowDialog();
        }

        private void ShowPayDetail()
        {
            // Tạo form mới để hiển thị chi tiết giao dịch Thanh toán khoản vay
            FormPay payForm = new FormPay();
            UC_SuccessfulPay uc = new UC_SuccessfulPay();
            payForm.LoadUserControl(uc);

            // Gán thông tin giao dịch cho UC_SuccessfulPay
            uc.Amount = $"- {selectedTransaction.Amount.ToString("#,##0")} VND"; // Số tiền giảm
            uc.CustomerName = selectedTransaction.AccountName;
            uc.CustomerAccountID = selectedTransaction.AccountID;
            uc.AccountBalance = GetAccountBalance(selectedTransaction.AccountID).ToString("#,##0") + " VND";

            // Lấy thông tin ServiceID, PayLoanID và RemainingDebt
            serviceId = "N/A";
            payLoanId = "N/A";
            remainingDebt = 0;
            using (var connection = dbContext.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand(
                    @"
            SELECT 
                s.ServiceID,
                lp.PayLoanID,
                lp.RemainingDebt
            FROM [TRANSACTION] t
            JOIN ACCOUNT a ON t.AccountID = a.AccountID
            JOIN SERVICE s ON s.AccountID = a.AccountID
            LEFT JOIN LOAN_PAYMENT lp ON lp.ServiceID = s.ServiceID
            WHERE t.TransactionID = @TransactionID", connection))
                {
                    command.Parameters.AddWithValue("@TransactionID", selectedTransaction.TransactionID);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            serviceId = reader.IsDBNull(0) ? "N/A" : reader.GetInt32(0).ToString();
                            payLoanId = reader.IsDBNull(1) ? "N/A" : reader.GetInt32(1).ToString();
                            remainingDebt = reader.IsDBNull(2) ? 0 : reader.GetDecimal(2);
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy thông tin thanh toán khoản vay cho TransactionID: {selectedTransaction.TransactionID}");
                        }
                    }
                }
            }

            // Log giá trị để kiểm tra
            Console.WriteLine($"ServiceID: {serviceId}, PayLoanID: {payLoanId}, RemainingDebt: {remainingDebt}");

            // Thêm tiền tố cho ServiceID và PayLoanID
            string formattedServiceId = serviceId == "N/A" ? "N/A" : $"DV{serviceId}";
            string formattedPayLoanId = payLoanId == "N/A" ? "N/A" : $"TTV{payLoanId}";

            // Sử dụng giá trị đã được định dạng
            uc.ServiceID = formattedServiceId; // Sửa từ serviceId thành formattedServiceId
            uc.PayLoanID = formattedPayLoanId; // Sửa từ payLoanId thành formattedPayLoanId
            uc.CustomerRemainingDebt = remainingDebt.ToString("#,##0") + " VND";
            uc.TransactionDate = selectedTransaction.TransactionDate;
            uc.EmployeeName = selectedTransaction.HandledBy == "" ? currentEmployee?.EmployeeName : selectedTransaction.HandledBy;
            uc.TransactionDescription = selectedTransaction.TransactionDescription;

            // Đăng ký sự kiện
            uc.DoneClicked += (s, e) =>
            {
                payForm.DialogResult = DialogResult.OK;
                payForm.Close();
            };
            uc.InvoiceClicked += (s, e) => ExportDetailToPDF();

            payForm.ShowDialog();
        }

        private void ExportDetailToPDF()
        {
            try
            {
                if (selectedTransaction == null)
                {
                    view.ShowError("Không có giao dịch để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string customerFullname = "";
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand("SELECT Fullname FROM CUSTOMER WHERE CustomerID = @CustomerID", connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", selectedTransaction.CustomerID);
                        customerFullname = command.ExecuteScalar()?.ToString() ?? selectedTransaction.AccountName;
                    }
                }

                // Kiểm tra file font
                string projectDir = AppDomain.CurrentDomain.BaseDirectory;
                string arialFontPath = Path.Combine(projectDir, "Resources", "fonts", "ARIAL.TTF");
                string arialBoldFontPath = Path.Combine(projectDir, "Resources", "fonts", "ARIALBD.TTF");

                if (!File.Exists(arialFontPath) || !File.Exists(arialBoldFontPath))
                {
                    view.ShowError($"Không tìm thấy file font tại:\n- {arialFontPath}\n- {arialBoldFontPath}\nVui lòng kiểm tra thư mục Resources/fonts trong dự án.", "Lỗi font", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF Files (*.pdf)|*.pdf",
                    Title = "Chọn nơi lưu hóa đơn giao dịch",
                    FileName = $"TransactionReceipt_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string pdfPath = saveFileDialog.FileName;

                    string directory = Path.GetDirectoryName(pdfPath);
                    try
                    {
                        string tempFile = Path.Combine(directory, "temp_test.txt");
                        File.WriteAllText(tempFile, "test");
                        File.Delete(tempFile);
                    }
                    catch (Exception ex)
                    {
                        view.ShowError($"Không có quyền ghi file tại thư mục: {directory}\nVui lòng chọn thư mục khác.\nChi tiết lỗi: {ex.Message}", "Lỗi quyền truy cập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Xóa file nếu đã tồn tại
                    if (File.Exists(pdfPath))
                    {
                        try
                        {
                            using (FileStream fs = new FileStream(pdfPath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                            {
                                fs.Close();
                            }
                            File.Delete(pdfPath);
                        }
                        catch (Exception ex)
                        {
                            view.ShowError($"File {pdfPath} đang bị khóa bởi một tiến trình khác.\nVui lòng đóng ứng dụng đang sử dụng file (nếu có) và thử lại.\nChi tiết lỗi: {ex.Message}", "Lỗi truy cập file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Thiết lập font
                    BaseFont arialBaseFont = BaseFont.CreateFont(arialFontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    BaseFont arialBoldBaseFont = BaseFont.CreateFont(arialBoldFontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font font = new iTextSharp.text.Font(arialBaseFont, 10);
                    iTextSharp.text.Font boldFont = new iTextSharp.text.Font(arialBoldBaseFont, 10);
                    iTextSharp.text.Font headerFont = new iTextSharp.text.Font(arialBoldBaseFont, 18, iTextSharp.text.Font.ITALIC, new BaseColor(0, 102, 204));
                    iTextSharp.text.Font subHeaderFont = new iTextSharp.text.Font(arialBoldBaseFont, 12);
                    iTextSharp.text.Font footerHighlightFont = new iTextSharp.text.Font(arialBoldBaseFont, 10, iTextSharp.text.Font.NORMAL, new BaseColor(255, 147, 0));

                    using (FileStream fs = new FileStream(pdfPath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        Document document = new Document(PageSize.A4, 36, 36, 36, 36); // Trang dọc, lề 36 giống ExportToPDF
                        PdfWriter writer = PdfWriter.GetInstance(document, fs);
                        document.Open();

                        // Header (giống hệt ExportToPDF)
                        document.Add(new Paragraph("Sacombank", headerFont)
                        {
                            Alignment = Element.ALIGN_LEFT
                        });

                        // Tiêu đề phụ tùy theo loại giao dịch
                        string transactionTitle = selectedTransaction.TransactionTypeName switch
                        {
                            "Nạp tiền" => "HÓA ĐƠN GIAO DỊCH NẠP TIỀN",
                            "Rút tiền" => "HÓA ĐƠN GIAO DỊCH RÚT TIỀN",
                            "Chuyển tiền" => "HÓA ĐƠN GIAO DỊCH CHUYỂN TIỀN",
                            "Thanh toán khoản vay" => "HÓA ĐƠN GIAO DỊCH THANH TOÁN KHOẢN VAY",
                            _ => "HÓA ĐƠN GIAO DỊCH"
                        };
                        document.Add(new Paragraph(transactionTitle, subHeaderFont)
                        {
                            Alignment = Element.ALIGN_LEFT
                        });

                        document.Add(new Paragraph($"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}", font)
                        {
                            Alignment = Element.ALIGN_LEFT
                        });

                        document.Add(new Paragraph($"Mã giao dịch: GD{selectedTransaction.TransactionID}", font)
                        {
                            Alignment = Element.ALIGN_LEFT
                        });

                        // Đường kẻ ngang màu xanh
                        PdfPTable lineTable = new PdfPTable(1);
                        lineTable.WidthPercentage = 100;
                        PdfPCell lineCell = new PdfPCell() { Border = PdfPCell.BOTTOM_BORDER, BorderColor = new BaseColor(0, 102, 204), FixedHeight = 5f };
                        lineTable.AddCell(lineCell);
                        document.Add(lineTable);

                        document.Add(new Paragraph("\n"));

                        // Bảng chính
                        PdfPTable table = new PdfPTable(new float[] { 1, 3, 5 });
                        table.WidthPercentage = 100;
                        table.DefaultCell.Border = PdfPCell.BOX;

                        // Tiêu đề cột 
                        table.AddCell(new PdfPCell(new Phrase("STT", boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = new BaseColor(200, 220, 255), Padding = 5f });
                        table.AddCell(new PdfPCell(new Phrase("Hạng mục", boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = new BaseColor(200, 220, 255), Padding = 5f });
                        table.AddCell(new PdfPCell(new Phrase("Nội dung", boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = new BaseColor(200, 220, 255), Padding = 5f });

                        // Hàng 1: Thông tin khách hàng
                        table.AddCell(new PdfPCell(new Phrase("1", font)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5f });
                        table.AddCell(new PdfPCell(new Phrase("Thông tin khách hàng", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5f });
                        PdfPTable subTableCustomer = new PdfPTable(new float[] { 1, 2 });
                        subTableCustomer.WidthPercentage = 100;
                        subTableCustomer.DefaultCell.Border = PdfPCell.NO_BORDER;
                        subTableCustomer.AddCell(new PdfPCell(new Phrase("Khách hàng", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                        subTableCustomer.AddCell(new PdfPCell(new Phrase(customerFullname, boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                        subTableCustomer.AddCell(new PdfPCell(new Phrase("Mã tài khoản", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                        subTableCustomer.AddCell(new PdfPCell(new Phrase(selectedTransaction.AccountID, boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                        subTableCustomer.AddCell(new PdfPCell(new Phrase("Số dư sau giao dịch", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                        subTableCustomer.AddCell(new PdfPCell(new Phrase(GetAccountBalance(selectedTransaction.AccountID).ToString("#,##0") + " VND", boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                        table.AddCell(new PdfPCell(subTableCustomer) { Border = PdfPCell.BOX, Padding = 5f });

                        // Hàng 2: Thông tin giao dịch
                        table.AddCell(new PdfPCell(new Phrase("2", font)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5f });
                        table.AddCell(new PdfPCell(new Phrase("Thông tin giao dịch", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5f });
                        PdfPTable subTableTransaction = new PdfPTable(new float[] { 1, 2 });
                        subTableTransaction.WidthPercentage = 100;
                        subTableTransaction.DefaultCell.Border = PdfPCell.NO_BORDER;

                        // Định dạng số tiền tùy theo loại giao dịch
                        string formattedAmount = selectedTransaction.TransactionTypeName switch
                        {
                            "Nạp tiền" => "+ " + selectedTransaction.Amount.ToString("#,##0") + " VND",
                            "Rút tiền" => "- " + selectedTransaction.Amount.ToString("#,##0") + " VND",
                            "Chuyển tiền" => selectedTransaction.Amount.ToString("#,##0") + " VND",
                            "Thanh toán khoản vay" => "- " + selectedTransaction.Amount.ToString("#,##0") + " VND",
                            _ => selectedTransaction.Amount.ToString("#,##0") + " VND"
                        };

                        // Nếu là giao dịch chuyển tiền, thêm thông tin  thông tin tài khoản nhận
                        if (selectedTransaction.TransactionTypeName == "Chuyển tiền")
                        {
                            subTableTransaction.AddCell(new PdfPCell(new Phrase("Tài khoản nhận", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                            subTableTransaction.AddCell(new PdfPCell(new Phrase($"{selectedTransaction.ReceiverAccountID} - {selectedTransaction.ReceiverAccountName}", boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                        }

                        // Nếu là giao dịch thanh toán khoản vay, thêm thông tin mã dịch vụ, mã thanh toán và số nợ còn lại
                        if (selectedTransaction.TransactionTypeName == "Thanh toán khoản vay")
                        {
                            // Thêm tiền tố cho ServiceID và PayLoanID
                            string formattedServiceId = serviceId == "N/A" ? "N/A" : $"DV{serviceId}";
                            string formattedPayLoanId = payLoanId == "N/A" ? "N/A" : $"TTV{payLoanId}";

                            subTableTransaction.AddCell(new PdfPCell(new Phrase("Mã dịch vụ", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                            subTableTransaction.AddCell(new PdfPCell(new Phrase(formattedServiceId, boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f }); // Sửa từ serviceId thành formattedServiceId
                            subTableTransaction.AddCell(new PdfPCell(new Phrase("Mã thanh toán", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                            subTableTransaction.AddCell(new PdfPCell(new Phrase(formattedPayLoanId, boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f }); // Sửa từ payLoanId thành formattedPayLoanId
                            subTableTransaction.AddCell(new PdfPCell(new Phrase("Số nợ còn lại", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                            subTableTransaction.AddCell(new PdfPCell(new Phrase(remainingDebt.ToString("#,##0") + " VND", boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                        }

                        subTableTransaction.AddCell(new PdfPCell(new Phrase("Số tiền", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                        subTableTransaction.AddCell(new PdfPCell(new Phrase(formattedAmount, boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                        subTableTransaction.AddCell(new PdfPCell(new Phrase("Nội dung", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                        subTableTransaction.AddCell(new PdfPCell(new Phrase(selectedTransaction.TransactionDescription, boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                        subTableTransaction.AddCell(new PdfPCell(new Phrase("Phương thức", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                        subTableTransaction.AddCell(new PdfPCell(new Phrase(selectedTransaction.TransactionMethod, boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                        subTableTransaction.AddCell(new PdfPCell(new Phrase("Người xử lý", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                        subTableTransaction.AddCell(new PdfPCell(new Phrase(selectedTransaction.HandledBy == "" ? "Tự động" : selectedTransaction.HandledBy, boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                        table.AddCell(new PdfPCell(subTableTransaction) { Border = PdfPCell.BOX, Padding = 5f });

                        document.Add(table);

                        // Footer
                        document.Add(new Paragraph("\n\n"));
                        PdfPTable footerTable = new PdfPTable(1);
                        footerTable.WidthPercentage = 100;
                        PdfPCell footerCell = new PdfPCell();
                        footerCell.Border = PdfPCell.NO_BORDER;
                        footerCell.HorizontalAlignment = Element.ALIGN_CENTER;

                        footerCell.AddElement(new Paragraph("NGÂN HÀNG THƯƠNG MẠI CỔ PHẦN SÀI GÒN THƯƠNG TÍN", footerHighlightFont)
                        {
                            Alignment = Element.ALIGN_LEFT
                        });
                        footerCell.AddElement(new Paragraph("•  266 - 268 Nam Kỳ Khởi Nghĩa, Q.3, TP.HCM", font)
                        {
                            Alignment = Element.ALIGN_LEFT
                        });
                        footerCell.AddElement(new Paragraph("•  1800 5858 88/+84 28 3526 6060", font)
                        {
                            Alignment = Element.ALIGN_LEFT
                        });
                        footerCell.AddElement(new Paragraph("•  sacombank.com.vn/ask@sacombank.com", font)
                        {
                            Alignment = Element.ALIGN_LEFT
                        });

                        footerTable.AddCell(footerCell);
                        document.Add(footerTable);

                        document.Close();
                        writer.Close();
                    }

                    view.ShowError($"Hóa đơn đã được xuất thành công tại: {pdfPath}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                view.ShowError($"Lỗi khi xuất hóa đơn PDF: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal GetAccountBalance(string accountCode)
        {
            try
            {
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand("SELECT Balance FROM ACCOUNT WHERE AccountCode = @AccountCode", connection))
                    {
                        command.Parameters.AddWithValue("@AccountCode", accountCode);
                        return Convert.ToDecimal(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy số dư tài khoản: {ex.Message}");
            }
        }

        public void ExportToPDF(object sender, EventArgs e)
        {
            try
            {
                if (transactions.Count == 0)
                {
                    view.ShowError("Không có giao dịch để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF files (*.pdf)|*.pdf",
                    FileName = "TransactionList.pdf"
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
                    iTextSharp.text.Font footerHighlightFont = new iTextSharp.text.Font(baseFontBold, 10, iTextSharp.text.Font.NORMAL, new BaseColor(255, 147, 0));

                    // Header
                    document.Add(new Paragraph("Sacombank", headerFont)
                    {
                        Alignment = Element.ALIGN_LEFT
                    });

                    document.Add(new Paragraph("DANH SÁCH GIAO DỊCH", subHeaderFont)
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
                    PdfPTable pdfTable = new PdfPTable(13); // 13 cột
                    pdfTable.WidthPercentage = 100;
                    pdfTable.SetWidths(new float[] { 1f, 1.5f, 2f, 1.5f, 1.5f, 2f, 1.5f, 1.5f, 2f, 2f, 1.5f, 1.5f, 1.5f });

                    // Thêm tiêu đề cột với màu nền
                    string[] headers = { "Mã KH", "Mã TK", "Tên TK", "Loại GD", "Mã GD", "Tên TK nhận", "Mã TK nhận", "Số tiền", "Nội dung", "Ngày GD", "Phương thức", "Người xử lý", "Trạng thái" };
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

                    // Thêm dữ liệu từ danh sách transactions
                    foreach (var transaction in transactions)
                    {
                        pdfTable.AddCell(new Phrase(transaction.CustomerID.ToString(), vietnameseFont));
                        pdfTable.AddCell(new Phrase(transaction.AccountID, vietnameseFont));
                        pdfTable.AddCell(new Phrase(transaction.AccountName, vietnameseFont));
                        pdfTable.AddCell(new Phrase(transaction.TransactionTypeName, vietnameseFont));
                        pdfTable.AddCell(new Phrase(transaction.TransactionID, vietnameseFont));
                        pdfTable.AddCell(new Phrase(transaction.ReceiverAccountName, vietnameseFont));
                        pdfTable.AddCell(new Phrase(transaction.ReceiverAccountID, vietnameseFont));
                        pdfTable.AddCell(new Phrase(transaction.Amount.ToString("#,##0"), vietnameseFont));
                        pdfTable.AddCell(new Phrase(transaction.TransactionDescription, vietnameseFont));
                        pdfTable.AddCell(new Phrase(transaction.TransactionDate, vietnameseFont));
                        pdfTable.AddCell(new Phrase(transaction.TransactionMethod, vietnameseFont));
                        pdfTable.AddCell(new Phrase(transaction.HandledBy, vietnameseFont));
                        pdfTable.AddCell(new Phrase(transaction.TransactionStatus, vietnameseFont));
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
                    view.ShowError("Xuất PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                view.ShowError($"Lỗi khi xuất PDF: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExportToExcel(object sender, EventArgs e)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                if (transactions.Count == 0)
                {
                    view.ShowError("Không có giao dịch để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    FileName = "TransactionList.xlsx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    excelApp = new Excel.Application();
                    if (excelApp == null)
                    {
                        throw new Exception("Không thể khởi tạo ứng dụng Excel. Vui lòng kiểm tra cài đặt Microsoft Excel trên máy.");
                    }

                    excelApp.Visible = false;
                    excelApp.DisplayAlerts = false;

                    workbook = excelApp.Workbooks.Add();
                    worksheet = (Excel.Worksheet)workbook.Sheets[1];
                    worksheet.Name = "TransactionList";

                    // Header
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

                    Excel.Range subHeaderRange = worksheet.Range[worksheet.Cells[3, 1], worksheet.Cells[3, 2]];
                    subHeaderRange.Merge();
                    subHeaderRange.Value = "DANH SÁCH GIAO DỊCH";
                    subHeaderRange.Font.Name = "Arial";
                    subHeaderRange.Font.Bold = true;
                    subHeaderRange.Font.Size = 12;
                    subHeaderRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                    Excel.Range dateRange = worksheet.Range[worksheet.Cells[4, 1], worksheet.Cells[4, 2]];
                    dateRange.Merge();
                    dateRange.Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
                    dateRange.Font.Name = "Arial";
                    dateRange.Font.Size = 10;
                    dateRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                    // Tiêu đề cột
                    string[] headers = { "Mã KH", "Mã TK", "Tên TK", "Loại GD", "Mã GD", "Tên TK nhận", "Mã TK nhận", "Số tiền", "Nội dung", "Ngày GD", "Phương thức", "Người xử lý", "Trạng thái" };
                    for (int i = 0; i < headers.Length; i++)
                    {
                        Excel.Range headerCell = worksheet.Cells[6, i + 1];
                        headerCell.Value = headers[i];
                        headerCell.Font.Bold = true;
                        headerCell.Interior.Color = System.Drawing.Color.FromArgb(252, 186, 3).ToArgb();
                        headerCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        headerCell.Borders.Weight = Excel.XlBorderWeight.xlThin;
                    }

                    // Thêm dữ liệu
                    for (int i = 0; i < transactions.Count; i++)
                    {
                        var transaction = transactions[i];
                        Excel.Range rowRange = worksheet.Range[worksheet.Cells[i + 7, 1], worksheet.Cells[i + 7, 13]];
                        worksheet.Cells[i + 7, 1] = transaction.CustomerID;
                        worksheet.Cells[i + 7, 2] = transaction.AccountID;
                        worksheet.Cells[i + 7, 3] = transaction.AccountName;
                        worksheet.Cells[i + 7, 4] = transaction.TransactionTypeName;
                        worksheet.Cells[i + 7, 5] = transaction.TransactionID;
                        worksheet.Cells[i + 7, 6] = transaction.ReceiverAccountName;
                        worksheet.Cells[i + 7, 7] = transaction.ReceiverAccountID;
                        worksheet.Cells[i + 7, 8] = transaction.Amount.ToString("#,##0");
                        worksheet.Cells[i + 7, 9] = transaction.TransactionDescription;
                        worksheet.Cells[i + 7, 10] = transaction.TransactionDate;
                        worksheet.Cells[i + 7, 11] = transaction.TransactionMethod;
                        worksheet.Cells[i + 7, 12] = transaction.HandledBy;
                        worksheet.Cells[i + 7, 13] = transaction.TransactionStatus;

                        rowRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        rowRange.Borders.Weight = Excel.XlBorderWeight.xlThin;
                    }

                    // Footer
                    int lastRow = transactions.Count + 8;
                    Excel.Range footerRange1 = worksheet.Cells[lastRow, 1];
                    footerRange1.Value = "NGÂN HÀNG THƯƠNG MẠI CỔ PHẦN SÀI GÒN THƯƠNG TÍN";
                    footerRange1.Font.Name = "Arial";
                    footerRange1.Font.Bold = true;
                    footerRange1.Font.Size = 10;
                    footerRange1.Font.Color = System.Drawing.Color.FromArgb(255, 147, 0).ToArgb();

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

                    // Autosize cột
                    for (int i = 1; i <= 13; i++)
                    {
                        worksheet.Columns[i].AutoFit();
                    }

                    // Lưu file
                    workbook.SaveAs(saveFileDialog.FileName, Excel.XlFileFormat.xlOpenXMLWorkbook);
                    view.ShowError("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                view.ShowError($"Lỗi khi xuất Excel: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void ExportToCSV(object sender, EventArgs e)
        {
            try
            {
                if (transactions.Count == 0)
                {
                    view.ShowError("Không có giao dịch để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv",
                    FileName = "TransactionList.csv"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder csvContent = new StringBuilder();

                    // Tiêu đề cột
                    string[] headers = { "Mã KH", "Mã TK", "Tên TK", "Loại GD", "Mã GD", "Tên TK nhận", "Mã TK nhận", "Số tiền", "Nội dung", "Ngày GD", "Phương thức", "Người xử lý", "Trạng thái" };
                    csvContent.AppendLine(string.Join(",", headers.Select(h => $"\"{h}\"")));

                    // Thêm dữ liệu
                    foreach (var transaction in transactions)
                    {
                        string[] rowData = new string[]
                        {
                            transaction.CustomerID.ToString(),
                            transaction.AccountID?.Replace("\"", "\"\"") ?? "",
                            transaction.AccountName?.Replace("\"", "\"\"") ?? "",
                            transaction.TransactionTypeName?.Replace("\"", "\"\"") ?? "",
                            transaction.TransactionID?.Replace("\"", "\"\"") ?? "",
                            transaction.ReceiverAccountName?.Replace("\"", "\"\"") ?? "",
                            transaction.ReceiverAccountID?.Replace("\"", "\"\"") ?? "",
                            transaction.Amount.ToString("#,##0"),
                            transaction.TransactionDescription?.Replace("\"", "\"\"") ?? "",
                            transaction.TransactionDate?.Replace("\"", "\"\"") ?? "",
                            transaction.TransactionMethod?.Replace("\"", "\"\"") ?? "",
                            transaction.HandledBy?.Replace("\"", "\"\"") ?? "",
                            transaction.TransactionStatus?.Replace("\"", "\"\"") ?? ""
                        };
                        csvContent.AppendLine(string.Join(",", rowData.Select(d => $"\"{d}\"")));
                    }

                    var utf16Le = new UnicodeEncoding(false, true);
                    File.WriteAllBytes(saveFileDialog.FileName, utf16Le.GetBytes(csvContent.ToString()));
                    view.ShowError("Xuất CSV thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                view.ShowError($"Lỗi khi xuất CSV: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}