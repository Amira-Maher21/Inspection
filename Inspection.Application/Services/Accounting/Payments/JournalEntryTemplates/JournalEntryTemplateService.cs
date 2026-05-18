using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.JournalEntryTemplates;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.Payments;
using Inspection.Application.Contracts.Services.Accounting.Payments;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Accounting.Payment.JournalEntryTemplates;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
namespace Inspection.Application.Services.Accounting.Payments.JournalEntryTemplates
{
    public class JournalEntryTemplateService : AccountsServiceBase, IJournalEntryTemplateService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly ISeriesService _seriesService;

        public JournalEntryTemplateService(IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager, IMapper mapper,
            ITenantResolver tenantResolver, IExceptionManager exceptionManager,
            IExcelTemplateGenerator templateGenerator,
            ISeriesService seriesService) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            this._tenantResolver = tenantResolver;
            this._templateGenerator = templateGenerator;
            this._seriesService = seriesService;

        }

        public async Task<ReturnBase<JournalEntryTemplateDto>> Create(JournalEntryTemplateCreateDto createDto)
        {
            try
            {
                const string SCREEN_CODE = "Journal EntryTemplate";

                var series = await _queriesManager.Series
                    .GetByScreen_IDAsync(SCREEN_CODE);

                if (series == null || !series.IsActive)
                {
                    return ReturnBase<JournalEntryTemplateDto>.Fail(
                        new Exception($"No active series for '{SCREEN_CODE}'"),
                        _exceptionManager);
                }

                var seriesResult =
                    await this._seriesService
                        .GetSeriesCodeWithCustomDateUsingSeriesDetails(
                            series.Id,
                            DateTime.UtcNow);

                if (!seriesResult.Succeeded || seriesResult.Result == null)
                    return ReturnBase<JournalEntryTemplateDto>.Fail(seriesResult.Errors);
                var entity = _mapper.Map<JournalEntryTemplate>(createDto);

                entity.Tenant_ID = _tenantResolver.GetTenantName();
                entity.SeriesId = series.Id;
                entity.JournalEntryTemplateNumber =
                    seriesResult.Result["FinelSeriesCodeAndSeriesNumber"];
                entity.RunningNumber =
                    int.Parse(seriesResult.Result["RunningNumber"]);
                if (createDto.JournalEntryTemplateLines != null && createDto.JournalEntryTemplateLines.Any())
                {
                    entity.JournalEntryTemplateLines = _mapper.Map<List<JournalEntryTemplateLine>>(createDto.JournalEntryTemplateLines);

                    foreach (var varient in entity.JournalEntryTemplateLines)
                    {
                        varient.JournalEntryTemplate = entity;
                    }
                }
                else
                {
                    entity.JournalEntryTemplateLines = new List<JournalEntryTemplateLine>();
                }

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<JournalEntryTemplateDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (saveResult == null)
                    return ReturnBase<JournalEntryTemplateDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "500", ErrorMessage = "SaveAsync returned null" }
            });

                if (!saveResult.Succeeded)
                    return ReturnBase<JournalEntryTemplateDto>.Fail(
                        saveResult.Errors?.ToList() ??
                        new List<ReturnBaseError>
                        {
                    new() { ErrorCode = "500", ErrorMessage = "Save failed" }
                        });

                return ReturnBase<JournalEntryTemplateDto>.Success(_mapper.Map<JournalEntryTemplateDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<JournalEntryTemplateDto>.Fail(ex, _exceptionManager);
            }
        }


        #region Update

        public async Task<ReturnBase<JournalEntryTemplateDto>> Update(JournalEntryTemplateUpdateDto dto)
        {
            try
            {
                var entity = await _queriesManager.JournalEntryTemplate.GetById(dto.Id);
                if (entity == null)
                    return ReturnBase<JournalEntryTemplateDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = "Journal Entry Template Not Found" }
                    });



                if (dto.JournalEntryTemplateLines == null || !dto.JournalEntryTemplateLines.Any())
                    return ReturnBase<JournalEntryTemplateDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "400", ErrorMessage = "Journal Entry Template must contain at least one line." }
                    });


                _mapper.Map(dto, entity);



                entity.JournalEntryTemplateLines.Clear();
                entity.JournalEntryTemplateLines = _mapper.Map<List<JournalEntryTemplateLine>>(dto.JournalEntryTemplateLines);

                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)
                    return ReturnBase<JournalEntryTemplateDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<JournalEntryTemplateDto>.Fail(saveResult.Errors);

                return ReturnBase<JournalEntryTemplateDto>.Success(_mapper.Map<JournalEntryTemplateDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<JournalEntryTemplateDto>.Fail(ex, _exceptionManager);
            }
        }

        #endregion

        #region Delete

        public async Task<ReturnBase<JournalEntryTemplateDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.JournalEntryTemplate.GetById(id);
                if (entity == null)

                    return ReturnBase<JournalEntryTemplateDto>.Fail(
                        new List<ReturnBaseError>
                        {
                        new ReturnBaseError
                        {
                            ErrorCode = "400",
                            ErrorMessage = "Journal Entry Not Found"
                        }
                        }); ;
                var deleteResult = await _commands.DeleteById(id);
                if (!deleteResult.Succeeded)
                    return ReturnBase<JournalEntryTemplateDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<JournalEntryTemplateDto>.Fail(saveResult.Errors);

                return ReturnBase<JournalEntryTemplateDto>.Success(_mapper.Map<JournalEntryTemplateDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<JournalEntryTemplateDto>.Fail(ex, _exceptionManager);
            }
        }

        #endregion


        public async Task<ReturnBase<IEnumerable<JournalEntryTemplateSearchReturnDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.JournalEntryTemplate.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<JournalEntryTemplateSearchReturnDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<JournalEntryTemplateSearchReturnDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<JournalEntryTemplateSearchReturnDto>>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<JournalEntryTemplateDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.JournalEntryTemplate.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "JournalEntryTemplate Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<JournalEntryTemplateDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<JournalEntryTemplateDto>(entity);

                return ReturnBase<JournalEntryTemplateDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<JournalEntryTemplateDto>.Fail(ex, _exceptionManager);
            }
        }

        private IJournalEntryTemplateCommandRepository _commands
        {
            get { return _accountUoW.JournalEntryTemplate; }
        }
    }

}


