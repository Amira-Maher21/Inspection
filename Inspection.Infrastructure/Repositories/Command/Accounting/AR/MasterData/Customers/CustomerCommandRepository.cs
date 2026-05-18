using Inspection.Application.Contracts.Repositories.Command.Accounting.AR.MasterData;
using Inspection.Domain.Models.Accounting.AR.MasterData;
using Inspection.Domain.Models.InspectionManagement.CustomerLocations;
using Inspection.Domain.Models.InspectionManagement.CustomerProjects;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.Accounting.AR.MasterData.Customers
{
    public class CustomerCommandRepository : CommandRepositoryBase<Customer>, ICustomerCommandRepository
    {
        public CustomerCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
        {

            _entityStructure = new EntityStructure
            {
                Key = ["Id"]
            };
        }






        public async Task<ReturnBase> DeleteById(long id)
        {
            var entity = await _dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (entity is null)
            {
                var error = new ReturnBaseError
                {
                    ErrorCode = "404",
                    ErrorMessage = "Country Not Found"
                };
                var listOfErrors = new List<ReturnBaseError>() { error };
                return ReturnBase.Fail(listOfErrors);
            }
            _dbSet.Remove(entity);
            return ReturnBase.Success();
        }









        public async Task<ReturnBase> DeleteCustomerContactsByCustomerId(long customerId)
        {
            var items = await _context.Set<CustomerContact>()
                .Where(x => x.CustomerId == customerId)
                .ToListAsync();

            if (items.Any())
                _context.Set<CustomerContact>().RemoveRange(items);

            return ReturnBase.Success();
        }

        public async Task<ReturnBase> DeleteCustomerContactsByIds(List<long> ids)
        {
            var items = await _context.Set<CustomerContact>()
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            if (items.Any())
                _context.Set<CustomerContact>().RemoveRange(items);

            return ReturnBase.Success();
        }

        // ===================== LOCATIONS =====================
        public async Task<ReturnBase> DeleteCustomerLocationsByCustomerId(long customerId)
        {
            var items = await _context.Set<CustomerLocation>()
                .Where(x => x.CustomerId == customerId)
                .ToListAsync();

            if (items.Any())
                _context.Set<CustomerLocation>().RemoveRange(items);

            return ReturnBase.Success();
        }

        public async Task<ReturnBase> DeleteCustomerLocationsByIds(List<long> ids)
        {
            var items = await _context.Set<CustomerLocation>()
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            if (items.Any())
                _context.Set<CustomerLocation>().RemoveRange(items);

            return ReturnBase.Success();
        }

        // ===================== PROJECTS =====================
        public async Task<ReturnBase> DeleteCustomerProjectsByCustomerId(long customerId)
        {
            var items = await _context.Set<CustomerProject>()
                .Where(x => x.CustomerId == customerId)
                .ToListAsync();

            if (items.Any())
                _context.Set<CustomerProject>().RemoveRange(items);

            return ReturnBase.Success();
        }

        public async Task<ReturnBase> DeleteCustomerProjectsByIds(List<long> ids)
        {
            var items = await _context.Set<CustomerProject>()
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            if (items.Any())
                _context.Set<CustomerProject>().RemoveRange(items);

            return ReturnBase.Success();
        }





    }
}