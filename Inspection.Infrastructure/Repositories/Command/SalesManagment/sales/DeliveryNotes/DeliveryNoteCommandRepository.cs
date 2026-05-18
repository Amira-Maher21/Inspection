using Inspection.Application.Contracts.Repositories.Command.SalesManagment.sales.DeliveryNotes;
using Inspection.Domain.Models.SalesManagment.Transaction.DeliveryNotes;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.SalesManagment.sales.DeliveryNotes
{

    public class DeliveryNoteCommandRepository : CommandRepositoryBase<DeliveryNote>, IDeliveryNoteCommandRepository
    {
        public DeliveryNoteCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
        {
            _entityStructure = new EntityStructure
            {
                Key = ["Id"]
            };
        }

        public async Task<ReturnBase> DeleteById(long Id)
        {
            var entity = await _dbSet.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (entity is null)
            {
                var error = new ReturnBaseError
                {
                    ErrorCode = "404",
                    ErrorMessage = "Delivery Note Detail Not Found"
                };
                var listOfErrors = new List<ReturnBaseError>() { error };
                return ReturnBase.Fail(listOfErrors);
            }
            _dbSet.Remove(entity);
            return ReturnBase.Success();
        }


        public async Task<ReturnBase> DeleteDeliveryNoteLinesByDeliveryNoteId(long DeliveryNoteId)

        {
            var items = await _context.Set<DeliveryNoteLine>()
                .Where(x => x.Id == DeliveryNoteId)
                .ToListAsync();

            if (items.Any())
                _context.Set<DeliveryNoteLine>().RemoveRange(items);

            return ReturnBase.Success();
        }

        public async Task<ReturnBase> DeleteDeliveryNoteLinesByIds(List<long> ids)
        {
            var items = await _context.Set<DeliveryNoteLine>()
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            if (items.Any())
                _context.Set<DeliveryNoteLine>().RemoveRange(items);

            return ReturnBase.Success();
        }




    }

}
