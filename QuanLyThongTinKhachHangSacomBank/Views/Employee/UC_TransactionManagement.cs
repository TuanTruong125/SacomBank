using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Deposit;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Withdraw;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Transfer;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Pay;
using QuanLyThongTinKhachHangSacomBank.Controllers;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Views.Customer;

namespace QuanLyThongTinKhachHangSacomBank.Views.Employee
{
    public interface ITransactionManagementView
    {
        void LoadTransactions(List<TransactionManagementDisplayModel> transactions);
        void ClearTransactions();
        void ShowError(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon);
        void EnableDetailButton(bool enable);
        void SetDateFilter(DateTime fromDate, DateTime toDate);

        DateTime GetFromDate();
        DateTime GetToDate();
        string GetTransactionTypeFilter();
        string GetStatusFilter();
        string GetSearchText();
        DataGridView GetDataGridView();

        event EventHandler SearchRequested;
        event EventHandler FilterChanged;
        event EventHandler ViewDetailRequested;
        event EventHandler ExportToPDFRequested;
        event EventHandler ExportToExcelRequested;
        event EventHandler ExportToCSVRequested;
    }

    public partial class UC_TransactionManagement : UserControl, ITransactionManagementView
    {
        private readonly DepositController depositController;
        private readonly WithdrawController withdrawController;
        private readonly TransferController transferController;
        private readonly PayController payController;
        private readonly EmployeeTransactionManagementController controller;
        private readonly AccountModel currentAccount;
        private readonly EmployeeModel currentEmployee;

        public event EventHandler SearchRequested;
        public event EventHandler FilterChanged;
        public event EventHandler ViewDetailRequested;
        public event EventHandler ExportToPDFRequested;
        public event EventHandler ExportToExcelRequested;
        public event EventHandler ExportToCSVRequested;

        public UC_TransactionManagement(AccountModel currentAccount, EmployeeModel currentEmployee, DatabaseContext dbContext, IConfiguration configuration, ICustomerHomeView customerHomeView)
        {
            try
            {
                InitializeComponent();
                this.currentAccount = currentAccount;
                this.currentEmployee = currentEmployee;
                depositController = new DepositController(currentEmployee, dbContext, configuration);
                withdrawController = new WithdrawController(currentEmployee, dbContext, configuration);
                transferController = new TransferController(currentAccount, currentEmployee, dbContext, configuration, customerHomeView);
                payController = new PayController();

                // Đăng ký sự kiện TransactionCompleted từ các controller
                depositController.TransactionCompleted += (s, e) => RefreshTransactions();
                withdrawController.TransactionCompleted += (s, e) => RefreshTransactions();
                transferController.TransactionCompleted += (s, e) => RefreshTransactions();


                // Cấu hình DataGridView
                dataGridViewTransactionManagement.ReadOnly = true;
                dataGridViewTransactionManagement.AllowUserToDeleteRows = false;
                dataGridViewTransactionManagement.AutoGenerateColumns = false;
                dataGridViewTransactionManagement.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Đặt mặc định cho comboBox
                comboBoxTransactionTypeFilter.SelectedIndex = 0; // "Không áp dụng"
                comboBoxStatusFilter.SelectedIndex = 0; // "Không áp dụng"

                // Khởi tạo trạng thái ban đầu
                controller = new EmployeeTransactionManagementController(this, currentEmployee, dbContext, configuration);
                controller.InitializeControlState();
                controller.LoadInitialData();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo UC_TransactionManagement: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }



        public DateTime FromDate => dateTimePickerFrom.Value;
        public DateTime ToDate => dateTimePickerTo.Value;
        public string SearchText => textBoxTransactionSearch.Text.Trim();
        public string TransactionTypeFilter => comboBoxTransactionTypeFilter.SelectedItem?.ToString() ?? "Không áp dụng";
        public string StatusFilter => comboBoxStatusFilter.SelectedItem?.ToString() ?? "Không áp dụng";




        private void RefreshTransactions()
        {
            controller.LoadTransactions(GetFromDate(), GetToDate(), GetTransactionTypeFilter(), GetStatusFilter());
        }

        public void LoadTransactions(List<TransactionManagementDisplayModel> transactions)
        {
            dataGridViewTransactionManagement.Rows.Clear();
            foreach (var transaction in transactions)
            {
                dataGridViewTransactionManagement.Rows.Add(
                    transaction.CustomerID,
                    transaction.AccountID,
                    transaction.AccountName,
                    transaction.TransactionTypeName,
                    transaction.TransactionID,
                    transaction.ReceiverAccountName,
                    transaction.ReceiverAccountID,
                    transaction.Amount.ToString("#,##0"),
                    transaction.TransactionDescription,
                    transaction.TransactionDate,
                    transaction.TransactionMethod,
                    transaction.HandledBy,
                    transaction.TransactionStatus
                );
            }
        }

        public void ClearTransactions()
        {
            dataGridViewTransactionManagement.Rows.Clear();
        }

        public void ShowError(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, buttons, icon);
        }

        public void EnableDetailButton(bool enable)
        {
            buttonViewDetail.Enabled = enable;
        }

        public void SetDateFilter(DateTime fromDate, DateTime toDate)
        {
            dateTimePickerFrom.Value = fromDate;
            dateTimePickerTo.Value = toDate;
        }

        public DateTime GetFromDate()
        {
            return dateTimePickerFrom.Value.Date;
        }

        public DateTime GetToDate()
        {
            return dateTimePickerTo.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
        }

        public string GetTransactionTypeFilter()
        {
            return comboBoxTransactionTypeFilter.SelectedItem?.ToString() ?? "Không áp dụng";
        }

        public string GetStatusFilter()
        {
            return comboBoxStatusFilter.SelectedItem?.ToString() ?? "Không áp dụng";
        }

        public string GetSearchText()
        {
            return textBoxTransactionSearch.Text.Trim();
        }

        public DataGridView GetDataGridView()
        {
            return dataGridViewTransactionManagement;
        }



        private void dataGridViewTransactionManagement_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewTransactionManagement.SelectedRows.Count == 0 || dataGridViewTransactionManagement.SelectedRows[0].IsNewRow)
            {
                EnableDetailButton(false); // Vô hiệu hóa nút khi không có hàng hoặc hàng trống
            }
            else
            {
                EnableDetailButton(true); // Kích hoạt nút khi có hàng hợp lệ
            }
        }



        private void buttonDeposit_Click(object sender, EventArgs e)
        {
            try
            {
                depositController.OpenDeposit(new UC_DepositInfo());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở FormDeposit: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonWithdraw_Click(object sender, EventArgs e)
        {
            try
            {
                withdrawController.OpenWithdraw(new UC_WithdrawInfo());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở FormWithdraw: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                transferController.OpenTransfer(new UC_TransferInfo(currentAccount, isEmployee: true), isEmployee: true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở FormTransfer: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonPay_Click(object sender, EventArgs e)
        {
            try
            {
                payController.OpenPay(new UC_PayInfo(), isEmployee: true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở FormPay: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void buttonTransactionSearch_Click(object sender, EventArgs e)
        {
            SearchRequested?.Invoke(this, EventArgs.Empty);
        }

        private void buttonExportPDF_Click(object sender, EventArgs e)
        {
            ExportToPDFRequested?.Invoke(this, EventArgs.Empty);
        }

        private void buttonExportExcel_Click(object sender, EventArgs e)
        {
            ExportToExcelRequested?.Invoke(this, EventArgs.Empty);
        }

        private void buttonExportCSV_Click(object sender, EventArgs e)
        {
            ExportToCSVRequested?.Invoke(this, EventArgs.Empty);
        }

        

        private void comboBoxTransactionTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterChanged?.Invoke(this, EventArgs.Empty);
        }

        private void comboBoxStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterChanged?.Invoke(this, EventArgs.Empty);
        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            FilterChanged?.Invoke(this, EventArgs.Empty);
        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            FilterChanged?.Invoke(this, EventArgs.Empty);
        }

        private void buttonViewDetail_Click(object sender, EventArgs e)
        {
            ViewDetailRequested?.Invoke(this, EventArgs.Empty);
        }
    }

    public class TransactionManagementDisplayModel
    {
        public string CustomerID { get; set; }
        public string AccountID { get; set; }
        public string AccountName { get; set; }
        public string TransactionTypeName { get; set; }
        public string TransactionID { get; set; }
        public string ReceiverAccountName { get; set; }
        public string ReceiverAccountID { get; set; }
        public decimal Amount { get; set; }
        public string TransactionDescription { get; set; }
        public string TransactionDate { get; set; }
        public string TransactionMethod { get; set; }
        public string HandledBy { get; set; }
        public string TransactionStatus { get; set; }
    }
}
