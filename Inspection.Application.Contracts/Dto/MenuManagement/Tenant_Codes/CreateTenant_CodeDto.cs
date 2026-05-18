using Inspection.Application.Contracts.Dto.MenuManagement.User_Codes;
using Inspection.Application.Contracts.Dto.MenuManagement.User_Groups;

namespace Inspection.Application.Contracts.Dto.MenuManagement.Tenant_Codes
{
    public class CreateTenant_CodeDto
    {
        //public string Tenant_ID { get; set; } = null!;

        public string Tenant_Name { get; set; } = null!;

        public string LocaleCode { get; set; } = null!;

        public virtual ICollection<CreateUser_CodeDto> User_Codes { get; set; } = new List<CreateUser_CodeDto>();

        public virtual ICollection<CreateUser_GroupDto> User_Groups { get; set; } = new List<CreateUser_GroupDto>();
    }
}
