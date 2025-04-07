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

namespace QuanLyThongTinKhachHangSacomBank.Views.Customer
{
    public partial class UC_CustomerService : UserControl
    {
        private readonly LoanDetailController loanDetailController;
        private readonly LoanApplicationController loanApplicationController;
        private readonly SavingsDetailController savingsDetailController;
        private readonly OpenSavingsController openSavingsController;

        public UC_CustomerService()
        {
            try
            {
                InitializeComponent();
                loanDetailController = new LoanDetailController();
                loanApplicationController = new LoanApplicationController();
                savingsDetailController = new SavingsDetailController();
                openSavingsController = new OpenSavingsController();


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo UC_CustomerService: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
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
