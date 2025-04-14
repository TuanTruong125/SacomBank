using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Controllers;
using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Data;
using Microsoft.Data.SqlClient;

namespace QuanLyThongTinKhachHangSacomBank.Views.Employee
{
    public interface IAccountManagementView
    {
        // Lấy dữ liệu từ các control
        string GetCustomerID();
        string GetAccountID();
        string GetAccountName();
        string GetAccountTypeName();
        decimal GetBalance();
        DateTime GetAccountOpenDate();
        string GetAccountStatus();
        string GetAccountTypeFilter();
        string GetStatusFilter();
        DateTime GetFromDate();
        DateTime GetToDate();
        string GetSearchText();

        // Lấy thông tin từ DataGridView
        int GetSelectedRowCount();
        DataGridViewRow GetSelectedRow();

        // Cập nhật dữ liệu lên các control
        void SetCustomerID(string customerID);
        void SetAccountID(string accountID);
        void SetAccountName(string accountName);
        void SetAccountTypeName(string accountTypeName);
        void SetBalance(decimal balance);
        void SetAccountOpenDate(DateTime openDate);
        void SetAccountStatus(string status);
        void LoadAccountTypes(List<AccountTypeModel> accountTypes);
        void LoadAccounts(List<AccountDisplayModel> accounts);
        void SetDateFilter(DateTime fromDate, DateTime toDate);

        // Điều khiển trạng thái control
        void EnableControls(bool enable);
        void EnableControls(bool enable, bool customerIDOnly, bool editMode = false);
        void EnableResetButtons(bool enable);
        void ClearInputs();
        void SetControlState(bool enableAdd, bool enableEdit, bool enableCancel, bool enableSave);

        // Hiển thị thông báo
        void ShowMessage(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon);
        DialogResult ShowConfirmation(string message, string title);
    }

    public partial class UC_AccountManagement : UserControl, IAccountManagementView
    {
        private readonly EmployeeCustomerAccountManagementController controller;

        public UC_AccountManagement(DatabaseContext dbContext, IConfiguration configuration)
        {
            InitializeComponent();
            // Cấu hình DataGridView
            dataGridViewAccountManagement.ReadOnly = true;
            dataGridViewAccountManagement.AllowUserToDeleteRows = false;
            dataGridViewAccountManagement.AutoGenerateColumns = false;
            dataGridViewAccountManagement.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewAccountManagement.MultiSelect = false; // Chỉ cho phép chọn một hàng

            this.controller = new EmployeeCustomerAccountManagementController(this, configuration, dbContext);
            InitializeControlState();
            controller.LoadInitialData();

            dataGridViewAccountManagement.SelectionChanged += dataGridViewAccountManagement_SelectionChanged;
            textBoxCustomerID.Leave += TextBoxCustomerID_Leave;
        }

        // Triển khai các phương thức lấy dữ liệu từ control
        public string GetCustomerID() => textBoxCustomerID.Text.Trim();
        public string GetAccountID() => textBoxAccountID.Text.Trim();
        public string GetAccountName() => textBoxAccountName.Text.Trim();
        public string GetAccountTypeName() => comboBoxAccountTypeName.SelectedItem?.ToString();
        public decimal GetBalance() => decimal.TryParse(textBoxBalance.Text, out decimal balance) ? balance : 0;
        public DateTime GetAccountOpenDate() => dateTimePickerAccountOpenDate.Value;
        public string GetAccountStatus() => comboBoxAccountStatus.SelectedItem?.ToString();
        public string GetStatusFilter() => comboBoxAccountStatusFilter.SelectedItem?.ToString() ?? "Không áp dụng";
        public string GetAccountTypeFilter() => comboBoxAccountTypeFilter.SelectedItem?.ToString() ?? "Không áp dụng";
        public DateTime GetFromDate() => dateTimePickerFrom.Value.Date; // Chỉ lấy ngày, bỏ giờ
        public DateTime GetToDate() => dateTimePickerTo.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59); // Bao gồm cả ngày cuối
        public string GetSearchText() => textBoxAccountSearch.Text.Trim();

        // Triển khai các phương thức lấy thông tin từ DataGridView
        public int GetSelectedRowCount() => dataGridViewAccountManagement.SelectedRows.Count;
        public DataGridViewRow GetSelectedRow() => dataGridViewAccountManagement.SelectedRows[0];

        // Triển khai các phương thức cập nhật dữ liệu lên control
        public void SetCustomerID(string customerID) => textBoxCustomerID.Text = customerID;
        public void SetAccountID(string accountID) => textBoxAccountID.Text = accountID;
        public void SetAccountName(string accountName) => textBoxAccountName.Text = accountName;
        public void SetAccountTypeName(string accountTypeName) => comboBoxAccountTypeName.SelectedItem = accountTypeName;
        public void SetBalance(decimal balance) => textBoxBalance.Text = balance.ToString("N0");
        public void SetAccountOpenDate(DateTime openDate) => dateTimePickerAccountOpenDate.Value = openDate;
        public void SetAccountStatus(string status) => comboBoxAccountStatus.SelectedItem = status;
        public void SetDateFilter(DateTime fromDate, DateTime toDate)
        {
            dateTimePickerFrom.Value = fromDate;
            dateTimePickerTo.Value = toDate;
        }

        private void TextBoxCustomerID_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxCustomerID.Text))
            {
                controller.OnCustomerIDChanged(); // Gọi trực tiếp phương thức của controller
            }
        }

        public void LoadAccountTypes(List<AccountTypeModel> accountTypes)
        {
            comboBoxAccountTypeName.Items.Clear();
            comboBoxAccountTypeFilter.Items.Clear();
            comboBoxAccountTypeFilter.Items.Add("Không áp dụng");
            foreach (var type in accountTypes)
            {
                comboBoxAccountTypeName.Items.Add(type.AccountTypeName);
                comboBoxAccountTypeFilter.Items.Add(type.AccountTypeName);
            }
            if (comboBoxAccountTypeFilter.Items.Count > 0)
                comboBoxAccountTypeFilter.SelectedIndex = 0; // Đặt giá trị mặc định
        }

        public void LoadAccounts(List<AccountDisplayModel> accounts)
        {
            dataGridViewAccountManagement.Rows.Clear();
            foreach (var account in accounts)
            {
                dataGridViewAccountManagement.Rows.Add(
                    account.CustomerCode, // Đã có tiền tố "KH"
                    account.AccountName,
                    account.AccountCode, // Đã có tiền tố "TK"
                    account.AccountTypeName,
                    account.Balance,
                    account.AccountOpenDate,
                    account.AccountStatus
                );
            }
        }

        // Điều khiển trạng thái control
        public void EnableControls(bool enable)
        {
            EnableControls(enable, false, false);
        }

        public void EnableControls(bool enable, bool customerIDOnly = false, bool editMode = false)
        {
            textBoxCustomerID.Enabled = enable && customerIDOnly; // Chỉ bật trong chế độ thêm
            textBoxAccountID.Enabled = false; // Luôn tắt
            textBoxAccountName.Enabled = enable && !customerIDOnly && !editMode; // Tắt trong editMode
            comboBoxAccountTypeName.Enabled = enable && !customerIDOnly && !editMode; // Tắt trong editMode
            textBoxBalance.Enabled = enable && !customerIDOnly && !editMode; // Tắt trong editMode
            comboBoxAccountStatus.Enabled = enable && !customerIDOnly; // Bật trong editMode hoặc chế độ thêm
            dateTimePickerAccountOpenDate.Enabled = enable && !customerIDOnly && !editMode; // Tắt trong editMode
        }

        public void EnableResetButtons(bool enable)
        {
            buttonResetPassword.Enabled = enable;
            buttonResetPINCode.Enabled = enable;
        }

        public void ClearInputs()
        {
            textBoxCustomerID.Clear();
            textBoxAccountID.Clear();
            textBoxAccountName.Clear();
            textBoxBalance.Clear();
            comboBoxAccountTypeName.SelectedIndex = -1;
            comboBoxAccountStatus.SelectedIndex = -1;
            dateTimePickerAccountOpenDate.Value = DateTime.Now;
        }

        public void SetControlState(bool enableAdd, bool enableEdit, bool enableCancel, bool enableSave)
        {
            // Button states
            buttonAddAccount.Enabled = enableAdd;
            buttonEditAccount.Enabled = enableEdit;
            buttonSaveAccount.Enabled = enableSave;
            buttonCancelAccount.Enabled = enableCancel;

            // Kiểm tra xem hàng được chọn có phải là hàng trống không
            bool isRowNotEmpty = dataGridViewAccountManagement.SelectedRows.Count > 0 && !dataGridViewAccountManagement.SelectedRows[0].IsNewRow;

            // Vô hiệu hóa các nút Reset Password và Reset PIN khi không có hàng nào được chọn
            buttonResetPassword.Enabled = enableEdit && isRowNotEmpty;
            buttonResetPINCode.Enabled = enableEdit && isRowNotEmpty;
        }

        // Hiển thị thông báo
        public void ShowMessage(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, buttons, icon);
        }

        public DialogResult ShowConfirmation(string message, string title)
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void InitializeControlState()
        {
            controller.InitializeControlState();

            // Initialize comboBoxAccountStatus
            comboBoxAccountStatus.Items.Clear();
            comboBoxAccountStatus.Items.AddRange(new string[] { "Hoạt động", "Khóa", "Đóng" });
            comboBoxAccountStatus.SelectedIndex = 0; // Default to "Hoạt động"

            // Initialize comboBoxAccountTypeFilter
            comboBoxAccountTypeFilter.Items.Clear();
            comboBoxAccountTypeFilter.Items.Add("Không áp dụng");

            // Initialize comboBoxStatusFilter
            comboBoxAccountStatusFilter.Items.Clear();
            comboBoxAccountStatusFilter.Items.AddRange(new string[] { "Không áp dụng", "Hoạt động", "Khóa", "Đóng" });
            comboBoxAccountStatusFilter.SelectedIndex = 0; // Default to "Không áp dụng"
        }

        // Sự kiện khi chọn một hàng trong DataGridView
        private void dataGridViewAccountManagement_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewAccountManagement.SelectedRows.Count > 0)
            {
                var row = dataGridViewAccountManagement.SelectedRows[0];
                if (!row.IsNewRow)
                {
                    var account = new AccountModel
                    {
                        CustomerID = int.Parse(row.Cells[0].Value.ToString().Replace("KH", "")), // Cột CustomerCode
                        AccountName = row.Cells[1].Value.ToString(), // Cột AccountName
                        AccountID = int.Parse(row.Cells[2].Value.ToString().Replace("TK", "")), // Cột AccountCode
                        AccountTypeID = row.Cells[3].Value.ToString() == "Cá nhân" ? 1 : 2, // Cột AccountTypeName
                        Balance = decimal.Parse(row.Cells[4].Value.ToString(), System.Globalization.NumberStyles.AllowThousands), // Cột Balance
                        AccountOpenDate = DateTime.ParseExact(row.Cells[5].Value.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture), // Cột AccountOpenDate
                        AccountStatus = row.Cells[6].Value.ToString() // Cột AccountStatus
                    };

                    // Load dữ liệu lên grAccountInfo nhưng không cho phép thao tác
                    SetCustomerID(row.Cells[0].Value.ToString()); // Giữ nguyên "KH"
                    SetAccountID(row.Cells[2].Value.ToString()); // Giữ nguyên "TK"
                    SetAccountName(account.AccountName);
                    SetAccountTypeName(account.AccountTypeID == 1 ? "Cá nhân" : "Doanh nghiệp");
                    SetBalance(account.Balance);
                    SetAccountOpenDate(account.AccountOpenDate);
                    SetAccountStatus(account.AccountStatus);

                    controller.OnAccountSelected(account);
                }
            }
            else
            {
                ClearInputs();
                controller.OnAccountDeselected();
            }
        }

        private void dataGridViewAccountManagement_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridViewAccountManagement.ClearSelection();
                dataGridViewAccountManagement.Rows[e.RowIndex].Selected = true;
            }
        }

        // Sự kiện click của các nút
        private void buttonAddAccount_Click(object sender, EventArgs e)
        {
            controller.OnAddAccountRequested();
        }

        private void buttonEditAccount_Click(object sender, EventArgs e)
        {
            controller.OnEditAccountRequested();
        }

        private void buttonCancelAccount_Click(object sender, EventArgs e)
        {
            controller.OnCancelAccountRequested();
        }

        private void buttonSaveAccount_Click(object sender, EventArgs e)
        {
            controller.OnSaveAccountRequested();
        }

        private void buttonResetPassword_Click(object sender, EventArgs e)
        {
            controller.OnResetPasswordRequested();
        }

        private void buttonResetPINCode_Click(object sender, EventArgs e)
        {
            controller.OnResetPINCodeRequested();
        }

        private void buttonAccountSearch_Click(object sender, EventArgs e)
        {
            controller.OnSearchAccountRequested();
        }

        private void buttonExportPDF_Click(object sender, EventArgs e)
        {
            controller.OnExportPDFRequested();
        }

        private void buttonExportExcel_Click(object sender, EventArgs e)
        {
            controller.OnExportExcelRequested();
        }

        private void buttonExportCSV_Click(object sender, EventArgs e)
        {
            controller.OnExportCSVRequested();
        }

        // Sự kiện thay đổi bộ lọc
        private void comboBoxAccountTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.LoadAccounts(GetFromDate(), GetToDate(), GetAccountTypeFilter(), GetStatusFilter());
        }

        private void comboBoxAccountStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.LoadAccounts(GetFromDate(), GetToDate(), GetAccountTypeFilter(), GetStatusFilter());
        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            controller.LoadAccounts(GetFromDate(), GetToDate(), GetAccountTypeFilter(), GetStatusFilter());
        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            controller.LoadAccounts(GetFromDate(), GetToDate(), GetAccountTypeFilter(), GetStatusFilter());
        }
    }


    public class AccountDisplayModel
    {
        public string CustomerCode { get; set; }
        public string AccountName { get; set; }
        public string AccountCode { get; set; }
        public string AccountTypeName { get; set; }
        public string Balance { get; set; } // Định dạng N0
        public string AccountOpenDate { get; set; } // Định dạng dd/MM/yyyy
        public string AccountStatus { get; set; }
    }
}
