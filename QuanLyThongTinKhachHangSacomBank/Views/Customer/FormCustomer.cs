using QuanLyThongTinKhachHangSacomBank.UIHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThongTinKhachHangSacomBank.Views.Employee;
using QuanLyThongTinKhachHangSacomBank.Controllers;

namespace QuanLyThongTinKhachHangSacomBank.Views.Customer
{
    public interface IFormCustomerView
    {
        void LoadUserControl(UserControl uc);
    }

    public partial class FormCustomer : Form, IFormCustomerView
    {
        private List<Button> menuButtons;
        private UserControl activeUC = null;
        private FormCustomerController controller;

        public event EventHandler CustomerHomeRequested;
        public event EventHandler CustomerServiceRequested;
        public event EventHandler CustomerPersonalRequested;

        public FormCustomer()
        {
            try
            {
                InitializeComponent();
                InitializeMenuButtons();
                controller = new FormCustomerController(this);

                // Đăng ký sự kiện
                CustomerHomeRequested += (s, e) => controller.LoadCustomerHome();
                CustomerServiceRequested += (s, e) => controller.LoadCustomerService();
                CustomerPersonalRequested += (s, e) => controller.LoadCustomerPersonal();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo FormCustomer: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        // Hàm khởi tạo danh sách menu dùng UIHelper
        private void InitializeMenuButtons()
        {
            menuButtons = new List<Button>
            {
                buttonCustomerHome, buttonCustomerService, buttonCustomerPersonal
            };
        }

        // Hàm load UserControl vào panelMainContentCustomer
        public void LoadUserControl(UserControl uc)
        {
            try
            {
                if (panelMainContentCustomer == null)
                {
                    throw new InvalidOperationException("panelMainContentCustomer không được khởi tạo trong FormCustomer.");
                }

                if (activeUC != null && activeUC.GetType() == uc.GetType())
                {
                    return; // Đã load rồi thì không load lại
                }

                panelMainContentCustomer.Controls.Clear();
                activeUC = uc;
                activeUC.Dock = DockStyle.Fill;
                activeUC.AutoSize = false;
                activeUC.Width = panelMainContentCustomer.Width;
                activeUC.Height = panelMainContentCustomer.Height;
                panelMainContentCustomer.Controls.Add(activeUC);
                panelMainContentCustomer.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load UserControl: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load UC_CustomerHome mặc định khi mới mở form
        private void FormCustomer_Load(object sender, EventArgs e)
        {
            try
            {
                controller.LoadCustomerHome();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load FormCustomer: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // --- Button ---
        private void buttonCustomerHome_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerMenu.ActivateButton(menuButtons, buttonCustomerHome, panelNavigationBar, pictureBoxNavigationCircle);
                CustomerHomeRequested?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi bấm ButtonCustomerHome: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCustomerService_Click(object sender, EventArgs e)
        { 
            try
            {
                CustomerMenu.ActivateButton(menuButtons, buttonCustomerService, panelNavigationBar, pictureBoxNavigationCircle);
                CustomerServiceRequested?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi bấm ButtonCustomerService: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCustomerPersonal_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerMenu.ActivateButton(menuButtons, buttonCustomerPersonal, panelNavigationBar, pictureBoxNavigationCircle);
                CustomerPersonalRequested?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi bấm ButtonCustomerPersonal: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCustomerLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Đánh dấu logout
            this.Close(); // Đóng FormCustomer
        }
    }
}
