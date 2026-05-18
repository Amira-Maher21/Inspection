using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionCertificates;
using Inspection.Domain.Models.InspectionManagement.InspectionCertificates;

namespace Inspection.Application.Mapping.InspectionManagement.InspectionCertificates
{
    public class InspectionCertificateMappingProfile : Profile
    {
        public InspectionCertificateMappingProfile()
        {




            CreateMap<InspectionCertificate, InspectionCertificateDto>().ReverseMap();
            CreateMap<InspectionCertificateCreateDto, InspectionCertificate>().ReverseMap();
            CreateMap<InspectionCertificateUpdateDto, InspectionCertificate>().ReverseMap();
            CreateMap<InspectionCertificateDtoByInclude, InspectionCertificate>().ReverseMap();
            CreateMap<InspectionCertificateDtoByInclude, InspectionCertificateDto>().ReverseMap();
        }
    }
}