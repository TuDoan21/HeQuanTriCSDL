namespace QL_SuKienHoiNghi
{
    partial class FormQLKhachHang
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.dgvKhachHang = new System.Windows.Forms.DataGridView();
            this.btnDuyet = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvKhachHang
            // 
            this.dgvKhachHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhachHang.ColumnHeadersHeight = 46;
            this.dgvKhachHang.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvKhachHang.Location = new System.Drawing.Point(0, 98);
            this.dgvKhachHang.Name = "dgvKhachHang";
            this.dgvKhachHang.RowHeadersWidth = 82;
            this.dgvKhachHang.Size = new System.Drawing.Size(974, 482);
            this.dgvKhachHang.TabIndex = 3;
            // 
            // btnDuyet
            // 
            this.btnDuyet.BackColor = System.Drawing.Color.Orange;
            this.btnDuyet.Location = new System.Drawing.Point(702, 62);
            this.btnDuyet.Name = "btnDuyet";
            this.btnDuyet.Size = new System.Drawing.Size(120, 30);
            this.btnDuyet.TabIndex = 1;
            this.btnDuyet.Text = "DUYỆT TÀI KHOẢN";
            this.btnDuyet.UseVisualStyleBackColor = false;
            this.btnDuyet.Click += new System.EventHandler(this.btnDuyet_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(851, 62);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 30);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Tải lại";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(137, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(610, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh sách Khách Hàng & Trạng thái Tài khoản";
            // 
            // FormQLKhachHang
            // 
            this.ClientSize = new System.Drawing.Size(974, 580);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDuyet);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvKhachHang);
            this.Name = "FormQLKhachHang";
            this.Text = "Quản Lý Khách Hàng";
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridView dgvKhachHang;
        private System.Windows.Forms.Button btnDuyet;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label1;
    }
}