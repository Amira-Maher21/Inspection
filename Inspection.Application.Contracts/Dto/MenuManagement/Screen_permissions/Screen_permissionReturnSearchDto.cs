namespace Inspection.Application.Contracts.Dto.MenuManagement.Screen_permissions
{
    public class Screen_permissionReturnSearchDto
    {

        public string Tenant_ID { get; set; } = null!;

        public long User_group_ID { get; set; }
        public string User_group_Name { get; set; } = null!;

        public string Screen_ID { get; set; } = null!;

        public bool CanAdd { get; set; }

        public bool CanUpdate { get; set; }

        public bool CanDelete { get; set; }

        public bool CanPrice { get; set; }

        public bool CanPost { get; set; }

        public bool CanPrint { get; set; }

        public bool CanAttachment { get; set; }
    }
}
