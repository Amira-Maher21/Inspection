using Inspection.Application.Contracts.Dto.AccountingDtos.AccountSystemDto.DefaultAccountTypeDto;
using Inspection.Domain.Models.Accounting.AccountingSystem;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSystem
{
    public interface IDefaultAccountTypeQueryRepository : IQueryRepository<DefaultAccountType>
    {
        Task<DefaultAccountType?> GetById(long id);
        Task<ReturnBase<List<DefaultAccountType>>> GetAll();
        Task<ReturnBase<IEnumerable<DefaultAccountTypeReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
