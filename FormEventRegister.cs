using QL_SuKienHoiNghi.Database;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QL_SuKienHoiNghi
{
    public partial class FormEventRegister : Form
    {
        private string _maKHTC;

        public FormEventRegister(string maKHTC)
        {
            InitializeComponent();
            _maKHTC = maKHTC;
            lblMaKHTC.Text = "Mã KH: " + _maKHTC;

            // Set default dates
            dtpBatDau.Value = DateTime.Now.AddDays(7); // Mặc định sự kiện sau 1 tuần
            dtpKetThuc.Value = DateTime.Now.AddDays(7).AddHours(4);
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string loaiHinh = txtLoaiHinh.Text.Trim();
            int soLuong = (int)numSoLuongKhach.Value;
            DateTime start = dtpBatDau.Value;
            DateTime end = dtpKetThuc.Value;

            if (string.IsNullOrEmpty(loaiHinh))
            {
                MessageBox.Show("Vui lòng nhập loại hình sự kiện (VD: Hội thảo, Đám cưới...).");
                return;
            }

            if (start < DateTime.Now)
            {
                MessageBox.Show("Ngày bắt đầu không được ở quá khứ.");
                return;
            }

            if (start >= end)
            {
                MessageBox.Show("Thời gian kết thúc phải sau thời gian bắt đầu.");
                return;
            }

            try
            {
                using (var db = new QL_SKHNDbContext())
                {
                    db.Database.ExecuteSqlCommand(
                        "EXEC usp_DangKySuKien @MaKHTC, @LoaiHinhSK, @SoLuongKhach, @NgayBatDau, @NgayKetThuc",
                        new SqlParameter("@MaKHTC", _maKHTC),
                        new SqlParameter("@LoaiHinhSK", loaiHinh),
                        new SqlParameter("@SoLuongKhach", soLuong),
                        new SqlParameter("@NgayBatDau", start),
                        new SqlParameter("@NgayKetThuc", end)
                    );

                    MessageBox.Show("Đăng ký sự kiện thành công!\nNhân viên sẽ liên hệ để xác nhận.", "Thông báo");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đăng ký sự kiện: " + ex.Message);
            }
        }

        private void btnTroLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}