using AutoMapper;
using Inspection.Application.Contracts.Dto;
using Inspection.Application.Contracts.Dto.ApprovalManagement.ApprovalDelegation;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.ApprovalManagement;
using Inspection.Application.Contracts.Repositories.Query.ApprovalManagement;
using Inspection.Application.Contracts.Services.ApprovalManagement;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.ApprovalManagement;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.SharedModels;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Services.ApprovalManagement
{
    internal class ApprovalDelegationService : AccountsServiceBase, IApprovalDelegationService
    {
        public ApprovalDelegationService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
        }

        public async Task<ReturnBase<IEnumerable<ApprovalDelegationIndexItemDto>>> GetApprovalDelegationIndexAsync(SqlQueryOptions queryOptions)
        {
            var result = await this._queriesManager.ApprovalDelegation.GetApprovalDelegationIndexAsync(queryOptions);
            return result;
        }
        public async Task<ReturnBase<ApprovalDelegationIndexItemDto>> InsertApprovalDelegationAsync(ApprovalDelegationInsertDto insertDto)
        {
            try
            {
                var entity = this._mapper.Map<Approval_Delegation>(insertDto);
                var insertResult = await this._commands.InsertAsync(entity);
                if (insertResult.Succeeded)
                {
                    var saveResult = await this._accountUoW.SaveAsync();
                    if (saveResult.Succeeded)
                    {
                        var insertedEntity = this._mapper.Map<ApprovalDelegationIndexItemDto>(insertResult.Result);
                        return ReturnBase<ApprovalDelegationIndexItemDto>.Success(insertedEntity);
                    }
                    return ReturnBase<ApprovalDelegationIndexItemDto>.Fail(saveResult.Errors);
                }
                return ReturnBase<ApprovalDelegationIndexItemDto>.Fail(insertResult.Errors);
            }
            catch (Exception ex)
            {
                return ReturnBase<ApprovalDelegationIndexItemDto>.Fail(ex, this._exceptionManager);
            }
        }

        public async Task<ReturnBase<ApprovalDelegationUpdateDto>> GetApprovalDelegationEntityAsync(EntityKeyValueDictionary keys)
        {
            var findResult = await this._commands.GetEntityAsync(keys);
            if (findResult.Succeeded)
            {
                var mappingResult = this._mapper.Map<ApprovalDelegationUpdateDto>(findResult.Result);
                return ReturnBase<ApprovalDelegationUpdateDto>.Success(mappingResult);
            }
            else
            {
                return ReturnBase<ApprovalDelegationUpdateDto>.Fail(findResult.Errors);
            }
        }

        public async Task<ReturnBase<ApprovalDelegationUpdateDto>> UpdateApprovalDelegationAsync(ApprovalDelegationUpdateDto updateDto)
        {
            try
            {
                var entity = this._mapper.Map<Approval_Delegation>(updateDto);
                var updateResult = await this._commands.UpdateAsync(entity);
                if (updateResult.Succeeded)
                {
                    var saveResult = await this._accountUoW.SaveAsync();
                    if (saveResult.Succeeded)
                    {
                        var updatedEntity = this._mapper.Map<ApprovalDelegationUpdateDto>(updateResult.Result);
                        return ReturnBase<ApprovalDelegationUpdateDto>.Success(updatedEntity);
                    }
                    return ReturnBase<ApprovalDelegationUpdateDto>.Fail(saveResult.Errors);
                }
                return ReturnBase<ApprovalDelegationUpdateDto>.Fail(updateResult.Errors);
            }
            catch (Exception ex)
            {
                return ReturnBase<ApprovalDelegationUpdateDto>.Fail(ex, this._exceptionManager);
            }
        }

        //public async Task<ReturnBase<ApprovalDelegationUpdateDto>> DeleteApprovalDelegationAsync(EntityKeyValueDictionary keys)
        //{
        //    try
        //    {
        //        var deleteResult = await this._commands.DeleteAsync(keys);
        //        if (deleteResult.Succeeded)
        //        {
        //            var saveResult = await this._accountUoW.SaveAsync();
        //            if (saveResult.Succeeded)
        //            {
        //                var deletedEntity = this._mapper.Map<ApprovalDelegationUpdateDto>(deleteResult.Result);
        //                return ReturnBase<ApprovalDelegationUpdateDto>.Success(deletedEntity);
        //            }
        //            return ReturnBase<ApprovalDelegationUpdateDto>.Fail(saveResult.Errors);
        //        }
        //        return ReturnBase<ApprovalDelegationUpdateDto>.Fail(deleteResult.Errors);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ReturnBase<ApprovalDelegationUpdateDto>.Fail(ex, this._exceptionManager);
        //    }
        //}

        public async Task<ReturnBase<IEnumerable<DeleteResultDto>>> BulkDeleteApprovalDelegationsAsync(IEnumerable<EntityKeyValueDictionary> keysList)
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


        public async Task<ReturnBase<IEnumerable<ApprovalDelegationApprovalDLookUpDto>>> GetApprovalDelegationApprovalDLookUpAsync(SqlQueryOptions queryOptions)
        {
            var result = await this._queriesManager.ApprovalDelegation.GetApprovalDelegationApprovalDLookUpAsync(queryOptions);
            return result;
        }
        private IApprovalDelegationCommandRepository _commands
        {
            get { return this._accountUoW.ApprovalDelegation; }
        }

        private IApprovalDelegationQueryRepository _queries
        {
            get { return this._queriesManager.ApprovalDelegation; }
        }
    }
}
