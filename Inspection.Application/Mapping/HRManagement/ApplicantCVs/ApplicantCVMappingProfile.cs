using AutoMapper;
using Inspection.Application.Contracts.Dto.HRManagement.ApplicantCVs;
using Inspection.Application.Contracts.Dto.HRManagement.Departments;
using Inspection.Domain.Models.HRManagement.ApplicantCVs;
using Inspection.Domain.Models.HRManagement.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Mapping.HRManagement.ApplicantCVs
{
    public class ApplicantCVMappingProfile : Profile
    {
        public ApplicantCVMappingProfile()
        {
            CreateMap<ApplicantCV, CreateApplicantCVDto>().ReverseMap();

            CreateMap<UpdateApplicantCVDto, ApplicantCV>().ReverseMap();

            CreateMap<ApplicantCVDto, ApplicantCV>().ReverseMap();

            CreateMap<ApplicantCV, ApplicantCVDtoLookUpForNames>()
          .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FullName));

            CreateMap<ApplicantCVDto, ApplicantCVDtoLookUpForNames>()
       .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FullName));

        }
    }
}
