-- Xóa database nếu đã tồn tại
IF DB_ID('SmartRecruit') IS NOT NULL
BEGIN
    ALTER DATABASE SmartRecruit SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE SmartRecruit;
END
GO

-- Tạo Database
CREATE DATABASE SmartRecruit;
GO

USE SmartRecruit;
GO

-- 1. BẢNG USERS (Người dùng)
CREATE TABLE Users (
    Id NVARCHAR(450) PRIMARY KEY,
    Email NVARCHAR(256) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(MAX) NOT NULL,
    FullName NVARCHAR(200) NOT NULL,
    AvatarUrl NVARCHAR(500) DEFAULT 'https://i.pravatar.cc/150',
    Role INT NOT NULL DEFAULT 0, -- 0=CANDIDATE, 1=RECRUITER, 2=ADMIN
    IsVip BIT NOT NULL DEFAULT 0,
    CreatedAt DATETIME DEFAULT GETDATE(),
    
    INDEX IX_Users_Email (Email),
    INDEX IX_Users_Role (Role)
);
GO

-- 2. BẢNG JOBS (Công việc)
CREATE TABLE Jobs (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    RecruiterId NVARCHAR(450) NOT NULL,
    Title NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX) NOT NULL,
    Requirement NVARCHAR(MAX) NOT NULL,
    SkillsRequired NVARCHAR(MAX) NOT NULL,
    SalaryMin DECIMAL(10,2) NOT NULL,
    SalaryMax DECIMAL(10,2) NOT NULL,
    JobType INT NOT NULL,
    Status INT NOT NULL DEFAULT 0,
    ViewCount INT DEFAULT 0,
    Location NVARCHAR(100) NOT NULL,
    Category NVARCHAR(100) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL,
    
    FOREIGN KEY (RecruiterId) REFERENCES Users(Id),
    
    INDEX IX_Jobs_RecruiterId (RecruiterId),
    INDEX IX_Jobs_Status (Status),
    INDEX IX_Jobs_CreatedAt (CreatedAt DESC)
);
GO

-- 3. BẢNG CANDIDATE_PROFILES
CREATE TABLE CandidateProfiles (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    UserId NVARCHAR(450) UNIQUE NOT NULL,
    Skills NVARCHAR(MAX),
    ExperienceYears INT DEFAULT 0,
    CVText NVARCHAR(MAX),
    ExpectedSalary DECIMAL(10,2) NULL,
    UpdatedAt DATETIME DEFAULT GETDATE(),
    
    FOREIGN KEY (UserId) REFERENCES Users(Id),
    
    INDEX IX_CandidateProfiles_UserId (UserId)
);
GO

-- 4. BẢNG APPLICATIONS
CREATE TABLE Applications (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    JobId UNIQUEIDENTIFIER NOT NULL,
    CandidateId NVARCHAR(450) NOT NULL,

    MatchScore DECIMAL(5,2) DEFAULT 0,
    SkillMatch DECIMAL(5,2) DEFAULT 0,
    ExperienceMatch DECIMAL(5,2) DEFAULT 0,
    AI_Summary NVARCHAR(1000),

    Status INT DEFAULT 0,
    AppliedAt DATETIME DEFAULT GETDATE(),
    Notes NVARCHAR(MAX),
    
    FOREIGN KEY (JobId) REFERENCES Jobs(Id) ON DELETE CASCADE,
    FOREIGN KEY (CandidateId) REFERENCES Users(Id),
    
    UNIQUE (JobId, CandidateId),
    
    INDEX IX_Applications_JobId (JobId),
    INDEX IX_Applications_CandidateId (CandidateId),
    INDEX IX_Applications_Status (Status),
    INDEX IX_Applications_MatchScore (MatchScore DESC)
);
GO

-- 5. BẢNG WALLETS
CREATE TABLE Wallets (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    UserId NVARCHAR(450) UNIQUE NOT NULL,
    Balance DECIMAL(10,2) DEFAULT 0,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL,
    
    FOREIGN KEY (UserId) REFERENCES Users(Id),
    
    INDEX IX_Wallets_UserId (UserId)
);
GO

-- 6. BẢNG TRANSACTIONS
CREATE TABLE Transactions (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    UserId NVARCHAR(450) NOT NULL,
    WalletId UNIQUEIDENTIFIER NOT NULL,
    
    Amount DECIMAL(10,2) NOT NULL,
    Type INT NOT NULL,
    Status INT DEFAULT 0,
    
    OrderCode BIGINT NULL,
    
    Description NVARCHAR(200) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    
    FOREIGN KEY (UserId) REFERENCES Users(Id),
    FOREIGN KEY (WalletId) REFERENCES Wallets(Id),
    
    INDEX IX_Transactions_UserId (UserId),
    INDEX IX_Transactions_WalletId (WalletId),
    INDEX IX_Transactions_Status (Status),
    INDEX IX_Transactions_CreatedAt (CreatedAt DESC),
    INDEX IX_Transactions_OrderCode (OrderCode) WHERE OrderCode IS NOT NULL
);
GO

-- 7. BẢNG NOTIFICATIONS
CREATE TABLE Notifications (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    UserId NVARCHAR(450) NOT NULL,
    Title NVARCHAR(200) NOT NULL,
    Message NVARCHAR(500) NOT NULL,
    Type INT DEFAULT 0,
    RedirectUrl NVARCHAR(500),
    IsRead BIT DEFAULT 0,
    CreatedAt DATETIME DEFAULT GETDATE(),
    
    FOREIGN KEY (UserId) REFERENCES Users(Id),
    
    INDEX IX_Notifications_UserId (UserId),
    INDEX IX_Notifications_IsRead (IsRead),
    INDEX IX_Notifications_CreatedAt (CreatedAt DESC)
);
GO

-- THÊM DỮ LIỆU MẪU
INSERT INTO Users (Id, Email, PasswordHash, FullName, Role, IsVip) VALUES
('cand-1', 'alice@dev.com', '$2a$10$...', 'Alice Developer', 0, 0),
('rec-1', 'hr@techcorp.com', '$2a$10$...', 'John HR Manager', 1, 1),
('admin-1', 'admin@smartrecruit.com', '$2a$10$...', 'System Admin', 2, 0);

INSERT INTO Wallets (Id, UserId, Balance) VALUES
(NEWID(), 'cand-1', 0),
(NEWID(), 'rec-1', 2500000),
(NEWID(), 'admin-1', 0);
GO
