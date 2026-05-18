using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.CommitmentDTOs.CommitmentLineDTOs;
using Inspection.Domain.Enums.Accounting.payments.JournalEntrys;
using Inspection.Domain.Enums.Contracting.Setup.Commitments;

namespace Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.CommitmentDTOs
{
    public class CommitmentUpdateDto
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public long OperationId { get; set; }
        public CommitmentType CommitmentType { get; set; }
        public string DocumentNo { get; set; } = string.Empty;
        public long SupplierId { get; set; }
        public DateTime CommitmentDate { get; set; }
        public DocumentStatus DocumentStatus { get; set; }
        public decimal TotalAmount { get; set; }

        public ICollection<CommitmentLineUpdateDto> CommitmentLines { get; set; } = new List<CommitmentLineUpdateDto>();
    }
}