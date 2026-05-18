using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetComponents;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.Assets.Setup.AssetComponents;
using Inspection.Application.Contracts.Services.Accounting.Assets.Setup.AssetComponents;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Application.Shared.SharedValidation;
using Inspection.Domain.Models.Accounting.Assets.Setup.AssetCategories;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.Assets.Setup.AssetComponents
{
    public class AssetComponentService : AccountsServiceBase, IAssetComponentService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public AssetComponentService(
            IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            IExcelTemplateGenerator templateGenerator
        ) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }
        private IAssetComponentCommandRepository _commands => _accountUoW.AssetComponent;

        public async Task<ReturnBase<AssetComponentDto>> Create(AssetComponentCreateDto dto)
        {
            try
            {
                dto.ComponentName.ValidateAsName();

                var entity = _mapper.Map<AssetComponent>(dto);

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<AssetComponentDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<AssetComponentDto>.Fail(saveResult.Errors);

                var resultDto = _mapper.Map<AssetComponentDto>(entity);

                return ReturnBase<AssetComponentDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<AssetComponentDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<AssetComponentDto>> Update(AssetComponentUpdateDto dto)
        {
            try
            {
                var entity = await _queriesManager.AssetComponent.GetById(dto.Id);

                if (entity == null)
                    return ReturnBase<AssetComponentDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404", ErrorMessage = $"Asset Component with Id {dto.Id} was not found" }
            });

                _mapper.Map(dto, entity);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<AssetComponentDto>.Fail(saveResult.Errors);

                return ReturnBase<AssetComponentDto>.Success(_mapper.Map<AssetComponentDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<AssetComponentDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<AssetComponentDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.AssetComponent.GetById(id);

                if (entity is null)
                {
                    return ReturnBase<AssetComponentDto>.Fail(new List<ReturnBaseError>
                      {
                          new ReturnBaseError
                          {
                           ErrorCode = "404",
                           ErrorMessage = $"Asset Component with '{id}' was not found"
                          }
                      });
                }

                var deleteResult = await _commands.DeleteById(id);
                if (!deleteResult.Succeeded)
                    return ReturnBase<AssetComponentDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<AssetComponentDto>.Fail(saveResult.Errors);

                var resultDto = _mapper.Map<AssetComponentDto>(entity);

                return ReturnBase<AssetComponentDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<AssetComponentDto>.Fail(ex, _exceptionManager);
            }
        }

        // -------------------- GET BY ID --------------------
        public async Task<ReturnBase<AssetComponentDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.AssetComponent.GetById(id);

                if (entity is null)
                {
                    return ReturnBase<AssetComponentDto>.Fail(new List<ReturnBaseError>
                      {
                          new ReturnBaseError
                          {
                           ErrorCode = "404",
                           ErrorMessage = $"Asset Component with '{id}' was not found"
                          }
                      });
                }

                var resultDto = _mapper.Map<AssetComponentDto>(entity);

                return ReturnBase<AssetComponentDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<AssetComponentDto>.Fail(ex, _exceptionManager);
            }
        }

        // -------------------- SEARCH --------------------
        public async Task<ReturnBase<IEnumerable<AssetComponentReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult =
                    await _queriesManager.AssetComponent.Search(sqlQueryOptions);

                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<AssetComponentReturnSearchDto>>
                        .Fail(getResult.Errors);

                return ReturnBase<IEnumerable<AssetComponentReturnSearchDto>>
                    .Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<AssetComponentReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }

    }
}