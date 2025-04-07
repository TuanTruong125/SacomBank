using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Deposit;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Withdraw;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Transfer;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Pay;
using QuanLyThongTinKhachHangSacomBank.Controllers;

namespace QuanLyThongTinKhachHangSacomBank.Views.Employee
{
    public partial class UC_TransactionManagement : UserControl
    {
        private readonly DepositController depositController;
        private readonly WithdrawController withdrawController;
        private readonly TransferController transferController;
        private readonly PayController payController;

        public UC_TransactionManagement()
        {
            try
            {
                InitializeComponent();
                depositController = new DepositController();
                withdrawController = new WithdrawController();
                transferController = new TransferController();
                payController = new PayController();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo UC_TransactionManagement: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void buttonDeposit_Click(object sender, EventArgs e)
        {
            try
            {
                depositController.OpenDeposit(new UC_DepositInfo());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở FormDeposit: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonWithdraw_Click(object sender, EventArgs e)
        {
            try
            {
                withdrawController.OpenWithdraw(new UC_WithdrawInfo());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở FormWithdraw: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                transferController.OpenTransfer(new UC_TransferInfo(), isEmployee: true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở FormTransfer: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonPay_Click(object sender, EventArgs e)
        {
            try
            {
                payController.OpenPay(new UC_PayInfo(), isEmployee: true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở FormPay: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
