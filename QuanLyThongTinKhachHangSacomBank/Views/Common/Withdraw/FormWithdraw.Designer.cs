namespace QuanLyThongTinKhachHangSacomBank.Views.Common.Withdraw
{
    partial class FormWithdraw
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWithdraw));
            pictureBoxTopPanel = new PictureBox();
            panelMainContentWithdraw = new Panel();
            pictureBox1 = new PictureBox();
            pictureBoxRight = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTopPanel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRight).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxTopPanel
            // 
            pictureBoxTopPanel.Image = (Image)resources.GetObject("pictureBoxTopPanel.Image");
            pictureBoxTopPanel.Location = new Point(-2, 1);
            pictureBoxTopPanel.Name = "pictureBoxTopPanel";
            pictureBoxTopPanel.Size = new Size(786, 78);
            pictureBoxTopPanel.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxTopPanel.TabIndex = 39;
            pictureBoxTopPanel.TabStop = false;
            // 
            // panelMainContentWithdraw
            // 
            panelMainContentWithdraw.Location = new Point(45, 80);
            panelMainContentWithdraw.Name = "panelMainContentWithdraw";
            panelMainContentWithdraw.Size = new Size(691, 520);
            panelMainContentWithdraw.TabIndex = 42;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-38, 493);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(160, 160);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBoxRight
            // 
            pictureBoxRight.Image = (Image)resources.GetObject("pictureBoxRight.Image");
            pictureBoxRight.Location = new Point(649, 510);
            pictureBoxRight.Name = "pictureBoxRight";
            pictureBoxRight.Size = new Size(151, 105);
            pictureBoxRight.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxRight.TabIndex = 43;
            pictureBoxRight.TabStop = false;
            // 
            // FormWithdraw
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 613);
            Controls.Add(pictureBoxRight);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBoxTopPanel);
            Controls.Add(panelMainContentWithdraw);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormWithdraw";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Rút tiền";
            ((System.ComponentModel.ISupportInitialize)pictureBoxTopPanel).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRight).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBoxTopPanel;
        private Panel panelMainContentWithdraw;
        private PictureBox pictureBox1;
        private PictureBox pictureBoxRight;
    }
}