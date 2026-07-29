using QL_SuKienHoiNghi.Database;

using System;

using System.Data;

using System.Data.SqlClient;

using System.Linq;

using System.Windows.Forms;

using System.Data.Entity;

using System.Diagnostics;

using System.Collections.Generic;

using System.Drawing; // Cần thiết cho Designer



namespace QL_SuKienHoiNghi

{

    public partial class FormQLPhanCong : Form

    {

        // Lưu ý: Các control (cboNhanVien, txtMaPC, dgvPhanCong,...) 

        // được sử dụng trực tiếp do đã có trong Designer.



        public FormQLPhanCong()

        {

            InitializeComponent();

        }



        private void FormQLPhanCong_Load(object sender, EventArgs e)

        {

            try

            {

                LoadPhanCong();

                LoadNhanVien();

                LoadSuKien();

            }

            catch (Exception ex)

            {

                Debug.WriteLine("LỖI KẾT NỐI/LOAD DATA: " + ex.Message);

                MessageBox.Show("Lỗi tải dữ liệu. Vui lòng kiểm tra lại kết nối CSDL.", "Lỗi Database");

            }

        }



        // ===================== LOAD DATA =============================



        private void LoadPhanCong()

        {

            using (var db = new QL_SKHNDbContext())

            {

                // Sử dụng Projection cho Entity PhanBoNguonLuc

                var listPC = db.PhanBoNguonLuc

                    .Select(p => new

                    {

                        p.MaPB,

                        p.MaSK,

                        p.MaNV,

                        p.MaDichVu,

                        p.NgayThucHien,

                        p.SoGio

                    })

                    .ToList();

                dgvPhanCong.DataSource = listPC;

            }

        }



        private void LoadNhanVien()

        {

            using (var db = new QL_SKHNDbContext())

            {

                var listNV = db.NhanVien.Select(n => new { n.MaNV, n.HoTenNV }).ToList();

                cboNhanVien.DataSource = listNV;

                cboNhanVien.DisplayMember = "HoTenNV";

                cboNhanVien.ValueMember = "MaNV";

            }

        }



        private void LoadSuKien()

        {

            using (var db = new QL_SKHNDbContext())

            {

                var listSK = db.SuKienHoiNghi.Select(s => new { s.MaSK, s.LoaiHinhSK }).ToList();

                cboSuKien.DataSource = listSK;

                cboSuKien.DisplayMember = "LoaiHinhSK";

                cboSuKien.ValueMember = "MaSK";

            }

        }



        // ===================== THÊM (DÙNG SP) =============================

        private void btnThem_Click(object sender, EventArgs e)

        {

            string maSK = cboSuKien.SelectedValue?.ToString();

            string maNV = cboNhanVien.SelectedValue?.ToString();

            string maDichVu = txtNhiemVu.Text.Trim();

            double soGio = 8.0; // GIẢ ĐỊNH



            if (string.IsNullOrWhiteSpace(maSK) || string.IsNullOrWhiteSpace(maNV) || string.IsNullOrWhiteSpace(maDichVu))

            {

                MessageBox.Show("Vui lòng chọn đầy đủ Sự kiện, Nhân viên và Dịch vụ.", "Cảnh báo");

                return;

            }



            try

            {

                using (var db = new QL_SKHNDbContext())

                {


                    db.Database.ExecuteSqlCommand(

                        "EXEC usp_PhanBoDichVuSuKien @MaSK, @MaDichVu, @MaNVPhuTrach, @NgayThucHien, @SoGio",

                        new SqlParameter("@MaSK", maSK),

                        new SqlParameter("@MaDichVu", maDichVu),

                        new SqlParameter("@MaNVPhuTrach", maNV),

                        new SqlParameter("@NgayThucHien", dtNgay.Value.Date),

                        new SqlParameter("@SoGio", soGio)

                    );

                }



                LoadPhanCong();

                MessageBox.Show("Thêm phân công thành công!");

            }

            catch (Exception ex)

            {

                Debug.WriteLine("LỖI THÊM PHÂN CÔNG: " + ex.Message);

                MessageBox.Show("Lỗi thêm: " + ex.Message);

            }

        }



        // ===================== SỬA (DÙNG EF) =============================

        private void btnSua_Click(object sender, EventArgs e)

        {

            string maPC = txtMaPC.Text.Trim();

            string maNV = cboNhanVien.SelectedValue?.ToString();

            string maSK = cboSuKien.SelectedValue?.ToString();

            string maDichVu = txtNhiemVu.Text.Trim();

            DateTime ngay = dtNgay.Value.Date;



            if (string.IsNullOrWhiteSpace(maPC))

            {

                MessageBox.Show("Vui lòng chọn mã phân công cần sửa.", "Cảnh báo");

                return;

            }



            try

            {

                using (var db = new QL_SKHNDbContext())

                {

                    var pc = db.PhanBoNguonLuc.Find(maPC);

                    if (pc != null)

                    {

                        pc.MaNV = maNV;

                        pc.MaSK = maSK;

                        pc.MaDichVu = maDichVu;

                        pc.NgayThucHien = ngay;

                        // pc.SoGio = [Giá trị mới] 



                        db.SaveChanges();

                        MessageBox.Show("Đã sửa phân công!");

                        LoadPhanCong();

                    }

                }

            }

            catch (Exception ex)

            {

                Debug.WriteLine("LỖI SỬA PHÂN CÔNG: " + ex.Message);

                MessageBox.Show("Lỗi sửa: " + ex.Message);

            }

        }



        // ===================== XÓA (DÙNG EF) =============================

        private void btnXoa_Click(object sender, EventArgs e)

        {

            string maPC = txtMaPC.Text.Trim();

            if (string.IsNullOrWhiteSpace(maPC))

            {

                MessageBox.Show("Vui lòng chọn mã phân công cần xóa.", "Cảnh báo");

                return;

            }



            if (MessageBox.Show("Xóa phân công này?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes) return;



            try

            {

                using (var db = new QL_SKHNDbContext())

                {

                    var pc = db.PhanBoNguonLuc.Find(maPC);

                    if (pc != null)

                    {

                        db.PhanBoNguonLuc.Remove(pc);

                        db.SaveChanges();

                        MessageBox.Show("Đã xóa phân công!");

                        LoadPhanCong();

                    }

                }

            }

            catch (Exception ex)

            {

                Debug.WriteLine("LỖI XÓA PHÂN CÔNG: " + ex.Message);

                MessageBox.Show("Lỗi xóa: " + ex.Message);

            }

        }



        // ===================== TÌM KIẾM (DÙNG EF) =============================

        private void btnTim_Click(object sender, EventArgs e)

        {

            string searchTerm = txtMaPC.Text.Trim();



            if (string.IsNullOrWhiteSpace(searchTerm))

            {

                LoadPhanCong();

                return;

            }



            try

            {

                using (var db = new QL_SKHNDbContext())

                {

                    var listPC = db.PhanBoNguonLuc

                        // Tìm theo MaPB, MaSK hoặc MaNV

                        .Where(p => p.MaPB.Contains(searchTerm) || p.MaSK.Contains(searchTerm) || p.MaNV.Contains(searchTerm))

                        .Select(p => new

                        {

                            p.MaPB,

                            p.MaSK,

                            p.MaNV,

                            p.MaDichVu,

                            p.NgayThucHien,

                            p.SoGio

                        })

                        .ToList();

                    dgvPhanCong.DataSource = listPC;

                }

            }

            catch (Exception ex)

            {

                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);

            }

        }



        // ===================== CLICK ON DATAGRID =============================

        private void dgvPhanCong_CellClick(object sender, DataGridViewCellEventArgs e)

        {

            if (e.RowIndex >= 0)

            {

                // Đổ dữ liệu từ hàng được chọn lên các control

                var row = dgvPhanCong.Rows[e.RowIndex];



                txtMaPC.Text = row.Cells["MaPB"].Value?.ToString();

                cboNhanVien.SelectedValue = row.Cells["MaNV"].Value;

                cboSuKien.SelectedValue = row.Cells["MaSK"].Value;

                txtNhiemVu.Text = row.Cells["MaDichVu"].Value?.ToString();



                if (row.Cells["NgayThucHien"].Value is DateTime dateValue)

                {

                    dtNgay.Value = dateValue;

                }

            }

        }

    }

}