namespace Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.CostCenterDTOs
{
    public class CostCenterImportTemplateDto
    {
        public long? ParentCostCenterCode { get; set; }
        public long CompanyCode { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public bool IsMain { get; set; }
        public long? DepartmentCode { get; set; }


    }
}
