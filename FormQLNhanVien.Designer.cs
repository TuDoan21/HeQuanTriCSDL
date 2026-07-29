namespace QL_SuKienHoiNghi
{
    partial class FormQLNhanVien
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.numHeSo = new System.Windows.Forms.NumericUpDown();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThemNV = new System.Windows.Forms.Button();
            this.txtChucVu = new System.Windows.Forms.TextBox();
            this.lblChucVu = new System.Windows.Forms.Label();
            this.lblHeSo = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.pnlFill = new System.Windows.Forms.Panel();
            this.grpDanhSach = new System.Windows.Forms.GroupBox();
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.pnlLeft.SuspendLayout();
            this.grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHeSo)).BeginInit();
            this.pnlFill.SuspendLayout();
            this.grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlLeft.Controls.Add(this.grpThongTin);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(6);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(20, 19, 20, 19);
            this.pnlLeft.Size = new System.Drawing.Size(700, 889);
            this.pnlLeft.TabIndex = 0;
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.lblNote);
            this.grpThongTin.Controls.Add(this.numHeSo);
            this.grpThongTin.Controls.Add(this.btnLamMoi);
            this.grpThongTin.Controls.Add(this.btnXoa);
            this.grpThongTin.Controls.Add(this.btnSua);
            this.grpThongTin.Controls.Add(this.btnThemNV);
            this.grpThongTin.Controls.Add(this.txtChucVu);
            this.grpThongTin.Controls.Add(this.lblChucVu);
            this.grpThongTin.Controls.Add(this.lblHeSo);
            this.grpThongTin.Controls.Add(this.txtSDT);
            this.grpThongTin.Controls.Add(this.lblSDT);
            this.grpThongTin.Controls.Add(this.txtEmail);
            this.grpThongTin.Controls.Add(this.lblEmail);
            this.grpThongTin.Controls.Add(this.txtHoTen);
            this.grpThongTin.Controls.Add(this.lblHoTen);
            this.grpThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpThongTin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpThongTin.Location = new System.Drawing.Point(20, 19);
            this.grpThongTin.Margin = new System.Windows.Forms.Padding(6);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Padding = new System.Windows.Forms.Padding(6);
            this.grpThongTin.Size = new System.Drawing.Size(660, 851);
            this.grpThongTin.TabIndex = 0;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông Tin Nhân Viên";
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.ForeColor = System.Drawing.Color.DimGray;
            this.lblNote.Location = new System.Drawing.Point(34, 250);
            this.lblNote.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(544, 31);
            this.lblNote.TabIndex = 14;
            this.lblNote.Text = "* Mật khẩu mặc định khi tạo mới tài khoản là: 123456";
            // 
            // numHeSo
            // 
            this.numHeSo.DecimalPlaces = 2;
            this.numHeSo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numHeSo.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numHeSo.Location = new System.Drawing.Point(40, 559);
            this.numHeSo.Margin = new System.Windows.Forms.Padding(6);
            this.numHeSo.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numHeSo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHeSo.Name = "numHeSo";
            this.numHeSo.Size = new System.Drawing.Size(578, 43);
            this.numHeSo.TabIndex = 4;
            this.numHeSo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.LightGray;
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.Location = new System.Drawing.Point(346, 737);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(6);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(274, 67);
            this.btnLamMoi.TabIndex = 8;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.IndianRed;
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(40, 737);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(6);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(274, 67);
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Text = "Xóa NV";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.Goldenrod;
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(346, 634);
            this.btnSua.Margin = new System.Windows.Forms.Padding(6);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(274, 67);
            this.btnSua.TabIndex = 6;
            this.btnSua.Text = "Cập nhật";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThemNV
            // 
            this.btnThemNV.BackColor = System.Drawing.Color.SeaGreen;
            this.btnThemNV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemNV.FlatAppearance.BorderSize = 0;
            this.btnThemNV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemNV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemNV.ForeColor = System.Drawing.Color.White;
            this.btnThemNV.Location = new System.Drawing.Point(42, 634);
            this.btnThemNV.Margin = new System.Windows.Forms.Padding(6);
            this.btnThemNV.Name = "btnThemNV";
            this.btnThemNV.Size = new System.Drawing.Size(274, 67);
            this.btnThemNV.TabIndex = 5;
            this.btnThemNV.Text = "+ Thêm Mới";
            this.btnThemNV.UseVisualStyleBackColor = false;
            this.btnThemNV.Click += new System.EventHandler(this.btnThemNV_Click);
            // 
            // txtChucVu
            // 
            this.txtChucVu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChucVu.Location = new System.Drawing.Point(40, 475);
            this.txtChucVu.Margin = new System.Windows.Forms.Padding(6);
            this.txtChucVu.Name = "txtChucVu";
            this.txtChucVu.Size = new System.Drawing.Size(574, 43);
            this.txtChucVu.TabIndex = 3;
            // 
            // lblChucVu
            // 
            this.lblChucVu.AutoSize = true;
            this.lblChucVu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChucVu.Location = new System.Drawing.Point(37, 417);
            this.lblChucVu.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblChucVu.Name = "lblChucVu";
            this.lblChucVu.Size = new System.Drawing.Size(101, 32);
            this.lblChucVu.TabIndex = 8;
            this.lblChucVu.Text = "Chức vụ";
            // 
            // lblHeSo
            // 
            this.lblHeSo.Location = new System.Drawing.Point(36, 524);
            this.lblHeSo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblHeSo.Name = "lblHeSo";
            this.lblHeSo.Size = new System.Drawing.Size(142, 29);
            this.lblHeSo.TabIndex = 9;
            this.lblHeSo.Text = "Hệ số lương";
            // 
            // txtSDT
            // 
            this.txtSDT.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.Location = new System.Drawing.Point(40, 352);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(6);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(574, 43);
            this.txtSDT.TabIndex = 2;
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSDT.Location = new System.Drawing.Point(36, 303);
            this.lblSDT.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(156, 32);
            this.lblSDT.TabIndex = 6;
            this.lblSDT.Text = "Số điện thoại";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(42, 190);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(6);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(574, 43);
            this.txtEmail.TabIndex = 1;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(36, 156);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(193, 32);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email (Tài khoản)";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTen.Location = new System.Drawing.Point(42, 87);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(6);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(574, 43);
            this.txtHoTen.TabIndex = 0;
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoTen.Location = new System.Drawing.Point(36, 52);
            this.lblHoTen.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(118, 32);
            this.lblHoTen.TabIndex = 2;
            this.lblHoTen.Text = "Họ và tên";
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.grpDanhSach);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(700, 0);
            this.pnlFill.Margin = new System.Windows.Forms.Padding(6);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Padding = new System.Windows.Forms.Padding(20, 19, 20, 19);
            this.pnlFill.Size = new System.Drawing.Size(768, 889);
            this.pnlFill.TabIndex = 1;
            // 
            // grpDanhSach
            // 
            this.grpDanhSach.Controls.Add(this.dgvNhanVien);
            this.grpDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDanhSach.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDanhSach.Location = new System.Drawing.Point(20, 19);
            this.grpDanhSach.Margin = new System.Windows.Forms.Padding(6);
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Padding = new System.Windows.Forms.Padding(6);
            this.grpDanhSach.Size = new System.Drawing.Size(728, 851);
            this.grpDanhSach.TabIndex = 0;
            this.grpDanhSach.TabStop = false;
            this.grpDanhSach.Text = "Danh Sách Nhân Viên";
            // 
            // dgvNhanVien
            // 
            this.dgvNhanVien.AllowUserToAddRows = false;
            this.dgvNhanVien.AllowUserToDeleteRows = false;
            this.dgvNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhanVien.BackgroundColor = System.Drawing.Color.White;
            this.dgvNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNhanVien.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNhanVien.Location = new System.Drawing.Point(6, 42);
            this.dgvNhanVien.Margin = new System.Windows.Forms.Padding(6);
            this.dgvNhanVien.MultiSelect = false;
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.ReadOnly = true;
            this.dgvNhanVien.RowHeadersVisible = false;
            this.dgvNhanVien.RowHeadersWidth = 82;
            this.dgvNhanVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhanVien.Size = new System.Drawing.Size(716, 803);
            this.dgvNhanVien.TabIndex = 0;
            // 
            // FormQLNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1468, 889);
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlLeft);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormQLNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Nhân Viên";
            this.pnlLeft.ResumeLayout(false);
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHeSo)).EndInit();
            this.pnlFill.ResumeLayout(false);
            this.grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtChucVu;
        private System.Windows.Forms.Label lblChucVu;
        private System.Windows.Forms.Label lblHeSo;
        private System.Windows.Forms.NumericUpDown numHeSo;
        private System.Windows.Forms.Button btnThemNV;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Panel pnlFill;
        private System.Windows.Forms.GroupBox grpDanhSach;
        private System.Windows.Forms.DataGridView dgvNhanVien;
    }
}