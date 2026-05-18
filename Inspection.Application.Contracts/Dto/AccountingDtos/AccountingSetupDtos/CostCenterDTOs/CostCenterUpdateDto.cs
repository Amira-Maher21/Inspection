namespace Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.CostCenterDTOs
{
    public class CostCenterUpdateDto
    {
        public long Id { get; set; }
        public long? ParentCostCenterId { get; set; }
        public long CompanyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public bool IsMain { get; set; }
        public long? DepartmentId { get; set; }
    }
}
