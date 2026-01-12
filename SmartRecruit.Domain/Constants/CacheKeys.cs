namespace SmartRecruit.Domain.Constants
{
    public static class CacheKeys
    {
        // Pattern: job_detail:{id}
        public const string JobDetailPrefix = "job_detail:";

        // Pattern: user_token:{userId}
        public const string UserTokenPrefix = "user_token:";

        public const string TrendingJobs = "trending_jobs";
    }
}