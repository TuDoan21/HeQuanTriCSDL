namespace QL_SuKienHoiNghi
{
    partial class FormDangNhap
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.linkLblDangKy = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(26, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(520, 51);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "ĐĂNG NHẬP HỆ THỐNG";
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(30, 70);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(100, 23);
            this.lblEmail.TabIndex = 5;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(30, 90);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(399, 31);
            this.txtEmail.TabIndex = 4;
            // 
            // lblPass
            // 
            this.lblPass.Location = new System.Drawing.Point(30, 120);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(100, 23);
            this.lblPass.TabIndex = 3;
            this.lblPass.Text = "Mật khẩu:";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(30, 140);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(399, 31);
            this.txtMatKhau.TabIndex = 2;
            this.txtMatKhau.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(79, 192);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(280, 35);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Đăng Nhập";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // linkLblDangKy
            // 
            this.linkLblDangKy.AutoSize = true;
            this.linkLblDangKy.Location = new System.Drawing.Point(74, 230);
            this.linkLblDangKy.Name = "linkLblDangKy";
            this.linkLblDangKy.Size = new System.Drawing.Size(336, 25);
            this.linkLblDangKy.TabIndex = 0;
            this.linkLblDangKy.TabStop = true;
            this.linkLblDangKy.Text = "Chưa có tài khoản? Đăng ký ngay";
            this.linkLblDangKy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblDangKy_LinkClicked);
            // 
            // FormDangNhap
            // 
            this.ClientSize = new System.Drawing.Size(571, 309);
            this.Controls.Add(this.linkLblDangKy);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblTitle);
            this.Name = "FormDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel linkLblDangKy;
    }
}