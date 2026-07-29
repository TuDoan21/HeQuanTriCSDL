-- =============================================
-- PHẦN 1: KHỞI TẠO DATABASE & DỌN DẸP
-- =============================================
USE master;
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'QL_SKHN')
BEGIN
    DROP DATABASE QL_SKHN;
END
GO

CREATE DATABASE QL_SKHN;
GO
USE QL_SKHN;
GO

-- Xóa Tables cũ (Thứ tự quan trọng để tránh lỗi khóa ngoại)
DROP TABLE IF EXISTS AuditLog;
DROP TABLE IF EXISTS ThongKeLuong;
DROP TABLE IF EXISTS VeSuKien;
DROP TABLE IF EXISTS PhanBoNguonLuc;
DROP TABLE IF EXISTS DichVuCungCap;
DROP TABLE IF EXISTS ChiTietHoaDon;
DROP TABLE IF EXISTS HoaDon;
DROP TABLE IF EXISTS HopDongDichVu;
DROP TABLE IF EXISTS SuKienHoiNghi;
DROP TABLE IF EXISTS KhachHangToChuc;
DROP TABLE IF EXISTS NhanVien;
DROP TABLE IF EXISTS TaiKhoan;
GO

-- =============================================
-- PHẦN 2: TẠO BẢNG (SCHEMA)
-- =============================================

-- 1. TaiKhoan
CREATE TABLE TaiKhoan(
    Email VARCHAR(100) PRIMARY KEY,
    MatKhauHash VARCHAR(255) NOT NULL,
    Role VARCHAR(20) NOT NULL, 
    MaThamChieu VARCHAR(10) UNIQUE NOT NULL,
    TrangThai NVARCHAR(50) DEFAULT N'Đang hoạt động'
);
GO

-- 2. NhanVien
CREATE TABLE NhanVien (
    MaNV VARCHAR(10) PRIMARY KEY,
    HoTenNV NVARCHAR(100) NOT NULL,
    ChucVu NVARCHAR(50) NOT NULL,
    SDT VARCHAR(20),
    HeSoLuong FLOAT DEFAULT 1.0,
    CONSTRAINT FK_NV_TK FOREIGN KEY (MaNV) REFERENCES TaiKhoan(MaThamChieu)
);
GO

-- 3. KhachHangToChuc
CREATE TABLE KhachHangToChuc (
    MaKHTC VARCHAR(10) PRIMARY KEY,
    TenToChuc NVARCHAR(150) NOT NULL,
    HoTenLienHe NVARCHAR(100),
    DienThoai VARCHAR(15),
    Email NVARCHAR(150),
    CONSTRAINT FK_KHTC_TK FOREIGN KEY (MaKHTC) REFERENCES TaiKhoan(MaThamChieu)
);
GO

-- 4. SuKienHoiNghi
CREATE TABLE SuKienHoiNghi (
    MaSK VARCHAR(10) PRIMARY KEY,
    MaKHTC VARCHAR(10) NOT NULL,
    LoaiHinhSK NVARCHAR(100) NOT NULL,
    SoLuongKhachDuKien INT,
    NgayBatDau DATE NOT NULL,
    NgayKetThuc DATE,
    TrangThai NVARCHAR(50) DEFAULT N'Chờ xử lý',
    MaNVQL VARCHAR(10),
    CONSTRAINT FK_SK_KHTC FOREIGN KEY (MaKHTC) REFERENCES KhachHangToChuc(MaKHTC),
    CONSTRAINT FK_SK_NVQL FOREIGN KEY (MaNVQL) REFERENCES NhanVien(MaNV),
    CONSTRAINT CK_SK_Ngay CHECK (NgayKetThuc >= NgayBatDau),
    CONSTRAINT CK_SK_Khach CHECK (SoLuongKhachDuKien > 0)
);
GO

-- 5. HopDongDichVu
CREATE TABLE HopDongDichVu (
    MaHD VARCHAR(10) PRIMARY KEY,
    MaSK VARCHAR(10) UNIQUE NOT NULL, 
    TongGiaTriHD DECIMAL(18, 2) NOT NULL,
    NgayKy DATE,
    TrangThaiThanhToan NVARCHAR(50) DEFAULT N'Chờ thanh toán',
    CONSTRAINT FK_HD_SK FOREIGN KEY (MaSK) REFERENCES SuKienHoiNghi(MaSK),
    CONSTRAINT CK_HD_GiaTri CHECK (TongGiaTriHD >= 0)
);
GO

-- 6. HoaDon
CREATE TABLE HoaDon (
    MaHDON VARCHAR(10) PRIMARY KEY,
    MaHD VARCHAR(10) NOT NULL, 
    MaSK VARCHAR(10) NOT NULL,
    NgayLapHD DATE NOT NULL,
    TongTienThanhToan DECIMAL(18, 2) NOT NULL,
    LoaiHD NVARCHAR(50), 
    MaNVKetoan VARCHAR(10),
    GhiChu NVARCHAR(500),
    CONSTRAINT FK_HDON_HD FOREIGN KEY (MaHD) REFERENCES HopDongDichVu(MaHD),
    CONSTRAINT FK_HDON_SK FOREIGN KEY (MaSK) REFERENCES SuKienHoiNghi(MaSK),
    CONSTRAINT FK_HDON_KETOAN FOREIGN KEY (MaNVKetoan) REFERENCES NhanVien(MaNV),
    CONSTRAINT CK_HDON_Tien CHECK (TongTienThanhToan > 0)
);
GO

-- 7. ChiTietHoaDon
CREATE TABLE ChiTietHoaDon (
    MaCTHD VARCHAR(10) PRIMARY KEY,
    MaHDON VARCHAR(10) NOT NULL,
    NoiDung NVARCHAR(200),
    DonGia DECIMAL(18, 2),
    SoLuong INT,
    ThanhTien DECIMAL(18, 2),
    CONSTRAINT FK_CTHD_HDON FOREIGN KEY (MaHDON) REFERENCES HoaDon(MaHDON),
    CONSTRAINT CK_CTHD_SL CHECK (SoLuong > 0)
);
GO

-- 8. DichVuCungCap
CREATE TABLE DichVuCungCap (
    MaDichVu VARCHAR(10) PRIMARY KEY,
    TenDichVu NVARCHAR(100) NOT NULL UNIQUE,
    DonGiaCoBan DECIMAL(18, 2) DEFAULT 0.00
);
GO

-- 9. PhanBoNguonLuc
CREATE TABLE PhanBoNguonLuc (
    MaPB VARCHAR(10) PRIMARY KEY,
    MaSK VARCHAR(10) NOT NULL,
    MaNV VARCHAR(10),
    MaDichVu VARCHAR(10),
    NgayThucHien DATE,
    SoGio FLOAT,
    CONSTRAINT FK_PB_SK FOREIGN KEY (MaSK) REFERENCES SuKienHoiNghi(MaSK),
    CONSTRAINT FK_PB_NV FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
    CONSTRAINT FK_PB_DV FOREIGN KEY (MaDichVu) REFERENCES DichVuCungCap(MaDichVu),
    CONSTRAINT UQ_PhanCong_SK_NV_Ngay UNIQUE (MaSK, MaNV, NgayThucHien),
    CONSTRAINT CK_PB_Gio CHECK (SoGio >= 0)
);
GO

-- 10. VeSuKien
CREATE TABLE VeSuKien (
    MaVe VARCHAR(20) PRIMARY KEY,
    MaSK VARCHAR(10) NOT NULL,
    MaKhachHangNhanVe NVARCHAR(100),
    NgayPhatHanh DATE,
    TrangThaiVe NVARCHAR(50) DEFAULT N'Chưa sử dụng',
    CONSTRAINT FK_VE_SK FOREIGN KEY (MaSK) REFERENCES SuKienHoiNghi(MaSK)
);
GO

-- 11. ThongKeLuong
CREATE TABLE ThongKeLuong(
    MaTKL VARCHAR(10) PRIMARY KEY,
    MaNV VARCHAR(10) NOT NULL,
    ThangNam DATE NOT NULL,
    TongGioCong FLOAT,
    LuongThucNhan DECIMAL(18, 2) DEFAULT 0.00,
    CONSTRAINT FK_TKL_NV FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
    CONSTRAINT UQ_TKL_NV_THANG UNIQUE (MaNV, ThangNam)
);
GO



-- =============================================
-- PHẦN 3: INSERT DATA (DỮ LIỆU MẪU)
-- =============================================
DECLARE @PwdHash VARCHAR(255) = 'hashed_123456'; 

-- TaiKhoan
INSERT INTO TaiKhoan (Email, MatKhauHash, Role, MaThamChieu, TrangThai) VALUES
('admin@mycorp.com', @PwdHash, 'NHANVIEN', 'NV001', N'Đang hoạt động'), 
('ketoan@mycorp.com', @PwdHash, 'NHANVIEN', 'NV002', N'Đang hoạt động'), 
('kythuat@mycorp.com', @PwdHash, 'NHANVIEN', 'NV003', N'Đang hoạt động'), 
('phucvu@mycorp.com', @PwdHash, 'NHANVIEN', 'NV004', N'Đang hoạt động'),
('vanphong@mycorp.com', @PwdHash, 'NHANVIEN', 'NV005', N'Đang hoạt động'),
('logistics@mycorp.com', @PwdHash, 'NHANVIEN', 'NV006', N'Đã khóa'),
('support@mycorp.com', @PwdHash, 'NHANVIEN', 'NV007', N'Đang hoạt động'),
('eventlead@mycorp.com', @PwdHash, 'NHANVIEN', 'NV008', N'Đang hoạt động'),
('techmanager@mycorp.com', @PwdHash, 'NHANVIEN', 'NV009', N'Đang hoạt động'),
('ceo@mycorp.com', @PwdHash, 'NHANVIEN', 'NV010', N'Đang hoạt động'),
('stage@mycorp.com', @PwdHash, 'NHANVIEN', 'NV011', N'Đang hoạt động'),
-- Khách hàng
('clientA@corp.vn', @PwdHash, 'KHACHHANG', 'KH001', N'Đang hoạt động'),
('clientB@corp.vn', @PwdHash, 'KHACHHANG', 'KH002', N'Đang hoạt động'),
('clientC@startup.vn', @PwdHash, 'KHACHHANG', 'KH003', N'Chờ duyệt'), 
('customer01@green.org', @PwdHash, 'KHACHHANG', 'KH004', N'Đang hoạt động'),
('customer02@green.org', @PwdHash, 'KHACHHANG', 'KH005', N'Đang hoạt động'),
('vipclient@vipcorp.vn', @PwdHash, 'KHACHHANG', 'KH006', N'Đang hoạt động'),
('partner@asiaevent.com', @PwdHash, 'KHACHHANG', 'KH007', N'Đang hoạt động'),
('contact@mediastars.com', @PwdHash, 'KHACHHANG', 'KH008', N'Đang hoạt động');

-- NhanVien
INSERT INTO NhanVien (MaNV, HoTenNV, ChucVu, SDT, HeSoLuong) VALUES
('NV001', N'Lý Văn Lợi', N'Admin', '0123456789', 2.0),
('NV002', N'Trần Thị Mai', N'Kế toán', '0987654321', 1.5), 
('NV003', N'Phạm Hữu Trí', N'Kỹ thuật viên', '0987654123', 1.2),
('NV004', N'Võ Thanh Sang', N'Phục vụ','0123456987', 1.0),
('NV005', N'Đỗ Thị Hương', N'Văn phòng','0947561274', 1.1),
('NV006', N'Lê Minh Cường', N'Logistics', '0465871231', 1.3),
('NV007', N'Phạm Minh Hòa', N'Hỗ trợ khách hàng', '0147608483', 1.2),
('NV008', N'Đinh Hải Long', N'Quản lý sự kiện', '0986374511', 1.4),
('NV009', N'Nguyễn Mỹ Tiên', N'Quản lý kỹ thuật', '0999999934', 1.4),
('NV010', N'Vũ Quốc Khánh', N'Giám đốc điều hành', '0333331245', 3.0),
('NV011', N'Hoàng Lâm Phát', N'Sân khấu', '0123455426', 1.1);

-- KhachHangToChuc
INSERT INTO KhachHangToChuc (MaKHTC, TenToChuc, HoTenLienHe, DienThoai, Email) VALUES
('KH001', N'Công ty TechCorp Việt Nam', N'Nguyễn Văn A', '0901112222', 'clientA@corp.vn'),
('KH002', N'Tổ chức GreenFuture', N'Lê Thị B', '0903334444', 'clientB@corp.vn'),
('KH003', N'Startup Innovate', N'Phan Thanh C', '0905556666', 'clientC@startup.vn'),
('KH004', N'Tập đoàn SunBright', N'Lý Thanh T', '0937112233', 'customer01@green.org'),
('KH005', N'Hội Doanh Nhân Trẻ', N'Vũ Thanh D', '0908877665', 'customer02@green.org'),
('KH006', N'Global Finance Group', N'Ngô Thảo P', '0933556677', 'vipclient@vipcorp.vn'),
('KH007', N'Công ty Sự Kiện Á Châu', N'Trần Văn E', '0911223344', 'partner@asiaevent.com'),
('KH008', N'Media Star Holdings', N'Lê Hoàng F', '0988776655', 'contact@mediastars.com');

-- SuKienHoiNghi
INSERT INTO SuKienHoiNghi (MaSK, MaKHTC, LoaiHinhSK, SoLuongKhachDuKien, NgayBatDau, NgayKetThuc, TrangThai, MaNVQL) VALUES
('SK001', 'KH001', N'Hội nghị Công nghệ Lớn', 300, '2026-03-01', '2026-03-05', N'Đã phê duyệt', 'NV001'), 
('SK002', 'KH002', N'Sự kiện Âm nhạc', 5000, '2026-01-20', '2026-01-20', N'Chờ xử lý', 'NV005'), 
('SK003', 'KH001', N'Workshop nội bộ', 50, '2025-01-10', '2025-01-15', N'Đã hoàn thành', 'NV003'), 
('SK004', 'KH002', N'Hội thảo Môi trường', 100, '2024-10-01', '2024-10-05', N'Đã hoàn thành', 'NV003'), 
('SK005', 'KH003', N'Ra mắt Sản phẩm', 80, '2026-04-10', '2026-04-10', N'Đang lên kế hoạch', 'NV001'),
('SK006', 'KH004', N'Hội nghị Khách hàng thường niên', 600, '2026-06-15', '2026-06-16', N'Đã phê duyệt', 'NV010'),
('SK007', 'KH005', N'Hội trại Doanh nhân', 200, '2026-08-01', '2026-08-03', N'Đang lên kế hoạch', 'NV007'),
('SK008', 'KH003', N'Hội thảo gọi vốn Startup', 120, '2026-02-10', '2026-02-11', N'Chờ xử lý', 'NV001'),
('SK009', 'KH006', N'Hội nghị Tài chính Châu Á', 800, '2025-11-20', '2025-11-22', N'Đã hoàn thành', 'NV003'),
('SK010', 'KH007', N'Lễ khai trương dự án', 150, '2026-01-12', '2026-01-12', N'Đã phê duyệt', 'NV005'),
('SK011', 'KH008', N'Hội thảo công nghệ AI', 250, '2026-05-05', '2026-05-07', N'Đang lên kế hoạch', 'NV003'),
('SK012', 'KH004', N'Sự kiện nội bộ nhân sự', 80, '2025-12-10', '2025-12-10', N'Đã hoàn thành', 'NV007'),
('SK013', 'KH006', N'Hội nghị quốc tế', 1000, '2026-09-20', '2026-09-23', N'Chờ xử lý', 'NV010');

-- HopDongDichVu
INSERT INTO HopDongDichVu (MaHD, MaSK, TongGiaTriHD, NgayKy, TrangThaiThanhToan) VALUES
('HD001', 'SK001', 500000000.00, '2026-01-10', N'Đã thanh toán'),
('HD002', 'SK003', 10000000.00, '2025-01-05', N'Chờ thanh toán'),
('HD003', 'SK004', 15000000.00, '2024-09-01', N'Đã thanh lý'),
('HD004', 'SK006', 200000000.00, '2026-05-10', N'Đã thanh toán'),
('HD005', 'SK007', 75000000.00, '2026-06-01', N'Chờ thanh toán'),
('HD006', 'SK008', 30000000.00, '2026-01-05', N'Đã thanh lý'),
('HD007', 'SK009', 120000000.00, '2025-10-01', N'Đã thanh toán'),
('HD008', 'SK010', 45000000.00, '2025-12-01', N'Đang xử lý'),
('HD009', 'SK013', 550000000.00, '2026-07-01', N'Chờ thanh toán');

-- HoaDon
INSERT INTO HoaDon (MaHDON, MaHD, MaSK, NgayLapHD, TongTienThanhToan, LoaiHD, MaNVKetoan) VALUES
('HDO001', 'HD001', 'SK001', '2026-01-10', 50000000.00, N'Tạm ứng (Đợt 1)', 'NV002'),
('HDO002', 'HD001', 'SK001', '2026-06-20', 450000000.00, N'Thanh lý (Đợt 2)', 'NV002'),
('HDO003', 'HD003', 'SK004', '2024-09-05', 15000000.00, N'Thanh toán toàn bộ', 'NV002'),
('HDO004', 'HD004', 'SK006', '2026-05-12', 200000000, N'Thanh toán', 'NV002'),
('HDO005', 'HD005', 'SK007', '2026-06-02', 25000000, N'Tạm ứng', 'NV002'),
('HDO006', 'HD005', 'SK007', '2026-06-20', 50000000, N'Thanh toán', 'NV002'),
('HDO007', 'HD006', 'SK008', '2026-01-06', 30000000, N'Thanh lý', 'NV002'),
('HDO008', 'HD007', 'SK009', '2025-10-02', 120000000, N'Thanh toán', 'NV002'),
('HDO009', 'HD008', 'SK010', '2025-12-02', 15000000, N'Tạm ứng', 'NV002'),
('HDO010', 'HD009', 'SK013', '2026-07-02', 100000000, N'Tạm ứng (Đợt 1)', 'NV002');

-- DichVuCungCap
INSERT INTO DichVuCungCap (MaDichVu, TenDichVu, DonGiaCoBan) VALUES 
('DV001', N'Dịch vụ Kỹ thuật và Ánh sáng', 10000000.00),
('DV002', N'Dịch vụ Ăn uống (Catering)', 500000.00),
('DV003', N'Dịch vụ Bảo vệ và An ninh', 8000000.00),
('DV004', N'Dịch vụ Âm thanh sân khấu nâng cao', 15000000),
('DV005', N'Dịch vụ Truyền thông LiveStream', 12000000),
('DV006', N'Dịch vụ Dàn dựng sân khấu cao cấp', 30000000),
('DV007', N'Dịch vụ Hướng dẫn – đón tiếp', 3000000),
('DV008', N'Dịch vụ Quản lý khách VIP', 8000000);

-- VeSuKien
INSERT INTO VeSuKien (MaVe, MaSK, MaKhachHangNhanVe, NgayPhatHanh, TrangThaiVe) VALUES
('V001-S001', 'SK001', 'Nguyen Van A', '2026-06-01', N'Chưa phát hành'),
('V002-S001', 'SK006', N'Tran Van T', '2026-06-10', N'Đã phát hành'),
('V003-S001', 'SK008', N'Do Thi Hanh', '2026-02-05', N'Đã gửi cho khách'),
('V004-S001', 'SK009', N'Le Minh Quan', '2025-11-01', N'Đã xác nhận'),
('V005-S001', 'SK010', N'Pham Bao Ngoc', '2025-12-05', N'Đã check-in'),
('V006-S001', 'SK011', N'Huynh Tan Loc', '2026-04-25', N'Chưa phát hành'),
('V007-S001', 'SK012', N'Hoang Thi Lan', '2025-12-01',  N'Đã hủy'),
('V008-S001', 'SK013', N'Dao Thanh Son', '2026-09-10', N'Không hợp lệ'),
('V009-S001', 'SK013', N'Tran My Duyen', '2026-09-11', N'Chưa phát hành');

-- PhanBoNguonLuc
INSERT INTO PhanBoNguonLuc (MaPB, MaSK, MaNV, MaDichVu, NgayThucHien, SoGio) VALUES 
('PB001', 'SK001', 'NV003', 'DV001', '2026-03-01', 8.0), 
('PB002', 'SK001', 'NV004', 'DV002', '2026-03-01', 6.0), 
('PB003', 'SK003', 'NV003', 'DV001', '2025-01-10', 5.0), 
('PB004', 'SK002', 'NV006', NULL, '2026-01-15', 4.0), 
('PB005', 'SK006', 'NV009', 'DV005', '2026-06-15', 7),
('PB006', 'SK006', 'NV003', 'DV001', '2026-06-15', 6),
('PB007', 'SK007', 'NV011', 'DV007', '2026-08-01', 8),
('PB008', 'SK007', 'NV004', 'DV002', '2026-08-01', 5),
('PB009', 'SK008', 'NV001', NULL, '2026-02-10', 4),
('PB010', 'SK009', 'NV008', 'DV004', '2025-11-20', 10),
('PB011', 'SK009', 'NV006', 'DV008', '2025-11-21', 6),
('PB012', 'SK011', 'NV003', 'DV001', '2026-05-05', 8),
('PB013', 'SK011', 'NV005', 'DV002', '2026-05-05', 6),
('PB014', 'SK012', 'NV007', NULL, '2025-12-10', 4),
('PB015', 'SK013', 'NV010', 'DV006', '2026-09-20', 12),
('PB016', 'SK013', 'NV009', 'DV005', '2026-09-21', 9);

-- ThongKeLuong
INSERT INTO ThongKeLuong (MaTKL, MaNV, ThangNam, TongGioCong, LuongThucNhan) VALUES 
('TKL001', 'NV003', '2026-01-01', 130.5, 15000000.00), 
('TKL002', 'NV001', '2026-01-01', 160.0, 30000000.00),
('TKL003', 'NV004', '2026-01-01', 140.0, 12000000),
('TKL004', 'NV007', '2026-01-01', 150.0, 18000000),
('TKL005', 'NV010', '2026-01-01', 160.0, 42000000),
('TKL006', 'NV008', '2026-01-01', 135.0, 15000000),
('TKL007', 'NV009', '2026-01-01', 100.0, 13000000),
('TKL008', 'NV011', '2026-01-01', 90.0, 10000000);


INSERT INTO ChiTietHoaDon (MaCTHD, MaHDON, NoiDung, DonGia, SoLuong, ThanhTien) VALUES
('CTHD001', 'HDO001', N'Dịch vụ Setup âm thanh', 5000000.00, 1, 5000000.00),
('CTHD002', 'HDO001', N'Thuê màn hình LED 100 inch', 3500000.00, 2, 7000000.00),
('CTHD003', 'HDO001', N'Chi phí tổ chức tiệc nhẹ (50 người)', 150000.00, 50, 7500000.00),
('CTHD004', 'HDO001', N'Nhân sự hỗ trợ sự kiện (8 người/ngày)', 300000.00, 8, 2400000.00),
('CTHD005', 'HDO002', N'Dịch vụ quay phim/chụp ảnh trọn gói', 8000000.00, 1, 8000000.00),
('CTHD006', 'HDO002', N'Chi phí in ấn tài liệu hội nghị', 5000.00, 500, 2500000.00),
('CTHD007', 'HDO002', N'Thuê thiết bị dịch thuật không dây', 1000000.00, 10, 10000000.00),
('CTHD008', 'HDO003', N'Chi phí thuê địa điểm (Hội trường lớn)', 20000000.00, 1, 20000000.00),
('CTHD009', 'HDO003', N'Cà phê giải lao (Tea break) (120 khách)', 80000.00, 120, 9600000.00),
('CTHD010', 'HDO003', N'Chi phí vận chuyển thiết bị', 100000.00, 5, 500000.00);
-- =============================================
-- PHẦN 4: HÀM (FUNCTIONS)
-- =============================================

-- 4.1. Tính tổng tiền còn nợ
IF OBJECT_ID('fn_GetTongTienConNo') IS NOT NULL DROP FUNCTION fn_GetTongTienConNo;
GO
CREATE FUNCTION fn_GetTongTienConNo (@MaHD VARCHAR(10))
RETURNS DECIMAL(18, 2)
AS
BEGIN
    DECLARE @GiaTriHopDong DECIMAL(18, 2);
    DECLARE @TongDaThanhToan DECIMAL(18, 2);
    SELECT @GiaTriHopDong = TongGiaTriHD FROM HopDongDichVu WHERE MaHD = @MaHD;
    SELECT @TongDaThanhToan = ISNULL(SUM(TongTienThanhToan), 0) FROM HoaDon WHERE MaHD = @MaHD;
    RETURN @GiaTriHopDong - @TongDaThanhToan;
END
GO

-- 4.2. Tính doanh thu sự kiện
CREATE FUNCTION fn_GetDoanhThuSuKien(@MaSK VARCHAR(10))
RETURNS DECIMAL(18,2)
AS
BEGIN
    RETURN (SELECT ISNULL(SUM(TongTienThanhToan),0) FROM HoaDon WHERE MaSK = @MaSK);
END
GO

-- 4.3. Tính chi phí dịch vụ
CREATE FUNCTION fn_TinhTongChiPhiDichVu(@MaSK VARCHAR(10))
RETURNS DECIMAL(18,2)
AS
BEGIN
    DECLARE @Tong DECIMAL(18,2);
    SELECT @Tong = ISNULL(SUM(PB.SoGio * DV.DonGiaCoBan), 0)
    FROM PhanBoNguonLuc PB
    JOIN DichVuCungCap DV ON PB.MaDichVu = DV.MaDichVu
    WHERE PB.MaSK = @MaSK;
    RETURN @Tong;
END
GO

-- 4.4. Tính giờ làm
CREATE FUNCTION fn_TongGioLamNam(@MaNV VARCHAR(10))
RETURNS FLOAT
AS
BEGIN
    RETURN (SELECT ISNULL(SUM(SoGio), 0) FROM PhanBoNguonLuc 
            WHERE MaNV = @MaNV AND YEAR(NgayThucHien) = YEAR(GETDATE()));
END
GO

-- 4.5. Kiểm tra nợ xấu
CREATE FUNCTION fn_KiemTraNoXau(@MaKHTC VARCHAR(10))
RETURNS NVARCHAR(50)
AS
BEGIN
    DECLARE @KetQua NVARCHAR(50) = N'Tốt';
    IF EXISTS (
        SELECT 1 
        FROM SuKienHoiNghi SK
        JOIN HopDongDichVu HD ON SK.MaSK = HD.MaSK
        WHERE SK.MaKHTC = @MaKHTC
          AND SK.NgayKetThuc < GETDATE() - 30
          AND HD.TrangThaiThanhToan NOT IN (N'Đã thanh toán', N'Đã thanh lý')
    )
    BEGIN
        SET @KetQua = N'Có nợ quá hạn';
    END
    RETURN @KetQua;
END
GO

-- =============================================
-- PHẦN 5: VIEWS
-- =============================================

IF OBJECT_ID('vw_BaoCaoTaiChinhKhachHang') IS NOT NULL DROP VIEW vw_BaoCaoTaiChinhKhachHang;
GO
CREATE VIEW vw_BaoCaoTaiChinhKhachHang
AS
SELECT
    SK.MaKHTC, SK.MaSK, SK.LoaiHinhSK, SK.NgayKetThuc,
    HD.MaHD, HD.TongGiaTriHD, HD.TrangThaiThanhToan,
    ISNULL(SUM(HDON.TongTienThanhToan), 0) AS TongTienDaThu
FROM SuKienHoiNghi SK
LEFT JOIN HopDongDichVu HD ON SK.MaSK = HD.MaSK
LEFT JOIN HoaDon HDON ON HD.MaHD = HDON.MaHD
GROUP BY 
    SK.MaKHTC, SK.MaSK, SK.LoaiHinhSK, SK.NgayKetThuc,
    HD.MaHD, HD.TongGiaTriHD, HD.TrangThaiThanhToan
GO


CREATE VIEW vw_BaoCaoTongHop AS
SELECT SK.MaSK, SK.LoaiHinhSK,
       (SELECT dbo.fn_GetDoanhThuSuKien(SK.MaSK)) AS DoanhThu,
       (SELECT COUNT(DISTINCT MaNV) FROM PhanBoNguonLuc WHERE MaSK = SK.MaSK) AS SoNhanVien
FROM SuKienHoiNghi SK
GO

-- =============================================
-- PHẦN 6: STORED PROCEDURES (NGHIỆP VỤ)
-- =============================================

-- 6.1. AUTH: Đăng nhập
IF OBJECT_ID('usp_CheckLogin') IS NOT NULL DROP PROCEDURE usp_CheckLogin;
GO
CREATE PROCEDURE usp_CheckLogin @Email VARCHAR(100), @PasswordHash VARCHAR(255)
AS BEGIN
    SET NOCOUNT ON;
    SELECT TOP 1 TK.Role, NV.ChucVu, TK.MaThamChieu
    FROM TaiKhoan TK LEFT JOIN NhanVien NV ON TK.MaThamChieu = NV.MaNV
    WHERE TK.Email = @Email AND TK.MatKhauHash = @PasswordHash;
END
GO

-- 6.2. AUTH: Đăng ký
IF OBJECT_ID('usp_DangKyKhachHang') IS NOT NULL DROP PROCEDURE usp_DangKyKhachHang;
GO
CREATE PROCEDURE usp_DangKyKhachHang
    @Email VARCHAR(100), @PasswordHash VARCHAR(255), @TenToChuc NVARCHAR(150),
    @HoTenLienHe NVARCHAR(100), @DienThoai VARCHAR(15), @MaKHTC_Output VARCHAR(10) OUTPUT
AS BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM TaiKhoan WHERE Email = @Email) BEGIN RAISERROR(N'Email đã được đăng ký.', 16, 1); RETURN; END
    DECLARE @MaxId INT; DECLARE @NewMaKHTC VARCHAR(10);
    SELECT @MaxId = ISNULL(MAX(CAST(SUBSTRING(MaKHTC, 3, LEN(MaKHTC) - 2) AS INT)), 0) FROM KhachHangToChuc WHERE MaKHTC LIKE 'KH[0-9][0-9][0-9]';
    SET @NewMaKHTC = 'KH' + RIGHT('00' + CAST(@MaxId + 1 AS VARCHAR(3)), 3);
    BEGIN TRANSACTION;
    BEGIN TRY
        INSERT INTO TaiKhoan (Email, MatKhauHash, Role, MaThamChieu) VALUES (@Email, @PasswordHash, 'KHACHHANG', @NewMaKHTC);
        INSERT INTO KhachHangToChuc (MaKHTC, TenToChuc, HoTenLienHe, DienThoai) VALUES (@NewMaKHTC, @TenToChuc, @HoTenLienHe, @DienThoai);
        COMMIT TRANSACTION; SET @MaKHTC_Output = @NewMaKHTC;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION; THROW; 
    END CATCH
END
GO

-- 6.3. ADMIN: Duyệt khách
CREATE PROCEDURE usp_DuyetKhachHang @MaKhachHang VARCHAR(10), @TrangThaiDuyet NVARCHAR(50) = N'Đang hoạt động'
AS BEGIN
    IF NOT EXISTS (SELECT 1 FROM TaiKhoan WHERE MaThamChieu = @MaKhachHang AND Role = 'KHACHHANG') 
	BEGIN
        RAISERROR(N'Khách hàng không tồn tại.', 16, 1);
        RETURN;
    END

    UPDATE TaiKhoan SET TrangThai = @TrangThaiDuyet WHERE MaThamChieu = @MaKhachHang;
    INSERT INTO AuditLog(TableName, Action, PrimaryKeyValue, ChangedBy, Details) VALUES('TaiKhoan', 'APPROVE', @MaKhachHang, SUSER_SNAME(), N'Duyệt: ' + @TrangThaiDuyet);
END
GO

-- 6.4. CLIENT: Đăng ký Sự kiện
IF OBJECT_ID('usp_DangKySuKien') IS NOT NULL DROP PROCEDURE usp_DangKySuKien;
GO
CREATE PROCEDURE usp_DangKySuKien
    @MaKHTC VARCHAR(10), @LoaiHinhSK NVARCHAR(100), @SoLuongKhach INT, @NgayBatDau DATE, @NgayKetThuc DATE
AS BEGIN
    SET NOCOUNT ON;
    DECLARE @NgayHienTai DATE = CAST(GETDATE() AS DATE);
    IF @NgayBatDau < @NgayHienTai OR @NgayKetThuc < @NgayHienTai 
	BEGIN THROW 50001, N'Ngày bắt đầu hoặc ngày kết thúc không được nhỏ hơn ngày hiện tại.', 1; RETURN; END
    IF @NgayKetThuc < @NgayBatDau BEGIN THROW 50002, N'Ngày kết thúc không được trước ngày bắt đầu.', 1; RETURN; END
    DECLARE @MaxId INT; DECLARE @NewMaSK VARCHAR(10);
    SELECT @MaxId = ISNULL(MAX(CAST(SUBSTRING(MaSK, 3, LEN(MaSK) - 2) AS INT)), 0) FROM SuKienHoiNghi WHERE MaSK LIKE 'SK[0-9][0-9][0-9]';
    SET @NewMaSK = 'SK' + RIGHT('00' + CAST(@MaxId + 1 AS VARCHAR(3)), 3);
    BEGIN TRANSACTION;
    BEGIN TRY
        INSERT INTO SuKienHoiNghi (MaSK, MaKHTC, LoaiHinhSK, SoLuongKhachDuKien, NgayBatDau, NgayKetThuc, TrangThai)
        VALUES (@NewMaSK, @MaKHTC, @LoaiHinhSK, @SoLuongKhach, @NgayBatDau, @NgayKetThuc, N'Chờ xử lý');
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION; THROW; 
    END CATCH
END
GO

-- 6.5. ADMIN: Thêm Dịch Vụ
CREATE PROCEDURE usp_ThemDichVu @TenDichVu NVARCHAR(100), @DonGiaCoBan DECIMAL(18,2)
AS BEGIN
    DECLARE @MaxId INT, @NewMaDV VARCHAR(10);
    SELECT @MaxId = ISNULL(MAX(CAST(SUBSTRING(MaDichVu, 3, LEN(MaDichVu) - 2) AS INT)), 0) FROM DichVuCungCap;
    SET @NewMaDV = 'DV' + RIGHT('00' + CAST(@MaxId + 1 AS VARCHAR(3)), 3);
    INSERT INTO DichVuCungCap(MaDichVu, TenDichVu, DonGiaCoBan) VALUES (@NewMaDV, @TenDichVu, @DonGiaCoBan);
END
GO

-- 6.6. ADMIN: Phân bổ dịch vụ
CREATE PROCEDURE usp_PhanBoDichVuSuKien @MaSK VARCHAR(10), @MaDichVu VARCHAR(10), @MaNVPhuTrach VARCHAR(10), @NgayThucHien DATE, @SoGio FLOAT
AS BEGIN
    DECLARE @MaxId INT, @NewMaPB VARCHAR(10);
    SELECT @MaxId = ISNULL(MAX(CAST(SUBSTRING(MaPB, 3, LEN(MaPB) - 2) AS INT)), 0) FROM PhanBoNguonLuc;
    SET @NewMaPB = 'PB' + RIGHT('00' + CAST(@MaxId + 1 AS VARCHAR(3)), 3);
    INSERT INTO PhanBoNguonLuc(MaPB, MaSK, MaNV, MaDichVu, NgayThucHien, SoGio) VALUES (@NewMaPB, @MaSK, @MaNVPhuTrach, @MaDichVu, @NgayThucHien, @SoGio);
END
GO

-- 6.7. ADMIN: Thêm Nhân Viên
CREATE PROCEDURE usp_ThemNhanVienMoi @Email VARCHAR(100), @MatKhauMacDinh VARCHAR(255), @HoTenNV NVARCHAR(100), @ChucVu NVARCHAR(50), @SDT NVARCHAR(20), @HeSoLuong FLOAT
AS BEGIN
    DECLARE @MaxId INT, @NewMaNV VARCHAR(10);
    SELECT @MaxId = ISNULL(MAX(CAST(SUBSTRING(MaNV, 3, LEN(MaNV) - 2) AS INT)), 0) FROM NhanVien;
    SET @NewMaNV = 'NV' + RIGHT('00' + CAST(@MaxId + 1 AS VARCHAR(3)), 3);
    BEGIN TRANSACTION;
    BEGIN TRY
        INSERT INTO TaiKhoan(Email, MatKhauHash, Role, MaThamChieu, TrangThai) VALUES (@Email, @MatKhauMacDinh, 'NHANVIEN', @NewMaNV, N'Đang hoạt động');
        INSERT INTO NhanVien(MaNV, HoTenNV, ChucVu, SDT, HeSoLuong) VALUES (@NewMaNV, @HoTenNV, @ChucVu, @SDT, @HeSoLuong);
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END
GO

-- 6.8. ADMIN: Tính Lương
CREATE PROCEDURE usp_TinhLuongThang @ThangNam DATE, @LuongCoBan1Gio DECIMAL(18,2) = 100000
AS BEGIN
    DELETE FROM ThongKeLuong WHERE ThangNam = @ThangNam;
    DECLARE @MaxId INT; SELECT @MaxId = ISNULL(MAX(CAST(SUBSTRING(MaTKL, 4, LEN(MaTKL)-3) AS INT)), 0) FROM ThongKeLuong;
    INSERT INTO ThongKeLuong (MaTKL, MaNV, ThangNam, TongGioCong, LuongThucNhan)
    SELECT 'TKL' + RIGHT('000' + CAST(@MaxId + ROW_NUMBER() OVER(ORDER BY PB.MaNV) AS VARCHAR(10)), 3),
           PB.MaNV, @ThangNam, SUM(PB.SoGio), SUM(PB.SoGio) * @LuongCoBan1Gio * NV.HeSoLuong
    FROM PhanBoNguonLuc PB JOIN NhanVien NV ON PB.MaNV = NV.MaNV
    WHERE MONTH(PB.NgayThucHien) = MONTH(@ThangNam) AND YEAR(PB.NgayThucHien) = YEAR(@ThangNam)
    GROUP BY PB.MaNV, NV.HeSoLuong;
END
GO

-- 6.9. CLIENT/ADMIN: Phát hành vé
CREATE PROCEDURE usp_PhatHanhVeSuKien @MaSK VARCHAR(10), @HoTenKhach NVARCHAR(100)
AS BEGIN
    DECLARE @DaPhat INT, @DuKien INT;
    SELECT @DuKien = SoLuongKhachDuKien FROM SuKienHoiNghi WHERE MaSK = @MaSK;
    SELECT @DaPhat = COUNT(*) FROM VeSuKien WHERE MaSK = @MaSK AND TrangThaiVe != N'Đã hủy';
    IF @DaPhat >= @DuKien 
	BEGIN
        RAISERROR(N'Sự kiện đã hết vé.', 16, 1);
        RETURN;
    END

    DECLARE @MaxId INT, @NewMaVe VARCHAR(20);
    SELECT @MaxId = ISNULL(COUNT(*), 0) FROM VeSuKien WHERE MaSK = @MaSK;
    SET @NewMaVe = 'V' + RIGHT('00' + CAST(@MaxId + 1 AS VARCHAR(3)), 3) + '-' + @MaSK;
    INSERT INTO VeSuKien(MaVe, MaSK, MaKhachHangNhanVe, NgayPhatHanh, TrangThaiVe) VALUES (@NewMaVe, @MaSK, @HoTenKhach, GETDATE(), N'Đã phát hành');
END
GO

-- 6.10. FINANCE: Thêm Hóa Đơn
CREATE PROCEDURE usp_AddHDon @MaHD VARCHAR(10), @MaSK VARCHAR(10), @NgayLapHD DATE, @TongTienThanhToan DECIMAL(18,2), @LoaiHD NVARCHAR(50), @MaNVKetoan VARCHAR(10), @GhiChu NVARCHAR(500)
AS BEGIN
    DECLARE @MaxId INT, @NewMaHDON VARCHAR(10);
    SELECT @MaxId = ISNULL(MAX(CAST(SUBSTRING(MaHDON, 4, LEN(MaHDON) - 3) AS INT)), 0) FROM HoaDon WHERE MaHDON LIKE 'HDO%';
    SET @NewMaHDON = 'HDO' + RIGHT('00' + CAST(@MaxId + 1 AS VARCHAR(3)), 3);
    INSERT INTO HoaDon (MaHDON, MaHD, MaSK, NgayLapHD, TongTienThanhToan, LoaiHD, MaNVKetoan, GhiChu) VALUES (@NewMaHDON, @MaHD, @MaSK, @NgayLapHD, @TongTienThanhToan, @LoaiHD, @MaNVKetoan, @GhiChu);
END
GO

-- 6.11. FINANCE: Cập nhật hóa đơn
CREATE PROCEDURE usp_UpdateHDon @MaHDon VARCHAR(10), @TongTienThanhToan DECIMAL(18,2), @GhiChu NVARCHAR(500)
AS BEGIN
    UPDATE HoaDon SET TongTienThanhToan = @TongTienThanhToan, GhiChu = @GhiChu WHERE MaHDON = @MaHDon;
END
GO

-- 6.12. ADMIN: Lấy danh sách chờ duyệt
CREATE PROCEDURE usp_LayDanhSachKhachChoDuyet AS
BEGIN
    SELECT TK.MaThamChieu AS MaKHTC, KH.TenToChuc, KH.HoTenLienHe, KH.DienThoai, TK.TrangThai 
    FROM TaiKhoan TK JOIN KhachHangToChuc KH ON TK.MaThamChieu = KH.MaKHTC
    WHERE TK.TrangThai = N'Chờ duyệt';
END
GO

-- 6.12. Danh sách Phân công theo sự kiện
CREATE PROCEDURE sp_PhanCongTheoSuKien
    @MaSK VARCHAR(10)
AS
BEGIN
    SELECT pb.MaPB, nv.HoTenNV, pb.NgayThucHien
    FROM PhanBoNguonLuc pb
    INNER JOIN NhanVien nv ON pb.MaNV = nv.MaNV
    WHERE pb.MaSK = @MaSK
END
GO

-- 6.13. Lấy hóa đơn theo khách hàng/sự kiện
CREATE PROCEDURE sp_HoaDonTheoSK
    @MaSK VARCHAR(10)
AS
BEGIN
    SELECT hd.MaHDON, hd.NgayLapHD, hd.TongTienThanhToan, nv.HoTenNV AS NguoiLap
    FROM HoaDon hd
    LEFT JOIN NhanVien nv ON hd.MaNVKetoan = nv.MaNV
    WHERE hd.MaSK = @MaSK
END
GO



-- =============================================
-- PHẦN 7: TRIGGERS
-- =============================================

-- 7.1. Log thay đổi sự kiện
IF OBJECT_ID('trg_SuKien_Update', 'TR') IS NOT NULL 
    DROP TRIGGER trg_SuKien_Update;
GO

CREATE TRIGGER trg_SuKien_Update ON SuKienHoiNghi AFTER UPDATE AS
BEGIN
    INSERT INTO AuditLog(TableName, Action, PrimaryKeyValue, ChangedBy, Details)
    SELECT 
        'SuKienHoiNghi', 
        'UPDATE', 
        i.MaSK, 
        SUSER_SNAME(), 
        -- SỬA LỖI: Dùng dấu + thay cho CONCAT
        -- Dùng ISNULL để xử lý trường hợp giá trị là NULL (tránh bị lỗi NULL + Chuỗi = NULL)
        N'Trạng thái cũ: ' + ISNULL(d.TrangThai, N'(trống)') + N' -> Mới: ' + ISNULL(i.TrangThai, N'(trống)')
    FROM inserted i 
    JOIN deleted d ON i.MaSK = d.MaSK;
END
GO

-- 7.2. Validate hóa đơn & Log
IF OBJECT_ID('trg_HoaDon_Insert_Update', 'TR') IS NOT NULL 
    DROP TRIGGER trg_HoaDon_Insert_Update;
GO

CREATE TRIGGER trg_HoaDon_Insert_Update ON HoaDon AFTER INSERT, UPDATE AS
BEGIN
    -- 1. Kiểm tra logic nghiệp vụ
    IF EXISTS (SELECT 1 FROM inserted WHERE TongTienThanhToan < 0) 
    BEGIN 
        RAISERROR(N'Tiền không thể âm', 16, 1); 
        ROLLBACK; 
        RETURN; 
    END

    -- 2. Ghi Log Audit
    INSERT INTO AuditLog(TableName, Action, PrimaryKeyValue, ChangedBy, Details)
    SELECT 
        'HoaDon', 
        CASE WHEN EXISTS(SELECT 1 FROM deleted) THEN 'UPDATE' ELSE 'INSERT' END, 
        i.MaHDON, 
        SUSER_SNAME(), 
        -- SỬA LỖI Ở ĐÂY: Dùng + và CAST
        N'Tiền: ' + CAST(i.TongTienThanhToan AS NVARCHAR(50))
    FROM inserted i;
END
GO

-- 7.3. Prevent xóa dịch vụ đang dùng
CREATE TRIGGER trg_PreventDeleteUsedService ON DichVuCungCap INSTEAD OF DELETE AS
BEGIN
    IF EXISTS (SELECT 1 FROM PhanBoNguonLuc PB JOIN deleted d ON PB.MaDichVu = d.MaDichVu) BEGIN RAISERROR(N'Dịch vụ đang được sử dụng.', 16, 1); RETURN; END
    DELETE FROM DichVuCungCap WHERE MaDichVu IN (SELECT MaDichVu FROM deleted);
END
GO

-- 7.4. Log thay đổi lương
IF OBJECT_ID('trg_LogThayDoiLuong', 'TR') IS NOT NULL 
    DROP TRIGGER trg_LogThayDoiLuong;
GO

CREATE TRIGGER trg_LogThayDoiLuong ON NhanVien AFTER UPDATE AS
BEGIN
    -- Chỉ chạy khi cột HeSoLuong bị thay đổi
    IF UPDATE(HeSoLuong)
    BEGIN
        INSERT INTO AuditLog(TableName, Action, PrimaryKeyValue, ChangedBy, Details)
        SELECT 
            'NhanVien', 
            'UPDATE_SALARY', 
            i.MaNV, 
            SUSER_SNAME(), 
            -- SỬA LỖI: Dùng + và CAST để chuyển số sang chuỗi
            N'Hệ số cũ: ' + CAST(d.HeSoLuong AS NVARCHAR(20)) + N' -> Mới: ' + CAST(i.HeSoLuong AS NVARCHAR(20))
        FROM inserted i 
        JOIN deleted d ON i.MaNV = d.MaNV;
    END
END
GO

-- 7.5. Trigger tự động ghi audit khi insert / update bảng Hóa đơn
CREATE TRIGGER trg_HoaDon_Audit
ON HoaDon
AFTER INSERT, UPDATE
AS
BEGIN
    INSERT INTO AuditLog(TableName, Action, PrimaryKeyValue, ChangedBy, Details)
    SELECT 'HoaDon',
           CASE WHEN EXISTS(SELECT * FROM inserted) AND EXISTS(SELECT * FROM deleted) THEN 'UPDATE' ELSE 'INSERT' END,
           MaHDON,
           SYSTEM_USER,
           'TongTienThanhToan=' + CAST(TongTienThanhToan AS NVARCHAR(20))
    FROM inserted;
END
GO


-- =============================================
-- PHẦN 8: BẢO MẬT & PHÂN QUYỀN (ROLES)
-- =============================================

IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = 'db_admin' AND type = 'R') CREATE ROLE db_admin;
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = 'db_accountant' AND type = 'R') CREATE ROLE db_accountant;
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = 'db_service_mgr' AND type = 'R') CREATE ROLE db_service_mgr;
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = 'db_hr_mgr' AND type = 'R') CREATE ROLE db_hr_mgr;
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = 'db_crm_mgr' AND type = 'R') CREATE ROLE db_crm_mgr;
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = 'db_client' AND type = 'R') CREATE ROLE db_client;
GO

-- Cấp quyền (Full cho Admin)
GRANT SELECT, INSERT, UPDATE, DELETE ON SCHEMA::dbo TO db_admin;
GRANT EXECUTE ON SCHEMA::dbo TO db_admin;

-- Kế toán
GRANT SELECT, INSERT, UPDATE, DELETE ON HoaDon TO db_accountant;
GRANT SELECT, INSERT, UPDATE, DELETE ON ChiTietHoaDon TO db_accountant;
GRANT SELECT ON HopDongDichVu TO db_accountant;
GRANT SELECT ON SuKienHoiNghi TO db_accountant;
GRANT EXECUTE ON usp_AddHDon TO db_accountant;
GRANT EXECUTE ON usp_UpdateHDon TO db_accountant;
GRANT EXECUTE ON fn_GetTongTienConNo TO db_accountant;

-- Service Mgr
GRANT SELECT, INSERT, UPDATE, DELETE ON DichVuCungCap TO db_service_mgr;
GRANT SELECT, INSERT, UPDATE, DELETE ON PhanBoNguonLuc TO db_service_mgr;
GRANT SELECT ON SuKienHoiNghi TO db_service_mgr;
GRANT SELECT ON NhanVien TO db_service_mgr;
GRANT EXECUTE ON usp_ThemDichVu TO db_service_mgr;
GRANT EXECUTE ON usp_PhanBoDichVuSuKien TO db_service_mgr;
GRANT EXECUTE ON fn_TinhTongChiPhiDichVu TO db_service_mgr;
GRANT EXECUTE ON usp_DangKySuKien TO db_service_mgr;

-- HR Mgr
GRANT SELECT, INSERT, UPDATE, DELETE ON NhanVien TO db_hr_mgr;
GRANT SELECT, INSERT, UPDATE, DELETE ON TaiKhoan TO db_hr_mgr;
GRANT SELECT, INSERT, UPDATE, DELETE ON ThongKeLuong TO db_hr_mgr;
GRANT SELECT ON PhanBoNguonLuc TO db_hr_mgr;
GRANT EXECUTE ON usp_ThemNhanVienMoi TO db_hr_mgr;
GRANT EXECUTE ON usp_TinhLuongThang TO db_hr_mgr;
GRANT EXECUTE ON fn_TongGioLamNam TO db_hr_mgr;

-- CRM Mgr
GRANT SELECT, INSERT, UPDATE ON KhachHangToChuc TO db_crm_mgr;
GRANT SELECT, INSERT, UPDATE, DELETE ON VeSuKien TO db_crm_mgr;
GRANT SELECT ON SuKienHoiNghi TO db_crm_mgr;
GRANT EXECUTE ON usp_PhatHanhVeSuKien TO db_crm_mgr;
GRANT EXECUTE ON fn_KiemTraNoXau TO db_crm_mgr;
GRANT EXECUTE ON usp_DuyetKhachHang TO db_crm_mgr;
GRANT EXECUTE ON usp_LayDanhSachKhachChoDuyet TO db_crm_mgr;

-- Client
GRANT SELECT ON SuKienHoiNghi TO db_client;
GRANT SELECT ON HopDongDichVu TO db_client;

-- Public (Login/Register)
GRANT EXECUTE ON usp_CheckLogin TO public;
GRANT EXECUTE ON usp_DangKyKhachHang TO public;
GO

PRINT N'=== TRIỂN KHAI DATABASE HOÀN TẤT (Full Fix & Logic) ===';

-- =============================================
-- PHẦN 9: CURSOR
-- =============================================
-- 1. Duyệt phân bổ nguồn lực (PhanBoNguonLuc)
DECLARE 
    @PB_MaPB VARCHAR(10),
    @PB_MaSK VARCHAR(10),
    @PB_LoaiSuKien NVARCHAR(100),
    @PB_MaNV VARCHAR(10),
    @PB_HoTenNV NVARCHAR(100),
    @PB_MaDichVu VARCHAR(10),
    @PB_TenDichVu NVARCHAR(100),
    @PB_NgayThucHien DATE,
    @PB_SoGio FLOAT;

-- Khởi tạo cursor
DECLARE PB_Cursor CURSOR FOR
SELECT 
    pb.MaPB, pb.MaSK, sk.LoaiHinhSK, pb.MaNV, nv.HoTenNV, 
    pb.MaDichVu, dv.TenDichVu, pb.NgayThucHien, pb.SoGio
FROM PhanBoNguonLuc pb
LEFT JOIN SuKienHoiNghi sk ON pb.MaSK = sk.MaSK
LEFT JOIN NhanVien nv ON pb.MaNV = nv.MaNV
LEFT JOIN DichVuCungCap dv ON pb.MaDichVu = dv.MaDichVu;

OPEN PB_Cursor;

FETCH NEXT FROM PB_Cursor INTO 
    @PB_MaPB, @PB_MaSK, @PB_LoaiSuKien, @PB_MaNV, @PB_HoTenNV, 
    @PB_MaDichVu, @PB_TenDichVu, @PB_NgayThucHien, @PB_SoGio;

WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT 'PhanBo - MaPB: ' + @PB_MaPB +
          ', SuKien: ' + ISNULL(@PB_LoaiSuKien,'Chưa có') +
          ', NhanVien: ' + ISNULL(@PB_HoTenNV,'Chưa có') +
          ', DichVu: ' + ISNULL(@PB_TenDichVu,'Chưa có') +
          ', Ngay: ' + CAST(@PB_NgayThucHien AS NVARCHAR(10)) +
          ', SoGio: ' + CAST(@PB_SoGio AS NVARCHAR(10));

    FETCH NEXT FROM PB_Cursor INTO 
        @PB_MaPB, @PB_MaSK, @PB_LoaiSuKien, @PB_MaNV, @PB_HoTenNV, 
        @PB_MaDichVu, @PB_TenDichVu, @PB_NgayThucHien, @PB_SoGio;
END

CLOSE PB_Cursor;
DEALLOCATE PB_Cursor;

-- 2. Duyệt Hóa đơn (HoaDon) - giữ nguyên
DECLARE @HD_MaHDON VARCHAR(10),
        @HD_MaSK VARCHAR(10),
        @HD_NgayLap DATE,
        @HD_TongTien DECIMAL(18,2),
        @HD_NguoiLap NVARCHAR(100);

DECLARE HoaDon_Cursor CURSOR FOR
SELECT hd.MaHDON, hd.MaSK, hd.NgayLapHD, hd.TongTienThanhToan, nv.HoTenNV
FROM HoaDon hd
LEFT JOIN NhanVien nv ON hd.MaNVKetoan = nv.MaNV;

OPEN HoaDon_Cursor;

FETCH NEXT FROM HoaDon_Cursor INTO @HD_MaHDON, @HD_MaSK, @HD_NgayLap, @HD_TongTien, @HD_NguoiLap;

WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT 'HoaDon: ' + @HD_MaHDON + 
          ', SuKien: ' + @HD_MaSK + 
          ', NgayLap: ' + CAST(@HD_NgayLap AS NVARCHAR(10)) + 
          ', TongTien: ' + CAST(@HD_TongTien AS NVARCHAR(20)) + 
          ', NguoiLap: ' + ISNULL(@HD_NguoiLap,'Chưa có');

    FETCH NEXT FROM HoaDon_Cursor INTO @HD_MaHDON, @HD_MaSK, @HD_NgayLap, @HD_TongTien, @HD_NguoiLap;
END

CLOSE HoaDon_Cursor;
DEALLOCATE HoaDon_Cursor;


-- =============================================
-- PHẦN 10: GIAO TÁC
-- =============================================

-- 10.1. Giao tác CURD cho bảng PhanBoNguonLuc
-- 1. Insert dữ liệu phân bổ
INSERT INTO PhanBoNguonLuc (MaPB, MaSK, MaNV, MaDichVu, NgayThucHien, SoGio)
VALUES ('PB017', 'SK001', 'NV001', 'DV001', GETDATE(), 4);

-- 2. Update dữ liệu
UPDATE PhanBoNguonLuc
SET SoGio = 5
WHERE MaPB = 'PB017';

-- 3. Delete dữ liệu
DELETE FROM PhanBoNguonLuc
WHERE MaPB = 'PB017';

-- 4. Select dữ liệu
SELECT pb.MaPB, pb.MaSK, sk.LoaiHinhSK, pb.MaNV, nv.HoTenNV, pb.MaDichVu, dv.TenDichVu, pb.NgayThucHien, pb.SoGio
FROM PhanBoNguonLuc pb
LEFT JOIN SuKienHoiNghi sk ON pb.MaSK = sk.MaSK
LEFT JOIN NhanVien nv ON pb.MaNV = nv.MaNV
LEFT JOIN DichVuCungCap dv ON pb.MaDichVu = dv.MaDichVu;

-- 10.2. Giao tác CURD cho bảng PhanBoNguonLuc
-- 1. Insert Hóa đơn
INSERT INTO HoaDon (MaHDON, MaHD, MaSK, NgayLapHD, TongTienThanhToan, LoaiHD, MaNVKetoan, GhiChu)
VALUES 
('HDO011', 'HD001', 'SK001', GETDATE(), 1500000, N'Bán lẻ', 'NV002', N'Thanh toán trực tiếp');

-- 2. Update Hóa đơn
UPDATE HoaDon
SET TongTienThanhToan = 2000000
WHERE MaHDON = 'HDO011';

-- 3. Delete Hóa đơn
DELETE FROM HoaDon
WHERE MaHDON = 'HDO011';

-- 4. Select Hóa đơn theo Sự kiện
SELECT 
    hd.MaHDON, 
    hd.NgayLapHD, 
    hd.TongTienThanhToan, 
    ISNULL(nv.HoTenNV,'Chưa có') AS NguoiLap
FROM HoaDon hd
LEFT JOIN NhanVien nv ON hd.MaNVKetoan = nv.MaNV
WHERE hd.MaSK = 'SK001';

-- =============================================
-- PHẦN 11: BACKUP VÀ RESTORE (ĐÃ SỬA LỖI CÚ PHÁP ĐƯỜNG DẪN)
-- =============================================

DECLARE @FullBackupPath NVARCHAR(255) = N'H:\Đồ án HK5\HQT\SQL_Backups\QL_SKHN_Full.bak'; 
DECLARE @DiffBackupPath NVARCHAR(255) = N'H:\Đồ án HK5\HQT\SQL_Backups\QL_SKHN_Diff.bak'; 
DECLARE @LogBackupPath NVARCHAR(255) = N'H:\Đồ án HK5\HQT\SQL_Backups\QL_SKHN_Log.trn';    
GO

-- 11.1. Backup CSDL

-- Backup full database (Batch 1)
DECLARE @FullBackupPath NVARCHAR(255) = N'H:\Đồ án HK5\HQT\SQL_Backups\QL_SKHN_Full.bak';
BACKUP DATABASE QL_SKHN
TO DISK = @FullBackupPath
WITH FORMAT, INIT, NAME = 'Backup full QL_SKHN';
GO 

-- Backup differential (Batch 2)
DECLARE @DiffBackupPath NVARCHAR(255) = N'H:\Đồ án HK5\HQT\SQL_Backups\QL_SKHN_Diff.bak';
BACKUP DATABASE QL_SKHN
TO DISK = @DiffBackupPath
WITH NAME = 'Backup differential QL_SKHN';
GO 

-- Backup transaction log (Batch 3)
DECLARE @LogBackupPath NVARCHAR(255) = N'H:\Đồ án HK5\HQT\SQL_Backups\QL_SKHN_Log.trn';
BACKUP LOG QL_SKHN
TO DISK = @LogBackupPath
WITH NAME = 'Transaction log backup QL_SKHN';
GO 

-- 11.2. Restore CSDL (Batch 4 - Restore Full)
DECLARE @FullBackupPath NVARCHAR(255) = N'H:\Đồ án HK5\HQT\SQL_Backups\QL_SKHN_Full.bak';
RESTORE DATABASE QL_SKHN
FROM DISK = @FullBackupPath
WITH REPLACE, NORECOVERY;
GO

-- Restore differential (Batch 5)
DECLARE @DiffBackupPath NVARCHAR(255) = N'H:\Đồ án HK5\HQT\SQL_Backups\QL_SKHN_Diff.bak';
RESTORE DATABASE QL_SKHN
FROM DISK = @DiffBackupPath
WITH NORECOVERY;
GO

-- Restore transaction log (Batch 6 - Restore Log và Recovery)
DECLARE @LogBackupPath NVARCHAR(255) = N'H:\Đồ án HK5\HQT\SQL_Backups\QL_SKHN_Log.trn';
RESTORE LOG QL_SKHN
FROM DISK = @LogBackupPath
WITH RECOVERY;
GO