namespace SmartRecruit.Domain.Constants
{
    public static class Messages
    {
        // --- System & Generic Errors ---
        public static class GeneralMsg
        {
            public const string InternalServerError = "An unexpected error occurred. Please try again later.";
            public const string BadRequest = "The request is invalid.";
            public const string NotFound = "The requested resource was not found.";
            public const string Unauthorized = "Authentication is required to access this resource.";
            public const string Forbidden = "You do not have permission to perform this action.";
            public const string ConcurrencyError = "The data has been modified by another user. Please refresh.";
        }

        // --- Authentication & Identity ---
        public static class AuthMsg
        {
            public const string InvalidCredentials = "Invalid email or password.";
            public const string AccountLocked = "Your account has been locked. Please contact support.";
            public const string EmailExists = "This email address is already registered.";
            public const string InvalidToken = "Invalid or expired access token.";
            public const string PasswordMismatch = "Password and confirmation password do not match.";
            public const string RefreshTokenExpired = "Session has expired. Please login again.";
        }

        // --- Wallet & Finance ---
        public static class WalletMsg
        {
            public const string InsufficientBalance = "Your wallet balance is insufficient for this transaction.";
            public const string InvalidAmount = "Transaction amount must be greater than zero.";
            public const string BelowMinimum = "The amount is below the required minimum limit.";
            public const string DailyLimitExceeded = "You have reached your daily transaction limit.";
            public const string TransactionNotFound = "Transaction record not found.";
        }

        // --- Recruitment & Job Management ---
        public static class JobMsg
        {
            public const string JobNotFound = "The job posting was not found or has been closed.";
            public const string AlreadyApplied = "You have already applied for this position.";
            public const string JobExpired = "This job posting has reached its application deadline.";
            public const string ProfileIncomplete = "Please complete your profile and upload a CV before applying.";
            public const string RecruitmentClosed = "The recruiter has stopped receiving applications for this job.";
        }

        // --- Success Responses ---
        public static class SuccessMsg
        {
            // CRUD Operations
            public const string Created = "Resource created successfully.";
            public const string Updated = "Resource updated successfully.";
            public const string Deleted = "Resource deleted successfully.";

            // Specific Flows
            public const string Applied = "Application submitted successfully! Good luck.";
            public const string DepositSuccess = "Money has been successfully added to your wallet.";
            public const string WithdrawalRequested = "Withdrawal request submitted for approval.";
            public const string JobPublished = "Your job posting is now live.";
        }
    }
}