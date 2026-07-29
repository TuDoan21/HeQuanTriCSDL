using QL_SuKienHoiNghi.Database;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity; // Cần thiết cho LoadData và Update

namespace QL_SuKienHoiNghi
{
    public partial class FormQLDichVu : Form
    {
        public FormQLDichVu()
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
                    var listDV = db.DichVuCungCap
                        .Select(d => new
                        {
                            d.MaDichVu,
                            d.TenDichVu,
                            d.DonGiaCoBan
                        })
                        .ToList();

                    dgvDichVu.DataSource = listDV;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu Dịch vụ: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenDV = txtTenDV.Text.Trim();
            decimal donGia = numDonGia.Value;

            if (string.IsNullOrEmpty(tenDV)) { MessageBox.Show("Vui lòng nhập tên dịch vụ", "Cảnh báo"); return; }

            try
            {
                using (var db = new QL_SKHNDbContext())
                {
                    // Cải tiến: Thêm kiểm tra trùng tên trước khi gọi SP
                    if (db.DichVuCungCap.Any(d => d.TenDichVu == tenDV))
                    {
                        MessageBox.Show("Tên dịch vụ đã tồn tại.", "Cảnh báo");
                        return;
                    }

                    db.Database.ExecuteSqlCommand("EXEC usp_ThemDichVu @Ten, @Gia",
                      new SqlParameter("@Ten", tenDV),
                      new SqlParameter("@Gia", donGia));

                    MessageBox.Show("Thêm thành công!");
                    LoadData();
                    txtTenDV.Clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        // Bổ sung: Hàm Sửa (Update) bị thiếu
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDichVu.CurrentRow == null) return;
            string maDV = dgvDichVu.CurrentRow.Cells["MaDichVu"].Value.ToString();
            string tenDV = txtTenDV.Text.Trim();
            decimal donGia = numDonGia.Value;

            try
            {
                using (var db = new QL_SKHNDbContext())
                {
                    var dv = db.DichVuCungCap.Find(maDV);
                    if (dv != null)
                    {
                        dv.TenDichVu = tenDV;
                        dv.DonGiaCoBan = donGia;
                        db.SaveChanges();
                        MessageBox.Show("Cập nhật thành công!");
                        LoadData();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi cập nhật: " + ex.Message); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDichVu.CurrentRow == null) return;
            string maDV = dgvDichVu.CurrentRow.Cells["MaDichVu"].Value.ToString();

            if (MessageBox.Show("Xóa dịch vụ này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (var db = new QL_SKHNDbContext())
                    {
                        // EF sẽ tự động gọi Trigger INSTEAD OF DELETE trong SQL
                        var dv = db.DichVuCungCap.Find(maDV);
                        if (dv != null)
                        {
                            db.DichVuCungCap.Remove(dv);
                            db.SaveChanges();
                            LoadData();
                            MessageBox.Show("Đã xóa thành công!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Bắt lỗi từ Trigger SQL (Dịch vụ đang được sử dụng)
                    MessageBox.Show("Không thể xóa (Dịch vụ đang được sử dụng hoặc lỗi: " + ex.Message + ").", "Lỗi ràng buộc");
                }
            }
        }

        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvDichVu.Rows[e.RowIndex];
                txtTenDV.Text = row.Cells["TenDichVu"].Value.ToString();
                // Xử lý trường hợp NULL an toàn
                if (row.Cells["DonGiaCoBan"].Value != null)
                {
                    numDonGia.Value = Convert.ToDecimal(row.Cells["DonGiaCoBan"].Value);
                }
                else
                {
                    numDonGia.Value = 0;
                }
            }
        }
    }
}