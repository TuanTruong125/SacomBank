using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThongTinKhachHangSacomBank.Views.Customer
{
    public interface ILoanApplicationView
    {
        string AccountName { get; set; }
        string AccountID { get; set; }
        string Phone { get; set; }
        string CitizenID { get; set; }
        string ServiceTypeName { get; set; }
        string ServiceID { get; }
        string InterestRate { get; set; }
        string Duration { get; }
        DateTime CreatedDate { get; set; }
        string TotalPrincipalAmount { get; }
        string ServiceDescription { get; }
        void ShowError(string message);
        void HideError();
        event EventHandler SendRequestClicked;
        event EventHandler CancelClicked;

        void SetInterestRateBasedOnCustomerType(int customerType);
        void SetCustomerType(int customerType);
    }

    public partial class FormLoanApplication : Form, ILoanApplicationView
    {
        public event EventHandler SendRequestClicked;
        public event EventHandler CancelClicked;
        private int customerType;

        public FormLoanApplication()
        {
            InitializeComponent();
            SetupControls();
        }

        private void SetupControls()
        {
            // Vô hiệu hóa các trường không cho chỉnh sửa
            textBoxAccountName.Enabled = false;
            textBoxAccountID.Enabled = false;
            textBoxPhone.Enabled = false;
            textBoxCitizenID.Enabled = false;
            textBoxServiceID.Enabled = false;
            comboBoxServiceTypeName.Enabled = false;
            dateTimePickerCreatedDate.Enabled = false;
            textBoxInterestRate.Enabled = false;

            // Đặt giá trị mặc định cho comboBoxServiceTypeName
            comboBoxServiceTypeName.SelectedItem = "Vay vốn";

            // Để trống comboBoxDuration và textBoxInterestRate ban đầu
            comboBoxDuration.SelectedIndex = -1; // Không chọn gì
            textBoxInterestRate.Text = "";

            // Cập nhật lãi suất khi chọn kỳ hạn
            comboBoxDuration.SelectedIndexChanged += (s, e) =>
            {
                if (comboBoxDuration.SelectedItem != null)
                {
                    SetInterestRateBasedOnCustomerType(customerType);
                }
            };

            // Định dạng số tiền cho textBoxTotalPrincipalAmount
            textBoxTotalPrincipalAmount.TextChanged += TextBoxTotalPrincipalAmount_TextChanged;
            textBoxTotalPrincipalAmount.KeyPress += TextBoxTotalPrincipalAmount_KeyPress;
        }

        // Chỉ giữ getter cho các thuộc tính lấy dữ liệu từ giao diện
        public string AccountName
        {
            get => textBoxAccountName.Text;
            set => textBoxAccountName.Text = value;
        }
        public string AccountID
        {
            get => textBoxAccountID.Text;
            set => textBoxAccountID.Text = value;
        }
        public string Phone
        {
            get => textBoxPhone.Text;
            set => textBoxPhone.Text = value;
        }
        public string CitizenID
        {
            get => textBoxCitizenID.Text;
            set => textBoxCitizenID.Text = value;
        }
        public string ServiceID => textBoxServiceID.Text;
        public string ServiceTypeName
        {
            get => comboBoxServiceTypeName.SelectedItem?.ToString();
            set => comboBoxServiceTypeName.SelectedItem = value;
        }
        public string InterestRate
        {
            get => textBoxInterestRate.Text;
            set => textBoxInterestRate.Text = value;
        }
        public string Duration => comboBoxDuration.SelectedItem?.ToString();
        public DateTime CreatedDate
        {
            get => dateTimePickerCreatedDate.Value;
            set => dateTimePickerCreatedDate.Value = value;
        }
        public string TotalPrincipalAmount => textBoxTotalPrincipalAmount.Text;
        public string ServiceDescription => textBoxServiceDescription.Text;

        public void ShowError(string message)
        {
            labelError.Text = message;
            labelError.Visible = !string.IsNullOrEmpty(message);
        }

        public void HideError()
        {
            labelError.Visible = false;
        }

        public void SetCustomerType(int customerType)
        {
            this.customerType = customerType;
        }

        public void SetInterestRateBasedOnCustomerType(int customerType)
        {
            decimal interestRate;
            switch (customerType)
            {
                case 1: // Cá nhân
                    interestRate = 6m; // 6%
                    break;
                case 2: // Doanh nghiệp
                    interestRate = 5m; // 5%
                    break;
                case 3: // VIP Cá nhân
                    interestRate = 5m; // 5%
                    break;
                case 4: // VIP Doanh nghiệp
                    interestRate = 4m; // 4%
                    break;
                default:
                    interestRate = 0m;
                    break;
            }
            textBoxInterestRate.Text = interestRate.ToString();
        }

        private void TextBoxTotalPrincipalAmount_TextChanged(object sender, EventArgs e)
        {
            // Định dạng số tiền: thêm dấu phẩy sau mỗi 3 chữ số
            string text = textBoxTotalPrincipalAmount.Text.Replace(",", "");
            if (string.IsNullOrEmpty(text)) return;

            if (decimal.TryParse(text, out decimal number))
            {
                textBoxTotalPrincipalAmount.TextChanged -= TextBoxTotalPrincipalAmount_TextChanged;
                textBoxTotalPrincipalAmount.Text = number.ToString("#,##0");
                textBoxTotalPrincipalAmount.SelectionStart = textBoxTotalPrincipalAmount.Text.Length;
                textBoxTotalPrincipalAmount.TextChanged += TextBoxTotalPrincipalAmount_TextChanged;
            }
        }

        private void TextBoxTotalPrincipalAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và phím Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }


        private void cyberButtonCancel_Click(object sender, EventArgs e)
        {
            CancelClicked?.Invoke(this, EventArgs.Empty);
        }

        private void cyberButtonSendRequest_Click(object sender, EventArgs e)
        {
            SendRequestClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
