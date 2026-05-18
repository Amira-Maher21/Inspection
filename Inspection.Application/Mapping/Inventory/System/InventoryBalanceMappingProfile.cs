using AutoMapper;
using Inspection.Application.Contracts.Dto.Inventory.System.InventoryBalance;
using Inspection.Domain.Models.Inventory.System.InventoryBalances;

namespace Inspection.Application.Mapping.Inventory.System
{
    public class InventoryBalanceMappingProfile : Profile
    {
        public InventoryBalanceMappingProfile()
        {
            CreateMap<InventoryBalance, InventoryBalanceCreateDto>().ReverseMap();
            CreateMap<InventoryBalance, InventoryBalanceDto>().ReverseMap();
            CreateMap<InventoryBalanceUpdateDto, InventoryBalance>().ReverseMap();
            CreateMap<InventoryBalanceDto, InventoryBalance>().ReverseMap();
            CreateMap<InventoryBalance, InventoryBalanceReturnSearchDto>().ReverseMap();
        }
    }
}
