namespace QL_SuKienHoiNghi
{
    partial class FormClientMain
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnDangKyMoi = new System.Windows.Forms.Button();
            this.tabControlClient = new System.Windows.Forms.TabControl();
            this.tabEvents = new System.Windows.Forms.TabPage();
            this.dgvClientEvents = new System.Windows.Forms.DataGridView();
            this.tabHistory = new System.Windows.Forms.TabPage();
            this.dgvContracts = new System.Windows.Forms.DataGridView();
            this.lblAmountDue = new System.Windows.Forms.Label();

            this.tabControlClient.SuspendLayout();
            this.tabEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientEvents)).BeginInit();
            this.tabHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContracts)).BeginInit();
            this.SuspendLayout();

            // lblWelcome
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(12, 15);
            this.lblWelcome.Text = "Xin chào Khách hàng";

            // btnLogOut
            this.btnLogOut.Location = new System.Drawing.Point(680, 12);
            this.btnLogOut.Size = new System.Drawing.Size(90, 30);
            this.btnLogOut.Text = "Đăng xuất";
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);

            // btnDangKyMoi
            this.btnDangKyMoi.BackColor = System.Drawing.Color.Orange;
            this.btnDangKyMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnDangKyMoi.Location = new System.Drawing.Point(550, 12);
            this.btnDangKyMoi.Size = new System.Drawing.Size(120, 30);
            this.btnDangKyMoi.Text = "+ Đăng ký SK Mới";
            this.btnDangKyMoi.UseVisualStyleBackColor = false;
            this.btnDangKyMoi.Click += new System.EventHandler(this.btnDangKyMoi_Click);

            // tabControlClient
            this.tabControlClient.Controls.Add(this.tabEvents);
            this.tabControlClient.Controls.Add(this.tabHistory);
            this.tabControlClient.Location = new System.Drawing.Point(12, 60);
            this.tabControlClient.Size = new System.Drawing.Size(760, 480);

            // tabEvents
            this.tabEvents.Text = "Sự kiện Đang diễn ra";
            this.tabEvents.Controls.Add(this.dgvClientEvents);

            // dgvClientEvents
            this.dgvClientEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClientEvents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // tabHistory
            this.tabHistory.Text = "Lịch sử & Công nợ";
            this.tabHistory.Controls.Add(this.dgvContracts);
            this.tabHistory.Controls.Add(this.lblAmountDue);

            // lblAmountDue
            this.lblAmountDue.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblAmountDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblAmountDue.ForeColor = System.Drawing.Color.Red;
            this.lblAmountDue.Height = 40;
            this.lblAmountDue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblAmountDue.Text = "Tổng nợ: 0 VNĐ   ";

            // dgvContracts
            this.dgvContracts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContracts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvContracts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // FormClientMain
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tabControlClient);
            this.Controls.Add(this.btnDangKyMoi);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.lblWelcome);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cổng thông tin Khách hàng";

            this.tabControlClient.ResumeLayout(false);
            this.tabEvents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientEvents)).EndInit();
            this.tabHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContracts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnDangKyMoi;
        private System.Windows.Forms.TabControl tabControlClient;
        private System.Windows.Forms.TabPage tabEvents;
        private System.Windows.Forms.DataGridView dgvClientEvents;
        private System.Windows.Forms.TabPage tabHistory;
        private System.Windows.Forms.DataGridView dgvContracts;
        private System.Windows.Forms.Label lblAmountDue;
    }
}