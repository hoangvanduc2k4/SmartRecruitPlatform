using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRecruit.Application.DTO.Application
{
     public record ApplicationSearchRequest(
        long? CandidateId,    // Lọc theo candidate
        long? JobId,          // Lọc theo job
        int? Status,          // Lọc theo ApplicationStatus
        int Page = 1,
        int PageSize = 10
     );

}
