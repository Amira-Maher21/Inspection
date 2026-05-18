namespace Inspection.Application.Contracts.Dto.ApprovalManagement.ApprovalDelegation
{
    public class ApprovalDelegationUpdateDto
    {
        public long ID { get; set; }
        public long IDScrAproval { get; set; }
        public long User_CodeId { get; set; }
        public long User_CodeId_Delegated { get; set; } 
        public DateTime? To_Date { get; set; }
    }
}
