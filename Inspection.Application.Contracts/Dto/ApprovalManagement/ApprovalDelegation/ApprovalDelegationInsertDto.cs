namespace Inspection.Application.Contracts.Dto.ApprovalManagement.ApprovalDelegation
{
    public class ApprovalDelegationInsertDto
    {
        public long IDScrAproval { get; set; }
        public long User_CodeId { get; set; }
        public long User_CodeId_Delegated { get; set; }
        public DateTime? To_Date { get; set; }
    }
}
