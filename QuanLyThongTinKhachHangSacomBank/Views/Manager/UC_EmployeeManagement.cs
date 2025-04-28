using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Controllers;
using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Data;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Runtime.InteropServices;

namespace QuanLyThongTinKhachHangSacomBank.Views.Manager
{
    public interface IEmployeeManagementView
    {
        // Thuộc tính
        string EmployeeSearchText { get; }
        string SelectedGender { get; }
        int GetSelectedEmployeeID();
        void SetAccessLevelOptions();
        // Phương thức
        void LoadEmployeeList(System.Data.DataTable employeeData);  // Thay đổi tham số
        void ClearInputFields();
        void SetButtonState(bool isEditMode);
        void ShowMessage(string message, string title, MessageBoxIcon icon);
        EmployeeModel GetEmployeeFromInputFields();
        void DisplayEmployeeForEdit(EmployeeModel employee);
        void DisplayEmployeeInfo(EmployeeModel employee);  // Thêm phương thức mới

        // Sự kiện
        event EventHandler AddButtonClicked;
        event EventHandler EditButtonClicked;
        event EventHandler DeleteButtonClicked;
        event EventHandler SaveButtonClicked;
        event EventHandler CancelButtonClicked;
        event EventHandler SearchButtonClicked;
        event EventHandler GenderFilterChanged;
        event EventHandler ExportToExcelButtonClicked;
        event EventHandler ExportToPDFButtonClicked;
    }

    public partial class UC_EmployeeManagement : UserControl, IEmployeeManagementView
    {
        private readonly EmployeeManagementController controller;
        // Thuộc tính
        public string EmployeeSearchText => textBoxEmployeeSearch.Text.Trim();
        public string SelectedGender => comboBoxGenderFilter.SelectedItem?.ToString() ?? "";

        // Sự kiện
        public event EventHandler AddButtonClicked;
        public event EventHandler EditButtonClicked;
        public event EventHandler DeleteButtonClicked;
        public event EventHandler SaveButtonClicked;
        public event EventHandler CancelButtonClicked;
        public event EventHandler SearchButtonClicked;
        public event EventHandler GenderFilterChanged;
        public event EventHandler ExportToExcelButtonClicked;
        public event EventHandler ExportToPDFButtonClicked;

        public UC_EmployeeManagement(EmployeeModel currentManager, DatabaseContext dbContext, IConfiguration configuration)
        {
            InitializeComponent();

            // Khởi tạo controller
            controller = new EmployeeManagementController(this, currentManager, dbContext, configuration);

            // Cài đặt ban đầu
            SetupInitialState();

            // Đăng ký sự kiện
            RegisterEvents();

        }
        public void SetAccessLevelOptions()
        {
            comboBoxAccessLevel.Items.Clear();
            comboBoxAccessLevel.Items.Add("Nhân viên");
            comboBoxAccessLevel.Items.Add("Quản lý");
            comboBoxAccessLevel.SelectedIndex = 0;
        }
        private void SetupInitialState()
        {
            // Cài đặt ComboBox
            comboBoxEmployeeGender.SelectedIndex = 0; // "Nam"
            if (comboBoxGenderFilter.Items.Count > 0)
                comboBoxGenderFilter.SelectedIndex = 0; // "Nam"

            // Mặc định trạng thái ban đầu
            SetButtonState(false);

            // Cài đặt DataGridView
            ConfigureDataGridView();
        }

        private void RegisterEvents()
        {
            // Nút chức năng
            buttonAddEmployee.Click += (s, e) => AddButtonClicked?.Invoke(s, e);
            buttonEditEmployee.Click += (s, e) => EditButtonClicked?.Invoke(s, e);
            buttonDeleteEmployee.Click += (s, e) => DeleteButtonClicked?.Invoke(s, e);
            buttonSaveEmployee.Click += (s, e) => SaveButtonClicked?.Invoke(s, e);
            buttonCancelEmployee.Click += (s, e) => CancelButtonClicked?.Invoke(s, e);

            // Tìm kiếm và lọc
            buttonEmployeeSearch.Click += (s, e) => SearchButtonClicked?.Invoke(s, e);
            comboBoxGenderFilter.SelectedIndexChanged += (s, e) => GenderFilterChanged?.Invoke(s, e);

            // Xuất báo cáo
            buttonExportExcel.Click += (s, e) => ExportToExcelButtonClicked?.Invoke(s, e);
            buttonExportPDF.Click += (s, e) => ExportToPDFButtonClicked?.Invoke(s, e);

            // Sự kiện của DataGridView
            dataEmployeeManagement.SelectionChanged += DataEmployeeManagement_SelectionChanged;
        }

        private void ConfigureDataGridView()
        {
            // Cấu hình DataGridView để hiển thị dữ liệu
            dataEmployeeManagement.AutoGenerateColumns = false;
            dataEmployeeManagement.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataEmployeeManagement.MultiSelect = false;
            dataEmployeeManagement.ReadOnly = true;

            // Thêm một cột ẩn để lưu trữ EmployeeID
            if (!dataEmployeeManagement.Columns.Contains("EmployeeIDColumn"))
            {
                DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
                idColumn.Name = "EmployeeIDColumn";
                idColumn.DataPropertyName = "EmployeeID";
                idColumn.Visible = false;
                dataEmployeeManagement.Columns.Add(idColumn);
            }

            // Cấu hình các cột
            dataEmployeeManagement.Columns["EmployeeID"].DataPropertyName = "EmployeeCode";
            dataEmployeeManagement.Columns["EmployeeName"].DataPropertyName = "EmployeeName";
            dataEmployeeManagement.Columns["EmployeeGender"].DataPropertyName = "EmployeeGender";
            dataEmployeeManagement.Columns["EmployeeDateOfBirth"].DataPropertyName = "EmployeeDateOfBirth";
            dataEmployeeManagement.Columns["EmployeeCitizenID"].DataPropertyName = "EmployeeCitizenID";
            dataEmployeeManagement.Columns["EmployeeAddress"].DataPropertyName = "EmployeeAddress";
            dataEmployeeManagement.Columns["Role"].DataPropertyName = "EmployeeRole";
            dataEmployeeManagement.Columns["EmployeePhone"].DataPropertyName = "EmployeePhone";
            dataEmployeeManagement.Columns["EmployeeEmail"].DataPropertyName = "EmployeeEmail";
            dataEmployeeManagement.Columns["HireDate"].DataPropertyName = "HireDate";
            dataEmployeeManagement.Columns["Salary"].DataPropertyName = "Salary";
            // Định dạng cột Lương theo VND
            DataGridViewCellStyle currencyStyle = new DataGridViewCellStyle();
            currencyStyle.Format = "N0"; // Định dạng có dấu phẩy ngăn cách hàng nghìn, không có phần thập phân
            dataEmployeeManagement.Columns["Salary"].DefaultCellStyle = currencyStyle;
        }

        private void DataEmployeeManagement_SelectionChanged(object sender, EventArgs e)
        {
            if (dataEmployeeManagement.SelectedRows.Count > 0)
            {
                try
                {
                    // Sử dụng cột ẩn để lấy ID
                    int selectedEmployeeID = Convert.ToInt32(dataEmployeeManagement.SelectedRows[0].Cells["EmployeeIDColumn"].Value);
                    controller.LoadEmployeeToView(selectedEmployeeID);
                }
                catch (Exception ex)
                {
                    // Ghi log lỗi chi tiết
                    Console.WriteLine($"Chi tiết lỗi: {ex.Message}\nStackTrace: {ex.StackTrace}");
                    MessageBox.Show("Không thể tải thông tin nhân viên được chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Interface implementations
        public void LoadEmployeeList(System.Data.DataTable employeeData)
        {
            try
            {
                // Đảm bảo không tự động tạo cột
                dataEmployeeManagement.AutoGenerateColumns = false;

                // Gán nguồn dữ liệu
                dataEmployeeManagement.DataSource = employeeData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị danh sách nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ClearInputFields()
        {
            textBoxEmployeeID.Text = string.Empty;
            textBoxEmployeeName.Text = string.Empty;
            comboBoxEmployeeGender.SelectedIndex = 0;
            dateTimePickerEmployeeDateOfBirth.Value = DateTime.Now.AddYears(-18);
            textBoxEmployeeCitizenID.Text = string.Empty;
            textBoxEmployeeAddress.Text = string.Empty;
            comboBoxAccessLevel.SelectedIndex = 0; // Giả sử có một ComboBox cho vai trò
            textBoxEmployeePhone.Text = string.Empty;
            textBoxEmployeeEmail.Text = string.Empty;
            dateTimePickerHireDate.Value = DateTime.Now;
            textBoxSalary.Text = string.Empty;
        }

        public void SetButtonState(bool isEditMode)
        {
            // Trạng thái nhập liệu
            textBoxEmployeeID.Enabled = isEditMode;
            textBoxEmployeeName.Enabled = isEditMode;
            comboBoxEmployeeGender.Enabled = isEditMode;
            dateTimePickerEmployeeDateOfBirth.Enabled = isEditMode;
            textBoxEmployeeCitizenID.Enabled = isEditMode;
            textBoxEmployeeAddress.Enabled = isEditMode;
            comboBoxAccessLevel.Enabled = isEditMode;
            textBoxEmployeePhone.Enabled = isEditMode;
            textBoxEmployeeEmail.Enabled = isEditMode;
            dateTimePickerHireDate.Enabled = isEditMode;
            textBoxSalary.Enabled = isEditMode;

            // Trạng thái nút
            buttonSaveEmployee.Enabled = isEditMode;
            buttonCancelEmployee.Enabled = isEditMode;
            buttonAddEmployee.Enabled = !isEditMode;
            buttonEditEmployee.Enabled = !isEditMode;
            buttonDeleteEmployee.Enabled = !isEditMode;
        }

        public void ShowMessage(string message, string title, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
        }

        public EmployeeModel GetEmployeeFromInputFields()
        {
            decimal salary = 0;
            decimal.TryParse(textBoxSalary.Text, out salary);

            // Xác định AccessLevel dựa trên EmployeeRole
            int accessLevel = 1; // Mặc định là nhân viên
            string role = comboBoxAccessLevel.SelectedItem.ToString();
            if (role.Equals("Quản lý", StringComparison.OrdinalIgnoreCase))
            {
                accessLevel = 2; // Quản lý
            }
            // Tạo đối tượng nhân viên với các trường thông tin chung
            var employee = new EmployeeModel
            {
                EmployeeCode = textBoxEmployeeID.Text.Trim(),
                EmployeeName = textBoxEmployeeName.Text.Trim(),
                EmployeeGender = comboBoxEmployeeGender.SelectedItem.ToString(),
                EmployeeDateOfBirth = dateTimePickerEmployeeDateOfBirth.Value,
                EmployeeCitizenID = textBoxEmployeeCitizenID.Text.Trim(),
                EmployeeAddress = textBoxEmployeeAddress.Text.Trim(),
                EmployeeRole = comboBoxAccessLevel.SelectedItem.ToString(),
                EmployeePhone = textBoxEmployeePhone.Text.Trim(),
                EmployeeEmail = textBoxEmployeeEmail.Text.Trim(),
                HireDate = dateTimePickerHireDate.Value,
                Salary = salary,
                AccessLevel = accessLevel, // Lấy cấp bậc từ ComboBox
                ManagerID = null, // Có thể cải tiến thêm để chọn người quản lý nếu cần

                // Sử dụng số điện thoại làm tên đăng nhập
                EmployeeUsername = textBoxEmployeePhone.Text.Trim(),

                // QUAN TRỌNG: Trong chế độ cập nhật, KHÔNG đặt mật khẩu tại đây
                // Đặt một giá trị tạm thời để tránh null, nhưng sẽ được ghi đè trong controller
                EmployeePassword = textBoxEmployeeID.Text.Equals("(Tự động tạo)") ?
                          GenerateRandomPassword() : "[CURRENT_PASSWORD]",

            };

            return employee;
        }
        private string GenerateRandomPassword()
        {
            Random random = new Random();
            StringBuilder password = new StringBuilder();

            // Thêm 3 chữ cái Latin ngẫu nhiên
            for (int i = 0; i < 3; i++)
            {
                // Mã ASCII: 65-90 (A-Z), 97-122 (a-z)
                char randomChar = (char)(random.Next(26) + (random.Next(2) == 0 ? 65 : 97));
                password.Append(randomChar);
            }

            // Thêm 3 số tự nhiên ngẫu nhiên
            for (int i = 0; i < 3; i++)
            {
                password.Append(random.Next(10)); // Số từ 0-9
            }

            return password.ToString();
        }
        private string GenerateDefaultUsername(string fullName)
        {
            // Tạo username mặc định từ tên nhân viên, ví dụ: nguyen.van.a
            if (string.IsNullOrEmpty(fullName)) return "";

            string[] parts = fullName.Trim().ToLower().Split(' ');
            if (parts.Length == 0) return "";

            string username = parts[parts.Length - 1]; // Lấy tên

            for (int i = 0; i < parts.Length - 1; i++)
            {
                if (!string.IsNullOrEmpty(parts[i]))
                    username = parts[i][0] + "." + username;
            }

            return username;
        }
        public void SetupAddEmployeeMode()
        {
            // Xóa các trường hiện tại
            ClearInputFields();

            // Vô hiệu hóa trường mã nhân viên vì nó sẽ được tạo tự động
            textBoxEmployeeID.Text = "(Tự động tạo)";
            textBoxEmployeeID.Enabled = false;
            textBoxEmployeeID.BackColor = System.Drawing.SystemColors.Control;

            // Thiết lập giá trị mặc định cho ComboBox cấp bậc
            comboBoxAccessLevel.SelectedIndex = 0; // Mặc định là nhân viên

            // Kích hoạt chế độ chỉnh sửa cho các trường khác
            SetButtonState(true);
        }

        public void DisplayEmployeeForEdit(EmployeeModel employee)
        {
            // Hiển thị thông tin nhưng không cho phép chỉnh sửa EmployeeCode
            textBoxEmployeeID.Text = employee.EmployeeCode;
            textBoxEmployeeID.Enabled = false;  // Vô hiệu hóa hoàn toàn trường mã nhân viên
            textBoxEmployeeID.BackColor = System.Drawing.SystemColors.Control;

            textBoxEmployeeName.Text = employee.EmployeeName;
            comboBoxEmployeeGender.SelectedItem = employee.EmployeeGender;
            dateTimePickerEmployeeDateOfBirth.Value = employee.EmployeeDateOfBirth;
            textBoxEmployeeCitizenID.Text = employee.EmployeeCitizenID;
            textBoxEmployeeAddress.Text = employee.EmployeeAddress;
            comboBoxAccessLevel.SelectedItem = employee.EmployeeRole;
            textBoxEmployeePhone.Text = employee.EmployeePhone;
            textBoxEmployeeEmail.Text = employee.EmployeeEmail;
            dateTimePickerHireDate.Value = employee.HireDate;
            textBoxSalary.Text = FormatCurrency(employee.Salary);
        }

        public void DisplayEmployeeInfo(EmployeeModel employee)
        {
            // Hiển thị thông tin nhưng không cho phép chỉnh sửa
            DisplayEmployeeForEdit(employee);
            SetButtonState(false);
        }

        public int GetSelectedEmployeeID()
        {
            if (dataEmployeeManagement.SelectedRows.Count > 0)
            {
                try
                {
                    var selectedRow = dataEmployeeManagement.SelectedRows[0];
                    // Sử dụng cột ẩn để lấy giá trị ID
                    return Convert.ToInt32(selectedRow.Cells["EmployeeIDColumn"].Value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi lấy ID nhân viên: {ex.Message}");
                    return -1;
                }
            }
            return -1;
        }
        private string FormatCurrency(decimal value)
        {
            // Định dạng tiền tệ: 000,000,000 (không hiển thị đơn vị)
            return string.Format("{0:#,##0}", value);
        }
        // Thêm vào lớp UC_EmployeeManagement
        private void textBoxSalary_Leave(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBoxSalary.Text.Replace(",", ""), out decimal value))
            {
                textBoxSalary.Text = FormatCurrency(value);
            }
        }
    }
}