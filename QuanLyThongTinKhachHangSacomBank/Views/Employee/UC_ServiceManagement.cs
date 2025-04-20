using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThongTinKhachHangSacomBank.Data;
using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Controllers;
using QuanLyThongTinKhachHangSacomBank.Models;

namespace QuanLyThongTinKhachHangSacomBank.Views.Employee
{
    public interface IServiceManagementView
    {
        string GetCustomerID();
        string GetAccountID();
        string GetAccountName();
        string GetServiceTypeName();
        string GetServiceID();
        decimal GetTotalPrincipalAmount();
        decimal GetInterestRate();
        decimal GetTotalInterestAmount();
        string GetDuration();
        string GetCreatedDate();
        string GetApplicableDate();
        string GetEndDate();
        string GetHandledBy();
        string GetApprovalStatus();
        string GetStatus();
        string GetServiceDescription();
        string GetServiceTypeFilter();
        string GetDurationFilter();
        string GetStatusFilter();
        string GetApprovalStatusFilter();
        DateTime GetDateFrom();
        DateTime GetDateTo();
        string GetSearchText();

        int GetSelectedRowCount();
        DataGridViewRow GetSelectedRow();
        DataGridView GetDataGridView();

        void SetCustomerID(string value);
        void SetAccountID(string value);
        void SetAccountName(string value);
        void SetServiceTypeName(string value);
        void SetServiceID(string value);
        void SetTotalPrincipalAmount(decimal value);
        void SetInterestRate(decimal value);
        void SetDuration(string value);
        void SetCreatedDate(string value);
        void SetApplicableDate(string value);
        void SetEndDate(string value);
        void SetHandledBy(string value);
        void SetApprovalStatus(string value);
        void SetStatus(string value);
        void SetServiceDescription(string value);
        void SetTotalInterestAmount(decimal value);
        void LoadServiceTypes(List<string> serviceTypes);
        void LoadDurations(List<string> durations);
        void UpdateDataGridView(List<ServiceDisplayModel> services);

        void EnableInputControls(bool enable, bool accountIDOnly = false, bool editModeLimited = false);
        void EnableButtons(bool add, bool delete, bool edit, bool cancel, bool save);
        void ClearInputs();
        void SetDateFilter(DateTime fromDate, DateTime toDate);

        void ShowMessage(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon);
        DialogResult ShowConfirmation(string message, string title);
    }

    public partial class UC_ServiceManagement : UserControl, IServiceManagementView
    {
        private readonly DatabaseContext dbContext;
        private EmployeeServiceManagementController controller;
        private bool isAdding;
        private bool isEditing;

        public UC_ServiceManagement(DatabaseContext dbContext, IConfiguration configuration, EmployeeModel currentEmployee = null)
        {
            InitializeComponent();
            this.dbContext = dbContext;
            controller = new EmployeeServiceManagementController(this, configuration, dbContext, currentEmployee);
            isAdding = false;
            isEditing = false;

            dataGridViewServiceManagement.ReadOnly = true;
            dataGridViewServiceManagement.AllowUserToDeleteRows = false;
            dataGridViewServiceManagement.AutoGenerateColumns = false;
            dataGridViewServiceManagement.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewServiceManagement.MultiSelect = false;

            InitializeControlState();
            controller.LoadInitialData();

            dataGridViewServiceManagement.SelectionChanged += DataGridViewServiceManagement_SelectionChanged;
            textBoxAccountID.Leave += TextBoxAccountID_Leave;
            comboBoxServiceTypeName.SelectedIndexChanged += ComboBoxServiceTypeName_SelectedIndexChanged;
            comboBoxDuration.SelectedIndexChanged += ComboBoxDuration_SelectedIndexChanged;
            textBoxTotalPrincipalAmount.TextChanged += TextBoxTotalPrincipalAmount_TextChanged;
            textBoxTotalPrincipalAmount.KeyPress += TextBoxTotalPrincipalAmount_KeyPress;
        }

        private void InitializeControlState()
        {
            comboBoxServiceTypeFilter.Items.Clear();
            comboBoxServiceTypeFilter.Items.Add("Không áp dụng");
            comboBoxServiceTypeFilter.SelectedIndex = 0;

            comboBoxDurationFilter.Items.Clear();
            comboBoxDurationFilter.Items.AddRange(new string[] { "Không áp dụng", "12 tháng", "24 tháng", "36 tháng" });
            comboBoxDurationFilter.SelectedIndex = 0;

            comboBoxDuration.Items.Clear();
            comboBoxDuration.Items.AddRange(new string[] { "12 tháng", "24 tháng", "36 tháng" });
            comboBoxDuration.SelectedIndex = -1;

            comboBoxStatusFilter.Items.Clear();
            comboBoxStatusFilter.Items.AddRange(new string[] { "Không áp dụng", "Chờ hoạt động", "Đang hoạt động", "Đã tất toán", "Hủy", "Trễ hạn thanh toán" });
            comboBoxStatusFilter.SelectedIndex = 0;

            comboBoxApprovalStatusFilter.Items.Clear();
            comboBoxApprovalStatusFilter.Items.AddRange(new string[] { "Không áp dụng", "Chờ duyệt", "Đã duyệt", "Từ chối" });
            comboBoxApprovalStatusFilter.SelectedIndex = 0;

            comboBoxApprovalStatus.Items.Clear();
            comboBoxApprovalStatus.Items.AddRange(new string[] { "Chờ duyệt", "Đã duyệt", "Từ chối" });
            comboBoxApprovalStatus.SelectedIndex = 0;

            comboBoxServiceStatus.Items.Clear();
            comboBoxServiceStatus.Items.AddRange(new string[] { "Chờ hoạt động", "Đang hoạt động", "Đã tất toán", "Hủy", "Trễ hạn thanh toán" });
            comboBoxServiceStatus.SelectedIndex = 0;

            EnableInputControls(false);
            EnableButtons(true, false, false, false, false);
        }

        public string GetCustomerID() => textBoxCustomerID.Text.Trim();
        public string GetAccountID() => textBoxAccountID.Text.Trim();
        public string GetAccountName() => textBoxAccountName.Text.Trim();
        public string GetServiceTypeName() => comboBoxServiceTypeName.SelectedItem?.ToString();
        public string GetServiceID() => textBoxServiceID.Text.Trim();
        public decimal GetTotalPrincipalAmount()
        {
            string text = textBoxTotalPrincipalAmount.Text.Replace(",", "");
            return decimal.TryParse(text, out decimal amount) ? amount : 0;
        }
        public decimal GetInterestRate()
        {
            string text = textBoxInterestRate.Text.Replace("%/năm", "").Trim();
            return decimal.TryParse(text, out decimal rate) ? rate : 0;
        }
        public decimal GetTotalInterestAmount()
        {
            string text = textBoxTotalInterestAmount.Text.Replace(",", "");
            return decimal.TryParse(text, out decimal amount) ? amount : 0;
        }
        public string GetDuration() => comboBoxDuration.SelectedItem?.ToString();
        public string GetCreatedDate() => dateTimePickerCreatedDate.Value.ToString("dd/MM/yyyy HH:mm:ss");
        public string GetApplicableDate() => dateTimePickerApplicableDate.Value.ToString("dd/MM/yyyy HH:mm:ss");
        public string GetEndDate() => dateTimePickerEndDate.Value.ToString("dd/MM/yyyy HH:mm:ss");
        public string GetHandledBy() => textBoxHandledBy.Text.Trim();
        public string GetApprovalStatus() => comboBoxApprovalStatus.SelectedItem?.ToString() ?? "Chờ duyệt";
        public string GetStatus() => comboBoxServiceStatus.SelectedItem?.ToString() ?? "Chờ hoạt động";
        public string GetServiceDescription() => richTextBoxServiceDescription.Text.Trim();
        public string GetServiceTypeFilter() => comboBoxServiceTypeFilter.SelectedItem?.ToString() ?? "Không áp dụng";
        public string GetDurationFilter() => comboBoxDurationFilter.SelectedItem?.ToString() ?? "Không áp dụng";
        public string GetStatusFilter() => comboBoxStatusFilter.SelectedItem?.ToString() ?? "Không áp dụng";
        public string GetApprovalStatusFilter() => comboBoxApprovalStatusFilter.SelectedItem?.ToString() ?? "Không áp dụng";
        public DateTime GetDateFrom() => dateTimePickerFrom.Value.Date;
        public DateTime GetDateTo() => dateTimePickerTo.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
        public string GetSearchText() => textBoxServiceSearch.Text.Trim();

        public int GetSelectedRowCount() => dataGridViewServiceManagement.SelectedRows.Count;
        public DataGridViewRow GetSelectedRow() => dataGridViewServiceManagement.SelectedRows[0];
        public DataGridView GetDataGridView() => dataGridViewServiceManagement;

        public void SetCustomerID(string value) => textBoxCustomerID.Text = value;
        public void SetAccountID(string value) => textBoxAccountID.Text = value;
        public void SetAccountName(string value) => textBoxAccountName.Text = value;
        public void SetServiceTypeName(string value) => comboBoxServiceTypeName.SelectedItem = value;
        public void SetServiceID(string value) => textBoxServiceID.Text = value;
        public void SetTotalPrincipalAmount(decimal value) => textBoxTotalPrincipalAmount.Text = value.ToString("N0");
        public void SetInterestRate(decimal value) => textBoxInterestRate.Text = value.ToString("F2") + " %/năm";
        public void SetDuration(string value) => comboBoxDuration.SelectedItem = value;

        public void SetCreatedDate(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                dateTimePickerCreatedDate.Format = DateTimePickerFormat.Custom;
                dateTimePickerCreatedDate.CustomFormat = " ";
                return;
            }

            try
            {
                DateTime createdDate = DateTime.ParseExact(value, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                dateTimePickerCreatedDate.Format = DateTimePickerFormat.Custom;
                dateTimePickerCreatedDate.CustomFormat = "dd/MM/yyyy HH:mm:ss";
                dateTimePickerCreatedDate.Value = createdDate;
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Lỗi định dạng ngày tháng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePickerCreatedDate.Format = DateTimePickerFormat.Custom;
                dateTimePickerCreatedDate.CustomFormat = " ";
            }
        }

        public void SetApplicableDate(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                dateTimePickerApplicableDate.Format = DateTimePickerFormat.Custom;
                dateTimePickerApplicableDate.CustomFormat = " ";
                return;
            }

            try
            {
                DateTime applicableDate = DateTime.ParseExact(value, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                dateTimePickerApplicableDate.Format = DateTimePickerFormat.Custom;
                dateTimePickerApplicableDate.CustomFormat = "dd/MM/yyyy HH:mm:ss";
                dateTimePickerApplicableDate.Value = applicableDate;
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Lỗi định dạng ngày tháng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePickerApplicableDate.Format = DateTimePickerFormat.Custom;
                dateTimePickerApplicableDate.CustomFormat = " ";
            }
        }

        public void SetEndDate(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                dateTimePickerEndDate.Format = DateTimePickerFormat.Custom;
                dateTimePickerEndDate.CustomFormat = " ";
                return;
            }

            try
            {
                DateTime endDate = DateTime.ParseExact(value, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                dateTimePickerEndDate.Format = DateTimePickerFormat.Custom;
                dateTimePickerEndDate.CustomFormat = "dd/MM/yyyy HH:mm:ss";
                dateTimePickerEndDate.Value = endDate;
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Lỗi định dạng ngày tháng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePickerEndDate.Format = DateTimePickerFormat.Custom;
                dateTimePickerEndDate.CustomFormat = " ";
            }
        }

        public void SetHandledBy(string value) => textBoxHandledBy.Text = value;
        public void SetApprovalStatus(string value) => comboBoxApprovalStatus.SelectedItem = value;
        public void SetStatus(string value) => comboBoxServiceStatus.SelectedItem = value;
        public void SetServiceDescription(string value) => richTextBoxServiceDescription.Text = value;
        public void SetTotalInterestAmount(decimal value) => textBoxTotalInterestAmount.Text = value.ToString("N0");

        public void LoadServiceTypes(List<string> serviceTypes)
        {
            comboBoxServiceTypeName.Items.Clear();
            comboBoxServiceTypeFilter.Items.Clear();
            comboBoxServiceTypeFilter.Items.Add("Không áp dụng");
            foreach (var type in serviceTypes)
            {
                comboBoxServiceTypeName.Items.Add(type);
                comboBoxServiceTypeFilter.Items.Add(type);
            }
            if (comboBoxServiceTypeFilter.Items.Count > 0)
                comboBoxServiceTypeFilter.SelectedIndex = 0;
        }

        public void LoadDurations(List<string> durations)
        {
            comboBoxDuration.Items.Clear();
            comboBoxDurationFilter.Items.Clear();
            comboBoxDurationFilter.Items.Add("Không áp dụng");
            foreach (var duration in durations)
            {
                comboBoxDuration.Items.Add(duration);
                comboBoxDurationFilter.Items.Add(duration);
            }
            if (comboBoxDurationFilter.Items.Count > 0)
                comboBoxDurationFilter.SelectedIndex = 0;
        }

        public void UpdateDataGridView(List<ServiceDisplayModel> services)
        {
            dataGridViewServiceManagement.Rows.Clear();
            if (services == null || services.Count == 0)
            {
                return;
            }

            foreach (var service in services)
            {
                int rowIndex = dataGridViewServiceManagement.Rows.Add(
                    service.CustomerCode,
                    service.AccountName,
                    service.AccountCode,
                    service.ServiceTypeName,
                    service.ServiceCode,
                    service.TotalPrincipalAmount,
                    service.ServiceDescription,
                    service.Duration,
                    service.InterestRate,
                    service.TotalInterestAmount,
                    service.CreatedDate,
                    service.ApplicableDate,
                    service.EndDate,
                    service.HandledBy,
                    service.ApprovalStatus,
                    service.ServiceStatus
                );

                // Lưu ServiceID gốc vào Tag của hàng
                dataGridViewServiceManagement.Rows[rowIndex].Tag = service.ServiceID;
            }

            // Ngăn DataGridView tự động chọn hàng đầu tiên sau khi làm mới
            dataGridViewServiceManagement.ClearSelection();
        }

        public void SetDateFilter(DateTime fromDate, DateTime toDate)
        {
            dateTimePickerFrom.Value = fromDate;
            dateTimePickerTo.Value = toDate;
        }

        public void EnableInputControls(bool enable, bool accountIDOnly = false, bool editModeLimited = false)
        {
            textBoxAccountID.Enabled = enable && (accountIDOnly || !editModeLimited);
            comboBoxServiceTypeName.Enabled = enable && !accountIDOnly && !editModeLimited;
            textBoxTotalPrincipalAmount.Enabled = enable && !accountIDOnly; // Luôn bật khi sửa
            comboBoxDuration.Enabled = enable && !accountIDOnly; // Luôn bật khi sửa
            richTextBoxServiceDescription.Enabled = enable && !accountIDOnly; // Luôn bật khi sửa

            textBoxCustomerID.Enabled = false;
            textBoxServiceID.Enabled = false;
            textBoxInterestRate.Enabled = false;
            textBoxTotalInterestAmount.Enabled = false;
            dateTimePickerCreatedDate.Enabled = false;
            dateTimePickerApplicableDate.Enabled = false;
            dateTimePickerEndDate.Enabled = false;
            textBoxHandledBy.Enabled = false;
            comboBoxApprovalStatus.Enabled = false;
            comboBoxServiceStatus.Enabled = false;

            textBoxAccountName.ReadOnly = true;
        }

        public void EnableButtons(bool add, bool delete, bool edit, bool cancel, bool save)
        {
            buttonAddService.Enabled = add;
            buttonDeleteService.Enabled = delete && dataGridViewServiceManagement.SelectedRows.Count > 0;
            buttonEditService.Enabled = edit && dataGridViewServiceManagement.SelectedRows.Count > 0;
            buttonCancelService.Enabled = cancel;
            buttonSaveService.Enabled = save;
        }

        public void ClearInputs()
        {
            textBoxCustomerID.Clear();
            textBoxAccountID.Clear();
            textBoxAccountName.Clear();
            textBoxServiceID.Clear();
            textBoxTotalPrincipalAmount.Clear();
            textBoxInterestRate.Clear();
            textBoxTotalInterestAmount.Clear();
            comboBoxServiceTypeName.SelectedIndex = -1;
            comboBoxDuration.SelectedIndex = -1;
            dateTimePickerCreatedDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerCreatedDate.CustomFormat = " ";
            dateTimePickerApplicableDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerApplicableDate.CustomFormat = " ";
            dateTimePickerEndDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerEndDate.CustomFormat = " ";
            textBoxHandledBy.Clear();
            comboBoxApprovalStatus.SelectedIndex = 0;
            comboBoxServiceStatus.SelectedIndex = 0;
            richTextBoxServiceDescription.Clear();
        }

        private void DataGridViewServiceManagement_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewServiceManagement.SelectedRows.Count > 0)
            {
                var row = dataGridViewServiceManagement.SelectedRows[0];
                if (!row.IsNewRow && row.Tag != null) // Kiểm tra Tag không null
                {
                    try
                    {
                        string employeeName = row.Cells[13].Value?.ToString() ?? "";

                        var service = new ServiceModel
                        {
                            ServiceID = (int)row.Tag,
                            CustomerID = row.Cells[0].Value != null ? int.Parse(row.Cells[0].Value.ToString().Replace("KH", "")) : 0,
                            AccountID = row.Cells[2].Value != null ? int.Parse(row.Cells[2].Value.ToString().Replace("TK", "")) : 0,
                            ServiceCode = row.Cells[4].Value?.ToString() ?? "",
                            ServiceTypeID = row.Cells[3].Value?.ToString() == "Gửi tiết kiệm" ? 1 : (row.Cells[3].Value?.ToString() == "Vay vốn" ? 2 : 0),
                            TotalPrincipalAmount = row.Cells[5].Value != null ? decimal.Parse(row.Cells[5].Value.ToString(), System.Globalization.NumberStyles.AllowThousands) : 0,
                            InterestRate = row.Cells[8].Value != null ? decimal.Parse(row.Cells[8].Value.ToString().Replace("%/năm", "").Trim()) : 0,
                            TotalInterestAmount = string.IsNullOrEmpty(row.Cells[9].Value?.ToString()) ? null : decimal.Parse(row.Cells[9].Value.ToString(), System.Globalization.NumberStyles.AllowThousands),
                            Duration = row.Cells[7].Value?.ToString() ?? "",
                            CreatedDate = row.Cells[10].Value != null ? DateTime.ParseExact(row.Cells[10].Value.ToString(), "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) : DateTime.Now,
                            ApplicableDate = string.IsNullOrEmpty(row.Cells[11].Value?.ToString()) ? null : DateTime.ParseExact(row.Cells[11].Value.ToString(), "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                            EndDate = string.IsNullOrEmpty(row.Cells[12].Value?.ToString()) ? null : DateTime.ParseExact(row.Cells[12].Value.ToString(), "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                            HandledBy = controller.GetEmployeeIDFromName(employeeName),
                            ApprovalStatus = row.Cells[14].Value?.ToString() ?? "",
                            ServiceStatus = row.Cells[15].Value?.ToString() ?? "",
                            ServiceDescription = row.Cells[6].Value?.ToString() ?? "",
                        };

                        if (isAdding || isEditing)
                        {
                            ShowMessage("Bạn đang ở chế độ thêm hoặc sửa, không thể chọn dịch vụ khác!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ClearInputs();
                            EnableInputControls(false);
                            EnableButtons(false, false, false, true, false);
                            return;
                        }

                        // Cập nhật giao diện với dịch vụ được chọn
                        SetCustomerID(row.Cells[0].Value?.ToString() ?? "");
                        SetAccountID(row.Cells[2].Value?.ToString() ?? "");
                        SetAccountName(row.Cells[1].Value?.ToString() ?? "");
                        SetServiceTypeName(row.Cells[3].Value?.ToString() ?? "");
                        SetServiceID(row.Cells[4].Value?.ToString() ?? "");
                        SetTotalPrincipalAmount(service.TotalPrincipalAmount);
                        SetInterestRate(service.InterestRate);
                        SetTotalInterestAmount(service.TotalInterestAmount ?? 0);
                        SetDuration(service.Duration);
                        SetCreatedDate(service.CreatedDate.ToString("dd/MM/yyyy HH:mm:ss"));
                        SetApplicableDate(service.ApplicableDate?.ToString("dd/MM/yyyy HH:mm:ss") ?? "");
                        SetEndDate(service.EndDate?.ToString("dd/MM/yyyy HH:mm:ss") ?? "");
                        SetApprovalStatus(service.ApprovalStatus);
                        SetStatus(service.ServiceStatus);
                        SetServiceDescription(service.ServiceDescription);
                        SetHandledBy(employeeName);
                        controller.OnServiceSelected(service);

                        bool isPendingApproval = service.ApprovalStatus == "Chờ duyệt";
                        EnableButtons(true, isPendingApproval, isPendingApproval, true, false);
                    }
                    catch (Exception ex)
                    {
                        ShowMessage($"Lỗi khi chọn dịch vụ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ClearInputs();
                        controller.OnServiceDeselected();
                        EnableButtons(true, false, false, false, false);
                    }
                }
            }
            else
            {
                ClearInputs();
                EnableInputControls(false, false, false); // Bật các textbox, không chỉ định accountIDOnly hay editModeLimited
                EnableButtons(false, false, false, false, false);
                if (!isAdding && !isEditing)
                {
                    controller.OnServiceDeselected();
                    EnableButtons(false, false, false, false, false); // Tắt hết các nút
                }
            }
        }


        private void TextBoxAccountID_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxAccountID.Text))
            {
                controller.OnAccountIDChanged();
            }
        }

        public void ShowMessage(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, buttons, icon);
        }

        public DialogResult ShowConfirmation(string message, string title)
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void ComboBoxServiceTypeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxCustomerID.Text))
            {
                controller.CalculateInterestRate();
            }
        }

        private void ComboBoxDuration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxCustomerID.Text))
            {
                controller.CalculateInterestRate();
            }
        }

        private void TextBoxTotalPrincipalAmount_TextChanged(object sender, EventArgs e)
        {
            string text = textBoxTotalPrincipalAmount.Text.Replace(",", "");
            if (string.IsNullOrEmpty(text)) return;

            if (decimal.TryParse(text, out decimal number))
            {
                textBoxTotalPrincipalAmount.TextChanged -= TextBoxTotalPrincipalAmount_TextChanged;
                textBoxTotalPrincipalAmount.Text = number.ToString("#,##0");
                textBoxTotalPrincipalAmount.SelectionStart = textBoxTotalPrincipalAmount.Text.Length;
                textBoxTotalPrincipalAmount.TextChanged += TextBoxTotalPrincipalAmount_TextChanged;
            }

            if (!string.IsNullOrWhiteSpace(textBoxCustomerID.Text))
            {
                controller.CalculateInterestRate();
            }
        }

        private void TextBoxTotalPrincipalAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép các phím điều khiển như Backspace
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // Chỉ cho phép nhập số (0-9)
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }
        }



        private void buttonAddService_Click(object sender, EventArgs e)
        {
            isAdding = true;
            controller.AddService();
        }

        private void buttonDeleteService_Click(object sender, EventArgs e)
        {
            controller.DeleteService();
        }

        private void buttonEditService_Click(object sender, EventArgs e)
        {
            isEditing = true;
            controller.EditService();
        }

        private void buttonCancelService_Click(object sender, EventArgs e)
        {
            isAdding = false;
            isEditing = false;
            controller.CancelService();
        }

        private void buttonSaveService_Click(object sender, EventArgs e)
        {
            isAdding = false;
            isEditing = false;
            controller.SaveService();
        }

        private void buttonServiceSearch_Click(object sender, EventArgs e)
        {
            controller.SearchServices();
        }

        private void comboBoxServiceTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.SearchServices();
        }

        private void comboBoxDurationFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.SearchServices();
        }

        private void comboBoxApprovalStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.SearchServices();
        }

        private void comboBoxStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.SearchServices();
        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            controller.SearchServices();
        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            controller.SearchServices();
        }

        private void buttonExportPDF_Click(object sender, EventArgs e)
        {
            controller.ExportToPDF();
        }

        private void buttonExportExcel_Click(object sender, EventArgs e)
        {
            controller.ExportToExcel();
        }

        private void buttonExportCSV_Click(object sender, EventArgs e)
        {
            controller.ExportToCSV();
        }

        private void buttonCancelSavings_Click(object sender, EventArgs e)
        {
            controller.CancelSavings();
        }

        private void buttonLoanPrepayment_Click(object sender, EventArgs e)
        {
            controller.LoanPrepayment();
        }
    }

    public class ServiceDisplayModel
    {
        public int ServiceID { get; set; }
        public string ServiceCode { get; set; }
        public string AccountCode { get; set; }
        public string CustomerCode { get; set; }
        public string AccountName { get; set; }
        public string ServiceTypeName { get; set; }
        public string TotalPrincipalAmount { get; set; }
        public string InterestRate { get; set; }
        public string Duration { get; set; }
        public string CreatedDate { get; set; }
        public string ApplicableDate { get; set; }
        public string EndDate { get; set; }
        public string ApprovalStatus { get; set; }
        public string ServiceStatus { get; set; }
        public string HandledBy { get; set; }
        public string ServiceDescription { get; set; }
        public string TotalInterestAmount { get; set; }
    }
}