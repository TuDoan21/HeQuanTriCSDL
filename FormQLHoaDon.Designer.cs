namespace QL_SuKienHoiNghi
{
    partial class FormQLHoaDon
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
            this.txtMaHDon = new System.Windows.Forms.TextBox();
            this.txtMaSK = new System.Windows.Forms.TextBox();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.cboMaHD = new System.Windows.Forms.ComboBox();
            this.cboLoaiHD = new System.Windows.Forms.ComboBox();
            this.dtpNgayLap = new System.Windows.Forms.DateTimePicker();
            this.txtMaNVKetoan = new System.Windows.Forms.TextBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMaHDon
            // 
            this.txtMaHDon.Location = new System.Drawing.Point(299, 70);
            this.txtMaHDon.Name = "txtMaHDon";
            this.txtMaHDon.Size = new System.Drawing.Size(245, 31);
            this.txtMaHDon.TabIndex = 0;
            // 
            // txtMaSK
            // 
            this.txtMaSK.Location = new System.Drawing.Point(299, 141);
            this.txtMaSK.Name = "txtMaSK";
            this.txtMaSK.Size = new System.Drawing.Size(245, 31);
            this.txtMaSK.TabIndex = 1;
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(299, 212);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(245, 31);
            this.txtTongTien.TabIndex = 2;
            // 
            // cboMaHD
            // 
            this.cboMaHD.FormattingEnabled = true;
            this.cboMaHD.Location = new System.Drawing.Point(652, 68);
            this.cboMaHD.Name = "cboMaHD";
            this.cboMaHD.Size = new System.Drawing.Size(288, 33);
            this.cboMaHD.TabIndex = 3;
            // 
            // cboLoaiHD
            // 
            this.cboLoaiHD.FormattingEnabled = true;
            this.cboLoaiHD.Location = new System.Drawing.Point(652, 141);
            this.cboLoaiHD.Name = "cboLoaiHD";
            this.cboLoaiHD.Size = new System.Drawing.Size(288, 33);
            this.cboLoaiHD.TabIndex = 4;
            // 
            // dtpNgayLap
            // 
            this.dtpNgayLap.Location = new System.Drawing.Point(652, 212);
            this.dtpNgayLap.Name = "dtpNgayLap";
            this.dtpNgayLap.Size = new System.Drawing.Size(288, 31);
            this.dtpNgayLap.TabIndex = 5;
            // 
            // txtMaNVKetoan
            // 
            this.txtMaNVKetoan.Location = new System.Drawing.Point(54, 68);
            this.txtMaNVKetoan.Name = "txtMaNVKetoan";
            this.txtMaNVKetoan.Size = new System.Drawing.Size(154, 31);
            this.txtMaNVKetoan.TabIndex = 6;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(54, 280);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(886, 31);
            this.txtGhiChu.TabIndex = 7;
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Location = new System.Drawing.Point(54, 340);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.RowHeadersWidth = 82;
            this.dgvHoaDon.RowTemplate.Height = 33;
            this.dgvHoaDon.Size = new System.Drawing.Size(1255, 513);
            this.dgvHoaDon.TabIndex = 8;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(1093, 68);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(86, 31);
            this.btnThem.TabIndex = 9;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(1093, 141);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(86, 31);
            this.btnXoa.TabIndex = 10;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(1093, 212);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(84, 31);
            this.btnSua.TabIndex = 11;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(1038, 282);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(86, 33);
            this.btnTim.TabIndex = 12;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(1159, 282);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(121, 29);
            this.btnLamMoi.TabIndex = 13;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // FormQLHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 891);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvHoaDon);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.txtMaNVKetoan);
            this.Controls.Add(this.dtpNgayLap);
            this.Controls.Add(this.cboLoaiHD);
            this.Controls.Add(this.cboMaHD);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.txtMaSK);
            this.Controls.Add(this.txtMaHDon);
            this.Name = "FormQLHoaDon";
            this.Text = "FormQLHoaDon";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaHDon;
        private System.Windows.Forms.TextBox txtMaSK;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.ComboBox cboMaHD;
        private System.Windows.Forms.ComboBox cboLoaiHD;
        private System.Windows.Forms.DateTimePicker dtpNgayLap;
        private System.Windows.Forms.TextBox txtMaNVKetoan;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Button btnLamMoi;
    }
}