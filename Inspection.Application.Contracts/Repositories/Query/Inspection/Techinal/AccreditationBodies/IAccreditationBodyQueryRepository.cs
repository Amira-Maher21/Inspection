using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.AccreditationBodyDTOs;
using Inspection.Domain.Models.Inspection.Techinal.AccreditationBodies;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Inspection.Techinal.AccreditationBodies
{
    public interface IAccreditationBodyQueryRepository : IQueryRepository<AccreditationBody>
    {
        Task<AccreditationBody?> GetById(long id);
        Task<ReturnBase<IEnumerable<AccreditationBodyReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}