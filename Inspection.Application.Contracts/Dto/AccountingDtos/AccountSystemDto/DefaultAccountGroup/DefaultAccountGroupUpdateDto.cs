using Inspection.Domain.Enums;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.AccountSystemDto.DefaultAccountGroup
{
    public class DefaultAccountGroupUpdateDto
    {
        public long Id { get; set; }

        public string GroupCode { get; set; } = string.Empty;

        public string GroupName { get; set; } = string.Empty;
        public EntityType EntityType { get; set; }
    }
}
