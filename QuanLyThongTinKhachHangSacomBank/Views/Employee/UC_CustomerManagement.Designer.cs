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
            buttonDeleteCustomer = new Button();
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
            CustomerType = new DataGridViewTextBoxColumn();
            FullName = new DataGridViewTextBoxColumn();
            Gender = new DataGridViewTextBoxColumn();
            DateOfBirth = new DataGridViewTextBoxColumn();
            Nationality = new DataGridViewTextBoxColumn();
            CitizenID = new DataGridViewTextBoxColumn();
            Address = new DataGridViewTextBoxColumn();
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
            buttonFilterConfirm = new Button();
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
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1132, 753);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBoxCustomerInfo
            // 
            tableLayoutPanel1.SetColumnSpan(groupBoxCustomerInfo, 2);
            groupBoxCustomerInfo.Controls.Add(panel1);
            groupBoxCustomerInfo.Controls.Add(tableLayoutPanel2);
            groupBoxCustomerInfo.Dock = DockStyle.Fill;
            groupBoxCustomerInfo.Font = new Font("Roboto SemiCondensed Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxCustomerInfo.ForeColor = SystemColors.HotTrack;
            groupBoxCustomerInfo.Location = new Point(3, 3);
            groupBoxCustomerInfo.Name = "groupBoxCustomerInfo";
            groupBoxCustomerInfo.Size = new Size(1126, 370);
            groupBoxCustomerInfo.TabIndex = 0;
            groupBoxCustomerInfo.TabStop = false;
            groupBoxCustomerInfo.Text = "Thông tin khách hàng";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.HotTrack;
            panel1.Location = new Point(218, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(236, 5);
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
            tableLayoutPanel2.Controls.Add(buttonDeleteCustomer, 5, 2);
            tableLayoutPanel2.Controls.Add(buttonEditCustomer, 5, 4);
            tableLayoutPanel2.Controls.Add(buttonCancelCustomer, 5, 6);
            tableLayoutPanel2.Controls.Add(buttonSaveCustomer, 5, 8);
            tableLayoutPanel2.Controls.Add(pictureBox1, 6, 0);
            tableLayoutPanel2.Controls.Add(labelCustomerType, 1, 0);
            tableLayoutPanel2.Controls.Add(comboBoxCustomerTypeName, 1, 1);
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
            tableLayoutPanel2.TabIndex = 0;
            // 
            // labelCustomerID
            // 
            labelCustomerID.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelCustomerID.AutoSize = true;
            labelCustomerID.BackColor = Color.Transparent;
            labelCustomerID.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelCustomerID.ForeColor = Color.Black;
            labelCustomerID.Location = new Point(3, 13);
            labelCustomerID.Name = "labelCustomerID";
            labelCustomerID.Size = new Size(120, 20);
            labelCustomerID.TabIndex = 9;
            labelCustomerID.Text = "Mã khách hàng";
            // 
            // labelFullName
            // 
            labelFullName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelFullName.AutoSize = true;
            labelFullName.BackColor = Color.Transparent;
            labelFullName.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelFullName.ForeColor = Color.Black;
            labelFullName.Location = new Point(3, 79);
            labelFullName.Name = "labelFullName";
            labelFullName.Size = new Size(56, 20);
            labelFullName.TabIndex = 10;
            labelFullName.Text = "Họ tên";
            // 
            // labelGender
            // 
            labelGender.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelGender.AutoSize = true;
            labelGender.BackColor = Color.Transparent;
            labelGender.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelGender.ForeColor = Color.Black;
            labelGender.Location = new Point(3, 145);
            labelGender.Name = "labelGender";
            labelGender.Size = new Size(69, 20);
            labelGender.TabIndex = 12;
            labelGender.Text = "Giới tính";
            // 
            // labelNationality
            // 
            labelNationality.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelNationality.AutoSize = true;
            labelNationality.BackColor = Color.Transparent;
            labelNationality.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelNationality.ForeColor = Color.Black;
            labelNationality.Location = new Point(3, 277);
            labelNationality.Name = "labelNationality";
            labelNationality.Size = new Size(76, 20);
            labelNationality.TabIndex = 13;
            labelNationality.Text = "Quốc tịch";
            // 
            // labelDateOfBirth
            // 
            labelDateOfBirth.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelDateOfBirth.AutoSize = true;
            labelDateOfBirth.BackColor = Color.Transparent;
            labelDateOfBirth.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelDateOfBirth.ForeColor = Color.Black;
            labelDateOfBirth.Location = new Point(3, 211);
            labelDateOfBirth.Name = "labelDateOfBirth";
            labelDateOfBirth.Size = new Size(80, 20);
            labelDateOfBirth.TabIndex = 11;
            labelDateOfBirth.Text = "Ngày sinh";
            // 
            // textBoxCustomerID
            // 
            textBoxCustomerID.BackColor = SystemColors.InactiveCaption;
            textBoxCustomerID.Dock = DockStyle.Fill;
            textBoxCustomerID.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxCustomerID.Location = new Point(3, 36);
            textBoxCustomerID.Name = "textBoxCustomerID";
            textBoxCustomerID.Size = new Size(168, 28);
            textBoxCustomerID.TabIndex = 23;
            // 
            // textBoxFullName
            // 
            textBoxFullName.BackColor = SystemColors.InactiveCaption;
            tableLayoutPanel2.SetColumnSpan(textBoxFullName, 2);
            textBoxFullName.Dock = DockStyle.Fill;
            textBoxFullName.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxFullName.Location = new Point(3, 102);
            textBoxFullName.Name = "textBoxFullName";
            textBoxFullName.Size = new Size(311, 28);
            textBoxFullName.TabIndex = 24;
            // 
            // comboBoxGender
            // 
            comboBoxGender.BackColor = SystemColors.Window;
            tableLayoutPanel2.SetColumnSpan(comboBoxGender, 2);
            comboBoxGender.Dock = DockStyle.Fill;
            comboBoxGender.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGender.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxGender.FormattingEnabled = true;
            comboBoxGender.Items.AddRange(new object[] { "Nam", "Nữ" });
            comboBoxGender.Location = new Point(3, 168);
            comboBoxGender.Name = "comboBoxGender";
            comboBoxGender.Size = new Size(311, 28);
            comboBoxGender.TabIndex = 25;
            // 
            // textBoxNationality
            // 
            textBoxNationality.BackColor = SystemColors.InactiveCaption;
            tableLayoutPanel2.SetColumnSpan(textBoxNationality, 2);
            textBoxNationality.Dock = DockStyle.Fill;
            textBoxNationality.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxNationality.Location = new Point(3, 300);
            textBoxNationality.Name = "textBoxNationality";
            textBoxNationality.Size = new Size(311, 28);
            textBoxNationality.TabIndex = 27;
            // 
            // dateTimePickerDateOfBirth
            // 
            dateTimePickerDateOfBirth.CalendarFont = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePickerDateOfBirth.CalendarMonthBackground = SystemColors.InactiveCaption;
            tableLayoutPanel2.SetColumnSpan(dateTimePickerDateOfBirth, 2);
            dateTimePickerDateOfBirth.Dock = DockStyle.Fill;
            dateTimePickerDateOfBirth.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePickerDateOfBirth.Location = new Point(3, 234);
            dateTimePickerDateOfBirth.Name = "dateTimePickerDateOfBirth";
            dateTimePickerDateOfBirth.Size = new Size(311, 28);
            dateTimePickerDateOfBirth.TabIndex = 28;
            // 
            // labelCitizenID
            // 
            labelCitizenID.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelCitizenID.AutoSize = true;
            labelCitizenID.BackColor = Color.Transparent;
            labelCitizenID.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelCitizenID.ForeColor = Color.Black;
            labelCitizenID.Location = new Point(328, 13);
            labelCitizenID.Name = "labelCitizenID";
            labelCitizenID.Size = new Size(119, 20);
            labelCitizenID.TabIndex = 29;
            labelCitizenID.Text = "CCCD/Passport";
            // 
            // labelAddress
            // 
            labelAddress.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelAddress.AutoSize = true;
            labelAddress.BackColor = Color.Transparent;
            labelAddress.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelAddress.ForeColor = Color.Black;
            labelAddress.Location = new Point(328, 79);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(59, 20);
            labelAddress.TabIndex = 30;
            labelAddress.Text = "Địa chỉ";
            // 
            // labelEmail
            // 
            labelEmail.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelEmail.AutoSize = true;
            labelEmail.BackColor = Color.Transparent;
            labelEmail.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelEmail.ForeColor = Color.Black;
            labelEmail.Location = new Point(328, 211);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(49, 20);
            labelEmail.TabIndex = 32;
            labelEmail.Text = "Email";
            // 
            // labelRegistrationDate
            // 
            labelRegistrationDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelRegistrationDate.AutoSize = true;
            labelRegistrationDate.BackColor = Color.Transparent;
            labelRegistrationDate.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelRegistrationDate.ForeColor = Color.Black;
            labelRegistrationDate.Location = new Point(328, 277);
            labelRegistrationDate.Name = "labelRegistrationDate";
            labelRegistrationDate.Size = new Size(105, 20);
            labelRegistrationDate.TabIndex = 33;
            labelRegistrationDate.Text = "Ngày đăng kí";
            // 
            // textBoxCitizenID
            // 
            textBoxCitizenID.BackColor = SystemColors.InactiveCaption;
            textBoxCitizenID.Dock = DockStyle.Fill;
            textBoxCitizenID.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxCitizenID.Location = new Point(328, 36);
            textBoxCitizenID.Name = "textBoxCitizenID";
            textBoxCitizenID.Size = new Size(611, 28);
            textBoxCitizenID.TabIndex = 34;
            // 
            // textBoxAddress
            // 
            textBoxAddress.BackColor = SystemColors.InactiveCaption;
            textBoxAddress.Dock = DockStyle.Fill;
            textBoxAddress.Font = new Font("Roboto", 10.2F);
            textBoxAddress.Location = new Point(328, 102);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(611, 28);
            textBoxAddress.TabIndex = 35;
            // 
            // textBoxPhone
            // 
            textBoxPhone.BackColor = SystemColors.InactiveCaption;
            textBoxPhone.Dock = DockStyle.Fill;
            textBoxPhone.Font = new Font("Roboto", 10.2F);
            textBoxPhone.Location = new Point(328, 168);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(611, 28);
            textBoxPhone.TabIndex = 36;
            // 
            // labelPhone
            // 
            labelPhone.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelPhone.AutoSize = true;
            labelPhone.BackColor = Color.Transparent;
            labelPhone.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelPhone.ForeColor = Color.Black;
            labelPhone.Location = new Point(328, 145);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(39, 20);
            labelPhone.TabIndex = 31;
            labelPhone.Text = "SĐT";
            // 
            // textBoxEmail
            // 
            textBoxEmail.BackColor = SystemColors.InactiveCaption;
            textBoxEmail.Dock = DockStyle.Fill;
            textBoxEmail.Font = new Font("Roboto", 10.2F);
            textBoxEmail.Location = new Point(328, 234);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(611, 28);
            textBoxEmail.TabIndex = 37;
            // 
            // dateTimePickerRegistrationDate
            // 
            dateTimePickerRegistrationDate.CalendarFont = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePickerRegistrationDate.CalendarMonthBackground = SystemColors.InactiveCaption;
            dateTimePickerRegistrationDate.Dock = DockStyle.Fill;
            dateTimePickerRegistrationDate.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePickerRegistrationDate.Location = new Point(328, 300);
            dateTimePickerRegistrationDate.Name = "dateTimePickerRegistrationDate";
            dateTimePickerRegistrationDate.Size = new Size(611, 28);
            dateTimePickerRegistrationDate.TabIndex = 38;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.HotTrack;
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(945, 3);
            panel2.Name = "panel2";
            tableLayoutPanel2.SetRowSpan(panel2, 10);
            panel2.Size = new Size(6, 333);
            panel2.TabIndex = 39;
            // 
            // buttonAddCustomer
            // 
            buttonAddCustomer.BackColor = Color.DeepSkyBlue;
            buttonAddCustomer.Dock = DockStyle.Fill;
            buttonAddCustomer.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonAddCustomer.ForeColor = Color.White;
            buttonAddCustomer.Image = (Image)resources.GetObject("buttonAddCustomer.Image");
            buttonAddCustomer.ImageAlign = ContentAlignment.MiddleLeft;
            buttonAddCustomer.Location = new Point(957, 3);
            buttonAddCustomer.Name = "buttonAddCustomer";
            tableLayoutPanel2.SetRowSpan(buttonAddCustomer, 2);
            buttonAddCustomer.Size = new Size(96, 60);
            buttonAddCustomer.TabIndex = 40;
            buttonAddCustomer.Text = "   Thêm";
            buttonAddCustomer.UseVisualStyleBackColor = false;
            // 
            // buttonDeleteCustomer
            // 
            buttonDeleteCustomer.BackColor = Color.DeepSkyBlue;
            buttonDeleteCustomer.Dock = DockStyle.Fill;
            buttonDeleteCustomer.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonDeleteCustomer.ForeColor = Color.White;
            buttonDeleteCustomer.Image = (Image)resources.GetObject("buttonDeleteCustomer.Image");
            buttonDeleteCustomer.ImageAlign = ContentAlignment.MiddleLeft;
            buttonDeleteCustomer.Location = new Point(957, 69);
            buttonDeleteCustomer.Name = "buttonDeleteCustomer";
            tableLayoutPanel2.SetRowSpan(buttonDeleteCustomer, 2);
            buttonDeleteCustomer.Size = new Size(96, 60);
            buttonDeleteCustomer.TabIndex = 41;
            buttonDeleteCustomer.Text = "   Xóa";
            buttonDeleteCustomer.UseVisualStyleBackColor = false;
            // 
            // buttonEditCustomer
            // 
            buttonEditCustomer.BackColor = Color.DeepSkyBlue;
            buttonEditCustomer.Dock = DockStyle.Fill;
            buttonEditCustomer.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonEditCustomer.ForeColor = Color.White;
            buttonEditCustomer.Image = (Image)resources.GetObject("buttonEditCustomer.Image");
            buttonEditCustomer.ImageAlign = ContentAlignment.MiddleLeft;
            buttonEditCustomer.Location = new Point(957, 135);
            buttonEditCustomer.Name = "buttonEditCustomer";
            tableLayoutPanel2.SetRowSpan(buttonEditCustomer, 2);
            buttonEditCustomer.Size = new Size(96, 60);
            buttonEditCustomer.TabIndex = 42;
            buttonEditCustomer.Text = "   Sửa";
            buttonEditCustomer.UseVisualStyleBackColor = false;
            // 
            // buttonCancelCustomer
            // 
            buttonCancelCustomer.BackColor = Color.DeepSkyBlue;
            buttonCancelCustomer.Dock = DockStyle.Fill;
            buttonCancelCustomer.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonCancelCustomer.ForeColor = Color.White;
            buttonCancelCustomer.Image = (Image)resources.GetObject("buttonCancelCustomer.Image");
            buttonCancelCustomer.ImageAlign = ContentAlignment.MiddleLeft;
            buttonCancelCustomer.Location = new Point(957, 201);
            buttonCancelCustomer.Name = "buttonCancelCustomer";
            tableLayoutPanel2.SetRowSpan(buttonCancelCustomer, 2);
            buttonCancelCustomer.Size = new Size(96, 60);
            buttonCancelCustomer.TabIndex = 43;
            buttonCancelCustomer.Text = "   Hủy";
            buttonCancelCustomer.UseVisualStyleBackColor = false;
            // 
            // buttonSaveCustomer
            // 
            buttonSaveCustomer.BackColor = Color.DeepSkyBlue;
            buttonSaveCustomer.Dock = DockStyle.Fill;
            buttonSaveCustomer.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonSaveCustomer.ForeColor = Color.White;
            buttonSaveCustomer.Image = (Image)resources.GetObject("buttonSaveCustomer.Image");
            buttonSaveCustomer.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSaveCustomer.Location = new Point(957, 267);
            buttonSaveCustomer.Name = "buttonSaveCustomer";
            tableLayoutPanel2.SetRowSpan(buttonSaveCustomer, 2);
            buttonSaveCustomer.Size = new Size(96, 69);
            buttonSaveCustomer.TabIndex = 44;
            buttonSaveCustomer.Text = "   Lưu";
            buttonSaveCustomer.UseVisualStyleBackColor = false;
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
            // labelCustomerType
            // 
            labelCustomerType.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelCustomerType.AutoSize = true;
            labelCustomerType.BackColor = Color.Transparent;
            labelCustomerType.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelCustomerType.ForeColor = Color.Black;
            labelCustomerType.Location = new Point(177, 13);
            labelCustomerType.Name = "labelCustomerType";
            labelCustomerType.Size = new Size(128, 20);
            labelCustomerType.TabIndex = 22;
            labelCustomerType.Text = "Loại khách hàng";
            // 
            // comboBoxCustomerTypeName
            // 
            comboBoxCustomerTypeName.BackColor = SystemColors.Window;
            comboBoxCustomerTypeName.Dock = DockStyle.Fill;
            comboBoxCustomerTypeName.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCustomerTypeName.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxCustomerTypeName.FormattingEnabled = true;
            comboBoxCustomerTypeName.Items.AddRange(new object[] { "Cá nhân", "Doanh nghiệp" });
            comboBoxCustomerTypeName.Location = new Point(177, 36);
            comboBoxCustomerTypeName.Name = "comboBoxCustomerTypeName";
            comboBoxCustomerTypeName.Size = new Size(137, 28);
            comboBoxCustomerTypeName.TabIndex = 26;
            // 
            // groupBoxDataCustomerManagement
            // 
            tableLayoutPanel1.SetColumnSpan(groupBoxDataCustomerManagement, 2);
            groupBoxDataCustomerManagement.Controls.Add(tableLayoutPanel3);
            groupBoxDataCustomerManagement.Controls.Add(panel3);
            groupBoxDataCustomerManagement.Dock = DockStyle.Fill;
            groupBoxDataCustomerManagement.Font = new Font("Roboto SemiCondensed Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxDataCustomerManagement.ForeColor = SystemColors.HotTrack;
            groupBoxDataCustomerManagement.Location = new Point(3, 379);
            groupBoxDataCustomerManagement.Name = "groupBoxDataCustomerManagement";
            groupBoxDataCustomerManagement.Size = new Size(1126, 371);
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
            tableLayoutPanel3.Controls.Add(buttonFilterConfirm, 0, 7);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel4, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 28);
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
            tableLayoutPanel3.Size = new Size(1120, 340);
            tableLayoutPanel3.TabIndex = 7;
            // 
            // buttonExportCSV
            // 
            buttonExportCSV.Dock = DockStyle.Fill;
            buttonExportCSV.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonExportCSV.ForeColor = Color.FromArgb(25, 137, 14);
            buttonExportCSV.Image = (Image)resources.GetObject("buttonExportCSV.Image");
            buttonExportCSV.Location = new Point(905, 3);
            buttonExportCSV.Name = "buttonExportCSV";
            buttonExportCSV.Size = new Size(141, 55);
            buttonExportCSV.TabIndex = 35;
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
            buttonExportExcel.Location = new Point(758, 3);
            buttonExportExcel.Name = "buttonExportExcel";
            buttonExportExcel.Size = new Size(141, 55);
            buttonExportExcel.TabIndex = 34;
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
            buttonExportPDF.Location = new Point(611, 3);
            buttonExportPDF.Name = "buttonExportPDF";
            buttonExportPDF.Size = new Size(141, 55);
            buttonExportPDF.TabIndex = 33;
            buttonExportPDF.Text = "Xuất PDF";
            buttonExportPDF.TextAlign = ContentAlignment.MiddleLeft;
            buttonExportPDF.TextImageRelation = TextImageRelation.TextBeforeImage;
            buttonExportPDF.UseVisualStyleBackColor = true;
            // 
            // buttonCustomerSearch
            // 
            buttonCustomerSearch.BackColor = SystemColors.HotTrack;
            buttonCustomerSearch.Dock = DockStyle.Fill;
            buttonCustomerSearch.ForeColor = Color.White;
            buttonCustomerSearch.Image = (Image)resources.GetObject("buttonCustomerSearch.Image");
            buttonCustomerSearch.Location = new Point(542, 3);
            buttonCustomerSearch.Name = "buttonCustomerSearch";
            buttonCustomerSearch.Size = new Size(57, 55);
            buttonCustomerSearch.TabIndex = 5;
            toolTip1.SetToolTip(buttonCustomerSearch, "Tìm kiếm");
            buttonCustomerSearch.UseVisualStyleBackColor = false;
            // 
            // dataCustomerManagement
            // 
            dataCustomerManagement.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataCustomerManagement.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataCustomerManagement.BackgroundColor = Color.White;
            dataCustomerManagement.BorderStyle = BorderStyle.None;
            dataCustomerManagement.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            dataCustomerManagement.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataCustomerManagement.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataCustomerManagement.ColumnHeadersHeight = 29;
            dataCustomerManagement.Columns.AddRange(new DataGridViewColumn[] { CustomerID, CustomerType, FullName, Gender, DateOfBirth, Nationality, CitizenID, Address, Phone, Email, RegistrationDate });
            tableLayoutPanel3.SetColumnSpan(dataCustomerManagement, 7);
            dataCustomerManagement.Dock = DockStyle.Fill;
            dataCustomerManagement.EnableHeadersVisualStyles = false;
            dataCustomerManagement.GridColor = Color.White;
            dataCustomerManagement.Location = new Point(197, 64);
            dataCustomerManagement.Name = "dataCustomerManagement";
            dataCustomerManagement.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataCustomerManagement.RowHeadersVisible = false;
            dataCustomerManagement.RowHeadersWidth = 51;
            tableLayoutPanel3.SetRowSpan(dataCustomerManagement, 8);
            dataCustomerManagement.Size = new Size(920, 273);
            dataCustomerManagement.TabIndex = 26;
            dataCustomerManagement.CellContentClick += dataCustomerManagement_CellContentClick;
            // 
            // CustomerID
            // 
            CustomerID.HeaderText = "Mã khách hàng";
            CustomerID.MinimumWidth = 6;
            CustomerID.Name = "CustomerID";
            // 
            // CustomerType
            // 
            CustomerType.HeaderText = "Loại khách hàng";
            CustomerType.MinimumWidth = 6;
            CustomerType.Name = "CustomerType";
            // 
            // FullName
            // 
            FullName.HeaderText = "Họ tên";
            FullName.MinimumWidth = 6;
            FullName.Name = "FullName";
            // 
            // Gender
            // 
            Gender.HeaderText = "Giới tính";
            Gender.MinimumWidth = 6;
            Gender.Name = "Gender";
            // 
            // DateOfBirth
            // 
            DateOfBirth.HeaderText = "Ngày sinh";
            DateOfBirth.MinimumWidth = 6;
            DateOfBirth.Name = "DateOfBirth";
            // 
            // Nationality
            // 
            Nationality.HeaderText = "Quốc tịch";
            Nationality.MinimumWidth = 6;
            Nationality.Name = "Nationality";
            // 
            // CitizenID
            // 
            CitizenID.HeaderText = "CCCD/Passport";
            CitizenID.MinimumWidth = 6;
            CitizenID.Name = "CitizenID";
            // 
            // Address
            // 
            Address.HeaderText = "Địa chỉ";
            Address.MinimumWidth = 6;
            Address.Name = "Address";
            // 
            // Phone
            // 
            Phone.HeaderText = "SĐT";
            Phone.MinimumWidth = 6;
            Phone.Name = "Phone";
            // 
            // Email
            // 
            Email.HeaderText = "Email";
            Email.MinimumWidth = 6;
            Email.Name = "Email";
            // 
            // RegistrationDate
            // 
            RegistrationDate.HeaderText = "Ngày đăng kí";
            RegistrationDate.MinimumWidth = 6;
            RegistrationDate.Name = "RegistrationDate";
            // 
            // labelCustomerFilter
            // 
            labelCustomerFilter.Anchor = AnchorStyles.Bottom;
            labelCustomerFilter.AutoSize = true;
            labelCustomerFilter.BackColor = Color.Transparent;
            labelCustomerFilter.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelCustomerFilter.ForeColor = Color.Black;
            labelCustomerFilter.Location = new Point(33, 41);
            labelCustomerFilter.Name = "labelCustomerFilter";
            labelCustomerFilter.Size = new Size(128, 20);
            labelCustomerFilter.TabIndex = 24;
            labelCustomerFilter.Text = "Lọc khách hàng:";
            labelCustomerFilter.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(3, 71);
            label1.Name = "label1";
            label1.Size = new Size(128, 20);
            label1.TabIndex = 27;
            label1.Text = "Loại khách hàng";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBoxCustomerTypeFilter
            // 
            comboBoxCustomerTypeFilter.BackColor = SystemColors.Window;
            comboBoxCustomerTypeFilter.Dock = DockStyle.Fill;
            comboBoxCustomerTypeFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCustomerTypeFilter.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxCustomerTypeFilter.FormattingEnabled = true;
            comboBoxCustomerTypeFilter.Items.AddRange(new object[] { "Cá nhân", "Doanh nghiệp", "VIP Cá nhân", "VIP Doanh nghiệp" });
            comboBoxCustomerTypeFilter.Location = new Point(3, 94);
            comboBoxCustomerTypeFilter.Name = "comboBoxCustomerTypeFilter";
            comboBoxCustomerTypeFilter.Size = new Size(188, 32);
            comboBoxCustomerTypeFilter.TabIndex = 25;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(3, 141);
            label2.Name = "label2";
            label2.Size = new Size(28, 20);
            label2.TabIndex = 28;
            label2.Text = "Từ";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(3, 205);
            label3.Name = "label3";
            label3.Size = new Size(38, 20);
            label3.TabIndex = 29;
            label3.Text = "Đến";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dateTimePickerFrom
            // 
            dateTimePickerFrom.CalendarFont = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePickerFrom.Dock = DockStyle.Fill;
            dateTimePickerFrom.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePickerFrom.Location = new Point(3, 164);
            dateTimePickerFrom.Name = "dateTimePickerFrom";
            dateTimePickerFrom.Size = new Size(188, 28);
            dateTimePickerFrom.TabIndex = 30;
            // 
            // dateTimePickerTo
            // 
            dateTimePickerTo.CalendarFont = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePickerTo.Dock = DockStyle.Fill;
            dateTimePickerTo.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePickerTo.Location = new Point(3, 228);
            dateTimePickerTo.Name = "dateTimePickerTo";
            dateTimePickerTo.Size = new Size(188, 28);
            dateTimePickerTo.TabIndex = 31;
            // 
            // buttonFilterConfirm
            // 
            buttonFilterConfirm.Dock = DockStyle.Fill;
            buttonFilterConfirm.Image = (Image)resources.GetObject("buttonFilterConfirm.Image");
            buttonFilterConfirm.Location = new Point(3, 265);
            buttonFilterConfirm.Name = "buttonFilterConfirm";
            buttonFilterConfirm.Size = new Size(188, 51);
            buttonFilterConfirm.TabIndex = 32;
            buttonFilterConfirm.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(textBoxCustomerSearch, 0, 1);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(197, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 3;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 14.54545F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 70.90909F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 14.545455F));
            tableLayoutPanel4.Size = new Size(339, 55);
            tableLayoutPanel4.TabIndex = 36;
            // 
            // textBoxCustomerSearch
            // 
            textBoxCustomerSearch.Dock = DockStyle.Fill;
            textBoxCustomerSearch.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxCustomerSearch.Location = new Point(3, 10);
            textBoxCustomerSearch.Name = "textBoxCustomerSearch";
            textBoxCustomerSearch.PlaceholderText = "Tìm kiếm . . .";
            textBoxCustomerSearch.Size = new Size(333, 32);
            textBoxCustomerSearch.TabIndex = 1;
            textBoxCustomerSearch.WordWrap = false;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.HotTrack;
            panel3.Location = new Point(281, 11);
            panel3.Name = "panel3";
            panel3.Size = new Size(450, 5);
            panel3.TabIndex = 6;
            // 
            // UC_CustomerManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "UC_CustomerManagement";
            Size = new Size(1132, 753);
            Load += UC_CustomerManagement_Load;
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
        private Button buttonDeleteCustomer;
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
        private DataGridViewTextBoxColumn CustomerID;
        private DataGridViewTextBoxColumn CustomerType;
        private DataGridViewTextBoxColumn FullName;
        private DataGridViewTextBoxColumn Gender;
        private DataGridViewTextBoxColumn DateOfBirth;
        private DataGridViewTextBoxColumn Nationality;
        private DataGridViewTextBoxColumn CitizenID;
        private DataGridViewTextBoxColumn Address;
        private DataGridViewTextBoxColumn Phone;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn RegistrationDate;
        private Label label1;
        private Label label2;
        private Label label3;
        private DateTimePicker dateTimePickerFrom;
        private DateTimePicker dateTimePickerTo;
        private Button buttonFilterConfirm;
        private Button buttonExportPDF;
        private Button buttonExportExcel;
        private Button buttonExportCSV;
        private TableLayoutPanel tableLayoutPanel4;
    }
}
