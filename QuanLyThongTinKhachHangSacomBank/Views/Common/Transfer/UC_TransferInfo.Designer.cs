namespace QuanLyThongTinKhachHangSacomBank.Views.Common.Transfer
{
    partial class UC_TransferInfo
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
            labelBalance = new Label();
            buttonCancel = new Button();
            labelCitizenID = new Label();
            textBoxCitizenID = new TextBox();
            labelPhone = new Label();
            textBoxPhone = new TextBox();
            labelAccountID = new Label();
            buttonConfirm = new Button();
            labelTransferInfo = new Label();
            textBoxAccountID = new TextBox();
            labelTransfer = new Label();
            labelDepositor = new Label();
            textBoxAccountName = new TextBox();
            textBoxBalance = new TextBox();
            textBoxAmount = new TextBox();
            textBoxReceiverAccountName = new TextBox();
            labelReceiver = new Label();
            labelAmount = new Label();
            labelBank = new Label();
            labelReceiverPhone = new Label();
            textBoxReceiverPhone = new TextBox();
            labelReceiverAccountID = new Label();
            textBoxReceiverAccountID = new TextBox();
            comboBoxBank = new ComboBox();
            labelReceiverCitizenID = new Label();
            textBoxReceiverCitizenID = new TextBox();
            textBoxDescription = new TextBox();
            labelDescription = new Label();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // labelError
            // 
            labelError.AutoSize = true;
            labelError.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelError.ForeColor = Color.Red;
            labelError.Location = new Point(347, 462);
            labelError.Name = "labelError";
            labelError.Size = new Size(240, 20);
            labelError.TabIndex = 96;
            labelError.Text = "Vui lòng nhập đầy đủ thông tin!";
            labelError.Visible = false;
            // 
            // labelBalance
            // 
            labelBalance.AutoSize = true;
            labelBalance.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelBalance.Location = new Point(47, 312);
            labelBalance.Name = "labelBalance";
            labelBalance.Size = new Size(60, 24);
            labelBalance.TabIndex = 94;
            labelBalance.Text = "Số dư";
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.IndianRed;
            buttonCancel.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 192, 0);
            buttonCancel.FlatAppearance.MouseOverBackColor = Color.LimeGreen;
            buttonCancel.Font = new Font("Roboto SemiCondensed Medium", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonCancel.ForeColor = Color.Transparent;
            buttonCancel.Location = new Point(300, 491);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(165, 62);
            buttonCancel.TabIndex = 95;
            buttonCancel.Text = "Hủy bỏ";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // labelCitizenID
            // 
            labelCitizenID.AutoSize = true;
            labelCitizenID.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCitizenID.Location = new Point(47, 262);
            labelCitizenID.Name = "labelCitizenID";
            labelCitizenID.Size = new Size(142, 24);
            labelCitizenID.TabIndex = 92;
            labelCitizenID.Text = "CCCD/Passport";
            // 
            // textBoxCitizenID
            // 
            textBoxCitizenID.Font = new Font("Roboto", 12F);
            textBoxCitizenID.Location = new Point(195, 256);
            textBoxCitizenID.Name = "textBoxCitizenID";
            textBoxCitizenID.Size = new Size(240, 32);
            textBoxCitizenID.TabIndex = 91;
            // 
            // labelPhone
            // 
            labelPhone.AutoSize = true;
            labelPhone.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPhone.Location = new Point(47, 211);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(45, 24);
            labelPhone.TabIndex = 90;
            labelPhone.Text = "SĐT";
            // 
            // textBoxPhone
            // 
            textBoxPhone.Font = new Font("Roboto", 12F);
            textBoxPhone.Location = new Point(195, 205);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(240, 32);
            textBoxPhone.TabIndex = 89;
            // 
            // labelAccountID
            // 
            labelAccountID.AutoSize = true;
            labelAccountID.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAccountID.Location = new Point(47, 161);
            labelAccountID.Name = "labelAccountID";
            labelAccountID.Size = new Size(120, 24);
            labelAccountID.TabIndex = 88;
            labelAccountID.Text = "Mã tài khoản";
            // 
            // buttonConfirm
            // 
            buttonConfirm.BackColor = Color.LimeGreen;
            buttonConfirm.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 192, 0);
            buttonConfirm.FlatAppearance.MouseOverBackColor = Color.LimeGreen;
            buttonConfirm.Font = new Font("Roboto SemiCondensed Medium", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonConfirm.ForeColor = Color.Transparent;
            buttonConfirm.Location = new Point(471, 491);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Size = new Size(165, 62);
            buttonConfirm.TabIndex = 87;
            buttonConfirm.Text = "Xác nhận";
            buttonConfirm.UseVisualStyleBackColor = false;
            buttonConfirm.Click += buttonConfirm_Click;
            // 
            // labelTransferInfo
            // 
            labelTransferInfo.AutoSize = true;
            labelTransferInfo.Font = new Font("Roboto SemiCondensed Medium", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTransferInfo.Location = new Point(385, 52);
            labelTransferInfo.Name = "labelTransferInfo";
            labelTransferInfo.Size = new Size(169, 28);
            labelTransferInfo.TabIndex = 86;
            labelTransferInfo.Text = "Nhập thông tin";
            // 
            // textBoxAccountID
            // 
            textBoxAccountID.Font = new Font("Roboto", 12F);
            textBoxAccountID.Location = new Point(195, 155);
            textBoxAccountID.Name = "textBoxAccountID";
            textBoxAccountID.Size = new Size(240, 32);
            textBoxAccountID.TabIndex = 85;
            // 
            // labelTransfer
            // 
            labelTransfer.AutoSize = true;
            labelTransfer.Font = new Font("Roboto SemiCondensed", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTransfer.ForeColor = SystemColors.HotTrack;
            labelTransfer.Location = new Point(376, 11);
            labelTransfer.Name = "labelTransfer";
            labelTransfer.Size = new Size(189, 41);
            labelTransfer.TabIndex = 84;
            labelTransfer.Text = "Chuyển tiền";
            // 
            // labelDepositor
            // 
            labelDepositor.AutoSize = true;
            labelDepositor.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDepositor.Location = new Point(47, 112);
            labelDepositor.Name = "labelDepositor";
            labelDepositor.Size = new Size(93, 24);
            labelDepositor.TabIndex = 97;
            labelDepositor.Text = "Người gửi";
            // 
            // textBoxAccountName
            // 
            textBoxAccountName.Font = new Font("Roboto", 12F);
            textBoxAccountName.Location = new Point(195, 106);
            textBoxAccountName.Name = "textBoxAccountName";
            textBoxAccountName.Size = new Size(240, 32);
            textBoxAccountName.TabIndex = 98;
            // 
            // textBoxBalance
            // 
            textBoxBalance.Font = new Font("Roboto", 12F);
            textBoxBalance.Location = new Point(195, 306);
            textBoxBalance.Name = "textBoxBalance";
            textBoxBalance.Size = new Size(240, 32);
            textBoxBalance.TabIndex = 99;
            // 
            // textBoxAmount
            // 
            textBoxAmount.Font = new Font("Roboto", 12F);
            textBoxAmount.Location = new Point(286, 379);
            textBoxAmount.Name = "textBoxAmount";
            textBoxAmount.Size = new Size(464, 32);
            textBoxAmount.TabIndex = 109;
            // 
            // textBoxReceiverAccountName
            // 
            textBoxReceiverAccountName.Font = new Font("Roboto", 12F);
            textBoxReceiverAccountName.Location = new Point(619, 106);
            textBoxReceiverAccountName.Name = "textBoxReceiverAccountName";
            textBoxReceiverAccountName.Size = new Size(278, 32);
            textBoxReceiverAccountName.TabIndex = 108;
            // 
            // labelReceiver
            // 
            labelReceiver.AutoSize = true;
            labelReceiver.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelReceiver.Location = new Point(471, 112);
            labelReceiver.Name = "labelReceiver";
            labelReceiver.Size = new Size(109, 24);
            labelReceiver.TabIndex = 107;
            labelReceiver.Text = "Người nhận";
            // 
            // labelAmount
            // 
            labelAmount.AutoSize = true;
            labelAmount.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAmount.Location = new Point(192, 385);
            labelAmount.Name = "labelAmount";
            labelAmount.Size = new Size(70, 24);
            labelAmount.TabIndex = 106;
            labelAmount.Text = "Số tiền";
            // 
            // labelBank
            // 
            labelBank.AutoSize = true;
            labelBank.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelBank.Location = new Point(471, 312);
            labelBank.Name = "labelBank";
            labelBank.Size = new Size(103, 24);
            labelBank.TabIndex = 105;
            labelBank.Text = "Ngân hàng";
            // 
            // labelReceiverPhone
            // 
            labelReceiverPhone.AutoSize = true;
            labelReceiverPhone.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelReceiverPhone.Location = new Point(471, 211);
            labelReceiverPhone.Name = "labelReceiverPhone";
            labelReceiverPhone.Size = new Size(45, 24);
            labelReceiverPhone.TabIndex = 103;
            labelReceiverPhone.Text = "SĐT";
            // 
            // textBoxReceiverPhone
            // 
            textBoxReceiverPhone.Font = new Font("Roboto", 12F);
            textBoxReceiverPhone.Location = new Point(619, 205);
            textBoxReceiverPhone.Name = "textBoxReceiverPhone";
            textBoxReceiverPhone.Size = new Size(278, 32);
            textBoxReceiverPhone.TabIndex = 102;
            // 
            // labelReceiverAccountID
            // 
            labelReceiverAccountID.AutoSize = true;
            labelReceiverAccountID.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelReceiverAccountID.Location = new Point(471, 161);
            labelReceiverAccountID.Name = "labelReceiverAccountID";
            labelReceiverAccountID.Size = new Size(120, 24);
            labelReceiverAccountID.TabIndex = 101;
            labelReceiverAccountID.Text = "Mã tài khoản";
            // 
            // textBoxReceiverAccountID
            // 
            textBoxReceiverAccountID.Font = new Font("Roboto", 12F);
            textBoxReceiverAccountID.Location = new Point(619, 155);
            textBoxReceiverAccountID.Name = "textBoxReceiverAccountID";
            textBoxReceiverAccountID.Size = new Size(278, 32);
            textBoxReceiverAccountID.TabIndex = 100;
            // 
            // comboBoxBank
            // 
            comboBoxBank.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBank.Font = new Font("Roboto", 12F);
            comboBoxBank.FormattingEnabled = true;
            comboBoxBank.Items.AddRange(new object[] { "Sacombank" });
            comboBoxBank.Location = new Point(619, 306);
            comboBoxBank.Name = "comboBoxBank";
            comboBoxBank.Size = new Size(278, 32);
            comboBoxBank.TabIndex = 110;
            // 
            // labelReceiverCitizenID
            // 
            labelReceiverCitizenID.AutoSize = true;
            labelReceiverCitizenID.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelReceiverCitizenID.Location = new Point(471, 262);
            labelReceiverCitizenID.Name = "labelReceiverCitizenID";
            labelReceiverCitizenID.Size = new Size(142, 24);
            labelReceiverCitizenID.TabIndex = 112;
            labelReceiverCitizenID.Text = "CCCD/Passport";
            // 
            // textBoxReceiverCitizenID
            // 
            textBoxReceiverCitizenID.Font = new Font("Roboto", 12F);
            textBoxReceiverCitizenID.Location = new Point(619, 256);
            textBoxReceiverCitizenID.Name = "textBoxReceiverCitizenID";
            textBoxReceiverCitizenID.Size = new Size(278, 32);
            textBoxReceiverCitizenID.TabIndex = 111;
            // 
            // textBoxDescription
            // 
            textBoxDescription.Font = new Font("Roboto", 12F);
            textBoxDescription.Location = new Point(286, 420);
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(464, 32);
            textBoxDescription.TabIndex = 114;
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Roboto SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDescription.Location = new Point(192, 426);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(88, 24);
            labelDescription.TabIndex = 113;
            labelDescription.Text = "Nội dung";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.HotTrack;
            panel1.Location = new Point(188, 359);
            panel1.Name = "panel1";
            panel1.Size = new Size(580, 5);
            panel1.TabIndex = 115;
            // 
            // UC_TransferInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(textBoxDescription);
            Controls.Add(labelDescription);
            Controls.Add(labelReceiverCitizenID);
            Controls.Add(textBoxReceiverCitizenID);
            Controls.Add(comboBoxBank);
            Controls.Add(textBoxAmount);
            Controls.Add(textBoxReceiverAccountName);
            Controls.Add(labelReceiver);
            Controls.Add(labelAmount);
            Controls.Add(labelBank);
            Controls.Add(labelReceiverPhone);
            Controls.Add(textBoxReceiverPhone);
            Controls.Add(labelReceiverAccountID);
            Controls.Add(textBoxReceiverAccountID);
            Controls.Add(textBoxBalance);
            Controls.Add(textBoxAccountName);
            Controls.Add(labelDepositor);
            Controls.Add(labelError);
            Controls.Add(labelBalance);
            Controls.Add(buttonCancel);
            Controls.Add(labelCitizenID);
            Controls.Add(textBoxCitizenID);
            Controls.Add(labelPhone);
            Controls.Add(textBoxPhone);
            Controls.Add(labelAccountID);
            Controls.Add(buttonConfirm);
            Controls.Add(labelTransferInfo);
            Controls.Add(textBoxAccountID);
            Controls.Add(labelTransfer);
            Name = "UC_TransferInfo";
            Size = new Size(935, 560);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelError;
        private Label labelBalance;
        private Button buttonCancel;
        private Label labelCitizenID;
        private TextBox textBoxCitizenID;
        private Label labelPhone;
        private TextBox textBoxPhone;
        private Label labelAccountID;
        private Button buttonConfirm;
        private Label labelTransferInfo;
        private TextBox textBoxAccountID;
        private Label labelTransfer;
        private Label labelDepositor;
        private TextBox textBoxAccountName;
        private TextBox textBoxBalance;
        private TextBox textBoxAmount;
        private TextBox textBoxReceiverAccountName;
        private Label labelReceiver;
        private Label labelAmount;
        private Label labelBank;
        private Label labelReceiverPhone;
        private TextBox textBoxReceiverPhone;
        private Label labelReceiverAccountID;
        private TextBox textBoxReceiverAccountID;
        private ComboBox comboBoxBank;
        private Label labelReceiverCitizenID;
        private TextBox textBoxReceiverCitizenID;
        private TextBox textBoxDescription;
        private Label labelDescription;
        private Panel panel1;
    }
}
