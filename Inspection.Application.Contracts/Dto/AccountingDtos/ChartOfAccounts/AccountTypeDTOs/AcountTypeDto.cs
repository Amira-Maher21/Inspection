namespace Inspection.Application.Contracts.Dto.AccountingDtos.ChartOfAccounts.AccountTypeDTOs
{
    public class AcountTypeDto
    {
        public string AccountTypeCode { get; set; } = string.Empty;
        public string AccountTypeName { get; set; } = string.Empty;
        public string? ParentAccountType { get; set; } = string.Empty;
    }
}