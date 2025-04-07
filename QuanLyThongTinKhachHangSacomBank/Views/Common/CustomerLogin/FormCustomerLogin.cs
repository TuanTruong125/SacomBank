using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Controllers;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Views.Common.CustomerLogin;
using System.Windows.Forms;

namespace QuanLyThongTinKhachHangSacomBank.Views.Common.CustomerLogin
{
    public partial class FormCustomerLogin : Form
    {
        private UserControl activeUC = null;
        private CustomerLoginController controller;
        private readonly IConfiguration configuration;
        private readonly DatabaseContext dbContext;

        public FormCustomerLogin(IConfiguration configuration, DatabaseContext dbContext)
        {
            InitializeComponent();
            this.configuration = configuration;
            this.dbContext = dbContext;

            var customerLoginView = new UC_CustomerLogin(configuration, dbContext);
            controller = new CustomerLoginController(this, customerLoginView, configuration, dbContext);
        }

        public void LoadUserControl(UserControl uc)
        {
            if (activeUC != null && activeUC.GetType() == uc.GetType())
            {
                return;
            }

            panelMainContentCustomerLogin.Controls.Clear();
            activeUC = uc;
            activeUC.Dock = DockStyle.Fill;
            activeUC.AutoSize = false;
            activeUC.Width = panelMainContentCustomerLogin.Width;
            activeUC.Height = panelMainContentCustomerLogin.Height;
            panelMainContentCustomerLogin.Controls.Add(activeUC);
            panelMainContentCustomerLogin.Refresh();
        }
    }
}