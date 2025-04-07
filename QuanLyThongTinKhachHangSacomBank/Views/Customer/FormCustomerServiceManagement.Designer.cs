namespace QuanLyThongTinKhachHangSacomBank.Views.Customer
{
    partial class FormCustomerServiceManagement
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCustomerServiceManagement));
            dataGridViewServiceNotification = new DataGridView();
            ServiceID = new DataGridViewTextBoxColumn();
            ServiceType = new DataGridViewTextBoxColumn();
            Amount = new DataGridViewTextBoxColumn();
            InterestRate = new DataGridViewTextBoxColumn();
            Duration = new DataGridViewTextBoxColumn();
            CreatedDate = new DataGridViewTextBoxColumn();
            ApplicableDate = new DataGridViewTextBoxColumn();
            EndDtae = new DataGridViewTextBoxColumn();
            ApprovalStatus = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            pictureBoxTopPanel = new PictureBox();
            labelPay = new Label();
            cyberButtonLoanPrepayment = new ReaLTaiizor.Controls.CyberButton();
            cyberButtonCancelSavings = new ReaLTaiizor.Controls.CyberButton();
            ((System.ComponentModel.ISupportInitialize)dataGridViewServiceNotification).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTopPanel).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewServiceNotification
            // 
            dataGridViewServiceNotification.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewServiceNotification.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewServiceNotification.BackgroundColor = Color.White;
            dataGridViewServiceNotification.BorderStyle = BorderStyle.None;
            dataGridViewServiceNotification.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewServiceNotification.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle4.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dataGridViewServiceNotification.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewServiceNotification.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewServiceNotification.Columns.AddRange(new DataGridViewColumn[] { ServiceID, ServiceType, Amount, InterestRate, Duration, CreatedDate, ApplicableDate, EndDtae, ApprovalStatus, Status });
            dataGridViewServiceNotification.EnableHeadersVisualStyles = false;
            dataGridViewServiceNotification.GridColor = Color.White;
            dataGridViewServiceNotification.Location = new Point(0, 244);
            dataGridViewServiceNotification.Name = "dataGridViewServiceNotification";
            dataGridViewServiceNotification.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewServiceNotification.RowHeadersVisible = false;
            dataGridViewServiceNotification.RowHeadersWidth = 51;
            dataGridViewServiceNotification.Size = new Size(1025, 203);
            dataGridViewServiceNotification.TabIndex = 1;
            // 
            // ServiceID
            // 
            ServiceID.HeaderText = "Mã dịch vụ";
            ServiceID.MinimumWidth = 6;
            ServiceID.Name = "ServiceID";
            // 
            // ServiceType
            // 
            ServiceType.HeaderText = "Loại dịch vụ";
            ServiceType.MinimumWidth = 6;
            ServiceType.Name = "ServiceType";
            // 
            // Amount
            // 
            Amount.HeaderText = "Số tiền";
            Amount.MinimumWidth = 6;
            Amount.Name = "Amount";
            // 
            // InterestRate
            // 
            InterestRate.HeaderText = "Lãi suất";
            InterestRate.MinimumWidth = 6;
            InterestRate.Name = "InterestRate";
            // 
            // Duration
            // 
            Duration.HeaderText = "Kì hạn";
            Duration.MinimumWidth = 6;
            Duration.Name = "Duration";
            // 
            // CreatedDate
            // 
            CreatedDate.HeaderText = "Ngày tạo";
            CreatedDate.MinimumWidth = 6;
            CreatedDate.Name = "CreatedDate";
            // 
            // ApplicableDate
            // 
            ApplicableDate.HeaderText = "Ngày áp dụng";
            ApplicableDate.MinimumWidth = 6;
            ApplicableDate.Name = "ApplicableDate";
            // 
            // EndDtae
            // 
            EndDtae.HeaderText = "Ngày kết thúc";
            EndDtae.MinimumWidth = 6;
            EndDtae.Name = "EndDtae";
            // 
            // ApprovalStatus
            // 
            ApprovalStatus.HeaderText = "Trạng thái duyệt";
            ApprovalStatus.MinimumWidth = 6;
            ApprovalStatus.Name = "ApprovalStatus";
            // 
            // Status
            // 
            Status.HeaderText = "Trạng thái";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            // 
            // pictureBoxTopPanel
            // 
            pictureBoxTopPanel.Image = (Image)resources.GetObject("pictureBoxTopPanel.Image");
            pictureBoxTopPanel.Location = new Point(0, 1);
            pictureBoxTopPanel.Name = "pictureBoxTopPanel";
            pictureBoxTopPanel.Size = new Size(1025, 78);
            pictureBoxTopPanel.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxTopPanel.TabIndex = 179;
            pictureBoxTopPanel.TabStop = false;
            // 
            // labelPay
            // 
            labelPay.AutoSize = true;
            labelPay.Font = new Font("Roboto SemiCondensed", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPay.ForeColor = SystemColors.HotTrack;
            labelPay.Location = new Point(376, 82);
            labelPay.Name = "labelPay";
            labelPay.Size = new Size(266, 41);
            labelPay.TabIndex = 183;
            labelPay.Text = "Quản lý giao dịch";
            // 
            // cyberButtonLoanPrepayment
            // 
            cyberButtonLoanPrepayment.Alpha = 20;
            cyberButtonLoanPrepayment.BackColor = Color.Transparent;
            cyberButtonLoanPrepayment.Background = true;
            cyberButtonLoanPrepayment.Background_WidthPen = 4F;
            cyberButtonLoanPrepayment.BackgroundPen = true;
            cyberButtonLoanPrepayment.ColorBackground = Color.FromArgb(37, 52, 68);
            cyberButtonLoanPrepayment.ColorBackground_1 = SystemColors.HotTrack;
            cyberButtonLoanPrepayment.ColorBackground_2 = Color.Turquoise;
            cyberButtonLoanPrepayment.ColorBackground_Pen = Color.FromArgb(29, 200, 238);
            cyberButtonLoanPrepayment.ColorLighting = Color.FromArgb(29, 200, 238);
            cyberButtonLoanPrepayment.ColorPen_1 = SystemColors.HotTrack;
            cyberButtonLoanPrepayment.ColorPen_2 = Color.Turquoise;
            cyberButtonLoanPrepayment.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            cyberButtonLoanPrepayment.Effect_1 = true;
            cyberButtonLoanPrepayment.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            cyberButtonLoanPrepayment.Effect_1_Transparency = 25;
            cyberButtonLoanPrepayment.Effect_2 = true;
            cyberButtonLoanPrepayment.Effect_2_ColorBackground = Color.White;
            cyberButtonLoanPrepayment.Effect_2_Transparency = 20;
            cyberButtonLoanPrepayment.Font = new Font("Roboto SemiCondensed Medium", 12F, FontStyle.Bold);
            cyberButtonLoanPrepayment.ForeColor = Color.FromArgb(245, 245, 245);
            cyberButtonLoanPrepayment.Lighting = false;
            cyberButtonLoanPrepayment.LinearGradient_Background = true;
            cyberButtonLoanPrepayment.LinearGradientPen = true;
            cyberButtonLoanPrepayment.Location = new Point(505, 144);
            cyberButtonLoanPrepayment.Name = "cyberButtonLoanPrepayment";
            cyberButtonLoanPrepayment.PenWidth = 15;
            cyberButtonLoanPrepayment.Rounding = true;
            cyberButtonLoanPrepayment.RoundingInt = 70;
            cyberButtonLoanPrepayment.Size = new Size(204, 56);
            cyberButtonLoanPrepayment.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberButtonLoanPrepayment.TabIndex = 206;
            cyberButtonLoanPrepayment.Tag = "Cyber";
            cyberButtonLoanPrepayment.TextButton = "Tất toán trước hạn";
            cyberButtonLoanPrepayment.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            cyberButtonLoanPrepayment.Timer_Effect_1 = 5;
            cyberButtonLoanPrepayment.Timer_RGB = 300;
            cyberButtonLoanPrepayment.Click += cyberButtonLoanPrepayment_Click;
            // 
            // cyberButtonCancelSavings
            // 
            cyberButtonCancelSavings.Alpha = 20;
            cyberButtonCancelSavings.BackColor = Color.Transparent;
            cyberButtonCancelSavings.Background = true;
            cyberButtonCancelSavings.Background_WidthPen = 4F;
            cyberButtonCancelSavings.BackgroundPen = true;
            cyberButtonCancelSavings.ColorBackground = Color.FromArgb(37, 52, 68);
            cyberButtonCancelSavings.ColorBackground_1 = Color.Red;
            cyberButtonCancelSavings.ColorBackground_2 = Color.FromArgb(255, 128, 128);
            cyberButtonCancelSavings.ColorBackground_Pen = Color.FromArgb(29, 200, 238);
            cyberButtonCancelSavings.ColorLighting = Color.FromArgb(29, 200, 238);
            cyberButtonCancelSavings.ColorPen_1 = Color.Red;
            cyberButtonCancelSavings.ColorPen_2 = Color.FromArgb(255, 128, 128);
            cyberButtonCancelSavings.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            cyberButtonCancelSavings.Effect_1 = true;
            cyberButtonCancelSavings.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            cyberButtonCancelSavings.Effect_1_Transparency = 25;
            cyberButtonCancelSavings.Effect_2 = true;
            cyberButtonCancelSavings.Effect_2_ColorBackground = Color.White;
            cyberButtonCancelSavings.Effect_2_Transparency = 20;
            cyberButtonCancelSavings.Font = new Font("Roboto SemiCondensed Medium", 12F, FontStyle.Bold);
            cyberButtonCancelSavings.ForeColor = Color.FromArgb(245, 245, 245);
            cyberButtonCancelSavings.Lighting = false;
            cyberButtonCancelSavings.LinearGradient_Background = true;
            cyberButtonCancelSavings.LinearGradientPen = true;
            cyberButtonCancelSavings.Location = new Point(285, 144);
            cyberButtonCancelSavings.Name = "cyberButtonCancelSavings";
            cyberButtonCancelSavings.PenWidth = 15;
            cyberButtonCancelSavings.Rounding = true;
            cyberButtonCancelSavings.RoundingInt = 70;
            cyberButtonCancelSavings.Size = new Size(187, 56);
            cyberButtonCancelSavings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberButtonCancelSavings.TabIndex = 207;
            cyberButtonCancelSavings.Tag = "Cyber";
            cyberButtonCancelSavings.TextButton = "Rút toàn bộ";
            cyberButtonCancelSavings.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            cyberButtonCancelSavings.Timer_Effect_1 = 5;
            cyberButtonCancelSavings.Timer_RGB = 300;
            cyberButtonCancelSavings.Click += cyberButtonCancelSavings_Click;
            // 
            // FormCustomerServiceManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1022, 447);
            Controls.Add(cyberButtonCancelSavings);
            Controls.Add(cyberButtonLoanPrepayment);
            Controls.Add(labelPay);
            Controls.Add(pictureBoxTopPanel);
            Controls.Add(dataGridViewServiceNotification);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormCustomerServiceManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý dịch vụ";
            ((System.ComponentModel.ISupportInitialize)dataGridViewServiceNotification).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTopPanel).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewServiceNotification;
        private DataGridViewTextBoxColumn ServiceID;
        private DataGridViewTextBoxColumn ServiceType;
        private DataGridViewTextBoxColumn Amount;
        private DataGridViewTextBoxColumn InterestRate;
        private DataGridViewTextBoxColumn Duration;
        private DataGridViewTextBoxColumn CreatedDate;
        private DataGridViewTextBoxColumn ApplicableDate;
        private DataGridViewTextBoxColumn EndDtae;
        private DataGridViewTextBoxColumn ApprovalStatus;
        private DataGridViewTextBoxColumn Status;
        private PictureBox pictureBoxTopPanel;
        private Label labelPay;
        private ReaLTaiizor.Controls.CyberButton cyberButtonLoanPrepayment;
        private ReaLTaiizor.Controls.CyberButton cyberButtonCancelSavings;
    }
}