using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace QuanLyThongTinKhachHangSacomBank.Data
{
    public class DatabaseContext
    {
        private readonly string _connectionString;

        public DatabaseContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SacomBankConnection");
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}