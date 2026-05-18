using Inspection.Domain.Models.TestTableMasters;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Command.TestTableSubDetails
{
    public interface ITestTableSubDetailsCommandRepository : ICommandRepository<TestTableSubDetail>
    {
        Task<ReturnBase> DeleteByIdAsync(long id);

    }

}
