using AutoMapper;
using Inspection.Application.Contracts.Dto.EquipmentManagement.Series;
 using Inspection.Application.Contracts.Dto.InspectionManagement.InspectorCategory;
using Inspection.Application.Contracts.Dto.InspectionManagement.ServicesItemsF;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.ServicesItemsF;
using Inspection.Application.Contracts.Repositories.Command.MenuManagement.SeriesF;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.ServicesItemsF;
using Inspection.Application.Contracts.Repositories.Query.MenuManagement.SeriesF;
using Inspection.Application.Contracts.Services.InspectionManagement.ServicesItemsF;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.InspectionManagement.ServicesItems;
using Inspection.Domain.Models.MenuManagement;
using Inspection.Infrastructure.UnitOfWork;
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

namespace Inspection.Application.Services.InspectionManagement.ServicesItemsF
{

    public class ServiceItemService : AccountsServiceBase, IServiceItemService
    {
        private readonly ITenantResolver _tenantResolver;
        public ServiceItemService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
        }

        private IServiceItemCommandRepository _commands => _accountUoW.ServicesItems;
        private IServiceItemQueryRepository _queries => _queriesManager.ServicesItems;

        public async Task<ReturnBase<UpdateServiceItemDto>> CreateAsync(CreateServiceItemDto input)
        {
            try
            {
                var entity = _mapper.Map<ServiceItem>(input);
                var TenantName = _tenantResolver.GetTenantName();
                entity.Tenant_ID = TenantName;

                var result = await _commands.InsertAsync(entity);
                if (!result.Succeeded) return ReturnBase<UpdateServiceItemDto>.Fail(result.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded) return ReturnBase<UpdateServiceItemDto>.Fail(saveResult.Errors);
                return ReturnBase<UpdateServiceItemDto>.Success(_mapper.Map<UpdateServiceItemDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateServiceItemDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateServiceItemDto>> UpdateAsync(long id, UpdateServiceItemDto input)
        {
            try
            {
                var entity = await _queries.GetByIdAsync(id);
                if (entity == null) return ReturnBase<UpdateServiceItemDto>.Fail();

                _mapper.Map(input, entity);

                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded) return ReturnBase<UpdateServiceItemDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded) return ReturnBase<UpdateServiceItemDto>.Fail(saveResult.Errors);

                return ReturnBase<UpdateServiceItemDto>.Success(_mapper.Map<UpdateServiceItemDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateServiceItemDto>.Fail(ex, _exceptionManager);
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
        public async Task<ReturnBase<List<ServiceItemDto>>> GetListAsync()
        {
            try
            {
                var list = await _queries.GetAllAsync();

                return ReturnBase<List<ServiceItemDto>>.Success(_mapper.Map<List<ServiceItemDto>>(list.Result));
            }
            catch (Exception ex)
            {
                return ReturnBase<List<ServiceItemDto>>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<ServiceItemDto>> GetAsync(long id)
        {
            try
            {
                var Item = await _queries.GetByIdAsync(id);
                var itemDto = _mapper.Map<ServiceItemDto>(Item);
                return new ReturnBase<ServiceItemDto>(itemDto, true);
            }
            catch (Exception ex)
            {
                return ReturnBase<ServiceItemDto>.Fail(ex, _exceptionManager);
            }

        }

        public async Task<ReturnBase<List<ServiceItemIncludeDto>>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var list = await _queries.GetListByIncludeAsync(sqlQueryOptions);

                return ReturnBase<List<ServiceItemIncludeDto>>.Success(_mapper.Map<List<ServiceItemIncludeDto>>(list));
            }
            catch (Exception ex)
            {
                return ReturnBase<List<ServiceItemIncludeDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<List<ServiceItemLookupDefualtDto>>> ServiceItemLookupDefualt(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var list = await _queries.GetListByIncludeAsync(sqlQueryOptions);

                return ReturnBase<List<ServiceItemLookupDefualtDto>>.Success(_mapper.Map<List<ServiceItemLookupDefualtDto>>(list));
            }
            catch (Exception ex)
            {
                return ReturnBase<List<ServiceItemLookupDefualtDto>>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<List<ServiceItemLookUpByIdForInspectionRequestDto>>> ServiceItemLookUpByIdData(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var list = await _queries.GetListByIncludeAsync(sqlQueryOptions);

                return ReturnBase<List<ServiceItemLookUpByIdForInspectionRequestDto>>.Success(_mapper.Map<List<ServiceItemLookUpByIdForInspectionRequestDto>>(list));
            }
            catch (Exception ex)
            {
                return ReturnBase<List<ServiceItemLookUpByIdForInspectionRequestDto>>.Fail(ex, _exceptionManager);
            }
        }






    }
}
