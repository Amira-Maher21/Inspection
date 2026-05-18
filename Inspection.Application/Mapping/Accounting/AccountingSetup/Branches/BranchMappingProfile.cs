using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.Branches;
using Inspection.Domain.Models.Accounting.AccountingSetup.Branches;

namespace Inspection.Application.Mapping.Accounting.AccountingSetup.Branches
{
    public class BranchMappingProfile : Profile
    {
        public BranchMappingProfile()
        {
            CreateMap<Branch, BranchDto>().ReverseMap();

            CreateMap<BranchCreateDto, Branch>().ReverseMap();

            CreateMap<BranchUpdateDto, Branch>().ReverseMap();
            CreateMap<BranchReturnSearchDto, Branch>().ReverseMap();
        }
    }
}
