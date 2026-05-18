using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetAccountingEvents;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.Assets.AssetAccountingEvents;
using Inspection.Application.Contracts.Services.Accounting.Assets.AssetAccountingEvents;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Application.Shared.SharedValidation;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.AssetAccountingEvent.AssetAccountingEvent
{
    internal class AssetAccountingEventService : AccountsServiceBase, IAssetAccountingEventService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public AssetAccountingEventService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }
        public async Task<ReturnBase<AssetAccountingEventDto>> Create(
            AssetAccountingEventCreateDto createDto)
        {
            try
            {
                createDto.Code.ValidateAsCode();
                createDto.Name.ValidateAsName();
                var validationResult = Validate(
                createDto.AssetEventType,
                createDto.SourceModule,
                createDto.IsReversible,
                createDto.Disabled
                );


                if (!validationResult.Succeeded)
                    return validationResult;

                var entity = _mapper.Map<Domain.Models.Accounting.Assets.AssetAccountingEvents.AssetAccountingEvent>(createDto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();
                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<AssetAccountingEventDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<AssetAccountingEventDto>.Fail(saveResult.Errors);

                var resultDto = _mapper.Map<AssetAccountingEventDto>(entity);
                return ReturnBase<AssetAccountingEventDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<AssetAccountingEventDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<AssetAccountingEventDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.AssetAccountingEvents.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "AssetAccountingEvent Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<AssetAccountingEventDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<AssetAccountingEventDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<AssetAccountingEventDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<AssetAccountingEventDto>(entity);

                return ReturnBase<AssetAccountingEventDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<AssetAccountingEventDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<List<AssetAccountingEventDto>>> GetAll()
        {
            try
            {
                var result = await _queriesManager.AssetAccountingEvents.GetAll();

                if (!result.Succeeded)
                {
                    return ReturnBase<List<AssetAccountingEventDto>>.Fail(result.Errors);
                }

                var mapped = _mapper.Map<List<AssetAccountingEventDto>>(result.Result);

                return ReturnBase<List<AssetAccountingEventDto>>.Success(mapped);
            }
            catch (Exception ex)
            {
                return ReturnBase<List<AssetAccountingEventDto>>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<AssetAccountingEventDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.AssetAccountingEvents.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "AssetAccountingEvent not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<AssetAccountingEventDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<AssetAccountingEventDto>(entity);

                return ReturnBase<AssetAccountingEventDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<AssetAccountingEventDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<IEnumerable<AssetAccountingEventDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.AssetAccountingEvents.Search(sqlQueryOptions);
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

        public async Task<ReturnBase<AssetAccountingEventDto>> Update(AssetAccountingEventUpdateDto updateDto)
        {
            try
            {
                updateDto.Code.ValidateAsCode();
                updateDto.Name.ValidateAsName();
                var validationResult = Validate(
                updateDto.AssetEventType,
                updateDto.SourceModule,
                updateDto.IsReversible,
                updateDto.Disabled
                );


                if (!validationResult.Succeeded)
                    return validationResult;

                var entity = await _queriesManager.AssetAccountingEvents.GetById(updateDto.Id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "AssetAccounting Event Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<AssetAccountingEventDto>.Fail(listOfErrors);
                }
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(updateDto, entity);

                //entity.Tenant_ID = _tenantResolver.GetTenantName();

                //entity = _mapper.Map<Inspection.Domain.Models.Accounting.FixedAsset.AssetAccountingEvents.AssetAccountingEvent>(updateDto);

                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<AssetAccountingEventDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<AssetAccountingEventDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<AssetAccountingEventDto>(entity);

                return ReturnBase<AssetAccountingEventDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<AssetAccountingEventDto>.Fail(ex, _exceptionManager);
            }
        }

        private ReturnBase<AssetAccountingEventDto> Validate(
         string assetEventType,
         string sourceModule,
         bool? isReversible,
         bool? disabled)
        {
            var errors = new List<ReturnBaseError>();

            if (string.IsNullOrWhiteSpace(assetEventType))
            {
                errors.Add(new ReturnBaseError
                {
                    ErrorCode = "400",
                    ErrorMessage = "AssetEventType is required"
                });
            }

            if (string.IsNullOrWhiteSpace(sourceModule))
            {
                errors.Add(new ReturnBaseError
                {
                    ErrorCode = "400",
                    ErrorMessage = "SourceModule is required"
                });
            }

            if (isReversible == null)
            {
                errors.Add(new ReturnBaseError
                {
                    ErrorCode = "400",
                    ErrorMessage = "IsReversible is required"
                });
            }

            if (disabled == null)
            {
                errors.Add(new ReturnBaseError
                {
                    ErrorCode = "400",
                    ErrorMessage = "Disabled is required"
                });
            }

            if (errors.Any())
            {
                return ReturnBase<AssetAccountingEventDto>.Fail(errors);
            }

            return ReturnBase<AssetAccountingEventDto>.Success(null);
        }

        private IAssetAccountingEventCommandRepository _commands
        {
            get { return _accountUoW.AssetAccountingEvent; }
        }
    }
}