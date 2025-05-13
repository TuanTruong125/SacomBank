using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThongTinKhachHangSacomBank.Services;

namespace QuanLyThongTinKhachHangSacomBank.Views.Common
{
    public partial class FormDatabaseConfig : Form
    {
        public FormDatabaseConfig()
        {
            InitializeComponent();
            rbWindowsAuth.Checked = true;
            UpdateUiState();

            // Thêm controls vào panel
            pnlAuth.Controls.Add(rbWindowsAuth);
            pnlAuth.Controls.Add(rbSqlAuth);
            pnlAuth.Controls.Add(lblUsername);
            pnlAuth.Controls.Add(txtUsername);
            pnlAuth.Controls.Add(lblPassword);
            pnlAuth.Controls.Add(txtPassword);
        }

        private void UpdateUiState()
        {
            bool sqlAuthEnabled = rbSqlAuth.Checked;

            lblUsername.Enabled = sqlAuthEnabled;
            txtUsername.Enabled = sqlAuthEnabled;
            lblPassword.Enabled = sqlAuthEnabled;
            txtPassword.Enabled = sqlAuthEnabled;

            btnSave.Enabled = !string.IsNullOrWhiteSpace(txtServer.Text) &&
                              !string.IsNullOrWhiteSpace(txtDatabase.Text) &&
                              (!sqlAuthEnabled ||
                               (!string.IsNullOrWhiteSpace(txtUsername.Text) &&
                                !string.IsNullOrWhiteSpace(txtPassword.Text)));
        }

        private void rbWindowsAuth_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUiState();
        }

        private void rbSqlAuth_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUiState();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Đang kiểm tra kết nối...";
            lblStatus.ForeColor = System.Drawing.Color.Blue;
            Application.DoEvents();

            string server = txtServer.Text.Trim();
            string database = txtDatabase.Text.Trim();
            bool integratedSecurity = rbWindowsAuth.Checked;
            string userId = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            bool success = ConnectionConfigService.TestConnection(
                server, database, integratedSecurity, userId, password);

            if (success)
            {
                lblStatus.Text = "Kết nối thành công!";
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblStatus.Text = "Kết nối thất bại! Vui lòng kiểm tra thông tin.";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string server = txtServer.Text.Trim();
            string database = txtDatabase.Text.Trim();
            bool integratedSecurity = rbWindowsAuth.Checked;
            string userId = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // Kiểm tra kết nối trước khi lưu
            bool connectionValid = ConnectionConfigService.TestConnection(
                server, database, integratedSecurity, userId, password);

            if (!connectionValid)
            {
                MessageBox.Show(
                    "Không thể kết nối đến cơ sở dữ liệu với thông tin đã cung cấp.\n" +
                    "Vui lòng kiểm tra lại thông tin kết nối.",
                    "Lỗi kết nối",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            bool saveSuccess = ConnectionConfigService.SaveConnectionConfig(
                server, database, integratedSecurity, userId, password);

            if (saveSuccess)
            {
                MessageBox.Show(
                    "Cấu hình kết nối đã được lưu thành công.\n" +
                    "Ứng dụng sẽ khởi động lại để áp dụng thay đổi.",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();

                // Khởi động lại ứng dụng để áp dụng cấu hình mới
                Application.Restart();
            }
            else
            {
                MessageBox.Show(
                    "Không thể lưu cấu hình kết nối. Vui lòng kiểm tra quyền truy cập hệ thống.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}