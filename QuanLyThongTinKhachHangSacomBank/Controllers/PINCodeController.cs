using System;
using System.Windows.Forms;
using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Views.Common;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    public class PINCodeController
    {
        private readonly FormPINCode form;
        private readonly IPINCodeView view;
        private readonly AccountModel account;

        public PINCodeController(FormPINCode form, IPINCodeView view, AccountModel account)
        {
            this.form = form;
            this.view = view;
            this.account = account;
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            view.VerifyPINRequested += View_VerifyPINRequested;
        }

        private void View_VerifyPINRequested(object sender, EventArgs e)
        {
            try
            {
                string enteredPIN = view.EnteredPIN;

                if (string.IsNullOrEmpty(enteredPIN) || enteredPIN.Length != 6)
                {
                    view.ShowError("Vui lòng nhập đầy đủ mã PIN!");
                    return;
                }

                if (enteredPIN != account.PINCode)
                {
                    view.ShowError("Mã PIN không đúng!");
                    return;
                }

                view.HideError();
                form.DialogResult = DialogResult.OK;
                form.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xác thực mã PIN: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}