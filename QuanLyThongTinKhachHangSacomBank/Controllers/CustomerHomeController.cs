using System;
using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Views.Customer;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class CustomerHomeController
    {
        private ICustomerHomeView view;
        private AccountModel account;
        private bool isBalanceVisible = true;

        public CustomerHomeController(ICustomerHomeView view, AccountModel account = null)
        {
            this.view = view;
            this.account = account;

            // Khởi tạo giao diện ban đầu
            InitializeView();

            // Đăng ký sự kiện
            view.ViewBalanceRequested += ToggleBalanceVisibility;
        }

        private void InitializeView()
        {
            if (account != null)
            {
                view.SetAccountName(account.AccountName);
                view.SetAccountID(account.AccountCode);
                UpdateBalanceDisplay();
                view.SetEyeImage(Properties.Resources.ViewBalance); // Mắt mở mặc định
            }
        }

        private void UpdateBalanceDisplay()
        {
            if (account != null)
            {
                if (isBalanceVisible)
                {
                    view.SetBalance(string.Format("{0:N0} VND", account.Balance));
                }
                else
                {
                    view.SetBalance("******");
                }
            }
        }

        private void ToggleBalanceVisibility(object sender, EventArgs e)
        {
            isBalanceVisible = !isBalanceVisible;
            view.SetEyeImage(isBalanceVisible ? Properties.Resources.ViewBalance : Properties.Resources.HideBalance);
            UpdateBalanceDisplay();
        }
    }
}