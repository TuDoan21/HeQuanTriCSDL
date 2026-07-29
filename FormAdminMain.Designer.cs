namespace QL_SuKienHoiNghi
{
    partial class FormAdminMain
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.tabControlAdmin = new System.Windows.Forms.TabControl();

            // Khởi tạo 6 TabPage
            this.tabDichVu = new System.Windows.Forms.TabPage();
            this.tabNhanVien = new System.Windows.Forms.TabPage();
            this.tabKhachHang = new System.Windows.Forms.TabPage();
            this.tabHoaDon = new System.Windows.Forms.TabPage();
            this.tabPhanCong = new System.Windows.Forms.TabPage();
            this.tabBaoCao = new System.Windows.Forms.TabPage();

            this.pnlHeader.SuspendLayout();
            this.tabControlAdmin.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlHeader (Thanh trên cùng)
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlHeader.Controls.Add(this.btnDangXuat);
            this.pnlHeader.Controls.Add(this.lblUserInfo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(984, 50);
            this.pnlHeader.TabIndex = 0;

            // 
            // lblUserInfo
            // 
            this.lblUserInfo.AutoSize = true;
            this.lblUserInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserInfo.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblUserInfo.Location = new System.Drawing.Point(12, 15);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(76, 19);
            this.lblUserInfo.Text = "User Info";

            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDangXuat.BackColor = System.Drawing.Color.IndianRed;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangXuat.ForeColor = System.Drawing.Color.White;
            this.btnDangXuat.Location = new System.Drawing.Point(880, 10);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(92, 30);
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);

            // 
            // tabControlAdmin
            // 
            this.tabControlAdmin.Controls.Add(this.tabDichVu);
            this.tabControlAdmin.Controls.Add(this.tabNhanVien);
            this.tabControlAdmin.Controls.Add(this.tabKhachHang);
            this.tabControlAdmin.Controls.Add(this.tabHoaDon);
            this.tabControlAdmin.Controls.Add(this.tabPhanCong);
            this.tabControlAdmin.Controls.Add(this.tabBaoCao);
            this.tabControlAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlAdmin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlAdmin.ItemSize = new System.Drawing.Size(100, 30);
            this.tabControlAdmin.Location = new System.Drawing.Point(0, 50);
            this.tabControlAdmin.Name = "tabControlAdmin";
            this.tabControlAdmin.SelectedIndex = 0;
            this.tabControlAdmin.Size = new System.Drawing.Size(984, 611);
            this.tabControlAdmin.TabIndex = 1;

            // 1. Tab QL Dịch Vụ
            this.tabDichVu.Location = new System.Drawing.Point(4, 34);
            this.tabDichVu.Name = "tabDichVu";
            this.tabDichVu.Padding = new System.Windows.Forms.Padding(3);
            this.tabDichVu.Size = new System.Drawing.Size(976, 573);
            this.tabDichVu.Text = "QL Dịch Vụ";
            this.tabDichVu.UseVisualStyleBackColor = true;

            // 2. Tab QL Nhân Viên
            this.tabNhanVien.Location = new System.Drawing.Point(4, 34);
            this.tabNhanVien.Name = "tabNhanVien";
            this.tabNhanVien.Padding = new System.Windows.Forms.Padding(3);
            this.tabNhanVien.Size = new System.Drawing.Size(976, 573);
            this.tabNhanVien.Text = "QL Nhân Viên";
            this.tabNhanVien.UseVisualStyleBackColor = true;

            // 3. Tab QL Khách Hàng
            this.tabKhachHang.Location = new System.Drawing.Point(4, 34);
            this.tabKhachHang.Name = "tabKhachHang";
            this.tabKhachHang.Size = new System.Drawing.Size(976, 573);
            this.tabKhachHang.Text = "QL Khách Hàng";
            this.tabKhachHang.UseVisualStyleBackColor = true;

            // 4. Tab QL Hóa Đơn
            this.tabHoaDon.Location = new System.Drawing.Point(4, 34);
            this.tabHoaDon.Name = "tabHoaDon";
            this.tabHoaDon.Size = new System.Drawing.Size(976, 573);
            this.tabHoaDon.Text = "QL Hóa Đơn";
            this.tabHoaDon.UseVisualStyleBackColor = true;

            // 5. Tab Phân Công
            this.tabPhanCong.Location = new System.Drawing.Point(4, 34);
            this.tabPhanCong.Name = "tabPhanCong";
            this.tabPhanCong.Size = new System.Drawing.Size(976, 573);
            this.tabPhanCong.Text = "Phân Công";
            this.tabPhanCong.UseVisualStyleBackColor = true;

            // 6. Tab Báo Cáo
            this.tabBaoCao.Location = new System.Drawing.Point(4, 34);
            this.tabBaoCao.Name = "tabBaoCao";
            this.tabBaoCao.Size = new System.Drawing.Size(976, 573);
            this.tabBaoCao.Text = "Báo Cáo";
            this.tabBaoCao.UseVisualStyleBackColor = true;

            // 
            // FormAdminMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.tabControlAdmin);
            this.Controls.Add(this.pnlHeader);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Sự kiện & Hội nghị - Admin";

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tabControlAdmin.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.TabControl tabControlAdmin;

        // Khai báo 6 tab
        private System.Windows.Forms.TabPage tabDichVu;
        private System.Windows.Forms.TabPage tabNhanVien;
        private System.Windows.Forms.TabPage tabKhachHang;
        private System.Windows.Forms.TabPage tabHoaDon;
        private System.Windows.Forms.TabPage tabPhanCong;
        private System.Windows.Forms.TabPage tabBaoCao;
    }
}