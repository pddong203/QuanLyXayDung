-- =============================================
-- BÀI TẬP LỚN: QUẢN LÝ PHÂN CÔNG NHÂN LỰC XÂY DỰNG
-- ĐỀ TÀI SỐ 10 - KHOA CNTT - ĐẠI HỌC MỞ HÀ NỘI
-- =============================================

USE master;
GO

-- 1. TẠO DATABASE
-- Kiểm tra nếu DB đã tồn tại thì xóa đi tạo lại (để chạy script được nhiều lần)
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'QuanLyXayDung')
    DROP DATABASE QuanLyXayDung;
GO

CREATE DATABASE QuanLyXayDung;
GO

USE QuanLyXayDung;
GO

-- =============================================
-- 2. TẠO BẢNG DỮ LIỆU & RÀNG BUỘC (CONSTRAINTS)
-- =============================================

-- 2.1. Bảng Phòng Ban
CREATE TABLE tblPhongBan (
    MaPB VARCHAR(10) PRIMARY KEY,
    TenPB NVARCHAR(50) NOT NULL,
    ChucNang NVARCHAR(255),
    MaTruongPhong VARCHAR(10), -- Sẽ tạo FK sau để tránh vòng lặp
    
    -- Ràng buộc tên phòng không trùng lặp
    CONSTRAINT UQ_TenPB UNIQUE (TenPB)
);
GO

-- 2.2. Bảng Nhân Viên
CREATE TABLE tblNhanvien (
    MaNV VARCHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(50) NOT NULL,
    DiaChi NVARCHAR(100),
    NgaySinh DATE,
    GioiTinh NVARCHAR(10),
    MaPB VARCHAR(10) NOT NULL, -- Bắt buộc phải thuộc 1 phòng ban
    
    -- Ràng buộc khóa ngoại
    CONSTRAINT FK_NhanVien_PhongBan FOREIGN KEY (MaPB) REFERENCES tblPhongBan(MaPB),
    
    -- Ràng buộc kiểm tra dữ liệu (Data Integrity)
    CONSTRAINT CK_NgaySinh CHECK (NgaySinh < GETDATE()), -- Ngày sinh phải nhỏ hơn ngày hiện tại
    CONSTRAINT CK_GioiTinh CHECK (GioiTinh IN (N'Nam', N'Nữ', N'Khác'))
);
GO

-- Cập nhật lại FK Trưởng phòng cho bảng Phòng Ban
ALTER TABLE tblPhongBan
ADD CONSTRAINT FK_PhongBan_TruongPhong FOREIGN KEY (MaTruongPhong) REFERENCES tblNhanvien(MaNV);
GO

-- 2.3. Bảng Công Trình
CREATE TABLE tblCongtrinh (
    MaCT VARCHAR(10) PRIMARY KEY,
    TenCT NVARCHAR(100) NOT NULL,
    DiaDiem NVARCHAR(100),
    NgayCapPhep DATE,
    NgayKhoiCong DATE,
    NgayDuKienHoanThanh DATE,
    
    -- Ngày hoàn thành dự kiến phải sau ngày khởi công
    CONSTRAINT CK_NgayThang CHECK (NgayDuKienHoanThanh >= NgayKhoiCong)
);
GO

-- 2.4. Bảng Thi Công (Phân công & Chấm công)
CREATE TABLE tblThicong (
    MaNV VARCHAR(10),
    MaCT VARCHAR(10),
    SoNgayCong INT DEFAULT 0,
    
    PRIMARY KEY (MaNV, MaCT),
    
    CONSTRAINT FK_ThiCong_NhanVien FOREIGN KEY (MaNV) REFERENCES tblNhanvien(MaNV),
    CONSTRAINT FK_ThiCong_CongTrinh FOREIGN KEY (MaCT) REFERENCES tblCongtrinh(MaCT),
    
    -- Số ngày công không được âm
    CONSTRAINT CK_SoNgayCong CHECK (SoNgayCong >= 0)
);
GO

-- =============================================
-- 3. THÊM DỮ LIỆU MẪU (SEED DATA)
-- =============================================
-- Tắt kiểm tra khóa ngoại tạm thời để insert dữ liệu chéo (Trưởng phòng <-> Phòng ban)
ALTER TABLE tblPhongBan NOCHECK CONSTRAINT ALL;
ALTER TABLE tblNhanvien NOCHECK CONSTRAINT ALL;

-- Thêm Phòng ban
INSERT INTO tblPhongBan (MaPB, TenPB, ChucNang) VALUES ('PB01', N'Phòng Kỹ Thuật', N'Giám sát, thiết kế');
INSERT INTO tblPhongBan (MaPB, TenPB, ChucNang) VALUES ('PB02', N'Phòng Hành Chính', N'Nhân sự, văn thư');

-- Thêm Nhân viên
INSERT INTO tblNhanvien (MaNV, HoTen, DiaChi, NgaySinh, GioiTinh, MaPB) 
VALUES ('NV01', N'Nguyễn Văn A', N'Hà Nội', '1990-01-01', N'Nam', 'PB01');

INSERT INTO tblNhanvien (MaNV, HoTen, DiaChi, NgaySinh, GioiTinh, MaPB) 
VALUES ('NV02', N'Trần Thị B', N'Hải Dương', '1995-05-20', N'Nữ', 'PB02');

-- Cập nhật Trưởng phòng
UPDATE tblPhongBan SET MaTruongPhong = 'NV01' WHERE MaPB = 'PB01';
UPDATE tblPhongBan SET MaTruongPhong = 'NV02' WHERE MaPB = 'PB02';

-- Bật lại kiểm tra khóa ngoại
ALTER TABLE tblPhongBan CHECK CONSTRAINT ALL;
ALTER TABLE tblNhanvien CHECK CONSTRAINT ALL;

-- Thêm Công trình
INSERT INTO tblCongtrinh (MaCT, TenCT, DiaDiem, NgayKhoiCong, NgayDuKienHoanThanh) 
VALUES ('CT01', N'Cầu Vĩnh Tuy 2', N'Hà Nội', '2023-01-01', '2025-01-01');

-- Thêm Thi công (Phân công)
INSERT INTO tblThicong (MaNV, MaCT, SoNgayCong) VALUES ('NV01', 'CT01', 20);
GO

-- =============================================
-- 4. STORED PROCEDURES (THEO YÊU CẦU MỤC 3.1)
-- =============================================

-- 4.1. NHÓM QUẢN LÝ NHÂN VIÊN (THÊM, SỬA, XÓA)
------------------------------------------------
CREATE PROCEDURE sp_ThemNhanVien
    @MaNV VARCHAR(10),
    @HoTen NVARCHAR(50),
    @DiaChi NVARCHAR(100),
    @NgaySinh DATE,
    @GioiTinh NVARCHAR(10),
    @MaPB VARCHAR(10)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM tblNhanvien WHERE MaNV = @MaNV)
    BEGIN
        PRINT N'Mã nhân viên đã tồn tại!';
        RETURN;
    END

    INSERT INTO tblNhanvien (MaNV, HoTen, DiaChi, NgaySinh, GioiTinh, MaPB)
    VALUES (@MaNV, @HoTen, @DiaChi, @NgaySinh, @GioiTinh, @MaPB);
END;
GO

CREATE PROCEDURE sp_SuaNhanVien
    @MaNV VARCHAR(10),
    @HoTen NVARCHAR(50),
    @DiaChi NVARCHAR(100),
    @NgaySinh DATE,
    @GioiTinh NVARCHAR(10),
    @MaPB VARCHAR(10)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM tblNhanvien WHERE MaNV = @MaNV)
    BEGIN
        PRINT N'Không tìm thấy nhân viên cần sửa!';
        RETURN;
    END

    UPDATE tblNhanvien
    SET HoTen = @HoTen,
        DiaChi = @DiaChi,
        NgaySinh = @NgaySinh,
        GioiTinh = @GioiTinh,
        MaPB = @MaPB
    WHERE MaNV = @MaNV;
END;
GO

CREATE PROCEDURE sp_XoaNhanVien
    @MaNV VARCHAR(10)
AS
BEGIN
    -- Kiểm tra ràng buộc trước khi xóa
    IF EXISTS (SELECT 1 FROM tblThicong WHERE MaNV = @MaNV)
    BEGIN
        PRINT N'Nhân viên đang tham gia công trình, không thể xóa!';
        RETURN; -- Thoát procedure, không thực hiện xóa
    END
    
    IF EXISTS (SELECT 1 FROM tblPhongBan WHERE MaTruongPhong = @MaNV)
    BEGIN
        PRINT N'Nhân viên đang là Trưởng phòng, cần thay đổi trưởng phòng trước khi xóa!';
        RETURN;
    END

    DELETE FROM tblNhanvien WHERE MaNV = @MaNV;
END;
GO

--Phòng ban
CREATE PROCEDURE sp_LayDanhSachPhongBan
AS
BEGIN
    SELECT 
        pb.MaPB,
        pb.TenPB,
        pb.ChucNang,
        ISNULL(tp.HoTen, N'Chưa có') AS TenTruongPhong,
        COUNT(nv.MaNV) AS SoNhanVien
    FROM tblPhongBan pb
    LEFT JOIN tblNhanVien nv
        ON pb.MaPB = nv.MaPB
    LEFT JOIN tblNhanVien tp
        ON pb.MaTruongPhong = tp.MaNV
    GROUP BY 
        pb.MaPB,
        pb.TenPB,
        pb.ChucNang,
        tp.HoTen;
END;
GO


CREATE PROCEDURE sp_ThemPhongBan
    @MaPB VARCHAR(10),
    @TenPB NVARCHAR(50),
    @ChucNang NVARCHAR(255)
AS
BEGIN
    -- Kiểm tra trùng mã phòng ban
    IF EXISTS (SELECT 1 FROM tblPhongBan WHERE MaPB = @MaPB)
    BEGIN
        PRINT N'Mã phòng ban đã tồn tại!';
        RETURN;
    END

    -- Kiểm tra trùng tên phòng ban
    IF EXISTS (SELECT 1 FROM tblPhongBan WHERE TenPB = @TenPB)
    BEGIN
        PRINT N'Tên phòng ban đã tồn tại!';
        RETURN;
    END

    -- Thêm phòng ban mới
    INSERT INTO tblPhongBan (MaPB, TenPB, ChucNang)
    VALUES (@MaPB, @TenPB, @ChucNang);
END;
GO



CREATE PROCEDURE sp_SuaPhongBan
    @MaPB VARCHAR(10),
    @TenPB NVARCHAR(50),
    @ChucNang NVARCHAR(255)
AS
BEGIN
    -- Kiểm tra phòng ban tồn tại
    IF NOT EXISTS (SELECT 1 FROM tblPhongBan WHERE MaPB = @MaPB)
    BEGIN
        PRINT N'Không tìm thấy phòng ban cần sửa!';
        RETURN;
    END

    -- Không cho trùng tên phòng ban khác
    IF EXISTS (
        SELECT 1
        FROM tblPhongBan
        WHERE TenPB = @TenPB
          AND MaPB <> @MaPB
    )
    BEGIN
        PRINT N'Tên phòng ban đã tồn tại!';
        RETURN;
    END

    -- Cập nhật thông tin phòng ban
    UPDATE tblPhongBan
    SET TenPB = @TenPB,
        ChucNang = @ChucNang
    WHERE MaPB = @MaPB;
END;
GO



CREATE PROCEDURE sp_XoaPhongBan
    @MaPB VARCHAR(10)
AS
BEGIN
    -- Kiểm tra phòng ban tồn tại
    IF NOT EXISTS (SELECT 1 FROM tblPhongBan WHERE MaPB = @MaPB)
    BEGIN
        PRINT N'Không tìm thấy phòng ban!';
        RETURN;
    END

    -- Kiểm tra còn nhân viên không
    IF EXISTS (SELECT 1 FROM tblNhanvien WHERE MaPB = @MaPB)
    BEGIN
        PRINT N'Phòng ban còn nhân viên, không thể xóa!';
        RETURN;
    END

    DELETE FROM tblPhongBan WHERE MaPB = @MaPB;
END;
GO
--Chọn trưởng phòng
CREATE PROCEDURE sp_ChonTruongPhong
    @MaPB VARCHAR(10),
    @MaNV VARCHAR(10)
AS
BEGIN
    UPDATE tblPhongBan
    SET MaTruongPhong = @MaNV
    WHERE MaPB = @MaPB
END;
GO

-- 4.1.2. NHÓM QUẢN LÝ CÔNG TRÌNH (THÊM, SỬA, XÓA)
------------------------------------------------
CREATE PROCEDURE sp_LayDanhSachCongTrinh
AS
BEGIN
    SELECT 
        ct.MaCT,
        ct.TenCT,
        ct.DiaDiem,
        ct.NgayCapPhep,
        ct.NgayKhoiCong,
        ct.NgayDuKienHoanThanh,
        COUNT(tc.MaNV) AS SoNhanVien
    FROM tblCongtrinh ct
    LEFT JOIN tblThicong tc ON ct.MaCT = tc.MaCT
    GROUP BY 
        ct.MaCT,
        ct.TenCT,
        ct.DiaDiem,
        ct.NgayCapPhep,
        ct.NgayKhoiCong,
        ct.NgayDuKienHoanThanh;
END;
GO

CREATE PROCEDURE sp_ThemCongTrinh
    @MaCT VARCHAR(10),
    @TenCT NVARCHAR(100),
    @DiaDiem NVARCHAR(100),
    @NgayCapPhep DATE,
    @NgayKhoiCong DATE,
    @NgayDuKienHoanThanh DATE
AS
BEGIN
    -- Kiểm tra mã công trình đã tồn tại
    IF EXISTS (SELECT 1 FROM tblCongtrinh WHERE MaCT = @MaCT)
    BEGIN
        PRINT N'Mã công trình đã tồn tại!';
        RETURN;
    END

    -- Kiểm tra tên công trình không được rỗng
    IF @TenCT IS NULL OR LEN(LTRIM(RTRIM(@TenCT))) = 0
    BEGIN
        PRINT N'Tên công trình không được để trống!';
        RETURN;
    END

    -- Kiểm tra ngày dự kiến hoàn thành phải sau ngày khởi công
    IF @NgayDuKienHoanThanh < @NgayKhoiCong
    BEGIN
        PRINT N'Ngày dự kiến hoàn thành phải sau ngày khởi công!';
        RETURN;
    END

    INSERT INTO tblCongtrinh (MaCT, TenCT, DiaDiem, NgayCapPhep, NgayKhoiCong, NgayDuKienHoanThanh)
    VALUES (@MaCT, @TenCT, @DiaDiem, @NgayCapPhep, @NgayKhoiCong, @NgayDuKienHoanThanh);
END;
GO

CREATE PROCEDURE sp_SuaCongTrinh
    @MaCT VARCHAR(10),
    @TenCT NVARCHAR(100),
    @DiaDiem NVARCHAR(100),
    @NgayCapPhep DATE,
    @NgayKhoiCong DATE,
    @NgayDuKienHoanThanh DATE
AS
BEGIN
    -- Kiểm tra công trình tồn tại
    IF NOT EXISTS (SELECT 1 FROM tblCongtrinh WHERE MaCT = @MaCT)
    BEGIN
        PRINT N'Không tìm thấy công trình cần sửa!';
        RETURN;
    END

    -- Kiểm tra tên công trình không được rỗng
    IF @TenCT IS NULL OR LEN(LTRIM(RTRIM(@TenCT))) = 0
    BEGIN
        PRINT N'Tên công trình không được để trống!';
        RETURN;
    END

    -- Kiểm tra ngày dự kiến hoàn thành phải sau ngày khởi công
    IF @NgayDuKienHoanThanh < @NgayKhoiCong
    BEGIN
        PRINT N'Ngày dự kiến hoàn thành phải sau ngày khởi công!';
        RETURN;
    END

    -- Cập nhật thông tin công trình
    UPDATE tblCongtrinh
    SET TenCT = @TenCT,
        DiaDiem = @DiaDiem,
        NgayCapPhep = @NgayCapPhep,
        NgayKhoiCong = @NgayKhoiCong,
        NgayDuKienHoanThanh = @NgayDuKienHoanThanh
    WHERE MaCT = @MaCT;
END;
GO

CREATE PROCEDURE sp_XoaCongTrinh
    @MaCT VARCHAR(10)
AS
BEGIN
    -- Kiểm tra công trình tồn tại
    IF NOT EXISTS (SELECT 1 FROM tblCongtrinh WHERE MaCT = @MaCT)
    BEGIN
        PRINT N'Không tìm thấy công trình!';
        RETURN;
    END

    -- Kiểm tra còn nhân viên thi công không
    IF EXISTS (SELECT 1 FROM tblThicong WHERE MaCT = @MaCT)
    BEGIN
        PRINT N'Công trình còn nhân viên thi công, không thể xóa!';
        RETURN;
    END

    DELETE FROM tblCongtrinh WHERE MaCT = @MaCT;
END;
GO

-- 4.2. NHÓM NGHIỆP VỤ (PHÂN CÔNG & CHẤM CÔNG)
-----------------------------------------------

-- SP Phân công nhân viên vào công trình (Chỉ tạo record, ngày công = 0)
CREATE PROCEDURE sp_PhanCongNhanVien
    @MaNV VARCHAR(10),
    @MaCT VARCHAR(10)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM tblThicong WHERE MaNV = @MaNV AND MaCT = @MaCT)
    BEGIN
        PRINT N'Nhân viên đã được phân công vào công trình này rồi!';
        RETURN;
    END

    INSERT INTO tblThicong (MaNV, MaCT, SoNgayCong)
    VALUES (@MaNV, @MaCT, 0);
END;
GO

-- SP Chấm công (Cập nhật số ngày công)
CREATE PROCEDURE sp_ChamCong
    @MaNV VARCHAR(10),
    @MaCT VARCHAR(10),
    @SoNgayCong INT
AS
BEGIN
    -- Kiểm tra xem đã được phân công chưa
    IF NOT EXISTS (SELECT 1 FROM tblThicong WHERE MaNV = @MaNV AND MaCT = @MaCT)
    BEGIN
        PRINT N'Nhân viên chưa được phân công vào công trình này!';
        RETURN;
    END

    UPDATE tblThicong
    SET SoNgayCong = @SoNgayCong
    WHERE MaNV = @MaNV AND MaCT = @MaCT;
END;
GO


-- Lấy danh sách Nhân viên (để đổ vào ComboBox)
CREATE PROCEDURE sp_LayDanhSachNhanVien
AS
BEGIN
    SELECT MaNV, HoTen, GioiTinh, NgaySinh, DiaChi, MaPB 
    FROM tblNhanvien;
END;
GO

-- Lấy danh sách Công trình (để đổ vào ComboBox)
CREATE PROCEDURE sp_LayDanhSachCongTrinh
AS
BEGIN
    SELECT MaCT, TenCT, DiaDiem, NgayKhoiCong, NgayDuKienHoanThanh
    FROM tblCongtrinh;
END;
GO

-- Lấy danh sách Thi công (để hiển thị lên lưới)
CREATE PROCEDURE sp_LayDanhSachThiCong
AS
BEGIN
    SELECT 
        tc.MaNV,
        nv.HoTen,
        tc.MaCT,
        ct.TenCT,
        tc.SoNgayCong
    FROM tblThicong tc
    JOIN tblNhanvien nv ON tc.MaNV = nv.MaNV
    JOIN tblCongtrinh ct ON tc.MaCT = ct.MaCT;
END;
GO

-- Xóa Phân công
CREATE PROCEDURE sp_XoaPhanCong
    @MaNV VARCHAR(10),
    @MaCT VARCHAR(10)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM tblThicong WHERE MaNV = @MaNV AND MaCT = @MaCT)
    BEGIN
        PRINT N'Không tìm thấy dữ liệu phân công để xóa!';
        RETURN;
    END

    DELETE FROM tblThicong 
    WHERE MaNV = @MaNV AND MaCT = @MaCT;
END;
GO

-- =============================================
-- 5. VIEWS (HỖ TRỢ BÁO CÁO CRYSTAL REPORT - MỤC 3.2)
-- =============================================

-- View 1: Danh sách nhân viên chi tiết kèm tên phòng ban
CREATE VIEW vw_DSNhanVien 
AS
SELECT 
    nv.MaNV, 
    nv.HoTen, 
    nv.GioiTinh, 
    nv.NgaySinh, 
    nv.DiaChi, 
    pb.TenPB
FROM tblNhanvien nv
JOIN tblPhongBan pb ON nv.MaPB = pb.MaPB;
GO

-- View 2: Thống kê tình hình nhân sự tại các công trình
CREATE VIEW vw_ThongKeCongTrinh
AS
SELECT 
    ct.MaCT,
    ct.TenCT,
    nv.MaNV,
    nv.HoTen,
    tc.SoNgayCong
FROM tblThicong tc
JOIN tblNhanvien nv ON tc.MaNV = nv.MaNV
JOIN tblCongtrinh ct ON tc.MaCT = ct.MaCT;