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

namespace QuanLyThongTinKhachHangSacomBank.Views.Customer
{
    public partial class UC_CustomerHome : UserControl
    {
        private readonly NotificationController notificationController;
        private readonly TransferController transferController;
        private readonly TransactionHistoryController transactionHistoryController;
        private readonly PayController payController;
        private readonly ShowCustomerAccountInfoController showCustomerAccountInfoController;
        private readonly CustomerServiceManagementController customerServiceManagementController;
        private readonly ChatController chatController;

        public UC_CustomerHome()
        {
            try
            {
                InitializeComponent();
                notificationController = new NotificationController();
                transferController = new TransferController();
                transactionHistoryController = new TransactionHistoryController();
                payController = new PayController();
                showCustomerAccountInfoController = new ShowCustomerAccountInfoController();
                customerServiceManagementController = new CustomerServiceManagementController();
                chatController = new ChatController();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo UC_CustomerHome: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
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
                transferController.OpenTransfer(new UC_TransferInfo(), isEmployee: false);
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
                payController.OpenPay(new UC_PayInfo(), isEmployee: false);
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
                showCustomerAccountInfoController.OpenShowCustomerAccountInfo();
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
                chatController.OpenChat(new UC_CustomerChat());
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

       
    }
}
