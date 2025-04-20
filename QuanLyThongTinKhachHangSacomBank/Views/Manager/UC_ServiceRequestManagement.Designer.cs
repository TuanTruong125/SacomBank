namespace QuanLyThongTinKhachHangSacomBank.Views.Manager
{
    partial class UC_ServiceRequestManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_ServiceRequestManagement));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            buttonApproveService = new Button();
            buttonDeclineService = new Button();
            labelDurationFilter = new Label();
            comboBoxDurationFilter = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            comboBoxApprovalStatusFilter = new ComboBox();
            panel3 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            label6 = new Label();
            textBoxCustomerID = new TextBox();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
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
            label3 = new Label();
            labelApprovalStatus = new Label();
            textBoxHandledBy = new TextBox();
            labelHandledBy = new Label();
            dateTimePickerEndDate = new DateTimePicker();
            label1 = new Label();
            dateTimePickerApplicableDate = new DateTimePicker();
            label2 = new Label();
            dateTimePickerCreatedDate = new DateTimePicker();
            labelCreatedDate = new Label();
            labelDuration = new Label();
            comboBoxDuration = new ComboBox();
            labelInterestRate = new Label();
            textBoxInterestRate = new TextBox();
            textBoxTotalInterestAmount = new TextBox();
            label10 = new Label();
            label11 = new Label();
            richTextBoxServiceDescription = new RichTextBox();
            comboBoxApprovalStatus = new ComboBox();
            comboBoxServiceStatus = new ComboBox();
            panel1 = new Panel();
            groupBox2 = new GroupBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            dataGridViewServiceRequestManagement = new DataGridView();
            CustomerID = new DataGridViewTextBoxColumn();
            AccountName = new DataGridViewTextBoxColumn();
            AccountID = new DataGridViewTextBoxColumn();
            ServiceTypeName = new DataGridViewTextBoxColumn();
            ServiceID = new DataGridViewTextBoxColumn();
            TotalPrincipalAmount = new DataGridViewTextBoxColumn();
            ServiceDescription = new DataGridViewTextBoxColumn();
            Duration = new DataGridViewTextBoxColumn();
            InterestRate = new DataGridViewTextBoxColumn();
            TotalInterestAmount = new DataGridViewTextBoxColumn();
            CreatedDate = new DataGridViewTextBoxColumn();
            ApplicableDate = new DataGridViewTextBoxColumn();
            EndDate = new DataGridViewTextBoxColumn();
            HandledBy = new DataGridViewTextBoxColumn();
            ApprovalStatus = new DataGridViewTextBoxColumn();
            ServiceStatus = new DataGridViewTextBoxColumn();
            buttonExportCSV = new Button();
            buttonExportExcel = new Button();
            buttonExportPDF = new Button();
            labelServiceFilter = new Label();
            buttonServiceSearch = new Button();
            labelServiceTypeFilter = new Label();
            comboBoxServiceTypeFilter = new ComboBox();
            label8 = new Label();
            label9 = new Label();
            dateTimePickerFrom = new DateTimePicker();
            dateTimePickerTo = new DateTimePicker();
            comboBoxStatusFilter = new ComboBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            textBoxServiceSearch = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox2.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewServiceRequestManagement).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // buttonApproveService
            // 
            buttonApproveService.BackColor = Color.DeepSkyBlue;
            buttonApproveService.Dock = DockStyle.Fill;
            buttonApproveService.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonApproveService.ForeColor = Color.White;
            buttonApproveService.Image = (Image)resources.GetObject("buttonApproveService.Image");
            buttonApproveService.ImageAlign = ContentAlignment.MiddleLeft;
            buttonApproveService.Location = new Point(920, 69);
            buttonApproveService.Name = "buttonApproveService";
            tableLayoutPanel2.SetRowSpan(buttonApproveService, 2);
            buttonApproveService.Size = new Size(137, 60);
            buttonApproveService.TabIndex = 42;
            buttonApproveService.Text = "   Duyệt";
            buttonApproveService.UseVisualStyleBackColor = false;
            buttonApproveService.Click += buttonApproveService_Click;
            // 
            // buttonDeclineService
            // 
            buttonDeclineService.BackColor = Color.DeepSkyBlue;
            buttonDeclineService.Dock = DockStyle.Fill;
            buttonDeclineService.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonDeclineService.ForeColor = Color.White;
            buttonDeclineService.Image = (Image)resources.GetObject("buttonDeclineService.Image");
            buttonDeclineService.ImageAlign = ContentAlignment.MiddleLeft;
            buttonDeclineService.Location = new Point(920, 201);
            buttonDeclineService.Name = "buttonDeclineService";
            tableLayoutPanel2.SetRowSpan(buttonDeclineService, 2);
            buttonDeclineService.Size = new Size(137, 60);
            buttonDeclineService.TabIndex = 43;
            buttonDeclineService.Text = "   Từ chối";
            buttonDeclineService.UseVisualStyleBackColor = false;
            buttonDeclineService.Click += buttonDeclineService_Click;
            // 
            // labelDurationFilter
            // 
            labelDurationFilter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelDurationFilter.AutoSize = true;
            labelDurationFilter.BackColor = Color.Transparent;
            labelDurationFilter.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelDurationFilter.ForeColor = Color.Black;
            labelDurationFilter.Location = new Point(3, 107);
            labelDurationFilter.Name = "labelDurationFilter";
            labelDurationFilter.Size = new Size(55, 20);
            labelDurationFilter.TabIndex = 48;
            labelDurationFilter.Text = "Kì hạn";
            // 
            // comboBoxDurationFilter
            // 
            tableLayoutPanel4.SetColumnSpan(comboBoxDurationFilter, 2);
            comboBoxDurationFilter.Dock = DockStyle.Fill;
            comboBoxDurationFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDurationFilter.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxDurationFilter.FormattingEnabled = true;
            comboBoxDurationFilter.Items.AddRange(new object[] { "Không áp dụng", "12 tháng", "24 tháng", "36 tháng" });
            comboBoxDurationFilter.Location = new Point(3, 130);
            comboBoxDurationFilter.Name = "comboBoxDurationFilter";
            comboBoxDurationFilter.Size = new Size(260, 28);
            comboBoxDurationFilter.TabIndex = 49;
            comboBoxDurationFilter.SelectedIndexChanged += comboBoxDurationFilter_SelectedIndexChanged;
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
            // comboBoxApprovalStatusFilter
            // 
            comboBoxApprovalStatusFilter.BackColor = SystemColors.Window;
            comboBoxApprovalStatusFilter.Dock = DockStyle.Fill;
            comboBoxApprovalStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxApprovalStatusFilter.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxApprovalStatusFilter.FormattingEnabled = true;
            comboBoxApprovalStatusFilter.Items.AddRange(new object[] { "Không áp dụng", "Chờ duyệt", "Đã duyệt", "Từ chối" });
            comboBoxApprovalStatusFilter.Location = new Point(3, 188);
            comboBoxApprovalStatusFilter.Name = "comboBoxApprovalStatusFilter";
            comboBoxApprovalStatusFilter.Size = new Size(129, 28);
            comboBoxApprovalStatusFilter.TabIndex = 53;
            comboBoxApprovalStatusFilter.SelectedIndexChanged += comboBoxApprovalStatusFilter_SelectedIndexChanged;
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
            tableLayoutPanel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            tableLayoutPanel1.SetColumnSpan(groupBox1, 2);
            groupBox1.Controls.Add(tableLayoutPanel2);
            groupBox1.Controls.Add(panel1);
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
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 10;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.7264881F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.887023F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.526377261F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.5714283F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.4464283F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.3035717F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.714285731F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.8035714F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.7678576F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.925893F));
            tableLayoutPanel2.Controls.Add(label6, 0, 0);
            tableLayoutPanel2.Controls.Add(textBoxCustomerID, 0, 1);
            tableLayoutPanel2.Controls.Add(panel2, 7, 0);
            tableLayoutPanel2.Controls.Add(pictureBox1, 9, 0);
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
            tableLayoutPanel2.Controls.Add(label3, 4, 8);
            tableLayoutPanel2.Controls.Add(labelApprovalStatus, 4, 6);
            tableLayoutPanel2.Controls.Add(textBoxHandledBy, 4, 5);
            tableLayoutPanel2.Controls.Add(labelHandledBy, 4, 4);
            tableLayoutPanel2.Controls.Add(dateTimePickerEndDate, 4, 3);
            tableLayoutPanel2.Controls.Add(label1, 4, 2);
            tableLayoutPanel2.Controls.Add(dateTimePickerApplicableDate, 4, 1);
            tableLayoutPanel2.Controls.Add(label2, 4, 0);
            tableLayoutPanel2.Controls.Add(dateTimePickerCreatedDate, 3, 9);
            tableLayoutPanel2.Controls.Add(labelCreatedDate, 3, 8);
            tableLayoutPanel2.Controls.Add(labelDuration, 3, 2);
            tableLayoutPanel2.Controls.Add(comboBoxDuration, 3, 3);
            tableLayoutPanel2.Controls.Add(labelInterestRate, 3, 4);
            tableLayoutPanel2.Controls.Add(textBoxInterestRate, 3, 5);
            tableLayoutPanel2.Controls.Add(textBoxTotalInterestAmount, 3, 7);
            tableLayoutPanel2.Controls.Add(label10, 3, 6);
            tableLayoutPanel2.Controls.Add(label11, 5, 0);
            tableLayoutPanel2.Controls.Add(richTextBoxServiceDescription, 5, 1);
            tableLayoutPanel2.Controls.Add(comboBoxApprovalStatus, 4, 7);
            tableLayoutPanel2.Controls.Add(comboBoxServiceStatus, 4, 9);
            tableLayoutPanel2.Controls.Add(buttonApproveService, 8, 2);
            tableLayoutPanel2.Controls.Add(buttonDeclineService, 8, 6);
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
            tableLayoutPanel2.Size = new Size(1120, 339);
            tableLayoutPanel2.TabIndex = 47;
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
            textBoxCustomerID.Size = new Size(247, 28);
            textBoxCustomerID.TabIndex = 23;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.HotTrack;
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(911, 3);
            panel2.Name = "panel2";
            tableLayoutPanel2.SetRowSpan(panel2, 10);
            panel2.Size = new Size(3, 333);
            panel2.TabIndex = 39;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1063, 3);
            pictureBox1.Name = "pictureBox1";
            tableLayoutPanel2.SetRowSpan(pictureBox1, 10);
            pictureBox1.Size = new Size(54, 333);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 45;
            pictureBox1.TabStop = false;
            // 
            // textBoxTotalPrincipalAmount
            // 
            textBoxTotalPrincipalAmount.BackColor = SystemColors.InactiveCaption;
            textBoxTotalPrincipalAmount.Dock = DockStyle.Fill;
            textBoxTotalPrincipalAmount.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxTotalPrincipalAmount.Location = new Point(261, 36);
            textBoxTotalPrincipalAmount.Name = "textBoxTotalPrincipalAmount";
            textBoxTotalPrincipalAmount.Size = new Size(202, 28);
            textBoxTotalPrincipalAmount.TabIndex = 34;
            // 
            // labelTotalPrincipalAmount
            // 
            labelTotalPrincipalAmount.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelTotalPrincipalAmount.AutoSize = true;
            labelTotalPrincipalAmount.BackColor = Color.Transparent;
            labelTotalPrincipalAmount.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelTotalPrincipalAmount.ForeColor = Color.Black;
            labelTotalPrincipalAmount.Location = new Point(261, 13);
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
            textBoxServiceID.Size = new Size(247, 28);
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
            comboBoxServiceTypeName.Size = new Size(247, 28);
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
            textBoxAccountID.Size = new Size(247, 28);
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
            textBoxAccountName.Size = new Size(247, 28);
            textBoxAccountName.TabIndex = 61;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(469, 277);
            label3.Name = "label3";
            label3.Size = new Size(82, 20);
            label3.TabIndex = 55;
            label3.Text = "Trạng thái";
            // 
            // labelApprovalStatus
            // 
            labelApprovalStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelApprovalStatus.AutoSize = true;
            labelApprovalStatus.BackColor = Color.Transparent;
            labelApprovalStatus.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelApprovalStatus.ForeColor = Color.Black;
            labelApprovalStatus.Location = new Point(469, 211);
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
            textBoxHandledBy.Location = new Point(469, 168);
            textBoxHandledBy.Name = "textBoxHandledBy";
            textBoxHandledBy.Size = new Size(223, 28);
            textBoxHandledBy.TabIndex = 27;
            // 
            // labelHandledBy
            // 
            labelHandledBy.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelHandledBy.AutoSize = true;
            labelHandledBy.BackColor = Color.Transparent;
            labelHandledBy.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelHandledBy.ForeColor = Color.Black;
            labelHandledBy.Location = new Point(469, 145);
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
            dateTimePickerEndDate.Format = DateTimePickerFormat.Short;
            dateTimePickerEndDate.Location = new Point(469, 102);
            dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            dateTimePickerEndDate.Size = new Size(223, 28);
            dateTimePickerEndDate.TabIndex = 52;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(469, 79);
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
            dateTimePickerApplicableDate.Format = DateTimePickerFormat.Short;
            dateTimePickerApplicableDate.Location = new Point(469, 36);
            dateTimePickerApplicableDate.Name = "dateTimePickerApplicableDate";
            dateTimePickerApplicableDate.Size = new Size(223, 28);
            dateTimePickerApplicableDate.TabIndex = 54;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(469, 13);
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
            dateTimePickerCreatedDate.Format = DateTimePickerFormat.Short;
            dateTimePickerCreatedDate.Location = new Point(261, 300);
            dateTimePickerCreatedDate.Name = "dateTimePickerCreatedDate";
            dateTimePickerCreatedDate.Size = new Size(202, 28);
            dateTimePickerCreatedDate.TabIndex = 49;
            // 
            // labelCreatedDate
            // 
            labelCreatedDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelCreatedDate.AutoSize = true;
            labelCreatedDate.BackColor = Color.Transparent;
            labelCreatedDate.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelCreatedDate.ForeColor = Color.Black;
            labelCreatedDate.Location = new Point(261, 277);
            labelCreatedDate.Name = "labelCreatedDate";
            labelCreatedDate.Size = new Size(73, 20);
            labelCreatedDate.TabIndex = 32;
            labelCreatedDate.Text = "Ngày tạo";
            // 
            // labelDuration
            // 
            labelDuration.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelDuration.AutoSize = true;
            labelDuration.BackColor = Color.Transparent;
            labelDuration.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelDuration.ForeColor = Color.Black;
            labelDuration.Location = new Point(261, 79);
            labelDuration.Name = "labelDuration";
            labelDuration.Size = new Size(58, 20);
            labelDuration.TabIndex = 31;
            labelDuration.Text = "Kỳ hạn";
            // 
            // comboBoxDuration
            // 
            comboBoxDuration.BackColor = SystemColors.Window;
            comboBoxDuration.Dock = DockStyle.Fill;
            comboBoxDuration.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDuration.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxDuration.FormattingEnabled = true;
            comboBoxDuration.Items.AddRange(new object[] { "12 tháng", "24 tháng", "36 tháng" });
            comboBoxDuration.Location = new Point(261, 102);
            comboBoxDuration.Name = "comboBoxDuration";
            comboBoxDuration.Size = new Size(202, 28);
            comboBoxDuration.TabIndex = 48;
            // 
            // labelInterestRate
            // 
            labelInterestRate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelInterestRate.AutoSize = true;
            labelInterestRate.BackColor = Color.Transparent;
            labelInterestRate.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelInterestRate.ForeColor = Color.Black;
            labelInterestRate.Location = new Point(261, 145);
            labelInterestRate.Name = "labelInterestRate";
            labelInterestRate.Size = new Size(66, 20);
            labelInterestRate.TabIndex = 30;
            labelInterestRate.Text = "Lãi suất";
            // 
            // textBoxInterestRate
            // 
            textBoxInterestRate.BackColor = SystemColors.InactiveCaption;
            textBoxInterestRate.Dock = DockStyle.Fill;
            textBoxInterestRate.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxInterestRate.Location = new Point(261, 168);
            textBoxInterestRate.Name = "textBoxInterestRate";
            textBoxInterestRate.Size = new Size(202, 28);
            textBoxInterestRate.TabIndex = 67;
            // 
            // textBoxTotalInterestAmount
            // 
            textBoxTotalInterestAmount.BackColor = SystemColors.InactiveCaption;
            textBoxTotalInterestAmount.Dock = DockStyle.Fill;
            textBoxTotalInterestAmount.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxTotalInterestAmount.Location = new Point(261, 234);
            textBoxTotalInterestAmount.Name = "textBoxTotalInterestAmount";
            textBoxTotalInterestAmount.Size = new Size(202, 28);
            textBoxTotalInterestAmount.TabIndex = 68;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(261, 211);
            label10.Name = "label10";
            label10.Size = new Size(123, 20);
            label10.TabIndex = 69;
            label10.Text = "Tổng lãi dự kiến";
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Bottom;
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            label11.ForeColor = Color.Black;
            label11.Location = new Point(761, 13);
            label11.Name = "label11";
            label11.Size = new Size(73, 20);
            label11.TabIndex = 70;
            label11.Text = "Nội dung";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // richTextBoxServiceDescription
            // 
            richTextBoxServiceDescription.Dock = DockStyle.Fill;
            richTextBoxServiceDescription.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBoxServiceDescription.Location = new Point(698, 36);
            richTextBoxServiceDescription.Name = "richTextBoxServiceDescription";
            tableLayoutPanel2.SetRowSpan(richTextBoxServiceDescription, 9);
            richTextBoxServiceDescription.Size = new Size(199, 300);
            richTextBoxServiceDescription.TabIndex = 71;
            richTextBoxServiceDescription.Text = "";
            // 
            // comboBoxApprovalStatus
            // 
            comboBoxApprovalStatus.BackColor = SystemColors.Window;
            comboBoxApprovalStatus.Dock = DockStyle.Fill;
            comboBoxApprovalStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxApprovalStatus.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxApprovalStatus.FormattingEnabled = true;
            comboBoxApprovalStatus.Items.AddRange(new object[] { "Tiết kiệm", "Vay vốn" });
            comboBoxApprovalStatus.Location = new Point(469, 234);
            comboBoxApprovalStatus.Name = "comboBoxApprovalStatus";
            comboBoxApprovalStatus.Size = new Size(223, 28);
            comboBoxApprovalStatus.TabIndex = 72;
            // 
            // comboBoxServiceStatus
            // 
            comboBoxServiceStatus.BackColor = SystemColors.Window;
            comboBoxServiceStatus.Dock = DockStyle.Fill;
            comboBoxServiceStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxServiceStatus.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxServiceStatus.FormattingEnabled = true;
            comboBoxServiceStatus.Items.AddRange(new object[] { "Tiết kiệm", "Vay vốn" });
            comboBoxServiceStatus.Location = new Point(469, 300);
            comboBoxServiceStatus.Name = "comboBoxServiceStatus";
            comboBoxServiceStatus.Size = new Size(223, 28);
            comboBoxServiceStatus.TabIndex = 73;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.HotTrack;
            panel1.Location = new Point(178, 11);
            panel1.Name = "panel1";
            panel1.Size = new Size(165, 5);
            panel1.TabIndex = 46;
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
            tableLayoutPanel4.Controls.Add(dataGridViewServiceRequestManagement, 2, 1);
            tableLayoutPanel4.Controls.Add(buttonExportCSV, 6, 0);
            tableLayoutPanel4.Controls.Add(buttonExportExcel, 5, 0);
            tableLayoutPanel4.Controls.Add(buttonExportPDF, 4, 0);
            tableLayoutPanel4.Controls.Add(labelServiceFilter, 0, 0);
            tableLayoutPanel4.Controls.Add(buttonServiceSearch, 3, 0);
            tableLayoutPanel4.Controls.Add(labelServiceTypeFilter, 0, 1);
            tableLayoutPanel4.Controls.Add(comboBoxServiceTypeFilter, 0, 2);
            tableLayoutPanel4.Controls.Add(label8, 0, 7);
            tableLayoutPanel4.Controls.Add(label9, 1, 7);
            tableLayoutPanel4.Controls.Add(dateTimePickerFrom, 0, 8);
            tableLayoutPanel4.Controls.Add(dateTimePickerTo, 1, 8);
            tableLayoutPanel4.Controls.Add(comboBoxDurationFilter, 0, 4);
            tableLayoutPanel4.Controls.Add(label4, 0, 5);
            tableLayoutPanel4.Controls.Add(label5, 1, 5);
            tableLayoutPanel4.Controls.Add(comboBoxStatusFilter, 1, 6);
            tableLayoutPanel4.Controls.Add(comboBoxApprovalStatusFilter, 0, 6);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel3, 2, 0);
            tableLayoutPanel4.Controls.Add(labelDurationFilter, 0, 3);
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
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Size = new Size(1120, 340);
            tableLayoutPanel4.TabIndex = 8;
            // 
            // dataGridViewServiceRequestManagement
            // 
            dataGridViewServiceRequestManagement.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewServiceRequestManagement.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewServiceRequestManagement.BackgroundColor = Color.White;
            dataGridViewServiceRequestManagement.BorderStyle = BorderStyle.None;
            dataGridViewServiceRequestManagement.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewServiceRequestManagement.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridViewServiceRequestManagement.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewServiceRequestManagement.ColumnHeadersHeight = 29;
            dataGridViewServiceRequestManagement.Columns.AddRange(new DataGridViewColumn[] { CustomerID, AccountName, AccountID, ServiceTypeName, ServiceID, TotalPrincipalAmount, ServiceDescription, Duration, InterestRate, TotalInterestAmount, CreatedDate, ApplicableDate, EndDate, HandledBy, ApprovalStatus, ServiceStatus });
            tableLayoutPanel4.SetColumnSpan(dataGridViewServiceRequestManagement, 6);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.HotTrack;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewServiceRequestManagement.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewServiceRequestManagement.Dock = DockStyle.Fill;
            dataGridViewServiceRequestManagement.EnableHeadersVisualStyles = false;
            dataGridViewServiceRequestManagement.GridColor = Color.White;
            dataGridViewServiceRequestManagement.Location = new Point(269, 54);
            dataGridViewServiceRequestManagement.Name = "dataGridViewServiceRequestManagement";
            dataGridViewServiceRequestManagement.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewServiceRequestManagement.RowHeadersVisible = false;
            dataGridViewServiceRequestManagement.RowHeadersWidth = 51;
            tableLayoutPanel4.SetRowSpan(dataGridViewServiceRequestManagement, 10);
            dataGridViewServiceRequestManagement.Size = new Size(848, 283);
            dataGridViewServiceRequestManagement.TabIndex = 64;
            // 
            // CustomerID
            // 
            CustomerID.HeaderText = "Mã khách hàng";
            CustomerID.MinimumWidth = 6;
            CustomerID.Name = "CustomerID";
            CustomerID.Width = 159;
            // 
            // AccountName
            // 
            AccountName.HeaderText = "Tên tài khoản";
            AccountName.MinimumWidth = 6;
            AccountName.Name = "AccountName";
            AccountName.Width = 146;
            // 
            // AccountID
            // 
            AccountID.HeaderText = "Mã tài khoản";
            AccountID.MinimumWidth = 6;
            AccountID.Name = "AccountID";
            AccountID.Width = 141;
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
            // ServiceDescription
            // 
            ServiceDescription.HeaderText = "Nội dung";
            ServiceDescription.MinimumWidth = 6;
            ServiceDescription.Name = "ServiceDescription";
            ServiceDescription.Width = 108;
            // 
            // Duration
            // 
            Duration.HeaderText = "Kỳ hạn";
            Duration.MinimumWidth = 6;
            Duration.Name = "Duration";
            Duration.Width = 91;
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
            TotalInterestAmount.HeaderText = "Tỗng lãi dự kiến";
            TotalInterestAmount.MinimumWidth = 6;
            TotalInterestAmount.Name = "TotalInterestAmount";
            TotalInterestAmount.Width = 166;
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
            // EndDate
            // 
            EndDate.HeaderText = "Ngày kết thúc";
            EndDate.MinimumWidth = 6;
            EndDate.Name = "EndDate";
            EndDate.Width = 147;
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
            buttonExportCSV.Click += buttonExportCSV_Click;
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
            buttonExportExcel.Click += buttonExportExcel_Click;
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
            buttonExportPDF.Click += buttonExportPDF_Click;
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
            buttonServiceSearch.Click += buttonServiceSearch_Click;
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
            comboBoxServiceTypeFilter.Items.AddRange(new object[] { "Không áp dụng", "Vay vốn", "Gửi tiết kiệm" });
            comboBoxServiceTypeFilter.Location = new Point(3, 77);
            comboBoxServiceTypeFilter.Name = "comboBoxServiceTypeFilter";
            comboBoxServiceTypeFilter.Size = new Size(260, 28);
            comboBoxServiceTypeFilter.TabIndex = 28;
            comboBoxServiceTypeFilter.SelectedIndexChanged += comboBoxServiceTypeFilter_SelectedIndexChanged;
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
            dateTimePickerFrom.Format = DateTimePickerFormat.Short;
            dateTimePickerFrom.Location = new Point(3, 245);
            dateTimePickerFrom.Name = "dateTimePickerFrom";
            dateTimePickerFrom.Size = new Size(129, 28);
            dateTimePickerFrom.TabIndex = 60;
            dateTimePickerFrom.ValueChanged += dateTimePickerFrom_ValueChanged;
            // 
            // dateTimePickerTo
            // 
            dateTimePickerTo.Dock = DockStyle.Fill;
            dateTimePickerTo.Font = new Font("Roboto", 10.2F);
            dateTimePickerTo.Format = DateTimePickerFormat.Short;
            dateTimePickerTo.Location = new Point(138, 245);
            dateTimePickerTo.Name = "dateTimePickerTo";
            dateTimePickerTo.Size = new Size(125, 28);
            dateTimePickerTo.TabIndex = 61;
            dateTimePickerTo.ValueChanged += dateTimePickerTo_ValueChanged;
            // 
            // comboBoxStatusFilter
            // 
            comboBoxStatusFilter.BackColor = SystemColors.Window;
            comboBoxStatusFilter.Dock = DockStyle.Fill;
            comboBoxStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStatusFilter.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxStatusFilter.FormattingEnabled = true;
            comboBoxStatusFilter.Items.AddRange(new object[] { "Không áp dụng", "Chờ hoạt động", "Đang hoạt động", "Đã tất toán", "Hủy", "Trễ hạn thanh toán" });
            comboBoxStatusFilter.Location = new Point(138, 188);
            comboBoxStatusFilter.Name = "comboBoxStatusFilter";
            comboBoxStatusFilter.Size = new Size(125, 28);
            comboBoxStatusFilter.TabIndex = 54;
            comboBoxStatusFilter.SelectedIndexChanged += comboBoxStatusFilter_SelectedIndexChanged;
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
            // UC_ServiceRequestManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "UC_ServiceRequestManagement";
            Size = new Size(1132, 753);
            tableLayoutPanel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox2.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewServiceRequestManagement).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label labelCustomerID;
        private Button buttonApproveService;
        private Button buttonDeclineService;
        private Label labelDurationFilter;
        private ComboBox comboBoxDurationFilter;
        private TableLayoutPanel tableLayoutPanel4;
        private Label labelServiceFilter;
        private TextBox textBoxServiceSearch;
        private Button buttonServiceSearch;
        private Label labelServiceTypeFilter;
        private ComboBox comboBoxServiceTypeFilter;
        private Label label4;
        private Label label5;
        private ComboBox comboBoxApprovalStatusFilter;
        private ComboBox comboBoxStatusFilter;
        private Panel panel3;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox1;
        private Panel panel1;
        private GroupBox groupBox2;
        private Button buttonExportPDF;
        private Button buttonExportExcel;
        private Button buttonExportCSV;
        private Label label8;
        private Label label9;
        private DateTimePicker dateTimePickerFrom;
        private DateTimePicker dateTimePickerTo;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label6;
        private TextBox textBoxCustomerID;
        private Panel panel2;
        private PictureBox pictureBox1;
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
        private Label label3;
        private Label labelApprovalStatus;
        private TextBox textBoxHandledBy;
        private Label labelHandledBy;
        private DateTimePicker dateTimePickerEndDate;
        private Label label1;
        private DateTimePicker dateTimePickerApplicableDate;
        private Label label2;
        private DateTimePicker dateTimePickerCreatedDate;
        private Label labelCreatedDate;
        private Label labelDuration;
        private ComboBox comboBoxDuration;
        private Label labelInterestRate;
        private TextBox textBoxInterestRate;
        private TextBox textBoxTotalInterestAmount;
        private Label label10;
        private Label label11;
        private RichTextBox richTextBoxServiceDescription;
        private ComboBox comboBoxApprovalStatus;
        private ComboBox comboBoxServiceStatus;
        private DataGridView dataGridViewServiceRequestManagement;
        private DataGridViewTextBoxColumn CustomerID;
        private DataGridViewTextBoxColumn AccountName;
        private DataGridViewTextBoxColumn AccountID;
        private DataGridViewTextBoxColumn ServiceTypeName;
        private DataGridViewTextBoxColumn ServiceID;
        private DataGridViewTextBoxColumn TotalPrincipalAmount;
        private DataGridViewTextBoxColumn ServiceDescription;
        private DataGridViewTextBoxColumn Duration;
        private DataGridViewTextBoxColumn InterestRate;
        private DataGridViewTextBoxColumn TotalInterestAmount;
        private DataGridViewTextBoxColumn CreatedDate;
        private DataGridViewTextBoxColumn ApplicableDate;
        private DataGridViewTextBoxColumn EndDate;
        private DataGridViewTextBoxColumn HandledBy;
        private DataGridViewTextBoxColumn ApprovalStatus;
        private DataGridViewTextBoxColumn ServiceStatus;
    }
}
