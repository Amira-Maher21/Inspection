using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetMaintenanceDTOs;
using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetMaintenanceDTOs.AssetMaintenanceLineDTOs;
using Inspection.Domain.Models.Accounting.Assets.AssetMaintenances;

namespace Inspection.Application.Mapping.Accounting.Assets.AssetMaintenances
{
    public class AssetMaintenanceMappingProfile : Profile
    {
        public AssetMaintenanceMappingProfile()
        {
            // -------------------- READ --------------------

            CreateMap<AssetMaintenance, AssetMaintenanceDto>();
            CreateMap<AssetMaintenanceLine, AssetMaintenanceLineDto>();

            // -------------------- CREATE --------------------

            CreateMap<AssetMaintenanceCreateDto, AssetMaintenance>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.AssetMaintenanceLines, opt => opt.Ignore());

            CreateMap<AssetMaintenanceLineCreateDto, AssetMaintenanceLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.AssetMaintenance, opt => opt.Ignore());

            // -------------------- UPDATE --------------------

            CreateMap<AssetMaintenanceUpdateDto, AssetMaintenance>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.AssetMaintenanceLines, opt => opt.Ignore());

            CreateMap<AssetMaintenanceLineUpdateDto, AssetMaintenanceLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.AssetMaintenance, opt => opt.Ignore());
        }
    }
}