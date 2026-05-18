using AutoMapper;
using Inspection.Application.Contracts.Dto.Manufacturing.Setup.ProductionOrderDTOs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Manufacturing.Setup.ProductionOrders;
using Inspection.Application.Contracts.Repositories.Query.Manufacturing.Setup.ProductionOrders;
using Inspection.Application.Contracts.Services.Manufacturing.Setup.ProductionOrders;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Manufacturing.Setup.ProductionOrder;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Manufacturing.Setup.Contracting.ProductionOrders
{
    internal class ProductionOrderService : AccountsServiceBase, IProductionOrderService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;


        public ProductionOrderService(
            IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper,
            IExceptionManager exceptionManager,
            ITenantResolver tenantResolver,
            IExcelTemplateGenerator templateGenerator) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;

        }
        private IProductionOrderCommandRepository _commands => _accountUoW.ProductionOrder;
        private IProductionOrderQueryRepository _queries => _queriesManager.ProductionOrder;

        public async Task<ReturnBase<ProductionOrderDto>> Create(ProductionOrderCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<ProductionOrder>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                CreateProductionOrderLines(entity, dto);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<ProductionOrderDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<ProductionOrderDto>.Fail(saveResult.Errors);

                return ReturnBase<ProductionOrderDto>.Success(_mapper.Map<ProductionOrderDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ProductionOrderDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<ProductionOrderDto>> Update(ProductionOrderUpdateDto dto)
        {
            try
            {
                var entity = await _queriesManager.ProductionOrder.GetById(dto.Id);

                if (entity == null)
                    return ReturnBase<ProductionOrderDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404", ErrorMessage = $"Production Order with Id {dto.Id} was not found" }
            });

                _mapper.Map(dto, entity);

                await UpdateProductionOrderLines(entity, dto);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<ProductionOrderDto>.Fail(saveResult.Errors);

                return ReturnBase<ProductionOrderDto>.Success(_mapper.Map<ProductionOrderDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ProductionOrderDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<ProductionOrderDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.ProductionOrder.GetById(id);
                if (entity == null)
                    return ReturnBase<ProductionOrderDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = $"Production Order with Id {id} was not found" }
                    });


                var updateResult = await _commands.DeleteAsync(id);
                if (!updateResult.Succeeded) return ReturnBase<ProductionOrderDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded) return ReturnBase<ProductionOrderDto>.Fail(saveResult.Errors);

                return ReturnBase<ProductionOrderDto>.Success(_mapper.Map<ProductionOrderDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ProductionOrderDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<ProductionOrderDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.ProductionOrder.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = $"Production Order with Id '{id}' was not found."
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<ProductionOrderDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<ProductionOrderDto>(entity);

                return ReturnBase<ProductionOrderDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<ProductionOrderDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<ProductionOrderReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult =
                    await _queriesManager.ProductionOrder.Search(sqlQueryOptions);

                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<ProductionOrderReturnSearchDto>>
                        .Fail(getResult.Errors);

                return ReturnBase<IEnumerable<ProductionOrderReturnSearchDto>>
                    .Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ProductionOrderReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }



        // ProductionOrderLines
        private void CreateProductionOrderLines(ProductionOrder entity, ProductionOrderCreateDto dto)
        {
            if (dto.ProductionOrderLines == null || !dto.ProductionOrderLines.Any())
            {
                entity.ProductionOrderLines = new List<ProductionOrderLine>();
                return;
            }

            entity.ProductionOrderLines = _mapper.Map<List<ProductionOrderLine>>(dto.ProductionOrderLines);
            foreach (var line in entity.ProductionOrderLines)
            {
                line.ProductionOrder = entity;
            }
        }

        private async Task UpdateProductionOrderLines(ProductionOrder entity, ProductionOrderUpdateDto dto)
        {
            var existing = entity.ProductionOrderLines.ToList();

            if (dto.ProductionOrderLines == null || !dto.ProductionOrderLines.Any())
            {
                var allIds = existing.Select(x => x.Id).ToList();

                if (allIds.Any())
                    await _commands.DeleteProductionOrderLinesByProductionOrderIds(allIds);
                return;
            }

            var dtoIds = dto.ProductionOrderLines
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            foreach (var lineDto in dto.ProductionOrderLines)
            {
                if (lineDto.Id == 0)
                {
                    var newEntity = _mapper.Map<ProductionOrderLine>(lineDto);
                    newEntity.ProductionOrderId = entity.Id;
                    entity.ProductionOrderLines.Add(newEntity);
                }
                else
                {
                    var existingEntity = existing.FirstOrDefault(x => x.Id == lineDto.Id);

                    if (existingEntity != null)
                        _mapper.Map(lineDto, existingEntity);
                }
            }

            var removed = existing
                .Where(x => !dtoIds.Contains(x.Id))
                .Select(x => x.Id)
                .ToList();

            if (removed.Any())
                await _commands.DeleteProductionOrderLinesByProductionOrderIds(removed);
        }

    }
}