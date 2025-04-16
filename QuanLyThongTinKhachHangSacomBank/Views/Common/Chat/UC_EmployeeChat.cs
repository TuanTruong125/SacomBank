using System;
using System.Windows.Forms;

namespace QuanLyThongTinKhachHangSacomBank.Views.Common.Chat
{
    public interface IEmployeeChatView
    {
        void DisplayRequest(string title, string message);
    }

    public partial class UC_EmployeeChat : UserControl, IEmployeeChatView
    {
        public UC_EmployeeChat()
        {
            InitializeComponent();
        }

        public void DisplayRequest(string title, string message)
        {
            try
            {
                textBoxTitle.Text = title;
                richTextBoxMessage.Text = message;
                textBoxTitle.ReadOnly = true;
                richTextBoxMessage.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị yêu cầu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}