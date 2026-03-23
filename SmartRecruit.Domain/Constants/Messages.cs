namespace SmartRecruit.Domain.Constants
{
    public static class Messages
    {
        // ================================
        // GENERAL SYSTEM & ERROR MESSAGES
        // ================================
        public static class GeneralMsg
        {
            public const string INTERNAL_SERVER_ERROR = "An unexpected error occurred. Please try again later.";
            public const string BAD_REQUEST = "The request is invalid.";
            public const string NOT_FOUND = "The requested resource was not found.";
            public const string UNAUTHORIZED = "Authentication is required to access this resource.";
            public const string FORBIDDEN = "You do not have permission to perform this action.";
            public const string CONCURRENCY_ERROR = "The data has been modified by another user. Please refresh.";
            public const string VALIDATION_ERROR = "Validation failed";
            public const string SERVER_ERROR = "Internal server error";
            public const string RETRIEVE_SUCCESS = "Retrieved successfully";
            public const string SEARCH_SUCCESS = "Search completed successfully";
        }

        // ================================
        // AUTHENTICATION & IDENTITY
        // ================================
        public static class AuthMsg
        {
            public const string INVALID_CREDENTIALS = "Invalid email or password.";
            public const string ACCOUNT_LOCKED = "Your account has been locked. Please contact support.";
            public const string EMAIL_EXISTS = "This email address is already registered.";
            public const string INVALID_TOKEN = "Invalid or expired access token.";
            public const string PASSWORD_MISMATCH = "Password and confirmation password do not match.";
            public const string REFRESH_TOKEN_EXPIRED = "Session has expired. Please login again.";
        }

        // ================================
        // WALLET & FINANCE
        // ================================
        public static class WalletMsg
        {
            public const string INSUFFICIENT_BALANCE = "Your wallet balance is insufficient for this transaction.";
            public const string INVALID_AMOUNT = "Transaction amount must be greater than zero.";
            public const string BELOW_MINIMUM = "The amount is below the required minimum limit.";
            public const string DAILY_LIMIT_EXCEEDED = "You have reached your daily transaction limit.";
            public const string TRANSACTION_NOT_FOUND = "Transaction record not found.";
        }

        // ================================
        // JOB & RECRUITMENT
        // ================================
        public static class JobMsg
        {
            public const string JOB_NOT_FOUND = "The job posting was not found or has been closed.";
            public const string ALREADY_APPLIED = "You have already applied for this position.";
            public const string JOB_EXPIRED = "This job posting has reached its application deadline.";
            public const string PROFILE_INCOMPLETE = "Please complete your profile and upload a CV before applying.";
            public const string RECRUITMENT_CLOSED = "The recruiter has stopped receiving applications for this job.";
            public const string JOB_CREATED = "Job posted successfully";
            public const string JOB_UPDATED = "Job updated successfully";
            public const string JOB_DELETED = "Job deleted successfully";
            public const string JOB_RESTORED = "Job restored successfully";
            public const string JOB_BLOCKED = "Job is blocked and cannot be modified";
            public const string JOB_NOT_OWNED = "You do not own this job";
            public const string SALARY_RANGE_INVALID = "Maximum salary must be greater than minimum salary";
        }

        // ================================
        // SUCCESS MESSAGES
        // ================================
        public static class SuccessMsg
        {
            public const string CREATED = "Resource created successfully.";
            public const string UPDATED = "Resource updated successfully.";
            public const string DELETED = "Resource deleted successfully.";
            public const string APPLIED = "Application submitted successfully! Good luck.";
            public const string DEPOSIT_SUCCESS = "Money has been successfully added to your wallet.";
            public const string WITHDRAWAL_REQUESTED = "Withdrawal request submitted for approval.";
            public const string JOB_PUBLISHED = "Your job posting is now live.";
            public const string CREATE_SUCCESS = "Created successfully";
            public const string UPDATE_SUCCESS = "Updated successfully";
            public const string DELETE_SUCCESS = "Deleted successfully";
        }
    }
}
