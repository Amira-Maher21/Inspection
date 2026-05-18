 
using Inspection.Domain.Models.TestTableMasters;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Query.InspectionManagement.TestTableDetails 
{
    public interface ITestTableDetailQueryRepository : IQueryRepository<TestTableDetail>
    {
        Task<TestTableDetail?> GetByIdAsync(long id);
        //Task<ReturnBase<IEnumerable<TestTableMasterDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions);
        //Task<ReturnBase<IEnumerable<TestTableMasterDtoByInclude>>> GetListIncldeNameAsync(SqlQueryOptions sqlQueryOptions);
     
    }
}
