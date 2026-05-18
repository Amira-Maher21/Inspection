using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.AR.PurchaseReturns;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AR.PurchaseReturns;
using Inspection.Application.Contracts.Repositories.Query.Accounting.AR.PurchaseReturns;
using Inspection.Application.Contracts.Services.Accounting.AR.PurchaseReturns;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Accounting.AR.PurchaseReturns;
using Inspection.Domain.Models.Accounting.AR.PurchaseReturns.PurchaseReturnAdjustments;
using Inspection.Domain.Models.Accounting.AR.PurchaseReturns.PurchaseReturnLines;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.AR.PurchaseReturns
{
    internal class PurchaseReturnService : AccountsServiceBase, IPurchaseReturnService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly ISeriesService _seriesService;

        public PurchaseReturnService(
      IAccountUnitOfWork accountUoW,
      IAccountsQueriesManager queriesManager,
      IMapper mapper,
      IExceptionManager exceptionManager,
      ITenantResolver tenantResolver,
      IExcelTemplateGenerator templateGenerator,
      ISeriesService seriesService)
      : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
            _seriesService = seriesService;
        }

        private IPurchaseReturnCommandRepository _commands => _accountUoW.PurchaseReturn;
        private IPurchaseReturnQueryRepository _queries => _queriesManager.PurchaseReturn;

        // ================= CREATE =================

        public async Task<ReturnBase<PurchaseReturnDto>> Create(PurchaseReturnCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<PurchaseReturn>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // Series
                const string SCREEN_CODE = "Purchase Return";

                var series = await _queriesManager.Series.GetByScreen_IDAsync(SCREEN_CODE);

                if (series == null || !series.IsActive)
                    return ReturnBase<PurchaseReturnDto>.Fail(
                        new Exception($"No active series configured for screen '{SCREEN_CODE}'"),
                        _exceptionManager);

                entity.SeriesId = series.Id;

                var seriesResult = await _seriesService
                    .GetSeriesCodeWithCustomDateUsingSeriesDetails(series.Id, DateTime.Now);

                if (!seriesResult.Succeeded || seriesResult.Result == null)
                    return ReturnBase<PurchaseReturnDto>.Fail(seriesResult.Errors);

                entity.ReturnNumber = seriesResult.Result["FinelSeriesCodeAndSeriesNumber"];
                entity.RunningNumber = int.Parse(seriesResult.Result["RunningNumber"]);


                CreatePurchaseReturnLines(entity, dto);
                CreatePurchaseReturnAdjustments(entity, dto);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<PurchaseReturnDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<PurchaseReturnDto>.Fail(saveResult.Errors);

                return ReturnBase<PurchaseReturnDto>.Success(_mapper.Map<PurchaseReturnDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<PurchaseReturnDto>.Fail(ex, _exceptionManager);
            }
        }

        // ================= UPDATE =================

        public async Task<ReturnBase<PurchaseReturnDto>> Update(PurchaseReturnUpdateDto dto)
        {
            try
            {
                var entity = await _queries.GetById(dto.Id);

                if (entity == null)
                    return ReturnBase<PurchaseReturnDto>.Fail(new List<ReturnBaseError>
                {
                    new() { ErrorCode = "404", ErrorMessage = $"PurchaseReturn with Id {dto.Id} not found" }
                });

                _mapper.Map(dto, entity);

                await UpdatePurchaseReturnLines(entity, dto);
                await UpdatePurchaseReturnAdjustments(entity, dto);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<PurchaseReturnDto>.Fail(saveResult.Errors);

                return ReturnBase<PurchaseReturnDto>.Success(_mapper.Map<PurchaseReturnDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<PurchaseReturnDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<PurchaseReturnDto>> Delete(long id)
        {
            try
            {
                var entity = await _queries.GetById(id);
                if (entity == null)
                    return ReturnBase<PurchaseReturnDto>.Fail(new List<ReturnBaseError>
                {
                    new() { ErrorCode = "404", ErrorMessage = $"PurchaseReturn with Id {id} not found" }
                });

                var deleteResult = await _commands.DeleteAsync(id);
                if (!deleteResult.Succeeded)
                    return ReturnBase<PurchaseReturnDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<PurchaseReturnDto>.Fail(saveResult.Errors);

                return ReturnBase<PurchaseReturnDto>.Success(_mapper.Map<PurchaseReturnDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<PurchaseReturnDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<PurchaseReturnDto>> GetById(long id)
        {
            try
            {
                var entity = await _queries.GetById(id);

                if (entity == null)
                    return ReturnBase<PurchaseReturnDto>.Fail(new List<ReturnBaseError>
                {
                    new() { ErrorCode = "404", ErrorMessage = $"PurchaseReturn with Id {id} not found" }
                });

                return ReturnBase<PurchaseReturnDto>.Success(_mapper.Map<PurchaseReturnDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<PurchaseReturnDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<IEnumerable<PurchaseReturnReturnSearchDto>>> Search(SqlQueryOptions options)
        {
            try
            {
                var result = await _queries.Search(options);

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<PurchaseReturnReturnSearchDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<PurchaseReturnReturnSearchDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<PurchaseReturnReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        // ================= LINES =================

        private void CreatePurchaseReturnLines(PurchaseReturn entity, PurchaseReturnCreateDto dto)
        {
            entity.PurchaseReturnLines = dto.PurchaseReturnLines == null
                ? new List<PurchaseReturnLine>()
                : _mapper.Map<List<PurchaseReturnLine>>(dto.PurchaseReturnLines);

            foreach (var line in entity.PurchaseReturnLines)
                line.GetType().GetProperty("PurchaseReturn")?.SetValue(line, entity);
        }

        private async Task UpdatePurchaseReturnLines(PurchaseReturn entity, PurchaseReturnUpdateDto dto)
        {
            var existing = entity.PurchaseReturnLines.ToList();

            var dtoIds = dto.PurchaseReturnLines?
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet() ?? new HashSet<long>();

            foreach (var lineDto in dto.PurchaseReturnLines ?? new())
            {
                if (lineDto.Id == 0)
                {
                    var newLine = _mapper.Map<PurchaseReturnLine>(lineDto);
                    entity.PurchaseReturnLines.Add(newLine);
                }
                else
                {
                    var existingLine = existing.FirstOrDefault(x => x.Id == lineDto.Id);
                    if (existingLine != null)
                        _mapper.Map(lineDto, existingLine);
                }
            }

            var removed = existing.Where(x => !dtoIds.Contains(x.Id)).Select(x => x.Id).ToList();

            if (removed.Any())
                await _commands.DeletePurchaseReturnLinesByPurchaseReturnIds(removed);
        }

        // ================= ADJUSTMENTS =================

        private void CreatePurchaseReturnAdjustments(PurchaseReturn entity, PurchaseReturnCreateDto dto)
        {
            entity.PurchaseReturnAdjustments = dto.PurchaseReturnAdjustments == null
                ? new List<PurchaseReturnAdjustment>()
                : _mapper.Map<List<PurchaseReturnAdjustment>>(dto.PurchaseReturnAdjustments);

            foreach (var adj in entity.PurchaseReturnAdjustments)
                adj.PurchaseReturn = entity;
        }

        private async Task UpdatePurchaseReturnAdjustments(PurchaseReturn entity, PurchaseReturnUpdateDto dto)
        {
            var existing = entity.PurchaseReturnAdjustments.ToList();

            var dtoIds = dto.PurchaseReturnAdjustments?
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet() ?? new HashSet<long>();

            foreach (var adjDto in dto.PurchaseReturnAdjustments ?? new())
            {
                if (adjDto.Id == 0)
                {
                    var newAdj = _mapper.Map<PurchaseReturnAdjustment>(adjDto);
                    entity.PurchaseReturnAdjustments.Add(newAdj);
                }
                else
                {
                    var existingAdj = existing.FirstOrDefault(x => x.Id == adjDto.Id);
                    if (existingAdj != null)
                        _mapper.Map(adjDto, existingAdj);
                }
            }

            var removed = existing.Where(x => !dtoIds.Contains(x.Id)).Select(x => x.Id).ToList();

            if (removed.Any())
                await _commands.DeletePurchaseReturnAdjustmentsByPurchaseReturnIds(removed);
        }
    }
}
