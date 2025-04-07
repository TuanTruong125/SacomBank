namespace QuanLyThongTinKhachHangSacomBank.Views.Common.EmployeeLogin
{
    partial class UC_EmployeeForgotPassword
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
            label3 = new Label();
            panelUC_EmployeeForgotPassword = new Panel();
            labelError = new Label();
            cyberButtonConfirm = new ReaLTaiizor.Controls.CyberButton();
            cyberButtonReturn = new ReaLTaiizor.Controls.CyberButton();
            panel2 = new Panel();
            textBoxEmployeeEmail = new TextBox();
            label2 = new Label();
            panel1 = new Panel();
            textBoxEmployeePhone = new TextBox();
            label1 = new Label();
            panelUC_EmployeeForgotPassword.SuspendLayout();
            SuspendLayout();
            // 
            // label3
            // 
            label3.BackColor = Color.White;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(33, 145, 245);
            label3.Location = new Point(54, 49);
            label3.Name = "label3";
            label3.Size = new Size(327, 62);
            label3.TabIndex = 7;
            label3.Text = "Quên mật khẩu";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelUC_EmployeeForgotPassword
            // 
            panelUC_EmployeeForgotPassword.BackColor = Color.White;
            panelUC_EmployeeForgotPassword.Controls.Add(labelError);
            panelUC_EmployeeForgotPassword.Controls.Add(cyberButtonConfirm);
            panelUC_EmployeeForgotPassword.Controls.Add(cyberButtonReturn);
            panelUC_EmployeeForgotPassword.Controls.Add(label3);
            panelUC_EmployeeForgotPassword.Controls.Add(panel2);
            panelUC_EmployeeForgotPassword.Controls.Add(textBoxEmployeeEmail);
            panelUC_EmployeeForgotPassword.Controls.Add(label2);
            panelUC_EmployeeForgotPassword.Controls.Add(panel1);
            panelUC_EmployeeForgotPassword.Controls.Add(textBoxEmployeePhone);
            panelUC_EmployeeForgotPassword.Controls.Add(label1);
            panelUC_EmployeeForgotPassword.Dock = DockStyle.Fill;
            panelUC_EmployeeForgotPassword.Location = new Point(0, 0);
            panelUC_EmployeeForgotPassword.Name = "panelUC_EmployeeForgotPassword";
            panelUC_EmployeeForgotPassword.Size = new Size(434, 501);
            panelUC_EmployeeForgotPassword.TabIndex = 9;
            // 
            // labelError
            // 
            labelError.BackColor = Color.Transparent;
            labelError.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelError.ForeColor = Color.Red;
            labelError.Location = new Point(3, 344);
            labelError.Name = "labelError";
            labelError.Size = new Size(428, 23);
            labelError.TabIndex = 62;
            labelError.Text = "Vui lòng nhập đầy đủ thông tin!";
            labelError.TextAlign = ContentAlignment.MiddleCenter;
            labelError.Visible = false;
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
            cyberButtonConfirm.Location = new Point(229, 404);
            cyberButtonConfirm.Name = "cyberButtonConfirm";
            cyberButtonConfirm.PenWidth = 15;
            cyberButtonConfirm.Rounding = true;
            cyberButtonConfirm.RoundingInt = 70;
            cyberButtonConfirm.Size = new Size(169, 53);
            cyberButtonConfirm.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberButtonConfirm.TabIndex = 50;
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
            cyberButtonReturn.Location = new Point(39, 404);
            cyberButtonReturn.Name = "cyberButtonReturn";
            cyberButtonReturn.PenWidth = 15;
            cyberButtonReturn.Rounding = true;
            cyberButtonReturn.RoundingInt = 70;
            cyberButtonReturn.Size = new Size(169, 53);
            cyberButtonReturn.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberButtonReturn.TabIndex = 49;
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
            panel2.Location = new Point(54, 297);
            panel2.Name = "panel2";
            panel2.Size = new Size(312, 2);
            panel2.TabIndex = 26;
            // 
            // textBoxEmployeeEmail
            // 
            textBoxEmployeeEmail.BorderStyle = BorderStyle.None;
            textBoxEmployeeEmail.Font = new Font("Segoe UI", 12F);
            textBoxEmployeeEmail.Location = new Point(54, 267);
            textBoxEmployeeEmail.Name = "textBoxEmployeeEmail";
            textBoxEmployeeEmail.Size = new Size(312, 27);
            textBoxEmployeeEmail.TabIndex = 25;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(54, 236);
            label2.Name = "label2";
            label2.Size = new Size(64, 28);
            label2.TabIndex = 24;
            label2.Text = "Email";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.HotTrack;
            panel1.Location = new Point(54, 189);
            panel1.Name = "panel1";
            panel1.Size = new Size(312, 2);
            panel1.TabIndex = 23;
            // 
            // textBoxEmployeePhone
            // 
            textBoxEmployeePhone.BorderStyle = BorderStyle.None;
            textBoxEmployeePhone.Font = new Font("Segoe UI", 12F);
            textBoxEmployeePhone.Location = new Point(54, 159);
            textBoxEmployeePhone.Name = "textBoxEmployeePhone";
            textBoxEmployeePhone.Size = new Size(312, 27);
            textBoxEmployeePhone.TabIndex = 22;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(54, 128);
            label1.Name = "label1";
            label1.Size = new Size(138, 28);
            label1.TabIndex = 21;
            label1.Text = "Số điện thoại";
            // 
            // UC_EmployeeForgotPassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panelUC_EmployeeForgotPassword);
            Name = "UC_EmployeeForgotPassword";
            Size = new Size(434, 501);
            panelUC_EmployeeForgotPassword.ResumeLayout(false);
            panelUC_EmployeeForgotPassword.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label3;
        private Panel panelUC_EmployeeForgotPassword;
        private Label labelError;
        private ReaLTaiizor.Controls.CyberButton cyberButtonConfirm;
        private ReaLTaiizor.Controls.CyberButton cyberButtonReturn;
        private Panel panel2;
        private TextBox textBoxEmployeeEmail;
        private Label label2;
        private Panel panel1;
        private TextBox textBoxEmployeePhone;
        private Label label1;
    }
}
