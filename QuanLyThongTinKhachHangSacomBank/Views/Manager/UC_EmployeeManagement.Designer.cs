﻿namespace QuanLyThongTinKhachHangSacomBank.Views.Manager
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
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
            labelCustomerID.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            labelCustomerID.ForeColor = Color.Black;
            labelCustomerID.Location = new Point(3, 13);
            labelCustomerID.Name = "labelCustomerID";
            labelCustomerID.Size = new Size(118, 20);
            labelCustomerID.TabIndex = 9;
            labelCustomerID.Text = "Mã nhân viên";
            // 
            // labelFullName
            // 
            labelFullName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelFullName.AutoSize = true;
            labelFullName.BackColor = Color.Transparent;
            labelFullName.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            labelFullName.ForeColor = Color.Black;
            labelFullName.Location = new Point(3, 79);
            labelFullName.Name = "labelFullName";
            labelFullName.Size = new Size(62, 20);
            labelFullName.TabIndex = 10;
            labelFullName.Text = "Họ tên";
            // 
            // labelGender
            // 
            labelGender.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelGender.AutoSize = true;
            labelGender.BackColor = Color.Transparent;
            labelGender.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            labelGender.ForeColor = Color.Black;
            labelGender.Location = new Point(3, 145);
            labelGender.Name = "labelGender";
            labelGender.Size = new Size(77, 20);
            labelGender.TabIndex = 12;
            labelGender.Text = "Giới tính";
            // 
            // labelNationality
            // 
            labelNationality.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelNationality.AutoSize = true;
            labelNationality.BackColor = Color.Transparent;
            labelNationality.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            labelNationality.ForeColor = Color.Black;
            labelNationality.Location = new Point(3, 277);
            labelNationality.Name = "labelNationality";
            labelNationality.Size = new Size(53, 20);
            labelNationality.TabIndex = 13;
            labelNationality.Text = "CCCD";
            // 
            // labelDateOfBirth
            // 
            labelDateOfBirth.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelDateOfBirth.AutoSize = true;
            labelDateOfBirth.BackColor = Color.Transparent;
            labelDateOfBirth.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            labelDateOfBirth.ForeColor = Color.Black;
            labelDateOfBirth.Location = new Point(3, 211);
            labelDateOfBirth.Name = "labelDateOfBirth";
            labelDateOfBirth.Size = new Size(89, 20);
            labelDateOfBirth.TabIndex = 11;
            labelDateOfBirth.Text = "Ngày sinh";
            // 
            // textBoxEmployeeID
            // 
            textBoxEmployeeID.BackColor = SystemColors.InactiveCaption;
            tableLayoutPanel2.SetColumnSpan(textBoxEmployeeID, 2);
            textBoxEmployeeID.Dock = DockStyle.Fill;
            textBoxEmployeeID.Enabled = false;
            textBoxEmployeeID.Font = new Font("Roboto", 10.2F);
            textBoxEmployeeID.Location = new Point(3, 36);
            textBoxEmployeeID.Name = "textBoxEmployeeID";
            textBoxEmployeeID.Size = new Size(357, 28);
            textBoxEmployeeID.TabIndex = 23;
            // 
            // textBoxEmployeeName
            // 
            textBoxEmployeeName.BackColor = SystemColors.InactiveCaption;
            tableLayoutPanel2.SetColumnSpan(textBoxEmployeeName, 2);
            textBoxEmployeeName.Dock = DockStyle.Fill;
            textBoxEmployeeName.Font = new Font("Roboto", 10.2F);
            textBoxEmployeeName.Location = new Point(3, 102);
            textBoxEmployeeName.Name = "textBoxEmployeeName";
            textBoxEmployeeName.Size = new Size(357, 28);
            textBoxEmployeeName.TabIndex = 24;
            // 
            // textBoxEmployeeCitizenID
            // 
            textBoxEmployeeCitizenID.BackColor = SystemColors.InactiveCaption;
            tableLayoutPanel2.SetColumnSpan(textBoxEmployeeCitizenID, 2);
            textBoxEmployeeCitizenID.Dock = DockStyle.Fill;
            textBoxEmployeeCitizenID.Font = new Font("Roboto", 10.2F);
            textBoxEmployeeCitizenID.Location = new Point(3, 300);
            textBoxEmployeeCitizenID.Name = "textBoxEmployeeCitizenID";
            textBoxEmployeeCitizenID.Size = new Size(357, 28);
            textBoxEmployeeCitizenID.TabIndex = 27;
            // 
            // dateTimePickerEmployeeDateOfBirth
            // 
            dateTimePickerEmployeeDateOfBirth.CalendarFont = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePickerEmployeeDateOfBirth.CalendarMonthBackground = SystemColors.InactiveCaption;
            tableLayoutPanel2.SetColumnSpan(dateTimePickerEmployeeDateOfBirth, 2);
            dateTimePickerEmployeeDateOfBirth.Dock = DockStyle.Fill;
            dateTimePickerEmployeeDateOfBirth.Font = new Font("Roboto", 10.2F);
            dateTimePickerEmployeeDateOfBirth.Format = DateTimePickerFormat.Short;
            dateTimePickerEmployeeDateOfBirth.Location = new Point(3, 234);
            dateTimePickerEmployeeDateOfBirth.Name = "dateTimePickerEmployeeDateOfBirth";
            dateTimePickerEmployeeDateOfBirth.Size = new Size(357, 28);
            dateTimePickerEmployeeDateOfBirth.TabIndex = 28;
            // 
            // labelCitizenID
            // 
            labelCitizenID.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelCitizenID.AutoSize = true;
            labelCitizenID.BackColor = Color.Transparent;
            labelCitizenID.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            labelCitizenID.ForeColor = Color.Black;
            labelCitizenID.Location = new Point(373, 13);
            labelCitizenID.Name = "labelCitizenID";
            labelCitizenID.Size = new Size(65, 20);
            labelCitizenID.TabIndex = 29;
            labelCitizenID.Text = "Địa chỉ";
            // 
            // labelAddress
            // 
            labelAddress.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelAddress.AutoSize = true;
            labelAddress.BackColor = Color.Transparent;
            labelAddress.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            labelAddress.ForeColor = Color.Black;
            labelAddress.Location = new Point(373, 79);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(74, 20);
            labelAddress.TabIndex = 30;
            labelAddress.Text = "Chức vụ";
            // 
            // dataEmployeeManagement
            // 
            dataEmployeeManagement.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataEmployeeManagement.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataEmployeeManagement.BackgroundColor = Color.White;
            dataEmployeeManagement.BorderStyle = BorderStyle.None;
            dataEmployeeManagement.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            dataEmployeeManagement.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataEmployeeManagement.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataEmployeeManagement.ColumnHeadersHeight = 29;
            dataEmployeeManagement.Columns.AddRange(new DataGridViewColumn[] { EmployeeID, EmployeeName, EmployeeGender, EmployeeDateOfBirth, EmployeeCitizenID, EmployeeAddress, Role, EmployeePhone, EmployeeEmail, HireDate, Salary });
            tableLayoutPanel3.SetColumnSpan(dataEmployeeManagement, 5);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.HotTrack;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataEmployeeManagement.DefaultCellStyle = dataGridViewCellStyle2;
            dataEmployeeManagement.Dock = DockStyle.Fill;
            dataEmployeeManagement.EnableHeadersVisualStyles = false;
            dataEmployeeManagement.GridColor = Color.White;
            dataEmployeeManagement.Location = new Point(151, 44);
            dataEmployeeManagement.Name = "dataEmployeeManagement";
            dataEmployeeManagement.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataEmployeeManagement.RowHeadersVisible = false;
            dataEmployeeManagement.RowHeadersWidth = 51;
            tableLayoutPanel3.SetRowSpan(dataEmployeeManagement, 6);
            dataEmployeeManagement.Size = new Size(966, 293);
            dataEmployeeManagement.TabIndex = 26;
            // 
            // EmployeeID
            // 
            EmployeeID.HeaderText = "Mã nhân viên";
            EmployeeID.MinimumWidth = 6;
            EmployeeID.Name = "EmployeeID";
            EmployeeID.Width = 145;
            // 
            // EmployeeName
            // 
            EmployeeName.HeaderText = "Họ tên";
            EmployeeName.MinimumWidth = 6;
            EmployeeName.Name = "EmployeeName";
            EmployeeName.Width = 89;
            // 
            // EmployeeGender
            // 
            EmployeeGender.HeaderText = "Giới tính";
            EmployeeGender.MinimumWidth = 6;
            EmployeeGender.Name = "EmployeeGender";
            EmployeeGender.Width = 104;
            // 
            // EmployeeDateOfBirth
            // 
            EmployeeDateOfBirth.HeaderText = "Ngày sinh";
            EmployeeDateOfBirth.MinimumWidth = 6;
            EmployeeDateOfBirth.Name = "EmployeeDateOfBirth";
            EmployeeDateOfBirth.Width = 116;
            // 
            // EmployeeCitizenID
            // 
            EmployeeCitizenID.HeaderText = "CCCD";
            EmployeeCitizenID.MinimumWidth = 6;
            EmployeeCitizenID.Name = "EmployeeCitizenID";
            EmployeeCitizenID.Width = 80;
            // 
            // EmployeeAddress
            // 
            EmployeeAddress.HeaderText = "Địa chỉ";
            EmployeeAddress.MinimumWidth = 6;
            EmployeeAddress.Name = "EmployeeAddress";
            EmployeeAddress.Width = 92;
            // 
            // Role
            // 
            Role.HeaderText = "Chức vụ";
            Role.MinimumWidth = 6;
            Role.Name = "Role";
            Role.Width = 101;
            // 
            // EmployeePhone
            // 
            EmployeePhone.HeaderText = "SĐT";
            EmployeePhone.MinimumWidth = 6;
            EmployeePhone.Name = "EmployeePhone";
            EmployeePhone.Width = 70;
            // 
            // EmployeeEmail
            // 
            EmployeeEmail.HeaderText = "Email";
            EmployeeEmail.MinimumWidth = 6;
            EmployeeEmail.Name = "EmployeeEmail";
            EmployeeEmail.Width = 81;
            // 
            // HireDate
            // 
            HireDate.HeaderText = "Ngày vào làm";
            HireDate.MinimumWidth = 6;
            HireDate.Name = "HireDate";
            HireDate.Width = 146;
            // 
            // Salary
            // 
            Salary.HeaderText = "Lương";
            Salary.MinimumWidth = 6;
            Salary.Name = "Salary";
            Salary.Width = 87;
            // 
            // comboBoxEmployeeGender
            // 
            comboBoxEmployeeGender.BackColor = SystemColors.Window;
            tableLayoutPanel2.SetColumnSpan(comboBoxEmployeeGender, 2);
            comboBoxEmployeeGender.Dock = DockStyle.Fill;
            comboBoxEmployeeGender.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEmployeeGender.Font = new Font("Roboto", 10.2F);
            comboBoxEmployeeGender.FormattingEnabled = true;
            comboBoxEmployeeGender.Items.AddRange(new object[] { "Nam", "Nữ" });
            comboBoxEmployeeGender.Location = new Point(3, 168);
            comboBoxEmployeeGender.Name = "comboBoxEmployeeGender";
            comboBoxEmployeeGender.Size = new Size(357, 28);
            comboBoxEmployeeGender.TabIndex = 25;
            // 
            // labelEmployeeEmail
            // 
            labelEmployeeEmail.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelEmployeeEmail.AutoSize = true;
            labelEmployeeEmail.BackColor = Color.Transparent;
            labelEmployeeEmail.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            labelEmployeeEmail.ForeColor = Color.Black;
            labelEmployeeEmail.Location = new Point(373, 211);
            labelEmployeeEmail.Name = "labelEmployeeEmail";
            labelEmployeeEmail.Size = new Size(54, 20);
            labelEmployeeEmail.TabIndex = 32;
            labelEmployeeEmail.Text = "Email";
            // 
            // labelRegistrationDate
            // 
            labelRegistrationDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelRegistrationDate.AutoSize = true;
            labelRegistrationDate.BackColor = Color.Transparent;
            labelRegistrationDate.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            labelRegistrationDate.ForeColor = Color.Black;
            labelRegistrationDate.Location = new Point(373, 277);
            labelRegistrationDate.Name = "labelRegistrationDate";
            labelRegistrationDate.Size = new Size(119, 20);
            labelRegistrationDate.TabIndex = 33;
            labelRegistrationDate.Text = "Ngày vào làm";
            // 
            // textBoxEmployeeAddress
            // 
            textBoxEmployeeAddress.BackColor = SystemColors.InactiveCaption;
            tableLayoutPanel2.SetColumnSpan(textBoxEmployeeAddress, 2);
            textBoxEmployeeAddress.Dock = DockStyle.Fill;
            textBoxEmployeeAddress.Font = new Font("Roboto", 10.2F);
            textBoxEmployeeAddress.Location = new Point(373, 36);
            textBoxEmployeeAddress.Name = "textBoxEmployeeAddress";
            textBoxEmployeeAddress.Size = new Size(581, 28);
            textBoxEmployeeAddress.TabIndex = 34;
            // 
            // textBoxEmployeePhone
            // 
            textBoxEmployeePhone.BackColor = SystemColors.InactiveCaption;
            tableLayoutPanel2.SetColumnSpan(textBoxEmployeePhone, 2);
            textBoxEmployeePhone.Dock = DockStyle.Fill;
            textBoxEmployeePhone.Font = new Font("Roboto", 10.2F);
            textBoxEmployeePhone.Location = new Point(373, 168);
            textBoxEmployeePhone.Name = "textBoxEmployeePhone";
            textBoxEmployeePhone.Size = new Size(581, 28);
            textBoxEmployeePhone.TabIndex = 36;
            // 
            // labelEmployeePhone
            // 
            labelEmployeePhone.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelEmployeePhone.AutoSize = true;
            labelEmployeePhone.BackColor = Color.Transparent;
            labelEmployeePhone.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            labelEmployeePhone.ForeColor = Color.Black;
            labelEmployeePhone.Location = new Point(373, 145);
            labelEmployeePhone.Name = "labelEmployeePhone";
            labelEmployeePhone.Size = new Size(43, 20);
            labelEmployeePhone.TabIndex = 31;
            labelEmployeePhone.Text = "SĐT";
            // 
            // dateTimePickerHireDate
            // 
            dateTimePickerHireDate.CalendarFont = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePickerHireDate.CalendarMonthBackground = SystemColors.InactiveCaption;
            dateTimePickerHireDate.Dock = DockStyle.Fill;
            dateTimePickerHireDate.Enabled = false;
            dateTimePickerHireDate.Font = new Font("Roboto", 10.2F);
            dateTimePickerHireDate.Format = DateTimePickerFormat.Short;
            dateTimePickerHireDate.Location = new Point(373, 300);
            dateTimePickerHireDate.Name = "dateTimePickerHireDate";
            dateTimePickerHireDate.Size = new Size(315, 28);
            dateTimePickerHireDate.TabIndex = 38;
            // 
            // textBoxEmployeeEmail
            // 
            textBoxEmployeeEmail.BackColor = SystemColors.InactiveCaption;
            tableLayoutPanel2.SetColumnSpan(textBoxEmployeeEmail, 2);
            textBoxEmployeeEmail.Dock = DockStyle.Fill;
            textBoxEmployeeEmail.Font = new Font("Roboto", 10.2F);
            textBoxEmployeeEmail.Location = new Point(373, 234);
            textBoxEmployeeEmail.Name = "textBoxEmployeeEmail";
            textBoxEmployeeEmail.Size = new Size(581, 28);
            textBoxEmployeeEmail.TabIndex = 37;
            // 
            // buttonEmployeeSearch
            // 
            buttonEmployeeSearch.BackColor = SystemColors.HotTrack;
            buttonEmployeeSearch.Dock = DockStyle.Fill;
            buttonEmployeeSearch.ForeColor = Color.White;
            buttonEmployeeSearch.Image = (Image)resources.GetObject("buttonEmployeeSearch.Image");
            buttonEmployeeSearch.Location = new Point(933, 3);
            buttonEmployeeSearch.Name = "buttonEmployeeSearch";
            buttonEmployeeSearch.Size = new Size(43, 35);
            buttonEmployeeSearch.TabIndex = 5;
            toolTip1.SetToolTip(buttonEmployeeSearch, "Tìm kiếm");
            buttonEmployeeSearch.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.HotTrack;
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(960, 3);
            panel2.Name = "panel2";
            tableLayoutPanel2.SetRowSpan(panel2, 10);
            panel2.Size = new Size(4, 333);
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
            tableLayoutPanel3.Controls.Add(buttonEmployeeSearch, 3, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 28);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 7;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 12.0918064F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 19.169939F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 9.163992F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 2.35937715F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 17.1054821F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 18.8750172F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 21.2343922F));
            tableLayoutPanel3.Size = new Size(1120, 340);
            tableLayoutPanel3.TabIndex = 7;
            // 
            // textBoxEmployeeSearch
            // 
            tableLayoutPanel3.SetColumnSpan(textBoxEmployeeSearch, 2);
            textBoxEmployeeSearch.Dock = DockStyle.Fill;
            textBoxEmployeeSearch.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxEmployeeSearch.Location = new Point(151, 3);
            textBoxEmployeeSearch.Name = "textBoxEmployeeSearch";
            textBoxEmployeeSearch.PlaceholderText = "Tìm kiếm . . .";
            textBoxEmployeeSearch.Size = new Size(776, 32);
            textBoxEmployeeSearch.TabIndex = 1;
            textBoxEmployeeSearch.WordWrap = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(10, 21);
            label1.Name = "label1";
            label1.Size = new Size(127, 20);
            label1.TabIndex = 27;
            label1.Text = "Lọc nhân viên:";
            label1.TextAlign = ContentAlignment.BottomCenter;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(3, 86);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 28;
            label2.Text = "Giới tính";
            label2.TextAlign = ContentAlignment.BottomCenter;
            // 
            // comboBoxGenderFilter
            // 
            comboBoxGenderFilter.BackColor = SystemColors.Window;
            comboBoxGenderFilter.Dock = DockStyle.Fill;
            comboBoxGenderFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGenderFilter.Font = new Font("Roboto", 10.2F);
            comboBoxGenderFilter.FormattingEnabled = true;
            comboBoxGenderFilter.Items.AddRange(new object[] { "Không áp dụng", "Nam", "Nữ" });
            comboBoxGenderFilter.Location = new Point(3, 109);
            comboBoxGenderFilter.Name = "comboBoxGenderFilter";
            comboBoxGenderFilter.Size = new Size(142, 28);
            comboBoxGenderFilter.TabIndex = 30;
            // 
            // buttonExportPDF
            // 
            buttonExportPDF.Dock = DockStyle.Fill;
            buttonExportPDF.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            buttonExportPDF.ForeColor = Color.FromArgb(207, 0, 0);
            buttonExportPDF.Image = (Image)resources.GetObject("buttonExportPDF.Image");
            buttonExportPDF.Location = new Point(3, 148);
            buttonExportPDF.Name = "buttonExportPDF";
            buttonExportPDF.Size = new Size(142, 52);
            buttonExportPDF.TabIndex = 31;
            buttonExportPDF.Text = "Xuất PDF";
            buttonExportPDF.TextAlign = ContentAlignment.MiddleLeft;
            buttonExportPDF.TextImageRelation = TextImageRelation.TextBeforeImage;
            buttonExportPDF.UseVisualStyleBackColor = true;
            // 
            // buttonExportExcel
            // 
            buttonExportExcel.Dock = DockStyle.Fill;
            buttonExportExcel.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            buttonExportExcel.ForeColor = Color.FromArgb(20, 169, 6);
            buttonExportExcel.Image = (Image)resources.GetObject("buttonExportExcel.Image");
            buttonExportExcel.Location = new Point(3, 206);
            buttonExportExcel.Name = "buttonExportExcel";
            buttonExportExcel.Size = new Size(142, 58);
            buttonExportExcel.TabIndex = 32;
            buttonExportExcel.Text = "Xuất Excel";
            buttonExportExcel.TextAlign = ContentAlignment.MiddleLeft;
            buttonExportExcel.TextImageRelation = TextImageRelation.TextBeforeImage;
            buttonExportExcel.UseVisualStyleBackColor = true;
            // 
            // groupBoxDataEmployeeManagement
            // 
            tableLayoutPanel1.SetColumnSpan(groupBoxDataEmployeeManagement, 2);
            groupBoxDataEmployeeManagement.Controls.Add(tableLayoutPanel3);
            groupBoxDataEmployeeManagement.Controls.Add(panel3);
            groupBoxDataEmployeeManagement.Dock = DockStyle.Fill;
            groupBoxDataEmployeeManagement.Font = new Font("Roboto SemiCondensed Medium", 12F, FontStyle.Bold);
            groupBoxDataEmployeeManagement.ForeColor = SystemColors.HotTrack;
            groupBoxDataEmployeeManagement.Location = new Point(3, 379);
            groupBoxDataEmployeeManagement.Name = "groupBoxDataEmployeeManagement";
            groupBoxDataEmployeeManagement.Size = new Size(1126, 371);
            groupBoxDataEmployeeManagement.TabIndex = 1;
            groupBoxDataEmployeeManagement.TabStop = false;
            groupBoxDataEmployeeManagement.Text = "Dữ liệu thông tin nhân viên";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.HotTrack;
            panel3.Location = new Point(281, 11);
            panel3.Name = "panel3";
            panel3.Size = new Size(450, 5);
            panel3.TabIndex = 6;
            // 
            // buttonAddEmployee
            // 
            buttonAddEmployee.BackColor = Color.DeepSkyBlue;
            buttonAddEmployee.Dock = DockStyle.Fill;
            buttonAddEmployee.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            buttonAddEmployee.ForeColor = Color.White;
            buttonAddEmployee.Image = (Image)resources.GetObject("buttonAddEmployee.Image");
            buttonAddEmployee.ImageAlign = ContentAlignment.MiddleLeft;
            buttonAddEmployee.Location = new Point(970, 3);
            buttonAddEmployee.Name = "buttonAddEmployee";
            tableLayoutPanel2.SetRowSpan(buttonAddEmployee, 2);
            buttonAddEmployee.Size = new Size(87, 60);
            buttonAddEmployee.TabIndex = 40;
            buttonAddEmployee.Text = "   Thêm";
            buttonAddEmployee.UseVisualStyleBackColor = false;
            // 
            // buttonDeleteEmployee
            // 
            buttonDeleteEmployee.BackColor = Color.DeepSkyBlue;
            buttonDeleteEmployee.Dock = DockStyle.Fill;
            buttonDeleteEmployee.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            buttonDeleteEmployee.ForeColor = Color.White;
            buttonDeleteEmployee.Image = (Image)resources.GetObject("buttonDeleteEmployee.Image");
            buttonDeleteEmployee.ImageAlign = ContentAlignment.MiddleLeft;
            buttonDeleteEmployee.Location = new Point(970, 69);
            buttonDeleteEmployee.Name = "buttonDeleteEmployee";
            tableLayoutPanel2.SetRowSpan(buttonDeleteEmployee, 2);
            buttonDeleteEmployee.Size = new Size(87, 60);
            buttonDeleteEmployee.TabIndex = 41;
            buttonDeleteEmployee.Text = "   Xóa";
            buttonDeleteEmployee.UseVisualStyleBackColor = false;
            // 
            // buttonEditEmployee
            // 
            buttonEditEmployee.BackColor = Color.DeepSkyBlue;
            buttonEditEmployee.Dock = DockStyle.Fill;
            buttonEditEmployee.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            buttonEditEmployee.ForeColor = Color.White;
            buttonEditEmployee.Image = (Image)resources.GetObject("buttonEditEmployee.Image");
            buttonEditEmployee.ImageAlign = ContentAlignment.MiddleLeft;
            buttonEditEmployee.Location = new Point(970, 135);
            buttonEditEmployee.Name = "buttonEditEmployee";
            tableLayoutPanel2.SetRowSpan(buttonEditEmployee, 2);
            buttonEditEmployee.Size = new Size(87, 60);
            buttonEditEmployee.TabIndex = 42;
            buttonEditEmployee.Text = "   Sửa";
            buttonEditEmployee.UseVisualStyleBackColor = false;
            // 
            // buttonCancelEmployee
            // 
            buttonCancelEmployee.BackColor = Color.DeepSkyBlue;
            buttonCancelEmployee.Dock = DockStyle.Fill;
            buttonCancelEmployee.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            buttonCancelEmployee.ForeColor = Color.White;
            buttonCancelEmployee.Image = (Image)resources.GetObject("buttonCancelEmployee.Image");
            buttonCancelEmployee.ImageAlign = ContentAlignment.MiddleLeft;
            buttonCancelEmployee.Location = new Point(970, 201);
            buttonCancelEmployee.Name = "buttonCancelEmployee";
            tableLayoutPanel2.SetRowSpan(buttonCancelEmployee, 2);
            buttonCancelEmployee.Size = new Size(87, 60);
            buttonCancelEmployee.TabIndex = 43;
            buttonCancelEmployee.Text = "   Hủy";
            buttonCancelEmployee.UseVisualStyleBackColor = false;
            // 
            // buttonSaveEmployee
            // 
            buttonSaveEmployee.BackColor = Color.DeepSkyBlue;
            buttonSaveEmployee.Dock = DockStyle.Fill;
            buttonSaveEmployee.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            buttonSaveEmployee.ForeColor = Color.White;
            buttonSaveEmployee.Image = (Image)resources.GetObject("buttonSaveEmployee.Image");
            buttonSaveEmployee.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSaveEmployee.Location = new Point(970, 267);
            buttonSaveEmployee.Name = "buttonSaveEmployee";
            tableLayoutPanel2.SetRowSpan(buttonSaveEmployee, 2);
            buttonSaveEmployee.Size = new Size(87, 69);
            buttonSaveEmployee.TabIndex = 44;
            buttonSaveEmployee.Text = "   Lưu";
            buttonSaveEmployee.UseVisualStyleBackColor = false;
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
            // comboBoxAccessLevel
            // 
            comboBoxAccessLevel.BackColor = SystemColors.Window;
            tableLayoutPanel2.SetColumnSpan(comboBoxAccessLevel, 2);
            comboBoxAccessLevel.Dock = DockStyle.Fill;
            comboBoxAccessLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAccessLevel.Font = new Font("Roboto", 10.2F);
            comboBoxAccessLevel.FormattingEnabled = true;
            comboBoxAccessLevel.Items.AddRange(new object[] { "Quản lý", "Nhân viên" });
            comboBoxAccessLevel.Location = new Point(373, 102);
            comboBoxAccessLevel.Name = "comboBoxAccessLevel";
            comboBoxAccessLevel.Size = new Size(581, 28);
            comboBoxAccessLevel.TabIndex = 48;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(694, 277);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 46;
            label3.Text = "Lương";
            // 
            // textBoxSalary
            // 
            textBoxSalary.BackColor = SystemColors.InactiveCaption;
            textBoxSalary.Dock = DockStyle.Fill;
            textBoxSalary.Font = new Font("Roboto", 10.2F);
            textBoxSalary.Location = new Point(694, 300);
            textBoxSalary.Name = "textBoxSalary";
            textBoxSalary.Size = new Size(260, 28);
            textBoxSalary.TabIndex = 47;
            textBoxSalary.Leave += textBoxSalary_Leave;
            // 
            // groupBoxCustomerInfo
            // 
            tableLayoutPanel1.SetColumnSpan(groupBoxCustomerInfo, 2);
            groupBoxCustomerInfo.Controls.Add(panel1);
            groupBoxCustomerInfo.Controls.Add(tableLayoutPanel2);
            groupBoxCustomerInfo.Dock = DockStyle.Fill;
            groupBoxCustomerInfo.Font = new Font("Roboto SemiCondensed Medium", 12F, FontStyle.Bold);
            groupBoxCustomerInfo.ForeColor = SystemColors.HotTrack;
            groupBoxCustomerInfo.Location = new Point(3, 3);
            groupBoxCustomerInfo.Name = "groupBoxCustomerInfo";
            groupBoxCustomerInfo.Size = new Size(1126, 370);
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
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1132, 753);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // UC_EmployeeManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "UC_EmployeeManagement";
            Size = new Size(1132, 753);
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
