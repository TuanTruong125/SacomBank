using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.Data.SqlClient;
using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Data;
using System.IO;

namespace QuanLyThongTinKhachHangSacomBank.Views.Customer
{
    public interface IFormTransactionHistoryView
    {
        void SetAccountID(string accountID);
        void SetAccountName(string accountName);
        void DisplayTransactions(List<TransactionDisplayModel> transactions);
        void ShowDialog();

        DateTime DateFrom { get; }
        DateTime DateTo { get; }
        string TransactionTypeNameFilter { get; }

        event EventHandler FilterChanged;
        event EventHandler ExportPDFRequested;
        event EventHandler ExportExcelRequested;
        event EventHandler ExportCSVRequested;
    }

    public partial class FormTransactionHistory : Form, IFormTransactionHistoryView
    {
        private readonly DatabaseContext _dbContext;
        private int accountId;
        private string accountName;

        public event EventHandler FilterChanged;
        public event EventHandler ExportPDFRequested;
        public event EventHandler ExportExcelRequested;
        public event EventHandler ExportCSVRequested;

        public DateTime DateFrom => dateTimePickerFrom.Value;
        public DateTime DateTo => dateTimePickerTo.Value;
        public string TransactionTypeNameFilter => comboBoxTransactionTypeNameFilter.SelectedItem?.ToString() ?? "Không áp dụng";

        public FormTransactionHistory(DatabaseContext dbContext)
        {
            InitializeComponent();

            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

            // Đặt DataGridView thành chỉ đọc
            dataGridViewTransactionHistory.ReadOnly = true;

            // Mặc định chọn "Không áp dụng" cho bộ lọc loại giao dịch
            comboBoxTransactionTypeNameFilter.SelectedIndex = 0;

            // Mặc định khoảng thời gian lọc: từ 1 tháng trước đến hiện tại
            dateTimePickerFrom.Value = DateTime.Now.AddMonths(-1);
            dateTimePickerTo.Value = DateTime.Now;

            // Đăng ký sự kiện lọc
            dateTimePickerFrom.ValueChanged += OnFilterChanged;
            dateTimePickerTo.ValueChanged += OnFilterChanged;
            comboBoxTransactionTypeNameFilter.SelectedIndexChanged += OnFilterChanged;

            // Đăng ký sự kiện để định dạng màu sắc cho cột "Số tiền"
            dataGridViewTransactionHistory.CellFormatting += DataGridViewTransactionHistory_CellFormatting;

        }

        public void SetAccountID(string accountID)
        {
            this.accountId = int.Parse(accountID);
        }

        public void SetAccountName(string accountName)
        {
            this.accountName = accountName;
        }

        public void DisplayTransactions(List<TransactionDisplayModel> transactions)
        {
            dataGridViewTransactionHistory.Rows.Clear();

            foreach (var transaction in transactions)
            {
                dataGridViewTransactionHistory.Rows.Add(
                    transaction.TransactionID,
                    transaction.TransactionTypeName,
                    transaction.ServiceID,
                    transaction.Amount,
                    transaction.TransactionDate,
                    transaction.TransactionDescription,
                    transaction.FromAccount,
                    transaction.ToAccount
                );
            }
        }

        public new void ShowDialog()
        {
            base.ShowDialog();
        }

        private void OnFilterChanged(object sender, EventArgs e)
        {
            FilterChanged?.Invoke(this, EventArgs.Empty);
        }

        private void DataGridViewTransactionHistory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Định dạng màu sắc cho cột "Số tiền" (cột thứ 4, index 3)
            if (e.ColumnIndex == 3 && e.RowIndex >= 0)
            {
                string amount = dataGridViewTransactionHistory.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                if (!string.IsNullOrEmpty(amount))
                {
                    if (amount.StartsWith("+"))
                    {
                        e.CellStyle.ForeColor = Color.Green; // Màu xanh lá cho số tiền dương
                    }
                    else if (amount.StartsWith("-"))
                    {
                        e.CellStyle.ForeColor = Color.Red; // Màu đỏ cho số tiền âm
                    }
                }
            }
        }

        private void buttonExportPDF_Click(object sender, EventArgs e)
        {
            ExportPDFRequested?.Invoke(this, EventArgs.Empty);
        }

        private void buttonExportExcel_Click(object sender, EventArgs e)
        {
            ExportExcelRequested?.Invoke(this, EventArgs.Empty);
        }

        private void buttonExportCSV_Click(object sender, EventArgs e)
        {
            ExportCSVRequested?.Invoke(this, EventArgs.Empty);
        }
    }

    // Model để truyền dữ liệu đã xử lý từ controller sang view
    public class TransactionDisplayModel
    {
        public int TransactionID { get; set; }
        public string TransactionTypeName { get; set; }
        public string ServiceID { get; set; }
        public string Amount { get; set; } // Định dạng: "+ 200,000 VND" hoặc "- 200,000 VND"
        public string TransactionDate { get; set; }
        public string TransactionDescription { get; set; }
        public string FromAccount { get; set; }
        public string ToAccount { get; set; }
    }
}

   
