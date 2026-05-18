using AutoMapper;
using Inspection.Application.Contracts.Dto.DMSDTOs.DocumentShares;
using Inspection.Domain.Models.DMS.DocumentShares;

namespace Inspection.Application.Mapping.DMS.DocumentShareS

{

    public class DocumentShareMappingProfile : Profile
    {
        public DocumentShareMappingProfile()
        {
            CreateMap<DocumentShare, DocumentShareCreateDto>().ReverseMap().ForMember(x => x.Tenant_ID, opt => opt.Ignore());
            CreateMap<DocumentShare, DocumentShareUpdateDto>().ReverseMap();
            CreateMap<DocumentShare, DocumentShareDto>().ReverseMap();
            CreateMap<DocumentShare, DocumentShareReturnSearchDto>().ReverseMap();
        }
    }
}
