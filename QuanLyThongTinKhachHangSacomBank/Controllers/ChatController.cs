using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Chat;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    public class ChatController
    {
        private IChatView chatView;
        private UserControl activeUC;

        public ChatController()
        {
            activeUC = null;
        }

        public void OpenChat(UserControl chatUC)
        {
            try
            {
                // Tạo instance mới mỗi lần mở
                chatView = new FormChat();

                activeUC = chatUC;
                chatView.LoadUserControl(chatUC);
                chatView.ShowForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong ChatController.OpenChat: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
