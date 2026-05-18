using AutoMapper;
using Inspection.Application.Contracts.Dto.Inventory.System.InventoryLedgers;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Inventory.System.InventoryLedgers;
using Inspection.Application.Contracts.Services.Inventory.System.InventoryLedgers;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Inventory.System.InventoryLedgers;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Inventory.System.InventoryLedgers
{
    public class InventoryLedgerService : AccountsServiceBase, IInventoryLedgerService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public InventoryLedgerService(
                IAccountUnitOfWork accountUoW,
                IAccountsQueriesManager queriesManager,
                IMapper mapper,
                IExceptionManager exceptionManager,
                ITenantResolver tenantResolver,
                IExcelTemplateGenerator templateGenerator
            )
            : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }


        public async Task<ReturnBase<InventoryLedgerDto>> Create(InventoryLedgerCreateDto createDto)
        {
            try
            {
                ValidateQuantityRule(createDto.QuantityIn, createDto.QuantityOut);

                var entity = _mapper.Map<InventoryLedger>(createDto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();


                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<InventoryLedgerDto>.Fail(insertResult.Errors);

                //var saveResult = await _accountUoW.SaveAsync();
                //if (!saveResult.Succeeded)
                //    return ReturnBase<InventoryLedgerDto>.Fail(saveResult.Errors);

                var resultDto = _mapper.Map<InventoryLedgerDto>(entity);
                return ReturnBase<InventoryLedgerDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<InventoryLedgerDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<InventoryLedgerDto>> Update(InventoryLedgerUpdateDto updateDto)
        {
            try
            {
                var entity = await _queriesManager.InventoryLedger.GetById(updateDto.Id);
                if (entity == null)
                    return ReturnBase<InventoryLedgerDto>.Fail(new List<ReturnBaseError>
            {
                new ReturnBaseError { ErrorCode = "404", ErrorMessage = "Inventory Ledger Not Found" }
            });

                ValidateQuantityRule(updateDto.QuantityIn, updateDto.QuantityOut);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(updateDto, entity);
                entity.Mod_User = "currentUser";
                entity.Mod_Date = DateTime.UtcNow;

                //var saveResult = await _accountUoW.SaveAsync();
                //if (!saveResult.Succeeded)
                //    return ReturnBase<InventoryLedgerDto>.Fail(saveResult.Errors);

                var resultDto = _mapper.Map<InventoryLedgerDto>(entity);
                return ReturnBase<InventoryLedgerDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<InventoryLedgerDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<InventoryLedgerDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.InventoryLedger.GetById(id);
                if (entity == null)
                {
                    return ReturnBase<InventoryLedgerDto>.Fail(new List<ReturnBaseError>
                    {
                        new ReturnBaseError
                        {
                            ErrorCode = "404",
                            ErrorMessage = "Inventory Ledger Not Found"
                        }
                    });
                }

                //var deleteResult = await _commands.DeleteById(id);
                //if (!deleteResult.Succeeded)
                //    return ReturnBase<InventoryLedgerDto>.Fail(deleteResult.Errors);

                entity.IsDeleted = true;
                entity.IsCancelled = true;

                await _commands.UpdateAsync(entity);


                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<InventoryLedgerDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<InventoryLedgerDto>(entity);
                return ReturnBase<InventoryLedgerDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<InventoryLedgerDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<InventoryLedgerReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.InventoryLedger.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<InventoryLedgerReturnSearchDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<InventoryLedgerReturnSearchDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InventoryLedgerReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<InventoryLedger?> GetByItemAsync(long itemId, long warehouseId, long? warehouseLocationId)
        {
            var getResult = await _queriesManager.InventoryLedger.GetByItemAsync(itemId, warehouseId, warehouseLocationId);
            return getResult;
        }


        public async Task<ReturnBase<InventoryLedgerDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.InventoryLedger.GetById(id);
                if (entity == null)
                {
                    return ReturnBase<InventoryLedgerDto>.Fail(new List<ReturnBaseError>
                    {
                        new ReturnBaseError
                        {
                            ErrorCode = "404",
                            ErrorMessage = "Inventory Ledger Not Found"
                        }
                    });
                }

                var mappedResult = _mapper.Map<InventoryLedgerDto>(entity);
                return ReturnBase<InventoryLedgerDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<InventoryLedgerDto>.Fail(ex, _exceptionManager);
            }
        }
        private ReturnBase<InventoryLedgerDto> ValidateQuantityRule(decimal? quantityIn, decimal? quantityOut)
        {
            var inQty = quantityIn ?? 0;
            var outQty = quantityOut ?? 0;

            if ((inQty > 0 && outQty > 0) || (inQty == 0 && outQty == 0))
            {
                return ReturnBase<InventoryLedgerDto>.Fail(new List<ReturnBaseError>
                {
                    new ReturnBaseError
                    {
                        ErrorCode = "400",
                        ErrorMessage = "Either QuantityIn or QuantityOut must be entered, not both or neither."
                    }
                });
            }

            return ReturnBase<InventoryLedgerDto>.Success(null);
        }

        public async Task<InventoryLedger?> GetLastEntryAsync(long itemId, long warehouseId, long? warehouseLocationId)
        {
            var entries = await _queriesManager.InventoryLedger.GetEntriesForItem(itemId, warehouseId, warehouseLocationId);

            return entries
                .OrderByDescending(x => x.PostingDate)
                .ThenByDescending(x => x.Id)
                .FirstOrDefault();
        }

        public async Task<List<InventoryLedger>> GetEntriesForItem(long itemId, long warehouseId, long? warehouseLocationId)
        {
            var result = await _queriesManager.InventoryLedger.GetEntriesForItem(itemId, warehouseId, warehouseLocationId);
            return result.ToList();
        }

        public async Task MarkAsCancelled(long id)
        {
            var entity = await _queriesManager.InventoryLedger.GetById(id);

            if (entity == null)
                throw new Exception("InventoryLedger not found");

            entity.IsCancelled = true;
            entity.Mod_Date = DateTime.UtcNow;
            entity.Mod_User = "system";

            await _commands.UpdateAsync(entity);
        }

        public async Task UpdateBalanceOnly(long id, decimal balance)
        {
            var entity = await _queriesManager.InventoryLedger.GetById(id);

            if (entity == null)
                throw new Exception("InventoryLedger not found");

            entity.BalanceAfter = balance;
            entity.Mod_Date = DateTime.UtcNow;
            entity.Mod_User = "system";

            await _commands.UpdateAsync(entity);
        }

        //public async Task<List<InventoryLedger>> GetByReferenceDocumentId(long referenceDocumentId)
        //{
        //    var result = await _queriesManager.InventoryLedger.GetAllAsync();
        //    return result.Result
        //        .Where(x => x.ReferenceDocumentId == referenceDocumentId && !x.IsDeleted)
        //        .ToList();
        //}

        public async Task<List<InventoryLedger>> GetByReferenceDocumentId(long referenceDocumentId)
        {
            var result = await _queriesManager.InventoryLedger.GetByReferenceDocumentId(referenceDocumentId);
            return result.ToList();
        }

        private IInventoryLedgerCommandRepository _commands
            => _accountUoW.InventoryLedger;
    }
}