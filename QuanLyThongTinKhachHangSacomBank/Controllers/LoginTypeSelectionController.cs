using QuanLyThongTinKhachHangSacomBank.Views.Common.LoginTypeSelection;
using System.Windows.Forms;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    public class LoginTypeSelectionController
    {
        private readonly ILoginTypeSelectionView view;

        public LoginTypeSelectionController(ILoginTypeSelectionView view)
        {
            this.view = view;
        }

        public void HandleConfirmButtonClick()
        {
            // Kiểm tra nếu ComboBox trống
            if (string.IsNullOrEmpty(this.view.ComboBoxSelectedItem))
            {
                this.view.ShowErrorMessage(true); // Hiển thị lỗi
                return;
            }

            // Ẩn lỗi nếu có lựa chọn
            this.view.ShowErrorMessage(false);

            // Lưu vai trò được chọn
            this.view.SelectedRole = this.view.ComboBoxSelectedItem;

            // Đặt DialogResult để thoát form
            this.view.DialogResult = DialogResult.OK;

            // Đóng form
            this.view.CloseForm();
        }
    }
}