namespace QuanLyThongTinKhachHangSacomBank.Views.Common.Transfer
{
    partial class FormTransfer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTransfer));
            pictureBoxLeft = new PictureBox();
            pictureBoxRight = new PictureBox();
            panelMainContentTransfer = new Panel();
            pictureBoxTopPanel = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLeft).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTopPanel).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxLeft
            // 
            pictureBoxLeft.Image = (Image)resources.GetObject("pictureBoxLeft.Image");
            pictureBoxLeft.Location = new Point(-40, 542);
            pictureBoxLeft.Name = "pictureBoxLeft";
            pictureBoxLeft.Size = new Size(150, 150);
            pictureBoxLeft.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxLeft.TabIndex = 41;
            pictureBoxLeft.TabStop = false;
            // 
            // pictureBoxRight
            // 
            pictureBoxRight.Image = (Image)resources.GetObject("pictureBoxRight.Image");
            pictureBoxRight.Location = new Point(911, 586);
            pictureBoxRight.Name = "pictureBoxRight";
            pictureBoxRight.Size = new Size(140, 73);
            pictureBoxRight.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxRight.TabIndex = 40;
            pictureBoxRight.TabStop = false;
            // 
            // panelMainContentTransfer
            // 
            panelMainContentTransfer.Location = new Point(44, 77);
            panelMainContentTransfer.Name = "panelMainContentTransfer";
            panelMainContentTransfer.Size = new Size(935, 560);
            panelMainContentTransfer.TabIndex = 42;
            // 
            // pictureBoxTopPanel
            // 
            pictureBoxTopPanel.Image = (Image)resources.GetObject("pictureBoxTopPanel.Image");
            pictureBoxTopPanel.Location = new Point(-1, -3);
            pictureBoxTopPanel.Name = "pictureBoxTopPanel";
            pictureBoxTopPanel.Size = new Size(1025, 78);
            pictureBoxTopPanel.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxTopPanel.TabIndex = 39;
            pictureBoxTopPanel.TabStop = false;
            // 
            // FormTransfer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1022, 653);
            Controls.Add(pictureBoxLeft);
            Controls.Add(pictureBoxRight);
            Controls.Add(panelMainContentTransfer);
            Controls.Add(pictureBoxTopPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormTransfer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chuyển tiền";
            ((System.ComponentModel.ISupportInitialize)pictureBoxLeft).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRight).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTopPanel).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBoxLeft;
        private PictureBox pictureBoxRight;
        private Panel panelMainContentTransfer;
        private PictureBox pictureBoxTopPanel;
    }
}