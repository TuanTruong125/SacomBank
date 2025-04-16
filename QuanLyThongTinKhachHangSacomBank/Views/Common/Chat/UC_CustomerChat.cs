using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Views.Employee;

namespace QuanLyThongTinKhachHangSacomBank.Views.Common.Chat
{
    public interface ICustomerChatView
    {
        string GetTitle();
        string GetMessage();
        void SetSendButtonEnable(bool enable);
        void ClearInputs();
        void ShowConfirmation(string message, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, Action onYes);
        event EventHandler SendRequestClicked;
        void LoadRequests(List<RequestDisplayModel> requests);
    }

    public partial class UC_CustomerChat : UserControl, ICustomerChatView
    {
        private readonly AccountModel currentAccount;
        public event EventHandler SendRequestClicked;

        public UC_CustomerChat()
        {
            InitializeComponent();
            InitializeControlState();
        }

        // Constructor mới nhận currentAccount
        public UC_CustomerChat(AccountModel currentAccount)
        {
            this.currentAccount = currentAccount; // Lưu trữ currentAccount
            InitializeComponent();
            InitializeControlState();
        }

        private void InitializeControlState()
        {
            dataGridViewChat.ReadOnly = true;
            dataGridViewChat.AllowUserToDeleteRows = false;
            dataGridViewChat.AutoGenerateColumns = false;
            dataGridViewChat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewChat.MultiSelect = false;
        }

        public string GetTitle() => textBoxTitle.Text.Trim();
        public string GetMessage() => richTextBoxMessage.Text.Trim();

        public void SetSendButtonEnable(bool enable) => buttonSendMessage.Enabled = enable;

        public void ClearInputs()
        {
            textBoxTitle.Clear();
            richTextBoxMessage.Clear();
        }

        public void ShowConfirmation(string message, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, Action onYes)
        {
            if (MessageBox.Show(message, caption, buttons, icon) == DialogResult.Yes)
            {
                onYes?.Invoke();
            }
        }

        public void LoadRequests(List<RequestDisplayModel> requests)
        {
            dataGridViewChat.Rows.Clear();
            foreach (var request in requests)
            {
                // Giới hạn RequestMessage hiển thị tối đa 30 ký tự
                string displayMessage = request.RequestMessage;
                if (!string.IsNullOrEmpty(displayMessage) && displayMessage.Length > 30)
                {
                    displayMessage = displayMessage.Substring(0, 30) + "...";
                }

                dataGridViewChat.Rows.Add(
                    request.CustomerCode,
                    request.RequestCode,
                    request.Title,
                    displayMessage, // Sử dụng chuỗi đã cắt ngắn
                    request.RequestDate,
                    request.EmployeeName,
                    request.RequestStatus
                );
            }
        }



        private void buttonSendMessage_Click(object sender, EventArgs e)
        {
            SendRequestClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
