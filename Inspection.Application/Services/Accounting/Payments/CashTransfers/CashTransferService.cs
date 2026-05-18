using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashTransferDTOs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.Payments.CashTransfers;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Payments.CashTransfers;
using Inspection.Application.Contracts.Services.Accounting.Payments.CashTransfers;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Accounting.Payment.CashTransfers;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.Payments.CashTransfers
{
    internal class CashTransferService : AccountsServiceBase, ICashTransferService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly ISeriesService _seriesService;


        public CashTransferService(
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
        private ICashTransferCommandRepository _commands => _accountUoW.CashTransfer;
        private ICashTransferQueryRepository _queries => _queriesManager.CashTransfer;

        public async Task<ReturnBase<CashTransferDto>> Create(CashTransferCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<CashTransfer>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // Series
                const string SCREEN_CODE = "Cash Transfer";

                var series = await _queriesManager.Series.GetByScreen_IDAsync(SCREEN_CODE);

                if (series == null || !series.IsActive)
                    return ReturnBase<CashTransferDto>.Fail(
                        new Exception($"No active series configured for screen '{SCREEN_CODE}'"),
                        _exceptionManager);

                entity.SeriesId = series.Id;

                var seriesResult = await _seriesService
                    .GetSeriesCodeWithCustomDateUsingSeriesDetails(series.Id, entity.TransferDate);

                if (!seriesResult.Succeeded || seriesResult.Result == null)
                    return ReturnBase<CashTransferDto>.Fail(seriesResult.Errors);

                entity.TransferNumber = seriesResult.Result["FinelSeriesCodeAndSeriesNumber"];
                entity.RunningNumber = int.Parse(seriesResult.Result["RunningNumber"]);

                CreateCashTransferLines(entity, dto);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<CashTransferDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<CashTransferDto>.Fail(saveResult.Errors);

                return ReturnBase<CashTransferDto>.Success(_mapper.Map<CashTransferDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<CashTransferDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<CashTransferDto>> Update(CashTransferUpdateDto dto)
        {
            try
            {
                var entity = await _queriesManager.CashTransfer.GetById(dto.Id);

                if (entity == null)
                    return ReturnBase<CashTransferDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404", ErrorMessage = $"Cash Transfer with Id {dto.Id} was not found" }
            });

                _mapper.Map(dto, entity);

                await UpdateCashTransferLines(entity, dto);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<CashTransferDto>.Fail(saveResult.Errors);

                return ReturnBase<CashTransferDto>.Success(_mapper.Map<CashTransferDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<CashTransferDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<CashTransferDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.CashTransfer.GetById(id);
                if (entity == null)
                    return ReturnBase<CashTransferDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = $"Cash Transfer with Id {id} was not found" }
                    });


                var updateResult = await _commands.DeleteAsync(id);
                if (!updateResult.Succeeded) return ReturnBase<CashTransferDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded) return ReturnBase<CashTransferDto>.Fail(saveResult.Errors);

                return ReturnBase<CashTransferDto>.Success(_mapper.Map<CashTransferDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<CashTransferDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<CashTransferDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.CashTransfer.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = $"Cash Transfer with Id '{id}' was not found."
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<CashTransferDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<CashTransferDto>(entity);

                return ReturnBase<CashTransferDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<CashTransferDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<CashTransferReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult =
                    await _queriesManager.CashTransfer.Search(sqlQueryOptions);

                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<CashTransferReturnSearchDto>>
                        .Fail(getResult.Errors);

                return ReturnBase<IEnumerable<CashTransferReturnSearchDto>>
                    .Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CashTransferReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }


        // Create && Update  Any Detail For Cash Transfer (Lines) should be handled in these methods to make sure that all operations will be in the same transaction scope

        // CashTransferLines
        private void CreateCashTransferLines(CashTransfer entity, CashTransferCreateDto dto)
        {
            if (dto.CashTransferLines == null || !dto.CashTransferLines.Any())
            {
                entity.CashTransferLines = new List<CashTransferLine>();
                return;
            }

            entity.CashTransferLines = _mapper.Map<List<CashTransferLine>>(dto.CashTransferLines);
            foreach (var line in entity.CashTransferLines)
            {
                line.CashTransfer = entity;
            }
        }

        private async Task UpdateCashTransferLines(CashTransfer entity, CashTransferUpdateDto dto)
        {
            var existing = entity.CashTransferLines.ToList();

            if (dto.CashTransferLines == null || !dto.CashTransferLines.Any())
            {
                var allIds = existing.Select(x => x.Id).ToList();

                if (allIds.Any())
                    await _commands.DeleteCashTransferLinesByCashTransferIds(allIds);
                return;
            }

            var dtoIds = dto.CashTransferLines
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            foreach (var lineDto in dto.CashTransferLines)
            {
                if (lineDto.Id == 0)
                {
                    var newEntity = _mapper.Map<CashTransferLine>(lineDto);
                    newEntity.CashTransferId = entity.Id;
                    entity.CashTransferLines.Add(newEntity);
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
                await _commands.DeleteCashTransferLinesByCashTransferIds(removed);
        }

    }
}