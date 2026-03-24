namespace SmartRecruit.Application.DTO.Job
{
    public class JobScreeningResponse
    {
        public bool IsSafe { get; set; }
        public string RiskLevel { get; set; } = string.Empty;
        public string ViolationType { get; set; } = string.Empty;
        public string Analysis { get; set; } = string.Empty;
    }
}
