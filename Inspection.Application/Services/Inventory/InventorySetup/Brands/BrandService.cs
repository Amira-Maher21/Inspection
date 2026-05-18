using AutoMapper;
using ClosedXML.Excel;
using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.Brands;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Inventory.InventorySetup.Brands;
using Inspection.Application.Contracts.Services.Inventory.InventorySetup.Brands;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Inventory.InventorySetup.Brands;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Inventory.InventorySetup.Brands
{
    internal class BrandService : AccountsServiceBase, IBrandService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public BrandService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }
        //done
        public async Task<ReturnBase<BrandDto>> Create(
            BrandCreateDto createDto)
        {
            try
            {
                var entity = _mapper.Map<Brand>(createDto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();
                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<BrandDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<BrandDto>.Fail(saveResult.Errors);

                var resultDto = _mapper.Map<BrandDto>(entity);
                return ReturnBase<BrandDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<BrandDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<BrandDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.Brands.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Default Account Assignment Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<BrandDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<BrandDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<BrandDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<BrandDto>(entity);

                return ReturnBase<BrandDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<BrandDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<List<BrandDto>>> GetAll()
        {
            try
            {
                var result = await _queriesManager.Brands.GetAll();

                if (!result.Succeeded)
                {
                    return ReturnBase<List<BrandDto>>.Fail(result.Errors);
                }

                var mapped = _mapper.Map<List<BrandDto>>(result.Result);

                return ReturnBase<List<BrandDto>>.Success(mapped);
            }
            catch (Exception ex)
            {
                return ReturnBase<List<BrandDto>>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<BrandDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.Brands.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Brand not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<BrandDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<BrandDto>(entity);

                return ReturnBase<BrandDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<BrandDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<IEnumerable<BrandDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.Brands.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<BrandDto>>.Fail(getResult.Errors);

                var mappedResult = _mapper.Map<IEnumerable<BrandDto>>(getResult.Result);

                return ReturnBase<IEnumerable<BrandDto>>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<BrandDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<BrandDto>> Update(BrandUpdateDto updateDto)
        {
            try
            {
                var entity = await _queriesManager.Brands.GetById(updateDto.Id);

                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Brand Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<BrandDto>.Fail(listOfErrors);
                }
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(updateDto, entity);
                //entity.Tenant_ID = _tenantResolver.GetTenantName();


                //entity = _mapper.Map<Brand>(updateDto);
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<BrandDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<BrandDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<BrandDto>(entity);

                return ReturnBase<BrandDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<BrandDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<ImportResultDto>> ImportBrand(ExcelImportRequestDto dto)
        {
            try
            {
                var result = new ImportResultDto();

                using var stream = dto.File.OpenReadStream();
                using var workbook = new XLWorkbook(stream);
                var ws = workbook.Worksheets.First();

                var firstDataRow = 2;
                var lastRow = ws.LastRowUsed()?.RowNumber() ?? firstDataRow - 1;

                var profile = new BrandImportProfile();
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
                    .GenerateTemplateAsync<BrandTampleteDto>("BrandConversion");

                var file = new FileResultDto
                {
                    Content = content,
                    FileName = "BrandConversion.xlsx"
                };

                return ReturnBase<FileResultDto>.Success(file);
            }
            catch (Exception ex)
            {
                return ReturnBase<FileResultDto>.Fail(ex, _exceptionManager);
            }
        }


        private IBrandCommandRepository _commands
        {
            get { return _accountUoW.Brand; }
        }
    }
}