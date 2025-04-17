namespace QuanLyThongTinKhachHangSacomBank.Views.Customer
{
    partial class FormLoanApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLoanApplication));
            pictureBoxTopPanel = new PictureBox();
            textBoxServiceDescription = new TextBox();
            panel1 = new Panel();
            labelDescription = new Label();
            labelDuration = new Label();
            labelPay = new Label();
            textBoxAccountID = new TextBox();
            comboBoxDuration = new ComboBox();
            labelPayInfo = new Label();
            textBoxTotalPrincipalAmount = new TextBox();
            labelAccountID = new Label();
            textBoxPhone = new TextBox();
            labelAmount = new Label();
            labelPhone = new Label();
            textBoxCitizenID = new TextBox();
            labelInterestRate = new Label();
            labelCitizenID = new Label();
            labelServiceID = new Label();
            textBoxServiceID = new TextBox();
            labelError = new Label();
            labelCustomer = new Label();
            textBoxAccountName = new TextBox();
            label1 = new Label();
            comboBoxServiceTypeName = new ComboBox();
            labelCreatedDate = new Label();
            dateTimePickerCreatedDate = new DateTimePicker();
            cyberButtonCancel = new ReaLTaiizor.Controls.CyberButton();
            textBoxInterestRate = new TextBox();
            cyberButtonSendRequest = new ReaLTaiizor.Controls.CyberButton();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTopPanel).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxTopPanel
            // 
            pictureBoxTopPanel.Image = (Image)resources.GetObject("pictureBoxTopPanel.Image");
            pictureBoxTopPanel.Location = new Point(-4, -4);
            pictureBoxTopPanel.Name = "pictureBoxTopPanel";
            pictureBoxTopPanel.Size = new Size(1025, 78);
            pictureBoxTopPanel.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxTopPanel.TabIndex = 40;
            pictureBoxTopPanel.TabStop = false;
            // 
            // textBoxServiceDescription
            // 
            textBoxServiceDescription.Font = new Font("Roboto", 12F);
            textBoxServiceDescription.Location = new Point(325, 483);
            textBoxServiceDescription.Name = "textBoxServiceDescription";
            textBoxServiceDescription.Size = new Size(464, 32);
            textBoxServiceDescription.TabIndex = 169;
            // 
            // panel1
            // 
            panel1.BackColor = Color.MediumSeaGreen;
            panel1.Location = new Point(226, 421);
            panel1.Name = "panel1";
            panel1.Size = new Size(580, 5);
            panel1.TabIndex = 144;
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDescription.Location = new Point(231, 489);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(88, 24);
            labelDescription.TabIndex = 168;
            labelDescription.Text = "Nội dung";
            // 
            // labelDuration
            // 
            labelDuration.AutoSize = true;
            labelDuration.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDuration.Location = new Point(560, 298);
            labelDuration.Name = "labelDuration";
            labelDuration.Size = new Size(64, 24);
            labelDuration.TabIndex = 167;
            labelDuration.Text = "Kì hạn";
            // 
            // labelPay
            // 
            labelPay.Font = new Font("Roboto SemiCondensed", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPay.ForeColor = Color.MediumSeaGreen;
            labelPay.Location = new Point(12, 74);
            labelPay.Name = "labelPay";
            labelPay.Size = new Size(998, 41);
            labelPay.TabIndex = 145;
            labelPay.Text = "Đăng ký vay vốn";
            labelPay.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxAccountID
            // 
            textBoxAccountID.Font = new Font("Roboto", 12F);
            textBoxAccountID.Location = new Point(210, 213);
            textBoxAccountID.Name = "textBoxAccountID";
            textBoxAccountID.Size = new Size(344, 32);
            textBoxAccountID.TabIndex = 146;
            // 
            // comboBoxDuration
            // 
            comboBoxDuration.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDuration.Font = new Font("Roboto", 12F);
            comboBoxDuration.FormattingEnabled = true;
            comboBoxDuration.Items.AddRange(new object[] { "12 tháng", "24 tháng", "36 tháng" });
            comboBoxDuration.Location = new Point(708, 292);
            comboBoxDuration.Name = "comboBoxDuration";
            comboBoxDuration.Size = new Size(248, 32);
            comboBoxDuration.TabIndex = 166;
            // 
            // labelPayInfo
            // 
            labelPayInfo.Font = new Font("Roboto SemiCondensed Medium", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPayInfo.Location = new Point(12, 115);
            labelPayInfo.Name = "labelPayInfo";
            labelPayInfo.Size = new Size(998, 28);
            labelPayInfo.TabIndex = 147;
            labelPayInfo.Text = "Nhập thông tin";
            labelPayInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxTotalPrincipalAmount
            // 
            textBoxTotalPrincipalAmount.Font = new Font("Roboto", 12F);
            textBoxTotalPrincipalAmount.Location = new Point(325, 442);
            textBoxTotalPrincipalAmount.Name = "textBoxTotalPrincipalAmount";
            textBoxTotalPrincipalAmount.Size = new Size(464, 32);
            textBoxTotalPrincipalAmount.TabIndex = 165;
            // 
            // labelAccountID
            // 
            labelAccountID.AutoSize = true;
            labelAccountID.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAccountID.Location = new Point(62, 219);
            labelAccountID.Name = "labelAccountID";
            labelAccountID.Size = new Size(120, 24);
            labelAccountID.TabIndex = 149;
            labelAccountID.Text = "Mã tài khoản";
            // 
            // textBoxPhone
            // 
            textBoxPhone.Font = new Font("Roboto", 12F);
            textBoxPhone.Location = new Point(210, 254);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(344, 32);
            textBoxPhone.TabIndex = 150;
            // 
            // labelAmount
            // 
            labelAmount.AutoSize = true;
            labelAmount.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAmount.Location = new Point(231, 448);
            labelAmount.Name = "labelAmount";
            labelAmount.Size = new Size(70, 24);
            labelAmount.TabIndex = 164;
            labelAmount.Text = "Số tiền";
            // 
            // labelPhone
            // 
            labelPhone.AutoSize = true;
            labelPhone.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPhone.Location = new Point(62, 260);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(45, 24);
            labelPhone.TabIndex = 151;
            labelPhone.Text = "SĐT";
            // 
            // textBoxCitizenID
            // 
            textBoxCitizenID.Font = new Font("Roboto", 12F);
            textBoxCitizenID.Location = new Point(210, 295);
            textBoxCitizenID.Name = "textBoxCitizenID";
            textBoxCitizenID.Size = new Size(344, 32);
            textBoxCitizenID.TabIndex = 152;
            // 
            // labelInterestRate
            // 
            labelInterestRate.AutoSize = true;
            labelInterestRate.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelInterestRate.Location = new Point(560, 257);
            labelInterestRate.Name = "labelInterestRate";
            labelInterestRate.Size = new Size(77, 24);
            labelInterestRate.TabIndex = 163;
            labelInterestRate.Text = "Lãi suất";
            // 
            // labelCitizenID
            // 
            labelCitizenID.AutoSize = true;
            labelCitizenID.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCitizenID.Location = new Point(62, 301);
            labelCitizenID.Name = "labelCitizenID";
            labelCitizenID.Size = new Size(142, 24);
            labelCitizenID.TabIndex = 153;
            labelCitizenID.Text = "CCCD/Passport";
            // 
            // labelServiceID
            // 
            labelServiceID.AutoSize = true;
            labelServiceID.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelServiceID.Location = new Point(560, 216);
            labelServiceID.Name = "labelServiceID";
            labelServiceID.Size = new Size(104, 24);
            labelServiceID.TabIndex = 161;
            labelServiceID.Text = "Mã dịch vụ";
            // 
            // textBoxServiceID
            // 
            textBoxServiceID.Font = new Font("Roboto", 12F);
            textBoxServiceID.Location = new Point(708, 210);
            textBoxServiceID.Name = "textBoxServiceID";
            textBoxServiceID.Size = new Size(248, 32);
            textBoxServiceID.TabIndex = 160;
            // 
            // labelError
            // 
            labelError.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelError.ForeColor = Color.Red;
            labelError.Location = new Point(12, 525);
            labelError.Name = "labelError";
            labelError.Size = new Size(998, 20);
            labelError.TabIndex = 156;
            labelError.Text = "Vui lòng nhập đầy đủ thông tin!";
            labelError.TextAlign = ContentAlignment.MiddleCenter;
            labelError.Visible = false;
            // 
            // labelCustomer
            // 
            labelCustomer.AutoSize = true;
            labelCustomer.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCustomer.Location = new Point(62, 178);
            labelCustomer.Name = "labelCustomer";
            labelCustomer.Size = new Size(112, 24);
            labelCustomer.TabIndex = 157;
            labelCustomer.Text = "Khách hàng";
            // 
            // textBoxAccountName
            // 
            textBoxAccountName.Font = new Font("Roboto", 12F);
            textBoxAccountName.Location = new Point(210, 172);
            textBoxAccountName.Name = "textBoxAccountName";
            textBoxAccountName.Size = new Size(344, 32);
            textBoxAccountName.TabIndex = 158;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(560, 175);
            label1.Name = "label1";
            label1.Size = new Size(114, 24);
            label1.TabIndex = 171;
            label1.Text = "Loại dịch vụ";
            // 
            // comboBoxServiceTypeName
            // 
            comboBoxServiceTypeName.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxServiceTypeName.Font = new Font("Roboto", 12F);
            comboBoxServiceTypeName.FormattingEnabled = true;
            comboBoxServiceTypeName.Items.AddRange(new object[] { "Vay vốn", "Gửi tiết kiệm" });
            comboBoxServiceTypeName.Location = new Point(708, 169);
            comboBoxServiceTypeName.Name = "comboBoxServiceTypeName";
            comboBoxServiceTypeName.Size = new Size(248, 32);
            comboBoxServiceTypeName.TabIndex = 170;
            // 
            // labelCreatedDate
            // 
            labelCreatedDate.AutoSize = true;
            labelCreatedDate.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCreatedDate.Location = new Point(224, 368);
            labelCreatedDate.Name = "labelCreatedDate";
            labelCreatedDate.Size = new Size(86, 24);
            labelCreatedDate.TabIndex = 173;
            labelCreatedDate.Text = "Ngày tạo";
            // 
            // dateTimePickerCreatedDate
            // 
            dateTimePickerCreatedDate.CalendarFont = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePickerCreatedDate.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePickerCreatedDate.Format = DateTimePickerFormat.Short;
            dateTimePickerCreatedDate.Location = new Point(316, 368);
            dateTimePickerCreatedDate.Name = "dateTimePickerCreatedDate";
            dateTimePickerCreatedDate.Size = new Size(490, 32);
            dateTimePickerCreatedDate.TabIndex = 174;
            // 
            // cyberButtonCancel
            // 
            cyberButtonCancel.Alpha = 20;
            cyberButtonCancel.BackColor = Color.Transparent;
            cyberButtonCancel.Background = true;
            cyberButtonCancel.Background_WidthPen = 4F;
            cyberButtonCancel.BackgroundPen = true;
            cyberButtonCancel.ColorBackground = Color.FromArgb(37, 52, 68);
            cyberButtonCancel.ColorBackground_1 = Color.Red;
            cyberButtonCancel.ColorBackground_2 = Color.FromArgb(255, 128, 128);
            cyberButtonCancel.ColorBackground_Pen = Color.FromArgb(29, 200, 238);
            cyberButtonCancel.ColorLighting = Color.FromArgb(29, 200, 238);
            cyberButtonCancel.ColorPen_1 = Color.Red;
            cyberButtonCancel.ColorPen_2 = Color.FromArgb(255, 128, 128);
            cyberButtonCancel.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            cyberButtonCancel.Effect_1 = true;
            cyberButtonCancel.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            cyberButtonCancel.Effect_1_Transparency = 25;
            cyberButtonCancel.Effect_2 = true;
            cyberButtonCancel.Effect_2_ColorBackground = Color.White;
            cyberButtonCancel.Effect_2_Transparency = 20;
            cyberButtonCancel.Font = new Font("Roboto SemiCondensed Medium", 12F, FontStyle.Bold);
            cyberButtonCancel.ForeColor = Color.FromArgb(245, 245, 245);
            cyberButtonCancel.Lighting = false;
            cyberButtonCancel.LinearGradient_Background = true;
            cyberButtonCancel.LinearGradientPen = true;
            cyberButtonCancel.Location = new Point(325, 564);
            cyberButtonCancel.Name = "cyberButtonCancel";
            cyberButtonCancel.PenWidth = 15;
            cyberButtonCancel.Rounding = true;
            cyberButtonCancel.RoundingInt = 70;
            cyberButtonCancel.Size = new Size(187, 56);
            cyberButtonCancel.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberButtonCancel.TabIndex = 176;
            cyberButtonCancel.Tag = "Cyber";
            cyberButtonCancel.TextButton = "Trở về";
            cyberButtonCancel.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            cyberButtonCancel.Timer_Effect_1 = 5;
            cyberButtonCancel.Timer_RGB = 300;
            cyberButtonCancel.Click += cyberButtonCancel_Click;
            // 
            // textBoxInterestRate
            // 
            textBoxInterestRate.Font = new Font("Roboto", 12F);
            textBoxInterestRate.Location = new Point(708, 251);
            textBoxInterestRate.Name = "textBoxInterestRate";
            textBoxInterestRate.Size = new Size(248, 32);
            textBoxInterestRate.TabIndex = 177;
            // 
            // cyberButtonSendRequest
            // 
            cyberButtonSendRequest.Alpha = 20;
            cyberButtonSendRequest.BackColor = Color.Transparent;
            cyberButtonSendRequest.Background = true;
            cyberButtonSendRequest.Background_WidthPen = 4F;
            cyberButtonSendRequest.BackgroundPen = true;
            cyberButtonSendRequest.ColorBackground = Color.FromArgb(37, 52, 68);
            cyberButtonSendRequest.ColorBackground_1 = Color.Teal;
            cyberButtonSendRequest.ColorBackground_2 = Color.Turquoise;
            cyberButtonSendRequest.ColorBackground_Pen = Color.FromArgb(29, 200, 238);
            cyberButtonSendRequest.ColorLighting = Color.FromArgb(29, 200, 238);
            cyberButtonSendRequest.ColorPen_1 = Color.Teal;
            cyberButtonSendRequest.ColorPen_2 = Color.Turquoise;
            cyberButtonSendRequest.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            cyberButtonSendRequest.Effect_1 = true;
            cyberButtonSendRequest.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            cyberButtonSendRequest.Effect_1_Transparency = 25;
            cyberButtonSendRequest.Effect_2 = true;
            cyberButtonSendRequest.Effect_2_ColorBackground = Color.White;
            cyberButtonSendRequest.Effect_2_Transparency = 20;
            cyberButtonSendRequest.Font = new Font("Roboto SemiCondensed Medium", 12F, FontStyle.Bold);
            cyberButtonSendRequest.ForeColor = Color.FromArgb(245, 245, 245);
            cyberButtonSendRequest.Lighting = false;
            cyberButtonSendRequest.LinearGradient_Background = true;
            cyberButtonSendRequest.LinearGradientPen = true;
            cyberButtonSendRequest.Location = new Point(542, 564);
            cyberButtonSendRequest.Name = "cyberButtonSendRequest";
            cyberButtonSendRequest.PenWidth = 15;
            cyberButtonSendRequest.Rounding = true;
            cyberButtonSendRequest.RoundingInt = 70;
            cyberButtonSendRequest.Size = new Size(187, 56);
            cyberButtonSendRequest.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberButtonSendRequest.TabIndex = 205;
            cyberButtonSendRequest.Tag = "Cyber";
            cyberButtonSendRequest.TextButton = "Gửi yêu cầu";
            cyberButtonSendRequest.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            cyberButtonSendRequest.Timer_Effect_1 = 5;
            cyberButtonSendRequest.Timer_RGB = 300;
            cyberButtonSendRequest.Click += cyberButtonSendRequest_Click;
            // 
            // FormLoanApplication
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1022, 653);
            Controls.Add(cyberButtonSendRequest);
            Controls.Add(textBoxInterestRate);
            Controls.Add(cyberButtonCancel);
            Controls.Add(dateTimePickerCreatedDate);
            Controls.Add(labelCreatedDate);
            Controls.Add(label1);
            Controls.Add(comboBoxServiceTypeName);
            Controls.Add(textBoxServiceDescription);
            Controls.Add(panel1);
            Controls.Add(labelDescription);
            Controls.Add(labelDuration);
            Controls.Add(labelPay);
            Controls.Add(textBoxAccountID);
            Controls.Add(comboBoxDuration);
            Controls.Add(labelPayInfo);
            Controls.Add(textBoxTotalPrincipalAmount);
            Controls.Add(labelAccountID);
            Controls.Add(textBoxPhone);
            Controls.Add(labelAmount);
            Controls.Add(labelPhone);
            Controls.Add(textBoxCitizenID);
            Controls.Add(labelInterestRate);
            Controls.Add(labelCitizenID);
            Controls.Add(labelServiceID);
            Controls.Add(textBoxServiceID);
            Controls.Add(labelError);
            Controls.Add(labelCustomer);
            Controls.Add(textBoxAccountName);
            Controls.Add(pictureBoxTopPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormLoanApplication";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng ký Vay vốn";
            ((System.ComponentModel.ISupportInitialize)pictureBoxTopPanel).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxTopPanel;
        private TextBox textBoxServiceDescription;
        private Panel panel1;
        private Label labelDescription;
        private Label labelDuration;
        private Label labelPay;
        private TextBox textBoxAccountID;
        private ComboBox comboBoxDuration;
        private Label labelPayInfo;
        private TextBox textBoxTotalPrincipalAmount;
        private Label labelAccountID;
        private TextBox textBoxPhone;
        private Label labelAmount;
        private Label labelPhone;
        private TextBox textBoxCitizenID;
        private Label labelInterestRate;
        private Label labelCitizenID;
        private Label labelServiceID;
        private TextBox textBoxServiceID;
        private Label labelError;
        private Label labelCustomer;
        private TextBox textBoxAccountName;
        private Label label1;
        private ComboBox comboBoxServiceTypeName;
        private Label labelCreatedDate;
        private DateTimePicker dateTimePickerCreatedDate;
        private ReaLTaiizor.Controls.CyberButton cyberButtonCancel;
        private TextBox textBoxInterestRate;
        private ReaLTaiizor.Controls.CyberButton cyberButtonSendRequest;
    }
}