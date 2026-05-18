using AutoMapper;
using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CurrencyDTOs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.SystemConfigurations.Currencies;
using Inspection.Application.Contracts.Services.SystemConfigurations.Currencies;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.SystemConfigurations.Currencies;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.SystemConfigurations.Currencies
{
    public class CurrencyService : AccountsServiceBase, ICurrencyService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public CurrencyService(IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper, ITenantResolver tenantResolver,
            IExceptionManager exceptionManager
            , IExcelTemplateGenerator templateGenerator
)
            : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            this._tenantResolver = tenantResolver;
            this._templateGenerator = templateGenerator;

        }

        public async Task<ReturnBase<CurrencyDto>> Create(CurrencyCreateDto createDto)
        {
            try
            {
                var entity = _mapper.Map<Currency>(createDto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<CurrencyDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<CurrencyDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<CurrencyDto>(entity);

                return ReturnBase<CurrencyDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<CurrencyDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<CurrencyDto>> Update(CurrencyUpdateDto updateDto)
        {
            try
            {
                var entity = await _queriesManager.Currencies.GetById(updateDto.Id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Company Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<CurrencyDto>.Fail(listOfErrors);
                }


                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(updateDto, entity);
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<CurrencyDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<CurrencyDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<CurrencyDto>(entity);

                return ReturnBase<CurrencyDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<CurrencyDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<CurrencyDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.Currencies.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Currency Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<CurrencyDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<CurrencyDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<CurrencyDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<CurrencyDto>(entity);

                return ReturnBase<CurrencyDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<CurrencyDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<CurrencyDto>> GetByCode(string code)
        {
            try
            {
                var entity = await _queriesManager.Currencies.GetByCode(code);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Currency Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<CurrencyDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<CurrencyDto>(entity);

                return ReturnBase<CurrencyDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<CurrencyDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<IEnumerable<CurrencyDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.Currencies.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<CurrencyDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<CurrencyDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CurrencyDto>>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<CurrencyDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.Currencies.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Company Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<CurrencyDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<CurrencyDto>(entity);

                return ReturnBase<CurrencyDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<CurrencyDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<CurrencyRatesResultDto>> GetRatesAsync(long companyId, long transactionCurrencyId, DateTime Date)
        {
            try
            {
                var company = await _queriesManager.Companies.GetById(companyId);

                if (company == null)
                {
                    return ReturnBase<CurrencyRatesResultDto>.Fail(new List<ReturnBaseError>
            {
                new ReturnBaseError
                {
                    ErrorCode = "404",
                    ErrorMessage = "Company Not Found"
                }
            });
                }

                var result = new CurrencyRatesResultDto
                {
                    BaseCurrencyId = company.BaseCurrencyId,
                    OfficialCurrencyId = company.OfficialCurrencyId,
                    ReportingCurrencyId = company.ReportingCurrencyId
                };

                // Base
                if (transactionCurrencyId == company.BaseCurrencyId)
                {
                    result.BaseRate = 1;
                }
                else
                {
                    result.BaseRate = await GetRate(
                        transactionCurrencyId,
                        company.BaseCurrencyId,
                        Date);
                }

                // Official
                if (company.OfficialCurrencyId == null)
                {
                    result.OfficialRate = 0;
                }
                else if (transactionCurrencyId == company.OfficialCurrencyId)
                {
                    result.OfficialRate = 1;
                }
                else
                {
                    result.OfficialRate = await GetRate(
                        transactionCurrencyId,
                        company.OfficialCurrencyId,
                        Date);
                }

                // Reporting
                if (company.ReportingCurrencyId == null)
                {
                    result.ReportingRate = 0;
                }
                else if (transactionCurrencyId == company.ReportingCurrencyId)
                {
                    result.ReportingRate = 1;
                }
                else
                {
                    result.ReportingRate = await GetRate(
                        transactionCurrencyId,
                        company.ReportingCurrencyId.Value,
                        Date);
                }

                return ReturnBase<CurrencyRatesResultDto>.Success(result);
            }
            catch (Exception ex)
            {
                return ReturnBase<CurrencyRatesResultDto>.Fail(ex, _exceptionManager);
            }
        }

        private async Task<decimal> GetRate(long baseCurrencyId, long targetCurrencyId, DateTime date)
        {
            if (baseCurrencyId == targetCurrencyId)
                return 1m;

            var result = await _queriesManager.SCurrencyExchangeRates
                .GetLatestRateAsync(baseCurrencyId, targetCurrencyId, date);

            if (result.Succeeded)
                return result.Result;

            // try reverse
            var reverseResult = await _queriesManager.SCurrencyExchangeRates
                .GetLatestRateAsync(targetCurrencyId, baseCurrencyId, date);

            if (reverseResult.Succeeded && reverseResult.Result != 0)
                return 1 / reverseResult.Result;

            throw new Exception(
                $"No exchange rate found for currency pair {baseCurrencyId}->{targetCurrencyId} at {date:yyyy-MM-dd}");
        }

        private ICurrencyCommandRepository _commands
        {
            get { return _accountUoW.Currency; }
        }
    }
}