using Inspection.Domain.Enums;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.AccountSystemDto.DefaultAccountTypeDto
{
    public class DefaultAccountTypeReturnSearchDto
    {
        public long Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string VATOUTPUT { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public EntityType EntityType { get; private set; }


        public string ProgramId { get; set; }
        public string ProgramName { get; set; } = string.Empty;
    }
}
