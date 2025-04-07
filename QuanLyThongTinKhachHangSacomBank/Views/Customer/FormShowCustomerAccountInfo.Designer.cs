namespace QuanLyThongTinKhachHangSacomBank.Views.Customer
{
    partial class FormShowCustomerAccountInfo
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShowCustomerAccountInfo));
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            groupBox1 = new GroupBox();
            buttonAccountCopy = new Button();
            labelAccountName = new Label();
            panel2 = new Panel();
            labelAccountID = new Label();
            label1 = new Label();
            panel3 = new Panel();
            labelCustomerTypeName = new Label();
            label7 = new Label();
            labelAccountTypeName = new Label();
            label5 = new Label();
            labelAccountOpenDate = new Label();
            label4 = new Label();
            labelBalance = new Label();
            label2 = new Label();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(470, 86);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(-2, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(470, 266);
            panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonAccountCopy);
            groupBox1.Controls.Add(labelAccountName);
            groupBox1.Controls.Add(panel2);
            groupBox1.Controls.Add(labelAccountID);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Roboto SemiCondensed Medium", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(14, 98);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(442, 154);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "TÀI KHOẢN";
            // 
            // buttonAccountCopy
            // 
            buttonAccountCopy.Image = (Image)resources.GetObject("buttonAccountCopy.Image");
            buttonAccountCopy.Location = new Point(394, 75);
            buttonAccountCopy.Name = "buttonAccountCopy";
            buttonAccountCopy.Size = new Size(42, 42);
            buttonAccountCopy.TabIndex = 5;
            toolTip1.SetToolTip(buttonAccountCopy, "Copy thông tin tài khoản");
            buttonAccountCopy.UseVisualStyleBackColor = true;
            // 
            // labelAccountName
            // 
            labelAccountName.AutoSize = true;
            labelAccountName.Font = new Font("Roboto SemiCondensed Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAccountName.Location = new Point(6, 111);
            labelAccountName.Name = "labelAccountName";
            labelAccountName.Size = new Size(197, 24);
            labelAccountName.TabIndex = 4;
            labelAccountName.Text = "TRUONG ANH TUAN";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.HotTrack;
            panel2.Location = new Point(6, 34);
            panel2.Name = "panel2";
            panel2.Size = new Size(430, 5);
            panel2.TabIndex = 3;
            // 
            // labelAccountID
            // 
            labelAccountID.AutoSize = true;
            labelAccountID.Font = new Font("Roboto SemiCondensed Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAccountID.Location = new Point(6, 75);
            labelAccountID.Name = "labelAccountID";
            labelAccountID.Size = new Size(47, 24);
            labelAccountID.TabIndex = 2;
            labelAccountID.Text = "TK1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.SteelBlue;
            label1.Location = new Point(6, 42);
            label1.Name = "label1";
            label1.Size = new Size(116, 24);
            label1.TabIndex = 1;
            label1.Text = "SacomBank";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(labelCustomerTypeName);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(labelAccountTypeName);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(labelAccountOpenDate);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(labelBalance);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(0, 270);
            panel3.Name = "panel3";
            panel3.Size = new Size(468, 207);
            panel3.TabIndex = 2;
            // 
            // labelCustomerTypeName
            // 
            labelCustomerTypeName.AutoSize = true;
            labelCustomerTypeName.Font = new Font("Roboto SemiCondensed Medium", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCustomerTypeName.ForeColor = Color.Gray;
            labelCustomerTypeName.Location = new Point(273, 55);
            labelCustomerTypeName.Name = "labelCustomerTypeName";
            labelCustomerTypeName.Size = new Size(92, 28);
            labelCustomerTypeName.TabIndex = 9;
            labelCustomerTypeName.Text = "Thường";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(273, 20);
            label7.Name = "label7";
            label7.Size = new Size(50, 24);
            label7.TabIndex = 8;
            label7.Text = "Cấp:";
            // 
            // labelAccountTypeName
            // 
            labelAccountTypeName.AutoSize = true;
            labelAccountTypeName.Font = new Font("Roboto SemiCondensed Medium", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAccountTypeName.ForeColor = Color.Black;
            labelAccountTypeName.Location = new Point(18, 148);
            labelAccountTypeName.Name = "labelAccountTypeName";
            labelAccountTypeName.Size = new Size(99, 28);
            labelAccountTypeName.TabIndex = 7;
            labelAccountTypeName.Text = "Cá nhân";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(18, 113);
            label5.Name = "label5";
            label5.Size = new Size(140, 24);
            label5.TabIndex = 6;
            label5.Text = "Loại tài khoản:";
            // 
            // labelAccountOpenDate
            // 
            labelAccountOpenDate.AutoSize = true;
            labelAccountOpenDate.Font = new Font("Roboto SemiCondensed Medium", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAccountOpenDate.ForeColor = Color.Black;
            labelAccountOpenDate.Location = new Point(273, 148);
            labelAccountOpenDate.Name = "labelAccountOpenDate";
            labelAccountOpenDate.Size = new Size(136, 28);
            labelAccountOpenDate.TabIndex = 5;
            labelAccountOpenDate.Text = "26/03/2025";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(273, 113);
            label4.Name = "label4";
            label4.Size = new Size(181, 24);
            label4.TabIndex = 4;
            label4.Text = "Ngày mở tài khoản:";
            // 
            // labelBalance
            // 
            labelBalance.AutoSize = true;
            labelBalance.Font = new Font("Roboto SemiCondensed Medium", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelBalance.ForeColor = Color.ForestGreen;
            labelBalance.Location = new Point(18, 55);
            labelBalance.Name = "labelBalance";
            labelBalance.Size = new Size(25, 28);
            labelBalance.TabIndex = 3;
            labelBalance.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(18, 20);
            label2.Name = "label2";
            label2.Size = new Size(125, 24);
            label2.TabIndex = 2;
            label2.Text = "Số dư (VND):";
            // 
            // FormCustomerAccountInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(467, 476);
            Controls.Add(panel3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormCustomerAccountInfo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thông tin tài khoản";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Panel panel1;
        private GroupBox groupBox1;
        private Panel panel2;
        private Label labelAccountID;
        private Label label1;
        private Label labelAccountName;
        private Panel panel3;
        private Label label2;
        private Label labelBalance;
        private Label labelAccountOpenDate;
        private Label label4;
        private Label labelCustomerTypeName;
        private Label label7;
        private Label labelAccountTypeName;
        private Label label5;
        private Button buttonAccountCopy;
        private ToolTip toolTip1;
    }
}