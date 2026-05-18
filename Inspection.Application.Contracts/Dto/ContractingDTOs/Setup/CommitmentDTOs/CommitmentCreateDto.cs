using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.CommitmentDTOs.CommitmentLineDTOs;
using Inspection.Domain.Enums.Accounting.payments.JournalEntrys;
using Inspection.Domain.Enums.Contracting.Setup.Commitments;

namespace Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.CommitmentDTOs
{
    public class CommitmentCreateDto
    {
        public long CompanyId { get; set; }
        public long OperationId { get; set; }
        public CommitmentType CommitmentType { get; set; }
        public string DocumentNo { get; set; } = string.Empty;
        public long SupplierId { get; set; }
        public DateTime CommitmentDate { get; set; }
        public DocumentStatus DocumentStatus { get; set; }
        public decimal TotalAmount { get; set; }

        public ICollection<CommitmentLineCreateDto> CommitmentLines { get; set; } = new List<CommitmentLineCreateDto>();
    }
}