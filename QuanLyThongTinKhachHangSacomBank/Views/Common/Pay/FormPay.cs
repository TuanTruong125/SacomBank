using QuanLyThongTinKhachHangSacomBank.Views.Common.Transfer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThongTinKhachHangSacomBank.Views.Common.Pay
{
    public interface IPayView
    {
        void LoadUserControl(UserControl uc);
        void ShowForm();
        Form FindForm();

        event EventHandler<FormClosingEventArgs> FormClosing;
    }

    public partial class FormPay : Form, IPayView
    {
        private UserControl activeUC = null;  // UserControl đang hiển thị
        public event EventHandler<FormClosingEventArgs> FormClosing;

        public FormPay()
        {
            try
            {
                InitializeComponent();
                if (panelMainContentPay == null)
                {
                    throw new InvalidOperationException("panelMainContentPay không được khởi tạo trong FormPay.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo FormPay: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        // Hàm load UserControl vào panelMainContentPay
        public void LoadUserControl(UserControl uc)
        {
            if (activeUC != null && activeUC.GetType() == uc.GetType())
            {
                return; // Đã load rồi thì không load lại
            }

            panelMainContentPay.Controls.Clear(); // Xóa hết control cũ
            activeUC = uc;
            activeUC.Dock = DockStyle.Fill;
            activeUC.AutoSize = false; // Không cho UC tự co dãn theo nội dung
            activeUC.Width = panelMainContentPay.Width; // Đặt kích thước theo Panel
            activeUC.Height = panelMainContentPay.Height;
            panelMainContentPay.Controls.Add(activeUC);
            panelMainContentPay.Refresh(); // Cập nhật lại UI
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

        protected virtual void OnFormClosing(FormClosingEventArgs e)
        {
            FormClosing?.Invoke(this, e);
        }
    }
}
