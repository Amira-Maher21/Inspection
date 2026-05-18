using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CompanyDTOs;
using Inspection.Domain.Models.SystemConfigurations.Companies;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.SystemConfigurations.Companies
{
    public interface ICompanyQueryRepository : IQueryRepository<Company>
    {
        Task<Company?> GetById(long id);
        Task<Company?> GetByCode(string code);
        Task<ReturnBase<IEnumerable<CompanyReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<CompanyDto>>> GetCompanyIdAndName(SqlQueryOptions queryOptions);
    }
}