using AutoMapper;
using Inspection.Application.Contracts.Event;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Query.Inventory.Transaction.GoodsReceipts;
using Inspection.Application.Contracts.Services.Inventory.System.InventoryBalances;
using Inspection.Application.Contracts.Services.Inventory.System.InventoryCostLayers;
using Inspection.Application.Contracts.Services.Inventory.System.InventoryLedgers;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Inventory.Transaction.GoodsReceipts;
using Inspection.Domain.Models.Inventory.Transaction.GoodsReceipts.GoodsReceiptLines;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Inventory.System.InventoryBalances
{
    public class GoodsReceiptPosted_InventoryBalanceHandler
    : AccountsServiceBase, IEventHandler<GoodsReceiptPostedEvent>
    {
        private readonly IGoodsReceiptQueryRepository _grQuery;
        private readonly IInventoryBalanceService _balanceService;
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public GoodsReceiptPosted_InventoryBalanceHandler(
            IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper,
            IExceptionManager exceptionManager,
            IExcelTemplateGenerator templateGenerator,
            ITenantResolver tenantResolver,
            IGoodsReceiptQueryRepository grQuery,
            IInventoryLedgerService ledgerService,
           IInventoryCostLayersService costService,
            IInventoryBalanceService balanceService
        ) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _grQuery = grQuery;
            _balanceService = balanceService;
            _templateGenerator = templateGenerator;
        }


        public async Task Handle(GoodsReceiptPostedEvent @event)
        {
            try
            {
                var receipt = await _grQuery.GetById(@event.DocId);
                if (receipt == null)
                {
                    throw new Exception($"Goods Receipt with ID {@event.DocId} not found");
                }

                foreach (var line in receipt.GoodsReceiptLines)
                {
                    await UpdateInventoryBalance(receipt, line);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    throw new Exception($"Failed to save inventory changes: {string.Join(", ", saveResult.Errors.Select(e => e.ErrorMessage))}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GoodsReceiptPostedEventHandler: {ex.Message}", ex);
            }
        }

        private async Task UpdateInventoryBalance(GoodsReceipt receipt, GoodsReceiptLine line)
        {
            //var balance = await _balanceService.GetByKey(
            //    line.ItemId,
            //    // receipt.WarehouseId,
            //    line.WarehouseLocationId
            //);

            //if (balance == null)
            //{
            //    var createDto = new InventoryBalanceCreateDto
            //    {
            //        ItemId = line.ItemId,
            //        // WarehouseId = receipt.WarehouseId,
            //        WarehouseLocationId = line.WarehouseLocationId,
            //        BaseUoMId = line.UnitOfMeasureId,

            //        Quantity = line.Quantity,
            //        ReservedQuantity = 0,
            //        AvailableQuantity = line.Quantity,
            //    };

            //    await _balanceService.Create(createDto);
            //}
            //else
            //{
            //    // Domain Logic
            //    balance.Mod_Date = DateTime.UtcNow;
            //    balance.Mod_User = "system";

            //    var updateDto = new InventoryBalanceUpdateDto
            //    {
            //        Id = balance.Id,
            //        ItemId = balance.ItemId,
            //        WarehouseId = balance.WarehouseId,
            //        WarehouseLocationId = balance.WarehouseLocationId,
            //        BaseUoMId = balance.BaseUoMId,

            //        Quantity = balance.Quantity,
            //        ReservedQuantity = balance.ReservedQuantity,
            //        AvailableQuantity = balance.AvailableQuantity,
            //        AverageCost = balance.AverageCost
            //    };

            //    await _balanceService.Update(updateDto);
            //}
        }
    }
}