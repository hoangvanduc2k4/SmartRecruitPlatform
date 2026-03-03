using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRecruit.Application.DTO.Application
{
    public record ApplicationResponse
    (
        long Id,
        long JobId,
        string JobTitle,
        string Company,
        long CandidateId,
        string CandidateName,
        string CandidateEmail,
        decimal MatchScore,
        decimal SkillMatch,
        decimal ExperienceMatch,
        string? AI_Summary,
        string Status,       // ApplicationStatus enum → string
        string? Notes,
        DateTime CreatedAt
    );

}
