using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.ModeOfPayments;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup.ModeOfPayments;
using Inspection.Application.Contracts.Services.Accounting.AccountSetup.ModeOfPayments;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Accounting.AccountingSetup.ModeOfPayments;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.AccountSetup.ModeOfPayments
{
    public class ModeOfPaymentService : AccountsServiceBase, IModeOfPaymentService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly ISeriesService _seriesService;

        public ModeOfPaymentService(
            IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper,
            IExceptionManager exceptionManager,
            ITenantResolver tenantResolver,
            IExcelTemplateGenerator templateGenerator,
            ISeriesService seriesService)
            : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
            _seriesService = seriesService;
        }

        public async Task<ReturnBase<ModeOfPaymentDto>> Create(ModeOfPaymentCreateDto createDto)
        {
            try
            {
                var entity = _mapper.Map<ModeOfPayment>(createDto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                const string SCREEN_CODE = "Mode Of Payment";

                var series = await _queriesManager.Series.GetByScreen_IDAsync(SCREEN_CODE);
                if (series == null || !series.IsActive)
                {
                    return ReturnBase<ModeOfPaymentDto>.Fail(
                        new Exception($"No active series configured for screen '{SCREEN_CODE}'"),
                        _exceptionManager);
                }

                //entity.SeriesId = series.Id;

                //var seriesResult =
                //    await _seriesService.GetSeriesCodeWithCustomDateUsingSeriesDetails(
                //        series.Id,
                //        DateTime.Now
                //    );

                //if (!seriesResult.Succeeded || seriesResult.Result == null)
                //    return ReturnBase<ModeOfPaymentDto>.Fail(seriesResult.Errors);

                //entity.Code = seriesResult.Result["FinelSeriesCodeAndSeriesNumber"];
                //entity.RunningNumber = int.Parse(seriesResult.Result["RunningNumber"]);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<ModeOfPaymentDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<ModeOfPaymentDto>.Fail(saveResult.Errors);

                return ReturnBase<ModeOfPaymentDto>
                    .Success(_mapper.Map<ModeOfPaymentDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ModeOfPaymentDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<ModeOfPaymentDto>> Update(ModeOfPaymentUpdateDto updateDto)
        {
            try
            {
                var entity = await _queriesManager.ModeOfPayment.GetById(updateDto.Id);
                if (entity == null)
                {
                    return ReturnBase<ModeOfPaymentDto>.Fail(new List<ReturnBaseError>
                    {
                        new()
                        {
                            ErrorCode = "404",
                            ErrorMessage = "Mode Of Payment Not Found"
                        }
                    });
                }

                _mapper.Map(updateDto, entity);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)
                    return ReturnBase<ModeOfPaymentDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<ModeOfPaymentDto>.Fail(saveResult.Errors);

                return ReturnBase<ModeOfPaymentDto>
                    .Success(_mapper.Map<ModeOfPaymentDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ModeOfPaymentDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<ModeOfPaymentDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.ModeOfPayment.GetById(id);
                if (entity == null)
                {
                    return ReturnBase<ModeOfPaymentDto>.Fail(new List<ReturnBaseError>
                    {
                        new()
                        {
                            ErrorCode = "404",
                            ErrorMessage = "ModeOfPayment Not Found"
                        }
                    });
                }

                var deleteResult = await _commands.DeleteById(id);
                if (!deleteResult.Succeeded)
                    return ReturnBase<ModeOfPaymentDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<ModeOfPaymentDto>.Fail(saveResult.Errors);

                return ReturnBase<ModeOfPaymentDto>
                    .Success(_mapper.Map<ModeOfPaymentDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ModeOfPaymentDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<ModeOfPaymentSearchReturnDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.ModeOfPayment.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<ModeOfPaymentSearchReturnDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<ModeOfPaymentSearchReturnDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ModeOfPaymentSearchReturnDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<ModeOfPaymentDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.ModeOfPayment.GetById(id);
                if (entity == null)
                {
                    return ReturnBase<ModeOfPaymentDto>.Fail(new List<ReturnBaseError>
                    {
                        new()
                        {
                            ErrorCode = "404",
                            ErrorMessage = "ModeOfPayment Not Found"
                        }
                    });
                }

                return ReturnBase<ModeOfPaymentDto>
                    .Success(_mapper.Map<ModeOfPaymentDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ModeOfPaymentDto>.Fail(ex, _exceptionManager);
            }
        }

        private IModeOfPaymentCommandRepository _commands
            => _accountUoW.ModeOfPayment;
    }
}