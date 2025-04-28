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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panel2 = new Panel();
            labelRequestFilter = new Label();
            textBoxRequestSearch = new TextBox();
            buttonRequestSearch = new Button();
            labelStatusFilter = new Label();
            comboBoxRequestStatusFilter = new ComboBox();
            groupBox2 = new GroupBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            dateTimePickerForm = new DateTimePicker();
            dateTimePickerTo = new DateTimePicker();
            dataGridViewChat = new DataGridView();
            CustomerID = new DataGridViewTextBoxColumn();
            RequestID = new DataGridViewTextBoxColumn();
            Title = new DataGridViewTextBoxColumn();
            Message = new DataGridViewTextBoxColumn();
            RequestDate = new DataGridViewTextBoxColumn();
            HandledBy = new DataGridViewTextBoxColumn();
            RequestStatus = new DataGridViewTextBoxColumn();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel3 = new Panel();
            tableLayoutPanel3 = new TableLayoutPanel();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            panel4 = new Panel();
            tableLayoutPanel5 = new TableLayoutPanel();
            buttonViewRequest = new Button();
            buttonDeny = new Button();
            buttonHandle = new Button();
            buttonDone = new Button();
            panel5 = new Panel();
            tableLayoutPanel6 = new TableLayoutPanel();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            groupBox1 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox2.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewChat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            panel3.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel4.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            panel5.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
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
            labelRequestFilter.Location = new Point(95, 21);
            labelRequestFilter.Name = "labelRequestFilter";
            labelRequestFilter.Size = new Size(100, 20);
            labelRequestFilter.TabIndex = 26;
            labelRequestFilter.Text = "Lọc yêu cầu:";
            // 
            // textBoxRequestSearch
            // 
            textBoxRequestSearch.Dock = DockStyle.Fill;
            textBoxRequestSearch.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxRequestSearch.Location = new Point(293, 3);
            textBoxRequestSearch.Name = "textBoxRequestSearch";
            textBoxRequestSearch.PlaceholderText = "Tìm kiếm . . .";
            textBoxRequestSearch.Size = new Size(635, 32);
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
            buttonRequestSearch.Click += buttonRequestSearch_Click;
            // 
            // labelStatusFilter
            // 
            labelStatusFilter.Anchor = AnchorStyles.Bottom;
            labelStatusFilter.AutoSize = true;
            labelStatusFilter.BackColor = Color.Transparent;
            tableLayoutPanel4.SetColumnSpan(labelStatusFilter, 2);
            labelStatusFilter.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelStatusFilter.ForeColor = Color.Black;
            labelStatusFilter.Location = new Point(74, 114);
            labelStatusFilter.Name = "labelStatusFilter";
            labelStatusFilter.Size = new Size(142, 20);
            labelStatusFilter.TabIndex = 32;
            labelStatusFilter.Text = "Trạng thái yêu cầu";
            labelStatusFilter.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBoxRequestStatusFilter
            // 
            tableLayoutPanel4.SetColumnSpan(comboBoxRequestStatusFilter, 2);
            comboBoxRequestStatusFilter.Dock = DockStyle.Fill;
            comboBoxRequestStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRequestStatusFilter.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxRequestStatusFilter.FormattingEnabled = true;
            comboBoxRequestStatusFilter.Items.AddRange(new object[] { "Không áp dụng", "Chờ xử lý", "Đang xử lý", "Đã xử lý", "Từ chối xử lý" });
            comboBoxRequestStatusFilter.Location = new Point(3, 137);
            comboBoxRequestStatusFilter.Name = "comboBoxRequestStatusFilter";
            comboBoxRequestStatusFilter.Size = new Size(284, 28);
            comboBoxRequestStatusFilter.TabIndex = 47;
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
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.0395679F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.0395679F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 57.6438866F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.226619F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.05036F));
            tableLayoutPanel4.Controls.Add(textBoxRequestSearch, 2, 0);
            tableLayoutPanel4.Controls.Add(buttonRequestSearch, 3, 0);
            tableLayoutPanel4.Controls.Add(comboBoxRequestStatusFilter, 0, 4);
            tableLayoutPanel4.Controls.Add(labelRequestFilter, 0, 0);
            tableLayoutPanel4.Controls.Add(label1, 0, 5);
            tableLayoutPanel4.Controls.Add(label2, 1, 5);
            tableLayoutPanel4.Controls.Add(dateTimePickerForm, 0, 6);
            tableLayoutPanel4.Controls.Add(dateTimePickerTo, 1, 6);
            tableLayoutPanel4.Controls.Add(dataGridViewChat, 2, 1);
            tableLayoutPanel4.Controls.Add(labelStatusFilter, 0, 3);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 28);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 9;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 13.2679462F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 10.0642252F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 3.215434F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 16.7202568F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 10.0642252F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 10.9765768F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 11.5863867F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 18.9244747F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 4.98772144F));
            tableLayoutPanel4.Size = new Size(1112, 311);
            tableLayoutPanel4.TabIndex = 9;
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
            label2.Location = new Point(148, 179);
            label2.Name = "label2";
            label2.Size = new Size(38, 20);
            label2.TabIndex = 50;
            label2.Text = "Đến";
            // 
            // dateTimePickerForm
            // 
            dateTimePickerForm.Dock = DockStyle.Fill;
            dateTimePickerForm.Font = new Font("Roboto", 10.2F);
            dateTimePickerForm.Format = DateTimePickerFormat.Short;
            dateTimePickerForm.Location = new Point(3, 202);
            dateTimePickerForm.Name = "dateTimePickerForm";
            dateTimePickerForm.Size = new Size(139, 28);
            dateTimePickerForm.TabIndex = 51;
            // 
            // dateTimePickerTo
            // 
            dateTimePickerTo.Dock = DockStyle.Fill;
            dateTimePickerTo.Font = new Font("Roboto", 10.2F);
            dateTimePickerTo.Format = DateTimePickerFormat.Short;
            dateTimePickerTo.Location = new Point(148, 202);
            dateTimePickerTo.Name = "dateTimePickerTo";
            dateTimePickerTo.Size = new Size(139, 28);
            dateTimePickerTo.TabIndex = 52;
            // 
            // dataGridViewChat
            // 
            dataGridViewChat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewChat.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewChat.BackgroundColor = Color.White;
            dataGridViewChat.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewChat.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle3.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridViewChat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewChat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewChat.Columns.AddRange(new DataGridViewColumn[] { CustomerID, RequestID, Title, Message, RequestDate, HandledBy, RequestStatus });
            tableLayoutPanel4.SetColumnSpan(dataGridViewChat, 3);
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.HotTrack;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dataGridViewChat.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewChat.Dock = DockStyle.Fill;
            dataGridViewChat.EnableHeadersVisualStyles = false;
            dataGridViewChat.GridColor = Color.White;
            dataGridViewChat.Location = new Point(293, 44);
            dataGridViewChat.Name = "dataGridViewChat";
            dataGridViewChat.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewChat.RowHeadersVisible = false;
            dataGridViewChat.RowHeadersWidth = 51;
            tableLayoutPanel4.SetRowSpan(dataGridViewChat, 8);
            dataGridViewChat.Size = new Size(816, 264);
            dataGridViewChat.TabIndex = 53;
            // 
            // CustomerID
            // 
            CustomerID.HeaderText = "Mã khách hàng";
            CustomerID.MinimumWidth = 6;
            CustomerID.Name = "CustomerID";
            CustomerID.Width = 159;
            // 
            // RequestID
            // 
            RequestID.HeaderText = "Mã yêu cầu";
            RequestID.MinimumWidth = 6;
            RequestID.Name = "RequestID";
            RequestID.Width = 129;
            // 
            // Title
            // 
            Title.HeaderText = "Tiêu đề";
            Title.MinimumWidth = 6;
            Title.Name = "Title";
            Title.Width = 98;
            // 
            // Message
            // 
            Message.HeaderText = "Tin nhắn";
            Message.MinimumWidth = 6;
            Message.Name = "Message";
            Message.Width = 107;
            // 
            // RequestDate
            // 
            RequestDate.HeaderText = "Ngày yêu cầu";
            RequestDate.MinimumWidth = 6;
            RequestDate.Name = "RequestDate";
            RequestDate.Width = 145;
            // 
            // HandledBy
            // 
            HandledBy.HeaderText = "Nhân viên xử lý";
            HandledBy.MinimumWidth = 6;
            HandledBy.Name = "HandledBy";
            HandledBy.Width = 161;
            // 
            // RequestStatus
            // 
            RequestStatus.HeaderText = "Trạng thái";
            RequestStatus.MinimumWidth = 6;
            RequestStatus.Name = "RequestStatus";
            RequestStatus.Width = 119;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1045, 3);
            pictureBox1.Name = "pictureBox1";
            tableLayoutPanel2.SetRowSpan(pictureBox1, 3);
            pictureBox1.Size = new Size(64, 304);
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
            tableLayoutPanel2.ColumnCount = 11;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.0329237F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.5907755F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.11425257F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.5907755F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.47250175F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.5907755F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.38787651F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.5907755F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.92525244F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.75587654F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.948215F));
            tableLayoutPanel2.Controls.Add(pictureBox1, 10, 0);
            tableLayoutPanel2.Controls.Add(panel3, 0, 0);
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
            // panel3
            // 
            tableLayoutPanel2.SetColumnSpan(panel3, 10);
            panel3.Controls.Add(tableLayoutPanel3);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            tableLayoutPanel2.SetRowSpan(panel3, 3);
            panel3.Size = new Size(1036, 304);
            panel3.TabIndex = 10;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.886307F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 88.22739F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.88630724F));
            tableLayoutPanel3.Controls.Add(pictureBox2, 1, 1);
            tableLayoutPanel3.Controls.Add(pictureBox3, 1, 3);
            tableLayoutPanel3.Controls.Add(panel4, 1, 2);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 5;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 8.471502F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 10.5919533F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 61.8730927F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 10.5919533F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 8.471501F));
            tableLayoutPanel3.Size = new Size(1036, 304);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // pictureBox2
            // 
            pictureBox2.Dock = DockStyle.Fill;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(63, 28);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(908, 26);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Dock = DockStyle.Fill;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(63, 248);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(908, 26);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 1;
            pictureBox3.TabStop = false;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(tableLayoutPanel5);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(63, 60);
            panel4.Name = "panel4";
            panel4.Size = new Size(908, 182);
            panel4.TabIndex = 2;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 9;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel5.Controls.Add(buttonViewRequest, 1, 1);
            tableLayoutPanel5.Controls.Add(buttonDeny, 7, 1);
            tableLayoutPanel5.Controls.Add(buttonHandle, 3, 1);
            tableLayoutPanel5.Controls.Add(buttonDone, 5, 1);
            tableLayoutPanel5.Controls.Add(panel5, 0, 2);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(0, 0);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 4;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 4.67836237F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 53.2163734F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 35.08772F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 8.77193F));
            tableLayoutPanel5.Size = new Size(908, 182);
            tableLayoutPanel5.TabIndex = 0;
            // 
            // buttonViewRequest
            // 
            buttonViewRequest.BackColor = Color.PaleTurquoise;
            buttonViewRequest.Dock = DockStyle.Fill;
            buttonViewRequest.ForeColor = Color.Black;
            buttonViewRequest.Image = (Image)resources.GetObject("buttonViewRequest.Image");
            buttonViewRequest.Location = new Point(103, 11);
            buttonViewRequest.Name = "buttonViewRequest";
            buttonViewRequest.Size = new Size(94, 89);
            buttonViewRequest.TabIndex = 10;
            buttonViewRequest.UseVisualStyleBackColor = false;
            buttonViewRequest.Click += buttonViewRequest_Click;
            // 
            // buttonDeny
            // 
            buttonDeny.BackColor = Color.Tomato;
            buttonDeny.Dock = DockStyle.Fill;
            buttonDeny.ForeColor = Color.Black;
            buttonDeny.Image = (Image)resources.GetObject("buttonDeny.Image");
            buttonDeny.Location = new Point(703, 11);
            buttonDeny.Name = "buttonDeny";
            buttonDeny.Size = new Size(94, 89);
            buttonDeny.TabIndex = 13;
            buttonDeny.UseVisualStyleBackColor = false;
            buttonDeny.Click += buttonDeny_Click;
            // 
            // buttonHandle
            // 
            buttonHandle.BackColor = Color.FromArgb(255, 255, 128);
            buttonHandle.Dock = DockStyle.Fill;
            buttonHandle.ForeColor = Color.Black;
            buttonHandle.Image = (Image)resources.GetObject("buttonHandle.Image");
            buttonHandle.Location = new Point(303, 11);
            buttonHandle.Name = "buttonHandle";
            buttonHandle.Size = new Size(94, 89);
            buttonHandle.TabIndex = 14;
            buttonHandle.UseVisualStyleBackColor = false;
            buttonHandle.Click += buttonHandle_Click;
            // 
            // buttonDone
            // 
            buttonDone.BackColor = Color.LightGreen;
            buttonDone.Dock = DockStyle.Fill;
            buttonDone.ForeColor = Color.Black;
            buttonDone.Image = (Image)resources.GetObject("buttonDone.Image");
            buttonDone.Location = new Point(503, 11);
            buttonDone.Name = "buttonDone";
            buttonDone.Size = new Size(94, 89);
            buttonDone.TabIndex = 12;
            buttonDone.UseVisualStyleBackColor = false;
            buttonDone.Click += buttonDone_Click;
            // 
            // panel5
            // 
            tableLayoutPanel5.SetColumnSpan(panel5, 9);
            panel5.Controls.Add(tableLayoutPanel6);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(3, 106);
            panel5.Name = "panel5";
            tableLayoutPanel5.SetRowSpan(panel5, 2);
            panel5.Size = new Size(902, 73);
            panel5.TabIndex = 15;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 9;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.685454F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.9076862F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.878049F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.2971172F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6.31929064F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.9667406F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6.76274967F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.075388F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.860623F));
            tableLayoutPanel6.Controls.Add(label3, 1, 0);
            tableLayoutPanel6.Controls.Add(label4, 3, 0);
            tableLayoutPanel6.Controls.Add(label5, 5, 0);
            tableLayoutPanel6.Controls.Add(label6, 7, 0);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(0, 0);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 2;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 68.1159439F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 31.884058F));
            tableLayoutPanel6.Size = new Size(902, 73);
            tableLayoutPanel6.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(81, 0);
            label3.Name = "label3";
            label3.Size = new Size(146, 49);
            label3.TabIndex = 0;
            label3.Text = "Xem yêu cầu";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.ForeColor = Color.Black;
            label4.Location = new Point(277, 0);
            label4.Name = "label4";
            label4.Size = new Size(141, 49);
            label4.TabIndex = 1;
            label4.Text = "Xử lý yêu cầu";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.ForeColor = Color.Black;
            label5.Location = new Point(481, 0);
            label5.Name = "label5";
            label5.Size = new Size(129, 49);
            label5.TabIndex = 2;
            label5.Text = "Hoàn thành";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.ForeColor = Color.Black;
            label6.Location = new Point(677, 0);
            label6.Name = "label6";
            label6.Size = new Size(139, 49);
            label6.TabIndex = 3;
            label6.Text = "Hủy";
            label6.TextAlign = ContentAlignment.MiddleCenter;
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
            ((System.ComponentModel.ISupportInitialize)dataGridViewChat).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel4.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            panel5.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
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
        private Label labelStatusFilter;
        private ComboBox comboBoxRequestStatusFilter;
        private DataGridView dataGridViewTransactionManagement;
        private TableLayoutPanel tableLayoutPanel4;
        private GroupBox groupBox2;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox1;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel2;
        private PictureBox pictureBox1;
        private Button buttonViewRequest;
        private Button buttonDone;
        private Button buttonDeny;
        private Label label1;
        private Label label2;
        private DateTimePicker dateTimePickerForm;
        private DateTimePicker dateTimePickerTo;
        private DataGridView dataGridViewChat;
        private Button buttonHandle;
        private DataGridViewTextBoxColumn CustomerID;
        private DataGridViewTextBoxColumn RequestID;
        private DataGridViewTextBoxColumn Title;
        private DataGridViewTextBoxColumn Message;
        private DataGridViewTextBoxColumn RequestDate;
        private DataGridViewTextBoxColumn HandledBy;
        private DataGridViewTextBoxColumn RequestStatus;
        private Panel panel3;
        private TableLayoutPanel tableLayoutPanel3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Panel panel4;
        private TableLayoutPanel tableLayoutPanel5;
        private Panel panel5;
        private TableLayoutPanel tableLayoutPanel6;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}
