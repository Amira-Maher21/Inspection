using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetAccountingEventAccounts;
using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetAccountingEvents;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.Assets.AssetAccountingEventAccounts;
using Inspection.Application.Contracts.Services.Accounting.Assets.AssetAccountingEventAccounts;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.Assets.AssetAccountingEventAccounts
{
    internal class AssetAccountingEventAccountService : AccountsServiceBase, IAssetAccountingEventAccountService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public AssetAccountingEventAccountService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }
        public async Task<ReturnBase<AssetAccountingEventAccountDto>> Create(
             AssetAccountingEventAccountCreateDto createDto)
        {
            try
            {

                var entity = _mapper.Map<Domain.Models.Accounting.Assets.AssetAccountingEventAccounts.AssetAccountingEventAccount>(createDto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();
                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<AssetAccountingEventAccountDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<AssetAccountingEventAccountDto>.Fail(saveResult.Errors);

                var resultDto = _mapper.Map<AssetAccountingEventAccountDto>(entity);
                return ReturnBase<AssetAccountingEventAccountDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<AssetAccountingEventAccountDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<AssetAccountingEventAccountDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.AssetAccountingEventAccounts.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = " AssetAccounting Event Account Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<AssetAccountingEventAccountDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<AssetAccountingEventAccountDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<AssetAccountingEventAccountDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<AssetAccountingEventAccountDto>(entity);

                return ReturnBase<AssetAccountingEventAccountDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<AssetAccountingEventAccountDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<List<AssetAccountingEventAccountDto>>> GetAll()
        {
            try
            {
                var result = await _queriesManager.AssetAccountingEventAccounts.GetAll();

                if (!result.Succeeded)
                {
                    return ReturnBase<List<AssetAccountingEventAccountDto>>.Fail(result.Errors);
                }

                var mapped = _mapper.Map<List<AssetAccountingEventAccountDto>>(result.Result);

                return ReturnBase<List<AssetAccountingEventAccountDto>>.Success(mapped);
            }
            catch (Exception ex)
            {
                return ReturnBase<List<AssetAccountingEventAccountDto>>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<AssetAccountingEventAccountDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.AssetAccountingEventAccounts.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = " AssetAccountingEventAccount not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<AssetAccountingEventAccountDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<AssetAccountingEventAccountDto>(entity);

                return ReturnBase<AssetAccountingEventAccountDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<AssetAccountingEventAccountDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<IEnumerable<AssetAccountingEventDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.AssetAccountingEventAccounts.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<AssetAccountingEventDto>>.Fail(getResult.Errors);

                var mappedResult = _mapper.Map<IEnumerable<AssetAccountingEventDto>>(getResult.Result);

                return ReturnBase<IEnumerable<AssetAccountingEventDto>>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<AssetAccountingEventDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<AssetAccountingEventAccountDto>> Update(AssetAccountingEventAccountUpdateDto updateDto)
        {
            try
            {
                var entity = await _queriesManager.AssetAccountingEventAccounts.GetById(updateDto.Id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = " Asset Accounting Event Account Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<AssetAccountingEventAccountDto>.Fail(listOfErrors);
                }
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(updateDto, entity);
                //entity.Tenant_ID = _tenantResolver.GetTenantName();


                //entity = _mapper.Map<Inspection.Domain.Models.Accounting.FixedAsset.AssetAccountingEventAccounts.AssetAccountingEventAccount>(updateDto);

                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<AssetAccountingEventAccountDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<AssetAccountingEventAccountDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<AssetAccountingEventAccountDto>(entity);

                return ReturnBase<AssetAccountingEventAccountDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<AssetAccountingEventAccountDto>.Fail(ex, _exceptionManager);
            }
        }



        private IAssetAccountingEventAccountCommandRepository _commands
        {
            get { return _accountUoW.AssetAccountingEventAccount; }
        }
    }
}