using Inspection.Domain.Models.Accounting.PR.MasterData.Suppliers;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspection.Domain.Models.Accounting.PR.MasterData.SupplierContacts
{
    [Table("SupplierContact")]
    public class SupplierContact : IAuditable
    {

        public long Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string? JobTitle { get; private set; }
        public string? Phone { get; private set; }
        public string? Mobile { get; private set; }
        public string? Email { get; private set; }
        public string? Fax { get; private set; }
        public string? Department { get; private set; }
        public bool IsPrimary { get; private set; }
        public string Notes { get; private set; } = string.Empty;


        //Fk
        public long SupplierId { get; set; }
        public Supplier Supplier { get; private set; } = null!;
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }


        public void SetAsNotPrimary()
        {
            IsPrimary = false;
        }

    }
}
