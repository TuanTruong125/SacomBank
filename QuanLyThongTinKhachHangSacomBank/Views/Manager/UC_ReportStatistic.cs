using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Controllers;
using QuanLyThongTinKhachHangSacomBank.Data;

namespace QuanLyThongTinKhachHangSacomBank.Views.Manager
{
    public interface IReportStatisticView
    {
        void UpdateRevenueDataGridView(List<RevenueDisplayModel> revenues);
        void UpdateExpenseDataGridView(List<ExpenseDisplayModel> expenses);
        void UpdateProfitDataGridView(List<ProfitDisplayModel> profits);
        void UpdateSummaryLabels(decimal totalRevenue, decimal totalExpense, decimal netProfit, decimal maxRevenue, decimal maxExpense, decimal maxNetProfit);

        List<RevenueDisplayModel> GetRevenueData();
        List<ExpenseDisplayModel> GetExpenseData();
        List<ProfitDisplayModel> GetProfitData();
        DateTime GetDateFrom();
        DateTime GetDateTo();
        string GetTotalRevenue();
        string GetTotalExpense();
        string GetNetProfit();
        string GetMaxRevenueAmount();
        string GetMaxExpenseAmount();
        string GetMaxNetProfit();
    }

    public partial class UC_ReportStatistic : UserControl, IReportStatisticView
    {
        private readonly ManagerReportStatisticController controller;
        private readonly DatabaseContext dbContext;
        private readonly IConfiguration configuration;

        public UC_ReportStatistic(DatabaseContext dbContext, IConfiguration configuration)
        {
            InitializeComponent();
            this.dbContext = dbContext;
            this.configuration = configuration;
            controller = new ManagerReportStatisticController(this, dbContext, configuration);

            dateTimePickerFrom.Value = DateTime.Now;
            dateTimePickerTo.Value = DateTime.Now;

            LoadData();
        }



        // Tải dữ liệu cho các DataGridView và Label
        private void LoadData()
        {
            DateTime fromDate = dateTimePickerFrom.Value.Date;
            DateTime toDate = dateTimePickerTo.Value.Date;

            if (fromDate > toDate)
            {
                dataGridViewRevenue.Rows.Clear();
                dataGridViewExpense.Rows.Clear();
                dataGridViewProfit.Rows.Clear();

                labelTotalRevenue.Text = "0 VND";
                labelTotalExpense.Text = "0 VND";
                labelNetProfit.Text = "0 VND";
                labelMaxRevenueAmount.Text = "0 VND";
                labelMaxExpenseAmount.Text = "0 VND";
                labelMaxNetProfit.Text = "0 VND";

                labelRevenueDate.Text = "";
                labelExpenseDate.Text = "";
                labelProfitDate.Text = "";
                return;
            }

            // Tải dữ liệu cho tất cả DataGridViews và nhãn
            controller.LoadData(fromDate, toDate);

            // Cập nhật nhãn ngày dựa trên bộ lọc
            if (fromDate == toDate)
            {
                labelRevenueDate.Text = fromDate.ToString("dd/MM/yyyy");
                labelExpenseDate.Text = fromDate.ToString("dd/MM/yyyy");
                labelProfitDate.Text = fromDate.ToString("dd/MM/yyyy");
            }
            else
            {
                labelRevenueDate.Text = $"{fromDate.ToString("dd/MM/yyyy")} - {toDate.ToString("dd/MM/yyyy")}";
                labelExpenseDate.Text = $"{fromDate.ToString("dd/MM/yyyy")} - {toDate.ToString("dd/MM/yyyy")}";
                labelProfitDate.Text = $"{fromDate.ToString("dd/MM/yyyy")} - {toDate.ToString("dd/MM/yyyy")}";
            }
        }



        // Cập nhật DataGridView doanh thu
        public void UpdateRevenueDataGridView(List<RevenueDisplayModel> revenues)
        {
            dataGridViewRevenue.Rows.Clear();
            foreach (var revenue in revenues)
            {
                dataGridViewRevenue.Rows.Add(
                    revenue.PayLoanCode,
                    revenue.RevenueCode,
                    revenue.PrincipalAmount,
                    revenue.InterestAmount,
                    revenue.LateFee,
                    revenue.TotalAmount,
                    revenue.RevenueDate
                );
            }
        }



        // Cập nhật DataGridView chi phí
        public void UpdateExpenseDataGridView(List<ExpenseDisplayModel> expenses)
        {
            dataGridViewExpense.Rows.Clear();
            foreach (var expense in expenses)
            {
                dataGridViewExpense.Rows.Add(
                    expense.PaySavingsCode,
                    expense.ExpenseCode,
                    expense.InterestPaid,
                    expense.EmployeeSalary,
                    expense.SystemMaintenanceFee,
                    expense.ExpenseDate
                );
            }
        }



        // Cập nhật DataGridView lợi nhuận
        public void UpdateProfitDataGridView(List<ProfitDisplayModel> profits)
        {
            dataGridViewProfit.Rows.Clear();
            foreach (var profit in profits)
            {
                dataGridViewProfit.Rows.Add(
                    profit.ProfitCode,
                    profit.TotalRevenue,
                    profit.TotalExpense,
                    profit.NetProfit,
                    profit.ProfitDate
                );
            }
        }



        // Cập nhật nhãn tổng doanh thu, chi phí và lợi nhuận
        public void UpdateSummaryLabels(decimal totalRevenue, decimal totalExpense, decimal netProfit, decimal maxRevenue, decimal maxExpense, decimal maxNetProfit)
        {
            labelTotalRevenue.Text = totalRevenue.ToString("N0") + " VND";
            labelTotalExpense.Text = totalExpense.ToString("N0") + " VND";
            labelNetProfit.Text = netProfit.ToString("N0") + " VND";
            labelMaxRevenueAmount.Text = maxRevenue.ToString("N0") + " VND";
            labelMaxExpenseAmount.Text = maxExpense.ToString("N0") + " VND";
            labelMaxNetProfit.Text = maxNetProfit.ToString("N0") + " VND";
        }



        // Lấy dữ liệu doanh thu từ DataGridView
        public List<RevenueDisplayModel> GetRevenueData()
        {
            var revenues = new List<RevenueDisplayModel>();
            foreach (DataGridViewRow row in dataGridViewRevenue.Rows)
            {
                if (!row.IsNewRow)
                {
                    revenues.Add(new RevenueDisplayModel
                    {
                        PayLoanCode = row.Cells[0].Value?.ToString() ?? "",
                        RevenueCode = row.Cells[1].Value?.ToString() ?? "",
                        PrincipalAmount = row.Cells[2].Value?.ToString() ?? "0",
                        InterestAmount = row.Cells[3].Value?.ToString() ?? "0",
                        LateFee = row.Cells[4].Value?.ToString() ?? "0",
                        TotalAmount = row.Cells[5].Value?.ToString() ?? "0",
                        RevenueDate = row.Cells[6].Value?.ToString() ?? ""
                    });
                }
            }
            return revenues;
        }



        // Lấy dữ liệu chi phí từ DataGridView
        public List<ExpenseDisplayModel> GetExpenseData()
        {
            var expenses = new List<ExpenseDisplayModel>();
            foreach (DataGridViewRow row in dataGridViewExpense.Rows)
            {
                if (!row.IsNewRow)
                {
                    expenses.Add(new ExpenseDisplayModel
                    {
                        PaySavingsCode = row.Cells[0].Value?.ToString() ?? "",
                        ExpenseCode = row.Cells[1].Value?.ToString() ?? "",
                        InterestPaid = row.Cells[2].Value?.ToString() ?? "0",
                        EmployeeSalary = row.Cells[3].Value?.ToString() ?? "0",
                        SystemMaintenanceFee = row.Cells[4].Value?.ToString() ?? "0",
                        ExpenseDate = row.Cells[5].Value?.ToString() ?? ""
                    });
                }
            }
            return expenses;
        }



        // Lấy dữ liệu lợi nhuận từ DataGridView
        public List<ProfitDisplayModel> GetProfitData()
        {
            var profits = new List<ProfitDisplayModel>();
            foreach (DataGridViewRow row in dataGridViewProfit.Rows)
            {
                if (!row.IsNewRow)
                {
                    profits.Add(new ProfitDisplayModel
                    {
                        ProfitCode = row.Cells[0].Value?.ToString() ?? "",
                        TotalRevenue = row.Cells[1].Value?.ToString() ?? "0",
                        TotalExpense = row.Cells[2].Value?.ToString() ?? "0",
                        NetProfit = row.Cells[3].Value?.ToString() ?? "0",
                        ProfitDate = row.Cells[4].Value?.ToString() ?? ""
                    });
                }
            }
            return profits;
        }



        // Lấy ngày bắt đầu từ dateTimePickerFrom
        public DateTime GetDateFrom() => dateTimePickerFrom.Value.Date;

        // Lấy ngày kết thúc từ dateTimePickerTo
        public DateTime GetDateTo() => dateTimePickerTo.Value.Date;

        // Lấy giá trị của nhãn Tổng doanh thu
        public string GetTotalRevenue() => labelTotalRevenue.Text;

        // Lấy giá trị của nhãn Tổng chi phí
        public string GetTotalExpense() => labelTotalExpense.Text;

        // Lấy giá trị của nhãn Lợi nhuận ròng
        public string GetNetProfit() => labelNetProfit.Text;

        // Lấy giá trị của nhãn Doanh thu lớn nhất
        public string GetMaxRevenueAmount() => labelMaxRevenueAmount.Text;

        // Lấy giá trị của nhãn Chi phí lớn nhất
        public string GetMaxExpenseAmount() => labelMaxExpenseAmount.Text;

        // Lấy giá trị của nhãn Lợi nhuận lớn nhất
        public string GetMaxNetProfit() => labelMaxNetProfit.Text;



        // Sự kiện khi người dùng thay đổi ngày và nhấn nút xuất file
        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonExportPDF_Click(object sender, EventArgs e)
        {
            controller.ExportToPDF();
        }

        private void buttonExportExcel_Click(object sender, EventArgs e)
        {
            controller.ExportToExcel();
        }
    }

    public class RevenueDisplayModel
    {
        public string PayLoanCode { get; set; }
        public string RevenueCode { get; set; }
        public string PrincipalAmount { get; set; }
        public string InterestAmount { get; set; }
        public string LateFee { get; set; }
        public string TotalAmount { get; set; }
        public string RevenueDate { get; set; }
    }

    public class ExpenseDisplayModel
    {
        public string PaySavingsCode { get; set; }
        public string ExpenseCode { get; set; }
        public string InterestPaid { get; set; }
        public string EmployeeSalary { get; set; }
        public string SystemMaintenanceFee { get; set; }
        public string ExpenseDate { get; set; }
    }

    public class ProfitDisplayModel
    {
        public string ProfitCode { get; set; }
        public string TotalRevenue { get; set; }
        public string TotalExpense { get; set; }
        public string NetProfit { get; set; }
        public string ProfitDate { get; set; }
    }
}
