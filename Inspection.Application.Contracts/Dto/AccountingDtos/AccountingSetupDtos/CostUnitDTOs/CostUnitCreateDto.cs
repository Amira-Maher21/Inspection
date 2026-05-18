namespace Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.CostUnitDTOs
{
    public class CostUnitCreateDto
    {
        public long CompanyId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public bool IsMain { get; set; } = true;
        public long? ParentCostUnitId { get; set; }

    }
}
