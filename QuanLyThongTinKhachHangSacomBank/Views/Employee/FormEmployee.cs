using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using QuanLyThongTinKhachHangSacomBank.UIHelpers;
using QuanLyThongTinKhachHangSacomBank.Controllers;
using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Models;


namespace QuanLyThongTinKhachHangSacomBank.Views.Employee
{
    public interface IFormEmployeeView
    {
        void LoadUserControl(UserControl uc);
    }

    public partial class FormEmployee : Form, IFormEmployeeView
    {
        private List<Button> menuButtons;
        private UserControl activeUC = null;
        private FormEmployeeController controller;
        private readonly EmployeeModel employee;
        private readonly DatabaseContext dbContext;
        private readonly IConfiguration configuration;

        public event EventHandler HomeRequested;
        public event EventHandler CustomerManagementRequested;
        public event EventHandler AccountManagementRequested;
        public event EventHandler ServiceManagementRequested;
        public event EventHandler TransactionManagementRequested;
        public event EventHandler CustomerCareRequested;
        public event EventHandler SettingRequested;

        public FormEmployee(AccountModel account, EmployeeModel employee, DatabaseContext dbContext, IConfiguration configuration)
        {
            try
            {
                this.employee = employee;
                this.dbContext = dbContext;
                this.configuration = configuration;

                InitializeComponent();
                InitializeMenuButtons();

                controller = new FormEmployeeController(this, account, this.employee, dbContext, configuration);

                // Đăng ký sự kiện
                HomeRequested += (s, e) => controller.LoadHome();
                CustomerManagementRequested += (s, e) => controller.LoadCustomerManagement();
                AccountManagementRequested += (s, e) => controller.LoadAccountManagement();
                ServiceManagementRequested += (s, e) => controller.LoadServiceManagement();
                TransactionManagementRequested += (s, e) => controller.LoadTransactionManagement();
                CustomerCareRequested += (s, e) => controller.LoadCustomerCare();
                SettingRequested += (s, e) => controller.LoadSetting();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo FormEmployee: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        // Hàm khởi tạo danh sách menu dùng UIHelper
        private void InitializeMenuButtons()
        {
            menuButtons = new List<Button>
            {
                buttonHome, buttonCustomerManagement, buttonAccountManagement,
                buttonServiceManagement, buttonTransactionManagement, buttonCustomerCare, buttonSetting
            };

        }

        // Hàm load UserControl vào panelMainContentEmployee
        public void LoadUserControl(UserControl uc)
        {
            try
            {
                if (panelMainContentEmployee == null)
                {
                    throw new InvalidOperationException("panelMainContentEmployee không được khởi tạo trong FormEmployee.");
                }

                if (activeUC != null && activeUC.GetType() == uc.GetType())
                {
                    return; // Đã load rồi thì không load lại
                }

                panelMainContentEmployee.Controls.Clear();
                activeUC = uc;
                activeUC.Dock = DockStyle.Fill;
                activeUC.AutoSize = false;
                activeUC.Width = panelMainContentEmployee.Width;
                activeUC.Height = panelMainContentEmployee.Height;
                panelMainContentEmployee.Controls.Add(activeUC);
                panelMainContentEmployee.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load UserControl: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load UC_Home mặc định khi mới mở form
        private void FormEmployee_Load(object sender, EventArgs e)
        {   
            try
            {
                controller.LoadHome();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load FormEmployee: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // --- Button ---
        private void buttonHome_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeMenu.ActivateButton(menuButtons, buttonHome, panelNavigationBar, pictureBoxNavigationCircle);
                HomeRequested?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi bấm ButtonHome: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCustomerManagement_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeMenu.ActivateButton(menuButtons, buttonCustomerManagement, panelNavigationBar, pictureBoxNavigationCircle);
                CustomerManagementRequested?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi bấm ButtonCustomerManagement: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAccountManagement_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeMenu.ActivateButton(menuButtons, buttonAccountManagement, panelNavigationBar, pictureBoxNavigationCircle);
                AccountManagementRequested?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi bấm ButtonAccountManagement: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonServiceManagement_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeMenu.ActivateButton(menuButtons, buttonServiceManagement, panelNavigationBar, pictureBoxNavigationCircle);
                ServiceManagementRequested?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi bấm ButtonServiceManagement: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonTransactionManagement_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeMenu.ActivateButton(menuButtons, buttonTransactionManagement, panelNavigationBar, pictureBoxNavigationCircle);
                TransactionManagementRequested?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi bấm ButtonTransactionManagement: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCustomerCare_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeMenu.ActivateButton(menuButtons, buttonCustomerCare, panelNavigationBar, pictureBoxNavigationCircle);
                CustomerCareRequested?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi bấm ButtonCustomerCare: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSetting_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeMenu.ActivateButton(menuButtons, buttonSetting, panelNavigationBar, pictureBoxNavigationCircle);
                SettingRequested?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi bấm ButtonSetting: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Đánh dấu logout
            this.Close();
        }

    }
}
