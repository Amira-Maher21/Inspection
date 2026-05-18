using AutoMapper;
using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.Batchs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Inventory.InventorySetup.Batchs;
using Inspection.Application.Contracts.Services.Inventory.Batchs;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.Inventory.InventorySetup.Batchs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Inventory.InventorySetup.Batchs
{

    public class BatchServise : AccountsServiceBase, IBatchServise
    {
        private readonly ITenantResolver _tenantResolver;

        public BatchServise(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
        }




        public async Task<ReturnBase<BatchDto>> Create(BatchCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<Batch>(dto);
                var TenantName = _tenantResolver.GetTenantName();
                entity.Tenant_ID = TenantName;



                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<BatchDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<BatchDto>.Fail(saveResult.Errors);

                return ReturnBase<BatchDto>.Success(_mapper.Map<BatchDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<BatchDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<BatchDto>> Update(BatchUpdateDto dto)
        {
            try
            {
                var entity = await _queriesManager.Batch.GetById(dto.Id);
                if (entity is null)
                {
                    return ReturnBase<BatchDto>.Fail(new List<ReturnBaseError>
            {
                new ReturnBaseError
                {
                    ErrorCode = "404",
                    ErrorMessage = "Batch Not Found"
                }
            });
                }
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(dto, entity);








                var updateResult = await _commands.UpdateAsync(entity);


                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<BatchDto>.Fail(saveResult.Errors);

                return ReturnBase<BatchDto>.Success(_mapper.Map<BatchDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<BatchDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<BatchDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.Batch.GetById(id);
                if (entity is null)
                {
                    return ReturnBase<BatchDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404", ErrorMessage = "Batch Not Found" }
            });
                }

                var mappedResult = _mapper.Map<BatchDto>(entity);

                var deleteResult = await _commands.DeleteById(id);
                if (!deleteResult.Succeeded)
                    return ReturnBase<BatchDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<BatchDto>.Fail(saveResult.Errors);


                return ReturnBase<BatchDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<BatchDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<BatchDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.Batch.GetById(id);
                if (entity is null)
                {
                    return ReturnBase<BatchDto>.Fail(new List<ReturnBaseError>
            {
                new ReturnBaseError
                {
                    ErrorCode = "404",
                    ErrorMessage = "Batch Not Found"
                }
            });
                }

                var mappedResult = _mapper.Map<BatchDto>(entity);
                return ReturnBase<BatchDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<BatchDto>.Fail(ex, _exceptionManager);
            }
        }

        //public async Task<ReturnBase<IEnumerable<BatchDto>>> GetList(SqlQueryOptions? sqlQueryOptions = null)
        //{
        //    try
        //    {
        //        var entities = await _queriesManager.Batch.GetList(sqlQueryOptions);
        //        var mappedResult = _mapper.Map<IEnumerable<BatchDto>>(entities);
        //        return ReturnBase<IEnumerable<BatchDto>>.Success(mappedResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ReturnBase<IEnumerable<BatchDto>>.Fail(ex, _exceptionManager);
        //    }
        //}




        public async Task<ReturnBase<IEnumerable<BatchReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.Batch.Search(sqlQueryOptions);

                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<BatchReturnSearchDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<BatchReturnSearchDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<BatchReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }



        private IBatchCommandRepository _commands
    => _accountUoW.Batch;

    }

}
