// Data/DatabaseContext.cs

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Services;

namespace QuanLyThongTinKhachHangSacomBank.Data
{
    public class DatabaseContext
    {
        private readonly string _connectionString;

        public DatabaseContext(IConfiguration configuration)
        {
            // Ưu tiên sử dụng cấu hình động từ ConnectionConfigService
            string dynamicConnectionString = ConnectionConfigService.GetConnectionString();

            if (!string.IsNullOrEmpty(dynamicConnectionString))
            {
                _connectionString = dynamicConnectionString;
            }
            else
            {
                // Sử dụng chuỗi kết nối từ appsettings.json nếu không có cấu hình động
                _connectionString = configuration.GetConnectionString("SacomBankConnection");
            }
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}