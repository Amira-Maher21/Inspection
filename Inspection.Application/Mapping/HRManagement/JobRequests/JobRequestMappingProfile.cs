using AutoMapper;
using Inspection.Application.Contracts.Dto.HRManagement.Departments;
using Inspection.Application.Contracts.Dto.HRManagement.JobRequests;
using Inspection.Domain.Models.HRManagement.Departments;
using Inspection.Domain.Models.HRManagement.JobRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Mapping.HRManagement.JobRequests
{
    public class JobRequestMappingProfile : Profile
    {
        public JobRequestMappingProfile()
        {
            CreateMap<JobRequest, CreateJobRequestDto>().ReverseMap();

            CreateMap<UpdateJobRequestDto, JobRequest>()
                       .ForMember(dest => dest.Id, opt => opt.Ignore())
                       .ForMember(dest => dest.Tenant_ID, opt => opt.Ignore()).ReverseMap();
            CreateMap<JobRequestDto, JobRequest>().ReverseMap();
            CreateMap<JobRequest, JobRequestLookUpForNames>();


        }
    }
}
