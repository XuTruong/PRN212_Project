create database RoomManager
use RoomManager
CREATE TABLE Account (
    AccountId INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(50) UNIQUE NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    FullName NVARCHAR(100),
    CreatedAt DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1
);

CREATE TABLE Room (
    RoomId INT PRIMARY KEY IDENTITY,
    RoomName NVARCHAR(20),
    Area FLOAT,
    Price DECIMAL(18, 2),
    Status NVARCHAR(20) -- Trống, Đang thuê
);

CREATE TABLE Tenant (
    TenantId INT PRIMARY KEY IDENTITY,
    FullName NVARCHAR(100),
    Gender NVARCHAR(10),
    PhoneNumber NVARCHAR(15),
    IdNumber NVARCHAR(20),
    Dob DATE,
    Address NVARCHAR(255),
	IsActive BIT DEFAULT 1
);

CREATE TABLE Contract (
    ContractId INT PRIMARY KEY IDENTITY,
    RoomId INT FOREIGN KEY REFERENCES Room(RoomId),
    TenantId INT FOREIGN KEY REFERENCES Tenant(TenantId),
    StartDate DATE,
    EndDate DATE,
    Deposit DECIMAL(18, 2),
    Note NVARCHAR(255),
    IsActive BIT
);

CREATE TABLE MonthlyBill (
    BillId INT PRIMARY KEY IDENTITY,
    ContractId INT FOREIGN KEY REFERENCES Contract(ContractId),
    MonthYear CHAR(7), -- '2025-07'
    ElectricityOld INT,
    ElectricityNew INT,
    WaterOld INT,
    WaterNew INT,
    ElectricityRate DECIMAL(10, 2),
    WaterRate DECIMAL(10, 2),
    RoomPrice DECIMAL(18, 2),
    TotalAmount DECIMAL(18, 2),
    IsPaid BIT,
    PaymentDate DATE
);

CREATE TABLE Payment (
    PaymentId INT PRIMARY KEY IDENTITY,
    BillId INT FOREIGN KEY REFERENCES MonthlyBill(BillId),
    Amount DECIMAL(18, 2),
    PaymentDate DATE,
    Note NVARCHAR(255)
);

CREATE TABLE RoomTenant (
    RoomTenantId INT PRIMARY KEY IDENTITY,
    ContractId INT FOREIGN KEY REFERENCES Contract(ContractId),
    TenantId INT FOREIGN KEY REFERENCES Tenant(TenantId)
);

INSERT INTO Account (Username, PasswordHash, FullName, IsActive)
VALUES (
    'admin',
    '123456',
    N'Chủ trọ',
    1
);

INSERT INTO Room (RoomName, Area, Price, Status) VALUES
(N'P101', 18, 1400000, N'Occupied'),
(N'P102', 22, 1600000, N'Occupied'),
(N'P103', 25, 1600000, N'Occupied'),
(N'P104', 25, 1600000, N'Occupied'),
(N'P201', 18, 1500000, N'Occupied'),
(N'P202', 20, 1800000, N'Occupied'),
(N'P203', 22, 1400000, N'Occupied'),
(N'P301', 20, 1600000, N'Occupied'),
(N'P302', 25, 1500000, N'Available'),
(N'P303', 22, 1500000, N'Available');


INSERT INTO Tenant (FullName, Gender, PhoneNumber, IdNumber, Dob, Address) VALUES
(N'Nguyễn Văn A', N'Nam', '0970183893', '789271230', '1990-01-01', N'Tỉnh 1'),
(N'Nguyễn Văn B', N'Nam', '0943475606', '437769732', '1991-02-02', N'Tỉnh 2'),
(N'Nguyễn Văn C', N'Nữ', '0943071956', '709296969', '1992-03-03', N'Tỉnh 3'),
(N'Nguyễn Văn D', N'Nam', '0912298445', '925496289', '1993-04-04', N'Tỉnh 4'),
(N'Nguyễn Văn E', N'Nữ', '0988581751', '980680497', '1994-05-05', N'Tỉnh 5'),
(N'Nguyễn Văn F', N'Nữ', '0935404923', '689409289', '1995-06-06', N'Tỉnh 6'),
(N'Nguyễn Văn G', N'Nữ', '0992093327', '173169885', '1996-07-07', N'Tỉnh 7'),
(N'Nguyễn Văn H', N'Nữ', '0958386825', '557437160', '1997-08-08', N'Tỉnh 8'),
(N'Nguyễn Văn I', N'Nam', '0951800363', '582888727', '1998-09-09', N'Tỉnh 9'),
(N'Nguyễn Văn J', N'Nữ', '0989321371', '799674221', '1999-10-10', N'Tỉnh 10'),
(N'Nguyễn Văn K', N'Nam', '0999737901', '408147563', '1990-11-11', N'Tỉnh 11'),
(N'Nguyễn Văn L', N'Nữ', '0993286792', '377536043', '1991-12-12', N'Tỉnh 12'),
(N'Nguyễn Văn M', N'Nam', '0933345071', '310810360', '1992-01-01', N'Tỉnh 13'),
(N'Nguyễn Văn N', N'Nữ', '0918444067', '709539647', '1993-02-02', N'Tỉnh 14'),
(N'Nguyễn Văn O', N'Nữ', '0933472709', '509652241', '1994-03-03', N'Tỉnh 15');


-- Mỗi phòng từ P101 đến P108 có hợp đồng với tenant tương ứng
INSERT INTO Contract (RoomId, TenantId, StartDate, EndDate, Deposit, Note, IsActive) VALUES
(1, 1, '2024-06-01', '2025-06-01', 1400000, N'Hợp đồng thuê phòng P101', 1),
(2, 2, '2024-07-01', '2025-07-01', 1600000, N'Hợp đồng thuê phòng P102', 1),
(3, 3, '2024-08-01', '2025-08-01', 1600000, N'Hợp đồng thuê phòng P103', 1),
(4, 4, '2024-09-01', '2025-09-01', 1600000, N'Hợp đồng thuê phòng P104', 1),
(5, 5, '2024-10-01', '2025-10-01', 1500000, N'Hợp đồng thuê phòng P105', 1),
(6, 6, '2024-11-01', '2025-11-01', 1800000, N'Hợp đồng thuê phòng P106', 1),
(7, 7, '2024-12-01', '2025-12-01', 1400000, N'Hợp đồng thuê phòng P107', 1),
(8, 8, '2025-01-01', '2026-01-01', 1600000, N'Hợp đồng thuê phòng P108', 1);


INSERT INTO RoomTenant (ContractId, TenantId) VALUES
(1, 9),
(2, 10),
(3, 11),
(4, 12),
(5, 13),
(6, 14),
(7, 15);


INSERT INTO MonthlyBill (ContractId, MonthYear, ElectricityOld, ElectricityNew, WaterOld, WaterNew, ElectricityRate, WaterRate, RoomPrice, TotalAmount, IsPaid, PaymentDate) VALUES
(1, '2025-07', 113, 140, 15, 19, 3500, 15000, 1400000, 1554500, 1, '2025-07-05'),
(2, '2025-07', 131, 142, 14, 18, 3500, 15000, 1600000, 1698500, 0, NULL),
(3, '2025-07', 120, 138, 11, 14, 3500, 15000, 1600000, 1663000, 1, '2025-07-06'),
(4, '2025-07', 110, 126, 10, 13, 3500, 15000, 1600000, 1623000, 0, NULL),
(5, '2025-07', 100, 118, 12, 16, 3500, 15000, 1500000, 1581000, 1, '2025-07-03'),
(6, '2025-07', 130, 150, 13, 17, 3500, 15000, 1800000, 1891000, 0, NULL),
(7, '2025-07', 115, 130, 12, 15, 3500, 15000, 1400000, 1517500, 1, '2025-07-07'),
(8, '2025-07', 123, 137, 11, 14, 3500, 15000, 1600000, 1654500, 0, NULL);


INSERT INTO Payment (BillId, Amount, PaymentDate, Note) VALUES
(1, 1554500, '2025-07-05', N'Thanh toán tiền mặt'),
(3, 1663000, '2025-07-06', N'Thanh toán chuyển khoản'),
(5, 1581000, '2025-07-03', N'Thanh toán tiền mặt'),
(7, 1517500, '2025-07-07', N'Thanh toán tiền mặt');


