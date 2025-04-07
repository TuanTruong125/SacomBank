namespace QuanLyThongTinKhachHangSacomBank.Views.Common.CustomerLogin
{
    partial class FormCustomerRegister
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCustomerRegister));
            panelMainContentCustomerRegister = new Panel();
            parrotGradientPanel1 = new ReaLTaiizor.Controls.ParrotGradientPanel();
            pictureBox1 = new PictureBox();
            parrotGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panelMainContentCustomerRegister
            // 
            panelMainContentCustomerRegister.BackColor = Color.White;
            panelMainContentCustomerRegister.Dock = DockStyle.Top;
            panelMainContentCustomerRegister.Location = new Point(0, 0);
            panelMainContentCustomerRegister.Name = "panelMainContentCustomerRegister";
            panelMainContentCustomerRegister.Size = new Size(1000, 580);
            panelMainContentCustomerRegister.TabIndex = 0;
            // 
            // parrotGradientPanel1
            // 
            parrotGradientPanel1.BottomLeft = Color.FromArgb(9, 74, 148);
            parrotGradientPanel1.BottomRight = Color.FromArgb(33, 145, 245);
            parrotGradientPanel1.CompositingQualityType = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            parrotGradientPanel1.Controls.Add(pictureBox1);
            parrotGradientPanel1.Dock = DockStyle.Bottom;
            parrotGradientPanel1.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            parrotGradientPanel1.Location = new Point(0, 524);
            parrotGradientPanel1.Name = "parrotGradientPanel1";
            parrotGradientPanel1.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            parrotGradientPanel1.PrimerColor = Color.FromArgb(33, 145, 245);
            parrotGradientPanel1.Size = new Size(1000, 179);
            parrotGradientPanel1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            parrotGradientPanel1.Style = ReaLTaiizor.Controls.ParrotGradientPanel.GradientStyle.Vertical;
            parrotGradientPanel1.TabIndex = 1;
            parrotGradientPanel1.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            parrotGradientPanel1.TopLeft = Color.FromArgb(9, 74, 148);
            parrotGradientPanel1.TopRight = Color.FromArgb(33, 145, 245);
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1, 29);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(999, 150);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // FormCustomerRegister
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 703);
            Controls.Add(panelMainContentCustomerRegister);
            Controls.Add(parrotGradientPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormCustomerRegister";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng ký";
            parrotGradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMainContentCustomerRegister;
        private ReaLTaiizor.Controls.ParrotGradientPanel parrotGradientPanel1;
        private PictureBox pictureBox1;
    }
}