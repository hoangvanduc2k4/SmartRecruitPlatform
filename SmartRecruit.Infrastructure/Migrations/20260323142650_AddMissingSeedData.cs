using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartRecruit.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMissingSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AILogs",
                columns: new[] { "Id", "AIType", "CreatedAt", "Decision", "InputText", "JobId", "OutputResult", "Reason" },
                values: new object[,]
                {
                    { 1L, 2, new DateTime(2024, 1, 1, 1, 0, 0, 0, DateTimeKind.Utc), "BLOCK", "Yêu cầu cung cấp thông tin tài khoản ngân hàng trong mô tả công việc...", 2L, "BLOCK", "Phát hiện dấu hiệu lừa đảo: Yêu cầu thông tin nhạy cảm." },
                    { 2L, 2, new DateTime(2024, 1, 1, 2, 0, 0, 0, DateTimeKind.Utc), "BLOCK", "Yêu cầu cung cấp thông tin tài khoản ngân hàng trong mô tả công việc...", 3L, "BLOCK", "Phát hiện dấu hiệu lừa đảo: Yêu cầu thông tin nhạy cảm." },
                    { 3L, 2, new DateTime(2024, 1, 1, 3, 0, 0, 0, DateTimeKind.Utc), "BLOCK", "Yêu cầu cung cấp thông tin tài khoản ngân hàng trong mô tả công việc...", 4L, "BLOCK", "Phát hiện dấu hiệu lừa đảo: Yêu cầu thông tin nhạy cảm." },
                    { 4L, 2, new DateTime(2024, 1, 1, 4, 0, 0, 0, DateTimeKind.Utc), "BLOCK", "Yêu cầu cung cấp thông tin tài khoản ngân hàng trong mô tả công việc...", 5L, "BLOCK", "Phát hiện dấu hiệu lừa đảo: Yêu cầu thông tin nhạy cảm." },
                    { 5L, 2, new DateTime(2024, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), "BLOCK", "Yêu cầu cung cấp thông tin tài khoản ngân hàng trong mô tả công việc...", 6L, "BLOCK", "Phát hiện dấu hiệu lừa đảo: Yêu cầu thông tin nhạy cảm." },
                    { 6L, 2, new DateTime(2024, 1, 1, 6, 0, 0, 0, DateTimeKind.Utc), "BLOCK", "Yêu cầu cung cấp thông tin tài khoản ngân hàng trong mô tả công việc...", 7L, "BLOCK", "Phát hiện dấu hiệu lừa đảo: Yêu cầu thông tin nhạy cảm." },
                    { 7L, 2, new DateTime(2024, 1, 1, 7, 0, 0, 0, DateTimeKind.Utc), "BLOCK", "Yêu cầu cung cấp thông tin tài khoản ngân hàng trong mô tả công việc...", 8L, "BLOCK", "Phát hiện dấu hiệu lừa đảo: Yêu cầu thông tin nhạy cảm." },
                    { 8L, 2, new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "BLOCK", "Yêu cầu cung cấp thông tin tài khoản ngân hàng trong mô tả công việc...", 9L, "BLOCK", "Phát hiện dấu hiệu lừa đảo: Yêu cầu thông tin nhạy cảm." },
                    { 9L, 2, new DateTime(2024, 1, 1, 9, 0, 0, 0, DateTimeKind.Utc), "BLOCK", "Yêu cầu cung cấp thông tin tài khoản ngân hàng trong mô tả công việc...", 10L, "BLOCK", "Phát hiện dấu hiệu lừa đảo: Yêu cầu thông tin nhạy cảm." },
                    { 10L, 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "BLOCK", "Yêu cầu cung cấp thông tin tài khoản ngân hàng trong mô tả công việc...", 11L, "BLOCK", "Phát hiện dấu hiệu lừa đảo: Yêu cầu thông tin nhạy cảm." },
                    { 11L, 2, new DateTime(2024, 1, 1, 11, 0, 0, 0, DateTimeKind.Utc), "BLOCK", "Yêu cầu cung cấp thông tin tài khoản ngân hàng trong mô tả công việc...", 12L, "BLOCK", "Phát hiện dấu hiệu lừa đảo: Yêu cầu thông tin nhạy cảm." },
                    { 12L, 2, new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), "BLOCK", "Yêu cầu cung cấp thông tin tài khoản ngân hàng trong mô tả công việc...", 13L, "BLOCK", "Phát hiện dấu hiệu lừa đảo: Yêu cầu thông tin nhạy cảm." },
                    { 13L, 2, new DateTime(2024, 1, 1, 13, 0, 0, 0, DateTimeKind.Utc), "BLOCK", "Yêu cầu cung cấp thông tin tài khoản ngân hàng trong mô tả công việc...", 14L, "BLOCK", "Phát hiện dấu hiệu lừa đảo: Yêu cầu thông tin nhạy cảm." },
                    { 14L, 2, new DateTime(2024, 1, 1, 14, 0, 0, 0, DateTimeKind.Utc), "BLOCK", "Yêu cầu cung cấp thông tin tài khoản ngân hàng trong mô tả công việc...", 15L, "BLOCK", "Phát hiện dấu hiệu lừa đảo: Yêu cầu thông tin nhạy cảm." },
                    { 15L, 2, new DateTime(2024, 1, 1, 15, 0, 0, 0, DateTimeKind.Utc), "BLOCK", "Yêu cầu cung cấp thông tin tài khoản ngân hàng trong mô tả công việc...", 16L, "BLOCK", "Phát hiện dấu hiệu lừa đảo: Yêu cầu thông tin nhạy cảm." },
                    { 16L, 2, new DateTime(2024, 1, 1, 16, 0, 0, 0, DateTimeKind.Utc), "BLOCK", "Yêu cầu cung cấp thông tin tài khoản ngân hàng trong mô tả công việc...", 17L, "BLOCK", "Phát hiện dấu hiệu lừa đảo: Yêu cầu thông tin nhạy cảm." },
                    { 17L, 2, new DateTime(2024, 1, 1, 17, 0, 0, 0, DateTimeKind.Utc), "BLOCK", "Yêu cầu cung cấp thông tin tài khoản ngân hàng trong mô tả công việc...", 18L, "BLOCK", "Phát hiện dấu hiệu lừa đảo: Yêu cầu thông tin nhạy cảm." },
                    { 18L, 2, new DateTime(2024, 1, 1, 18, 0, 0, 0, DateTimeKind.Utc), "BLOCK", "Yêu cầu cung cấp thông tin tài khoản ngân hàng trong mô tả công việc...", 19L, "BLOCK", "Phát hiện dấu hiệu lừa đảo: Yêu cầu thông tin nhạy cảm." },
                    { 19L, 2, new DateTime(2024, 1, 1, 19, 0, 0, 0, DateTimeKind.Utc), "BLOCK", "Yêu cầu cung cấp thông tin tài khoản ngân hàng trong mô tả công việc...", 20L, "BLOCK", "Phát hiện dấu hiệu lừa đảo: Yêu cầu thông tin nhạy cảm." },
                    { 20L, 2, new DateTime(2024, 1, 1, 20, 0, 0, 0, DateTimeKind.Utc), "BLOCK", "Yêu cầu cung cấp thông tin tài khoản ngân hàng trong mô tả công việc...", 21L, "BLOCK", "Phát hiện dấu hiệu lừa đảo: Yêu cầu thông tin nhạy cảm." }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "PasswordHash",
                value: "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "CreatedAt", "Email", "EmailVerified", "FullName", "IsActive", "IsDeleted", "LockReason", "PasswordHash", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { 2L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "hongngoc48@yahoo.com", true, "Quang Thái Tăng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 3L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "hanhmy_tang9@gmail.com", true, "Kim Khuyên Đào", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 4L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "hoami.ly@yahoo.com", true, "Duy Khiêm Lê", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 5L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "thanhhao.lam38@gmail.com", true, "Huệ Hồng Vương", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 6L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "tuyethan42@yahoo.com", true, "Hồng Bạch Thảo Vũ", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 7L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "bathinh28@yahoo.com", true, "Tịnh Yên Mai", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 8L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "dieuhuong38@hotmail.com", true, "Mai Vy Nguyễn", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 9L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "thuymy.duong35@yahoo.com", true, "Huy Thông Đào", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 10L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "kimlien_vu53@hotmail.com", true, "Giao Linh Vương", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 11L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "thuylinh_to@hotmail.com", true, "Thái Thảo Trịnh", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 12L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "kimthoa_vu13@hotmail.com", true, "Tường Lân Ngô", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 13L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "trucphuong_tran@gmail.com", true, "Hùng Phong Phùng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 14L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "namthong4@yahoo.com", true, "Vành Khuyên Trần", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 15L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "binhminh.ho@gmail.com", true, "Đinh Hương Lâm", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 16L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "minhan88@yahoo.com", true, "Phước Nguyên Hồ", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 17L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "tantrinh84@gmail.com", true, "Huy Trân Đặng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 18L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "anhminh.tran@yahoo.com", true, "Thành Vinh Lâm", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 19L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "maihien.phan83@gmail.com", true, "Thanh Thế Hồ", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 20L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "baoanh80@gmail.com", true, "Lâm Trường Dương", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 21L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "hoaivy.trinh@hotmail.com", true, "Việt Ngọc Hoàng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 22L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "huukhoi.lam31@hotmail.com", true, "Vinh Diệu Dương", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 23L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "hongviet.tang49@gmail.com", true, "Tố Quyên Nguyễn", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 24L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "quocphuong_truong@hotmail.com", true, "Ngọc Lý Lê", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 25L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "kimly43@yahoo.com", true, "Trọng Hùng Bùi", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 26L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "lamgiang_dinh61@hotmail.com", true, "Thu Ngọc Hồ", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 27L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "thieucuong97@hotmail.com", true, "Hữu Khanh Lê", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 28L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "minhvuong_pham@hotmail.com", true, "Ngọc Hải Bùi", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 29L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "mongthi61@gmail.com", true, "Hạnh Nga Dương", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 30L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "phuonglien.vu3@yahoo.com", true, "Lâm Tường Hồ", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 31L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "thanhkien_trinh82@yahoo.com", true, "Minh Tú Ngô", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 32L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "hagiang61@hotmail.com", true, "Bảo Bảo Đoàn", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 33L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "tungquan_tran71@hotmail.com", true, "Hạ Giang Bùi", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 34L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "thuymi97@gmail.com", true, "Quế Chi Dương", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 35L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "hongquy24@yahoo.com", true, "Tuấn Tài Vương", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 36L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "giahuan_lam57@gmail.com", true, "Vĩnh Ân Đặng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 37L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "minhhoang50@yahoo.com", true, "Tuấn Khoan Đỗ", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 38L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "hieuphong_ly44@yahoo.com", true, "Hướng Tiền Tô", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 39L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "tuyetbang_tang@hotmail.com", true, "Hồng Lâm Vương", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 40L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "yenthanh.dao@yahoo.com", true, "Minh Kỳ Ngô", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 41L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "nhatle48@hotmail.com", true, "Minh Thuận Hồ", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 42L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "congluan.lam@hotmail.com", true, "Dạ Yến Trịnh", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 43L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "tienhiep.ho84@yahoo.com", true, "Liên Phương Vũ", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 44L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "tunglinh62@gmail.com", true, "Nam Thanh Ngô", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 45L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "nhatnam.vuong@yahoo.com", true, "Mạnh Trường Đinh", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 46L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "uyphong.tang93@gmail.com", true, "Như Bảo Bùi", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 47L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "thuanthanh.le@gmail.com", true, "Ðình Lộc Nguyễn", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 48L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "ngocuyen72@gmail.com", true, "Công Hải Nguyễn", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 49L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "duycan.mai65@hotmail.com", true, "Yến Thanh Nguyễn", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 50L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "huutuong16@gmail.com", true, "Khắc Việt Đinh", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 51L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "tamhien90@yahoo.com", true, "Hữu Tài Nguyễn", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 1, null },
                    { 52L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "giacan_le92@hotmail.com", true, "Ðức Huy Phạm", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 53L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "ngochoa_ngo@hotmail.com", true, "Thu Minh Đinh", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 54L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "hongxuan.lam80@yahoo.com", true, "Diễm Khuê Trịnh", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 55L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "trongkien.to62@gmail.com", true, "Mai Hà Nguyễn", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 56L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "mythuan59@gmail.com", true, "Hoài Vỹ Vương", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 57L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "touyen_le@gmail.com", true, "Xuân Linh Lý", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 58L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "phuongloan.ha@yahoo.com", true, "Quang Triều Lê", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 59L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "kimduyen.pham7@gmail.com", true, "Tuấn Minh Vũ", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 60L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "huudinh_hoang@yahoo.com", true, "Thúy Liên Tăng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 61L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "baohue_vu@gmail.com", true, "Diên Vỹ Phùng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 62L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "nghiahoa_to81@hotmail.com", true, "Anh Quốc Phan", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 63L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "suongsuong.vu@hotmail.com", true, "Uyển Nhi Nguyễn", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 64L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "quangthach_trinh@yahoo.com", true, "Tích Ðức Đào", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 65L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "thanhha.mai@hotmail.com", true, "Đan Quỳnh Mai", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 66L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "baotin.le26@gmail.com", true, "Huyền Trân Đoàn", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 67L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "vietcuong_vuong@yahoo.com", true, "Chiêu Phong Vũ", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 68L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "duyhieu_phan24@gmail.com", true, "Bạch Cúc Mai", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 69L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "phucthinh.vu@gmail.com", true, "Tâm Thanh Mai", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 70L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "hongchau_ha@gmail.com", true, "Quý Vĩnh Vũ", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 71L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "gianhi_doan@gmail.com", true, "Trang Nhã Đỗ", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 72L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "yennhi25@hotmail.com", true, "Việt Long Ngô", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 73L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "haidang.le46@yahoo.com", true, "Vy Lam Nguyễn", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 74L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "diemthu_tran78@yahoo.com", true, "Gia Hoàng Đinh", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 75L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "thiyen62@yahoo.com", true, "Ngọc Khanh Dương", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 76L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "myyen43@yahoo.com", true, "Tiến Ðức Tăng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 77L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "camnhung_phan23@hotmail.com", true, "Phương An Tô", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 78L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "tamthanh.hoang@hotmail.com", true, "Minh Ngọc Trương", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 79L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "hanhtrang.lam2@hotmail.com", true, "Thuận Hòa Dương", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 80L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "duclong8@gmail.com", true, "Ái Thy Lâm", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 81L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "duyhieu39@yahoo.com", true, "Hồng Hà Trương", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 82L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "duchanh33@hotmail.com", true, "Quỳnh Ngân Dương", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 83L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "huukhoat.phan26@hotmail.com", true, "Khánh Hội Lê", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 84L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "quangdai_tang@gmail.com", true, "Diễm Uyên Hồ", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 85L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "huonggiang.nguyen87@gmail.com", true, "Tú Uyên Trịnh", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 86L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "thanhdao_ngo31@gmail.com", true, "Sĩ Hoàng Lý", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 87L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "mynhan71@gmail.com", true, "Ngọc Uyên Tăng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 88L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "giahung_dinh15@gmail.com", true, "Ðức Phú Lê", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 89L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "danguyet.ho57@yahoo.com", true, "Quang Nhân Trần", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 90L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "truongvinh_phung@yahoo.com", true, "Quỳnh Anh Mai", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 91L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "huuchau.trinh14@hotmail.com", true, "Thiên Ðức Đào", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 92L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "havy.mai46@gmail.com", true, "Tuấn Sỹ Phạm", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 93L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "tridung.ha@yahoo.com", true, "Thiên Mai Hồ", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 94L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "phuongle57@yahoo.com", true, "Tuệ Mẫn Phan", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 95L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "tuyettam.bui4@hotmail.com", true, "Hữu Tài Hoàng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 96L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "xuanan_dang@yahoo.com", true, "Hoài Giang Tô", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 97L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "anhduong65@yahoo.com", true, "Hữu Bào Trương", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 98L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "myhiep97@hotmail.com", true, "Yên Ðan Phan", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 99L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "phucdien.ngo83@gmail.com", true, "Tố Nga Lý", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 100L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "kieugiang34@yahoo.com", true, "Thuận Phương Lý", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 101L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "namson.bui@gmail.com", true, "Phong Dinh Đào", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 102L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "haccuc15@hotmail.com", true, "Diệu Ngọc Phạm", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 103L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "manhnghiem_dang90@yahoo.com", true, "Ngọc Dung Nguyễn", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 104L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "habang_dao@yahoo.com", true, "Kim Quyên Trần", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 105L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "thanhthe.pham89@yahoo.com", true, "Thuận Anh Lê", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 106L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "kimanh.to61@gmail.com", true, "Ngọc Sơn Ngô", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 107L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "thutrang_dinh51@yahoo.com", true, "Hải Dương Mai", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 108L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "thuylien79@gmail.com", true, "Phương Thùy Bùi", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 109L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "thanhlam.nguyen@gmail.com", true, "Thanh Hào Đoàn", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 110L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "duytuyen_ha@yahoo.com", true, "Xuân Thủy Hồ", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 111L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "haigiang_do46@yahoo.com", true, "Kiều Thu Dương", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 112L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "minhtrieu_ha62@hotmail.com", true, "Giao Kiều Lê", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 113L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "haithanh_le77@yahoo.com", true, "Linh Chi Hà", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 114L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "mynuong85@yahoo.com", true, "Nghi Xuân Hồ", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 115L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "chicong8@yahoo.com", true, "Hoàng Miên Mai", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 116L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "anhquoc26@hotmail.com", true, "Thụy Uyên Trần", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 117L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "bichduyen37@gmail.com", true, "Thục Ðào Đặng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 118L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "khangkien_phan23@hotmail.com", true, "Xuân Hương Vũ", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 119L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "phuongquynh40@hotmail.com", true, "Thế Phương Đỗ", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 120L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "hoaly_dao@yahoo.com", true, "Thanh Vinh Mai", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 121L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "vietthi.le46@yahoo.com", true, "Mỹ Loan Phan", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 122L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "quangbuu.hoang41@gmail.com", true, "Thùy Uyên Hoàng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 123L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "duythanh.truong31@yahoo.com", true, "An Nguyên Dương", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 124L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "minhnguyet.tang@gmail.com", true, "Trường Sơn Phan", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 125L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "thanhdanh.truong@hotmail.com", true, "Ngọc Trinh Trương", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 126L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "phucduy27@gmail.com", true, "Cẩm Nhi Trịnh", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 127L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "trongviet_do@gmail.com", true, "Kim Oanh Đoàn", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 128L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "thienlac.tang@hotmail.com", true, "Tùng Anh Vũ", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 129L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "hienmai_bui@hotmail.com", true, "Mộng Hằng Đào", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 130L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "thuctam_lam2@gmail.com", true, "Thu Giang Lâm", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 131L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "tuylinh.trinh53@gmail.com", true, "Kiên Lâm Đào", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 132L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "nguyetanh_nguyen@yahoo.com", true, "Quốc Quân Đoàn", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 133L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "quynhlien1@hotmail.com", true, "Mạnh Hùng Lý", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 134L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "tainguyen.phung79@gmail.com", true, "Hoàng Giang Mai", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 135L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "bichnga59@yahoo.com", true, "Dã Thảo Đỗ", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 136L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "quangtuan.phung66@gmail.com", true, "Thiện Giang Đặng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 137L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "dieunga19@yahoo.com", true, "Ngọc Hoan Lâm", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 138L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "dinhphu_doan10@gmail.com", true, "Tích Ðức Đặng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 139L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "giaphong.ha22@gmail.com", true, "Hữu Hạnh Vương", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 140L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "minhdan.dao6@yahoo.com", true, "Minh Khiếu Dương", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 141L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "bichlam42@yahoo.com", true, "Khánh Giao Vương", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 142L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "nghiadung_trinh3@gmail.com", true, "Việt Hà Phạm", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 143L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "truongnhan_ha19@yahoo.com", true, "Trọng Khánh Lý", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 144L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "ngocthi_vuong33@yahoo.com", true, "Thư Sương Hồ", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 145L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "thientuyen49@hotmail.com", true, "Quốc Huy Ngô", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 146L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "baolam_pham@yahoo.com", true, "Trang Nhã Trịnh", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 147L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "duytiep.ly95@hotmail.com", true, "Trúc Quỳnh Tăng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 148L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "maily.doan@hotmail.com", true, "Kim Phú Đoàn", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 149L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "quangthach_lam7@yahoo.com", true, "Quang Dũng Đặng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 150L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "mytam.doan@yahoo.com", true, "Kiều Dung Vương", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 151L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "huyanh7@hotmail.com", true, "Chính Thuận Hà", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 152L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "quangtrieu_ha@hotmail.com", true, "Minh Hào Tô", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 153L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "yenanh28@gmail.com", true, "Kiều Diễm Đinh", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 154L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "vanhanh28@gmail.com", true, "Quỳnh Thơ Trương", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 155L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "baoha_dao@hotmail.com", true, "Thúy Minh Mai", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 156L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "doantrang.do@hotmail.com", true, "Minh Minh Ngô", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 157L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "hoangkhoi61@hotmail.com", true, "Tâm Nguyệt Phạm", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 158L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "hongquang.vu@gmail.com", true, "Anh Hương Phùng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 159L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "huyhoang.truong3@hotmail.com", true, "Kiến Ðức Đặng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 160L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "danthu_nguyen@yahoo.com", true, "Quang Tài Hoàng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 161L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "thuhoai93@gmail.com", true, "Phượng Vũ Phan", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 162L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "thuongthuat_ngo@yahoo.com", true, "Diệu Vân Dương", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 163L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "hongdang.vuong58@hotmail.com", true, "Thư Sương Lê", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 164L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "lamtruong33@hotmail.com", true, "Mỹ Loan Trương", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 165L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "manhthien33@yahoo.com", true, "Thường Xuân Trương", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 166L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "bichnhu1@gmail.com", true, "Tôn Lễ Vương", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 167L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "thuyen11@gmail.com", true, "Ðình Nhân Phùng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 168L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "tritinh.nguyen@hotmail.com", true, "Anh Ðào Phạm", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 169L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "maiha_bui@gmail.com", true, "Viễn Ðông Phạm", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 170L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "tonle_ho27@yahoo.com", true, "Mộng Vy Lâm", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 171L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "thanhnhan_dinh@hotmail.com", true, "Thành Ân Đào", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 172L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "hungthinh_lam@yahoo.com", true, "Trọng Hà Tăng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 173L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "syphu27@hotmail.com", true, "Quỳnh Anh Lê", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 174L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "honglien.truong86@hotmail.com", true, "Trọng Việt Trần", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 175L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "binhduong_nguyen7@gmail.com", true, "Minh Nhu Mai", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 176L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "luuly_dang29@yahoo.com", true, "Ðức Nhân Ngô", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 177L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "hongnga84@yahoo.com", true, "Văn Minh Trần", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 178L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "theanh.hoang@hotmail.com", true, "Anh Khoa Đỗ", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 179L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "huongtien_phan@yahoo.com", true, "Tiểu Mi Trịnh", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 180L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "kimdung25@hotmail.com", true, "Ngọc Hoan Lê", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 181L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "yenanh_trinh39@hotmail.com", true, "Ngọc Vy Vũ", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 182L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "bachquynh_to54@yahoo.com", true, "Kim Sơn Phan", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 183L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "tudung.truong79@gmail.com", true, "Việt Duy Phạm", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 184L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "hoaly.lam44@yahoo.com", true, "Quang Tuấn Hồ", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 185L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "lequyen53@gmail.com", true, "Anh Thi Tăng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 186L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "haisinh.phan5@yahoo.com", true, "Phương Quyên Phùng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 187L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "tanlong.phung50@gmail.com", true, "Thiên Hà Nguyễn", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 188L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "khacdung_lam73@yahoo.com", true, "Ðoan Trang Hoàng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 189L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "thaihoa_phan71@hotmail.com", true, "Thụy Lâm Vũ", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 190L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "quynhnhi70@yahoo.com", true, "Dạ Thảo Đào", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 191L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "minhthien.le@yahoo.com", true, "Ðức Thọ Hồ", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 192L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "haimy80@hotmail.com", true, "Phúc Cường Phan", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 193L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "thaomai.dao40@hotmail.com", true, "Mỹ Thuận Hà", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 194L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "toanthang78@hotmail.com", true, "Lệ Chi Hà", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 195L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "chilan.truong@gmail.com", true, "Diễm Lộc Dương", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 196L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "quocanh80@yahoo.com", true, "Cẩm Nhung Hồ", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 197L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "doantu_bui14@hotmail.com", true, "Minh Khai Đoàn", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 198L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "quockhanh19@yahoo.com", true, "Viễn Phương Hoàng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 199L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "phuonggiang73@yahoo.com", true, "Thanh Thúy Hà", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 200L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "anhkhai48@hotmail.com", true, "Chính Thuận Trần", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 201L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "ngocuyen_tang@gmail.com", true, "Trung Ðức Trịnh", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 202L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "thanhtung.vu34@hotmail.com", true, "Sao Mai Đinh", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 203L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "viethuy_truong@yahoo.com", true, "Thành An Hoàng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 204L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "songlam.vuong7@yahoo.com", true, "Việt Khoa Phan", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 205L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "thangcanh.trinh@yahoo.com", true, "Bích Thu Lý", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 206L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "hoangdung26@yahoo.com", true, "Tường Vinh Hà", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 207L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "hoaly8@yahoo.com", true, "Thế Anh Tô", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 208L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "thedung10@hotmail.com", true, "Thế Trung Hoàng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 209L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "truonggiang.to@gmail.com", true, "Ngọc Hạnh Lâm", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 210L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "phuongloan_ho@hotmail.com", true, "Nam Phương Trịnh", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 211L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "antuong81@hotmail.com", true, "Sơn Lâm Hoàng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 212L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "thienngon48@hotmail.com", true, "Quỳnh Nhi Phạm", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 213L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "batung27@gmail.com", true, "Lệ Khanh Mai", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 214L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "baothach66@gmail.com", true, "Quang Hòa Hoàng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 215L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "baoan65@gmail.com", true, "Phi Hoàng Trịnh", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 216L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "anhthi89@hotmail.com", true, "Hoàng Hà Lý", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 217L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "sydan_dao@yahoo.com", true, "Bảo Vy Lý", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 218L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "nhannguyen_hoang71@yahoo.com", true, "Ánh Dương Dương", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 219L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "nhuphuong_tang@hotmail.com", true, "Trúc Lan Đào", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 220L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "lethanh.phung98@yahoo.com", true, "Hữu Cương Vương", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 221L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "kimvuong.tang75@gmail.com", true, "Mỹ Vân Phùng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 222L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "thanhlam.trinh@hotmail.com", true, "Hạ Uyên Trần", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 223L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "bichduyen.ngo@gmail.com", true, "Minh Quang Đặng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 224L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "dinhsieu27@gmail.com", true, "Linh Châu Lâm", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 225L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "quanglan_dao@gmail.com", true, "Hoa Thiên Mai", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 226L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "conghai.nguyen@gmail.com", true, "Quang Lộc Vương", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 227L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "conghieu_dang@gmail.com", true, "An Hằng Phạm", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 228L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "namtu_dinh@yahoo.com", true, "Xuân Phượng Phùng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 229L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "danthu3@hotmail.com", true, "Thụy Lâm Đặng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 230L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "khanhquyen91@hotmail.com", true, "Bích Loan Hà", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 231L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "andi_tran82@hotmail.com", true, "Việt Phương Đinh", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 232L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "nhuhoa.le94@gmail.com", true, "Gia Khiêm Hoàng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 233L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "uyenmy.tang@hotmail.com", true, "Thy Oanh Trương", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 234L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "maichi_bui@hotmail.com", true, "Lương Tài Đỗ", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 235L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "tiendung52@hotmail.com", true, "Phước Nguyên Lý", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 236L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "xuanson_do35@gmail.com", true, "Mỹ Ngọc Đào", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 237L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "vanganh.to@hotmail.com", true, "Ngọc Khánh Mai", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 238L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "duyngon67@yahoo.com", true, "Thu Duyên Đoàn", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 239L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "uyenmy_dinh@hotmail.com", true, "Chí Hiếu Nguyễn", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 240L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "thuytien82@gmail.com", true, "Tố Loan Đoàn", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 241L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "haiphuong9@hotmail.com", true, "Xuân Hiếu Phùng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 242L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "khanhchi6@yahoo.com", true, "Ðình Hợp Vũ", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 243L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "chanhung_vu27@hotmail.com", true, "Ngọc Huy Hoàng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 244L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "cuongthinh.hoang16@gmail.com", true, "Thụy Miên Trương", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 245L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "thuyhuong.do@hotmail.com", true, "Hương Ly Nguyễn", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 246L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "mythuan88@yahoo.com", true, "Thiện Sinh Đào", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 247L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "ngocsuong73@yahoo.com", true, "Thanh Nhung Phùng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 248L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "minhvu_tran68@gmail.com", true, "Thu Phượng Phan", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 249L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "khactuan_tran@hotmail.com", true, "Công Tráng Hoàng", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 250L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "locuyen63@yahoo.com", true, "Tuyết Thanh Dương", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null },
                    { 251L, "https://i.pravatar.cc/150", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "thatdung4@yahoo.com", true, "Khánh Huyền Tô", true, false, null, "$2a$11$hhasZuevNmRmoQm04XzQoeZ.KA72aEuuKogVUgG0k9b19tddFN9p2", 0, null }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "Balance", "CreatedAt", "Currency", "IsDeleted", "UpdatedAt", "UserId" },
                values: new object[] { 1L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 1L });

            migrationBuilder.InsertData(
                table: "CandidateProfiles",
                columns: new[] { "Id", "CVText", "CVUrl", "CreatedAt", "ExpectedSalary", "ExperienceYears", "IsDeleted", "Skills", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 57000000m, 9, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 52L },
                    { 2L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 50000000m, 1, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 53L },
                    { 3L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 41000000m, 4, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 54L },
                    { 4L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 43000000m, 8, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 55L },
                    { 5L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 44000000m, 8, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 56L },
                    { 6L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 33000000m, 4, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 57L },
                    { 7L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 24000000m, 6, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 58L },
                    { 8L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 56000000m, 4, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 59L },
                    { 9L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 31000000m, 12, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 60L },
                    { 10L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 20000000m, 11, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 61L },
                    { 11L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 57000000m, 8, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 62L },
                    { 12L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 16000000m, 12, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 63L },
                    { 13L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 17000000m, 9, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 64L },
                    { 14L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 45000000m, 12, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 65L },
                    { 15L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 43000000m, 7, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 66L },
                    { 16L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 41000000m, 14, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 67L },
                    { 17L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 16000000m, 1, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 68L },
                    { 18L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 17000000m, 7, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 69L },
                    { 19L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 23000000m, 8, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 70L },
                    { 20L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 23000000m, 6, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 71L },
                    { 21L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 26000000m, 7, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 72L },
                    { 22L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 29000000m, 10, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 73L },
                    { 23L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 39000000m, 9, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 74L },
                    { 24L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 19000000m, 4, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 75L },
                    { 25L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 26000000m, 11, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 76L },
                    { 26L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 58000000m, 7, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 77L },
                    { 27L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 15000000m, 10, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 78L },
                    { 28L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 46000000m, 4, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 79L },
                    { 29L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 16000000m, 2, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 80L },
                    { 30L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 22000000m, 3, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 81L },
                    { 31L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 52000000m, 11, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 82L },
                    { 32L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 57000000m, 2, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 83L },
                    { 33L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 46000000m, 10, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 84L },
                    { 34L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 31000000m, 6, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 85L },
                    { 35L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 23000000m, 11, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 86L },
                    { 36L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 42000000m, 6, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 87L },
                    { 37L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 38000000m, 14, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 88L },
                    { 38L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 28000000m, 10, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 89L },
                    { 39L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 37000000m, 4, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 90L },
                    { 40L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 17000000m, 6, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 91L },
                    { 41L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 47000000m, 12, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 92L },
                    { 42L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 25000000m, 14, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 93L },
                    { 43L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 16000000m, 3, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 94L },
                    { 44L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 15000000m, 14, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 95L },
                    { 45L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 50000000m, 12, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 96L },
                    { 46L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 38000000m, 14, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 97L },
                    { 47L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 26000000m, 1, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 98L },
                    { 48L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 41000000m, 7, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 99L },
                    { 49L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 49000000m, 2, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 100L },
                    { 50L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 56000000m, 10, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 101L },
                    { 51L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 53000000m, 3, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 102L },
                    { 52L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 39000000m, 6, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 103L },
                    { 53L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 54000000m, 13, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 104L },
                    { 54L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 20000000m, 1, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 105L },
                    { 55L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 56000000m, 5, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 106L },
                    { 56L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 42000000m, 7, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 107L },
                    { 57L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 20000000m, 9, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 108L },
                    { 58L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 15000000m, 5, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 109L },
                    { 59L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 56000000m, 13, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 110L },
                    { 60L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 43000000m, 11, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 111L },
                    { 61L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 31000000m, 11, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 112L },
                    { 62L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 57000000m, 8, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 113L },
                    { 63L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 53000000m, 4, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 114L },
                    { 64L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 46000000m, 9, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 115L },
                    { 65L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 19000000m, 2, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 116L },
                    { 66L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 36000000m, 3, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 117L },
                    { 67L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 36000000m, 12, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 118L },
                    { 68L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 59000000m, 13, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 119L },
                    { 69L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 32000000m, 5, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 120L },
                    { 70L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 28000000m, 5, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 121L },
                    { 71L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 52000000m, 1, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 122L },
                    { 72L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 54000000m, 10, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 123L },
                    { 73L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 29000000m, 5, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 124L },
                    { 74L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 55000000m, 13, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 125L },
                    { 75L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 34000000m, 13, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 126L },
                    { 76L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 24000000m, 10, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 127L },
                    { 77L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 16000000m, 14, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 128L },
                    { 78L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 50000000m, 3, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 129L },
                    { 79L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 34000000m, 5, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 130L },
                    { 80L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 16000000m, 5, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 131L },
                    { 81L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 29000000m, 5, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 132L },
                    { 82L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 24000000m, 1, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 133L },
                    { 83L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 58000000m, 11, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 134L },
                    { 84L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 20000000m, 11, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 135L },
                    { 85L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 30000000m, 4, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 136L },
                    { 86L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 38000000m, 10, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 137L },
                    { 87L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 36000000m, 9, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 138L },
                    { 88L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 56000000m, 9, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 139L },
                    { 89L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 45000000m, 10, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 140L },
                    { 90L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 56000000m, 9, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 141L },
                    { 91L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 46000000m, 14, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 142L },
                    { 92L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 43000000m, 11, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 143L },
                    { 93L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 58000000m, 6, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 144L },
                    { 94L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 51000000m, 8, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 145L },
                    { 95L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 18000000m, 5, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 146L },
                    { 96L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 56000000m, 10, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 147L },
                    { 97L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 28000000m, 2, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 148L },
                    { 98L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 46000000m, 1, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 149L },
                    { 99L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 36000000m, 11, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 150L },
                    { 100L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 32000000m, 2, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 151L },
                    { 101L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 50000000m, 8, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 152L },
                    { 102L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 41000000m, 10, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 153L },
                    { 103L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 22000000m, 11, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 154L },
                    { 104L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 37000000m, 9, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 155L },
                    { 105L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 26000000m, 6, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 156L },
                    { 106L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 43000000m, 2, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 157L },
                    { 107L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 31000000m, 12, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 158L },
                    { 108L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 41000000m, 2, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 159L },
                    { 109L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 33000000m, 8, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 160L },
                    { 110L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 50000000m, 12, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 161L },
                    { 111L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 58000000m, 7, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 162L },
                    { 112L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 22000000m, 12, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 163L },
                    { 113L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 47000000m, 10, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 164L },
                    { 114L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 26000000m, 6, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 165L },
                    { 115L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 56000000m, 7, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 166L },
                    { 116L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 23000000m, 2, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 167L },
                    { 117L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 25000000m, 8, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 168L },
                    { 118L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 22000000m, 6, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 169L },
                    { 119L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 23000000m, 1, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 170L },
                    { 120L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 26000000m, 13, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 171L },
                    { 121L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 59000000m, 5, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 172L },
                    { 122L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 16000000m, 6, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 173L },
                    { 123L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 17000000m, 14, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 174L },
                    { 124L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 47000000m, 2, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 175L },
                    { 125L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 33000000m, 4, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 176L },
                    { 126L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 31000000m, 3, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 177L },
                    { 127L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 29000000m, 10, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 178L },
                    { 128L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 41000000m, 13, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 179L },
                    { 129L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 36000000m, 14, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 180L },
                    { 130L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 17000000m, 14, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 181L },
                    { 131L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 31000000m, 11, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 182L },
                    { 132L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 36000000m, 1, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 183L },
                    { 133L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 56000000m, 2, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 184L },
                    { 134L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 41000000m, 2, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 185L },
                    { 135L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 56000000m, 1, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 186L },
                    { 136L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 30000000m, 8, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 187L },
                    { 137L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 39000000m, 8, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 188L },
                    { 138L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 35000000m, 7, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 189L },
                    { 139L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 50000000m, 8, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 190L },
                    { 140L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 41000000m, 3, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 191L },
                    { 141L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 46000000m, 9, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 192L },
                    { 142L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 17000000m, 1, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 193L },
                    { 143L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 49000000m, 11, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 194L },
                    { 144L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 25000000m, 7, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 195L },
                    { 145L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 49000000m, 5, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 196L },
                    { 146L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 40000000m, 3, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 197L },
                    { 147L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 51000000m, 4, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 198L },
                    { 148L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 58000000m, 7, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 199L },
                    { 149L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 56000000m, 14, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 200L },
                    { 150L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 16000000m, 13, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 201L },
                    { 151L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 38000000m, 14, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 202L },
                    { 152L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 28000000m, 10, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 203L },
                    { 153L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 51000000m, 13, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 204L },
                    { 154L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 21000000m, 12, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 205L },
                    { 155L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 36000000m, 13, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 206L },
                    { 156L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 22000000m, 1, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 207L },
                    { 157L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 30000000m, 5, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 208L },
                    { 158L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 16000000m, 7, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 209L },
                    { 159L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 58000000m, 5, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 210L },
                    { 160L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 31000000m, 10, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 211L },
                    { 161L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 52000000m, 7, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 212L },
                    { 162L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 26000000m, 4, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 213L },
                    { 163L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 59000000m, 11, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 214L },
                    { 164L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 48000000m, 2, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 215L },
                    { 165L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 36000000m, 1, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 216L },
                    { 166L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 43000000m, 7, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 217L },
                    { 167L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 22000000m, 13, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 218L },
                    { 168L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 18000000m, 9, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 219L },
                    { 169L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 48000000m, 14, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 220L },
                    { 170L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 58000000m, 3, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 221L },
                    { 171L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 30000000m, 14, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 222L },
                    { 172L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 52000000m, 6, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 223L },
                    { 173L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 16000000m, 11, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 224L },
                    { 174L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 55000000m, 4, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 225L },
                    { 175L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 35000000m, 5, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 226L },
                    { 176L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 15000000m, 10, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 227L },
                    { 177L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 39000000m, 4, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 228L },
                    { 178L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 21000000m, 9, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 229L },
                    { 179L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 35000000m, 4, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 230L },
                    { 180L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 54000000m, 9, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 231L },
                    { 181L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 18000000m, 10, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 232L },
                    { 182L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 32000000m, 2, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 233L },
                    { 183L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 33000000m, 14, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 234L },
                    { 184L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 20000000m, 5, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 235L },
                    { 185L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 32000000m, 11, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 236L },
                    { 186L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 41000000m, 1, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 237L },
                    { 187L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 47000000m, 11, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 238L },
                    { 188L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 18000000m, 6, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 239L },
                    { 189L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 35000000m, 7, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 240L },
                    { 190L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 45000000m, 8, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 241L },
                    { 191L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 24000000m, 11, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 242L },
                    { 192L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 41000000m, 6, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 243L },
                    { 193L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 36000000m, 12, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 244L },
                    { 194L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 29000000m, 6, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 245L },
                    { 195L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 35000000m, 8, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 246L },
                    { 196L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 38000000m, 12, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 247L },
                    { 197L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 29000000m, 3, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 248L },
                    { 198L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 52000000m, 4, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 249L },
                    { 199L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 58000000m, 4, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 250L },
                    { 200L, "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 29000000m, 12, false, ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp", null, 251L }
                });
            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireDate",
                table: "Jobs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "AppealMessage", "Benefits", "BoostExpiryTime", "CategoryId", "Company", "CreatedAt", "Description", "DraftChanges", "ExpireDate", "IsAppealed", "IsDeleted", "JobType", "Location", "ModerationNote", "RecruiterId", "Requirement", "SalaryMax", "SalaryMin", "SkillsRequired", "Status", "Title", "UpdatedAt", "ViewCount" },
                values: new object[,]
                {
                    { 1L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 2L, "Vũ - Phùng", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 26, 14, 26, 47, 4, DateTimeKind.Utc).AddTicks(7984), false, false, 0, "Hà Nội", null, 9L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 51000000m, 32000000m, ".NET Core, SQL Server", 1, "Lập trình viên Frontend", null, 0 },
                    { 2L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 6L, "Phạm and Sons", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 18, 14, 26, 47, 4, DateTimeKind.Utc).AddTicks(8131), false, false, 0, "Đồng Nai", null, 8L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 56000000m, 24000000m, ".NET Core, SQL Server", 1, "Kỹ sư phần mềm", null, 0 },
                    { 3L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 7L, "Dương - Đoàn", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 21, 14, 26, 47, 4, DateTimeKind.Utc).AddTicks(8217), false, false, 0, "Cần Thơ", null, 26L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 38000000m, 14000000m, ".NET Core, SQL Server", 1, "Nhân viên kinh doanh", null, 0 },
                    { 4L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 3L, "Trần, Dương and Lê", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 2, 14, 26, 47, 4, DateTimeKind.Utc).AddTicks(8313), false, false, 0, "Đà Nẵng", null, 30L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 62000000m, 39000000m, ".NET Core, SQL Server", 1, "Nhân viên kinh doanh", null, 0 },
                    { 5L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 9L, "Dương, Hà and Vương", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 19, 14, 26, 47, 4, DateTimeKind.Utc).AddTicks(8375), false, false, 0, "TP. Hồ Chí Minh", null, 31L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 49000000m, 23000000m, ".NET Core, SQL Server", 1, "Nhân viên kinh doanh", null, 0 },
                    { 6L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 5L, "Hồ, Đỗ and Phạm", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 19, 14, 26, 47, 4, DateTimeKind.Utc).AddTicks(8469), false, false, 0, "TP. Hồ Chí Minh", null, 5L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 59000000m, 27000000m, ".NET Core, SQL Server", 1, "Chuyên viên Marketing", null, 0 },
                    { 7L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 8L, "Vương, Lý and Hà", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 23, 14, 26, 47, 4, DateTimeKind.Utc).AddTicks(8560), false, false, 0, "TP. Hồ Chí Minh", null, 3L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 40000000m, 15000000m, ".NET Core, SQL Server", 1, "Lập trình viên .NET", null, 0 },
                    { 8L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 8L, "Trương - Hoàng", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 14, 14, 26, 47, 4, DateTimeKind.Utc).AddTicks(8609), false, false, 0, "Đà Nẵng", null, 9L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 49000000m, 33000000m, ".NET Core, SQL Server", 1, "Thiết kế đồ họa", null, 0 },
                    { 9L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 5L, "Trịnh - Nguyễn", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 18, 14, 26, 47, 4, DateTimeKind.Utc).AddTicks(8700), false, false, 0, "Bình Dương", null, 44L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 54000000m, 27000000m, ".NET Core, SQL Server", 1, "Chuyên viên tư vấn", null, 0 },
                    { 10L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 2L, "Đoàn, Hoàng and Trương", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 7, 14, 26, 47, 4, DateTimeKind.Utc).AddTicks(8804), false, false, 0, "Đồng Nai", null, 36L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 56000000m, 26000000m, ".NET Core, SQL Server", 1, "Chuyên viên Marketing", null, 0 },
                    { 11L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 4L, "Bùi, Đặng and Mai", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 14, 14, 26, 47, 4, DateTimeKind.Utc).AddTicks(8869), false, false, 0, "Hà Nội", null, 15L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 36000000m, 22000000m, ".NET Core, SQL Server", 1, "Quản lý dự án", null, 0 },
                    { 12L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 6L, "Phạm - Đặng", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 11, 14, 26, 47, 4, DateTimeKind.Utc).AddTicks(9016), false, false, 0, "TP. Hồ Chí Minh", null, 26L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 36000000m, 26000000m, ".NET Core, SQL Server", 1, "Lập trình viên Frontend", null, 0 },
                    { 13L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 1L, "Hồ, Nguyễn and Đinh", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 18, 14, 26, 47, 4, DateTimeKind.Utc).AddTicks(9140), false, false, 0, "TP. Hồ Chí Minh", null, 6L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 57000000m, 22000000m, ".NET Core, SQL Server", 1, "Kế toán trưởng", null, 0 },
                    { 14L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 3L, "Bùi, Lâm and Hoàng", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 9, 14, 26, 47, 4, DateTimeKind.Utc).AddTicks(9201), false, false, 0, "Đồng Nai", null, 3L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 35000000m, 16000000m, ".NET Core, SQL Server", 1, "Chuyên viên Marketing", null, 0 },
                    { 15L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 9L, "Trương Group", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 30, 14, 26, 47, 4, DateTimeKind.Utc).AddTicks(9341), false, false, 0, "Hải Phòng", null, 34L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 35000000m, 20000000m, ".NET Core, SQL Server", 1, "Chuyên viên tư vấn", null, 0 },
                    { 16L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 7L, "Tô, Lý and Đoàn", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 19, 14, 26, 47, 4, DateTimeKind.Utc).AddTicks(9428), false, false, 0, "Đồng Nai", null, 22L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 50000000m, 36000000m, ".NET Core, SQL Server", 1, "Lập trình viên .NET", null, 0 },
                    { 17L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 10L, "Hà Inc", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 21, 14, 26, 47, 4, DateTimeKind.Utc).AddTicks(9482), false, false, 0, "Đà Nẵng", null, 46L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 43000000m, 20000000m, ".NET Core, SQL Server", 1, "Nhân viên kinh doanh", null, 0 },
                    { 18L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 9L, "Đặng and Sons", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 25, 14, 26, 47, 4, DateTimeKind.Utc).AddTicks(9544), false, false, 0, "Hải Phòng", null, 5L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 61000000m, 28000000m, ".NET Core, SQL Server", 1, "Chuyên viên tư vấn", null, 0 },
                    { 19L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 7L, "Vương, Đoàn and Lý", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 24, 14, 26, 47, 4, DateTimeKind.Utc).AddTicks(9602), false, false, 0, "Hà Nội", null, 3L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 28000000m, 17000000m, ".NET Core, SQL Server", 1, "Chuyên viên tư vấn", null, 0 },
                    { 20L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 1L, "Đào - Hồ", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 5, 14, 26, 47, 4, DateTimeKind.Utc).AddTicks(9678), false, false, 0, "Đà Nẵng", null, 35L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 63000000m, 35000000m, ".NET Core, SQL Server", 1, "Chuyên viên tư vấn", null, 0 },
                    { 21L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 3L, "Vương - Tăng", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 17, 14, 26, 47, 4, DateTimeKind.Utc).AddTicks(9721), false, false, 0, "Đồng Nai", null, 23L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 40000000m, 30000000m, ".NET Core, SQL Server", 1, "Kỹ sư phần mềm", null, 0 },
                    { 22L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 7L, "Lê - Đoàn", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 12, 14, 26, 47, 4, DateTimeKind.Utc).AddTicks(9797), false, false, 0, "Cần Thơ", null, 18L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 38000000m, 14000000m, ".NET Core, SQL Server", 1, "Chuyên viên tư vấn", null, 0 },
                    { 23L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 10L, "Lâm, Đào and Trịnh", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 9, 14, 26, 47, 4, DateTimeKind.Utc).AddTicks(9882), false, false, 0, "Hà Nội", null, 51L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 32000000m, 27000000m, ".NET Core, SQL Server", 1, "Thiết kế đồ họa", null, 0 },
                    { 24L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 2L, "Đỗ and Sons", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 4, 14, 26, 47, 4, DateTimeKind.Utc).AddTicks(9929), false, false, 0, "Bình Dương", null, 2L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 56000000m, 21000000m, ".NET Core, SQL Server", 1, "Lập trình viên .NET", null, 0 },
                    { 25L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 7L, "Vũ Group", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 19, 14, 26, 47, 5, DateTimeKind.Utc), false, false, 0, "Hải Phòng", null, 46L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 55000000m, 16000000m, ".NET Core, SQL Server", 1, "Chuyên viên tư vấn", null, 0 },
                    { 26L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 3L, "Đỗ, Hồ and Trần", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 21, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(60), false, false, 0, "Đà Nẵng", null, 33L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 54000000m, 29000000m, ".NET Core, SQL Server", 1, "Kỹ sư phần mềm", null, 0 },
                    { 27L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 10L, "Vương Group", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 27, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(132), false, false, 0, "Cần Thơ", null, 3L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 56000000m, 31000000m, ".NET Core, SQL Server", 1, "Kỹ sư phần mềm", null, 0 },
                    { 28L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 4L, "Dương, Hồ and Nguyễn", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 28, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(215), false, false, 0, "Đồng Nai", null, 6L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 42000000m, 30000000m, ".NET Core, SQL Server", 1, "Kỹ sư phần mềm", null, 0 },
                    { 29L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 6L, "Đặng - Đinh", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 19, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(255), false, false, 0, "Đà Nẵng", null, 4L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 31000000m, 22000000m, ".NET Core, SQL Server", 1, "Kế toán trưởng", null, 0 },
                    { 30L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 1L, "Ngô LLC", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 19, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(354), false, false, 0, "Bình Dương", null, 49L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 61000000m, 23000000m, ".NET Core, SQL Server", 1, "Nhân viên kinh doanh", null, 0 },
                    { 31L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 9L, "Trương - Mai", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 10, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(405), false, false, 0, "Cần Thơ", null, 38L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 53000000m, 20000000m, ".NET Core, SQL Server", 1, "Thiết kế đồ họa", null, 0 },
                    { 32L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 5L, "Hà Inc", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 5, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(468), false, false, 0, "TP. Hồ Chí Minh", null, 13L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 56000000m, 39000000m, ".NET Core, SQL Server", 1, "Kế toán trưởng", null, 0 },
                    { 33L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 2L, "Dương - Phạm", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 26, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(508), false, false, 0, "Hải Phòng", null, 18L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 63000000m, 34000000m, ".NET Core, SQL Server", 1, "Quản lý dự án", null, 0 },
                    { 34L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 4L, "Hồ, Trần and Bùi", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 27, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(597), false, false, 0, "TP. Hồ Chí Minh", null, 39L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 65000000m, 27000000m, ".NET Core, SQL Server", 1, "Thiết kế đồ họa", null, 0 },
                    { 35L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 1L, "Đỗ, Nguyễn and Đào", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 29, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(688), false, false, 0, "Đà Nẵng", null, 47L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 40000000m, 12000000m, ".NET Core, SQL Server", 1, "Kỹ sư phần mềm", null, 0 },
                    { 36L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 3L, "Hà, Hồ and Lâm", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 1, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(748), false, false, 0, "Hải Phòng", null, 26L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 36000000m, 20000000m, ".NET Core, SQL Server", 1, "Nhân viên nhân sự", null, 0 },
                    { 37L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 1L, "Hồ - Tô", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 8, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(823), false, false, 0, "Đà Nẵng", null, 3L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 44000000m, 34000000m, ".NET Core, SQL Server", 1, "Quản lý dự án", null, 0 },
                    { 38L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 9L, "Tăng - Đoàn", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 14, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(866), false, false, 0, "Hải Phòng", null, 45L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 38000000m, 28000000m, ".NET Core, SQL Server", 1, "Kế toán trưởng", null, 0 },
                    { 39L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 10L, "Hà LLC", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 19, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(941), false, false, 0, "Đà Nẵng", null, 27L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 56000000m, 38000000m, ".NET Core, SQL Server", 1, "Chuyên viên tư vấn", null, 0 },
                    { 40L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 7L, "Hồ, Lâm and Mai", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 2, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(1101), false, false, 0, "TP. Hồ Chí Minh", null, 25L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 53000000m, 19000000m, ".NET Core, SQL Server", 1, "Quản lý dự án", null, 0 },
                    { 41L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 4L, "Đinh LLC", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 12, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(1149), false, false, 0, "Bình Dương", null, 48L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 40000000m, 34000000m, ".NET Core, SQL Server", 1, "Nhân viên nhân sự", null, 0 },
                    { 42L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 7L, "Đỗ, Trịnh and Phan", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 2, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(1398), false, false, 0, "Hải Phòng", null, 18L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 64000000m, 32000000m, ".NET Core, SQL Server", 1, "Quản lý dự án", null, 0 },
                    { 43L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 4L, "Phạm, Tô and Hà", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 1, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(1489), false, false, 0, "Cần Thơ", null, 12L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 40000000m, 11000000m, ".NET Core, SQL Server", 1, "Nhân viên kinh doanh", null, 0 },
                    { 44L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 6L, "Lý, Tăng and Đỗ", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 5, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(1550), false, false, 0, "Cần Thơ", null, 17L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 51000000m, 39000000m, ".NET Core, SQL Server", 1, "Lập trình viên Frontend", null, 0 },
                    { 45L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 1L, "Ngô, Trương and Hà", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 15, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(1626), false, false, 0, "TP. Hồ Chí Minh", null, 20L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 37000000m, 26000000m, ".NET Core, SQL Server", 1, "Nhân viên nhân sự", null, 0 },
                    { 46L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 10L, "Phạm - Phùng", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 25, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(1719), false, false, 0, "Hà Nội", null, 23L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 72000000m, 38000000m, ".NET Core, SQL Server", 1, "Chuyên viên Marketing", null, 0 },
                    { 47L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 1L, "Lâm - Vũ", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 26, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(1763), false, false, 0, "Cần Thơ", null, 15L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 46000000m, 15000000m, ".NET Core, SQL Server", 1, "Nhân viên kinh doanh", null, 0 },
                    { 48L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 2L, "Đoàn - Mai", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 16, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(1839), false, false, 0, "Hà Nội", null, 17L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 45000000m, 17000000m, ".NET Core, SQL Server", 1, "Chuyên viên Marketing", null, 0 },
                    { 49L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 5L, "Đào Group", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 24, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(1899), false, false, 0, "TP. Hồ Chí Minh", null, 44L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 44000000m, 28000000m, ".NET Core, SQL Server", 1, "Chuyên viên tư vấn", null, 0 },
                    { 50L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 5L, "Tô Group", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 22, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(1973), false, false, 0, "Hải Phòng", null, 33L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 60000000m, 39000000m, ".NET Core, SQL Server", 1, "Kỹ sư phần mềm", null, 0 },
                    { 51L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 5L, "Đặng, Tô and Ngô", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 15, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(2034), false, false, 0, "TP. Hồ Chí Minh", null, 23L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 55000000m, 33000000m, ".NET Core, SQL Server", 1, "Chuyên viên tư vấn", null, 0 },
                    { 52L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 4L, "Đặng - Trần", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 29, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(2104), false, false, 0, "TP. Hồ Chí Minh", null, 25L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 15000000m, 10000000m, ".NET Core, SQL Server", 1, "Thiết kế đồ họa", null, 0 },
                    { 53L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 2L, "Đoàn, Đoàn and Đinh", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 29, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(2189), false, false, 0, "Đồng Nai", null, 45L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 20000000m, 11000000m, ".NET Core, SQL Server", 1, "Nhân viên kinh doanh", null, 0 },
                    { 54L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 3L, "Đặng - Mai", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 25, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(2230), false, false, 0, "Hà Nội", null, 26L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 60000000m, 27000000m, ".NET Core, SQL Server", 1, "Nhân viên kinh doanh", null, 0 },
                    { 55L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 10L, "Mai, Hồ and Vương", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 3, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(2339), false, false, 0, "Hà Nội", null, 31L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 63000000m, 29000000m, ".NET Core, SQL Server", 1, "Kế toán trưởng", null, 0 },
                    { 56L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 4L, "Lâm Group", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 7, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(2388), false, false, 0, "Hà Nội", null, 41L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 71000000m, 36000000m, ".NET Core, SQL Server", 1, "Chuyên viên Marketing", null, 0 },
                    { 57L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 4L, "Bùi Group", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 18, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(2480), false, false, 0, "Bình Dương", null, 5L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 59000000m, 21000000m, ".NET Core, SQL Server", 1, "Nhân viên nhân sự", null, 0 },
                    { 58L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 1L, "Hoàng Group", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 25, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(2576), false, false, 0, "Bình Dương", null, 18L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 60000000m, 32000000m, ".NET Core, SQL Server", 1, "Nhân viên nhân sự", null, 0 },
                    { 59L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 4L, "Phan - Đoàn", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 31, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(2636), false, false, 0, "Hải Phòng", null, 7L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 47000000m, 38000000m, ".NET Core, SQL Server", 1, "Kỹ sư phần mềm", null, 0 },
                    { 60L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 3L, "Lê, Tăng and Trịnh", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 24, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(2728), false, false, 0, "Đồng Nai", null, 20L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 45000000m, 36000000m, ".NET Core, SQL Server", 1, "Chuyên viên Marketing", null, 0 },
                    { 61L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 4L, "Trần, Tăng and Lâm", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 25, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(2788), false, false, 0, "Bình Dương", null, 43L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 48000000m, 12000000m, ".NET Core, SQL Server", 1, "Kế toán trưởng", null, 0 },
                    { 62L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 2L, "Phùng, Tô and Bùi", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 18, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(2885), false, false, 0, "Đà Nẵng", null, 49L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 33000000m, 22000000m, ".NET Core, SQL Server", 1, "Chuyên viên tư vấn", null, 0 },
                    { 63L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 10L, "Lâm and Sons", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 19, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(2983), false, false, 0, "TP. Hồ Chí Minh", null, 46L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 34000000m, 17000000m, ".NET Core, SQL Server", 1, "Chuyên viên Marketing", null, 0 },
                    { 64L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 5L, "Tô - Phạm", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 3, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(3024), false, false, 0, "TP. Hồ Chí Minh", null, 51L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 50000000m, 30000000m, ".NET Core, SQL Server", 1, "Quản lý dự án", null, 0 },
                    { 65L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 2L, "Hoàng, Đinh and Lê", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 9, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(3109), false, false, 0, "Bình Dương", null, 9L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 69000000m, 30000000m, ".NET Core, SQL Server", 1, "Chuyên viên tư vấn", null, 0 },
                    { 66L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 2L, "Mai, Tô and Mai", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 5, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(3194), false, false, 0, "Đồng Nai", null, 38L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 31000000m, 25000000m, ".NET Core, SQL Server", 1, "Quản lý dự án", null, 0 },
                    { 67L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 9L, "Mai Inc", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 9, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(3240), false, false, 0, "Cần Thơ", null, 8L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 29000000m, 14000000m, ".NET Core, SQL Server", 1, "Lập trình viên Frontend", null, 0 },
                    { 68L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 10L, "Đoàn - Tăng", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 1, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(3310), false, false, 0, "TP. Hồ Chí Minh", null, 16L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 49000000m, 24000000m, ".NET Core, SQL Server", 1, "Quản lý dự án", null, 0 },
                    { 69L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 5L, "Trần Group", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 13, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(3355), false, false, 0, "Bình Dương", null, 46L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 58000000m, 35000000m, ".NET Core, SQL Server", 1, "Thiết kế đồ họa", null, 0 },
                    { 70L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 1L, "Vũ Group", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 12, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(3423), false, false, 0, "TP. Hồ Chí Minh", null, 4L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 59000000m, 34000000m, ".NET Core, SQL Server", 1, "Kế toán trưởng", null, 0 },
                    { 71L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 5L, "Đinh - Vũ", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 4, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(3466), false, false, 0, "Đà Nẵng", null, 42L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 28000000m, 14000000m, ".NET Core, SQL Server", 1, "Kế toán trưởng", null, 0 },
                    { 72L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 9L, "Phan, Phạm and Dương", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 24, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(3547), false, false, 0, "Bình Dương", null, 34L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 65000000m, 35000000m, ".NET Core, SQL Server", 1, "Chuyên viên Marketing", null, 0 },
                    { 73L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 1L, "Phạm - Lê", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 10, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(3590), false, false, 0, "TP. Hồ Chí Minh", null, 9L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 55000000m, 35000000m, ".NET Core, SQL Server", 1, "Nhân viên nhân sự", null, 0 },
                    { 74L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 3L, "Lý - Lê", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 30, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(3659), false, false, 0, "Bình Dương", null, 32L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 48000000m, 35000000m, ".NET Core, SQL Server", 1, "Nhân viên kinh doanh", null, 0 },
                    { 75L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 8L, "Dương Group", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 29, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(3705), false, false, 0, "Đồng Nai", null, 42L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 25000000m, 12000000m, ".NET Core, SQL Server", 1, "Quản lý dự án", null, 0 },
                    { 76L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 5L, "Đào - Lê", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 21, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(3777), false, false, 0, "Đồng Nai", null, 31L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 59000000m, 24000000m, ".NET Core, SQL Server", 1, "Nhân viên nhân sự", null, 0 },
                    { 77L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 4L, "Nguyễn, Trịnh and Hoàng", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 20, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(3909), false, false, 0, "Cần Thơ", null, 34L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 52000000m, 16000000m, ".NET Core, SQL Server", 1, "Chuyên viên tư vấn", null, 0 },
                    { 78L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 9L, "Hoàng and Sons", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 28, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(3955), false, false, 0, "Hà Nội", null, 50L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 41000000m, 36000000m, ".NET Core, SQL Server", 1, "Chuyên viên Marketing", null, 0 },
                    { 79L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 8L, "Hà and Sons", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 14, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(4022), false, false, 0, "TP. Hồ Chí Minh", null, 7L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 42000000m, 16000000m, ".NET Core, SQL Server", 1, "Lập trình viên .NET", null, 0 },
                    { 80L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 5L, "Đinh, Mai and Vũ", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 31, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(4083), false, false, 0, "Bình Dương", null, 8L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 72000000m, 35000000m, ".NET Core, SQL Server", 1, "Thiết kế đồ họa", null, 0 },
                    { 81L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 1L, "Vương, Vương and Lâm", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 8, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(4172), false, false, 0, "Hải Phòng", null, 30L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 42000000m, 26000000m, ".NET Core, SQL Server", 1, "Nhân viên kinh doanh", null, 0 },
                    { 82L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 8L, "Tăng - Đoàn", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 24, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(4235), false, false, 0, "Đà Nẵng", null, 50L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 50000000m, 38000000m, ".NET Core, SQL Server", 1, "Nhân viên nhân sự", null, 0 },
                    { 83L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 7L, "Trần and Sons", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 27, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(4279), false, false, 0, "Hà Nội", null, 47L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 69000000m, 35000000m, ".NET Core, SQL Server", 1, "Kế toán trưởng", null, 0 },
                    { 84L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 3L, "Vũ and Sons", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 31, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(4324), false, false, 0, "TP. Hồ Chí Minh", null, 37L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 55000000m, 24000000m, ".NET Core, SQL Server", 1, "Kế toán trưởng", null, 0 },
                    { 85L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 4L, "Trịnh Group", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 29, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(4397), false, false, 0, "Hải Phòng", null, 47L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 54000000m, 25000000m, ".NET Core, SQL Server", 1, "Lập trình viên Frontend", null, 0 },
                    { 86L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 6L, "Trịnh Inc", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 26, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(4442), false, false, 0, "Hải Phòng", null, 38L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 39000000m, 21000000m, ".NET Core, SQL Server", 1, "Kỹ sư phần mềm", null, 0 },
                    { 87L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 7L, "Tăng, Trịnh and Tăng", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 18, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(4518), false, false, 0, "Hải Phòng", null, 4L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 44000000m, 14000000m, ".NET Core, SQL Server", 1, "Thiết kế đồ họa", null, 0 },
                    { 88L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 3L, "Trương, Hoàng and Lâm", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 20, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(4641), false, false, 0, "Hà Nội", null, 42L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 49000000m, 16000000m, ".NET Core, SQL Server", 1, "Lập trình viên .NET", null, 0 },
                    { 89L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 4L, "Bùi, Đoàn and Bùi", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 2, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(4780), false, false, 0, "TP. Hồ Chí Minh", null, 41L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 57000000m, 35000000m, ".NET Core, SQL Server", 1, "Nhân viên kinh doanh", null, 0 },
                    { 90L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 4L, "Dương - Đoàn", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 2, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(4822), false, false, 0, "Bình Dương", null, 22L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 45000000m, 11000000m, ".NET Core, SQL Server", 1, "Nhân viên kinh doanh", null, 0 },
                    { 91L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 6L, "Phạm - Phan", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 30, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(4911), false, false, 0, "Hà Nội", null, 5L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 31000000m, 15000000m, ".NET Core, SQL Server", 1, "Thiết kế đồ họa", null, 0 },
                    { 92L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 9L, "Lý Group", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 28, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(4957), false, false, 0, "Đà Nẵng", null, 31L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 55000000m, 30000000m, ".NET Core, SQL Server", 1, "Lập trình viên .NET", null, 0 },
                    { 93L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 10L, "Đinh - Lý", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 5, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(5025), false, false, 0, "TP. Hồ Chí Minh", null, 3L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 34000000m, 13000000m, ".NET Core, SQL Server", 1, "Chuyên viên tư vấn", null, 0 },
                    { 94L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 2L, "Hồ - Nguyễn", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 21, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(5067), false, false, 0, "Bình Dương", null, 11L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 58000000m, 38000000m, ".NET Core, SQL Server", 1, "Chuyên viên tư vấn", null, 0 },
                    { 95L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 10L, "Lâm - Mai", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 19, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(5131), false, false, 0, "Hải Phòng", null, 20L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 60000000m, 29000000m, ".NET Core, SQL Server", 1, "Chuyên viên tư vấn", null, 0 },
                    { 96L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 7L, "Đặng LLC", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 24, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(5188), false, false, 0, "Hải Phòng", null, 39L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 38000000m, 31000000m, ".NET Core, SQL Server", 1, "Thiết kế đồ họa", null, 0 },
                    { 97L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 6L, "Phùng Inc", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 19, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(5307), false, false, 0, "Hà Nội", null, 26L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 50000000m, 15000000m, ".NET Core, SQL Server", 1, "Chuyên viên tư vấn", null, 0 },
                    { 98L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 7L, "Trương and Sons", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 26, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(5354), false, false, 0, "Đồng Nai", null, 22L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 46000000m, 21000000m, ".NET Core, SQL Server", 1, "Nhân viên nhân sự", null, 0 },
                    { 99L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 6L, "Hoàng and Sons", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 19, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(5438), false, false, 0, "TP. Hồ Chí Minh", null, 21L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 48000000m, 36000000m, ".NET Core, SQL Server", 1, "Chuyên viên tư vấn", null, 0 },
                    { 100L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 2L, "Phạm, Lê and Trịnh", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 31, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(5527), false, false, 0, "TP. Hồ Chí Minh", null, 48L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 49000000m, 17000000m, ".NET Core, SQL Server", 1, "Chuyên viên tư vấn", null, 0 },
                    { 101L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 4L, "Mai LLC", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 13, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(5571), false, false, 0, "Đà Nẵng", null, 17L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 42000000m, 18000000m, ".NET Core, SQL Server", 1, "Nhân viên nhân sự", null, 0 },
                    { 102L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 10L, "Phạm, Dương and Dương", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 27, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(5669), false, false, 0, "TP. Hồ Chí Minh", null, 32L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 60000000m, 31000000m, ".NET Core, SQL Server", 1, "Nhân viên kinh doanh", null, 0 },
                    { 103L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 6L, "Phan Inc", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 16, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(5712), false, false, 0, "Bình Dương", null, 15L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 66000000m, 38000000m, ".NET Core, SQL Server", 1, "Chuyên viên Marketing", null, 0 },
                    { 104L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 6L, "Tăng - Phạm", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 20, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(5777), false, false, 0, "TP. Hồ Chí Minh", null, 2L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 40000000m, 20000000m, ".NET Core, SQL Server", 1, "Chuyên viên tư vấn", null, 0 },
                    { 105L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 1L, "Đỗ - Đinh", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 20, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(5818), false, false, 0, "Cần Thơ", null, 21L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 60000000m, 26000000m, ".NET Core, SQL Server", 1, "Lập trình viên .NET", null, 0 },
                    { 106L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 10L, "Nguyễn and Sons", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 24, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(5886), false, false, 0, "Cần Thơ", null, 13L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 36000000m, 12000000m, ".NET Core, SQL Server", 1, "Lập trình viên .NET", null, 0 },
                    { 107L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 4L, "Hồ LLC", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 28, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(5931), false, false, 0, "Bình Dương", null, 32L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 41000000m, 33000000m, ".NET Core, SQL Server", 1, "Nhân viên kinh doanh", null, 0 },
                    { 108L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 7L, "Phạm, Phùng and Phạm", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 19, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(6020), false, false, 0, "Cần Thơ", null, 32L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 50000000m, 29000000m, ".NET Core, SQL Server", 1, "Chuyên viên Marketing", null, 0 },
                    { 109L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 6L, "Hoàng - Lê", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 22, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(6061), false, false, 0, "Bình Dương", null, 41L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 30000000m, 19000000m, ".NET Core, SQL Server", 1, "Chuyên viên Marketing", null, 0 },
                    { 110L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 5L, "Ngô Inc", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 16, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(6131), false, false, 0, "TP. Hồ Chí Minh", null, 48L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 42000000m, 16000000m, ".NET Core, SQL Server", 1, "Chuyên viên tư vấn", null, 0 },
                    { 111L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 2L, "Lý, Lâm and Trần", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 6, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(6217), false, false, 0, "Hải Phòng", null, 28L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 27000000m, 11000000m, ".NET Core, SQL Server", 1, "Chuyên viên Marketing", null, 0 },
                    { 112L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 4L, "Hà Inc", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 18, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(6262), false, false, 0, "Hải Phòng", null, 16L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 40000000m, 22000000m, ".NET Core, SQL Server", 1, "Nhân viên nhân sự", null, 0 },
                    { 113L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 10L, "Tăng, Phùng and Lý", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 14, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(6336), false, false, 0, "TP. Hồ Chí Minh", null, 19L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 72000000m, 33000000m, ".NET Core, SQL Server", 1, "Nhân viên nhân sự", null, 0 },
                    { 114L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 10L, "Lê - Hồ", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 7, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(6379), false, false, 0, "Hà Nội", null, 25L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 50000000m, 23000000m, ".NET Core, SQL Server", 1, "Nhân viên nhân sự", null, 0 },
                    { 115L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 7L, "Đào Group", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 8, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(6451), false, false, 0, "Cần Thơ", null, 43L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 55000000m, 30000000m, ".NET Core, SQL Server", 1, "Thiết kế đồ họa", null, 0 },
                    { 116L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 1L, "Trương and Sons", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 18, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(6496), false, false, 0, "Đà Nẵng", null, 29L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 47000000m, 12000000m, ".NET Core, SQL Server", 1, "Chuyên viên Marketing", null, 0 },
                    { 117L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 8L, "Nguyễn - Trương", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 1, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(6569), false, false, 0, "TP. Hồ Chí Minh", null, 11L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 35000000m, 25000000m, ".NET Core, SQL Server", 1, "Quản lý dự án", null, 0 },
                    { 118L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 5L, "Trương, Trương and Đào", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 7, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(6655), false, false, 0, "Hà Nội", null, 28L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 33000000m, 27000000m, ".NET Core, SQL Server", 1, "Kỹ sư phần mềm", null, 0 },
                    { 119L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 8L, "Phạm LLC", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 12, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(6699), false, false, 0, "Đồng Nai", null, 13L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 38000000m, 12000000m, ".NET Core, SQL Server", 1, "Kỹ sư phần mềm", null, 0 },
                    { 120L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 9L, "Bùi and Sons", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 12, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(6768), false, false, 0, "TP. Hồ Chí Minh", null, 34L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 35000000m, 23000000m, ".NET Core, SQL Server", 1, "Chuyên viên tư vấn", null, 0 },
                    { 121L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 3L, "Bùi - Đào", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 19, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(6809), false, false, 0, "Đồng Nai", null, 49L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 66000000m, 34000000m, ".NET Core, SQL Server", 1, "Chuyên viên Marketing", null, 0 },
                    { 122L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 6L, "Vương - Lý", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 21, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(6875), false, false, 0, "TP. Hồ Chí Minh", null, 9L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 51000000m, 18000000m, ".NET Core, SQL Server", 1, "Nhân viên kinh doanh", null, 0 },
                    { 123L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 9L, "Phan, Vũ and Đinh", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 21, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(6936), false, false, 0, "Hà Nội", null, 14L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 37000000m, 19000000m, ".NET Core, SQL Server", 1, "Nhân viên kinh doanh", null, 0 },
                    { 124L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 5L, "Phan, Tăng and Đỗ", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 19, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(7021), false, false, 0, "TP. Hồ Chí Minh", null, 16L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 37000000m, 19000000m, ".NET Core, SQL Server", 1, "Kế toán trưởng", null, 0 },
                    { 125L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 10L, "Tăng - Đinh", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 13, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(7085), false, false, 0, "Hải Phòng", null, 48L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 64000000m, 26000000m, ".NET Core, SQL Server", 1, "Lập trình viên Frontend", null, 0 },
                    { 126L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 6L, "Trần - Đỗ", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 14, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(7126), false, false, 0, "Hải Phòng", null, 11L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 37000000m, 27000000m, ".NET Core, SQL Server", 1, "Kế toán trưởng", null, 0 },
                    { 127L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 2L, "Nguyễn and Sons", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 23, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(7185), false, false, 0, "Hải Phòng", null, 10L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 45000000m, 12000000m, ".NET Core, SQL Server", 1, "Chuyên viên tư vấn", null, 0 },
                    { 128L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 3L, "Bùi LLC", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 3, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(7231), false, false, 0, "Bình Dương", null, 50L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 34000000m, 21000000m, ".NET Core, SQL Server", 1, "Chuyên viên tư vấn", null, 0 },
                    { 129L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 9L, "Phạm and Sons", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 12, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(7304), false, false, 0, "Đồng Nai", null, 43L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 59000000m, 29000000m, ".NET Core, SQL Server", 1, "Nhân viên nhân sự", null, 0 },
                    { 130L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 6L, "Trương - Phùng", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 12, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(7346), false, false, 0, "Đà Nẵng", null, 31L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 37000000m, 16000000m, ".NET Core, SQL Server", 1, "Chuyên viên tư vấn", null, 0 },
                    { 131L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 3L, "Bùi, Vũ and Phan", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 26, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(7440), false, false, 0, "TP. Hồ Chí Minh", null, 20L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 29000000m, 12000000m, ".NET Core, SQL Server", 1, "Kế toán trưởng", null, 0 },
                    { 132L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 5L, "Nguyễn, Vương and Vũ", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 23, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(7524), false, false, 0, "Đồng Nai", null, 14L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 37000000m, 13000000m, ".NET Core, SQL Server", 1, "Nhân viên kinh doanh", null, 0 },
                    { 133L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 1L, "Phạm Inc", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 18, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(7568), false, false, 0, "Đà Nẵng", null, 37L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 78000000m, 39000000m, ".NET Core, SQL Server", 1, "Quản lý dự án", null, 0 },
                    { 134L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 9L, "Mai Group", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 17, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(7641), false, false, 0, "Hà Nội", null, 34L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 52000000m, 20000000m, ".NET Core, SQL Server", 1, "Thiết kế đồ họa", null, 0 },
                    { 135L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 10L, "Hồ Group", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 29, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(7686), false, false, 0, "Đà Nẵng", null, 31L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 42000000m, 27000000m, ".NET Core, SQL Server", 1, "Nhân viên nhân sự", null, 0 },
                    { 136L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 7L, "Lý - Phạm", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 5, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(7750), false, false, 0, "TP. Hồ Chí Minh", null, 51L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 50000000m, 27000000m, ".NET Core, SQL Server", 1, "Chuyên viên tư vấn", null, 0 },
                    { 137L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 9L, "Lâm - Trịnh", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 26, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(7792), false, false, 0, "Hải Phòng", null, 23L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 66000000m, 27000000m, ".NET Core, SQL Server", 1, "Chuyên viên Marketing", null, 0 },
                    { 138L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 2L, "Đặng Group", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 12, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(7862), false, false, 0, "Bình Dương", null, 28L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 42000000m, 36000000m, ".NET Core, SQL Server", 1, "Thiết kế đồ họa", null, 0 },
                    { 139L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 8L, "Bùi, Vũ and Đặng", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 5, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(7922), false, false, 0, "Đà Nẵng", null, 22L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 40000000m, 31000000m, ".NET Core, SQL Server", 1, "Nhân viên kinh doanh", null, 0 },
                    { 140L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 3L, "Phan Inc", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 31, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(7993), false, false, 0, "Bình Dương", null, 24L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 51000000m, 30000000m, ".NET Core, SQL Server", 1, "Kế toán trưởng", null, 0 },
                    { 141L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 9L, "Lâm, Trần and Đào", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 14, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(8068), false, false, 0, "Đà Nẵng", null, 23L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 38000000m, 31000000m, ".NET Core, SQL Server", 1, "Thiết kế đồ họa", null, 0 },
                    { 142L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 3L, "Mai Inc", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 11, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(8114), false, false, 0, "Hải Phòng", null, 5L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 37000000m, 16000000m, ".NET Core, SQL Server", 1, "Chuyên viên tư vấn", null, 0 },
                    { 143L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 9L, "Hà, Lê and Mai", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 17, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(8202), false, false, 0, "Hải Phòng", null, 44L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 37000000m, 11000000m, ".NET Core, SQL Server", 1, "Kế toán trưởng", null, 0 },
                    { 144L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 4L, "Vương Inc", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 18, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(8248), false, false, 0, "Hà Nội", null, 46L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 61000000m, 27000000m, ".NET Core, SQL Server", 1, "Nhân viên nhân sự", null, 0 },
                    { 145L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 10L, "Trần Group", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 24, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(8323), false, false, 0, "Bình Dương", null, 29L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 70000000m, 39000000m, ".NET Core, SQL Server", 1, "Thiết kế đồ họa", null, 0 },
                    { 146L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 1L, "Hồ - Bùi", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 5, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(8365), false, false, 0, "Đồng Nai", null, 16L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 33000000m, 13000000m, ".NET Core, SQL Server", 1, "Lập trình viên Frontend", null, 0 },
                    { 147L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 8L, "Đặng LLC", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 8, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(8435), false, false, 0, "Bình Dương", null, 26L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 50000000m, 20000000m, ".NET Core, SQL Server", 1, "Kỹ sư phần mềm", null, 0 },
                    { 148L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 10L, "Lý Group", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 21, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(8479), false, false, 0, "Cần Thơ", null, 22L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 39000000m, 27000000m, ".NET Core, SQL Server", 1, "Chuyên viên tư vấn", null, 0 },
                    { 149L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 1L, "Phùng, Mai and Đinh", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 25, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(8562), false, false, 0, "Đồng Nai", null, 28L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 43000000m, 26000000m, ".NET Core, SQL Server", 1, "Kế toán trưởng", null, 0 },
                    { 150L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 4L, "Vương - Bùi", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 20, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(8629), false, false, 0, "Cần Thơ", null, 19L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 57000000m, 25000000m, ".NET Core, SQL Server", 1, "Quản lý dự án", null, 0 },
                    { 151L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 3L, "Mai, Mai and Dương", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 26, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(8690), false, false, 0, "Đà Nẵng", null, 41L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 54000000m, 26000000m, ".NET Core, SQL Server", 1, "Chuyên viên Marketing", null, 0 },
                    { 152L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 8L, "Hà Group", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 31, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(8758), false, false, 0, "Đà Nẵng", null, 29L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 32000000m, 22000000m, ".NET Core, SQL Server", 1, "Chuyên viên Marketing", null, 0 },
                    { 153L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 7L, "Lâm - Phan", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 6, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(8799), false, false, 0, "Hà Nội", null, 49L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 30000000m, 14000000m, ".NET Core, SQL Server", 1, "Nhân viên kinh doanh", null, 0 },
                    { 154L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 8L, "Lý - Tăng", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 15, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(8867), false, false, 0, "Đà Nẵng", null, 51L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 39000000m, 32000000m, ".NET Core, SQL Server", 1, "Lập trình viên .NET", null, 0 },
                    { 155L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 10L, "Vũ, Ngô and Hoàng", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 18, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(8944), false, false, 0, "Hải Phòng", null, 23L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 31000000m, 14000000m, ".NET Core, SQL Server", 1, "Lập trình viên Frontend", null, 0 },
                    { 156L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 8L, "Hà and Sons", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 22, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(8988), false, false, 0, "Đồng Nai", null, 36L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 39000000m, 28000000m, ".NET Core, SQL Server", 1, "Nhân viên kinh doanh", null, 0 },
                    { 157L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 2L, "Trần, Mai and Phạm", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 31, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(9076), false, false, 0, "Bình Dương", null, 18L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 64000000m, 39000000m, ".NET Core, SQL Server", 1, "Kế toán trưởng", null, 0 },
                    { 158L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 2L, "Đào, Đinh and Đinh", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 14, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(9168), false, false, 0, "Đà Nẵng", null, 37L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 42000000m, 22000000m, ".NET Core, SQL Server", 1, "Thiết kế đồ họa", null, 0 },
                    { 159L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 1L, "Nguyễn Group", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 27, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(9213), false, false, 0, "Đà Nẵng", null, 29L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 40000000m, 34000000m, ".NET Core, SQL Server", 1, "Nhân viên kinh doanh", null, 0 },
                    { 160L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 2L, "Phùng, Tô and Trịnh", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 5, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(9296), false, false, 0, "Đà Nẵng", null, 42L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 40000000m, 13000000m, ".NET Core, SQL Server", 1, "Quản lý dự án", null, 0 },
                    { 161L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 10L, "Trần Group", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 14, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(9342), false, false, 0, "Cần Thơ", null, 46L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 29000000m, 17000000m, ".NET Core, SQL Server", 1, "Chuyên viên Marketing", null, 0 },
                    { 162L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 9L, "Mai Group", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 12, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(9416), false, false, 0, "Cần Thơ", null, 33L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 50000000m, 29000000m, ".NET Core, SQL Server", 1, "Thiết kế đồ họa", null, 0 },
                    { 163L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 5L, "Dương, Trương and Phạm", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 15, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(9500), false, false, 0, "TP. Hồ Chí Minh", null, 38L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 44000000m, 31000000m, ".NET Core, SQL Server", 1, "Lập trình viên Frontend", null, 0 },
                    { 164L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 10L, "Phan and Sons", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 16, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(9545), false, false, 0, "Đồng Nai", null, 34L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 34000000m, 14000000m, ".NET Core, SQL Server", 1, "Chuyên viên Marketing", null, 0 },
                    { 165L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 5L, "Tô - Trịnh", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 23, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(9610), false, false, 0, "Bình Dương", null, 50L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 45000000m, 25000000m, ".NET Core, SQL Server", 1, "Lập trình viên Frontend", null, 0 },
                    { 166L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 4L, "Đinh, Trương and Trịnh", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 23, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(9671), false, false, 0, "Hà Nội", null, 12L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 72000000m, 34000000m, ".NET Core, SQL Server", 1, "Kế toán trưởng", null, 0 },
                    { 167L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 1L, "Phan, Mai and Phan", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 31, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(9754), false, false, 0, "Cần Thơ", null, 13L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 76000000m, 37000000m, ".NET Core, SQL Server", 1, "Nhân viên kinh doanh", null, 0 },
                    { 168L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 9L, "Nguyễn, Hà and Trần", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 21, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(9829), false, false, 0, "Hải Phòng", null, 35L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 21000000m, 12000000m, ".NET Core, SQL Server", 1, "Nhân viên nhân sự", null, 0 },
                    { 169L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 1L, "Đinh, Dương and Đặng", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 23, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(9919), false, false, 0, "Đồng Nai", null, 3L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 41000000m, 17000000m, ".NET Core, SQL Server", 1, "Quản lý dự án", null, 0 },
                    { 170L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 6L, "Nguyễn, Vũ and Trịnh", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 18, 14, 26, 47, 5, DateTimeKind.Utc).AddTicks(9978), false, false, 0, "Cần Thơ", null, 23L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 54000000m, 29000000m, ".NET Core, SQL Server", 1, "Lập trình viên .NET", null, 0 },
                    { 171L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 7L, "Trịnh - Lý", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 26, 14, 26, 47, 6, DateTimeKind.Utc).AddTicks(48), false, false, 0, "Hải Phòng", null, 10L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 38000000m, 26000000m, ".NET Core, SQL Server", 1, "Kế toán trưởng", null, 0 },
                    { 172L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 6L, "Phùng, Tô and Hồ", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 2, 14, 26, 47, 6, DateTimeKind.Utc).AddTicks(132), false, false, 0, "Cần Thơ", null, 45L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 38000000m, 22000000m, ".NET Core, SQL Server", 1, "Thiết kế đồ họa", null, 0 },
                    { 173L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 6L, "Trần, Tô and Hoàng", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 7, 14, 26, 47, 6, DateTimeKind.Utc).AddTicks(194), false, false, 0, "Hà Nội", null, 29L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 28000000m, 18000000m, ".NET Core, SQL Server", 1, "Nhân viên nhân sự", null, 0 },
                    { 174L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 5L, "Dương and Sons", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 27, 14, 26, 47, 6, DateTimeKind.Utc).AddTicks(261), false, false, 0, "Hà Nội", null, 16L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 21000000m, 15000000m, ".NET Core, SQL Server", 1, "Nhân viên nhân sự", null, 0 },
                    { 175L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 6L, "Phạm - Hà", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 6, 14, 26, 47, 6, DateTimeKind.Utc).AddTicks(303), false, false, 0, "Cần Thơ", null, 28L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 71000000m, 33000000m, ".NET Core, SQL Server", 1, "Nhân viên nhân sự", null, 0 },
                    { 176L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 1L, "Trần - Ngô", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 15, 14, 26, 47, 6, DateTimeKind.Utc).AddTicks(391), false, false, 0, "Bình Dương", null, 11L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 31000000m, 25000000m, ".NET Core, SQL Server", 1, "Lập trình viên Frontend", null, 0 },
                    { 177L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 4L, "Đào LLC", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 30, 14, 26, 47, 6, DateTimeKind.Utc).AddTicks(435), false, false, 0, "Bình Dương", null, 24L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 36000000m, 14000000m, ".NET Core, SQL Server", 1, "Kế toán trưởng", null, 0 },
                    { 178L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 8L, "Bùi Group", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 30, 14, 26, 47, 6, DateTimeKind.Utc).AddTicks(525), false, false, 0, "Đà Nẵng", null, 3L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 58000000m, 36000000m, ".NET Core, SQL Server", 1, "Thiết kế đồ họa", null, 0 },
                    { 179L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 9L, "Vũ, Lâm and Tô", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 9, 14, 26, 47, 6, DateTimeKind.Utc).AddTicks(639), false, false, 0, "Đồng Nai", null, 15L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 62000000m, 35000000m, ".NET Core, SQL Server", 1, "Chuyên viên Marketing", null, 0 },
                    { 180L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 1L, "Vũ - Trịnh", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 14, 14, 26, 47, 6, DateTimeKind.Utc).AddTicks(680), false, false, 0, "Đồng Nai", null, 4L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 57000000m, 19000000m, ".NET Core, SQL Server", 1, "Nhân viên nhân sự", null, 0 },
                    { 181L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 4L, "Đoàn - Nguyễn", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 18, 14, 26, 47, 6, DateTimeKind.Utc).AddTicks(744), false, false, 0, "Bình Dương", null, 23L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 32000000m, 20000000m, ".NET Core, SQL Server", 1, "Chuyên viên Marketing", null, 0 },
                    { 182L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 2L, "Dương, Đỗ and Tăng", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 18, 14, 26, 47, 6, DateTimeKind.Utc).AddTicks(803), false, false, 0, "Đồng Nai", null, 7L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 50000000m, 35000000m, ".NET Core, SQL Server", 1, "Nhân viên kinh doanh", null, 0 },
                    { 183L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 10L, "Trương, Lê and Đoàn", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 9, 14, 26, 47, 6, DateTimeKind.Utc).AddTicks(916), false, false, 0, "TP. Hồ Chí Minh", null, 41L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 35000000m, 24000000m, ".NET Core, SQL Server", 1, "Thiết kế đồ họa", null, 0 },
                    { 184L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 8L, "Hồ - Tô", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 16, 14, 26, 47, 6, DateTimeKind.Utc).AddTicks(1009), false, false, 0, "TP. Hồ Chí Minh", null, 11L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 72000000m, 37000000m, ".NET Core, SQL Server", 1, "Nhân viên nhân sự", null, 0 },
                    { 185L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 9L, "Bùi Group", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 5, 14, 26, 47, 6, DateTimeKind.Utc).AddTicks(1053), false, false, 0, "Cần Thơ", null, 14L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 55000000m, 21000000m, ".NET Core, SQL Server", 1, "Nhân viên kinh doanh", null, 0 },
                    { 186L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 4L, "Dương, Phùng and Phan", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 18, 14, 26, 47, 6, DateTimeKind.Utc).AddTicks(1163), false, false, 0, "Đà Nẵng", null, 18L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 51000000m, 27000000m, ".NET Core, SQL Server", 1, "Kế toán trưởng", null, 0 },
                    { 187L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 7L, "Phạm - Đào", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 16, 14, 26, 47, 6, DateTimeKind.Utc).AddTicks(1370), false, false, 0, "Bình Dương", null, 39L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 21000000m, 14000000m, ".NET Core, SQL Server", 1, "Nhân viên nhân sự", null, 0 },
                    { 188L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 9L, "Đỗ, Tăng and Vương", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 2, 14, 26, 47, 6, DateTimeKind.Utc).AddTicks(1463), false, false, 0, "TP. Hồ Chí Minh", null, 8L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 46000000m, 17000000m, ".NET Core, SQL Server", 1, "Quản lý dự án", null, 0 },
                    { 189L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 8L, "Mai - Ngô", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 3, 14, 26, 47, 6, DateTimeKind.Utc).AddTicks(1643), false, false, 0, "TP. Hồ Chí Minh", null, 34L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 42000000m, 17000000m, ".NET Core, SQL Server", 1, "Nhân viên nhân sự", null, 0 },
                    { 190L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 10L, "Phùng LLC", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 18, 14, 26, 47, 6, DateTimeKind.Utc).AddTicks(1711), false, false, 0, "Đà Nẵng", null, 15L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 52000000m, 36000000m, ".NET Core, SQL Server", 1, "Thiết kế đồ họa", null, 0 },
                    { 191L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 3L, "Hà - Phan", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 14, 14, 26, 47, 6, DateTimeKind.Utc).AddTicks(1786), false, false, 0, "Hải Phòng", null, 32L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 56000000m, 23000000m, ".NET Core, SQL Server", 1, "Kỹ sư phần mềm", null, 0 },
                    { 192L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 1L, "Lâm Inc", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 22, 14, 26, 47, 6, DateTimeKind.Utc).AddTicks(1838), false, false, 0, "Đồng Nai", null, 7L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 43000000m, 23000000m, ".NET Core, SQL Server", 1, "Chuyên viên tư vấn", null, 0 },
                    { 193L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 8L, "Mai and Sons", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 30, 14, 26, 47, 6, DateTimeKind.Utc).AddTicks(1923), false, false, 0, "Hà Nội", null, 51L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 32000000m, 13000000m, ".NET Core, SQL Server", 1, "Chuyên viên Marketing", null, 0 },
                    { 194L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 10L, "Hồ Group", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 3, 27, 14, 26, 47, 6, DateTimeKind.Utc).AddTicks(1975), false, false, 0, "Cần Thơ", null, 32L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 41000000m, 30000000m, ".NET Core, SQL Server", 1, "Lập trình viên Frontend", null, 0 },
                    { 195L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 10L, "Lâm, Lâm and Hà", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 14, 14, 26, 47, 6, DateTimeKind.Utc).AddTicks(2063), false, false, 0, "Đồng Nai", null, 33L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 41000000m, 24000000m, ".NET Core, SQL Server", 1, "Quản lý dự án", null, 0 },
                    { 196L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 2L, "Đỗ - Phùng", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 14, 14, 26, 47, 6, DateTimeKind.Utc).AddTicks(2111), false, false, 0, "Hải Phòng", null, 36L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 47000000m, 25000000m, ".NET Core, SQL Server", 1, "Chuyên viên tư vấn", null, 0 },
                    { 197L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 6L, "Đoàn LLC", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 13, 14, 26, 47, 6, DateTimeKind.Utc).AddTicks(2197), false, false, 0, "Đà Nẵng", null, 36L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 36000000m, 25000000m, ".NET Core, SQL Server", 1, "Chuyên viên Marketing", null, 0 },
                    { 198L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 4L, "Phạm, Hoàng and Mai", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 13, 14, 26, 47, 6, DateTimeKind.Utc).AddTicks(2324), false, false, 0, "Cần Thơ", null, 13L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 32000000m, 18000000m, ".NET Core, SQL Server", 1, "Lập trình viên Frontend", null, 0 },
                    { 199L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 7L, "Phan - Ngô", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 21, 14, 26, 47, 6, DateTimeKind.Utc).AddTicks(2371), false, false, 0, "Cần Thơ", null, 15L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 46000000m, 39000000m, ".NET Core, SQL Server", 1, "Kỹ sư phần mềm", null, 0 },
                    { 200L, null, "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm", null, 1L, "Ngô Inc", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.", null, new DateTime(2026, 4, 7, 14, 26, 47, 6, DateTimeKind.Utc).AddTicks(2448), false, false, 0, "Đà Nẵng", null, 7L, "Có kinh nghiệm tương đương, nhiệt huyết với công việc.", 31000000m, 24000000m, ".NET Core, SQL Server", 1, "Lập trình viên .NET", null, 0 }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "IsRead", "Message", "RedirectUrl", "Title", "Type", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 2L },
                    { 2L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 3L },
                    { 3L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 4L },
                    { 4L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 5L },
                    { 5L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 6L },
                    { 6L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 7L },
                    { 7L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 8L },
                    { 8L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 9L },
                    { 9L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 10L },
                    { 10L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 11L },
                    { 11L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 12L },
                    { 12L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 13L },
                    { 13L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 14L },
                    { 14L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 15L },
                    { 15L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 16L },
                    { 16L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 17L },
                    { 17L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 18L },
                    { 18L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 19L },
                    { 19L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 20L },
                    { 20L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 21L },
                    { 21L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 22L },
                    { 22L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 23L },
                    { 23L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 24L },
                    { 24L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 25L },
                    { 25L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 26L },
                    { 26L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 27L },
                    { 27L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 28L },
                    { 28L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 29L },
                    { 29L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 30L },
                    { 30L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 31L },
                    { 31L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 32L },
                    { 32L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 33L },
                    { 33L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 34L },
                    { 34L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 35L },
                    { 35L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 36L },
                    { 36L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 37L },
                    { 37L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 38L },
                    { 38L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 39L },
                    { 39L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 40L },
                    { 40L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 41L },
                    { 41L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 42L },
                    { 42L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 43L },
                    { 43L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 44L },
                    { 44L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 45L },
                    { 45L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 46L },
                    { 46L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 47L },
                    { 47L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 48L },
                    { 48L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 49L },
                    { 49L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 50L },
                    { 50L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 51L },
                    { 51L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 52L },
                    { 52L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 53L },
                    { 53L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 54L },
                    { 54L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 55L },
                    { 55L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 56L },
                    { 56L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 57L },
                    { 57L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 58L },
                    { 58L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 59L },
                    { 59L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 60L },
                    { 60L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 61L },
                    { 61L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 62L },
                    { 62L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 63L },
                    { 63L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 64L },
                    { 64L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 65L },
                    { 65L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 66L },
                    { 66L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 67L },
                    { 67L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 68L },
                    { 68L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 69L },
                    { 69L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 70L },
                    { 70L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 71L },
                    { 71L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 72L },
                    { 72L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 73L },
                    { 73L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 74L },
                    { 74L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 75L },
                    { 75L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 76L },
                    { 76L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 77L },
                    { 77L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 78L },
                    { 78L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 79L },
                    { 79L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 80L },
                    { 80L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 81L },
                    { 81L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 82L },
                    { 82L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 83L },
                    { 83L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 84L },
                    { 84L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 85L },
                    { 85L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 86L },
                    { 86L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 87L },
                    { 87L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 88L },
                    { 88L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 89L },
                    { 89L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 90L },
                    { 90L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 91L },
                    { 91L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 92L },
                    { 92L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 93L },
                    { 93L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 94L },
                    { 94L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 95L },
                    { 95L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 96L },
                    { 96L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 97L },
                    { 97L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 98L },
                    { 98L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 99L },
                    { 99L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 100L },
                    { 100L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 101L },
                    { 101L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 102L },
                    { 102L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 103L },
                    { 103L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 104L },
                    { 104L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 105L },
                    { 105L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 106L },
                    { 106L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 107L },
                    { 107L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 108L },
                    { 108L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 109L },
                    { 109L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 110L },
                    { 110L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 111L },
                    { 111L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 112L },
                    { 112L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 113L },
                    { 113L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 114L },
                    { 114L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 115L },
                    { 115L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 116L },
                    { 116L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 117L },
                    { 117L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 118L },
                    { 118L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 119L },
                    { 119L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 120L },
                    { 120L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 121L },
                    { 121L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 122L },
                    { 122L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 123L },
                    { 123L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 124L },
                    { 124L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 125L },
                    { 125L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 126L },
                    { 126L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 127L },
                    { 127L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 128L },
                    { 128L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 129L },
                    { 129L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 130L },
                    { 130L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 131L },
                    { 131L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 132L },
                    { 132L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 133L },
                    { 133L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 134L },
                    { 134L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 135L },
                    { 135L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 136L },
                    { 136L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 137L },
                    { 137L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 138L },
                    { 138L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 139L },
                    { 139L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 140L },
                    { 140L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 141L },
                    { 141L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 142L },
                    { 142L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 143L },
                    { 143L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 144L },
                    { 144L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 145L },
                    { 145L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 146L },
                    { 146L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 147L },
                    { 147L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 148L },
                    { 148L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 149L },
                    { 149L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 150L },
                    { 150L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 151L },
                    { 151L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 152L },
                    { 152L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 153L },
                    { 153L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 154L },
                    { 154L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 155L },
                    { 155L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 156L },
                    { 156L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 157L },
                    { 157L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 158L },
                    { 158L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 159L },
                    { 159L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 160L },
                    { 160L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 161L },
                    { 161L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 162L },
                    { 162L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 163L },
                    { 163L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 164L },
                    { 164L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 165L },
                    { 165L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 166L },
                    { 166L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 167L },
                    { 167L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 168L },
                    { 168L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 169L },
                    { 169L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 170L },
                    { 170L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 171L },
                    { 171L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 172L },
                    { 172L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 173L },
                    { 173L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 174L },
                    { 174L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 175L },
                    { 175L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 176L },
                    { 176L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 177L },
                    { 177L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 178L },
                    { 178L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 179L },
                    { 179L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 180L },
                    { 180L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 181L },
                    { 181L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 182L },
                    { 182L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 183L },
                    { 183L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 184L },
                    { 184L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 185L },
                    { 185L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 186L },
                    { 186L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 187L },
                    { 187L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 188L },
                    { 188L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 189L },
                    { 189L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 190L },
                    { 190L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 191L },
                    { 191L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 192L },
                    { 192L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 193L },
                    { 193L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 194L },
                    { 194L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 195L },
                    { 195L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 196L },
                    { 196L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 197L },
                    { 197L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 198L },
                    { 198L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 199L },
                    { 199L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 200L },
                    { 200L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "Tài khoản của bạn vừa có cập nhật mới.", null, "Hệ thống", 0, null, 201L }
                });

            migrationBuilder.InsertData(
                table: "RefreshTokens",
                columns: new[] { "Id", "CreatedAt", "ExpiryDate", "IsDeleted", "IsRevoked", "Token", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-1", null, 2L },
                    { 2L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-2", null, 3L },
                    { 3L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-3", null, 4L },
                    { 4L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-4", null, 5L },
                    { 5L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-5", null, 6L },
                    { 6L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-6", null, 7L },
                    { 7L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-7", null, 8L },
                    { 8L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-8", null, 9L },
                    { 9L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-9", null, 10L },
                    { 10L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-10", null, 11L },
                    { 11L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-11", null, 12L },
                    { 12L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-12", null, 13L },
                    { 13L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-13", null, 14L },
                    { 14L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-14", null, 15L },
                    { 15L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-15", null, 16L },
                    { 16L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-16", null, 17L },
                    { 17L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-17", null, 18L },
                    { 18L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-18", null, 19L },
                    { 19L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-19", null, 20L },
                    { 20L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-20", null, 21L },
                    { 21L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-21", null, 22L },
                    { 22L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-22", null, 23L },
                    { 23L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-23", null, 24L },
                    { 24L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-24", null, 25L },
                    { 25L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-25", null, 26L },
                    { 26L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-26", null, 27L },
                    { 27L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-27", null, 28L },
                    { 28L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-28", null, 29L },
                    { 29L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-29", null, 30L },
                    { 30L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-30", null, 31L },
                    { 31L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-31", null, 32L },
                    { 32L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-32", null, 33L },
                    { 33L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-33", null, 34L },
                    { 34L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-34", null, 35L },
                    { 35L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-35", null, 36L },
                    { 36L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-36", null, 37L },
                    { 37L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-37", null, 38L },
                    { 38L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-38", null, 39L },
                    { 39L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-39", null, 40L },
                    { 40L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-40", null, 41L },
                    { 41L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-41", null, 42L },
                    { 42L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-42", null, 43L },
                    { 43L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-43", null, 44L },
                    { 44L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-44", null, 45L },
                    { 45L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-45", null, 46L },
                    { 46L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-46", null, 47L },
                    { 47L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-47", null, 48L },
                    { 48L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-48", null, 49L },
                    { 49L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-49", null, 50L },
                    { 50L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, false, "seed-token-50", null, 51L }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "Balance", "CreatedAt", "Currency", "IsDeleted", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 2L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 2L },
                    { 3L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 3L },
                    { 4L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 4L },
                    { 5L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 5L },
                    { 6L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 6L },
                    { 7L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 7L },
                    { 8L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 8L },
                    { 9L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 9L },
                    { 10L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 10L },
                    { 11L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 11L },
                    { 12L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 12L },
                    { 13L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 13L },
                    { 14L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 14L },
                    { 15L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 15L },
                    { 16L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 16L },
                    { 17L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 17L },
                    { 18L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 18L },
                    { 19L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 19L },
                    { 20L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 20L },
                    { 21L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 21L },
                    { 22L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 22L },
                    { 23L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 23L },
                    { 24L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 24L },
                    { 25L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 25L },
                    { 26L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 26L },
                    { 27L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 27L },
                    { 28L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 28L },
                    { 29L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 29L },
                    { 30L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 30L },
                    { 31L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 31L },
                    { 32L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 32L },
                    { 33L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 33L },
                    { 34L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 34L },
                    { 35L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 35L },
                    { 36L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 36L },
                    { 37L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 37L },
                    { 38L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 38L },
                    { 39L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 39L },
                    { 40L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 40L },
                    { 41L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 41L },
                    { 42L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 42L },
                    { 43L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 43L },
                    { 44L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 44L },
                    { 45L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 45L },
                    { 46L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 46L },
                    { 47L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 47L },
                    { 48L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 48L },
                    { 49L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 49L },
                    { 50L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 50L },
                    { 51L, 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 51L },
                    { 52L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 52L },
                    { 53L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 53L },
                    { 54L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 54L },
                    { 55L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 55L },
                    { 56L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 56L },
                    { 57L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 57L },
                    { 58L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 58L },
                    { 59L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 59L },
                    { 60L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 60L },
                    { 61L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 61L },
                    { 62L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 62L },
                    { 63L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 63L },
                    { 64L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 64L },
                    { 65L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 65L },
                    { 66L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 66L },
                    { 67L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 67L },
                    { 68L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 68L },
                    { 69L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 69L },
                    { 70L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 70L },
                    { 71L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 71L },
                    { 72L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 72L },
                    { 73L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 73L },
                    { 74L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 74L },
                    { 75L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 75L },
                    { 76L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 76L },
                    { 77L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 77L },
                    { 78L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 78L },
                    { 79L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 79L },
                    { 80L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 80L },
                    { 81L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 81L },
                    { 82L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 82L },
                    { 83L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 83L },
                    { 84L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 84L },
                    { 85L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 85L },
                    { 86L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 86L },
                    { 87L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 87L },
                    { 88L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 88L },
                    { 89L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 89L },
                    { 90L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 90L },
                    { 91L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 91L },
                    { 92L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 92L },
                    { 93L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 93L },
                    { 94L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 94L },
                    { 95L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 95L },
                    { 96L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 96L },
                    { 97L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 97L },
                    { 98L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 98L },
                    { 99L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 99L },
                    { 100L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 100L },
                    { 101L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 101L },
                    { 102L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 102L },
                    { 103L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 103L },
                    { 104L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 104L },
                    { 105L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 105L },
                    { 106L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 106L },
                    { 107L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 107L },
                    { 108L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 108L },
                    { 109L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 109L },
                    { 110L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 110L },
                    { 111L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 111L },
                    { 112L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 112L },
                    { 113L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 113L },
                    { 114L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 114L },
                    { 115L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 115L },
                    { 116L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 116L },
                    { 117L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 117L },
                    { 118L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 118L },
                    { 119L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 119L },
                    { 120L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 120L },
                    { 121L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 121L },
                    { 122L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 122L },
                    { 123L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 123L },
                    { 124L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 124L },
                    { 125L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 125L },
                    { 126L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 126L },
                    { 127L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 127L },
                    { 128L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 128L },
                    { 129L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 129L },
                    { 130L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 130L },
                    { 131L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 131L },
                    { 132L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 132L },
                    { 133L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 133L },
                    { 134L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 134L },
                    { 135L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 135L },
                    { 136L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 136L },
                    { 137L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 137L },
                    { 138L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 138L },
                    { 139L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 139L },
                    { 140L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 140L },
                    { 141L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 141L },
                    { 142L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 142L },
                    { 143L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 143L },
                    { 144L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 144L },
                    { 145L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 145L },
                    { 146L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 146L },
                    { 147L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 147L },
                    { 148L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 148L },
                    { 149L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 149L },
                    { 150L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 150L },
                    { 151L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 151L },
                    { 152L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 152L },
                    { 153L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 153L },
                    { 154L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 154L },
                    { 155L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 155L },
                    { 156L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 156L },
                    { 157L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 157L },
                    { 158L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 158L },
                    { 159L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 159L },
                    { 160L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 160L },
                    { 161L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 161L },
                    { 162L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 162L },
                    { 163L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 163L },
                    { 164L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 164L },
                    { 165L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 165L },
                    { 166L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 166L },
                    { 167L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 167L },
                    { 168L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 168L },
                    { 169L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 169L },
                    { 170L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 170L },
                    { 171L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 171L },
                    { 172L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 172L },
                    { 173L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 173L },
                    { 174L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 174L },
                    { 175L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 175L },
                    { 176L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 176L },
                    { 177L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 177L },
                    { 178L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 178L },
                    { 179L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 179L },
                    { 180L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 180L },
                    { 181L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 181L },
                    { 182L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 182L },
                    { 183L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 183L },
                    { 184L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 184L },
                    { 185L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 185L },
                    { 186L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 186L },
                    { 187L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 187L },
                    { 188L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 188L },
                    { 189L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 189L },
                    { 190L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 190L },
                    { 191L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 191L },
                    { 192L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 192L },
                    { 193L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 193L },
                    { 194L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 194L },
                    { 195L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 195L },
                    { 196L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 196L },
                    { 197L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 197L },
                    { 198L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 198L },
                    { 199L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 199L },
                    { 200L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 200L },
                    { 201L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 201L },
                    { 202L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 202L },
                    { 203L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 203L },
                    { 204L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 204L },
                    { 205L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 205L },
                    { 206L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 206L },
                    { 207L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 207L },
                    { 208L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 208L },
                    { 209L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 209L },
                    { 210L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 210L },
                    { 211L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 211L },
                    { 212L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 212L },
                    { 213L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 213L },
                    { 214L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 214L },
                    { 215L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 215L },
                    { 216L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 216L },
                    { 217L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 217L },
                    { 218L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 218L },
                    { 219L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 219L },
                    { 220L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 220L },
                    { 221L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 221L },
                    { 222L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 222L },
                    { 223L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 223L },
                    { 224L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 224L },
                    { 225L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 225L },
                    { 226L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 226L },
                    { 227L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 227L },
                    { 228L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 228L },
                    { 229L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 229L },
                    { 230L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 230L },
                    { 231L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 231L },
                    { 232L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 232L },
                    { 233L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 233L },
                    { 234L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 234L },
                    { 235L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 235L },
                    { 236L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 236L },
                    { 237L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 237L },
                    { 238L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 238L },
                    { 239L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 239L },
                    { 240L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 240L },
                    { 241L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 241L },
                    { 242L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 242L },
                    { 243L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 243L },
                    { 244L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 244L },
                    { 245L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 245L },
                    { 246L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 246L },
                    { 247L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 247L },
                    { 248L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 248L },
                    { 249L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 249L },
                    { 250L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 250L },
                    { 251L, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VND", false, null, 251L }
                });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "AI_Summary", "CandidateId", "CreatedAt", "ExperienceMatch", "IsDeleted", "JobId", "MatchScore", "Notes", "SkillMatch", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, null, 174L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 59L, 25.3339054180933m, null, 0m, 0, null },
                    { 2L, null, 138L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 183L, 57.1669875910352m, null, 0m, 0, null },
                    { 3L, null, 235L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 33L, 40.50249836431m, null, 0m, 0, null },
                    { 4L, null, 54L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 158L, 23.4427994226305m, null, 0m, 0, null },
                    { 5L, null, 86L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 100L, 39.6630999351214m, null, 0m, 0, null },
                    { 6L, null, 213L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 119L, 7.1044147979023m, null, 0m, 0, null },
                    { 7L, null, 57L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 77L, 53.2194103362129m, null, 0m, 0, null },
                    { 8L, null, 145L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 84L, 23.8310252892929m, null, 0m, 0, null },
                    { 9L, null, 80L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 87L, 79.8901714290912m, null, 0m, 0, null },
                    { 10L, null, 169L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 8L, 42.567090058032m, null, 0m, 0, null },
                    { 11L, null, 72L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 14L, 97.0463871010795m, null, 0m, 0, null },
                    { 12L, null, 52L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 38L, 61.6116494692916m, null, 0m, 0, null },
                    { 13L, null, 251L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 14L, 85.1324423612712m, null, 0m, 0, null },
                    { 14L, null, 172L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 196L, 7.59129659626228m, null, 0m, 0, null },
                    { 15L, null, 230L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 174L, 62.7553955944047m, null, 0m, 0, null },
                    { 16L, null, 55L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 170L, 81.1330782627375m, null, 0m, 0, null },
                    { 17L, null, 155L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 19L, 28.7359053402841m, null, 0m, 0, null },
                    { 18L, null, 188L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 4L, 31.7991549762893m, null, 0m, 0, null },
                    { 19L, null, 226L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 10L, 14.5524115835095m, null, 0m, 0, null },
                    { 20L, null, 148L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 4L, 29.1186369625473m, null, 0m, 0, null },
                    { 21L, null, 77L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 155L, 33.2971839389285m, null, 0m, 0, null },
                    { 22L, null, 196L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 196L, 90.7825565388345m, null, 0m, 0, null },
                    { 23L, null, 113L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 53L, 17.4264014314052m, null, 0m, 0, null },
                    { 24L, null, 156L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 157L, 81.0413803351304m, null, 0m, 0, null },
                    { 25L, null, 133L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 44L, 42.7567478002779m, null, 0m, 0, null },
                    { 26L, null, 162L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 92L, 57.4862344458169m, null, 0m, 0, null },
                    { 27L, null, 169L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 123L, 12.3338426986401m, null, 0m, 0, null },
                    { 28L, null, 240L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 198L, 6.57942290724228m, null, 0m, 0, null },
                    { 29L, null, 61L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 28L, 41.9554982529746m, null, 0m, 0, null },
                    { 30L, null, 79L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 131L, 12.6686895325168m, null, 0m, 0, null },
                    { 31L, null, 62L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 95L, 51.8435068669932m, null, 0m, 0, null },
                    { 32L, null, 92L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 113L, 47.5427873654025m, null, 0m, 0, null },
                    { 33L, null, 229L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 149L, 17.2488269942109m, null, 0m, 0, null },
                    { 34L, null, 168L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 144L, 70.879245908409m, null, 0m, 0, null },
                    { 35L, null, 114L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 128L, 99.8851153067709m, null, 0m, 0, null },
                    { 36L, null, 211L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 96L, 27.6333158033124m, null, 0m, 0, null },
                    { 37L, null, 170L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 179L, 32.1096722651784m, null, 0m, 0, null },
                    { 38L, null, 132L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 115L, 89.4415915428854m, null, 0m, 0, null },
                    { 39L, null, 209L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 34L, 18.1222640993643m, null, 0m, 0, null },
                    { 40L, null, 220L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 54L, 67.2277018275241m, null, 0m, 0, null },
                    { 41L, null, 174L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 98L, 17.1935720914945m, null, 0m, 0, null },
                    { 42L, null, 113L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 10L, 46.6675642163807m, null, 0m, 0, null },
                    { 43L, null, 183L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 59L, 20.5722534193528m, null, 0m, 0, null },
                    { 44L, null, 194L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 191L, 66.4646344568881m, null, 0m, 0, null },
                    { 45L, null, 230L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 81L, 0.496704923220307m, null, 0m, 0, null },
                    { 46L, null, 122L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 83L, 63.1963681258244m, null, 0m, 0, null },
                    { 47L, null, 184L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 14L, 25.1820652397266m, null, 0m, 0, null },
                    { 48L, null, 204L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 29L, 54.5177452054423m, null, 0m, 0, null },
                    { 49L, null, 231L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 162L, 64.9992971983735m, null, 0m, 0, null },
                    { 50L, null, 130L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 125L, 41.746380152994m, null, 0m, 0, null },
                    { 51L, null, 147L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 59L, 4.67174388685811m, null, 0m, 0, null },
                    { 52L, null, 98L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 101L, 97.0180439748886m, null, 0m, 0, null },
                    { 53L, null, 169L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 108L, 0.294432975488916m, null, 0m, 0, null },
                    { 54L, null, 88L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 107L, 13.8251476519858m, null, 0m, 0, null },
                    { 55L, null, 239L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 15L, 87.9416553247448m, null, 0m, 0, null },
                    { 56L, null, 85L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 132L, 51.3244597945942m, null, 0m, 0, null },
                    { 57L, null, 202L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 178L, 43.469306660569m, null, 0m, 0, null },
                    { 58L, null, 92L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 110L, 17.9675638759358m, null, 0m, 0, null },
                    { 59L, null, 121L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 85L, 84.944355247982m, null, 0m, 0, null },
                    { 60L, null, 100L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 126L, 40.999151831958m, null, 0m, 0, null },
                    { 61L, null, 185L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 164L, 26.7291559030903m, null, 0m, 0, null },
                    { 62L, null, 183L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 158L, 23.7576494569693m, null, 0m, 0, null },
                    { 63L, null, 232L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 124L, 65.9570098696076m, null, 0m, 0, null },
                    { 64L, null, 227L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 7L, 76.1014514025773m, null, 0m, 0, null },
                    { 65L, null, 158L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 126L, 47.640008175578m, null, 0m, 0, null },
                    { 66L, null, 66L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 23L, 82.3763782076428m, null, 0m, 0, null },
                    { 67L, null, 81L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 134L, 73.1642910620031m, null, 0m, 0, null },
                    { 68L, null, 198L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 28L, 63.8988136611408m, null, 0m, 0, null },
                    { 69L, null, 200L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 197L, 27.5528981944327m, null, 0m, 0, null },
                    { 70L, null, 67L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 174L, 88.6409049335126m, null, 0m, 0, null },
                    { 71L, null, 234L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 25L, 34.7502703008942m, null, 0m, 0, null },
                    { 72L, null, 195L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 119L, 51.7006933929868m, null, 0m, 0, null },
                    { 73L, null, 108L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 175L, 28.0350095722987m, null, 0m, 0, null },
                    { 74L, null, 59L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 129L, 26.6124874011672m, null, 0m, 0, null },
                    { 75L, null, 222L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 171L, 87.5612745003594m, null, 0m, 0, null },
                    { 76L, null, 236L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 135L, 66.5466969211338m, null, 0m, 0, null },
                    { 77L, null, 113L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 141L, 27.243755770495m, null, 0m, 0, null },
                    { 78L, null, 244L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 6L, 9.28471517250161m, null, 0m, 0, null },
                    { 79L, null, 187L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 136L, 93.338929439587m, null, 0m, 0, null },
                    { 80L, null, 213L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 126L, 91.298809876339m, null, 0m, 0, null },
                    { 81L, null, 202L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 193L, 82.24079370603m, null, 0m, 0, null },
                    { 82L, null, 234L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 155L, 96.7590760424543m, null, 0m, 0, null },
                    { 83L, null, 59L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 83L, 81.9274724376981m, null, 0m, 0, null },
                    { 84L, null, 100L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 192L, 79.0259309481019m, null, 0m, 0, null },
                    { 85L, null, 56L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 109L, 11.061832220788m, null, 0m, 0, null },
                    { 86L, null, 108L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 94L, 87.9908030331092m, null, 0m, 0, null },
                    { 87L, null, 113L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 153L, 82.470666469294m, null, 0m, 0, null },
                    { 88L, null, 84L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 123L, 77.2867695788326m, null, 0m, 0, null },
                    { 89L, null, 71L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 123L, 94.9101099255076m, null, 0m, 0, null },
                    { 90L, null, 234L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 51L, 3.55585445815504m, null, 0m, 0, null },
                    { 91L, null, 100L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 117L, 47.686389343667m, null, 0m, 0, null },
                    { 92L, null, 187L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 74L, 28.7634366791525m, null, 0m, 0, null },
                    { 93L, null, 68L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 89L, 94.0612534499081m, null, 0m, 0, null },
                    { 94L, null, 104L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 182L, 88.4173068163997m, null, 0m, 0, null },
                    { 95L, null, 200L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 170L, 6.42779316121144m, null, 0m, 0, null },
                    { 96L, null, 148L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 97L, 93.7076529924328m, null, 0m, 0, null },
                    { 97L, null, 94L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 197L, 39.6860421354352m, null, 0m, 0, null },
                    { 98L, null, 224L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 11L, 49.6395815395003m, null, 0m, 0, null },
                    { 99L, null, 122L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 18L, 58.7120862485432m, null, 0m, 0, null },
                    { 100L, null, 83L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 10L, 81.899260534858m, null, 0m, 0, null },
                    { 101L, null, 83L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 4L, 12.1462336332287m, null, 0m, 0, null },
                    { 102L, null, 127L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 157L, 99.9952763318994m, null, 0m, 0, null },
                    { 103L, null, 87L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 63L, 34.412829407683m, null, 0m, 0, null },
                    { 104L, null, 56L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 165L, 20.2560424899012m, null, 0m, 0, null },
                    { 105L, null, 223L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 188L, 4.89254407812494m, null, 0m, 0, null },
                    { 106L, null, 204L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 189L, 41.988383392798m, null, 0m, 0, null },
                    { 107L, null, 78L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 142L, 61.279103281572m, null, 0m, 0, null },
                    { 108L, null, 106L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 3L, 70.177363264457m, null, 0m, 0, null },
                    { 109L, null, 158L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 128L, 37.7728464257777m, null, 0m, 0, null },
                    { 110L, null, 107L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 197L, 32.7807046160012m, null, 0m, 0, null },
                    { 111L, null, 130L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 141L, 92.1323892158141m, null, 0m, 0, null },
                    { 112L, null, 229L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 25L, 10.1310481830179m, null, 0m, 0, null },
                    { 113L, null, 64L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 153L, 36.8106900885751m, null, 0m, 0, null },
                    { 114L, null, 85L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 13L, 30.621439465611m, null, 0m, 0, null },
                    { 115L, null, 83L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 119L, 19.1029471434201m, null, 0m, 0, null },
                    { 116L, null, 74L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 39L, 0.957462378292094m, null, 0m, 0, null },
                    { 117L, null, 81L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 90L, 58.8115731993744m, null, 0m, 0, null },
                    { 118L, null, 120L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 34L, 2.739631432453m, null, 0m, 0, null },
                    { 119L, null, 53L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 42L, 88.6429537966116m, null, 0m, 0, null },
                    { 120L, null, 81L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 84L, 84.5639132822696m, null, 0m, 0, null },
                    { 121L, null, 118L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 125L, 89.6971126504695m, null, 0m, 0, null },
                    { 122L, null, 76L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 4L, 62.7624403977592m, null, 0m, 0, null },
                    { 123L, null, 215L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 57L, 96.5821083619176m, null, 0m, 0, null },
                    { 124L, null, 87L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 190L, 70.1393702859708m, null, 0m, 0, null },
                    { 125L, null, 180L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 11L, 96.3010411226661m, null, 0m, 0, null },
                    { 126L, null, 135L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 62L, 11.3181847666009m, null, 0m, 0, null },
                    { 127L, null, 140L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 103L, 41.5950607236452m, null, 0m, 0, null },
                    { 128L, null, 158L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 74L, 13.133272534764m, null, 0m, 0, null },
                    { 129L, null, 158L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 148L, 5.32262185836333m, null, 0m, 0, null },
                    { 130L, null, 235L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 179L, 88.3067231570867m, null, 0m, 0, null },
                    { 131L, null, 120L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 43L, 91.7458008470693m, null, 0m, 0, null },
                    { 132L, null, 140L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 105L, 83.5855494176902m, null, 0m, 0, null },
                    { 133L, null, 167L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 82L, 3.67744229905188m, null, 0m, 0, null },
                    { 134L, null, 234L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 113L, 29.6510201551258m, null, 0m, 0, null },
                    { 135L, null, 151L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 9L, 96.9924972844275m, null, 0m, 0, null },
                    { 136L, null, 75L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 178L, 69.6685881212673m, null, 0m, 0, null },
                    { 137L, null, 231L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 13L, 58.7388758355467m, null, 0m, 0, null },
                    { 138L, null, 233L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 155L, 70.0619929796373m, null, 0m, 0, null },
                    { 139L, null, 102L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 86L, 79.9929634574768m, null, 0m, 0, null },
                    { 140L, null, 107L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 154L, 58.919397536162m, null, 0m, 0, null },
                    { 141L, null, 129L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 115L, 90.2257210063868m, null, 0m, 0, null },
                    { 142L, null, 198L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 17L, 83.4800836553239m, null, 0m, 0, null },
                    { 143L, null, 157L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 157L, 20.2163726651186m, null, 0m, 0, null },
                    { 144L, null, 231L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 26L, 84.2449345552572m, null, 0m, 0, null },
                    { 145L, null, 241L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 16L, 53.133466305739m, null, 0m, 0, null },
                    { 146L, null, 116L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 24L, 3.31422877652302m, null, 0m, 0, null },
                    { 147L, null, 222L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 33L, 41.7816380233418m, null, 0m, 0, null },
                    { 148L, null, 217L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 72L, 1.5793422244393m, null, 0m, 0, null },
                    { 149L, null, 140L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 60L, 43.4077485666646m, null, 0m, 0, null },
                    { 150L, null, 70L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 44L, 18.8030410645544m, null, 0m, 0, null },
                    { 151L, null, 180L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 8L, 29.9997054180129m, null, 0m, 0, null },
                    { 152L, null, 249L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 90L, 52.575450880721m, null, 0m, 0, null },
                    { 153L, null, 244L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 79L, 76.7121400575676m, null, 0m, 0, null },
                    { 154L, null, 72L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 28L, 58.615093053605m, null, 0m, 0, null },
                    { 155L, null, 239L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 99L, 0.229156436505335m, null, 0m, 0, null },
                    { 156L, null, 191L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 149L, 96.1605448723587m, null, 0m, 0, null },
                    { 157L, null, 114L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 34L, 92.967015827525m, null, 0m, 0, null },
                    { 158L, null, 172L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 154L, 42.3660648718318m, null, 0m, 0, null },
                    { 159L, null, 95L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 35L, 55.7767280171517m, null, 0m, 0, null },
                    { 160L, null, 209L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 178L, 29.1100761523052m, null, 0m, 0, null },
                    { 161L, null, 165L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 81L, 43.6529922502362m, null, 0m, 0, null },
                    { 162L, null, 70L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 3L, 25.3728503013835m, null, 0m, 0, null },
                    { 163L, null, 177L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 109L, 95.833221169111m, null, 0m, 0, null },
                    { 164L, null, 197L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 2L, 36.3400612195675m, null, 0m, 0, null },
                    { 165L, null, 57L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 54L, 75.0182950287211m, null, 0m, 0, null },
                    { 166L, null, 224L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 167L, 89.2310688687633m, null, 0m, 0, null },
                    { 167L, null, 162L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 3L, 74.479298793934m, null, 0m, 0, null },
                    { 168L, null, 61L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 95L, 78.2531122575761m, null, 0m, 0, null },
                    { 169L, null, 105L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 52L, 3.93742183406717m, null, 0m, 0, null },
                    { 170L, null, 107L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 176L, 77.1149034039652m, null, 0m, 0, null },
                    { 171L, null, 153L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 194L, 17.3924309282528m, null, 0m, 0, null },
                    { 172L, null, 198L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 96L, 53.5688719030325m, null, 0m, 0, null },
                    { 173L, null, 148L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 30L, 84.6001928600484m, null, 0m, 0, null },
                    { 174L, null, 92L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 150L, 6.80132885780247m, null, 0m, 0, null },
                    { 175L, null, 84L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 1L, 58.5060705703246m, null, 0m, 0, null },
                    { 176L, null, 152L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 114L, 57.794703244136m, null, 0m, 0, null },
                    { 177L, null, 119L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 135L, 35.5839665213525m, null, 0m, 0, null },
                    { 178L, null, 226L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 134L, 23.6336318420403m, null, 0m, 0, null },
                    { 179L, null, 237L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 110L, 51.954480377936m, null, 0m, 0, null },
                    { 180L, null, 203L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 131L, 82.209054465503m, null, 0m, 0, null },
                    { 181L, null, 185L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 43L, 35.2624124545895m, null, 0m, 0, null },
                    { 182L, null, 59L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 38L, 21.7398210529889m, null, 0m, 0, null },
                    { 183L, null, 210L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 38L, 29.1882830807885m, null, 0m, 0, null },
                    { 184L, null, 188L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 43L, 38.1629344253628m, null, 0m, 0, null },
                    { 185L, null, 104L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 10L, 34.8251938982053m, null, 0m, 0, null },
                    { 186L, null, 145L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 136L, 88.3847699446533m, null, 0m, 0, null },
                    { 187L, null, 190L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 40L, 76.8372053172613m, null, 0m, 0, null },
                    { 188L, null, 92L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 93L, 93.6490707069864m, null, 0m, 0, null },
                    { 189L, null, 112L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 84L, 63.482727372778m, null, 0m, 0, null },
                    { 190L, null, 237L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 188L, 80.6149471460911m, null, 0m, 0, null },
                    { 191L, null, 151L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 4L, 72.4615774920497m, null, 0m, 0, null },
                    { 192L, null, 158L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 5L, 53.637123551982m, null, 0m, 0, null },
                    { 193L, null, 215L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 144L, 12.6112186874315m, null, 0m, 0, null },
                    { 194L, null, 127L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 74L, 71.0766211483053m, null, 0m, 0, null },
                    { 195L, null, 143L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 58L, 65.7667703767152m, null, 0m, 0, null },
                    { 196L, null, 175L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 195L, 60.8023133412014m, null, 0m, 0, null },
                    { 197L, null, 225L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 178L, 45.9052514032951m, null, 0m, 0, null },
                    { 198L, null, 143L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 128L, 6.36823573446285m, null, 0m, 0, null },
                    { 199L, null, 202L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 11L, 46.3257178879928m, null, 0m, 0, null },
                    { 200L, null, 206L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 84L, 73.5062288462679m, null, 0m, 0, null },
                    { 201L, null, 102L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 117L, 86.0287382668018m, null, 0m, 0, null },
                    { 202L, null, 91L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 98L, 18.6422233556594m, null, 0m, 0, null },
                    { 203L, null, 56L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 132L, 73.0730019850065m, null, 0m, 0, null },
                    { 204L, null, 244L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 163L, 65.3108740529562m, null, 0m, 0, null },
                    { 205L, null, 217L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 152L, 31.5297463124291m, null, 0m, 0, null },
                    { 206L, null, 87L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 12L, 74.3875239856483m, null, 0m, 0, null },
                    { 207L, null, 140L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 56L, 68.3382805755074m, null, 0m, 0, null },
                    { 208L, null, 61L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 6L, 6.01847912465151m, null, 0m, 0, null },
                    { 209L, null, 128L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 70L, 3.90938250530017m, null, 0m, 0, null },
                    { 210L, null, 246L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 133L, 78.1281677904204m, null, 0m, 0, null },
                    { 211L, null, 111L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 15L, 4.42162505556905m, null, 0m, 0, null },
                    { 212L, null, 209L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 79L, 12.4904931115408m, null, 0m, 0, null },
                    { 213L, null, 212L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 171L, 26.0633151168298m, null, 0m, 0, null },
                    { 214L, null, 115L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 95L, 59.6750455255038m, null, 0m, 0, null },
                    { 215L, null, 67L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 176L, 90.8137538893212m, null, 0m, 0, null },
                    { 216L, null, 227L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 162L, 62.6720461354926m, null, 0m, 0, null },
                    { 217L, null, 251L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 150L, 57.7564114508016m, null, 0m, 0, null },
                    { 218L, null, 79L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 144L, 33.0774760959099m, null, 0m, 0, null },
                    { 219L, null, 163L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 11L, 20.2384700627245m, null, 0m, 0, null },
                    { 220L, null, 79L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 161L, 81.7903505087785m, null, 0m, 0, null },
                    { 221L, null, 251L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 30L, 5.22044836786597m, null, 0m, 0, null },
                    { 222L, null, 199L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 190L, 66.2134788773086m, null, 0m, 0, null },
                    { 223L, null, 125L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 122L, 4.47163633279113m, null, 0m, 0, null },
                    { 224L, null, 93L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 39L, 37.5032141979333m, null, 0m, 0, null },
                    { 225L, null, 213L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 97L, 12.3902296239465m, null, 0m, 0, null },
                    { 226L, null, 81L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 18L, 97.3299935447657m, null, 0m, 0, null },
                    { 227L, null, 160L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 31L, 50.2485219157527m, null, 0m, 0, null },
                    { 228L, null, 234L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 83L, 97.4080242670178m, null, 0m, 0, null },
                    { 229L, null, 122L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 41L, 16.194533238278m, null, 0m, 0, null },
                    { 230L, null, 119L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 143L, 22.9324761884904m, null, 0m, 0, null },
                    { 231L, null, 62L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 185L, 66.169444036749m, null, 0m, 0, null },
                    { 232L, null, 116L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 89L, 32.1116599869503m, null, 0m, 0, null },
                    { 233L, null, 237L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 109L, 33.7437029153778m, null, 0m, 0, null },
                    { 234L, null, 91L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 50L, 51.1275977600029m, null, 0m, 0, null },
                    { 235L, null, 163L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 117L, 78.8985636918333m, null, 0m, 0, null },
                    { 236L, null, 99L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 41L, 32.9732881081166m, null, 0m, 0, null },
                    { 237L, null, 245L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 42L, 40.6255769732527m, null, 0m, 0, null },
                    { 238L, null, 181L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 46L, 59.7483217994442m, null, 0m, 0, null },
                    { 239L, null, 198L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 64L, 8.35316284017319m, null, 0m, 0, null },
                    { 240L, null, 201L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 16L, 38.5034529205893m, null, 0m, 0, null },
                    { 241L, null, 231L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 101L, 2.73151984565496m, null, 0m, 0, null },
                    { 242L, null, 105L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 164L, 15.6750775480993m, null, 0m, 0, null },
                    { 243L, null, 60L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 143L, 48.3660471385187m, null, 0m, 0, null },
                    { 244L, null, 160L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 161L, 22.1666255137728m, null, 0m, 0, null },
                    { 245L, null, 233L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 128L, 34.4101900395053m, null, 0m, 0, null },
                    { 246L, null, 218L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 199L, 35.4556161144076m, null, 0m, 0, null },
                    { 247L, null, 218L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 24L, 50.6569024876956m, null, 0m, 0, null },
                    { 248L, null, 216L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 75L, 69.3435465308575m, null, 0m, 0, null },
                    { 249L, null, 64L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 81L, 12.7311360150255m, null, 0m, 0, null },
                    { 250L, null, 99L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 118L, 46.6421730567898m, null, 0m, 0, null },
                    { 251L, null, 242L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 37L, 74.5813293729822m, null, 0m, 0, null },
                    { 252L, null, 148L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 61L, 76.6612496584008m, null, 0m, 0, null },
                    { 253L, null, 178L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 59L, 48.9194270916839m, null, 0m, 0, null },
                    { 254L, null, 221L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 40L, 40.4086768349673m, null, 0m, 0, null },
                    { 255L, null, 88L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 85L, 59.3221858885708m, null, 0m, 0, null },
                    { 256L, null, 102L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 149L, 32.420904437276m, null, 0m, 0, null },
                    { 257L, null, 197L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 181L, 89.3029635256636m, null, 0m, 0, null },
                    { 258L, null, 105L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 149L, 66.7977005088691m, null, 0m, 0, null },
                    { 259L, null, 182L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 78L, 99.2322609290631m, null, 0m, 0, null },
                    { 260L, null, 202L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 115L, 64.9126479238796m, null, 0m, 0, null },
                    { 261L, null, 230L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 183L, 56.5200724902191m, null, 0m, 0, null },
                    { 262L, null, 59L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 16L, 68.3460406345995m, null, 0m, 0, null },
                    { 263L, null, 60L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 33L, 50.7248462414019m, null, 0m, 0, null },
                    { 264L, null, 64L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 13L, 55.2859744314505m, null, 0m, 0, null },
                    { 265L, null, 236L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 103L, 98.6140041605635m, null, 0m, 0, null },
                    { 266L, null, 242L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 21L, 63.8479477557577m, null, 0m, 0, null },
                    { 267L, null, 184L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 21L, 81.0829904773659m, null, 0m, 0, null },
                    { 268L, null, 188L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 161L, 50.8609504210115m, null, 0m, 0, null },
                    { 269L, null, 139L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 115L, 68.4960238023177m, null, 0m, 0, null },
                    { 270L, null, 234L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 16L, 83.0968864183393m, null, 0m, 0, null },
                    { 271L, null, 195L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 155L, 87.780498428168m, null, 0m, 0, null },
                    { 272L, null, 108L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 169L, 95.1373955212242m, null, 0m, 0, null },
                    { 273L, null, 121L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 168L, 14.5037252523488m, null, 0m, 0, null },
                    { 274L, null, 168L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 182L, 21.0879700356573m, null, 0m, 0, null },
                    { 275L, null, 220L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 164L, 66.4539366804314m, null, 0m, 0, null },
                    { 276L, null, 98L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 69L, 34.5477402371111m, null, 0m, 0, null },
                    { 277L, null, 109L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 137L, 70.1629384747534m, null, 0m, 0, null },
                    { 278L, null, 146L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 71L, 9.4119815665353m, null, 0m, 0, null },
                    { 279L, null, 74L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 168L, 21.0322216716745m, null, 0m, 0, null },
                    { 280L, null, 152L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 12L, 60.1983456687063m, null, 0m, 0, null },
                    { 281L, null, 68L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 200L, 12.9783309590902m, null, 0m, 0, null },
                    { 282L, null, 109L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 136L, 34.8752875974752m, null, 0m, 0, null },
                    { 283L, null, 186L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 136L, 63.9538534283423m, null, 0m, 0, null },
                    { 284L, null, 104L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 7L, 60.4066425284402m, null, 0m, 0, null },
                    { 285L, null, 90L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 99L, 7.85304331586372m, null, 0m, 0, null },
                    { 286L, null, 249L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 120L, 84.3547227719588m, null, 0m, 0, null },
                    { 287L, null, 98L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 169L, 20.5014937652748m, null, 0m, 0, null },
                    { 288L, null, 131L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 68L, 62.6318588678874m, null, 0m, 0, null },
                    { 289L, null, 136L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 26L, 24.145999468931m, null, 0m, 0, null },
                    { 290L, null, 52L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 157L, 17.2327558590252m, null, 0m, 0, null },
                    { 291L, null, 208L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 149L, 84.5023551883652m, null, 0m, 0, null },
                    { 292L, null, 234L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 109L, 49.9384708469447m, null, 0m, 0, null },
                    { 293L, null, 80L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 17L, 55.1362128253729m, null, 0m, 0, null },
                    { 294L, null, 185L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 64L, 56.0630339458878m, null, 0m, 0, null },
                    { 295L, null, 181L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 142L, 2.28035058932395m, null, 0m, 0, null },
                    { 296L, null, 224L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 20L, 28.3771075906125m, null, 0m, 0, null },
                    { 297L, null, 99L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 4L, 12.3957032861168m, null, 0m, 0, null },
                    { 298L, null, 94L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 74L, 26.9050348675368m, null, 0m, 0, null },
                    { 299L, null, 183L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 80L, 68.6395594704149m, null, 0m, 0, null },
                    { 300L, null, 161L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, false, 101L, 86.9020126233352m, null, 0m, 0, null }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "CreatedAt", "Description", "IsDeleted", "OrderCode", "ReferenceId", "Status", "Type", "UpdatedAt", "UserId", "WalletId" },
                values: new object[,]
                {
                    { 1L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 3L, 3L },
                    { 2L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 4L, 4L },
                    { 3L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 5L, 5L },
                    { 4L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 6L, 6L },
                    { 5L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 7L, 7L },
                    { 6L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 8L, 8L },
                    { 7L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 9L, 9L },
                    { 8L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 10L, 10L },
                    { 9L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 11L, 11L },
                    { 10L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 12L, 12L },
                    { 11L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 13L, 13L },
                    { 12L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 14L, 14L },
                    { 13L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 15L, 15L },
                    { 14L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 16L, 16L },
                    { 15L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 17L, 17L },
                    { 16L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 18L, 18L },
                    { 17L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 19L, 19L },
                    { 18L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 20L, 20L },
                    { 19L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 21L, 21L },
                    { 20L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 22L, 22L },
                    { 21L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 23L, 23L },
                    { 22L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 24L, 24L },
                    { 23L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 25L, 25L },
                    { 24L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 26L, 26L },
                    { 25L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 27L, 27L },
                    { 26L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 28L, 28L },
                    { 27L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 29L, 29L },
                    { 28L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 30L, 30L },
                    { 29L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 31L, 31L },
                    { 30L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 32L, 32L },
                    { 31L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 33L, 33L },
                    { 32L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 34L, 34L },
                    { 33L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 35L, 35L },
                    { 34L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 36L, 36L },
                    { 35L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 37L, 37L },
                    { 36L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 38L, 38L },
                    { 37L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 39L, 39L },
                    { 38L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 40L, 40L },
                    { 39L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 41L, 41L },
                    { 40L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 42L, 42L },
                    { 41L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 43L, 43L },
                    { 42L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 44L, 44L },
                    { 43L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 45L, 45L },
                    { 44L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 46L, 46L },
                    { 45L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 47L, 47L },
                    { 46L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 48L, 48L },
                    { 47L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 49L, 49L },
                    { 48L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 50L, 50L },
                    { 49L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 51L, 51L },
                    { 50L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 2L, 2L },
                    { 51L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 3L, 3L },
                    { 52L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 4L, 4L },
                    { 53L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 5L, 5L },
                    { 54L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 6L, 6L },
                    { 55L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 7L, 7L },
                    { 56L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 8L, 8L },
                    { 57L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 9L, 9L },
                    { 58L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 10L, 10L },
                    { 59L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 11L, 11L },
                    { 60L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 12L, 12L },
                    { 61L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 13L, 13L },
                    { 62L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 14L, 14L },
                    { 63L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 15L, 15L },
                    { 64L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 16L, 16L },
                    { 65L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 17L, 17L },
                    { 66L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 18L, 18L },
                    { 67L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 19L, 19L },
                    { 68L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 20L, 20L },
                    { 69L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 21L, 21L },
                    { 70L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 22L, 22L },
                    { 71L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 23L, 23L },
                    { 72L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 24L, 24L },
                    { 73L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 25L, 25L },
                    { 74L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 26L, 26L },
                    { 75L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 27L, 27L },
                    { 76L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 28L, 28L },
                    { 77L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 29L, 29L },
                    { 78L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 30L, 30L },
                    { 79L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 31L, 31L },
                    { 80L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 32L, 32L },
                    { 81L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 33L, 33L },
                    { 82L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 34L, 34L },
                    { 83L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 35L, 35L },
                    { 84L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 36L, 36L },
                    { 85L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 37L, 37L },
                    { 86L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 38L, 38L },
                    { 87L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 39L, 39L },
                    { 88L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 40L, 40L },
                    { 89L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 41L, 41L },
                    { 90L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 42L, 42L },
                    { 91L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 43L, 43L },
                    { 92L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 44L, 44L },
                    { 93L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 45L, 45L },
                    { 94L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 46L, 46L },
                    { 95L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 47L, 47L },
                    { 96L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 48L, 48L },
                    { 97L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 49L, 49L },
                    { 98L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 50L, 50L },
                    { 99L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 51L, 51L },
                    { 100L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 2L, 2L },
                    { 101L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 3L, 3L },
                    { 102L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 4L, 4L },
                    { 103L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 5L, 5L },
                    { 104L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 6L, 6L },
                    { 105L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 7L, 7L },
                    { 106L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 8L, 8L },
                    { 107L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 9L, 9L },
                    { 108L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 10L, 10L },
                    { 109L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 11L, 11L },
                    { 110L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 12L, 12L },
                    { 111L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 13L, 13L },
                    { 112L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 14L, 14L },
                    { 113L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 15L, 15L },
                    { 114L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 16L, 16L },
                    { 115L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 17L, 17L },
                    { 116L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 18L, 18L },
                    { 117L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 19L, 19L },
                    { 118L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 20L, 20L },
                    { 119L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 21L, 21L },
                    { 120L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 22L, 22L },
                    { 121L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 23L, 23L },
                    { 122L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 24L, 24L },
                    { 123L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 25L, 25L },
                    { 124L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 26L, 26L },
                    { 125L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 27L, 27L },
                    { 126L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 28L, 28L },
                    { 127L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 29L, 29L },
                    { 128L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 30L, 30L },
                    { 129L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 31L, 31L },
                    { 130L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 32L, 32L },
                    { 131L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 33L, 33L },
                    { 132L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 34L, 34L },
                    { 133L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 35L, 35L },
                    { 134L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 36L, 36L },
                    { 135L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 37L, 37L },
                    { 136L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 38L, 38L },
                    { 137L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 39L, 39L },
                    { 138L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 40L, 40L },
                    { 139L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 41L, 41L },
                    { 140L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 42L, 42L },
                    { 141L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 43L, 43L },
                    { 142L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 44L, 44L },
                    { 143L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 45L, 45L },
                    { 144L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 46L, 46L },
                    { 145L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 47L, 47L },
                    { 146L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 48L, 48L },
                    { 147L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 49L, 49L },
                    { 148L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 50L, 50L },
                    { 149L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 51L, 51L },
                    { 150L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 2L, 2L },
                    { 151L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 3L, 3L },
                    { 152L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 4L, 4L },
                    { 153L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 5L, 5L },
                    { 154L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 6L, 6L },
                    { 155L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 7L, 7L },
                    { 156L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 8L, 8L },
                    { 157L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 9L, 9L },
                    { 158L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 10L, 10L },
                    { 159L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 11L, 11L },
                    { 160L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 12L, 12L },
                    { 161L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 13L, 13L },
                    { 162L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 14L, 14L },
                    { 163L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 15L, 15L },
                    { 164L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 16L, 16L },
                    { 165L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 17L, 17L },
                    { 166L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 18L, 18L },
                    { 167L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 19L, 19L },
                    { 168L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 20L, 20L },
                    { 169L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 21L, 21L },
                    { 170L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 22L, 22L },
                    { 171L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 23L, 23L },
                    { 172L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 24L, 24L },
                    { 173L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 25L, 25L },
                    { 174L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 26L, 26L },
                    { 175L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 27L, 27L },
                    { 176L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 28L, 28L },
                    { 177L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 29L, 29L },
                    { 178L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 30L, 30L },
                    { 179L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 31L, 31L },
                    { 180L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 32L, 32L },
                    { 181L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 33L, 33L },
                    { 182L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 34L, 34L },
                    { 183L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 35L, 35L },
                    { 184L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 36L, 36L },
                    { 185L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 37L, 37L },
                    { 186L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 38L, 38L },
                    { 187L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 39L, 39L },
                    { 188L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 40L, 40L },
                    { 189L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 41L, 41L },
                    { 190L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 42L, 42L },
                    { 191L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 43L, 43L },
                    { 192L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 44L, 44L },
                    { 193L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 45L, 45L },
                    { 194L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 46L, 46L },
                    { 195L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 47L, 47L },
                    { 196L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 48L, 48L },
                    { 197L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 49L, 49L },
                    { 198L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 50L, 50L },
                    { 199L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 51L, 51L },
                    { 200L, -20000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, null, null, 1, 2, null, 2L, 2L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AILogs",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "AILogs",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "AILogs",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "AILogs",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "AILogs",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "AILogs",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "AILogs",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "AILogs",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "AILogs",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "AILogs",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "AILogs",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "AILogs",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "AILogs",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "AILogs",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "AILogs",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "AILogs",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "AILogs",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "AILogs",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "AILogs",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "AILogs",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 35L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 36L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 37L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 38L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 39L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 41L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 42L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 43L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 44L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 45L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 46L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 47L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 48L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 49L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 50L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 51L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 52L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 53L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 54L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 55L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 56L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 57L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 58L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 59L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 60L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 61L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 62L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 63L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 64L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 65L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 66L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 67L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 68L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 69L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 70L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 71L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 72L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 73L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 74L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 75L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 76L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 77L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 78L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 79L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 80L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 81L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 82L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 83L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 84L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 85L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 86L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 87L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 88L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 89L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 90L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 91L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 92L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 93L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 94L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 95L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 96L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 97L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 98L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 99L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 100L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 101L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 102L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 103L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 104L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 105L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 106L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 107L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 108L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 109L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 110L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 111L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 112L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 113L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 114L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 115L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 116L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 117L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 118L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 119L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 120L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 121L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 122L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 123L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 124L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 125L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 126L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 127L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 128L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 129L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 130L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 131L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 132L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 133L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 134L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 135L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 136L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 137L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 138L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 139L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 140L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 141L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 142L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 143L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 144L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 145L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 146L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 147L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 148L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 149L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 150L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 151L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 152L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 153L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 154L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 155L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 156L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 157L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 158L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 159L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 160L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 161L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 162L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 163L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 164L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 165L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 166L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 167L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 168L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 169L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 170L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 171L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 172L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 173L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 174L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 175L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 176L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 177L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 178L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 179L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 180L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 181L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 182L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 183L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 184L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 185L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 186L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 187L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 188L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 189L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 190L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 191L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 192L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 193L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 194L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 195L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 196L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 197L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 198L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 199L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 200L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 201L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 202L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 203L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 204L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 205L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 206L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 207L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 208L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 209L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 210L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 211L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 212L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 213L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 214L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 215L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 216L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 217L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 218L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 219L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 220L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 221L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 222L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 223L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 224L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 225L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 226L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 227L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 228L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 229L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 230L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 231L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 232L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 233L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 234L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 235L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 236L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 237L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 238L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 239L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 240L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 241L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 242L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 243L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 244L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 245L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 246L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 247L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 248L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 249L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 250L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 251L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 252L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 253L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 254L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 255L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 256L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 257L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 258L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 259L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 260L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 261L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 262L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 263L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 264L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 265L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 266L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 267L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 268L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 269L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 270L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 271L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 272L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 273L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 274L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 275L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 276L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 277L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 278L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 279L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 280L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 281L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 282L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 283L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 284L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 285L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 286L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 287L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 288L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 289L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 290L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 291L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 292L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 293L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 294L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 295L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 296L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 297L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 298L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 299L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 300L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 35L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 36L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 37L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 38L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 39L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 41L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 42L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 43L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 44L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 45L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 46L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 47L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 48L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 49L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 50L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 51L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 52L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 53L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 54L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 55L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 56L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 57L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 58L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 59L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 60L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 61L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 62L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 63L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 64L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 65L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 66L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 67L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 68L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 69L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 70L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 71L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 72L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 73L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 74L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 75L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 76L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 77L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 78L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 79L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 80L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 81L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 82L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 83L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 84L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 85L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 86L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 87L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 88L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 89L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 90L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 91L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 92L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 93L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 94L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 95L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 96L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 97L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 98L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 99L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 100L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 101L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 102L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 103L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 104L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 105L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 106L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 107L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 108L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 109L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 110L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 111L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 112L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 113L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 114L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 115L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 116L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 117L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 118L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 119L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 120L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 121L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 122L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 123L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 124L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 125L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 126L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 127L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 128L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 129L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 130L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 131L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 132L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 133L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 134L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 135L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 136L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 137L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 138L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 139L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 140L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 141L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 142L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 143L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 144L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 145L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 146L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 147L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 148L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 149L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 150L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 151L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 152L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 153L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 154L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 155L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 156L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 157L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 158L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 159L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 160L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 161L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 162L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 163L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 164L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 165L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 166L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 167L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 168L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 169L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 170L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 171L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 172L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 173L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 174L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 175L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 176L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 177L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 178L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 179L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 180L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 181L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 182L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 183L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 184L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 185L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 186L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 187L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 188L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 189L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 190L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 191L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 192L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 193L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 194L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 195L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 196L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 197L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 198L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 199L);

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "Id",
                keyValue: 200L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 36L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 45L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 47L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 48L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 49L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 55L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 65L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 66L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 67L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 73L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 76L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 88L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 91L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 102L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 104L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 106L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 111L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 112L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 116L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 121L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 127L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 130L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 138L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 139L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 140L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 145L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 146L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 147L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 151L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 156L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 159L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 160L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 166L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 172L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 173L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 177L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 180L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 184L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 186L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 187L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 35L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 36L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 37L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 38L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 39L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 41L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 42L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 43L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 44L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 45L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 46L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 47L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 48L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 49L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 50L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 51L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 52L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 53L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 54L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 55L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 56L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 57L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 58L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 59L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 60L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 61L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 62L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 63L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 64L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 65L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 66L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 67L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 68L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 69L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 70L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 71L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 72L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 73L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 74L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 75L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 76L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 77L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 78L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 79L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 80L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 81L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 82L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 83L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 84L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 85L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 86L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 87L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 88L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 89L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 90L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 91L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 92L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 93L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 94L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 95L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 96L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 97L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 98L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 99L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 100L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 101L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 102L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 103L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 104L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 105L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 106L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 107L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 108L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 109L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 110L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 111L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 112L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 113L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 114L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 115L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 116L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 117L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 118L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 119L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 120L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 121L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 122L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 123L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 124L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 125L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 126L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 127L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 128L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 129L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 130L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 131L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 132L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 133L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 134L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 135L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 136L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 137L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 138L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 139L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 140L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 141L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 142L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 143L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 144L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 145L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 146L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 147L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 148L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 149L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 150L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 151L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 152L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 153L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 154L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 155L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 156L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 157L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 158L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 159L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 160L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 161L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 162L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 163L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 164L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 165L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 166L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 167L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 168L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 169L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 170L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 171L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 172L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 173L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 174L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 175L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 176L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 177L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 178L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 179L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 180L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 181L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 182L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 183L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 184L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 185L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 186L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 187L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 188L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 189L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 190L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 191L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 192L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 193L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 194L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 195L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 196L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 197L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 198L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 199L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 200L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 35L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 36L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 37L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 38L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 39L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 41L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 42L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 43L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 44L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 45L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 46L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 47L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 48L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 49L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 50L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 35L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 36L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 37L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 38L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 39L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 41L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 42L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 43L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 44L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 45L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 46L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 47L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 48L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 49L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 50L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 51L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 52L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 53L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 54L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 55L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 56L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 57L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 58L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 59L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 60L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 61L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 62L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 63L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 64L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 65L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 66L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 67L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 68L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 69L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 70L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 71L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 72L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 73L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 74L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 75L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 76L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 77L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 78L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 79L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 80L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 81L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 82L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 83L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 84L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 85L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 86L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 87L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 88L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 89L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 90L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 91L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 92L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 93L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 94L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 95L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 96L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 97L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 98L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 99L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 100L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 101L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 102L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 103L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 104L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 105L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 106L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 107L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 108L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 109L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 110L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 111L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 112L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 113L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 114L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 115L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 116L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 117L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 118L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 119L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 120L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 121L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 122L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 123L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 124L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 125L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 126L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 127L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 128L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 129L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 130L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 131L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 132L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 133L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 134L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 135L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 136L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 137L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 138L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 139L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 140L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 141L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 142L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 143L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 144L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 145L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 146L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 147L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 148L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 149L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 150L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 151L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 152L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 153L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 154L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 155L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 156L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 157L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 158L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 159L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 160L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 161L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 162L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 163L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 164L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 165L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 166L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 167L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 168L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 169L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 170L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 171L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 172L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 173L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 174L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 175L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 176L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 177L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 178L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 179L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 180L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 181L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 182L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 183L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 184L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 185L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 186L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 187L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 188L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 189L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 190L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 191L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 192L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 193L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 194L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 195L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 196L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 197L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 198L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 199L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 200L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 52L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 53L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 54L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 55L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 56L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 57L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 58L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 59L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 60L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 61L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 62L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 63L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 64L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 65L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 66L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 67L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 68L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 69L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 70L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 71L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 72L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 73L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 74L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 75L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 76L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 77L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 78L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 79L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 80L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 81L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 82L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 83L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 84L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 85L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 86L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 87L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 88L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 89L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 90L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 91L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 92L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 93L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 94L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 95L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 96L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 97L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 98L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 99L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 100L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 101L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 102L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 103L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 104L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 105L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 106L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 107L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 108L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 109L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 110L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 111L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 112L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 113L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 114L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 115L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 116L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 117L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 118L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 119L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 120L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 121L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 122L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 123L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 124L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 125L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 126L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 127L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 128L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 129L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 130L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 131L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 132L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 133L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 134L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 135L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 136L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 137L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 138L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 139L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 140L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 141L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 142L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 143L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 144L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 145L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 146L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 147L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 148L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 149L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 150L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 151L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 152L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 153L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 154L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 155L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 156L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 157L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 158L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 159L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 160L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 161L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 162L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 163L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 164L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 165L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 166L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 167L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 168L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 169L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 170L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 171L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 172L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 173L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 174L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 175L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 176L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 177L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 178L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 179L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 180L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 181L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 182L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 183L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 184L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 185L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 186L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 187L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 188L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 189L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 190L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 191L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 192L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 193L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 194L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 195L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 196L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 197L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 198L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 199L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 200L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 201L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 202L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 203L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 204L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 205L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 206L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 207L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 208L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 209L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 210L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 211L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 212L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 213L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 214L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 215L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 216L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 217L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 218L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 219L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 220L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 221L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 222L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 223L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 224L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 225L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 226L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 227L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 228L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 229L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 230L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 231L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 232L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 233L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 234L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 235L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 236L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 237L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 238L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 239L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 240L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 241L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 242L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 243L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 244L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 245L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 246L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 247L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 248L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 249L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 250L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 251L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 35L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 37L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 38L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 39L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 41L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 42L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 43L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 44L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 46L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 50L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 51L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 52L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 53L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 54L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 56L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 57L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 58L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 59L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 60L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 61L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 62L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 63L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 64L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 68L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 69L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 70L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 71L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 72L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 74L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 75L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 77L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 78L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 79L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 80L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 81L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 82L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 83L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 84L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 85L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 86L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 87L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 89L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 90L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 92L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 93L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 94L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 95L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 96L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 97L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 98L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 99L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 100L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 101L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 103L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 105L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 107L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 108L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 109L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 110L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 113L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 114L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 115L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 117L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 118L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 119L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 120L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 122L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 123L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 124L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 125L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 126L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 128L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 129L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 131L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 132L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 133L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 134L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 135L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 136L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 137L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 141L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 142L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 143L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 144L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 148L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 149L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 150L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 152L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 153L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 154L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 155L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 157L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 158L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 161L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 162L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 163L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 164L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 165L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 167L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 168L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 169L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 170L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 171L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 174L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 175L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 176L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 178L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 179L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 181L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 182L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 183L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 185L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 188L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 189L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 190L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 191L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 192L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 193L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 194L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 195L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 196L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 197L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 198L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 199L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 200L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 52L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 53L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 54L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 55L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 56L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 57L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 58L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 59L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 60L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 61L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 62L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 63L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 64L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 65L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 66L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 67L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 68L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 69L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 70L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 71L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 72L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 73L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 74L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 75L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 76L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 77L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 78L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 79L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 80L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 81L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 82L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 83L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 84L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 85L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 86L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 87L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 88L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 89L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 90L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 91L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 92L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 93L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 94L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 95L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 96L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 97L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 98L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 99L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 100L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 101L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 102L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 103L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 104L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 105L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 106L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 107L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 108L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 109L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 110L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 111L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 112L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 113L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 114L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 115L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 116L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 117L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 118L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 119L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 120L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 121L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 122L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 123L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 124L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 125L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 126L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 127L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 128L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 129L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 130L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 131L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 132L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 133L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 134L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 135L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 136L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 137L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 138L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 139L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 140L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 141L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 142L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 143L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 144L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 145L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 146L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 147L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 148L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 149L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 150L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 151L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 152L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 153L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 154L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 155L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 156L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 157L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 158L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 159L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 160L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 161L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 162L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 163L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 164L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 165L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 166L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 167L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 168L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 169L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 170L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 171L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 172L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 173L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 174L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 175L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 176L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 177L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 178L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 179L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 180L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 181L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 182L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 183L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 184L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 185L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 186L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 187L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 188L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 189L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 190L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 191L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 192L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 193L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 194L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 195L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 196L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 197L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 198L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 199L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 200L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 201L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 202L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 203L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 204L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 205L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 206L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 207L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 208L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 209L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 210L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 211L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 212L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 213L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 214L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 215L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 216L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 217L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 218L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 219L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 220L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 221L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 222L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 223L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 224L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 225L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 226L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 227L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 228L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 229L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 230L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 231L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 232L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 233L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 234L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 235L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 236L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 237L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 238L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 239L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 240L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 241L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 242L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 243L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 244L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 245L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 246L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 247L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 248L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 249L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 250L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 251L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 35L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 36L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 37L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 38L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 39L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 41L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 42L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 43L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 44L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 45L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 46L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 47L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 48L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 49L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 50L);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 51L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 35L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 36L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 37L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 38L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 39L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 41L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 42L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 43L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 44L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 45L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 46L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 47L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 48L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 49L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 50L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 51L);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "PasswordHash",
                value: "$2a$11$ZmZ7XI6o.G/aC5dxfvBtwOcp8juov7r6cr6R04W2eXB4a7631za6y");

            migrationBuilder.DropColumn(
                name: "ExpireDate",
                table: "Jobs");
        }
    }
}
