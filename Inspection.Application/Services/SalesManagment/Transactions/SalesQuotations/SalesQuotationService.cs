using AutoMapper;
using Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.SalesQuotationDTOs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionRequests;
using Inspection.Application.Contracts.Repositories.Command.SalesManagment.Transactions.SalesQuotations;
using Inspection.Application.Contracts.Repositories.Query.SalesManagment.Transactions.SalesQuotations;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.Services.SalesManagment.Transactions.SalesQuotations;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Enums;
using Inspection.Domain.Models.SalesManagment.Transaction.DTOs;
using Inspection.Domain.Models.SalesManagment.Transaction.SalesQuotations;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.SalesManagment.Transactions.SalesQuotations
{
    internal class SalesQuotationService : AccountsServiceBase, ISalesQuotationService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly ISeriesService _seriesService;


        public SalesQuotationService(
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
        private ISalesQuotationCommandRepository _commands => _accountUoW.SalesQuotation;
        private ISalesQuotationQueryRepository _queries => _queriesManager.SalesQuotation;
        private IInspectionRequestCommandRepository _inspectionRequestCommands => _accountUoW.InspectionRequest;

        public async Task<ReturnBase<SalesQuotationDto>> Create(SalesQuotationCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<SalesQuotation>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // Series
                const string SCREEN_CODE = "Sales Quotation";

                var series = await _queriesManager.Series.GetByScreen_IDAsync(SCREEN_CODE);

                if (series == null || !series.IsActive)
                    return ReturnBase<SalesQuotationDto>.Fail(
                        new Exception($"No active series configured for screen '{SCREEN_CODE}'"),
                        _exceptionManager);

                entity.SeriesId = series.Id;

                var seriesResult = await _seriesService
                    .GetSeriesCodeWithCustomDateUsingSeriesDetails(series.Id, DateTime.Now);

                if (!seriesResult.Succeeded || seriesResult.Result == null)
                    return ReturnBase<SalesQuotationDto>.Fail(seriesResult.Errors);

                entity.QuotationNumber = seriesResult.Result["FinelSeriesCodeAndSeriesNumber"];
                entity.RunningNumber = int.Parse(seriesResult.Result["RunningNumber"]);

                CreateSalesQuotationLines(entity, dto);


                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<SalesQuotationDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<SalesQuotationDto>.Fail(saveResult.Errors);

                return ReturnBase<SalesQuotationDto>.Success(_mapper.Map<SalesQuotationDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<SalesQuotationDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<SalesQuotationDto>> Update(SalesQuotationUpdateDto dto)
        {
            try
            {
                var entity = await _queriesManager.SalesQuotation.GetById(dto.Id);

                if (entity == null)
                    return ReturnBase<SalesQuotationDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404", ErrorMessage = $"Sales Quotation with Id {dto.Id} was not found" }
            });

                _mapper.Map(dto, entity);

                await UpdateSalesQuotationLines(entity, dto);


                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<SalesQuotationDto>.Fail(saveResult.Errors);

                return ReturnBase<SalesQuotationDto>.Success(_mapper.Map<SalesQuotationDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<SalesQuotationDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<SalesQuotationDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.SalesQuotation.GetById(id);
                if (entity == null)
                    return ReturnBase<SalesQuotationDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = $"Sales Quotation with Id {id} was not found" }
                    });


                var updateResult = await _commands.DeleteAsync(id);
                if (!updateResult.Succeeded) return ReturnBase<SalesQuotationDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded) return ReturnBase<SalesQuotationDto>.Fail(saveResult.Errors);

                return ReturnBase<SalesQuotationDto>.Success(_mapper.Map<SalesQuotationDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<SalesQuotationDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<SalesQuotationDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.SalesQuotation.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = $" Sales Quotation with Id '{id}' was not found."
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<SalesQuotationDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<SalesQuotationDto>(entity);

                return ReturnBase<SalesQuotationDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<SalesQuotationDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<SalesQuotationReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult =
                    await _queriesManager.SalesQuotation.Search(sqlQueryOptions);

                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<SalesQuotationReturnSearchDto>>
                        .Fail(getResult.Errors);

                return ReturnBase<IEnumerable<SalesQuotationReturnSearchDto>>
                    .Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<SalesQuotationReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }

        // Document Change Status
        public async Task<ReturnBase<bool>> ChangeDocumentStatusAsync(ChangeSalesQuotationDocumentStatusDto newStatus)
        {
            try
            {
                var quotation = await _queriesManager.SalesQuotation.GetById(newStatus.RequestId);
                if (quotation == null)
                    return ReturnBase<bool>.Fail();

                var oldStatus = quotation.DocumentStatus;
                quotation.DocumentStatus = newStatus.DocumentStatus;

                if (!string.IsNullOrWhiteSpace(newStatus.CancelledDescription))
                {
                    quotation.DocumentStatusCancelled = newStatus.CancelledDescription;
                }

                if (quotation.InspectionRequestId.HasValue)
                {
                    var inspectionRequest =
                        await _queriesManager.InspectionRequest
                            .GetByIdAsync(quotation.InspectionRequestId.Value);

                    if (inspectionRequest != null)
                    {
                        // Draft → Sent
                        if (oldStatus == SalesQuotationDocumentStatus.Draft &&
                            newStatus.DocumentStatus == SalesQuotationDocumentStatus.Sent)
                        {
                            inspectionRequest.DocumentStatus =
                                InspectionDocumentStatus.QuotationIssued;
                        }

                        // Sent → Draft
                        else if (oldStatus == SalesQuotationDocumentStatus.Sent &&
                                 newStatus.DocumentStatus == SalesQuotationDocumentStatus.Draft)
                        {
                            inspectionRequest.DocumentStatus =
                                InspectionDocumentStatus.Submitted;
                        }

                        var updateInspectionResult =
                            await _inspectionRequestCommands.UpdateAsync(inspectionRequest);

                        if (!updateInspectionResult.Succeeded)
                            return ReturnBase<bool>.Fail(updateInspectionResult.Errors);
                    }
                }

                var updateResult = await _commands.UpdateAsync(quotation);
                if (!updateResult.Succeeded)
                    return ReturnBase<bool>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<bool>.Fail(saveResult.Errors);

                return ReturnBase<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return ReturnBase<bool>.Fail(ex, _exceptionManager);
            }
        }



        // Create && Update  Any Detail For Sales Quotation (Lines) should be handled in these methods to make sure that all operations will be in the same transaction scope

        // SalesQuotationLines
        private void CreateSalesQuotationLines(SalesQuotation entity, SalesQuotationCreateDto dto)
        {
            if (dto.SalesQuotationLines == null || !dto.SalesQuotationLines.Any())
            {
                entity.SalesQuotationLines = new List<SalesQuotationLine>();
                return;
            }

            entity.SalesQuotationLines = _mapper.Map<List<SalesQuotationLine>>(dto.SalesQuotationLines);

            foreach (var line in entity.SalesQuotationLines)
            {
                line.SalesQuotation = entity;
            }
        }

        private async Task UpdateSalesQuotationLines(SalesQuotation entity, SalesQuotationUpdateDto dto)
        {
            var existing = entity.SalesQuotationLines.ToList();

            if (dto.SalesQuotationLines == null || !dto.SalesQuotationLines.Any())
            {
                var allIds = existing.Select(x => x.Id).ToList();

                if (allIds.Any())
                    await _commands.DeleteSalesQuotationLinesByIds(allIds);
                return;
            }

            var dtoIds = dto.SalesQuotationLines
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            foreach (var lineDto in dto.SalesQuotationLines)
            {
                if (lineDto.Id == 0)
                {
                    var newEntity = _mapper.Map<SalesQuotationLine>(lineDto);
                    newEntity.SalesQuotationId = entity.Id;
                    entity.SalesQuotationLines.Add(newEntity);
                }
                else
                {
                    var existingEntity = existing.FirstOrDefault(x => x.Id == lineDto.Id);

                    if (existingEntity != null)
                        _mapper.Map(lineDto, existingEntity);
                }
            }

            var removed = existing
                .Where(x => !dtoIds.Contains(x.Id))
                .Select(x => x.Id)
                .ToList();

            if (removed.Any())
                await _commands.DeleteSalesQuotationLinesByIds(removed);
        }

    }
}