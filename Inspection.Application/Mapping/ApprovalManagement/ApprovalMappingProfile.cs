using AutoMapper;
using Inspection.Application.Contracts.Dto.ApprovalManagement;
using Inspection.Domain.Models.ApprovalManagement;

namespace Inspection.Application.Mapping.ApprovalManagement
{
    public class ApprovalMappingProfile : Profile
    {
        public ApprovalMappingProfile()
        {
            // -------------------- READ --------------------

            CreateMap<Approval, ApprovalDto>()
                .ForMember(d => d.ApprovalDs,
                           opt => opt.MapFrom(src => src.Approval_ds));

            CreateMap<Approval_d, ApprovalDDto>();


            // -------------------- CREATE --------------------

            CreateMap<ApprovalInsertDto, Approval>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.Approval_ds, opt => opt.Ignore()) // 🔥 IMPORTANT
                .ForMember(d => d.Approval_Delegations, opt => opt.Ignore());

            CreateMap<ApprovalDInsertDto, Approval_d>()
                .ForMember(d => d.IDScrAproval, opt => opt.Ignore()); // FK
                                                                      //.ForMember(d => d.Id, opt => opt.Ignore());


            // -------------------- UPDATE --------------------

            CreateMap<ApprovalUpdateDto, Approval>()
               .ForMember(d => d.Id, opt => opt.Ignore()) // Never overwrite PK
               .ForMember(d => d.Approval_ds, opt => opt.Ignore()) // Handle child collection manually
               .ForMember(d => d.Approval_Delegations, opt => opt.Ignore()); // Optional, depends on your logic

            CreateMap<ApprovalDUpdateDto, Approval_d>()
               .ForMember(d => d.IDScrAproval, opt => opt.Ignore()); // FK handled manually


        }
    }
}