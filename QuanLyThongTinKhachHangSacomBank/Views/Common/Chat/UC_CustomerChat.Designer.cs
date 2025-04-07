namespace QuanLyThongTinKhachHangSacomBank.Views.Common.Chat
{
    partial class UC_CustomerChat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_CustomerChat));
            buttonSendMessage = new Button();
            textBoxMessage = new TextBox();
            flowLayoutPanelMessage = new FlowLayoutPanel();
            panel2 = new Panel();
            panel1 = new Panel();
            label1 = new Label();
            cyberButtonEndChat = new ReaLTaiizor.Controls.CyberButton();
            SuspendLayout();
            // 
            // buttonSendMessage
            // 
            buttonSendMessage.BackColor = Color.Transparent;
            buttonSendMessage.Image = (Image)resources.GetObject("buttonSendMessage.Image");
            buttonSendMessage.Location = new Point(734, 381);
            buttonSendMessage.Name = "buttonSendMessage";
            buttonSendMessage.Size = new Size(35, 32);
            buttonSendMessage.TabIndex = 17;
            buttonSendMessage.UseVisualStyleBackColor = false;
            // 
            // textBoxMessage
            // 
            textBoxMessage.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxMessage.Location = new Point(3, 381);
            textBoxMessage.Name = "textBoxMessage";
            textBoxMessage.PlaceholderText = "Nhập tin nhắn . . .";
            textBoxMessage.Size = new Size(725, 32);
            textBoxMessage.TabIndex = 16;
            // 
            // flowLayoutPanelMessage
            // 
            flowLayoutPanelMessage.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanelMessage.Location = new Point(3, 34);
            flowLayoutPanelMessage.Name = "flowLayoutPanelMessage";
            flowLayoutPanelMessage.Size = new Size(766, 341);
            flowLayoutPanelMessage.TabIndex = 15;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.HotTrack;
            panel2.Location = new Point(71, 16);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 5);
            panel2.TabIndex = 14;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.HotTrack;
            panel1.Location = new Point(495, 16);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 5);
            panel1.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Roboto SemiCondensed", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(286, 3);
            label1.Name = "label1";
            label1.Size = new Size(194, 28);
            label1.TabIndex = 12;
            label1.Text = "Chat với nhân viên";
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
            cyberButtonEndChat.Location = new Point(286, 419);
            cyberButtonEndChat.Name = "cyberButtonEndChat";
            cyberButtonEndChat.PenWidth = 15;
            cyberButtonEndChat.Rounding = true;
            cyberButtonEndChat.RoundingInt = 70;
            cyberButtonEndChat.Size = new Size(220, 49);
            cyberButtonEndChat.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberButtonEndChat.TabIndex = 177;
            cyberButtonEndChat.Tag = "Cyber";
            cyberButtonEndChat.TextButton = "Kết thúc đoạn Chat";
            cyberButtonEndChat.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            cyberButtonEndChat.Timer_Effect_1 = 5;
            cyberButtonEndChat.Timer_RGB = 300;
            // 
            // UC_CustomerChat
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
            Name = "UC_CustomerChat";
            Size = new Size(772, 471);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonSendMessage;
        private TextBox textBoxMessage;
        private FlowLayoutPanel flowLayoutPanelMessage;
        private Panel panel2;
        private Panel panel1;
        private Label label1;
        private ReaLTaiizor.Controls.CyberButton cyberButtonEndChat;
    }
}
