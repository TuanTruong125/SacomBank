namespace QuanLyThongTinKhachHangSacomBank.Views.Employee
{
    partial class UC_ServiceManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_ServiceManagement));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            panel1 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            label6 = new Label();
            textBoxCustomerID = new TextBox();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            buttonLoanPrepayment = new Button();
            buttonCancelSavings = new Button();
            textBoxStatus = new TextBox();
            label3 = new Label();
            textBoxApprovalStatus = new TextBox();
            labelApprovalStatus = new Label();
            textBoxHandledBy = new TextBox();
            labelHandledBy = new Label();
            dateTimePickerEndDate = new DateTimePicker();
            label1 = new Label();
            dateTimePickerApplicableDate = new DateTimePicker();
            label2 = new Label();
            dateTimePickerCreatedDate = new DateTimePicker();
            labelCreatedDate = new Label();
            comboBoxDuration = new ComboBox();
            labelDuration = new Label();
            comboBoxInterestRate = new ComboBox();
            labelInterestRate = new Label();
            textBoxTotalPrincipalAmount = new TextBox();
            labelTotalPrincipalAmount = new Label();
            textBoxServiceID = new TextBox();
            labelServiceID = new Label();
            comboBoxServiceTypeName = new ComboBox();
            labelServiceType = new Label();
            textBoxAccountID = new TextBox();
            labelAccountID = new Label();
            label7 = new Label();
            textBoxAccountName = new TextBox();
            buttonAddService = new Button();
            buttonDeleteService = new Button();
            buttonEditService = new Button();
            buttonCancelService = new Button();
            buttonSaveService = new Button();
            ApprovalStatus = new DataGridViewTextBoxColumn();
            groupBox2 = new GroupBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            buttonExportCSV = new Button();
            buttonExportExcel = new Button();
            buttonExportPDF = new Button();
            labelServiceFilter = new Label();
            buttonServiceSearch = new Button();
            labelServiceTypeFilter = new Label();
            comboBoxServiceTypeFilter = new ComboBox();
            labelInterestRateFilter = new Label();
            comboBoxInterestRateFilter = new ComboBox();
            dataGridViewServiceManagement = new DataGridView();
            CustomerID = new DataGridViewTextBoxColumn();
            AccountName = new DataGridViewTextBoxColumn();
            AccountID = new DataGridViewTextBoxColumn();
            ServiceTypeName = new DataGridViewTextBoxColumn();
            ServiceID = new DataGridViewTextBoxColumn();
            TotalPrincipalAmount = new DataGridViewTextBoxColumn();
            InterestRate = new DataGridViewTextBoxColumn();
            Duration = new DataGridViewTextBoxColumn();
            CreatedDate = new DataGridViewTextBoxColumn();
            ApplicableDate = new DataGridViewTextBoxColumn();
            EndDate = new DataGridViewTextBoxColumn();
            HandledBy = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            label8 = new Label();
            label9 = new Label();
            dateTimePickerFrom = new DateTimePicker();
            dateTimePickeTo = new DateTimePicker();
            labelDurationFilter = new Label();
            comboBoxDurationFilter = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            comboBoxStatusFilter = new ComboBox();
            comboBoxApprovalStatusFilter = new ComboBox();
            buttonFilterConfirm = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            textBoxServiceSearch = new TextBox();
            panel3 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox2.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewServiceManagement).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            tableLayoutPanel1.SetColumnSpan(groupBox1, 2);
            groupBox1.Controls.Add(panel1);
            groupBox1.Controls.Add(tableLayoutPanel2);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Roboto SemiCondensed Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = SystemColors.HotTrack;
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1126, 370);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin dịch vụ";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.HotTrack;
            panel1.Location = new Point(178, 11);
            panel1.Name = "panel1";
            panel1.Size = new Size(165, 5);
            panel1.TabIndex = 46;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 9;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.4220123F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.8597126F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.586588264F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.3597126F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.4604321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.928572F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.892857134F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.821428F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.48935366F));
            tableLayoutPanel2.Controls.Add(label6, 0, 0);
            tableLayoutPanel2.Controls.Add(textBoxCustomerID, 0, 1);
            tableLayoutPanel2.Controls.Add(panel2, 6, 0);
            tableLayoutPanel2.Controls.Add(pictureBox1, 8, 0);
            tableLayoutPanel2.Controls.Add(buttonLoanPrepayment, 5, 5);
            tableLayoutPanel2.Controls.Add(buttonCancelSavings, 5, 3);
            tableLayoutPanel2.Controls.Add(textBoxStatus, 4, 7);
            tableLayoutPanel2.Controls.Add(label3, 4, 6);
            tableLayoutPanel2.Controls.Add(textBoxApprovalStatus, 4, 5);
            tableLayoutPanel2.Controls.Add(labelApprovalStatus, 4, 4);
            tableLayoutPanel2.Controls.Add(textBoxHandledBy, 4, 3);
            tableLayoutPanel2.Controls.Add(labelHandledBy, 4, 2);
            tableLayoutPanel2.Controls.Add(dateTimePickerEndDate, 4, 1);
            tableLayoutPanel2.Controls.Add(label1, 4, 0);
            tableLayoutPanel2.Controls.Add(dateTimePickerApplicableDate, 3, 9);
            tableLayoutPanel2.Controls.Add(label2, 3, 8);
            tableLayoutPanel2.Controls.Add(dateTimePickerCreatedDate, 3, 7);
            tableLayoutPanel2.Controls.Add(labelCreatedDate, 3, 6);
            tableLayoutPanel2.Controls.Add(comboBoxDuration, 3, 5);
            tableLayoutPanel2.Controls.Add(labelDuration, 3, 4);
            tableLayoutPanel2.Controls.Add(comboBoxInterestRate, 3, 3);
            tableLayoutPanel2.Controls.Add(labelInterestRate, 3, 2);
            tableLayoutPanel2.Controls.Add(textBoxTotalPrincipalAmount, 3, 1);
            tableLayoutPanel2.Controls.Add(labelTotalPrincipalAmount, 3, 0);
            tableLayoutPanel2.Controls.Add(textBoxServiceID, 0, 9);
            tableLayoutPanel2.Controls.Add(labelServiceID, 0, 8);
            tableLayoutPanel2.Controls.Add(comboBoxServiceTypeName, 0, 7);
            tableLayoutPanel2.Controls.Add(labelServiceType, 0, 6);
            tableLayoutPanel2.Controls.Add(textBoxAccountID, 0, 5);
            tableLayoutPanel2.Controls.Add(labelAccountID, 0, 4);
            tableLayoutPanel2.Controls.Add(label7, 0, 2);
            tableLayoutPanel2.Controls.Add(textBoxAccountName, 0, 3);
            tableLayoutPanel2.Controls.Add(buttonAddService, 7, 0);
            tableLayoutPanel2.Controls.Add(buttonDeleteService, 7, 2);
            tableLayoutPanel2.Controls.Add(buttonEditService, 7, 4);
            tableLayoutPanel2.Controls.Add(buttonCancelService, 7, 6);
            tableLayoutPanel2.Controls.Add(buttonSaveService, 7, 8);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 28);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 10;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(1120, 339);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(3, 13);
            label6.Name = "label6";
            label6.Size = new Size(120, 20);
            label6.TabIndex = 59;
            label6.Text = "Mã khách hàng";
            // 
            // textBoxCustomerID
            // 
            textBoxCustomerID.BackColor = SystemColors.InactiveCaption;
            tableLayoutPanel2.SetColumnSpan(textBoxCustomerID, 2);
            textBoxCustomerID.Dock = DockStyle.Fill;
            textBoxCustomerID.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxCustomerID.Location = new Point(3, 36);
            textBoxCustomerID.Name = "textBoxCustomerID";
            textBoxCustomerID.Size = new Size(266, 28);
            textBoxCustomerID.TabIndex = 23;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.HotTrack;
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(939, 3);
            panel2.Name = "panel2";
            tableLayoutPanel2.SetRowSpan(panel2, 10);
            panel2.Size = new Size(4, 333);
            panel2.TabIndex = 39;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1059, 3);
            pictureBox1.Name = "pictureBox1";
            tableLayoutPanel2.SetRowSpan(pictureBox1, 10);
            pictureBox1.Size = new Size(58, 333);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 45;
            pictureBox1.TabStop = false;
            // 
            // buttonLoanPrepayment
            // 
            buttonLoanPrepayment.BackColor = Color.MediumTurquoise;
            buttonLoanPrepayment.Dock = DockStyle.Fill;
            buttonLoanPrepayment.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonLoanPrepayment.ForeColor = Color.White;
            buttonLoanPrepayment.ImageAlign = ContentAlignment.MiddleLeft;
            buttonLoanPrepayment.Location = new Point(839, 168);
            buttonLoanPrepayment.Name = "buttonLoanPrepayment";
            tableLayoutPanel2.SetRowSpan(buttonLoanPrepayment, 2);
            buttonLoanPrepayment.Size = new Size(94, 60);
            buttonLoanPrepayment.TabIndex = 58;
            buttonLoanPrepayment.Text = "Tất toán trước hạn";
            buttonLoanPrepayment.UseVisualStyleBackColor = false;
            // 
            // buttonCancelSavings
            // 
            buttonCancelSavings.BackColor = Color.OrangeRed;
            buttonCancelSavings.Dock = DockStyle.Fill;
            buttonCancelSavings.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonCancelSavings.ForeColor = Color.White;
            buttonCancelSavings.ImageAlign = ContentAlignment.MiddleLeft;
            buttonCancelSavings.Location = new Point(839, 102);
            buttonCancelSavings.Name = "buttonCancelSavings";
            tableLayoutPanel2.SetRowSpan(buttonCancelSavings, 2);
            buttonCancelSavings.Size = new Size(94, 60);
            buttonCancelSavings.TabIndex = 57;
            buttonCancelSavings.Text = "Rút toàn bộ";
            buttonCancelSavings.UseVisualStyleBackColor = false;
            // 
            // textBoxStatus
            // 
            textBoxStatus.BackColor = SystemColors.InactiveCaption;
            textBoxStatus.Dock = DockStyle.Fill;
            textBoxStatus.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxStatus.Location = new Point(565, 234);
            textBoxStatus.Name = "textBoxStatus";
            textBoxStatus.Size = new Size(268, 28);
            textBoxStatus.TabIndex = 56;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(565, 211);
            label3.Name = "label3";
            label3.Size = new Size(82, 20);
            label3.TabIndex = 55;
            label3.Text = "Trạng thái";
            // 
            // textBoxApprovalStatus
            // 
            textBoxApprovalStatus.BackColor = SystemColors.InactiveCaption;
            textBoxApprovalStatus.Dock = DockStyle.Fill;
            textBoxApprovalStatus.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxApprovalStatus.Location = new Point(565, 168);
            textBoxApprovalStatus.Name = "textBoxApprovalStatus";
            textBoxApprovalStatus.Size = new Size(268, 28);
            textBoxApprovalStatus.TabIndex = 50;
            // 
            // labelApprovalStatus
            // 
            labelApprovalStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelApprovalStatus.AutoSize = true;
            labelApprovalStatus.BackColor = Color.Transparent;
            labelApprovalStatus.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelApprovalStatus.ForeColor = Color.Black;
            labelApprovalStatus.Location = new Point(565, 145);
            labelApprovalStatus.Name = "labelApprovalStatus";
            labelApprovalStatus.Size = new Size(126, 20);
            labelApprovalStatus.TabIndex = 33;
            labelApprovalStatus.Text = "Trạng thái duyệt";
            // 
            // textBoxHandledBy
            // 
            textBoxHandledBy.BackColor = SystemColors.InactiveCaption;
            textBoxHandledBy.Dock = DockStyle.Fill;
            textBoxHandledBy.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxHandledBy.Location = new Point(565, 102);
            textBoxHandledBy.Name = "textBoxHandledBy";
            textBoxHandledBy.Size = new Size(268, 28);
            textBoxHandledBy.TabIndex = 27;
            // 
            // labelHandledBy
            // 
            labelHandledBy.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelHandledBy.AutoSize = true;
            labelHandledBy.BackColor = Color.Transparent;
            labelHandledBy.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelHandledBy.ForeColor = Color.Black;
            labelHandledBy.Location = new Point(565, 79);
            labelHandledBy.Name = "labelHandledBy";
            labelHandledBy.Size = new Size(119, 20);
            labelHandledBy.TabIndex = 13;
            labelHandledBy.Text = "Nhân viên xử lý";
            // 
            // dateTimePickerEndDate
            // 
            dateTimePickerEndDate.CalendarFont = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePickerEndDate.CalendarMonthBackground = SystemColors.InactiveCaption;
            dateTimePickerEndDate.Dock = DockStyle.Fill;
            dateTimePickerEndDate.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePickerEndDate.Location = new Point(565, 36);
            dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            dateTimePickerEndDate.Size = new Size(268, 28);
            dateTimePickerEndDate.TabIndex = 52;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(565, 13);
            label1.Name = "label1";
            label1.Size = new Size(108, 20);
            label1.TabIndex = 51;
            label1.Text = "Ngày kết thúc";
            // 
            // dateTimePickerApplicableDate
            // 
            dateTimePickerApplicableDate.CalendarFont = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePickerApplicableDate.CalendarMonthBackground = SystemColors.InactiveCaption;
            dateTimePickerApplicableDate.Dock = DockStyle.Fill;
            dateTimePickerApplicableDate.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePickerApplicableDate.Location = new Point(281, 300);
            dateTimePickerApplicableDate.Name = "dateTimePickerApplicableDate";
            dateTimePickerApplicableDate.Size = new Size(278, 28);
            dateTimePickerApplicableDate.TabIndex = 54;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(281, 277);
            label2.Name = "label2";
            label2.Size = new Size(108, 20);
            label2.TabIndex = 53;
            label2.Text = "Ngày áp dụng";
            // 
            // dateTimePickerCreatedDate
            // 
            dateTimePickerCreatedDate.CalendarFont = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePickerCreatedDate.CalendarMonthBackground = SystemColors.InactiveCaption;
            dateTimePickerCreatedDate.Dock = DockStyle.Fill;
            dateTimePickerCreatedDate.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePickerCreatedDate.Location = new Point(281, 234);
            dateTimePickerCreatedDate.Name = "dateTimePickerCreatedDate";
            dateTimePickerCreatedDate.Size = new Size(278, 28);
            dateTimePickerCreatedDate.TabIndex = 49;
            // 
            // labelCreatedDate
            // 
            labelCreatedDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelCreatedDate.AutoSize = true;
            labelCreatedDate.BackColor = Color.Transparent;
            labelCreatedDate.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelCreatedDate.ForeColor = Color.Black;
            labelCreatedDate.Location = new Point(281, 211);
            labelCreatedDate.Name = "labelCreatedDate";
            labelCreatedDate.Size = new Size(73, 20);
            labelCreatedDate.TabIndex = 32;
            labelCreatedDate.Text = "Ngày tạo";
            // 
            // comboBoxDuration
            // 
            comboBoxDuration.BackColor = SystemColors.Window;
            comboBoxDuration.Dock = DockStyle.Fill;
            comboBoxDuration.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDuration.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxDuration.FormattingEnabled = true;
            comboBoxDuration.Items.AddRange(new object[] { "12 tháng", "60 tháng" });
            comboBoxDuration.Location = new Point(281, 168);
            comboBoxDuration.Name = "comboBoxDuration";
            comboBoxDuration.Size = new Size(278, 28);
            comboBoxDuration.TabIndex = 48;
            // 
            // labelDuration
            // 
            labelDuration.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelDuration.AutoSize = true;
            labelDuration.BackColor = Color.Transparent;
            labelDuration.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelDuration.ForeColor = Color.Black;
            labelDuration.Location = new Point(281, 145);
            labelDuration.Name = "labelDuration";
            labelDuration.Size = new Size(58, 20);
            labelDuration.TabIndex = 31;
            labelDuration.Text = "Kỳ hạn";
            // 
            // comboBoxInterestRate
            // 
            comboBoxInterestRate.BackColor = SystemColors.Window;
            comboBoxInterestRate.Dock = DockStyle.Fill;
            comboBoxInterestRate.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxInterestRate.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxInterestRate.FormattingEnabled = true;
            comboBoxInterestRate.Items.AddRange(new object[] { "5%", "4.32%" });
            comboBoxInterestRate.Location = new Point(281, 102);
            comboBoxInterestRate.Name = "comboBoxInterestRate";
            comboBoxInterestRate.Size = new Size(278, 28);
            comboBoxInterestRate.TabIndex = 47;
            // 
            // labelInterestRate
            // 
            labelInterestRate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelInterestRate.AutoSize = true;
            labelInterestRate.BackColor = Color.Transparent;
            labelInterestRate.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelInterestRate.ForeColor = Color.Black;
            labelInterestRate.Location = new Point(281, 79);
            labelInterestRate.Name = "labelInterestRate";
            labelInterestRate.Size = new Size(66, 20);
            labelInterestRate.TabIndex = 30;
            labelInterestRate.Text = "Lãi suất";
            // 
            // textBoxTotalPrincipalAmount
            // 
            textBoxTotalPrincipalAmount.BackColor = SystemColors.InactiveCaption;
            textBoxTotalPrincipalAmount.Dock = DockStyle.Fill;
            textBoxTotalPrincipalAmount.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxTotalPrincipalAmount.Location = new Point(281, 36);
            textBoxTotalPrincipalAmount.Name = "textBoxTotalPrincipalAmount";
            textBoxTotalPrincipalAmount.Size = new Size(278, 28);
            textBoxTotalPrincipalAmount.TabIndex = 34;
            // 
            // labelTotalPrincipalAmount
            // 
            labelTotalPrincipalAmount.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelTotalPrincipalAmount.AutoSize = true;
            labelTotalPrincipalAmount.BackColor = Color.Transparent;
            labelTotalPrincipalAmount.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelTotalPrincipalAmount.ForeColor = Color.Black;
            labelTotalPrincipalAmount.Location = new Point(281, 13);
            labelTotalPrincipalAmount.Name = "labelTotalPrincipalAmount";
            labelTotalPrincipalAmount.Size = new Size(89, 20);
            labelTotalPrincipalAmount.TabIndex = 29;
            labelTotalPrincipalAmount.Text = "Số tiền gốc";
            // 
            // textBoxServiceID
            // 
            textBoxServiceID.BackColor = SystemColors.InactiveCaption;
            tableLayoutPanel2.SetColumnSpan(textBoxServiceID, 2);
            textBoxServiceID.Dock = DockStyle.Fill;
            textBoxServiceID.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxServiceID.Location = new Point(3, 300);
            textBoxServiceID.Name = "textBoxServiceID";
            textBoxServiceID.Size = new Size(266, 28);
            textBoxServiceID.TabIndex = 46;
            // 
            // labelServiceID
            // 
            labelServiceID.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelServiceID.AutoSize = true;
            labelServiceID.BackColor = Color.Transparent;
            labelServiceID.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelServiceID.ForeColor = Color.Black;
            labelServiceID.Location = new Point(3, 277);
            labelServiceID.Name = "labelServiceID";
            labelServiceID.Size = new Size(87, 20);
            labelServiceID.TabIndex = 11;
            labelServiceID.Text = "Mã dịch vụ";
            // 
            // comboBoxServiceTypeName
            // 
            comboBoxServiceTypeName.BackColor = SystemColors.Window;
            tableLayoutPanel2.SetColumnSpan(comboBoxServiceTypeName, 2);
            comboBoxServiceTypeName.Dock = DockStyle.Fill;
            comboBoxServiceTypeName.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxServiceTypeName.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxServiceTypeName.FormattingEnabled = true;
            comboBoxServiceTypeName.Items.AddRange(new object[] { "Tiết kiệm", "Vay vốn" });
            comboBoxServiceTypeName.Location = new Point(3, 234);
            comboBoxServiceTypeName.Name = "comboBoxServiceTypeName";
            comboBoxServiceTypeName.Size = new Size(266, 28);
            comboBoxServiceTypeName.TabIndex = 25;
            // 
            // labelServiceType
            // 
            labelServiceType.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelServiceType.AutoSize = true;
            labelServiceType.BackColor = Color.Transparent;
            labelServiceType.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelServiceType.ForeColor = Color.Black;
            labelServiceType.Location = new Point(3, 211);
            labelServiceType.Name = "labelServiceType";
            labelServiceType.Size = new Size(95, 20);
            labelServiceType.TabIndex = 12;
            labelServiceType.Text = "Loại dịch vụ";
            // 
            // textBoxAccountID
            // 
            textBoxAccountID.BackColor = SystemColors.InactiveCaption;
            tableLayoutPanel2.SetColumnSpan(textBoxAccountID, 2);
            textBoxAccountID.Dock = DockStyle.Fill;
            textBoxAccountID.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxAccountID.Location = new Point(3, 168);
            textBoxAccountID.Name = "textBoxAccountID";
            textBoxAccountID.Size = new Size(266, 28);
            textBoxAccountID.TabIndex = 24;
            // 
            // labelAccountID
            // 
            labelAccountID.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelAccountID.AutoSize = true;
            labelAccountID.BackColor = Color.Transparent;
            labelAccountID.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelAccountID.ForeColor = Color.Black;
            labelAccountID.Location = new Point(3, 145);
            labelAccountID.Name = "labelAccountID";
            labelAccountID.Size = new Size(103, 20);
            labelAccountID.TabIndex = 10;
            labelAccountID.Text = "Mã tài khoản";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(3, 79);
            label7.Name = "label7";
            label7.Size = new Size(107, 20);
            label7.TabIndex = 60;
            label7.Text = "Tên tài khoản";
            // 
            // textBoxAccountName
            // 
            textBoxAccountName.BackColor = SystemColors.InactiveCaption;
            tableLayoutPanel2.SetColumnSpan(textBoxAccountName, 2);
            textBoxAccountName.Dock = DockStyle.Fill;
            textBoxAccountName.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxAccountName.Location = new Point(3, 102);
            textBoxAccountName.Name = "textBoxAccountName";
            textBoxAccountName.Size = new Size(266, 28);
            textBoxAccountName.TabIndex = 61;
            // 
            // buttonAddService
            // 
            buttonAddService.BackColor = Color.DeepSkyBlue;
            buttonAddService.Dock = DockStyle.Fill;
            buttonAddService.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonAddService.ForeColor = Color.White;
            buttonAddService.Image = (Image)resources.GetObject("buttonAddService.Image");
            buttonAddService.ImageAlign = ContentAlignment.MiddleLeft;
            buttonAddService.Location = new Point(949, 3);
            buttonAddService.Name = "buttonAddService";
            tableLayoutPanel2.SetRowSpan(buttonAddService, 2);
            buttonAddService.Size = new Size(104, 60);
            buttonAddService.TabIndex = 62;
            buttonAddService.Text = "   Thêm";
            buttonAddService.UseVisualStyleBackColor = false;
            // 
            // buttonDeleteService
            // 
            buttonDeleteService.BackColor = Color.DeepSkyBlue;
            buttonDeleteService.Dock = DockStyle.Fill;
            buttonDeleteService.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonDeleteService.ForeColor = Color.White;
            buttonDeleteService.Image = (Image)resources.GetObject("buttonDeleteService.Image");
            buttonDeleteService.ImageAlign = ContentAlignment.MiddleLeft;
            buttonDeleteService.Location = new Point(949, 69);
            buttonDeleteService.Name = "buttonDeleteService";
            tableLayoutPanel2.SetRowSpan(buttonDeleteService, 2);
            buttonDeleteService.Size = new Size(104, 60);
            buttonDeleteService.TabIndex = 63;
            buttonDeleteService.Text = "   Xóa";
            buttonDeleteService.UseVisualStyleBackColor = false;
            // 
            // buttonEditService
            // 
            buttonEditService.BackColor = Color.DeepSkyBlue;
            buttonEditService.Dock = DockStyle.Fill;
            buttonEditService.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonEditService.ForeColor = Color.White;
            buttonEditService.Image = (Image)resources.GetObject("buttonEditService.Image");
            buttonEditService.ImageAlign = ContentAlignment.MiddleLeft;
            buttonEditService.Location = new Point(949, 135);
            buttonEditService.Name = "buttonEditService";
            tableLayoutPanel2.SetRowSpan(buttonEditService, 2);
            buttonEditService.Size = new Size(104, 60);
            buttonEditService.TabIndex = 64;
            buttonEditService.Text = "   Sửa";
            buttonEditService.UseVisualStyleBackColor = false;
            // 
            // buttonCancelService
            // 
            buttonCancelService.BackColor = Color.DeepSkyBlue;
            buttonCancelService.Dock = DockStyle.Fill;
            buttonCancelService.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonCancelService.ForeColor = Color.White;
            buttonCancelService.Image = (Image)resources.GetObject("buttonCancelService.Image");
            buttonCancelService.ImageAlign = ContentAlignment.MiddleLeft;
            buttonCancelService.Location = new Point(949, 201);
            buttonCancelService.Name = "buttonCancelService";
            tableLayoutPanel2.SetRowSpan(buttonCancelService, 2);
            buttonCancelService.Size = new Size(104, 60);
            buttonCancelService.TabIndex = 65;
            buttonCancelService.Text = "   Hủy";
            buttonCancelService.UseVisualStyleBackColor = false;
            // 
            // buttonSaveService
            // 
            buttonSaveService.BackColor = Color.DeepSkyBlue;
            buttonSaveService.Dock = DockStyle.Fill;
            buttonSaveService.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonSaveService.ForeColor = Color.White;
            buttonSaveService.Image = (Image)resources.GetObject("buttonSaveService.Image");
            buttonSaveService.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSaveService.Location = new Point(949, 267);
            buttonSaveService.Name = "buttonSaveService";
            tableLayoutPanel2.SetRowSpan(buttonSaveService, 2);
            buttonSaveService.Size = new Size(104, 69);
            buttonSaveService.TabIndex = 66;
            buttonSaveService.Text = "   Lưu";
            buttonSaveService.UseVisualStyleBackColor = false;
            // 
            // ApprovalStatus
            // 
            ApprovalStatus.HeaderText = "Trạng thái duyệt";
            ApprovalStatus.MinimumWidth = 6;
            ApprovalStatus.Name = "ApprovalStatus";
            // 
            // groupBox2
            // 
            tableLayoutPanel1.SetColumnSpan(groupBox2, 2);
            groupBox2.Controls.Add(tableLayoutPanel4);
            groupBox2.Controls.Add(panel3);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Font = new Font("Roboto SemiCondensed Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.ForeColor = SystemColors.HotTrack;
            groupBox2.Location = new Point(3, 379);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1126, 371);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Dữ liệu dịch vụ khách hàng";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 8;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.05357F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.6964283F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.21109F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.645726F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.7178249F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.7178249F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.7178249F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1.09020925F));
            tableLayoutPanel4.Controls.Add(buttonExportCSV, 6, 0);
            tableLayoutPanel4.Controls.Add(buttonExportExcel, 5, 0);
            tableLayoutPanel4.Controls.Add(buttonExportPDF, 4, 0);
            tableLayoutPanel4.Controls.Add(labelServiceFilter, 0, 0);
            tableLayoutPanel4.Controls.Add(buttonServiceSearch, 3, 0);
            tableLayoutPanel4.Controls.Add(labelServiceTypeFilter, 0, 1);
            tableLayoutPanel4.Controls.Add(comboBoxServiceTypeFilter, 0, 2);
            tableLayoutPanel4.Controls.Add(labelInterestRateFilter, 0, 3);
            tableLayoutPanel4.Controls.Add(comboBoxInterestRateFilter, 0, 4);
            tableLayoutPanel4.Controls.Add(dataGridViewServiceManagement, 2, 1);
            tableLayoutPanel4.Controls.Add(label8, 0, 7);
            tableLayoutPanel4.Controls.Add(label9, 1, 7);
            tableLayoutPanel4.Controls.Add(dateTimePickerFrom, 0, 8);
            tableLayoutPanel4.Controls.Add(dateTimePickeTo, 1, 8);
            tableLayoutPanel4.Controls.Add(labelDurationFilter, 1, 3);
            tableLayoutPanel4.Controls.Add(comboBoxDurationFilter, 1, 4);
            tableLayoutPanel4.Controls.Add(label4, 0, 5);
            tableLayoutPanel4.Controls.Add(label5, 1, 5);
            tableLayoutPanel4.Controls.Add(comboBoxStatusFilter, 1, 6);
            tableLayoutPanel4.Controls.Add(comboBoxApprovalStatusFilter, 0, 6);
            tableLayoutPanel4.Controls.Add(buttonFilterConfirm, 0, 9);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel3, 2, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 28);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 11;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 6.76470566F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 9.574111F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 6.17647076F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 7.05882359F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 6.76470566F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 9.705882F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 17.0588226F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 0.9069239F));
            tableLayoutPanel4.Size = new Size(1120, 340);
            tableLayoutPanel4.TabIndex = 8;
            // 
            // buttonExportCSV
            // 
            buttonExportCSV.Dock = DockStyle.Fill;
            buttonExportCSV.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonExportCSV.ForeColor = Color.FromArgb(25, 137, 14);
            buttonExportCSV.Image = (Image)resources.GetObject("buttonExportCSV.Image");
            buttonExportCSV.Location = new Point(944, 3);
            buttonExportCSV.Name = "buttonExportCSV";
            buttonExportCSV.Size = new Size(159, 45);
            buttonExportCSV.TabIndex = 57;
            buttonExportCSV.Text = "Xuất CSV";
            buttonExportCSV.TextAlign = ContentAlignment.MiddleLeft;
            buttonExportCSV.TextImageRelation = TextImageRelation.TextBeforeImage;
            buttonExportCSV.UseVisualStyleBackColor = true;
            // 
            // buttonExportExcel
            // 
            buttonExportExcel.Dock = DockStyle.Fill;
            buttonExportExcel.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonExportExcel.ForeColor = Color.FromArgb(20, 169, 6);
            buttonExportExcel.Image = (Image)resources.GetObject("buttonExportExcel.Image");
            buttonExportExcel.Location = new Point(779, 3);
            buttonExportExcel.Name = "buttonExportExcel";
            buttonExportExcel.Size = new Size(159, 45);
            buttonExportExcel.TabIndex = 56;
            buttonExportExcel.Text = "Xuất Excel";
            buttonExportExcel.TextAlign = ContentAlignment.MiddleLeft;
            buttonExportExcel.TextImageRelation = TextImageRelation.TextBeforeImage;
            buttonExportExcel.UseVisualStyleBackColor = true;
            // 
            // buttonExportPDF
            // 
            buttonExportPDF.Dock = DockStyle.Fill;
            buttonExportPDF.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonExportPDF.ForeColor = Color.FromArgb(207, 0, 0);
            buttonExportPDF.Image = (Image)resources.GetObject("buttonExportPDF.Image");
            buttonExportPDF.Location = new Point(614, 3);
            buttonExportPDF.Name = "buttonExportPDF";
            buttonExportPDF.Size = new Size(159, 45);
            buttonExportPDF.TabIndex = 55;
            buttonExportPDF.Text = "Xuất PDF";
            buttonExportPDF.TextAlign = ContentAlignment.MiddleLeft;
            buttonExportPDF.TextImageRelation = TextImageRelation.TextBeforeImage;
            buttonExportPDF.UseVisualStyleBackColor = true;
            // 
            // labelServiceFilter
            // 
            labelServiceFilter.Anchor = AnchorStyles.Bottom;
            labelServiceFilter.AutoSize = true;
            labelServiceFilter.BackColor = Color.Transparent;
            tableLayoutPanel4.SetColumnSpan(labelServiceFilter, 2);
            labelServiceFilter.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelServiceFilter.ForeColor = Color.Black;
            labelServiceFilter.ImageAlign = ContentAlignment.BottomCenter;
            labelServiceFilter.Location = new Point(85, 31);
            labelServiceFilter.Name = "labelServiceFilter";
            labelServiceFilter.Size = new Size(95, 20);
            labelServiceFilter.TabIndex = 26;
            labelServiceFilter.Text = "Lọc dịch vụ:";
            // 
            // buttonServiceSearch
            // 
            buttonServiceSearch.BackColor = SystemColors.HotTrack;
            buttonServiceSearch.Dock = DockStyle.Fill;
            buttonServiceSearch.ForeColor = Color.White;
            buttonServiceSearch.Image = (Image)resources.GetObject("buttonServiceSearch.Image");
            buttonServiceSearch.Location = new Point(551, 3);
            buttonServiceSearch.Name = "buttonServiceSearch";
            buttonServiceSearch.Size = new Size(57, 45);
            buttonServiceSearch.TabIndex = 6;
            buttonServiceSearch.UseVisualStyleBackColor = false;
            // 
            // labelServiceTypeFilter
            // 
            labelServiceTypeFilter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelServiceTypeFilter.AutoSize = true;
            labelServiceTypeFilter.BackColor = Color.Transparent;
            labelServiceTypeFilter.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelServiceTypeFilter.ForeColor = Color.Black;
            labelServiceTypeFilter.Location = new Point(3, 54);
            labelServiceTypeFilter.Name = "labelServiceTypeFilter";
            labelServiceTypeFilter.Size = new Size(95, 20);
            labelServiceTypeFilter.TabIndex = 27;
            labelServiceTypeFilter.Text = "Loại dịch vụ";
            // 
            // comboBoxServiceTypeFilter
            // 
            comboBoxServiceTypeFilter.BackColor = SystemColors.Window;
            tableLayoutPanel4.SetColumnSpan(comboBoxServiceTypeFilter, 2);
            comboBoxServiceTypeFilter.Dock = DockStyle.Fill;
            comboBoxServiceTypeFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxServiceTypeFilter.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxServiceTypeFilter.FormattingEnabled = true;
            comboBoxServiceTypeFilter.Items.AddRange(new object[] { "Không áp dụng", "Tiết kiệm", "Vay vốn" });
            comboBoxServiceTypeFilter.Location = new Point(3, 77);
            comboBoxServiceTypeFilter.Name = "comboBoxServiceTypeFilter";
            comboBoxServiceTypeFilter.Size = new Size(260, 28);
            comboBoxServiceTypeFilter.TabIndex = 28;
            // 
            // labelInterestRateFilter
            // 
            labelInterestRateFilter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelInterestRateFilter.AutoSize = true;
            labelInterestRateFilter.BackColor = Color.Transparent;
            labelInterestRateFilter.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelInterestRateFilter.ForeColor = Color.Black;
            labelInterestRateFilter.Location = new Point(3, 107);
            labelInterestRateFilter.Name = "labelInterestRateFilter";
            labelInterestRateFilter.Size = new Size(66, 20);
            labelInterestRateFilter.TabIndex = 32;
            labelInterestRateFilter.Text = "Lãi suất";
            // 
            // comboBoxInterestRateFilter
            // 
            comboBoxInterestRateFilter.Dock = DockStyle.Fill;
            comboBoxInterestRateFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxInterestRateFilter.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxInterestRateFilter.FormattingEnabled = true;
            comboBoxInterestRateFilter.Items.AddRange(new object[] { "Không áp dụng" });
            comboBoxInterestRateFilter.Location = new Point(3, 130);
            comboBoxInterestRateFilter.Name = "comboBoxInterestRateFilter";
            comboBoxInterestRateFilter.Size = new Size(129, 28);
            comboBoxInterestRateFilter.TabIndex = 47;
            // 
            // dataGridViewServiceManagement
            // 
            dataGridViewServiceManagement.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewServiceManagement.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewServiceManagement.BackgroundColor = Color.White;
            dataGridViewServiceManagement.BorderStyle = BorderStyle.None;
            dataGridViewServiceManagement.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewServiceManagement.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridViewServiceManagement.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewServiceManagement.ColumnHeadersHeight = 29;
            dataGridViewServiceManagement.Columns.AddRange(new DataGridViewColumn[] { CustomerID, AccountName, AccountID, ServiceTypeName, ServiceID, TotalPrincipalAmount, InterestRate, Duration, CreatedDate, ApplicableDate, EndDate, HandledBy, ApprovalStatus, Status });
            tableLayoutPanel4.SetColumnSpan(dataGridViewServiceManagement, 6);
            dataGridViewServiceManagement.Dock = DockStyle.Fill;
            dataGridViewServiceManagement.EnableHeadersVisualStyles = false;
            dataGridViewServiceManagement.GridColor = Color.White;
            dataGridViewServiceManagement.Location = new Point(269, 54);
            dataGridViewServiceManagement.Name = "dataGridViewServiceManagement";
            dataGridViewServiceManagement.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewServiceManagement.RowHeadersVisible = false;
            dataGridViewServiceManagement.RowHeadersWidth = 51;
            tableLayoutPanel4.SetRowSpan(dataGridViewServiceManagement, 10);
            dataGridViewServiceManagement.Size = new Size(848, 283);
            dataGridViewServiceManagement.TabIndex = 50;
            // 
            // CustomerID
            // 
            CustomerID.HeaderText = "Mã khách hàng";
            CustomerID.MinimumWidth = 6;
            CustomerID.Name = "CustomerID";
            // 
            // AccountName
            // 
            AccountName.HeaderText = "Tên tài khoản";
            AccountName.MinimumWidth = 6;
            AccountName.Name = "AccountName";
            // 
            // AccountID
            // 
            AccountID.HeaderText = "Mã tài khoản";
            AccountID.MinimumWidth = 6;
            AccountID.Name = "AccountID";
            // 
            // ServiceTypeName
            // 
            ServiceTypeName.HeaderText = "Loại dịch vụ";
            ServiceTypeName.MinimumWidth = 6;
            ServiceTypeName.Name = "ServiceTypeName";
            // 
            // ServiceID
            // 
            ServiceID.HeaderText = "Mã dịch vụ";
            ServiceID.MinimumWidth = 6;
            ServiceID.Name = "ServiceID";
            // 
            // TotalPrincipalAmount
            // 
            TotalPrincipalAmount.HeaderText = "Số tiền gốc";
            TotalPrincipalAmount.MinimumWidth = 6;
            TotalPrincipalAmount.Name = "TotalPrincipalAmount";
            // 
            // InterestRate
            // 
            InterestRate.HeaderText = "Lãi suất";
            InterestRate.MinimumWidth = 6;
            InterestRate.Name = "InterestRate";
            // 
            // Duration
            // 
            Duration.HeaderText = "Kỳ hạn";
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
            // EndDate
            // 
            EndDate.HeaderText = "Ngày kết thúc";
            EndDate.MinimumWidth = 6;
            EndDate.Name = "EndDate";
            // 
            // HandledBy
            // 
            HandledBy.HeaderText = "Nhân viên xử lý";
            HandledBy.MinimumWidth = 6;
            HandledBy.Name = "HandledBy";
            // 
            // Status
            // 
            Status.HeaderText = "Trạng thái";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(3, 222);
            label8.Name = "label8";
            label8.Size = new Size(28, 20);
            label8.TabIndex = 58;
            label8.Text = "Từ";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(138, 222);
            label9.Name = "label9";
            label9.Size = new Size(38, 20);
            label9.TabIndex = 59;
            label9.Text = "Đến";
            // 
            // dateTimePickerFrom
            // 
            dateTimePickerFrom.Dock = DockStyle.Fill;
            dateTimePickerFrom.Font = new Font("Roboto", 10.2F);
            dateTimePickerFrom.Location = new Point(3, 245);
            dateTimePickerFrom.Name = "dateTimePickerFrom";
            dateTimePickerFrom.Size = new Size(129, 28);
            dateTimePickerFrom.TabIndex = 60;
            // 
            // dateTimePickeTo
            // 
            dateTimePickeTo.Dock = DockStyle.Fill;
            dateTimePickeTo.Font = new Font("Roboto", 10.2F);
            dateTimePickeTo.Location = new Point(138, 245);
            dateTimePickeTo.Name = "dateTimePickeTo";
            dateTimePickeTo.Size = new Size(125, 28);
            dateTimePickeTo.TabIndex = 61;
            // 
            // labelDurationFilter
            // 
            labelDurationFilter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelDurationFilter.AutoSize = true;
            labelDurationFilter.BackColor = Color.Transparent;
            labelDurationFilter.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelDurationFilter.ForeColor = Color.Black;
            labelDurationFilter.Location = new Point(138, 107);
            labelDurationFilter.Name = "labelDurationFilter";
            labelDurationFilter.Size = new Size(55, 20);
            labelDurationFilter.TabIndex = 48;
            labelDurationFilter.Text = "Kì hạn";
            // 
            // comboBoxDurationFilter
            // 
            comboBoxDurationFilter.Dock = DockStyle.Fill;
            comboBoxDurationFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDurationFilter.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxDurationFilter.FormattingEnabled = true;
            comboBoxDurationFilter.Items.AddRange(new object[] { "Không áp dụng", "3 tháng", "6 tháng", "12 tháng" });
            comboBoxDurationFilter.Location = new Point(138, 130);
            comboBoxDurationFilter.Name = "comboBoxDurationFilter";
            comboBoxDurationFilter.Size = new Size(125, 28);
            comboBoxDurationFilter.TabIndex = 49;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(3, 165);
            label4.Name = "label4";
            label4.Size = new Size(126, 20);
            label4.TabIndex = 51;
            label4.Text = "Trạng thái duyệt";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(138, 165);
            label5.Name = "label5";
            label5.Size = new Size(82, 20);
            label5.TabIndex = 52;
            label5.Text = "Trạng thái";
            // 
            // comboBoxStatusFilter
            // 
            comboBoxStatusFilter.BackColor = SystemColors.Window;
            comboBoxStatusFilter.Dock = DockStyle.Fill;
            comboBoxStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStatusFilter.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxStatusFilter.FormattingEnabled = true;
            comboBoxStatusFilter.Items.AddRange(new object[] { "Không áp dụng", "Tiết kiệm", "Vay vốn" });
            comboBoxStatusFilter.Location = new Point(138, 188);
            comboBoxStatusFilter.Name = "comboBoxStatusFilter";
            comboBoxStatusFilter.Size = new Size(125, 28);
            comboBoxStatusFilter.TabIndex = 54;
            // 
            // comboBoxApprovalStatusFilter
            // 
            comboBoxApprovalStatusFilter.BackColor = SystemColors.Window;
            comboBoxApprovalStatusFilter.Dock = DockStyle.Fill;
            comboBoxApprovalStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxApprovalStatusFilter.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxApprovalStatusFilter.FormattingEnabled = true;
            comboBoxApprovalStatusFilter.Items.AddRange(new object[] { "Không áp dụng", "Tiết kiệm", "Vay vốn" });
            comboBoxApprovalStatusFilter.Location = new Point(3, 188);
            comboBoxApprovalStatusFilter.Name = "comboBoxApprovalStatusFilter";
            comboBoxApprovalStatusFilter.Size = new Size(129, 28);
            comboBoxApprovalStatusFilter.TabIndex = 53;
            // 
            // buttonFilterConfirm
            // 
            tableLayoutPanel4.SetColumnSpan(buttonFilterConfirm, 2);
            buttonFilterConfirm.Dock = DockStyle.Fill;
            buttonFilterConfirm.Image = (Image)resources.GetObject("buttonFilterConfirm.Image");
            buttonFilterConfirm.Location = new Point(3, 278);
            buttonFilterConfirm.Name = "buttonFilterConfirm";
            buttonFilterConfirm.Size = new Size(260, 52);
            buttonFilterConfirm.TabIndex = 62;
            buttonFilterConfirm.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(textBoxServiceSearch, 0, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(269, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 18.75F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 62.5F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 18.75F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(276, 45);
            tableLayoutPanel3.TabIndex = 63;
            // 
            // textBoxServiceSearch
            // 
            textBoxServiceSearch.Dock = DockStyle.Fill;
            textBoxServiceSearch.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxServiceSearch.Location = new Point(3, 7);
            textBoxServiceSearch.Name = "textBoxServiceSearch";
            textBoxServiceSearch.PlaceholderText = "Tìm kiếm . . .";
            tableLayoutPanel3.SetRowSpan(textBoxServiceSearch, 3);
            textBoxServiceSearch.Size = new Size(270, 32);
            textBoxServiceSearch.TabIndex = 2;
            textBoxServiceSearch.WordWrap = false;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.HotTrack;
            panel3.Location = new Point(269, 9);
            panel3.Name = "panel3";
            panel3.Size = new Size(450, 5);
            panel3.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(groupBox2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1132, 753);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // UC_ServiceManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "UC_ServiceManagement";
            Size = new Size(1132, 753);
            groupBox1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox2.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewServiceManagement).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox2;
        private TableLayoutPanel tableLayoutPanel4;
        private Button buttonExportCSV;
        private Button buttonExportExcel;
        private Button buttonExportPDF;
        private Label labelServiceFilter;
        private Button buttonServiceSearch;
        private Label labelServiceTypeFilter;
        private ComboBox comboBoxServiceTypeFilter;
        private Label labelInterestRateFilter;
        private ComboBox comboBoxInterestRateFilter;
        private DataGridView dataGridViewServiceManagement;
        private DataGridViewTextBoxColumn CustomerID;
        private DataGridViewTextBoxColumn AccountName;
        private DataGridViewTextBoxColumn AccountID;
        private DataGridViewTextBoxColumn ServiceTypeName;
        private DataGridViewTextBoxColumn ServiceID;
        private DataGridViewTextBoxColumn TotalPrincipalAmount;
        private DataGridViewTextBoxColumn InterestRate;
        private DataGridViewTextBoxColumn Duration;
        private DataGridViewTextBoxColumn CreatedDate;
        private DataGridViewTextBoxColumn ApplicableDate;
        private DataGridViewTextBoxColumn EndDate;
        private DataGridViewTextBoxColumn HandledBy;
        private DataGridViewTextBoxColumn ApprovalStatus;
        private DataGridViewTextBoxColumn Status;
        private Label label8;
        private Label label9;
        private DateTimePicker dateTimePickerFrom;
        private DateTimePicker dateTimePickeTo;
        private Label labelDurationFilter;
        private ComboBox comboBoxDurationFilter;
        private Label label4;
        private Label label5;
        private ComboBox comboBoxStatusFilter;
        private ComboBox comboBoxApprovalStatusFilter;
        private Button buttonFilterConfirm;
        private TableLayoutPanel tableLayoutPanel3;
        private TextBox textBoxServiceSearch;
        private Panel panel3;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label6;
        private TextBox textBoxCustomerID;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Button buttonLoanPrepayment;
        private Button buttonCancelSavings;
        private TextBox textBoxStatus;
        private Label label3;
        private TextBox textBoxApprovalStatus;
        private Label labelApprovalStatus;
        private TextBox textBoxHandledBy;
        private Label labelHandledBy;
        private DateTimePicker dateTimePickerEndDate;
        private Label label1;
        private DateTimePicker dateTimePickerApplicableDate;
        private Label label2;
        private DateTimePicker dateTimePickerCreatedDate;
        private Label labelCreatedDate;
        private ComboBox comboBoxDuration;
        private Label labelDuration;
        private ComboBox comboBoxInterestRate;
        private Label labelInterestRate;
        private TextBox textBoxTotalPrincipalAmount;
        private Label labelTotalPrincipalAmount;
        private TextBox textBoxServiceID;
        private Label labelServiceID;
        private ComboBox comboBoxServiceTypeName;
        private Label labelServiceType;
        private TextBox textBoxAccountID;
        private Label labelAccountID;
        private Label label7;
        private TextBox textBoxAccountName;
        private Button buttonAddService;
        private Button buttonDeleteService;
        private Button buttonEditService;
        private Button buttonCancelService;
        private Button buttonSaveService;
    }
}
