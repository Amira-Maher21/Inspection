namespace Inspection.Application.Contracts.Dto.AccountingDtos.AR.MasterData.CustomerGroup
{
    public class CustomerGroupReturnSearchDto
    {
        public long Id { get; set; }
        public string GroupCode { get; set; } = string.Empty;
        public string GroupName { get; set; } = string.Empty;
        public decimal? CreditLimit { get; set; }

        // PaymentTerm info
        public long? PaymentTermsId { get; set; }
        public string PaymentTermName { get; set; } = string.Empty;
        public string PaymentTermCode { get; set; } = string.Empty;

        // DefaultAccountGroup info
        public long? DefaultAccountGroupId { get; set; }
        public string DefaultAccountGroupName { get; set; } = string.Empty;
        public string DefaultAccountGroupCode { get; set; } = string.Empty;

        // TaxCategory info
        public long? TaxCategoryId { get; set; }
        public string TaxCategoryName { get; set; } = string.Empty;
        public string TaxCategoryCode { get; set; } = string.Empty;




    }
}
