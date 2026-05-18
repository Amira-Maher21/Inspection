using Inspection.Application.Contracts.Repositories.Command.Accounting.PR.MasterData.Suppliers;
using Inspection.Domain.Models.Accounting.PR.MasterData.SupplierContacts;
using Inspection.Domain.Models.Accounting.PR.MasterData.Suppliers;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.Accounting.PR.MasterData.Suppliers
{
    public class SupplierCommandRepository : CommandRepositoryBase<Supplier>, ISupplierCommandRepository
    {
        public SupplierCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager)
            : base(context, tenantResolver, exceptionManager)
        {
            _entityStructure = new EntityStructure
            {
                Key = ["Id"]
            };
        }

        // ===================== HARD DELETE =====================
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


        // ===================== CONTACTS =====================
        public async Task<ReturnBase> DeleteSupplierContactsBySupplierId(long supplierId)
        {
            var items = await _context.Set<SupplierContact>()
                .Where(x => x.SupplierId == supplierId)
                .ToListAsync();

            if (items.Any())
                _context.Set<SupplierContact>().RemoveRange(items);

            return ReturnBase.Success();
        }

        public async Task<ReturnBase> DeleteSupplierContactsByIds(List<long> ids)
        {
            var items = await _context.Set<SupplierContact>()
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            if (items.Any())
                _context.Set<SupplierContact>().RemoveRange(items);

            return ReturnBase.Success();
        }
    }
}
