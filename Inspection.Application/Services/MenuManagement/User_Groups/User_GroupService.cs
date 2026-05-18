using AutoMapper;
using Inspection.Application.Contracts.Dto.MenuManagement.User_Groups;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.MenuManagement.User_Groups;
using Inspection.Application.Contracts.Repositories.Query.MenuManagement.User_Groups;
using Inspection.Application.Contracts.Services.MenuManagement.User_Groups;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.MenuManagement.User_Groups
{
    public class User_GroupService : AccountsServiceBase, IUser_GroupService
    {
        private readonly IAccountUnitOfWork _accountUoW;
        private readonly IAccountsQueriesManager _queriesManager;

        private readonly ITenantResolver _tenantResolver;

        public User_GroupService(
            IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper,
            IExceptionManager exceptionManager,
            ITenantResolver tenantResolver
        ) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _accountUoW = accountUoW;
            _queriesManager = queriesManager;
            _tenantResolver = tenantResolver;
        }

        private IUser_GroupCommandRepository _commands =>
            _accountUoW.User_GroupCommandRepository;

        private IUser_GroupQueryRepository _queries =>
            _queriesManager.User_Groups;

        public async Task<ReturnBase<User_GroupDto>> Create(CreateUser_GroupDto dto)
        {
            try
            {

                var entity = _mapper.Map<User_Group>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                if (dto.Screen_permissions?.Any() == true)
                {
                    entity.Screen_permissions =
                        dto.Screen_permissions
                           .Select(x => _mapper.Map<Screen_permission>(x))
                           .ToList();
                }

                if (dto.User_Code_dGroups?.Any() == true)
                {
                    entity.User_Code_dGroups =
                        dto.User_Code_dGroups
                           .Select(x => _mapper.Map<User_Code_dGroup>(x))
                           .ToList();
                }

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<User_GroupDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<User_GroupDto>.Fail(saveResult.Errors);

                return ReturnBase<User_GroupDto>.Success(
                    _mapper.Map<User_GroupDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<User_GroupDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<User_GroupDto>> Update(UpdateUser_GroupDto dto)
        {
            try
            {
                var entity = await _queriesManager.User_Groups.GetById(dto.User_group_ID);
                if (entity == null)
                {
                    return ReturnBase<User_GroupDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404", ErrorMessage = "User Group Not Found" }
            });
                }
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // Update main fields
                entity.User_group_Name = dto.User_group_Name;

                // ===== Screen Permissions =====
                entity.Screen_permissions.Clear();

                if (dto.Screen_permissions?.Any() == true)
                {
                    foreach (var screenDto in dto.Screen_permissions)
                    {
                        entity.Screen_permissions.Add(
                            _mapper.Map<Screen_permission>(screenDto));
                    }
                }

                // ===== User Code Groups =====
                entity.User_Code_dGroups.Clear();

                if (dto.User_Code_dGroups?.Any() == true)
                {
                    foreach (var codeDto in dto.User_Code_dGroups)
                    {
                        entity.User_Code_dGroups.Add(
                            _mapper.Map<User_Code_dGroup>(codeDto));
                    }
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<User_GroupDto>.Fail(saveResult.Errors);

                return ReturnBase<User_GroupDto>.Success(
                    _mapper.Map<User_GroupDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<User_GroupDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<User_GroupDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.User_Groups.GetById(id);
                if (entity is null)
                {
                    return ReturnBase<User_GroupDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404", ErrorMessage = "Tax Not Found" }
            });
                }

                var mappedResult = _mapper.Map<User_GroupDto>(entity);

                // Hard delete
                var deleteResult = await _commands.DeleteById(id);
                if (!deleteResult.Succeeded)
                    return ReturnBase<User_GroupDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<User_GroupDto>.Fail(saveResult.Errors);


                return ReturnBase<User_GroupDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<User_GroupDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<User_GroupDto>> GetById(long id)
        {
            try
            {
                var entity = await _queries.GetById(id);
                if (entity == null)
                {
                    return ReturnBase<User_GroupDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = "User Group Not Found" }
                    });
                }

                return ReturnBase<User_GroupDto>.Success(
                    _mapper.Map<User_GroupDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<User_GroupDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<User_GroupReturnSearchDto>>> Search(
           SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var result = await _queries.Search(sqlQueryOptions);
                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<User_GroupReturnSearchDto>>
                        .Fail(result.Errors);

                return ReturnBase<IEnumerable<User_GroupReturnSearchDto>>
                    .Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<User_GroupReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }
    }
}
