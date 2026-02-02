using AutoMapper;
using System;
using SmartRecruit.Application.DTO.Job;
using SmartRecruit.Application.Helpers;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Domain.Enums;
using Hangfire;

namespace SmartRecruit.Application.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGeminiService _geminiService;
        private readonly Hangfire.IBackgroundJobClient _backgroundJobClient;

        public JobService(IJobRepository jobRepository, IUnitOfWork unitOfWork, IMapper mapper, IGeminiService geminiService, Hangfire.IBackgroundJobClient backgroundJobClient)
        {
            _jobRepository = jobRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _geminiService = geminiService;
            _backgroundJobClient = backgroundJobClient;
        }

        public async Task<PagedList<JobResponse>> GetJobsByRecruiterAsync(long recruiterId)
        {
            var request = new JobSearchRequest(null, null, null, null, null, null, null, null, 1, 100, true, true)
            {
                RecruiterId = recruiterId
            };
            return await GetJobsAsync(request);
        }

        public async Task<PagedList<JobResponse>> GetJobsAsync(JobSearchRequest request)
        {
            var jobs = await _jobRepository.GetJobsAsync(request);
            var jobResponses = _mapper.Map<List<JobResponse>>(jobs);
            return new PagedList<JobResponse>(jobResponses, jobs.TotalCount, jobs.CurrentPage, jobs.PageSize);
        }

        public async Task<JobResponse> GetJobByIdAsync(long id)
        {
            var job = await _jobRepository.GetByIdAsync(id);
            if (job == null) throw new KeyNotFoundException("Job not found");
            return _mapper.Map<JobResponse>(job);
        }

        public async Task<JobResponse> CreateJobAsync(JobCreateRequest request)
        {
            var job = new Job
            {
                Title = request.Title,
                Company = request.Company,
                Benefits = request.Benefits,
                Description = request.Description,
                Requirement = request.Requirement,
                SkillsRequired = request.SkillsRequired,
                SalaryMin = request.SalaryMin,
                SalaryMax = request.SalaryMax,
                JobType = request.JobType,
                Location = request.Location,
                CategoryId = request.CategoryId,
                RecruiterId = request.RecruiterId,
                CreatedAt = DateTime.UtcNow,
                Status = JobStatus.CHECKING // Initial status
            };

            await _jobRepository.AddAsync(job);
            await _unitOfWork.CompleteAsync();

            // Enqueue background moderation
            _backgroundJobClient.Enqueue<IJobService>(x => x.ModerateJobAsync(job.Id));

            // Refresh job to get Category Name
            var createdJob = await _jobRepository.GetByIdAsync(job.Id);
            return _mapper.Map<JobResponse>(createdJob!);
        }

        public async Task ModerateJobAsync(long jobId)
        {
            var job = await _jobRepository.GetByIdAsync(jobId);
            if (job == null) return;

            try
            {
                var screeningResult = await _geminiService.CheckJobContentAsync(job.Title, job.Description);

                if (screeningResult.IsSafe)
                {
                    job.Status = JobStatus.APPROVED;
                    job.ModerationNote = "Approved by AI.";
                }
                else
                {
                    job.Status = JobStatus.BLOCKED;
                    job.ModerationNote = $"Blocked by AI: {screeningResult.ViolationType} - {screeningResult.Analysis}";
                }
            }
            catch (Exception ex)
            {
                // Check for transient errors to allow Hangfire to retry
                if (ex.Message.Contains("503") || ex.Message.Contains("429") || ex.Message.Contains("The model is overloaded"))
                {
                    throw; // Re-throw to let Hangfire retry with exponential backoff
                }

                // Permanent errors (config missing, validation, etc.) -> Block job
                job.Status = JobStatus.BLOCKED;
                job.ModerationNote = $"AI Check Failed: {ex.Message}";
            }

            _jobRepository.Update(job);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<JobResponse> UpdateJobAsync(long id, JobUpdateRequest request)
        {
            var job = await _jobRepository.GetByIdAsync(id);
            if (job == null) throw new KeyNotFoundException("Job not found");

            // Update fields
            job.Title = request.Title;
            job.Company = request.Company;
            job.Benefits = request.Benefits;
            job.Description = request.Description;
            job.Requirement = request.Requirement;
            job.SkillsRequired = request.SkillsRequired;
            job.SalaryMin = request.SalaryMin;
            job.SalaryMax = request.SalaryMax;
            job.JobType = request.JobType;
            job.JobType = request.JobType;
            job.Location = request.Location;
            job.CategoryId = request.CategoryId;
            // job.UpdatedTime = DateTime.UtcNow; 

            _jobRepository.Update(job);
            await _unitOfWork.CompleteAsync();

            // Refresh job to get Category Name
            var updatedJob = await _jobRepository.GetByIdAsync(job.Id);
            return _mapper.Map<JobResponse>(updatedJob!);
        }

        public async Task<bool> DeleteJobAsync(long id)
        {
            var job = await _jobRepository.GetByIdAsync(id);
            if (job == null) return false;

            _jobRepository.Delete(job);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> ToggleVisibilityAsync(long id)
        {
            var job = await _jobRepository.GetByIdAsync(id);
            if (job == null) throw new KeyNotFoundException("Job not found");

            bool isVisible = job.Status != JobStatus.HIDDEN; // Current state
            await _jobRepository.UpdateVisibilityAsync(id, !isVisible); // Toggle
            return !isVisible;
        }


    }
}
