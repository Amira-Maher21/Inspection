namespace Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.CostCenterDTOs
{
    public class CostCenterReturnSearchDto
    {
        public long Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public bool IsMain { get; set; }
        public long CompanyId { get; set; }
        public long? ParentCostCenterId { get; set; }
        public string? ParentCostCenterName { get; set; }

        public long? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }


    }
}
