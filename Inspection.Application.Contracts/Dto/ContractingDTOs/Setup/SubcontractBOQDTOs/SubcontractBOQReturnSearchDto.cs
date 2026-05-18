using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.SubcontractBOQDTOs.SubcontractBOQLineDTOs;
using Inspection.Domain.Enums.Contracting.Setup.SubcontractBOQs;

namespace Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.SubcontractBOQDTOs
{
    public class SubcontractBOQReturnSearchDto
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }

        public long OperationId { get; set; }
        public string OperationCode { get; set; } = string.Empty;
        public string OperationName { get; set; } = string.Empty;

        public string SubcontractBOQNumber { get; set; } = string.Empty;
        public float RevisionNumber { get; set; }
        public SubcontractBOQDocumentStatus DocumentStatus { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

        public ICollection<SubcontractBOQLineDto> SubcontractBOQLines { get; set; } = new List<SubcontractBOQLineDto>();
    }
}
