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
    public interface IOpenSavingsView
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

    public partial class FormOpenSavings : Form, IOpenSavingsView
    {
        public event EventHandler SendRequestClicked;
        public event EventHandler CancelClicked;
        private int customerType;

        public FormOpenSavings()
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
            comboBoxServiceTypeName.SelectedItem = "Gửi tiết kiệm";

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

        // Getter và Setter cho các thuộc tính giao diện
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
            decimal interestRate = 0m;
            if (comboBoxDuration.SelectedItem != null)
            {
                string duration = comboBoxDuration.SelectedItem.ToString();
                switch (customerType)
                {
                    case 1: // Cá nhân thường
                        interestRate = GetInterestRateForNormalCustomer(duration);
                        break;
                    case 3: // VIP Cá nhân
                        interestRate = GetInterestRateForVIPCustomer(duration);
                        break;
                    case 2: // Doanh nghiệp
                    case 4: // VIP Doanh nghiệp
                        interestRate = 0m; // Không hỗ trợ
                        break;
                }
                textBoxInterestRate.Text = interestRate.ToString("F2") + "%/năm"; // Hiển thị dạng 5.27%/năm
            }
        }

        private decimal GetInterestRateForNormalCustomer(string duration)
        {
            int months = int.Parse(duration.Split(' ')[0]);
            switch (months)
            {
                case 12: return 5.27m;
                case 24: return 5.41m;
                case 36: return 5.27m;
                default: return 0m;
            }
        }

        private decimal GetInterestRateForVIPCustomer(string duration)
        {
            int months = int.Parse(duration.Split(' ')[0]);
            switch (months)
            {
                case 12: return 5.4m;
                case 24: return 5.7m;
                case 36: return 5.7m;
                default: return 0m;
            }
        }

        private void TextBoxTotalPrincipalAmount_TextChanged(object sender, EventArgs e)
        {
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
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }



        private void cyberButtonSendRequest_Click(object sender, EventArgs e)
        {
            SendRequestClicked?.Invoke(this, EventArgs.Empty);
        }

        private void cyberButtonCancel_Click(object sender, EventArgs e)
        {
            CancelClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
