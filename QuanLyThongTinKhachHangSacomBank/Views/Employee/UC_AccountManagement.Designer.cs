namespace QuanLyThongTinKhachHangSacomBank.Views.Employee
{
    partial class UC_AccountManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_AccountManagement));
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            labelCustomerID = new Label();
            textBoxCustomerID = new TextBox();
            labelBalance = new Label();
            textBoxBalance = new TextBox();
            panel2 = new Panel();
            buttonAddAccount = new Button();
            buttonEditAccount = new Button();
            buttonCancelAccount = new Button();
            buttonSaveAccount = new Button();
            pictureBox1 = new PictureBox();
            panel3 = new Panel();
            groupBox2 = new GroupBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            buttonResetPassword = new Button();
            buttonResetPINCode = new Button();
            dateTimePickerAccountOpenDate = new DateTimePicker();
            labelAccountOpenDate = new Label();
            comboBoxAccountTypeName = new ComboBox();
            labelAccountType = new Label();
            textBoxAccountID = new TextBox();
            labelAccountID = new Label();
            label1 = new Label();
            textBoxAccountName = new TextBox();
            comboBoxAccountStatus = new ComboBox();
            labelStatus = new Label();
            panel1 = new Panel();
            groupBox3 = new GroupBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            buttonExportCSV = new Button();
            buttonExportExcel = new Button();
            buttonExportPDF = new Button();
            buttonAccountSearch = new Button();
            dataGridViewAccountManagement = new DataGridView();
            CustomerID = new DataGridViewTextBoxColumn();
            AccountName = new DataGridViewTextBoxColumn();
            AccountID = new DataGridViewTextBoxColumn();
            AccountTypeName = new DataGridViewTextBoxColumn();
            Balance = new DataGridViewTextBoxColumn();
            AccountOpenDate = new DataGridViewTextBoxColumn();
            AccountStatus = new DataGridViewTextBoxColumn();
            labelAccountTypeFilter = new Label();
            labelStatusFilter = new Label();
            comboBoxAccountTypeFilter = new ComboBox();
            comboBoxAccountStatusFilter = new ComboBox();
            label2 = new Label();
            dateTimePickerFrom = new DateTimePicker();
            dateTimePickerTo = new DateTimePicker();
            label3 = new Label();
            labelAccountFilter = new Label();
            tableLayoutPanel5 = new TableLayoutPanel();
            textBoxAccountSearch = new TextBox();
            panel4 = new Panel();
            tableLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            groupBox3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAccountManagement).BeginInit();
            tableLayoutPanel5.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(groupBox3, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1124, 695);
            tableLayoutPanel1.TabIndex = 0;
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
            groupBox1.Size = new Size(1118, 341);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin tài khoản";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 9;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.3408718F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.889084F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.794658542F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34.80216F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.989208639F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.2410069F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.989208639F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.4352512F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.291171F));
            tableLayoutPanel2.Controls.Add(labelCustomerID, 0, 0);
            tableLayoutPanel2.Controls.Add(textBoxCustomerID, 0, 1);
            tableLayoutPanel2.Controls.Add(labelBalance, 3, 0);
            tableLayoutPanel2.Controls.Add(textBoxBalance, 3, 1);
            tableLayoutPanel2.Controls.Add(panel2, 4, 0);
            tableLayoutPanel2.Controls.Add(buttonAddAccount, 5, 0);
            tableLayoutPanel2.Controls.Add(buttonEditAccount, 5, 2);
            tableLayoutPanel2.Controls.Add(buttonCancelAccount, 5, 6);
            tableLayoutPanel2.Controls.Add(buttonSaveAccount, 5, 8);
            tableLayoutPanel2.Controls.Add(pictureBox1, 8, 0);
            tableLayoutPanel2.Controls.Add(panel3, 6, 0);
            tableLayoutPanel2.Controls.Add(groupBox2, 7, 0);
            tableLayoutPanel2.Controls.Add(dateTimePickerAccountOpenDate, 3, 3);
            tableLayoutPanel2.Controls.Add(labelAccountOpenDate, 3, 2);
            tableLayoutPanel2.Controls.Add(comboBoxAccountTypeName, 0, 7);
            tableLayoutPanel2.Controls.Add(labelAccountType, 0, 6);
            tableLayoutPanel2.Controls.Add(textBoxAccountID, 0, 5);
            tableLayoutPanel2.Controls.Add(labelAccountID, 0, 4);
            tableLayoutPanel2.Controls.Add(label1, 0, 2);
            tableLayoutPanel2.Controls.Add(textBoxAccountName, 0, 3);
            tableLayoutPanel2.Controls.Add(comboBoxAccountStatus, 3, 5);
            tableLayoutPanel2.Controls.Add(labelStatus, 3, 4);
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
            tableLayoutPanel2.Size = new Size(1112, 310);
            tableLayoutPanel2.TabIndex = 6;
            // 
            // labelCustomerID
            // 
            labelCustomerID.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelCustomerID.AutoSize = true;
            labelCustomerID.BackColor = Color.Transparent;
            labelCustomerID.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            labelCustomerID.ForeColor = Color.Black;
            labelCustomerID.Location = new Point(3, 11);
            labelCustomerID.Name = "labelCustomerID";
            labelCustomerID.Size = new Size(132, 20);
            labelCustomerID.TabIndex = 9;
            labelCustomerID.Text = "Mã khách hàng";
            // 
            // textBoxCustomerID
            // 
            textBoxCustomerID.BackColor = SystemColors.InactiveCaption;
            tableLayoutPanel2.SetColumnSpan(textBoxCustomerID, 2);
            textBoxCustomerID.Dock = DockStyle.Fill;
            textBoxCustomerID.Font = new Font("Roboto", 10.2F);
            textBoxCustomerID.Location = new Point(3, 34);
            textBoxCustomerID.Name = "textBoxCustomerID";
            textBoxCustomerID.Size = new Size(297, 28);
            textBoxCustomerID.TabIndex = 23;
            // 
            // labelBalance
            // 
            labelBalance.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelBalance.AutoSize = true;
            labelBalance.BackColor = Color.Transparent;
            labelBalance.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            labelBalance.ForeColor = Color.Black;
            labelBalance.Location = new Point(314, 11);
            labelBalance.Name = "labelBalance";
            labelBalance.Size = new Size(56, 20);
            labelBalance.TabIndex = 29;
            labelBalance.Text = "Số dư";
            // 
            // textBoxBalance
            // 
            textBoxBalance.BackColor = SystemColors.InactiveCaption;
            textBoxBalance.Dock = DockStyle.Fill;
            textBoxBalance.Font = new Font("Roboto", 10.2F);
            textBoxBalance.Location = new Point(314, 34);
            textBoxBalance.Name = "textBoxBalance";
            textBoxBalance.Size = new Size(381, 28);
            textBoxBalance.TabIndex = 34;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.HotTrack;
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(701, 3);
            panel2.Name = "panel2";
            tableLayoutPanel2.SetRowSpan(panel2, 10);
            panel2.Size = new Size(5, 304);
            panel2.TabIndex = 39;
            // 
            // buttonAddAccount
            // 
            buttonAddAccount.BackColor = Color.DeepSkyBlue;
            buttonAddAccount.Dock = DockStyle.Fill;
            buttonAddAccount.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            buttonAddAccount.ForeColor = Color.White;
            buttonAddAccount.Image = (Image)resources.GetObject("buttonAddAccount.Image");
            buttonAddAccount.ImageAlign = ContentAlignment.MiddleLeft;
            buttonAddAccount.Location = new Point(712, 3);
            buttonAddAccount.Name = "buttonAddAccount";
            tableLayoutPanel2.SetRowSpan(buttonAddAccount, 2);
            buttonAddAccount.Size = new Size(119, 56);
            buttonAddAccount.TabIndex = 40;
            buttonAddAccount.Text = "   Thêm";
            buttonAddAccount.UseVisualStyleBackColor = false;
            buttonAddAccount.Click += buttonAddAccount_Click;
            // 
            // buttonEditAccount
            // 
            buttonEditAccount.BackColor = Color.DeepSkyBlue;
            buttonEditAccount.Dock = DockStyle.Fill;
            buttonEditAccount.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            buttonEditAccount.ForeColor = Color.White;
            buttonEditAccount.Image = (Image)resources.GetObject("buttonEditAccount.Image");
            buttonEditAccount.ImageAlign = ContentAlignment.MiddleLeft;
            buttonEditAccount.Location = new Point(712, 65);
            buttonEditAccount.Name = "buttonEditAccount";
            tableLayoutPanel2.SetRowSpan(buttonEditAccount, 2);
            buttonEditAccount.Size = new Size(119, 56);
            buttonEditAccount.TabIndex = 42;
            buttonEditAccount.Text = "   Sửa";
            buttonEditAccount.UseVisualStyleBackColor = false;
            buttonEditAccount.Click += buttonEditAccount_Click;
            // 
            // buttonCancelAccount
            // 
            buttonCancelAccount.BackColor = Color.DeepSkyBlue;
            buttonCancelAccount.Dock = DockStyle.Fill;
            buttonCancelAccount.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            buttonCancelAccount.ForeColor = Color.White;
            buttonCancelAccount.Image = (Image)resources.GetObject("buttonCancelAccount.Image");
            buttonCancelAccount.ImageAlign = ContentAlignment.MiddleLeft;
            buttonCancelAccount.Location = new Point(712, 189);
            buttonCancelAccount.Name = "buttonCancelAccount";
            tableLayoutPanel2.SetRowSpan(buttonCancelAccount, 2);
            buttonCancelAccount.Size = new Size(119, 56);
            buttonCancelAccount.TabIndex = 43;
            buttonCancelAccount.Text = "   Hủy";
            buttonCancelAccount.UseVisualStyleBackColor = false;
            buttonCancelAccount.Click += buttonCancelAccount_Click;
            // 
            // buttonSaveAccount
            // 
            buttonSaveAccount.BackColor = Color.DeepSkyBlue;
            buttonSaveAccount.Dock = DockStyle.Fill;
            buttonSaveAccount.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            buttonSaveAccount.ForeColor = Color.White;
            buttonSaveAccount.Image = (Image)resources.GetObject("buttonSaveAccount.Image");
            buttonSaveAccount.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSaveAccount.Location = new Point(712, 251);
            buttonSaveAccount.Name = "buttonSaveAccount";
            tableLayoutPanel2.SetRowSpan(buttonSaveAccount, 2);
            buttonSaveAccount.Size = new Size(119, 56);
            buttonSaveAccount.TabIndex = 44;
            buttonSaveAccount.Text = "   Lưu";
            buttonSaveAccount.UseVisualStyleBackColor = false;
            buttonSaveAccount.Click += buttonSaveAccount_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1053, 3);
            pictureBox1.Name = "pictureBox1";
            tableLayoutPanel2.SetRowSpan(pictureBox1, 10);
            pictureBox1.Size = new Size(56, 304);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 45;
            pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.HotTrack;
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(837, 3);
            panel3.Name = "panel3";
            tableLayoutPanel2.SetRowSpan(panel3, 10);
            panel3.Size = new Size(5, 304);
            panel3.TabIndex = 47;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Controls.Add(tableLayoutPanel3);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Font = new Font("Roboto SemiCondensed Medium", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.ForeColor = Color.OrangeRed;
            groupBox2.Location = new Point(848, 3);
            groupBox2.Name = "groupBox2";
            tableLayoutPanel2.SetRowSpan(groupBox2, 10);
            groupBox2.Size = new Size(199, 304);
            groupBox2.TabIndex = 48;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thao tác đặc biệt";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(buttonResetPassword, 0, 2);
            tableLayoutPanel3.Controls.Add(buttonResetPINCode, 0, 3);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 25);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 5;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25.2836647F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 16.1692162F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 16.1692162F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 16.1692162F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 26.208683F));
            tableLayoutPanel3.Size = new Size(193, 276);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // buttonResetPassword
            // 
            buttonResetPassword.BackColor = Color.LightCoral;
            tableLayoutPanel3.SetColumnSpan(buttonResetPassword, 2);
            buttonResetPassword.Dock = DockStyle.Fill;
            buttonResetPassword.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            buttonResetPassword.ForeColor = Color.White;
            buttonResetPassword.Image = (Image)resources.GetObject("buttonResetPassword.Image");
            buttonResetPassword.ImageAlign = ContentAlignment.MiddleLeft;
            buttonResetPassword.Location = new Point(3, 116);
            buttonResetPassword.Name = "buttonResetPassword";
            buttonResetPassword.Size = new Size(187, 38);
            buttonResetPassword.TabIndex = 8;
            buttonResetPassword.Text = "   Đặt lại mật khẩu";
            buttonResetPassword.UseVisualStyleBackColor = false;
            buttonResetPassword.Click += buttonResetPassword_Click;
            // 
            // buttonResetPINCode
            // 
            buttonResetPINCode.BackColor = Color.LightCoral;
            tableLayoutPanel3.SetColumnSpan(buttonResetPINCode, 2);
            buttonResetPINCode.Dock = DockStyle.Fill;
            buttonResetPINCode.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            buttonResetPINCode.ForeColor = Color.White;
            buttonResetPINCode.Image = (Image)resources.GetObject("buttonResetPINCode.Image");
            buttonResetPINCode.ImageAlign = ContentAlignment.MiddleLeft;
            buttonResetPINCode.Location = new Point(3, 160);
            buttonResetPINCode.Name = "buttonResetPINCode";
            buttonResetPINCode.Size = new Size(187, 38);
            buttonResetPINCode.TabIndex = 9;
            buttonResetPINCode.Text = "   Đặt lại mã PIN";
            buttonResetPINCode.UseVisualStyleBackColor = false;
            buttonResetPINCode.Click += buttonResetPINCode_Click;
            // 
            // dateTimePickerAccountOpenDate
            // 
            dateTimePickerAccountOpenDate.CalendarFont = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePickerAccountOpenDate.CalendarMonthBackground = SystemColors.InactiveCaption;
            dateTimePickerAccountOpenDate.Dock = DockStyle.Fill;
            dateTimePickerAccountOpenDate.Font = new Font("Roboto", 10.2F);
            dateTimePickerAccountOpenDate.Format = DateTimePickerFormat.Short;
            dateTimePickerAccountOpenDate.Location = new Point(314, 96);
            dateTimePickerAccountOpenDate.Name = "dateTimePickerAccountOpenDate";
            dateTimePickerAccountOpenDate.Size = new Size(381, 28);
            dateTimePickerAccountOpenDate.TabIndex = 28;
            // 
            // labelAccountOpenDate
            // 
            labelAccountOpenDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelAccountOpenDate.AutoSize = true;
            labelAccountOpenDate.BackColor = Color.Transparent;
            labelAccountOpenDate.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            labelAccountOpenDate.ForeColor = Color.Black;
            labelAccountOpenDate.Location = new Point(314, 73);
            labelAccountOpenDate.Name = "labelAccountOpenDate";
            labelAccountOpenDate.Size = new Size(160, 20);
            labelAccountOpenDate.TabIndex = 11;
            labelAccountOpenDate.Text = "Ngày mở tài khoản";
            // 
            // comboBoxAccountTypeName
            // 
            comboBoxAccountTypeName.BackColor = SystemColors.Window;
            tableLayoutPanel2.SetColumnSpan(comboBoxAccountTypeName, 2);
            comboBoxAccountTypeName.Dock = DockStyle.Fill;
            comboBoxAccountTypeName.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAccountTypeName.Font = new Font("Roboto", 10.2F);
            comboBoxAccountTypeName.FormattingEnabled = true;
            comboBoxAccountTypeName.Items.AddRange(new object[] { "Cá nhân", "Doanh nghiệp" });
            comboBoxAccountTypeName.Location = new Point(3, 220);
            comboBoxAccountTypeName.Name = "comboBoxAccountTypeName";
            comboBoxAccountTypeName.Size = new Size(297, 28);
            comboBoxAccountTypeName.TabIndex = 25;
            // 
            // labelAccountType
            // 
            labelAccountType.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelAccountType.AutoSize = true;
            labelAccountType.BackColor = Color.Transparent;
            labelAccountType.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            labelAccountType.ForeColor = Color.Black;
            labelAccountType.Location = new Point(3, 197);
            labelAccountType.Name = "labelAccountType";
            labelAccountType.Size = new Size(124, 20);
            labelAccountType.TabIndex = 12;
            labelAccountType.Text = "Loại tài khoản";
            // 
            // textBoxAccountID
            // 
            textBoxAccountID.BackColor = SystemColors.InactiveCaption;
            tableLayoutPanel2.SetColumnSpan(textBoxAccountID, 2);
            textBoxAccountID.Dock = DockStyle.Fill;
            textBoxAccountID.Font = new Font("Roboto", 10.2F);
            textBoxAccountID.Location = new Point(3, 158);
            textBoxAccountID.Name = "textBoxAccountID";
            textBoxAccountID.Size = new Size(297, 28);
            textBoxAccountID.TabIndex = 24;
            // 
            // labelAccountID
            // 
            labelAccountID.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelAccountID.AutoSize = true;
            labelAccountID.BackColor = Color.Transparent;
            labelAccountID.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            labelAccountID.ForeColor = Color.Black;
            labelAccountID.Location = new Point(3, 135);
            labelAccountID.Name = "labelAccountID";
            labelAccountID.Size = new Size(114, 20);
            labelAccountID.TabIndex = 10;
            labelAccountID.Text = "Mã tài khoản";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(3, 73);
            label1.Name = "label1";
            label1.Size = new Size(119, 20);
            label1.TabIndex = 49;
            label1.Text = "Tên tài khoản";
            // 
            // textBoxAccountName
            // 
            textBoxAccountName.BackColor = SystemColors.InactiveCaption;
            tableLayoutPanel2.SetColumnSpan(textBoxAccountName, 2);
            textBoxAccountName.Dock = DockStyle.Fill;
            textBoxAccountName.Font = new Font("Roboto", 10.2F);
            textBoxAccountName.Location = new Point(3, 96);
            textBoxAccountName.Name = "textBoxAccountName";
            textBoxAccountName.Size = new Size(297, 28);
            textBoxAccountName.TabIndex = 50;
            // 
            // comboBoxAccountStatus
            // 
            comboBoxAccountStatus.Dock = DockStyle.Fill;
            comboBoxAccountStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAccountStatus.Font = new Font("Roboto", 10.2F);
            comboBoxAccountStatus.FormattingEnabled = true;
            comboBoxAccountStatus.Items.AddRange(new object[] { "Hoạt động", "Khóa", "Đóng" });
            comboBoxAccountStatus.Location = new Point(314, 158);
            comboBoxAccountStatus.Name = "comboBoxAccountStatus";
            comboBoxAccountStatus.Size = new Size(381, 28);
            comboBoxAccountStatus.TabIndex = 46;
            // 
            // labelStatus
            // 
            labelStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelStatus.AutoSize = true;
            labelStatus.BackColor = Color.Transparent;
            labelStatus.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            labelStatus.ForeColor = Color.Black;
            labelStatus.Location = new Point(314, 135);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(92, 20);
            labelStatus.TabIndex = 31;
            labelStatus.Text = "Trạng thái";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.HotTrack;
            panel1.Location = new Point(194, 11);
            panel1.Name = "panel1";
            panel1.Size = new Size(236, 5);
            panel1.TabIndex = 5;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.Transparent;
            tableLayoutPanel1.SetColumnSpan(groupBox3, 2);
            groupBox3.Controls.Add(tableLayoutPanel4);
            groupBox3.Controls.Add(panel4);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Font = new Font("Roboto SemiCondensed Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox3.ForeColor = SystemColors.HotTrack;
            groupBox3.Location = new Point(3, 350);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1118, 342);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "Dữ liệu tài khoản khách hàng";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 8;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.8784866F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.8784914F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.5799637F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.826379F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.6095228F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.6095228F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.6095228F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1.00811279F));
            tableLayoutPanel4.Controls.Add(buttonExportCSV, 6, 0);
            tableLayoutPanel4.Controls.Add(buttonExportExcel, 5, 0);
            tableLayoutPanel4.Controls.Add(buttonExportPDF, 4, 0);
            tableLayoutPanel4.Controls.Add(buttonAccountSearch, 3, 0);
            tableLayoutPanel4.Controls.Add(dataGridViewAccountManagement, 2, 1);
            tableLayoutPanel4.Controls.Add(labelAccountTypeFilter, 0, 1);
            tableLayoutPanel4.Controls.Add(labelStatusFilter, 1, 1);
            tableLayoutPanel4.Controls.Add(comboBoxAccountTypeFilter, 0, 2);
            tableLayoutPanel4.Controls.Add(comboBoxAccountStatusFilter, 1, 2);
            tableLayoutPanel4.Controls.Add(label2, 0, 3);
            tableLayoutPanel4.Controls.Add(dateTimePickerFrom, 0, 4);
            tableLayoutPanel4.Controls.Add(dateTimePickerTo, 1, 4);
            tableLayoutPanel4.Controls.Add(label3, 1, 3);
            tableLayoutPanel4.Controls.Add(labelAccountFilter, 0, 0);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel5, 2, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 28);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 7;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 17.0418015F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 9.324759F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 10.2893887F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 9.003216F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 11.5755625F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 20.900322F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 23.47267F));
            tableLayoutPanel4.Size = new Size(1112, 311);
            tableLayoutPanel4.TabIndex = 7;
            // 
            // buttonExportCSV
            // 
            buttonExportCSV.Dock = DockStyle.Fill;
            buttonExportCSV.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            buttonExportCSV.ForeColor = Color.FromArgb(25, 137, 14);
            buttonExportCSV.Image = (Image)resources.GetObject("buttonExportCSV.Image");
            buttonExportCSV.Location = new Point(950, 3);
            buttonExportCSV.Name = "buttonExportCSV";
            buttonExportCSV.Size = new Size(145, 46);
            buttonExportCSV.TabIndex = 53;
            buttonExportCSV.Text = "Xuất CSV";
            buttonExportCSV.TextAlign = ContentAlignment.MiddleLeft;
            buttonExportCSV.TextImageRelation = TextImageRelation.TextBeforeImage;
            buttonExportCSV.UseVisualStyleBackColor = true;
            buttonExportCSV.Click += buttonExportCSV_Click;
            // 
            // buttonExportExcel
            // 
            buttonExportExcel.Dock = DockStyle.Fill;
            buttonExportExcel.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            buttonExportExcel.ForeColor = Color.FromArgb(20, 169, 6);
            buttonExportExcel.Image = (Image)resources.GetObject("buttonExportExcel.Image");
            buttonExportExcel.Location = new Point(799, 3);
            buttonExportExcel.Name = "buttonExportExcel";
            buttonExportExcel.Size = new Size(145, 46);
            buttonExportExcel.TabIndex = 52;
            buttonExportExcel.Text = "Xuất Excel";
            buttonExportExcel.TextAlign = ContentAlignment.MiddleLeft;
            buttonExportExcel.TextImageRelation = TextImageRelation.TextBeforeImage;
            buttonExportExcel.UseVisualStyleBackColor = true;
            buttonExportExcel.Click += buttonExportExcel_Click;
            // 
            // buttonExportPDF
            // 
            buttonExportPDF.Dock = DockStyle.Fill;
            buttonExportPDF.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            buttonExportPDF.ForeColor = Color.FromArgb(207, 0, 0);
            buttonExportPDF.Image = (Image)resources.GetObject("buttonExportPDF.Image");
            buttonExportPDF.Location = new Point(648, 3);
            buttonExportPDF.Name = "buttonExportPDF";
            buttonExportPDF.Size = new Size(145, 46);
            buttonExportPDF.TabIndex = 51;
            buttonExportPDF.Text = "Xuất PDF";
            buttonExportPDF.TextAlign = ContentAlignment.MiddleLeft;
            buttonExportPDF.TextImageRelation = TextImageRelation.TextBeforeImage;
            buttonExportPDF.UseVisualStyleBackColor = true;
            buttonExportPDF.Click += buttonExportPDF_Click;
            // 
            // buttonAccountSearch
            // 
            buttonAccountSearch.BackColor = SystemColors.HotTrack;
            buttonAccountSearch.Dock = DockStyle.Fill;
            buttonAccountSearch.ForeColor = Color.White;
            buttonAccountSearch.Image = (Image)resources.GetObject("buttonAccountSearch.Image");
            buttonAccountSearch.Location = new Point(595, 3);
            buttonAccountSearch.Name = "buttonAccountSearch";
            buttonAccountSearch.Size = new Size(47, 46);
            buttonAccountSearch.TabIndex = 6;
            buttonAccountSearch.UseVisualStyleBackColor = false;
            buttonAccountSearch.Click += buttonAccountSearch_Click;
            // 
            // dataGridViewAccountManagement
            // 
            dataGridViewAccountManagement.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewAccountManagement.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewAccountManagement.BackgroundColor = Color.White;
            dataGridViewAccountManagement.BorderStyle = BorderStyle.None;
            dataGridViewAccountManagement.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewAccountManagement.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle3.Font = new Font("Roboto SemiCondensed Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridViewAccountManagement.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewAccountManagement.ColumnHeadersHeight = 29;
            dataGridViewAccountManagement.Columns.AddRange(new DataGridViewColumn[] { CustomerID, AccountName, AccountID, AccountTypeName, Balance, AccountOpenDate, AccountStatus });
            tableLayoutPanel4.SetColumnSpan(dataGridViewAccountManagement, 6);
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.HotTrack;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dataGridViewAccountManagement.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewAccountManagement.Dock = DockStyle.Fill;
            dataGridViewAccountManagement.EnableHeadersVisualStyles = false;
            dataGridViewAccountManagement.GridColor = Color.White;
            dataGridViewAccountManagement.Location = new Point(311, 55);
            dataGridViewAccountManagement.Name = "dataGridViewAccountManagement";
            dataGridViewAccountManagement.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewAccountManagement.RowHeadersVisible = false;
            dataGridViewAccountManagement.RowHeadersWidth = 51;
            tableLayoutPanel4.SetRowSpan(dataGridViewAccountManagement, 6);
            dataGridViewAccountManagement.Size = new Size(798, 253);
            dataGridViewAccountManagement.TabIndex = 48;
            dataGridViewAccountManagement.CellClick += dataGridViewAccountManagement_CellClick;
            dataGridViewAccountManagement.CellContentClick += dataGridViewAccountManagement_SelectionChanged;
            // 
            // CustomerID
            // 
            CustomerID.HeaderText = "Mã khách hàng";
            CustomerID.MinimumWidth = 6;
            CustomerID.Name = "CustomerID";
            CustomerID.Width = 177;
            // 
            // AccountName
            // 
            AccountName.HeaderText = "Tên tài khoản";
            AccountName.MinimumWidth = 6;
            AccountName.Name = "AccountName";
            AccountName.Width = 162;
            // 
            // AccountID
            // 
            AccountID.HeaderText = "Mã tài khoản";
            AccountID.MinimumWidth = 6;
            AccountID.Name = "AccountID";
            AccountID.Width = 157;
            // 
            // AccountTypeName
            // 
            AccountTypeName.HeaderText = "Loại tài khoản";
            AccountTypeName.MinimumWidth = 6;
            AccountTypeName.Name = "AccountTypeName";
            AccountTypeName.Width = 169;
            // 
            // Balance
            // 
            Balance.HeaderText = "Số dư";
            Balance.MinimumWidth = 6;
            Balance.Name = "Balance";
            Balance.Width = 92;
            // 
            // AccountOpenDate
            // 
            AccountOpenDate.HeaderText = "Ngày mở";
            AccountOpenDate.MinimumWidth = 6;
            AccountOpenDate.Name = "AccountOpenDate";
            AccountOpenDate.Width = 119;
            // 
            // AccountStatus
            // 
            AccountStatus.HeaderText = "Trạng thái";
            AccountStatus.MinimumWidth = 6;
            AccountStatus.Name = "AccountStatus";
            AccountStatus.Width = 131;
            // 
            // labelAccountTypeFilter
            // 
            labelAccountTypeFilter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelAccountTypeFilter.AutoSize = true;
            labelAccountTypeFilter.BackColor = Color.Transparent;
            labelAccountTypeFilter.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            labelAccountTypeFilter.ForeColor = Color.Black;
            labelAccountTypeFilter.Location = new Point(3, 60);
            labelAccountTypeFilter.Name = "labelAccountTypeFilter";
            labelAccountTypeFilter.Size = new Size(124, 20);
            labelAccountTypeFilter.TabIndex = 27;
            labelAccountTypeFilter.Text = "Loại tài khoản";
            // 
            // labelStatusFilter
            // 
            labelStatusFilter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelStatusFilter.AutoSize = true;
            labelStatusFilter.BackColor = Color.Transparent;
            labelStatusFilter.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            labelStatusFilter.ForeColor = Color.Black;
            labelStatusFilter.Location = new Point(157, 60);
            labelStatusFilter.Name = "labelStatusFilter";
            labelStatusFilter.Size = new Size(92, 20);
            labelStatusFilter.TabIndex = 32;
            labelStatusFilter.Text = "Trạng thái";
            // 
            // comboBoxAccountTypeFilter
            // 
            comboBoxAccountTypeFilter.BackColor = SystemColors.Window;
            comboBoxAccountTypeFilter.Dock = DockStyle.Fill;
            comboBoxAccountTypeFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAccountTypeFilter.Font = new Font("Roboto", 10.2F);
            comboBoxAccountTypeFilter.FormattingEnabled = true;
            comboBoxAccountTypeFilter.Items.AddRange(new object[] { "Không áp dụng", "Cá nhân", "Doanh nghiệp" });
            comboBoxAccountTypeFilter.Location = new Point(3, 83);
            comboBoxAccountTypeFilter.Name = "comboBoxAccountTypeFilter";
            comboBoxAccountTypeFilter.Size = new Size(148, 28);
            comboBoxAccountTypeFilter.TabIndex = 28;
            comboBoxAccountTypeFilter.SelectedIndexChanged += comboBoxAccountTypeFilter_SelectedIndexChanged;
            // 
            // comboBoxAccountStatusFilter
            // 
            comboBoxAccountStatusFilter.Dock = DockStyle.Fill;
            comboBoxAccountStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAccountStatusFilter.Font = new Font("Roboto", 10.2F);
            comboBoxAccountStatusFilter.FormattingEnabled = true;
            comboBoxAccountStatusFilter.Items.AddRange(new object[] { "Không áp dụng", "Hoạt động", "Khóa", "Đóng" });
            comboBoxAccountStatusFilter.Location = new Point(157, 83);
            comboBoxAccountStatusFilter.Name = "comboBoxAccountStatusFilter";
            comboBoxAccountStatusFilter.Size = new Size(148, 28);
            comboBoxAccountStatusFilter.TabIndex = 47;
            comboBoxAccountStatusFilter.SelectedIndexChanged += comboBoxAccountStatusFilter_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(3, 118);
            label2.Name = "label2";
            label2.Size = new Size(30, 20);
            label2.TabIndex = 49;
            label2.Text = "Từ";
            // 
            // dateTimePickerFrom
            // 
            dateTimePickerFrom.CalendarFont = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePickerFrom.Dock = DockStyle.Fill;
            dateTimePickerFrom.Font = new Font("Roboto", 10.2F);
            dateTimePickerFrom.Format = DateTimePickerFormat.Short;
            dateTimePickerFrom.Location = new Point(3, 141);
            dateTimePickerFrom.Name = "dateTimePickerFrom";
            dateTimePickerFrom.Size = new Size(148, 28);
            dateTimePickerFrom.TabIndex = 54;
            dateTimePickerFrom.ValueChanged += dateTimePickerFrom_ValueChanged;
            // 
            // dateTimePickerTo
            // 
            dateTimePickerTo.CalendarFont = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePickerTo.Dock = DockStyle.Fill;
            dateTimePickerTo.Font = new Font("Roboto", 10.2F);
            dateTimePickerTo.Format = DateTimePickerFormat.Short;
            dateTimePickerTo.Location = new Point(157, 141);
            dateTimePickerTo.Name = "dateTimePickerTo";
            dateTimePickerTo.Size = new Size(148, 28);
            dateTimePickerTo.TabIndex = 55;
            dateTimePickerTo.ValueChanged += dateTimePickerTo_ValueChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(157, 118);
            label3.Name = "label3";
            label3.Size = new Size(41, 20);
            label3.TabIndex = 50;
            label3.Text = "Đến";
            // 
            // labelAccountFilter
            // 
            labelAccountFilter.Anchor = AnchorStyles.Bottom;
            labelAccountFilter.AutoSize = true;
            labelAccountFilter.BackColor = Color.Transparent;
            tableLayoutPanel4.SetColumnSpan(labelAccountFilter, 2);
            labelAccountFilter.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            labelAccountFilter.ForeColor = Color.Black;
            labelAccountFilter.Location = new Point(92, 32);
            labelAccountFilter.Name = "labelAccountFilter";
            labelAccountFilter.Size = new Size(123, 20);
            labelAccountFilter.TabIndex = 26;
            labelAccountFilter.Text = "Lọc tài khoản:";
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Controls.Add(textBoxAccountSearch, 0, 1);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(311, 3);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 3;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 11.7346935F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 76.53062F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 11.7346935F));
            tableLayoutPanel5.Size = new Size(278, 46);
            tableLayoutPanel5.TabIndex = 57;
            // 
            // textBoxAccountSearch
            // 
            textBoxAccountSearch.Dock = DockStyle.Fill;
            textBoxAccountSearch.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxAccountSearch.Location = new Point(3, 8);
            textBoxAccountSearch.Name = "textBoxAccountSearch";
            textBoxAccountSearch.PlaceholderText = "Tìm kiếm . . .";
            textBoxAccountSearch.Size = new Size(272, 32);
            textBoxAccountSearch.TabIndex = 2;
            textBoxAccountSearch.WordWrap = false;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.HotTrack;
            panel4.Location = new Point(296, 11);
            panel4.Name = "panel4";
            panel4.Size = new Size(450, 5);
            panel4.TabIndex = 6;
            // 
            // UC_AccountManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "UC_AccountManagement";
            Size = new Size(1124, 695);
            tableLayoutPanel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAccountManagement).EndInit();
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox1;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label labelAccountID;
        private Label labelAccountType;
        private Label labelAccountOpenDate;
        private Label labelCustomerType;
        private TextBox textBoxCustomerID;
        private TextBox textBoxAccountID;
        private ComboBox comboBoxAccountTypeName;
        private ComboBox comboBoxCustomerType;
        private DateTimePicker dateTimePickerAccountOpenDate;
        private Label labelBalance;
        private TextBox textBoxBalance;
        private Label labelStatus;
        private Panel panel2;
        private Button buttonAddAccount;
        private Button buttonEditAccount;
        private Button buttonCancelAccount;
        private Button buttonSaveAccount;
        private PictureBox pictureBox1;
        private Label labelCustomerID;
        private ComboBox comboBoxAccountStatus;
        private Panel panel3;
        private GroupBox groupBox2;
        private TableLayoutPanel tableLayoutPanel3;
        private Button buttonResetPassword;
        private Button buttonResetPINCode;
        private GroupBox groupBox3;
        private Panel panel4;
        private TableLayoutPanel tableLayoutPanel4;
        private TextBox textBoxAccountSearch;
        private Button buttonAccountSearch;
        private Label labelAccountFilter;
        private Label labelAccountTypeFilter;
        private ComboBox comboBoxAccountTypeFilter;
        private Label labelStatusFilter;
        private ComboBox comboBoxAccountStatusFilter;
        private DataGridView dataGridViewAccountManagement;
        private Label label1;
        private TextBox textBoxAccountName;
        private Label label2;
        private Label label3;
        private Button buttonExportPDF;
        private Button buttonExportExcel;
        private Button buttonExportCSV;
        private DateTimePicker dateTimePickerFrom;
        private DateTimePicker dateTimePickerTo;
        private TableLayoutPanel tableLayoutPanel5;
        private DataGridViewTextBoxColumn CustomerID;
        private DataGridViewTextBoxColumn AccountName;
        private DataGridViewTextBoxColumn AccountID;
        private DataGridViewTextBoxColumn AccountTypeName;
        private DataGridViewTextBoxColumn Balance;
        private DataGridViewTextBoxColumn AccountOpenDate;
        private DataGridViewTextBoxColumn AccountStatus;
    }
}
