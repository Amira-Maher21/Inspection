namespace Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.Activitys
{
    public class ActivityReturnSearchDto
    {
        public long Id { get; set; }

        // FK
        public long OperationId { get; set; }
        public string OperationName { get; set; }
        public string OperationCode { get; set; }

        public long WBSId { get; set; }
        public string WBSCode { get; set; } = string.Empty;
        public string WBSName { get; set; } = string.Empty;

        // Required Fields
        public string ActivityCode { get; set; } = string.Empty;
        public string ActivityName { get; set; } = string.Empty;

        // Optional Fields
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public decimal? PlannedCost { get; set; }
        public decimal? ProgressPercent { get; set; }


        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }


        public long CompanyId { get; set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }

        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
