using Inspection.Application.Contracts.Dto.MenuManagement.Programs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.MenuManagement.Programs
{
    public interface IProgramService
    {

        Task<ReturnBase<IEnumerable<ProgramDto>>> GetList(SqlQueryOptions? sqlQueryOptions = null);

    }
}
