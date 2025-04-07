namespace QuanLyThongTinKhachHangSacomBank.Views.Common.Chat
{
    partial class UC_ChatBot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_ChatBot));
            buttonSendMessage = new Button();
            textBoxMessage = new TextBox();
            flowLayoutPanelMessage = new FlowLayoutPanel();
            panel2 = new Panel();
            panel1 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // buttonSendMessage
            // 
            buttonSendMessage.BackColor = Color.Transparent;
            buttonSendMessage.Image = (Image)resources.GetObject("buttonSendMessage.Image");
            buttonSendMessage.Location = new Point(734, 435);
            buttonSendMessage.Name = "buttonSendMessage";
            buttonSendMessage.Size = new Size(35, 32);
            buttonSendMessage.TabIndex = 23;
            buttonSendMessage.UseVisualStyleBackColor = false;
            // 
            // textBoxMessage
            // 
            textBoxMessage.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxMessage.Location = new Point(3, 435);
            textBoxMessage.Name = "textBoxMessage";
            textBoxMessage.PlaceholderText = "Nhập tin nhắn . . .";
            textBoxMessage.Size = new Size(725, 32);
            textBoxMessage.TabIndex = 22;
            // 
            // flowLayoutPanelMessage
            // 
            flowLayoutPanelMessage.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanelMessage.Location = new Point(3, 43);
            flowLayoutPanelMessage.Name = "flowLayoutPanelMessage";
            flowLayoutPanelMessage.Size = new Size(766, 386);
            flowLayoutPanelMessage.TabIndex = 21;
            // 
            // panel2
            // 
            panel2.BackColor = Color.LightSeaGreen;
            panel2.Location = new Point(71, 16);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 5);
            panel2.TabIndex = 20;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSeaGreen;
            panel1.Location = new Point(495, 16);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 5);
            panel1.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Roboto SemiCondensed", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(298, 3);
            label1.Name = "label1";
            label1.Size = new Size(112, 28);
            label1.TabIndex = 18;
            label1.Text = "SacomBot";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(416, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(55, 37);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 24;
            pictureBox1.TabStop = false;
            // 
            // UC_ChatBot
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBox1);
            Controls.Add(buttonSendMessage);
            Controls.Add(textBoxMessage);
            Controls.Add(flowLayoutPanelMessage);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "UC_ChatBot";
            Size = new Size(772, 471);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private PictureBox pictureBox1;
    }
}
