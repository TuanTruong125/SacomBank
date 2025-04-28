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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCustomerServiceManagement));
            dataGridViewCustomerServiceManagement = new DataGridView();
            ServiceTypeName = new DataGridViewTextBoxColumn();
            ServiceID = new DataGridViewTextBoxColumn();
            TotalPrincipalAmount = new DataGridViewTextBoxColumn();
            Duration = new DataGridViewTextBoxColumn();
            InterestRate = new DataGridViewTextBoxColumn();
            TotalInterestAmount = new DataGridViewTextBoxColumn();
            ServiceDescription = new DataGridViewTextBoxColumn();
            CreatedDate = new DataGridViewTextBoxColumn();
            ApplicableDate = new DataGridViewTextBoxColumn();
            EndDtae = new DataGridViewTextBoxColumn();
            HandledBy = new DataGridViewTextBoxColumn();
            ApprovalStatus = new DataGridViewTextBoxColumn();
            ServiceStatus = new DataGridViewTextBoxColumn();
            pictureBoxTopPanel = new PictureBox();
            labelPay = new Label();
            parrotCard1 = new ReaLTaiizor.Controls.ParrotCard();
            parrotCard2 = new ReaLTaiizor.Controls.ParrotCard();
            cyberTextBox2 = new ReaLTaiizor.Controls.CyberTextBox();
            cyberTextBox1 = new ReaLTaiizor.Controls.CyberTextBox();
            panel1 = new Panel();
            labelRemainingDebt = new Label();
            labelTotalLoanPrincipalAmount = new Label();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            labelTotalInterestPaid = new Label();
            labelTotalSavingsPrincipalAmount = new Label();
            label4 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCustomerServiceManagement).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTopPanel).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewCustomerServiceManagement
            // 
            dataGridViewCustomerServiceManagement.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCustomerServiceManagement.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCustomerServiceManagement.BackgroundColor = Color.White;
            dataGridViewCustomerServiceManagement.BorderStyle = BorderStyle.None;
            dataGridViewCustomerServiceManagement.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewCustomerServiceManagement.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle3.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridViewCustomerServiceManagement.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCustomerServiceManagement.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCustomerServiceManagement.Columns.AddRange(new DataGridViewColumn[] { ServiceTypeName, ServiceID, TotalPrincipalAmount, Duration, InterestRate, TotalInterestAmount, ServiceDescription, CreatedDate, ApplicableDate, EndDtae, HandledBy, ApprovalStatus, ServiceStatus });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dataGridViewCustomerServiceManagement.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCustomerServiceManagement.EnableHeadersVisualStyles = false;
            dataGridViewCustomerServiceManagement.GridColor = Color.White;
            dataGridViewCustomerServiceManagement.Location = new Point(0, 357);
            dataGridViewCustomerServiceManagement.Name = "dataGridViewCustomerServiceManagement";
            dataGridViewCustomerServiceManagement.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCustomerServiceManagement.RowHeadersVisible = false;
            dataGridViewCustomerServiceManagement.RowHeadersWidth = 51;
            dataGridViewCustomerServiceManagement.Size = new Size(1025, 203);
            dataGridViewCustomerServiceManagement.TabIndex = 1;
            // 
            // ServiceTypeName
            // 
            ServiceTypeName.HeaderText = "Loại dịch vụ";
            ServiceTypeName.MinimumWidth = 6;
            ServiceTypeName.Name = "ServiceTypeName";
            ServiceTypeName.Width = 134;
            // 
            // ServiceID
            // 
            ServiceID.HeaderText = "Mã dịch vụ";
            ServiceID.MinimumWidth = 6;
            ServiceID.Name = "ServiceID";
            ServiceID.Width = 124;
            // 
            // TotalPrincipalAmount
            // 
            TotalPrincipalAmount.HeaderText = "Số tiền gốc";
            TotalPrincipalAmount.MinimumWidth = 6;
            TotalPrincipalAmount.Name = "TotalPrincipalAmount";
            TotalPrincipalAmount.Width = 127;
            // 
            // Duration
            // 
            Duration.HeaderText = "Kì hạn";
            Duration.MinimumWidth = 6;
            Duration.Name = "Duration";
            Duration.Width = 87;
            // 
            // InterestRate
            // 
            InterestRate.HeaderText = "Lãi suất";
            InterestRate.MinimumWidth = 6;
            InterestRate.Name = "InterestRate";
            InterestRate.Width = 101;
            // 
            // TotalInterestAmount
            // 
            TotalInterestAmount.HeaderText = "Tổng lãi dự kiến";
            TotalInterestAmount.MinimumWidth = 6;
            TotalInterestAmount.Name = "TotalInterestAmount";
            TotalInterestAmount.Width = 166;
            // 
            // ServiceDescription
            // 
            ServiceDescription.HeaderText = "Nội dung";
            ServiceDescription.MinimumWidth = 6;
            ServiceDescription.Name = "ServiceDescription";
            ServiceDescription.Width = 108;
            // 
            // CreatedDate
            // 
            CreatedDate.HeaderText = "Ngày tạo";
            CreatedDate.MinimumWidth = 6;
            CreatedDate.Name = "CreatedDate";
            CreatedDate.Width = 108;
            // 
            // ApplicableDate
            // 
            ApplicableDate.HeaderText = "Ngày áp dụng";
            ApplicableDate.MinimumWidth = 6;
            ApplicableDate.Name = "ApplicableDate";
            ApplicableDate.Width = 147;
            // 
            // EndDtae
            // 
            EndDtae.HeaderText = "Ngày kết thúc";
            EndDtae.MinimumWidth = 6;
            EndDtae.Name = "EndDtae";
            EndDtae.Width = 147;
            // 
            // HandledBy
            // 
            HandledBy.HeaderText = "Nhân viên xử lý";
            HandledBy.MinimumWidth = 6;
            HandledBy.Name = "HandledBy";
            HandledBy.Width = 161;
            // 
            // ApprovalStatus
            // 
            ApprovalStatus.HeaderText = "Trạng thái duyệt";
            ApprovalStatus.MinimumWidth = 6;
            ApprovalStatus.Name = "ApprovalStatus";
            ApprovalStatus.Width = 169;
            // 
            // ServiceStatus
            // 
            ServiceStatus.HeaderText = "Trạng thái";
            ServiceStatus.MinimumWidth = 6;
            ServiceStatus.Name = "ServiceStatus";
            ServiceStatus.Width = 119;
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
            labelPay.Font = new Font("Roboto SemiCondensed", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPay.ForeColor = SystemColors.HotTrack;
            labelPay.Location = new Point(12, 82);
            labelPay.Name = "labelPay";
            labelPay.Size = new Size(998, 41);
            labelPay.TabIndex = 183;
            labelPay.Text = "Dịch vụ của tôi";
            labelPay.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // parrotCard1
            // 
            parrotCard1.BackColor = Color.Transparent;
            parrotCard1.Color1 = SystemColors.HotTrack;
            parrotCard1.Color2 = Color.DeepSkyBlue;
            parrotCard1.ForeColor = Color.White;
            parrotCard1.Location = new Point(159, 126);
            parrotCard1.Name = "parrotCard1";
            parrotCard1.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            parrotCard1.Size = new Size(341, 225);
            parrotCard1.TabIndex = 184;
            parrotCard1.Text = "parrotCard1";
            parrotCard1.Text1 = "";
            parrotCard1.Text2 = "";
            parrotCard1.Text3 = "";
            parrotCard1.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // parrotCard2
            // 
            parrotCard2.BackColor = Color.Transparent;
            parrotCard2.Color1 = Color.Teal;
            parrotCard2.Color2 = Color.Turquoise;
            parrotCard2.ForeColor = Color.White;
            parrotCard2.Location = new Point(550, 126);
            parrotCard2.Name = "parrotCard2";
            parrotCard2.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            parrotCard2.Size = new Size(341, 225);
            parrotCard2.TabIndex = 186;
            parrotCard2.Text = "parrotCard2";
            parrotCard2.Text1 = "";
            parrotCard2.Text2 = "";
            parrotCard2.Text3 = "";
            parrotCard2.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // cyberTextBox2
            // 
            cyberTextBox2.Alpha = 20;
            cyberTextBox2.BackColor = Color.Transparent;
            cyberTextBox2.Background_WidthPen = 3F;
            cyberTextBox2.BackgroundPen = true;
            cyberTextBox2.ColorBackground = Color.White;
            cyberTextBox2.ColorBackground_Pen = Color.DeepSkyBlue;
            cyberTextBox2.ColorLighting = Color.FromArgb(29, 200, 238);
            cyberTextBox2.ColorPen_1 = Color.DeepSkyBlue;
            cyberTextBox2.ColorPen_2 = Color.DeepSkyBlue;
            cyberTextBox2.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            cyberTextBox2.Enabled = false;
            cyberTextBox2.Font = new Font("Roboto SemiCondensed Medium", 14F, FontStyle.Bold);
            cyberTextBox2.ForeColor = Color.ForestGreen;
            cyberTextBox2.Lighting = false;
            cyberTextBox2.LinearGradientPen = false;
            cyberTextBox2.Location = new Point(613, 135);
            cyberTextBox2.Name = "cyberTextBox2";
            cyberTextBox2.PenWidth = 15;
            cyberTextBox2.RGB = false;
            cyberTextBox2.Rounding = true;
            cyberTextBox2.RoundingInt = 90;
            cyberTextBox2.Size = new Size(212, 57);
            cyberTextBox2.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberTextBox2.TabIndex = 187;
            cyberTextBox2.Tag = "Cyber";
            cyberTextBox2.TextButton = "Gửi tiết kiệm";
            cyberTextBox2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            cyberTextBox2.Timer_RGB = 300;
            // 
            // cyberTextBox1
            // 
            cyberTextBox1.Alpha = 20;
            cyberTextBox1.BackColor = Color.Transparent;
            cyberTextBox1.Background_WidthPen = 3F;
            cyberTextBox1.BackgroundPen = true;
            cyberTextBox1.ColorBackground = Color.White;
            cyberTextBox1.ColorBackground_Pen = Color.DeepSkyBlue;
            cyberTextBox1.ColorLighting = Color.FromArgb(29, 200, 238);
            cyberTextBox1.ColorPen_1 = Color.DeepSkyBlue;
            cyberTextBox1.ColorPen_2 = Color.DeepSkyBlue;
            cyberTextBox1.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            cyberTextBox1.Enabled = false;
            cyberTextBox1.Font = new Font("Roboto SemiCondensed Medium", 14F, FontStyle.Bold);
            cyberTextBox1.ForeColor = Color.SteelBlue;
            cyberTextBox1.Lighting = false;
            cyberTextBox1.LinearGradientPen = false;
            cyberTextBox1.Location = new Point(220, 135);
            cyberTextBox1.Name = "cyberTextBox1";
            cyberTextBox1.PenWidth = 15;
            cyberTextBox1.RGB = false;
            cyberTextBox1.Rounding = true;
            cyberTextBox1.RoundingInt = 90;
            cyberTextBox1.Size = new Size(212, 57);
            cyberTextBox1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberTextBox1.TabIndex = 188;
            cyberTextBox1.Tag = "Cyber";
            cyberTextBox1.TextButton = "Vay vốn";
            cyberTextBox1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            cyberTextBox1.Timer_RGB = 300;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(labelRemainingDebt);
            panel1.Controls.Add(labelTotalLoanPrincipalAmount);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(182, 198);
            panel1.Name = "panel1";
            panel1.Size = new Size(296, 131);
            panel1.TabIndex = 189;
            // 
            // labelRemainingDebt
            // 
            labelRemainingDebt.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelRemainingDebt.ForeColor = Color.SteelBlue;
            labelRemainingDebt.Location = new Point(3, 95);
            labelRemainingDebt.Name = "labelRemainingDebt";
            labelRemainingDebt.Size = new Size(290, 20);
            labelRemainingDebt.TabIndex = 3;
            labelRemainingDebt.Text = "0 VND";
            labelRemainingDebt.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelTotalLoanPrincipalAmount
            // 
            labelTotalLoanPrincipalAmount.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTotalLoanPrincipalAmount.Location = new Point(3, 37);
            labelTotalLoanPrincipalAmount.Name = "labelTotalLoanPrincipalAmount";
            labelTotalLoanPrincipalAmount.Size = new Size(290, 20);
            labelTotalLoanPrincipalAmount.TabIndex = 2;
            labelTotalLoanPrincipalAmount.Text = "0 VND";
            labelTotalLoanPrincipalAmount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(90, 65);
            label2.Name = "label2";
            label2.Size = new Size(114, 20);
            label2.TabIndex = 1;
            label2.Text = "Số nợ còn lại";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(96, 9);
            label1.Name = "label1";
            label1.Size = new Size(99, 20);
            label1.TabIndex = 0;
            label1.Text = "Số tiền vay";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(labelTotalInterestPaid);
            panel2.Controls.Add(labelTotalSavingsPrincipalAmount);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(572, 198);
            panel2.Name = "panel2";
            panel2.Size = new Size(296, 131);
            panel2.TabIndex = 190;
            // 
            // labelTotalInterestPaid
            // 
            labelTotalInterestPaid.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTotalInterestPaid.ForeColor = Color.ForestGreen;
            labelTotalInterestPaid.Location = new Point(3, 95);
            labelTotalInterestPaid.Name = "labelTotalInterestPaid";
            labelTotalInterestPaid.Size = new Size(290, 20);
            labelTotalInterestPaid.TabIndex = 4;
            labelTotalInterestPaid.Text = "0 VND";
            labelTotalInterestPaid.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelTotalSavingsPrincipalAmount
            // 
            labelTotalSavingsPrincipalAmount.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTotalSavingsPrincipalAmount.Location = new Point(3, 37);
            labelTotalSavingsPrincipalAmount.Name = "labelTotalSavingsPrincipalAmount";
            labelTotalSavingsPrincipalAmount.Size = new Size(290, 20);
            labelTotalSavingsPrincipalAmount.TabIndex = 3;
            labelTotalSavingsPrincipalAmount.Text = "0 VND";
            labelTotalSavingsPrincipalAmount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(83, 65);
            label4.Name = "label4";
            label4.Size = new Size(134, 20);
            label4.TabIndex = 2;
            label4.Text = "Tiền lãi tích lũy";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(99, 9);
            label3.Name = "label3";
            label3.Size = new Size(97, 20);
            label3.TabIndex = 1;
            label3.Text = "Số tiền gửi";
            // 
            // FormCustomerServiceManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1022, 557);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(cyberTextBox1);
            Controls.Add(cyberTextBox2);
            Controls.Add(parrotCard2);
            Controls.Add(parrotCard1);
            Controls.Add(labelPay);
            Controls.Add(pictureBoxTopPanel);
            Controls.Add(dataGridViewCustomerServiceManagement);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormCustomerServiceManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dịch vụ của tôi";
            ((System.ComponentModel.ISupportInitialize)dataGridViewCustomerServiceManagement).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTopPanel).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewCustomerServiceManagement;
        private PictureBox pictureBoxTopPanel;
        private Label labelPay;
        private ReaLTaiizor.Controls.ParrotCard parrotCard1;
        private ReaLTaiizor.Controls.ParrotCard parrotCard2;
        private ReaLTaiizor.Controls.CyberTextBox cyberTextBox2;
        private ReaLTaiizor.Controls.CyberTextBox cyberTextBox1;
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Label labelTotalLoanPrincipalAmount;
        private Label label2;
        private Label label4;
        private Label label3;
        private Label labelRemainingDebt;
        private Label labelTotalInterestPaid;
        private Label labelTotalSavingsPrincipalAmount;
        private DataGridViewTextBoxColumn ServiceTypeName;
        private DataGridViewTextBoxColumn ServiceID;
        private DataGridViewTextBoxColumn TotalPrincipalAmount;
        private DataGridViewTextBoxColumn Duration;
        private DataGridViewTextBoxColumn InterestRate;
        private DataGridViewTextBoxColumn TotalInterestAmount;
        private DataGridViewTextBoxColumn ServiceDescription;
        private DataGridViewTextBoxColumn CreatedDate;
        private DataGridViewTextBoxColumn ApplicableDate;
        private DataGridViewTextBoxColumn EndDtae;
        private DataGridViewTextBoxColumn HandledBy;
        private DataGridViewTextBoxColumn ApprovalStatus;
        private DataGridViewTextBoxColumn ServiceStatus;
    }
}