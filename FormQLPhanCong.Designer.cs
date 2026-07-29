using System.Windows.Forms;

namespace QL_SuKienHoiNghi
{
    partial class FormQLPhanCong : Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtMaPC = new System.Windows.Forms.TextBox();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.cboSuKien = new System.Windows.Forms.ComboBox();
            this.txtNhiemVu = new System.Windows.Forms.TextBox();
            this.dtNgay = new System.Windows.Forms.DateTimePicker();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnTim = new System.Windows.Forms.Button();
            this.dgvPhanCong = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanCong)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMaPC
            // 
            this.txtMaPC.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaPC.Location = new System.Drawing.Point(30, 30);
            this.txtMaPC.Name = "txtMaPC";
            this.txtMaPC.Size = new System.Drawing.Size(220, 34);
            this.txtMaPC.TabIndex = 9;
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboNhanVien.Location = new System.Drawing.Point(30, 70);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(220, 36);
            this.cboNhanVien.TabIndex = 8;
            // 
            // cboSuKien
            // 
            this.cboSuKien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboSuKien.Location = new System.Drawing.Point(30, 110);
            this.cboSuKien.Name = "cboSuKien";
            this.cboSuKien.Size = new System.Drawing.Size(220, 36);
            this.cboSuKien.TabIndex = 7;
            // 
            // txtNhiemVu
            // 
            this.txtNhiemVu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNhiemVu.Location = new System.Drawing.Point(30, 150);
            this.txtNhiemVu.Multiline = true;
            this.txtNhiemVu.Name = "txtNhiemVu";
            this.txtNhiemVu.Size = new System.Drawing.Size(220, 60);
            this.txtNhiemVu.TabIndex = 6;
            // 
            // dtNgay
            // 
            this.dtNgay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtNgay.Location = new System.Drawing.Point(30, 220);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.Size = new System.Drawing.Size(327, 34);
            this.dtNgay.TabIndex = 5;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(300, 25);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(90, 30);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(300, 65);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(90, 30);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(300, 105);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(90, 30);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(300, 145);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(90, 30);
            this.btnTim.TabIndex = 1;
            this.btnTim.Text = "Tìm";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // dgvPhanCong
            // 
            this.dgvPhanCong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhanCong.ColumnHeadersHeight = 34;
            this.dgvPhanCong.Location = new System.Drawing.Point(30, 270);
            this.dgvPhanCong.Name = "dgvPhanCong";
            this.dgvPhanCong.RowHeadersWidth = 62;
            this.dgvPhanCong.Size = new System.Drawing.Size(550, 230);
            this.dgvPhanCong.TabIndex = 0;
            this.dgvPhanCong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhanCong_CellClick);
            // 
            // FormQLPhanCong
            // 
            this.ClientSize = new System.Drawing.Size(620, 530);
            this.Controls.Add(this.dgvPhanCong);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dtNgay);
            this.Controls.Add(this.txtNhiemVu);
            this.Controls.Add(this.cboSuKien);
            this.Controls.Add(this.cboNhanVien);
            this.Controls.Add(this.txtMaPC);
            this.Name = "FormQLPhanCong";
            this.Text = "Quản Lý Phân Công";
            this.Load += new System.EventHandler(this.FormQLPhanCong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanCong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaPC;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.ComboBox cboSuKien;
        private System.Windows.Forms.TextBox txtNhiemVu;
        private System.Windows.Forms.DateTimePicker dtNgay;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.DataGridView dgvPhanCong;
    }
}