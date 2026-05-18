using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetGroupDTOs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.Assets.Setup.FixedAssets;
using Inspection.Application.Contracts.Services.Accounting.Assets.Setup.AssetGroups;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Accounting.Assets.Setup.AssetGroups;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.Assets.Setup.AssetGroups
{
    internal class AssetGroupService : AccountsServiceBase, IAssetGroupService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly ISeriesService _seriesService;


        public AssetGroupService(
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
        private IAssetGroupCommandRepository _commands => _accountUoW.AssetGroup;



        public async Task<ReturnBase<AssetGroupDto>> Create(AssetGroupCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<AssetGroup>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();


                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<AssetGroupDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<AssetGroupDto>.Fail(saveResult.Errors);

                return ReturnBase<AssetGroupDto>.Success(_mapper.Map<AssetGroupDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<AssetGroupDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<AssetGroupDto>> Update(AssetGroupUpdateDto dto)
        {
            try
            {
                var entity = await _queriesManager.AssetGroup.GetById(dto.Id);

                if (entity == null)
                    return ReturnBase<AssetGroupDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404", ErrorMessage = $"Asset Group with Id {dto.Id} was not found" }
            });

                _mapper.Map(dto, entity);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<AssetGroupDto>.Fail(saveResult.Errors);

                return ReturnBase<AssetGroupDto>.Success(_mapper.Map<AssetGroupDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<AssetGroupDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<AssetGroupDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.AssetGroup.GetById(id);
                if (entity == null)
                    return ReturnBase<AssetGroupDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = $"Asset Group with Id {id} was not found" }
                    });


                var updateResult = await _commands.DeleteAsync(id);
                if (!updateResult.Succeeded) return ReturnBase<AssetGroupDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded) return ReturnBase<AssetGroupDto>.Fail(saveResult.Errors);

                return ReturnBase<AssetGroupDto>.Success(_mapper.Map<AssetGroupDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<AssetGroupDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<AssetGroupDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.AssetGroup.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = $"Asset Group with Id '{id}' was not found."
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<AssetGroupDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<AssetGroupDto>(entity);

                return ReturnBase<AssetGroupDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<AssetGroupDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<AssetGroupReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult =
                    await _queriesManager.AssetGroup.Search(sqlQueryOptions);

                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<AssetGroupReturnSearchDto>>
                        .Fail(getResult.Errors);

                return ReturnBase<IEnumerable<AssetGroupReturnSearchDto>>
                    .Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<AssetGroupReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }

    }
}
