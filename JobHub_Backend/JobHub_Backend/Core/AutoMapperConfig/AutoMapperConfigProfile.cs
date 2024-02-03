using AutoMapper;
using JobHub_Backend.Core.DTO.Candidate;
using JobHub_Backend.Core.DTO.Company;
using JobHub_Backend.Core.DTO.Job;
using JobHub_Backend.Core.Entities;

namespace JobHub_Backend.Core.AutoMapperConfig
{
	public class AutoMapperConfigProfile : Profile
	{
        public AutoMapperConfigProfile()
        {
            // Company
            CreateMap<CompanyCreateDTO, Company>();
            CreateMap<Company, CompanyGetDTO>();


            //Job
            CreateMap<JobCreateDTO, Job>();
            CreateMap<Job, JobGetDTO>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name));


            //Candidate
            CreateMap<CandidateCreateDTO, Candidate>();
            CreateMap<Candidate, CandidateGetDTO>()
                .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.Job.Title));
        }
    }
}
