namespace Inspection.Application.Contracts.Dto.ApprovalManagement.LookUpDto
{
    public class ApprovalUserCountLookUpDto
    {
        public string ScreenId { get; set; } = null!;
        public string? ScreenName { get; set; }
        public int User_ID_Count { get; set; }
    }
}