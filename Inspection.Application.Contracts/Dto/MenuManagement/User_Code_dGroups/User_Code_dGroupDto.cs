namespace Inspection.Application.Contracts.Dto.MenuManagement.User_Code_dGroups
{
    public class User_Code_dGroupDto
    {
        public string Tenant_ID { get; set; } = null!;

        public long User_CodeId { get; set; }          // لازم يكون موجود

        public long User_group_ID { get; set; }
    }
}
