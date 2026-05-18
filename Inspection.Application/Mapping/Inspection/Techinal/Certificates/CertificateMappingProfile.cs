using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.CertificateDTOs;
using Inspection.Domain.Models.Inspection.Techinal.Certificates;

namespace Inspection.Application.Mapping.Inspection.Techinal.Certificates
{
    public class CertificateMappingProfile : Profile
    {
        public CertificateMappingProfile()
        {
            CreateMap<Certificate, CertificateCreateDto>().ReverseMap().ForMember(x => x.Tenant_ID, opt => opt.Ignore());
            CreateMap<Certificate, CertificateUpdateDto>().ReverseMap();
            CreateMap<Certificate, CertificateDto>().ReverseMap();
            CreateMap<Certificate, CertificateReturnSearchDto>().ReverseMap();
        }
    }
}