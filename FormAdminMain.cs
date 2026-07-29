using System;
using System.Windows.Forms;

namespace QL_SuKienHoiNghi
{
    public partial class FormAdminMain : Form
    {
        private bool _isAdmin;
        private string _chucVu;

        public FormAdminMain(bool isAdmin, string chucVu)
        {
            InitializeComponent();
            _isAdmin = isAdmin;
            _chucVu = chucVu;

            // Hiển thị thông tin
            lblUserInfo.Text = $"Xin chào: {_chucVu} | Quyền: {(_isAdmin ? "Quản trị viên" : "Nhân viên")}";

            // 1. Phân quyền
            SetupPermissions();

            // 2. Load Form con vào Tab
            LoadTabs();
        }

        private void SetupPermissions()
        {
            if (_isAdmin) return;

            // Ví dụ logic phân quyền
            if (_chucVu == "Kế toán")
            {
                RemoveTab(tabDichVu);
                RemoveTab(tabNhanVien);
                RemoveTab(tabPhanCong);
            }
            else if (_chucVu == "Kỹ thuật" || _chucVu == "Phục vụ")
            {
                RemoveTab(tabNhanVien);
                RemoveTab(tabHoaDon);
                RemoveTab(tabBaoCao);
                RemoveTab(tabKhachHang);
            }
        }

        private void RemoveTab(TabPage tab)
        {
            if (tabControlAdmin.TabPages.Contains(tab))
            {
                tabControlAdmin.TabPages.Remove(tab);
            }
        }

        private void LoadTabs()
        {
            try
            {
                // 1. Quản lý Dịch vụ
                if (tabControlAdmin.TabPages.Contains(tabDichVu))
                    EmbedForm(new FormQLDichVu(), tabDichVu);

                // 2. Quản lý Nhân viên
                if (tabControlAdmin.TabPages.Contains(tabNhanVien))
                    EmbedForm(new FormQLNhanVien(), tabNhanVien);

                // 3. Quản lý Khách hàng
                if (tabControlAdmin.TabPages.Contains(tabKhachHang))
                    EmbedForm(new FormQLKhachHang(), tabKhachHang);

                // 4. Quản lý Hóa đơn
                if (tabControlAdmin.TabPages.Contains(tabHoaDon))
                    EmbedForm(new FormQLHoaDon(), tabHoaDon);

                // 5. Phân công
                if (tabControlAdmin.TabPages.Contains(tabPhanCong))
                    EmbedForm(new FormQLPhanCong(), tabPhanCong);

                // 6. Báo cáo
                if (tabControlAdmin.TabPages.Contains(tabBaoCao))
                    EmbedForm(new FormBaoCao(), tabBaoCao);
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi nếu một Form con không thể tải (ví dụ: lỗi kết nối)
                MessageBox.Show($"Lỗi không thể tải Tab: {ex.Message}. Vui lòng kiểm tra lại kết nối CSDL hoặc tên Server.", "Lỗi Tải Giao Diện", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EmbedForm(Form childForm, TabPage page)
        {
            // Cấu hình để Form con hiển thị như một Control bên trong TabPage
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Xóa control cũ nếu có và thêm Form mới vào
            page.Controls.Clear();
            page.Controls.Add(childForm);

            // Hiển thị Form
            childForm.Show();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                new FormDangNhap().Show();
                this.Close();
            }
        }
    }
}