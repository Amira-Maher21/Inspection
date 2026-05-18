namespace Inspection.Domain.Shared.ApprovalStatus
{
    public enum ApprovalStatus
    {
        Initialized = 0,
        New = 1,
        Approved = 2,
        Rejected = 3,
        Returned = 4,
        Hold = 5,
        Delegate = 6,
        Completed = 7,
        Sent = 8
    }
}