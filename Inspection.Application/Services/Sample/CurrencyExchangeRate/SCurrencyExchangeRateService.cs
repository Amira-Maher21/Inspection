using AutoMapper;
using Inspection.Application.Contracts.Dto.SampleDTOs.CurrencyExchangeRateDTOs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Services.Sample.CurrencyExchangeRate;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.Sample.CurrencyExchangeRate;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.SharedModels;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Sample.CurrencyExchangeRate
{
    internal class SCurrencyExchangeRateService : AccountsServiceBase, ISCurrencyExchangeRateService
    {

        public SCurrencyExchangeRateService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
        }

        public async Task<ReturnBase<SCurrencyExchangeRateItemDto?>> GetCurrencyExchangeRateById(long id)
        {
            return await _queriesManager.SCurrencyExchangeRates.GetByIdAsync(id);
        }

        public async Task<ReturnBase<IEnumerable<SCurrencyExchangeRateListItemDto>>> GetCurrencyExchangeRateListAsync(SqlQueryOptions queryOptions)
        {
            return await _queriesManager.SCurrencyExchangeRates.GetListAsync(queryOptions);

        }

        public async Task<ReturnBase<long>> CreateCurrencyExchangeRateAsync(SCurrencyExchangeRateCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<SCurrencyExchangeRateHeader>(dto);
                var insertResult = await _accountUoW.SCurrencyExchangeRates.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<long>.Fail(insertResult.Errors);
                }


                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<long>.Fail(saveResult.Errors);

                }
                return ReturnBase<long>.Success(entity.Id);
            }
            catch (Exception ex)
            {
                return ReturnBase<long>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase> UpdateCurrencyExchangeRateAsync(SCurrencyExchangeRateUpdateDto dto)
        {
            try
            {

                var keys = new EntityKeyValueDictionary
                {
                    new KeyValuePair<string, object>("Id", dto.Id)
                };
                var getEntityResult = await _accountUoW.SCurrencyExchangeRates.GetEntityAsync(keys);
                if (!getEntityResult.Succeeded || getEntityResult.Result == null)
                {
                    return ReturnBase.Fail(getEntityResult.Errors);
                }


                _mapper.Map(dto, getEntityResult.Result);


                var updateResult = await _accountUoW.SCurrencyExchangeRates.UpdateAsync(getEntityResult.Result);
                if (!updateResult.Succeeded)
                {
                    return ReturnBase.Fail(updateResult.Errors);
                }
                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase.Fail(saveResult.Errors);
                }
                return ReturnBase.Success();

            }
            catch (Exception ex)
            {
                return ReturnBase.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase> AddCurrencyExchangeRateLineAsync(long id, SCurrencyExchangeRateAddLineDto addLineDto)
        {
            try
            {
                var keys = new EntityKeyValueDictionary
                {
                    new KeyValuePair<string, object>("Id", id)
                };

                var getEntityResult = await _accountUoW.SCurrencyExchangeRates.GetEntityAsync(keys);
                if (!getEntityResult.Succeeded || getEntityResult.Result == null)
                {
                    return ReturnBase.Fail(getEntityResult.Errors);
                }
                var lineEntity = _mapper.Map<SCurrencyExchangeRateLine>(addLineDto);
                getEntityResult.Result.Lines!.Add(lineEntity);
                var updateResult = await _accountUoW.SCurrencyExchangeRates.UpdateAsync(getEntityResult.Result);
                if (!updateResult.Succeeded)
                {
                    return ReturnBase.Fail(updateResult.Errors);
                }
                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase.Fail(saveResult.Errors);
                }
                return ReturnBase.Success();
            }
            catch (Exception ex)
            {
                return ReturnBase.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase> UpdateCurrencyExchangeRateLineAsync(long id, SCurrencyExchangeRateUpdateLineDto updateLineDto)
        {
            try
            {
                var keys = new EntityKeyValueDictionary
                {
                    new KeyValuePair<string, object>("Id", id)
                };

                var getEntityResult = await _accountUoW.SCurrencyExchangeRates.GetEntityAsync(keys);
                if (!getEntityResult.Succeeded || getEntityResult.Result == null)
                {
                    return ReturnBase.Fail(getEntityResult.Errors);
                }
                var lineEntity = getEntityResult.Result.Lines!.FirstOrDefault(l => l.Id == updateLineDto.Id);
                if (lineEntity == null)
                {
                    return ReturnBase.Fail(new List<ReturnBaseError> { new ReturnBaseError() { ErrorMessage = "The specified line was not found." } });
                }
                _mapper.Map(updateLineDto, lineEntity);
                var updateResult = await _accountUoW.SCurrencyExchangeRates.UpdateAsync(getEntityResult.Result);
                if (!updateResult.Succeeded)
                {
                    return ReturnBase.Fail(updateResult.Errors);
                }
                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase.Fail(saveResult.Errors);
                }
                return ReturnBase.Success();
            }
            catch (Exception ex)
            {
                return ReturnBase.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase> DeactivateCurrencyExchangeRateAsync(long id)
        {
            try
            {
                await _accountUoW.SCurrencyExchangeRates.Deactivate(id);
                return ReturnBase.Success();
            }
            catch (Exception ex)
            {
                return ReturnBase.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<SCurrencyExchangeRateLineListItemDto>>> GetCurrencyExchangeRatesLinesAsync(long id)
        {
            return await _queriesManager.SCurrencyExchangeRates.GetLinesAsync(id);
        }


    }
}
