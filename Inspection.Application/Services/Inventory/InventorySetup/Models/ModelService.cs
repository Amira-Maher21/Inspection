using AutoMapper;
using ClosedXML.Excel;
using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.Models;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Inventory.InventorySetup.Models;
using Inspection.Application.Contracts.Services.Inventory.InventorySetup.Models;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Inventory.InventorySetup.Models;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Inventory.InventorySetup.Models
{
    internal class ModelService : AccountsServiceBase, IModelService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public ModelService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }
        //done
        public async Task<ReturnBase<ModelDto>> Create(ModelCreateDto createDto)
        {
            try
            {
                var entity = _mapper.Map<Model>(createDto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<ModelDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<ModelDto>.Fail(saveResult.Errors);

                var resultDto = _mapper.Map<ModelDto>(entity);
                return ReturnBase<ModelDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<ModelDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<ModelDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.Models.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Default Account Assignment Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<ModelDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<ModelDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<ModelDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<ModelDto>(entity);

                return ReturnBase<ModelDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<ModelDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<List<ModelDto>>> GetAll()
        {
            try
            {
                var result = await _queriesManager.Models.GetAll();

                if (!result.Succeeded)
                {
                    return ReturnBase<List<ModelDto>>.Fail(result.Errors);
                }

                var mapped = _mapper.Map<List<ModelDto>>(result.Result);

                return ReturnBase<List<ModelDto>>.Success(mapped);
            }
            catch (Exception ex)
            {
                return ReturnBase<List<ModelDto>>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<ModelDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.Models.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "UnitOfMeasure not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<ModelDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<ModelDto>(entity);

                return ReturnBase<ModelDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<ModelDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<IEnumerable<ModelSearchReturnDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.Models.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<ModelSearchReturnDto>>.Fail(getResult.Errors);

                var mappedResult = _mapper.Map<IEnumerable<ModelSearchReturnDto>>(getResult.Result);

                return ReturnBase<IEnumerable<ModelSearchReturnDto>>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ModelSearchReturnDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<ModelDto>> Update(ModelUpdateDto updateDto)
        {
            try
            {
                var entity = await _queriesManager.Models.GetById(updateDto.Id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "UnitOfMeasure Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<ModelDto>.Fail(listOfErrors);
                }

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(updateDto, entity);
                //entity = _mapper.Map<Model>(updateDto);

                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<ModelDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<ModelDto>.Fail(saveResult.Errors);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                var mappedResult = _mapper.Map<ModelDto>(entity);

                return ReturnBase<ModelDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<ModelDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<ImportResultDto>> ImportModel(ExcelImportRequestDto dto)
        {
            try
            {
                var finalResult = new ImportResultDto();
                var profile = new ModelImportProfile();

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

                var brandCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);

                for (int r = firstDataRow; r <= lastRow; r++)
                {
                    finalResult.ProcessedCount++;

                    var rawRow = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                    for (int c = 0; c < headers.Count; c++)
                        rawRow[headers[c]] = ws.Cell(r, c + 1).GetString().Trim();

                    var rowErrors = new List<string>();
                    ModelTampleteDto? templateDto = null;

                    try
                    {
                        templateDto = await profile.MapAsync(rawRow, rowErrors);

                        if (templateDto != null)
                            await profile.ValidateAsync(templateDto, rawRow, rowErrors);
                    }
                    catch (Exception ex)
                    {
                        rowErrors.Add(ex.Message);
                    }

                    if (templateDto == null)
                    {
                        finalResult.FailedRows.Add(new ImportRowErrorDto
                        {
                            RowNumber = r,
                            RawRowData = string.Join(" | ", rawRow.Select(kv => $"{kv.Key}:{kv.Value}")),
                            Errors = rowErrors.Any() ? rowErrors : new() { "Row mapping failed." }
                        });
                        continue;
                    }

                    if (!string.IsNullOrWhiteSpace(templateDto.BrandCode))
                    {
                        if (!brandCache.TryGetValue(templateDto.BrandCode, out var brandId))
                        {
                            var brand = await _queriesManager.Brands.GetByCode(templateDto.BrandCode);

                            if (brand == null)
                                rowErrors.Add($"Brand '{templateDto.BrandCode}' not found.");
                            else
                                brandCache[templateDto.BrandCode] = brandId = brand.Id;
                        }


                    }
                    else
                    {
                        rowErrors.Add("BrandCode is required.");
                    }

                    if (rowErrors.Any())
                    {
                        finalResult.FailedRows.Add(new ImportRowErrorDto
                        {
                            RowNumber = r,
                            RawRowData = string.Join(" | ", rawRow.Select(kv => $"{kv.Key}:{kv.Value}")),
                            Errors = rowErrors
                        });
                        continue;
                    }

                    var createDto = new ModelCreateDto
                    {
                        Code = templateDto.Code,
                        Name = templateDto.Name,
                        Description = templateDto.Description,
                        BrandId = brandCache[templateDto.BrandCode]
                    };

                    var createResult = await Create(createDto);
                    if (!createResult.Succeeded)
                    {
                        finalResult.FailedRows.Add(new ImportRowErrorDto
                        {
                            RowNumber = r,
                            RawRowData = string.Join(" | ", rawRow.Select(kv => $"{kv.Key}:{kv.Value}")),
                            Errors = createResult.Errors
                                .Select(e => $"{e.ErrorCode}: {e.ErrorMessage}")
                                .ToList()
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




        public async Task<ReturnBase<FileResultDto>> DownloadTemplate()
        {
            try
            {
                var content = await _templateGenerator
                    .GenerateTemplateAsync<ModelTampleteDto>("ModelConversion");

                var file = new FileResultDto
                {
                    Content = content,
                    FileName = "ModelConversion.xlsx"
                };

                return ReturnBase<FileResultDto>.Success(file);
            }
            catch (Exception ex)
            {
                return ReturnBase<FileResultDto>.Fail(ex, _exceptionManager);
            }
        }



        private IModelCommandRepository _commands
        {
            get { return _accountUoW.Model; }
        }
    }
}