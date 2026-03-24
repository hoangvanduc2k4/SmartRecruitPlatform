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
        string? AISummary,
        string Status,       // ApplicationStatus enum → string
        string? Notes,
        DateTime CreatedAt
    );

}
