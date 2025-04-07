using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyThongTinKhachHangSacomBank.Views.Common;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Withdraw;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class WithdrawController
    {
        private IWithdrawView withdrawView;
        private UserControl activeUC;

        public WithdrawController()
        {
            activeUC = null;
        }

        public void OpenWithdraw(UserControl withdrawUC)
        {
            try
            {
                // Tạo instance mới mỗi lần mở
                withdrawView = new FormWithdraw();

                activeUC = withdrawUC;

                if (activeUC is IWithdrawViewData withdrawViewData)
                {
                    withdrawViewData.ConfirmRequested += (s, e) => HandleConfirm();
                    withdrawViewData.CancelRequested += (s, e) => HandleCancel();
                }

                withdrawView.LoadUserControl(withdrawUC);
                withdrawView.ShowForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong WithdrawController.OpenWithdraw: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleConfirm()
        {
            try
            {
                if (activeUC is IWithdrawViewData withdrawViewData)
                {
                    // Kiểm tra nếu có ô nào bị trống
                    if (string.IsNullOrWhiteSpace(withdrawViewData.AccountName) ||
                        string.IsNullOrWhiteSpace(withdrawViewData.AccountID) ||
                        string.IsNullOrWhiteSpace(withdrawViewData.Phone) ||
                        string.IsNullOrWhiteSpace(withdrawViewData.CitizenID) ||
                        string.IsNullOrWhiteSpace(withdrawViewData.Balance) ||
                        string.IsNullOrWhiteSpace(withdrawViewData.Amount) ||
                        string.IsNullOrWhiteSpace(withdrawViewData.Description))
                    {
                        withdrawViewData.ShowError("Vui lòng nhập đầy đủ thông tin!");
                        return;
                    }

                    withdrawViewData.HideError();

                    // Mở FormOTP để xác thực
                    FormOTP formOTP = new FormOTP();
                    if (formOTP.ShowDialog() == DialogResult.OK)
                    {
                        // OTP xác nhận thành công, chuyển sang UC_SuccessfulWithdraw
                        activeUC = new UC_SuccessfulWithdraw();
                        withdrawView.LoadUserControl(activeUC);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xác nhận rút tiền: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleCancel()
        {
            try
            {
                // Đóng FormWithdraw
                Form mainForm = activeUC.FindForm();
                if (mainForm != null)
                {
                    mainForm.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hủy rút tiền: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
