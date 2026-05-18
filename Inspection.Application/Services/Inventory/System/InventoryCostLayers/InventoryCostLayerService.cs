using AutoMapper;
using Inspection.Application.Contracts.Dto.Inventory.System.InventoryCostLayers;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Inventory.System.InventoryCostLayers;
using Inspection.Application.Contracts.Services.Inventory.System.InventoryCostLayers;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Inventory.System;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Inventory.System.InventoryCostLayers
{
    public class InventoryCostLayerService : AccountsServiceBase, IInventoryCostLayersService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public InventoryCostLayerService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, IExcelTemplateGenerator templateGenerator) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            this._tenantResolver = tenantResolver;
            this._templateGenerator = templateGenerator;

        }
        public async Task<ReturnBase<InventoryCostLayerDto>> Create(InventoryCostLayerCreateDto createDto)
        {
            try
            {
                var entity = _mapper.Map<InventoryCostLayer>(createDto);

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<InventoryCostLayerDto>.Fail(insertResult.Errors);
                }

                //var saveResult = await _accountUoW.SaveAsync();
                //if (!saveResult.Succeeded)
                //{
                //    return ReturnBase<InventoryCostLayerDto>.Fail(saveResult.Errors);
                //}

                var resultDto = _mapper.Map<InventoryCostLayerDto>(entity);

                return ReturnBase<InventoryCostLayerDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<InventoryCostLayerDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<InventoryCostLayerDto>> Update(InventoryCostLayerUpdateDto updateDto)
        {
            try
            {
                var entity = await _queriesManager.InventoryCostLayerQuery.GetById(updateDto.Id);

                if (entity is null)
                {
                    return ReturnBase<InventoryCostLayerDto>.Fail(new List<ReturnBaseError>
            {
                new()
                {
                    ErrorCode = "404",
                    ErrorMessage = "Inventory CostLayer Not Found"
                }
            });
                }

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(updateDto, entity);

                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)
                    return ReturnBase<InventoryCostLayerDto>.Fail(updateResult.Errors);

                //var saveResult = await _accountUoW.SaveAsync();
                //if (!saveResult.Succeeded)
                //    return ReturnBase<InventoryCostLayerDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<InventoryCostLayerDto>(entity);
                return ReturnBase<InventoryCostLayerDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<InventoryCostLayerDto>.Fail(ex, _exceptionManager);
            }
        }





        public async Task<ReturnBase<InventoryCostLayerDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.InventoryCostLayerQuery.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Inventory CostLayer Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<InventoryCostLayerDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<InventoryCostLayerDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<InventoryCostLayerDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<InventoryCostLayerDto>(entity);

                return ReturnBase<InventoryCostLayerDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<InventoryCostLayerDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<InventoryCostLayerReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.InventoryCostLayerQuery.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<InventoryCostLayerReturnSearchDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<InventoryCostLayerReturnSearchDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InventoryCostLayerReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<InventoryCostLayerDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.InventoryCostLayerQuery.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Inventory CostLayer Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<InventoryCostLayerDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<InventoryCostLayerDto>(entity);

                return ReturnBase<InventoryCostLayerDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<InventoryCostLayerDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<InventoryCostLayer?> GetByKey(long itemId, long warehouseId)
        {
            var result = await _queriesManager.InventoryCostLayerQuery.GetByKey(itemId, warehouseId);

            return result;
        }

        private IInventoryCostLayerCommandRepository _commands
        {
            get { return _accountUoW.InventoryCostLayer; }
        }
    }
}
