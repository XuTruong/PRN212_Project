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
    Address NVARCHAR(255)
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
