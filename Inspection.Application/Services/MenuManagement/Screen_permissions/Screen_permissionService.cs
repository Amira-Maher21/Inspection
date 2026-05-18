using AutoMapper;
using Inspection.Application.Contracts.Dto.MenuManagement.Screen_permissions;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.MenuManagement.Screen_permissions;
using Inspection.Application.Contracts.Services.MenuManagement.Screen_permissions;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.SharedModels;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.MenuManagement.Screen_permissions
{


    public class Screen_permissionService : AccountsServiceBase, IScreen_permissionService
    {
        private readonly ITenantResolver _tenantResolver;

        public Screen_permissionService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;

        }
        public async Task<List<Screen_permissionDto>> GetListAsync()
        {

            var list = await _queriesManager.Screen_permissions.GetAllAsync();
            return _mapper.Map<List<Screen_permissionDto>>(list.Result);
        }
        public async Task<ReturnBase<Screen_permissionDto>> InsertScreen_permissionAsync(CreateScreen_permissionDto insertDto)
        {
            try
            {
                var entity = _mapper.Map<Screen_permission>(insertDto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<Screen_permissionDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<Screen_permissionDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<Screen_permissionDto>(entity);

                return ReturnBase<Screen_permissionDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<Screen_permissionDto>.Fail(ex, _exceptionManager);
            }
        }






        public async Task<ReturnBase<Screen_permissionDto>> UpdateScreen_permissionAsync(UpdateScreen_permissionDto dto)
        {
            try
            {
                var entity = await _queriesManager.Screen_permissions.GetByIdAsync(dto.Screen_ID);
                if (entity == null)
                {
                    return ReturnBase<Screen_permissionDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404", ErrorMessage = "Screen Permission Not Found" }
            });
                }

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                entity.User_group_ID = dto.User_group_ID;
                entity.Screen_ID = dto.Screen_ID;
                entity.CanAdd = dto.CanAdd;
                entity.CanUpdate = dto.CanUpdate;
                entity.CanDelete = dto.CanDelete;
                entity.CanPrice = dto.CanPrice;
                entity.CanPost = dto.CanPost;
                entity.CanPrint = dto.CanPrint;
                entity.CanAttachment = dto.CanAttachment;



                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<Screen_permissionDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<Screen_permissionDto>(entity);

                return ReturnBase<Screen_permissionDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<Screen_permissionDto>.Fail(ex, _exceptionManager);
            }
        }




        public async Task<ReturnBase<Screen_permissionDto>> DeleteScreen_permissionAsync(string id)
        {
            try
            {
                var entity = await _queriesManager.Screen_permissions.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Screen_permission Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<Screen_permissionDto>.Fail(listOfErrors);
                }

                var keys = new EntityKeyValueDictionary();
                keys.Add(new KeyValuePair<string, object>("Screen_ID", id));
                var deleteResult = await _commands.DeleteAsync(keys);

                if (!deleteResult.Succeeded)
                    return ReturnBase<Screen_permissionDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<Screen_permissionDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<Screen_permissionDto>(entity);

                return ReturnBase<Screen_permissionDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<Screen_permissionDto>.Fail(ex, _exceptionManager);
            }
        }
        //public async Task<ReturnBase<IEnumerable<Screen_permissionDtoByInclude>>> GetScreen_permissionListAsync(SqlQueryOptions sqlQueryOptions)
        //{
        //    try
        //    {
        //        var getResult = await _queriesManager.Screen_permission.GetListAsync(sqlQueryOptions);
        //        if (!getResult.Succeeded)
        //            return ReturnBase<IEnumerable<Screen_permissionDtoByInclude>>.Fail(getResult.Errors);

        //        return ReturnBase<IEnumerable<Screen_permissionDtoByInclude>>.Success(getResult.Result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ReturnBase<IEnumerable<Screen_permissionDtoByInclude>>.Fail(ex, _exceptionManager);
        //    }
        //}
        public async Task<ReturnBase<Screen_permissionDto>> GetScreen_permissionByIdAsync(string id)
        {
            try
            {
                var entity = await _queriesManager.Screen_permissions.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Screen_permission Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<Screen_permissionDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<Screen_permissionDto>(entity);

                return ReturnBase<Screen_permissionDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<Screen_permissionDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<Screen_permissionReturnSearchDto>>> GetScreen_permissionListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.Screen_permissions.GetListIncldeNameAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<Screen_permissionReturnSearchDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<Screen_permissionReturnSearchDto>>.Success(_mapper.Map<IEnumerable<Screen_permissionReturnSearchDto>>(getResult.Result));
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<Screen_permissionReturnSearchDto>>.Fail(ex, _exceptionManager);
            }

        }
        //public async Task<ReturnBase<IEnumerable<Screen_permissionDtoLookUpForNames>>> GetLookUpScreen_permissionForNamesAsync(SqlQueryOptions queryOptions)
        //{
        //    var result = await this._queriesManager.Screen_permission.GetLookUpScreen_permissionForNamesAsync(queryOptions);

        //    var mappedResult = _mapper.Map<IEnumerable<Screen_permissionDtoLookUpForNames>>(result.Result);

        //    return ReturnBase<IEnumerable<Screen_permissionDtoLookUpForNames>>.Success(mappedResult);

        //}

        private IScreen_permissionCommandRepository _commands
        {
            get { return _accountUoW.Screen_permissionCommandRepository; }
        }


    }
}
