using AutoMapper;
using Inspection.Application.Contracts.Dto.Inventory.InventorySetup;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Inventory.InventorySetup;
using Inspection.Application.Contracts.Services.Inventory.InventorySetup;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Inventory.InventorySetup;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Inventory.InventorySetup
{
    internal class WarehouseService : AccountsServiceBase, IWarehouseService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public WarehouseService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }
        //done
        public async Task<ReturnBase<WarehouseDto>> Create(
            WarehouseCreateDto createDto)
        {
            try
            {
                var entity = _mapper.Map<Warehouse>(createDto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();
                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<WarehouseDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<WarehouseDto>.Fail(saveResult.Errors);

                var resultDto = _mapper.Map<WarehouseDto>(entity);
                return ReturnBase<WarehouseDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<WarehouseDto>.Fail(ex, _exceptionManager);
            }
        }
        
        public async Task<ReturnBase<WarehouseDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.Warehouses.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Default Account Assignment Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<WarehouseDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<WarehouseDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<WarehouseDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<WarehouseDto>(entity);

                return ReturnBase<WarehouseDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<WarehouseDto>.Fail(ex, _exceptionManager);
            }
        }


         public async Task<ReturnBase<List<WarehouseDto>>> GetAll()
        {
            try
            {
                var result = await _queriesManager.Warehouses.GetAll();

                if (!result.Succeeded)
                {
                    return ReturnBase<List<WarehouseDto>>.Fail(result.Errors);
                }

                var mapped = _mapper.Map<List<WarehouseDto>>(result.Result);

                return ReturnBase<List<WarehouseDto>>.Success(mapped);
            }
            catch (Exception ex)
            {
                return ReturnBase<List<WarehouseDto>>.Fail(ex, _exceptionManager);
            }
        }


    
        public async Task<ReturnBase<WarehouseDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.Warehouses.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "UnitOfMeasure not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<WarehouseDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<WarehouseDto>(entity);

                return ReturnBase<WarehouseDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<WarehouseDto>.Fail(ex, _exceptionManager);
            }
        }


         public async Task<ReturnBase<IEnumerable<WarehouseReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.Warehouses.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<WarehouseReturnSearchDto>>.Fail(getResult.Errors);

                var mappedResult = _mapper.Map<IEnumerable<WarehouseReturnSearchDto>>(getResult.Result);

                return ReturnBase<IEnumerable<WarehouseReturnSearchDto>>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<WarehouseReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<WarehouseDto>> Update(WarehouseUpdateDto updateDto)
        {
            try
            {
                var entity = await _queriesManager.Warehouses.GetById(updateDto.Id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Warehouse Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<WarehouseDto>.Fail(listOfErrors);
                }
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(updateDto, entity);

                //entity = _mapper.Map<Warehouse>(updateDto);
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<WarehouseDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<WarehouseDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<WarehouseDto>(entity);

                return ReturnBase<WarehouseDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<WarehouseDto>.Fail(ex, _exceptionManager);
            }
        }




        public async Task<ReturnBase<IEnumerable<WarehouseSelectDto>>> Select(SqlQueryOptions sqlQueryOptions)
        {
            try
            {

                var getResult = await _queriesManager.Warehouses.Select(sqlQueryOptions);

                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<WarehouseSelectDto>>.Fail(getResult.Errors);

                var mappedResult = _mapper.Map<IEnumerable<WarehouseSelectDto>>(getResult.Result);

                return ReturnBase<IEnumerable<WarehouseSelectDto>>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<WarehouseSelectDto>>.Fail(ex, _exceptionManager);
            }
        }
        private IWarehouseCommandRepository _commands
        {
            get { return _accountUoW.Warehouse; }
        }
    }
}