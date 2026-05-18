using AutoMapper;
 using Inspection.Application.Contracts.Dto.InspectionManagement.CustomerProjects;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.CustomerProjects;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.CustomerProjects;
using Inspection.Application.Contracts.Services.InspectionManagement.CustomerProjects;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.InspectionManagement.CustomerProjects;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Services.InspectionManagement.CustomerProjects
{
    public class CustomerProjectServices : AccountsServiceBase, ICustomerProjectService
    {
        public CustomerProjectServices(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
        }
        public async Task<List<CustomerProjectDto>> GetListAsync()
        {

            var list = await _queriesManager.CustomerProject.GetAllAsync();
            return _mapper.Map<List<CustomerProjectDto>>(list.Result);
        }
        public async Task<ReturnBase<UpdateCustomerProjectDto>> InsertCustomerProjectAsync(CreateCustomerProjectDto insertDto)
        {
            try
            {
                var entity = _mapper.Map<CustomerProject>(insertDto);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<UpdateCustomerProjectDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<UpdateCustomerProjectDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<UpdateCustomerProjectDto>(entity);

                return ReturnBase<UpdateCustomerProjectDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateCustomerProjectDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateCustomerProjectDto>> UpdateCustomerProjectAsync(UpdateCustomerProjectDto updateDto, long id)
        {
            try
            {
                var entity = await _queriesManager.CustomerProject.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "CustomerProject Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateCustomerProjectDto>.Fail(listOfErrors);
                }

                //if (updateDto.ServiceTypeId is 0)
                //    entity.ServiceTypeId = updateDto.ServiceTypeId;

                //if (updateDto.Notes is not null)
                //    entity.Notes = updateDto.Notes;
                entity = _mapper.Map<CustomerProject>(updateDto);
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<UpdateCustomerProjectDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateCustomerProjectDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateCustomerProjectDto>(entity);

                return ReturnBase<UpdateCustomerProjectDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateCustomerProjectDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateCustomerProjectDto>> DeleteCustomerProjectAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.CustomerProject.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "CustomerProject Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateCustomerProjectDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteByIdAsync(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<UpdateCustomerProjectDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateCustomerProjectDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateCustomerProjectDto>(entity);

                return ReturnBase<UpdateCustomerProjectDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateCustomerProjectDto>.Fail(ex, _exceptionManager);
            }
        }
        //public async Task<ReturnBase<IEnumerable<CustomerProjectDtoByInclude>>> GetCustomerProjectListAsync(SqlQueryOptions sqlQueryOptions)
        //{
        //    try
        //    {
        //        var getResult = await _queriesManager.CustomerProject.GetListAsync(sqlQueryOptions);
        //        if (!getResult.Succeeded)
        //            return ReturnBase<IEnumerable<CustomerProjectDtoByInclude>>.Fail(getResult.Errors);

        //        return ReturnBase<IEnumerable<CustomerProjectDtoByInclude>>.Success(getResult.Result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ReturnBase<IEnumerable<CustomerProjectDtoByInclude>>.Fail(ex, _exceptionManager);
        //    }
        //}
        public async Task<ReturnBase<CustomerProjectDto>> GetCustomerProjectByIdAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.CustomerProject.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "CustomerProject Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<CustomerProjectDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<CustomerProjectDto>(entity);

                return ReturnBase<CustomerProjectDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<CustomerProjectDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<CustomerProjectDtoByInclude>>> GetCustomerProjectListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.CustomerProject.GetListIncldeNameAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<CustomerProjectDtoByInclude>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<CustomerProjectDtoByInclude>>.Success(_mapper.Map<IEnumerable<CustomerProjectDtoByInclude>>(getResult.Result));
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CustomerProjectDtoByInclude>>.Fail(ex, _exceptionManager);
            }

        }
        public async Task<ReturnBase<IEnumerable<CustomerProjectDtoLookUpForNames>>> GetLookUpCustomerProjectForNamesAsync(SqlQueryOptions queryOptions)
        {
            var result = await this._queriesManager.CustomerProject.GetLookUpCustomerProjectForNamesAsync(queryOptions);

            var mappedResult = _mapper.Map<IEnumerable<CustomerProjectDtoLookUpForNames>>(result.Result);

            return ReturnBase<IEnumerable<CustomerProjectDtoLookUpForNames>>.Success(mappedResult);

        }

        private ICustomerProjectCommandRepository _commands
        {
            get { return _accountUoW.CustomerProject; }
        }

        ///////////////////////////////////////ddddddddddddddddddddddd/////

    }
}
