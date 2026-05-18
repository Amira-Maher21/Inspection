using AutoMapper;
using Inspection.Application.Contracts.Dto.HRManagement.JobAdvertisements;
using Inspection.Domain.Models.HRManagement.JobAdvertisements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Mapping.HRManagement.JobAdvertisements
{
    public class JobAdvertisementMappingProfile : Profile
    {
        public JobAdvertisementMappingProfile()
        {
            CreateMap<JobAdvertisement, CreateJobAdvertisementDto>().ReverseMap();

            CreateMap<UpdateJobAdvertisementDto, JobAdvertisement>()
                       .ForMember(dest => dest.Id, opt => opt.Ignore())
                       .ForMember(dest => dest.Tenant_ID, opt => opt.Ignore()).ReverseMap();
            CreateMap<JobAdvertisementDto, JobAdvertisement>().ReverseMap();
            CreateMap<JobAdvertisement, JobAdvertisementDtoLookUpForNames>();



        }
    }
}
