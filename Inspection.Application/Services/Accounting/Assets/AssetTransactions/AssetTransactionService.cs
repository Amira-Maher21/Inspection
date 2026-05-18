using AutoMapper;
using ClosedXML.Excel;
using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetTransactions;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.Assets.AssetTransactions;
using Inspection.Application.Contracts.Services.Accounting.Assets.AssetTransactions;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Accounting.Assets.AssetTransactions;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.Assets.AssetTransactions
{
    public class AssetTransactionService : AccountsServiceBase, IAssetTransactionService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public AssetTransactionService(IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper, ITenantResolver tenantResolver,
            IExceptionManager exceptionManager
            , IExcelTemplateGenerator templateGenerator
            ) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            this._tenantResolver = tenantResolver;
            this._templateGenerator = templateGenerator;


        }

        public async Task<ReturnBase<AssetTransactionDto>> Create(AssetTransactionCreateDto createDto)
        {
            try
            {
                var entity = _mapper.Map<AssetTransaction>(createDto);

                entity.Tenant_ID = _tenantResolver.GetTenantName();


                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<AssetTransactionDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<AssetTransactionDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<AssetTransactionDto>(entity);

                return ReturnBase<AssetTransactionDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<AssetTransactionDto>.Fail(ex, _exceptionManager);
            }
        }



        public async Task<ReturnBase<AssetTransactionDto>> Update(AssetTransactionUpdateDto updateDto)

        {
            var entity = await _queriesManager.AssetTransaction.GetById(updateDto.Id);


            if (entity == null)
            {
                return ReturnBase<AssetTransactionDto>.Fail(new List<ReturnBaseError>
        {
            new ReturnBaseError
            {
                ErrorCode = "404",
                ErrorMessage = "AssetTransaction Not Found"
            }
        });
            }

            entity.Tenant_ID = _tenantResolver.GetTenantName();


            _mapper.Map(updateDto, entity);

            await _accountUoW.SaveAsync();

            var resultDto = _mapper.Map<AssetTransactionDto>(entity);

            return ReturnBase<AssetTransactionDto>.Success(resultDto);
        }



        public async Task<ReturnBase<AssetTransactionDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.AssetTransaction.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "AssetTransaction Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<AssetTransactionDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<AssetTransactionDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<AssetTransactionDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<AssetTransactionDto>(entity);

                return ReturnBase<AssetTransactionDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<AssetTransactionDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<AssetTransactionReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.AssetTransaction.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<AssetTransactionReturnSearchDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<AssetTransactionReturnSearchDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<AssetTransactionReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<AssetTransactionDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.AssetTransaction.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "AssetTransaction Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<AssetTransactionDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<AssetTransactionDto>(entity);

                return ReturnBase<AssetTransactionDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<AssetTransactionDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<ImportResultDto>> ImportAssetTransaction(ExcelImportRequestDto dto)
        {
            try
            {
                var finalResult = new ImportResultDto();
                var profile = new AssetTransactionImportProfile(); // Profile خاص بـ AssetTransaction

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
                    AssetTransactionCreateDto? createDto = null;

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

                    // -------- Create AssetTransaction --------
                    var createResult = await CreateAssetTransaction(createDto);

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
                var content = await _templateGenerator.GenerateTemplateAsync<AssetTransactionImportTemplateDto>("AssetTransaction");

                var file = new FileResultDto
                {
                    Content = content,
                    FileName = "AssetTransaction.xlsx"
                };

                return ReturnBase<FileResultDto>.Success(file);
            }
            catch (Exception ex)
            {
                return ReturnBase<FileResultDto>.Fail(ex, _exceptionManager);
            }
        }

        private async Task<ReturnBase<AssetTransactionDto>> CreateAssetTransaction(AssetTransactionCreateDto createDto)
        {
            var entity = _mapper.Map<AssetTransaction>(createDto);
            var insertResult = await _accountUoW.AssetTransaction.InsertAsync(entity);
            if (!insertResult.Succeeded)
                return ReturnBase<AssetTransactionDto>.Fail(insertResult.Errors);

            await _accountUoW.SaveAsync();
            var dto = _mapper.Map<AssetTransactionDto>(entity);
            return ReturnBase<AssetTransactionDto>.Success(dto);
        }


        private IAssetTransactionCommandRepository _commands
        {
            get { return _accountUoW.AssetTransaction; }
        }
    }

}
