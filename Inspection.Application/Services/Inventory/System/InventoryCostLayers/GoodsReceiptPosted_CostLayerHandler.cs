using AutoMapper;
using Inspection.Application.Contracts.Event;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Query.Inventory.Transaction.GoodsReceipts;
using Inspection.Application.Contracts.Services.Inventory.System.InventoryCostLayers;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Inventory.Transaction.GoodsReceipts;
using Inspection.Domain.Models.Inventory.Transaction.GoodsReceipts.GoodsReceiptLines;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Inventory.System.InventoryCostLayers
{
    public class GoodsReceiptPosted_CostLayerHandler
   : AccountsServiceBase, IEventHandler<GoodsReceiptPostedEvent>
    {
        private readonly IGoodsReceiptQueryRepository _grQuery;
        private readonly IInventoryCostLayersService _costLayerService;
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public GoodsReceiptPosted_CostLayerHandler(
            IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper,
            IExceptionManager exceptionManager,
            IExcelTemplateGenerator templateGenerator,
            ITenantResolver tenantResolver,
            IGoodsReceiptQueryRepository grQuery,
            IInventoryCostLayersService costLayerService
        ) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _grQuery = grQuery;
            _costLayerService = costLayerService;
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
                    await InsertCostLayer(receipt, line, @event.TenantId);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    throw new Exception($"Failed to save inventory changes: {string.Join(", ", saveResult.Errors.Select(e => e.ErrorMessage))}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in hiii: {ex.Message}", ex);
            }
        }

        private async Task InsertCostLayer(GoodsReceipt receipt, GoodsReceiptLine line, string tenantId)
        {
            // var existingLayer = await _costLayerService.GetByKey(line.ItemId );

            //if (existingLayer != null)
            //{
            //    var updatedDto = new InventoryCostLayerUpdateDto
            //    {
            //        Id = existingLayer.Id,
            //        ItemId = existingLayer.ItemId,
            //        CompanyId = existingLayer.CompanyId,
            //        WarehouseId = existingLayer.WarehouseId,

            //        QuantityIn = existingLayer.QuantityIn + line.Quantity,
            //        QuantityOut = existingLayer.QuantityOut,
            //        RemainingQty = existingLayer.RemainingQty + line.Quantity,

            //        UnitCost = ((existingLayer.QuantityIn * existingLayer.UnitCost) /*+ (line.Quantity * line.UnitCost)*/) / (existingLayer.QuantityIn + line.Quantity),

            //        ReferenceDocumentId = existingLayer.ReferenceDocumentId,
            //        TransactionDate = existingLayer.TransactionDate
            //    };

            //    await _costLayerService.Update(updatedDto);
            //}
            //else
            //{
            //    var createDto = new InventoryCostLayerCreateDto
            //    {
            //        CompanyId = receipt.CompanyId,
            //        //WarehouseId = receipt.WarehouseId,
            //        ItemId = line.ItemId,
            //        QuantityIn = line.Quantity,
            //        QuantityOut = 0,
            //        RemainingQty = line.Quantity,

            //        ReferenceDocumentId = receipt.Id,
            //        TransactionDate = receipt.GoodsReceiptDate
            //    };

            //    await _costLayerService.Create(createDto);
            //}
        }
    }
}