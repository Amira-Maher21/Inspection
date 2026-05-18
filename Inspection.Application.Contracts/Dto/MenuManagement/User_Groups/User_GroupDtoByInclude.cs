using Inspection.Application.Contracts.Dto.MenuManagement.Screen_permissions;
using Inspection.Application.Contracts.Dto.MenuManagement.User_Code_dGroups;
using Inspection.Domain.Models.MenuManagement;

namespace Inspection.Application.Contracts.Dto.MenuManagement.User_Groups
{
    public class User_GroupDtoByInclude
    {
        public string Tenant_ID { get; set; } = null!;

        public long User_group_ID { get; set; }

        public string User_group_Name { get; set; } = null!;

        public virtual ICollection<Screen_permissionDtoByInclude> Screen_permissions { get; set; } = new List<Screen_permissionDtoByInclude>();

        public virtual Tenant_Code Tenant { get; set; } = null!;

        public virtual ICollection<User_Code_dGroupDtoByInclude> User_Code_dGroups { get; set; } = new List<User_Code_dGroupDtoByInclude>();
    }
}
