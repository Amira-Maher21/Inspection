using Inspection.Domain.Models.Accounting.AR.MasterData;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.AR.MasterData
{
    public interface ICustomerCommandRepository : ICommandRepository<Customer>
    {
        // ===== CUSTOMER =====
        Task<ReturnBase> DeleteById(long customerId);


        // ===== CONTACTS =====
        Task<ReturnBase> DeleteCustomerContactsByCustomerId(long customerId);
        Task<ReturnBase> DeleteCustomerContactsByIds(List<long> ids);

        // ===== LOCATIONS =====
        Task<ReturnBase> DeleteCustomerLocationsByCustomerId(long customerId);
        Task<ReturnBase> DeleteCustomerLocationsByIds(List<long> ids);

        // ===== PROJECTS =====
        Task<ReturnBase> DeleteCustomerProjectsByCustomerId(long customerId);
        Task<ReturnBase> DeleteCustomerProjectsByIds(List<long> ids);



    }
}
