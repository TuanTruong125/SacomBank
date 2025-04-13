namespace QuanLyThongTinKhachHangSacomBank.Views.Common.Deposit
{
    partial class UC_DepositInfo
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
            labelAmount = new Label();
            buttonCancel = new Button();
            textBoxAmount = new TextBox();
            labelCitizenID = new Label();
            textBoxCitizenID = new TextBox();
            labelPhone = new Label();
            textBoxPhone = new TextBox();
            labelAccountID = new Label();
            buttonConfirm = new Button();
            labelDepositInfo = new Label();
            textBoxAccountID = new TextBox();
            labelDeposit = new Label();
            labelError = new Label();
            labelDescription = new Label();
            textBoxTransactionDescription = new TextBox();
            labelBalance = new Label();
            textBoxBalance = new TextBox();
            panel1 = new Panel();
            labelCustomer = new Label();
            textBoxAccountName = new TextBox();
            SuspendLayout();
            // 
            // labelAmount
            // 
            labelAmount.AutoSize = true;
            labelAmount.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAmount.Location = new Point(63, 342);
            labelAmount.Name = "labelAmount";
            labelAmount.Size = new Size(70, 24);
            labelAmount.TabIndex = 68;
            labelAmount.Text = "Số tiền";
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.IndianRed;
            buttonCancel.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 192, 0);
            buttonCancel.FlatAppearance.MouseOverBackColor = Color.LimeGreen;
            buttonCancel.Font = new Font("Roboto SemiCondensed Medium", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonCancel.ForeColor = Color.Transparent;
            buttonCancel.Location = new Point(175, 448);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(165, 62);
            buttonCancel.TabIndex = 69;
            buttonCancel.Text = "Hủy bỏ";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // textBoxAmount
            // 
            textBoxAmount.Font = new Font("Roboto", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxAmount.Location = new Point(211, 336);
            textBoxAmount.Name = "textBoxAmount";
            textBoxAmount.Size = new Size(417, 35);
            textBoxAmount.TabIndex = 67;
            // 
            // labelCitizenID
            // 
            labelCitizenID.AutoSize = true;
            labelCitizenID.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCitizenID.Location = new Point(63, 225);
            labelCitizenID.Name = "labelCitizenID";
            labelCitizenID.Size = new Size(142, 24);
            labelCitizenID.TabIndex = 66;
            labelCitizenID.Text = "CCCD/Passport";
            // 
            // textBoxCitizenID
            // 
            textBoxCitizenID.Font = new Font("Roboto", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxCitizenID.Location = new Point(211, 219);
            textBoxCitizenID.Name = "textBoxCitizenID";
            textBoxCitizenID.Size = new Size(417, 35);
            textBoxCitizenID.TabIndex = 65;
            // 
            // labelPhone
            // 
            labelPhone.AutoSize = true;
            labelPhone.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPhone.Location = new Point(63, 184);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(45, 24);
            labelPhone.TabIndex = 64;
            labelPhone.Text = "SĐT";
            // 
            // textBoxPhone
            // 
            textBoxPhone.Font = new Font("Roboto", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxPhone.Location = new Point(211, 178);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(417, 35);
            textBoxPhone.TabIndex = 63;
            // 
            // labelAccountID
            // 
            labelAccountID.AutoSize = true;
            labelAccountID.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAccountID.Location = new Point(63, 143);
            labelAccountID.Name = "labelAccountID";
            labelAccountID.Size = new Size(120, 24);
            labelAccountID.TabIndex = 62;
            labelAccountID.Text = "Mã tài khoản";
            // 
            // buttonConfirm
            // 
            buttonConfirm.BackColor = Color.LimeGreen;
            buttonConfirm.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 192, 0);
            buttonConfirm.FlatAppearance.MouseOverBackColor = Color.LimeGreen;
            buttonConfirm.Font = new Font("Roboto SemiCondensed Medium", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonConfirm.ForeColor = Color.Transparent;
            buttonConfirm.Location = new Point(346, 448);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Size = new Size(165, 62);
            buttonConfirm.TabIndex = 61;
            buttonConfirm.Text = "Xác nhận";
            buttonConfirm.UseVisualStyleBackColor = false;
            buttonConfirm.Click += buttonConfirm_Click;
            // 
            // labelDepositInfo
            // 
            labelDepositInfo.AutoSize = true;
            labelDepositInfo.Font = new Font("Roboto SemiCondensed Medium", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDepositInfo.Location = new Point(259, 56);
            labelDepositInfo.Name = "labelDepositInfo";
            labelDepositInfo.Size = new Size(169, 28);
            labelDepositInfo.TabIndex = 60;
            labelDepositInfo.Text = "Nhập thông tin";
            // 
            // textBoxAccountID
            // 
            textBoxAccountID.Font = new Font("Roboto", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxAccountID.Location = new Point(211, 137);
            textBoxAccountID.Name = "textBoxAccountID";
            textBoxAccountID.Size = new Size(417, 35);
            textBoxAccountID.TabIndex = 59;
            // 
            // labelDeposit
            // 
            labelDeposit.AutoSize = true;
            labelDeposit.Font = new Font("Roboto SemiCondensed", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDeposit.ForeColor = Color.LimeGreen;
            labelDeposit.Location = new Point(279, 15);
            labelDeposit.Name = "labelDeposit";
            labelDeposit.Size = new Size(138, 41);
            labelDeposit.TabIndex = 58;
            labelDeposit.Text = "Nạp tiền";
            // 
            // labelError
            // 
            labelError.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelError.ForeColor = Color.Red;
            labelError.Location = new Point(3, 422);
            labelError.Name = "labelError";
            labelError.Size = new Size(685, 20);
            labelError.TabIndex = 70;
            labelError.Text = "Vui lòng nhập đầy đủ thông tin!";
            labelError.TextAlign = ContentAlignment.MiddleCenter;
            labelError.Visible = false;
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDescription.Location = new Point(63, 383);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(88, 24);
            labelDescription.TabIndex = 72;
            labelDescription.Text = "Nội dung";
            // 
            // textBoxTransactionDescription
            // 
            textBoxTransactionDescription.Font = new Font("Roboto", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxTransactionDescription.Location = new Point(211, 377);
            textBoxTransactionDescription.Name = "textBoxTransactionDescription";
            textBoxTransactionDescription.Size = new Size(417, 35);
            textBoxTransactionDescription.TabIndex = 71;
            // 
            // labelBalance
            // 
            labelBalance.AutoSize = true;
            labelBalance.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelBalance.Location = new Point(63, 266);
            labelBalance.Name = "labelBalance";
            labelBalance.Size = new Size(60, 24);
            labelBalance.TabIndex = 74;
            labelBalance.Text = "Số dư";
            // 
            // textBoxBalance
            // 
            textBoxBalance.Font = new Font("Roboto", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxBalance.Location = new Point(211, 260);
            textBoxBalance.Name = "textBoxBalance";
            textBoxBalance.Size = new Size(417, 35);
            textBoxBalance.TabIndex = 73;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LimeGreen;
            panel1.Location = new Point(57, 317);
            panel1.Name = "panel1";
            panel1.Size = new Size(580, 5);
            panel1.TabIndex = 75;
            // 
            // labelCustomer
            // 
            labelCustomer.AutoSize = true;
            labelCustomer.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCustomer.Location = new Point(63, 102);
            labelCustomer.Name = "labelCustomer";
            labelCustomer.Size = new Size(126, 24);
            labelCustomer.TabIndex = 77;
            labelCustomer.Text = "Tên tài khoản";
            // 
            // textBoxAccountName
            // 
            textBoxAccountName.Font = new Font("Roboto", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxAccountName.Location = new Point(211, 96);
            textBoxAccountName.Name = "textBoxAccountName";
            textBoxAccountName.Size = new Size(417, 35);
            textBoxAccountName.TabIndex = 76;
            // 
            // UC_DepositInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelCustomer);
            Controls.Add(textBoxAccountName);
            Controls.Add(panel1);
            Controls.Add(labelBalance);
            Controls.Add(textBoxBalance);
            Controls.Add(labelDescription);
            Controls.Add(textBoxTransactionDescription);
            Controls.Add(labelError);
            Controls.Add(labelAmount);
            Controls.Add(buttonCancel);
            Controls.Add(textBoxAmount);
            Controls.Add(labelCitizenID);
            Controls.Add(textBoxCitizenID);
            Controls.Add(labelPhone);
            Controls.Add(textBoxPhone);
            Controls.Add(labelAccountID);
            Controls.Add(buttonConfirm);
            Controls.Add(labelDepositInfo);
            Controls.Add(textBoxAccountID);
            Controls.Add(labelDeposit);
            Name = "UC_DepositInfo";
            Size = new Size(691, 520);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelAmount;
        private Button buttonCancel;
        private TextBox textBoxAmount;
        private Label labelCitizenID;
        private TextBox textBoxCitizenID;
        private Label labelPhone;
        private TextBox textBoxPhone;
        private Label labelAccountID;
        private Button buttonConfirm;
        private Label labelDepositInfo;
        private TextBox textBoxAccountID;
        private Label labelDeposit;
        private Label labelError;
        private Label labelDescription;
        private TextBox textBoxTransactionDescription;
        private Label labelBalance;
        private TextBox textBoxBalance;
        private Panel panel1;
        private Label labelCustomer;
        private TextBox textBoxAccountName;
    }
}
