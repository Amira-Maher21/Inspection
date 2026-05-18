using AutoMapper;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Posting;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup.ILedgerCommandRepository;
using Inspection.Application.Contracts.Repositories.Query.Posting;
using Inspection.Application.Contracts.Services.SystemConfigurations.Currencies;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Models.Accounting.Payment.JonrnalEntrys;
using Inspection.Domain.Models.Inventory.Ledger;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Posting.Posting.Handlers
{
    public class JournalEntryPostingHandler : AccountsServiceBase, IPostingHandler<JournalEntry>
    {
        private readonly ILedgerCommandRepository _ledgerCommandRepo;
        private readonly IPostingAccountMappingQueryRepository _mappingRepo;
        private readonly IPostingEngine _postingEngine;

        private readonly ICurrencyService _currencyService;

        public string DocumentCode => "JournalEntry";

        public JournalEntryPostingHandler
            (
            ILedgerCommandRepository ledgerRepo,
            IPostingAccountMappingQueryRepository mappingRepo,
            IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IPostingEngine postingEngine,
            ICurrencyService currencyService,
            IMapper mapper,
            IExceptionManager exceptionManager
            )
            : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _ledgerCommandRepo = ledgerRepo;
            _mappingRepo = mappingRepo;
            _postingEngine = postingEngine;
            this._currencyService = currencyService;
        }

        public async Task HandleAsync(JournalEntry doc)
        {
            if (doc.Posting == PostingEnum.Posted)
                throw new InvalidOperationException("Journal already posted");

            if (doc.JournalEntryLines == null || !doc.JournalEntryLines.Any())
                throw new InvalidOperationException("Journal Entry has no lines to post");

            var mappings = await _mappingRepo.GetByDocumentCode(DocumentCode);

            var ratesResult = await this._currencyService.GetRatesAsync(doc.CompanyId, doc.CurrencyId, doc.PostingDate);


            if (!ratesResult.Succeeded)
                throw new Exception(string.Join(",", ratesResult.Errors));

            var rates = ratesResult.Result;

            var ledger = new Ledger
            {
                Tenant_ID = doc.Tenant_ID,
                CompanyId = doc.CompanyId,
                DocumentCode = doc.DocumentCode,
                ReferenceDocumentId = doc.Id,
                DocumentDate = doc.JournalDate,
                PostingDocumentTypeId = 1,
                PostingDate = doc.PostingDate,
                JournalEntryId = doc.Id,
                CurrencyId = doc.CurrencyId,
                BranchId = doc.BranchId,
                PostedDate = DateTime.UtcNow
            };

            decimal totalDebit = 0;
            decimal totalCredit = 0;

            // Only mappings for FixedLines
            var fixedLineMappings = mappings
                .Where(x => x.AccountSource == "FixedLines")
                .OrderBy(x => x.Priority)
                .ToList();

            if (fixedLineMappings.Any())
            {
                foreach (var line in doc.JournalEntryLines)
                {
                    //var ledgerLine = new LedgerLine
                    //{
                    //    ChartOfAccountId = line.ChartOfAccountId,
                    //    DebitAmount = line.DebitAmount,
                    //    CreditAmount = line.CreditAmount,
                    //    CostCenterId = line.CostCenterId,
                    //    OperationId = line.OperationId,
                    //    In_Date = DateTime.UtcNow,
                    //    In_User = doc.In_User
                    //};

                    var ledgerLine = new LedgerLine
                    {
                        ChartOfAccountId = line.ChartOfAccountId,

                        // Transaction
                        DebitAmount = line.DebitAmount,
                        CreditAmount = line.CreditAmount,

                        // Base
                        BaseDebitAmount = rates.BaseRate != 0
                            ? Math.Round(line.DebitAmount * rates.BaseRate, 6)
                            : 0,
                        BaseCreditAmount = rates.BaseRate != 0
                            ? Math.Round(line.CreditAmount * rates.BaseRate, 6)
                            : 0,

                        // Reporting
                        ReportingDebitAmount = rates.ReportingRate != 0
                            ? Math.Round(line.DebitAmount * rates.ReportingRate, 6)
                            : 0,
                        ReportingCreditAmount = rates.ReportingRate != 0
                            ? Math.Round(line.CreditAmount * rates.ReportingRate, 6)
                            : 0,

                        // Official
                        OfficialDebitAmount = rates.OfficialRate != 0
                            ? Math.Round(line.DebitAmount * rates.OfficialRate, 6)
                            : 0,
                        OfficialCreditAmount = rates.OfficialRate != 0
                            ? Math.Round(line.CreditAmount * rates.OfficialRate, 6)
                            : 0,

                        CostCenterId = line.CostCenterId,
                        OperationId = line.OperationId,
                        In_Date = DateTime.UtcNow,
                        In_User = doc.In_User
                    };

                    ledger.LedgerLines.Add(ledgerLine);

                    totalDebit += line.DebitAmount;
                    totalCredit += line.CreditAmount;
                }
            }

            if (totalDebit != totalCredit)
            {
                throw new InvalidOperationException($"Journal Entry is not balanced. Total Debit: {totalDebit}, Total Credit: {totalCredit}");
            }

            ledger.TotalDebit = totalDebit;
            ledger.TotalCredit = totalCredit;

            // Update account balances
            await _postingEngine.UpdateAccountBalance(ledger);

            doc.Posting = PostingEnum.Posted;

            var updateResult = await _accountUoW.IJournalEntry.UpdateAsync(doc);
            if (!updateResult.Succeeded)
            {
                throw new Exception($"Failed to update JournalEntry: {string.Join(", ", updateResult.Errors)}");
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
