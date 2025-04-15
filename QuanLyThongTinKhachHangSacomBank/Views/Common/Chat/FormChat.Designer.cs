

namespace QuanLyThongTinKhachHangSacomBank.Views.Common.Chat
{
    partial class FormChat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChat));
            pictureBoxTopPanel = new PictureBox();
            panelMainContentChat = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTopPanel).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxTopPanel
            // 
            pictureBoxTopPanel.Image = Properties.Resources.Top;
            pictureBoxTopPanel.Location = new Point(0, -3);
            pictureBoxTopPanel.Name = "pictureBoxTopPanel";
            pictureBoxTopPanel.Size = new Size(797, 78);
            pictureBoxTopPanel.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxTopPanel.TabIndex = 1;
            pictureBoxTopPanel.TabStop = false;
            // 
            // panelMainContentChat
            // 
            panelMainContentChat.Location = new Point(12, 81);
            panelMainContentChat.Name = "panelMainContentChat";
            panelMainContentChat.Size = new Size(772, 581);
            panelMainContentChat.TabIndex = 2;
            // 
            // FormChat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(796, 674);
            Controls.Add(panelMainContentChat);
            Controls.Add(pictureBoxTopPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormChat";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tin nhắn";
            ((System.ComponentModel.ISupportInitialize)pictureBoxTopPanel).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBoxTopPanel;
        private Panel panelMainContentChat;
    }
}