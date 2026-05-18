using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.SubcontractBOQDTOs.SubcontractBOQLineDTOs;
using Inspection.Domain.Enums.Contracting.Setup.SubcontractBOQs;

namespace Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.SubcontractBOQDTOs
{
    public class SubcontractBOQUpdateDto
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public long OperationId { get; set; }
        public string SubcontractBOQNumber { get; set; } = string.Empty;
        public float RevisionNumber { get; set; }
        public SubcontractBOQDocumentStatus DocumentStatus { get; set; }

        public ICollection<SubcontractBOQLineUpdateDto> SubcontractBOQLines { get; set; } = new List<SubcontractBOQLineUpdateDto>();
    }
}
