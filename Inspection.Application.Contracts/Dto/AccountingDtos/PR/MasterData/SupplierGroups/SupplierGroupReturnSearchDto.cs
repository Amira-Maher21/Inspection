namespace Inspection.Application.Contracts.Dto.AccountingDtos.PR.MasterData.SupplierGroups
{
    public class SupplierGroupReturnSearchDto
    {
        public long Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Tenant_ID { get; set; } = string.Empty;

        //DefaultAccountGroup
        public long? DefaultAccountGroupId { get; set; }
        public string GroupCode { get; set; } = null!;
        public string GroupName { get; set; } = null!;


        //PaymentTerm
        public long? PaymentTermsId { get; set; }
        public string PaymentTermCode { get; set; } = null!;
        public string PaymentTermName { get; set; } = null!;



        //TaxCategory
        public long? TaxCategoryId { get; set; }
        public string TaxCategoryCode { get; set; } = null!;
        public string TaxCategoryName { get; set; } = null!;

        public string Notes { get; set; } = string.Empty;

    }
}
