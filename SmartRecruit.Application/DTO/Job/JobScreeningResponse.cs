namespace SmartRecruit.Application.DTO.Job
{
    public class JobScreeningResponse
    {
        public bool IsSafe { get; set; }
        public string RiskLevel { get; set; }
        public string ViolationType { get; set; }
        public string Analysis { get; set; }
    }
}
