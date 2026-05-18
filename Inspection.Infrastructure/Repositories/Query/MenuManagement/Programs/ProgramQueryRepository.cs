using Inspection.Application.Contracts.Repositories.Query.MenuManagement.Programs;
using Inspection.Domain.Models.MenuManagement;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;

namespace Inspection.Infrastructure.Repositories.Query.MenuManagement.Programs
{



    public class ProgramQueryRepository : IProgramQueryRepository
    {
        private readonly DbContext _context;

        public ProgramQueryRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Program>> GetList(SqlQueryOptions sqlQueryOptions = null)
        {
            return await _context.Set<Program>().ToListAsync();
        }
    }



}
