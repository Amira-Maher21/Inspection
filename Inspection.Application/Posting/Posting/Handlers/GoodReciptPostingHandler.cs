using AutoMapper;
using Inspection.Application.Contracts.Dto.Inventory.System.InventoryBalance;
using Inspection.Application.Contracts.Dto.Inventory.System.InventoryCostLayers;
using Inspection.Application.Contracts.Dto.Inventory.System.InventoryLedgers;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Posting;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup.ILedgerCommandRepository;
using Inspection.Application.Contracts.Repositories.Query.Posting;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Models.Inventory.Ledger;
using Inspection.Domain.Models.Inventory.Transaction.GoodsReceipts;
using Inspection.Domain.Models.Inventory.Transaction.GoodsReceipts.GoodsReceiptLines;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Posting.Posting.Handlers
{
    public class GoodsReceiptPostingHandler : AccountsServiceBase
    {
        private readonly ILedgerCommandRepository _ledgerCommandRepo;
        private readonly IPostingAccountMappingQueryRepository _mappingRepo;
        private readonly IPostingEngine _postingEngine;

        public string DocumentCode => "GoodsReceipt";

        public GoodsReceiptPostingHandler
            (
            ILedgerCommandRepository ledgerRepo,
            IPostingAccountMappingQueryRepository mappingRepo,
            IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IPostingEngine postingEngine,
            IMapper mapper,
            IExceptionManager exceptionManager
            )
            : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _ledgerCommandRepo = ledgerRepo;
            _mappingRepo = mappingRepo;
            _postingEngine = postingEngine;
        }

        public async Task HandleAsync(GoodsReceipt doc)
        {
            //var journal = (JournalEntry)doc;

            if (doc.Posting == PostingEnum.Posted)
                throw new InvalidOperationException("Good Receipt already posted");

            // 1. Inventory Ledger Mapping - فقط سطر واحد!
            var ledgerDto = new InventoryLedgerCreateDto();
            await _postingEngine.InventoryLedgerMapping<GoodsReceipt, GoodsReceiptLine>(doc, ledgerDto);

            // 2. Inventory Cost Layer Mapping
            var costLayerDto = new InventoryCostLayerCreateDto();
            await _postingEngine.InventoryCostLayerMapping<GoodsReceipt, GoodsReceiptLine>(doc, costLayerDto);

            // 3. Inventory Balance Mapping
            var balanceDto = new InventoryBalanceCreateDto();
            await _postingEngine.InventoryBalanceMapping<GoodsReceipt, GoodsReceiptLine>(doc, balanceDto);

            var mappings = await _mappingRepo.GetByDocumentCode(DocumentCode);

            var ledger = new Ledger
            {
                Tenant_ID = doc.Tenant_ID,
                CompanyId = doc.CompanyId,
                ReferenceDocumentId = doc.Id,
                PostingDocumentTypeId = 1,
                DocumentDate = doc.GoodsReceiptDate,
                //JournalEntryId = doc.Id,
                //TotalDebit = doc.TotalDebit,
                //TotalCredit = doc.TotalCredit,
                //CurrencyId = doc.CurrencyId,
                BranchId = doc.BranchId,
                PostedDate = DateTime.UtcNow,

                //DocumentCode = doc.DocumentCode,

            };

            // Only mappings for FixedLines
            var fixedLineMappings = mappings
                .Where(x => x.AccountSource == "FixedLines")
                .OrderBy(x => x.Priority)
                .ToList();

            if (fixedLineMappings.Any())
            {
                foreach (var line in doc.GoodsReceiptLines)
                {
                    var ledgerLine = new LedgerLine
                    {
                        //ChartOfAccountId = line.ChartOfAccountId,
                        //DebitAmount = line.DebitAmount,
                        //CreditAmount = line.CreditAmount,
                        //CostCenterId = line.CostCenterId,
                        OperationId = line.OperationId,
                        //WBSId = line.WBSId,
                        //BOQItemId = line.BOQItemId,
                        //SubcontractBOQId = line.SubcontractBOQId,
                        //ProductionOrderId = line.ProductionOrderId,
                        //ActivityId = line.ActivityId,
                        //CostCodeId = line.CostCodeId,
                    };

                    ledger.LedgerLines.Add(ledgerLine);
                }
            }

            // Update account balances
            await _postingEngine.UpdateAccountBalance(ledger);

            doc.Posting = PostingEnum.Posted;

            // Update the JournalEntry using the command repository
            var updateResult = await _accountUoW.GoodsReceipt.UpdateAsync(doc);
            if (!updateResult.Succeeded)
            {
                throw new Exception($"Failed to update GoodsReceipt: {string.Join(", ", updateResult.Errors)}");
            }

            // Insert ledger
            var insertResult = await _accountUoW.Ledger.InsertAsync(ledger);
            if (!insertResult.Succeeded)
            {
                throw new Exception($"Failed to insert ledger: {string.Join(", ", insertResult.Errors)}");
            }

        }

    }


}
