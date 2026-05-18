using Inspection.Application.Contracts.Dto.GenericLookupDto;
using Inspection.Application.Contracts.Repositories.Query.SharedRepository;
using Inspection.Domain.Models.GenericLookupDto;
using Inspection.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Infrastructure.Repositories.Query.SharedRepository
{
    public class genericlookuprepository<tentity, tkey> : igenericlookuprepository<tentity, tkey>
     where tentity : class, ILookupEntity<tkey>
    {
        //private readonly dbinspectioncontext _context;

        //public genericlookuprepository(dbinspectioncontext context)
        //{
        //    _context = context;
        //}


        //public async task<string?> getdisplaynamebyidasync(tkey id)
        //{
        //    var entity = await _context.set<tentity>()
        //        .asnotracking()
        //        .firstordefaultasync(e => e.id.equals(id));

        //    return entity?.name;
        //}


        //public async task<list<lookupdto<tkey>>> getlookuplistbyidsasync(list<tkey> ids)
        //{
        //    return await _context.set<tentity>()
        //        .asnotracking()
        //        .where(e => ids.contains(e.id))
        //        .select(e => new lookupdto<tkey>
        //        {
        //            id = e.id,
        //            displayname = e.name
        //        })
        //        .tolistasync();
        //}

    }

}
