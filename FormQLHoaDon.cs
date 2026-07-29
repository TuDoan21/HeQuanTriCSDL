using QL_SuKienHoiNghi.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_SuKienHoiNghi
{
    public partial class FormQLHoaDon : Form
    {
        public FormQLHoaDon()
        {
            InitializeComponent();
            LoadComboboxes();
            LoadHoaDon();
        }

        private void LoadComboboxes()
        {
            try
            {
                using (var db = new QL_SKHNDbContext())
                {
                    // 1. Tải danh sách Mã Hợp đồng
                    var hdList = db.HopDongDichVu.Select(h => new { h.MaHD }).ToList();
                    cboMaHD.DataSource = hdList;
                    cboMaHD.DisplayMember = "MaHD";
                    cboMaHD.ValueMember = "MaHD";

                    // 2. Tải danh sách Loại hóa đơn
                    cboLoaiHD.Items.Clear();
                    cboLoaiHD.Items.AddRange(new object[] { "Tạm ứng", "Thanh lý", "Bán lẻ", "Thanh toán" });
                    cboLoaiHD.SelectedIndex = 0;

                    // 3. Đặt NV Kế toán mặc định (Giả định NV002)
                    txtMaNVKetoan.Text = "NV002";
                    txtMaNVKetoan.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách: " + ex.Message, "Lỗi kết nối");
            }
        }

        private void LoadHoaDon()
        {
            try
            {
                using (var db = new QL_SKHNDbContext())
                {
                    var listHD = db.HoaDon
                        .Select(h => new
                        {
                            h.MaHDON,
                            h.MaHD,
                            h.MaSK,
                            h.NgayLapHD,
                            h.TongTienThanhToan,
                            h.LoaiHD,
                            h.MaNVKetoan,
                            h.GhiChu
                        })
                        .ToList();
                    dgvHoaDon.DataSource = listHD;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Lỗi LoadData: " + ex.Message);
                MessageBox.Show("Lỗi tải Hóa đơn. Vui lòng kiểm tra lại kết nối CSDL.", "Lỗi Database");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maHD = cboMaHD.SelectedValue?.ToString();
            string maSK = txtMaSK.Text.Trim();
            string loaiHD = cboLoaiHD.SelectedItem?.ToString();
            string maNVKetoan = txtMaNVKetoan.Text.Trim();
            string ghiChu = txtGhiChu.Text.Trim();
            decimal tongTien;

            if (string.IsNullOrWhiteSpace(maHD) || string.IsNullOrWhiteSpace(maSK) || !decimal.TryParse(txtTongTien.Text, out tongTien))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã Hợp đồng, Mã Sự kiện và Tổng tiền hợp lệ.", "Cảnh báo");
                return;
            }

            try
            {
                using (var db = new QL_SKHNDbContext())
                {
                    // Gọi SP usp_AddHDon với đủ 7 tham số
                    db.Database.ExecuteSqlCommand("EXEC usp_AddHDon @MaHD, @MaSK, @NgayLapHD, @TongTienThanhToan, @LoaiHD, @MaNVKetoan, @GhiChu",
                        new SqlParameter("@MaHD", maHD),
                        new SqlParameter("@MaSK", maSK),
                        new SqlParameter("@NgayLapHD", dtpNgayLap.Value.Date),
                        new SqlParameter("@TongTienThanhToan", tongTien),
                        new SqlParameter("@LoaiHD", loaiHD),
                        new SqlParameter("@MaNVKetoan", maNVKetoan),
                        new SqlParameter("@GhiChu", ghiChu)
                    );

                    LoadHoaDon();
                    MessageBox.Show("Thêm hóa đơn thành công!");
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi thêm: " + ex.Message); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maHDon = txtMaHDon.Text.Trim();
            if (string.IsNullOrWhiteSpace(maHDon)) return;

            if (MessageBox.Show($"Xóa hóa đơn {maHDon} này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            try
            {
                using (var db = new QL_SKHNDbContext())
                {
                    var chiTiet = db.ChiTietHoaDon.Where(c => c.MaHDON == maHDon);
                    db.ChiTietHoaDon.RemoveRange(chiTiet);

                    // 2. Xóa HoaDon
                    var hd = db.HoaDon.Find(maHDon);
                    if (hd != null)
                    {
                        db.HoaDon.Remove(hd);
                        db.SaveChanges();
                    }

                    MessageBox.Show("Xóa hóa đơn thành công!");
                    LoadHoaDon();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maHDon = txtMaHDon.Text.Trim();
            string ghiChu = txtGhiChu.Text.Trim();
            decimal tongTien;

            if (string.IsNullOrWhiteSpace(maHDon) || !decimal.TryParse(txtTongTien.Text, out tongTien))
            {
                MessageBox.Show("Vui lòng chọn Hóa đơn và nhập Tổng tiền hợp lệ.", "Cảnh báo");
                return;
            }

            try
            {
                using (var db = new QL_SKHNDbContext())
                {
                    // Gọi SP usp_UpdateHDon 
                    db.Database.ExecuteSqlCommand("EXEC usp_UpdateHDon @MaHDon, @TongTienThanhToan, @GhiChu",
                        new SqlParameter("@MaHDon", maHDon),
                        new SqlParameter("@TongTienThanhToan", tongTien),
                        new SqlParameter("@GhiChu", ghiChu)
                    );

                    MessageBox.Show("Sửa hóa đơn thành công!");
                    LoadHoaDon();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa: " + ex.Message);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string searchTerm = txtMaHDon.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                LoadHoaDon();
                return;
            }

            try
            {
                using (var db = new QL_SKHNDbContext())
                {
                    var listHD = db.HoaDon
                        .Where(h => h.MaHDON.Contains(searchTerm) || h.MaSK.Contains(searchTerm))
                        .Select(h => new
                        {
                            h.MaHDON,
                            h.MaHD,
                            h.MaSK,
                            h.NgayLapHD,
                            h.TongTienThanhToan,
                            h.LoaiHD,
                            h.MaNVKetoan,
                            h.GhiChu
                        })
                        .ToList();
                    dgvHoaDon.DataSource = listHD;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadComboboxes();
            LoadHoaDon();
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvHoaDon.DataSource != null)
            {
                var row = dgvHoaDon.Rows[e.RowIndex];

                // Ánh xạ các cột cũ
                txtMaHDon.Text = row.Cells["MaHDON"].Value?.ToString() ?? "";
                txtMaSK.Text = row.Cells["MaSK"].Value?.ToString() ?? "";

                // Kiểm tra và gán giá trị cho Tổng tiền
                if (row.Cells["TongTienThanhToan"].Value != null && decimal.TryParse(row.Cells["TongTienThanhToan"].Value.ToString(), out decimal tongTien))
                {
                    txtTongTien.Text = tongTien.ToString();
                }
                else
                {
                    txtTongTien.Text = "0";
                }

                // Ánh xạ các cột nghiệp vụ (ComboBoxes và TextBox)
                cboMaHD.SelectedValue = row.Cells["MaHD"].Value;
                cboLoaiHD.SelectedItem = row.Cells["LoaiHD"].Value;
                txtMaNVKetoan.Text = row.Cells["MaNVKetoan"].Value?.ToString() ?? "";
                txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString() ?? "";

                // Ngày Lập HĐ
                if (row.Cells["NgayLapHD"].Value is DateTime dateValue)
                {
                    dtpNgayLap.Value = dateValue;
                }
            }
        }
    }
}
