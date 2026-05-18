using Inspection.Domain.Models.DMS.Tags;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.DMS.Tags
{
    public interface ITagCommandRepository : ICommandRepository<Tag>
    {
        Task<ReturnBase> DeleteById(long id);
    }
}