namespace QL_SuKienHoiNghi
{
    partial class FormEventRegister
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
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.lblMaKHTC = new System.Windows.Forms.Label();
            this.lblLoaiHinh = new System.Windows.Forms.Label();
            this.txtLoaiHinh = new System.Windows.Forms.TextBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.numSoLuongKhach = new System.Windows.Forms.NumericUpDown();
            this.lblBatDau = new System.Windows.Forms.Label();
            this.dtpBatDau = new System.Windows.Forms.DateTimePicker();
            this.lblKetThuc = new System.Windows.Forms.Label();
            this.dtpKetThuc = new System.Windows.Forms.DateTimePicker();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.btnTroLai = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongKhach)).BeginInit();
            this.SuspendLayout();
            // 
            // grpInfo
            // 
            this.grpInfo.BackColor = System.Drawing.Color.White;
            this.grpInfo.Controls.Add(this.dtpKetThuc);
            this.grpInfo.Controls.Add(this.lblKetThuc);
            this.grpInfo.Controls.Add(this.dtpBatDau);
            this.grpInfo.Controls.Add(this.lblBatDau);
            this.grpInfo.Controls.Add(this.numSoLuongKhach);
            this.grpInfo.Controls.Add(this.lblSoLuong);
            this.grpInfo.Controls.Add(this.txtLoaiHinh);
            this.grpInfo.Controls.Add(this.lblLoaiHinh);
            this.grpInfo.Controls.Add(this.lblMaKHTC);
            this.grpInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpInfo.Location = new System.Drawing.Point(23, 62);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(387, 276);
            this.grpInfo.TabIndex = 0;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Thông tin sự kiện";
            // 
            // lblMaKHTC
            // 
            this.lblMaKHTC.AutoSize = true;
            this.lblMaKHTC.Font = new System.Drawing.Font("Segoe UI", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaKHTC.ForeColor = System.Drawing.Color.DimGray;
            this.lblMaKHTC.Location = new System.Drawing.Point(22, 32);
            this.lblMaKHTC.Name = "lblMaKHTC";
            this.lblMaKHTC.Size = new System.Drawing.Size(127, 19);
            this.lblMaKHTC.TabIndex = 0;
            this.lblMaKHTC.Text = "Khách hàng: N/A";
            // 
            // lblLoaiHinh
            // 
            this.lblLoaiHinh.AutoSize = true;
            this.lblLoaiHinh.Location = new System.Drawing.Point(22, 69);
            this.lblLoaiHinh.Name = "lblLoaiHinh";
            this.lblLoaiHinh.Size = new System.Drawing.Size(183, 19);
            this.lblLoaiHinh.TabIndex = 1;
            this.lblLoaiHinh.Text = "Loại hình sự kiện (Hội thảo...)";
            // 
            // txtLoaiHinh
            // 
            this.txtLoaiHinh.Location = new System.Drawing.Point(26, 91);
            this.txtLoaiHinh.Name = "txtLoaiHinh";
            this.txtLoaiHinh.Size = new System.Drawing.Size(335, 25);
            this.txtLoaiHinh.TabIndex = 2;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(22, 131);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(128, 19);
            this.lblSoLuong.TabIndex = 3;
            this.lblSoLuong.Text = "Số lượng khách mời";
            // 
            // numSoLuongKhach
            // 
            this.numSoLuongKhach.Location = new System.Drawing.Point(26, 153);
            this.numSoLuongKhach.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numSoLuongKhach.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numSoLuongKhach.Name = "numSoLuongKhach";
            this.numSoLuongKhach.Size = new System.Drawing.Size(147, 25);
            this.numSoLuongKhach.TabIndex = 4;
            this.numSoLuongKhach.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // lblBatDau
            // 
            this.lblBatDau.AutoSize = true;
            this.lblBatDau.Location = new System.Drawing.Point(22, 196);
            this.lblBatDau.Name = "lblBatDau";
            this.lblBatDau.Size = new System.Drawing.Size(92, 19);
            this.lblBatDau.TabIndex = 5;
            this.lblBatDau.Text = "Ngày bắt đầu";
            // 
            // dtpBatDau
            // 
            this.dtpBatDau.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBatDau.Location = new System.Drawing.Point(26, 218);
            this.dtpBatDau.Name = "dtpBatDau";
            this.dtpBatDau.Size = new System.Drawing.Size(147, 25);
            this.dtpBatDau.TabIndex = 6;
            // 
            // lblKetThuc
            // 
            this.lblKetThuc.AutoSize = true;
            this.lblKetThuc.Location = new System.Drawing.Point(210, 196);
            this.lblKetThuc.Name = "lblKetThuc";
            this.lblKetThuc.Size = new System.Drawing.Size(95, 19);
            this.lblKetThuc.TabIndex = 7;
            this.lblKetThuc.Text = "Ngày kết thúc";
            // 
            // dtpKetThuc
            // 
            this.dtpKetThuc.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpKetThuc.Location = new System.Drawing.Point(214, 218);
            this.dtpKetThuc.Name = "dtpKetThuc";
            this.dtpKetThuc.Size = new System.Drawing.Size(147, 25);
            this.dtpKetThuc.TabIndex = 8;
            // 
            // btnDangKy
            // 
            this.btnDangKy.BackColor = System.Drawing.Color.Goldenrod;
            this.btnDangKy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangKy.FlatAppearance.BorderSize = 0;
            this.btnDangKy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangKy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangKy.ForeColor = System.Drawing.Color.White;
            this.btnDangKy.Location = new System.Drawing.Point(227, 354);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(183, 39);
            this.btnDangKy.TabIndex = 1;
            this.btnDangKy.Text = "Xác nhận Đăng ký";
            this.btnDangKy.UseVisualStyleBackColor = false;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // btnTroLai
            // 
            this.btnTroLai.BackColor = System.Drawing.Color.Gray;
            this.btnTroLai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTroLai.FlatAppearance.BorderSize = 0;
            this.btnTroLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTroLai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTroLai.ForeColor = System.Drawing.Color.White;
            this.btnTroLai.Location = new System.Drawing.Point(23, 354);
            this.btnTroLai.Name = "btnTroLai";
            this.btnTroLai.Size = new System.Drawing.Size(100, 39);
            this.btnTroLai.TabIndex = 2;
            this.btnTroLai.Text = "Quay lại";
            this.btnTroLai.UseVisualStyleBackColor = false;
            this.btnTroLai.Click += new System.EventHandler(this.btnTroLai_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(107, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(212, 30);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "ĐĂNG KÝ SỰ KIỆN";
            // 
            // FormEventRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(434, 417);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnTroLai);
            this.Controls.Add(this.btnDangKy);
            this.Controls.Add(this.grpInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormEventRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng ký Tổ chức Sự kiện";
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongKhach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Label lblMaKHTC;
        private System.Windows.Forms.Label lblLoaiHinh;
        private System.Windows.Forms.TextBox txtLoaiHinh;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.NumericUpDown numSoLuongKhach;
        private System.Windows.Forms.Label lblBatDau;
        private System.Windows.Forms.DateTimePicker dtpBatDau;
        private System.Windows.Forms.Label lblKetThuc;
        private System.Windows.Forms.DateTimePicker dtpKetThuc;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Button btnTroLai;
        private System.Windows.Forms.Label lblTitle;
    }
}