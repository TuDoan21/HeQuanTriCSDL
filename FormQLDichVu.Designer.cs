namespace QL_SuKienHoiNghi
{
    partial class FormQLDichVu
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.dgvDichVu = new System.Windows.Forms.DataGridView();
            this.txtTenDV = new System.Windows.Forms.TextBox();
            this.numDonGia = new System.Windows.Forms.NumericUpDown();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.numDonGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVu)).BeginInit();
            this.SuspendLayout();

            // Label
            this.label1.Text = "Tên Dịch Vụ:"; this.label1.Location = new System.Drawing.Point(20, 20); this.label1.AutoSize = true;
            this.label2.Text = "Đơn giá:"; this.label2.Location = new System.Drawing.Point(20, 60); this.label2.AutoSize = true;

            // Inputs
            this.txtTenDV.Location = new System.Drawing.Point(100, 20); this.txtTenDV.Size = new System.Drawing.Size(200, 20);
            this.numDonGia.Location = new System.Drawing.Point(100, 60); this.numDonGia.Size = new System.Drawing.Size(200, 20); this.numDonGia.Maximum = 1000000000;

            // Buttons
            this.btnThem.Text = "Thêm Mới"; this.btnThem.Location = new System.Drawing.Point(320, 18); this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnXoa.Text = "Xóa Chọn"; this.btnXoa.Location = new System.Drawing.Point(320, 58); this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            // Grid
            this.dgvDichVu.Location = new System.Drawing.Point(20, 100); this.dgvDichVu.Size = new System.Drawing.Size(500, 300);
            this.dgvDichVu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDichVu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDichVu_CellClick);

            this.Controls.Add(label1); this.Controls.Add(label2);
            this.Controls.Add(txtTenDV); this.Controls.Add(numDonGia);
            this.Controls.Add(btnThem); this.Controls.Add(btnXoa);
            this.Controls.Add(dgvDichVu);
            this.Text = "Quản Lý Dịch Vụ";
            this.Size = new System.Drawing.Size(560, 460);
            ((System.ComponentModel.ISupportInitialize)(this.numDonGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVu)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvDichVu;
        private System.Windows.Forms.TextBox txtTenDV;
        private System.Windows.Forms.NumericUpDown numDonGia;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}