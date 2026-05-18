using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectorDTOs;

namespace Inspection.Application.Mapping.Inspection.Techinal.Inspector
{
    public class InspectorMappingProfile : Profile
    {
        public InspectorMappingProfile()
        {
            CreateMap<Domain.Models.Inspection.Techinal.Inspectors.Inspector, InspectorCreateDto>().ReverseMap().ForMember(x => x.Tenant_ID, opt => opt.Ignore());
            CreateMap<Domain.Models.Inspection.Techinal.Inspectors.Inspector, InspectorUpdateDto>().ReverseMap();
            CreateMap<Domain.Models.Inspection.Techinal.Inspectors.Inspector, InspectorDto>().ReverseMap();
            CreateMap<Domain.Models.Inspection.Techinal.Inspectors.Inspector, InspectorReturnSearchDto>().ReverseMap();
            CreateMap<Domain.Models.Inspection.Techinal.Inspectors.Inspector, InspectorGetListDto>().ReverseMap();
        }
    }
}