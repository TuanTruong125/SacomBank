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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_EmployeeChat));
            panel2 = new Panel();
            panel1 = new Panel();
            label1 = new Label();
            flowLayoutPanelMessage = new FlowLayoutPanel();
            textBoxMessage = new TextBox();
            buttonSendMessage = new Button();
            cyberButtonEndChat = new ReaLTaiizor.Controls.CyberButton();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.HotTrack;
            panel2.Location = new Point(71, 17);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 5);
            panel2.TabIndex = 8;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.HotTrack;
            panel1.Location = new Point(495, 17);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 5);
            panel1.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Roboto SemiCondensed", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(277, 4);
            label1.Name = "label1";
            label1.Size = new Size(212, 28);
            label1.TabIndex = 6;
            label1.Text = "Chat với khách hàng";
            // 
            // flowLayoutPanelMessage
            // 
            flowLayoutPanelMessage.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanelMessage.Location = new Point(3, 35);
            flowLayoutPanelMessage.Name = "flowLayoutPanelMessage";
            flowLayoutPanelMessage.Size = new Size(766, 343);
            flowLayoutPanelMessage.TabIndex = 9;
            // 
            // textBoxMessage
            // 
            textBoxMessage.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxMessage.Location = new Point(3, 384);
            textBoxMessage.Name = "textBoxMessage";
            textBoxMessage.PlaceholderText = "Nhập tin nhắn . . .";
            textBoxMessage.Size = new Size(725, 32);
            textBoxMessage.TabIndex = 10;
            // 
            // buttonSendMessage
            // 
            buttonSendMessage.BackColor = Color.Transparent;
            buttonSendMessage.Image = (Image)resources.GetObject("buttonSendMessage.Image");
            buttonSendMessage.Location = new Point(734, 384);
            buttonSendMessage.Name = "buttonSendMessage";
            buttonSendMessage.Size = new Size(35, 32);
            buttonSendMessage.TabIndex = 11;
            buttonSendMessage.UseVisualStyleBackColor = false;
            // 
            // cyberButtonEndChat
            // 
            cyberButtonEndChat.Alpha = 20;
            cyberButtonEndChat.BackColor = Color.Transparent;
            cyberButtonEndChat.Background = true;
            cyberButtonEndChat.Background_WidthPen = 4F;
            cyberButtonEndChat.BackgroundPen = true;
            cyberButtonEndChat.ColorBackground = Color.FromArgb(37, 52, 68);
            cyberButtonEndChat.ColorBackground_1 = Color.Red;
            cyberButtonEndChat.ColorBackground_2 = Color.FromArgb(255, 128, 128);
            cyberButtonEndChat.ColorBackground_Pen = Color.FromArgb(29, 200, 238);
            cyberButtonEndChat.ColorLighting = Color.FromArgb(29, 200, 238);
            cyberButtonEndChat.ColorPen_1 = Color.Red;
            cyberButtonEndChat.ColorPen_2 = Color.FromArgb(255, 128, 128);
            cyberButtonEndChat.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            cyberButtonEndChat.Effect_1 = true;
            cyberButtonEndChat.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            cyberButtonEndChat.Effect_1_Transparency = 25;
            cyberButtonEndChat.Effect_2 = true;
            cyberButtonEndChat.Effect_2_ColorBackground = Color.White;
            cyberButtonEndChat.Effect_2_Transparency = 20;
            cyberButtonEndChat.Font = new Font("Roboto SemiCondensed Medium", 12F, FontStyle.Bold);
            cyberButtonEndChat.ForeColor = Color.FromArgb(245, 245, 245);
            cyberButtonEndChat.Lighting = false;
            cyberButtonEndChat.LinearGradient_Background = true;
            cyberButtonEndChat.LinearGradientPen = true;
            cyberButtonEndChat.Location = new Point(277, 419);
            cyberButtonEndChat.Name = "cyberButtonEndChat";
            cyberButtonEndChat.PenWidth = 15;
            cyberButtonEndChat.Rounding = true;
            cyberButtonEndChat.RoundingInt = 70;
            cyberButtonEndChat.Size = new Size(220, 49);
            cyberButtonEndChat.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberButtonEndChat.TabIndex = 178;
            cyberButtonEndChat.Tag = "Cyber";
            cyberButtonEndChat.TextButton = "Kết thúc đoạn Chat";
            cyberButtonEndChat.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            cyberButtonEndChat.Timer_Effect_1 = 5;
            cyberButtonEndChat.Timer_RGB = 300;
            // 
            // UC_EmployeeChat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cyberButtonEndChat);
            Controls.Add(buttonSendMessage);
            Controls.Add(textBoxMessage);
            Controls.Add(flowLayoutPanelMessage);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "UC_EmployeeChat";
            Size = new Size(772, 471);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel2;
        private Panel panel1;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanelMessage;
        private TextBox textBoxMessage;
        private Button buttonSendMessage;
        private ReaLTaiizor.Controls.CyberButton cyberButtonEndChat;
    }
}
