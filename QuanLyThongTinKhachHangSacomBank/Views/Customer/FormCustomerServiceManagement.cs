using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThongTinKhachHangSacomBank.Views.Customer
{
    public interface ICustomerServiceManagementView
    {
        void UpdateServiceDataGridView(List<CustomerServiceManagementDisplayModel> services);
        void UpdateLoanLabels(string totalLoanPrincipalAmount, string remainingDebt);
        void UpdateSavingsLabels(string totalSavingsPrincipalAmount, string totalInterestPaid);
        void ResetLabels();
        event System.EventHandler SelectionChanged;
        (string serviceType, string serviceCode, string totalPrincipalAmount)? GetSelectedRowData();
        string GetSelectedServiceStatus();
    }

    public partial class FormCustomerServiceManagement : Form, ICustomerServiceManagementView
    {
        public event EventHandler SelectionChanged;

        public FormCustomerServiceManagement()
        {
            InitializeComponent();

            // Cấu hình DataGridView
            ConfigureDataGridView();

            // Đăng ký sự kiện chọn hàng trong DataGridView
            dataGridViewCustomerServiceManagement.SelectionChanged += (s, e) => SelectionChanged?.Invoke(this, e);

            // Đăng ký sự kiện CellFormatting để tùy chỉnh hiển thị
            dataGridViewCustomerServiceManagement.CellFormatting += DataGridViewCustomerServiceManagement_CellFormatting;
        }

        // Cấu hình DataGridView
        private void ConfigureDataGridView()
        {
            // Chỉ cho phép chọn 1 hàng duy nhất
            dataGridViewCustomerServiceManagement.MultiSelect = false;
            dataGridViewCustomerServiceManagement.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Không cho phép chỉnh sửa hoặc xóa hàng
            dataGridViewCustomerServiceManagement.ReadOnly = true;
            dataGridViewCustomerServiceManagement.AllowUserToDeleteRows = false;

            // Đảm bảo số cột khớp với dữ liệu (13 cột)
            if (dataGridViewCustomerServiceManagement.Columns.Count != 13)
            {
                MessageBox.Show("Số cột trong DataGridView không khớp với dữ liệu (cần 13 cột).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cập nhật DataGridView với danh sách dịch vụ
        public void UpdateServiceDataGridView(List<CustomerServiceManagementDisplayModel> services)
        {
            dataGridViewCustomerServiceManagement.Rows.Clear();
            foreach (var service in services)
            {
                dataGridViewCustomerServiceManagement.Rows.Add(
                    service.ServiceTypeName,      // Cột 0
                    service.ServiceCode,         // Cột 1
                    service.TotalPrincipalAmount,// Cột 2
                    service.Duration,           // Cột 3
                    service.InterestRate,       // Cột 4
                    service.TotalInterestAmount,// Cột 5
                    service.ServiceDescription, // Cột 6
                    service.CreatedDate,        // Cột 7
                    service.ApplicableDate,     // Cột 8
                    service.EndDate,           // Cột 9
                    service.HandledBy,         // Cột 10
                    service.ApprovalStatus,    // Cột 11
                    service.ServiceStatus      // Cột 12
                );
            }
        }

        // Cập nhật các label cho Vay vốn
        public void UpdateLoanLabels(string totalLoanPrincipalAmount, string remainingDebt)
        {
            labelTotalLoanPrincipalAmount.Text = totalLoanPrincipalAmount + " VND";
            labelRemainingDebt.Text = remainingDebt + " VND";
        }

        // Cập nhật các label cho Gửi tiết kiệm
        public void UpdateSavingsLabels(string totalSavingsPrincipalAmount, string totalInterestPaid)
        {
            labelTotalSavingsPrincipalAmount.Text = totalSavingsPrincipalAmount + " VND";
            labelTotalInterestPaid.Text = totalInterestPaid + " VND";
        }

        // Đặt lại tất cả label về giá trị mặc định
        public void ResetLabels()
        {
            labelTotalLoanPrincipalAmount.Text = "0 VND";
            labelRemainingDebt.Text = "0 VND";
            labelTotalSavingsPrincipalAmount.Text = "0 VND";
            labelTotalInterestPaid.Text = "0 VND";
        }

        // Lấy dữ liệu của hàng được chọn trong DataGridView
        public (string serviceType, string serviceCode, string totalPrincipalAmount)? GetSelectedRowData()
        {
            if (dataGridViewCustomerServiceManagement.SelectedRows.Count == 0) return null;

            var selectedRow = dataGridViewCustomerServiceManagement.SelectedRows[0];
            string serviceType = selectedRow.Cells[0].Value?.ToString();
            string serviceCode = selectedRow.Cells[1].Value?.ToString();
            string totalPrincipalAmount = selectedRow.Cells[2].Value?.ToString();

            if (string.IsNullOrEmpty(serviceType) || string.IsNullOrEmpty(serviceCode) || string.IsNullOrEmpty(totalPrincipalAmount))
                return null;

            return (serviceType, serviceCode, totalPrincipalAmount);
        }

        // Tùy chỉnh hiển thị các ô trong DataGridView
        private void DataGridViewCustomerServiceManagement_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Tùy chỉnh cột "Trạng thái" (ServiceStatus) - Cột 12
            if (dataGridViewCustomerServiceManagement.Columns[e.ColumnIndex].Name == "ServiceStatus")
            {
                // In đậm chữ
                e.CellStyle.Font = new Font(dataGridViewCustomerServiceManagement.Font, FontStyle.Bold);

                // Thêm màu sắc dựa trên trạng thái
                string status = e.Value?.ToString()?.Trim();
                switch (status)
                {
                    case "Chờ hoạt động":
                        e.CellStyle.ForeColor = Color.DarkGray;
                        break;
                    case "Đang hoạt động":
                        e.CellStyle.ForeColor = Color.Green;
                        break;
                    case "Hủy":
                        e.CellStyle.ForeColor = Color.Red;
                        break;
                    case "Trễ hạn thanh toán":
                        e.CellStyle.ForeColor = Color.Orange;
                        break;
                }
            }
        }

        // Lấy trạng thái dịch vụ của hàng được chọn
        public string GetSelectedServiceStatus()
        {
            if (dataGridViewCustomerServiceManagement.SelectedRows.Count == 0) return null;

            var selectedRow = dataGridViewCustomerServiceManagement.SelectedRows[0];
            string serviceStatus = selectedRow.Cells[12].Value?.ToString(); // Cột ServiceStatus

            return serviceStatus;
        }
    }

    public class CustomerServiceManagementDisplayModel
    {
        public string ServiceTypeName { get; set; }      // Loại dịch vụ
        public string ServiceCode { get; set; }         // Mã dịch vụ (có tiền tố DV)
        public string TotalPrincipalAmount { get; set; } // Số tiền gốc
        public string Duration { get; set; }            // Kì hạn
        public string InterestRate { get; set; }        // Lãi suất
        public string TotalInterestAmount { get; set; } // Tổng lãi dự kiến
        public string ServiceDescription { get; set; }  // Nội dung
        public string CreatedDate { get; set; }         // Ngày tạo
        public string ApplicableDate { get; set; }      // Ngày áp dụng
        public string EndDate { get; set; }            // Ngày kết thúc
        public string HandledBy { get; set; }          // Nhân viên xử lý (có tiền tố NV)
        public string ApprovalStatus { get; set; }     // Trạng thái duyệt
        public string ServiceStatus { get; set; }      // Trạng thái dịch vụ
    }
}
