namespace Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.Activitys
{
    public class ActivityCreateDto
    {

        // FK
        public long OperationId { get; set; }
        public long WBSId { get; set; }

        public string ActivityCode { get; set; } = string.Empty;

        public string ActivityName { get; set; } = string.Empty;

        // Optional Fields
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public decimal? PlannedCost { get; set; }
        public decimal? ProgressPercent { get; set; }


        public long CompanyId { get; set; }


    }
}
