namespace QuanLyThongTinKhachHangSacomBank.Views.Common.Deposit
{
    partial class UC_SuccessfulDeposit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_SuccessfulDeposit));
            labelAccountID = new Label();
            buttonInvoice = new Button();
            labelDepositInform = new Label();
            pictureBoxSuccessfulDeposit = new PictureBox();
            panelDepositInform = new Panel();
            labelCustomer = new Label();
            labelBalance = new Label();
            labelDepositDate = new Label();
            labelHandledBy = new Label();
            labelDescription = new Label();
            labelTransactionDescription = new Label();
            labelEmployeeName = new Label();
            labelTransactionDate = new Label();
            labelAccountBalance = new Label();
            labelCustomerName = new Label();
            labelCustomerAmount = new Label();
            labelCustomerAccountID = new Label();
            buttonDone = new Button();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSuccessfulDeposit).BeginInit();
            SuspendLayout();
            // 
            // labelAccountID
            // 
            labelAccountID.AutoSize = true;
            labelAccountID.FlatStyle = FlatStyle.Flat;
            labelAccountID.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelAccountID.Location = new Point(63, 208);
            labelAccountID.Name = "labelAccountID";
            labelAccountID.Size = new Size(103, 20);
            labelAccountID.TabIndex = 62;
            labelAccountID.Text = "Mã tài khoản";
            // 
            // buttonInvoice
            // 
            buttonInvoice.BackColor = SystemColors.HotTrack;
            buttonInvoice.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 192, 0);
            buttonInvoice.FlatAppearance.MouseOverBackColor = Color.LimeGreen;
            buttonInvoice.Font = new Font("Roboto SemiCondensed Medium", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonInvoice.ForeColor = Color.Transparent;
            buttonInvoice.Location = new Point(350, 448);
            buttonInvoice.Name = "buttonInvoice";
            buttonInvoice.Size = new Size(165, 62);
            buttonInvoice.TabIndex = 61;
            buttonInvoice.Text = "Xuất hóa đơn";
            buttonInvoice.UseVisualStyleBackColor = false;
            // 
            // labelDepositInform
            // 
            labelDepositInform.AutoSize = true;
            labelDepositInform.Font = new Font("Roboto SemiCondensed Medium", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDepositInform.ForeColor = Color.LimeGreen;
            labelDepositInform.Location = new Point(229, 76);
            labelDepositInform.Name = "labelDepositInform";
            labelDepositInform.Size = new Size(234, 28);
            labelDepositInform.TabIndex = 60;
            labelDepositInform.Text = "Nạp tiền thành công!";
            // 
            // pictureBoxSuccessfulDeposit
            // 
            pictureBoxSuccessfulDeposit.Image = (Image)resources.GetObject("pictureBoxSuccessfulDeposit.Image");
            pictureBoxSuccessfulDeposit.Location = new Point(307, 3);
            pictureBoxSuccessfulDeposit.Name = "pictureBoxSuccessfulDeposit";
            pictureBoxSuccessfulDeposit.Size = new Size(70, 70);
            pictureBoxSuccessfulDeposit.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxSuccessfulDeposit.TabIndex = 70;
            pictureBoxSuccessfulDeposit.TabStop = false;
            // 
            // panelDepositInform
            // 
            panelDepositInform.BackColor = Color.Black;
            panelDepositInform.Location = new Point(90, 156);
            panelDepositInform.Name = "panelDepositInform";
            panelDepositInform.Size = new Size(500, 3);
            panelDepositInform.TabIndex = 71;
            // 
            // labelCustomer
            // 
            labelCustomer.AutoSize = true;
            labelCustomer.FlatStyle = FlatStyle.Flat;
            labelCustomer.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelCustomer.Location = new Point(63, 171);
            labelCustomer.Name = "labelCustomer";
            labelCustomer.Size = new Size(94, 20);
            labelCustomer.TabIndex = 72;
            labelCustomer.Text = "Khách hàng";
            // 
            // labelBalance
            // 
            labelBalance.AutoSize = true;
            labelBalance.FlatStyle = FlatStyle.Flat;
            labelBalance.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelBalance.Location = new Point(63, 240);
            labelBalance.Name = "labelBalance";
            labelBalance.Size = new Size(51, 20);
            labelBalance.TabIndex = 73;
            labelBalance.Text = "Số dư";
            // 
            // labelDepositDate
            // 
            labelDepositDate.AutoSize = true;
            labelDepositDate.FlatStyle = FlatStyle.Flat;
            labelDepositDate.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelDepositDate.Location = new Point(63, 306);
            labelDepositDate.Name = "labelDepositDate";
            labelDepositDate.Size = new Size(76, 20);
            labelDepositDate.TabIndex = 74;
            labelDepositDate.Text = "Thời gian";
            // 
            // labelHandledBy
            // 
            labelHandledBy.AutoSize = true;
            labelHandledBy.FlatStyle = FlatStyle.Flat;
            labelHandledBy.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelHandledBy.Location = new Point(63, 339);
            labelHandledBy.Name = "labelHandledBy";
            labelHandledBy.Size = new Size(81, 20);
            labelHandledBy.TabIndex = 75;
            labelHandledBy.Text = "Nhân viên";
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.FlatStyle = FlatStyle.Flat;
            labelDescription.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelDescription.Location = new Point(313, 374);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(73, 20);
            labelDescription.TabIndex = 76;
            labelDescription.Text = "Nội dung";
            // 
            // labelTransactionDescription
            // 
            labelTransactionDescription.FlatStyle = FlatStyle.Flat;
            labelTransactionDescription.Font = new Font("Roboto", 10.2F);
            labelTransactionDescription.Location = new Point(3, 403);
            labelTransactionDescription.Name = "labelTransactionDescription";
            labelTransactionDescription.Size = new Size(685, 20);
            labelTransactionDescription.TabIndex = 83;
            labelTransactionDescription.Text = "Nạp tiền từ ngân hàng";
            labelTransactionDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelEmployeeName
            // 
            labelEmployeeName.AutoSize = true;
            labelEmployeeName.FlatStyle = FlatStyle.Flat;
            labelEmployeeName.Font = new Font("Roboto", 10.2F);
            labelEmployeeName.Location = new Point(467, 339);
            labelEmployeeName.Name = "labelEmployeeName";
            labelEmployeeName.Size = new Size(82, 20);
            labelEmployeeName.TabIndex = 82;
            labelEmployeeName.Text = "Nhân viên";
            // 
            // labelTransactionDate
            // 
            labelTransactionDate.AutoSize = true;
            labelTransactionDate.FlatStyle = FlatStyle.Flat;
            labelTransactionDate.Font = new Font("Roboto", 10.2F);
            labelTransactionDate.Location = new Point(467, 306);
            labelTransactionDate.Name = "labelTransactionDate";
            labelTransactionDate.Size = new Size(78, 20);
            labelTransactionDate.TabIndex = 81;
            labelTransactionDate.Text = "Thời gian";
            // 
            // labelAccountBalance
            // 
            labelAccountBalance.AutoSize = true;
            labelAccountBalance.FlatStyle = FlatStyle.Flat;
            labelAccountBalance.Font = new Font("Roboto", 10.2F);
            labelAccountBalance.Location = new Point(467, 240);
            labelAccountBalance.Name = "labelAccountBalance";
            labelAccountBalance.Size = new Size(54, 20);
            labelAccountBalance.TabIndex = 80;
            labelAccountBalance.Text = "Số dư";
            // 
            // labelCustomerName
            // 
            labelCustomerName.AutoSize = true;
            labelCustomerName.FlatStyle = FlatStyle.Flat;
            labelCustomerName.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCustomerName.Location = new Point(467, 171);
            labelCustomerName.Name = "labelCustomerName";
            labelCustomerName.Size = new Size(114, 20);
            labelCustomerName.TabIndex = 79;
            labelCustomerName.Text = "Nguyễn Văn A";
            // 
            // labelCustomerAmount
            // 
            labelCustomerAmount.FlatStyle = FlatStyle.Flat;
            labelCustomerAmount.Font = new Font("Roboto SemiCondensed Medium", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCustomerAmount.ForeColor = SystemColors.HotTrack;
            labelCustomerAmount.Location = new Point(3, 113);
            labelCustomerAmount.Name = "labelCustomerAmount";
            labelCustomerAmount.Size = new Size(685, 29);
            labelCustomerAmount.TabIndex = 78;
            labelCustomerAmount.Text = "0 đ";
            labelCustomerAmount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelCustomerAccountID
            // 
            labelCustomerAccountID.AutoSize = true;
            labelCustomerAccountID.FlatStyle = FlatStyle.Flat;
            labelCustomerAccountID.Font = new Font("Roboto", 10.2F);
            labelCustomerAccountID.Location = new Point(467, 208);
            labelCustomerAccountID.Name = "labelCustomerAccountID";
            labelCustomerAccountID.Size = new Size(106, 20);
            labelCustomerAccountID.TabIndex = 77;
            labelCustomerAccountID.Text = "Mã tài khoản";
            // 
            // buttonDone
            // 
            buttonDone.BackColor = SystemColors.HotTrack;
            buttonDone.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 192, 0);
            buttonDone.FlatAppearance.MouseOverBackColor = Color.LimeGreen;
            buttonDone.Font = new Font("Roboto SemiCondensed Medium", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonDone.ForeColor = Color.Transparent;
            buttonDone.Location = new Point(179, 448);
            buttonDone.Name = "buttonDone";
            buttonDone.Size = new Size(165, 62);
            buttonDone.TabIndex = 84;
            buttonDone.Text = "Hoàn tất";
            buttonDone.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.Location = new Point(90, 283);
            panel2.Name = "panel2";
            panel2.Size = new Size(500, 3);
            panel2.TabIndex = 136;
            // 
            // UC_SuccessfulDeposit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(buttonDone);
            Controls.Add(labelTransactionDescription);
            Controls.Add(labelEmployeeName);
            Controls.Add(labelTransactionDate);
            Controls.Add(labelAccountBalance);
            Controls.Add(labelCustomerName);
            Controls.Add(labelCustomerAmount);
            Controls.Add(labelCustomerAccountID);
            Controls.Add(labelDescription);
            Controls.Add(labelHandledBy);
            Controls.Add(labelDepositDate);
            Controls.Add(labelBalance);
            Controls.Add(labelCustomer);
            Controls.Add(panelDepositInform);
            Controls.Add(pictureBoxSuccessfulDeposit);
            Controls.Add(labelAccountID);
            Controls.Add(buttonInvoice);
            Controls.Add(labelDepositInform);
            Name = "UC_SuccessfulDeposit";
            Size = new Size(691, 520);
            Load += UC_SuccessfullDeposit_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxSuccessfulDeposit).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelAccountID;
        private Button buttonInvoice;
        private Label labelDepositInform;
        private PictureBox pictureBoxSuccessfulDeposit;
        private Panel panelDepositInform;
        private Label labelCustomer;
        private Label labelBalance;
        private Label labelDepositDate;
        private Label labelHandledBy;
        private Label labelDescription;
        private Label labelTransactionDescription;
        private Label labelEmployeeName;
        private Label labelTransactionDate;
        private Label labelAccountBalance;
        private Label labelCustomerName;
        private Label labelCustomerAmount;
        private Label labelCustomerAccountID;
        private Button buttonDone;
        private Panel panel2;
    }
}
