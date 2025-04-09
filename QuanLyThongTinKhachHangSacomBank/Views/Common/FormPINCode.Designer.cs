namespace QuanLyThongTinKhachHangSacomBank.Views.Common
{
    partial class FormPINCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPINCode));
            pictureBox1 = new PictureBox();
            cyberButtonVerifyPINCode = new ReaLTaiizor.Controls.CyberButton();
            pictureBoxStar = new PictureBox();
            labelErrorOTP = new Label();
            pictureBoxLeft = new PictureBox();
            pictureBoxRight = new PictureBox();
            labelOTP = new Label();
            pictureBoxLogo = new PictureBox();
            pictureBoxTopPanel = new PictureBox();
            textBoxPINCode1 = new TextBox();
            textBoxPINCode2 = new TextBox();
            textBoxPINCode3 = new TextBox();
            textBoxPINCode5 = new TextBox();
            textBoxPINCode4 = new TextBox();
            textBoxPINCode6 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxStar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLeft).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTopPanel).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(149, 90);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(108, 102);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 49;
            pictureBox1.TabStop = false;
            // 
            // cyberButtonVerifyPINCode
            // 
            cyberButtonVerifyPINCode.Alpha = 20;
            cyberButtonVerifyPINCode.BackColor = Color.Transparent;
            cyberButtonVerifyPINCode.Background = true;
            cyberButtonVerifyPINCode.Background_WidthPen = 4F;
            cyberButtonVerifyPINCode.BackgroundPen = true;
            cyberButtonVerifyPINCode.ColorBackground = Color.FromArgb(37, 52, 68);
            cyberButtonVerifyPINCode.ColorBackground_1 = SystemColors.HotTrack;
            cyberButtonVerifyPINCode.ColorBackground_2 = Color.DeepSkyBlue;
            cyberButtonVerifyPINCode.ColorBackground_Pen = Color.FromArgb(29, 200, 238);
            cyberButtonVerifyPINCode.ColorLighting = Color.FromArgb(29, 200, 238);
            cyberButtonVerifyPINCode.ColorPen_1 = SystemColors.HotTrack;
            cyberButtonVerifyPINCode.ColorPen_2 = Color.DeepSkyBlue;
            cyberButtonVerifyPINCode.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            cyberButtonVerifyPINCode.Effect_1 = true;
            cyberButtonVerifyPINCode.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            cyberButtonVerifyPINCode.Effect_1_Transparency = 25;
            cyberButtonVerifyPINCode.Effect_2 = true;
            cyberButtonVerifyPINCode.Effect_2_ColorBackground = Color.White;
            cyberButtonVerifyPINCode.Effect_2_Transparency = 20;
            cyberButtonVerifyPINCode.Font = new Font("Roboto SemiCondensed Medium", 12F, FontStyle.Bold);
            cyberButtonVerifyPINCode.ForeColor = Color.FromArgb(245, 245, 245);
            cyberButtonVerifyPINCode.Lighting = false;
            cyberButtonVerifyPINCode.LinearGradient_Background = true;
            cyberButtonVerifyPINCode.LinearGradientPen = true;
            cyberButtonVerifyPINCode.Location = new Point(300, 374);
            cyberButtonVerifyPINCode.Name = "cyberButtonVerifyPINCode";
            cyberButtonVerifyPINCode.PenWidth = 15;
            cyberButtonVerifyPINCode.Rounding = true;
            cyberButtonVerifyPINCode.RoundingInt = 70;
            cyberButtonVerifyPINCode.Size = new Size(187, 56);
            cyberButtonVerifyPINCode.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberButtonVerifyPINCode.TabIndex = 47;
            cyberButtonVerifyPINCode.Tag = "Cyber";
            cyberButtonVerifyPINCode.TextButton = "Xác thực";
            cyberButtonVerifyPINCode.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            cyberButtonVerifyPINCode.Timer_Effect_1 = 5;
            cyberButtonVerifyPINCode.Timer_RGB = 300;
            cyberButtonVerifyPINCode.Click += cyberButtonVerifyPINCode_Click;
            // 
            // pictureBoxStar
            // 
            pictureBoxStar.Image = (Image)resources.GetObject("pictureBoxStar.Image");
            pictureBoxStar.Location = new Point(488, 150);
            pictureBoxStar.Name = "pictureBoxStar";
            pictureBoxStar.Size = new Size(60, 60);
            pictureBoxStar.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxStar.TabIndex = 44;
            pictureBoxStar.TabStop = false;
            // 
            // labelErrorOTP
            // 
            labelErrorOTP.AutoSize = true;
            labelErrorOTP.Font = new Font("Roboto SemiCondensed Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelErrorOTP.ForeColor = Color.Red;
            labelErrorOTP.Location = new Point(300, 330);
            labelErrorOTP.Name = "labelErrorOTP";
            labelErrorOTP.Size = new Size(199, 24);
            labelErrorOTP.TabIndex = 43;
            labelErrorOTP.Text = "Mã PIN không đúng!";
            labelErrorOTP.Visible = false;
            // 
            // pictureBoxLeft
            // 
            pictureBoxLeft.Image = (Image)resources.GetObject("pictureBoxLeft.Image");
            pictureBoxLeft.Location = new Point(-1, 216);
            pictureBoxLeft.Name = "pictureBoxLeft";
            pictureBoxLeft.Size = new Size(559, 240);
            pictureBoxLeft.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxLeft.TabIndex = 42;
            pictureBoxLeft.TabStop = false;
            // 
            // pictureBoxRight
            // 
            pictureBoxRight.Image = (Image)resources.GetObject("pictureBoxRight.Image");
            pictureBoxRight.Location = new Point(608, 303);
            pictureBoxRight.Name = "pictureBoxRight";
            pictureBoxRight.Size = new Size(175, 153);
            pictureBoxRight.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxRight.TabIndex = 41;
            pictureBoxRight.TabStop = false;
            // 
            // labelOTP
            // 
            labelOTP.AutoSize = true;
            labelOTP.Font = new Font("Roboto SemiCondensed", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelOTP.Location = new Point(283, 187);
            labelOTP.Name = "labelOTP";
            labelOTP.Size = new Size(206, 41);
            labelOTP.TabIndex = 30;
            labelOTP.Text = "Nhập mã PIN";
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Image = (Image)resources.GetObject("pictureBoxLogo.Image");
            pictureBoxLogo.Location = new Point(346, 90);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(93, 88);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxLogo.TabIndex = 29;
            pictureBoxLogo.TabStop = false;
            // 
            // pictureBoxTopPanel
            // 
            pictureBoxTopPanel.Image = (Image)resources.GetObject("pictureBoxTopPanel.Image");
            pictureBoxTopPanel.Location = new Point(-1, -1);
            pictureBoxTopPanel.Name = "pictureBoxTopPanel";
            pictureBoxTopPanel.Size = new Size(784, 78);
            pictureBoxTopPanel.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxTopPanel.TabIndex = 28;
            pictureBoxTopPanel.TabStop = false;
            // 
            // textBoxPINCode1
            // 
            textBoxPINCode1.Font = new Font("Roboto SemiCondensed Medium", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxPINCode1.Location = new Point(168, 240);
            textBoxPINCode1.Name = "textBoxPINCode1";
            textBoxPINCode1.Size = new Size(68, 68);
            textBoxPINCode1.TabIndex = 0;
            // 
            // textBoxPINCode2
            // 
            textBoxPINCode2.Font = new Font("Roboto SemiCondensed Medium", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxPINCode2.Location = new Point(242, 240);
            textBoxPINCode2.Name = "textBoxPINCode2";
            textBoxPINCode2.Size = new Size(68, 68);
            textBoxPINCode2.TabIndex = 51;
            // 
            // textBoxPINCode3
            // 
            textBoxPINCode3.Font = new Font("Roboto SemiCondensed Medium", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxPINCode3.Location = new Point(316, 240);
            textBoxPINCode3.Name = "textBoxPINCode3";
            textBoxPINCode3.Size = new Size(68, 68);
            textBoxPINCode3.TabIndex = 52;
            // 
            // textBoxPINCode5
            // 
            textBoxPINCode5.Font = new Font("Roboto SemiCondensed Medium", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxPINCode5.Location = new Point(464, 240);
            textBoxPINCode5.Name = "textBoxPINCode5";
            textBoxPINCode5.Size = new Size(68, 68);
            textBoxPINCode5.TabIndex = 53;
            // 
            // textBoxPINCode4
            // 
            textBoxPINCode4.Font = new Font("Roboto SemiCondensed Medium", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxPINCode4.Location = new Point(390, 240);
            textBoxPINCode4.Name = "textBoxPINCode4";
            textBoxPINCode4.Size = new Size(68, 68);
            textBoxPINCode4.TabIndex = 54;
            // 
            // textBoxPINCode6
            // 
            textBoxPINCode6.Font = new Font("Roboto SemiCondensed Medium", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxPINCode6.Location = new Point(538, 240);
            textBoxPINCode6.Name = "textBoxPINCode6";
            textBoxPINCode6.Size = new Size(68, 68);
            textBoxPINCode6.TabIndex = 55;
            // 
            // FormPINCode
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 451);
            Controls.Add(textBoxPINCode6);
            Controls.Add(textBoxPINCode4);
            Controls.Add(textBoxPINCode5);
            Controls.Add(textBoxPINCode3);
            Controls.Add(textBoxPINCode2);
            Controls.Add(textBoxPINCode1);
            Controls.Add(pictureBox1);
            Controls.Add(cyberButtonVerifyPINCode);
            Controls.Add(pictureBoxStar);
            Controls.Add(labelErrorOTP);
            Controls.Add(pictureBoxRight);
            Controls.Add(labelOTP);
            Controls.Add(pictureBoxLogo);
            Controls.Add(pictureBoxTopPanel);
            Controls.Add(pictureBoxLeft);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormPINCode";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Xác thực mã PIN";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxStar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLeft).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRight).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTopPanel).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private ReaLTaiizor.Controls.CyberButton cyberButtonVerifyPINCode;
        private PictureBox pictureBoxStar;
        private Label labelErrorOTP;
        private PictureBox pictureBoxLeft;
        private PictureBox pictureBoxRight;
        private Label labelOTP;
        private PictureBox pictureBoxLogo;
        private PictureBox pictureBoxTopPanel;
        private TextBox textBoxPINCode1;
        private TextBox textBoxPINCode2;
        private TextBox textBoxPINCode3;
        private TextBox textBoxPINCode5;
        private TextBox textBoxPINCode4;
        private TextBox textBoxPINCode6;
    }
}