using Inspection.Application.Contracts.Dto.MenuManagement.Screen_permissions;
using Inspection.Application.Contracts.Dto.MenuManagement.User_Code_dGroups;

namespace Inspection.Application.Contracts.Dto.MenuManagement.User_Groups
{

    public class UpdateUser_GroupDto
    {
        public long User_group_ID { get; set; }
        public string User_group_Name { get; set; } = null!;

        public List<UpdateScreen_permissionDto> Screen_permissions { get; set; } = new List<UpdateScreen_permissionDto>();
        public List<UpdateUser_Code_dGroupDto> User_Code_dGroups { get; set; } = new List<UpdateUser_Code_dGroupDto>();



    }
}
