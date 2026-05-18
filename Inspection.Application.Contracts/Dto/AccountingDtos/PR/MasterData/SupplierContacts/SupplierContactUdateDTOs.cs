using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.PR.MasterData.SupplierContacts
{
    public class SupplierContactUdateDTOs
    {
        public long Id { get;   set; }
        public string Name { get;   set; }
        public string? JobTitle { get;   set; }
        public string? Phone { get;   set; }
        public string? Mobile { get;   set; }
        public string? Email { get;   set; }
        public string? Fax { get;   set; }
        public string? Department { get;   set; }
        public bool IsPrimary { get;   set; }
        public string Notes { get;   set; }


        //Fk
        public long supplierId { get;   set; }
    }
}
