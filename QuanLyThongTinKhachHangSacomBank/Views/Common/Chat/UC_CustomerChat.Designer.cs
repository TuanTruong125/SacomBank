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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            panel2 = new Panel();
            panel1 = new Panel();
            label1 = new Label();
            textBoxTitle = new TextBox();
            buttonSendMessage = new Button();
            label2 = new Label();
            label3 = new Label();
            richTextBoxMessage = new RichTextBox();
            dataGridViewChat = new DataGridView();
            RequestID = new DataGridViewTextBoxColumn();
            Title = new DataGridViewTextBoxColumn();
            Message = new DataGridViewTextBoxColumn();
            RequestDate = new DataGridViewTextBoxColumn();
            HandledBy = new DataGridViewTextBoxColumn();
            RequestStatus = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridViewChat).BeginInit();
            SuspendLayout();
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
            label1.Location = new Point(316, 3);
            label1.Name = "label1";
            label1.Size = new Size(129, 28);
            label1.TabIndex = 12;
            label1.Text = "Tạo yêu cầu";
            // 
            // textBoxTitle
            // 
            textBoxTitle.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxTitle.Location = new Point(89, 57);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.PlaceholderText = "Nhập tiêu đề yêu cầu . . .";
            textBoxTitle.Size = new Size(680, 32);
            textBoxTitle.TabIndex = 16;
            // 
            // buttonSendMessage
            // 
            buttonSendMessage.BackColor = Color.Transparent;
            buttonSendMessage.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonSendMessage.ForeColor = SystemColors.HotTrack;
            buttonSendMessage.Image = (Image)resources.GetObject("buttonSendMessage.Image");
            buttonSendMessage.Location = new Point(280, 284);
            buttonSendMessage.Name = "buttonSendMessage";
            buttonSendMessage.Size = new Size(218, 51);
            buttonSendMessage.TabIndex = 17;
            buttonSendMessage.Text = "Gửi yêu cầu";
            buttonSendMessage.TextImageRelation = TextImageRelation.TextBeforeImage;
            buttonSendMessage.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Roboto SemiCondensed Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 60);
            label2.Name = "label2";
            label2.Size = new Size(86, 24);
            label2.TabIndex = 18;
            label2.Text = "Tiêu đề:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Roboto SemiCondensed Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(3, 92);
            label3.Name = "label3";
            label3.Size = new Size(100, 24);
            label3.TabIndex = 19;
            label3.Text = "Nội dung:";
            // 
            // richTextBoxMessage
            // 
            richTextBoxMessage.BorderStyle = BorderStyle.None;
            richTextBoxMessage.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBoxMessage.Location = new Point(3, 119);
            richTextBoxMessage.Name = "richTextBoxMessage";
            richTextBoxMessage.Size = new Size(766, 159);
            richTextBoxMessage.TabIndex = 20;
            richTextBoxMessage.Text = "";
            // 
            // dataGridViewChat
            // 
            dataGridViewChat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewChat.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewChat.BackgroundColor = Color.White;
            dataGridViewChat.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewChat.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle5.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dataGridViewChat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewChat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewChat.Columns.AddRange(new DataGridViewColumn[] { RequestID, Title, Message, RequestDate, HandledBy, RequestStatus });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dataGridViewChat.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewChat.EnableHeadersVisualStyles = false;
            dataGridViewChat.GridColor = Color.White;
            dataGridViewChat.Location = new Point(3, 341);
            dataGridViewChat.Name = "dataGridViewChat";
            dataGridViewChat.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewChat.RowHeadersVisible = false;
            dataGridViewChat.RowHeadersWidth = 51;
            dataGridViewChat.Size = new Size(766, 237);
            dataGridViewChat.TabIndex = 21;
            // 
            // RequestID
            // 
            RequestID.HeaderText = "Mã yêu cầu";
            RequestID.MinimumWidth = 6;
            RequestID.Name = "RequestID";
            RequestID.Width = 129;
            // 
            // Title
            // 
            Title.HeaderText = "Tiêu đề";
            Title.MinimumWidth = 6;
            Title.Name = "Title";
            Title.Width = 98;
            // 
            // Message
            // 
            Message.HeaderText = "Tin nhắn";
            Message.MinimumWidth = 6;
            Message.Name = "Message";
            Message.Width = 107;
            // 
            // RequestDate
            // 
            RequestDate.HeaderText = "Ngày yêu cầu";
            RequestDate.MinimumWidth = 6;
            RequestDate.Name = "RequestDate";
            RequestDate.Width = 145;
            // 
            // HandledBy
            // 
            HandledBy.HeaderText = "Nhân viên xử lý";
            HandledBy.MinimumWidth = 6;
            HandledBy.Name = "HandledBy";
            HandledBy.Width = 161;
            // 
            // RequestStatus
            // 
            RequestStatus.HeaderText = "Trạng thái";
            RequestStatus.MinimumWidth = 6;
            RequestStatus.Name = "RequestStatus";
            RequestStatus.Width = 119;
            // 
            // UC_CustomerChat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridViewChat);
            Controls.Add(richTextBoxMessage);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(buttonSendMessage);
            Controls.Add(textBoxTitle);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "UC_CustomerChat";
            Size = new Size(772, 581);
            ((System.ComponentModel.ISupportInitialize)dataGridViewChat).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel2;
        private Panel panel1;
        private Label label1;
        private TextBox textBoxTitle;
        private Button buttonSendMessage;
        private Label label2;
        private Label label3;
        private RichTextBox richTextBoxMessage;
        private DataGridView dataGridViewChat;
        private DataGridViewTextBoxColumn RequestID;
        private DataGridViewTextBoxColumn Title;
        private DataGridViewTextBoxColumn Message;
        private DataGridViewTextBoxColumn RequestDate;
        private DataGridViewTextBoxColumn HandledBy;
        private DataGridViewTextBoxColumn RequestStatus;
    }
}
