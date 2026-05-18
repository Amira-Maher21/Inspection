using Inspection.Application.Contracts.Dto.GenericLookupDto;
using Inspection.Domain.Models.GenericLookupDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Query.SharedRepository
{
    public interface igenericlookuprepository<tentity, tkey> where tentity : class, ILookupEntity<tkey>
    {
        //task<string?> getdisplaynamebyidasync(long id);

        //task<list<lookupdto<tkey>>> getlookuplistbyidsasync(list<long> ids);
    }
}
