using NDS.Shared.Domain.Contracts;

namespace Inspection.Domain.Models.MenuManagement
{
    public class User_Group : IRootEntity
    {
        public long User_group_ID { get; set; }
        public string User_group_Name { get; set; } = null!;
        public string Tenant_ID { get; set; } = null!;
        public List<Screen_permission> Screen_permissions { get; set; } = new List<Screen_permission>();
        public List<User_Code_dGroup> User_Code_dGroups { get; set; } = new List<User_Code_dGroup>();
        public virtual Tenant_Code Tenant { get; set; } = null!;
    }
}
