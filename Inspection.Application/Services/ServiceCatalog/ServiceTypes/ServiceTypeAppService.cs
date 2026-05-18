using AutoMapper;
using Inspection.Application.Contracts.Dto.ServiceCatalog.ServiceTypes;
 using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.ServiceCatalog.ServiceTypes;
using Inspection.Application.Contracts.Services.ServiceCatalog.ServiceTypes;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.ServiceCatalog.ServiceTypes;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Inspection.Application.Services.InspectionManagement.ServiceTypes
{
    public class ServiceTypeServices : AccountsServiceBase, IServiceTypeService
    {
        public ServiceTypeServices(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
        }
        public async Task<List<ServiceTypeDtoByInclude>> GetListAsync()
        {

            var list = await _queriesManager.ServiceType.GetAllAsync();
            return _mapper.Map<List<ServiceTypeDtoByInclude>>(list.Result);
        }
        public async Task<ReturnBase<UpdateServiceTypeDto>> InsertServiceTypeAsync(CreateServiceTypeDto insertDto)
        {
            try
            {
                var entity = _mapper.Map<ServiceType>(insertDto);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<UpdateServiceTypeDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<UpdateServiceTypeDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<UpdateServiceTypeDto>(entity);

                return ReturnBase<UpdateServiceTypeDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateServiceTypeDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateServiceTypeDto>> UpdateServiceTypeAsync(UpdateServiceTypeDto updateDto, long id)
        {
            try
            {
                var entity = await _queriesManager.ServiceType.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "ServiceType Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateServiceTypeDto>.Fail(listOfErrors);
                }

                //if (updateDto.ServiceTypeId is 0)
                //    entity.ServiceTypeId = updateDto.ServiceTypeId;

                //if (updateDto.Notes is not null)
                //    entity.Notes = updateDto.Notes;
                entity = _mapper.Map<ServiceType>(updateDto);
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<UpdateServiceTypeDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateServiceTypeDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateServiceTypeDto>(entity);

                return ReturnBase<UpdateServiceTypeDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateServiceTypeDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateServiceTypeDto>> DeleteServiceTypeAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.ServiceType.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "ServiceType Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateServiceTypeDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteByIdAsync(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<UpdateServiceTypeDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateServiceTypeDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateServiceTypeDto>(entity);

                return ReturnBase<UpdateServiceTypeDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateServiceTypeDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<ServiceTypeDtoByInclude>>> GetServiceTypeListAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.ServiceType.GetListAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<ServiceTypeDtoByInclude>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<ServiceTypeDtoByInclude>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ServiceTypeDtoByInclude>>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<ServiceTypeDto>> GetServiceTypeByIdAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.ServiceType.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "ServiceType Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<ServiceTypeDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<ServiceTypeDto>(entity);

                return ReturnBase<ServiceTypeDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<ServiceTypeDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<ServiceTypeDtoByInclude>>> GetServiceTypeListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.ServiceType.GetListIncludeNameAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<ServiceTypeDtoByInclude>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<ServiceTypeDtoByInclude>>.Success(_mapper.Map<IEnumerable<ServiceTypeDtoByInclude>>(getResult.Result));
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ServiceTypeDtoByInclude>>.Fail(ex, _exceptionManager);
            }

        }
        public async Task<ReturnBase<IEnumerable<ServiceTypeDtoLookUpForNames>>> GetLookUpServiceTypeForNamesAsync(SqlQueryOptions queryOptions)
        {
            var result = await this._queriesManager.ServiceType.GetLookUpServiceTypeForNamesAsync(queryOptions);

            var mappedResult = _mapper.Map<IEnumerable<ServiceTypeDtoLookUpForNames>>(result.Result);

            return ReturnBase<IEnumerable<ServiceTypeDtoLookUpForNames>>.Success(mappedResult);

        }

        private IServiceTypeCommandRepository _commands
        {
            get { return _accountUoW.ServiceType; }
        }


    }
}
