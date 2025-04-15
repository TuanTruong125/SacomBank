namespace QuanLyThongTinKhachHangSacomBank.Views.Common.Chat
{
    partial class UC_EmployeeChat
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
            panel2 = new Panel();
            panel1 = new Panel();
            label1 = new Label();
            richTextBoxMessage = new RichTextBox();
            label3 = new Label();
            label2 = new Label();
            textBoxTitle = new TextBox();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.HotTrack;
            panel2.Location = new Point(22, 17);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 5);
            panel2.TabIndex = 8;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.HotTrack;
            panel1.Location = new Point(546, 17);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 5);
            panel1.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Roboto SemiCondensed", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(239, 4);
            label1.Name = "label1";
            label1.Size = new Size(283, 28);
            label1.TabIndex = 6;
            label1.Text = "Chi tiết yêu cầu khách hàng";
            // 
            // richTextBoxMessage
            // 
            richTextBoxMessage.BorderStyle = BorderStyle.None;
            richTextBoxMessage.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBoxMessage.Location = new Point(6, 112);
            richTextBoxMessage.Name = "richTextBoxMessage";
            richTextBoxMessage.Size = new Size(766, 466);
            richTextBoxMessage.TabIndex = 24;
            richTextBoxMessage.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Roboto SemiCondensed Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(6, 85);
            label3.Name = "label3";
            label3.Size = new Size(100, 24);
            label3.TabIndex = 23;
            label3.Text = "Nội dung:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Roboto SemiCondensed Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(6, 53);
            label2.Name = "label2";
            label2.Size = new Size(86, 24);
            label2.TabIndex = 22;
            label2.Text = "Tiêu đề:";
            // 
            // textBoxTitle
            // 
            textBoxTitle.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxTitle.Location = new Point(92, 50);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.PlaceholderText = "Nhập tiêu đề yêu cầu . . .";
            textBoxTitle.Size = new Size(677, 32);
            textBoxTitle.TabIndex = 21;
            // 
            // UC_EmployeeChat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(richTextBoxMessage);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBoxTitle);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "UC_EmployeeChat";
            Size = new Size(772, 581);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel2;
        private Panel panel1;
        private Label label1;
        private RichTextBox richTextBoxMessage;
        private Label label3;
        private Label label2;
        private TextBox textBoxTitle;
    }
}
