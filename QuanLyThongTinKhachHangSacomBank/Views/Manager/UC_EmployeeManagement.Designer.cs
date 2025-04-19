namespace QuanLyThongTinKhachHangSacomBank.Views.Manager
{
    partial class UC_EmployeeManagement
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_EmployeeManagement));
            labelCustomerID = new Label();
            labelFullName = new Label();
            labelGender = new Label();
            labelNationality = new Label();
            labelDateOfBirth = new Label();
            textBoxEmployeeID = new TextBox();
            textBoxEmployeeName = new TextBox();
            textBoxEmployeeCitizenID = new TextBox();
            dateTimePickerEmployeeDateOfBirth = new DateTimePicker();
            labelCitizenID = new Label();
            labelAddress = new Label();
            dataEmployeeManagement = new DataGridView();
            EmployeeID = new DataGridViewTextBoxColumn();
            EmployeeName = new DataGridViewTextBoxColumn();
            EmployeeGender = new DataGridViewTextBoxColumn();
            EmployeeDateOfBirth = new DataGridViewTextBoxColumn();
            EmployeeCitizenID = new DataGridViewTextBoxColumn();
            EmployeeAddress = new DataGridViewTextBoxColumn();
            Role = new DataGridViewTextBoxColumn();
            EmployeePhone = new DataGridViewTextBoxColumn();
            EmployeeEmail = new DataGridViewTextBoxColumn();
            HireDate = new DataGridViewTextBoxColumn();
            Salary = new DataGridViewTextBoxColumn();
            comboBoxEmployeeGender = new ComboBox();
            labelEmployeeEmail = new Label();
            labelRegistrationDate = new Label();
            textBoxEmployeeAddress = new TextBox();
            textBoxEmployeePhone = new TextBox();
            labelEmployeePhone = new Label();
            dateTimePickerHireDate = new DateTimePicker();
            textBoxEmployeeEmail = new TextBox();
            toolTip1 = new ToolTip(components);
            buttonEmployeeSearch = new Button();
            panel2 = new Panel();
            tableLayoutPanel3 = new TableLayoutPanel();
            textBoxEmployeeSearch = new TextBox();
            label1 = new Label();
            label2 = new Label();
            comboBoxGenderFilter = new ComboBox();
            buttonExportPDF = new Button();
            buttonExportExcel = new Button();
            comboBoxTransactionTypeFilter = new ComboBox();
            groupBoxDataEmployeeManagement = new GroupBox();
            panel3 = new Panel();
            buttonAddEmployee = new Button();
            buttonDeleteEmployee = new Button();
            buttonEditEmployee = new Button();
            buttonCancelEmployee = new Button();
            buttonSaveEmployee = new Button();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            comboBoxAccessLevel = new ComboBox();
            label3 = new Label();
            textBoxSalary = new TextBox();
            groupBoxCustomerInfo = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dataEmployeeManagement).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            groupBoxDataEmployeeManagement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            groupBoxCustomerInfo.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
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
            labelCustomerID.Size = new Size(196, 32);
            labelCustomerID.TabIndex = 9;
            labelCustomerID.Text = "Mã nhân viên";
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
            labelNationality.Size = new Size(98, 32);
            labelNationality.TabIndex = 13;
            labelNationality.Text = "CCCD";
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
            // textBoxEmployeeID
            // 
            textBoxEmployeeID.BackColor = SystemColors.InactiveCaption;
            tableLayoutPanel2.SetColumnSpan(textBoxEmployeeID, 2);
            textBoxEmployeeID.Dock = DockStyle.Fill;
            textBoxEmployeeID.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxEmployeeID.Location = new Point(5, 59);
            textBoxEmployeeID.Margin = new Padding(5);
            textBoxEmployeeID.Name = "textBoxEmployeeID";
            textBoxEmployeeID.Size = new Size(581, 38);
            textBoxEmployeeID.TabIndex = 23;
            // 
            // textBoxEmployeeName
            // 
            textBoxEmployeeName.BackColor = SystemColors.InactiveCaption;
            tableLayoutPanel2.SetColumnSpan(textBoxEmployeeName, 2);
            textBoxEmployeeName.Dock = DockStyle.Fill;
            textBoxEmployeeName.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxEmployeeName.Location = new Point(5, 167);
            textBoxEmployeeName.Margin = new Padding(5);
            textBoxEmployeeName.Name = "textBoxEmployeeName";
            textBoxEmployeeName.Size = new Size(581, 38);
            textBoxEmployeeName.TabIndex = 24;
            // 
            // textBoxEmployeeCitizenID
            // 
            textBoxEmployeeCitizenID.BackColor = SystemColors.InactiveCaption;
            tableLayoutPanel2.SetColumnSpan(textBoxEmployeeCitizenID, 2);
            textBoxEmployeeCitizenID.Dock = DockStyle.Fill;
            textBoxEmployeeCitizenID.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxEmployeeCitizenID.Location = new Point(5, 491);
            textBoxEmployeeCitizenID.Margin = new Padding(5);
            textBoxEmployeeCitizenID.Name = "textBoxEmployeeCitizenID";
            textBoxEmployeeCitizenID.Size = new Size(581, 38);
            textBoxEmployeeCitizenID.TabIndex = 27;
            // 
            // dateTimePickerEmployeeDateOfBirth
            // 
            dateTimePickerEmployeeDateOfBirth.CalendarFont = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePickerEmployeeDateOfBirth.CalendarMonthBackground = SystemColors.InactiveCaption;
            tableLayoutPanel2.SetColumnSpan(dateTimePickerEmployeeDateOfBirth, 2);
            dateTimePickerEmployeeDateOfBirth.Dock = DockStyle.Fill;
            dateTimePickerEmployeeDateOfBirth.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePickerEmployeeDateOfBirth.Location = new Point(5, 383);
            dateTimePickerEmployeeDateOfBirth.Margin = new Padding(5);
            dateTimePickerEmployeeDateOfBirth.Name = "dateTimePickerEmployeeDateOfBirth";
            dateTimePickerEmployeeDateOfBirth.Size = new Size(581, 38);
            dateTimePickerEmployeeDateOfBirth.TabIndex = 28;
            // 
            // labelCitizenID
            // 
            labelCitizenID.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelCitizenID.AutoSize = true;
            labelCitizenID.BackColor = Color.Transparent;
            labelCitizenID.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            labelCitizenID.ForeColor = Color.Black;
            labelCitizenID.Location = new Point(608, 22);
            labelCitizenID.Margin = new Padding(5, 0, 5, 0);
            labelCitizenID.Name = "labelCitizenID";
            labelCitizenID.Size = new Size(108, 32);
            labelCitizenID.TabIndex = 29;
            labelCitizenID.Text = "Địa chỉ";
            // 
            // labelAddress
            // 
            labelAddress.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelAddress.AutoSize = true;
            labelAddress.BackColor = Color.Transparent;
            labelAddress.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            labelAddress.ForeColor = Color.Black;
            labelAddress.Location = new Point(608, 130);
            labelAddress.Margin = new Padding(5, 0, 5, 0);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(124, 32);
            labelAddress.TabIndex = 30;
            labelAddress.Text = "Chức vụ";
            // 
            // dataEmployeeManagement
            // 
            dataEmployeeManagement.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataEmployeeManagement.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataEmployeeManagement.BackgroundColor = Color.White;
            dataEmployeeManagement.BorderStyle = BorderStyle.None;
            dataEmployeeManagement.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            dataEmployeeManagement.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataEmployeeManagement.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataEmployeeManagement.ColumnHeadersHeight = 29;
            dataEmployeeManagement.Columns.AddRange(new DataGridViewColumn[] { EmployeeID, EmployeeName, EmployeeGender, EmployeeDateOfBirth, EmployeeCitizenID, EmployeeAddress, Role, EmployeePhone, EmployeeEmail, HireDate, Salary });
            tableLayoutPanel3.SetColumnSpan(dataEmployeeManagement, 5);
            dataEmployeeManagement.Dock = DockStyle.Fill;
            dataEmployeeManagement.EnableHeadersVisualStyles = false;
            dataEmployeeManagement.GridColor = Color.White;
            dataEmployeeManagement.Location = new Point(245, 71);
            dataEmployeeManagement.Margin = new Padding(5);
            dataEmployeeManagement.Name = "dataEmployeeManagement";
            dataEmployeeManagement.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataEmployeeManagement.RowHeadersVisible = false;
            dataEmployeeManagement.RowHeadersWidth = 51;
            tableLayoutPanel3.SetRowSpan(dataEmployeeManagement, 6);
            dataEmployeeManagement.Size = new Size(1570, 470);
            dataEmployeeManagement.TabIndex = 26;
            // 
            // EmployeeID
            // 
            EmployeeID.HeaderText = "Mã nhân viên";
            EmployeeID.MinimumWidth = 6;
            EmployeeID.Name = "EmployeeID";
            // 
            // EmployeeName
            // 
            EmployeeName.HeaderText = "Họ tên";
            EmployeeName.MinimumWidth = 6;
            EmployeeName.Name = "EmployeeName";
            // 
            // EmployeeGender
            // 
            EmployeeGender.HeaderText = "Giới tính";
            EmployeeGender.MinimumWidth = 6;
            EmployeeGender.Name = "EmployeeGender";
            // 
            // EmployeeDateOfBirth
            // 
            EmployeeDateOfBirth.HeaderText = "Ngày sinh";
            EmployeeDateOfBirth.MinimumWidth = 6;
            EmployeeDateOfBirth.Name = "EmployeeDateOfBirth";
            // 
            // EmployeeCitizenID
            // 
            EmployeeCitizenID.HeaderText = "CCCD";
            EmployeeCitizenID.MinimumWidth = 6;
            EmployeeCitizenID.Name = "EmployeeCitizenID";
            // 
            // EmployeeAddress
            // 
            EmployeeAddress.HeaderText = "Địa chỉ";
            EmployeeAddress.MinimumWidth = 6;
            EmployeeAddress.Name = "EmployeeAddress";
            // 
            // Role
            // 
            Role.HeaderText = "Chức vụ";
            Role.MinimumWidth = 6;
            Role.Name = "Role";
            // 
            // EmployeePhone
            // 
            EmployeePhone.HeaderText = "SĐT";
            EmployeePhone.MinimumWidth = 6;
            EmployeePhone.Name = "EmployeePhone";
            // 
            // EmployeeEmail
            // 
            EmployeeEmail.HeaderText = "Email";
            EmployeeEmail.MinimumWidth = 6;
            EmployeeEmail.Name = "EmployeeEmail";
            // 
            // HireDate
            // 
            HireDate.HeaderText = "Ngày vào làm";
            HireDate.MinimumWidth = 6;
            HireDate.Name = "HireDate";
            // 
            // Salary
            // 
            Salary.HeaderText = "Lương";
            Salary.MinimumWidth = 6;
            Salary.Name = "Salary";
            // 
            // comboBoxEmployeeGender
            // 
            comboBoxEmployeeGender.BackColor = SystemColors.Window;
            tableLayoutPanel2.SetColumnSpan(comboBoxEmployeeGender, 2);
            comboBoxEmployeeGender.Dock = DockStyle.Fill;
            comboBoxEmployeeGender.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEmployeeGender.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxEmployeeGender.FormattingEnabled = true;
            comboBoxEmployeeGender.Items.AddRange(new object[] { "Nam", "Nữ" });
            comboBoxEmployeeGender.Location = new Point(5, 275);
            comboBoxEmployeeGender.Margin = new Padding(5);
            comboBoxEmployeeGender.Name = "comboBoxEmployeeGender";
            comboBoxEmployeeGender.Size = new Size(581, 39);
            comboBoxEmployeeGender.TabIndex = 25;
            // 
            // labelEmployeeEmail
            // 
            labelEmployeeEmail.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelEmployeeEmail.AutoSize = true;
            labelEmployeeEmail.BackColor = Color.Transparent;
            labelEmployeeEmail.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            labelEmployeeEmail.ForeColor = Color.Black;
            labelEmployeeEmail.Location = new Point(608, 346);
            labelEmployeeEmail.Margin = new Padding(5, 0, 5, 0);
            labelEmployeeEmail.Name = "labelEmployeeEmail";
            labelEmployeeEmail.Size = new Size(91, 32);
            labelEmployeeEmail.TabIndex = 32;
            labelEmployeeEmail.Text = "Email";
            // 
            // labelRegistrationDate
            // 
            labelRegistrationDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelRegistrationDate.AutoSize = true;
            labelRegistrationDate.BackColor = Color.Transparent;
            labelRegistrationDate.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            labelRegistrationDate.ForeColor = Color.Black;
            labelRegistrationDate.Location = new Point(608, 454);
            labelRegistrationDate.Margin = new Padding(5, 0, 5, 0);
            labelRegistrationDate.Name = "labelRegistrationDate";
            labelRegistrationDate.Size = new Size(198, 32);
            labelRegistrationDate.TabIndex = 33;
            labelRegistrationDate.Text = "Ngày vào làm";
            // 
            // textBoxEmployeeAddress
            // 
            textBoxEmployeeAddress.BackColor = SystemColors.InactiveCaption;
            tableLayoutPanel2.SetColumnSpan(textBoxEmployeeAddress, 2);
            textBoxEmployeeAddress.Dock = DockStyle.Fill;
            textBoxEmployeeAddress.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxEmployeeAddress.Location = new Point(608, 59);
            textBoxEmployeeAddress.Margin = new Padding(5);
            textBoxEmployeeAddress.Name = "textBoxEmployeeAddress";
            textBoxEmployeeAddress.Size = new Size(945, 38);
            textBoxEmployeeAddress.TabIndex = 34;
            // 
            // textBoxEmployeePhone
            // 
            textBoxEmployeePhone.BackColor = SystemColors.InactiveCaption;
            tableLayoutPanel2.SetColumnSpan(textBoxEmployeePhone, 2);
            textBoxEmployeePhone.Dock = DockStyle.Fill;
            textBoxEmployeePhone.Font = new Font("Microsoft Sans Serif", 10.2F);
            textBoxEmployeePhone.Location = new Point(608, 275);
            textBoxEmployeePhone.Margin = new Padding(5);
            textBoxEmployeePhone.Name = "textBoxEmployeePhone";
            textBoxEmployeePhone.Size = new Size(945, 38);
            textBoxEmployeePhone.TabIndex = 36;
            // 
            // labelEmployeePhone
            // 
            labelEmployeePhone.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelEmployeePhone.AutoSize = true;
            labelEmployeePhone.BackColor = Color.Transparent;
            labelEmployeePhone.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            labelEmployeePhone.ForeColor = Color.Black;
            labelEmployeePhone.Location = new Point(608, 238);
            labelEmployeePhone.Margin = new Padding(5, 0, 5, 0);
            labelEmployeePhone.Name = "labelEmployeePhone";
            labelEmployeePhone.Size = new Size(73, 32);
            labelEmployeePhone.TabIndex = 31;
            labelEmployeePhone.Text = "SĐT";
            // 
            // dateTimePickerHireDate
            // 
            dateTimePickerHireDate.CalendarFont = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePickerHireDate.CalendarMonthBackground = SystemColors.InactiveCaption;
            dateTimePickerHireDate.Dock = DockStyle.Fill;
            dateTimePickerHireDate.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePickerHireDate.Location = new Point(608, 491);
            dateTimePickerHireDate.Margin = new Padding(5);
            dateTimePickerHireDate.Name = "dateTimePickerHireDate";
            dateTimePickerHireDate.Size = new Size(512, 38);
            dateTimePickerHireDate.TabIndex = 38;
            // 
            // textBoxEmployeeEmail
            // 
            textBoxEmployeeEmail.BackColor = SystemColors.InactiveCaption;
            tableLayoutPanel2.SetColumnSpan(textBoxEmployeeEmail, 2);
            textBoxEmployeeEmail.Dock = DockStyle.Fill;
            textBoxEmployeeEmail.Font = new Font("Microsoft Sans Serif", 10.2F);
            textBoxEmployeeEmail.Location = new Point(608, 383);
            textBoxEmployeeEmail.Margin = new Padding(5);
            textBoxEmployeeEmail.Name = "textBoxEmployeeEmail";
            textBoxEmployeeEmail.Size = new Size(945, 38);
            textBoxEmployeeEmail.TabIndex = 37;
            // 
            // buttonEmployeeSearch
            // 
            buttonEmployeeSearch.BackColor = SystemColors.HotTrack;
            buttonEmployeeSearch.Dock = DockStyle.Fill;
            buttonEmployeeSearch.ForeColor = Color.White;
            buttonEmployeeSearch.Image = (Image)resources.GetObject("buttonEmployeeSearch.Image");
            buttonEmployeeSearch.Location = new Point(1516, 5);
            buttonEmployeeSearch.Margin = new Padding(5);
            buttonEmployeeSearch.Name = "buttonEmployeeSearch";
            buttonEmployeeSearch.Size = new Size(69, 56);
            buttonEmployeeSearch.TabIndex = 5;
            toolTip1.SetToolTip(buttonEmployeeSearch, "Tìm kiếm");
            buttonEmployeeSearch.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.HotTrack;
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(1563, 5);
            panel2.Margin = new Padding(5);
            panel2.Name = "panel2";
            tableLayoutPanel2.SetRowSpan(panel2, 10);
            panel2.Size = new Size(7, 535);
            panel2.TabIndex = 39;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 6;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.2142859F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36.69643F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.125F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.375F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6.875F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.625F));
            tableLayoutPanel3.Controls.Add(textBoxEmployeeSearch, 1, 0);
            tableLayoutPanel3.Controls.Add(dataEmployeeManagement, 1, 1);
            tableLayoutPanel3.Controls.Add(label1, 0, 0);
            tableLayoutPanel3.Controls.Add(label2, 0, 1);
            tableLayoutPanel3.Controls.Add(comboBoxGenderFilter, 0, 2);
            tableLayoutPanel3.Controls.Add(buttonExportPDF, 0, 4);
            tableLayoutPanel3.Controls.Add(buttonExportExcel, 0, 5);
            tableLayoutPanel3.Controls.Add(comboBoxTransactionTypeFilter, 4, 0);
            tableLayoutPanel3.Controls.Add(buttonEmployeeSearch, 3, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(5, 42);
            tableLayoutPanel3.Margin = new Padding(5);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 7;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 12.0918064F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 19.169939F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 9.163992F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 2.35937715F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 17.1054821F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 18.8750172F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 21.2343922F));
            tableLayoutPanel3.Size = new Size(1820, 546);
            tableLayoutPanel3.TabIndex = 7;
            // 
            // textBoxEmployeeSearch
            // 
            tableLayoutPanel3.SetColumnSpan(textBoxEmployeeSearch, 2);
            textBoxEmployeeSearch.Dock = DockStyle.Fill;
            textBoxEmployeeSearch.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxEmployeeSearch.Location = new Point(245, 5);
            textBoxEmployeeSearch.Margin = new Padding(5);
            textBoxEmployeeSearch.Name = "textBoxEmployeeSearch";
            textBoxEmployeeSearch.PlaceholderText = "Tìm kiếm . . .";
            textBoxEmployeeSearch.Size = new Size(1261, 44);
            textBoxEmployeeSearch.TabIndex = 1;
            textBoxEmployeeSearch.WordWrap = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(13, 34);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(213, 32);
            label1.TabIndex = 27;
            label1.Text = "Lọc nhân viên:";
            label1.TextAlign = ContentAlignment.BottomCenter;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(5, 138);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(129, 32);
            label2.TabIndex = 28;
            label2.Text = "Giới tính";
            label2.TextAlign = ContentAlignment.BottomCenter;
            // 
            // comboBoxGenderFilter
            // 
            comboBoxGenderFilter.BackColor = SystemColors.Window;
            comboBoxGenderFilter.Dock = DockStyle.Fill;
            comboBoxGenderFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGenderFilter.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxGenderFilter.FormattingEnabled = true;
            comboBoxGenderFilter.Items.AddRange(new object[] { "Nam", "Nữ" });
            comboBoxGenderFilter.Location = new Point(5, 175);
            comboBoxGenderFilter.Margin = new Padding(5);
            comboBoxGenderFilter.Name = "comboBoxGenderFilter";
            comboBoxGenderFilter.Size = new Size(230, 39);
            comboBoxGenderFilter.TabIndex = 30;
            // 
            // buttonExportPDF
            // 
            buttonExportPDF.Dock = DockStyle.Fill;
            buttonExportPDF.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonExportPDF.ForeColor = Color.FromArgb(207, 0, 0);
            buttonExportPDF.Image = (Image)resources.GetObject("buttonExportPDF.Image");
            buttonExportPDF.Location = new Point(5, 237);
            buttonExportPDF.Margin = new Padding(5);
            buttonExportPDF.Name = "buttonExportPDF";
            buttonExportPDF.Size = new Size(230, 83);
            buttonExportPDF.TabIndex = 31;
            buttonExportPDF.Text = "Xuất PDF";
            buttonExportPDF.TextAlign = ContentAlignment.MiddleLeft;
            buttonExportPDF.TextImageRelation = TextImageRelation.TextBeforeImage;
            buttonExportPDF.UseVisualStyleBackColor = true;
            // 
            // buttonExportExcel
            // 
            buttonExportExcel.Dock = DockStyle.Fill;
            buttonExportExcel.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonExportExcel.ForeColor = Color.FromArgb(20, 169, 6);
            buttonExportExcel.Image = (Image)resources.GetObject("buttonExportExcel.Image");
            buttonExportExcel.Location = new Point(5, 330);
            buttonExportExcel.Margin = new Padding(5);
            buttonExportExcel.Name = "buttonExportExcel";
            buttonExportExcel.Size = new Size(230, 93);
            buttonExportExcel.TabIndex = 32;
            buttonExportExcel.Text = "Xuất Excel";
            buttonExportExcel.TextAlign = ContentAlignment.MiddleLeft;
            buttonExportExcel.TextImageRelation = TextImageRelation.TextBeforeImage;
            buttonExportExcel.UseVisualStyleBackColor = true;
            // 
            // comboBoxTransactionTypeFilter
            // 
            comboBoxTransactionTypeFilter.BackColor = SystemColors.Window;
            comboBoxTransactionTypeFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTransactionTypeFilter.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxTransactionTypeFilter.FormattingEnabled = true;
            comboBoxTransactionTypeFilter.Items.AddRange(new object[] { "Không áp dụng", "Nạp tiền", "Rút tiền", "Chuyển tiền", "Thanh toán dịch vụ" });
            comboBoxTransactionTypeFilter.Location = new Point(1595, 5);
            comboBoxTransactionTypeFilter.Margin = new Padding(5);
            comboBoxTransactionTypeFilter.Name = "comboBoxTransactionTypeFilter";
            comboBoxTransactionTypeFilter.Size = new Size(0, 39);
            comboBoxTransactionTypeFilter.TabIndex = 29;
            // 
            // groupBoxDataEmployeeManagement
            // 
            tableLayoutPanel1.SetColumnSpan(groupBoxDataEmployeeManagement, 2);
            groupBoxDataEmployeeManagement.Controls.Add(tableLayoutPanel3);
            groupBoxDataEmployeeManagement.Controls.Add(panel3);
            groupBoxDataEmployeeManagement.Dock = DockStyle.Fill;
            groupBoxDataEmployeeManagement.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxDataEmployeeManagement.ForeColor = SystemColors.HotTrack;
            groupBoxDataEmployeeManagement.Location = new Point(5, 607);
            groupBoxDataEmployeeManagement.Margin = new Padding(5);
            groupBoxDataEmployeeManagement.Name = "groupBoxDataEmployeeManagement";
            groupBoxDataEmployeeManagement.Padding = new Padding(5);
            groupBoxDataEmployeeManagement.Size = new Size(1830, 593);
            groupBoxDataEmployeeManagement.TabIndex = 1;
            groupBoxDataEmployeeManagement.TabStop = false;
            groupBoxDataEmployeeManagement.Text = "Dữ liệu thông tin nhân viên";
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
            // buttonAddEmployee
            // 
            buttonAddEmployee.BackColor = Color.DeepSkyBlue;
            buttonAddEmployee.Dock = DockStyle.Fill;
            buttonAddEmployee.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonAddEmployee.ForeColor = Color.White;
            buttonAddEmployee.Image = (Image)resources.GetObject("buttonAddEmployee.Image");
            buttonAddEmployee.ImageAlign = ContentAlignment.MiddleLeft;
            buttonAddEmployee.Location = new Point(1580, 5);
            buttonAddEmployee.Margin = new Padding(5);
            buttonAddEmployee.Name = "buttonAddEmployee";
            tableLayoutPanel2.SetRowSpan(buttonAddEmployee, 2);
            buttonAddEmployee.Size = new Size(141, 98);
            buttonAddEmployee.TabIndex = 40;
            buttonAddEmployee.Text = "   Thêm";
            buttonAddEmployee.UseVisualStyleBackColor = false;
            // 
            // buttonDeleteEmployee
            // 
            buttonDeleteEmployee.BackColor = Color.DeepSkyBlue;
            buttonDeleteEmployee.Dock = DockStyle.Fill;
            buttonDeleteEmployee.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonDeleteEmployee.ForeColor = Color.White;
            buttonDeleteEmployee.Image = (Image)resources.GetObject("buttonDeleteEmployee.Image");
            buttonDeleteEmployee.ImageAlign = ContentAlignment.MiddleLeft;
            buttonDeleteEmployee.Location = new Point(1580, 113);
            buttonDeleteEmployee.Margin = new Padding(5);
            buttonDeleteEmployee.Name = "buttonDeleteEmployee";
            tableLayoutPanel2.SetRowSpan(buttonDeleteEmployee, 2);
            buttonDeleteEmployee.Size = new Size(141, 98);
            buttonDeleteEmployee.TabIndex = 41;
            buttonDeleteEmployee.Text = "   Xóa";
            buttonDeleteEmployee.UseVisualStyleBackColor = false;
            // 
            // buttonEditEmployee
            // 
            buttonEditEmployee.BackColor = Color.DeepSkyBlue;
            buttonEditEmployee.Dock = DockStyle.Fill;
            buttonEditEmployee.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonEditEmployee.ForeColor = Color.White;
            buttonEditEmployee.Image = (Image)resources.GetObject("buttonEditEmployee.Image");
            buttonEditEmployee.ImageAlign = ContentAlignment.MiddleLeft;
            buttonEditEmployee.Location = new Point(1580, 221);
            buttonEditEmployee.Margin = new Padding(5);
            buttonEditEmployee.Name = "buttonEditEmployee";
            tableLayoutPanel2.SetRowSpan(buttonEditEmployee, 2);
            buttonEditEmployee.Size = new Size(141, 98);
            buttonEditEmployee.TabIndex = 42;
            buttonEditEmployee.Text = "   Sửa";
            buttonEditEmployee.UseVisualStyleBackColor = false;
            // 
            // buttonCancelEmployee
            // 
            buttonCancelEmployee.BackColor = Color.DeepSkyBlue;
            buttonCancelEmployee.Dock = DockStyle.Fill;
            buttonCancelEmployee.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonCancelEmployee.ForeColor = Color.White;
            buttonCancelEmployee.Image = (Image)resources.GetObject("buttonCancelEmployee.Image");
            buttonCancelEmployee.ImageAlign = ContentAlignment.MiddleLeft;
            buttonCancelEmployee.Location = new Point(1580, 329);
            buttonCancelEmployee.Margin = new Padding(5);
            buttonCancelEmployee.Name = "buttonCancelEmployee";
            tableLayoutPanel2.SetRowSpan(buttonCancelEmployee, 2);
            buttonCancelEmployee.Size = new Size(141, 98);
            buttonCancelEmployee.TabIndex = 43;
            buttonCancelEmployee.Text = "   Hủy";
            buttonCancelEmployee.UseVisualStyleBackColor = false;
            // 
            // buttonSaveEmployee
            // 
            buttonSaveEmployee.BackColor = Color.DeepSkyBlue;
            buttonSaveEmployee.Dock = DockStyle.Fill;
            buttonSaveEmployee.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonSaveEmployee.ForeColor = Color.White;
            buttonSaveEmployee.Image = (Image)resources.GetObject("buttonSaveEmployee.Image");
            buttonSaveEmployee.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSaveEmployee.Location = new Point(1580, 437);
            buttonSaveEmployee.Margin = new Padding(5);
            buttonSaveEmployee.Name = "buttonSaveEmployee";
            tableLayoutPanel2.SetRowSpan(buttonSaveEmployee, 2);
            buttonSaveEmployee.Size = new Size(141, 103);
            buttonSaveEmployee.TabIndex = 44;
            buttonSaveEmployee.Text = "   Lưu";
            buttonSaveEmployee.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1731, 5);
            pictureBox1.Margin = new Padding(5);
            pictureBox1.Name = "pictureBox1";
            tableLayoutPanel2.SetRowSpan(pictureBox1, 10);
            pictureBox1.Size = new Size(84, 535);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 45;
            pictureBox1.TabStop = false;
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
            tableLayoutPanel2.ColumnCount = 8;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.8118267F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.625F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.6654554F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.6607151F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.75F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.9788745F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.320435F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.988998F));
            tableLayoutPanel2.Controls.Add(comboBoxAccessLevel, 3, 3);
            tableLayoutPanel2.Controls.Add(labelCustomerID, 0, 0);
            tableLayoutPanel2.Controls.Add(labelFullName, 0, 2);
            tableLayoutPanel2.Controls.Add(labelGender, 0, 4);
            tableLayoutPanel2.Controls.Add(labelNationality, 0, 8);
            tableLayoutPanel2.Controls.Add(labelDateOfBirth, 0, 6);
            tableLayoutPanel2.Controls.Add(textBoxEmployeeID, 0, 1);
            tableLayoutPanel2.Controls.Add(textBoxEmployeeName, 0, 3);
            tableLayoutPanel2.Controls.Add(comboBoxEmployeeGender, 0, 5);
            tableLayoutPanel2.Controls.Add(textBoxEmployeeCitizenID, 0, 9);
            tableLayoutPanel2.Controls.Add(dateTimePickerEmployeeDateOfBirth, 0, 7);
            tableLayoutPanel2.Controls.Add(labelCitizenID, 3, 0);
            tableLayoutPanel2.Controls.Add(labelAddress, 3, 2);
            tableLayoutPanel2.Controls.Add(labelEmployeeEmail, 3, 6);
            tableLayoutPanel2.Controls.Add(labelRegistrationDate, 3, 8);
            tableLayoutPanel2.Controls.Add(textBoxEmployeeAddress, 3, 1);
            tableLayoutPanel2.Controls.Add(textBoxEmployeePhone, 3, 5);
            tableLayoutPanel2.Controls.Add(labelEmployeePhone, 3, 4);
            tableLayoutPanel2.Controls.Add(textBoxEmployeeEmail, 3, 7);
            tableLayoutPanel2.Controls.Add(dateTimePickerHireDate, 3, 9);
            tableLayoutPanel2.Controls.Add(panel2, 5, 0);
            tableLayoutPanel2.Controls.Add(buttonAddEmployee, 6, 0);
            tableLayoutPanel2.Controls.Add(buttonDeleteEmployee, 6, 2);
            tableLayoutPanel2.Controls.Add(buttonEditEmployee, 6, 4);
            tableLayoutPanel2.Controls.Add(buttonCancelEmployee, 6, 6);
            tableLayoutPanel2.Controls.Add(buttonSaveEmployee, 6, 8);
            tableLayoutPanel2.Controls.Add(pictureBox1, 7, 0);
            tableLayoutPanel2.Controls.Add(label3, 4, 8);
            tableLayoutPanel2.Controls.Add(textBoxSalary, 4, 9);
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
            // comboBoxAccessLevel
            // 
            comboBoxAccessLevel.BackColor = SystemColors.Window;
            tableLayoutPanel2.SetColumnSpan(comboBoxAccessLevel, 2);
            comboBoxAccessLevel.Dock = DockStyle.Fill;
            comboBoxAccessLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAccessLevel.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxAccessLevel.FormattingEnabled = true;
            comboBoxAccessLevel.Items.AddRange(new object[] { "Quản lý", "Nhân viên" });
            comboBoxAccessLevel.Location = new Point(608, 167);
            comboBoxAccessLevel.Margin = new Padding(5);
            comboBoxAccessLevel.Name = "comboBoxAccessLevel";
            comboBoxAccessLevel.Size = new Size(945, 39);
            comboBoxAccessLevel.TabIndex = 48;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(1130, 454);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(99, 32);
            label3.TabIndex = 46;
            label3.Text = "Lương";
            // 
            // textBoxSalary
            // 
            textBoxSalary.BackColor = SystemColors.InactiveCaption;
            textBoxSalary.Dock = DockStyle.Fill;
            textBoxSalary.Font = new Font("Microsoft Sans Serif", 10.2F);
            textBoxSalary.Location = new Point(1130, 491);
            textBoxSalary.Margin = new Padding(5);
            textBoxSalary.Name = "textBoxSalary";
            textBoxSalary.Size = new Size(423, 38);
            textBoxSalary.TabIndex = 47;
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
            groupBoxCustomerInfo.Text = "Thông tin nhân viên";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(groupBoxCustomerInfo, 0, 0);
            tableLayoutPanel1.Controls.Add(groupBoxDataEmployeeManagement, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(5);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1840, 1205);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // UC_EmployeeManagement
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(5);
            Name = "UC_EmployeeManagement";
            Size = new Size(1840, 1205);
            ((System.ComponentModel.ISupportInitialize)dataEmployeeManagement).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            groupBoxDataEmployeeManagement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            groupBoxCustomerInfo.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Label labelCustomerID;
        private Label labelFullName;
        private Label labelGender;
        private Label labelNationality;
        private Label labelDateOfBirth;
        private Label labelCustomerType;
        private TextBox textBoxEmployeeID;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox textBoxEmployeeName;
        private ComboBox comboBoxEmployeeGender;
        private ComboBox comboBoxCustomerType;
        private TextBox textBoxEmployeeCitizenID;
        private DateTimePicker dateTimePickerEmployeeDateOfBirth;
        private Label labelCitizenID;
        private Label labelAddress;
        private Label labelEmployeeEmail;
        private Label labelRegistrationDate;
        private TextBox textBoxEmployeeAddress;
        private TextBox textBoxEmployeePhone;
        private Label labelEmployeePhone;
        private TextBox textBoxEmployeeEmail;
        private DateTimePicker dateTimePickerHireDate;
        private Panel panel2;
        private Button buttonAddEmployee;
        private Button buttonDeleteEmployee;
        private Button buttonEditEmployee;
        private Button buttonCancelEmployee;
        private Button buttonSaveEmployee;
        private PictureBox pictureBox1;
        private DataGridView dataEmployeeManagement;
        private TableLayoutPanel tableLayoutPanel3;
        private Button buttonEmployeeSearch;
        private ToolTip toolTip1;
        private TextBox textBoxEmployeeSearch;
        private GroupBox groupBoxDataEmployeeManagement;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBoxCustomerInfo;
        private Panel panel1;
        private Panel panel3;
        private Label label1;
        private Label label2;
        private ComboBox comboBoxTransactionTypeFilter;
        private ComboBox comboBoxGenderFilter;
        private Button buttonExportPDF;
        private Button buttonExportExcel;
        private DataGridViewTextBoxColumn EmployeeID;
        private DataGridViewTextBoxColumn EmployeeName;
        private DataGridViewTextBoxColumn EmployeeGender;
        private DataGridViewTextBoxColumn EmployeeDateOfBirth;
        private DataGridViewTextBoxColumn EmployeeCitizenID;
        private DataGridViewTextBoxColumn EmployeeAddress;
        private DataGridViewTextBoxColumn Role;
        private DataGridViewTextBoxColumn EmployeePhone;
        private DataGridViewTextBoxColumn EmployeeEmail;
        private DataGridViewTextBoxColumn HireDate;
        private DataGridViewTextBoxColumn Salary;
        private Label label3;
        private TextBox textBoxSalary;
        private ComboBox comboBoxAccessLevel;
    }
}
