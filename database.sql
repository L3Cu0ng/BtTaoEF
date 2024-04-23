create database QuanLyCongTy

CREATE TABLE Congty (
    ID_CongTy INT PRIMARY KEY,
    TenCongTy VARCHAR(255),
    DiaChiCongTy VARCHAR(255),
    SoDienThoai VARCHAR(20)
);

CREATE TABLE PhongBan (
  MAPB INT PRIMARY KEY ,
  TENPB VARCHAR(50) NOT NULL,
  ID_CongTy INT NOT NULL,
  FOREIGN KEY (ID_CongTy) REFERENCES Congty(ID_CongTy)
);

CREATE TABLE NhanVien (
  MANV INT PRIMARY KEY,
  HOTEN VARCHAR(50) NOT NULL,
  NGAYSINH DATE NOT NULL,
  GIOITINH VARCHAR(1) NOT NULL,
  DIACHI VARCHAR(255) NOT NULL,
  LUONG INT NOT NULL,
  MAPB INT NOT NULL,
  FOREIGN KEY (MAPB) REFERENCES PhongBan(MAPB)
);


INSERT INTO PhongBan (MAPB, TENPB, ID_CongTy) VALUES
(1, 'Phòng Kinh Doanh', 1),
(2, 'Phòng Kế Toán', 1),
(3, 'Phòng Marketing', 1),
(4, 'Phòng Nhân Sự', 2),
(5, 'Phòng IT', 2);


INSERT INTO NhanVien (MANV, HOTEN, NGAYSINH, GIOITINH, DIACHI, LUONG, MAPB) VALUES
(1, 'Nguyen Van A', '1980-01-01', 'M', '52/52 Lâm Hoành', 1000, 1),
(2, 'Tran Thi B', '1995-05-15', 'F', '52/52 Lâm Hoành', 1200, 1),
(3, 'Hoang Minh C', '1978-12-20', 'M', '52/52 Lâm Hoành', 1500, 2),
(4, 'Le Thi D', '1992-07-10', 'F', '52/52 Lâm Hoành', 1300, 2),
(5, 'Pham Van E', '1993-03-25', 'M', '52/52 Lâm Hoành', 1100, 3),
(6, 'le Quang Bao Cuong', '1994-01-01', 'M', '52/52 Lâm Hoành', 6000, 3)
;

INSERT INTO NhanVien (MANV, HOTEN, NGAYSINH, GIOITINH, DIACHI, LUONG, MAPB) VALUES 
(6, 'le Quang Bao Cuong', '1994-01-01', 'M', '52/52 Lâm Hoành', 6000, 3);