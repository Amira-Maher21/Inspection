using AutoMapper;
using Inspection.Application.Contracts.Event;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Query.Inventory.Transaction.GoodsReceipts;
using Inspection.Application.Contracts.Services.Inventory.System.InventoryLedgers;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Inventory.Transaction.GoodsReceipts;
using Inspection.Domain.Models.Inventory.Transaction.GoodsReceipts.GoodsReceiptLines;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Inventory.System.InventoryLedgers
{
    public class GoodsReceiptPosted_InventoryLedgerHandler
   : AccountsServiceBase, IEventHandler<GoodsReceiptPostedEvent>
    {
        private readonly IGoodsReceiptQueryRepository _grQuery;
        private readonly IInventoryLedgerService _ledgerService;
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public GoodsReceiptPosted_InventoryLedgerHandler(
            IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper,
            IExceptionManager exceptionManager,
            IExcelTemplateGenerator templateGenerator,
            ITenantResolver tenantResolver,
            IGoodsReceiptQueryRepository grQuery,
            IInventoryLedgerService ledgerService
        ) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _grQuery = grQuery;
            _ledgerService = ledgerService;
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
                    await InsertLedger(receipt, line, @event.TenantId);
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

        //الدخل اليومي
        private async Task InsertLedger(GoodsReceipt receipt, GoodsReceiptLine line, string tenantId)
        {
            //var existingLedger = await _ledgerService.GetByItemAsync(
            // itemId: line.ItemId,
            //  warehouseId: receipt.WarehouseId,
            //    warehouseLocationId: line.WarehouseLocationId
            //  );

            //if (existingLedger != null)
            //{
            //    decimal totalQty = (existingLedger.QuantityIn ?? 0) + line.Quantity;
            //    decimal totalCost = ((existingLedger.QuantityIn ?? 0) * (existingLedger.UnitCost ?? 0)) /*+ (line.Quantity * line.UnitCost)*/;
            //    decimal newUnitCost = totalQty > 0 ? totalCost / totalQty : 0;

            //    existingLedger.QuantityIn = totalQty;
            //    existingLedger.UnitCost = newUnitCost;
            //    existingLedger.PostingDate = receipt.GoodsReceiptDate;

            //    var updateDto = new InventoryLedgerUpdateDto
            //    {
            //        Id = existingLedger.Id,
            //        BranchId = existingLedger.BranchId,
            //        WarehouseId = existingLedger.WarehouseId,
            //        WarehouseLocationId = existingLedger.WarehouseLocationId,
            //        ItemId = existingLedger.ItemId,
            //        UnitOfMeasureId = existingLedger.UnitOfMeasureId,
            //        QuantityIn = totalQty,
            //        UnitCost = newUnitCost,
            //        TransactionDate = receipt.GoodsReceiptDate,
            //        SourceType = existingLedger.SourceType,
            //        ReferenceDocumentId = existingLedger.ReferenceDocumentId,
            //        CostingMethod = existingLedger.CostingMethod,
            //    };

            //    await _ledgerService.Update(updateDto);

            //}
            //else
            //{
            //    var ledger = new InventoryLedgerCreateDto
            //    {
            //        //WarehouseId = receipt.WarehouseId,
            //        WarehouseLocationId = line.WarehouseLocationId,
            //        ItemId = line.ItemId,

            //        QuantityIn = line.Quantity,
            //        QuantityOut = null,

            //        TransactionDate = receipt.GoodsReceiptDate,
            //        TransactionType = "GoodsReceipt",
            //        SourceType = "GRN",
            //        ReferenceDocumentId = receipt.Id,
            //        CostingMethod = CostingMethodEnum.Average,
            //        BranchId = (long)receipt.BranchId,
            //    };

            //    await _ledgerService.Create(ledger);
            //}
        }

    }
}