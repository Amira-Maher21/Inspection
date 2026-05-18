using AutoMapper;
using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.Activitys;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Contracting.Setup.Activitys;
using Inspection.Application.Contracts.Services.Contracting.Setup.Activitys;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.Contracting.Setup.Activitys;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Contracting.Setup.Activitys
{
    public class ActivityService : AccountsServiceBase, IActivityService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly ISeriesService _seriesService;

        public ActivityService(
     IAccountUnitOfWork uow,
     IAccountsQueriesManager queriesManager,
     IMapper mapper,
     IExceptionManager exceptionManager,
     ITenantResolver tenantResolver,
     ISeriesService seriesService)
             : base(uow, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _seriesService = seriesService;
        }

        private IActivityCommandRepository _commands => _accountUoW.Activity;

        // ================= CREATE =================
        public async Task<ReturnBase<ActivityDto>> Create(ActivityCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<Activity>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();


                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<ActivityDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<ActivityDto>.Fail(saveResult.Errors);

                return ReturnBase<ActivityDto>.Success(_mapper.Map<ActivityDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ActivityDto>.Fail(ex, _exceptionManager);
            }
        }

        // ================= UPDATE =================
        public async Task<ReturnBase<ActivityDto>> Update(ActivityUpdaeDto dto)
        {
            try
            {
                var entity = await _queriesManager.Activity.GetById(dto.Id);
                if (entity == null)
                    return NotFound();

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(dto, entity);

                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)
                    return ReturnBase<ActivityDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<ActivityDto>.Fail(saveResult.Errors);

                return ReturnBase<ActivityDto>.Success(_mapper.Map<ActivityDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ActivityDto>.Fail(ex, _exceptionManager);
            }
        }

        // ================= DELETE =================
        public async Task<ReturnBase<ActivityDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.Activity.GetById(id);
                if (entity == null)
                    return NotFound();

                var deleteResult = await _commands.DeleteById(id);
                if (!deleteResult.Succeeded)
                    return ReturnBase<ActivityDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<ActivityDto>.Fail(saveResult.Errors);

                return ReturnBase<ActivityDto>.Success(_mapper.Map<ActivityDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ActivityDto>.Fail(ex, _exceptionManager);
            }
        }

        // ================= GET BY ID =================
        public async Task<ReturnBase<ActivityDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.Activity.GetById(id);
                if (entity == null)
                    return NotFound();

                return ReturnBase<ActivityDto>.Success(
                    _mapper.Map<ActivityDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ActivityDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<IEnumerable<ActivityReturnSearchDto>>> Search(SqlQueryOptions options)
        {
            try
            {
                var result = await _queriesManager.Activity.Search(options);
                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<ActivityReturnSearchDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<ActivityReturnSearchDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ActivityReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        private ReturnBase<ActivityDto> NotFound()
        {
            return ReturnBase<ActivityDto>.Fail(
                new List<ReturnBaseError>
                {
                    new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Activity Not Found"
                    }
                });
        }
    }
}