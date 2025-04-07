namespace QuanLyThongTinKhachHangSacomBank.Views.Common.EmployeeLogin
{
    partial class UC_EmployeeChangePassword
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_EmployeeChangePassword));
            labelError = new Label();
            buttonShowConfirmNewPassword = new Button();
            buttonShowNewPassword = new Button();
            cyberButtonConfirm = new ReaLTaiizor.Controls.CyberButton();
            cyberButtonReturn = new ReaLTaiizor.Controls.CyberButton();
            panel2 = new Panel();
            textBoxConfirmNewPassword = new TextBox();
            label2 = new Label();
            panel1 = new Panel();
            textBoxNewPassword = new TextBox();
            label1 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // labelError
            // 
            labelError.BackColor = Color.Transparent;
            labelError.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelError.ForeColor = Color.Red;
            labelError.Location = new Point(3, 351);
            labelError.Name = "labelError";
            labelError.Size = new Size(428, 23);
            labelError.TabIndex = 74;
            labelError.Text = "Vui lòng nhập đầy đủ thông tin!";
            labelError.TextAlign = ContentAlignment.MiddleCenter;
            labelError.Visible = false;
            // 
            // buttonShowConfirmNewPassword
            // 
            buttonShowConfirmNewPassword.Image = (Image)resources.GetObject("buttonShowConfirmNewPassword.Image");
            buttonShowConfirmNewPassword.Location = new Point(364, 271);
            buttonShowConfirmNewPassword.Name = "buttonShowConfirmNewPassword";
            buttonShowConfirmNewPassword.Size = new Size(40, 40);
            buttonShowConfirmNewPassword.TabIndex = 73;
            buttonShowConfirmNewPassword.UseVisualStyleBackColor = true;
            buttonShowConfirmNewPassword.Click += buttonShowConfirmNewPassword_Click;
            // 
            // buttonShowNewPassword
            // 
            buttonShowNewPassword.Image = (Image)resources.GetObject("buttonShowNewPassword.Image");
            buttonShowNewPassword.Location = new Point(364, 164);
            buttonShowNewPassword.Name = "buttonShowNewPassword";
            buttonShowNewPassword.Size = new Size(40, 40);
            buttonShowNewPassword.TabIndex = 72;
            buttonShowNewPassword.UseVisualStyleBackColor = true;
            buttonShowNewPassword.Click += buttonShowNewPassword_Click;
            // 
            // cyberButtonConfirm
            // 
            cyberButtonConfirm.Alpha = 20;
            cyberButtonConfirm.BackColor = Color.Transparent;
            cyberButtonConfirm.Background = true;
            cyberButtonConfirm.Background_WidthPen = 4F;
            cyberButtonConfirm.BackgroundPen = true;
            cyberButtonConfirm.ColorBackground = Color.FromArgb(37, 52, 68);
            cyberButtonConfirm.ColorBackground_1 = Color.Teal;
            cyberButtonConfirm.ColorBackground_2 = Color.Turquoise;
            cyberButtonConfirm.ColorBackground_Pen = Color.FromArgb(29, 200, 238);
            cyberButtonConfirm.ColorLighting = Color.FromArgb(29, 200, 238);
            cyberButtonConfirm.ColorPen_1 = Color.Teal;
            cyberButtonConfirm.ColorPen_2 = Color.Turquoise;
            cyberButtonConfirm.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            cyberButtonConfirm.Effect_1 = true;
            cyberButtonConfirm.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            cyberButtonConfirm.Effect_1_Transparency = 25;
            cyberButtonConfirm.Effect_2 = true;
            cyberButtonConfirm.Effect_2_ColorBackground = Color.White;
            cyberButtonConfirm.Effect_2_Transparency = 20;
            cyberButtonConfirm.Font = new Font("Roboto SemiCondensed Medium", 12F, FontStyle.Bold);
            cyberButtonConfirm.ForeColor = Color.FromArgb(245, 245, 245);
            cyberButtonConfirm.Lighting = false;
            cyberButtonConfirm.LinearGradient_Background = true;
            cyberButtonConfirm.LinearGradientPen = true;
            cyberButtonConfirm.Location = new Point(221, 412);
            cyberButtonConfirm.Name = "cyberButtonConfirm";
            cyberButtonConfirm.PenWidth = 15;
            cyberButtonConfirm.Rounding = true;
            cyberButtonConfirm.RoundingInt = 70;
            cyberButtonConfirm.Size = new Size(169, 53);
            cyberButtonConfirm.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberButtonConfirm.TabIndex = 71;
            cyberButtonConfirm.Tag = "Cyber";
            cyberButtonConfirm.TextButton = "Xác nhận";
            cyberButtonConfirm.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            cyberButtonConfirm.Timer_Effect_1 = 5;
            cyberButtonConfirm.Timer_RGB = 300;
            cyberButtonConfirm.Click += cyberButtonConfirm_Click;
            // 
            // cyberButtonReturn
            // 
            cyberButtonReturn.Alpha = 20;
            cyberButtonReturn.BackColor = Color.Transparent;
            cyberButtonReturn.Background = true;
            cyberButtonReturn.Background_WidthPen = 4F;
            cyberButtonReturn.BackgroundPen = true;
            cyberButtonReturn.ColorBackground = Color.FromArgb(37, 52, 68);
            cyberButtonReturn.ColorBackground_1 = SystemColors.HotTrack;
            cyberButtonReturn.ColorBackground_2 = Color.DeepSkyBlue;
            cyberButtonReturn.ColorBackground_Pen = Color.FromArgb(29, 200, 238);
            cyberButtonReturn.ColorLighting = Color.FromArgb(29, 200, 238);
            cyberButtonReturn.ColorPen_1 = SystemColors.HotTrack;
            cyberButtonReturn.ColorPen_2 = Color.DeepSkyBlue;
            cyberButtonReturn.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            cyberButtonReturn.Effect_1 = true;
            cyberButtonReturn.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            cyberButtonReturn.Effect_1_Transparency = 25;
            cyberButtonReturn.Effect_2 = true;
            cyberButtonReturn.Effect_2_ColorBackground = Color.White;
            cyberButtonReturn.Effect_2_Transparency = 20;
            cyberButtonReturn.Font = new Font("Roboto SemiCondensed Medium", 12F, FontStyle.Bold);
            cyberButtonReturn.ForeColor = Color.FromArgb(245, 245, 245);
            cyberButtonReturn.Lighting = false;
            cyberButtonReturn.LinearGradient_Background = true;
            cyberButtonReturn.LinearGradientPen = true;
            cyberButtonReturn.Location = new Point(31, 412);
            cyberButtonReturn.Name = "cyberButtonReturn";
            cyberButtonReturn.PenWidth = 15;
            cyberButtonReturn.Rounding = true;
            cyberButtonReturn.RoundingInt = 70;
            cyberButtonReturn.Size = new Size(169, 53);
            cyberButtonReturn.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberButtonReturn.TabIndex = 70;
            cyberButtonReturn.Tag = "Cyber";
            cyberButtonReturn.TextButton = "Trở về";
            cyberButtonReturn.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            cyberButtonReturn.Timer_Effect_1 = 5;
            cyberButtonReturn.Timer_RGB = 300;
            cyberButtonReturn.Click += cyberButtonReturn_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.HotTrack;
            panel2.Location = new Point(46, 305);
            panel2.Name = "panel2";
            panel2.Size = new Size(312, 2);
            panel2.TabIndex = 69;
            // 
            // textBoxConfirmNewPassword
            // 
            textBoxConfirmNewPassword.BorderStyle = BorderStyle.None;
            textBoxConfirmNewPassword.Font = new Font("Segoe UI", 12F);
            textBoxConfirmNewPassword.Location = new Point(46, 275);
            textBoxConfirmNewPassword.Name = "textBoxConfirmNewPassword";
            textBoxConfirmNewPassword.Size = new Size(312, 27);
            textBoxConfirmNewPassword.TabIndex = 68;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(46, 244);
            label2.Name = "label2";
            label2.Size = new Size(230, 28);
            label2.TabIndex = 67;
            label2.Text = "Nhập lại mật khẩu mới";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.HotTrack;
            panel1.Location = new Point(46, 197);
            panel1.Name = "panel1";
            panel1.Size = new Size(312, 2);
            panel1.TabIndex = 66;
            // 
            // textBoxNewPassword
            // 
            textBoxNewPassword.BorderStyle = BorderStyle.None;
            textBoxNewPassword.Font = new Font("Segoe UI", 12F);
            textBoxNewPassword.Location = new Point(46, 167);
            textBoxNewPassword.Name = "textBoxNewPassword";
            textBoxNewPassword.Size = new Size(312, 27);
            textBoxNewPassword.TabIndex = 65;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(46, 136);
            label1.Name = "label1";
            label1.Size = new Size(145, 28);
            label1.TabIndex = 64;
            label1.Text = "Mật khẩu mới";
            // 
            // label3
            // 
            label3.BackColor = Color.White;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(33, 145, 245);
            label3.Location = new Point(36, 35);
            label3.Name = "label3";
            label3.Size = new Size(357, 62);
            label3.TabIndex = 63;
            label3.Text = "Thay đổi mật khẩu";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UC_EmployeeChangePassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(labelError);
            Controls.Add(buttonShowConfirmNewPassword);
            Controls.Add(buttonShowNewPassword);
            Controls.Add(cyberButtonConfirm);
            Controls.Add(cyberButtonReturn);
            Controls.Add(panel2);
            Controls.Add(textBoxConfirmNewPassword);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(textBoxNewPassword);
            Controls.Add(label1);
            Controls.Add(label3);
            Name = "UC_EmployeeChangePassword";
            Size = new Size(434, 501);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelError;
        private Button buttonShowConfirmNewPassword;
        private Button buttonShowNewPassword;
        private ReaLTaiizor.Controls.CyberButton cyberButtonConfirm;
        private ReaLTaiizor.Controls.CyberButton cyberButtonReturn;
        private Panel panel2;
        private TextBox textBoxConfirmNewPassword;
        private Label label2;
        private Panel panel1;
        private TextBox textBoxNewPassword;
        private Label label1;
        private Label label3;
    }
}
