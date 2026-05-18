using AutoMapper;
using Inspection.Application.Contracts.Dto.Inventory.Transaction.ScrapReasons;
using Inspection.Domain.Models.Inventory.Transaction.ScrapReasons;

namespace Inspection.Application.Mapping.Inventory.Transaction.ScrapReasons
{
    public class ScrapReasonMappingProfile : Profile
    {
        public ScrapReasonMappingProfile()
        {
            // -------- READ --------
            CreateMap<ScrapReason, ScrapReasonDto>();

            // -------- CREATE --------
            CreateMap<ScrapReasonCreateDto, ScrapReason>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.ChartOfAccount, opt => opt.Ignore());

            // -------- UPDATE --------
            CreateMap<ScrapReasonUpdateDto, ScrapReason>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.ChartOfAccount, opt => opt.Ignore());
        }
    }
}