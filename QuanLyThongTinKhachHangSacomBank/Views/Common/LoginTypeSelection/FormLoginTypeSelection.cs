using QuanLyThongTinKhachHangSacomBank.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThongTinKhachHangSacomBank.Views.Common.LoginTypeSelection
{
    public interface ILoginTypeSelectionView
    {
        string SelectedRole { get; set; } // Thuộc tính lưu vai trò được chọn
        string ComboBoxSelectedItem { get; } // Lấy giá trị được chọn từ ComboBox
        void ShowErrorMessage(bool isVisible); // Hiển thị hoặc ẩn lỗi
        void CloseForm(); // Đóng form
        DialogResult DialogResult { get; set; } // Để đặt DialogResult
        void Show(); // Hiển thị form
    }

    public partial class FormLoginTypeSelection : Form, ILoginTypeSelectionView
    {
        private readonly LoginTypeSelectionController controller;

        public FormLoginTypeSelection()
        {
            InitializeComponent();

            InitializeControls();
            this.controller = new LoginTypeSelectionController(this);
        }

        private void InitializeControls()
        {

            // Ẩn labelError ban đầu
            labelError.Visible = false;
        }

        // Triển khai interface ILoginTypeSelectionView
        public string SelectedRole { get; set; }

        public string ComboBoxSelectedItem => comboBoxLoginTypeSelection.SelectedItem?.ToString();

        public void ShowErrorMessage(bool isVisible)
        {
            labelError.Visible = isVisible;
        }

        public void CloseForm()
        {
            Close();
        }

        public void Show()
        {
            Application.Run(this);
        }

        private void cyberButtonLoginTypeSelection_Click(object sender, EventArgs e)
        {
            this.controller.HandleConfirmButtonClick();
        }
    }
}
