using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.BankDTOs;
using Inspection.Domain.Models.Accounting.AccountingSetup.Banks;

namespace Inspection.Application.Mapping.Accounting.AccountingSetup.Banks
{
    public class BankMappingProfile : Profile
    {
        public BankMappingProfile()
        {
            CreateMap<Bank, BankDto>();


            CreateMap<BankCreateDto, Bank>();
            CreateMap<BankUpdateDto, Bank>();


        }
    }
}
