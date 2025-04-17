namespace QuanLyThongTinKhachHangSacomBank.Views.Customer
{
    partial class FormOpenSavings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOpenSavings));
            textBoxInterestRate = new TextBox();
            cyberButtonCancel = new ReaLTaiizor.Controls.CyberButton();
            cyberButtonSendRequest = new ReaLTaiizor.Controls.CyberButton();
            dateTimePickerCreatedDate = new DateTimePicker();
            labelCreatedDate = new Label();
            label1 = new Label();
            comboBoxServiceTypeName = new ComboBox();
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
            pictureBoxTopPanel = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTopPanel).BeginInit();
            SuspendLayout();
            // 
            // textBoxInterestRate
            // 
            textBoxInterestRate.Font = new Font("Roboto", 12F);
            textBoxInterestRate.Location = new Point(711, 269);
            textBoxInterestRate.Name = "textBoxInterestRate";
            textBoxInterestRate.Size = new Size(248, 32);
            textBoxInterestRate.TabIndex = 206;
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
            cyberButtonCancel.Location = new Point(328, 582);
            cyberButtonCancel.Name = "cyberButtonCancel";
            cyberButtonCancel.PenWidth = 15;
            cyberButtonCancel.Rounding = true;
            cyberButtonCancel.RoundingInt = 70;
            cyberButtonCancel.Size = new Size(187, 56);
            cyberButtonCancel.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberButtonCancel.TabIndex = 205;
            cyberButtonCancel.Tag = "Cyber";
            cyberButtonCancel.TextButton = "Trở về";
            cyberButtonCancel.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            cyberButtonCancel.Timer_Effect_1 = 5;
            cyberButtonCancel.Timer_RGB = 300;
            cyberButtonCancel.Click += cyberButtonCancel_Click;
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
            cyberButtonSendRequest.Location = new Point(543, 582);
            cyberButtonSendRequest.Name = "cyberButtonSendRequest";
            cyberButtonSendRequest.PenWidth = 15;
            cyberButtonSendRequest.Rounding = true;
            cyberButtonSendRequest.RoundingInt = 70;
            cyberButtonSendRequest.Size = new Size(187, 56);
            cyberButtonSendRequest.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberButtonSendRequest.TabIndex = 204;
            cyberButtonSendRequest.Tag = "Cyber";
            cyberButtonSendRequest.TextButton = "Gửi yêu cầu";
            cyberButtonSendRequest.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            cyberButtonSendRequest.Timer_Effect_1 = 5;
            cyberButtonSendRequest.Timer_RGB = 300;
            cyberButtonSendRequest.Click += cyberButtonSendRequest_Click;
            // 
            // dateTimePickerCreatedDate
            // 
            dateTimePickerCreatedDate.CalendarFont = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePickerCreatedDate.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePickerCreatedDate.Format = DateTimePickerFormat.Short;
            dateTimePickerCreatedDate.Location = new Point(319, 386);
            dateTimePickerCreatedDate.Name = "dateTimePickerCreatedDate";
            dateTimePickerCreatedDate.Size = new Size(490, 32);
            dateTimePickerCreatedDate.TabIndex = 203;
            // 
            // labelCreatedDate
            // 
            labelCreatedDate.AutoSize = true;
            labelCreatedDate.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCreatedDate.Location = new Point(227, 392);
            labelCreatedDate.Name = "labelCreatedDate";
            labelCreatedDate.Size = new Size(86, 24);
            labelCreatedDate.TabIndex = 202;
            labelCreatedDate.Text = "Ngày tạo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(563, 193);
            label1.Name = "label1";
            label1.Size = new Size(114, 24);
            label1.TabIndex = 201;
            label1.Text = "Loại dịch vụ";
            // 
            // comboBoxServiceTypeName
            // 
            comboBoxServiceTypeName.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxServiceTypeName.Font = new Font("Roboto", 12F);
            comboBoxServiceTypeName.FormattingEnabled = true;
            comboBoxServiceTypeName.Items.AddRange(new object[] { "Vay vốn", "Gửi tiết kiệm" });
            comboBoxServiceTypeName.Location = new Point(711, 187);
            comboBoxServiceTypeName.Name = "comboBoxServiceTypeName";
            comboBoxServiceTypeName.Size = new Size(248, 32);
            comboBoxServiceTypeName.TabIndex = 200;
            // 
            // textBoxServiceDescription
            // 
            textBoxServiceDescription.Font = new Font("Roboto", 12F);
            textBoxServiceDescription.Location = new Point(328, 499);
            textBoxServiceDescription.Name = "textBoxServiceDescription";
            textBoxServiceDescription.Size = new Size(464, 32);
            textBoxServiceDescription.TabIndex = 199;
            // 
            // panel1
            // 
            panel1.BackColor = Color.MediumSeaGreen;
            panel1.Location = new Point(229, 439);
            panel1.Name = "panel1";
            panel1.Size = new Size(580, 5);
            panel1.TabIndex = 179;
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDescription.Location = new Point(234, 507);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(88, 24);
            labelDescription.TabIndex = 198;
            labelDescription.Text = "Nội dung";
            // 
            // labelDuration
            // 
            labelDuration.AutoSize = true;
            labelDuration.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDuration.Location = new Point(563, 316);
            labelDuration.Name = "labelDuration";
            labelDuration.Size = new Size(64, 24);
            labelDuration.TabIndex = 197;
            labelDuration.Text = "Kì hạn";
            // 
            // labelPay
            // 
            labelPay.Font = new Font("Roboto SemiCondensed", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPay.ForeColor = Color.MediumSeaGreen;
            labelPay.Location = new Point(12, 80);
            labelPay.Name = "labelPay";
            labelPay.Size = new Size(998, 41);
            labelPay.TabIndex = 180;
            labelPay.Text = "Đăng ký gửi tiết kiệm";
            labelPay.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxAccountID
            // 
            textBoxAccountID.Font = new Font("Roboto", 12F);
            textBoxAccountID.Location = new Point(213, 231);
            textBoxAccountID.Name = "textBoxAccountID";
            textBoxAccountID.Size = new Size(344, 32);
            textBoxAccountID.TabIndex = 181;
            // 
            // comboBoxDuration
            // 
            comboBoxDuration.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDuration.Font = new Font("Roboto", 12F);
            comboBoxDuration.FormattingEnabled = true;
            comboBoxDuration.Items.AddRange(new object[] { "12 tháng", "24 tháng", "36 tháng" });
            comboBoxDuration.Location = new Point(711, 310);
            comboBoxDuration.Name = "comboBoxDuration";
            comboBoxDuration.Size = new Size(248, 32);
            comboBoxDuration.TabIndex = 196;
            // 
            // labelPayInfo
            // 
            labelPayInfo.Font = new Font("Roboto SemiCondensed Medium", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPayInfo.Location = new Point(12, 129);
            labelPayInfo.Name = "labelPayInfo";
            labelPayInfo.Size = new Size(998, 28);
            labelPayInfo.TabIndex = 182;
            labelPayInfo.Text = "Nhập thông tin";
            labelPayInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxTotalPrincipalAmount
            // 
            textBoxTotalPrincipalAmount.Font = new Font("Roboto", 12F);
            textBoxTotalPrincipalAmount.Location = new Point(328, 460);
            textBoxTotalPrincipalAmount.Name = "textBoxTotalPrincipalAmount";
            textBoxTotalPrincipalAmount.Size = new Size(464, 32);
            textBoxTotalPrincipalAmount.TabIndex = 195;
            // 
            // labelAccountID
            // 
            labelAccountID.AutoSize = true;
            labelAccountID.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAccountID.Location = new Point(65, 237);
            labelAccountID.Name = "labelAccountID";
            labelAccountID.Size = new Size(120, 24);
            labelAccountID.TabIndex = 183;
            labelAccountID.Text = "Mã tài khoản";
            // 
            // textBoxPhone
            // 
            textBoxPhone.Font = new Font("Roboto", 12F);
            textBoxPhone.Location = new Point(213, 272);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(344, 32);
            textBoxPhone.TabIndex = 184;
            // 
            // labelAmount
            // 
            labelAmount.AutoSize = true;
            labelAmount.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAmount.Location = new Point(234, 466);
            labelAmount.Name = "labelAmount";
            labelAmount.Size = new Size(70, 24);
            labelAmount.TabIndex = 194;
            labelAmount.Text = "Số tiền";
            // 
            // labelPhone
            // 
            labelPhone.AutoSize = true;
            labelPhone.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPhone.Location = new Point(65, 278);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(45, 24);
            labelPhone.TabIndex = 185;
            labelPhone.Text = "SĐT";
            // 
            // textBoxCitizenID
            // 
            textBoxCitizenID.Font = new Font("Roboto", 12F);
            textBoxCitizenID.Location = new Point(213, 313);
            textBoxCitizenID.Name = "textBoxCitizenID";
            textBoxCitizenID.Size = new Size(344, 32);
            textBoxCitizenID.TabIndex = 186;
            // 
            // labelInterestRate
            // 
            labelInterestRate.AutoSize = true;
            labelInterestRate.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelInterestRate.Location = new Point(563, 275);
            labelInterestRate.Name = "labelInterestRate";
            labelInterestRate.Size = new Size(77, 24);
            labelInterestRate.TabIndex = 193;
            labelInterestRate.Text = "Lãi suất";
            // 
            // labelCitizenID
            // 
            labelCitizenID.AutoSize = true;
            labelCitizenID.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCitizenID.Location = new Point(65, 319);
            labelCitizenID.Name = "labelCitizenID";
            labelCitizenID.Size = new Size(142, 24);
            labelCitizenID.TabIndex = 187;
            labelCitizenID.Text = "CCCD/Passport";
            // 
            // labelServiceID
            // 
            labelServiceID.AutoSize = true;
            labelServiceID.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelServiceID.Location = new Point(563, 234);
            labelServiceID.Name = "labelServiceID";
            labelServiceID.Size = new Size(104, 24);
            labelServiceID.TabIndex = 192;
            labelServiceID.Text = "Mã dịch vụ";
            // 
            // textBoxServiceID
            // 
            textBoxServiceID.Font = new Font("Roboto", 12F);
            textBoxServiceID.Location = new Point(711, 228);
            textBoxServiceID.Name = "textBoxServiceID";
            textBoxServiceID.Size = new Size(248, 32);
            textBoxServiceID.TabIndex = 191;
            // 
            // labelError
            // 
            labelError.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelError.ForeColor = Color.Red;
            labelError.Location = new Point(12, 547);
            labelError.Name = "labelError";
            labelError.Size = new Size(998, 20);
            labelError.TabIndex = 188;
            labelError.Text = "Vui lòng nhập đầy đủ thông tin!";
            labelError.TextAlign = ContentAlignment.MiddleCenter;
            labelError.Visible = false;
            // 
            // labelCustomer
            // 
            labelCustomer.AutoSize = true;
            labelCustomer.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCustomer.Location = new Point(65, 196);
            labelCustomer.Name = "labelCustomer";
            labelCustomer.Size = new Size(112, 24);
            labelCustomer.TabIndex = 189;
            labelCustomer.Text = "Khách hàng";
            // 
            // textBoxAccountName
            // 
            textBoxAccountName.Font = new Font("Roboto", 12F);
            textBoxAccountName.Location = new Point(213, 190);
            textBoxAccountName.Name = "textBoxAccountName";
            textBoxAccountName.Size = new Size(344, 32);
            textBoxAccountName.TabIndex = 190;
            // 
            // pictureBoxTopPanel
            // 
            pictureBoxTopPanel.Image = (Image)resources.GetObject("pictureBoxTopPanel.Image");
            pictureBoxTopPanel.Location = new Point(2, -1);
            pictureBoxTopPanel.Name = "pictureBoxTopPanel";
            pictureBoxTopPanel.Size = new Size(1025, 78);
            pictureBoxTopPanel.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxTopPanel.TabIndex = 178;
            pictureBoxTopPanel.TabStop = false;
            // 
            // FormOpenSavings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1022, 653);
            Controls.Add(textBoxInterestRate);
            Controls.Add(cyberButtonCancel);
            Controls.Add(cyberButtonSendRequest);
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
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormOpenSavings";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng ký Gửi tiết kiệm";
            ((System.ComponentModel.ISupportInitialize)pictureBoxTopPanel).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxInterestRate;
        private ReaLTaiizor.Controls.CyberButton cyberButtonCancel;
        private ReaLTaiizor.Controls.CyberButton cyberButtonSendRequest;
        private DateTimePicker dateTimePickerCreatedDate;
        private Label labelCreatedDate;
        private Label label1;
        private ComboBox comboBoxServiceTypeName;
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
        private PictureBox pictureBoxTopPanel;
    }
}