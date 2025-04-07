using QuanLyThongTinKhachHangSacomBank.Views.Common;
using QuanLyThongTinKhachHangSacomBank.Views.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class OpenSavingsController
    {
        private IOpenSavingsView view;

        public void OpenOpenSavings()
        {
            try
            {
                FormOpenSavings formOpenSavings = new FormOpenSavings();
                this.view = formOpenSavings;

                // Đăng ký sự kiện cho instance mới
                view.SendRequestClicked += (s, e) => HandleSendRequest();
                view.CancelClicked += (s, e) => HandleCancel();

                formOpenSavings.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở FormOpenSavings: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleSendRequest()
        {
            try
            {
                // Kiểm tra thông tin
                if (string.IsNullOrWhiteSpace(view.AccountName) ||
                    string.IsNullOrWhiteSpace(view.AccountID) ||
                    string.IsNullOrWhiteSpace(view.Phone) ||
                    string.IsNullOrWhiteSpace(view.CitizenID) ||
                    string.IsNullOrWhiteSpace(view.ServiceID) ||
                    string.IsNullOrWhiteSpace(view.ServiceTypeName) ||
                    string.IsNullOrWhiteSpace(view.InterestRate) ||
                    string.IsNullOrWhiteSpace(view.Duration) ||
                    string.IsNullOrWhiteSpace(view.TotalPrincipalAmount) ||
                    string.IsNullOrWhiteSpace(view.Description))
                {
                    view.ShowError("Vui lòng nhập đầy đủ thông tin!");
                    return;
                }

                view.HideError();

                // Mở FormOTP để xác nhận
                FormOTP formOTP = new FormOTP();
                if (formOTP.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Yêu cầu mở gửi tiết kiệm đã được gửi thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form mainForm = (view as Form);
                    mainForm?.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi yêu cầu mở gửi tiết kiệm: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleCancel()
        {
            try
            {
                Form mainForm = (view as Form);
                mainForm?.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hủy yêu cầu gửi tiết kiệm: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
