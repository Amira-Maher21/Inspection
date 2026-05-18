using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionManagement.CustomerLocations;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.Locations;
using Inspection.Application.Contracts.Services.InspectionManagement.CustomerLocations;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.InspectionManagement.CustomerLocations;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.InspectionManagement.CustomerLocations
{
    public class CustomerLocationServices : AccountsServiceBase, ICustomerLocationService
    {
        public CustomerLocationServices(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
        }
        public async Task<List<CustomerLocationDto>> GetListAsync()
        {

            var list = await _queriesManager.CustomerLocations.GetAllAsync();
            return _mapper.Map<List<CustomerLocationDto>>(list.Result);
        }
        public async Task<ReturnBase<UpdateCustomerLocationDto>> InsertCustomerLocationAsync(CreateCustomerLocationDto insertDto)
        {
            try
            {
                var entity = _mapper.Map<CustomerLocation>(insertDto);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<UpdateCustomerLocationDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<UpdateCustomerLocationDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<UpdateCustomerLocationDto>(entity);

                return ReturnBase<UpdateCustomerLocationDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateCustomerLocationDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateCustomerLocationDto>> UpdateCustomerLocationAsync(UpdateCustomerLocationDto updateDto, long id)
        {
            try
            {
                var entity = await _queriesManager.CustomerLocations.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "CustomerLocation Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateCustomerLocationDto>.Fail(listOfErrors);
                }


                entity = _mapper.Map<CustomerLocation>(updateDto);
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<UpdateCustomerLocationDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateCustomerLocationDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateCustomerLocationDto>(entity);

                return ReturnBase<UpdateCustomerLocationDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateCustomerLocationDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateCustomerLocationDto>> DeleteCustomerLocationAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.CustomerLocations.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "CustomerLocation Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateCustomerLocationDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteByIdAsync(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<UpdateCustomerLocationDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateCustomerLocationDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateCustomerLocationDto>(entity);

                return ReturnBase<UpdateCustomerLocationDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateCustomerLocationDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<CustomerLocationDtoByInclude>>> GetCustomerLocationListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.CustomerLocations.GetListIncludeNameAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<CustomerLocationDtoByInclude>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<CustomerLocationDtoByInclude>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CustomerLocationDtoByInclude>>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<CustomerLocationDto>> GetCustomerLocationByIdAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.CustomerLocations.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "CustomerLocation Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<CustomerLocationDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<CustomerLocationDto>(entity);

                return ReturnBase<CustomerLocationDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<CustomerLocationDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<CustomerLocationDtoLookUpForNames>>> GetLookUpCustomerLocationForNamesAsync(SqlQueryOptions queryOptions)
        {
            var result = await this._queriesManager.CustomerLocations.GetLookUpCustomerLocationForNamesAsync(queryOptions);

            var mappedResult = _mapper.Map<IEnumerable<CustomerLocationDtoLookUpForNames>>(result.Result);

            return ReturnBase<IEnumerable<CustomerLocationDtoLookUpForNames>>.Success(mappedResult);

        }

        private ICustomerLocationCommandRepository _commands
        {
            get { return _accountUoW.CustomerLocation; }
        }


    }
}
