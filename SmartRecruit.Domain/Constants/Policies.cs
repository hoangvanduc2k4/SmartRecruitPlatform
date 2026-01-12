namespace SmartRecruit.Domain.Constants
{
    public static class Policies
    {
        public const int DefaultJobExpiryDays = 30;

        public const int MaxFreeJobPosts = 5;

        public const decimal MinDepositAmount = 50000;

        public const decimal MinWithdrawAmount = 200000;

        public const decimal MaxWithdrawAmount = 20000000;

        public const string CurrencyLocale = "vi-VN";

        public const int MaxCvFileSize = 10 * 1024 * 1024;

        public const int MaxAvatarFileSize = 5 * 1024 * 1024;

        public const int HotJobsCacheHours = 6;
    }
}