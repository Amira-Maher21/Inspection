using Inspection.Application.Contracts.Dto.Inventory.System.InventoryBalance;
using Inspection.Application.Contracts.Dto.Inventory.System.InventoryCostLayers;
using Inspection.Application.Contracts.Dto.Inventory.System.InventoryLedgers;
using Inspection.Application.Contracts.Dto.Posting;
using Inspection.Domain.Event;
using Inspection.Domain.Event.Posting;
using Inspection.Domain.Models.Inventory.Ledger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Posting
{
    public interface IPostingEngine
    {
        //Task PostAsync(IPostableDocument document);
        //Task PostAsync<TEntity>(TEntity entity) where TEntity : IPostingEntity;
        Task PostAsync<TEntity>(TEntity entity) where TEntity : class, IPostingEntity;
        Task<IPostingEntity> GetPostingDocument(string documentCode, long id);

        // New methods for batch posting
        Task<PostingResult> PostAllUnpostedDocumentsAsync();
        Task<PostingResult> PostUnpostedDocumentsByTypeAsync(string documentCode);
        Task InventoryLedgerMapping<TEntity, TLine>(
            TEntity entity,
            InventoryLedgerCreateDto dto)
            where TEntity : class
            where TLine : class;

        //Task InventoryCostLayerMapping<TEntity, TLine>(
        //    TEntity entity,
        //    InventoryCostLayerCreateDto dto)
        //    where TEntity : class
        //    where TLine : class;

        Task InventoryCostLayerMapping<TEntity, TLine>(
            TEntity entity,
            InventoryCostLayerCreateDto dto)
            where TEntity : class
            where TLine : class;

        Task InventoryBalanceMapping<TEntity, TLine>(
            TEntity entity,
            InventoryBalanceCreateDto dto)
            where TEntity : class
            where TLine : class;

        Task UpdateAccountBalance(Ledger ledger);

        Task<long> ReverseLedgerAsync(long ledgerId);
    }
}
