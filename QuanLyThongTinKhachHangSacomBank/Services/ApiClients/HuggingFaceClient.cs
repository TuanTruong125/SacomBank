using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace QuanLyThongTinKhachHangSacomBank.Services.ApiClients
{
    public class HuggingFaceClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _modelEndpoint;

        public HuggingFaceClient(string apiKey, string modelEndpoint = "https://api-inference.huggingface.co/models/facebook/blenderbot-400M-distill")
        {
            _httpClient = new HttpClient();
            _apiKey = apiKey;
            _modelEndpoint = modelEndpoint;
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
        }

        public async Task<string> GetBotResponseAsync(string userInput, List<string> conversationHistory = null)
        {
            try
            {
                var payload = new
                {
                    inputs = new
                    {
                        text = userInput,
                        past_user_inputs = conversationHistory ?? new List<string>()
                    }
                };

                var content = new StringContent(
                    JsonConvert.SerializeObject(payload),
                    Encoding.UTF8,
                    "application/json");

                var response = await _httpClient.PostAsync(_modelEndpoint, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseJson = await response.Content.ReadAsStringAsync();
                    dynamic result = JsonConvert.DeserializeObject(responseJson);
                    return result.generated_text;
                }
                else
                {
                    // Trường hợp lỗi, trả về thông báo mặc định
                    return "Xin lỗi, tôi đang gặp sự cố kết nối. Vui lòng thử lại sau.";
                }
            }
            catch (Exception ex)
            {
                return $"Xin lỗi, đã xảy ra lỗi: {ex.Message}";
            }
        }
    }
}