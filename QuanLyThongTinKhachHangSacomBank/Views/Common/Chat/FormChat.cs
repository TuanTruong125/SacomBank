using QuanLyThongTinKhachHangSacomBank.Views.Common.Deposit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThongTinKhachHangSacomBank.Views.Common.Chat
{
    public interface IChatView
    {
        void LoadUserControl(UserControl uc);
        void ShowForm();
    }

    public partial class FormChat : Form, IChatView
    {
        public FormChat()
        {
            try
            {
                InitializeComponent();
                if (panelMainContentChat == null)
                {
                    throw new InvalidOperationException("panelMainContentChat không được khởi tạo trong FormChat.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo FormChat: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public void LoadUserControl(UserControl uc)
        {
            try
            {
                if (panelMainContentChat == null)
                {
                    MessageBox.Show("panelMainContentChat không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                panelMainContentChat.Controls.Clear();
                uc.Dock = DockStyle.Fill;
                panelMainContentChat.Controls.Add(uc);
                panelMainContentChat.Refresh();
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
                MessageBox.Show($"Lỗi khi hiển thị FormChat: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
