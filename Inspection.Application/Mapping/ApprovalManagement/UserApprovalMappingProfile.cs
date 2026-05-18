using AutoMapper;
using Inspection.Application.Contracts.Dto.ApprovalManagement.UserApproval;
using Inspection.Domain.Models.ApprovalManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Mapping.ApprovalManagement
{
    public class UserApprovalMappingProfile : Profile
    {
        public UserApprovalMappingProfile()
        {
            this.CreateMap<User_Approval, UserApprovalInsertDto>().ReverseMap();

            this.CreateMap<User_Approval, UserApprovalUpdateDto>().ReverseMap();
        }
    }
}
