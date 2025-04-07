using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Views.Common;
using System;
using System.Net.Mail;
using System.Windows.Forms;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    public interface IOTPController
    {
        string Phone { get; }
        string Email { get; }
    }

    public class OTPController
    {
        private readonly FormOTP form;
        private readonly IOTPView view;
        private readonly IOTPController parentController;
        private readonly IConfiguration configuration;
        private string generatedOTP;
        private System.Windows.Forms.Timer countdownTimer;
        private int secondsRemaining = 30;
        private bool isCountingDown = false;
        private string selectedMethod;

        public OTPController(FormOTP form, IOTPView view, IOTPController parentController, IConfiguration configuration)
        {
            this.form = form;
            this.view = view;
            this.parentController = parentController;
            this.configuration = configuration;

            countdownTimer = new System.Windows.Forms.Timer();
            countdownTimer.Interval = 1000;
            countdownTimer.Tick += CountdownTimer_Tick;

            this.view.ConfirmMethodRequested += View_ConfirmMethodRequested;
            this.view.VerifyOTPRequested += View_VerifyOTPRequested;
            this.view.RequestAgainRequested += View_RequestAgainRequested;
        }

        private void View_ConfirmMethodRequested(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(view.SelectedMethod))
            {
                MessageBox.Show("Vui lòng chọn phương thức gửi OTP!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            selectedMethod = view.SelectedMethod;

            view.ShowOTPInputControls();
            view.HideError();

            view.EnableMethodSelection(false);
            view.EnableRequestAgain(false);

            generatedOTP = GenerateOTP();

            if (selectedMethod == "SMS")
            {
                SendOTPBySMS(parentController.Phone, generatedOTP);
            }
            else if (selectedMethod == "Email")
            {
                SendOTPByEmail(parentController.Email, generatedOTP);
            }

            secondsRemaining = 30;
            view.UpdateCountdown("0:30");
            countdownTimer.Start();
            isCountingDown = true;
        }

        private void View_VerifyOTPRequested(object sender, EventArgs e)
        {
            string enteredOTP = view.EnteredOTP;
            if (string.IsNullOrEmpty(enteredOTP) || enteredOTP.Length != 6)
            {
                view.ShowError("Vui lòng nhập đầy đủ mã OTP!");
                return;
            }

            if (!isCountingDown)
            {
                view.ShowError("Mã OTP đã hết hạn!");
                return;
            }

            if (enteredOTP != generatedOTP)
            {
                view.ShowError("Mã OTP không đúng!");
                return;
            }

            countdownTimer.Stop();
            form.DialogResult = DialogResult.OK;
            form.Close();
        }

        private void View_RequestAgainRequested(object sender, EventArgs e)
        {
            if (!isCountingDown)
            {
                view.ShowOTPInputControls();
                view.HideError();

                view.EnableMethodSelection(false);
                view.EnableRequestAgain(false);

                generatedOTP = GenerateOTP();

                if (selectedMethod == "SMS")
                {
                    SendOTPBySMS(parentController.Phone, generatedOTP);
                }
                else if (selectedMethod == "Email")
                {
                    SendOTPByEmail(parentController.Email, generatedOTP);
                }

                secondsRemaining = 30;
                view.UpdateCountdown("0:30");
                countdownTimer.Start();
                isCountingDown = true;

                view.ClearOTPTextBoxes();
                view.FocusFirstTextBox();
            }
        }

        private string GenerateOTP()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        private void SendOTPByEmail(string email, string otp)
        {
            try
            {
                string smtpServer = configuration["EmailSettings:SmtpServer"];
                int smtpPort = int.Parse(configuration["EmailSettings:SmtpPort"]);
                string senderEmail = configuration["EmailSettings:SenderEmail"];
                string senderPassword = configuration["EmailSettings:SenderPassword"];
                string senderName = configuration["EmailSettings:SenderName"];

                using (var smtpClient = new SmtpClient(smtpServer, smtpPort))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = new System.Net.NetworkCredential(senderEmail, senderPassword);

                    string htmlBody = @"
                            <html>
                            <body style='font-family: Arial, sans-serif; color: #333;'>
                                <table width='100%' cellpadding='0' cellspacing='0' border='0'>
                                    <tr>
                                        <td align='center' bgcolor='#f4f4f4' style='padding: 20px;'>
                                            <table width='600' cellpadding='0' cellspacing='0' border='0' style='background-color: #ffffff; border-radius: 8px; box-shadow: 0 2px 4px rgba(0,0,0,0.1);'>
                                                <tr>
                                                    <td align='center' style='padding: 20px;'>
                                                        <h1 style='color: #1a73e8;'>Mã OTP Xác Thực</h1>
                                                        <h2 style='color: #1a73e8; margin: 5px 0 20px 0;'>SacomBank</h2>
                                                        <p>Xin chào,</p>
                                                        <p>Chúng tôi đã nhận được yêu cầu xác thực tài khoản của bạn. Dưới đây là mã OTP của bạn:</p>
                                                        <div style='font-size: 24px; font-weight: bold; color: #d32f2f; margin: 20px 0;'>
                                                            " + otp + @"
                                                        </div>
                                                        <p>Mã này có hiệu lực trong <strong>1 phút</strong>. Vui lòng không chia sẻ mã này với bất kỳ ai.</p>
                                                        <p>Nếu bạn không yêu cầu mã này, vui lòng bỏ qua email này hoặc liên hệ với chúng tôi qua email: <a href='mailto:support@sacombank.com'>support@sacombank.com</a>.</p>
                                                        <hr style='border: 0; border-top: 1px solid #eee; margin: 20px 0;' />
                                                        <p style='font-size: 12px; color: #777;'>© 2025 SacomBank. All rights reserved.</p>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </body>
                            </html>";

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(senderEmail, senderName),
                        Subject = "Mã OTP Xác Thực - SacomBank",
                        Body = htmlBody,
                        IsBodyHtml = true
                    };
                    mailMessage.To.Add(email);

                    smtpClient.Send(mailMessage);
                    MessageBox.Show($"Mã OTP đã được gửi đến email {email}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi email: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SendOTPBySMS(string phone, string otp)
        {
            MessageBox.Show($"Mã OTP đã được gửi đến số điện thoại {phone} là: {otp}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            if (secondsRemaining > 0)
            {
                secondsRemaining--;
                int minutes = secondsRemaining / 60;
                int seconds = secondsRemaining % 60;
                view.UpdateCountdown($"{minutes}:{seconds.ToString("D2")}");
            }
            else
            {
                countdownTimer.Stop();
                isCountingDown = false;
                view.EnableMethodSelection(true);
                view.EnableRequestAgain(true);
                view.ShowError("Mã OTP đã hết hạn!");
                view.ClearOTPTextBoxes();
                view.UnfocusTextBoxes();
            }
        }
    }
}