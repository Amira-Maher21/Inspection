using AutoMapper;
using Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryScraps;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Inventory.Transaction.InventoryScraps;
using Inspection.Application.Contracts.Repositories.Query.Inventory.Transaction.InventoryScraps;
using Inspection.Application.Contracts.Services.Inventory.Transaction.InventoryScraps;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.Inventory.Transaction.InventoryScraps;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Inventory.Transaction.InventoryScraps
{
    public class InventoryScrapService : AccountsServiceBase, IInventoryScrapService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IAccountsQueriesManager _queriesManager;
        private readonly ISeriesService _seriesService;


        public InventoryScrapService(
            IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper,
            IExceptionManager exceptionManager,
            ITenantResolver tenantResolver,
            ISeriesService seriesService
        )
            : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _queriesManager = queriesManager;
            _tenantResolver = tenantResolver;
            _seriesService = seriesService;

        }

        private IInventoryScrapCommandRepository _commands => _accountUoW.InventoryScrap;

        private IInventoryScrapQueryRepository _queries =>
            _queriesManager.InventoryScrap
            ?? throw new NullReferenceException("IInventoryScrapQueryRepository is null");


        // ================= CREATE =================
        private void CreateInventoryScrapLines(InventoryScrap entity, InventoryScrapCreateDto dto)
        {
            if (dto.InventoryScrapLines == null || !dto.InventoryScrapLines.Any())
            {
                entity.InventoryScrapLines = new List<InventoryScrapLine>();
                return;
            }

            entity.InventoryScrapLines = _mapper.Map<List<InventoryScrapLine>>(dto.InventoryScrapLines);

            foreach (var line in entity.InventoryScrapLines)
            {
                line.InventoryScrap = entity;
            }
        }
        public async Task<ReturnBase<InventoryScrapDto>> Create(InventoryScrapCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<InventoryScrap>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // SCREEN CODE
                const string SCREEN_CODE = "Inventory Scrap";

                var series = await _queriesManager.Series.GetByScreen_IDAsync(SCREEN_CODE);

                if (series == null || !series.IsActive)
                {
                    return ReturnBase<InventoryScrapDto>.Fail(
                        new Exception($"No active series configured for screen '{SCREEN_CODE}'"),
                        _exceptionManager
                    );
                }

                entity.SeriesId = series.Id;

                // Generate Series
                var seriesResult = await _seriesService
                    .GetSeriesCodeWithCustomDateUsingSeriesDetails(series.Id, entity.InventoryScrapDate);

                if (!seriesResult.Succeeded || seriesResult.Result == null)
                    return ReturnBase<InventoryScrapDto>.Fail(seriesResult.Errors);

                entity.InventoryScrapNumber = seriesResult.Result["FinelSeriesCodeAndSeriesNumber"];
                entity.RunningNumber = int.Parse(seriesResult.Result["RunningNumber"]);

                //  ( SalesInvoice)
                CreateInventoryScrapLines(entity, dto);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<InventoryScrapDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<InventoryScrapDto>.Fail(saveResult.Errors);

                return ReturnBase<InventoryScrapDto>.Success(_mapper.Map<InventoryScrapDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<InventoryScrapDto>.Fail(ex, _exceptionManager);
            }
        }


        // ================= UPDATE =================
        public async Task<ReturnBase<InventoryScrapDto>> Update(InventoryScrapUpdateDto dto)
        {
            try
            {
                var entity = await _queries.GetById(dto.Id);
                if (entity == null)
                    return ReturnBase<InventoryScrapDto>.Fail(new List<ReturnBaseError>
            {
                new()
                {
                    ErrorCode = "404",
                    ErrorMessage = "InventoryScrap Not Found"
                }
            });

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // MAIN
                _mapper.Map(dto, entity);

                // LINES
                await UpdateInventoryScrapLines(entity, dto);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<InventoryScrapDto>.Fail(saveResult.Errors);

                return ReturnBase<InventoryScrapDto>.Success(_mapper.Map<InventoryScrapDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<InventoryScrapDto>.Fail(ex, _exceptionManager);
            }
        }
        private async Task UpdateInventoryScrapLines(InventoryScrap entity, InventoryScrapUpdateDto dto)
        {
            var existing = entity.InventoryScrapLines.ToList();

            if (dto.InventoryScrapLines == null || !dto.InventoryScrapLines.Any())
            {
                var allIds = existing.Select(x => x.Id).ToList();

                if (allIds.Any())
                    await _commands.DeleteInventoryScrapLineByIds(allIds);
                return;
            }

            var dtoIds = dto.InventoryScrapLines
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            foreach (var lineDto in dto.InventoryScrapLines)
            {
                if (lineDto.Id == 0)
                {
                    var newEntity = _mapper.Map<InventoryScrapLine>(lineDto);
                    newEntity.InventoryScrapId = entity.Id;
                    entity.InventoryScrapLines.Add(newEntity);
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
                await _commands.DeleteInventoryScrapLineByIds(removed);
        }



        public async Task<ReturnBase<InventoryScrapDto>> Delete(long id)
        {
            try
            {
                var entity = await _queries.GetById(id);
                if (entity == null)
                    return ReturnBase<InventoryScrapDto>.Fail(new List<ReturnBaseError>
                {
                    new() { ErrorCode = "404", ErrorMessage = $"Inventory Scrap with Id {id} not found" }
                });

                var deleteResult = await _commands.DeleteById(id);
                if (!deleteResult.Succeeded)
                    return ReturnBase<InventoryScrapDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<InventoryScrapDto>.Fail(saveResult.Errors);

                return ReturnBase<InventoryScrapDto>.Success(_mapper.Map<InventoryScrapDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<InventoryScrapDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<InventoryScrapDto>> GetById(long id)
        {
            try
            {
                var entity = await _queries.GetById(id);
                if (entity == null)
                    return ReturnBase<InventoryScrapDto>.Fail(
                        new List<ReturnBaseError>
                        {
                            new() { ErrorCode = "404", ErrorMessage = "InventoryScrap Not Found" }
                        });

                return ReturnBase<InventoryScrapDto>.Success(_mapper.Map<InventoryScrapDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<InventoryScrapDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<IEnumerable<InventoryScrapReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var result = await _queries.Search(sqlQueryOptions);

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<InventoryScrapReturnSearchDto>>.Fail(result.Errors);

                var mapped = result.Result
                    .Select(x => _mapper.Map<InventoryScrapReturnSearchDto>(x))
                    .ToList();

                return ReturnBase<IEnumerable<InventoryScrapReturnSearchDto>>.Success(mapped);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InventoryScrapReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }
    }
}