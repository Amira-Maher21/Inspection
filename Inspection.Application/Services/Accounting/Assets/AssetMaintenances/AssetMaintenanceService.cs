using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetMaintenanceDTOs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.Assets.AssetMaintenances;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Assets.AssetMaintenances;
using Inspection.Application.Contracts.Services.Accounting.Assets.AssetMaintenances;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Accounting.Assets.AssetMaintenances;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.Assets.AssetMaintenances
{
    internal class AssetMaintenanceService : AccountsServiceBase, IAssetMaintenanceService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly ISeriesService _seriesService;

        public AssetMaintenanceService(
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
        private IAssetMaintenanceCommandRepository _commands => _accountUoW.AssetMaintenance;
        private IAssetMaintenanceQueryRepository _queries => _queriesManager.AssetMaintenance;

        public async Task<ReturnBase<AssetMaintenanceDto>> Create(AssetMaintenanceCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<AssetMaintenance>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // Series
                const string SCREEN_CODE = "Asset Maintenance";

                var series = await _queriesManager.Series.GetByScreen_IDAsync(SCREEN_CODE);

                if (series == null || !series.IsActive)
                    return ReturnBase<AssetMaintenanceDto>.Fail(
                        new Exception($"No active series configured for screen '{SCREEN_CODE}'"),
                        _exceptionManager);

                entity.SeriesId = series.Id;

                var seriesResult = await _seriesService
                    .GetSeriesCodeWithCustomDateUsingSeriesDetails(series.Id, entity.MaintenanceDate);

                if (!seriesResult.Succeeded || seriesResult.Result == null)
                    return ReturnBase<AssetMaintenanceDto>.Fail(seriesResult.Errors);

                entity.MaintenanceCode = seriesResult.Result["FinelSeriesCodeAndSeriesNumber"];
                entity.RunningNumber = int.Parse(seriesResult.Result["RunningNumber"]);

                CreateAssetMaintenanceLines(entity, dto);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<AssetMaintenanceDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<AssetMaintenanceDto>.Fail(saveResult.Errors);

                return ReturnBase<AssetMaintenanceDto>.Success(_mapper.Map<AssetMaintenanceDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<AssetMaintenanceDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<AssetMaintenanceDto>> Update(AssetMaintenanceUpdateDto dto)
        {
            try
            {
                var entity = await _queriesManager.AssetMaintenance.GetById(dto.Id);

                if (entity == null)
                    return ReturnBase<AssetMaintenanceDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404", ErrorMessage = $"Asset Maintenance with Id {dto.Id} was not found" }
            });

                _mapper.Map(dto, entity);

                await UpdateAssetMaintenanceLines(entity, dto);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<AssetMaintenanceDto>.Fail(saveResult.Errors);

                return ReturnBase<AssetMaintenanceDto>.Success(_mapper.Map<AssetMaintenanceDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<AssetMaintenanceDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<AssetMaintenanceDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.AssetMaintenance.GetById(id);
                if (entity == null)
                    return ReturnBase<AssetMaintenanceDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = $"Asset Maintenance with Id {id} was not found" }
                    });


                var updateResult = await _commands.DeleteAsync(id);
                if (!updateResult.Succeeded) return ReturnBase<AssetMaintenanceDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded) return ReturnBase<AssetMaintenanceDto>.Fail(saveResult.Errors);

                return ReturnBase<AssetMaintenanceDto>.Success(_mapper.Map<AssetMaintenanceDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<AssetMaintenanceDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<AssetMaintenanceDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.AssetMaintenance.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = $"Asset Maintenance with Id '{id}' was not found."
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<AssetMaintenanceDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<AssetMaintenanceDto>(entity);

                return ReturnBase<AssetMaintenanceDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<AssetMaintenanceDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<AssetMaintenanceReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult =
                    await _queriesManager.AssetMaintenance.Search(sqlQueryOptions);

                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<AssetMaintenanceReturnSearchDto>>
                        .Fail(getResult.Errors);

                return ReturnBase<IEnumerable<AssetMaintenanceReturnSearchDto>>
                    .Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<AssetMaintenanceReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }

        // Create && Update  Any Detail For Asset Maintenance (Lines) should be handled in these methods to make sure that all operations will be in the same transaction scope

        // AssetMaintenanceLines
        private void CreateAssetMaintenanceLines(AssetMaintenance entity, AssetMaintenanceCreateDto dto)
        {
            if (dto.AssetMaintenanceLines == null || !dto.AssetMaintenanceLines.Any())
            {
                entity.AssetMaintenanceLines = new List<AssetMaintenanceLine>();
                return;
            }

            entity.AssetMaintenanceLines = _mapper.Map<List<AssetMaintenanceLine>>(dto.AssetMaintenanceLines);
            foreach (var line in entity.AssetMaintenanceLines)
            {
                line.AssetMaintenance = entity;
            }
        }

        private async Task UpdateAssetMaintenanceLines(AssetMaintenance entity, AssetMaintenanceUpdateDto dto)
        {
            var existing = entity.AssetMaintenanceLines.ToList();

            if (dto.AssetMaintenanceLines == null || !dto.AssetMaintenanceLines.Any())
            {
                var allIds = existing.Select(x => x.Id).ToList();

                if (allIds.Any())
                    await _commands.DeleteAssetMaintenanceLinesByIds(allIds);
                return;
            }

            var dtoIds = dto.AssetMaintenanceLines
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            foreach (var lineDto in dto.AssetMaintenanceLines)
            {
                if (lineDto.Id == 0)
                {
                    var newEntity = _mapper.Map<AssetMaintenanceLine>(lineDto);
                    newEntity.AssetMaintenanceId = entity.Id;
                    entity.AssetMaintenanceLines.Add(newEntity);
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
                await _commands.DeleteAssetMaintenanceLinesByIds(removed);
        }
    }
}