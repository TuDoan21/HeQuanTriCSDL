namespace QL_SuKienHoiNghi
{
    partial class FormBaoCao
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvBaoCao;
        private System.Windows.Forms.ComboBox cboLoaiBaoCao;
        private System.Windows.Forms.Button btnXuatPDF;
        private System.Windows.Forms.Button btnXuatExcel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvBaoCao = new System.Windows.Forms.DataGridView();
            this.cboLoaiBaoCao = new System.Windows.Forms.ComboBox();
            this.btnXuatPDF = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBaoCao
            // 
            this.dgvBaoCao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaoCao.Location = new System.Drawing.Point(20, 60);
            this.dgvBaoCao.Name = "dgvBaoCao";
            this.dgvBaoCao.RowHeadersWidth = 62;
            this.dgvBaoCao.Size = new System.Drawing.Size(740, 300);
            this.dgvBaoCao.TabIndex = 0;
            // 
            // cboLoaiBaoCao
            // 
            this.cboLoaiBaoCao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiBaoCao.FormattingEnabled = true;
            this.cboLoaiBaoCao.Items.AddRange(new object[] {
            "Doanh Thu",
            "Phân Công",
            "Hóa Đơn"});
            this.cboLoaiBaoCao.Location = new System.Drawing.Point(20, 20);
            this.cboLoaiBaoCao.Name = "cboLoaiBaoCao";
            this.cboLoaiBaoCao.Size = new System.Drawing.Size(200, 28);
            this.cboLoaiBaoCao.TabIndex = 1;
            this.cboLoaiBaoCao.SelectedIndexChanged += new System.EventHandler(this.cboLoaiBaoCao_SelectedIndexChanged);
            // 
            // btnXuatPDF
            // 
            this.btnXuatPDF.Location = new System.Drawing.Point(20, 380);
            this.btnXuatPDF.Name = "btnXuatPDF";
            this.btnXuatPDF.Size = new System.Drawing.Size(120, 40);
            this.btnXuatPDF.TabIndex = 2;
            this.btnXuatPDF.Text = "Xuất PDF";
            this.btnXuatPDF.UseVisualStyleBackColor = true;
            this.btnXuatPDF.Click += new System.EventHandler(this.btnXuatPDF_Click);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Location = new System.Drawing.Point(160, 380);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(120, 40);
            this.btnXuatExcel.TabIndex = 3;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // FormBaoCao
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvBaoCao);
            this.Controls.Add(this.cboLoaiBaoCao);
            this.Controls.Add(this.btnXuatPDF);
            this.Controls.Add(this.btnXuatExcel);
            this.Name = "FormBaoCao";
            this.Text = "Báo cáo thống kê";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
