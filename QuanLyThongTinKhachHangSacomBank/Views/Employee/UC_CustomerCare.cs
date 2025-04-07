using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Chat;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Pay;
using QuanLyThongTinKhachHangSacomBank.Controllers;

namespace QuanLyThongTinKhachHangSacomBank.Views.Employee
{
    public partial class UC_CustomerCare : UserControl
    {
        private readonly ChatController chatController;

        public UC_CustomerCare()
        {
            try
            {
                InitializeComponent();
                chatController = new ChatController();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo UC_CustomerCare: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        // --- Label ---


        private void dataGridViewCustomerCareManagement_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonChat_Click(object sender, EventArgs e)
        {
            try
            {
                chatController.OpenChat(new UC_EmployeeChat());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở FormChat: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
