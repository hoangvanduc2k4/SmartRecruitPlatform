
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
            public const string NOT_FOUND = "Không tìm thấy thông tin ví.";
            public const string INSUFFICIENT_FUNDS = "Số dư ví của bạn không đủ để thực hiện giao dịch này.";
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
            public const string NOT_OWNER = "Bạn không có quyền thao tác trên công việc này.";
            public const string SALARY_RANGE_INVALID = "Lương tối đa phải lớn hơn lương tối thiểu";
            public const string JOB_UNDER_APPEAL = "Không thể thực hiện hành động này khi công việc đang trong quá trình khiếu nại.";
            public const string POST_JOB_DESC = "Đăng bài tuyển dụng: {0}";
            public const string BOOST_JOB_DESC = "Đẩy tin công việc {0}: {1}";
        }

        // ================================
        // CATEGORY
        // ================================
        public static class CategoryMsg
        {
            public const string NOT_FOUND = "Không tìm thấy danh mục.";
            public const string ALREADY_EXISTS = "Tên danh mục đã tồn tại.";
        }

        // ================================
        // AI & SCREENING
        // ================================
        public static class AiMsg
        {
            public const string APPROVED_BY_AI = "Đã được duyệt bởi AI.";
            public const string BLOCKED_BY_AI = "Bị chặn bởi AI: {0}";
            public const string SCORING_FAILED = "Phân tích AI thất bại: {0}";
        }

        // ================================
        // NOTIFICATIONS
        // ================================
        public static class NotificationMsg
        {
            // Job Notifications
            public const string JOB_APPROVED_TITLE = "Công việc đã được duyệt";
            public const string JOB_APPROVED_CONTENT = "Bài đăng tuyển dụng '{0}' của bạn đã được AI duyệt và hiện đang hiển thị công khai.";
            public const string JOB_BLOCKED_TITLE = "Công việc bị chặn";
            public const string JOB_BLOCKED_CONTENT = "Bài đăng tuyển dụng '{0}' của bạn bị chặn do: {1}. Bạn có thể khiếu nại quyết định này.";
            
            public const string JOB_EDIT_REJECTED_TITLE = "Chỉnh sửa Job bị từ chối";
            public const string JOB_EDIT_REJECTED_CONTENT = "Nội dung chỉnh sửa của job '{0}' vi phạm chính sách và đã bị từ chối. Job của bạn vẫn đang hoạt động bình thường với nội dung cũ.";
            
            public const string JOB_PUBLISHED_TITLE = "Phát hành Job thành công";
            public const string JOB_PUBLISHED_CONTENT = "Công việc '{0}' đã được duyệt và đăng tải.";
            
            public const string JOB_REJECTED_TITLE = "Job bị từ chối";
            public const string JOB_REJECTED_CONTENT = "Công việc '{0}' không vượt qua kiểm duyệt AI.";
            
            // Payment Notifications
            public const string PAYMENT_SUCCESS_TITLE = "Giao dịch thành công";
            public const string PAYMENT_SUCCESS_CONTENT = "Đã thanh toán {0:N0} VNĐ cho dịch vụ: {1}.";

            public const string DEPOSIT_SUCCESS_TITLE = "Nạp tiền thành công";
            public const string DEPOSIT_SUCCESS_CONTENT = "Nạp thành công {0:N0} VNĐ qua PayOS. Số dư mới của bạn là: {1:N0} VNĐ.";

            // Application Notifications
            public const string APPLICATION_NEW_TITLE = "Đơn ứng tuyển mới";
            public const string APPLICATION_NEW_CONTENT = "{0} đã ứng tuyển vào vị trí: {1}.";
            public const string APPLICATION_SUBMITTED_TITLE = "Ứng tuyển thành công";
            public const string APPLICATION_SUBMITTED_CONTENT = "Bạn đã ứng tuyển thành công vào vị trí '{0}'. Chúc bạn may mắn!";

            public const string APPLICATION_STATUS_UPDATE_TITLE = "Cập nhật hồ sơ";
            public const string APPLICATION_STATUS_UPDATE_CONTENT = "Hồ sơ của bạn cho vị trí '{0}' đã được cập nhật thành: {1}.";
            
            public const string APPLICATION_SCORED_TITLE = "CV của bạn đã được đánh giá";
            public const string APPLICATION_SCORED_CONTENT = "Hệ thống AI đã hoàn thành đánh giá CV của bạn cho vị trí '{0}'. Kết quả phù hợp: {1}%";
            
            public const string APPLICATION_INTERVIEW_TITLE = "Mời phỏng vấn";
            public const string APPLICATION_INTERVIEW_CONTENT = "Chúc mừng! Bạn đã được mời phỏng vấn cho vị trí '{0}'. Vui lòng kiểm tra email để biết chi tiết.";
            
            public const string APPLICATION_OFFER_TITLE = "Nhận lời mời làm việc";
            public const string APPLICATION_OFFER_CONTENT = "Tin vui! Bạn đã nhận được lời mời làm việc cho vị trí '{0}'. Chúc mừng!";
            
            public const string APPLICATION_REJECTED_TITLE = "Đơn ứng tuyển không được chấp nhận";
            public const string APPLICATION_REJECTED_CONTENT = "Cảm ơn bạn đã ứng tuyển vào vị trí '{0}'. Rất tiếc, hồ sơ của bạn không phù hợp trong lần này.";
            
            public const string APPLICATION_RESTORE_TITLE = "Khôi phục hồ sơ";
            public const string APPLICATION_RESTORE_CONTENT = "Hồ sơ của bạn cho vị trí '{0}' đã được khôi phục về trạng thái: {1}.";
            public const string APPLICATION_RESTORE_OFFER_CONTENT = "Tin vui! Đề nghị nhận việc của bạn cho vị trí '{0}' đã được khôi phục. Vui lòng kiểm tra lại.";
        }

        // ================================
        // APPLICATION
        // ================================
        public static class ApplicationMsg
        {
            public const string NOT_FOUND = "Không tìm thấy đơn ứng tuyển.";
            public const string ALREADY_APPLIED = "Bạn đã ứng tuyển vào vị trí này rồi.";
            public const string CV_REQUIRED = "Vui lòng tải lên CV trước khi ứng tuyển.";
            public const string ALREADY_REJECTED = "Đơn ứng tuyển này đã bị từ chối trước đó.";
            public const string INTERVIEW_DATE_REQUIRED = "Vui lòng cung cấp thời gian phỏng vấn.";
            public const string REJECTION_REASON_REQUIRED = "Vui lòng cung cấp lý do từ chối.";
            public const string ONLY_REJECT_RESTORE = "Chỉ có thể khôi phục các đơn đã bị từ chối.";
            public const string REANALYZE_REJECTED = "Không thể phân tích lại hồ sơ đã bị từ chối.";
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