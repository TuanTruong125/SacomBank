namespace QuanLyThongTinKhachHangSacomBank.Views.Common.Withdraw
{
    partial class UC_SuccessfulWithdraw
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_SuccessfulWithdraw));
            buttonDone = new Button();
            labelTransactionDescription = new Label();
            labelEmployeeName = new Label();
            labelTransactionDate = new Label();
            labelAccountBalance = new Label();
            labelCustomerName = new Label();
            labelCustomerAmount = new Label();
            labelCustomerAccountID = new Label();
            labelDescription = new Label();
            labelHandledBy = new Label();
            labelWithdrawDate = new Label();
            labelBalance = new Label();
            labelCustomer = new Label();
            panelDepositInform = new Panel();
            pictureBoxSuccessfulWithdraw = new PictureBox();
            labelAccountID = new Label();
            buttonInvoice = new Button();
            labelWithdrawInform = new Label();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSuccessfulWithdraw).BeginInit();
            SuspendLayout();
            // 
            // buttonDone
            // 
            buttonDone.BackColor = SystemColors.HotTrack;
            buttonDone.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 192, 0);
            buttonDone.FlatAppearance.MouseOverBackColor = Color.LimeGreen;
            buttonDone.Font = new Font("Roboto SemiCondensed Medium", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonDone.ForeColor = Color.Transparent;
            buttonDone.Location = new Point(172, 453);
            buttonDone.Name = "buttonDone";
            buttonDone.Size = new Size(165, 62);
            buttonDone.TabIndex = 103;
            buttonDone.Text = "Hoàn tất";
            buttonDone.UseVisualStyleBackColor = false;
            // 
            // labelTransactionDescription
            // 
            labelTransactionDescription.FlatStyle = FlatStyle.Flat;
            labelTransactionDescription.Font = new Font("Roboto", 10.2F);
            labelTransactionDescription.Location = new Point(3, 417);
            labelTransactionDescription.Name = "labelTransactionDescription";
            labelTransactionDescription.Size = new Size(685, 20);
            labelTransactionDescription.TabIndex = 102;
            labelTransactionDescription.Text = "Rút tiền từ ngân hàng";
            labelTransactionDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelEmployeeName
            // 
            labelEmployeeName.AutoSize = true;
            labelEmployeeName.FlatStyle = FlatStyle.Flat;
            labelEmployeeName.Font = new Font("Roboto", 10.2F);
            labelEmployeeName.Location = new Point(372, 349);
            labelEmployeeName.Name = "labelEmployeeName";
            labelEmployeeName.Size = new Size(82, 20);
            labelEmployeeName.TabIndex = 101;
            labelEmployeeName.Text = "Nhân viên";
            // 
            // labelTransactionDate
            // 
            labelTransactionDate.AutoSize = true;
            labelTransactionDate.FlatStyle = FlatStyle.Flat;
            labelTransactionDate.Font = new Font("Roboto", 10.2F);
            labelTransactionDate.Location = new Point(372, 314);
            labelTransactionDate.Name = "labelTransactionDate";
            labelTransactionDate.Size = new Size(78, 20);
            labelTransactionDate.TabIndex = 100;
            labelTransactionDate.Text = "Thời gian";
            // 
            // labelAccountBalance
            // 
            labelAccountBalance.AutoSize = true;
            labelAccountBalance.FlatStyle = FlatStyle.Flat;
            labelAccountBalance.Font = new Font("Roboto", 10.2F);
            labelAccountBalance.Location = new Point(372, 250);
            labelAccountBalance.Name = "labelAccountBalance";
            labelAccountBalance.Size = new Size(54, 20);
            labelAccountBalance.TabIndex = 99;
            labelAccountBalance.Text = "Số dư";
            // 
            // labelCustomerName
            // 
            labelCustomerName.AutoSize = true;
            labelCustomerName.FlatStyle = FlatStyle.Flat;
            labelCustomerName.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCustomerName.Location = new Point(372, 181);
            labelCustomerName.Name = "labelCustomerName";
            labelCustomerName.Size = new Size(114, 20);
            labelCustomerName.TabIndex = 98;
            labelCustomerName.Text = "Nguyễn Văn A";
            // 
            // labelCustomerAmount
            // 
            labelCustomerAmount.FlatStyle = FlatStyle.Flat;
            labelCustomerAmount.Font = new Font("Roboto SemiCondensed Medium", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCustomerAmount.ForeColor = SystemColors.HotTrack;
            labelCustomerAmount.Location = new Point(3, 117);
            labelCustomerAmount.Name = "labelCustomerAmount";
            labelCustomerAmount.Size = new Size(685, 38);
            labelCustomerAmount.TabIndex = 97;
            labelCustomerAmount.Text = "0 đ";
            labelCustomerAmount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelCustomerAccountID
            // 
            labelCustomerAccountID.AutoSize = true;
            labelCustomerAccountID.FlatStyle = FlatStyle.Flat;
            labelCustomerAccountID.Font = new Font("Roboto", 10.2F);
            labelCustomerAccountID.Location = new Point(372, 218);
            labelCustomerAccountID.Name = "labelCustomerAccountID";
            labelCustomerAccountID.Size = new Size(106, 20);
            labelCustomerAccountID.TabIndex = 96;
            labelCustomerAccountID.Text = "Mã tài khoản";
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.FlatStyle = FlatStyle.Flat;
            labelDescription.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelDescription.Location = new Point(316, 386);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(73, 20);
            labelDescription.TabIndex = 95;
            labelDescription.Text = "Nội dung";
            // 
            // labelHandledBy
            // 
            labelHandledBy.AutoSize = true;
            labelHandledBy.FlatStyle = FlatStyle.Flat;
            labelHandledBy.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelHandledBy.Location = new Point(39, 349);
            labelHandledBy.Name = "labelHandledBy";
            labelHandledBy.Size = new Size(81, 20);
            labelHandledBy.TabIndex = 94;
            labelHandledBy.Text = "Nhân viên";
            // 
            // labelWithdrawDate
            // 
            labelWithdrawDate.AutoSize = true;
            labelWithdrawDate.FlatStyle = FlatStyle.Flat;
            labelWithdrawDate.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelWithdrawDate.Location = new Point(39, 314);
            labelWithdrawDate.Name = "labelWithdrawDate";
            labelWithdrawDate.Size = new Size(76, 20);
            labelWithdrawDate.TabIndex = 93;
            labelWithdrawDate.Text = "Thời gian";
            // 
            // labelBalance
            // 
            labelBalance.AutoSize = true;
            labelBalance.FlatStyle = FlatStyle.Flat;
            labelBalance.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelBalance.Location = new Point(39, 250);
            labelBalance.Name = "labelBalance";
            labelBalance.Size = new Size(51, 20);
            labelBalance.TabIndex = 92;
            labelBalance.Text = "Số dư";
            // 
            // labelCustomer
            // 
            labelCustomer.AutoSize = true;
            labelCustomer.FlatStyle = FlatStyle.Flat;
            labelCustomer.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelCustomer.Location = new Point(39, 181);
            labelCustomer.Name = "labelCustomer";
            labelCustomer.Size = new Size(94, 20);
            labelCustomer.TabIndex = 91;
            labelCustomer.Text = "Khách hàng";
            // 
            // panelDepositInform
            // 
            panelDepositInform.BackColor = Color.Black;
            panelDepositInform.Location = new Point(66, 162);
            panelDepositInform.Name = "panelDepositInform";
            panelDepositInform.Size = new Size(500, 3);
            panelDepositInform.TabIndex = 90;
            // 
            // pictureBoxSuccessfulWithdraw
            // 
            pictureBoxSuccessfulWithdraw.Image = (Image)resources.GetObject("pictureBoxSuccessfulWithdraw.Image");
            pictureBoxSuccessfulWithdraw.Location = new Point(313, 5);
            pictureBoxSuccessfulWithdraw.Name = "pictureBoxSuccessfulWithdraw";
            pictureBoxSuccessfulWithdraw.Size = new Size(70, 70);
            pictureBoxSuccessfulWithdraw.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxSuccessfulWithdraw.TabIndex = 89;
            pictureBoxSuccessfulWithdraw.TabStop = false;
            // 
            // labelAccountID
            // 
            labelAccountID.AutoSize = true;
            labelAccountID.FlatStyle = FlatStyle.Flat;
            labelAccountID.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold);
            labelAccountID.Location = new Point(39, 218);
            labelAccountID.Name = "labelAccountID";
            labelAccountID.Size = new Size(103, 20);
            labelAccountID.TabIndex = 87;
            labelAccountID.Text = "Mã tài khoản";
            // 
            // buttonInvoice
            // 
            buttonInvoice.BackColor = SystemColors.HotTrack;
            buttonInvoice.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 192, 0);
            buttonInvoice.FlatAppearance.MouseOverBackColor = Color.LimeGreen;
            buttonInvoice.Font = new Font("Roboto SemiCondensed Medium", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonInvoice.ForeColor = Color.Transparent;
            buttonInvoice.Location = new Point(343, 453);
            buttonInvoice.Name = "buttonInvoice";
            buttonInvoice.Size = new Size(165, 62);
            buttonInvoice.TabIndex = 86;
            buttonInvoice.Text = "Xuất hóa đơn";
            buttonInvoice.UseVisualStyleBackColor = false;
            // 
            // labelWithdrawInform
            // 
            labelWithdrawInform.Font = new Font("Roboto SemiCondensed Medium", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelWithdrawInform.ForeColor = Color.LimeGreen;
            labelWithdrawInform.Location = new Point(3, 78);
            labelWithdrawInform.Name = "labelWithdrawInform";
            labelWithdrawInform.Size = new Size(685, 28);
            labelWithdrawInform.TabIndex = 85;
            labelWithdrawInform.Text = "Rút tiền thành công!";
            labelWithdrawInform.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.Location = new Point(66, 291);
            panel2.Name = "panel2";
            panel2.Size = new Size(500, 3);
            panel2.TabIndex = 136;
            // 
            // UC_SuccessfulWithdraw
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
            Controls.Add(labelWithdrawDate);
            Controls.Add(labelBalance);
            Controls.Add(labelCustomer);
            Controls.Add(panelDepositInform);
            Controls.Add(pictureBoxSuccessfulWithdraw);
            Controls.Add(labelAccountID);
            Controls.Add(buttonInvoice);
            Controls.Add(labelWithdrawInform);
            Name = "UC_SuccessfulWithdraw";
            Size = new Size(691, 520);
            ((System.ComponentModel.ISupportInitialize)pictureBoxSuccessfulWithdraw).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonDone;
        private Label labelTransactionDescription;
        private Label labelEmployeeName;
        private Label labelTransactionDate;
        private Label labelAccountBalance;
        private Label labelCustomerName;
        private Label labelCustomerAmount;
        private Label labelCustomerAccountID;
        private Label labelDescription;
        private Label labelHandledBy;
        private Label labelWithdrawDate;
        private Label labelBalance;
        private Label labelCustomer;
        private Panel panelDepositInform;
        private PictureBox pictureBoxSuccessfulWithdraw;
        private Label labelAccountID;
        private Button buttonInvoice;
        private Label labelWithdrawInform;
        private Panel panel2;
    }
}
