using Inspection.Domain.Enums.DMS.DocumentEnums;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;

namespace Inspection.Domain.Models.DMS.Documents
{
    public class DocumentEntityLink : IRootEntity, IAuditable
    {
        public long Id { get; private set; }

        // FK
        public long DocumentId { get; set; }
        public Document Document { get; set; } = null!;

        // ERP Linking
        public string ScreenId { get; private set; } = string.Empty;
        public string EntityId { get; private set; } = string.Empty;
        public string? EntityName { get; private set; }

        public LinkedEntityType LinkedEntityType { get; set; }
        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}