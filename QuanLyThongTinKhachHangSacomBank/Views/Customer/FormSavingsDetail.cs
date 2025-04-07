using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThongTinKhachHangSacomBank.Views.Customer
{
    public partial class FormSavingsDetail : Form
    {
        public FormSavingsDetail()
        {
            InitializeComponent();
        }

        private void buttonScrollToTopSavingsDetail_Click(object sender, EventArgs e)
        {
            this.AutoScrollPosition = new Point(0, 0); // Đưa thanh cuộn về đầu
        }
    }
}
