namespace SmartRecruit.Application.DTO.Application
{
    public record ApplyJobRequest(
        long JobId,
        long CandidateId
    );
}
