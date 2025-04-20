namespace QuanLyThongTinKhachHangSacomBank.Views.Employee
{
    partial class UC_CustomerManagement
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_CustomerManagement));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBoxCustomerInfo = new GroupBox();
            panel1 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            labelCustomerID = new Label();
            labelFullName = new Label();
            labelGender = new Label();
            labelNationality = new Label();
            labelDateOfBirth = new Label();
            textBoxCustomerID = new TextBox();
            textBoxFullName = new TextBox();
            comboBoxGender = new ComboBox();
            textBoxNationality = new TextBox();
            dateTimePickerDateOfBirth = new DateTimePicker();
            labelCitizenID = new Label();
            labelAddress = new Label();
            labelEmail = new Label();
            labelRegistrationDate = new Label();
            textBoxCitizenID = new TextBox();
            textBoxAddress = new TextBox();
            textBoxPhone = new TextBox();
            labelPhone = new Label();
            textBoxEmail = new TextBox();
            dateTimePickerRegistrationDate = new DateTimePicker();
            panel2 = new Panel();
            buttonAddCustomer = new Button();
            buttonEditCustomer = new Button();
            buttonCancelCustomer = new Button();
            buttonSaveCustomer = new Button();
            pictureBox1 = new PictureBox();
            labelCustomerType = new Label();
            comboBoxCustomerTypeName = new ComboBox();
            groupBoxDataCustomerManagement = new GroupBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            buttonExportCSV = new Button();
            buttonExportExcel = new Button();
            buttonExportPDF = new Button();
            buttonCustomerSearch = new Button();
            dataCustomerManagement = new DataGridView();
            CustomerID = new DataGridViewTextBoxColumn();
            CustomerTypeName = new DataGridViewTextBoxColumn();
            FullName = new DataGridViewTextBoxColumn();
            Gender = new DataGridViewTextBoxColumn();
            DateOfBirth = new DataGridViewTextBoxColumn();
            Nationality = new DataGridViewTextBoxColumn();
            CitizenID = new DataGridViewTextBoxColumn();
            CustomerAddress = new DataGridViewTextBoxColumn();
            Phone = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            RegistrationDate = new DataGridViewTextBoxColumn();
            labelCustomerFilter = new Label();
            label1 = new Label();
            comboBoxCustomerTypeFilter = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            dateTimePickerFrom = new DateTimePicker();
            dateTimePickerTo = new DateTimePicker();
            tableLayoutPanel4 = new TableLayoutPanel();
            textBoxCustomerSearch = new TextBox();
            panel3 = new Panel();
            toolTip1 = new ToolTip(components);
            tableLayoutPanel1.SuspendLayout();
            groupBoxCustomerInfo.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBoxDataCustomerManagement.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataCustomerManagement).BeginInit();
            tableLayoutPanel4.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(groupBoxCustomerInfo, 0, 0);
            tableLayoutPanel1.Controls.Add(groupBoxDataCustomerManagement, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(5);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1840, 1205);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBoxCustomerInfo
            // 
            tableLayoutPanel1.SetColumnSpan(groupBoxCustomerInfo, 2);
            groupBoxCustomerInfo.Controls.Add(panel1);
            groupBoxCustomerInfo.Controls.Add(tableLayoutPanel2);
            groupBoxCustomerInfo.Dock = DockStyle.Fill;
            groupBoxCustomerInfo.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxCustomerInfo.ForeColor = SystemColors.HotTrack;
            groupBoxCustomerInfo.Location = new Point(5, 5);
            groupBoxCustomerInfo.Margin = new Padding(5);
            groupBoxCustomerInfo.Name = "groupBoxCustomerInfo";
            groupBoxCustomerInfo.Padding = new Padding(5);
            groupBoxCustomerInfo.Size = new Size(1830, 592);
            groupBoxCustomerInfo.TabIndex = 0;
            groupBoxCustomerInfo.TabStop = false;
            groupBoxCustomerInfo.Text = "Thông tin khách hàng";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.HotTrack;
            panel1.Location = new Point(354, 16);
            panel1.Margin = new Padding(5);
            panel1.Name = "panel1";
            panel1.Size = new Size(384, 8);
            panel1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 7;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.5575542F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.769784F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.732000947F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55.0943336F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1.0767622F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.152478F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.487898F));
            tableLayoutPanel2.Controls.Add(labelCustomerID, 0, 0);
            tableLayoutPanel2.Controls.Add(labelFullName, 0, 2);
            tableLayoutPanel2.Controls.Add(labelGender, 0, 4);
            tableLayoutPanel2.Controls.Add(labelNationality, 0, 8);
            tableLayoutPanel2.Controls.Add(labelDateOfBirth, 0, 6);
            tableLayoutPanel2.Controls.Add(textBoxCustomerID, 0, 1);
            tableLayoutPanel2.Controls.Add(textBoxFullName, 0, 3);
            tableLayoutPanel2.Controls.Add(comboBoxGender, 0, 5);
            tableLayoutPanel2.Controls.Add(textBoxNationality, 0, 9);
            tableLayoutPanel2.Controls.Add(dateTimePickerDateOfBirth, 0, 7);
            tableLayoutPanel2.Controls.Add(labelCitizenID, 3, 0);
            tableLayoutPanel2.Controls.Add(labelAddress, 3, 2);
            tableLayoutPanel2.Controls.Add(labelEmail, 3, 6);
            tableLayoutPanel2.Controls.Add(labelRegistrationDate, 3, 8);
            tableLayoutPanel2.Controls.Add(textBoxCitizenID, 3, 1);
            tableLayoutPanel2.Controls.Add(textBoxAddress, 3, 3);
            tableLayoutPanel2.Controls.Add(textBoxPhone, 3, 5);
            tableLayoutPanel2.Controls.Add(labelPhone, 3, 4);
            tableLayoutPanel2.Controls.Add(textBoxEmail, 3, 7);
            tableLayoutPanel2.Controls.Add(dateTimePickerRegistrationDate, 3, 9);
            tableLayoutPanel2.Controls.Add(panel2, 4, 0);
            tableLayoutPanel2.Controls.Add(buttonAddCustomer, 5, 0);
            tableLayoutPanel2.Controls.Add(buttonEditCustomer, 5, 2);
            tableLayoutPanel2.Controls.Add(buttonCancelCustomer, 5, 6);
            tableLayoutPanel2.Controls.Add(buttonSaveCustomer, 5, 8);
            tableLayoutPanel2.Controls.Add(pictureBox1, 6, 0);
            tableLayoutPanel2.Controls.Add(labelCustomerType, 1, 0);
            tableLayoutPanel2.Controls.Add(comboBoxCustomerTypeName, 1, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(5, 42);
            tableLayoutPanel2.Margin = new Padding(5);
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
            tableLayoutPanel2.Size = new Size(1820, 545);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // labelCustomerID
            // 
            labelCustomerID.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelCustomerID.AutoSize = true;
            labelCustomerID.BackColor = Color.Transparent;
            labelCustomerID.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            labelCustomerID.ForeColor = Color.Black;
            labelCustomerID.Location = new Point(5, 22);
            labelCustomerID.Margin = new Padding(5, 0, 5, 0);
            labelCustomerID.Name = "labelCustomerID";
            labelCustomerID.Size = new Size(220, 32);
            labelCustomerID.TabIndex = 9;
            labelCustomerID.Text = "Mã khách hàng";
            // 
            // labelFullName
            // 
            labelFullName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelFullName.AutoSize = true;
            labelFullName.BackColor = Color.Transparent;
            labelFullName.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            labelFullName.ForeColor = Color.Black;
            labelFullName.Location = new Point(5, 130);
            labelFullName.Margin = new Padding(5, 0, 5, 0);
            labelFullName.Name = "labelFullName";
            labelFullName.Size = new Size(103, 32);
            labelFullName.TabIndex = 10;
            labelFullName.Text = "Họ tên";
            // 
            // labelGender
            // 
            labelGender.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelGender.AutoSize = true;
            labelGender.BackColor = Color.Transparent;
            labelGender.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            labelGender.ForeColor = Color.Black;
            labelGender.Location = new Point(5, 238);
            labelGender.Margin = new Padding(5, 0, 5, 0);
            labelGender.Name = "labelGender";
            labelGender.Size = new Size(129, 32);
            labelGender.TabIndex = 12;
            labelGender.Text = "Giới tính";
            // 
            // labelNationality
            // 
            labelNationality.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelNationality.AutoSize = true;
            labelNationality.BackColor = Color.Transparent;
            labelNationality.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            labelNationality.ForeColor = Color.Black;
            labelNationality.Location = new Point(5, 454);
            labelNationality.Margin = new Padding(5, 0, 5, 0);
            labelNationality.Name = "labelNationality";
            labelNationality.Size = new Size(143, 32);
            labelNationality.TabIndex = 13;
            labelNationality.Text = "Quốc tịch";
            // 
            // labelDateOfBirth
            // 
            labelDateOfBirth.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelDateOfBirth.AutoSize = true;
            labelDateOfBirth.BackColor = Color.Transparent;
            labelDateOfBirth.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            labelDateOfBirth.ForeColor = Color.Black;
            labelDateOfBirth.Location = new Point(5, 346);
            labelDateOfBirth.Margin = new Padding(5, 0, 5, 0);
            labelDateOfBirth.Name = "labelDateOfBirth";
            labelDateOfBirth.Size = new Size(149, 32);
            labelDateOfBirth.TabIndex = 11;
            labelDateOfBirth.Text = "Ngày sinh";
            // 
            // textBoxCustomerID
            // 
            textBoxCustomerID.BackColor = SystemColors.InactiveCaption;
            textBoxCustomerID.Dock = DockStyle.Fill;
            textBoxCustomerID.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxCustomerID.Location = new Point(5, 59);
            textBoxCustomerID.Margin = new Padding(5);
            textBoxCustomerID.Name = "textBoxCustomerID";
            textBoxCustomerID.Size = new Size(273, 38);
            textBoxCustomerID.TabIndex = 23;
            // 
            // textBoxFullName
            // 
            textBoxFullName.BackColor = SystemColors.InactiveCaption;
            tableLayoutPanel2.SetColumnSpan(textBoxFullName, 2);
            textBoxFullName.Dock = DockStyle.Fill;
            textBoxFullName.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxFullName.Location = new Point(5, 167);
            textBoxFullName.Margin = new Padding(5);
            textBoxFullName.Name = "textBoxFullName";
            textBoxFullName.Size = new Size(505, 38);
            textBoxFullName.TabIndex = 24;
            // 
            // comboBoxGender
            // 
            comboBoxGender.BackColor = SystemColors.Window;
            tableLayoutPanel2.SetColumnSpan(comboBoxGender, 2);
            comboBoxGender.Dock = DockStyle.Fill;
            comboBoxGender.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGender.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxGender.FormattingEnabled = true;
            comboBoxGender.Items.AddRange(new object[] { "Nam", "Nữ" });
            comboBoxGender.Location = new Point(5, 275);
            comboBoxGender.Margin = new Padding(5);
            comboBoxGender.Name = "comboBoxGender";
            comboBoxGender.Size = new Size(505, 39);
            comboBoxGender.TabIndex = 25;
            // 
            // textBoxNationality
            // 
            textBoxNationality.BackColor = SystemColors.InactiveCaption;
            tableLayoutPanel2.SetColumnSpan(textBoxNationality, 2);
            textBoxNationality.Dock = DockStyle.Fill;
            textBoxNationality.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxNationality.Location = new Point(5, 491);
            textBoxNationality.Margin = new Padding(5);
            textBoxNationality.Name = "textBoxNationality";
            textBoxNationality.Size = new Size(505, 38);
            textBoxNationality.TabIndex = 27;
            // 
            // dateTimePickerDateOfBirth
            // 
            dateTimePickerDateOfBirth.CalendarFont = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePickerDateOfBirth.CalendarMonthBackground = SystemColors.InactiveCaption;
            tableLayoutPanel2.SetColumnSpan(dateTimePickerDateOfBirth, 2);
            dateTimePickerDateOfBirth.Dock = DockStyle.Fill;
            dateTimePickerDateOfBirth.Font = new Font("Microsoft Sans Serif", 10.2F);
            dateTimePickerDateOfBirth.Format = DateTimePickerFormat.Short;
            dateTimePickerDateOfBirth.Location = new Point(5, 383);
            dateTimePickerDateOfBirth.Margin = new Padding(5);
            dateTimePickerDateOfBirth.Name = "dateTimePickerDateOfBirth";
            dateTimePickerDateOfBirth.Size = new Size(505, 38);
            dateTimePickerDateOfBirth.TabIndex = 28;
            // 
            // labelCitizenID
            // 
            labelCitizenID.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelCitizenID.AutoSize = true;
            labelCitizenID.BackColor = Color.Transparent;
            labelCitizenID.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            labelCitizenID.ForeColor = Color.Black;
            labelCitizenID.Location = new Point(533, 22);
            labelCitizenID.Margin = new Padding(5, 0, 5, 0);
            labelCitizenID.Name = "labelCitizenID";
            labelCitizenID.Size = new Size(227, 32);
            labelCitizenID.TabIndex = 29;
            labelCitizenID.Text = "CCCD/Passport";
            // 
            // labelAddress
            // 
            labelAddress.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelAddress.AutoSize = true;
            labelAddress.BackColor = Color.Transparent;
            labelAddress.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            labelAddress.ForeColor = Color.Black;
            labelAddress.Location = new Point(533, 130);
            labelAddress.Margin = new Padding(5, 0, 5, 0);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(108, 32);
            labelAddress.TabIndex = 30;
            labelAddress.Text = "Địa chỉ";
            // 
            // labelEmail
            // 
            labelEmail.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelEmail.AutoSize = true;
            labelEmail.BackColor = Color.Transparent;
            labelEmail.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            labelEmail.ForeColor = Color.Black;
            labelEmail.Location = new Point(533, 346);
            labelEmail.Margin = new Padding(5, 0, 5, 0);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(91, 32);
            labelEmail.TabIndex = 32;
            labelEmail.Text = "Email";
            // 
            // labelRegistrationDate
            // 
            labelRegistrationDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelRegistrationDate.AutoSize = true;
            labelRegistrationDate.BackColor = Color.Transparent;
            labelRegistrationDate.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            labelRegistrationDate.ForeColor = Color.Black;
            labelRegistrationDate.Location = new Point(533, 454);
            labelRegistrationDate.Margin = new Padding(5, 0, 5, 0);
            labelRegistrationDate.Name = "labelRegistrationDate";
            labelRegistrationDate.Size = new Size(191, 32);
            labelRegistrationDate.TabIndex = 33;
            labelRegistrationDate.Text = "Ngày đăng kí";
            // 
            // textBoxCitizenID
            // 
            textBoxCitizenID.BackColor = SystemColors.InactiveCaption;
            textBoxCitizenID.Dock = DockStyle.Fill;
            textBoxCitizenID.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxCitizenID.Location = new Point(533, 59);
            textBoxCitizenID.Margin = new Padding(5);
            textBoxCitizenID.Name = "textBoxCitizenID";
            textBoxCitizenID.Size = new Size(994, 38);
            textBoxCitizenID.TabIndex = 34;
            // 
            // textBoxAddress
            // 
            textBoxAddress.BackColor = SystemColors.InactiveCaption;
            textBoxAddress.Dock = DockStyle.Fill;
            textBoxAddress.Font = new Font("Microsoft Sans Serif", 10.2F);
            textBoxAddress.Location = new Point(533, 167);
            textBoxAddress.Margin = new Padding(5);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(994, 38);
            textBoxAddress.TabIndex = 35;
            // 
            // textBoxPhone
            // 
            textBoxPhone.BackColor = SystemColors.InactiveCaption;
            textBoxPhone.Dock = DockStyle.Fill;
            textBoxPhone.Font = new Font("Microsoft Sans Serif", 10.2F);
            textBoxPhone.Location = new Point(533, 275);
            textBoxPhone.Margin = new Padding(5);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(994, 38);
            textBoxPhone.TabIndex = 36;
            // 
            // labelPhone
            // 
            labelPhone.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelPhone.AutoSize = true;
            labelPhone.BackColor = Color.Transparent;
            labelPhone.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            labelPhone.ForeColor = Color.Black;
            labelPhone.Location = new Point(533, 238);
            labelPhone.Margin = new Padding(5, 0, 5, 0);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(73, 32);
            labelPhone.TabIndex = 31;
            labelPhone.Text = "SĐT";
            // 
            // textBoxEmail
            // 
            textBoxEmail.BackColor = SystemColors.InactiveCaption;
            textBoxEmail.Dock = DockStyle.Fill;
            textBoxEmail.Font = new Font("Microsoft Sans Serif", 10.2F);
            textBoxEmail.Location = new Point(533, 383);
            textBoxEmail.Margin = new Padding(5);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(994, 38);
            textBoxEmail.TabIndex = 37;
            // 
            // dateTimePickerRegistrationDate
            // 
            dateTimePickerRegistrationDate.CalendarFont = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePickerRegistrationDate.CalendarMonthBackground = SystemColors.InactiveCaption;
            dateTimePickerRegistrationDate.Dock = DockStyle.Fill;
            dateTimePickerRegistrationDate.Font = new Font("Microsoft Sans Serif", 10.2F);
            dateTimePickerRegistrationDate.Format = DateTimePickerFormat.Short;
            dateTimePickerRegistrationDate.Location = new Point(533, 491);
            dateTimePickerRegistrationDate.Margin = new Padding(5);
            dateTimePickerRegistrationDate.Name = "dateTimePickerRegistrationDate";
            dateTimePickerRegistrationDate.Size = new Size(994, 38);
            dateTimePickerRegistrationDate.TabIndex = 38;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.HotTrack;
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(1537, 5);
            panel2.Margin = new Padding(5);
            panel2.Name = "panel2";
            tableLayoutPanel2.SetRowSpan(panel2, 10);
            panel2.Size = new Size(9, 535);
            panel2.TabIndex = 39;
            // 
            // buttonAddCustomer
            // 
            buttonAddCustomer.BackColor = Color.DeepSkyBlue;
            buttonAddCustomer.Dock = DockStyle.Fill;
            buttonAddCustomer.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonAddCustomer.ForeColor = Color.White;
            buttonAddCustomer.Image = (Image)resources.GetObject("buttonAddCustomer.Image");
            buttonAddCustomer.ImageAlign = ContentAlignment.MiddleLeft;
            buttonAddCustomer.Location = new Point(1556, 5);
            buttonAddCustomer.Margin = new Padding(5);
            buttonAddCustomer.Name = "buttonAddCustomer";
            tableLayoutPanel2.SetRowSpan(buttonAddCustomer, 2);
            buttonAddCustomer.Size = new Size(156, 98);
            buttonAddCustomer.TabIndex = 40;
            buttonAddCustomer.Text = "   Thêm";
            buttonAddCustomer.UseVisualStyleBackColor = false;
            buttonAddCustomer.Click += buttonAddCustomer_Click;
            // 
            // buttonEditCustomer
            // 
            buttonEditCustomer.BackColor = Color.DeepSkyBlue;
            buttonEditCustomer.Dock = DockStyle.Fill;
            buttonEditCustomer.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonEditCustomer.ForeColor = Color.White;
            buttonEditCustomer.Image = (Image)resources.GetObject("buttonEditCustomer.Image");
            buttonEditCustomer.ImageAlign = ContentAlignment.MiddleLeft;
            buttonEditCustomer.Location = new Point(1556, 113);
            buttonEditCustomer.Margin = new Padding(5);
            buttonEditCustomer.Name = "buttonEditCustomer";
            tableLayoutPanel2.SetRowSpan(buttonEditCustomer, 2);
            buttonEditCustomer.Size = new Size(156, 98);
            buttonEditCustomer.TabIndex = 42;
            buttonEditCustomer.Text = "   Sửa";
            buttonEditCustomer.UseVisualStyleBackColor = false;
            buttonEditCustomer.Click += buttonEditCustomer_Click;
            // 
            // buttonCancelCustomer
            // 
            buttonCancelCustomer.BackColor = Color.DeepSkyBlue;
            buttonCancelCustomer.Dock = DockStyle.Fill;
            buttonCancelCustomer.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonCancelCustomer.ForeColor = Color.White;
            buttonCancelCustomer.Image = (Image)resources.GetObject("buttonCancelCustomer.Image");
            buttonCancelCustomer.ImageAlign = ContentAlignment.MiddleLeft;
            buttonCancelCustomer.Location = new Point(1556, 329);
            buttonCancelCustomer.Margin = new Padding(5);
            buttonCancelCustomer.Name = "buttonCancelCustomer";
            tableLayoutPanel2.SetRowSpan(buttonCancelCustomer, 2);
            buttonCancelCustomer.Size = new Size(156, 98);
            buttonCancelCustomer.TabIndex = 43;
            buttonCancelCustomer.Text = "   Hủy";
            buttonCancelCustomer.UseVisualStyleBackColor = false;
            buttonCancelCustomer.Click += buttonCancelCustomer_Click;
            // 
            // buttonSaveCustomer
            // 
            buttonSaveCustomer.BackColor = Color.DeepSkyBlue;
            buttonSaveCustomer.Dock = DockStyle.Fill;
            buttonSaveCustomer.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonSaveCustomer.ForeColor = Color.White;
            buttonSaveCustomer.Image = (Image)resources.GetObject("buttonSaveCustomer.Image");
            buttonSaveCustomer.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSaveCustomer.Location = new Point(1556, 437);
            buttonSaveCustomer.Margin = new Padding(5);
            buttonSaveCustomer.Name = "buttonSaveCustomer";
            tableLayoutPanel2.SetRowSpan(buttonSaveCustomer, 2);
            buttonSaveCustomer.Size = new Size(156, 103);
            buttonSaveCustomer.TabIndex = 44;
            buttonSaveCustomer.Text = "   Lưu";
            buttonSaveCustomer.UseVisualStyleBackColor = false;
            buttonSaveCustomer.Click += buttonSaveCustomer_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1722, 5);
            pictureBox1.Margin = new Padding(5);
            pictureBox1.Name = "pictureBox1";
            tableLayoutPanel2.SetRowSpan(pictureBox1, 10);
            pictureBox1.Size = new Size(93, 535);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 45;
            pictureBox1.TabStop = false;
            // 
            // labelCustomerType
            // 
            labelCustomerType.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelCustomerType.AutoSize = true;
            labelCustomerType.BackColor = Color.Transparent;
            labelCustomerType.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            labelCustomerType.ForeColor = Color.Black;
            labelCustomerType.Location = new Point(288, 0);
            labelCustomerType.Margin = new Padding(5, 0, 5, 0);
            labelCustomerType.Name = "labelCustomerType";
            labelCustomerType.Size = new Size(170, 54);
            labelCustomerType.TabIndex = 22;
            labelCustomerType.Text = "Loại khách hàng";
            // 
            // comboBoxCustomerTypeName
            // 
            comboBoxCustomerTypeName.BackColor = SystemColors.Window;
            comboBoxCustomerTypeName.Dock = DockStyle.Fill;
            comboBoxCustomerTypeName.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCustomerTypeName.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxCustomerTypeName.FormattingEnabled = true;
            comboBoxCustomerTypeName.Items.AddRange(new object[] { "Cá nhân", "Doanh nghiệp" });
            comboBoxCustomerTypeName.Location = new Point(288, 59);
            comboBoxCustomerTypeName.Margin = new Padding(5);
            comboBoxCustomerTypeName.Name = "comboBoxCustomerTypeName";
            comboBoxCustomerTypeName.Size = new Size(222, 39);
            comboBoxCustomerTypeName.TabIndex = 26;
            // 
            // groupBoxDataCustomerManagement
            // 
            tableLayoutPanel1.SetColumnSpan(groupBoxDataCustomerManagement, 2);
            groupBoxDataCustomerManagement.Controls.Add(tableLayoutPanel3);
            groupBoxDataCustomerManagement.Controls.Add(panel3);
            groupBoxDataCustomerManagement.Dock = DockStyle.Fill;
            groupBoxDataCustomerManagement.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxDataCustomerManagement.ForeColor = SystemColors.HotTrack;
            groupBoxDataCustomerManagement.Location = new Point(5, 607);
            groupBoxDataCustomerManagement.Margin = new Padding(5);
            groupBoxDataCustomerManagement.Name = "groupBoxDataCustomerManagement";
            groupBoxDataCustomerManagement.Padding = new Padding(5);
            groupBoxDataCustomerManagement.Size = new Size(1830, 593);
            groupBoxDataCustomerManagement.TabIndex = 1;
            groupBoxDataCustomerManagement.TabStop = false;
            groupBoxDataCustomerManagement.Text = "Dữ liệu thông tin khách hàng";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 8;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.3214283F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.8035717F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.672866F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.597848952F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.1959591F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.1959591F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.1959591F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.934691F));
            tableLayoutPanel3.Controls.Add(buttonExportCSV, 6, 0);
            tableLayoutPanel3.Controls.Add(buttonExportExcel, 5, 0);
            tableLayoutPanel3.Controls.Add(buttonExportPDF, 4, 0);
            tableLayoutPanel3.Controls.Add(buttonCustomerSearch, 2, 0);
            tableLayoutPanel3.Controls.Add(dataCustomerManagement, 1, 1);
            tableLayoutPanel3.Controls.Add(labelCustomerFilter, 0, 0);
            tableLayoutPanel3.Controls.Add(label1, 0, 1);
            tableLayoutPanel3.Controls.Add(comboBoxCustomerTypeFilter, 0, 2);
            tableLayoutPanel3.Controls.Add(label2, 0, 3);
            tableLayoutPanel3.Controls.Add(label3, 0, 5);
            tableLayoutPanel3.Controls.Add(dateTimePickerFrom, 0, 4);
            tableLayoutPanel3.Controls.Add(dateTimePickerTo, 0, 6);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel4, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(5, 42);
            tableLayoutPanel3.Margin = new Padding(5);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 9;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 17.9860477F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 8.900739F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 12.3974581F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 8.264972F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1259232F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 7.94708872F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1259232F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 16.847826F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 5.40402031F));
            tableLayoutPanel3.Size = new Size(1820, 546);
            tableLayoutPanel3.TabIndex = 7;
            // 
            // buttonExportCSV
            // 
            buttonExportCSV.Dock = DockStyle.Fill;
            buttonExportCSV.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonExportCSV.ForeColor = Color.FromArgb(25, 137, 14);
            buttonExportCSV.Image = (Image)resources.GetObject("buttonExportCSV.Image");
            buttonExportCSV.Location = new Point(1474, 5);
            buttonExportCSV.Margin = new Padding(5);
            buttonExportCSV.Name = "buttonExportCSV";
            buttonExportCSV.Size = new Size(230, 88);
            buttonExportCSV.TabIndex = 35;
            buttonExportCSV.Text = "Xuất CSV";
            buttonExportCSV.TextAlign = ContentAlignment.MiddleLeft;
            buttonExportCSV.TextImageRelation = TextImageRelation.TextBeforeImage;
            buttonExportCSV.UseVisualStyleBackColor = true;
            buttonExportCSV.Click += buttonExportCSV_Click;
            // 
            // buttonExportExcel
            // 
            buttonExportExcel.Dock = DockStyle.Fill;
            buttonExportExcel.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonExportExcel.ForeColor = Color.FromArgb(20, 169, 6);
            buttonExportExcel.Image = (Image)resources.GetObject("buttonExportExcel.Image");
            buttonExportExcel.Location = new Point(1234, 5);
            buttonExportExcel.Margin = new Padding(5);
            buttonExportExcel.Name = "buttonExportExcel";
            buttonExportExcel.Size = new Size(230, 88);
            buttonExportExcel.TabIndex = 34;
            buttonExportExcel.Text = "Xuất Excel";
            buttonExportExcel.TextAlign = ContentAlignment.MiddleLeft;
            buttonExportExcel.TextImageRelation = TextImageRelation.TextBeforeImage;
            buttonExportExcel.UseVisualStyleBackColor = true;
            buttonExportExcel.Click += buttonExportExcel_Click;
            // 
            // buttonExportPDF
            // 
            buttonExportPDF.Dock = DockStyle.Fill;
            buttonExportPDF.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonExportPDF.ForeColor = Color.FromArgb(207, 0, 0);
            buttonExportPDF.Image = (Image)resources.GetObject("buttonExportPDF.Image");
            buttonExportPDF.Location = new Point(994, 5);
            buttonExportPDF.Margin = new Padding(5);
            buttonExportPDF.Name = "buttonExportPDF";
            buttonExportPDF.Size = new Size(230, 88);
            buttonExportPDF.TabIndex = 33;
            buttonExportPDF.Text = "Xuất PDF";
            buttonExportPDF.TextAlign = ContentAlignment.MiddleLeft;
            buttonExportPDF.TextImageRelation = TextImageRelation.TextBeforeImage;
            buttonExportPDF.UseVisualStyleBackColor = true;
            buttonExportPDF.Click += buttonExportPDF_Click;
            // 
            // buttonCustomerSearch
            // 
            buttonCustomerSearch.BackColor = SystemColors.HotTrack;
            buttonCustomerSearch.Dock = DockStyle.Fill;
            buttonCustomerSearch.ForeColor = Color.White;
            buttonCustomerSearch.Image = (Image)resources.GetObject("buttonCustomerSearch.Image");
            buttonCustomerSearch.Location = new Point(881, 5);
            buttonCustomerSearch.Margin = new Padding(5);
            buttonCustomerSearch.Name = "buttonCustomerSearch";
            buttonCustomerSearch.Size = new Size(93, 88);
            buttonCustomerSearch.TabIndex = 5;
            toolTip1.SetToolTip(buttonCustomerSearch, "Tìm kiếm");
            buttonCustomerSearch.UseVisualStyleBackColor = false;
            buttonCustomerSearch.Click += buttonCustomerSearch_Click;
            // 
            // dataCustomerManagement
            // 
            dataCustomerManagement.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataCustomerManagement.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataCustomerManagement.BackgroundColor = Color.White;
            dataCustomerManagement.BorderStyle = BorderStyle.None;
            dataCustomerManagement.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            dataCustomerManagement.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataCustomerManagement.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataCustomerManagement.ColumnHeadersHeight = 29;
            dataCustomerManagement.Columns.AddRange(new DataGridViewColumn[] { CustomerID, CustomerTypeName, FullName, Gender, DateOfBirth, Nationality, CitizenID, CustomerAddress, Phone, Email, RegistrationDate });
            tableLayoutPanel3.SetColumnSpan(dataCustomerManagement, 7);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.HotTrack;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.HotTrack;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataCustomerManagement.DefaultCellStyle = dataGridViewCellStyle2;
            dataCustomerManagement.Dock = DockStyle.Fill;
            dataCustomerManagement.EnableHeadersVisualStyles = false;
            dataCustomerManagement.GridColor = Color.White;
            dataCustomerManagement.Location = new Point(320, 103);
            dataCustomerManagement.Margin = new Padding(5);
            dataCustomerManagement.Name = "dataCustomerManagement";
            dataCustomerManagement.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataCustomerManagement.RowHeadersVisible = false;
            dataCustomerManagement.RowHeadersWidth = 51;
            tableLayoutPanel3.SetRowSpan(dataCustomerManagement, 8);
            dataCustomerManagement.Size = new Size(1495, 438);
            dataCustomerManagement.TabIndex = 26;
            // 
            // CustomerID
            // 
            CustomerID.HeaderText = "Mã khách hàng";
            CustomerID.MinimumWidth = 6;
            CustomerID.Name = "CustomerID";
            CustomerID.Width = 263;
            // 
            // CustomerTypeName
            // 
            CustomerTypeName.HeaderText = "Loại khách hàng";
            CustomerTypeName.MinimumWidth = 6;
            CustomerTypeName.Name = "CustomerTypeName";
            CustomerTypeName.Width = 281;
            // 
            // FullName
            // 
            FullName.HeaderText = "Họ tên";
            FullName.MinimumWidth = 6;
            FullName.Name = "FullName";
            FullName.Width = 146;
            // 
            // Gender
            // 
            Gender.HeaderText = "Giới tính";
            Gender.MinimumWidth = 6;
            Gender.Name = "Gender";
            Gender.Width = 172;
            // 
            // DateOfBirth
            // 
            DateOfBirth.HeaderText = "Ngày sinh";
            DateOfBirth.MinimumWidth = 6;
            DateOfBirth.Name = "DateOfBirth";
            DateOfBirth.Width = 192;
            // 
            // Nationality
            // 
            Nationality.HeaderText = "Quốc tịch";
            Nationality.MinimumWidth = 6;
            Nationality.Name = "Nationality";
            Nationality.Width = 186;
            // 
            // CitizenID
            // 
            CitizenID.HeaderText = "CCCD/Passport";
            CitizenID.MinimumWidth = 6;
            CitizenID.Name = "CitizenID";
            CitizenID.Width = 270;
            // 
            // CustomerAddress
            // 
            CustomerAddress.HeaderText = "Địa chỉ";
            CustomerAddress.MinimumWidth = 6;
            CustomerAddress.Name = "CustomerAddress";
            CustomerAddress.Width = 151;
            // 
            // Phone
            // 
            Phone.HeaderText = "SĐT";
            Phone.MinimumWidth = 6;
            Phone.Name = "Phone";
            Phone.Width = 116;
            // 
            // Email
            // 
            Email.HeaderText = "Email";
            Email.MinimumWidth = 6;
            Email.Name = "Email";
            Email.Width = 134;
            // 
            // RegistrationDate
            // 
            RegistrationDate.HeaderText = "Ngày đăng kí";
            RegistrationDate.MinimumWidth = 6;
            RegistrationDate.Name = "RegistrationDate";
            RegistrationDate.Width = 234;
            // 
            // labelCustomerFilter
            // 
            labelCustomerFilter.Anchor = AnchorStyles.Bottom;
            labelCustomerFilter.AutoSize = true;
            labelCustomerFilter.BackColor = Color.Transparent;
            labelCustomerFilter.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            labelCustomerFilter.ForeColor = Color.Black;
            labelCustomerFilter.Location = new Point(39, 66);
            labelCustomerFilter.Margin = new Padding(5, 0, 5, 0);
            labelCustomerFilter.Name = "labelCustomerFilter";
            labelCustomerFilter.Size = new Size(237, 32);
            labelCustomerFilter.TabIndex = 24;
            labelCustomerFilter.Text = "Lọc khách hàng:";
            labelCustomerFilter.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(5, 114);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(238, 32);
            label1.TabIndex = 27;
            label1.Text = "Loại khách hàng";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBoxCustomerTypeFilter
            // 
            comboBoxCustomerTypeFilter.BackColor = SystemColors.Window;
            comboBoxCustomerTypeFilter.Dock = DockStyle.Fill;
            comboBoxCustomerTypeFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCustomerTypeFilter.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxCustomerTypeFilter.FormattingEnabled = true;
            comboBoxCustomerTypeFilter.Items.AddRange(new object[] { "Không áp dụng", "Cá nhân", "Doanh nghiệp", "VIP Cá nhân", "VIP Doanh nghiệp" });
            comboBoxCustomerTypeFilter.Location = new Point(5, 151);
            comboBoxCustomerTypeFilter.Margin = new Padding(5);
            comboBoxCustomerTypeFilter.Name = "comboBoxCustomerTypeFilter";
            comboBoxCustomerTypeFilter.Size = new Size(305, 45);
            comboBoxCustomerTypeFilter.TabIndex = 25;
            comboBoxCustomerTypeFilter.SelectedIndexChanged += comboBoxCustomerTypeFilter_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(5, 226);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(49, 32);
            label2.TabIndex = 28;
            label2.Text = "Từ";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(5, 329);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(69, 32);
            label3.TabIndex = 29;
            label3.Text = "Đến";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dateTimePickerFrom
            // 
            dateTimePickerFrom.CalendarFont = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePickerFrom.Dock = DockStyle.Fill;
            dateTimePickerFrom.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePickerFrom.Format = DateTimePickerFormat.Short;
            dateTimePickerFrom.Location = new Point(5, 263);
            dateTimePickerFrom.Margin = new Padding(5);
            dateTimePickerFrom.Name = "dateTimePickerFrom";
            dateTimePickerFrom.Size = new Size(305, 38);
            dateTimePickerFrom.TabIndex = 30;
            dateTimePickerFrom.ValueChanged += dateTimePickerFrom_ValueChanged;
            // 
            // dateTimePickerTo
            // 
            dateTimePickerTo.CalendarFont = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePickerTo.Dock = DockStyle.Fill;
            dateTimePickerTo.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePickerTo.Format = DateTimePickerFormat.Short;
            dateTimePickerTo.Location = new Point(5, 366);
            dateTimePickerTo.Margin = new Padding(5);
            dateTimePickerTo.Name = "dateTimePickerTo";
            dateTimePickerTo.Size = new Size(305, 38);
            dateTimePickerTo.TabIndex = 31;
            dateTimePickerTo.ValueChanged += dateTimePickerTo_ValueChanged;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(textBoxCustomerSearch, 0, 1);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(320, 5);
            tableLayoutPanel4.Margin = new Padding(5);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 3;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 14.54545F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 70.90909F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 14.545455F));
            tableLayoutPanel4.Size = new Size(551, 88);
            tableLayoutPanel4.TabIndex = 36;
            // 
            // textBoxCustomerSearch
            // 
            textBoxCustomerSearch.Dock = DockStyle.Fill;
            textBoxCustomerSearch.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxCustomerSearch.Location = new Point(5, 17);
            textBoxCustomerSearch.Margin = new Padding(5);
            textBoxCustomerSearch.Name = "textBoxCustomerSearch";
            textBoxCustomerSearch.PlaceholderText = "Tìm kiếm . . .";
            textBoxCustomerSearch.Size = new Size(541, 44);
            textBoxCustomerSearch.TabIndex = 1;
            textBoxCustomerSearch.WordWrap = false;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.HotTrack;
            panel3.Location = new Point(457, 18);
            panel3.Margin = new Padding(5);
            panel3.Name = "panel3";
            panel3.Size = new Size(731, 8);
            panel3.TabIndex = 6;
            // 
            // UC_CustomerManagement
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(5);
            Name = "UC_CustomerManagement";
            Size = new Size(1840, 1205);
            tableLayoutPanel1.ResumeLayout(false);
            groupBoxCustomerInfo.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBoxDataCustomerManagement.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataCustomerManagement).EndInit();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBoxCustomerInfo;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel1;
        private Label labelNationality;
        private Label labelGender;
        private Label labelDateOfBirth;
        private Label labelFullName;
        private Label labelCustomerID;
        private Label labelCustomerType;
        private TextBox textBoxCustomerID;
        private TextBox textBoxFullName;
        private ComboBox comboBoxGender;
        private ComboBox comboBoxCustomerTypeName;
        private TextBox textBoxNationality;
        private DateTimePicker dateTimePickerDateOfBirth;
        private Label labelRegistrationDate;
        private Label labelAddress;
        private Label labelCitizenID;
        private Label labelPhone;
        private Label labelEmail;
        private TextBox textBoxCitizenID;
        private TextBox textBoxAddress;
        private TextBox textBoxPhone;
        private TextBox textBoxEmail;
        private DateTimePicker dateTimePickerRegistrationDate;
        private Panel panel2;
        private Button buttonAddCustomer;
        private Button buttonEditCustomer;
        private Button buttonCancelCustomer;
        private Button buttonSaveCustomer;
        private PictureBox pictureBox1;
        private GroupBox groupBoxDataCustomerManagement;
        private Panel panel3;
        private TableLayoutPanel tableLayoutPanel3;
        private TextBox textBoxCustomerSearch;
        private Button buttonCustomerSearch;
        private ToolTip toolTip1;
        private Label labelCustomerFilter;
        private ComboBox comboBoxCustomerTypeFilter;
        private DataGridView dataCustomerManagement;
        private Label label1;
        private Label label2;
        private Label label3;
        private DateTimePicker dateTimePickerFrom;
        private DateTimePicker dateTimePickerTo;
        private Button buttonExportPDF;
        private Button buttonExportExcel;
        private Button buttonExportCSV;
        private TableLayoutPanel tableLayoutPanel4;
        private DataGridViewTextBoxColumn CustomerID;
        private DataGridViewTextBoxColumn CustomerTypeName;
        private DataGridViewTextBoxColumn FullName;
        private DataGridViewTextBoxColumn Gender;
        private DataGridViewTextBoxColumn DateOfBirth;
        private DataGridViewTextBoxColumn Nationality;
        private DataGridViewTextBoxColumn CitizenID;
        private DataGridViewTextBoxColumn CustomerAddress;
        private DataGridViewTextBoxColumn Phone;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn RegistrationDate;
    }
}
