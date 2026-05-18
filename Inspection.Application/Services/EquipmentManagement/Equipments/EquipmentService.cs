using AutoMapper;
using Inspection.Application.Contracts.Dto.EquipmentManagement.Equipments;
using Inspection.Application.Contracts.Dto.EquipmentManagement.Equipments.EquipmentNew;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.Equipments;
using Inspection.Application.Contracts.Services.EquipmentManagement.Equipments;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.EquipmentManagement.Equipments;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

internal class EquipmentService : AccountsServiceBase, IEquipmentService
{
    private readonly ITenantResolver _tenantResolver;
    private readonly ISeriesService _seriesService;

    public EquipmentService(
        IAccountUnitOfWork accountUoW,
        IAccountsQueriesManager queriesManager,
        IMapper mapper,
        IExceptionManager exceptionManager,
        ITenantResolver tenantResolver,
        ISeriesService seriesService)
        : base(accountUoW, queriesManager, mapper, exceptionManager)
    {
        _tenantResolver = tenantResolver;
        _seriesService = seriesService;
    }

    private IEquipmentCommandRepository _commands => _accountUoW.Equipment;






    public async Task<ReturnBase<object>> GetEquipmentByIdAsync(long id)
    {
        try
        {
            var result = await _queriesManager.Equipment.GetEquipmentByIdAsync(id);

            if (result == null)
            {
                return ReturnBase<object>.Fail(new List<ReturnBaseError>
            {
                new ReturnBaseError
                {
                    ErrorCode = "404",
                    ErrorMessage = "Equipment Not Found"
                }
            });
            }

            return ReturnBase<object>.Success(result);
        }
        catch (Exception ex)
        {
            return ReturnBase<object>.Fail(ex, _exceptionManager);
        }
    }



    #region Create

    public async Task<ReturnBase<EquipmentDto>> Create(CreateEquipmentDto dto)
    {
        try
        {
            var entity = _mapper.Map<Equipment>(dto);
            entity.Tenant_ID = _tenantResolver.GetTenantName();



            const string SCREEN_CODE = "Equipments";

            var series = await _queriesManager.Series.GetByScreen_IDAsync(SCREEN_CODE);

            if (series == null || !series.IsActive)
            {
                return ReturnBase<EquipmentDto>.Fail(new List<ReturnBaseError>
                {
                    new()
                    {
                        ErrorCode = "400",
                        ErrorMessage = $"No active series configured for screen '{SCREEN_CODE}'"
                    }
                });
            }

            entity.SeriesId = series.Id;

            var seriesResult =
                await _seriesService.GetSeriesCodeWithCustomDateUsingSeriesDetails(series.Id, null);

            if (!seriesResult.Succeeded || seriesResult.Result == null)
                return ReturnBase<EquipmentDto>.Fail(seriesResult.Errors);

            entity.EquipmentNo =
                seriesResult.Result["FinelSeriesCodeAndSeriesNumber"];

            entity.RunningNumber =
                int.Parse(seriesResult.Result["RunningNumber"]);



            var insertResult = await _commands.InsertAsync(entity);
            if (!insertResult.Succeeded)
                return ReturnBase<EquipmentDto>.Fail(insertResult.Errors);

            var saveResult = await _accountUoW.SaveAsync();
            if (!saveResult.Succeeded)
                return ReturnBase<EquipmentDto>.Fail(saveResult.Errors);

            return ReturnBase<EquipmentDto>.Success(_mapper.Map<EquipmentDto>(entity));
        }
        catch (Exception ex)
        {
            return ReturnBase<EquipmentDto>.Fail(ex, _exceptionManager);
        }
    }

    #endregion

    #region Update

    public async Task<ReturnBase<EquipmentDto>> Update(UpdateEquipmentDto dto)
    {
        try
        {
            var entity = await _queriesManager.Equipment.GetByIdAsync(dto.Id);

            if (entity is null)
            {
                return ReturnBase<EquipmentDto>.Fail(new List<ReturnBaseError>
                {
                    new()
                    {
                        ErrorCode = "404",
                        ErrorMessage = $"Equipment with Id {dto.Id} Not Found"
                    }
                });
            }

            entity.Tenant_ID = _tenantResolver.GetTenantName();

            _mapper.Map(dto, entity);

            var saveResult = await _accountUoW.SaveAsync();
            if (!saveResult.Succeeded)
                return ReturnBase<EquipmentDto>.Fail(saveResult.Errors);

            return ReturnBase<EquipmentDto>.Success(_mapper.Map<EquipmentDto>(entity));
        }
        catch (Exception ex)
        {
            return ReturnBase<EquipmentDto>.Fail(ex, _exceptionManager);
        }
    }

    #endregion

    #region Delete

    public async Task<ReturnBase<EquipmentDto>> Delete(long id)
    {
        try
        {
            var entity = await _queriesManager.Equipment.GetByIdAsync(id);

            if (entity is null)
            {
                return ReturnBase<EquipmentDto>.Fail(new List<ReturnBaseError>
            {
                new ReturnBaseError
                {
                    ErrorCode = "404",
                    ErrorMessage = "Equipment Not Found"
                }
            });
            }

            var deleteResult = await _commands.DeleteById(id);
            if (!deleteResult.Succeeded)
                return ReturnBase<EquipmentDto>.Fail(deleteResult.Errors);

            var saveResult = await _accountUoW.SaveAsync();
            if (!saveResult.Succeeded)
                return ReturnBase<EquipmentDto>.Fail(saveResult.Errors);

            var mappedResult = _mapper.Map<EquipmentDto>(entity);

            return ReturnBase<EquipmentDto>.Success(mappedResult);
        }
        catch (Exception ex)
        {
            return ReturnBase<EquipmentDto>.Fail(ex, _exceptionManager);
        }
    }

    #endregion

    #region GetById

    public async Task<ReturnBase<EquipmentDto>> GetById(long id)
    {
        try
        {
            var entity = await _queriesManager.Equipment.GetByIdAsync(id);

            if (entity is null)
            {
                return ReturnBase<EquipmentDto>.Fail(new List<ReturnBaseError>
                {
                    new()
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Equipment Not Found"
                    }
                });
            }

            return ReturnBase<EquipmentDto>.Success(_mapper.Map<EquipmentDto>(entity));
        }
        catch (Exception ex)
        {
            return ReturnBase<EquipmentDto>.Fail(ex, _exceptionManager);
        }
    }

    #endregion

    #region Search

    public async Task<ReturnBase<IEnumerable<EquipmentReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
    {
        try
        {
            var getResult = await _queriesManager.Equipment.Search(sqlQueryOptions);

            if (!getResult.Succeeded)
                return ReturnBase<IEnumerable<EquipmentReturnSearchDto>>.Fail(getResult.Errors);

            return ReturnBase<IEnumerable<EquipmentReturnSearchDto>>.Success(getResult.Result);
        }
        catch (Exception ex)
        {
            return ReturnBase<IEnumerable<EquipmentReturnSearchDto>>.Fail(ex, _exceptionManager);
        }
    }

    #endregion

    #region Checklist

    public async Task<ReturnBase<EquipmentWithChecklistTemplateDto>> GetChecklistTampleteAsync(long id)
    {
        var tenantName = _tenantResolver.GetTenantName();
        var commonData = _tenantResolver.GetCommonUserData();

        long companyId = 2;

        if (commonData?.Company != null)
        {
            long parsedCompanyId;
            if (long.TryParse(commonData.Company, out parsedCompanyId))
            {
                companyId = parsedCompanyId;
            }
        }

        var checklistResult = await _queriesManager.Equipment.GetChecklistTemplateByEquipmentAsync(id, tenantName, companyId);

        if (!checklistResult.Succeeded || checklistResult.Result == null)
            return ReturnBase<EquipmentWithChecklistTemplateDto>.Fail(checklistResult.Errors);

        return ReturnBase<EquipmentWithChecklistTemplateDto>.Success(checklistResult.Result);
    }


    #endregion
}