namespace Inspection.Domain.Models.MenuManagement
{
    public class User_Code_dGroup
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = null!;

        public long User_CodeId { get; set; }
        public long User_group_ID { get; set; }

        public virtual User_Code User_Code { get; set; } = null!;

        public virtual User_Group User_Group { get; set; } = null!;
    }
}
