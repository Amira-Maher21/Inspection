using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashReceiptDTOs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.Payments.CashReceipts;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Payments.CashReceipts;
using Inspection.Application.Contracts.Services.Accounting.Payments.CashReceipts;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Accounting.Payment.CashReceipts;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.Payments.CashReceipts
{
    internal class CashReceiptService : AccountsServiceBase, ICashReceiptService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly ISeriesService _seriesService;


        public CashReceiptService(
            IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper,
            IExceptionManager exceptionManager,
            ITenantResolver tenantResolver,
            IExcelTemplateGenerator templateGenerator, ISeriesService seriesService) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
            _seriesService = seriesService;

        }
        private ICashReceiptCommandRepository _commands => _accountUoW.CashReceipt;
        private ICashReceiptQueryRepository _queries => _queriesManager.CashReceipt;

        public async Task<ReturnBase<CashReceiptDto>> Create(CashReceiptCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<CashReceipt>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // Series
                const string SCREEN_CODE = "Cash Receipt";

                var series = await _queriesManager.Series.GetByScreen_IDAsync(SCREEN_CODE);

                if (series == null || !series.IsActive)
                    return ReturnBase<CashReceiptDto>.Fail(
                        new Exception($"No active series configured for screen '{SCREEN_CODE}'"),
                        _exceptionManager);

                entity.SeriesId = series.Id;

                var seriesResult = await _seriesService
                    .GetSeriesCodeWithCustomDateUsingSeriesDetails(series.Id, DateTime.Now);

                if (!seriesResult.Succeeded || seriesResult.Result == null)
                    return ReturnBase<CashReceiptDto>.Fail(seriesResult.Errors);

                entity.ReceiptNumber = seriesResult.Result["FinelSeriesCodeAndSeriesNumber"];
                entity.RunningNumber = int.Parse(seriesResult.Result["RunningNumber"]);

                CreateCashReceiptLines(entity, dto);
                CreateCashReceiptAdjustments(entity, dto);
                CreateSalesInvoiceAllocations(entity, dto);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<CashReceiptDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<CashReceiptDto>.Fail(saveResult.Errors);

                return ReturnBase<CashReceiptDto>.Success(_mapper.Map<CashReceiptDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<CashReceiptDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<CashReceiptDto>> Update(CashReceiptUpdateDto dto)
        {
            try
            {
                var entity = await _queriesManager.CashReceipt.GetById(dto.Id);

                if (entity == null)
                    return ReturnBase<CashReceiptDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404", ErrorMessage = $"Cash Receipt with Id {dto.Id} was not found" }
            });

                _mapper.Map(dto, entity);

                await UpdateCashReceiptLines(entity, dto);
                await UpdateCashReceiptAdjustments(entity, dto);
                await UpdateSalesInvoiceAllocations(entity, dto);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<CashReceiptDto>.Fail(saveResult.Errors);

                return ReturnBase<CashReceiptDto>.Success(_mapper.Map<CashReceiptDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<CashReceiptDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<CashReceiptDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.CashReceipt.GetById(id);
                if (entity == null)
                    return ReturnBase<CashReceiptDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = $"Cash Receipt with Id {id} was not found" }
                    });


                var updateResult = await _commands.DeleteAsync(id);
                if (!updateResult.Succeeded) return ReturnBase<CashReceiptDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded) return ReturnBase<CashReceiptDto>.Fail(saveResult.Errors);

                return ReturnBase<CashReceiptDto>.Success(_mapper.Map<CashReceiptDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<CashReceiptDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<CashReceiptDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.CashReceipt.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = $" Cash Receipt with Id '{id}' was not found."
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<CashReceiptDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<CashReceiptDto>(entity);

                return ReturnBase<CashReceiptDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<CashReceiptDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<CashReceiptReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult =
                    await _queriesManager.CashReceipt.Search(sqlQueryOptions);

                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<CashReceiptReturnSearchDto>>
                        .Fail(getResult.Errors);

                return ReturnBase<IEnumerable<CashReceiptReturnSearchDto>>
                    .Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CashReceiptReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }


        // Create && Update  Any Detail For Cash Receipt

        // CashReceiptLines
        private void CreateCashReceiptLines(CashReceipt entity, CashReceiptCreateDto dto)
        {
            if (dto.CashReceiptLines == null || !dto.CashReceiptLines.Any())
            {
                entity.CashReceiptLines = new List<CashReceiptLine>();
                return;
            }

            entity.CashReceiptLines = _mapper.Map<List<CashReceiptLine>>(dto.CashReceiptLines);

            foreach (var line in entity.CashReceiptLines)
            {
                line.CashReceipt = entity;
            }
        }

        private async Task UpdateCashReceiptLines(CashReceipt entity, CashReceiptUpdateDto dto)
        {
            var existing = entity.CashReceiptLines.ToList();

            if (dto.CashReceiptLines == null || !dto.CashReceiptLines.Any())
            {
                var allIds = existing.Select(x => x.Id).ToList();

                if (allIds.Any())
                    await _commands.DeleteCashReceiptLineByCashReceiptIds(allIds);
                //await _commands.DeleteCashReceiptLinesByCashReceiptId(entity.Id);
                return;
            }

            var dtoIds = dto.CashReceiptLines
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            foreach (var lineDto in dto.CashReceiptLines)
            {
                if (lineDto.Id == 0)
                {
                    var newEntity = _mapper.Map<CashReceiptLine>(lineDto);
                    newEntity.CashReceiptId = entity.Id;
                    entity.CashReceiptLines.Add(newEntity);
                }
                else
                {
                    var existingEntity = existing.FirstOrDefault(x => x.Id == lineDto.Id);

                    if (existingEntity != null)
                        _mapper.Map(lineDto, existingEntity);
                }
            }

            var removed = existing
                .Where(x => !dtoIds.Contains(x.Id))
                .Select(x => x.Id)
                .ToList();

            if (removed.Any())
                await _commands.DeleteCashReceiptLineByCashReceiptIds(removed);
        }

        // CashReceiptAdjustments
        private void CreateCashReceiptAdjustments(CashReceipt entity, CashReceiptCreateDto dto)
        {
            if (dto.CashReceiptAdjustments == null || !dto.CashReceiptAdjustments.Any())
            {
                entity.CashReceiptAdjustments = new List<CashReceiptAdjustment>();
                return;
            }

            entity.CashReceiptAdjustments = _mapper.Map<List<CashReceiptAdjustment>>(dto.CashReceiptAdjustments);

            foreach (var adj in entity.CashReceiptAdjustments)
            {
                adj.CashReceipt = entity;
            }
        }

        private async Task UpdateCashReceiptAdjustments(CashReceipt entity, CashReceiptUpdateDto dto)
        {
            var existing = entity.CashReceiptAdjustments.ToList();

            if (dto.CashReceiptAdjustments == null || !dto.CashReceiptAdjustments.Any())
            {
                var allIds = existing.Select(x => x.Id).ToList();

                if (allIds.Any())
                    await _commands.DeleteCashReceiptAdjustmentsCashReceiptIds(allIds);
                //await _commands.DeleteCashReceiptAdjustmentsByCashReceiptId(entity.Id);
                return;
            }

            var dtoIds = dto.CashReceiptAdjustments
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            foreach (var adjDto in dto.CashReceiptAdjustments)
            {
                if (adjDto.Id == 0)
                {
                    var newEntity = _mapper.Map<CashReceiptAdjustment>(adjDto);
                    newEntity.CashReceiptId = entity.Id;
                    entity.CashReceiptAdjustments.Add(newEntity);
                }
                else
                {
                    var existingEntity = existing.FirstOrDefault(x => x.Id == adjDto.Id);

                    if (existingEntity != null)
                        _mapper.Map(adjDto, existingEntity);
                }
            }

            var removed = existing
                .Where(x => !dtoIds.Contains(x.Id))
                .Select(x => x.Id)
                .ToList();

            if (removed.Any())
                await _commands.DeleteCashReceiptAdjustmentsCashReceiptIds(removed);
        }

        // SalesInvoiceAllocations
        private void CreateSalesInvoiceAllocations(CashReceipt entity, CashReceiptCreateDto dto)
        {
            if (dto.SalesInvoiceAllocations == null || !dto.SalesInvoiceAllocations.Any())
            {
                entity.SalesInvoiceAllocations = new List<SalesInvoiceAllocation>();
                return;
            }

            entity.SalesInvoiceAllocations = _mapper.Map<List<SalesInvoiceAllocation>>(dto.SalesInvoiceAllocations);

            foreach (var alloc in entity.SalesInvoiceAllocations)
            {
                alloc.CashReceipt = entity;
            }
        }

        private async Task UpdateSalesInvoiceAllocations(CashReceipt entity, CashReceiptUpdateDto dto)
        {
            var existing = entity.SalesInvoiceAllocations.ToList();

            if (dto.SalesInvoiceAllocations == null || !dto.SalesInvoiceAllocations.Any())
            {
                var allIds = existing.Select(x => x.Id).ToList();

                if (allIds.Any())
                    await _commands.DeleteSalesInvoiceAllocationsByCashReceiptIds(allIds);
                //await _commands.DeleteSalesInvoiceAllocationsByCashReceiptId(entity.Id);
                return;
            }

            var dtoIds = dto.SalesInvoiceAllocations
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            foreach (var allocDto in dto.SalesInvoiceAllocations)
            {
                if (allocDto.Id == 0)
                {
                    var newEntity = _mapper.Map<SalesInvoiceAllocation>(allocDto);
                    newEntity.CashReceiptId = entity.Id;
                    entity.SalesInvoiceAllocations.Add(newEntity);
                }
                else
                {
                    var existingEntity = existing.FirstOrDefault(x => x.Id == allocDto.Id);

                    if (existingEntity != null)
                        _mapper.Map(allocDto, existingEntity);
                }
            }

            var removed = existing
                .Where(x => !dtoIds.Contains(x.Id))
                .Select(x => x.Id)
                .ToList();

            if (removed.Any())
                await _commands.DeleteSalesInvoiceAllocationsByCashReceiptIds(removed);
        }

    }
}