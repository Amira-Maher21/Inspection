namespace Inspection.Application.Contracts.Dto.AccountingDtos.PR.MasterData.SupplierGroups
{
    public class SupplierGroupUpdateDto
    {
        public long Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public long? DefaultAccountGroupId { get; set; }
        public long? PaymentTermsId { get; set; }

        public long? TaxCategoryId { get; set; }

        public string Notes { get; set; } = string.Empty;

    }
}
