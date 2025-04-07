namespace QuanLyThongTinKhachHangSacomBank.Views.Common.EmployeeLogin
{
    partial class UC_EmployeeLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_EmployeeLogin));
            textBoxEmployeeUsername = new TextBox();
            label3 = new Label();
            label1 = new Label();
            label2 = new Label();
            panel2 = new Panel();
            panel1 = new Panel();
            textBoxEmployeePassword = new TextBox();
            label4 = new Label();
            label5 = new Label();
            linkLabelForgotPasswordEmployee = new LinkLabel();
            panelUC_EmployeeLogin = new Panel();
            labelError = new Label();
            buttonShowPassword = new Button();
            cyberButtonLoginEmployee = new ReaLTaiizor.Controls.CyberButton();
            pictureBox2 = new PictureBox();
            panelUC_EmployeeLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // textBoxEmployeeUsername
            // 
            textBoxEmployeeUsername.BorderStyle = BorderStyle.None;
            textBoxEmployeeUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxEmployeeUsername.Location = new Point(46, 164);
            textBoxEmployeeUsername.Name = "textBoxEmployeeUsername";
            textBoxEmployeeUsername.Size = new Size(312, 27);
            textBoxEmployeeUsername.TabIndex = 15;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(33, 145, 245);
            label3.Location = new Point(116, 33);
            label3.Name = "label3";
            label3.Size = new Size(197, 48);
            label3.TabIndex = 22;
            label3.Text = "Đăng nhập";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(42, 232);
            label1.Name = "label1";
            label1.Size = new Size(102, 28);
            label1.TabIndex = 6;
            label1.Text = "Mật khẩu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 273);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 23;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.HotTrack;
            panel2.Location = new Point(46, 194);
            panel2.Name = "panel2";
            panel2.Size = new Size(312, 2);
            panel2.TabIndex = 16;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.HotTrack;
            panel1.Location = new Point(46, 293);
            panel1.Name = "panel1";
            panel1.Size = new Size(312, 2);
            panel1.TabIndex = 11;
            // 
            // textBoxEmployeePassword
            // 
            textBoxEmployeePassword.BorderStyle = BorderStyle.None;
            textBoxEmployeePassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxEmployeePassword.Location = new Point(46, 263);
            textBoxEmployeePassword.Name = "textBoxEmployeePassword";
            textBoxEmployeePassword.PasswordChar = '●';
            textBoxEmployeePassword.Size = new Size(312, 27);
            textBoxEmployeePassword.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(51, 212);
            label4.Name = "label4";
            label4.Size = new Size(0, 20);
            label4.TabIndex = 25;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(42, 133);
            label5.Name = "label5";
            label5.Size = new Size(106, 28);
            label5.TabIndex = 24;
            label5.Text = "Username";
            // 
            // linkLabelForgotPasswordEmployee
            // 
            linkLabelForgotPasswordEmployee.AutoSize = true;
            linkLabelForgotPasswordEmployee.BackColor = Color.Transparent;
            linkLabelForgotPasswordEmployee.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            linkLabelForgotPasswordEmployee.LinkColor = Color.FromArgb(33, 145, 245);
            linkLabelForgotPasswordEmployee.Location = new Point(195, 341);
            linkLabelForgotPasswordEmployee.Name = "linkLabelForgotPasswordEmployee";
            linkLabelForgotPasswordEmployee.Size = new Size(163, 28);
            linkLabelForgotPasswordEmployee.TabIndex = 17;
            linkLabelForgotPasswordEmployee.TabStop = true;
            linkLabelForgotPasswordEmployee.Text = "Quên mật khẩu?";
            linkLabelForgotPasswordEmployee.LinkClicked += linkLabelForgotPasswordEmployee_LinkClicked;
            // 
            // panelUC_EmployeeLogin
            // 
            panelUC_EmployeeLogin.Controls.Add(labelError);
            panelUC_EmployeeLogin.Controls.Add(buttonShowPassword);
            panelUC_EmployeeLogin.Controls.Add(cyberButtonLoginEmployee);
            panelUC_EmployeeLogin.Controls.Add(textBoxEmployeeUsername);
            panelUC_EmployeeLogin.Controls.Add(panel2);
            panelUC_EmployeeLogin.Controls.Add(linkLabelForgotPasswordEmployee);
            panelUC_EmployeeLogin.Controls.Add(panel1);
            panelUC_EmployeeLogin.Controls.Add(label1);
            panelUC_EmployeeLogin.Controls.Add(textBoxEmployeePassword);
            panelUC_EmployeeLogin.Controls.Add(pictureBox2);
            panelUC_EmployeeLogin.Dock = DockStyle.Fill;
            panelUC_EmployeeLogin.Location = new Point(0, 0);
            panelUC_EmployeeLogin.Name = "panelUC_EmployeeLogin";
            panelUC_EmployeeLogin.Size = new Size(434, 501);
            panelUC_EmployeeLogin.TabIndex = 26;
            // 
            // labelError
            // 
            labelError.BackColor = Color.Transparent;
            labelError.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelError.ForeColor = Color.Red;
            labelError.Location = new Point(3, 313);
            labelError.Name = "labelError";
            labelError.Size = new Size(437, 23);
            labelError.TabIndex = 61;
            labelError.Text = "Vui lòng nhập đầy đủ thông tin!";
            labelError.TextAlign = ContentAlignment.MiddleCenter;
            labelError.Visible = false;
            // 
            // buttonShowPassword
            // 
            buttonShowPassword.Image = (Image)resources.GetObject("buttonShowPassword.Image");
            buttonShowPassword.Location = new Point(364, 260);
            buttonShowPassword.Name = "buttonShowPassword";
            buttonShowPassword.Size = new Size(40, 40);
            buttonShowPassword.TabIndex = 60;
            buttonShowPassword.UseVisualStyleBackColor = true;
            buttonShowPassword.Click += buttonShowPassword_Click;
            // 
            // cyberButtonLoginEmployee
            // 
            cyberButtonLoginEmployee.Alpha = 20;
            cyberButtonLoginEmployee.BackColor = Color.Transparent;
            cyberButtonLoginEmployee.Background = true;
            cyberButtonLoginEmployee.Background_WidthPen = 4F;
            cyberButtonLoginEmployee.BackgroundPen = true;
            cyberButtonLoginEmployee.ColorBackground = Color.FromArgb(37, 52, 68);
            cyberButtonLoginEmployee.ColorBackground_1 = SystemColors.HotTrack;
            cyberButtonLoginEmployee.ColorBackground_2 = Color.DeepSkyBlue;
            cyberButtonLoginEmployee.ColorBackground_Pen = Color.FromArgb(29, 200, 238);
            cyberButtonLoginEmployee.ColorLighting = Color.FromArgb(29, 200, 238);
            cyberButtonLoginEmployee.ColorPen_1 = SystemColors.HotTrack;
            cyberButtonLoginEmployee.ColorPen_2 = Color.DeepSkyBlue;
            cyberButtonLoginEmployee.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            cyberButtonLoginEmployee.Effect_1 = true;
            cyberButtonLoginEmployee.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            cyberButtonLoginEmployee.Effect_1_Transparency = 25;
            cyberButtonLoginEmployee.Effect_2 = true;
            cyberButtonLoginEmployee.Effect_2_ColorBackground = Color.White;
            cyberButtonLoginEmployee.Effect_2_Transparency = 20;
            cyberButtonLoginEmployee.Font = new Font("Roboto SemiCondensed Medium", 12F, FontStyle.Bold);
            cyberButtonLoginEmployee.ForeColor = Color.FromArgb(245, 245, 245);
            cyberButtonLoginEmployee.Lighting = false;
            cyberButtonLoginEmployee.LinearGradient_Background = true;
            cyberButtonLoginEmployee.LinearGradientPen = true;
            cyberButtonLoginEmployee.Location = new Point(133, 394);
            cyberButtonLoginEmployee.Name = "cyberButtonLoginEmployee";
            cyberButtonLoginEmployee.PenWidth = 15;
            cyberButtonLoginEmployee.Rounding = true;
            cyberButtonLoginEmployee.RoundingInt = 70;
            cyberButtonLoginEmployee.Size = new Size(169, 53);
            cyberButtonLoginEmployee.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberButtonLoginEmployee.TabIndex = 48;
            cyberButtonLoginEmployee.Tag = "Cyber";
            cyberButtonLoginEmployee.TextButton = "Đăng nhập";
            cyberButtonLoginEmployee.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            cyberButtonLoginEmployee.Timer_Effect_1 = 5;
            cyberButtonLoginEmployee.Timer_RGB = 300;
            cyberButtonLoginEmployee.Click += cyberButtonLoginEmployee_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(277, 344);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(157, 157);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 62;
            pictureBox2.TabStop = false;
            // 
            // UC_EmployeeLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(panelUC_EmployeeLogin);
            Name = "UC_EmployeeLogin";
            Size = new Size(434, 501);
            panelUC_EmployeeLogin.ResumeLayout(false);
            panelUC_EmployeeLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxEmployeeUsername;
        private Label label3;
        private Label label1;
        private Label label2;
        private Panel panel2;
        private Panel panel1;
        private TextBox textBoxEmployeePassword;
        private Label label4;
        private Label label5;
        private LinkLabel linkLabelSignUpCustomer;
        private Label label6;
        private LinkLabel linkLabelForgotPasswordEmployee;
        private Panel panelUC_EmployeeLogin;
        private Label labelError;
        private Button buttonShowPassword;
        private ReaLTaiizor.Controls.CyberButton cyberButtonLoginEmployee;
        private PictureBox pictureBox2;
    }
}
