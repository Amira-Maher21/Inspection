using AutoMapper;
using ClosedXML.Excel;
using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetDepreciationSchedules;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.Assets.AssetDepreciationSchedules;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Assets.Setup.FixedAssets;
using Inspection.Application.Contracts.Services.Accounting.Assets.AssetDepreciationSchedules;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Accounting.Assets;
using Inspection.Domain.Models.Accounting.Assets.FixedAssets;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.Assets.AssetDepreciationSchedules
{
    public class AssetDepreciationScheduleService : AccountsServiceBase, IAssetDepreciationScheduleService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public AssetDepreciationScheduleService(
    IAccountUnitOfWork accountUoW,
    IAccountsQueriesManager queriesManager,
    IMapper mapper,
    IExceptionManager exceptionManager,
    ITenantResolver tenantResolver,
    IExcelTemplateGenerator templateGenerator)
    : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;

        }
        public async Task<ReturnBase<AssetDepreciationScheduleDto>> Create(
            AssetDepreciationScheduleCreateDto createDto)
        {
            try
            {

                var entity = _mapper.Map<AssetDepreciationSchedule>(createDto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();
                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<AssetDepreciationScheduleDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<AssetDepreciationScheduleDto>.Fail(saveResult.Errors);

                var resultDto = _mapper.Map<AssetDepreciationScheduleDto>(entity);
                return ReturnBase<AssetDepreciationScheduleDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<AssetDepreciationScheduleDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<AssetDepreciationScheduleDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.AssetDepreciationSchedules.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "AssetDepreciationSchedule Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<AssetDepreciationScheduleDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<AssetDepreciationScheduleDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<AssetDepreciationScheduleDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<AssetDepreciationScheduleDto>(entity);

                return ReturnBase<AssetDepreciationScheduleDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<AssetDepreciationScheduleDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<List<AssetDepreciationScheduleDto>>> GetAll()
        {
            try
            {
                var result = await _queriesManager.AssetDepreciationSchedules.GetAll();

                if (!result.Succeeded)
                {
                    return ReturnBase<List<AssetDepreciationScheduleDto>>.Fail(result.Errors);
                }

                var mapped = _mapper.Map<List<AssetDepreciationScheduleDto>>(result.Result);

                return ReturnBase<List<AssetDepreciationScheduleDto>>.Success(mapped);
            }
            catch (Exception ex)
            {
                return ReturnBase<List<AssetDepreciationScheduleDto>>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<AssetDepreciationScheduleDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.AssetDepreciationSchedules.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "AssetDepreciationSchedule not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<AssetDepreciationScheduleDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<AssetDepreciationScheduleDto>(entity);

                return ReturnBase<AssetDepreciationScheduleDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<AssetDepreciationScheduleDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<AssetDepreciationScheduleReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.AssetDepreciationSchedules.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<AssetDepreciationScheduleReturnSearchDto>>.Fail(getResult.Errors);

                var mappedResult = _mapper.Map<IEnumerable<AssetDepreciationScheduleReturnSearchDto>>(getResult.Result);

                return ReturnBase<IEnumerable<AssetDepreciationScheduleReturnSearchDto>>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<AssetDepreciationScheduleReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<AssetDepreciationScheduleDto>> Update(AssetDepreciationScheduleUpdateDto updateDto)
        {
            try
            {
                var entity = await _queriesManager.AssetDepreciationSchedules.GetById(updateDto.Id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Default Account Assignment Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<AssetDepreciationScheduleDto>.Fail(listOfErrors);
                }
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(updateDto, entity);

                //entity.Tenant_ID = _tenantResolver.GetTenantName();


                //entity = _mapper.Map<AssetDepreciationSchedule>(updateDto);
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<AssetDepreciationScheduleDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<AssetDepreciationScheduleDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<AssetDepreciationScheduleDto>(entity);

                return ReturnBase<AssetDepreciationScheduleDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<AssetDepreciationScheduleDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<ImportResultDto>> ImportAssetDepreciationSchedule(
            ExcelImportRequestDto dto)
        {
            var result = new ImportResultDto();

            using var stream = dto.File.OpenReadStream();
            using var workbook = new XLWorkbook(stream);
            var ws = workbook.Worksheets.First();

            var profile = new AssetDepreciationScheduleImportProfile();
            var columns = profile.ColumnOrder;

            for (int r = 2; r <= ws.LastRowUsed().RowNumber(); r++)
            {
                result.ProcessedCount++;

                var rawRow = new Dictionary<string, string>();
                for (int i = 0; i < columns.Count; i++)
                    rawRow[columns[i]] = ws.Row(r).Cell(i + 1).GetString();

                var errors = new List<string>();
                var importDto = await profile.MapAsync(rawRow, errors);

                if (importDto != null)
                    await profile.ValidateAsync(importDto, rawRow, errors);

                if (errors.Any() || importDto == null)
                {
                    result.FailedRows.Add(new ImportRowErrorDto
                    {
                        RowNumber = r,
                        Errors = errors
                    });
                    continue;
                }

                var asset = await _commandFixedAssets
                    .GetByCode(importDto.AssetCode);

                if (asset == null)
                {
                    result.FailedRows.Add(new ImportRowErrorDto
                    {
                        RowNumber = r,
                        Errors = new List<string>
                {
                    $"Fixed Asset with code '{importDto.AssetCode}' not found."
                }
                    });
                    continue;
                }

                var createDto = new AssetDepreciationScheduleCreateDto
                {
                    AssetId = asset.Id,
                    PeriodYear = importDto.PeriodYear,
                    PeriodMonth = importDto.PeriodMonth,
                    DepreciationAmount = importDto.DepreciationAmount,
                    IsPosted = false
                };

                var createResult = await Create(createDto);

                if (!createResult.Succeeded)
                {
                    result.FailedRows.Add(new ImportRowErrorDto
                    {
                        RowNumber = r,
                        Errors = createResult.Errors
                            .Select(e => e.ErrorMessage)
                            .ToList()
                    });
                    continue;
                }

                result.CreatedCount++;
            }

            return ReturnBase<ImportResultDto>.Success(result);
        }

        public async Task<ReturnBase<FileResultDto>> DownloadTemplate()
        {
            try
            {
                var content = await _templateGenerator
                    .GenerateTemplateAsync<AssetDepreciationScheduleTampleteDto>("AssetDepreciationSchedule");

                var file = new FileResultDto
                {
                    Content = content,
                    FileName = "AssetDepreciationSchedule.xlsx"
                };

                return ReturnBase<FileResultDto>.Success(file);
            }
            catch (Exception ex)
            {
                return ReturnBase<FileResultDto>.Fail(ex, _exceptionManager);
            }
        }



        private IAssetDepreciationScheduleCommandRepository _commands
        {
            get { return _accountUoW.AssetDepreciationSchedule; }
        }
        private IFixedAssetQueryRepository _commandFixedAssets
        {
            get { return _queriesManager.FixedAsset; }
        }
    }
}