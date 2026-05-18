using AutoMapper;
using Inspection.Application.Contracts.Dto.Inventory.System.InventoryBalance;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Inventory.System.InventoryBalances;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Inventory.System.InventoryBalances;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Inventory.System.InventoryBalances
{
    public class InventoryBalanceService : AccountsServiceBase, Contracts.Services.Inventory.System.InventoryBalances.IInventoryBalanceService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public InventoryBalanceService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }
        //done
        public async Task<ReturnBase<InventoryBalanceDto>> Create(
            InventoryBalanceCreateDto createDto)
        {
            try
            {
                var entity = _mapper.Map<InventoryBalance>(createDto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();
                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<InventoryBalanceDto>.Fail(insertResult.Errors);
                }

                //var saveResult = await _accountUoW.SaveAsync();
                //if (!saveResult.Succeeded)
                //    return ReturnBase<InventoryBalanceDto>.Fail(saveResult.Errors);

                var resultDto = _mapper.Map<InventoryBalanceDto>(entity);
                return ReturnBase<InventoryBalanceDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<InventoryBalanceDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<InventoryBalanceDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.InventoryBalances.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Default Account Assignment Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<InventoryBalanceDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<InventoryBalanceDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<InventoryBalanceDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<InventoryBalanceDto>(entity);

                return ReturnBase<InventoryBalanceDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<InventoryBalanceDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<List<InventoryBalanceDto>>> GetAll()
        {
            try
            {
                var result = await _queriesManager.InventoryBalances.GetAll();

                if (!result.Succeeded)
                {
                    return ReturnBase<List<InventoryBalanceDto>>.Fail(result.Errors);
                }

                var mapped = _mapper.Map<List<InventoryBalanceDto>>(result.Result);

                return ReturnBase<List<InventoryBalanceDto>>.Success(mapped);
            }
            catch (Exception ex)
            {
                return ReturnBase<List<InventoryBalanceDto>>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<InventoryBalanceDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.InventoryBalances.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Inventory Balance not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<InventoryBalanceDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<InventoryBalanceDto>(entity);

                return ReturnBase<InventoryBalanceDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<InventoryBalanceDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<IEnumerable<InventoryBalanceReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.InventoryBalances.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<InventoryBalanceReturnSearchDto>>.Fail(getResult.Errors);

                var mappedResult = _mapper.Map<IEnumerable<InventoryBalanceReturnSearchDto>>(getResult.Result);

                return ReturnBase<IEnumerable<InventoryBalanceReturnSearchDto>>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InventoryBalanceReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<InventoryBalance?> GetByKey(long itemId, long warehouseId, long? locationId)
        {
            var result = await _queriesManager.InventoryBalances
                .GetByKey(itemId, warehouseId, locationId);
            return result;
        }

        public async Task<ReturnBase<InventoryBalanceDto>> Update(InventoryBalanceUpdateDto updateDto)
        {
            try
            {
                var entity = await _queriesManager.InventoryBalances.GetById(updateDto.Id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Inventory Balance Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<InventoryBalanceDto>.Fail(listOfErrors);
                }

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(updateDto, entity);
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<InventoryBalanceDto>.Fail(updateResult.Errors);

                //var saveResult = await _accountUoW.SaveAsync();

                //if (!saveResult.Succeeded)
                //    return ReturnBase<InventoryBalanceDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<InventoryBalanceDto>(entity);

                return ReturnBase<InventoryBalanceDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<InventoryBalanceDto>.Fail(ex, _exceptionManager);
            }
        }

        private IInventoryBalanceCommandRepository _commands
        {
            get { return _accountUoW.InventoryBalance; }
        }
    }
}