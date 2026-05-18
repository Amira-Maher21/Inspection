using Inspection.Domain.Enums;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.AccountSystemDto.DefaultAccountGroup
{
    public class DefaultAccountGroupDto
    {
        public long Id { get; set; }

        public string GroupCode { get; set; } = string.Empty;

        public string GroupName { get; set; } = string.Empty;
        public EntityType EntityType { get; set; }
        // Audit 
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
