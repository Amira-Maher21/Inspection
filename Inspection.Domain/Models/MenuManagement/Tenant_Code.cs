namespace Inspection.Domain.Models.MenuManagement
{
    public class Tenant_Code
    {
        public string Tenant_ID { get; set; } = null!;

        public string Tenant_Name { get; set; } = null!;

        public string LocaleCode { get; set; } = null!;

        public virtual ICollection<User_Code> User_Codes { get; set; } = new List<User_Code>();

        public virtual ICollection<User_Group> User_Groups { get; set; } = new List<User_Group>();
    }
}
