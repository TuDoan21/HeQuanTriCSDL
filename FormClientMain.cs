using QL_SuKienHoiNghi.Database;
using QL_SuKienHoiNghi.DataBase.DTOs;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace QL_SuKienHoiNghi
{
    public partial class FormClientMain : Form
    {
        private string _maKHTC;

        public FormClientMain(string maKHTC)
        {
            InitializeComponent();
            _maKHTC = maKHTC;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (var db = new QL_SKHNDbContext())
                {

                    var kh = db.KhachHangToChuc.Find(_maKHTC);
                    if (kh != null) lblWelcome.Text = $"Xin chào: {kh.TenToChuc}";

                    var listSK = db.SuKienHoiNghi
            .Where(s => s.MaKHTC == _maKHTC && s.TrangThai != "Đã hoàn thành")
            .Select(s => new { s.MaSK, s.LoaiHinhSK, s.NgayBatDau, s.TrangThai })
            .ToList();
                    dgvClientEvents.DataSource = listSK;


                    string sql = @"SELECT 
                                MaHD, LoaiHinhSK,
                                ISNULL(TongGiaTriHD, 0) AS TongGiaTriHD, 
                                TrangThaiThanhToan,
                                ISNULL(TongTienDaThu, 0) AS TongTienDaThu,
                                dbo.fn_GetTongTienConNo(MaHD) AS SoTienConNo
                               FROM vw_BaoCaoTaiChinhKhachHang 
                               WHERE MaKHTC = @MaKHTC";

                    var listHD = db.Database.SqlQuery<FinancialReportDTO>(sql, new SqlParameter("@MaKHTC", _maKHTC)).ToList();
                    dgvContracts.DataSource = listHD;

                    decimal tongNo = listHD.Sum(x => x.SoTienConNo ?? 0);
                    lblAmountDue.Text = $"Tổng nợ cần thanh toán: {tongNo:N0} VNĐ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải dữ liệu: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDangKyMoi_Click(object sender, EventArgs e)
        {
            var form = new FormEventRegister(_maKHTC);
            form.ShowDialog(); 
            LoadData();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            new FormDangNhap().Show();
            this.Close();
        }
    }
}