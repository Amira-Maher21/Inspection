using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.LedgerDTOs;
using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.LedgerDTOs.LedgerLineDTOs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup.ILedgerCommandRepository;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup.LedgerCommandRepository;
using Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSetup.LedgerQueryRepository;
using Inspection.Application.Contracts.Services.Accounting.AccountSetup.ILedger;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.Inventory.Ledger;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.SharedModels;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.AccountSetup.LedgerService
{
    public class LedgerService : AccountsServiceBase, ILedgerService
    {
        private readonly ITenantResolver _tenantResolver;

        public LedgerService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager,
            IMapper mapper, IExceptionManager exceptionManager,
            ITenantResolver tenantResolver
            ) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
        }

        private ILedgerCommandRepository _commandsMaster => _accountUoW.Ledger;
        private ILedgerLineCommandRepository _commandsDetails => _accountUoW.LedgerLine;
        private ILedgerQueryRepository _queriesMaster => _queriesManager.Ledger;
        private ILedgerLineQueryRepository _queriesDetails => _queriesManager.LedgerLine;

        public async Task<ReturnBase<UpdateLedgerDto>> CreateAsync(CreateLedgerDto input)
        {
            try
            {
                var entityMaster = _mapper.Map<Ledger>(input);
                entityMaster.Tenant_ID = _tenantResolver.GetTenantName();
                entityMaster.LedgerLines = new List<LedgerLine>();


                // ADD CHILDREN BEFORE INSERT
                foreach (var item in input.LedgerLines)
                {
                    var entityDetail = _mapper.Map<LedgerLine>(item);
                    entityMaster.LedgerLines.Add(entityDetail);
                }

                var insertMasterResult = await _commandsMaster.InsertAsync(entityMaster);
                if (!insertMasterResult.Succeeded)
                    return ReturnBase<UpdateLedgerDto>.Fail(insertMasterResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateLedgerDto>.Fail(saveResult.Errors);

                return ReturnBase<UpdateLedgerDto>.Success(
                    _mapper.Map<UpdateLedgerDto>(entityMaster)
                );
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateLedgerDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<bool>> DeleteAsync(long id)
        {
            try
            {
                var keys = new EntityKeyValueDictionary();
                keys.Add(new KeyValuePair<string, object>("Id", id));

                var deleteResult = await _commandsMaster.DeleteAsync(keys);
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

        public async Task<ReturnBase<List<LedgerDto>>> Index(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var list = await _queriesMaster.GetListByIncludeAsync(sqlQueryOptions);

                return ReturnBase<List<LedgerDto>>
                    .Success(list?.ToList() ?? new List<LedgerDto>());
            }
            catch (Exception ex)
            {
                return ReturnBase<List<LedgerDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<UpdateLedgerDto>> UpdateAsync(UpdateLedgerDto input)
        {
            try
            {
                var entityMaster = await _queriesMaster.GetByIdAsync(input.Id);
                if (entityMaster == null)
                    return ReturnBase<UpdateLedgerDto>.Fail();

                _mapper.Map(input, entityMaster);
                entityMaster.LedgerLines = null;


                var updateResultMaster = await _commandsMaster.UpdateAsync(entityMaster);
                if (!updateResultMaster.Succeeded)
                    return ReturnBase<UpdateLedgerDto>.Fail(updateResultMaster.Errors);
                else
                {
                    //ensert Details and update Details
                    foreach (var item in input.LedgerLines)
                    {
                        if (item.Id <= 0)
                        {
                            item.LedgerId = entityMaster.Id;
                            var entityDetail = _mapper.Map<LedgerLine>(item);
                            var resultDetail = await _commandsDetails.InsertAsync(entityDetail);
                            if (!resultDetail.Succeeded)
                            {
                                return ReturnBase<UpdateLedgerDto>.Fail(resultDetail.Errors);
                            }
                        }
                        else
                        {
                            var entityDetails = await _queriesDetails.GetByIdAsync(item.Id);
                            _mapper.Map(item, entityDetails);
                            var updateResultDetails = await _commandsDetails.UpdateAsync(entityDetails);
                            if (!updateResultDetails.Succeeded)
                            {
                                return ReturnBase<UpdateLedgerDto>.Fail(updateResultDetails.Errors);
                            }
                        }
                    }
                }
                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded) return ReturnBase<UpdateLedgerDto>.Fail(saveResult.Errors);

                return ReturnBase<UpdateLedgerDto>.Success(_mapper.Map<UpdateLedgerDto>(entityMaster));
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateLedgerDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<LedgerDto>> GetAsync(long id)
        {
            try
            {
                var Item = await _queriesMaster.GetByIdAsync(id);
                var itemDto = _mapper.Map<LedgerDto>(Item);

                return new ReturnBase<LedgerDto>(itemDto, true);
            }
            catch (Exception ex)
            {
                return ReturnBase<LedgerDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<IEnumerable<ViewEntryLedgerDto>>> ViewEntry(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var result = await _queriesMaster.GetLedgerLinesByDocumentAsync(sqlQueryOptions);

                return ReturnBase<IEnumerable<ViewEntryLedgerDto>>
                    .Success(result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ViewEntryLedgerDto>>
                    .Fail(ex, _exceptionManager);
            }
        }
    }
}
