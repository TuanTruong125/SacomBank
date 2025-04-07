using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThongTinKhachHangSacomBank.UIHelpers
{
    // Hiệu ứng khi chuyển tab giữa các chức năng trong menu FormEmployee
    class EmployeeMenu
    {
        public static void ActivateButton(List<Button> menuButtons, Button activeButton, Panel panelNavigationBar, PictureBox pictureBoxNavigationCircle)
        {
            foreach (Button btn in menuButtons)
            {
                btn.BackColor = Color.FromArgb(54, 116, 181);
                btn.ForeColor = Color.White;

                // Khôi phục ảnh gốc nếu có
                if (btn.Tag is Image originalImage)
                {
                    btn.Image = originalImage;
                }
            }

            activeButton.BackColor = Color.FromArgb(109, 232, 157);
            activeButton.ForeColor = Color.Black;

            // Lưu ảnh gốc nếu chưa lưu
            if (activeButton.Tag == null)
            {
                activeButton.Tag = activeButton.Image;
            }

            // Phóng to ảnh
            if (activeButton.Image != null)
            {
                Image original = (Image)activeButton.Tag;
                activeButton.Image = new Bitmap(original, new Size(original.Width + 5, original.Height + 5));
            }

            panelNavigationBar.BringToFront();
            panelNavigationBar.Height = activeButton.Height;
            panelNavigationBar.Top = activeButton.Top;

            pictureBoxNavigationCircle.BringToFront();
            pictureBoxNavigationCircle.Height = activeButton.Height;
            pictureBoxNavigationCircle.Top = activeButton.Top;
            pictureBoxNavigationCircle.BackColor = activeButton.BackColor;
        }
    }

    // Hiệu ứng khi chuyển tab giữa các chức năng trong menu FormCustomer
    class CustomerMenu
    {
        public static void ActivateButton(List<Button> menuButtons, Button activeButton, Panel panelNavigationBar, PictureBox pictureBoxNavigationCircle)
        {
            foreach (Button btn in menuButtons)
            {
                btn.BackColor = Color.FromArgb(54, 116, 181);
                btn.ForeColor = Color.White;

                // Khôi phục ảnh gốc nếu có
                if (btn.Tag is Image originalImage)
                {
                    btn.Image = originalImage;
                }
            }

            activeButton.BackColor = Color.FromArgb(135, 206, 235);
            activeButton.ForeColor = Color.Black;

            // Lưu ảnh gốc nếu chưa lưu
            if (activeButton.Tag == null)
            {
                activeButton.Tag = activeButton.Image;
            }

            // Phóng to ảnh
            if (activeButton.Image != null)
            {
                Image original = (Image)activeButton.Tag;
                activeButton.Image = new Bitmap(original, new Size(original.Width + 5, original.Height + 5));
            }

            panelNavigationBar.BringToFront();
            panelNavigationBar.Height = activeButton.Height;
            panelNavigationBar.Top = activeButton.Top;

            pictureBoxNavigationCircle.BringToFront();
            pictureBoxNavigationCircle.Height = activeButton.Height;
            pictureBoxNavigationCircle.Top = activeButton.Top;
            pictureBoxNavigationCircle.BackColor = activeButton.BackColor;
        }
    }

    // Hiệu ứng khi chuyển tab giữa các chức năng trong menu FormManager
    class ManagerMenu
    {
        public static void ActivateButton(List<Button> menuButtons, Button activeButton, Panel panelNavigationBar, PictureBox pictureBoxNavigationCircle)
        {
            foreach (Button btn in menuButtons)
            {
                btn.BackColor = Color.FromArgb(54, 116, 181);
                btn.ForeColor = Color.White;

                // Khôi phục ảnh gốc nếu có
                if (btn.Tag is Image originalImage)
                {
                    btn.Image = originalImage;
                }
            }

            activeButton.BackColor = Color.FromArgb(255, 128, 128);
            activeButton.ForeColor = Color.Black;

            // Lưu ảnh gốc nếu chưa lưu
            if (activeButton.Tag == null)
            {
                activeButton.Tag = activeButton.Image;
            }

            // Phóng to ảnh
            if (activeButton.Image != null)
            {
                Image original = (Image)activeButton.Tag;
                activeButton.Image = new Bitmap(original, new Size(original.Width + 5, original.Height + 5));
            }

            panelNavigationBar.BringToFront();
            panelNavigationBar.Height = activeButton.Height;
            panelNavigationBar.Top = activeButton.Top;

            pictureBoxNavigationCircle.BringToFront();
            pictureBoxNavigationCircle.Height = activeButton.Height;
            pictureBoxNavigationCircle.Top = activeButton.Top;
            pictureBoxNavigationCircle.BackColor = activeButton.BackColor;
        }
    }
}
