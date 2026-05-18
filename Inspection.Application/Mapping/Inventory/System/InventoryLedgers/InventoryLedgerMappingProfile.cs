using AutoMapper;
using Inspection.Application.Contracts.Dto.Inventory.System.InventoryLedgers;
using Inspection.Domain.Models.Inventory.System.InventoryLedgers;

namespace Inspection.Application.Mapping.Inventory.System.InventoryLedgers
{

    public class InventoryLedgerMappingProfile : Profile
    {

        public InventoryLedgerMappingProfile()
        {
            CreateMap<InventoryLedgerCreateDto, InventoryLedger>();

            CreateMap<InventoryLedger, InventoryLedgerDto>();

            CreateMap<InventoryLedgerUpdateDto, InventoryLedger>();
        }


    }
}

