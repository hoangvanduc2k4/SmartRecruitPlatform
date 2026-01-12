https://deepwiki.com/hoangvanduc2k4/SmartRecruitPlatform
---

# 🚀 SmartRecruit Recruitment System

**SmartRecruit** là hệ thống hỗ trợ tuyển dụng thông minh, giúp kết nối Nhà tuyển dụng (Recruiter) và Ứng viên (Candidate) thông qua cơ chế chấm điểm hồ sơ bằng AI (Gemini). Dự án được xây dựng theo chuẩn kiến trúc sạch (Clean Architecture) để đảm bảo tính mở rộng và dễ bảo trì.

---

## 🏗 Clean Architecture Workflow

Dự án tuân thủ nguyên tắc Dependency Rule: **Các lớp bên trong không phụ thuộc vào các lớp bên ngoài.**

1. **`SmartRecruit.Domain` (The Core):**
* **Entities:** Chứa các bảng Database (User, Job, Wallet...).
* **Constants:** Chứa hằng số hệ thống, Roles, English Messages.
* **Exceptions:** Chứa các Custom Exceptions (NotFound, BadRequest).
* **Enums:** Các trạng thái (JobStatus, ApplicationStatus).


2. **`SmartRecruit.Application` (Business Logic):**
* **Interfaces:** Định nghĩa "hợp đồng" cho Repository, UnitOfWork và Services.
* **DTOs:** Đối tượng vận chuyển dữ liệu giữa API và Client.
* **Utils:** Các công cụ dùng chung (PasswordUtil, JwtUtil).


3. **`SmartRecruit.Infrastructure` (Data & External Services):**
* **Data:** DBContext và Migrations.
* **Repositories:** Triển khai `GenericRepository` và `UnitOfWork` (EF Core).
* **External Services:** Implement PayOS, Gemini AI, Email Service.


4. **`SmartRecruit.API` (Presentation - Server):**
* Các Controllers xử lý Request và trả về JSON chuẩn.
* Cấu hình Middleware xử lý lỗi tập trung (Global Exception Handling).


5. **`SmartRecruit.WebPortal` (Presentation - Client):**
* Sử dụng Razor Pages gọi API qua `HttpClient` để hiển thị giao diện.



---

## 🛠 Tech Stack

* **Backend:** .NET 8 (C#)
* **ORM:** Entity Framework Core (Code First)
* **Database:** SQL Server
* **AI:** Google Gemini API (Matching Score logic)
* **Payment:** PayOS Integration
* **Security:** JWT, BCrypt Hashing

---

## 🚦 Getting Started (Dành cho Team Member)

Để bắt đầu làm task, bạn cần thực hiện các bước sau:

### 1. Cấu hình môi trường

* Cài đặt **.NET 8 SDK** và **SQL Server**.
* Mở project, tìm file `appsettings.json` trong **SmartRecruit.API**.
* Sửa `DefaultConnection` trỏ về Database local của bạn.

### 2. Khởi tạo Database & Seed Data

Dự án đã có sẵn code Auto-Seed để tạo dữ liệu mẫu (1 Admin, 5 HR, 30 Candidates, 20 Jobs).

* Mở **Package Manager Console**.
* Chọn Default Project: `SmartRecruit.Infrastructure`.
* Chạy lệnh: `Update-Database`.

### 3. Cách code Task mới

Khi làm một tính năng (ví dụ: *Xem ví tiền*), hãy tuân thủ luồng:

1. **Define Interface** trong tầng `Application`.
2. **Implement Logic** trong tầng `Infrastructure` (nếu cần truy vấn DB).
3. **Write Controller** trong tầng `API`.
4. **Call API** từ tầng `WebPortal` bằng `Service` tương ứng.

---

## ⚠️ Lưu ý quan trọng

* **No Hard-coding:** Tất cả thông báo trả về phải dùng `Messages.cs` trong tầng Domain.
* **Soft Delete:** Hầu hết các bảng đều dùng cờ `IsDeleted`. Hạn chế xóa vật lý bản ghi.
* **Exceptions:** Không dùng `try-catch` tràn lan. Hãy `throw` các Custom Exception (ví dụ: `throw new NotFoundException(...)`), hệ thống sẽ tự xử lý trả về JSON phù hợp cho Client.
* **Password:** Luôn dùng `PasswordUtil.HashPassword()` trước khi lưu.

---

## 🗄️ Database Diagram Overview

Hệ thống quản lý mối quan hệ chặt chẽ giữa: **User <-> Wallet <-> Transaction** và **Job <-> Application <-> CandidateProfile**.

---

