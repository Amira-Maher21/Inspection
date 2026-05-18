
using Inspection.Application.Contracts.Dto.MenuManagement.User_Code_dGroups;

namespace Inspection.Application.Contracts.Dto.MenuManagement.User_Codes
{
    public class CreateUser_CodeDto
    {
        public string User_ID { get; set; } = null!;

        public string User_Name { get; set; } = null!;
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool System_Owner { get; set; }
        public bool System_Administrator { get; set; }
        public virtual ICollection<CreateUser_Code_dGroupDto> User_Code_dGroups { get; set; } = new List<CreateUser_Code_dGroupDto>();
    }
}