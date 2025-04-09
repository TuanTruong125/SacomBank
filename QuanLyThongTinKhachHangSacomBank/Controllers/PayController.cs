using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Views.Common;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Pay;
using QuanLyThongTinKhachHangSacomBank.Views.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class PayController
    {
        private IPayView payView;
        private UserControl activeUC;
        private readonly AccountModel currentAccount;

        public PayController()
        {
            activeUC = null;
        }

        public void OpenPay(UserControl payUC, bool isEmployee = false)
        {
            try
            {
                // Tạo instance mới mỗi lần mở
                payView = new FormPay();

                activeUC = payUC;

                if (activeUC is IPayViewData payViewData)
                {
                    payViewData.ConfirmRequested += (s, e) => HandleConfirm(isEmployee);
                    payViewData.CancelRequested += (s, e) => HandleCancel();
                }

                payView.LoadUserControl(payUC);
                payView.ShowForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong PayController.OpenPay: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleConfirm(bool isEmployee)
        {
            try
            {
                if (activeUC is IPayViewData payViewData)
                {
                    // Kiểm tra nếu có ô nào bị trống
                    if (string.IsNullOrWhiteSpace(payViewData.AccountName) ||
                        string.IsNullOrWhiteSpace(payViewData.AccountID) ||
                        string.IsNullOrWhiteSpace(payViewData.Phone) ||
                        string.IsNullOrWhiteSpace(payViewData.CitizenID) ||
                        string.IsNullOrWhiteSpace(payViewData.Balance) ||
                        string.IsNullOrWhiteSpace(payViewData.PayLoanID) ||
                        string.IsNullOrWhiteSpace(payViewData.ServiceID) ||
                        string.IsNullOrWhiteSpace(payViewData.RemainingDebt) ||
                        string.IsNullOrWhiteSpace(payViewData.Amount) ||
                        string.IsNullOrWhiteSpace(payViewData.Description))
                    {
                        payViewData.ShowError("Vui lòng nhập đầy đủ thông tin!");
                        return;
                    }

                    payViewData.HideError();

                    // Quyết định mở FormPIN hay FormOTP
                    Form confirmationForm = isEmployee ? new FormOTP() : new FormPINCode(currentAccount);

                    if (confirmationForm.ShowDialog() == DialogResult.OK)
                    {
                        activeUC = new UC_SuccessfulPay();
                        payView.LoadUserControl(activeUC);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xác nhận thanh toán: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleCancel()
        {
            try
            {
                // Đóng FormPay
                Form mainForm = activeUC.FindForm();
                if (mainForm != null)
                {
                    mainForm.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hủy thanh toán: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
