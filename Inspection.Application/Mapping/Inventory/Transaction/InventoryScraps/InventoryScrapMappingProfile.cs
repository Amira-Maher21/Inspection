using AutoMapper;
using Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryScraps;
using Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryScraps.InventoryScrapLines;
using Inspection.Domain.Models.Inventory.Transaction.InventoryScraps;

namespace Inspection.Application.Mapping.Inventory.Transaction.InventoryScraps
{
    public class InventoryScrapMappingProfile : Profile
    {
        public InventoryScrapMappingProfile()
        {
            // ---------------- READ ----------------
            CreateMap<InventoryScrap, InventoryScrapDto>();

            CreateMap<InventoryScrapLine, InventoryScrapLineDto>();

            // ---------------- CREATE ----------------
            CreateMap<InventoryScrapCreateDto, InventoryScrap>();


            CreateMap<InventoryScrapLineCreateDto, InventoryScrapLine>();


            // ---------------- UPDATE ----------------
            CreateMap<InventoryScrapUpdateDto, InventoryScrap>()
                .ForMember(x => x.InventoryScrapLines, opt => opt.Ignore());


            CreateMap<InventoryScrapLineUpdateDto, InventoryScrapLine>();

        }
    }
}