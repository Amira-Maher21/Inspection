namespace Inspection.Application.Contracts.Dto.ApprovalManagement.LookUpDto
{
    public class ApprovalUser_CodeDLookUpDto
    {
        public long id { get; set; }
        public long User_CodeId { get; set; }
        public string User_Name { get; set; } = null!;
    }
}
