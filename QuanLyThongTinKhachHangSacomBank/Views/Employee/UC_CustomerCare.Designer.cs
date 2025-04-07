namespace QuanLyThongTinKhachHangSacomBank.Views.Employee
{
    partial class UC_CustomerCare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_CustomerCare));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panel2 = new Panel();
            labelRequestFilter = new Label();
            textBoxRequestSearch = new TextBox();
            buttonRequestSearch = new Button();
            labelViewStatusFilter = new Label();
            comboBoxViewStatusFilter = new ComboBox();
            labelStatusFilter = new Label();
            comboBoxChatStatusFilter = new ComboBox();
            groupBox2 = new GroupBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            dataGridViewCustomerCareManagement = new DataGridView();
            ChatID = new DataGridViewTextBoxColumn();
            AccountID = new DataGridViewTextBoxColumn();
            CustomerID = new DataGridViewTextBoxColumn();
            FullName = new DataGridViewTextBoxColumn();
            HandledBy = new DataGridViewTextBoxColumn();
            ChatDate = new DataGridViewTextBoxColumn();
            ViewStatus = new DataGridViewTextBoxColumn();
            ChatStatus = new DataGridViewTextBoxColumn();
            label1 = new Label();
            label2 = new Label();
            dateTimePickerForm = new DateTimePicker();
            dateTimePickerTo = new DateTimePicker();
            buttonFilterConfirm = new Button();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            buttonChat = new Button();
            buttonDone = new Button();
            buttonCancel = new Button();
            groupBox1 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox2.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCustomerCareManagement).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            groupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.HotTrack;
            panel2.Location = new Point(271, 11);
            panel2.Name = "panel2";
            panel2.Size = new Size(450, 5);
            panel2.TabIndex = 6;
            // 
            // labelRequestFilter
            // 
            labelRequestFilter.Anchor = AnchorStyles.Bottom;
            labelRequestFilter.AutoSize = true;
            labelRequestFilter.BackColor = Color.Transparent;
            tableLayoutPanel4.SetColumnSpan(labelRequestFilter, 2);
            labelRequestFilter.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelRequestFilter.ForeColor = Color.Black;
            labelRequestFilter.Location = new Point(104, 21);
            labelRequestFilter.Name = "labelRequestFilter";
            labelRequestFilter.Size = new Size(100, 20);
            labelRequestFilter.TabIndex = 26;
            labelRequestFilter.Text = "Lọc yêu cầu:";
            // 
            // textBoxRequestSearch
            // 
            textBoxRequestSearch.Dock = DockStyle.Fill;
            textBoxRequestSearch.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxRequestSearch.Location = new Point(311, 3);
            textBoxRequestSearch.Name = "textBoxRequestSearch";
            textBoxRequestSearch.PlaceholderText = "Tìm kiếm . . .";
            textBoxRequestSearch.Size = new Size(617, 32);
            textBoxRequestSearch.TabIndex = 2;
            textBoxRequestSearch.WordWrap = false;
            // 
            // buttonRequestSearch
            // 
            buttonRequestSearch.BackColor = SystemColors.HotTrack;
            buttonRequestSearch.Dock = DockStyle.Fill;
            buttonRequestSearch.ForeColor = Color.White;
            buttonRequestSearch.Image = (Image)resources.GetObject("buttonRequestSearch.Image");
            buttonRequestSearch.Location = new Point(934, 3);
            buttonRequestSearch.Name = "buttonRequestSearch";
            buttonRequestSearch.Size = new Size(41, 35);
            buttonRequestSearch.TabIndex = 6;
            buttonRequestSearch.UseVisualStyleBackColor = false;
            // 
            // labelViewStatusFilter
            // 
            labelViewStatusFilter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelViewStatusFilter.AutoSize = true;
            labelViewStatusFilter.BackColor = Color.Transparent;
            labelViewStatusFilter.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelViewStatusFilter.ForeColor = Color.Black;
            labelViewStatusFilter.Location = new Point(3, 52);
            labelViewStatusFilter.Name = "labelViewStatusFilter";
            labelViewStatusFilter.Size = new Size(144, 20);
            labelViewStatusFilter.TabIndex = 27;
            labelViewStatusFilter.Text = "Trạng thái tin nhắn";
            // 
            // comboBoxViewStatusFilter
            // 
            comboBoxViewStatusFilter.BackColor = SystemColors.Window;
            tableLayoutPanel4.SetColumnSpan(comboBoxViewStatusFilter, 2);
            comboBoxViewStatusFilter.Dock = DockStyle.Fill;
            comboBoxViewStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxViewStatusFilter.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxViewStatusFilter.FormattingEnabled = true;
            comboBoxViewStatusFilter.Items.AddRange(new object[] { "Không áp dụng", "Tin nhắn mới!", "Đã xem" });
            comboBoxViewStatusFilter.Location = new Point(3, 75);
            comboBoxViewStatusFilter.Name = "comboBoxViewStatusFilter";
            comboBoxViewStatusFilter.Size = new Size(302, 28);
            comboBoxViewStatusFilter.TabIndex = 28;
            // 
            // labelStatusFilter
            // 
            labelStatusFilter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelStatusFilter.AutoSize = true;
            labelStatusFilter.BackColor = Color.Transparent;
            labelStatusFilter.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelStatusFilter.ForeColor = Color.Black;
            labelStatusFilter.Location = new Point(3, 114);
            labelStatusFilter.Name = "labelStatusFilter";
            labelStatusFilter.Size = new Size(158, 20);
            labelStatusFilter.TabIndex = 32;
            labelStatusFilter.Text = "Trạng thái đoạn chat";
            // 
            // comboBoxChatStatusFilter
            // 
            tableLayoutPanel4.SetColumnSpan(comboBoxChatStatusFilter, 2);
            comboBoxChatStatusFilter.Dock = DockStyle.Fill;
            comboBoxChatStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxChatStatusFilter.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxChatStatusFilter.FormattingEnabled = true;
            comboBoxChatStatusFilter.Items.AddRange(new object[] { "Không áp dụng", "Chưa xử lý", "Đang xử lý", "Đã xử lý" });
            comboBoxChatStatusFilter.Location = new Point(3, 137);
            comboBoxChatStatusFilter.Name = "comboBoxChatStatusFilter";
            comboBoxChatStatusFilter.Size = new Size(302, 28);
            comboBoxChatStatusFilter.TabIndex = 47;
            // 
            // groupBox2
            // 
            tableLayoutPanel1.SetColumnSpan(groupBox2, 2);
            groupBox2.Controls.Add(tableLayoutPanel4);
            groupBox2.Controls.Add(panel2);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Font = new Font("Roboto SemiCondensed Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.ForeColor = SystemColors.HotTrack;
            groupBox2.Location = new Point(3, 350);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1118, 342);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Dữ liệu yêu cầu khách hàng";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 5;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.838129F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.8597126F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 56.02518F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.226619F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.05036F));
            tableLayoutPanel4.Controls.Add(textBoxRequestSearch, 2, 0);
            tableLayoutPanel4.Controls.Add(buttonRequestSearch, 3, 0);
            tableLayoutPanel4.Controls.Add(dataGridViewCustomerCareManagement, 2, 1);
            tableLayoutPanel4.Controls.Add(labelViewStatusFilter, 0, 1);
            tableLayoutPanel4.Controls.Add(comboBoxViewStatusFilter, 0, 2);
            tableLayoutPanel4.Controls.Add(labelStatusFilter, 0, 3);
            tableLayoutPanel4.Controls.Add(comboBoxChatStatusFilter, 0, 4);
            tableLayoutPanel4.Controls.Add(labelRequestFilter, 0, 0);
            tableLayoutPanel4.Controls.Add(label1, 0, 5);
            tableLayoutPanel4.Controls.Add(label2, 1, 5);
            tableLayoutPanel4.Controls.Add(dateTimePickerForm, 0, 6);
            tableLayoutPanel4.Controls.Add(dateTimePickerTo, 1, 6);
            tableLayoutPanel4.Controls.Add(buttonFilterConfirm, 0, 7);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 28);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 9;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 13.2679462F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 10.0642252F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 10.0642252F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 10.0642252F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 10.0642252F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 10.9765768F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 11.5863867F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 18.9244747F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 4.98772144F));
            tableLayoutPanel4.Size = new Size(1112, 311);
            tableLayoutPanel4.TabIndex = 9;
            // 
            // dataGridViewCustomerCareManagement
            // 
            dataGridViewCustomerCareManagement.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCustomerCareManagement.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCustomerCareManagement.BackgroundColor = Color.White;
            dataGridViewCustomerCareManagement.BorderStyle = BorderStyle.None;
            dataGridViewCustomerCareManagement.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewCustomerCareManagement.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridViewCustomerCareManagement.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCustomerCareManagement.ColumnHeadersHeight = 29;
            dataGridViewCustomerCareManagement.Columns.AddRange(new DataGridViewColumn[] { ChatID, AccountID, CustomerID, FullName, HandledBy, ChatDate, ViewStatus, ChatStatus });
            tableLayoutPanel4.SetColumnSpan(dataGridViewCustomerCareManagement, 3);
            dataGridViewCustomerCareManagement.Dock = DockStyle.Fill;
            dataGridViewCustomerCareManagement.EnableHeadersVisualStyles = false;
            dataGridViewCustomerCareManagement.GridColor = Color.White;
            dataGridViewCustomerCareManagement.Location = new Point(311, 44);
            dataGridViewCustomerCareManagement.Name = "dataGridViewCustomerCareManagement";
            dataGridViewCustomerCareManagement.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCustomerCareManagement.RowHeadersVisible = false;
            dataGridViewCustomerCareManagement.RowHeadersWidth = 51;
            tableLayoutPanel4.SetRowSpan(dataGridViewCustomerCareManagement, 8);
            dataGridViewCustomerCareManagement.Size = new Size(798, 264);
            dataGridViewCustomerCareManagement.TabIndex = 48;
            // 
            // ChatID
            // 
            ChatID.HeaderText = "Mã đoạn chat";
            ChatID.MinimumWidth = 6;
            ChatID.Name = "ChatID";
            // 
            // AccountID
            // 
            AccountID.HeaderText = "Mã tài khoản";
            AccountID.MinimumWidth = 6;
            AccountID.Name = "AccountID";
            // 
            // CustomerID
            // 
            CustomerID.HeaderText = "Mã khách hàng";
            CustomerID.MinimumWidth = 6;
            CustomerID.Name = "CustomerID";
            // 
            // FullName
            // 
            FullName.HeaderText = "Họ tên khách hàng";
            FullName.MinimumWidth = 6;
            FullName.Name = "FullName";
            // 
            // HandledBy
            // 
            HandledBy.HeaderText = "Nhân viên tiếp nhận";
            HandledBy.MinimumWidth = 6;
            HandledBy.Name = "HandledBy";
            // 
            // ChatDate
            // 
            ChatDate.HeaderText = "Ngày chat";
            ChatDate.MinimumWidth = 6;
            ChatDate.Name = "ChatDate";
            // 
            // ViewStatus
            // 
            ViewStatus.HeaderText = "Trạng thái tin nhắn";
            ViewStatus.MinimumWidth = 6;
            ViewStatus.Name = "ViewStatus";
            // 
            // ChatStatus
            // 
            ChatStatus.HeaderText = "Trạng thái đoạn chat";
            ChatStatus.MinimumWidth = 6;
            ChatStatus.Name = "ChatStatus";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(3, 179);
            label1.Name = "label1";
            label1.Size = new Size(28, 20);
            label1.TabIndex = 49;
            label1.Text = "Từ";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(168, 179);
            label2.Name = "label2";
            label2.Size = new Size(38, 20);
            label2.TabIndex = 50;
            label2.Text = "Đến";
            // 
            // dateTimePickerForm
            // 
            dateTimePickerForm.Dock = DockStyle.Fill;
            dateTimePickerForm.Font = new Font("Roboto", 10.2F);
            dateTimePickerForm.Location = new Point(3, 202);
            dateTimePickerForm.Name = "dateTimePickerForm";
            dateTimePickerForm.Size = new Size(159, 28);
            dateTimePickerForm.TabIndex = 51;
            // 
            // dateTimePickerTo
            // 
            dateTimePickerTo.Dock = DockStyle.Fill;
            dateTimePickerTo.Font = new Font("Roboto", 10.2F);
            dateTimePickerTo.Location = new Point(168, 202);
            dateTimePickerTo.Name = "dateTimePickerTo";
            dateTimePickerTo.Size = new Size(137, 28);
            dateTimePickerTo.TabIndex = 52;
            // 
            // buttonFilterConfirm
            // 
            tableLayoutPanel4.SetColumnSpan(buttonFilterConfirm, 2);
            buttonFilterConfirm.Dock = DockStyle.Fill;
            buttonFilterConfirm.Image = (Image)resources.GetObject("buttonFilterConfirm.Image");
            buttonFilterConfirm.Location = new Point(3, 238);
            buttonFilterConfirm.Name = "buttonFilterConfirm";
            buttonFilterConfirm.Size = new Size(302, 52);
            buttonFilterConfirm.TabIndex = 53;
            buttonFilterConfirm.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1051, 3);
            pictureBox1.Name = "pictureBox1";
            tableLayoutPanel2.SetRowSpan(pictureBox1, 3);
            pictureBox1.Size = new Size(58, 304);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.HotTrack;
            panel1.Location = new Point(189, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(236, 5);
            panel1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 9;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.9280577F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.9388485F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.3417263F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.9388485F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.7913666F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.9388485F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.19424438F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.193012F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.58862162F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Controls.Add(pictureBox1, 8, 0);
            tableLayoutPanel2.Controls.Add(buttonChat, 1, 1);
            tableLayoutPanel2.Controls.Add(buttonDone, 3, 1);
            tableLayoutPanel2.Controls.Add(buttonCancel, 5, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 28);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 22.6637F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 54.6726F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 22.6637F));
            tableLayoutPanel2.Size = new Size(1112, 310);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // buttonChat
            // 
            buttonChat.BackColor = Color.PaleTurquoise;
            buttonChat.Dock = DockStyle.Fill;
            buttonChat.ForeColor = Color.Black;
            buttonChat.Image = (Image)resources.GetObject("buttonChat.Image");
            buttonChat.ImageAlign = ContentAlignment.TopCenter;
            buttonChat.Location = new Point(169, 73);
            buttonChat.Name = "buttonChat";
            buttonChat.Size = new Size(149, 163);
            buttonChat.TabIndex = 10;
            buttonChat.Text = "Liên hệ khách hàng";
            buttonChat.UseVisualStyleBackColor = false;
            buttonChat.Click += buttonChat_Click;
            // 
            // buttonDone
            // 
            buttonDone.BackColor = Color.LightGreen;
            buttonDone.Dock = DockStyle.Fill;
            buttonDone.ForeColor = Color.Black;
            buttonDone.Image = (Image)resources.GetObject("buttonDone.Image");
            buttonDone.ImageAlign = ContentAlignment.TopCenter;
            buttonDone.Location = new Point(439, 73);
            buttonDone.Name = "buttonDone";
            buttonDone.Size = new Size(149, 163);
            buttonDone.TabIndex = 12;
            buttonDone.Text = "Hoàn thành";
            buttonDone.UseVisualStyleBackColor = false;
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.Tomato;
            buttonCancel.Dock = DockStyle.Fill;
            buttonCancel.ForeColor = Color.Black;
            buttonCancel.Image = (Image)resources.GetObject("buttonCancel.Image");
            buttonCancel.ImageAlign = ContentAlignment.TopCenter;
            buttonCancel.Location = new Point(714, 73);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(149, 163);
            buttonCancel.TabIndex = 13;
            buttonCancel.Text = "Hủy";
            buttonCancel.UseVisualStyleBackColor = false;
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
            groupBox1.Size = new Size(1118, 341);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Hỗ trợ khách hàng";
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
            tableLayoutPanel1.Size = new Size(1124, 695);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // UC_CustomerCare
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "UC_CustomerCare";
            Size = new Size(1124, 695);
            groupBox2.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCustomerCareManagement).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private DataGridViewTextBoxColumn TransactionDate;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn Amount;
        private DataGridViewTextBoxColumn DestinationAccountID;
        private DataGridViewTextBoxColumn TransactionID;
        private DataGridViewTextBoxColumn TransactionType;
        private Label labelRequestFilter;
        private TextBox textBoxRequestSearch;
        private Button buttonRequestSearch;
        private Label labelViewStatusFilter;
        private ComboBox comboBoxViewStatusFilter;
        private Label labelStatusFilter;
        private ComboBox comboBoxChatStatusFilter;
        private DataGridView dataGridViewTransactionManagement;
        private TableLayoutPanel tableLayoutPanel4;
        private GroupBox groupBox2;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox1;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel2;
        private PictureBox pictureBox1;
        private Button buttonChat;
        private Button buttonDone;
        private Button buttonCancel;
        private DataGridView dataGridViewCustomerCareManagement;
        private DataGridViewTextBoxColumn ChatID;
        private DataGridViewTextBoxColumn AccountID;
        private DataGridViewTextBoxColumn CustomerID;
        private DataGridViewTextBoxColumn FullName;
        private DataGridViewTextBoxColumn HandledBy;
        private DataGridViewTextBoxColumn ChatDate;
        private DataGridViewTextBoxColumn ViewStatus;
        private DataGridViewTextBoxColumn ChatStatus;
        private Label label1;
        private Label label2;
        private DateTimePicker dateTimePickerForm;
        private DateTimePicker dateTimePickerTo;
        private Button buttonFilterConfirm;
    }
}
