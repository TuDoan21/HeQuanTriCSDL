using QL_SuKienHoiNghi.Database;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Data.Entity.Infrastructure;

namespace QL_SuKienHoiNghi
{
    public partial class FormQLNhanVien : Form
    {
        public FormQLNhanVien()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (var db = new QL_SKHNDbContext())
                {
                    // Code đã sửa lỗi trước đó (Sử dụng Query Syntax và Join Tường Minh)
                    var listNV = (from nv in db.NhanVien
                                  join tk in db.TaiKhoan on nv.MaNV equals tk.MaThamChieu
                                  where tk.Role == "NHANVIEN"
                                  select new
                                  {
                                      nv.MaNV,
                                      nv.HoTenNV,
                                      nv.ChucVu,
                                      nv.SDT,
                                      nv.HeSoLuong,
                                      Email = tk.Email, 
                                      TrangThaiTK = tk.TrangThai 
                                  }).ToList();

                    dgvNhanVien.DataSource = listNV;
                }
                ResetInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi Database");
            }
        }

        // ========================== HASH PASSWORD ==========================
        private string HashPassword(string rawPassword)
        {
            // Logic Hash giữ nguyên
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawPassword));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // ========================== THÊM MỚI ==========================
        private void btnThemNV_Click(object sender, EventArgs e)
        {
            string ten = txtHoTen.Text.Trim();
            string chucVu = txtChucVu.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string email = txtEmail.Text.Trim();
            double heSo = (double)numHeSo.Value;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Email và Họ tên.");
                return;
            }

            string matKhauMacDinh = "123456";
            string matKhauHash = HashPassword(matKhauMacDinh);

            try
            {
                using (var db = new QL_SKHNDbContext())
                {
                    object[] parameters =
                    {
            new SqlParameter("@Email", email),
            new SqlParameter("@MatKhauMacDinh", matKhauHash),
            new SqlParameter("@HoTenNV", ten),
            new SqlParameter("@ChucVu", chucVu),
            new SqlParameter("@SDT", sdt),
            new SqlParameter("@HeSoLuong", heSo)
          };

                    string sqlCommand = "EXEC usp_ThemNhanVienMoi @Email, @MatKhauMacDinh, @HoTenNV, @ChucVu, @SDT, @HeSoLuong";

                    db.Database.ExecuteSqlCommand(sqlCommand, parameters);

                    MessageBox.Show($"Thêm nhân viên thành công!\nTài khoản: {email}\nMật khẩu mặc định: {matKhauMacDinh}", "Thành công");

                    LoadData();
                }
            }
            catch (SqlException sqlEx)
            {
                // Xử lý lỗi Email trùng lặp dựa trên tin nhắn lỗi từ SQL
                if (sqlEx.Message.Contains("Email đã được đăng ký"))
                {
                    MessageBox.Show("Email này đã tồn tại trong hệ thống. Vui lòng chọn email khác.", "Cảnh báo trùng lặp");
                }
                else
                {
                    MessageBox.Show("Lỗi CSDL: " + sqlEx.Message, "Lỗi SQL");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
            }
        }

        private void ResetInput()
        {
            txtHoTen.Text = "";
            txtChucVu.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
            numHeSo.Value = 1.0M;
            txtHoTen.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow == null) return;
            // Lấy MaNV từ hàng đang chọn (MaNV là cột ẩn hoặc cột đầu tiên)
            string maNV = dgvNhanVien.CurrentRow.Cells["MaNV"].Value.ToString();
            string emailCu = dgvNhanVien.CurrentRow.Cells["Email"].Value.ToString(); // Email cũ dùng để tìm TaiKhoan

            string ten = txtHoTen.Text.Trim();
            string chucVu = txtChucVu.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string emailMoi = txtEmail.Text.Trim();
            double heSo = (double)numHeSo.Value;

            if (string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(emailMoi))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Email và Họ tên.");
                return;
            }

            try
            {
                using (var db = new QL_SKHNDbContext())
                {
                    // 1. Cập nhật thông tin nhân viên
                    var nvToUpdate = db.NhanVien.Find(maNV);
                    if (nvToUpdate != null)
                    {
                        nvToUpdate.HoTenNV = ten;
                        nvToUpdate.ChucVu = chucVu;
                        nvToUpdate.SDT = sdt;
                        nvToUpdate.HeSoLuong = heSo; // Trigger SQL sẽ tự động ghi log thay đổi HeSoLuong
                    }

                    // 2. Cập nhật Email trong Tài Khoản (Nếu Email bị thay đổi)
                    if (emailCu != emailMoi)
                    {
                        // Kiểm tra Email mới có bị trùng với người khác không
                        if (db.TaiKhoan.Any(t => t.Email == emailMoi && t.MaThamChieu != maNV))
                        {
                            MessageBox.Show("Email mới này đã được đăng ký cho tài khoản khác.", "Lỗi trùng lặp");
                            return;
                        }

                        var tkToUpdate = db.TaiKhoan.FirstOrDefault(t => t.MaThamChieu == maNV);
                        if (tkToUpdate != null)
                        {
                            tkToUpdate.Email = emailMoi;
                        }
                    }

                    db.SaveChanges();
                    MessageBox.Show("Cập nhật nhân viên thành công!", "Thành công");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message, "Lỗi");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow == null) return;
            string maNV = dgvNhanVien.CurrentRow.Cells["MaNV"].Value.ToString();

            if (MessageBox.Show("Xóa nhân viên này? (Hành động này không thể hoàn tác)", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (var db = new QL_SKHNDbContext())
                    {
                        // Xóa các dữ liệu liên quan (Phân bổ nguồn lực, Thống kê lương) trước
                        var phanBo = db.PhanBoNguonLuc.Where(p => p.MaNV == maNV);
                        db.PhanBoNguonLuc.RemoveRange(phanBo);

                        var luong = db.ThongKeLuong.Where(l => l.MaNV == maNV);
                        db.ThongKeLuong.RemoveRange(luong);

                        // Xóa Tài Khoản và Nhân Viên (Quan trọng: Xóa Tài Khoản trước, vì MaNV là khóa ngoại)
                        var tk = db.TaiKhoan.FirstOrDefault(t => t.MaThamChieu == maNV);
                        if (tk != null)
                        {
                            db.TaiKhoan.Remove(tk);
                        }

                        var nv = db.NhanVien.Find(maNV);
                        if (nv != null)
                        {
                            db.NhanVien.Remove(nv);
                            db.SaveChanges();
                            MessageBox.Show("Xóa nhân viên thành công!");
                            LoadData();
                        }
                        ResetInput();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hệ thống khi xóa: " + ex.Message);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
            ResetInput();
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvNhanVien.Rows[e.RowIndex];

                string maNV = row.Cells[0].Value.ToString();
                txtHoTen.Text = row.Cells["HoTenNV"].Value?.ToString() ?? "";
                txtChucVu.Text = row.Cells["ChucVu"].Value?.ToString() ?? "";
                txtSDT.Text = row.Cells["SDT"].Value?.ToString() ?? "";
                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";

                // HeSoLuong
                if (row.Cells["HeSoLuong"].Value != null)
                {
                    numHeSo.Value = Convert.ToDecimal(row.Cells["HeSoLuong"].Value);
                }
                else
                {
                    numHeSo.Value = 1.0M;
                }
            }
        }
    }
}