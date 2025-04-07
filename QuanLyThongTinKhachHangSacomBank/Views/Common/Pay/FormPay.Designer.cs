namespace QuanLyThongTinKhachHangSacomBank.Views.Common.Pay
{
    partial class FormPay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPay));
            pictureBoxLeft = new PictureBox();
            pictureBoxRight = new PictureBox();
            panelMainContentPay = new Panel();
            pictureBoxTopPanel = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLeft).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTopPanel).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxLeft
            // 
            pictureBoxLeft.Image = (Image)resources.GetObject("pictureBoxLeft.Image");
            pictureBoxLeft.Location = new Point(-34, 524);
            pictureBoxLeft.Name = "pictureBoxLeft";
            pictureBoxLeft.Size = new Size(150, 150);
            pictureBoxLeft.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxLeft.TabIndex = 45;
            pictureBoxLeft.TabStop = false;
            // 
            // pictureBoxRight
            // 
            pictureBoxRight.Image = (Image)resources.GetObject("pictureBoxRight.Image");
            pictureBoxRight.Location = new Point(917, 583);
            pictureBoxRight.Name = "pictureBoxRight";
            pictureBoxRight.Size = new Size(140, 73);
            pictureBoxRight.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxRight.TabIndex = 44;
            pictureBoxRight.TabStop = false;
            // 
            // panelMainContentPay
            // 
            panelMainContentPay.Location = new Point(50, 59);
            panelMainContentPay.Name = "panelMainContentPay";
            panelMainContentPay.Size = new Size(935, 560);
            panelMainContentPay.TabIndex = 46;
            // 
            // pictureBoxTopPanel
            // 
            pictureBoxTopPanel.Image = (Image)resources.GetObject("pictureBoxTopPanel.Image");
            pictureBoxTopPanel.Location = new Point(5, -21);
            pictureBoxTopPanel.Name = "pictureBoxTopPanel";
            pictureBoxTopPanel.Size = new Size(1025, 78);
            pictureBoxTopPanel.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxTopPanel.TabIndex = 43;
            pictureBoxTopPanel.TabStop = false;
            // 
            // FormPay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1022, 653);
            Controls.Add(pictureBoxLeft);
            Controls.Add(pictureBoxRight);
            Controls.Add(panelMainContentPay);
            Controls.Add(pictureBoxTopPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormPay";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thanh toán";
            ((System.ComponentModel.ISupportInitialize)pictureBoxLeft).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRight).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTopPanel).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBoxLeft;
        private PictureBox pictureBoxRight;
        private Panel panelMainContentPay;
        private PictureBox pictureBoxTopPanel;
    }
}