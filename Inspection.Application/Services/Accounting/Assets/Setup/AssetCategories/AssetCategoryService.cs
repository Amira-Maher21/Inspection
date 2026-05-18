using AutoMapper;
using ClosedXML.Excel;
using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetCategories;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.Assets.Setup.AssetCategories;
using Inspection.Application.Contracts.Services.Accounting.Assets.Setup.AssetCategories;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Application.Shared.SharedValidation;
using Inspection.Domain.Models.Accounting.Assets.Setup.AssetCategories;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.Assets.Setup.AssetCategories
{

    public class AssetCategoryService : AccountsServiceBase, IAssetCategoryService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public AssetCategoryService(IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper, ITenantResolver tenantResolver,
            IExceptionManager exceptionManager
            , IExcelTemplateGenerator templateGenerator
)
            : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;

        }

        public async Task<ReturnBase<AssetCategoryDto>> Create(AssetCategoryCreateDto createDto)
        {
            try
            {
                createDto.CategoryCode.ValidateAsCode();
                createDto.CategoryName.ValidateAsName();
                var entity = _mapper.Map<AssetCategory>(createDto);

                var TenantName = _tenantResolver.GetTenantName();
                entity.Tenant_ID = TenantName;

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<AssetCategoryDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<AssetCategoryDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<AssetCategoryDto>(entity);

                return ReturnBase<AssetCategoryDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<AssetCategoryDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<AssetCategoryDto>> Update(AssetCategoryUpdateDto updateDto)
        {
            try
            {
                updateDto.CategoryCode.ValidateAsCode();
                updateDto.CategoryName.ValidateAsName();
                var entity = await _queriesManager.AssetCategory.GetById(updateDto.Id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Company Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<AssetCategoryDto>.Fail(listOfErrors);
                }


                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(updateDto, entity);
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<AssetCategoryDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<AssetCategoryDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<AssetCategoryDto>(entity);

                return ReturnBase<AssetCategoryDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<AssetCategoryDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<AssetCategoryDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.AssetCategory.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "AssetCategory Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<AssetCategoryDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<AssetCategoryDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<AssetCategoryDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<AssetCategoryDto>(entity);

                return ReturnBase<AssetCategoryDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<AssetCategoryDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<AssetCategoryReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult =
                    await _queriesManager.AssetCategory.Search(sqlQueryOptions);

                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<AssetCategoryReturnSearchDto>>
                        .Fail(getResult.Errors);

                return ReturnBase<IEnumerable<AssetCategoryReturnSearchDto>>
                    .Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<AssetCategoryReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<AssetCategoryDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.AssetCategory.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "AssetCategory Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<AssetCategoryDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<AssetCategoryDto>(entity);

                return ReturnBase<AssetCategoryDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<AssetCategoryDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<AssetCategoryDto>> GetByCode(string code)
        {
            try
            {
                var entity = await _queriesManager.AssetCategory.GetByCode(code);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Asset Category Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<AssetCategoryDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<AssetCategoryDto>(entity);

                return ReturnBase<AssetCategoryDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<AssetCategoryDto>.Fail(ex, _exceptionManager);
            }
        }




        public async Task<ReturnBase<ImportResultDto>> ImportAssetCategory(ExcelImportRequestDto dto)
        {
            try
            {
                var finalResult = new ImportResultDto();
                var profile = new AssetCategoryImportProfile();

                using var stream = dto.File.OpenReadStream();
                using var workbook = new XLWorkbook(stream);
                var ws = workbook.Worksheets.First();

                var headerRow = ws.FirstRowUsed();
                if (headerRow == null)
                    throw new InvalidOperationException("Excel file has no header row.");

                var headers = headerRow.Cells()
                    .Select(c => c.GetString().Trim())
                    .Where(h => !string.IsNullOrWhiteSpace(h))
                    .ToList();

                var firstDataRow = headerRow.RowNumber() + 1;
                var lastRow = ws.LastRowUsed()?.RowNumber() ?? firstDataRow - 1;

                for (int r = firstDataRow; r <= lastRow; r++)
                {
                    finalResult.ProcessedCount++;

                    var rawRow = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                    for (int c = 0; c < headers.Count; c++)
                        rawRow[headers[c]] = ws.Cell(r, c + 1).GetString().Trim();

                    var rowErrors = new List<string>();
                    AssetCategoryCreateDto? createDto = null;

                    try
                    {
                        createDto = await profile.MapAsync(rawRow, rowErrors);
                        await profile.ValidateAsync(createDto, rawRow, rowErrors);
                    }
                    catch (Exception ex)
                    {
                        rowErrors.Add(ex.Message);
                    }

                    if (rowErrors.Any() || createDto == null)
                    {
                        finalResult.FailedRows.Add(new ImportRowErrorDto
                        {
                            RowNumber = r,
                            RawRowData = string.Join(" | ", rawRow.Select(kv => $"{kv.Key}:{kv.Value}")),
                            Errors = rowErrors.Any() ? rowErrors : new() { "Row mapping failed." }
                        });
                        continue;
                    }

                    // -------- Create AssetCategory --------
                    var createResult = await Create(createDto);

                    if (!createResult.Succeeded)
                    {
                        finalResult.FailedRows.Add(new ImportRowErrorDto
                        {
                            RowNumber = r,
                            RawRowData = string.Join(" | ", rawRow.Select(kv => $"{kv.Key}:{kv.Value}")),
                            Errors = createResult.Errors.Select(e => $"{e.ErrorCode}: {e.ErrorMessage}").ToList()
                        });
                        continue;
                    }

                    finalResult.CreatedCount++;
                }

                return ReturnBase<ImportResultDto>.Success(finalResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<ImportResultDto>.Fail(ex, _exceptionManager);
            }
        }

        // ------------------- Download Template -------------------
        public async Task<ReturnBase<FileResultDto>> DownloadTemplate()
        {
            try
            {
                var content = await _templateGenerator.GenerateTemplateAsync<AssetCategoryImportTemplateDto>("AssetCategory");

                var file = new FileResultDto
                {
                    Content = content,
                    FileName = "AssetCategory.xlsx"
                };

                return ReturnBase<FileResultDto>.Success(file);
            }
            catch (Exception ex)
            {
                return ReturnBase<FileResultDto>.Fail(ex, _exceptionManager);
            }
        }

        // Helper to access command repository
        private IAssetCategoryCommandRepository _commands => _accountUoW.AssetCategory;
    }
}



