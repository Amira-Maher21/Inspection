using Inspection.Application.Contracts.Dto.MenuManagement.User_Codes;
using Inspection.Application.Contracts.Dto.MenuManagement.User_Groups;

namespace Inspection.Application.Contracts.Dto.MenuManagement.Tenant_Codes
{
    public class Tenant_CodeDtoByInclude
    {
        public string Tenant_ID { get; set; } = null!;

        public string Tenant_Name { get; set; } = null!;

        public string LocaleCode { get; set; } = null!;

        public virtual ICollection<User_CodeDtoByInclude> User_Codes { get; set; } = new List<User_CodeDtoByInclude>();

        public virtual ICollection<User_GroupDtoByInclude> User_Groups { get; set; } = new List<User_GroupDtoByInclude>();

    }
}
