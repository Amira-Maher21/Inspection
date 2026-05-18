using AutoMapper;
using Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryOpeningBalanceDTOs;
using Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryOpeningBalanceDTOs.InventoryOpeningBalanceLineDTOs;
using Inspection.Domain.Models.Inventory.Transaction.InventoryOpeningsBalance;

namespace Inspection.Application.Mapping.Inventory.Transaction.InventoryOpeningBalances
{

    public class InventoryOpeningBalanceMappingProfile : Profile
    {
        public InventoryOpeningBalanceMappingProfile()
        {
            // -------------------- READ --------------------

            CreateMap<InventoryOpeningBalance, InventoryOpeningBalanceDto>();
            CreateMap<InventoryOpeningBalanceLine, InventoryOpeningBalanceLineDto>();

            // -------------------- CREATE --------------------

            CreateMap<InventoryOpeningBalanceCreateDto, InventoryOpeningBalance>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.InventoryOpeningBalanceLines, opt => opt.Ignore());

            CreateMap<InventoryOpeningBalanceLineCreateDto, InventoryOpeningBalanceLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.InventoryOpeningBalance, opt => opt.Ignore()); ;

            // -------------------- UPDATE --------------------

            CreateMap<InventoryOpeningBalanceUpdateDto, InventoryOpeningBalance>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.InventoryOpeningBalanceLines, opt => opt.Ignore());

            CreateMap<InventoryOpeningBalanceLineUpdateDto, InventoryOpeningBalanceLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.InventoryOpeningBalance, opt => opt.Ignore());
        }
    }
}