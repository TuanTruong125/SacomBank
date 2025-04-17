using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThongTinKhachHangSacomBank.Controllers;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Models;

namespace QuanLyThongTinKhachHangSacomBank.Views.Customer
{
    public partial class UC_CustomerService : UserControl
    {
        private readonly LoanDetailController loanDetailController;
        private readonly LoanApplicationController loanApplicationController;
        private readonly SavingsDetailController savingsDetailController;
        private readonly OpenSavingsController openSavingsController;
        private readonly CustomerServiceController customerServiceController;

        public UC_CustomerService(AccountModel currentAccount, DatabaseContext dbContext, IConfiguration configuration)
        {
            try
            {
                InitializeComponent();
                loanDetailController = new LoanDetailController();
                loanApplicationController = new LoanApplicationController(currentAccount, dbContext, configuration);
                savingsDetailController = new SavingsDetailController();
                openSavingsController = new OpenSavingsController(currentAccount, dbContext, configuration);
                customerServiceController = new CustomerServiceController(this, currentAccount, dbContext, configuration);


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo UC_CustomerService: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        // Phương thức để vô hiệu hóa các nút liên quan đến tiết kiệm
        public void DisableSavingsButtons()
        {
            cyberButtonSavingsDetail.Visible = false; // Vô hiệu hóa nút "Chi tiết tiết kiệm"
            cyberButtonSavings.Visible = false; // Vô hiệu hóa nút "Đăng ký tiết kiệm"
        }

        private void cyberButtonLoanDetail_Click(object sender, EventArgs e)
        {
            try
            {
                loanDetailController.OpenLoanDetail();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở FormLoanDetail: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cyberButtonLoanApplication_Click(object sender, EventArgs e)
        {
            try
            {
                loanApplicationController.OpenLoanApplication();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở FormLoanApplication: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cyberButtonSavingsDetail_Click(object sender, EventArgs e)
        {
            try
            {
                savingsDetailController.OpenSavingsDetail();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở FormSavingsDetail: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cyberButtonOpenSavings_Click(object sender, EventArgs e)
        {
            try
            {
                openSavingsController.OpenOpenSavings();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở FormOpenSavings: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
