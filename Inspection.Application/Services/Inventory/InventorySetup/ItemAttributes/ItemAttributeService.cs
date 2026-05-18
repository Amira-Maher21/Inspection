using AutoMapper;
using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemAttributeDTOs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Inventory.InventorySetup.ItemAttributes;
using Inspection.Application.Contracts.Repositories.Query.Inventory.InventorySetup.ItemAttributes;
using Inspection.Application.Contracts.Services.Inventory.InventorySetup.ItemAttributes;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Inventory.InventorySetup.ItemAttribute;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Inventory.InventorySetup.ItemAttributes
{
    internal class ItemAttributeService : AccountsServiceBase, IItemAttributeService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly ISeriesService _seriesService;


        public ItemAttributeService(
            IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper,
            IExceptionManager exceptionManager,
            ITenantResolver tenantResolver,
            IExcelTemplateGenerator templateGenerator, ISeriesService seriesService) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
            _seriesService = seriesService;

        }
        private IItemAttributeCommandRepository _commands => _accountUoW.ItemAttribute;
        private IItemAttributeQueryRepository _queries => _queriesManager.ItemAttribute;

        public async Task<ReturnBase<ItemAttributeDto>> Create(ItemAttributeCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<ItemAttribute>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();


                CreateItemAttributeValues(entity, dto);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<ItemAttributeDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<ItemAttributeDto>.Fail(saveResult.Errors);

                return ReturnBase<ItemAttributeDto>.Success(_mapper.Map<ItemAttributeDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ItemAttributeDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<ItemAttributeDto>> Update(ItemAttributeUpdateDto dto)
        {
            try
            {
                var entity = await _queriesManager.ItemAttribute.GetById(dto.Id);

                if (entity == null)
                    return ReturnBase<ItemAttributeDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404",ErrorMessage =$"Item Attribute with Id '{dto.Id}' was not found."}
            });

                _mapper.Map(dto, entity);

                await UpdateItemAttributeValues(entity, dto);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<ItemAttributeDto>.Fail(saveResult.Errors);

                return ReturnBase<ItemAttributeDto>.Success(_mapper.Map<ItemAttributeDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ItemAttributeDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<ItemAttributeDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.ItemAttribute.GetById(id);
                if (entity == null)
                    return ReturnBase<ItemAttributeDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = $" Item Attribute with Id '{id}' was not found" }
                    });


                var updateResult = await _commands.DeleteAsync(id);
                if (!updateResult.Succeeded) return ReturnBase<ItemAttributeDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded) return ReturnBase<ItemAttributeDto>.Fail(saveResult.Errors);

                return ReturnBase<ItemAttributeDto>.Success(_mapper.Map<ItemAttributeDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ItemAttributeDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<ItemAttributeDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.ItemAttribute.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = $"Item Attribute with Id '{id}' was not found."
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<ItemAttributeDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<ItemAttributeDto>(entity);

                return ReturnBase<ItemAttributeDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<ItemAttributeDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<ItemAttributeReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult =
                    await _queriesManager.ItemAttribute.Search(sqlQueryOptions);

                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<ItemAttributeReturnSearchDto>>
                        .Fail(getResult.Errors);

                return ReturnBase<IEnumerable<ItemAttributeReturnSearchDto>>
                    .Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ItemAttributeReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }

        // Create && Update  Item Attribute Value


        private void CreateItemAttributeValues(ItemAttribute entity, ItemAttributeCreateDto dto)
        {
            if (dto.ItemAttributeValues == null || !dto.ItemAttributeValues.Any())
            {
                entity.ItemAttributeValues = new List<ItemAttributeValue>();
                return;
            }

            entity.ItemAttributeValues =
                _mapper.Map<List<ItemAttributeValue>>(dto.ItemAttributeValues);

            foreach (var value in entity.ItemAttributeValues)
            {
                value.ItemAttribute = entity;
            }
        }

        private async Task UpdateItemAttributeValues(ItemAttribute entity, ItemAttributeUpdateDto dto)
        {
            var existingValues = entity.ItemAttributeValues.ToList();

            if (dto.ItemAttributeValues == null || !dto.ItemAttributeValues.Any())
            {
                await _commands.DeleteItemAttributeValuesByItemAttributeId(entity.Id);
                return;
            }

            var dtoIds = dto.ItemAttributeValues
                .Where(v => v.Id > 0)
                .Select(v => v.Id)
                .ToHashSet();

            foreach (var valueDto in dto.ItemAttributeValues)
            {
                if (valueDto.Id == 0)
                {
                    var newValue = _mapper.Map<ItemAttributeValue>(valueDto);
                    newValue.ItemAttributeId = entity.Id;
                    entity.ItemAttributeValues.Add(newValue);
                }
                else
                {
                    var existingValue = existingValues
                        .FirstOrDefault(v => v.Id == valueDto.Id);

                    if (existingValue != null)
                        _mapper.Map(valueDto, existingValue);
                }
            }

            var removed = existingValues
                .Where(v => !dtoIds.Contains(v.Id))
                .Select(v => v.Id)
                .ToList();

            if (removed.Any())
                await _commands.DeleteItemAttributeValuesByItemAttributeIds(removed);
        }
    }
}
