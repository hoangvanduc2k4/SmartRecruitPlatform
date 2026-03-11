using SmartRecruit.Application.DTO.Report;
using SmartRecruit.Application.Helpers;
using System.Threading.Tasks;

namespace SmartRecruit.Application.Interfaces.Services
{
    public interface IReportService
    {
        Task<PagedList<ReportResponse>> GetReportsAsync(int page, int pageSize);
    }
}
