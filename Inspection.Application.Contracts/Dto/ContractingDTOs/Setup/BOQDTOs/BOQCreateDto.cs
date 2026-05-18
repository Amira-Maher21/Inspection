using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.BOQDTOs.BOQLineDTOs;
using Inspection.Domain.Enums.Contracting.Setup.BOQs;

namespace Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.BOQDTOs
{
    public class BOQCreateDto
    {
        public long CompanyId { get; set; }
        public long OperationId { get; set; }
        public string BOQNumber { get; set; } = string.Empty;
        public float RevisionNumber { get; set; }
        public BOQDocumentStatus DocumentStatus { get; set; }

        public ICollection<BOQLineCreateDto> BOQLines { get; set; } = new List<BOQLineCreateDto>();
    }
}