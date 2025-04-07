namespace QuanLyThongTinKhachHangSacomBank.Views.Common.Deposit
{
    partial class FormDeposit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDeposit));
            pictureBoxLeft = new PictureBox();
            pictureBoxRight = new PictureBox();
            pictureBoxTopPanel = new PictureBox();
            panelMainContentDeposit = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLeft).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTopPanel).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxLeft
            // 
            pictureBoxLeft.Image = (Image)resources.GetObject("pictureBoxLeft.Image");
            pictureBoxLeft.Location = new Point(-54, 493);
            pictureBoxLeft.Name = "pictureBoxLeft";
            pictureBoxLeft.Size = new Size(160, 160);
            pictureBoxLeft.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxLeft.TabIndex = 37;
            pictureBoxLeft.TabStop = false;
            // 
            // pictureBoxRight
            // 
            pictureBoxRight.Image = (Image)resources.GetObject("pictureBoxRight.Image");
            pictureBoxRight.Location = new Point(676, 509);
            pictureBoxRight.Name = "pictureBoxRight";
            pictureBoxRight.Size = new Size(146, 107);
            pictureBoxRight.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxRight.TabIndex = 36;
            pictureBoxRight.TabStop = false;
            // 
            // pictureBoxTopPanel
            // 
            pictureBoxTopPanel.Image = (Image)resources.GetObject("pictureBoxTopPanel.Image");
            pictureBoxTopPanel.Location = new Point(-3, 0);
            pictureBoxTopPanel.Name = "pictureBoxTopPanel";
            pictureBoxTopPanel.Size = new Size(796, 78);
            pictureBoxTopPanel.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxTopPanel.TabIndex = 22;
            pictureBoxTopPanel.TabStop = false;
            // 
            // panelMainContentDeposit
            // 
            panelMainContentDeposit.Location = new Point(45, 79);
            panelMainContentDeposit.Name = "panelMainContentDeposit";
            panelMainContentDeposit.Size = new Size(691, 520);
            panelMainContentDeposit.TabIndex = 38;
            // 
            // FormDeposit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 613);
            Controls.Add(pictureBoxLeft);
            Controls.Add(pictureBoxRight);
            Controls.Add(panelMainContentDeposit);
            Controls.Add(pictureBoxTopPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormDeposit";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nạp tiền";
            ((System.ComponentModel.ISupportInitialize)pictureBoxLeft).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRight).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTopPanel).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label labelErrorOTP;
        private PictureBox pictureBoxLeft;
        private PictureBox pictureBoxRight;
        private LinkLabel linkLabelRequestAgain;
        private Label labelQuestion;
        private PictureBox pictureBoxTopPanel;
        private Panel panelMainContentDeposit;
    }
}