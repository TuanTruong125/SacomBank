using Newtonsoft.Json;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuanLyThongTinKhachHangSacomBank.Services.AI
{
    public class ChatBotService
    {
        private readonly string _trainingDataPath;
        private readonly DatabaseContext _dbContext;
        private readonly List<TrainingData> _trainingData;

        public ChatBotService(DatabaseContext dbContext, string trainingDataPath)
        {
            _dbContext = dbContext;
            _trainingDataPath = trainingDataPath;
            _trainingData = LoadTrainingData();
        }

        // Tải dữ liệu huấn luyện từ file JSON
        private List<TrainingData> LoadTrainingData()
        {
            try
            {
                if (File.Exists(_trainingDataPath))
                {
                    string json = File.ReadAllText(_trainingDataPath);
                    return JsonConvert.DeserializeObject<List<TrainingData>>(json) ?? new List<TrainingData>();
                }
                return new List<TrainingData>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi đọc dữ liệu huấn luyện: {ex.Message}");
                return new List<TrainingData>();
            }
        }

        // Xử lý câu hỏi của người dùng
        public async Task<string> GetResponseAsync(string userInput, int? accountID = null)
        {
            if (string.IsNullOrWhiteSpace(userInput))
                return "Xin lỗi, tôi không hiểu bạn đang hỏi gì. Vui lòng thử lại.";

            // Lưu tin nhắn của người dùng vào DB
            await SaveMessageToDatabaseAsync(userInput, false, accountID);

            // Tìm câu trả lời phù hợp nhất
            var bestMatch = FindBestMatch(userInput);

            string response;
            if (bestMatch != null)
            {
                response = bestMatch.Answer;
            }
            else
            {
                response = "Xin lỗi, tôi chưa có thông tin về vấn đề này. Bạn có thể hỏi về lãi suất vay vốn, tiết kiệm, hoặc thủ tục đăng ký dịch vụ.";
            }

            // Lưu câu trả lời của bot vào DB
            await SaveMessageToDatabaseAsync(response, true, accountID);

            return response;
        }

        // Lưu tin nhắn vào database
        private async Task SaveMessageToDatabaseAsync(string message, bool isFromBot, int? accountID)
        {
            try
            {
                using (var connection = _dbContext.GetConnection())
                {
                    connection.Open();
                    string query = @"
                        INSERT INTO CHATMESSAGE (AccountID, MessageContent, IsFromBot, MessageTime)
                        VALUES (@AccountID, @MessageContent, @IsFromBot, @MessageTime)";

                    using (var command = new Microsoft.Data.SqlClient.SqlCommand(query, connection))
                    {
                        if (accountID.HasValue)
                            command.Parameters.AddWithValue("@AccountID", accountID.Value);
                        else
                            command.Parameters.AddWithValue("@AccountID", DBNull.Value);

                        command.Parameters.AddWithValue("@MessageContent", message);
                        command.Parameters.AddWithValue("@IsFromBot", isFromBot);
                        command.Parameters.AddWithValue("@MessageTime", DateTime.Now);

                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lưu tin nhắn: {ex.Message}");
            }
        }

        // Tải lịch sử trò chuyện từ database
        public async Task<List<ChatMessageModel>> GetChatHistoryAsync(int? accountID)
        {
            var chatHistory = new List<ChatMessageModel>();

            try
            {
                using (var connection = _dbContext.GetConnection())
                {
                    connection.Open();
                    string query = @"
                        SELECT MessageID, AccountID, MessageContent, IsFromBot, MessageTime
                        FROM CHATMESSAGE
                        WHERE AccountID IS NULL OR AccountID = @AccountID
                        ORDER BY MessageTime";

                    using (var command = new Microsoft.Data.SqlClient.SqlCommand(query, connection))
                    {
                        if (accountID.HasValue)
                            command.Parameters.AddWithValue("@AccountID", accountID.Value);
                        else
                            command.Parameters.AddWithValue("@AccountID", DBNull.Value);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                chatHistory.Add(new ChatMessageModel
                                {
                                    MessageID = reader.GetInt32(0),
                                    AccountID = reader.IsDBNull(1) ? null : (int?)reader.GetInt32(1),
                                    MessageContent = reader.GetString(2),
                                    IsFromBot = reader.GetBoolean(3),
                                    MessageTime = reader.GetDateTime(4)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tải lịch sử trò chuyện: {ex.Message}");
            }

            return chatHistory;
        }

        // Tìm câu trả lời phù hợp nhất
        private TrainingData FindBestMatch(string userInput)
        {
            const double SIMILARITY_THRESHOLD = 0.6;
            double maxSimilarity = 0;
            TrainingData bestMatch = null;

            foreach (var data in _trainingData)
            {
                double similarity = CalculateSimilarity(userInput, data);

                if (similarity > maxSimilarity && similarity >= SIMILARITY_THRESHOLD)
                {
                    maxSimilarity = similarity;
                    bestMatch = data;
                }
            }

            return bestMatch;
        }

        // Tính độ tương đồng giữa câu hỏi người dùng và dữ liệu huấn luyện
        private double CalculateSimilarity(string userInput, TrainingData data)
        {
            userInput = NormalizeText(userInput);

            // Tính điểm theo từ khóa
            int keywordMatchCount = 0;
            foreach (var keyword in data.Keywords)
            {
                if (userInput.Contains(NormalizeText(keyword)))
                {
                    keywordMatchCount++;
                }
            }

            // Nếu không có từ khóa nào khớp, trả về 0
            if (keywordMatchCount == 0)
                return 0;

            double keywordSimilarity = (double)keywordMatchCount / data.Keywords.Count;

            // Tính độ tương đồng văn bản
            string normalizedQuestion = NormalizeText(data.Question);
            var userWords = userInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var questionWords = normalizedQuestion.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int commonWords = userWords.Intersect(questionWords).Count();
            double textSimilarity = (double)commonWords / Math.Max(userWords.Length, questionWords.Length);

            // Kết hợp cả hai điểm số, ưu tiên từ khóa hơn
            return (keywordSimilarity * 0.7) + (textSimilarity * 0.3);
        }

        // Chuẩn hóa văn bản để so sánh
        private string NormalizeText(string text)
        {
            // Chuyển về chữ thường
            text = text.ToLower();

            // Loại bỏ dấu câu
            text = Regex.Replace(text, @"[^\w\s]", "");

            // Loại bỏ dấu tiếng Việt
            text = RemoveVietnameseAccents(text);

            return text;
        }

        // Loại bỏ dấu tiếng Việt
        private string RemoveVietnameseAccents(string text)
        {
            string[] vietnameseSigns = new string[]
            {
                "aAeEoOuUiIdDyY",
                "áàạảãâấầậẩẫăắằặẳẵ",
                "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
                "éèẹẻẽêếềệểễ",
                "ÉÈẸẺẼÊẾỀỆỂỄ",
                "óòọỏõôốồộổỗơớờợởỡ",
                "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
                "úùụủũưứừựửữ",
                "ÚÙỤỦŨƯỨỪỰỬỮ",
                "íìịỉĩ",
                "ÍÌỊỈĨ",
                "đ",
                "Đ",
                "ýỳỵỷỹ",
                "ÝỲỴỶỸ"
            };

            for (int i = 1; i < vietnameseSigns.Length; i++)
            {
                for (int j = 0; j < vietnameseSigns[i].Length; j++)
                {
                    text = text.Replace(vietnameseSigns[i][j], vietnameseSigns[0][i - 1]);
                }
            }

            return text;
        }

        // Cấu trúc dữ liệu huấn luyện
        public class TrainingData
        {
            public string Question { get; set; }
            public string Answer { get; set; }
            public List<string> Keywords { get; set; }
        }
    }
}