using AutoMapper;
using ClosedXML.Excel;
using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.Sizes;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Inventory.InventorySetup.Sizes;
using Inspection.Application.Contracts.Services.Inventory.InventorySetup.Sizes;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Inventory.InventorySetup.Sizes;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Inventory.InventorySetup.Sizes
{
    public class SizeService : AccountsServiceBase, ISizeService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public SizeService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, IExcelTemplateGenerator templateGenerator) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            this._tenantResolver = tenantResolver;
            this._templateGenerator = templateGenerator;

        }

        public async Task<ReturnBase<SizeDto>> Create(SizeCreateDto createDto)
        {
            try
            {
                var entity = _mapper.Map<Size>(createDto);

                var TenantName = _tenantResolver.GetTenantName();
                entity.Tenant_ID = TenantName;

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<SizeDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<SizeDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<SizeDto>(entity);

                return ReturnBase<SizeDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<SizeDto>.Fail(ex, _exceptionManager);
            }
        }



        public async Task<ReturnBase<SizeDto>> Update(SizeUpdateDto updateDto)

        {
            var Size = await _queriesManager.size.GetById(updateDto.Id);


            if (Size == null)
            {
                return ReturnBase<SizeDto>.Fail(new List<ReturnBaseError>
        {
            new ReturnBaseError
            {
                ErrorCode = "404",
                ErrorMessage = "Size Not Found"
            }
        });
            }
            Size.Tenant_ID = _tenantResolver.GetTenantName();

            _mapper.Map(updateDto, Size);

            await _accountUoW.SaveAsync();

            var resultDto = _mapper.Map<SizeDto>(Size);

            return ReturnBase<SizeDto>.Success(resultDto);
        }



        public async Task<ReturnBase<SizeDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.size.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Size Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<SizeDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<SizeDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<SizeDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<SizeDto>(entity);

                return ReturnBase<SizeDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<SizeDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<SizeDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.size.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<SizeDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<SizeDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<SizeDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<SizeDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.size.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "size Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<SizeDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<SizeDto>(entity);

                return ReturnBase<SizeDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<SizeDto>.Fail(ex, _exceptionManager);
            }
        }



        public async Task<ReturnBase<ImportResultDto>> ImportSize(ExcelImportRequestDto dto)
        {
            try
            {
                var finalResult = new ImportResultDto();
                var profile = new SizeImportProfile();

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
                    SizeCreateDto? createDto = null;

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
                    var createResult = await Create(createDto); // أو CreateSize(createDto)

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
                    .GenerateTemplateAsync<SizeImportTemplateDto>("Size");

                var file = new FileResultDto
                {
                    Content = content,
                    FileName = "Size.xlsx"
                };

                return ReturnBase<FileResultDto>.Success(file);
            }
            catch (Exception ex)
            {
                return ReturnBase<FileResultDto>.Fail(ex, _exceptionManager);
            }
        }



        private ISizeCommandRepository _commands
        {
            get { return _accountUoW.Size; }
        }
    }

}
