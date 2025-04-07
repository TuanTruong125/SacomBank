namespace QuanLyThongTinKhachHangSacomBank.Views.Customer
{
    partial class FormCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCustomer));
            panelMainContentCustomer = new Panel();
            pictureBoxNavigationCircle = new PictureBox();
            pictureBoxLogo = new PictureBox();
            panelLine2 = new Panel();
            buttonCustomerLogout = new Button();
            labelCustomer = new Label();
            panelLine1 = new Panel();
            panelNavigationBar = new Panel();
            buttonCustomerService = new Button();
            labelBank = new Label();
            buttonCustomerPersonal = new Button();
            buttonCustomerHome = new Button();
            panelMenu = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBoxNavigationCircle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelMainContentCustomer
            // 
            panelMainContentCustomer.Dock = DockStyle.Fill;
            panelMainContentCustomer.Location = new Point(282, 0);
            panelMainContentCustomer.Name = "panelMainContentCustomer";
            panelMainContentCustomer.Size = new Size(1132, 753);
            panelMainContentCustomer.TabIndex = 4;
            // 
            // pictureBoxNavigationCircle
            // 
            pictureBoxNavigationCircle.BackColor = Color.SkyBlue;
            pictureBoxNavigationCircle.Image = (Image)resources.GetObject("pictureBoxNavigationCircle.Image");
            pictureBoxNavigationCircle.Location = new Point(252, 120);
            pictureBoxNavigationCircle.Name = "pictureBoxNavigationCircle";
            pictureBoxNavigationCircle.Size = new Size(30, 63);
            pictureBoxNavigationCircle.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxNavigationCircle.TabIndex = 0;
            pictureBoxNavigationCircle.TabStop = false;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Image = (Image)resources.GetObject("pictureBoxLogo.Image");
            pictureBoxLogo.Location = new Point(102, 395);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(85, 79);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxLogo.TabIndex = 13;
            pictureBoxLogo.TabStop = false;
            // 
            // panelLine2
            // 
            panelLine2.BackColor = Color.White;
            panelLine2.Location = new Point(45, 314);
            panelLine2.Name = "panelLine2";
            panelLine2.Size = new Size(200, 5);
            panelLine2.TabIndex = 3;
            // 
            // buttonCustomerLogout
            // 
            buttonCustomerLogout.BackColor = Color.FromArgb(54, 116, 181);
            buttonCustomerLogout.FlatAppearance.BorderSize = 0;
            buttonCustomerLogout.FlatStyle = FlatStyle.Flat;
            buttonCustomerLogout.Font = new Font("Roboto SemiCondensed", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            buttonCustomerLogout.ForeColor = Color.Transparent;
            buttonCustomerLogout.Image = (Image)resources.GetObject("buttonCustomerLogout.Image");
            buttonCustomerLogout.Location = new Point(0, 325);
            buttonCustomerLogout.Name = "buttonCustomerLogout";
            buttonCustomerLogout.Size = new Size(282, 58);
            buttonCustomerLogout.TabIndex = 12;
            buttonCustomerLogout.Text = "     Đăng xuất";
            buttonCustomerLogout.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonCustomerLogout.UseVisualStyleBackColor = false;
            buttonCustomerLogout.Click += buttonCustomerLogout_Click;
            // 
            // labelCustomer
            // 
            labelCustomer.AutoSize = true;
            labelCustomer.Font = new Font("Roboto SemiCondensed", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            labelCustomer.ForeColor = Color.White;
            labelCustomer.Location = new Point(65, 58);
            labelCustomer.Name = "labelCustomer";
            labelCustomer.Size = new Size(156, 34);
            labelCustomer.TabIndex = 4;
            labelCustomer.Text = "Khách hàng";
            // 
            // panelLine1
            // 
            panelLine1.BackColor = Color.White;
            panelLine1.Location = new Point(46, 109);
            panelLine1.Name = "panelLine1";
            panelLine1.Size = new Size(200, 5);
            panelLine1.TabIndex = 2;
            // 
            // panelNavigationBar
            // 
            panelNavigationBar.BackColor = Color.Black;
            panelNavigationBar.Location = new Point(0, 120);
            panelNavigationBar.Name = "panelNavigationBar";
            panelNavigationBar.Size = new Size(10, 58);
            panelNavigationBar.TabIndex = 2;
            // 
            // buttonCustomerService
            // 
            buttonCustomerService.BackColor = Color.FromArgb(54, 116, 181);
            buttonCustomerService.FlatAppearance.BorderSize = 0;
            buttonCustomerService.FlatStyle = FlatStyle.Flat;
            buttonCustomerService.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            buttonCustomerService.ForeColor = Color.Transparent;
            buttonCustomerService.Image = (Image)resources.GetObject("buttonCustomerService.Image");
            buttonCustomerService.ImageAlign = ContentAlignment.MiddleLeft;
            buttonCustomerService.Location = new Point(3, 184);
            buttonCustomerService.Name = "buttonCustomerService";
            buttonCustomerService.Padding = new Padding(20, 0, 0, 0);
            buttonCustomerService.Size = new Size(282, 58);
            buttonCustomerService.TabIndex = 9;
            buttonCustomerService.Text = "   Dịch vụ";
            buttonCustomerService.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonCustomerService.UseVisualStyleBackColor = false;
            buttonCustomerService.Click += buttonCustomerService_Click;
            // 
            // labelBank
            // 
            labelBank.AutoSize = true;
            labelBank.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelBank.ForeColor = Color.Transparent;
            labelBank.Location = new Point(23, 9);
            labelBank.Name = "labelBank";
            labelBank.Size = new Size(223, 50);
            labelBank.TabIndex = 5;
            labelBank.Text = "Sacombank";
            // 
            // buttonCustomerPersonal
            // 
            buttonCustomerPersonal.BackColor = Color.FromArgb(54, 116, 181);
            buttonCustomerPersonal.FlatAppearance.BorderSize = 0;
            buttonCustomerPersonal.FlatStyle = FlatStyle.Flat;
            buttonCustomerPersonal.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            buttonCustomerPersonal.ForeColor = Color.Transparent;
            buttonCustomerPersonal.Image = (Image)resources.GetObject("buttonCustomerPersonal.Image");
            buttonCustomerPersonal.ImageAlign = ContentAlignment.MiddleLeft;
            buttonCustomerPersonal.Location = new Point(0, 248);
            buttonCustomerPersonal.Name = "buttonCustomerPersonal";
            buttonCustomerPersonal.Padding = new Padding(20, 0, 0, 0);
            buttonCustomerPersonal.Size = new Size(282, 58);
            buttonCustomerPersonal.TabIndex = 3;
            buttonCustomerPersonal.Text = "   Cá nhân";
            buttonCustomerPersonal.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonCustomerPersonal.UseVisualStyleBackColor = false;
            buttonCustomerPersonal.Click += buttonCustomerPersonal_Click;
            // 
            // buttonCustomerHome
            // 
            buttonCustomerHome.BackColor = Color.SkyBlue;
            buttonCustomerHome.FlatAppearance.BorderSize = 0;
            buttonCustomerHome.FlatStyle = FlatStyle.Flat;
            buttonCustomerHome.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            buttonCustomerHome.ForeColor = Color.Transparent;
            buttonCustomerHome.Image = (Image)resources.GetObject("buttonCustomerHome.Image");
            buttonCustomerHome.ImageAlign = ContentAlignment.MiddleLeft;
            buttonCustomerHome.Location = new Point(0, 120);
            buttonCustomerHome.Name = "buttonCustomerHome";
            buttonCustomerHome.Padding = new Padding(20, 0, 0, 0);
            buttonCustomerHome.Size = new Size(282, 58);
            buttonCustomerHome.TabIndex = 2;
            buttonCustomerHome.Text = "   Trang chủ";
            buttonCustomerHome.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonCustomerHome.UseVisualStyleBackColor = false;
            buttonCustomerHome.Click += buttonCustomerHome_Click;
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(54, 116, 181);
            panelMenu.Controls.Add(pictureBoxNavigationCircle);
            panelMenu.Controls.Add(pictureBoxLogo);
            panelMenu.Controls.Add(panelLine2);
            panelMenu.Controls.Add(buttonCustomerLogout);
            panelMenu.Controls.Add(labelCustomer);
            panelMenu.Controls.Add(panelLine1);
            panelMenu.Controls.Add(panelNavigationBar);
            panelMenu.Controls.Add(buttonCustomerService);
            panelMenu.Controls.Add(labelBank);
            panelMenu.Controls.Add(buttonCustomerPersonal);
            panelMenu.Controls.Add(buttonCustomerHome);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(282, 753);
            panelMenu.TabIndex = 3;
            // 
            // FormCustomer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1414, 753);
            Controls.Add(panelMainContentCustomer);
            Controls.Add(panelMenu);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1432, 800);
            Name = "FormCustomer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Khách hàng";
            Load += FormCustomer_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxNavigationCircle).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            panelMenu.ResumeLayout(false);
            panelMenu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMainContentCustomer;
        private PictureBox pictureBoxNavigationCircle;
        private PictureBox pictureBoxLogo;
        private Panel panelLine2;
        private Button buttonCustomerLogout;
        private Label labelCustomer;
        private Panel panelLine1;
        private Panel panelNavigationBar;
        private Button buttonCustomerService;
        private Label labelBank;
        private Button buttonCustomerPersonal;
        private Button buttonCustomerHome;
        private Panel panelMenu;
    }
}