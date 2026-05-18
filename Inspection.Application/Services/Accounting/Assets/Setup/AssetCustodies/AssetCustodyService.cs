using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetCustodies;
using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetCustodies.AssetCustodyLines;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.Assets.Setup.AssetCustodies;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Assets.Setup.AssetCustodies;
using Inspection.Application.Contracts.Services.Accounting.Assets.Setup.AssetCustodies;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Accounting.Assets.Setup.AssetCustodies;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.Assets.Setup.AssetCustodies
{
    internal class AssetCustodyService : AccountsServiceBase, IAssetCustodyService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly ISeriesService _seriesService;


        public AssetCustodyService(
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
        private IAssetCustodyCommandRepository _commands => _accountUoW.AssetCustody;
        private IAssetCustodyQueryRepository _queries => _queriesManager.AssetCustody;



        public async Task<ReturnBase<AssetCustodyDto>> Create(AssetCustodyCreateDto dto)
        {
            try
            {
                var dateValidationError = ValidateDateCreate(dto.AssetCustodyLines);
                if (dateValidationError != null)
                    return ReturnBase<AssetCustodyDto>.Fail(new List<ReturnBaseError> { dateValidationError });

                var entity = _mapper.Map<AssetCustody>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                CreateAssetCustodyLines(entity, dto);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<AssetCustodyDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<AssetCustodyDto>.Fail(saveResult.Errors);

                return ReturnBase<AssetCustodyDto>.Success(_mapper.Map<AssetCustodyDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<AssetCustodyDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<AssetCustodyDto>> Update(AssetCustodyUpdateDto dto)
        {
            try
            {
                var dateValidationError = ValidateDateUpdate(dto.AssetCustodyLines);
                if (dateValidationError != null)
                    return ReturnBase<AssetCustodyDto>.Fail(new List<ReturnBaseError> { dateValidationError });

                var entity = await _queriesManager.AssetCustody.GetById(dto.Id);

                if (entity == null)
                    return ReturnBase<AssetCustodyDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404", ErrorMessage = $"Asset Custody with Id {dto.Id} was not found" }
            });


                _mapper.Map(dto, entity);

                await UpdateAssetCustodyLines(entity, dto);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<AssetCustodyDto>.Fail(saveResult.Errors);
                return ReturnBase<AssetCustodyDto>.Success(_mapper.Map<AssetCustodyDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<AssetCustodyDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<AssetCustodyDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.AssetCustody.GetById(id);
                if (entity == null)
                    return ReturnBase<AssetCustodyDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = $"Asset Custody with Id {id} was not found" }
                    });


                var updateResult = await _commands.DeleteAsync(id);
                if (!updateResult.Succeeded) return ReturnBase<AssetCustodyDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded) return ReturnBase<AssetCustodyDto>.Fail(saveResult.Errors);

                return ReturnBase<AssetCustodyDto>.Success(_mapper.Map<AssetCustodyDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<AssetCustodyDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<AssetCustodyDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.AssetCustody.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = $"Asset Custody with Id '{id}' was not found."
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<AssetCustodyDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<AssetCustodyDto>(entity);

                return ReturnBase<AssetCustodyDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<AssetCustodyDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<AssetCustodyReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult =
                    await _queriesManager.AssetCustody.Search(sqlQueryOptions);

                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<AssetCustodyReturnSearchDto>>
                        .Fail(getResult.Errors);

                return ReturnBase<IEnumerable<AssetCustodyReturnSearchDto>>
                    .Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<AssetCustodyReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }


        // Create && Update  Any Detail For Cash Transfer (Lines) should be handled in these methods to make sure that all operations will be in the same transaction scope

        // AssetCustodyLines
        private void CreateAssetCustodyLines(AssetCustody entity, AssetCustodyCreateDto dto)
        {
            if (dto.AssetCustodyLines == null || !dto.AssetCustodyLines.Any())
            {
                entity.AssetCustodyLines = new List<AssetCustodyLine>();
                return;
            }

            entity.AssetCustodyLines = _mapper.Map<List<AssetCustodyLine>>(dto.AssetCustodyLines);
            foreach (var line in entity.AssetCustodyLines)
            {
                line.AssetCustody = entity;
            }
        }

        private async Task UpdateAssetCustodyLines(AssetCustody entity, AssetCustodyUpdateDto dto)
        {
            var existing = entity.AssetCustodyLines.ToList();

            if (dto.AssetCustodyLines == null || !dto.AssetCustodyLines.Any())
            {
                var allIds = existing.Select(x => x.Id).ToList();

                if (allIds.Any())
                    await _commands.DeleteAssetCustodyLinesByAssetCustodyIds(allIds);
                return;
            }

            var dtoIds = dto.AssetCustodyLines
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            foreach (var lineDto in dto.AssetCustodyLines)
            {
                if (lineDto.Id == 0)
                {
                    var newEntity = _mapper.Map<AssetCustodyLine>(lineDto);
                    newEntity.AssetCustodyId = entity.Id;
                    entity.AssetCustodyLines.Add(newEntity);
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
                await _commands.DeleteAssetCustodyLinesByAssetCustodyIds(removed);
        }



        private ReturnBaseError? ValidateDateCreate(List<AssetCustodyLineCreateDto> lines)
        {

            if (lines?.Count > 0)
            {
                // 1. Validate single line ranges
                foreach (var line in lines)
                {
                    if (line.CustodyEndDate.HasValue &&
                        line.CustodyStartDate > line.CustodyEndDate.Value)
                    {
                        return new ReturnBaseError
                        {
                            ErrorCode = "400",
                            ErrorMessage = $"Custody start date {line.CustodyStartDate} cannot be later than custody end date {line.CustodyEndDate}."
                        };
                    }
                }
                var grouped = lines.GroupBy(x => x.FixedAssetId);

                foreach (var group in grouped)
                {
                    var ordered = group
                        .OrderBy(x => x.CustodyStartDate)
                        .ToList();

                    for (int i = 0; i < ordered.Count - 1; i++)
                    {
                        var current = ordered[i];
                        var next = ordered[i + 1];

                        var currentEnd = current.CustodyEndDate ?? DateTime.MaxValue;

                        if (next.CustodyStartDate <= currentEnd)
                        {
                            return new ReturnBaseError
                            {
                                ErrorCode = "400",
                                ErrorMessage = $"Custody start date {next.CustodyStartDate} cannot be earlier than or equal to custody end date {current.CustodyEndDate} for the same asset."
                            };
                        }
                    }
                }
                return null;
            }

            return null;

        }

        private ReturnBaseError? ValidateDateUpdate(List<AssetCustodyLineUpdateDto> lines)
        {

            if (lines?.Count > 0)
            {
                // 1. Validate single line ranges

                foreach (var line in lines)
                {
                    if (line.CustodyEndDate.HasValue &&
                        line.CustodyStartDate > line.CustodyEndDate.Value)
                    {
                        return new ReturnBaseError
                        {
                            ErrorCode = "400",
                            ErrorMessage = $"Custody start date {line.CustodyStartDate} cannot be later than custody end date {line.CustodyEndDate}."
                        };
                    }
                }
                var grouped = lines.GroupBy(x => x.FixedAssetId);

                foreach (var group in grouped)
                {
                    var ordered = group
                        .OrderBy(x => x.CustodyStartDate)
                        .ToList();

                    for (int i = 0; i < ordered.Count - 1; i++)
                    {
                        var current = ordered[i];
                        var next = ordered[i + 1];

                        var currentEnd = current.CustodyEndDate ?? DateTime.MaxValue;

                        if (next.CustodyStartDate <= currentEnd)
                        {
                            return new ReturnBaseError
                            {
                                ErrorCode = "400",
                                ErrorMessage = $"Custody start date {next.CustodyStartDate} cannot be earlier than or equal to custody end date {current.CustodyEndDate} for the same asset."
                            };
                        }
                    }
                }
                return null;
            }

            return null;

        }



    }
}