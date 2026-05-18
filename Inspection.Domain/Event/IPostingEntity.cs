using Inspection.Domain.Enums.Posting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Domain.Event
{
    public interface IPostingEntity
    {
        long Id { get; }
        //DateTime PostingDate { get; }
        string DocumentCode { get; }
        PostingEnum Posting { get; }
        string Tenant_ID { get; set; }
        long CurrencyId { get; set; }
        long CompanyId { get; set; }
        long BranchId { get; }
        //decimal TotalDebit { get; set; }
        //decimal TotalCredit { get; set; }
        //decimal ExchangeRate { get; set; }
    }
}
