namespace QuanLyThongTinKhachHangSacomBank.Views.Common.CustomerLogin
{
    partial class FormCustomerLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCustomerLogin));
            parrotGradientPanel1 = new ReaLTaiizor.Controls.ParrotGradientPanel();
            label2 = new Label();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panelMainContentCustomerLogin = new Panel();
            parrotGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // parrotGradientPanel1
            // 
            parrotGradientPanel1.BottomLeft = Color.FromArgb(9, 74, 148);
            parrotGradientPanel1.BottomRight = Color.FromArgb(33, 145, 245);
            parrotGradientPanel1.CompositingQualityType = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            parrotGradientPanel1.Controls.Add(label2);
            parrotGradientPanel1.Controls.Add(label1);
            parrotGradientPanel1.Controls.Add(pictureBox2);
            parrotGradientPanel1.Controls.Add(pictureBox1);
            parrotGradientPanel1.Dock = DockStyle.Left;
            parrotGradientPanel1.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            parrotGradientPanel1.Location = new Point(0, 0);
            parrotGradientPanel1.Name = "parrotGradientPanel1";
            parrotGradientPanel1.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            parrotGradientPanel1.PrimerColor = Color.FromArgb(33, 145, 245);
            parrotGradientPanel1.Size = new Size(456, 501);
            parrotGradientPanel1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            parrotGradientPanel1.Style = ReaLTaiizor.Controls.ParrotGradientPanel.GradientStyle.Horizontal;
            parrotGradientPanel1.TabIndex = 0;
            parrotGradientPanel1.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            parrotGradientPanel1.TopLeft = Color.FromArgb(9, 74, 148);
            parrotGradientPanel1.TopRight = Color.FromArgb(33, 145, 245);
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(60, 57);
            label2.Name = "label2";
            label2.Size = new Size(278, 34);
            label2.TabIndex = 3;
            label2.Text = "Xin chào quý khách!";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold | FontStyle.Italic);
            label1.ForeColor = Color.White;
            label1.Location = new Point(82, 279);
            label1.Name = "label1";
            label1.Size = new Size(234, 48);
            label1.TabIndex = 2;
            label1.Text = "Sacombank";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(136, 167);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(111, 100);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(356, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 501);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panelMainContentCustomerLogin
            // 
            panelMainContentCustomerLogin.Dock = DockStyle.Right;
            panelMainContentCustomerLogin.Location = new Point(439, 0);
            panelMainContentCustomerLogin.Name = "panelMainContentCustomerLogin";
            panelMainContentCustomerLogin.Size = new Size(443, 501);
            panelMainContentCustomerLogin.TabIndex = 1;
            // 
            // FormCustomerLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(882, 501);
            Controls.Add(parrotGradientPanel1);
            Controls.Add(panelMainContentCustomerLogin);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormCustomerLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            parrotGradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.ParrotGradientPanel parrotGradientPanel1;
        private PictureBox pictureBox1;
        private Panel panelMainContentCustomerLogin;
        private PictureBox pictureBox2;
        private Label label1;
        private Label label2;
    }
}
