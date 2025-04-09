using QuanLyThongTinKhachHangSacomBank.Views.Common.Withdraw;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThongTinKhachHangSacomBank.Views.Common.Transfer
{
    public interface ITransferView
    {
        void LoadUserControl(UserControl uc);
        void ShowForm();
        Form FindForm();

        event EventHandler<FormClosingEventArgs> FormClosing;
    }

    public partial class FormTransfer : Form, ITransferView
    {
        public event EventHandler<FormClosingEventArgs> FormClosing;

        public FormTransfer()
        {
            try
            {
                InitializeComponent();
                if (panelMainContentTransfer == null)
                {
                    throw new InvalidOperationException("panelMainContentTransfer không được khởi tạo trong FormTransfer.");
                }

                this.FormClosing += (s, e) => OnFormClosing(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo FormTransfer: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        // Hàm load UserControl vào panelMainContentTransfer
        public void LoadUserControl(UserControl uc)
        {
            try
            {
                if (panelMainContentTransfer == null)
                {
                    MessageBox.Show("panelMainContentTransfer không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                panelMainContentTransfer.Controls.Clear();
                uc.Dock = DockStyle.Fill;
                panelMainContentTransfer.Controls.Add(uc);
                panelMainContentTransfer.Refresh();
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
                MessageBox.Show($"Lỗi khi hiển thị FormTransfer: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected virtual void OnFormClosing(FormClosingEventArgs e)
        {
            FormClosing?.Invoke(this, e);
        }
    }

}
