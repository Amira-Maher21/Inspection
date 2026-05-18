using Inspection.Domain.Models.MenuManagement;

namespace Inspection.Application.Contracts.Dto.MenuManagement.User_Code_dGroups
{
    public class User_Code_dGroupDtoByInclude
    {
        public string Tenant_ID { get; set; } = null!;

        public long User_CodeId { get; set; }

        public long User_group_ID { get; set; }

        public virtual User_Code User_Code { get; set; } = null!;

        public virtual User_Group User_Group { get; set; } = null!;
    }
}
