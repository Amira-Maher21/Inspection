using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectorDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Inspection.Techinal.Inspector
{
    public interface IInspectorQueryRepository : IQueryRepository<Domain.Models.Inspection.Techinal.Inspectors.Inspector>
    {
        IQueryable<Domain.Models.Inspection.Techinal.Inspectors.Inspector> GetAll();
        Task<Domain.Models.Inspection.Techinal.Inspectors.Inspector?> GetById(long id);
        Task<Domain.Models.Inspection.Techinal.Inspectors.Inspector?> GetByCode(string code);
        Task<ReturnBase<IEnumerable<InspectorReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<IEnumerable<InspectorGetListDto>> GetListAsync();

    }
}