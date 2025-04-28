using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace QuanLyThongTinKhachHangSacomBank.Services.AI
{
    public class TrainingDataManager
    {
        private readonly string _trainingDataPath;

        public TrainingDataManager(string trainingDataPath)
        {
            _trainingDataPath = trainingDataPath;

            // Đảm bảo thư mục tồn tại
            Directory.CreateDirectory(Path.GetDirectoryName(_trainingDataPath));

            // Tạo file nếu chưa tồn tại
            if (!File.Exists(_trainingDataPath))
            {
                File.WriteAllText(_trainingDataPath, JsonConvert.SerializeObject(new List<TrainingData>()));
            }
        }

        public void AddTrainingData(string question, string answer)
        {
            try
            {
                var trainingDataList = LoadTrainingData();

                // Kiểm tra xem câu hỏi đã tồn tại chưa
                var existingData = trainingDataList.Find(x => x.Question.Equals(question, StringComparison.OrdinalIgnoreCase));

                if (existingData != null)
                {
                    existingData.Answer = answer;
                }
                else
                {
                    trainingDataList.Add(new TrainingData { Question = question, Answer = answer });
                }

                // Lưu lại dữ liệu
                File.WriteAllText(_trainingDataPath, JsonConvert.SerializeObject(trainingDataList, Formatting.Indented));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thêm dữ liệu huấn luyện: {ex.Message}");
            }
        }

        public List<TrainingData> LoadTrainingData()
        {
            try
            {
                var json = File.ReadAllText(_trainingDataPath);
                return JsonConvert.DeserializeObject<List<TrainingData>>(json) ?? new List<TrainingData>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi đọc dữ liệu huấn luyện: {ex.Message}");
                return new List<TrainingData>();
            }
        }

        public class TrainingData
        {
            public string Question { get; set; }
            public string Answer { get; set; }
        }
    }
}