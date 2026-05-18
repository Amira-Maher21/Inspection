using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.CommitmentDTOs.CommitmentLineDTOs;
using Inspection.Domain.Enums.Accounting.payments.JournalEntrys;
using Inspection.Domain.Enums.Contracting.Setup.Commitments;

namespace Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.CommitmentDTOs
{
    public class CommitmentReturnSearchDto
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public long OperationId { get; set; }
        public CommitmentType CommitmentType { get; set; }
        public string DocumentNo { get; set; } = string.Empty;
        public long SupplierId { get; set; }
        public string SupplierName { get; set; } = string.Empty;
        public string SupplierCode { get; set; } = string.Empty;
        public DateTime CommitmentDate { get; set; }
        public DocumentStatus DocumentStatus { get; set; }
        public decimal TotalAmount { get; set; }

        public ICollection<CommitmentLineDto> CommitmentLines { get; set; } = new List<CommitmentLineDto>();

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}