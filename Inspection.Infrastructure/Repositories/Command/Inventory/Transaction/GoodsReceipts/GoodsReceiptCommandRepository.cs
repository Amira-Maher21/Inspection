using Inspection.Application.Contracts.Repositories.Command.Inventory.Transaction.GoodsReceipts;
using Inspection.Domain.Models.Inventory.Transaction.GoodsReceipts;
using Inspection.Domain.Models.Inventory.Transaction.GoodsReceipts.GoodsReceiptLines;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.Inventory.Transaction.GoodsReceipts
{

    public class GoodsReceiptCommandRepository : CommandRepositoryBase<GoodsReceipt>, IGoodsReceiptCommandRepository
    {
        public GoodsReceiptCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
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
                    ErrorMessage = " GoodsReceipt Not Found"
                };
                var listOfErrors = new List<ReturnBaseError>() { error };
                return ReturnBase.Fail(listOfErrors);
            }
            _dbSet.Remove(entity);
            return ReturnBase.Success();
        }

        public async Task<ReturnBase> DeleteGoodsReceiptLineByItemGoodsReceiptId(long GoodsReceiptId)
        {
            var GoodsReceiptLines = await _context.Set<GoodsReceiptLine>()
                .Where(v => v.GoodsReceiptId == GoodsReceiptId)
                .ToListAsync();

            if (!GoodsReceiptLines.Any())
                return ReturnBase.Success();

            _context.Set<GoodsReceiptLine>().RemoveRange(GoodsReceiptLines);

            return ReturnBase.Success();
        }
        public async Task<ReturnBase> DeleteGoodsReceiptLineByIds(List<long> ids)
        {
            var GoodsReceiptLines = await _context.Set<GoodsReceiptLine>()
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            _context.Set<GoodsReceiptLine>().RemoveRange(GoodsReceiptLines);

            return ReturnBase.Success();
        }
    }
}