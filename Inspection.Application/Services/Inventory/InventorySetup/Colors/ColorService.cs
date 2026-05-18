using AutoMapper;
using ClosedXML.Excel;
using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.Colors;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Inventory.InventorySetup.Colors;
using Inspection.Application.Contracts.Services.Inventory.InventorySetup.Colors;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Inventory.InventorySetup.Colors;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Inventory.InventorySetup.Colors
{

    public class ColorService : AccountsServiceBase, IColorService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public ColorService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, IExcelTemplateGenerator templateGenerator) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            this._tenantResolver = tenantResolver;
            this._templateGenerator = templateGenerator;

        }

        public async Task<ReturnBase<ColorDto>> Create(ColorCreateDto createDto)
        {
            try
            {
                var entity = _mapper.Map<Color>(createDto);

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<ColorDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<ColorDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<ColorDto>(entity);

                return ReturnBase<ColorDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<ColorDto>.Fail(ex, _exceptionManager);
            }
        }



        public async Task<ReturnBase<ColorDto>> Update(ColorUpdateDto updateDto)
        {
            try
            {
                var entity = await _queriesManager.Color.GetById(updateDto.Id);

                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Coloe Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<ColorDto>.Fail(listOfErrors);
                }
                //entity.Tenant_ID = _tenantResolver.GetTenantName();


                //entity = _mapper.Map<Color>(updateDto);

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(updateDto, entity);

                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<ColorDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<ColorDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<ColorDto>(entity);

                return ReturnBase<ColorDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<ColorDto>.Fail(ex, _exceptionManager);
            }
        }




        public async Task<ReturnBase<ColorDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.Color.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Color Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<ColorDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<ColorDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<ColorDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<ColorDto>(entity);

                return ReturnBase<ColorDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<ColorDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<ColorDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.Color.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<ColorDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<ColorDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ColorDto>>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<ColorDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.Color.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Company Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<ColorDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<ColorDto>(entity);

                return ReturnBase<ColorDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<ColorDto>.Fail(ex, _exceptionManager);
            }
        }




        public async Task<ReturnBase<ColorDto>> GetByCode(string code)
        {
            try
            {
                var entity = await _queriesManager.Color.GetByCode(code);
                if (entity == null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Color Not Found"
                    };
                    return ReturnBase<ColorDto>.Fail(new List<ReturnBaseError> { error });
                }

                var mappedResult = _mapper.Map<ColorDto>(entity);
                return ReturnBase<ColorDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<ColorDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<ImportResultDto>> ImportColor(ExcelImportRequestDto dto)
        {
            try
            {
                var finalResult = new ImportResultDto();
                var profile = new ColorImportProfile();

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

                    // -------- Read Row --------
                    var rawRow = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                    for (int c = 0; c < headers.Count; c++)
                        rawRow[headers[c]] = ws.Cell(r, c + 1).GetString().Trim();

                    var rowErrors = new List<string>();
                    ColorCreateDto? createDto = null;

                    // -------- Map & Validate --------
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
                            RawRowData = string.Join(" | ",
                                rawRow.Select(kv => $"{kv.Key}:{kv.Value}")),
                            Errors = rowErrors.Any()
                                ? rowErrors
                                : new() { "Row mapping failed." }
                        });
                        continue;
                    }

                    // -------- Create --------
                    var createResult = await Create(createDto); // CreateColor(createDto)

                    if (!createResult.Succeeded)
                    {
                        finalResult.FailedRows.Add(new ImportRowErrorDto
                        {
                            RowNumber = r,
                            RawRowData = string.Join(" | ",
                                rawRow.Select(kv => $"{kv.Key}:{kv.Value}")),
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
                    .GenerateTemplateAsync<ColorImportTemplateDto>("Color");

                var file = new FileResultDto
                {
                    Content = content,
                    FileName = "Color.xlsx"
                };

                return ReturnBase<FileResultDto>.Success(file);
            }
            catch (Exception ex)
            {
                return ReturnBase<FileResultDto>.Fail(ex, _exceptionManager);
            }
        }



        private IColorCommandRepository _commands
        {
            get { return _accountUoW.Color; }
        }
    }

}
