using QL_SuKienHoiNghi.Database;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography; // Bổ sung
using System.Text; // Bổ sung
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QL_SuKienHoiNghi
{
    public partial class FormClientRegister : Form
    {
        public FormClientRegister()
        {
            InitializeComponent();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu
            string email = txtEmail.Text.Trim();
            string pass = txtMatKhau.Text;
            string rePass = txtNhapLaiMatKhau.Text;
            string tenToChuc = txtTenToChuc.Text.Trim();
            string hoTen = txtHoTenLienHe.Text.Trim();
            string sdt = txtSoDienThoai.Text.Trim();

            // 2. Validate
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(tenToChuc))
            {
                MessageBox.Show("Vui lòng nhập đủ các trường bắt buộc (*).", "Thông báo");
                return;
            }
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Định dạng Email không hợp lệ.", "Lỗi");
                return;
            }
            if (pass != rePass)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp.", "Lỗi");
                return;
            }
            if (pass.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự.", "Lỗi");
                return;
            }

            // 3. Gọi SQL
            try
            {
                string passwordHash = "hashed_123456";

                using (var db = new QL_SKHNDbContext())
                {
                    var pOutput = new SqlParameter("@MaKHTC_Output", SqlDbType.VarChar, 10)
                    { Direction = ParameterDirection.Output };

                    // Lưu ý: Đảm bảo Stored Procedure usp_DangKyKhachHang đã tồn tại trong DB
                    db.Database.ExecuteSqlCommand(
                        "EXEC usp_DangKyKhachHang @Email, @PasswordHash, @TenToChuc, @HoTenLienHe, @DienThoai, @MaKHTC_Output OUT",
                        new SqlParameter("@Email", email),
                        new SqlParameter("@PasswordHash", passwordHash),
                        new SqlParameter("@TenToChuc", tenToChuc),
                        new SqlParameter("@HoTenLienHe", hoTen),
                        new SqlParameter("@DienThoai", sdt),
                        pOutput
                    );

                    string maKHTC = pOutput.Value != DBNull.Value ? pOutput.Value.ToString() : "N/A";
                    MessageBox.Show($"Đăng ký thành công!\nMã KH: {maKHTC}.\nTài khoản đã được tạo, vui lòng đăng nhập.", "Thành công");

                    // Chuyển sang form đăng nhập
                    FormDangNhap frmLogin = new FormDangNhap();
                    frmLogin.Show();
                    this.Close();
                }
            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Message.Contains("UNIQUE") || sqlEx.Message.Contains("tồn tại"))
                    MessageBox.Show("Email này đã được sử dụng.", "Lỗi trùng lặp");
                else
                    MessageBox.Show("Lỗi CSDL: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
            }
        }

        private void linkLblDangNhap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormDangNhap frmLogin = new FormDangNhap();
            frmLogin.Show();
            this.Close();
        }
    }
}