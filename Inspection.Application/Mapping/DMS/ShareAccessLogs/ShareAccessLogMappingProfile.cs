using AutoMapper;
using Inspection.Application.Contracts.Dto.DMSDTOs.ShareAccessLogs;
using Inspection.Domain.Models.DMS.ShareAccessLogs;

namespace Inspection.Application.Mapping.DMS.ShareAccessLogs
{

    public class ShareAccessLogMappingProfile : Profile
    {
        public ShareAccessLogMappingProfile()
        {
            CreateMap<ShareAccessLog, ShareAccessLogCreateDto>().ReverseMap().ForMember(x => x.Tenant_ID, opt => opt.Ignore());
            CreateMap<ShareAccessLog, ShareAccessLogUpdateDto>().ReverseMap();
            CreateMap<ShareAccessLog, ShareAccessLogDto>().ReverseMap();
            CreateMap<ShareAccessLog, ShareAccessLogReturnSearchDto>().ReverseMap();
        }
    }
}
