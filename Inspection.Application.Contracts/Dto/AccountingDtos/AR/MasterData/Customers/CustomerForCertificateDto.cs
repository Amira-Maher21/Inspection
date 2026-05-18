using Inspection.Domain.Enums.Accounting;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.AR.MasterData.Customers
{
    public class CustomerForCertificateDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public CustomerTypeEnum? CustomerType { get; set; }

        public string Code { get; set; } = null!;
        public string? NationalId { get; set; }
        public string? TaxRegistrationNo { get; set; }
        public string? CommercialRegistryNo { get; set; }
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
    }
}
