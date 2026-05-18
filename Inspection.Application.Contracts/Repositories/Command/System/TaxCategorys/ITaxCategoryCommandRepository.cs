using Inspection.Domain.Models.System.Taxestegories;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.System.TaxCategorys
{
    public interface ITaxCategoryCommandRepository : ICommandRepository<TaxCategory>
    {

        Task<ReturnBase> DeleteById(long id);

    }
}
