using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionMethodDTOs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionMethods;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionMethods;
using Inspection.Application.Contracts.Services.InspectionManagement.InspectionMethods;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.InspectionManagement.InspectionMethods;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.InspectionManagement.InspectionMethods
{

    public class InspectionMethodService : AccountsServiceBase, IInspectionMethodService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly ISeriesService _seriesService;

        public InspectionMethodService(
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
        private IInspectionMethodCommandRepository _commands => _accountUoW.InspectionMethod;
        private IInspectionMethodQueryRepository _queries => _queriesManager.InspectionMethod;

        public async Task<ReturnBase<InspectionMethodDto>> Create(InspectionMethodCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<InspectionMethod>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // Series
                const string SCREEN_CODE = "Inspection Method";

                var series = await _queriesManager.Series.GetByScreen_IDAsync(SCREEN_CODE);

                if (series == null || !series.IsActive)
                    return ReturnBase<InspectionMethodDto>.Fail(
                        new Exception($"No active series configured for screen '{SCREEN_CODE}'"),
                        _exceptionManager);

                entity.SeriesId = series.Id;

                var seriesResult = await _seriesService
                    .GetSeriesCodeWithCustomDateUsingSeriesDetails(series.Id, DateTime.Now);

                if (!seriesResult.Succeeded || seriesResult.Result == null)
                    return ReturnBase<InspectionMethodDto>.Fail(seriesResult.Errors);

                entity.Code = seriesResult.Result["FinelSeriesCodeAndSeriesNumber"];
                entity.RunningNumber = int.Parse(seriesResult.Result["RunningNumber"]);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<InspectionMethodDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<InspectionMethodDto>.Fail(saveResult.Errors);

                return ReturnBase<InspectionMethodDto>.Success(_mapper.Map<InspectionMethodDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<InspectionMethodDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<InspectionMethodDto>> Update(InspectionMethodUpdateDto dto)
        {
            try
            {
                var entity = await _queriesManager.InspectionMethod.GetById(dto.Id);

                if (entity == null)
                    return ReturnBase<InspectionMethodDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404", ErrorMessage = $"Inspection Method with Id {dto.Id} was not found" }
            });

                _mapper.Map(dto, entity);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<InspectionMethodDto>.Fail(saveResult.Errors);

                return ReturnBase<InspectionMethodDto>.Success(_mapper.Map<InspectionMethodDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<InspectionMethodDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<InspectionMethodDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.InspectionMethod.GetById(id);
                if (entity == null)
                    return ReturnBase<InspectionMethodDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = $"Inspection Method with Id {id} was not found" }
                    });


                var updateResult = await _commands.DeleteAsync(id);
                if (!updateResult.Succeeded) return ReturnBase<InspectionMethodDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded) return ReturnBase<InspectionMethodDto>.Fail(saveResult.Errors);

                return ReturnBase<InspectionMethodDto>.Success(_mapper.Map<InspectionMethodDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<InspectionMethodDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<InspectionMethodDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.InspectionMethod.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = $" Inspection Method with Id '{id}' was not found."
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<InspectionMethodDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<InspectionMethodDto>(entity);

                return ReturnBase<InspectionMethodDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<InspectionMethodDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<InspectionMethodReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult =
                    await _queriesManager.InspectionMethod.Search(sqlQueryOptions);

                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<InspectionMethodReturnSearchDto>>
                        .Fail(getResult.Errors);

                return ReturnBase<IEnumerable<InspectionMethodReturnSearchDto>>
                    .Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InspectionMethodReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }
    }
}