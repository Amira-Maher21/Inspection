using NDS.Shared.Domain.Contracts;

namespace Inspection.Domain.Models.MenuManagement
{
    public class Screen_permission : IRootEntity
    {
        public string Tenant_ID { get; set; } = null!;

        public long User_group_ID { get; set; }

        public string Screen_ID { get; set; } = null!;

        public bool CanAdd { get; set; }

        public bool CanUpdate { get; set; }

        public bool CanDelete { get; set; }

        public bool CanPrice { get; set; }

        public bool CanPost { get; set; }

        public bool CanPrint { get; set; }

        public bool CanAttachment { get; set; }

        public virtual User_Group User_Group { get; set; } = null!;
    }
}
