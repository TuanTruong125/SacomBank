using QuanLyThongTinKhachHangSacomBank.Views.Common;
using QuanLyThongTinKhachHangSacomBank.Views.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class LoanApplicationController
    {
        private ILoanApplicationView view;

        public void OpenLoanApplication()
        {
            try
            {
                FormLoanApplication formLoanApplication = new FormLoanApplication();
                this.view = formLoanApplication;

                // Đăng ký sự kiện cho instance mới
                view.SendRequestClicked += (s, e) => HandleSendRequest();
                view.CancelClicked += (s, e) => HandleCancel();

                formLoanApplication.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở FormLoanApplication: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Yêu cầu vay vốn đã được gửi thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form mainForm = (view as Form);
                    mainForm?.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi yêu cầu vay vốn: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Lỗi khi hủy yêu cầu vay vốn: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
