using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.BOQDTOs.BOQLineDTOs;
using Inspection.Domain.Enums.Contracting.Setup.BOQs;

namespace Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.BOQDTOs
{
    public class BOQDto
    {
        public long Id { get; set; }

        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }
        public long OperationId { get; set; }
        public string BOQNumber { get; set; } = string.Empty;
        public float RevisionNumber { get; set; }
        public BOQDocumentStatus DocumentStatus { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

        public ICollection<BOQLineDto> BOQLines { get; set; } = new List<BOQLineDto>();
    }
}