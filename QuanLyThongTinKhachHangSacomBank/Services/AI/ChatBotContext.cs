using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThongTinKhachHangSacomBank.Services.AI
{
    public class ChatBotContext
    {
        private readonly List<string> _conversationHistory;
        private readonly int _maxHistoryLength;

        public ChatBotContext(int maxHistoryLength = 5)
        {
            _conversationHistory = new List<string>();
            _maxHistoryLength = maxHistoryLength;
        }

        public void AddUserMessage(string message)
        {
            _conversationHistory.Add(message);

            // Giữ lịch sử hội thoại trong giới hạn
            if (_conversationHistory.Count > _maxHistoryLength)
            {
                _conversationHistory.RemoveAt(0);
            }
        }

        public List<string> GetConversationHistory()
        {
            return _conversationHistory.ToList();
        }

        public void ClearContext()
        {
            _conversationHistory.Clear();
        }
    }
}
