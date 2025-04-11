using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Controllers;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Models;
using System.Data;

namespace QuanLyThongTinKhachHangSacomBank.Views.Employee
{
    public interface IEmployeeCustomerManagementView
    {
        void SetCustomerTypeList(List<CustomerTypeModel> customerTypes);
        void UpdateDataGridView(List<CustomerDisplayModel> customers); // Thay đổi để nhận List<CustomerDisplayModel>
        void SetDateFilter(DateTime fromDate, DateTime toDate);
        DateTime GetFromDate();
        DateTime GetToDate();
        string GetCustomerTypeFilter();
        DataGridView GetDataGridView();

        // Các phương thức để lấy dữ liệu từ giao diện
        string GetFullName();
        string GetGender();
        DateTime GetDateOfBirth();
        string GetNationality();
        string GetCitizenID();
        string GetAddress();
        string GetPhone();
        string GetEmail();
        DateTime GetRegistrationDate();
        int GetCustomerTypeID();

        // Các phương thức để cập nhật trạng thái giao diện
        void EnableCustomerInfoControls(bool enable, bool isAdding);
        void ClearCustomerInfo();
        void SetCustomerInfo(CustomerModel customer);
        void EnableButtons(bool addEnabled, bool editEnabled, bool cancelEnabled, bool saveEnabled);
        void ShowMessage(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon);
        DialogResult ShowConfirmation(string message, string title);
    }

    public partial class UC_CustomerManagement : UserControl, IEmployeeCustomerManagementView
    {
        private readonly EmployeeCustomerManagementController controller;

        public UC_CustomerManagement(DatabaseContext dbContext, IConfiguration configuration)
        {
            InitializeComponent();
            // Đặt DataGridView ở chế độ chỉ đọc
            dataCustomerManagement.ReadOnly = true;
            dataCustomerManagement.AllowUserToDeleteRows = false; // Không cho phép xóa hàng
            dataCustomerManagement.AutoGenerateColumns = false;
            dataCustomerManagement.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Cấu hình dateTimePickerRegistrationDate để hiển thị cả ngày và thời gian
            dateTimePickerRegistrationDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerRegistrationDate.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dateTimePickerRegistrationDate.ShowUpDown = true; // Cho phép chỉnh sửa thời gian bằng nút lên/xuống

            // Đăng ký sự kiện KeyPress cho textBoxPhone
            textBoxPhone.KeyPress += TextBoxPhone_KeyPress;

            // Đăng ký sự kiện KeyPress cho textBoxCitizenID
            textBoxCitizenID.KeyPress += TextBoxCitizenID_KeyPress;

            controller = new EmployeeCustomerManagementController(this, dbContext, configuration);
            controller.InitializeControlState();
            controller.LoadInitialData();

            // Đăng ký sự kiện SelectionChanged
            dataCustomerManagement.SelectionChanged += DataCustomerManagement_SelectionChanged;
        }

        private void TextBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và phím điều khiển (như Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }
        }

        private void TextBoxCitizenID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và phím điều khiển (như Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }
        }

        public void SetCustomerTypeList(List<CustomerTypeModel> customerTypes)
        {
            // Thêm "Không áp dụng" vào comboBoxCustomerTypeFilter
            comboBoxCustomerTypeFilter.Items.Clear();
            comboBoxCustomerTypeFilter.Items.Add("Không áp dụng");
            foreach (var type in customerTypes)
            {
                comboBoxCustomerTypeFilter.Items.Add(type.CustomerTypeName);
            }
            comboBoxCustomerTypeFilter.SelectedIndex = 0;

            // Lọc danh sách loại khách hàng cho comboBoxCustomerTypeName (chỉ giữ "Cá nhân" và "Doanh nghiệp")
            var filteredCustomerTypes = customerTypes
                .Where(ct => ct.CustomerTypeName == "Cá nhân" || ct.CustomerTypeName == "Doanh nghiệp")
                .ToList();

            // Gán danh sách đã lọc cho comboBoxCustomerTypeName
            comboBoxCustomerTypeName.DataSource = new List<CustomerTypeModel>(filteredCustomerTypes);
            comboBoxCustomerTypeName.DisplayMember = "CustomerTypeName";
            comboBoxCustomerTypeName.ValueMember = "CustomerTypeID";
        }

        public void UpdateDataGridView(List<CustomerDisplayModel> customers)
        {
            dataCustomerManagement.Rows.Clear();
            foreach (var customer in customers)
            {
                dataCustomerManagement.Rows.Add(
                    customer.CustomerCode,
                    customer.CustomerTypeName,
                    customer.FullName,
                    customer.Gender,
                    customer.DateOfBirth,
                    customer.Nationality,
                    customer.CitizenID,
                    customer.CustomerAddress,
                    customer.Phone,
                    customer.Email,
                    customer.RegistrationDate
                );
            }
        }

        public void SetDateFilter(DateTime fromDate, DateTime toDate)
        {
            dateTimePickerFrom.Value = fromDate;
            dateTimePickerTo.Value = toDate;
        }

        public DateTime GetFromDate()
        {
            return dateTimePickerFrom.Value.Date; // Đảm bảo chỉ lấy ngày, bỏ giờ
        }

        public DateTime GetToDate()
        {
            // Đặt thời gian của ngày đến là 23:59:59 để bao gồm cả ngày cuối
            return dateTimePickerTo.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
        }

        public string GetCustomerTypeFilter()
        {
            return comboBoxCustomerTypeFilter.SelectedItem?.ToString() ?? "Không áp dụng";
        }

        public DataGridView GetDataGridView()
        {
            return dataCustomerManagement;
        }

        // Các phương thức để lấy dữ liệu từ giao diện
        public string GetFullName()
        {
            return textBoxFullName.Text;
        }

        public string GetGender()
        {
            return comboBoxGender.SelectedItem?.ToString();
        }

        public DateTime GetDateOfBirth()
        {
            return dateTimePickerDateOfBirth.Value;
        }

        public string GetNationality()
        {
            return textBoxNationality.Text;
        }

        public string GetCitizenID()
        {
            return textBoxCitizenID.Text;
        }

        public string GetAddress()
        {
            return textBoxAddress.Text;
        }

        public string GetPhone()
        {
            return textBoxPhone.Text;
        }

        public string GetEmail()
        {
            return textBoxEmail.Text;
        }

        public DateTime GetRegistrationDate()
        {
            return dateTimePickerRegistrationDate.Value;
        }

        public int GetCustomerTypeID()
        {
            return (int)comboBoxCustomerTypeName.SelectedValue;
        }

        // Các phương thức để cập nhật giao diện
        public void EnableCustomerInfoControls(bool enable, bool isAdding)
        {
            textBoxCustomerID.Enabled = false;
            comboBoxCustomerTypeName.Enabled = enable && isAdding; // Chỉ cho phép chỉnh sửa CustomerType khi thêm
            textBoxFullName.Enabled = enable;
            comboBoxGender.Enabled = enable;
            dateTimePickerDateOfBirth.Enabled = enable;
            textBoxNationality.Enabled = enable;
            textBoxCitizenID.Enabled = enable;
            textBoxAddress.Enabled = enable;
            textBoxPhone.Enabled = enable;
            textBoxEmail.Enabled = enable;
            dateTimePickerRegistrationDate.Enabled = enable && isAdding; // Chỉ cho phép chỉnh sửa RegistrationDate khi thêm
        }

        public void ClearCustomerInfo()
        {
            textBoxCustomerID.Text = "";
            comboBoxCustomerTypeName.SelectedIndex = -1;
            textBoxFullName.Text = "";
            comboBoxGender.SelectedIndex = -1;
            dateTimePickerDateOfBirth.Value = DateTime.Now;
            textBoxNationality.Text = "";
            textBoxCitizenID.Text = "";
            textBoxAddress.Text = "";
            textBoxPhone.Text = "";
            textBoxEmail.Text = "";
            dateTimePickerRegistrationDate.Value = DateTime.Now;
        }

        public void SetCustomerInfo(CustomerModel customer)
        {
            if (customer == null)
            {
                ClearCustomerInfo();
                return;
            }

            textBoxCustomerID.Text = customer.CustomerCode;
            comboBoxCustomerTypeName.SelectedValue = customer.CustomerTypeID;
            textBoxFullName.Text = customer.FullName;
            comboBoxGender.SelectedItem = customer.Gender;
            dateTimePickerDateOfBirth.Value = customer.DateOfBirth;
            textBoxNationality.Text = customer.Nationality;
            textBoxCitizenID.Text = customer.CitizenID;
            textBoxAddress.Text = customer.CustomerAddress;
            textBoxPhone.Text = customer.Phone;
            textBoxEmail.Text = customer.Email;
            dateTimePickerRegistrationDate.Value = customer.RegistrationDate;
        }

        public void EnableButtons(bool addEnabled, bool editEnabled, bool cancelEnabled, bool saveEnabled)
        {
            buttonAddCustomer.Enabled = addEnabled;
            buttonEditCustomer.Enabled = editEnabled;
            buttonCancelCustomer.Enabled = cancelEnabled;
            buttonSaveCustomer.Enabled = saveEnabled;
        }

        public void ShowMessage(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, buttons, icon);
        }

        public DialogResult ShowConfirmation(string message, string title)
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        // Sự kiện gọi Controller
        private void buttonAddCustomer_Click(object sender, EventArgs e)
        {
            controller.OnAddCustomer();
        }

        private void buttonEditCustomer_Click(object sender, EventArgs e)
        {
            controller.OnEditCustomer();
        }

        private void buttonCancelCustomer_Click(object sender, EventArgs e)
        {
            controller.OnCancelCustomer();
        }

        private void buttonSaveCustomer_Click(object sender, EventArgs e)
        {
            controller.OnSaveCustomer();
        }

        private void comboBoxCustomerTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.LoadCustomers(GetFromDate(), GetToDate(), GetCustomerTypeFilter());
        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            controller.LoadCustomers(GetFromDate(), GetToDate(), GetCustomerTypeFilter());
        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            controller.LoadCustomers(GetFromDate(), GetToDate(), GetCustomerTypeFilter());
        }

        private void buttonCustomerSearch_Click(object sender, EventArgs e)
        {
            controller.SearchCustomers(textBoxCustomerSearch.Text.Trim(), GetFromDate(), GetToDate(), GetCustomerTypeFilter());
        }

        private void buttonExportPDF_Click(object sender, EventArgs e)
        {
            controller.ExportToPDF(dataCustomerManagement);
        }

        private void buttonExportExcel_Click(object sender, EventArgs e)
        {
            controller.ExportToExcel(dataCustomerManagement);
        }

        private void buttonExportCSV_Click(object sender, EventArgs e)
        {
            controller.ExportToCSV(dataCustomerManagement);
        }

        private void DataCustomerManagement_SelectionChanged(object sender, EventArgs e)
        {
            if (dataCustomerManagement.SelectedRows.Count > 0)
            {
                var row = dataCustomerManagement.SelectedRows[0]; // Lấy hàng được chọn đầu tiên
                if (!row.IsNewRow) // Đảm bảo không phải hàng mới (hàng trống)
                {
                    var customer = new CustomerModel
                    {
                        CustomerID = int.Parse(row.Cells["CustomerID"].Value.ToString().Replace("KH", "")),
                        CustomerCode = row.Cells["CustomerID"].Value.ToString(),
                        FullName = row.Cells["FullName"].Value.ToString(),
                        Gender = row.Cells["Gender"].Value.ToString(),
                        DateOfBirth = DateTime.ParseExact(row.Cells["DateOfBirth"].Value.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                        Nationality = row.Cells["Nationality"].Value.ToString(),
                        CitizenID = row.Cells["CitizenID"].Value.ToString(),
                        CustomerAddress = row.Cells["CustomerAddress"].Value.ToString(),
                        Phone = row.Cells["Phone"].Value.ToString(),
                        Email = row.Cells["Email"].Value.ToString(),
                        RegistrationDate = DateTime.ParseExact(row.Cells["RegistrationDate"].Value.ToString(), "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), // Parse cả thời gian
                        CustomerTypeID = GetCustomerTypeIdByName(row.Cells["CustomerTypeName"].Value.ToString())
                    };
                    controller.OnCustomerSelected(customer);
                }
            }
        }

        private int GetCustomerTypeIdByName(string customerTypeName)
        {
            var customerType = (comboBoxCustomerTypeName.DataSource as List<CustomerTypeModel>)
                .FirstOrDefault(ct => ct.CustomerTypeName == customerTypeName);
            return customerType?.CustomerTypeID ?? 0;
        }

        
    }

    public class CustomerDisplayModel
    {
        public string CustomerCode { get; set; }
        public string CustomerTypeName { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; } // Định dạng dd/MM/yyyy
        public string Nationality { get; set; }
        public string CitizenID { get; set; }
        public string CustomerAddress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string RegistrationDate { get; set; } // Định dạng dd/MM/yyyy
    }
}

