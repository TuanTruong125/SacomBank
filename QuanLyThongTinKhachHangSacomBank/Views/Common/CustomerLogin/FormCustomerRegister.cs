using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Controllers;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Views.Common.CustomerLogin;
using System.Windows.Forms;

namespace QuanLyThongTinKhachHangSacomBank.Views.Common.CustomerLogin
{
    public partial class FormCustomerRegister : Form
    {
        private UserControl activeUC = null;
        private CustomerRegisterController controller;
        private readonly IConfiguration configuration;
        private readonly DatabaseContext dbContext;

        public FormCustomerRegister(IConfiguration configuration, DatabaseContext dbContext)
        {
            InitializeComponent();
            this.configuration = configuration;
            this.dbContext = dbContext;

            var customerInfoRegisterView = new UC_CustomerInfoRegister();
            controller = new CustomerRegisterController(this, customerInfoRegisterView, configuration, dbContext);
        }

        public void LoadUserControl(UserControl uc)
        {
            if (activeUC != null && activeUC.GetType() == uc.GetType())
            {
                return;
            }

            panelMainContentCustomerRegister.Controls.Clear();
            activeUC = uc;
            activeUC.Dock = DockStyle.Fill;
            activeUC.AutoSize = false;
            activeUC.Width = panelMainContentCustomerRegister.Width;
            activeUC.Height = panelMainContentCustomerRegister.Height;
            panelMainContentCustomerRegister.Controls.Add(activeUC);
            panelMainContentCustomerRegister.Refresh();
        }
    }
}