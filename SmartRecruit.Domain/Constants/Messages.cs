
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

        public static class AiMsg
        {
            public const string APPROVED_BY_AI = "Đã được duyệt bởi AI.";
            public const string BLOCKED_BY_AI = "Bị AI chặn: {0} - {1}";
            public const string MODERATION_FAILED = "Kiểm tra AI thất bại: {0}";
            public const string SAFE_CONTENT = "An toàn";
            public const string VIOLATION_DETECTED = "Chỉnh sửa bị chặn bởi AI: {0} - {1}";
        }

        public static class NotificationMsg
        {
            public const string JOB_APPROVED_TITLE = "Công việc đã được duyệt";
            public const string JOB_APPROVED_CONTENT = "Bài đăng tuyển dụng '{0}' của bạn đã được AI duyệt và hiện đang hiển thị công khai.";
            public const string JOB_BLOCKED_TITLE = "Công việc bị chặn";
            public const string JOB_BLOCKED_CONTENT = "Bài đăng tuyển dụng '{0}' của bạn bị chặn do: {1}. Bạn có thể khiếu nại quyết định này.";
            public const string PAYMENT_SUCCESS_TITLE = "Giao dịch thành công";
            public const string PAYMENT_SUCCESS_CONTENT = "Đã thanh toán {0:N0} VNĐ để đăng bài tuyển dụng: {1}.";
            
            public const string NEW_APP_TITLE = "Ứng tuyển mới";
            public const string NEW_APP_CONTENT = "{0} đã ứng tuyển vào công việc: {1}";
            public const string APP_SUBMITTED_TITLE = "Nộp đơn thành công";
            public const string APP_SUBMITTED_CONTENT = "Bạn đã ứng tuyển thành công vào: {0}. Chúc bạn may mắn!";
        }

        public static class ApplicationMsg
        {
            public const string NOT_FOUND = "Không tìm thấy hồ sơ ứng tuyển.";
            public const string ALREADY_APPLIED = "Bạn đã ứng tuyển vào công việc này rồi.";
            public const string CV_REQUIRED = "Vui lòng cập nhật CV trong trang cá nhân trước khi ứng tuyển.";
            public const string INVALID_TRANSITION = "Chuyển đổi trạng thái không hợp lệ: {0} sang {1}.";
            public const string ALREADY_REJECTED = "Hồ sơ này đã bị từ chối rồi.";
            public const string INTERVIEW_DATE_REQUIRED = "Phải có ngày phỏng vấn khi chuyển sang trạng thái Phỏng vấn.";
            public const string REJECTION_REASON_REQUIRED = "Phải có lý do từ chối khi loại hồ sơ.";
            public const string DATA_NOT_REQUIRED = "Ngày phỏng vấn hoặc lý do từ chối không cần thiết cho trạng thái này.";
        }

        public static class CategoryMsg
        {
            public const string NOT_FOUND = "Không tìm thấy danh mục";
            public const string NAME_EXISTED = "Tên danh mục đã tồn tại.";
            public const string CREATED = "Tạo danh mục thành công";
            public const string UPDATED = "Cập nhật danh mục thành công";
            public const string DELETED = "Xóa danh mục thành công";
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
            public const string PAYMENT_SUCCESS = "Giao dịch thành công";
            public const string PUBLISH_SUCCESS = "Đăng bài tuyển dụng thành công";
        }
    }
}