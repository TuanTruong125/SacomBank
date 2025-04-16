using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Chat;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Pay;
using QuanLyThongTinKhachHangSacomBank.Controllers;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Models;

namespace QuanLyThongTinKhachHangSacomBank.Views.Employee
{
    public interface ICustomerCareView
    {
        string GetRequestStatusFilter();
        DateTime GetFromDate();
        DateTime GetToDate();
        int GetSelectedRowCount();
        DataGridViewRow GetSelectedRow();
        void LoadRequests(List<RequestDisplayModel> requests);
        void SetControlState(bool enableView, bool enableHandle, bool enableDone, bool enableDeny);
        void ShowMessage(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon);
        DialogResult ShowConfirmation(string message, string title);
        string GetSearchText();
        RequestDisplayModel GetSelectedRequestModel();
        void SetDateFilter(DateTime fromDate, DateTime toDate);
    }

    public partial class UC_CustomerCare : UserControl, ICustomerCareView
    {
        private readonly EmployeeCustomerCareController controller;
        private List<RequestDisplayModel> allRequests;

        public UC_CustomerCare(DatabaseContext dbContext, EmployeeModel currentEmployee)
        {
            InitializeComponent();
            this.controller = new EmployeeCustomerCareController(this, dbContext, currentEmployee);
            InitializeControlState();
        }

        private void InitializeControlState()
        {
            dataGridViewChat.ReadOnly = true;
            dataGridViewChat.AllowUserToDeleteRows = false;
            dataGridViewChat.AutoGenerateColumns = false;
            dataGridViewChat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewChat.MultiSelect = false;

            comboBoxRequestStatusFilter.Items.Clear();
            comboBoxRequestStatusFilter.Items.AddRange(new string[] { "Không áp dụng", "Chờ xử lý", "Đang xử lý", "Đã xử lý", "Từ chối xử lý" });
            comboBoxRequestStatusFilter.SelectedIndex = 0;

            // Đặt khoảng thời gian mặc định (tương tự UC_AccountManagement)
            dateTimePickerForm.Value = new DateTime(2025, 1, 1); // Từ năm 2025
            dateTimePickerTo.Value = DateTime.Now; // Đến ngày hiện tại

            dataGridViewChat.SelectionChanged += (s, e) => controller.OnRequestSelected();
            comboBoxRequestStatusFilter.SelectedIndexChanged += (s, e) => controller.LoadRequests();
            dateTimePickerForm.ValueChanged += (s, e) => controller.LoadRequests();
            dateTimePickerTo.ValueChanged += (s, e) => controller.LoadRequests();

            SetControlState(false, false, false, false);
        }

        public string GetRequestStatusFilter() => comboBoxRequestStatusFilter.SelectedItem?.ToString() ?? "Không áp dụng";
        public DateTime GetFromDate() => dateTimePickerForm.Value.Date;
        public DateTime GetToDate() => dateTimePickerTo.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
        public int GetSelectedRowCount() => dataGridViewChat.SelectedRows.Count;
        public DataGridViewRow GetSelectedRow() => dataGridViewChat.SelectedRows.Count > 0 ? dataGridViewChat.SelectedRows[0] : null; // Sửa lỗi không kiểm tra Count
        public string GetSearchText() => textBoxRequestSearch.Text.Trim();
        public void SetDateFilter(DateTime fromDate, DateTime toDate)
        {
            dateTimePickerForm.Value = fromDate;
            dateTimePickerTo.Value = toDate;
        }

        public RequestDisplayModel GetSelectedRequestModel()
        {
            if (GetSelectedRowCount() > 0)
            {
                var selectedRow = GetSelectedRow();
                if (selectedRow != null && selectedRow.Cells[1].Value != null)
                {
                    string requestCode = selectedRow.Cells[1].Value.ToString();
                    return allRequests.FirstOrDefault(r => r.RequestCode == requestCode);
                }
            }
            return null;
        }

        public void LoadRequests(List<RequestDisplayModel> requests)
        {

            allRequests = requests;
            dataGridViewChat.Rows.Clear();
            foreach (var request in requests)
            {
                // Giới hạn RequestMessage hiển thị tối đa 30 ký tự
                string displayMessage = request.RequestMessage;
                if (!string.IsNullOrEmpty(displayMessage) && displayMessage.Length > 30)
                {
                    displayMessage = displayMessage.Substring(0, 30) + "...";
                }

                dataGridViewChat.Rows.Add(
                    request.CustomerCode,
                    request.RequestCode,
                    request.Title,
                    displayMessage, // Sử dụng chuỗi đã cắt ngắn
                    request.RequestDate,
                    request.EmployeeName,
                    request.RequestStatus
                );
            }
        }

        public void SetControlState(bool enableView, bool enableHandle, bool enableDone, bool enableDeny)
        {
            buttonViewRequest.Enabled = enableView;
            buttonHandle.Enabled = enableHandle;
            buttonDone.Enabled = enableDone;
            buttonDeny.Enabled = enableDeny;
        }

        public void ShowMessage(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, buttons, icon);
        }

        public DialogResult ShowConfirmation(string message, string title)
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }


        private void buttonViewRequest_Click(object sender, EventArgs e)
        {
            controller.OnViewRequest();
        }

        private void buttonHandle_Click(object sender, EventArgs e)
        {
            controller.OnHandleRequest();
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            controller.OnCompleteRequest();
        }

        private void buttonDeny_Click(object sender, EventArgs e)
        {
            controller.OnDenyRequest();
        }

        private void buttonRequestSearch_Click(object sender, EventArgs e)
        {
            controller.SearchRequests();
        }
    }
}
