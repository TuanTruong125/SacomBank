﻿namespace QuanLyThongTinKhachHangSacomBank.Views.Employee
{
    partial class UC_TransactionManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_TransactionManagement));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            panel1 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            panel3 = new Panel();
            tableLayoutPanel3 = new TableLayoutPanel();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            panel4 = new Panel();
            tableLayoutPanel5 = new TableLayoutPanel();
            buttonTransfer = new Button();
            buttonPay = new Button();
            buttonDeposit = new Button();
            buttonWithdraw = new Button();
            panel5 = new Panel();
            tableLayoutPanel6 = new TableLayoutPanel();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            groupBox2 = new GroupBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            buttonExportCSV = new Button();
            buttonExportExcel = new Button();
            buttonExportPDF = new Button();
            textBoxTransactionSearch = new TextBox();
            buttonTransactionSearch = new Button();
            dataGridViewTransactionManagement = new DataGridView();
            CustomerID = new DataGridViewTextBoxColumn();
            AccountID = new DataGridViewTextBoxColumn();
            AccountName = new DataGridViewTextBoxColumn();
            TransactionTypeName = new DataGridViewTextBoxColumn();
            TransactionID = new DataGridViewTextBoxColumn();
            ReceiverAccountName = new DataGridViewTextBoxColumn();
            ReceiverAccountID = new DataGridViewTextBoxColumn();
            Amount = new DataGridViewTextBoxColumn();
            TransactionDescription = new DataGridViewTextBoxColumn();
            TransactionDate = new DataGridViewTextBoxColumn();
            TransactionMethod = new DataGridViewTextBoxColumn();
            HandledBy = new DataGridViewTextBoxColumn();
            TransactionStatus = new DataGridViewTextBoxColumn();
            labelTransactionTypeFilter = new Label();
            labelStatusFilter = new Label();
            comboBoxTransactionTypeFilter = new ComboBox();
            comboBoxStatusFilter = new ComboBox();
            labelTransactionFilter = new Label();
            label1 = new Label();
            label2 = new Label();
            buttonViewDetail = new Button();
            dateTimePickerFrom = new DateTimePicker();
            dateTimePickerTo = new DateTimePicker();
            panel2 = new Panel();
            tableLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel4.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            panel5.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            groupBox2.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTransactionManagement).BeginInit();
            SuspendLayout();
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
            tableLayoutPanel1.TabIndex = 0;
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
            groupBox1.Text = "Giao dịch";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.HotTrack;
            panel1.Location = new Point(109, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(236, 5);
            panel1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 10;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.5138569F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.5205126F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.469374F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.51565F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6.33250666F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.3266182F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.655717F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.9882231F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.506351F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.17118645F));
            tableLayoutPanel2.Controls.Add(pictureBox1, 9, 0);
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
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1054, 3);
            pictureBox1.Name = "pictureBox1";
            tableLayoutPanel2.SetRowSpan(pictureBox1, 3);
            pictureBox1.Size = new Size(55, 304);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            tableLayoutPanel2.SetColumnSpan(panel3, 9);
            panel3.Controls.Add(tableLayoutPanel3);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            tableLayoutPanel2.SetRowSpan(panel3, 3);
            panel3.Size = new Size(1045, 304);
            panel3.TabIndex = 10;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.683316F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 88.63336F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.68331575F));
            tableLayoutPanel3.Controls.Add(pictureBox2, 1, 1);
            tableLayoutPanel3.Controls.Add(pictureBox3, 1, 3);
            tableLayoutPanel3.Controls.Add(panel4, 1, 2);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 5;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 6.3164897F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 10.1063833F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 67.15425F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 10.1063833F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 6.3164897F));
            tableLayoutPanel3.Size = new Size(1045, 304);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // pictureBox2
            // 
            pictureBox2.Dock = DockStyle.Fill;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(62, 22);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(920, 24);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Dock = DockStyle.Fill;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(62, 256);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(920, 24);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 1;
            pictureBox3.TabStop = false;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(tableLayoutPanel5);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(62, 52);
            panel4.Name = "panel4";
            panel4.Size = new Size(920, 198);
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
            tableLayoutPanel5.Controls.Add(buttonTransfer, 5, 1);
            tableLayoutPanel5.Controls.Add(buttonPay, 7, 1);
            tableLayoutPanel5.Controls.Add(buttonDeposit, 1, 1);
            tableLayoutPanel5.Controls.Add(buttonWithdraw, 3, 1);
            tableLayoutPanel5.Controls.Add(panel5, 0, 2);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(0, 0);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 4;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 5.050505F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 44.4444427F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel5.Size = new Size(920, 198);
            tableLayoutPanel5.TabIndex = 0;
            // 
            // buttonTransfer
            // 
            buttonTransfer.BackColor = Color.RoyalBlue;
            buttonTransfer.Dock = DockStyle.Fill;
            buttonTransfer.ForeColor = Color.Black;
            buttonTransfer.Image = (Image)resources.GetObject("buttonTransfer.Image");
            buttonTransfer.Location = new Point(513, 13);
            buttonTransfer.Name = "buttonTransfer";
            buttonTransfer.Size = new Size(96, 82);
            buttonTransfer.TabIndex = 7;
            buttonTransfer.UseVisualStyleBackColor = false;
            buttonTransfer.Click += buttonTransfer_Click;
            // 
            // buttonPay
            // 
            buttonPay.BackColor = Color.Gold;
            buttonPay.Dock = DockStyle.Fill;
            buttonPay.ForeColor = Color.Black;
            buttonPay.Image = (Image)resources.GetObject("buttonPay.Image");
            buttonPay.Location = new Point(717, 13);
            buttonPay.Name = "buttonPay";
            buttonPay.Size = new Size(96, 82);
            buttonPay.TabIndex = 8;
            buttonPay.UseVisualStyleBackColor = false;
            buttonPay.Click += buttonPay_Click;
            // 
            // buttonDeposit
            // 
            buttonDeposit.BackColor = Color.LightGreen;
            buttonDeposit.Dock = DockStyle.Fill;
            buttonDeposit.ForeColor = Color.Black;
            buttonDeposit.Image = (Image)resources.GetObject("buttonDeposit.Image");
            buttonDeposit.Location = new Point(105, 13);
            buttonDeposit.Name = "buttonDeposit";
            buttonDeposit.Size = new Size(96, 82);
            buttonDeposit.TabIndex = 5;
            buttonDeposit.UseVisualStyleBackColor = false;
            buttonDeposit.Click += buttonDeposit_Click;
            // 
            // buttonWithdraw
            // 
            buttonWithdraw.BackColor = Color.Coral;
            buttonWithdraw.Dock = DockStyle.Fill;
            buttonWithdraw.ForeColor = Color.Black;
            buttonWithdraw.Image = (Image)resources.GetObject("buttonWithdraw.Image");
            buttonWithdraw.Location = new Point(309, 13);
            buttonWithdraw.Name = "buttonWithdraw";
            buttonWithdraw.Size = new Size(96, 82);
            buttonWithdraw.TabIndex = 6;
            buttonWithdraw.UseVisualStyleBackColor = false;
            buttonWithdraw.Click += buttonWithdraw_Click;
            // 
            // panel5
            // 
            tableLayoutPanel5.SetColumnSpan(panel5, 9);
            panel5.Controls.Add(tableLayoutPanel6);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(3, 101);
            panel5.Name = "panel5";
            tableLayoutPanel5.SetRowSpan(panel5, 2);
            panel5.Size = new Size(914, 94);
            panel5.TabIndex = 9;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 9;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.874341F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.203867F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.0940247F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.4235506F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.446397F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.9499121F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.862144F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.0196934F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.0395432F));
            tableLayoutPanel6.Controls.Add(label3, 1, 0);
            tableLayoutPanel6.Controls.Add(label4, 3, 0);
            tableLayoutPanel6.Controls.Add(label5, 5, 0);
            tableLayoutPanel6.Controls.Add(label6, 7, 0);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(0, 0);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 2;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Size = new Size(914, 94);
            tableLayoutPanel6.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(102, 0);
            label3.Name = "label3";
            label3.Size = new Size(96, 47);
            label3.TabIndex = 0;
            label3.Text = "Nạp tiền";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.ForeColor = Color.Black;
            label4.Location = new Point(305, 0);
            label4.Name = "label4";
            label4.Size = new Size(98, 47);
            label4.TabIndex = 1;
            label4.Text = "Rút tiền";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.ForeColor = Color.Black;
            label5.Location = new Point(495, 0);
            label5.Name = "label5";
            label5.Size = new Size(121, 47);
            label5.TabIndex = 2;
            label5.Text = "Chuyển tiền";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.ForeColor = Color.Black;
            label6.Location = new Point(703, 0);
            label6.Name = "label6";
            label6.Size = new Size(113, 47);
            label6.TabIndex = 3;
            label6.Text = "Thanh toán";
            label6.TextAlign = ContentAlignment.MiddleCenter;
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
            groupBox2.Text = "Dữ liệu dịch vụ khách hàng";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 8;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.0273952F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.8423567F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.2752266F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.10201263F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.8888636F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.8888636F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.8888636F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 3.086414F));
            tableLayoutPanel4.Controls.Add(buttonExportCSV, 6, 0);
            tableLayoutPanel4.Controls.Add(buttonExportExcel, 5, 0);
            tableLayoutPanel4.Controls.Add(buttonExportPDF, 4, 0);
            tableLayoutPanel4.Controls.Add(textBoxTransactionSearch, 2, 0);
            tableLayoutPanel4.Controls.Add(buttonTransactionSearch, 3, 0);
            tableLayoutPanel4.Controls.Add(dataGridViewTransactionManagement, 2, 1);
            tableLayoutPanel4.Controls.Add(labelTransactionTypeFilter, 0, 1);
            tableLayoutPanel4.Controls.Add(labelStatusFilter, 1, 1);
            tableLayoutPanel4.Controls.Add(comboBoxTransactionTypeFilter, 0, 2);
            tableLayoutPanel4.Controls.Add(comboBoxStatusFilter, 1, 2);
            tableLayoutPanel4.Controls.Add(labelTransactionFilter, 0, 0);
            tableLayoutPanel4.Controls.Add(label1, 0, 3);
            tableLayoutPanel4.Controls.Add(label2, 1, 3);
            tableLayoutPanel4.Controls.Add(buttonViewDetail, 0, 6);
            tableLayoutPanel4.Controls.Add(dateTimePickerFrom, 0, 4);
            tableLayoutPanel4.Controls.Add(dateTimePickerTo, 1, 4);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 28);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 8;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 16.869278F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 8.434639F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 11.0299129F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 8.110231F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 16.2204628F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 18.4913254F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 19.7889614F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 1.05518651F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Size = new Size(1112, 311);
            tableLayoutPanel4.TabIndex = 9;
            // 
            // buttonExportCSV
            // 
            buttonExportCSV.Dock = DockStyle.Fill;
            buttonExportCSV.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonExportCSV.ForeColor = Color.FromArgb(25, 137, 14);
            buttonExportCSV.Image = (Image)resources.GetObject("buttonExportCSV.Image");
            buttonExportCSV.Location = new Point(923, 3);
            buttonExportCSV.Name = "buttonExportCSV";
            buttonExportCSV.Size = new Size(148, 46);
            buttonExportCSV.TabIndex = 55;
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
            buttonExportExcel.Location = new Point(769, 3);
            buttonExportExcel.Name = "buttonExportExcel";
            buttonExportExcel.Size = new Size(148, 46);
            buttonExportExcel.TabIndex = 54;
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
            buttonExportPDF.Location = new Point(615, 3);
            buttonExportPDF.Name = "buttonExportPDF";
            buttonExportPDF.Size = new Size(148, 46);
            buttonExportPDF.TabIndex = 53;
            buttonExportPDF.Text = "Xuất PDF";
            buttonExportPDF.TextAlign = ContentAlignment.MiddleLeft;
            buttonExportPDF.TextImageRelation = TextImageRelation.TextBeforeImage;
            buttonExportPDF.UseVisualStyleBackColor = true;
            buttonExportPDF.Click += buttonExportPDF_Click;
            // 
            // textBoxTransactionSearch
            // 
            textBoxTransactionSearch.Dock = DockStyle.Fill;
            textBoxTransactionSearch.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxTransactionSearch.Location = new Point(267, 3);
            textBoxTransactionSearch.Name = "textBoxTransactionSearch";
            textBoxTransactionSearch.PlaceholderText = "Tìm kiếm . . .";
            textBoxTransactionSearch.Size = new Size(286, 32);
            textBoxTransactionSearch.TabIndex = 2;
            textBoxTransactionSearch.WordWrap = false;
            // 
            // buttonTransactionSearch
            // 
            buttonTransactionSearch.BackColor = SystemColors.HotTrack;
            buttonTransactionSearch.Dock = DockStyle.Fill;
            buttonTransactionSearch.ForeColor = Color.White;
            buttonTransactionSearch.Image = (Image)resources.GetObject("buttonTransactionSearch.Image");
            buttonTransactionSearch.Location = new Point(559, 3);
            buttonTransactionSearch.Name = "buttonTransactionSearch";
            buttonTransactionSearch.Size = new Size(50, 46);
            buttonTransactionSearch.TabIndex = 6;
            buttonTransactionSearch.UseVisualStyleBackColor = false;
            buttonTransactionSearch.Click += buttonTransactionSearch_Click;
            // 
            // dataGridViewTransactionManagement
            // 
            dataGridViewTransactionManagement.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewTransactionManagement.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewTransactionManagement.BackgroundColor = Color.White;
            dataGridViewTransactionManagement.BorderStyle = BorderStyle.None;
            dataGridViewTransactionManagement.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewTransactionManagement.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridViewTransactionManagement.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewTransactionManagement.ColumnHeadersHeight = 29;
            dataGridViewTransactionManagement.Columns.AddRange(new DataGridViewColumn[] { CustomerID, AccountID, AccountName, TransactionTypeName, TransactionID, ReceiverAccountName, ReceiverAccountID, Amount, TransactionDescription, TransactionDate, TransactionMethod, HandledBy, TransactionStatus });
            tableLayoutPanel4.SetColumnSpan(dataGridViewTransactionManagement, 6);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.HotTrack;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewTransactionManagement.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewTransactionManagement.Dock = DockStyle.Fill;
            dataGridViewTransactionManagement.EnableHeadersVisualStyles = false;
            dataGridViewTransactionManagement.GridColor = Color.White;
            dataGridViewTransactionManagement.Location = new Point(267, 55);
            dataGridViewTransactionManagement.Name = "dataGridViewTransactionManagement";
            dataGridViewTransactionManagement.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewTransactionManagement.RowHeadersVisible = false;
            dataGridViewTransactionManagement.RowHeadersWidth = 51;
            tableLayoutPanel4.SetRowSpan(dataGridViewTransactionManagement, 7);
            dataGridViewTransactionManagement.Size = new Size(842, 253);
            dataGridViewTransactionManagement.TabIndex = 49;
            dataGridViewTransactionManagement.SelectionChanged += dataGridViewTransactionManagement_SelectionChanged;
            // 
            // CustomerID
            // 
            CustomerID.HeaderText = "Mã khách hàng";
            CustomerID.MinimumWidth = 6;
            CustomerID.Name = "CustomerID";
            CustomerID.Width = 159;
            // 
            // AccountID
            // 
            AccountID.HeaderText = "Mã tài khoản";
            AccountID.MinimumWidth = 6;
            AccountID.Name = "AccountID";
            AccountID.Width = 141;
            // 
            // AccountName
            // 
            AccountName.HeaderText = "Tên tài khoản";
            AccountName.MinimumWidth = 6;
            AccountName.Name = "AccountName";
            AccountName.Width = 146;
            // 
            // TransactionTypeName
            // 
            TransactionTypeName.HeaderText = "Loại giao dịch";
            TransactionTypeName.MinimumWidth = 6;
            TransactionTypeName.Name = "TransactionTypeName";
            TransactionTypeName.Width = 150;
            // 
            // TransactionID
            // 
            TransactionID.HeaderText = "Mã giao dịch";
            TransactionID.MinimumWidth = 6;
            TransactionID.Name = "TransactionID";
            TransactionID.Width = 140;
            // 
            // ReceiverAccountName
            // 
            ReceiverAccountName.HeaderText = "Tên tài khoản người nhận";
            ReceiverAccountName.MinimumWidth = 6;
            ReceiverAccountName.Name = "ReceiverAccountName";
            ReceiverAccountName.Width = 242;
            // 
            // ReceiverAccountID
            // 
            ReceiverAccountID.HeaderText = "Tài khoản người nhận";
            ReceiverAccountID.MinimumWidth = 6;
            ReceiverAccountID.Name = "ReceiverAccountID";
            ReceiverAccountID.Width = 211;
            // 
            // Amount
            // 
            Amount.HeaderText = "Số tiền";
            Amount.MinimumWidth = 6;
            Amount.Name = "Amount";
            Amount.Width = 93;
            // 
            // TransactionDescription
            // 
            TransactionDescription.HeaderText = "Nội dung";
            TransactionDescription.MinimumWidth = 6;
            TransactionDescription.Name = "TransactionDescription";
            TransactionDescription.Width = 108;
            // 
            // TransactionDate
            // 
            TransactionDate.HeaderText = "Ngày giao dịch";
            TransactionDate.MinimumWidth = 6;
            TransactionDate.Name = "TransactionDate";
            TransactionDate.Width = 156;
            // 
            // TransactionMethod
            // 
            TransactionMethod.HeaderText = "Phương thức";
            TransactionMethod.MinimumWidth = 6;
            TransactionMethod.Name = "TransactionMethod";
            TransactionMethod.Width = 139;
            // 
            // HandledBy
            // 
            HandledBy.HeaderText = "Nhân viên xử lý";
            HandledBy.MinimumWidth = 6;
            HandledBy.Name = "HandledBy";
            HandledBy.Width = 161;
            // 
            // TransactionStatus
            // 
            TransactionStatus.HeaderText = "Trạng thái";
            TransactionStatus.MinimumWidth = 6;
            TransactionStatus.Name = "TransactionStatus";
            TransactionStatus.Width = 119;
            // 
            // labelTransactionTypeFilter
            // 
            labelTransactionTypeFilter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelTransactionTypeFilter.AutoSize = true;
            labelTransactionTypeFilter.BackColor = Color.Transparent;
            labelTransactionTypeFilter.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelTransactionTypeFilter.ForeColor = Color.Black;
            labelTransactionTypeFilter.Location = new Point(3, 58);
            labelTransactionTypeFilter.Name = "labelTransactionTypeFilter";
            labelTransactionTypeFilter.Size = new Size(109, 20);
            labelTransactionTypeFilter.TabIndex = 27;
            labelTransactionTypeFilter.Text = "Loại giao dịch";
            // 
            // labelStatusFilter
            // 
            labelStatusFilter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelStatusFilter.AutoSize = true;
            labelStatusFilter.BackColor = Color.Transparent;
            labelStatusFilter.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelStatusFilter.ForeColor = Color.Black;
            labelStatusFilter.Location = new Point(136, 58);
            labelStatusFilter.Name = "labelStatusFilter";
            labelStatusFilter.Size = new Size(82, 20);
            labelStatusFilter.TabIndex = 32;
            labelStatusFilter.Text = "Trạng thái";
            // 
            // comboBoxTransactionTypeFilter
            // 
            comboBoxTransactionTypeFilter.BackColor = SystemColors.Window;
            comboBoxTransactionTypeFilter.Dock = DockStyle.Fill;
            comboBoxTransactionTypeFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTransactionTypeFilter.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxTransactionTypeFilter.FormattingEnabled = true;
            comboBoxTransactionTypeFilter.Items.AddRange(new object[] { "Không áp dụng", "Nạp tiền", "Rút tiền", "Chuyển tiền", "Thanh toán khoản vay" });
            comboBoxTransactionTypeFilter.Location = new Point(3, 81);
            comboBoxTransactionTypeFilter.Name = "comboBoxTransactionTypeFilter";
            comboBoxTransactionTypeFilter.Size = new Size(127, 28);
            comboBoxTransactionTypeFilter.TabIndex = 28;
            comboBoxTransactionTypeFilter.SelectedIndexChanged += comboBoxTransactionTypeFilter_SelectedIndexChanged;
            // 
            // comboBoxStatusFilter
            // 
            comboBoxStatusFilter.Dock = DockStyle.Fill;
            comboBoxStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStatusFilter.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxStatusFilter.FormattingEnabled = true;
            comboBoxStatusFilter.Items.AddRange(new object[] { "Không áp dụng", "Hoàn tất", "Đang xử lý", "Thất bại" });
            comboBoxStatusFilter.Location = new Point(136, 81);
            comboBoxStatusFilter.Name = "comboBoxStatusFilter";
            comboBoxStatusFilter.Size = new Size(125, 28);
            comboBoxStatusFilter.TabIndex = 47;
            comboBoxStatusFilter.SelectedIndexChanged += comboBoxStatusFilter_SelectedIndexChanged;
            // 
            // labelTransactionFilter
            // 
            labelTransactionFilter.Anchor = AnchorStyles.Bottom;
            labelTransactionFilter.AutoSize = true;
            labelTransactionFilter.BackColor = Color.Transparent;
            tableLayoutPanel4.SetColumnSpan(labelTransactionFilter, 2);
            labelTransactionFilter.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelTransactionFilter.ForeColor = Color.Black;
            labelTransactionFilter.Location = new Point(77, 32);
            labelTransactionFilter.Name = "labelTransactionFilter";
            labelTransactionFilter.Size = new Size(109, 20);
            labelTransactionFilter.TabIndex = 26;
            labelTransactionFilter.Text = "Lọc giao dịch:";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(3, 117);
            label1.Name = "label1";
            label1.Size = new Size(28, 20);
            label1.TabIndex = 50;
            label1.Text = "Từ";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(136, 117);
            label2.Name = "label2";
            label2.Size = new Size(38, 20);
            label2.TabIndex = 51;
            label2.Text = "Đến";
            // 
            // buttonViewDetail
            // 
            buttonViewDetail.BackColor = SystemColors.ActiveCaption;
            tableLayoutPanel4.SetColumnSpan(buttonViewDetail, 2);
            buttonViewDetail.Dock = DockStyle.Fill;
            buttonViewDetail.ForeColor = Color.White;
            buttonViewDetail.Image = (Image)resources.GetObject("buttonViewDetail.Image");
            buttonViewDetail.ImageAlign = ContentAlignment.MiddleLeft;
            buttonViewDetail.Location = new Point(3, 247);
            buttonViewDetail.Name = "buttonViewDetail";
            buttonViewDetail.Size = new Size(258, 55);
            buttonViewDetail.TabIndex = 48;
            buttonViewDetail.Text = "Xem chi tiết";
            buttonViewDetail.UseVisualStyleBackColor = false;
            buttonViewDetail.Click += buttonViewDetail_Click;
            // 
            // dateTimePickerFrom
            // 
            dateTimePickerFrom.Dock = DockStyle.Fill;
            dateTimePickerFrom.Font = new Font("Roboto", 10.2F);
            dateTimePickerFrom.Format = DateTimePickerFormat.Short;
            dateTimePickerFrom.Location = new Point(3, 140);
            dateTimePickerFrom.Name = "dateTimePickerFrom";
            dateTimePickerFrom.Size = new Size(127, 28);
            dateTimePickerFrom.TabIndex = 56;
            dateTimePickerFrom.ValueChanged += dateTimePickerFrom_ValueChanged;
            // 
            // dateTimePickerTo
            // 
            dateTimePickerTo.Dock = DockStyle.Fill;
            dateTimePickerTo.Font = new Font("Roboto", 10.2F);
            dateTimePickerTo.Format = DateTimePickerFormat.Short;
            dateTimePickerTo.Location = new Point(136, 140);
            dateTimePickerTo.Name = "dateTimePickerTo";
            dateTimePickerTo.Size = new Size(125, 28);
            dateTimePickerTo.TabIndex = 57;
            dateTimePickerTo.ValueChanged += dateTimePickerTo_ValueChanged;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.HotTrack;
            panel2.Location = new Point(271, 11);
            panel2.Name = "panel2";
            panel2.Size = new Size(450, 5);
            panel2.TabIndex = 6;
            // 
            // UC_TransactionManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "UC_TransactionManagement";
            Size = new Size(1124, 695);
            tableLayoutPanel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel4.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            panel5.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            groupBox2.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTransactionManagement).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button buttonCancelService;
        private Button buttonSaveService;
        private Button buttonEditService;
        private Button buttonDeleteService;
        private Button buttonAddService;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel1;
        private Button buttonDeposit;
        private Button buttonWithdraw;
        private Button buttonTransfer;
        private Button buttonPay;
        private PictureBox pictureBox1;
        private GroupBox groupBox2;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel4;
        private TextBox textBoxTransactionSearch;
        private Button buttonTransactionSearch;
        private Label labelTransactionTypeFilter;
        private ComboBox comboBoxTransactionTypeFilter;
        private Label labelStatusFilter;
        private ComboBox comboBoxStatusFilter;
        private Label labelTransactionFilter;
        private Button buttonViewDetail;
        private DataGridView dataGridViewTransactionManagement;
        private Label label1;
        private Label label2;
        private Button buttonExportPDF;
        private Button buttonExportExcel;
        private DateTimePicker dateTimePickerFrom;
        private DateTimePicker dateTimePickerTo;
        private DataGridViewTextBoxColumn CustomerID;
        private DataGridViewTextBoxColumn AccountID;
        private DataGridViewTextBoxColumn AccountName;
        private DataGridViewTextBoxColumn TransactionTypeName;
        private DataGridViewTextBoxColumn TransactionID;
        private DataGridViewTextBoxColumn ReceiverAccountName;
        private DataGridViewTextBoxColumn ReceiverAccountID;
        private DataGridViewTextBoxColumn Amount;
        private DataGridViewTextBoxColumn TransactionDescription;
        private DataGridViewTextBoxColumn TransactionDate;
        private DataGridViewTextBoxColumn TransactionMethod;
        private DataGridViewTextBoxColumn HandledBy;
        private DataGridViewTextBoxColumn TransactionStatus;
        private Button buttonExportCSV;
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
