using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.PR.MasterData.SupplierGroups;
using Inspection.Domain.Models.Accounting.PR.MasterData.Suppliers;

namespace Inspection.Application.Mapping.Accounting.PR.MasterData.SupplierGroups
{
    public class SupplierGroupMappingProfile : Profile
    {
        public SupplierGroupMappingProfile()
        {
            CreateMap<SupplierGroup, SupplierGroupDto>().ReverseMap();

            CreateMap<SupplierGroupCreateDto, SupplierGroup>().ReverseMap();

            CreateMap<SupplierGroupUpdateDto, SupplierGroup>().ReverseMap();
            CreateMap<SupplierGroupReturnSearchDto, SupplierGroup>().ReverseMap();
        }
    }
}