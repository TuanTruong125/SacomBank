namespace QuanLyThongTinKhachHangSacomBank.Views.Common.Withdraw
{
    partial class UC_WithdrawInfo
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
            labelError = new Label();
            labelAmount = new Label();
            buttonCancel = new Button();
            textBoxAmount = new TextBox();
            labelCitizenID = new Label();
            textBoxCitizenID = new TextBox();
            labelPhone = new Label();
            textBoxPhone = new TextBox();
            labelAccountID = new Label();
            buttonConfirm = new Button();
            labelWithdrawInfo = new Label();
            textBoxAccountID = new TextBox();
            labelWithdraw = new Label();
            labelDescription = new Label();
            textBoxTransactionDescription = new TextBox();
            labelBalance = new Label();
            textBoxBalance = new TextBox();
            panel1 = new Panel();
            labelCustomer = new Label();
            textBoxAccountName = new TextBox();
            SuspendLayout();
            // 
            // labelError
            // 
            labelError.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelError.ForeColor = Color.Red;
            labelError.Location = new Point(3, 426);
            labelError.Name = "labelError";
            labelError.Size = new Size(685, 20);
            labelError.TabIndex = 83;
            labelError.Text = "Vui lòng nhập đầy đủ thông tin!";
            labelError.TextAlign = ContentAlignment.MiddleCenter;
            labelError.Visible = false;
            // 
            // labelAmount
            // 
            labelAmount.AutoSize = true;
            labelAmount.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAmount.Location = new Point(63, 348);
            labelAmount.Name = "labelAmount";
            labelAmount.Size = new Size(70, 24);
            labelAmount.TabIndex = 81;
            labelAmount.Text = "Số tiền";
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.IndianRed;
            buttonCancel.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 192, 0);
            buttonCancel.FlatAppearance.MouseOverBackColor = Color.LimeGreen;
            buttonCancel.Font = new Font("Roboto SemiCondensed Medium", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonCancel.ForeColor = Color.Transparent;
            buttonCancel.Location = new Point(172, 455);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(165, 62);
            buttonCancel.TabIndex = 82;
            buttonCancel.Text = "Hủy bỏ";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // textBoxAmount
            // 
            textBoxAmount.Font = new Font("Roboto", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxAmount.Location = new Point(211, 342);
            textBoxAmount.Name = "textBoxAmount";
            textBoxAmount.Size = new Size(417, 35);
            textBoxAmount.TabIndex = 80;
            // 
            // labelCitizenID
            // 
            labelCitizenID.AutoSize = true;
            labelCitizenID.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCitizenID.Location = new Point(63, 227);
            labelCitizenID.Name = "labelCitizenID";
            labelCitizenID.Size = new Size(58, 24);
            labelCitizenID.TabIndex = 79;
            labelCitizenID.Text = "CCCD";
            // 
            // textBoxCitizenID
            // 
            textBoxCitizenID.Font = new Font("Roboto", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxCitizenID.Location = new Point(211, 221);
            textBoxCitizenID.Name = "textBoxCitizenID";
            textBoxCitizenID.Size = new Size(417, 35);
            textBoxCitizenID.TabIndex = 78;
            // 
            // labelPhone
            // 
            labelPhone.AutoSize = true;
            labelPhone.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPhone.Location = new Point(63, 186);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(45, 24);
            labelPhone.TabIndex = 77;
            labelPhone.Text = "SĐT";
            // 
            // textBoxPhone
            // 
            textBoxPhone.Font = new Font("Roboto", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxPhone.Location = new Point(211, 180);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(417, 35);
            textBoxPhone.TabIndex = 76;
            // 
            // labelAccountID
            // 
            labelAccountID.AutoSize = true;
            labelAccountID.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAccountID.Location = new Point(63, 145);
            labelAccountID.Name = "labelAccountID";
            labelAccountID.Size = new Size(120, 24);
            labelAccountID.TabIndex = 75;
            labelAccountID.Text = "Mã tài khoản";
            // 
            // buttonConfirm
            // 
            buttonConfirm.BackColor = Color.LimeGreen;
            buttonConfirm.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 192, 0);
            buttonConfirm.FlatAppearance.MouseOverBackColor = Color.LimeGreen;
            buttonConfirm.Font = new Font("Roboto SemiCondensed Medium", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonConfirm.ForeColor = Color.Transparent;
            buttonConfirm.Location = new Point(343, 455);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Size = new Size(165, 62);
            buttonConfirm.TabIndex = 74;
            buttonConfirm.Text = "Xác nhận";
            buttonConfirm.UseVisualStyleBackColor = false;
            buttonConfirm.Click += buttonConfirm_Click;
            // 
            // labelWithdrawInfo
            // 
            labelWithdrawInfo.Font = new Font("Roboto SemiCondensed Medium", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelWithdrawInfo.Location = new Point(3, 56);
            labelWithdrawInfo.Name = "labelWithdrawInfo";
            labelWithdrawInfo.Size = new Size(685, 28);
            labelWithdrawInfo.TabIndex = 73;
            labelWithdrawInfo.Text = "Nhập thông tin";
            labelWithdrawInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxAccountID
            // 
            textBoxAccountID.Font = new Font("Roboto", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxAccountID.Location = new Point(211, 139);
            textBoxAccountID.Name = "textBoxAccountID";
            textBoxAccountID.Size = new Size(417, 35);
            textBoxAccountID.TabIndex = 72;
            // 
            // labelWithdraw
            // 
            labelWithdraw.Font = new Font("Roboto SemiCondensed", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelWithdraw.ForeColor = Color.Crimson;
            labelWithdraw.Location = new Point(3, 15);
            labelWithdraw.Name = "labelWithdraw";
            labelWithdraw.Size = new Size(685, 41);
            labelWithdraw.TabIndex = 71;
            labelWithdraw.Text = "Rút tiền";
            labelWithdraw.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDescription.Location = new Point(63, 389);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(88, 24);
            labelDescription.TabIndex = 85;
            labelDescription.Text = "Nội dung";
            // 
            // textBoxTransactionDescription
            // 
            textBoxTransactionDescription.Font = new Font("Roboto", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxTransactionDescription.Location = new Point(211, 383);
            textBoxTransactionDescription.Name = "textBoxTransactionDescription";
            textBoxTransactionDescription.Size = new Size(417, 35);
            textBoxTransactionDescription.TabIndex = 84;
            // 
            // labelBalance
            // 
            labelBalance.AutoSize = true;
            labelBalance.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelBalance.Location = new Point(63, 268);
            labelBalance.Name = "labelBalance";
            labelBalance.Size = new Size(60, 24);
            labelBalance.TabIndex = 87;
            labelBalance.Text = "Số dư";
            // 
            // textBoxBalance
            // 
            textBoxBalance.Font = new Font("Roboto", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxBalance.Location = new Point(211, 262);
            textBoxBalance.Name = "textBoxBalance";
            textBoxBalance.Size = new Size(417, 35);
            textBoxBalance.TabIndex = 86;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Red;
            panel1.Location = new Point(58, 318);
            panel1.Name = "panel1";
            panel1.Size = new Size(580, 5);
            panel1.TabIndex = 88;
            // 
            // labelCustomer
            // 
            labelCustomer.AutoSize = true;
            labelCustomer.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCustomer.Location = new Point(63, 104);
            labelCustomer.Name = "labelCustomer";
            labelCustomer.Size = new Size(126, 24);
            labelCustomer.TabIndex = 90;
            labelCustomer.Text = "Tên tài khoản";
            // 
            // textBoxAccountName
            // 
            textBoxAccountName.Font = new Font("Roboto", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxAccountName.Location = new Point(211, 98);
            textBoxAccountName.Name = "textBoxAccountName";
            textBoxAccountName.Size = new Size(417, 35);
            textBoxAccountName.TabIndex = 89;
            // 
            // UC_WithdrawInfo
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
            Controls.Add(labelWithdrawInfo);
            Controls.Add(textBoxAccountID);
            Controls.Add(labelWithdraw);
            Name = "UC_WithdrawInfo";
            Size = new Size(691, 520);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelError;
        private Label labelAmount;
        private Button buttonCancel;
        private TextBox textBoxAmount;
        private Label labelCitizenID;
        private TextBox textBoxCitizenID;
        private Label labelPhone;
        private TextBox textBoxPhone;
        private Label labelAccountID;
        private Button buttonConfirm;
        private Label labelWithdrawInfo;
        private TextBox textBoxAccountID;
        private Label labelWithdraw;
        private Label labelDescription;
        private TextBox textBoxTransactionDescription;
        private Label labelBalance;
        private TextBox textBoxBalance;
        private Panel panel1;
        private Label labelCustomer;
        private TextBox textBoxAccountName;
    }
}
