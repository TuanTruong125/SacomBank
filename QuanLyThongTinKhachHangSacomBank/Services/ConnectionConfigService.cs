// Thêm vào thư mục Services
// Services/ConnectionConfigService.cs

using Newtonsoft.Json;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;

namespace QuanLyThongTinKhachHangSacomBank.Services
{
    public class ConnectionConfigService
    {
        private const string ConfigFileName = "dbconfig.json";
        private const string EncryptionKey = "SacomBankSecureConnectionString2025";

        private class ConnectionConfig
        {
            public string Server { get; set; }
            public string Database { get; set; }
            public bool IntegratedSecurity { get; set; }
            public string UserId { get; set; }
            public string Password { get; set; }
        }

        public static bool ConfigExists()
        {
            return File.Exists(GetConfigPath());
        }

        public static string GetConnectionString()
        {
            if (!ConfigExists())
                return null;

            try
            {
                string encryptedJson = File.ReadAllText(GetConfigPath());
                string decryptedJson = Decrypt(encryptedJson);

                var config = JsonConvert.DeserializeObject<ConnectionConfig>(decryptedJson);

                if (config.IntegratedSecurity)
                {
                    return $"Server={config.Server};Database={config.Database};" +
                           "Trusted_Connection=True;TrustServerCertificate=True";
                }
                else
                {
                    return $"Server={config.Server};Database={config.Database};" +
                           $"User ID={config.UserId};Password={config.Password};" +
                           "TrustServerCertificate=True";
                }
            }
            catch
            {
                return null;
            }
        }

        public static bool SaveConnectionConfig(string server, string database,
            bool integratedSecurity, string userId = null, string password = null)
        {
            try
            {
                var config = new ConnectionConfig
                {
                    Server = server,
                    Database = database,
                    IntegratedSecurity = integratedSecurity,
                    UserId = userId,
                    Password = password
                };

                string json = JsonConvert.SerializeObject(config);
                string encryptedJson = Encrypt(json);

                File.WriteAllText(GetConfigPath(), encryptedJson);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool TestConnection(string server, string database,
            bool integratedSecurity, string userId = null, string password = null)
        {
            try
            {
                string connectionString;

                if (integratedSecurity)
                {
                    connectionString = $"Server={server};Database={database};" +
                                      "Trusted_Connection=True;TrustServerCertificate=True;Connection Timeout=5;";
                }
                else
                {
                    connectionString = $"Server={server};Database={database};" +
                                      $"User ID={userId};Password={password};" +
                                      "TrustServerCertificate=True;Connection Timeout=5;";
                }

                using (var connection = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private static string GetConfigPath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigFileName);
        }

        private static string Encrypt(string plainText)
        {
            byte[] key = Encoding.UTF8.GetBytes(EncryptionKey.PadRight(32).Substring(0, 32));
            byte[] iv = new byte[16];

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(cryptoStream))
                        {
                            writer.Write(plainText);
                        }

                        return Convert.ToBase64String(memoryStream.ToArray());
                    }
                }
            }
        }

        private static string Decrypt(string cipherText)
        {
            byte[] key = Encoding.UTF8.GetBytes(EncryptionKey.PadRight(32).Substring(0, 32));
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cryptoStream))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}