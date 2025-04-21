using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Transfer;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Pay;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Chat;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Notification;
using QuanLyThongTinKhachHangSacomBank.Controllers;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Models;

namespace QuanLyThongTinKhachHangSacomBank.Views.Customer
{
    public interface ICustomerHomeView
    {
        void SetAccountName(string name);
        void SetAccountID(string id);
        void SetBalance(string balance);
        void SetEyeImage(Image image);
        void UpdateServiceNotifications(List<ServiceNotificationDisplayModel> notifications);
        void UpdateServiceNotificationRow(string payLoanCode, string paymentStatus, string remainingDebt);

        event EventHandler ViewBalanceRequested;
    }

    public partial class UC_CustomerHome : UserControl, ICustomerHomeView
    {
        private readonly NotificationController notificationController;
        private readonly TransferController transferController;
        private readonly TransactionHistoryController transactionHistoryController;
        private readonly PayController payController;
        private readonly ShowCustomerAccountInfoController showCustomerAccountInfoController;
        private readonly CustomerServiceManagementController customerServiceManagementController;
        private readonly ChatController chatController;
        private readonly AccountModel currentAccount;

        public event EventHandler ViewBalanceRequested;

        public UC_CustomerHome(AccountModel currentAccount, EmployeeModel currentEmployee, DatabaseContext dbContext, IConfiguration configuration)
        {
            try
            {
                this.currentAccount = currentAccount;
                InitializeComponent();
                notificationController = new NotificationController();
                transferController = new TransferController(currentAccount, currentEmployee, dbContext, configuration, this);

                // Khai báo rõ ràng kiểu IFormTransactionHistoryView
                IFormTransactionHistoryView transactionView = new FormTransactionHistory(dbContext);
                transactionHistoryController = new TransactionHistoryController(transactionView, currentAccount, dbContext);


                payController = new PayController(currentAccount, currentEmployee, dbContext, configuration, this);
                showCustomerAccountInfoController = new ShowCustomerAccountInfoController(new FormShowCustomerAccountInfo(), dbContext);
                customerServiceManagementController = new CustomerServiceManagementController();
                chatController = new ChatController(dbContext);

                // Cấu hình DataGridView
                dataGridViewServiceNotification.ReadOnly = true;
                dataGridViewServiceNotification.AllowUserToDeleteRows = false;
                dataGridViewServiceNotification.AutoGenerateColumns = false;
                dataGridViewServiceNotification.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewServiceNotification.MultiSelect = false;

                // Đảm bảo DataGridView có đúng số cột
                if (dataGridViewServiceNotification.Columns.Count != 11)
                {
                    System.Diagnostics.Debug.WriteLine("Số cột trong DataGridView không khớp với dữ liệu (cần 11 cột).");
                }

                // Đăng ký sự kiện CellFormatting để tùy chỉnh giao diện
                dataGridViewServiceNotification.CellFormatting += dataGridViewServiceNotification_CellFormatting;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo UC_CustomerHome: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        // Sự kiện CellFormatting để tùy chỉnh giao diện các ô trong DataGridView
        private void dataGridViewServiceNotification_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Định dạng cột "Phí chậm thanh toán" (LateFee) - Cột 5: Màu đỏ
            if (dataGridViewServiceNotification.Columns[e.ColumnIndex].Name == "LateFee")
            {
                e.CellStyle.ForeColor = Color.Red;
            }

            // Định dạng cột "Tổng thanh toán" (TotalDue) - Cột 6: In đậm
            if (dataGridViewServiceNotification.Columns[e.ColumnIndex].Name == "TotalDue")
            {
                e.CellStyle.Font = new Font(dataGridViewServiceNotification.Font, FontStyle.Bold);
            }

            // Định dạng cột "Mã thanh toán" (PayLoanID) - Cột 0: In đậm
            if (dataGridViewServiceNotification.Columns[e.ColumnIndex].Name == "PayLoanID")
            {
                e.CellStyle.Font = new Font(dataGridViewServiceNotification.Font, FontStyle.Bold);
            }

            // Định dạng cột "Trạng thái" (PaymentStatus) - Cột 10: Màu sắc theo trạng thái và in đậm
            if (dataGridViewServiceNotification.Columns[e.ColumnIndex].Name == "PaymentStatus")
            {
                string status = e.Value?.ToString()?.Trim();
                e.CellStyle.Font = new Font(dataGridViewServiceNotification.Font, FontStyle.Bold);

                if (status == "Chưa thanh toán")
                {
                    e.CellStyle.ForeColor = Color.DarkGray;
                }
                else if (status == "Đã thanh toán")
                {
                    e.CellStyle.ForeColor = Color.Green;
                }
                else if (status == "Trễ hạn")
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
        }

        public void UpdateServiceNotifications(List<ServiceNotificationDisplayModel> notifications)
        {
            dataGridViewServiceNotification.Rows.Clear();

            foreach (var notification in notifications)
            {
                dataGridViewServiceNotification.Rows.Add(
                    notification.PayLoanCode,      // Cột 0: Mã thanh toán (đã có tiền tố TTV từ CSDL)
                    notification.ServiceCode,      // Cột 1: Mã dịch vụ
                    notification.ServiceTypeName,  // Cột 2: Loại dịch vụ
                    notification.PrincipalDue,     // Cột 3: Tiền gốc
                    notification.InterestDue,      // Cột 4: Tiền lãi
                    notification.LateFee,          // Cột 5: Phí chậm thanh toán
                    notification.TotalDue,         // Cột 6: Tổng thanh toán
                    notification.RemainingDebt,    // Cột 7: Số nợ còn lại
                    notification.PayNotification,  // Cột 8: Thông báo thanh toán
                    notification.DueDate,          // Cột 9: Ngày đến hạn
                    notification.PaymentStatus     // Cột 10: Trạng thái
                );
            }
        }

        public void UpdateServiceNotificationRow(string payLoanCode, string paymentStatus, string remainingDebt)
        {
            foreach (DataGridViewRow row in dataGridViewServiceNotification.Rows)
            {
                if (row.Cells["PayLoanID"].Value?.ToString() == payLoanCode)
                {
                    row.Cells["PaymentStatus"].Value = paymentStatus;
                    row.Cells["RemainingDebt"].Value = remainingDebt;

                    // Làm mới hàng để áp dụng định dạng màu sắc
                    dataGridViewServiceNotification.InvalidateRow(row.Index);
                    break;
                }
            }
        }



        // --- Button ---
        private void buttonNotification_Click(object sender, EventArgs e)
        {
            try
            {
                notificationController.OpenNotification(new UC_CustomerNotification());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở FormNotification: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCustomerTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                transferController.OpenTransfer(new UC_TransferInfo(currentAccount, isEmployee: false), isEmployee: false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở FormTransfer: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonTransactionHistory_Click(object sender, EventArgs e)
        {
            try
            {
                transactionHistoryController.OpenTransactionHistory();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở FormTransactionHistory: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonPayService_Click(object sender, EventArgs e)
        {
            try
            {
                payController.OpenPay(new UC_PayInfo(currentAccount, isEmployee: false), isEmployee: false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở FormPay: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonShowCustomerAccountInfo_Click(object sender, EventArgs e)
        {
            try
            {
                showCustomerAccountInfoController.OpenShowCustomerAccountInfo(currentAccount);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở FormShowCustomerAccountInfo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCustomerServiceManagement_Click(object sender, EventArgs e)
        {
            try
            {
                customerServiceManagementController.OpenCustomerServiceManagement();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở FormCustomerServiceManagement: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonChatEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                chatController.OpenChat(new UC_CustomerChat(currentAccount), currentAccount);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở FormChat: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonChatBot_Click(object sender, EventArgs e)
        {
            try
            {
                chatController.OpenChat(new UC_ChatBot());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở FormChat: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonViewBalance_Click(object sender, EventArgs e)
        {
            ViewBalanceRequested?.Invoke(this, EventArgs.Empty);
        }

        public void SetAccountName(string name)
        {
            labelAccountName.Text = name;
        }

        public void SetAccountID(string id)
        {
            labelAccountID.Text = id;
        }

        public void SetBalance(string balance)
        {
            labelAccountBalance.Text = balance;
        }

        public void SetEyeImage(Image image)
        {
            buttonViewBalance.Image = image;
        }
    }

    public class ServiceNotificationDisplayModel
    {
        public string PayLoanCode { get; set; } // Mã thanh toán (ví dụ: TTV1)
        public string ServiceCode { get; set; } // Mã dịch vụ
        public string ServiceTypeName { get; set; } // Loại dịch vụ
        public string PrincipalDue { get; set; } // Tiền gốc
        public string InterestDue { get; set; } // Tiền lãi
        public string LateFee { get; set; } // Phí chậm thanh toán
        public string TotalDue { get; set; } // Tổng thanh toán
        public string RemainingDebt { get; set; } // Số nợ còn lại
        public string PayNotification { get; set; } // Thông báo thanh toán
        public string DueDate { get; set; } // Ngày đến hạn
        public string PaymentStatus { get; set; } // Trạng thái
    }
}
