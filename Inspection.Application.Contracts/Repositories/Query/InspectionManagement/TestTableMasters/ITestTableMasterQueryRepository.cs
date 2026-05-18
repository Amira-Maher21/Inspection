using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequests;
using Inspection.Domain.Models.InspectionManagement.InspectionRequests;
using Inspection.Domain.Models.TestTableMaster;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Query.InspectionManagement.TestTableMasters
{
    public interface ITestTableMasterQueryRepository : IQueryRepository<TestTableMaster>
    {
        Task<TestTableMaster?> GetByIdAsync(long id);
        //Task<ReturnBase<IEnumerable<TestTableMasterDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions);
        //Task<ReturnBase<IEnumerable<TestTableMasterDtoByInclude>>> GetListIncldeNameAsync(SqlQueryOptions sqlQueryOptions);
     
    }
}
