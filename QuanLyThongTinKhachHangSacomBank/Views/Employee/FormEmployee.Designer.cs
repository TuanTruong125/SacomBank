using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyThongTinKhachHangSacomBank.Views.Employee
{
    partial class FormEmployee
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEmployee));
            panelMenu = new Panel();
            pictureBoxNavigationCircle = new PictureBox();
            pictureBoxLogo = new PictureBox();
            panelLine2 = new Panel();
            buttonLogout = new Button();
            labelEmployee = new Label();
            panelLine1 = new Panel();
            buttonCustomerCare = new Button();
            buttonTransactionManagement = new Button();
            panelNavigationBar = new Panel();
            buttonServiceManagement = new Button();
            buttonAccountManagement = new Button();
            labelBank = new Label();
            buttonSetting = new Button();
            buttonCustomerManagement = new Button();
            buttonHome = new Button();
            panelMainContentEmployee = new Panel();
            panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxNavigationCircle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(54, 116, 181);
            panelMenu.Controls.Add(pictureBoxNavigationCircle);
            panelMenu.Controls.Add(pictureBoxLogo);
            panelMenu.Controls.Add(panelLine2);
            panelMenu.Controls.Add(buttonLogout);
            panelMenu.Controls.Add(labelEmployee);
            panelMenu.Controls.Add(panelLine1);
            panelMenu.Controls.Add(buttonCustomerCare);
            panelMenu.Controls.Add(buttonTransactionManagement);
            panelMenu.Controls.Add(panelNavigationBar);
            panelMenu.Controls.Add(buttonServiceManagement);
            panelMenu.Controls.Add(buttonAccountManagement);
            panelMenu.Controls.Add(labelBank);
            panelMenu.Controls.Add(buttonSetting);
            panelMenu.Controls.Add(buttonCustomerManagement);
            panelMenu.Controls.Add(buttonHome);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(282, 753);
            panelMenu.TabIndex = 0;
            // 
            // pictureBoxNavigationCircle
            // 
            pictureBoxNavigationCircle.BackColor = Color.FromArgb(109, 232, 157);
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
            pictureBoxLogo.Location = new Point(102, 662);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(85, 79);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxLogo.TabIndex = 13;
            pictureBoxLogo.TabStop = false;
            // 
            // panelLine2
            // 
            panelLine2.BackColor = Color.White;
            panelLine2.Location = new Point(45, 581);
            panelLine2.Name = "panelLine2";
            panelLine2.Size = new Size(200, 5);
            panelLine2.TabIndex = 3;
            // 
            // buttonLogout
            // 
            buttonLogout.BackColor = Color.FromArgb(54, 116, 181);
            buttonLogout.FlatAppearance.BorderSize = 0;
            buttonLogout.FlatStyle = FlatStyle.Flat;
            buttonLogout.Font = new Font("Roboto SemiCondensed", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            buttonLogout.ForeColor = Color.Transparent;
            buttonLogout.Image = (Image)resources.GetObject("buttonLogout.Image");
            buttonLogout.Location = new Point(0, 592);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new Size(282, 58);
            buttonLogout.TabIndex = 12;
            buttonLogout.Text = "     Đăng xuất";
            buttonLogout.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonLogout.UseVisualStyleBackColor = false;
            buttonLogout.Click += buttonLogout_Click;
            // 
            // labelEmployee
            // 
            labelEmployee.AutoSize = true;
            labelEmployee.Font = new Font("Roboto SemiCondensed", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            labelEmployee.ForeColor = Color.White;
            labelEmployee.Location = new Point(65, 58);
            labelEmployee.Name = "labelEmployee";
            labelEmployee.Size = new Size(133, 34);
            labelEmployee.TabIndex = 4;
            labelEmployee.Text = "Nhân viên";
            // 
            // panelLine1
            // 
            panelLine1.BackColor = Color.White;
            panelLine1.Location = new Point(46, 109);
            panelLine1.Name = "panelLine1";
            panelLine1.Size = new Size(200, 5);
            panelLine1.TabIndex = 2;
            // 
            // buttonCustomerCare
            // 
            buttonCustomerCare.BackColor = Color.FromArgb(54, 116, 181);
            buttonCustomerCare.FlatAppearance.BorderSize = 0;
            buttonCustomerCare.FlatStyle = FlatStyle.Flat;
            buttonCustomerCare.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            buttonCustomerCare.ForeColor = Color.Transparent;
            buttonCustomerCare.Image = (Image)resources.GetObject("buttonCustomerCare.Image");
            buttonCustomerCare.ImageAlign = ContentAlignment.MiddleLeft;
            buttonCustomerCare.Location = new Point(0, 440);
            buttonCustomerCare.Name = "buttonCustomerCare";
            buttonCustomerCare.Padding = new Padding(20, 0, 0, 0);
            buttonCustomerCare.Size = new Size(282, 58);
            buttonCustomerCare.TabIndex = 11;
            buttonCustomerCare.Text = "   Chăm sóc khách hàng";
            buttonCustomerCare.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonCustomerCare.UseVisualStyleBackColor = false;
            buttonCustomerCare.Click += buttonCustomerCare_Click;
            // 
            // buttonTransactionManagement
            // 
            buttonTransactionManagement.BackColor = Color.FromArgb(54, 116, 181);
            buttonTransactionManagement.FlatAppearance.BorderSize = 0;
            buttonTransactionManagement.FlatStyle = FlatStyle.Flat;
            buttonTransactionManagement.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            buttonTransactionManagement.ForeColor = Color.Transparent;
            buttonTransactionManagement.Image = (Image)resources.GetObject("buttonTransactionManagement.Image");
            buttonTransactionManagement.ImageAlign = ContentAlignment.MiddleLeft;
            buttonTransactionManagement.Location = new Point(0, 376);
            buttonTransactionManagement.Name = "buttonTransactionManagement";
            buttonTransactionManagement.Padding = new Padding(20, 0, 0, 0);
            buttonTransactionManagement.Size = new Size(282, 58);
            buttonTransactionManagement.TabIndex = 10;
            buttonTransactionManagement.Text = "   Quản lý giao dịch";
            buttonTransactionManagement.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonTransactionManagement.UseVisualStyleBackColor = false;
            buttonTransactionManagement.Click += buttonTransactionManagement_Click;
            // 
            // panelNavigationBar
            // 
            panelNavigationBar.BackColor = Color.Black;
            panelNavigationBar.Location = new Point(0, 120);
            panelNavigationBar.Name = "panelNavigationBar";
            panelNavigationBar.Size = new Size(10, 58);
            panelNavigationBar.TabIndex = 2;
            // 
            // buttonServiceManagement
            // 
            buttonServiceManagement.BackColor = Color.FromArgb(54, 116, 181);
            buttonServiceManagement.FlatAppearance.BorderSize = 0;
            buttonServiceManagement.FlatStyle = FlatStyle.Flat;
            buttonServiceManagement.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            buttonServiceManagement.ForeColor = Color.Transparent;
            buttonServiceManagement.Image = (Image)resources.GetObject("buttonServiceManagement.Image");
            buttonServiceManagement.ImageAlign = ContentAlignment.MiddleLeft;
            buttonServiceManagement.Location = new Point(0, 312);
            buttonServiceManagement.Name = "buttonServiceManagement";
            buttonServiceManagement.Padding = new Padding(20, 0, 0, 0);
            buttonServiceManagement.Size = new Size(282, 58);
            buttonServiceManagement.TabIndex = 9;
            buttonServiceManagement.Text = "   Quản lý dịch vụ";
            buttonServiceManagement.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonServiceManagement.UseVisualStyleBackColor = false;
            buttonServiceManagement.Click += buttonServiceManagement_Click;
            // 
            // buttonAccountManagement
            // 
            buttonAccountManagement.BackColor = Color.FromArgb(54, 116, 181);
            buttonAccountManagement.FlatAppearance.BorderSize = 0;
            buttonAccountManagement.FlatStyle = FlatStyle.Flat;
            buttonAccountManagement.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            buttonAccountManagement.ForeColor = Color.Transparent;
            buttonAccountManagement.Image = (Image)resources.GetObject("buttonAccountManagement.Image");
            buttonAccountManagement.ImageAlign = ContentAlignment.MiddleLeft;
            buttonAccountManagement.Location = new Point(0, 248);
            buttonAccountManagement.Name = "buttonAccountManagement";
            buttonAccountManagement.Padding = new Padding(20, 0, 0, 0);
            buttonAccountManagement.Size = new Size(282, 58);
            buttonAccountManagement.TabIndex = 8;
            buttonAccountManagement.Text = "   Quản lý tài khoản";
            buttonAccountManagement.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonAccountManagement.UseVisualStyleBackColor = false;
            buttonAccountManagement.Click += buttonAccountManagement_Click;
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
            // buttonSetting
            // 
            buttonSetting.BackColor = Color.FromArgb(54, 116, 181);
            buttonSetting.FlatAppearance.BorderSize = 0;
            buttonSetting.FlatStyle = FlatStyle.Flat;
            buttonSetting.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            buttonSetting.ForeColor = Color.Transparent;
            buttonSetting.Image = (Image)resources.GetObject("buttonSetting.Image");
            buttonSetting.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSetting.Location = new Point(0, 504);
            buttonSetting.Name = "buttonSetting";
            buttonSetting.Padding = new Padding(20, 0, 0, 0);
            buttonSetting.Size = new Size(282, 58);
            buttonSetting.TabIndex = 7;
            buttonSetting.Text = "   Cài đặt";
            buttonSetting.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonSetting.UseVisualStyleBackColor = false;
            buttonSetting.Click += buttonSetting_Click;
            // 
            // buttonCustomerManagement
            // 
            buttonCustomerManagement.BackColor = Color.FromArgb(54, 116, 181);
            buttonCustomerManagement.FlatAppearance.BorderSize = 0;
            buttonCustomerManagement.FlatStyle = FlatStyle.Flat;
            buttonCustomerManagement.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            buttonCustomerManagement.ForeColor = Color.Transparent;
            buttonCustomerManagement.Image = (Image)resources.GetObject("buttonCustomerManagement.Image");
            buttonCustomerManagement.ImageAlign = ContentAlignment.MiddleLeft;
            buttonCustomerManagement.Location = new Point(0, 184);
            buttonCustomerManagement.Name = "buttonCustomerManagement";
            buttonCustomerManagement.Padding = new Padding(20, 0, 0, 0);
            buttonCustomerManagement.Size = new Size(282, 58);
            buttonCustomerManagement.TabIndex = 3;
            buttonCustomerManagement.Text = "   Quản lý khách hàng";
            buttonCustomerManagement.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonCustomerManagement.UseVisualStyleBackColor = false;
            buttonCustomerManagement.Click += buttonCustomerManagement_Click;
            // 
            // buttonHome
            // 
            buttonHome.BackColor = Color.MediumAquamarine;
            buttonHome.FlatAppearance.BorderSize = 0;
            buttonHome.FlatStyle = FlatStyle.Flat;
            buttonHome.Font = new Font("Roboto SemiCondensed", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            buttonHome.ForeColor = Color.Transparent;
            buttonHome.Image = (Image)resources.GetObject("buttonHome.Image");
            buttonHome.ImageAlign = ContentAlignment.MiddleLeft;
            buttonHome.Location = new Point(0, 120);
            buttonHome.Name = "buttonHome";
            buttonHome.Padding = new Padding(20, 0, 0, 0);
            buttonHome.Size = new Size(282, 58);
            buttonHome.TabIndex = 2;
            buttonHome.Text = "   Trang chủ";
            buttonHome.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonHome.UseVisualStyleBackColor = false;
            buttonHome.Click += buttonHome_Click;
            // 
            // panelMainContentEmployee
            // 
            panelMainContentEmployee.Dock = DockStyle.Fill;
            panelMainContentEmployee.Location = new Point(282, 0);
            panelMainContentEmployee.Name = "panelMainContentEmployee";
            panelMainContentEmployee.Size = new Size(1132, 753);
            panelMainContentEmployee.TabIndex = 2;
            // 
            // FormEmployee
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1414, 753);
            Controls.Add(panelMainContentEmployee);
            Controls.Add(panelMenu);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1432, 800);
            Name = "FormEmployee";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nhân viên";
            Load += FormEmployee_Load;
            panelMenu.ResumeLayout(false);
            panelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxNavigationCircle).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private Button buttonHome;
        private Button buttonCustomerManagement;
        private Button buttonSetting;
        private Panel panelNavigationBar;
        private Label labelBank;
        private Panel panelLine1;
        private Label labelEmployee;
        private Button buttonAccountManagement;
        private Button buttonTransactionManagement;
        private Button buttonServiceManagement;
        private Button buttonCustomerCare;
        private Button buttonLogout;
        private Panel panelLine2;
        private Panel panelMainContentEmployee;
        private PictureBox pictureBoxLogo;
        private PictureBox pictureBoxNavigationCircle;
    }
}
