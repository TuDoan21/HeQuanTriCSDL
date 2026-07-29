using QL_SuKienHoiNghi.Database;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace QL_SuKienHoiNghi
{
    public partial class FormQLKhachHang : Form
    {
        public FormQLKhachHang()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (var db = new QL_SKHNDbContext())
            {
                var list = (from k in db.KhachHangToChuc
                            join t in db.TaiKhoan on k.MaKHTC equals t.MaThamChieu
                            select new
                            {
                                k.MaKHTC,
                                k.TenToChuc,
                                k.HoTenLienHe,
                                k.DienThoai,
                                TrangThai = t.TrangThai 
                            }).ToList();

                dgvKhachHang.DataSource = list;
            }
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow == null) return;
            string maKH = dgvKhachHang.CurrentRow.Cells["MaKHTC"].Value.ToString();
            string status = dgvKhachHang.CurrentRow.Cells["TrangThai"].Value.ToString();

            if (status == "Đang hoạt động")
            {
                MessageBox.Show("Khách hàng này đã được duyệt rồi.");
                return;
            }

            try
            {
                using (var db = new QL_SKHNDbContext())
                {
                    db.Database.ExecuteSqlCommand("EXEC usp_DuyetKhachHang @MaKH, @TT",
                        new SqlParameter("@MaKH", maKH),
                        new SqlParameter("@TT", "Đang hoạt động"));

                    MessageBox.Show("Đã duyệt tài khoản: " + maKH);
                    LoadData();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}