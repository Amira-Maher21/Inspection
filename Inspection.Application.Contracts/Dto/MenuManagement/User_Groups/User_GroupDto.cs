using Inspection.Application.Contracts.Dto.MenuManagement.Screen_permissions;
using Inspection.Application.Contracts.Dto.MenuManagement.User_Code_dGroups;

namespace Inspection.Application.Contracts.Dto.MenuManagement.User_Groups
{
    public class User_GroupDto
    {
        public string Tenant_ID { get; set; } = null!;

        public long User_group_ID { get; set; }

        public string User_group_Name { get; set; } = null!;



        public List<Screen_permissionDto> Screen_permissions { get; set; } = new List<Screen_permissionDto>();
        public List<User_Code_dGroupDto> User_Code_dGroups { get; set; } = new List<User_Code_dGroupDto>();
    }
}
