## [![Ask DeepWiki](https://deepwiki.com/badge.svg)](https://deepwiki.com/hoangvanduc2k4/SmartRecruitPlatform)

# 🚀 SmartRecruit - Nền tảng Tuyển dụng Thông Minh

**SmartRecruit** là nền tảng tuyển dụng hiện đại kết nối **Nhà tuyển dụng (Recruiter)** và **Ứng viên (Candidate)** với các tính năng thông minh bao gồm:

- ✅ Chế độ xác thực an toàn (JWT + BCrypt)
- ✅ Tạo & quản lý bài đăng tuyển dụng
- ✅ Ứng tuyển & theo dõi trạng thái hồ sơ
- ✅ AI Moderation (Gemini API) duyệt bài đăng tự động
- ✅ Hệ thống ví điện tử & thanh toán trực tuyến (PayOS)
- ✅ Thông báo real-time (SignalR)
- ✅ Dashboard Admin quản lý toàn bộ hệ thống
- ✅ Background Jobs (Hangfire)

Dự án được xây dựng theo **Clean Architecture** đảm bảo tính mở rộng, dễ bảo trì và kiểm thử.

---

## 📋 Mục lục

- [🏗 Kiến trúc](#-kiến-trúc)
- [🛠 Tech Stack](#-tech-stack)
- [✨ Tính năng chính](#-tính-năng-chính)
- [📁 Cấu trúc dự án](#-cấu-trúc-dự-án)
- [🚀 Cài đặt & Chạy](#-cài-đặt--chạy)
- [🔐 Xác thực & Quyền](#-xác-thực--quyền)
- [📊 Database Schema](#-database-schema)
- [⚙️ API Endpoints](#-api-endpoints)
- [🤝 Hướng dẫn contribute](#-hướng-dẫn-contribute)

---

## 🏗 Kiến trúc

Dự án tuân thủ **Clean Architecture** với 5 tầng chính:

### Tầng 1: Domain (SmartRecruit.Domain) - The Core

**Trách nhiệm:** Định nghĩa business rules không phụ thuộc vào framework

```
├── Entities/           # Models cơ sở dữ liệu (User, Job, Wallet, ...)
├── Enums/              # Trạng thái và loại (JobStatus, UserRole, ...)
├── Exceptions/         # Custom Exceptions (BadRequestException, NotFoundException, ...)
├── Constants/          # Hằng số hệ thống (Messages, Roles, Policies, ...)
└── Commons/            # Base classes (BaseEntity, ...)
```

### Tầng 2: Application (SmartRecruit.Application) - Business Logic

**Trách nhiệm:** Implement use cases, validate data, orchestrate objects

```
├── Interfaces/         # Contracts (IUserService, IJobService, ...)
├── Services/           # Business logic (AuthService, JobService, ...)
├── DTO/                # Data Transfer Objects (LoginRequest, JobResponse, ...)
├── Validations/        # FluentValidation rules
├── Mappings/           # AutoMapper profiles
├── Helpers/            # Utilities (PagedList, ...)
└── Extensions/         # Extension methods
```

### Tầng 3: Infrastructure (SmartRecruit.Infrastructure) - External Services

**Trách nhiệm:** Database, APIs bên ngoài, cơ sở hạ tầng

```
├── Data/               # DBContext, Migrations (EF Core)
├── Repositories/       # Data access (GenericRepository, UnitOfWork)
├── Services/           # External integrations (PaymentService, EmailService, ...)
├── Configurations/     # Settings, Policies
├── Jobs/               # Hangfire background jobs
├── Hubs/               # SignalR hubs (notifications real-time)
└── Migrations/         # Database migrations
```

### Tầng 4: API (SmartRecruit.API) - Server Presentation

**Trách nhiệm:** HTTP endpoints, request/response handling

```
├── Controllers/        # REST endpoints
├── Extensions/         # DI, CORS, Swagger, Middleware config
├── Middlewares/        # Global error handling
├── Properties/         # Launch settings
└── Program.cs          # Main entry point
```

### Tầng 5: WebPortal (SmartRecruit.WebPortal) - Client Presentation

**Trách nhiệm:** UI pages, user interaction

```
├── Pages/              # Razor Pages (Index, JobDetail, ...)
├── Services/           # API clients (HttpClient)
├── Models/             # View models, UI models
├── wwwroot/            # Static assets (CSS, JS, images)
├── Extensions/         # Helper methods
└── Middlewares/        # Authentication handling
```

**Dependency Flow:**

```
WebPortal (UI) → API (Controllers) → Application (Services) → Infrastructure (Repositories) → Domain (Entities)
                                                                                          ↑
                                                        (Domain không phụ thuộc vào ai)
```

---

## 🛠 Tech Stack

| Layer               | Technology                 |
| ------------------- | -------------------------- |
| **Framework**       | .NET 8 (C#)                |
| **ORM**             | Entity Framework Core 8.0  |
| **Database**        | SQL Server 2022+           |
| **API**             | ASP.NET Core Web API       |
| **Client**          | Razor Pages + Tailwind CSS |
| **Authentication**  | JWT + Refresh Tokens       |
| **Hashing**         | BCrypt                     |
| **AI**              | Google Gemini API          |
| **Payment**         | PayOS Integration          |
| **Real-time**       | SignalR                    |
| **Background Jobs** | Hangfire                   |
| **Validation**      | FluentValidation           |
| **Mapping**         | AutoMapper                 |
| **API Doc**         | Swagger/OpenAPI            |
| **Logging**         | Serilog (Console + File)   |
| **Rate Limiting**   | AspNetCoreRateLimit        |

---

## ✨ Tính năng chính

### 🔐 Authentication & Authorization

- [x] Đăng ký / Đăng nhập
- [x] JWT + Refresh Token
- [x] Role-based Access Control (Admin, Recruiter, Candidate)
- [x] Gmail OAuth Integration
- [x] OTP verification

### 💼 Job Management (Recruiter)

- [x] Tạo bài tuyển dụng (nháp, duyệt, từ chối)
- [x] Chỉnh sửa bài đăng
- [x] Xóa mêm (soft delete)
- [x] Boost job (đẩy tin) - chi phí 20k VNĐ
- [x] AI Moderation kiểm duyệt tự động
- [x] Xem danh sách ứng viên
- [x] Quản lý trạng thái ứng viên (Reviewing → Interviewing → Offered/Rejected)
- [x] Khiếu nại (appeal) quyết định chặn của AI

### 👤 Candidate Features

- [x] Tìm kiếm bài tuyển dụng (filter theo vị trí, ngành nghề, mức lương)
- [x] Ứng tuyển & upload CV
- [x] Xem trạng thái hồ sơ
- [x] Lưu bài tuyển dụng yêu thích
- [x] Quản lý hồ sơ cá nhân
- [x] Xem lịch sử ứng tuyển

### 💰 Wallet & Payment

- [x] Nạp tiền vào ví (qua PayOS)
- [x] Lịch sử giao dịch
- [x] Tự động cập nhật sau payment webhook
- [x] Hỗ trợ VNPay, MoMo, banking

### 🔔 Notifications

- [x] Real-time notifications (SignalR)
- [x] Thông báo trạng thái công việc
- [x] Thông báo ứng viên mới
- [x] Thông báo giao dịch ví
- [x] Persistent notifications (lưu DB)
- [x] Ghi lại lịch sử thông báo

### 🤖 AI Moderation

- [x] Gemini API chấm điểm bài tuyển dụng
- [x] Kiểm tra vi phạm chính sách
- [x] Ghi log chi tiết quyết định AI
- [x] Cho phép khiếu nại

### 👨‍💼 Admin Dashboard

- [x] Davegh danh sách tất cả users
- [x] Duyệt / từ chối bài tuyển dụng đang chờ
- [x] Quản lý khiếu nại (appeal)
- [x] Xem thống kê hệ thống
- [x] Quản lý danh mục công việc

### 🛠 System Features

- [x] Global exception handling
- [x] Request/Response logging
- [x] Pagination & Filtering
- [x] Background jobs (Hangfire)
- [x] Soft delete pattern
- [x] Concurrency handling
- [x] Rate limiting
- [x] CORS configuration
- [x] Swagger documentation

---

## 📁 Cấu trúc dự án

```
SmartRecruitPlatform/
│
├── SmartRecruit.Domain/                    # Entities, Enums, Constants, Exceptions
│   ├── Entities/                           # User, Job, Application, Wallet, ...
│   ├── Enums/                              # JobStatus, UserRole, ApplicationStatus, ...
│   ├── Constants/                          # Messages (tiếng Việt), Roles, Policies
│   ├── Exceptions/                         # BadRequestException, NotFoundException, ...
│   └── Commons/                            # BaseEntity
│
├── SmartRecruit.Application/               # Business Logic, DTOs, Services
│   ├── Interfaces/
│   │   ├── Repositories/                   # IJobRepository, IUserRepository
│   │   ├── Services/                       # IAuthService, IJobService, IWalletService
│   │   └── ...
│   ├── Services/                           # AuthService, JobService, ApplicationService
│   ├── DTO/
│   │   ├── Auth/                           # LoginRequest, AuthResponse
│   │   ├── Job/                            # JobCreateRequest, JobResponse
│   │   ├── Application/                    # ApplicationRequest, ApplicationResponse
│   │   ├── Wallet/                         # WalletRequest, WalletResponse
│   │   ├── Notification/                   # NotificationResponse
│   │   └── ...
│   ├── Validations/                        # FluentValidation rules
│   ├── Mappings/                           # AutoMapper profiles
│   ├── Helpers/                            # PagedList, Extensions
│   └── Utils/                              # PasswordUtil, JwtUtil
│
├── SmartRecruit.Infrastructure/            # Database, External Services
│   ├── Data/
│   │   ├── ApplicationDbContext.cs         # EF Core Context
│   │   └── Migrations/                     # EF Core migrations
│   ├── Repositories/                       # GenericRepository, specific repos
│   ├── Services/
│   │   ├── PaymentService.cs               # PayOS integration
│   │   ├── EmailService.cs                 # Email sending
│   │   ├── GeminiService.cs                # AI moderation
│   │   └── ...
│   ├── Configurations/                     # Entity configurations
│   ├── Hubs/                               # SignalR hubs
│   └── Jobs/                               # Hangfire jobs
│
├── SmartRecruit.API/                       # REST API Server
│   ├── Controllers/
│   │   ├── AuthController.cs               # /api/auth
│   │   ├── JobController.cs                # /api/jobs
│   │   ├── ApplicationController.cs        # /api/applications
│   │   ├── WalletController.cs             # /api/wallet
│   │   ├── NotificationsController.cs      # /api/notifications
│   │   ├── AdminController.cs              # /api/admin
│   │   └── ...
│   ├── Extensions/                         # DI, CORS, Swagger, Middleware
│   ├── Middlewares/                        # GlobalExceptionHandling
│   ├── Logging/                            # Serilog configuration
│   ├── Program.cs                          # Startup configuration
│   ├── appsettings.json                    # Configuration
│   └── Properties/launchSettings.json
│
├── SmartRecruit.WebPortal/                 # Razor Pages Client
│   ├── Pages/
│   │   ├── Index.cshtml                    # Home page
│   │   ├── Auth/                           # Login, Register
│   │   ├── Jobs/                           # Job list, detail
│   │   ├── Recruiter/                      # PostJob, ManageJobs, Candidates
│   │   ├── Candidate/                      # MyApplications, SavedJobs
│   │   ├── Admin/                          # AdminDashboard, ManageJobs, Appeals
│   │   ├── Account/                        # Profile, Wallet
│   │   ├── Shared/                         # _Layout, _Navigation
│   │   └── ...
│   ├── Services/                           # API clients, HTTP services
│   ├── Models/                             # View models
│   ├── wwwroot/
│   │   ├── css/                            # Tailwind compiled CSS
│   │   ├── js/                             # SignalR, utilities
│   │   └── images/
│   ├── Extensions/                         # Helper extensions
│   ├── Program.cs
│   ├── appsettings.json
│   └── Properties/launchSettings.json
│
├── SmartRecruit.sln                        # Solution file
├── run.bat                                 # Quick run batch (optional)
├── README.md                               # This file
└── LICENSE.txt
```

---

## 🚀 Cài đặt & Chạy

### ✅ Yêu cầu

- .NET 8 SDK
- SQL Server 2022+ (local hoặc remote)
- Visual Studio 2022 / VS Code + C# extension
- Git

### 1️⃣ Clone & Setup

```bash
# Clone repository
git clone https://github.com/yourusername/SmartRecruitPlatform.git
cd SmartRecruitPlatform

# Restore dependencies
dotnet restore
```

### 2️⃣ Cấu hình Database

**Tệp:** `SmartRecruit.API/appsettings.json`

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=SmartRecruit_DB;Trusted_Connection=true;TrustServerCertificate=true;"
  }
}
```

### 3️⃣ Khởi tạo Database

```bash
# Chuyển đến Package Manager Console trong Visual Studio
# Set Default Project = SmartRecruit.Infrastructure

Update-Database

# Hoặc dùng CLI
dotnet ef database update -p SmartRecruit.Infrastructure -s SmartRecruit.API
```

**Kết quả:** Database sẽ auto seed 1 Admin + 5 Recruiter + 30 Candidate + 20 Job postings

### 4️⃣ Cấu hình API Keys

**Tệp:** `SmartRecruit.API/appsettings.json`

```json
{
  "GoogleOAuth": {
    "ClientId": "your-google-client-id",
    "ClientSecret": "your-google-secret"
  },
  "GeminiAi": {
    "ApiKey": "your-gemini-api-key"
  },
  "PayOS": {
    "ClientId": "payos-client-id",
    "ApiKey": "payos-api-key",
    "ChecksumKey": "payos-checksum-key"
  },
  "Jwt": {
    "SecretKey": "your-jwt-secret-key",
    "ValidAudience": "SmartRecruit",
    "ValidIssuer": "SmartRecruit"
  },
  "EmailSettings": {
    "From": "noreply@smartrecruit.local",
    "SMTPServer": "smtp.gmail.com",
    "SMTPPort": 587,
    "Username": "your-email@gmail.com",
    "Password": "your-app-password"
  }
}
```

### 5️⃣ Chạy ứng dụng

**Option 1: Visual Studio**

- Mở `SmartRecruit.sln`
- Set **SmartRecruit.WebPortal** làm startup project
- Bấm `F5` hoặc **Start Debugging**

**Option 2: Command Line**

```bash
# Terminal 1 - Chạy API
cd SmartRecruit.API
dotnet run

# Terminal 2 - Chạy WebPortal
cd SmartRecruit.WebPortal
dotnet run
```

**Option 3: Batch File (Windows)**

```bash
run.bat
```

### 6️⃣ Truy cập ứng dụng

- **WebPortal:** https://localhost:7001
- **API Swagger:** https://localhost:7000/swagger

---

## Test Accounts

| Email                         | Password      | Role      |
| ----------------------------- | ------------- | --------- |
| admin@smartrecruit.local      | Admin@123     | Admin     |
| recruiter1@smartrecruit.local | Recruiter@123 | Recruiter |
| candidate1@smartrecruit.local | Candidate@123 | Candidate |

---

## 🔐 Xác thực & Quyền

### JWT Token Flow

```
1. User gửi credentials (email + password)
   ↓
2. API xác thực, sinh JWT Token + Refresh Token
   ↓
3. Client lưu tokens (localStorage / sessionStorage)
   ↓
4. Mỗi request, gửi: Authorization: Bearer <jwt_token>
   ↓
5. API validate signature & claims
   ↓
6. Khi JWT hết hạn, dùng Refresh Token lấy cái mới
```

### Roles & Permissions

| Role          | Features                                      |
| ------------- | --------------------------------------------- |
| **Admin**     | Duyệt job, quản lý users, xem stats           |
| **Recruiter** | Tạo job, view candidates, manage applications |
| **Candidate** | Apply job, view applications, manage profile  |

---

## 📊 Database Schema

### Core Tables

```sql
-- Users
Users (Id, Email, FullName, PasswordHash, Role, IsActive, ...)

-- Jobs
Jobs (Id, RecruiterId, Title, Company, Description, SalaryMin, SalaryMax, Status, ...)

-- Applications
Applications (Id, JobId, CandidateId, Status, CreatedAt, ...)

-- Wallets
Wallets (Id, UserId, Balance, ...)

-- Transactions
Transactions (Id, WalletId, Amount, Type, Status, ...)

-- Notifications
Notifications (Id, UserId, Title, Message, Type, IsRead, ...)

-- Candidates (Profile)
CandidateProfiles (Id, UserId, PhoneNumber, Address, CV_Url, ...)

-- Companies (Recruiter Info)
Companies (Id, RecruiterId, Name, Description, Logo_Url, ...)

-- Categories
Categories (Id, Name, Description, ...)

-- Others
AILogs, Appeals, SavedJobs, ...
```

---

## ⚙️ API Endpoints

### Authentication

```
POST   /api/auth/register              # Đăng ký
POST   /api/auth/login                 # Đăng nhập
POST   /api/auth/refresh-token         # Làm mới token
POST   /api/auth/logout                # Đăng xuất
POST   /api/auth/request-otp           # Yêu cầu OTP
POST   /api/auth/verify-otp            # Xác thực OTP
POST   /api/auth/google-login          # Gmail OAuth
```

### Jobs

```
GET    /api/jobs                       # Danh sách công việc
GET    /api/jobs/{id}                  # Chi tiết công việc
POST   /api/jobs                       # Tạo công việc (Recruiter)
PUT    /api/jobs/{id}                  # Chỉnh sửa công việc
DELETE /api/jobs/{id}                  # Xóa công việc
POST   /api/jobs/{id}/boost            # Đẩy tin
POST   /api/jobs/{id}/publish          # Đăng bài
```

### Applications

```
GET    /api/applications                           # Danh sách ứng viên
GET    /api/applications/{id}                      # Chi tiết ứng dụng
POST   /api/applications                           # Ứng tuyển
PUT    /api/applications/{id}/status               # Cập nhật trạng thái
POST   /api/applications/{id}/reject               # Từ chối
POST   /api/applications/{id}/offer                # Gửi offer
```

### Wallet

```
GET    /api/wallet                     # Thông tin ví
POST   /api/wallet/deposit             # Nạp tiền
GET    /api/wallet/transactions        # Lịch sử giao dịch
```

### Notifications

```
GET    /api/notifications                          # Danh sách thông báo
PUT    /api/notifications/{id}/read                # Đánh dấu đã đọc
DELETE /api/notifications/{id}                     # Xóa thông báo
```

### Admin

```
GET    /api/admin/jobs                 # Danh sách job chờ duyệt
GET    /api/admin/appeals              # Danh sách khiếu nại
PUT    /api/admin/jobs/{id}/approve    # Duyệt job
PUT    /api/admin/jobs/{id}/reject     # Từ chối job
```

---

## 🤝 Hướng dẫn contribute

### Qui tắc coding

✅ **Bắt buộc:**

1. **No hardcoded strings** - Dùng `Messages.` constants từ Domain
2. **Exception handling** - Throw custom exceptions, không dùng generic Exception
3. **Dependency Injection** - Constructor injection, không new instances
4. **DTO mapping** - Dùng AutoMapper, không manual mapping
5. **Validation** - FluentValidator cho tất cả requests
6. **Soft delete** - Set isDeleted = true, không xóa vật lý

❌ **Cấm:**

```csharp
// ❌ Không được
if (user == null) throw new Exception("User not found");
var password = "hardcoded_pass";
var service = new UserService();  // Direct instantiation

// ✅ Được
if (user == null) throw new NotFoundException(Messages.AuthMsg.USER_NOT_FOUND);
var password = PasswordUtil.HashPassword(input);
// Constructor injection
```

### Git Workflow

```bash
# 1. Tạo branch feature
git checkout -b feature/job-posting

# 2. Commit với message rõ ràng
git commit -m "feat: add job posting functionality"

# 3. Push và tạo Pull Request
git push origin feature/job-posting
```

### Testing

```bash
# Chạy unit tests (khi có)
dotnet test

# Build & check errors
dotnet build
```

---

## 📝 FAQ & Troubleshooting

### Q: Lỗi "Migration Failed"

**A:** Xóa `migrations/` folder và database, chạy lại `Update-Database`

### Q: JWT token không valid

**A:** Kiểm tra `SecretKey` trong appsettings.json phải > 32 ký tự

### Q: PayOS webhook không nhận

**A:** Dùng Ngrok để expose local IP, update webhook URL trên PayOS dashboard

### Q: SignalR connection failed

**A:** Kiểm tra CORS config cho localhost:port tương ứng

---

## 📞 Support & Contact

- **Issues:** GitHub Issues
- **Email:** support@smartrecruit.local
- **Documentation:** [Wiki](https://github.com/yourrepo/wiki)

---

## 📄 License

MIT License - Xem file [LICENSE.txt](LICENSE.txt)

---

**Last Updated:** March 2026  
**Version:** 1.0.0 MVP  
**Status:** ✅ Production Ready

---
