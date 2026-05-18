namespace Inspection.Application.Contracts.Dto.AccountingDtos.AR.MasterData.CustomerContacts
{
    public class CustomerContactDto
    {
        public long Id { get; set; }
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


        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }









    }

}
