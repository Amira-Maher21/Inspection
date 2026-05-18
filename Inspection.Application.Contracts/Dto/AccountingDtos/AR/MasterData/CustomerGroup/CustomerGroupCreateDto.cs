namespace Inspection.Application.Contracts.Dto.AccountingDtos.AR.MasterData.CustomerGroup
{
    public class CustomerGroupCreateDto
    {
        public string GroupCode { get; set; } = string.Empty;
        public string GroupName { get; set; } = string.Empty;
        public decimal? CreditLimit { get; set; }
        public long? PaymentTermsId { get; set; }

        public long? DefaultAccountGroupId { get; set; }

        public long? TaxCategoryId { get; set; }


    }
}
