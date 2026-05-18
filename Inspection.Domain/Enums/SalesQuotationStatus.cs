namespace Inspection.Domain.Enums
{
    public class ChangeStatusRequest
    {
        public SalesQuotationStatus ApprovalStatus { get; set; }
    }
    public enum SalesQuotationStatus
    {
        Draft = 1,
        Submitted,
        UnderReview,
        Approved,
        Rejected,
        Expired
    }

}
