using AutoMapper;
using Inspection.Application.Contracts.Dto.MenuManagement.AreaF;
using Inspection.Application.Contracts.Dto.MenuManagement.BranchF;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.MenuManagement.AreaF;
using Inspection.Application.Contracts.Repositories.Command.MenuManagement.BranchF;
using Inspection.Application.Contracts.Repositories.Query.MenuManagement.AreaF;
using Inspection.Application.Contracts.Repositories.Query.MenuManagement.BranchF;
using Inspection.Application.Contracts.Services.MenuManagement.AreaF;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.SharedModels;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Services.MenuManagement.AreaF
{
    public class AreaService : AccountsServiceBase, IAreaService
    {
        private readonly ITenantResolver _tenantResolver;
        public AreaService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
        }

        private IAreaCommandRepository _commands => _accountUoW.Area;
        private IAreaQueryRepository _queries => _queriesManager.Area;

        public async Task<ReturnBase<List<AreaLookupDefaultDto>>> AreaLookupDefault(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var list = await _queries.GetListByIncludeAsync(sqlQueryOptions);

                return ReturnBase<List<AreaLookupDefaultDto>>.Success(_mapper.Map<List<AreaLookupDefaultDto>>(list));
            }
            catch (Exception ex)
            {
                return ReturnBase<List<AreaLookupDefaultDto>>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateAreaDto>> CreateAsync(CreateAreaDto input)
        {
            try
            {
                var entity = _mapper.Map<Area>(input);
                var TenantName = _tenantResolver.GetTenantName();
                entity.Tenant_ID = TenantName;
                var result = await _commands.InsertAsync(entity);
                if (!result.Succeeded) return ReturnBase<UpdateAreaDto>.Fail(result.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateAreaDto>.Fail(saveResult.Errors);

                return ReturnBase<UpdateAreaDto>.Success(_mapper.Map<UpdateAreaDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateAreaDto>.Fail(ex, _exceptionManager);
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

        public async Task<ReturnBase<AreaDto>> GetAsync(long id)
        {
            try
            {
                var Item = await _queries.GetByIdAsync(id);
                var itemDto = _mapper.Map<AreaDto>(Item);
                return new ReturnBase<AreaDto>(itemDto, true);
            }
            catch (Exception ex)
            {
                return ReturnBase<AreaDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<List<AreaDto>>> GetListAsync()
        {
            try
            {
                var list = await _queries.GetAllAsync();

                return ReturnBase<List<AreaDto>>.Success(_mapper.Map<List<AreaDto>>(list.Result));
            }
            catch (Exception ex)
            {
                return ReturnBase<List<AreaDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<List<AreaIncludeDto>>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var list = await _queries.GetListByIncludeAsync(sqlQueryOptions);

                return ReturnBase<List<AreaIncludeDto>>.Success(_mapper.Map<List<AreaIncludeDto>>(list));
            }
            catch (Exception ex)
            {
                return ReturnBase<List<AreaIncludeDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<UpdateAreaDto>> UpdateAsync(long id, UpdateAreaDto input)
        {
            try
            {
                var entity = await _queries.GetByIdAsync(id);
                if (entity == null) return ReturnBase<UpdateAreaDto>.Fail();

                _mapper.Map(input, entity);

                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded) 
                    return ReturnBase<UpdateAreaDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded) 
                    return ReturnBase<UpdateAreaDto>.Fail(saveResult.Errors);

                return ReturnBase<UpdateAreaDto>.Success(_mapper.Map<UpdateAreaDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateAreaDto>.Fail(ex, _exceptionManager);
            }
        }
    }
}
