using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThongTinKhachHangSacomBank.Data;
using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Controllers;
using QuanLyThongTinKhachHangSacomBank.Models;

namespace QuanLyThongTinKhachHangSacomBank.Views.Manager
{
    public interface IServiceRequestManagementView
    {
        void SetCustomerID(string value);
        void SetAccountName(string value);
        void SetAccountID(string value);
        void SetServiceTypeName(string value);
        void SetServiceID(string value);
        void SetTotalPrincipalAmount(decimal value);
        void SetServiceDescription(string value);
        void SetDuration(string value);
        void SetInterestRate(decimal value);
        void SetTotalInterestAmount(decimal value);
        void SetCreatedDate(string value);
        void SetApplicableDate(string value);
        void SetEndDate(string value);
        void SetHandledBy(string value);
        void SetApprovalStatus(string value);
        void SetServiceStatus(string value);

        void EnableApproveButton(bool enable);
        void EnableDeclineButton(bool enable);
        void UpdateDataGridView(List<ServiceRequestDisplayModel> serviceRequests);
        void ShowMessage(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon);
        void ClearInputs();
        void LoadServiceTypes(List<string> serviceTypes);
        void SetDateFilter(DateTime fromDate, DateTime toDate);

        string GetServiceTypeFilter();
        string GetDurationFilter();
        string GetStatusFilter();
        string GetApprovalStatusFilter();
        DateTime GetDateFrom();
        DateTime GetDateTo();
        string GetSearchText();
    }

    public partial class UC_ServiceRequestManagement : UserControl, IServiceRequestManagementView
    {
        private readonly DatabaseContext dbContext;
        private ManagerServiceRequestManagementController controller;


        public UC_ServiceRequestManagement(DatabaseContext dbContext, IConfiguration configuration)
        {
            InitializeComponent();
            this.dbContext = dbContext;
            controller = new ManagerServiceRequestManagementController(this, configuration, dbContext);

            dataGridViewServiceRequestManagement.ReadOnly = true;
            dataGridViewServiceRequestManagement.AllowUserToDeleteRows = false;
            dataGridViewServiceRequestManagement.AutoGenerateColumns = false;
            dataGridViewServiceRequestManagement.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewServiceRequestManagement.MultiSelect = false;

            InitializeControlState();
            controller.LoadInitialData();

            dataGridViewServiceRequestManagement.SelectionChanged += DataGridViewServiceRequestManagement_SelectionChanged;
        }

        private void InitializeControlState()
        {
            comboBoxServiceTypeFilter.Items.Clear();
            comboBoxServiceTypeFilter.Items.Add("Không áp dụng");
            comboBoxServiceTypeFilter.SelectedIndex = 0;

            comboBoxDurationFilter.Items.Clear();
            comboBoxDurationFilter.Items.AddRange(new string[] { "Không áp dụng", "12 tháng", "24 tháng", "36 tháng" });
            comboBoxDurationFilter.SelectedIndex = 0;

            comboBoxApprovalStatusFilter.Items.Clear();
            comboBoxApprovalStatusFilter.Items.AddRange(new string[] { "Không áp dụng", "Chờ duyệt", "Đã duyệt", "Từ chối" });
            comboBoxApprovalStatusFilter.SelectedIndex = 0;

            comboBoxStatusFilter.Items.Clear();
            comboBoxStatusFilter.Items.AddRange(new string[] { "Không áp dụng", "Chờ hoạt động", "Đang hoạt động", "Đã tất toán", "Hủy", "Trễ hạn thanh toán" });
            comboBoxStatusFilter.SelectedIndex = 0;

            comboBoxServiceTypeName.Items.Clear();
            comboBoxServiceTypeName.Items.AddRange(new string[] { "Gửi tiết kiệm", "Vay vốn" });
            comboBoxServiceTypeName.SelectedIndex = -1;
            comboBoxServiceTypeName.Enabled = false;

            comboBoxDuration.Items.Clear();
            comboBoxDuration.Items.AddRange(new string[] { "12 tháng", "24 tháng", "36 tháng" });
            comboBoxDuration.SelectedIndex = -1;
            comboBoxDuration.Enabled = false;

            comboBoxApprovalStatus.Items.Clear();
            comboBoxApprovalStatus.Items.AddRange(new string[] { "Chờ duyệt", "Đã duyệt", "Từ chối" });
            comboBoxApprovalStatus.SelectedIndex = -1;
            comboBoxApprovalStatus.Enabled = false;

            comboBoxServiceStatus.Items.Clear();
            comboBoxServiceStatus.Items.AddRange(new string[] { "Chờ hoạt động", "Đang hoạt động", "Đã tất toán", "Hủy", "Trễ hạn thanh toán" });
            comboBoxServiceStatus.SelectedIndex = -1;
            comboBoxServiceStatus.Enabled = false;

            // Disable tất cả các TextBox và RichTextBox
            textBoxCustomerID.Enabled = false;
            textBoxAccountName.Enabled = false;
            textBoxAccountID.Enabled = false;
            textBoxServiceID.Enabled = false;
            textBoxTotalPrincipalAmount.Enabled = false;
            textBoxInterestRate.Enabled = false;
            textBoxTotalInterestAmount.Enabled = false;
            richTextBoxServiceDescription.Enabled = false;
            textBoxHandledBy.Enabled = false;

            // Disable các DateTimePicker
            dateTimePickerCreatedDate.Enabled = false;
            dateTimePickerApplicableDate.Enabled = false;
            dateTimePickerEndDate.Enabled = false;

            EnableApproveButton(false);
            EnableDeclineButton(false);
        }

        // Triển khai các phương thức lấy giá trị từ giao diện
        public string GetServiceTypeFilter() => comboBoxServiceTypeFilter.SelectedItem?.ToString() ?? "Không áp dụng";
        public string GetDurationFilter() => comboBoxDurationFilter.SelectedItem?.ToString() ?? "Không áp dụng";
        public string GetStatusFilter() => comboBoxStatusFilter.SelectedItem?.ToString() ?? "Không áp dụng";
        public string GetApprovalStatusFilter() => comboBoxApprovalStatusFilter.SelectedItem?.ToString() ?? "Không áp dụng";
        public DateTime GetDateFrom() => dateTimePickerFrom.Value.Date;
        public DateTime GetDateTo() => dateTimePickerTo.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
        public string GetSearchText() => textBoxServiceSearch.Text.Trim();
        

        // Triển khai các phương thức của IServiceRequestManagementView
        public void SetCustomerID(string value) => textBoxCustomerID.Text = value;
        public void SetAccountName(string value) => textBoxAccountName.Text = value;
        public void SetAccountID(string value) => textBoxAccountID.Text = value;
        public void SetServiceTypeName(string value) => comboBoxServiceTypeName.SelectedItem = value;
        public void SetServiceID(string value) => textBoxServiceID.Text = value;
        public void SetTotalPrincipalAmount(decimal value) => textBoxTotalPrincipalAmount.Text = value.ToString("N0");
        public void SetServiceDescription(string value) => richTextBoxServiceDescription.Text = value;
        public void SetDuration(string value) => comboBoxDuration.SelectedItem = value;
        public void SetInterestRate(decimal value) => textBoxInterestRate.Text = value.ToString("F2") + " %/năm";
        public void SetTotalInterestAmount(decimal value) => textBoxTotalInterestAmount.Text = value.ToString("N0");

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
                ShowMessage($"Lỗi định dạng ngày tháng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                ShowMessage($"Lỗi định dạng ngày tháng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                ShowMessage($"Lỗi định dạng ngày tháng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePickerEndDate.Format = DateTimePickerFormat.Custom;
                dateTimePickerEndDate.CustomFormat = " ";
            }
        }

        public void SetHandledBy(string value) => textBoxHandledBy.Text = value;
        public void SetApprovalStatus(string value) => comboBoxApprovalStatus.SelectedItem = value;
        public void SetServiceStatus(string value) => comboBoxServiceStatus.SelectedItem = value;

        public void EnableApproveButton(bool enable) => buttonApproveService.Enabled = enable;
        public void EnableDeclineButton(bool enable) => buttonDeclineService.Enabled = enable;

        public void UpdateDataGridView(List<ServiceRequestDisplayModel> serviceRequests)
        {
            dataGridViewServiceRequestManagement.Rows.Clear();
            if (serviceRequests == null || serviceRequests.Count == 0)
            {
                return;
            }

            foreach (var service in serviceRequests)
            {
                int rowIndex = dataGridViewServiceRequestManagement.Rows.Add(
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
                dataGridViewServiceRequestManagement.Rows[rowIndex].Tag = service.ServiceID;
            }

            // Ngăn DataGridView tự động chọn hàng đầu tiên sau khi làm mới
            dataGridViewServiceRequestManagement.ClearSelection();
        }

        public void ShowMessage(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, buttons, icon);
        }

        private void DataGridViewServiceRequestManagement_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewServiceRequestManagement.SelectedRows.Count > 0)
            {
                var row = dataGridViewServiceRequestManagement.SelectedRows[0];
                if (!row.IsNewRow && row.Tag != null) // Kiểm tra Tag không null
                {
                    try
                    {
                        string employeeName = row.Cells[13].Value?.ToString() ?? "";

                        var serviceRequest = new ServiceModel
                        {
                            ServiceID = (int)row.Tag,
                            CustomerID = row.Cells[0].Value != null ? int.Parse(row.Cells[0].Value.ToString().Replace("KH", "")) : 0,
                            AccountID = row.Cells[2].Value != null ? int.Parse(row.Cells[2].Value.ToString().Replace("TK", "")) : 0,
                            ServiceCode = row.Cells[4].Value?.ToString() ?? "",
                            ServiceTypeID = row.Cells[3].Value?.ToString() == "Vay vốn" ? 1 : (row.Cells[3].Value?.ToString() == "Gửi tiết kiệm" ? 2 : 0),
                            TotalPrincipalAmount = row.Cells[5].Value != null ? decimal.Parse(row.Cells[5].Value.ToString(), System.Globalization.NumberStyles.AllowThousands) : 0,
                            InterestRate = row.Cells[8].Value != null ? decimal.Parse(row.Cells[8].Value.ToString().Replace("%/năm", "").Trim()) : 0,
                            TotalInterestAmount = string.IsNullOrEmpty(row.Cells[9].Value?.ToString()) ? null : decimal.Parse(row.Cells[9].Value.ToString(), System.Globalization.NumberStyles.AllowThousands),
                            Duration = row.Cells[7].Value?.ToString() ?? "",
                            CreatedDate = row.Cells[10].Value != null ? DateTime.ParseExact(row.Cells[10].Value.ToString(), "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) : DateTime.Now,
                            ApplicableDate = string.IsNullOrEmpty(row.Cells[11].Value?.ToString()) ? null : DateTime.ParseExact(row.Cells[11].Value.ToString(), "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                            EndDate = string.IsNullOrEmpty(row.Cells[12].Value?.ToString()) ? null : DateTime.ParseExact(row.Cells[12].Value.ToString(), "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                            HandledBy = string.IsNullOrEmpty(employeeName) ? null : controller.GetEmployeeIDFromName(employeeName),
                            ApprovalStatus = row.Cells[14].Value?.ToString() ?? "",
                            ServiceStatus = row.Cells[15].Value?.ToString() ?? "",
                            ServiceDescription = row.Cells[6].Value?.ToString() ?? ""
                            // Không cần gán AccountName vì ServiceModel không có thuộc tính này
                        };

                        // Hiển thị thông tin lên giao diện
                        SetCustomerID(row.Cells[0].Value?.ToString() ?? "");
                        SetAccountID(row.Cells[2].Value?.ToString() ?? "");
                        SetAccountName(row.Cells[1].Value?.ToString() ?? ""); // Lấy AccountName trực tiếp từ DGV
                        SetServiceTypeName(row.Cells[3].Value?.ToString() ?? "");
                        SetServiceID(row.Cells[4].Value?.ToString() ?? "");
                        SetTotalPrincipalAmount(serviceRequest.TotalPrincipalAmount);
                        SetInterestRate(serviceRequest.InterestRate);
                        SetTotalInterestAmount(serviceRequest.TotalInterestAmount ?? 0);
                        SetDuration(serviceRequest.Duration);
                        SetCreatedDate(serviceRequest.CreatedDate.ToString("dd/MM/yyyy HH:mm:ss"));
                        SetApplicableDate(serviceRequest.ApplicableDate?.ToString("dd/MM/yyyy HH:mm:ss") ?? "");
                        SetEndDate(serviceRequest.EndDate?.ToString("dd/MM/yyyy HH:mm:ss") ?? "");
                        SetApprovalStatus(serviceRequest.ApprovalStatus);
                        SetServiceStatus(serviceRequest.ServiceStatus);
                        SetServiceDescription(serviceRequest.ServiceDescription);
                        SetHandledBy(employeeName);

                        controller.OnServiceRequestSelected(serviceRequest);
                    }
                    catch (Exception ex)
                    {
                        ShowMessage($"Lỗi khi chọn dịch vụ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ClearInputs();
                        controller.OnServiceRequestDeselected();
                    }
                }
            }
            else
            {
                ClearInputs();
                controller.OnServiceRequestDeselected();
            }
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
            comboBoxApprovalStatus.SelectedIndex = -1;
            comboBoxServiceStatus.SelectedIndex = -1;
            richTextBoxServiceDescription.Clear();
        }

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

        public void SetDateFilter(DateTime fromDate, DateTime toDate)
        {
            dateTimePickerFrom.Value = fromDate;
            dateTimePickerTo.Value = toDate;
        }




        private void buttonApproveService_Click(object sender, EventArgs e)
        {
            controller.ApproveServiceRequest();
        }

        private void buttonDeclineService_Click(object sender, EventArgs e)
        {
            controller.DeclineServiceRequest();
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

        private void buttonServiceSearch_Click(object sender, EventArgs e)
        {
            controller.SearchServiceRequests();
        }

        private void comboBoxServiceTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.SearchServiceRequests();
        }

        private void comboBoxDurationFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.SearchServiceRequests();
        }

        private void comboBoxApprovalStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.SearchServiceRequests();
        }

        private void comboBoxStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.SearchServiceRequests();
        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            controller.SearchServiceRequests();
        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            controller.SearchServiceRequests();
        }
    }

    public class ServiceRequestDisplayModel
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
