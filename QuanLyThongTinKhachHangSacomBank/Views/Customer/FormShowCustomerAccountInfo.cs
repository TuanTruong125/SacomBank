using System;
using System.Windows.Forms;
using QuanLyThongTinKhachHangSacomBank.Models;
using Microsoft.Data.SqlClient;
using QuanLyThongTinKhachHangSacomBank.Data;

namespace QuanLyThongTinKhachHangSacomBank.Views.Customer
{
    public interface IFormShowCustomerAccountInfoView
    {
        void SetAccountID(string accountID);
        void SetAccountName(string accountName);
        void SetBalance(string balance);
        void SetAccountOpenDate(string openDate);
        void SetAccountTypeName(string accountTypeName);
        void SetCustomerTypeName(string customerTypeName, Color color);
        void ShowDialog();
    }

    public partial class FormShowCustomerAccountInfo : Form, IFormShowCustomerAccountInfoView
    {
        public FormShowCustomerAccountInfo()
        {
            InitializeComponent();
        }

        public void SetAccountID(string accountID)
        {
            labelAccountID.Text = accountID;
        }

        public void SetAccountName(string accountName)
        {
            labelAccountName.Text = accountName;
        }

        public void SetBalance(string balance)
        {
            labelBalance.Text = balance;
        }

        public void SetAccountOpenDate(string openDate)
        {
            labelAccountOpenDate.Text = openDate;
        }

        public void SetAccountTypeName(string accountTypeName)
        {
            labelAccountTypeName.Text = accountTypeName;
        }

        public void SetCustomerTypeName(string customerTypeName, Color color)
        {
            labelCustomerTypeName.Text = customerTypeName;
            labelCustomerTypeName.ForeColor = color;
        }

        public new void ShowDialog()
        {
            base.ShowDialog();
        }

        private void buttonAccountCopy_Click(object sender, EventArgs e)
        {
            try
            {
                // Sao chép thông tin tài khoản vào clipboard
                string accountInfo = $"Mã tài khoản: {labelAccountID.Text}\nTên tài khoản: {labelAccountName.Text}";
                Clipboard.SetText(accountInfo);
                MessageBox.Show("Thông tin tài khoản đã được sao chép vào clipboard!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sao chép thông tin tài khoản: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}