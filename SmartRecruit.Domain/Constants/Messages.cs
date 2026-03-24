
namespace SmartRecruit.Domain.Constants
{
    public static class Messages
    {
        // ================================
        // GENERAL SYSTEM & ERROR MESSAGES
        // ================================
        public static class GeneralMsg
        {
            public const string INTERNAL_SERVER_ERROR = "Đã xảy ra lỗi không mong muốn. Vui lòng thử lại sau.";
            public const string BAD_REQUEST = "Yêu cầu không hợp lệ.";
            public const string NOT_FOUND = "Không tìm thấy yêu cầu.";
            public const string UNAUTHORIZED = "Cần đăng nhập để truy cập.";
            public const string FORBIDDEN = "Bạn không có quyền thực hiện hành động này.";
            public const string CONCURRENCY_ERROR = "Dữ liệu đã được thay đổi bởi người khác. Vui lòng tải lại trang.";
            public const string VALIDATION_ERROR = "Lỗi dữ liệu";
            public const string SERVER_ERROR = "Lỗi máy chủ";
            public const string RETRIEVE_SUCCESS = "Tải dữ liệu thành công";
            public const string SEARCH_SUCCESS = "Tìm kiếm thành công";
        }

        // ================================
        // AUTHENTICATION & IDENTITY
        // ================================
        public static class AuthMsg
        {
            public const string INVALID_CREDENTIALS = "Email hoặc mật khẩu không đúng.";
            public const string ACCOUNT_LOCKED = "Tài khoản của bạn đã bị khóa. Vui lòng liên hệ hỗ trợ.";
            public const string EMAIL_EXISTS = "Địa chỉ email này đã được đăng ký.";
            public const string INVALID_TOKEN = "Mã truy cập không hợp lệ hoặc đã hết hạn.";
            public const string PASSWORD_MISMATCH = "Mật khẩu và xác nhận mật khẩu không khớp.";
            public const string REFRESH_TOKEN_EXPIRED = "Phiên đăng nhập đã hết hạn. Vui lòng đăng nhập lại.";
        }

        // ================================
        // WALLET & FINANCE
        // ================================
        public static class WalletMsg
        {
            public const string INSUFFICIENT_BALANCE = "Số dư ví của bạn không đủ để thực hiện giao dịch này.";
            public const string INVALID_AMOUNT = "Số tiền giao dịch phải lớn hơn không.";
            public const string BELOW_MINIMUM = "Số tiền thấp hơn hạn mức tối thiểu yêu cầu.";
            public const string DAILY_LIMIT_EXCEEDED = "Bạn đã đạt giới hạn giao dịch hàng ngày.";
            public const string TRANSACTION_NOT_FOUND = "Không tìm thấy lịch sử giao dịch.";
        }

        // ================================
        // JOB & RECRUITMENT
        // ================================
        public static class JobMsg
        {
            public const string JOB_NOT_FOUND = "Không tìm thấy bài đăng tuyển dụng hoặc đã đóng.";
            public const string ALREADY_APPLIED = "Bạn đã ứng tuyển vào vị trí này rồi.";
            public const string JOB_EXPIRED = "Bài đăng này đã hết hạn ứng tuyển.";
            public const string PROFILE_INCOMPLETE = "Vui lòng hoàn thiện hồ sơ và tải lên CV trước khi ứng tuyển.";
            public const string RECRUITMENT_CLOSED = "Nhà tuyển dụng đã ngừng nhận hồ sơ cho công việc này.";
            public const string JOB_CREATED = "Đăng bài tuyển dụng thành công";
            public const string JOB_UPDATED = "Cập nhật bài tuyển dụng thành công";
            public const string JOB_DELETED = "Xóa bài tuyển dụng thành công";
            public const string JOB_RESTORED = "Khôi phục bài tuyển dụng thành công";
            public const string JOB_BLOCKED = "Bài đăng bị chặn và không thể sửa đổi";
            public const string JOB_NOT_OWNED = "Bạn không sở hữu bài đăng này";
            public const string SALARY_RANGE_INVALID = "Lương tối đa phải lớn hơn lương tối thiểu";
        }

        // ================================
        // SUCCESS MESSAGES
        // ================================
        public static class SuccessMsg
        {
            public const string CREATED = "Tạo thành công.";
            public const string UPDATED = "Cập nhật thành công.";
            public const string DELETED = "Xóa thành công.";
            public const string APPLIED = "Ứng tuyển thành công! Chúc bạn may mắn.";
            public const string DEPOSIT_SUCCESS = "Nạp tiền vào ví thành công.";
            public const string WITHDRAWAL_REQUESTED = "Yêu cầu rút tiền đã được gửi để duyệt.";
            public const string JOB_PUBLISHED = "Bài tuyển dụng của bạn đã được hiển thị.";
            public const string CREATE_SUCCESS = "Thành công";
            public const string UPDATE_SUCCESS = "Cập nhật thành công";
            public const string DELETE_SUCCESS = "Xóa thành công";
        }
    }
}