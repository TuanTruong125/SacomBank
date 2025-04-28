using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Services.AI;

namespace QuanLyThongTinKhachHangSacomBank.Views.Common.Chat
{
    public partial class UC_ChatBot : UserControl
    {
        private readonly ChatBotService _chatBotService;
        private readonly int? _accountID;

        public UC_ChatBot(DatabaseContext dbContext = null, AccountModel currentAccount = null)
        {
            InitializeComponent();

            try
            {
                _accountID = currentAccount?.AccountID;

                // Lấy đường dẫn tới file training data
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                string trainingDataPath = Path.Combine(appPath, "Data", "TrainingData", "chatbot_training.json");

                // Đảm bảo thư mục tồn tại
                Directory.CreateDirectory(Path.GetDirectoryName(trainingDataPath));

                // Khởi tạo service
                _chatBotService = new ChatBotService(dbContext, trainingDataPath);

                // Đăng ký sự kiện
                buttonSendMessage.Click += ButtonSendMessage_Click;
                textBoxMessage.KeyDown += TextBoxMessage_KeyDown;

                // Load lịch sử chat
                LoadChatHistoryAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo UC_ChatBot: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void LoadChatHistoryAsync()
        {
            try
            {
                // Lấy lịch sử trò chuyện từ database
                var chatHistory = await _chatBotService.GetChatHistoryAsync(_accountID);

                if (chatHistory.Count == 0)
                {
                    // Nếu không có lịch sử, hiển thị tin nhắn chào mừng
                    AddBotMessage("Xin chào! Tôi là SacomBot, trợ lý ảo của Sacombank. Tôi có thể giúp bạn với các thông tin về dịch vụ vay vốn và gửi tiết kiệm. Bạn cần hỗ trợ điều gì?");
                }
                else
                {
                    // Hiển thị lịch sử trò chuyện
                    foreach (var message in chatHistory)
                    {
                        if (message.IsFromBot)
                            AddBotMessage(message.MessageContent, false);
                        else
                            AddUserMessage(message.MessageContent, false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải lịch sử trò chuyện: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TextBoxMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn chặn tiếng "ding"
                SendMessageAsync();
            }
        }

        private void ButtonSendMessage_Click(object sender, EventArgs e)
        {
            SendMessageAsync();
        }

        private async void SendMessageAsync()
        {
            string userMessage = textBoxMessage.Text.Trim();

            if (string.IsNullOrEmpty(userMessage))
                return;

            // Hiển thị tin nhắn người dùng
            AddUserMessage(userMessage);

            // Xóa nội dung textbox
            textBoxMessage.Text = string.Empty;

            // Hiện thông báo "đang nhập..." cho bot
            Panel typingIndicator = AddBotTypingIndicator();

            try
            {
                // Lấy phản hồi từ chatbot
                string botResponse = await _chatBotService.GetResponseAsync(userMessage, _accountID);

                // Xóa chỉ báo "đang nhập..."
                flowLayoutPanelMessage.Controls.Remove(typingIndicator);

                // Hiển thị phản hồi của bot
                AddBotMessage(botResponse);
            }
            catch (Exception ex)
            {
                // Xóa chỉ báo "đang nhập..."
                flowLayoutPanelMessage.Controls.Remove(typingIndicator);

                // Hiển thị thông báo lỗi
                AddBotMessage($"Xin lỗi, đã xảy ra lỗi: {ex.Message}");
            }
        }

        private void AddUserMessage(string message, bool scrollToBottom = true)
        {
            Panel messagePanel = CreateMessageBubble(message, Color.FromArgb(0, 74, 173), Color.White, ContentAlignment.MiddleRight);

            // Thêm panel vào FlowLayoutPanel
            flowLayoutPanelMessage.Controls.Add(messagePanel);

            if (scrollToBottom)
                flowLayoutPanelMessage.ScrollControlIntoView(messagePanel);
        }

        private void AddBotMessage(string message, bool scrollToBottom = true)
        {
            Panel messagePanel = CreateMessageBubble(message, Color.LightSeaGreen, Color.White, ContentAlignment.MiddleLeft);

            // Thêm panel vào FlowLayoutPanel
            flowLayoutPanelMessage.Controls.Add(messagePanel);

            if (scrollToBottom)
                flowLayoutPanelMessage.ScrollControlIntoView(messagePanel);
        }

        private Panel AddBotTypingIndicator()
        {
            Panel panel = CreateMessageBubble("Đang nhập...", Color.Gray, Color.White, ContentAlignment.MiddleLeft);
            flowLayoutPanelMessage.Controls.Add(panel);
            flowLayoutPanelMessage.ScrollControlIntoView(panel);
            return panel;
        }

        private Panel CreateMessageBubble(string message, Color backgroundColor, Color textColor, ContentAlignment alignment)
        {
            Panel panel = new Panel
            {
                BackColor = backgroundColor,
                AutoSize = true,
                MaximumSize = new Size(flowLayoutPanelMessage.Width - 100, 0),
                Padding = new Padding(10),
                Margin = new Padding(5),
                
            };

            Label label = new Label
            {
                Text = message,
                ForeColor = textColor,
                Font = new Font("Roboto", 10),
                AutoSize = true,
                MaximumSize = new Size(panel.MaximumSize.Width - 20, 0),
                Dock = DockStyle.Fill
            };

            panel.Controls.Add(label);
            panel.Height = label.Height + 20; // Thêm padding
            panel.Width = label.Width + 20;

            // Đặt vị trí căn lề dựa trên người gửi (khách hàng hay bot)
            if (alignment == ContentAlignment.MiddleRight)
            {
                // Tin nhắn của khách hàng - Căn bên phải
                flowLayoutPanelMessage.FlowDirection = FlowDirection.LeftToRight;
                panel.Margin = new Padding(flowLayoutPanelMessage.Width - panel.Width - 30, 5, 5, 5);
                panel.Anchor = AnchorStyles.Right;
                label.TextAlign = ContentAlignment.MiddleRight;
            }
            else
            {
                // Tin nhắn của bot - Căn bên trái
                flowLayoutPanelMessage.FlowDirection = FlowDirection.LeftToRight;
                panel.Margin = new Padding(5, 5, 5, 5);
                panel.Anchor = AnchorStyles.Left;
                label.TextAlign = ContentAlignment.MiddleLeft;
            }

            return panel;
        }
    }
}
