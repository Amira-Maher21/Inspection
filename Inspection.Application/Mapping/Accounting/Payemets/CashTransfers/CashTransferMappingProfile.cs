using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashTransferDTOs;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashTransferDTOs.CashTransferLineDTOs;
using Inspection.Domain.Models.Accounting.Payment.CashTransfers;

namespace Inspection.Application.Mapping.Accounting.Payemets.CashTransfers
{
    public class CashTransferMappingProfile : Profile
    {
        public CashTransferMappingProfile()
        {
            // -------------------- READ --------------------

            CreateMap<CashTransfer, CashTransferDto>();
            CreateMap<CashTransferLine, CashTransferLineDto>();

            // -------------------- CREATE --------------------

            CreateMap<CashTransferCreateDto, CashTransfer>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CashTransferLines, opt => opt.Ignore());

            CreateMap<CashTransferLineCreateDto, CashTransferLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CashTransfer, opt => opt.Ignore());

            // -------------------- UPDATE --------------------

            CreateMap<CashTransferUpdateDto, CashTransfer>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CashTransferLines, opt => opt.Ignore());

            CreateMap<CashTransferLineUpdateDto, CashTransferLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CashTransfer, opt => opt.Ignore());
        }
    }
}