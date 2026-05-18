namespace Inspection.Application.Contracts.Dto.ApprovalManagement.LookUpDto
{
    public class ApprovalHlpScrScreenCodedApprovalLookUpDto
    {
        public string ScreenId { get; set; } = null!;
        public string Screen_Name { get; set; } = null!;
        public bool HasCondition { get; set; }
    }
}