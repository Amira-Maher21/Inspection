using Inspection.Application.Contracts.Dto.MenuManagement.User_Code_dGroups;
using Inspection.Domain.Models.MenuManagement;

namespace Inspection.Application.Contracts.Dto.MenuManagement.User_Codes
{
    public class User_CodeDtoByInclude
    {
        public long Id { get; set; }

        public string Tenant_ID { get; set; } = null!;

        public string User_ID { get; set; } = null!;

        public string User_Name { get; set; } = null!;

        public string? Email { get; set; }

        public string? Password { get; set; }

        public bool System_Owner { get; set; }

        public bool System_Administrator { get; set; }

        public virtual Tenant_Code Tenant { get; set; } = null!;

        public virtual ICollection<User_Code_dGroupDtoByInclude> User_Code_dGroups { get; set; } = new List<User_Code_dGroupDtoByInclude>();
    }
}