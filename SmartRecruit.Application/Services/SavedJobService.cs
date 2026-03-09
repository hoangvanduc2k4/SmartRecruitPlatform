using AutoMapper;
using SmartRecruit.Application.DTO.Job;
using SmartRecruit.Application.Helpers;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Domain.Entities;

namespace SmartRecruit.Application.Services
{
    public class SavedJobService : ISavedJobService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SavedJobService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> ToggleSaveJobAsync(long jobId, long userId)
        {
            var existing = await _unitOfWork.SavedJobs.FindAsync(sj => sj.JobId == jobId && sj.UserId == userId);

            if (existing != null)
            {
                _unitOfWork.SavedJobs.Delete(existing);
                await _unitOfWork.CompleteAsync();
                return false; // Unsaved
            }

            // Verify job exists
            var job = await _unitOfWork.Jobs.GetByIdAsync(jobId);
            if (job == null) throw new KeyNotFoundException("Job not found");

            var savedJob = new SavedJob
            {
                JobId = jobId,
                UserId = userId
            };

            await _unitOfWork.SavedJobs.AddAsync(savedJob);
            await _unitOfWork.CompleteAsync();
            return true; // Saved
        }

        public async Task<bool> IsJobSavedAsync(long jobId, long userId)
        {
            var existing = await _unitOfWork.SavedJobs.FindAsync(sj => sj.JobId == jobId && sj.UserId == userId);
            return existing != null;
        }

        public async Task<PagedList<JobResponse>> GetSavedJobsAsync(long userId, int page, int pageSize)
        {
            var savedJobs = await _unitOfWork.SavedJobs.FindAllAsync(sj => sj.UserId == userId);

            var totalCount = savedJobs.Count();
            var jobIds = savedJobs
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(sj => sj.JobId)
                .ToList();

            if (!jobIds.Any())
            {
                return new PagedList<JobResponse>(new List<JobResponse>(), totalCount, page, pageSize);
            }

            var jobs = await _unitOfWork.Jobs.FindAllAsync(j => jobIds.Contains(j.Id));

            // Note: Since GenericRepository.FindAllAsync performs an in-memory or already executed query,
            // we should be careful about order. Let's ensure the order matches the JobIds sequence if possible.
            // Also filter out any jobs that might have been deleted (and thus not returned by the generic repository).
            var orderedJobs = jobIds
                .Select(id => jobs.FirstOrDefault(j => j.Id == id))
                .Where(j => j != null)
                .Cast<Job>()
                .ToList();

            var jobResponses = _mapper.Map<List<JobResponse>>(orderedJobs);
            return new PagedList<JobResponse>(jobResponses, totalCount, page, pageSize);
        }
    }
}
