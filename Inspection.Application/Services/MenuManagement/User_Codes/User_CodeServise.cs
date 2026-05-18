using AutoMapper;
using Inspection.Application.Contracts.Dto.MenuManagement.User_Codes;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.MenuManagement.User_Codes;
using Inspection.Application.Contracts.Repositories.Query.MenuManagement.User_Codes;
using Inspection.Application.Contracts.Services.MenuManagement.User_Codes;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Application.Shared.SharedValidaion;
using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.MenuManagement.User_Codes
{
    public class User_CodeServise : AccountsServiceBase, IUser_CodeServise
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly IAccountUnitOfWork _accountUoW;
        private readonly IAccountsQueriesManager _queriesManager;

        public User_CodeServise(
            IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper,
            IExceptionManager exceptionManager,
            ITenantResolver tenantResolver,
            IExcelTemplateGenerator templateGenerator
        ) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _accountUoW = accountUoW ?? throw new ArgumentNullException(nameof(accountUoW));
            _queriesManager = queriesManager ?? throw new ArgumentNullException(nameof(queriesManager));
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }

        private IUser_CodeCommandRepository _commands
            => _accountUoW.User_CodeCommandRepository;

        private IUser_CodeQueryRepository _queries
            => _queriesManager.User_CodeQueryRepository;

        #region Create

        public async Task<ReturnBase<User_CodeDto>> Create(CreateUser_CodeDto dto)
        {
            try
            {
                if (dto.Email != null)
                    EmailValidator.Validate(dto.Email);

                var entity = _mapper.Map<User_Code>(dto);

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                foreach (var group in entity.User_Code_dGroups)
                {
                    group.Tenant_ID = entity.Tenant_ID;
                }

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<User_CodeDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<User_CodeDto>.Fail(saveResult.Errors);

                var createdEntity = await _queries.GetById(entity.Id);

                var dtoResult = _mapper.Map<User_CodeDto>(createdEntity);

                return ReturnBase<User_CodeDto>.Success(dtoResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<User_CodeDto>.Fail(ex, _exceptionManager);
            }
        }

        #endregion

        #region Update

        public async Task<ReturnBase<User_CodeDto>> Update(UpdateUser_CodeDto dto)
        {
            try
            {
                // 1️⃣ Validate Email
                EmailValidator.Validate(dto.Email);

                // 2️⃣ Load user
                var entity = await _queries.GetById(dto.Id);
                if (entity == null)
                {
                    return ReturnBase<User_CodeDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404", ErrorMessage = $"User Code with Id '{dto.Id}' was not found." }
            });
                }

                // 3️⃣ Tenant
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // 4️⃣ Update basic fields
                _mapper.Map(dto, entity);

                // 5️⃣ Sync groups (Add / Update / Remove)
                var existingGroups = entity.User_Code_dGroups.ToList();
                var dtoGroupIds = new HashSet<long>();

                if (dto.User_Code_dGroups != null && dto.User_Code_dGroups.Any())
                {
                    foreach (var groupDto in dto.User_Code_dGroups)
                    {
                        if (groupDto.User_group_ID == 0 /*&& !string.IsNullOrWhiteSpace(groupDto.User_group_Name)*/)
                        {
                            // ✅ Create new group
                            var newGroup = new User_Group
                            {
                                Tenant_ID = entity.Tenant_ID,
                                //User_group_Name = groupDto.User_group_Name
                            };

                            var insertResult = await _accountUoW.User_GroupCommandRepository.InsertAsync(newGroup);
                            if (!insertResult.Succeeded)
                                return ReturnBase<User_CodeDto>.Fail(insertResult.Errors);

                            await _accountUoW.SaveAsync(); // ID generated

                            // Link new group
                            entity.User_Code_dGroups.Add(new User_Code_dGroup
                            {
                                Tenant_ID = entity.Tenant_ID,
                                User_CodeId = entity.Id,
                                User_group_ID = newGroup.User_group_ID
                            });

                            dtoGroupIds.Add(newGroup.User_group_ID);
                        }
                        else
                        {
                            // ✅ Existing group: link if missing
                            dtoGroupIds.Add(groupDto.User_group_ID);

                            if (!existingGroups.Any(x => x.User_group_ID == groupDto.User_group_ID))
                            {
                                entity.User_Code_dGroups.Add(new User_Code_dGroup
                                {
                                    Tenant_ID = entity.Tenant_ID,
                                    User_CodeId = entity.Id,
                                    User_group_ID = groupDto.User_group_ID
                                });
                            }
                        }
                    }

                    // 🔴 Remove old groups not in DTO
                    var groupsToRemove = existingGroups
                        .Where(x => !dtoGroupIds.Contains(x.User_group_ID))
                        .ToList();

                    foreach (var group in groupsToRemove)
                    {
                        entity.User_Code_dGroups.Remove(group);
                    }
                }
                else
                {
                    // DTO has no groups → remove all
                    entity.User_Code_dGroups.Clear();
                }

                // 6️⃣ Update entity
                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)
                    return ReturnBase<User_CodeDto>.Fail(updateResult.Errors);

                // 7️⃣ Save
                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<User_CodeDto>.Fail(saveResult.Errors);

                // 8️⃣ Return DTO
                return ReturnBase<User_CodeDto>.Success(_mapper.Map<User_CodeDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<User_CodeDto>.Fail(ex, _exceptionManager);
            }
        }

        #endregion

        #region Delete

        public async Task<ReturnBase<User_CodeDto>> Delete(long id)
        {
            try
            {
                var entity = await _queries.GetById(id);
                if (entity == null)
                {
                    return ReturnBase<User_CodeDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = $"User Code with Id '{id}' was not found."}
                    });
                }

                var deleteResult = await _commands.DeleteById(id);
                if (!deleteResult.Succeeded)
                    return ReturnBase<User_CodeDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<User_CodeDto>.Fail(saveResult.Errors);

                return ReturnBase<User_CodeDto>.Success(
                    _mapper.Map<User_CodeDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<User_CodeDto>.Fail(ex, _exceptionManager);
            }
        }

        #endregion

        #region Get By Id

        public async Task<ReturnBase<User_CodeDto>> GetById(long id)
        {
            try
            {
                var entity = await _queries.GetById(id);
                if (entity == null)
                {
                    return ReturnBase<User_CodeDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = $"User Code with Id '{id}' was not found." }
                    });
                }

                return ReturnBase<User_CodeDto>.Success(
                    _mapper.Map<User_CodeDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<User_CodeDto>.Fail(ex, _exceptionManager);
            }
        }

        #endregion
        public async Task<ReturnBase<User_CodeDto>> GetByCode(string code)
        {
            try
            {
                var entity = await _queriesManager.User_CodeQueryRepository.GetByCode(code);
                if (entity == null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = $"User Code with Code '{code}' was not found."
                    };
                    return ReturnBase<User_CodeDto>.Fail(new List<ReturnBaseError> { error });
                }

                var mappedResult = _mapper.Map<User_CodeDto>(entity);
                return ReturnBase<User_CodeDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<User_CodeDto>.Fail(ex, _exceptionManager);
            }
        }

        #region Search

        public async Task<ReturnBase<IEnumerable<User_CodeReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var result = await _queries.Search(sqlQueryOptions);
                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<User_CodeReturnSearchDto>>
                        .Fail(result.Errors);

                return ReturnBase<IEnumerable<User_CodeReturnSearchDto>>
                    .Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<User_CodeReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }

        #endregion
    }
}
