using AutoMapper;
using Inspection.Application.Contracts.Dto;
using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.CostCenterDTOs;
using Inspection.Application.Contracts.Dto.ApprovalManagement.UserApproval;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.ApprovalManagement;
using Inspection.Application.Contracts.Services.ApprovalManagement;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.ApprovalManagement;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.SharedModels;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.ApprovalManagement
{
    internal class UserApprovalService : AccountsServiceBase, IUserApprovalService
    {
        public UserApprovalService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {

        }

        public async Task<ReturnBase<UserApprovalUpdateDto>> GetUserApprovalEntityForUpdate(EntityKeyValueDictionary keys)
        {
            var findResult = await this._commands.GetEntityAsync(keys);
            if (findResult.Succeeded)
            {
                var mappingResult = this._mapper.Map<UserApprovalUpdateDto>(findResult.Result);
                return ReturnBase<UserApprovalUpdateDto>.Success(mappingResult);
            }
            else
            {
                return ReturnBase<UserApprovalUpdateDto>.Fail(findResult.Errors);
            }
        }

        public async Task<ReturnBase<IEnumerable<UserApprovalIndexItemDto>>> GetUserApprovalIndexAsync(SqlQueryOptions queryOptions)
        {
            var result = await this._queriesManager.UserApproval.GetUserApprovalIndexAsync(queryOptions);
            return result;
        }

        public async Task<ReturnBase<UserApprovalInsertDto>> InsertUserApprovalAsync(UserApprovalInsertDto insertDto)
        {
            try
            {
                var entity = this._mapper.Map<User_Approval>(insertDto);
                var insertResult = await this._commands.InsertAsync(entity);
                if (insertResult.Succeeded)
                {
                    var saveResult = await this._accountUoW.SaveAsync();
                    if (saveResult.Succeeded)
                    {
                        var insertedEntity = this._mapper.Map<UserApprovalInsertDto>(insertResult.Result);
                        return ReturnBase<UserApprovalInsertDto>.Success(insertedEntity);
                    }
                    return ReturnBase<UserApprovalInsertDto>.Fail(saveResult.Errors);
                }
                return ReturnBase<UserApprovalInsertDto>.Fail(insertResult.Errors);
            }
            catch (Exception ex)
            {
                return ReturnBase<UserApprovalInsertDto>.Fail(ex, this._exceptionManager);
            }
        }

        public async Task<ReturnBase<UserApprovalUpdateDto>> UpdateUserApprovalAsync(UserApprovalUpdateDto updateDto)
        {
            try
            {
                var entity = this._mapper.Map<User_Approval>(updateDto);
                var updateResult = await this._commands.UpdateAsync(entity);
                if (updateResult.Succeeded)
                {
                    var saveResult = await this._accountUoW.SaveAsync();
                    if (saveResult.Succeeded)
                    {
                        var updatedEntity = this._mapper.Map<UserApprovalUpdateDto>(updateResult.Result);
                        return ReturnBase<UserApprovalUpdateDto>.Success(updatedEntity);
                    }
                    return ReturnBase<UserApprovalUpdateDto>.Fail(saveResult.Errors);
                }
                return ReturnBase<UserApprovalUpdateDto>.Fail(updateResult.Errors);
            }
            catch (Exception ex)
            {
                return ReturnBase<UserApprovalUpdateDto>.Fail(ex, this._exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<DeleteResultDto>>> BulkDeleteUserApprovalAsync(IEnumerable<EntityKeyValueDictionary> keysList)
        {
            try
            {
                var deleteResult = await this._commands.BulkDeleteAsync(keysList, this._accountUoW.SaveAsync);
                if (deleteResult.Succeeded)
                {
                    var results = deleteResult.Result.Select(x => new DeleteResultDto
                    {
                        Deleted = x.Succeeded,
                        Errors = x.Errors
                    });

                    return ReturnBase<IEnumerable<DeleteResultDto>>.Success(results);
                }

                var failedResults = keysList.Select(x => new DeleteResultDto
                {
                    Deleted = false,
                    Errors = deleteResult.Errors
                });

                return ReturnBase<IEnumerable<DeleteResultDto>>.Fail(deleteResult.Errors);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<DeleteResultDto>>.Fail(ex, this._exceptionManager);
            }
        }
        private IUserApprovalCommandRepository _commands
        {
            get { return this._accountUoW.UserApproval; }
        }

        public Task<ReturnBase<CostCenterDto>> Create(CostCenterCreateDto createDto)
        {
            throw new NotImplementedException();
        }




    }
}
