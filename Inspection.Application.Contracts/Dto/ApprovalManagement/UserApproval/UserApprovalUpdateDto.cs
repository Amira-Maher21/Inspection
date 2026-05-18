namespace Inspection.Application.Contracts.Dto.ApprovalManagement.UserApproval
{
    public class UserApprovalUpdateDto
    {
        public long Id { get; set; }

        public string ScreenId { get; set; } = null!;

        public string? TableMasterName { get; set; }

        public string? Keys { get; set; }

        public string? Values { get; set; }

        public string? ScreenName { get; set; }

        public DateTime Date { get; set; }

        public string? Descrp { get; set; }

        public string? RepFileName { get; set; }

        /// <summary>
        /// 0 Initialized 1 New 2 Approved 3 Rejected 4 Returned 5 Hold 6 Delegate 7 Completed 8 Sent
        /// </summary>
        public int? Status { get; set; }

        public long? User_CodeId { get; set; }

        public long? User_CodeId_SentTo { get; set; }

        public string? Rejected_Reasons { get; set; }

        public string? Hold_Reasons { get; set; }

        public string? Returned_Reasons { get; set; }

        public string? Delegate_Reasons { get; set; }

        public long? ReturnedUser_CodeId { get; set; }

        public long? User_CodeId_Delegated { get; set; }

        public DateTime? ReceivedDate { get; set; }

        public DateTime? ActionDate { get; set; }

        public int Confirm_No { get; set; }

        public string? In_User { get; set; }
    }
}
