using AutoMapper;
using Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.SalesReturns;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.SalesManagment.Transactions.SalesReturns;
using Inspection.Application.Contracts.Repositories.Query.SalesManagment.Transactions.SalesReturns;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.Services.SalesManagment.Transactions.SalesReturns;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.SalesManagment.Transaction.SalesReturns;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.SalesManagment.Transactions.SalesReturns
{
    internal class SalesReturnService : AccountsServiceBase, ISalesReturnService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly ISeriesService _seriesService;

        public SalesReturnService(
            IAccountUnitOfWork uow,
            IAccountsQueriesManager queriesManager,
            IMapper mapper,
            IExceptionManager exceptionManager,
            ITenantResolver tenantResolver,
            ISeriesService seriesService)
            : base(uow, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _seriesService = seriesService;
        }

        private ISalesReturnCommandRepository _commands => _accountUoW.SalesReturn;
        private ISalesReturnQueryRepository _queries => _queriesManager.SalesReturn;

        // ================= CREATE =================
        public async Task<ReturnBase<SalesReturnDto>> Create(SalesReturnCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<SalesReturn>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                const string SCREEN_CODE = "Sales Return";

                var series = await _queriesManager.Series.GetByScreen_IDAsync(SCREEN_CODE);

                if (series == null || !series.IsActive)
                    return ReturnBase<SalesReturnDto>.Fail(
                        new Exception($"No active series for '{SCREEN_CODE}'"),
                        _exceptionManager);

                entity.SeriesId = series.Id;

                var seriesResult = await _seriesService
                    .GetSeriesCodeWithCustomDateUsingSeriesDetails(series.Id, entity.ReturnDate);

                if (!seriesResult.Succeeded || seriesResult.Result == null)
                    return ReturnBase<SalesReturnDto>.Fail(seriesResult.Errors);

                entity.ReturnNumber = seriesResult.Result["FinelSeriesCodeAndSeriesNumber"];
                entity.RunningNumber = int.Parse(seriesResult.Result["RunningNumber"]);

                CreateLines(entity, dto);
                CreateAdjustments(entity, dto);

                var insert = await _commands.InsertAsync(entity);
                if (!insert.Succeeded)
                    return ReturnBase<SalesReturnDto>.Fail(insert.Errors);

                var save = await _accountUoW.SaveAsync();
                if (!save.Succeeded)
                    return ReturnBase<SalesReturnDto>.Fail(save.Errors);

                return ReturnBase<SalesReturnDto>.Success(_mapper.Map<SalesReturnDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<SalesReturnDto>.Fail(ex, _exceptionManager);
            }
        }

        // ================= UPDATE =================
        public async Task<ReturnBase<SalesReturnDto>> Update(SalesReturnUpdateDto dto)
        {
            try
            {
                var entity = await _queries.GetById(dto.Id);

                if (entity == null)
                    return ReturnBase<SalesReturnDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = $"SalesReturn {dto.Id} not found" }
                    });

                _mapper.Map(dto, entity);

                await UpdateLines(entity, dto);
                await UpdateAdjustments(entity, dto);

                var save = await _accountUoW.SaveAsync();
                if (!save.Succeeded)
                    return ReturnBase<SalesReturnDto>.Fail(save.Errors);

                return ReturnBase<SalesReturnDto>.Success(_mapper.Map<SalesReturnDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<SalesReturnDto>.Fail(ex, _exceptionManager);
            }
        }

        // ================= DELETE =================
        public async Task<ReturnBase<SalesReturnDto>> Delete(long id)
        {
            try
            {
                var entity = await _queries.GetById(id);

                if (entity == null)
                    return ReturnBase<SalesReturnDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = $"SalesReturn {id} not found" }
                    });

                var delete = await _commands.DeleteAsync(id);
                if (!delete.Succeeded)
                    return ReturnBase<SalesReturnDto>.Fail(delete.Errors);

                var save = await _accountUoW.SaveAsync();
                if (!save.Succeeded)
                    return ReturnBase<SalesReturnDto>.Fail(save.Errors);

                return ReturnBase<SalesReturnDto>.Success(_mapper.Map<SalesReturnDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<SalesReturnDto>.Fail(ex, _exceptionManager);
            }
        }

        // ================= GET =================
        public async Task<ReturnBase<SalesReturnDto>> GetById(long id)
        {
            try
            {
                var entity = await _queries.GetById(id);

                if (entity == null)
                    return ReturnBase<SalesReturnDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = $"SalesReturn {id} not found" }
                    });

                return ReturnBase<SalesReturnDto>.Success(_mapper.Map<SalesReturnDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<SalesReturnDto>.Fail(ex, _exceptionManager);
            }
        }

        // ================= SEARCH =================
        public async Task<ReturnBase<IEnumerable<SalesReturnReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var result = await _queriesManager.SalesReturn.Search(sqlQueryOptions);

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<SalesReturnReturnSearchDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<SalesReturnReturnSearchDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<SalesReturnReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        // ================= LINES =================
        private void CreateLines(SalesReturn entity, SalesReturnCreateDto dto)
        {
            if (dto.SalesReturnLines == null || !dto.SalesReturnLines.Any())
            {
                entity.SalesReturnLines = new List<SalesReturnLine>();
                return;
            }

            entity.SalesReturnLines = _mapper.Map<List<SalesReturnLine>>(dto.SalesReturnLines);

            foreach (var line in entity.SalesReturnLines)
                line.SalesReturn = entity;
        }

        private async Task UpdateLines(SalesReturn entity, SalesReturnUpdateDto dto)
        {
            var existing = entity.SalesReturnLines.ToList();

            if (dto.SalesReturnLines == null || !dto.SalesReturnLines.Any())
            {
                var allIds = existing.Select(x => x.Id).ToList();

                if (allIds.Any())
                    await _commands.DeleteSalesReturnLinesBySalesReturnIds(allIds);

                entity.SalesReturnLines.Clear(); // 🔥 مهم
                return;
            }

            var dtoIds = dto.SalesReturnLines
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            foreach (var dtoLine in dto.SalesReturnLines)
            {
                if (dtoLine.Id == 0)
                {
                    var newEntity = _mapper.Map<SalesReturnLine>(dtoLine);
                    newEntity.SalesReturnId = entity.Id;
                    entity.SalesReturnLines.Add(newEntity);
                }
                else
                {
                    var existingEntity = existing.FirstOrDefault(x => x.Id == dtoLine.Id);

                    if (existingEntity != null)
                        _mapper.Map(dtoLine, existingEntity);
                }
            }

            var removed = existing
                .Where(x => !dtoIds.Contains(x.Id))
                .ToList();

            if (removed.Any())
            {
                await _commands.DeleteSalesReturnLinesBySalesReturnIds(removed.Select(x => x.Id).ToList());

                foreach (var item in removed)
                    entity.SalesReturnLines.Remove(item);
            }
        }

        private void CreateAdjustments(SalesReturn entity, SalesReturnCreateDto dto)
        {
            if (dto.SalesReturnAdjustments == null || !dto.SalesReturnAdjustments.Any())
            {
                entity.SalesReturnAdjustments = new List<SalesReturnAdjustment>();
                return;
            }

            entity.SalesReturnAdjustments = _mapper.Map<List<SalesReturnAdjustment>>(dto.SalesReturnAdjustments);

            foreach (var adj in entity.SalesReturnAdjustments)
                adj.SalesReturn = entity;
        }

        private async Task UpdateAdjustments(SalesReturn entity, SalesReturnUpdateDto dto)
        {
            var existing = entity.SalesReturnAdjustments.ToList();

            if (dto.SalesReturnAdjustments == null || !dto.SalesReturnAdjustments.Any())
            {
                var allIds = existing.Select(x => x.Id).ToList();

                if (allIds.Any())
                    await _commands.DeleteSalesReturnAdjustmentsBySalesReturnIds(allIds);

                entity.SalesReturnAdjustments.Clear(); // 🔥 مهم
                return;
            }

            var dtoIds = dto.SalesReturnAdjustments
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            foreach (var dtoAdj in dto.SalesReturnAdjustments)
            {
                if (dtoAdj.Id == 0)
                {
                    var newEntity = _mapper.Map<SalesReturnAdjustment>(dtoAdj);
                    newEntity.SalesReturnId = entity.Id;
                    entity.SalesReturnAdjustments.Add(newEntity);
                }
                else
                {
                    var existingEntity = existing.FirstOrDefault(x => x.Id == dtoAdj.Id);

                    if (existingEntity != null)
                        _mapper.Map(dtoAdj, existingEntity);
                }
            }

            var removed = existing
                .Where(x => !dtoIds.Contains(x.Id))
                .ToList();

            if (removed.Any())
            {
                await _commands.DeleteSalesReturnAdjustmentsBySalesReturnIds(removed.Select(x => x.Id).ToList());

                foreach (var item in removed)
                    entity.SalesReturnAdjustments.Remove(item);
            }
        }
    }
}