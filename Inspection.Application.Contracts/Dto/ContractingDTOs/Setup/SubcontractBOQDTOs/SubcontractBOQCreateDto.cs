using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.SubcontractBOQDTOs.SubcontractBOQLineDTOs;
using Inspection.Domain.Enums.Contracting.Setup.SubcontractBOQs;

namespace Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.SubcontractBOQDTOs
{
    public class SubcontractBOQCreateDto
    {
        public long CompanyId { get; set; }
        public long OperationId { get; set; }
        public string SubcontractBOQNumber { get; set; } = string.Empty;
        public float RevisionNumber { get; set; }
        public SubcontractBOQDocumentStatus DocumentStatus { get; set; }

        public ICollection<SubcontractBOQLineCreateDto> SubcontractBOQLines { get; set; } = new List<SubcontractBOQLineCreateDto>();
    }
}