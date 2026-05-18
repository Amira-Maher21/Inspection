using AutoMapper;
using Inspection.Application.Contracts.Dto.HRManagement.JobOfferNegotiations;
using Inspection.Domain.Models.HRManagement.JobOfferNegotiations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Mapping.HRManagement.JobOfferNegotiations
{
    public class JobOfferNegotiationMappingProfile : Profile
    {
        public JobOfferNegotiationMappingProfile()
        {
            CreateMap<JobOfferNegotiation, CreateJobOfferNegotiationDto>().ReverseMap();

            CreateMap<UpdateJobOfferNegotiationDto, JobOfferNegotiation>()
                       .ForMember(dest => dest.Id, opt => opt.Ignore())
                       .ForMember(dest => dest.Tenant_ID, opt => opt.Ignore()).ReverseMap();
            CreateMap<JobOfferNegotiationDto, JobOfferNegotiation>().ReverseMap();
            CreateMap<JobOfferNegotiation, JobOfferNegotiationDtoLookUpForNames>();



        }
    }
}
