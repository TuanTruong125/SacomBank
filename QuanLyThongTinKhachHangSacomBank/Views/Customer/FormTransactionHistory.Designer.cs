namespace QuanLyThongTinKhachHangSacomBank.Views.Customer
{
    partial class FormTransactionHistory
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTransactionHistory));
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            panel1 = new Panel();
            label1 = new Label();
            dataGridViewTransactionHistory = new DataGridView();
            TransactionID = new DataGridViewTextBoxColumn();
            TransactionTypeID = new DataGridViewTextBoxColumn();
            ServiceID = new DataGridViewTextBoxColumn();
            Amount = new DataGridViewTextBoxColumn();
            TransactionDate = new DataGridViewTextBoxColumn();
            Description = new DataGridViewTextBoxColumn();
            AccountName = new DataGridViewTextBoxColumn();
            groupBox1 = new GroupBox();
            groupBox3 = new GroupBox();
            comboBoxTransactionTypeFilter = new ComboBox();
            groupBox2 = new GroupBox();
            dateTimePickerTo = new DateTimePicker();
            label3 = new Label();
            dateTimePickerFrom = new DateTimePicker();
            label2 = new Label();
            groupBox4 = new GroupBox();
            buttonExportExcel = new Button();
            buttonExportCSV = new Button();
            buttonExportPDF = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTransactionHistory).BeginInit();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-2, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(951, 78);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.HotTrack;
            panel2.Location = new Point(165, 95);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 5);
            panel2.TabIndex = 17;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.HotTrack;
            panel1.Location = new Point(589, 95);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 5);
            panel1.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Roboto SemiCondensed", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(390, 82);
            label1.Name = "label1";
            label1.Size = new Size(178, 28);
            label1.TabIndex = 15;
            label1.Text = "Lịch sử giao dịch";
            // 
            // dataGridViewTransactionHistory
            // 
            dataGridViewTransactionHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewTransactionHistory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewTransactionHistory.BackgroundColor = Color.White;
            dataGridViewTransactionHistory.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewTransactionHistory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle2.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewTransactionHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewTransactionHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTransactionHistory.Columns.AddRange(new DataGridViewColumn[] { TransactionID, TransactionTypeID, ServiceID, Amount, TransactionDate, Description, AccountName });
            dataGridViewTransactionHistory.EnableHeadersVisualStyles = false;
            dataGridViewTransactionHistory.GridColor = Color.White;
            dataGridViewTransactionHistory.Location = new Point(12, 298);
            dataGridViewTransactionHistory.Name = "dataGridViewTransactionHistory";
            dataGridViewTransactionHistory.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewTransactionHistory.RowHeadersVisible = false;
            dataGridViewTransactionHistory.RowHeadersWidth = 51;
            dataGridViewTransactionHistory.Size = new Size(925, 302);
            dataGridViewTransactionHistory.TabIndex = 19;
            // 
            // TransactionID
            // 
            TransactionID.HeaderText = "Mã giao dịch";
            TransactionID.MinimumWidth = 6;
            TransactionID.Name = "TransactionID";
            // 
            // TransactionTypeID
            // 
            TransactionTypeID.HeaderText = "Loại giao dịch";
            TransactionTypeID.MinimumWidth = 6;
            TransactionTypeID.Name = "TransactionTypeID";
            // 
            // ServiceID
            // 
            ServiceID.HeaderText = "Mã dịch vụ";
            ServiceID.MinimumWidth = 6;
            ServiceID.Name = "ServiceID";
            // 
            // Amount
            // 
            Amount.HeaderText = "Số tiền";
            Amount.MinimumWidth = 6;
            Amount.Name = "Amount";
            // 
            // TransactionDate
            // 
            TransactionDate.HeaderText = "Ngày giao dịch";
            TransactionDate.MinimumWidth = 6;
            TransactionDate.Name = "TransactionDate";
            // 
            // Description
            // 
            Description.HeaderText = "Nội dung";
            Description.MinimumWidth = 6;
            Description.Name = "Description";
            // 
            // AccountName
            // 
            AccountName.HeaderText = "Tên tài khoản";
            AccountName.MinimumWidth = 6;
            AccountName.Name = "AccountName";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Font = new Font("Roboto SemiCondensed Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(26, 124);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(561, 168);
            groupBox1.TabIndex = 20;
            groupBox1.TabStop = false;
            groupBox1.Text = "Lọc theo";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(comboBoxTransactionTypeFilter);
            groupBox3.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            groupBox3.Location = new Point(334, 33);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(221, 129);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "Loại giao dịch";
            // 
            // comboBoxTransactionTypeFilter
            // 
            comboBoxTransactionTypeFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTransactionTypeFilter.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxTransactionTypeFilter.FormattingEnabled = true;
            comboBoxTransactionTypeFilter.Items.AddRange(new object[] { "Không áp dụng", "Nạp tiền", "Rút tiền", "Chuyển tiền", "Thanh toán" });
            comboBoxTransactionTypeFilter.Location = new Point(6, 56);
            comboBoxTransactionTypeFilter.Name = "comboBoxTransactionTypeFilter";
            comboBoxTransactionTypeFilter.Size = new Size(209, 28);
            comboBoxTransactionTypeFilter.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dateTimePickerTo);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(dateTimePickerFrom);
            groupBox2.Controls.Add(label2);
            groupBox2.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold);
            groupBox2.Location = new Point(6, 33);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(322, 129);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Ngày";
            // 
            // dateTimePickerTo
            // 
            dateTimePickerTo.Location = new Point(58, 79);
            dateTimePickerTo.Name = "dateTimePickerTo";
            dateTimePickerTo.Size = new Size(245, 28);
            dateTimePickerTo.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 87);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 2;
            label3.Text = "Đến:";
            // 
            // dateTimePickerFrom
            // 
            dateTimePickerFrom.Location = new Point(58, 35);
            dateTimePickerFrom.Name = "dateTimePickerFrom";
            dateTimePickerFrom.Size = new Size(245, 28);
            dateTimePickerFrom.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 41);
            label2.Name = "label2";
            label2.Size = new Size(35, 20);
            label2.TabIndex = 0;
            label2.Text = "Từ:";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(buttonExportExcel);
            groupBox4.Controls.Add(buttonExportCSV);
            groupBox4.Controls.Add(buttonExportPDF);
            groupBox4.Font = new Font("Roboto SemiCondensed Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox4.Location = new Point(593, 124);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(324, 168);
            groupBox4.TabIndex = 21;
            groupBox4.TabStop = false;
            groupBox4.Text = "Xuất dữ liệu";
            // 
            // buttonExportExcel
            // 
            buttonExportExcel.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonExportExcel.ForeColor = Color.FromArgb(20, 169, 6);
            buttonExportExcel.Image = (Image)resources.GetObject("buttonExportExcel.Image");
            buttonExportExcel.Location = new Point(113, 65);
            buttonExportExcel.Name = "buttonExportExcel";
            buttonExportExcel.Size = new Size(98, 52);
            buttonExportExcel.TabIndex = 2;
            buttonExportExcel.Text = "Excel";
            buttonExportExcel.TextAlign = ContentAlignment.MiddleLeft;
            buttonExportExcel.TextImageRelation = TextImageRelation.TextBeforeImage;
            buttonExportExcel.UseVisualStyleBackColor = true;
            // 
            // buttonExportCSV
            // 
            buttonExportCSV.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonExportCSV.ForeColor = Color.FromArgb(25, 137, 14);
            buttonExportCSV.Image = (Image)resources.GetObject("buttonExportCSV.Image");
            buttonExportCSV.Location = new Point(217, 65);
            buttonExportCSV.Name = "buttonExportCSV";
            buttonExportCSV.Size = new Size(98, 52);
            buttonExportCSV.TabIndex = 1;
            buttonExportCSV.Text = "CSV";
            buttonExportCSV.TextAlign = ContentAlignment.MiddleLeft;
            buttonExportCSV.TextImageRelation = TextImageRelation.TextBeforeImage;
            buttonExportCSV.UseVisualStyleBackColor = true;
            // 
            // buttonExportPDF
            // 
            buttonExportPDF.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonExportPDF.ForeColor = Color.FromArgb(207, 0, 0);
            buttonExportPDF.Image = (Image)resources.GetObject("buttonExportPDF.Image");
            buttonExportPDF.Location = new Point(9, 65);
            buttonExportPDF.Name = "buttonExportPDF";
            buttonExportPDF.Size = new Size(98, 52);
            buttonExportPDF.TabIndex = 0;
            buttonExportPDF.Text = "PDF";
            buttonExportPDF.TextAlign = ContentAlignment.MiddleLeft;
            buttonExportPDF.TextImageRelation = TextImageRelation.TextBeforeImage;
            buttonExportPDF.UseVisualStyleBackColor = true;
            // 
            // FormTransactionHistory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(949, 612);
            Controls.Add(groupBox4);
            Controls.Add(groupBox1);
            Controls.Add(dataGridViewTransactionHistory);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormTransactionHistory";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lịch sử giao dịch";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTransactionHistory).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox4.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Panel panel2;
        private Panel panel1;
        private Label label1;
        private DataGridView dataGridViewTransactionHistory;
        private DataGridViewTextBoxColumn TransactionID;
        private DataGridViewTextBoxColumn TransactionTypeID;
        private DataGridViewTextBoxColumn ServiceID;
        private DataGridViewTextBoxColumn Amount;
        private DataGridViewTextBoxColumn TransactionDate;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn AccountName;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private GroupBox groupBox2;
        private DateTimePicker dateTimePickerTo;
        private Label label3;
        private DateTimePicker dateTimePickerFrom;
        private Label label2;
        private ComboBox comboBoxTransactionTypeFilter;
        private GroupBox groupBox4;
        private Button buttonExportPDF;
        private Button buttonExportExcel;
        private Button buttonExportCSV;
    }
}