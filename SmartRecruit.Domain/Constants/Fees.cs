namespace SmartRecruit.Domain.Constants
{
    public static class Fees
    {
        public const decimal JOB_PUBLISH_FEE = 50000;
        public const decimal JOB_REPUBLISH_FEE = 25000;
        public const decimal JOB_BOOST_FEE = 20000;
        public const int JOB_BOOST_DURATION_DAYS = 7;  // Boosted jobs remain prominent for 7 days
        public const int JOB_EXPIRE_WARNING_DAYS = 3;  // Send "expiring soon" notification 3 days before expiry
    }
}
