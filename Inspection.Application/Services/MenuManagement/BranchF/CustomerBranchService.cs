using AutoMapper;
using Inspection.Application.Contracts.Dto.MenuManagement.BranchF;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.MenuManagement.BranchF;
using Inspection.Application.Contracts.Repositories.Query.MenuManagement.BranchF;
using Inspection.Application.Contracts.Services.MenuManagement.BranchF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.SharedModels;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.MenuManagement.BranchF
{
    public class CustomerBranchService : AccountsServiceBase, ICustomerBranchService
    {
        private readonly ITenantResolver _tenantResolver;
        public CustomerBranchService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
        }
        private ICustomerBranchCommandRepository _commands => _accountUoW.CustomerBranch;
        private ICustomerBranchQueryRepository _queries => _queriesManager.CustomerBranch;

        public async Task<ReturnBase<List<CustomerBranchLookupDefualtDto>>> BranchLookupDefualt(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var list = await _queries.GetListByIncludeAsync(sqlQueryOptions);

                return ReturnBase<List<CustomerBranchLookupDefualtDto>>.Success(_mapper.Map<List<CustomerBranchLookupDefualtDto>>(list));
            }
            catch (Exception ex)
            {
                return ReturnBase<List<CustomerBranchLookupDefualtDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<UpdateCustomerBranchDto>> CreateAsync(CreateCustomerBranchDto input)
        {
            try
            {
                var entity = _mapper.Map<CustomerBranch>(input);
                var TenantName = _tenantResolver.GetTenantName();
                entity.Tenant_ID = TenantName;
                var result = await _commands.InsertAsync(entity);
                if (!result.Succeeded) return ReturnBase<UpdateCustomerBranchDto>.Fail(result.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateCustomerBranchDto>.Fail(saveResult.Errors);

                return ReturnBase<UpdateCustomerBranchDto>.Success(_mapper.Map<UpdateCustomerBranchDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateCustomerBranchDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<bool>> DeleteAsync(long id)
        {
            try
            {
                var keys = new EntityKeyValueDictionary();
                keys.Add(new KeyValuePair<string, object>("Id", id));

                var deleteResult = await _commands.DeleteAsync(keys);
                if (!deleteResult.Succeeded)
                {
                    return ReturnBase<bool>.Fail(deleteResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<bool>.Fail(saveResult.Errors);
                }

                return ReturnBase<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return ReturnBase<bool>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<CustomerBranchDto>> GetAsync(long id)
        {
            try
            {
                var Item = await _queries.GetByIdAsync(id);
                var itemDto = _mapper.Map<CustomerBranchDto>(Item);
                return new ReturnBase<CustomerBranchDto>(itemDto, true);
            }
            catch (Exception ex)
            {
                return ReturnBase<CustomerBranchDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<List<CustomerBranchDto>>> GetListAsync()
        {
            try
            {
                var list = await _queries.GetAllAsync();

                return ReturnBase<List<CustomerBranchDto>>.Success(_mapper.Map<List<CustomerBranchDto>>(list.Result));
            }
            catch (Exception ex)
            {
                return ReturnBase<List<CustomerBranchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<List<CustomerBranchIncludeDto>>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var list = await _queries.GetListByIncludeAsync(sqlQueryOptions);

                return ReturnBase<List<CustomerBranchIncludeDto>>.Success(_mapper.Map<List<CustomerBranchIncludeDto>>(list));
            }
            catch (Exception ex)
            {
                return ReturnBase<List<CustomerBranchIncludeDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<UpdateCustomerBranchDto>> UpdateAsync(long id, UpdateCustomerBranchDto input)
        {
            try
            {
                var entity = await _queries.GetByIdAsync(id);
                if (entity == null) return ReturnBase<UpdateCustomerBranchDto>.Fail();

                _mapper.Map(input, entity);

                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded) return ReturnBase<UpdateCustomerBranchDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded) return ReturnBase<UpdateCustomerBranchDto>.Fail(saveResult.Errors);

                return ReturnBase<UpdateCustomerBranchDto>.Success(_mapper.Map<UpdateCustomerBranchDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateCustomerBranchDto>.Fail(ex, _exceptionManager);
            }
        }
    }
}
