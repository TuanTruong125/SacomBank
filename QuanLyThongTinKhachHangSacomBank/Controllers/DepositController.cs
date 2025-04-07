using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyThongTinKhachHangSacomBank.Views.Common;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Deposit;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class DepositController
    {
        private IDepositView depositView;
        private UserControl activeUC;

        public DepositController()
        {
            activeUC = null;
        }

        public void OpenDeposit(UserControl depositUC)
        {
            try
            {
                // Tạo instance mới mỗi lần mở
                depositView = new FormDeposit();

                activeUC = depositUC;

                if (activeUC is IDepositViewData depositViewData)
                {
                    depositViewData.ConfirmRequested += (s, e) => HandleConfirm();
                    depositViewData.CancelRequested += (s, e) => HandleCancel();
                }

                depositView.LoadUserControl(depositUC);
                depositView.ShowForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong DepositController.OpenDeposit: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleConfirm()
        {
            try
            {
                if (activeUC is IDepositViewData depositViewData)
                {
                    // Kiểm tra nếu có ô nào bị trống
                    if (string.IsNullOrWhiteSpace(depositViewData.AccountName) ||
                        string.IsNullOrWhiteSpace(depositViewData.AccountID) ||
                        string.IsNullOrWhiteSpace(depositViewData.Phone) ||
                        string.IsNullOrWhiteSpace(depositViewData.CitizenID) ||
                        string.IsNullOrWhiteSpace(depositViewData.Balance) ||
                        string.IsNullOrWhiteSpace(depositViewData.Amount) ||
                        string.IsNullOrWhiteSpace(depositViewData.Description))
                    {
                        depositViewData.ShowError("Vui lòng nhập đầy đủ thông tin!");
                        return;
                    }

                    depositViewData.HideError();

                    // Mở FormOTP để xác thực
                    FormOTP formOTP = new FormOTP();
                    if (formOTP.ShowDialog() == DialogResult.OK)
                    {
                        // OTP xác nhận thành công, chuyển sang UC_SuccessfulDeposit
                        activeUC = new UC_SuccessfulDeposit();
                        depositView.LoadUserControl(activeUC);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xác nhận nạp tiền: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleCancel()
        {
            try
            {
                // Đóng FormDeposit
                Form mainForm = activeUC.FindForm();
                if (mainForm != null)
                {
                    mainForm.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hủy nạp tiền: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
