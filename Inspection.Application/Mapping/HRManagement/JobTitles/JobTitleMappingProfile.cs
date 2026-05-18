using AutoMapper;
using Inspection.Application.Contracts.Dto.HRManagement.JobRequests;
using Inspection.Application.Contracts.Dto.HRManagement.JobTitles;
using Inspection.Domain.Models.HRManagement.JobRequests;
using Inspection.Domain.Models.HRManagement.JobTitles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Mapping.HRManagement.JobTitles
{
    public class JobTitleMappingProfile : Profile
    {
        public JobTitleMappingProfile()
        {
            CreateMap<JobTitle, CreateJobTitleDto>().ReverseMap();

            CreateMap<UpdateJobTitleDto, JobTitle>()
                       .ForMember(dest => dest.Id, opt => opt.Ignore())
                       .ForMember(dest => dest.Tenant_ID, opt => opt.Ignore()).ReverseMap();
            CreateMap<JobTitleDto, JobTitle>().ReverseMap();
            CreateMap<JobTitle, JobTitleLookUpForNames>();


        }
    }
}
