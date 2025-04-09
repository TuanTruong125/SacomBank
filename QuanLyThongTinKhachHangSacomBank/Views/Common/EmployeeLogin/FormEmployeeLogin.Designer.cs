namespace QuanLyThongTinKhachHangSacomBank.Views.Common.EmployeeLogin
{
    partial class FormEmployeeLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEmployeeLogin));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            panelMainContentEmployeeLogin = new Panel();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = Properties.Resources.Left_Login;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(448, 501);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(24, 108, 220);
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold | FontStyle.Italic);
            label1.ForeColor = Color.White;
            label1.Location = new Point(86, 186);
            label1.Name = "label1";
            label1.Size = new Size(223, 50);
            label1.TabIndex = 1;
            label1.Text = "Sacombank";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(24, 108, 220);
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(122, 236);
            label2.Name = "label2";
            label2.Size = new Size(151, 38);
            label2.TabIndex = 2;
            label2.Text = "Nhân viên";
            // 
            // panelMainContentEmployeeLogin
            // 
            panelMainContentEmployeeLogin.Dock = DockStyle.Right;
            panelMainContentEmployeeLogin.Location = new Point(448, 0);
            panelMainContentEmployeeLogin.Name = "panelMainContentEmployeeLogin";
            panelMainContentEmployeeLogin.Size = new Size(434, 501);
            panelMainContentEmployeeLogin.TabIndex = 4;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.FromArgb(24, 108, 220);
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(142, 287);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(102, 91);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // FormEmployeeLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 501);
            Controls.Add(pictureBox2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(panelMainContentEmployeeLogin);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormEmployeeLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập nhân viên";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Panel panelMainContentEmployeeLogin;
        private PictureBox pictureBox2;
    }
}
