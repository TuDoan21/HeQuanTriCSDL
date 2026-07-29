using QL_SuKienHoiNghi.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity.Infrastructure;

namespace QL_SuKienHoiNghi
{
    public partial class FormBaoCao : Form
    {

        public FormBaoCao()
        {
            InitializeComponent();
            cboLoaiBaoCao.SelectedIndex = 0;
            cboLoaiBaoCao_SelectedIndexChanged(null, null);
        }

        private void cboLoaiBaoCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "";
            switch (cboLoaiBaoCao.SelectedIndex)
            {
                case 0:
                    sql = "SELECT * FROM vw_BaoCaoTongHop";
                    break;

                case 1:
                    sql = @"SELECT 
                                pc.MaPB AS MaPhanCong, 
                                nv.HoTenNV AS TenNV, 
                                sk.LoaiHinhSK AS TenSuKien, 
                                pc.MaDichVu AS NhiemVu, 
                                pc.NgayThucHien AS NgayPhanCong
                            FROM PhanBoNguonLuc pc
                            INNER JOIN NhanVien nv ON pc.MaNV = nv.MaNV 
                            INNER JOIN SuKienHoiNghi sk ON pc.MaSK = sk.MaSK";
                    break;

                case 2: sql = "SELECT * FROM HoaDon"; break;
            }

            try
            {
                using (var db = new QL_SKHNDbContext())
                {
                    using (var conn = db.Database.Connection)
                    {
                        if (conn.State == ConnectionState.Closed) conn.Open();

                        using (var cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = sql;
                            cmd.CommandType = CommandType.Text;

                            using (var adapter = new SqlDataAdapter((SqlCommand)cmd))
                            {
                                DataTable dt = new DataTable();
                                adapter.Fill(dt);
                                dgvBaoCao.DataSource = dt;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi Báo Cáo");
            }
        }

        private void btnXuatPDF_Click(object sender, EventArgs e)
        {
            if (dgvBaoCao.DataSource == null)
            {
                MessageBox.Show("Chưa có dữ liệu để xuất!");
                return;
            }
            DataTable dt = (DataTable)dgvBaoCao.DataSource;

            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "PDF File (*.pdf)|*.pdf";
            s.Title = "Xuất PDF";

            if (s.ShowDialog() == DialogResult.OK)
            {
                ExportHelper.ExportToPDFSimple(dt, s.FileName);
                MessageBox.Show("Xuất PDF thành công! (Hàm Export bị comment)");
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvBaoCao.DataSource == null)
            {
                MessageBox.Show("Chưa có dữ liệu để xuất!");
                return;
            }
            // Giả định hàm GetDataTableFromDataSource tồn tại
            DataTable dt = (DataTable)dgvBaoCao.DataSource;

            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "Excel File (*.csv)|*.csv";
            s.Title = "Xuất Excel";

            if (s.ShowDialog() == DialogResult.OK)
            {
                ExportHelper.ExportToExcelCSV(dt, s.FileName);
                MessageBox.Show("Xuất Excel thành công! (Hàm Export bị comment)");
            }
        }
    }
}