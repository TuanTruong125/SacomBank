using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThongTinKhachHangSacomBank.Views.Common.Notification
{
    public interface INotificationView
    {
        void LoadUserControl(UserControl uc);
        void ShowForm();
    }

    public partial class FormNotification: Form, INotificationView
    {
        public FormNotification()
        {
            try
            {
                InitializeComponent();
                if (panelMainContentNotification == null)
                {
                    throw new InvalidOperationException("panelChatMainNotification không được khởi tạo trong FormNotification.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo FormNotification: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public void LoadUserControl(UserControl uc)
        {
            try
            {
                if (panelMainContentNotification == null)
                {
                    MessageBox.Show("panelMainContentNotification không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                panelMainContentNotification.Controls.Clear();
                uc.Dock = DockStyle.Fill;
                panelMainContentNotification.Controls.Add(uc);
                panelMainContentNotification.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load UserControl: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ShowForm()
        {
            try
            {
                ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị FormNotification: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
