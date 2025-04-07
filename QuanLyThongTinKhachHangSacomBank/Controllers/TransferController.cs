using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyThongTinKhachHangSacomBank.Views.Common;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Pay;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Transfer;
using QuanLyThongTinKhachHangSacomBank.Views.Customer;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class TransferController
    {
        private ITransferView transferView;
        private UserControl activeUC;

        public TransferController()
        {
            activeUC = null;
        }

        public void OpenTransfer(UserControl transferUC, bool isEmployee = false)
        {
            try
            {
                // Tạo instance mới mỗi lần mở
                transferView = new FormTransfer();

                activeUC = transferUC;

                if (activeUC is ITransferViewData transferViewData)
                {
                    transferViewData.ConfirmRequested += (s, e) => HandleConfirm(isEmployee);
                    transferViewData.CancelRequested += (s, e) => HandleCancel();
                }

                transferView.LoadUserControl(transferUC);
                transferView.ShowForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong TransferController.OpenTransfer: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleConfirm(bool isEmployee)
        {
            try
            {
                if (activeUC is ITransferViewData transferViewData)
                {
                    // Kiểm tra nếu có ô nào bị trống
                    if (string.IsNullOrWhiteSpace(transferViewData.AccountName) ||
                        string.IsNullOrWhiteSpace(transferViewData.AccountID) ||
                        string.IsNullOrWhiteSpace(transferViewData.Phone) ||
                        string.IsNullOrWhiteSpace(transferViewData.CitizenID) ||
                        string.IsNullOrWhiteSpace(transferViewData.Balance) ||
                        string.IsNullOrWhiteSpace(transferViewData.ReceiverAccountName) ||
                        string.IsNullOrWhiteSpace(transferViewData.ReceiverAccountID) ||
                        string.IsNullOrWhiteSpace(transferViewData.ReceiverPhone) ||
                        string.IsNullOrWhiteSpace(transferViewData.ReceiverCitizenID) ||
                        transferViewData.BankSelectedIndex == -1 ||
                        string.IsNullOrWhiteSpace(transferViewData.Amount) ||
                        string.IsNullOrWhiteSpace(transferViewData.Description))
                    {
                        transferViewData.ShowError("Vui lòng nhập đầy đủ thông tin!");
                        return;
                    }

                    transferViewData.HideError();

                    // Quyết định mở FormPIN hay FormOTP
                    Form confirmationForm = isEmployee ? new FormOTP() : new FormPINCode();

                    if (confirmationForm.ShowDialog() == DialogResult.OK)
                    {
                        activeUC = new UC_SuccessfulPay();
                        transferView.LoadUserControl(activeUC);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xác nhận chuyển tiền: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleCancel()
        {
            try
            {
                // Đóng FormTransfer
                Form mainForm = activeUC.FindForm();
                if (mainForm != null)
                {
                    mainForm.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hủy chuyển tiền: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
