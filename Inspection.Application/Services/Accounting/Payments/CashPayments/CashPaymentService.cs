using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashPaymentDTOs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.Payments.CashPayments;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Payments.CashPayments;
using Inspection.Application.Contracts.Services.Accounting.Payments.CashPayments;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Accounting.Payment.CashPayments;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.Payments.CashPayments
{

    internal class CashPaymentService : AccountsServiceBase, ICashPaymentService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly ISeriesService _seriesService;


        public CashPaymentService(
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
        private ICashPaymentCommandRepository _commands => _accountUoW.CashPayment;
        private ICashPaymentQueryRepository _queries => _queriesManager.CashPayment;

        public async Task<ReturnBase<CashPaymentDto>> Create(CashPaymentCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<CashPayment>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // Series
                const string SCREEN_CODE = "Cash Payment";

                var series = await _queriesManager.Series.GetByScreen_IDAsync(SCREEN_CODE);

                if (series == null || !series.IsActive)
                    return ReturnBase<CashPaymentDto>.Fail(
                        new Exception($"No active series configured for screen '{SCREEN_CODE}'"),
                        _exceptionManager);

                entity.SeriesId = series.Id;

                var seriesResult = await _seriesService
                    .GetSeriesCodeWithCustomDateUsingSeriesDetails(series.Id, DateTime.Now);

                if (!seriesResult.Succeeded || seriesResult.Result == null)
                    return ReturnBase<CashPaymentDto>.Fail(seriesResult.Errors);

                entity.ReceiptNumber = seriesResult.Result["FinelSeriesCodeAndSeriesNumber"];
                entity.RunningNumber = int.Parse(seriesResult.Result["RunningNumber"]);

                CreateCashPaymentLines(entity, dto);
                CreateCashPaymentAdjustments(entity, dto);
                CreatePurchaseInvoiceAllocations(entity, dto);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<CashPaymentDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<CashPaymentDto>.Fail(saveResult.Errors);

                return ReturnBase<CashPaymentDto>.Success(_mapper.Map<CashPaymentDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<CashPaymentDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<CashPaymentDto>> Update(CashPaymentUpdateDto dto)
        {
            try
            {
                var entity = await _queriesManager.CashPayment.GetById(dto.Id);

                if (entity == null)
                    return ReturnBase<CashPaymentDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404", ErrorMessage = $"Cash Payment with Id {dto.Id} was not found" }
            });

                _mapper.Map(dto, entity);

                await UpdateCashPaymentLines(entity, dto);
                await UpdateCashPaymentAdjustments(entity, dto);
                await UpdatePurchaseInvoiceAllocations(entity, dto);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<CashPaymentDto>.Fail(saveResult.Errors);

                return ReturnBase<CashPaymentDto>.Success(_mapper.Map<CashPaymentDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<CashPaymentDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<CashPaymentDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.CashPayment.GetById(id);
                if (entity == null)
                    return ReturnBase<CashPaymentDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = $"Cash Payment with Id {id} was not found" }
                    });


                var updateResult = await _commands.DeleteAsync(id);
                if (!updateResult.Succeeded) return ReturnBase<CashPaymentDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded) return ReturnBase<CashPaymentDto>.Fail(saveResult.Errors);

                return ReturnBase<CashPaymentDto>.Success(_mapper.Map<CashPaymentDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<CashPaymentDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<CashPaymentDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.CashPayment.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = $" Cash Payment with Id '{id}' was not found."
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<CashPaymentDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<CashPaymentDto>(entity);

                return ReturnBase<CashPaymentDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<CashPaymentDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<CashPaymentReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult =
                    await _queriesManager.CashPayment.Search(sqlQueryOptions);

                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<CashPaymentReturnSearchDto>>
                        .Fail(getResult.Errors);

                return ReturnBase<IEnumerable<CashPaymentReturnSearchDto>>
                    .Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CashPaymentReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }


        // Create && Update  Any Detail For Cash Payment (Lines, Adjustments, Allocations) should be handled in these methods to make sure that all operations will be in the same transaction scope

        // CashPaymentLines
        private void CreateCashPaymentLines(CashPayment entity, CashPaymentCreateDto dto)
        {
            if (dto.CashPaymentLines == null || !dto.CashPaymentLines.Any())
            {
                entity.CashPaymentLines = new List<CashPaymentLine>();
                return;
            }

            entity.CashPaymentLines = _mapper.Map<List<CashPaymentLine>>(dto.CashPaymentLines);

            foreach (var line in entity.CashPaymentLines)
            {
                line.CashPayment = entity;
            }
        }

        private async Task UpdateCashPaymentLines(CashPayment entity, CashPaymentUpdateDto dto)
        {
            var existing = entity.CashPaymentLines.ToList();

            if (dto.CashPaymentLines == null || !dto.CashPaymentLines.Any())
            {
                var allIds = existing.Select(x => x.Id).ToList();

                if (allIds.Any())
                    await _commands.DeleteCashPaymentLinesByCashPaymentIds(allIds);
                return;
            }

            var dtoIds = dto.CashPaymentLines
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            foreach (var lineDto in dto.CashPaymentLines)
            {
                if (lineDto.Id == 0)
                {
                    var newEntity = _mapper.Map<CashPaymentLine>(lineDto);
                    newEntity.CashPaymentId = entity.Id;
                    entity.CashPaymentLines.Add(newEntity);
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
                await _commands.DeleteCashPaymentLinesByCashPaymentIds(removed);
        }

        // CashPaymentAdjustments
        private void CreateCashPaymentAdjustments(CashPayment entity, CashPaymentCreateDto dto)
        {
            if (dto.CashPaymentAdjustments == null || !dto.CashPaymentAdjustments.Any())
            {
                entity.CashPaymentAdjustments = new List<CashPaymentAdjustment>();
                return;
            }

            entity.CashPaymentAdjustments = _mapper.Map<List<CashPaymentAdjustment>>(dto.CashPaymentAdjustments);

            foreach (var adj in entity.CashPaymentAdjustments)
            {
                adj.CashPayment = entity;
            }
        }

        private async Task UpdateCashPaymentAdjustments(CashPayment entity, CashPaymentUpdateDto dto)
        {
            var existing = entity.CashPaymentAdjustments.ToList();

            if (dto.CashPaymentAdjustments == null || !dto.CashPaymentAdjustments.Any())
            {
                var allIds = existing.Select(x => x.Id).ToList();

                if (allIds.Any())
                    await _commands.DeleteCashPaymentAdjustmentsByCashPaymentIds(allIds);
                return;
            }

            var dtoIds = dto.CashPaymentAdjustments
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            foreach (var adjDto in dto.CashPaymentAdjustments)
            {
                if (adjDto.Id == 0)
                {
                    var newEntity = _mapper.Map<CashPaymentAdjustment>(adjDto);
                    newEntity.CashPaymentId = entity.Id;
                    entity.CashPaymentAdjustments.Add(newEntity);
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
                await _commands.DeleteCashPaymentAdjustmentsByCashPaymentIds(removed);
        }

        // PurchaseInvoiceAllocations
        private void CreatePurchaseInvoiceAllocations(CashPayment entity, CashPaymentCreateDto dto)
        {
            if (dto.PurchaseInvoiceAllocations == null || !dto.PurchaseInvoiceAllocations.Any())
            {
                entity.PurchaseInvoiceAllocations = new List<PurchaseInvoiceAllocation>();
                return;
            }

            entity.PurchaseInvoiceAllocations = _mapper.Map<List<PurchaseInvoiceAllocation>>(dto.PurchaseInvoiceAllocations);

            foreach (var alloc in entity.PurchaseInvoiceAllocations)
            {
                alloc.CashPayment = entity;
            }
        }

        private async Task UpdatePurchaseInvoiceAllocations(CashPayment entity, CashPaymentUpdateDto dto)
        {
            var existing = entity.PurchaseInvoiceAllocations.ToList();

            if (dto.PurchaseInvoiceAllocations == null || !dto.PurchaseInvoiceAllocations.Any())
            {
                var allIds = existing.Select(x => x.Id).ToList();

                if (allIds.Any())
                    await _commands.DeletePurchaseInvoiceAllocationsByCashPaymentIds(allIds);
                return;
            }

            var dtoIds = dto.PurchaseInvoiceAllocations
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            foreach (var allocDto in dto.PurchaseInvoiceAllocations)
            {
                if (allocDto.Id == 0)
                {
                    var newEntity = _mapper.Map<PurchaseInvoiceAllocation>(allocDto);
                    newEntity.CashPaymentId = entity.Id;
                    entity.PurchaseInvoiceAllocations.Add(newEntity);
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
                await _commands.DeletePurchaseInvoiceAllocationsByCashPaymentIds(removed);
        }

    }
}