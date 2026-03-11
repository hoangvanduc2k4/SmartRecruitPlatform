using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartRecruit.Application.DTO.Report;
using SmartRecruit.Application.Helpers;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRecruit.Application.Services
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReportService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedList<ReportResponse>> GetReportsAsync(int page, int pageSize)
        {
            var reportsQuery = await _unitOfWork.Reports.GetAllAsync();
            var totalCount = reportsQuery.Count();
            
            var reports = reportsQuery
                .OrderByDescending(r => r.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var responses = new List<ReportResponse>();
            foreach (var report in reports)
            {
                // Loading related entities manually if GenericRepository doesn't Include them
                // In a real scenario, we'd add Include support to GenericRepository or use a specific repository
                var job = await _unitOfWork.Jobs.GetByIdAsync(report.JobId);
                var reporter = await _unitOfWork.Users.GetByIdAsync(report.ReporterId);

                responses.Add(new ReportResponse
                {
                    Id = report.Id,
                    JobId = report.JobId,
                    JobTitle = job?.Title ?? "Unknown Job",
                    ReporterId = report.ReporterId,
                    ReporterName = reporter?.FullName ?? "Unknown User",
                    Reason = report.Reason,
                    CreatedAt = report.CreatedAt,
                    IsProcessed = report.IsProcessed
                });
            }

            return new PagedList<ReportResponse>(responses, totalCount, page, pageSize);
        }
    }
}
