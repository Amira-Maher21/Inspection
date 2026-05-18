using AutoMapper;
using ClosedXML.Excel;
using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.UnitOfMeasureConversion;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Inventory.InventorySetup.UnitOfMeasureConversions;
using Inspection.Application.Contracts.Services.Inventory.InventorySetup.UnitOfMeasureConversionConversion;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Inventory.InventorySetup.UnitOfMeasureConversions;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Inventory.InventorySetup.UnitOfMeasureConversions
{
    public class UnitOfMeasureConversionService : AccountsServiceBase, IUnitOfMeasureConversionService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public UnitOfMeasureConversionService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }
        //done
        public async Task<ReturnBase<UnitOfMeasureConversionDto>> Create(
            UnitOfMeasureConversionCreateDto createDto)
        {
            try
            {
                var entity = _mapper.Map<UnitOfMeasureConversion>(createDto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();
                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<UnitOfMeasureConversionDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<UnitOfMeasureConversionDto>.Fail(saveResult.Errors);

                var resultDto = _mapper.Map<UnitOfMeasureConversionDto>(entity);
                return ReturnBase<UnitOfMeasureConversionDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<UnitOfMeasureConversionDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<UnitOfMeasureConversionDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.UnitOfMeasureConversions.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "UnitOfMeasureConversion Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UnitOfMeasureConversionDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<UnitOfMeasureConversionDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UnitOfMeasureConversionDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UnitOfMeasureConversionDto>(entity);

                return ReturnBase<UnitOfMeasureConversionDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UnitOfMeasureConversionDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<List<UnitOfMeasureConversionDto>>> GetAll()
        {
            try
            {
                var result = await _queriesManager.UnitOfMeasureConversions.GetAll();

                if (!result.Succeeded)
                {
                    return ReturnBase<List<UnitOfMeasureConversionDto>>.Fail(result.Errors);
                }

                var mapped = _mapper.Map<List<UnitOfMeasureConversionDto>>(result.Result);

                return ReturnBase<List<UnitOfMeasureConversionDto>>.Success(mapped);
            }
            catch (Exception ex)
            {
                return ReturnBase<List<UnitOfMeasureConversionDto>>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<UnitOfMeasureConversionDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.UnitOfMeasureConversions.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "UnitOfMeasureConversion not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UnitOfMeasureConversionDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<UnitOfMeasureConversionDto>(entity);

                return ReturnBase<UnitOfMeasureConversionDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<UnitOfMeasureConversionDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<IEnumerable<UnitOfMeasureConversionReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.UnitOfMeasureConversions.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<UnitOfMeasureConversionReturnSearchDto>>.Fail(getResult.Errors);

                var mappedResult = _mapper.Map<IEnumerable<UnitOfMeasureConversionReturnSearchDto>>(getResult.Result);

                return ReturnBase<IEnumerable<UnitOfMeasureConversionReturnSearchDto>>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<UnitOfMeasureConversionReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<UnitOfMeasureConversionDto>> Update(UnitOfMeasureConversionUpdateDto updateDto)
        {
            try
            {
                var entity = await _queriesManager.UnitOfMeasureConversions.GetById(updateDto.Id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Default Account Assignment Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UnitOfMeasureConversionDto>.Fail(listOfErrors);
                }

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(updateDto, entity);
                //entity = _mapper.Map<UnitOfMeasureConversion>(updateDto);
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<UnitOfMeasureConversionDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UnitOfMeasureConversionDto>.Fail(saveResult.Errors);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                var mappedResult = _mapper.Map<UnitOfMeasureConversionDto>(entity);

                return ReturnBase<UnitOfMeasureConversionDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UnitOfMeasureConversionDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<ImportResultDto>> ImportUnitOfMeasureConversion(ExcelImportRequestDto dto)
        {
            try
            {
                var result = new ImportResultDto();

                using var stream = dto.File.OpenReadStream();
                using var workbook = new XLWorkbook(stream);
                var ws = workbook.Worksheets.First();

                var firstDataRow = 2;
                var lastRow = ws.LastRowUsed()?.RowNumber() ?? firstDataRow - 1;

                var profile = new UnitOfMeasureConversionImportProfile();
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
                    .GenerateTemplateAsync<UnitOfMeasureConversionTampleteDto>("UnitOfMeasureConversion");

                var file = new FileResultDto
                {
                    Content = content,
                    FileName = "UnitOfMeasureConversion.xlsx"
                };

                return ReturnBase<FileResultDto>.Success(file);
            }
            catch (Exception ex)
            {
                return ReturnBase<FileResultDto>.Fail(ex, _exceptionManager);
            }
        }



        private IUnitOfMeasureConversionCommandRepository _commands
        {
            get { return _accountUoW.UnitOfMeasureConversion; }
        }
    }
}