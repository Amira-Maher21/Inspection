using AutoMapper;
using ClosedXML.Excel;
using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.UnitOfMeasure;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Inventory.InventorySetup;
using Inspection.Application.Contracts.Services.Inventory.InventorySetup;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Inventory.InventorySetup.UnitOfMeasure
{
    internal class UnitOfMeasureService : AccountsServiceBase, IUnitOfMeasureService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public UnitOfMeasureService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }
        //done
        public async Task<ReturnBase<UnitOfMeasureDto>> Create(
            UnitOfMeasureCreateDto createDto)
        {
            try
            {
                var entity = _mapper.Map<Domain.Models.Inventory.InventorySetup.UnitOfMeasure>(createDto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();
                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<UnitOfMeasureDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<UnitOfMeasureDto>.Fail(saveResult.Errors);

                var resultDto = _mapper.Map<UnitOfMeasureDto>(entity);
                return ReturnBase<UnitOfMeasureDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<UnitOfMeasureDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<UnitOfMeasureDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.UnitOfMeasures.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "UnitOfMeasure Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UnitOfMeasureDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<UnitOfMeasureDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UnitOfMeasureDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UnitOfMeasureDto>(entity);

                return ReturnBase<UnitOfMeasureDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UnitOfMeasureDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<List<UnitOfMeasureDto>>> GetAll()
        {
            try
            {
                var result = await _queriesManager.UnitOfMeasures.GetAll();

                if (!result.Succeeded)
                {
                    return ReturnBase<List<UnitOfMeasureDto>>.Fail(result.Errors);
                }

                var mapped = _mapper.Map<List<UnitOfMeasureDto>>(result.Result);

                return ReturnBase<List<UnitOfMeasureDto>>.Success(mapped);
            }
            catch (Exception ex)
            {
                return ReturnBase<List<UnitOfMeasureDto>>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<UnitOfMeasureDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.UnitOfMeasures.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "UnitOfMeasure not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UnitOfMeasureDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<UnitOfMeasureDto>(entity);

                return ReturnBase<UnitOfMeasureDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<UnitOfMeasureDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<IEnumerable<UnitOfMeasureDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.UnitOfMeasures.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<UnitOfMeasureDto>>.Fail(getResult.Errors);

                var mappedResult = _mapper.Map<IEnumerable<UnitOfMeasureDto>>(getResult.Result);

                return ReturnBase<IEnumerable<UnitOfMeasureDto>>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<UnitOfMeasureDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<UnitOfMeasureDto>> Update(UnitOfMeasureUpdateDto updateDto)
        {
            try
            {
                var entity = await _queriesManager.UnitOfMeasures.GetById(updateDto.Id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Default Account Assignment Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UnitOfMeasureDto>.Fail(listOfErrors);
                }

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(updateDto, entity);
                //entity = _mapper.Map<Inspection.Domain.Models.Inventory.InventorySetup.UnitOfMeasure>(updateDto);
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<UnitOfMeasureDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UnitOfMeasureDto>.Fail(saveResult.Errors);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                var mappedResult = _mapper.Map<UnitOfMeasureDto>(entity);

                return ReturnBase<UnitOfMeasureDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UnitOfMeasureDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<ImportResultDto>> ImportUnitOfMeasure(ExcelImportRequestDto dto)
        {
            try
            {
                var result = new ImportResultDto();

                using var stream = dto.File.OpenReadStream();
                using var workbook = new XLWorkbook(stream);
                var ws = workbook.Worksheets.First();

                var firstDataRow = 2;
                var lastRow = ws.LastRowUsed()?.RowNumber() ?? firstDataRow - 1;

                var profile = new UnitOfMeasureImportProfile();
                var columns = profile.ColumnOrder;

                for (int r = firstDataRow; r <= lastRow; r++)
                {
                    result.ProcessedCount++;
                    var excelRow = ws.Row(r);

                    var rawRow = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                    for (int i = 0; i < columns.Count; i++)
                    {
                        rawRow[columns[i]] = excelRow.Cell(i + 1).GetString().Trim();
                    }

                    var rowErrors = new List<string>();

                    var dtoRow = await profile.MapAsync(rawRow, rowErrors);

                    if (dtoRow != null)
                        await profile.ValidateAsync(dtoRow, rawRow, rowErrors);

                    var rawRowData = string.Join(" | ", columns.Select(c => rawRow[c]));

                    if (rowErrors.Any() || dtoRow == null)
                    {
                        result.FailedRows.Add(new ImportRowErrorDto
                        {
                            RowNumber = r,
                            RawRowData = rawRowData,
                            Errors = rowErrors
                        });
                        continue;
                    }

                    var createResult = await Create(dtoRow);
                    if (!createResult.Succeeded)
                    {
                        result.FailedRows.Add(new ImportRowErrorDto
                        {
                            RowNumber = r,
                            RawRowData = rawRowData,
                            Errors = createResult.Errors
                                .Select(e => $"{e.ErrorCode}: {e.ErrorMessage}")
                                .ToList()
                        });
                        continue;
                    }

                    result.CreatedCount++;
                }

                return ReturnBase<ImportResultDto>.Success(result);
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
                    .GenerateTemplateAsync<UnitOfMeasureImportTemplateDto>("UnitOfMeasure");

                var file = new FileResultDto
                {
                    Content = content,
                    FileName = "UnitOfMeasure.xlsx"
                };

                return ReturnBase<FileResultDto>.Success(file);
            }
            catch (Exception ex)
            {
                return ReturnBase<FileResultDto>.Fail(ex, _exceptionManager);
            }
        }



        private IUnitOfMeasureCommandRepository _commands
        {
            get { return _accountUoW.UnitOfMeasure; }
        }
    }
}