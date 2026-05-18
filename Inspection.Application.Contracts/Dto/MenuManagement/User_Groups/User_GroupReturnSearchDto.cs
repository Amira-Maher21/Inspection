using Inspection.Application.Contracts.Dto.MenuManagement.Screen_permissions;
using Inspection.Application.Contracts.Dto.MenuManagement.User_Code_dGroups;

namespace Inspection.Application.Contracts.Dto.MenuManagement.User_Groups
{
    public class User_GroupReturnSearchDto
    {
        public long User_group_ID { get; set; }
        public string User_group_Name { get; set; } = null!;


        public string Tenant_ID { get; set; } = null!;
        public string Tenant_Name { get; set; } = null!;
        public string LocaleCode { get; set; } = null!;



        public List<CreateScreen_permissionDto> Screen_permissions { get; set; } = new List<CreateScreen_permissionDto>();
        public List<CreateUser_Code_dGroupDto> User_Code_dGroups { get; set; } = new List<CreateUser_Code_dGroupDto>();

    }
}
