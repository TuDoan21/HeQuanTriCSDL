using QL_SuKienHoiNghi.Database;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace QL_SuKienHoiNghi
{
    public partial class FormDangNhap : Form
    {
        private class LoginResult
        {
            public string Role { get; set; }
            public string ChucVu { get; set; }
            public string MaThamChieu { get; set; }
        }
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtMatKhau.Text;
            string passwordHash = "hashed_123456"; // Giả lập Hash

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Email và Mật khẩu.", "Lỗi Đăng nhập",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new QL_SKHNDbContext())
            {
                var paramEmail = new SqlParameter("@Email", email);
                var paramPassword = new SqlParameter("@PasswordHash", passwordHash);

                var result = db.Database.SqlQuery<LoginResult>(
                    "EXEC usp_CheckLogin @Email, @PasswordHash",
                    paramEmail, paramPassword).FirstOrDefault();

                if (result == null)
                {
                    MessageBox.Show("Email hoặc mật khẩu không đúng.", "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (result.Role == "NHANVIEN")
                {
                    bool isAdmin = string.Equals(result.ChucVu, "Admin", StringComparison.OrdinalIgnoreCase);
                    string chucVuThucTe = result.ChucVu;

                    FormAdminMain adminForm = new FormAdminMain(isAdmin, chucVuThucTe);
                    adminForm.Show();
                    this.Hide();
                }
                else if (result.Role == "KHACHHANG")
                {
                    // Lấy MaThamChieu (MaKHTC)
                    string maKHTC = result.MaThamChieu;

                    // Chuyển hướng tới Client Portal (Trang khách hàng)
                    FormClientMain clientForm = new FormClientMain(maKHTC);
                    clientForm.Show();
                    this.Hide();
                }
            }
        }

        private void linkLblDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormClientRegister registerForm = new FormClientRegister();
            registerForm.Show();
            this.Hide();
        }

    }
}
