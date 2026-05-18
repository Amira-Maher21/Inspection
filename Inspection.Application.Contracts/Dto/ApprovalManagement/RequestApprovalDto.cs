using NDS.Shared.Application.DataQuery;

namespace Inspection.Application.Contracts.Dto.ApprovalManagement
{
    public class RequestApprovalDto
    {
        public SqlQueryOptions QueryOptions { get; set; }
        public string ScreenId { get; set; } = null!;
        public long PrimaryKey_ID { get; set; }
        public DateTime Date { get; set; }
    }

    public class DoApprovalDto
    {
        public SqlQueryOptions QueryOptions { get; set; }
        public string ScreenId { get; set; } = null!;
        public long PrimaryKey_ID { get; set; }
        public DateTime Date { get; set; }

        /// <summary>
        /// 2 = Approve
        /// 3 = Reject
        /// 4 = Return
        /// 5 = Hold
        /// 6 = Delegate
        /// 7 = Complete
        /// </summary>
        public int Status { get; set; }
        public string? Rejected_Reasons { get; set; }
        public string? Hold_Reasons { get; set; }
        public string? Delegate_Reasons { get; set; }
        public long? User_CodeId_Delegated { get; set; }
        public string? Returned_Reasons { get; set; }
        public long? ReturnedUser_CodeId { get; set; }
    }
}