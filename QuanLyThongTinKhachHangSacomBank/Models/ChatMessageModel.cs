using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThongTinKhachHangSacomBank.Models
{
    public class ChatMessageModel
    {
        public int MessageID { get; set; }
        public int? AccountID { get; set; }
        public string MessageContent { get; set; }
        public bool IsFromBot { get; set; }
        public DateTime MessageTime { get; set; }

        public ChatMessageModel()
        {
            MessageTime = DateTime.Now;
        }

        public ChatMessageModel(string messageContent, bool isFromBot, int? accountID = null)
        {
            MessageContent = messageContent;
            IsFromBot = isFromBot;
            AccountID = accountID;
            MessageTime = DateTime.Now;
        }
    }
}
