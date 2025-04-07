using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Chat;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Notification;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class NotificationController
    {
        private INotificationView notificationView;
        private UserControl activeUC;

        public NotificationController()
        {
            activeUC = null;
        }

        public void OpenNotification(UserControl notificationUC)
        {
            try
            {
                // Tạo instance mới mỗi lần mở
                notificationView = new FormNotification();

                activeUC = notificationUC;
                notificationView.LoadUserControl(notificationUC);
                notificationView.ShowForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong NotificcationController.OpenChat: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
