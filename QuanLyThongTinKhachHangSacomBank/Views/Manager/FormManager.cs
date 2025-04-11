using QuanLyThongTinKhachHangSacomBank.UIHelpers;
using QuanLyThongTinKhachHangSacomBank.Views.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThongTinKhachHangSacomBank.Controllers;
using QuanLyThongTinKhachHangSacomBank.Models;
using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Data;


namespace QuanLyThongTinKhachHangSacomBank.Views.Manager
{
    public interface IFormManagerView
    {
        void LoadUserControl(UserControl uc);
    }

    public partial class FormManager : Form, IFormManagerView
    {
        private List<Button> menuButtons;
        private UserControl activeUC = null;
        private FormManagerController controller;
        private readonly EmployeeModel employee;
        private readonly DatabaseContext dbContext;
        private readonly IConfiguration configuration;


        public event EventHandler ManagerHomeRequested;
        public event EventHandler EmployeeManagementRequested;
        public event EventHandler RequestManagementRequested;
        public event EventHandler ReportStatisticRequested;
        public event EventHandler ManagerSettingRequested;

        public FormManager(EmployeeModel employee, DatabaseContext dbContext, IConfiguration configuration)
        {
            try
            {
                this.employee = employee;
                this.dbContext = dbContext;
                this.configuration = configuration;

                InitializeComponent();
                InitializeMenuButtons();
                controller = new FormManagerController(this, employee, dbContext, configuration);

                // Đăng ký sự kiện
                ManagerHomeRequested += (s, e) => controller.LoadManagerHome();
                EmployeeManagementRequested += (s, e) => controller.LoadEmployeeManagement();
                RequestManagementRequested += (s, e) => controller.LoadRequestManagement();
                ReportStatisticRequested += (s, e) => controller.LoadReportStatistic();
                ManagerSettingRequested += (s, e) => controller.LoadManagerSetting();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo FormManager: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        // Hàm khởi tạo danh sách menu dùng UIHelper
        private void InitializeMenuButtons()
        {
            menuButtons = new List<Button>
            {
                buttonManagerHome, buttonEmployeeManagement, buttonRequestManagement,
                buttonReportStatistic, buttonManagerSetting
            };
        }

        // Hàm load UserControl vào panelMainContentManager
        public void LoadUserControl(UserControl uc)
        {
            try
            {
                if (panelMainContentManager == null)
                {
                    throw new InvalidOperationException("panelMainContentManager không được khởi tạo trong FormManager.");
                }

                if (activeUC != null && activeUC.GetType() == uc.GetType())
                {
                    return; // Đã load rồi thì không load lại
                }

                panelMainContentManager.Controls.Clear();
                activeUC = uc;
                activeUC.Dock = DockStyle.Fill;
                activeUC.AutoSize = false;
                activeUC.Width = panelMainContentManager.Width;
                activeUC.Height = panelMainContentManager.Height;
                panelMainContentManager.Controls.Add(activeUC);
                panelMainContentManager.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load UserControl: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load UC_ManagerHome mặc định khi mới mở form
        private void FormManager_Load(object sender, EventArgs e)
        {
            try
            {
                controller.LoadManagerHome();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load FormManager: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // --- Button ---
        private void buttonManagerHome_Click(object sender, EventArgs e)
        {
            try
            {
                ManagerMenu.ActivateButton(menuButtons, buttonManagerHome, panelNavigationBar, pictureBoxNavigationCircle);
                ManagerHomeRequested?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi bấm ButtonManagerHome: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEmployeeManagement_Click(object sender, EventArgs e)
        {
            try
            {
                ManagerMenu.ActivateButton(menuButtons, buttonEmployeeManagement, panelNavigationBar, pictureBoxNavigationCircle);
                EmployeeManagementRequested?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi bấm ButtonEmployeeManagement: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRequestManagement_Click(object sender, EventArgs e)
        {
            try
            {
                ManagerMenu.ActivateButton(menuButtons, buttonRequestManagement, panelNavigationBar, pictureBoxNavigationCircle);
                RequestManagementRequested?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi bấm ButtonRequestManagement: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonReportStatistic_Click(object sender, EventArgs e)
        {
            try
            {
                ManagerMenu.ActivateButton(menuButtons, buttonReportStatistic, panelNavigationBar, pictureBoxNavigationCircle);
                ReportStatisticRequested?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi bấm ButtonReportStatistic: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonManagerSetting_Click(object sender, EventArgs e)
        {
            try
            {
                ManagerMenu.ActivateButton(menuButtons, buttonManagerSetting, panelNavigationBar, pictureBoxNavigationCircle);
                ManagerSettingRequested?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi bấm ButtonManagerSetting: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonManagerLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Đánh dấu logout
            this.Close();
        }
    }
}
