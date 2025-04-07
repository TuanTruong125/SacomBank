namespace QuanLyThongTinKhachHangSacomBank.Views.Common.Notification
{
    partial class UC_EmployeeNotification
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            richTextBoxMessage = new RichTextBox();
            label2 = new Label();
            textBoxTitle = new TextBox();
            label1 = new Label();
            labelPay = new Label();
            dataGridViewNotification = new DataGridView();
            NotificationTypeName = new DataGridViewTextBoxColumn();
            Title = new DataGridViewTextBoxColumn();
            Message = new DataGridViewTextBoxColumn();
            NotificationDate = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridViewNotification).BeginInit();
            SuspendLayout();
            // 
            // richTextBoxMessage
            // 
            richTextBoxMessage.BorderStyle = BorderStyle.None;
            richTextBoxMessage.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBoxMessage.Location = new Point(4, 133);
            richTextBoxMessage.Name = "richTextBoxMessage";
            richTextBoxMessage.ReadOnly = true;
            richTextBoxMessage.Size = new Size(1047, 107);
            richTextBoxMessage.TabIndex = 200;
            richTextBoxMessage.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Roboto SemiCondensed Medium", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(2, 102);
            label2.Name = "label2";
            label2.Size = new Size(114, 28);
            label2.TabIndex = 199;
            label2.Text = "Nội dung:";
            // 
            // textBoxTitle
            // 
            textBoxTitle.Font = new Font("Roboto SemiCondensed Medium", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxTitle.Location = new Point(108, 47);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.ReadOnly = true;
            textBoxTitle.Size = new Size(943, 35);
            textBoxTitle.TabIndex = 198;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Roboto SemiCondensed Medium", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(2, 50);
            label1.Name = "label1";
            label1.Size = new Size(100, 28);
            label1.TabIndex = 197;
            label1.Text = "Tiêu đề:";
            // 
            // labelPay
            // 
            labelPay.AutoSize = true;
            labelPay.Font = new Font("Roboto SemiCondensed", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPay.ForeColor = SystemColors.HotTrack;
            labelPay.Location = new Point(349, 3);
            labelPay.Name = "labelPay";
            labelPay.Size = new Size(318, 41);
            labelPay.TabIndex = 196;
            labelPay.Text = "Thông báo nhân viên";
            // 
            // dataGridViewNotification
            // 
            dataGridViewNotification.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewNotification.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewNotification.BackgroundColor = Color.White;
            dataGridViewNotification.BorderStyle = BorderStyle.None;
            dataGridViewNotification.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewNotification.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new Font("Roboto SemiCondensed Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridViewNotification.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewNotification.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewNotification.Columns.AddRange(new DataGridViewColumn[] { NotificationTypeName, Title, Message, NotificationDate, Status });
            dataGridViewNotification.EnableHeadersVisualStyles = false;
            dataGridViewNotification.GridColor = Color.White;
            dataGridViewNotification.Location = new Point(4, 246);
            dataGridViewNotification.Name = "dataGridViewNotification";
            dataGridViewNotification.ReadOnly = true;
            dataGridViewNotification.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewNotification.RowHeadersVisible = false;
            dataGridViewNotification.RowHeadersWidth = 51;
            dataGridViewNotification.Size = new Size(1047, 234);
            dataGridViewNotification.TabIndex = 195;
            // 
            // NotificationTypeName
            // 
            NotificationTypeName.HeaderText = "Loại thông báo";
            NotificationTypeName.MinimumWidth = 6;
            NotificationTypeName.Name = "NotificationTypeName";
            NotificationTypeName.ReadOnly = true;
            // 
            // Title
            // 
            Title.HeaderText = "Tiêu đề";
            Title.MinimumWidth = 6;
            Title.Name = "Title";
            Title.ReadOnly = true;
            // 
            // Message
            // 
            Message.HeaderText = "Tin nhắn";
            Message.MinimumWidth = 6;
            Message.Name = "Message";
            Message.ReadOnly = true;
            // 
            // NotificationDate
            // 
            NotificationDate.HeaderText = "Ngày thông báo";
            NotificationDate.MinimumWidth = 6;
            NotificationDate.Name = "NotificationDate";
            NotificationDate.ReadOnly = true;
            // 
            // Status
            // 
            Status.HeaderText = "Trạng thái";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            Status.ReadOnly = true;
            // 
            // UC_EmployeeNotification
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(richTextBoxMessage);
            Controls.Add(label2);
            Controls.Add(textBoxTitle);
            Controls.Add(label1);
            Controls.Add(labelPay);
            Controls.Add(dataGridViewNotification);
            Name = "UC_EmployeeNotification";
            Size = new Size(1053, 483);
            ((System.ComponentModel.ISupportInitialize)dataGridViewNotification).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBoxMessage;
        private Label label2;
        private TextBox textBoxTitle;
        private Label label1;
        private Label labelPay;
        private DataGridView dataGridViewNotification;
        private DataGridViewTextBoxColumn NotificationTypeName;
        private DataGridViewTextBoxColumn Title;
        private DataGridViewTextBoxColumn Message;
        private DataGridViewTextBoxColumn NotificationDate;
        private DataGridViewTextBoxColumn Status;
    }
}
