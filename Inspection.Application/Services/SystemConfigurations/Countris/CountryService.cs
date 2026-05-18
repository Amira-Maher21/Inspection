using AutoMapper;
using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CountrisDto;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.SystemConfigurations.Countries;
using Inspection.Application.Contracts.Services.SystemConfigurations.Country;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.SystemConfigurations.Countriess;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.SystemConfigurations.Countris
{
    public class CountryService : AccountsServiceBase, ICountryService
    {
        private readonly ITenantResolver _tenantResolver;
        public CountryService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            this._tenantResolver = tenantResolver;
        }

        public async Task<ReturnBase<CountryDto>> Create(CountryCreateDto createDto)
        {
            try
            {
                var entity = _mapper.Map<Country>(createDto);

                var TenantName = _tenantResolver.GetTenantName();
                entity.Tenant_ID = TenantName;

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<CountryDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<CountryDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<CountryDto>(entity);

                return ReturnBase<CountryDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<CountryDto>.Fail(ex, _exceptionManager);
            }
        }

        //public async Task<ReturnBase<CountryDto>> Update(CountryUpdateDto updateDto, long id)
        //{
        //    try
        //    {
        //        var entity = await _queriesManager.Counteris.GetById(id);
        //        if (entity is null)
        //        {
        //            var error = new ReturnBaseError
        //            {
        //                ErrorCode = "404",
        //                ErrorMessage = "Country Not Found"
        //            };
        //            var listOfErrors = new List<ReturnBaseError>() { error };
        //            return ReturnBase<CountryDto>.Fail(listOfErrors);
        //        }


        //        entity = _mapper.Map<Country>(updateDto);
        //        var updateResult = await _commands.UpdateAsync(entity);

        //        if (!updateResult.Succeeded)
        //            return ReturnBase<CountryDto>.Fail(updateResult.Errors);

        //        var saveResult = await _accountUoW.SaveAsync();

        //        if (!saveResult.Succeeded)
        //            return ReturnBase<CountryDto>.Fail(saveResult.Errors);

        //        var mappedResult = _mapper.Map<CountryDto>(entity);

        //        return ReturnBase<CountryDto>.Success(mappedResult);

        //    }
        //    catch (Exception ex)
        //    {
        //        return ReturnBase<CountryDto>.Fail(ex, _exceptionManager);
        //    }
        //}


        public async Task<ReturnBase<CountryDto>> Update(CountryUpdateDto updateDto)

        {
            var country = await _queriesManager.Counteris.GetById(updateDto.Id);


            if (country == null)
            {
                return ReturnBase<CountryDto>.Fail(new List<ReturnBaseError>
        {
            new ReturnBaseError
            {
                ErrorCode = "404",
                ErrorMessage = "Country Not Found"
            }
        });
            }
            country.Tenant_ID = _tenantResolver.GetTenantName();

            _mapper.Map(updateDto, country);

            await _accountUoW.SaveAsync();

            var resultDto = _mapper.Map<CountryDto>(country);

            return ReturnBase<CountryDto>.Success(resultDto);
        }



        public async Task<ReturnBase<CountryDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.Counteris.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Counteris Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<CountryDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<CountryDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<CountryDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<CountryDto>(entity);

                return ReturnBase<CountryDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<CountryDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<CountryDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.Counteris.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<CountryDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<CountryDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CountryDto>>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<CountryDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.Counteris.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Company Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<CountryDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<CountryDto>(entity);

                return ReturnBase<CountryDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<CountryDto>.Fail(ex, _exceptionManager);
            }
        }




        public async Task<ReturnBase<CountryDto>> GetByCode(string code)
        {
            try
            {
                var entity = await _queriesManager.Counteris.GetByCode(code);
                if (entity == null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Country Not Found"
                    };
                    return ReturnBase<CountryDto>.Fail(new List<ReturnBaseError> { error });
                }

                var mappedResult = _mapper.Map<CountryDto>(entity);
                return ReturnBase<CountryDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<CountryDto>.Fail(ex, _exceptionManager);
            }
        }



        private ICountriesCommandRepository _commands
        {
            get { return _accountUoW.Country; }
        }
    }
}
