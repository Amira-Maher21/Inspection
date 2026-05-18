namespace Inspection.Application.Contracts.Dto.AccountingDtos.AR.MasterData.CustomerContacts
{
    public class CustomerContactCreateDto
    {
        public long CustomerId { get; set; }
        public string ContactName { get; set; } = null!;
        public string? JobTitle { get; set; }
        public string? Phone { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? Fax { get; set; }
        public long? DepartmentId { get; set; }
        public bool IsPrimary { get; set; }
        public string? Notes { get; set; }
    }
}
