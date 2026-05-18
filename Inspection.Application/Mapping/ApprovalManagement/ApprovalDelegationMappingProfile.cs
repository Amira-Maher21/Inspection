using AutoMapper;
using Inspection.Application.Contracts.Dto.ApprovalManagement.ApprovalDelegation;
using Inspection.Domain.Models.ApprovalManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Mapping.ApprovalManagement
{
    public class ApprovalDelegationMappingProfile : Profile
    {
        public ApprovalDelegationMappingProfile()
        {
            this.CreateMap<Approval_Delegation, ApprovalDelegationIndexItemDto>().ReverseMap();
            this.CreateMap<Approval_Delegation, ApprovalDelegationInsertDto>().ReverseMap();
            this.CreateMap<Approval_Delegation, ApprovalDelegationUpdateDto>().ReverseMap();
        }
    }
}
