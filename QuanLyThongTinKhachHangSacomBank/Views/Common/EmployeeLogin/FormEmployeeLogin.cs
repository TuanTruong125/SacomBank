using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Controllers;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Views.Common.CustomerLogin;

namespace QuanLyThongTinKhachHangSacomBank.Views.Common.EmployeeLogin
{
    public partial class FormEmployeeLogin : Form
    {
        private UserControl activeUC = null;
        private EmployeeLoginController controller;
        private readonly IConfiguration configuration;
        private readonly DatabaseContext dbContext;

        public FormEmployeeLogin(IConfiguration configuration, DatabaseContext dbContext)
        {
            InitializeComponent();
            this.configuration = configuration;
            this.dbContext = dbContext;

            var employeeLoginView = new UC_EmployeeLogin(configuration, dbContext);
            controller = new EmployeeLoginController(this, employeeLoginView, configuration, dbContext);
        }

        public void LoadUserControl(UserControl uc)
        {
            if (activeUC != null && activeUC.GetType() == uc.GetType())
            {
                return; // Đã load rồi thì không load lại
            }

            panelMainContentEmployeeLogin.Controls.Clear();
            activeUC = uc;
            activeUC.Dock = DockStyle.Fill;
            activeUC.AutoSize = false;
            activeUC.Width = panelMainContentEmployeeLogin.Width;
            activeUC.Height = panelMainContentEmployeeLogin.Height;
            panelMainContentEmployeeLogin.Controls.Add(activeUC);
            panelMainContentEmployeeLogin.Refresh();
        }
    }
}
