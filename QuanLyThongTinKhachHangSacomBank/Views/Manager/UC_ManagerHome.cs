using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Notification;
using QuanLyThongTinKhachHangSacomBank.Controllers;

namespace QuanLyThongTinKhachHangSacomBank.Views.Manager
{
    public partial class UC_ManagerHome : UserControl
    {
        private readonly NotificationController notificationController;

        public UC_ManagerHome()
        {
            try
            {
                InitializeComponent();
                notificationController = new NotificationController();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo UC_ManagerHome: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void buttonNotification_Click(object sender, EventArgs e)
        {
            try
            {
                notificationController.OpenNotification(new UC_ManagerNotification());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở FormNotification: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
