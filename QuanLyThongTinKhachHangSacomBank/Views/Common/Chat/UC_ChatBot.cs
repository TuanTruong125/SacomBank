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

        // Thêm vào phương thức InitializeComponent hoặc constructor
        private void ConfigureFlowLayoutPanel()
        {
            // Thiết lập cần thiết cho khả năng cuộn
            flowLayoutPanelMessage.AutoScroll = true;
            flowLayoutPanelMessage.WrapContents = false;
            flowLayoutPanelMessage.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelMessage.VerticalScroll.Visible = true;
            flowLayoutPanelMessage.HorizontalScroll.Visible = false;
            flowLayoutPanelMessage.AutoScrollMinSize = new Size(0, 0);
        }
        public UC_ChatBot(DatabaseContext dbContext = null, AccountModel currentAccount = null)
        {
            InitializeComponent();

            try
            {
                // Cấu hình FlowLayoutPanel cho cuộn
                ConfigureFlowLayoutPanel();

                _accountID = currentAccount?.AccountID;

                // Lấy đường dẫn tới file training data
                string basePath = AppContext.BaseDirectory;
                string projectPath = Path.GetFullPath(Path.Combine(basePath, "..", "..", ".."));
                string trainingDataPath = Path.Combine(projectPath, "Data", "TrainingData", "chatbot_training.json");

                // Đảm bảo thư mục tồn tại
                Directory.CreateDirectory(Path.GetDirectoryName(trainingDataPath));

                // Khởi tạo service
                _chatBotService = new ChatBotService(dbContext, trainingDataPath);

                // Đăng ký sự kiện
                buttonSendMessage.Click += ButtonSendMessage_Click;
                textBoxMessage.KeyDown += TextBoxMessage_KeyDown;

                // Thêm sự kiện resize để đảm bảo cuộn hoạt động đúng
                this.Resize += UC_ChatBot_Resize;

                // Load lịch sử chat
                LoadChatHistoryAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo UC_ChatBot: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện resize để cập nhật kích thước của các tin nhắn và cải thiện cuộn
        private void UC_ChatBot_Resize(object sender, EventArgs e)
        {
            // Cập nhật kích thước tối đa cho các tin nhắn
            foreach (Control control in flowLayoutPanelMessage.Controls)
            {
                if (control is Panel messagePanel)
                {
                    UpdateMessagePanelWidth(messagePanel);
                }
            }
        }

        // Cập nhật chiều rộng của panel tin nhắn để phù hợp với kích thước mới
        private void UpdateMessagePanelWidth(Panel messagePanel)
        {
            // Xác định xem đây là tin nhắn của bot hay người dùng
            bool isUserMessage = messagePanel.BackColor.Equals(Color.FromArgb(0, 74, 173));

            if (isUserMessage)
            {
                // Cập nhật lại vị trí cho tin nhắn người dùng
                messagePanel.Left = flowLayoutPanelMessage.Width - messagePanel.Width - 20;
            }
        }

        // Đảm bảo cuộn đến tin nhắn mới nhất
        private void EnsureMessageVisible(Panel messagePanel)
        {
            try
            {
                // Cuộn đến tin nhắn mới nhất
                flowLayoutPanelMessage.ScrollControlIntoView(messagePanel);

                // Đảm bảo cuộn đến vị trí cuối cùng
                flowLayoutPanelMessage.VerticalScroll.Value = flowLayoutPanelMessage.VerticalScroll.Maximum;
                flowLayoutPanelMessage.PerformLayout();
            }
            catch { /* Bỏ qua lỗi cuộn nếu có */ }
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
            flowLayoutPanelMessage.Controls.Add(messagePanel);

            if (scrollToBottom)
                EnsureMessageVisible(messagePanel);
        }

        private void AddBotMessage(string message, bool scrollToBottom = true)
        {
            Panel messagePanel = CreateMessageBubble(message, Color.LightSeaGreen, Color.White, ContentAlignment.MiddleLeft);
            flowLayoutPanelMessage.Controls.Add(messagePanel);

            if (scrollToBottom)
                EnsureMessageVisible(messagePanel);
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
            //Panel panel = new Panel
            //{
            //    BackColor = backgroundColor,
            //    AutoSize = true,
            //    MaximumSize = new Size(flowLayoutPanelMessage.Width - 100, 0),
            //    Padding = new Padding(10),
            //    Margin = new Padding(5),

            //};
            // Tạo panel chính đầy đủ chiều rộng
            Panel containerPanel = new Panel
            {
                Width = flowLayoutPanelMessage.ClientSize.Width - 10,
                AutoSize = true,
                BackColor = Color.Transparent,
                Margin = new Padding(5, 5, 5, 0)
            };

            // Tạo panel chứa tin nhắn (bong bóng chat)
            Panel bubblePanel = new Panel
            {
                BackColor = backgroundColor,
                AutoSize = true,
                MaximumSize = new Size((int)(flowLayoutPanelMessage.ClientSize.Width * 0.7), 0),
                Padding = new Padding(10)
            };

            // Tạo và cấu hình label cho nội dung tin nhắn
            Label label = new Label
            {
                Text = message,
                ForeColor = textColor,
                Font = new Font("Roboto", 10),
                AutoSize = true,
                MaximumSize = new Size(bubblePanel.MaximumSize.Width - 20, 0)
            };

            bubblePanel.Controls.Add(label);
            containerPanel.Controls.Add(bubblePanel);

            // Đặt vị trí tin nhắn dựa vào người gửi
            if (alignment == ContentAlignment.MiddleRight)
            {
                // Tin nhắn của khách hàng - bên phải
                bubblePanel.Left = containerPanel.Width - bubblePanel.Width - 10;
                label.TextAlign = ContentAlignment.MiddleLeft;
            }
            else
            {
                // Tin nhắn của bot - bên trái
                bubblePanel.Left = 10;
                label.TextAlign = ContentAlignment.MiddleLeft;
            }

            containerPanel.Height = bubblePanel.Height + 10;
            return containerPanel;
        }
    }
}
