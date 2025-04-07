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

namespace QuanLyThongTinKhachHangSacomBank.Views.Common.Withdraw
{
    public interface IWithdrawView
    {
        void LoadUserControl(UserControl uc);
        void ShowForm();
    }

    public partial class FormWithdraw : Form, IWithdrawView
    {
        private UserControl activeUC = null;  // UserControl đang hiển thị

        public FormWithdraw()
        {
            try
            {
                InitializeComponent();
                if (panelMainContentWithdraw == null)
                {
                    throw new InvalidOperationException("panelMainContentWithdraw không được khởi tạo trong FormWithdraw.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo FormWithdraw: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        // Hàm load UserControl vào panelMainContentWithdraw
        public void LoadUserControl(UserControl uc)
        {
            if (activeUC != null && activeUC.GetType() == uc.GetType())
            {
                return; // Đã load rồi thì không load lại
            }

            panelMainContentWithdraw.Controls.Clear(); // Xóa hết control cũ
            activeUC = uc;
            activeUC.Dock = DockStyle.Fill;
            activeUC.AutoSize = false; // Không cho UC tự co dãn theo nội dung
            activeUC.Width = panelMainContentWithdraw.Width; // Đặt kích thước theo Panel
            activeUC.Height = panelMainContentWithdraw.Height;
            panelMainContentWithdraw.Controls.Add(activeUC);
            panelMainContentWithdraw.Refresh(); // Cập nhật lại UI
        }

        public void ShowForm()
        {
            try
            {
                ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị FormPay: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
