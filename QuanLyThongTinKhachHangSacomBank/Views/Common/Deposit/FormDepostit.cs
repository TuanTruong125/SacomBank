using QuanLyThongTinKhachHangSacomBank.Views.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThongTinKhachHangSacomBank.Views.Common.Deposit
{
    public interface IDepositView
    {
        void LoadUserControl(UserControl uc);
        void ShowForm();
    }

    public partial class FormDeposit : Form, IDepositView
    {
        private UserControl activeUC = null;  // UserControl đang hiển thị

        public FormDeposit()
        {
            try
            {
                InitializeComponent();
                if (panelMainContentDeposit == null)
                {
                    throw new InvalidOperationException("panelMainContentDeposit không được khởi tạo trong FormDeposit.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo FormDeposit: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        // Hàm load UserControl vào panelMainContentDeposit
        public void LoadUserControl(UserControl uc)
        {
            if (activeUC != null && activeUC.GetType() == uc.GetType())
            {
                return; // Đã load rồi thì không load lại
            }

            panelMainContentDeposit.Controls.Clear(); // Xóa hết control cũ
            activeUC = uc;
            activeUC.Dock = DockStyle.Fill;
            activeUC.AutoSize = false; // Không cho UC tự co dãn theo nội dung
            activeUC.Width = panelMainContentDeposit.Width; // Đặt kích thước theo Panel
            activeUC.Height = panelMainContentDeposit.Height;
            panelMainContentDeposit.Controls.Add(activeUC);
            panelMainContentDeposit.Refresh(); // Cập nhật lại UI
        }

        public void ShowForm()
        {
            try
            {
                ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị FormDeposit: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
