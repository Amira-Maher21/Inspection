using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.BOQDTOs.BOQLineDTOs;
using Inspection.Domain.Enums.Contracting.Setup.BOQs;

namespace Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.BOQDTOs
{
    public class BOQUpdateDto
    {
        public long Id { get; set; }

        public long CompanyId { get; set; }
        public long OperationId { get; set; }
        public string BOQNumber { get; set; } = string.Empty;
        public float RevisionNumber { get; set; }
        public BOQDocumentStatus DocumentStatus { get; set; }

        public ICollection<BOQLineUpdateDto> BOQLines { get; set; } = new List<BOQLineUpdateDto>();
    }
}