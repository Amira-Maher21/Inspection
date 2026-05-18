namespace Inspection.Application.Contracts.Dto.ApprovalManagement
{
    public class ApprovalUpdateDto
    {
        public long Id { get; set; }
        public string ScreenId { get; set; } = null!;
        public bool Active { get; set; }
        public string? WorkFlowTitle { get; set; }
        //public IEnumerable<ApprovalDelegationUpdateDto>? ApprovalDelegations { get; set; }
        public IEnumerable<ApprovalDUpdateDto>? ApprovalDs { get; set; }
    }
    //public class ApprovalDelegationUpdateDto
    //{
    //    public long ID { get; set; }
    //    public long IDScrAproval { get; set; }
    //    public string User_ID { get; set; } = null!;
    //    public string User_ID_Delegated { get; set; } = null!;
    //    public DateTime? To_Date { get; set; }

    //}
    public class ApprovalDUpdateDto
    {
        public long IDScrAproval { get; set; }
        public int RecordID { get; set; }
        public string Approval_title { get; set; } = null!;
        public long User_CodeId { get; set; }
        public bool HasCondition { get; set; }
        public decimal? From_Val { get; set; }
        public decimal? To_Val { get; set; }
        public bool Deactivate { get; set; }
        public DateTime? To_Date { get; set; }
    }
}