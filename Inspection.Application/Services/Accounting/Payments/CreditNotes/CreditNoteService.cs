using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CreditNoteDTOs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.Payments.CreditNotes;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Payments.CreditNotes;
using Inspection.Application.Contracts.Services.Accounting.Payments.CreditNotes;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Accounting.Payment.CreditNotes;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.Payments.CreditNotes
{
    internal class CreditNoteService : AccountsServiceBase, ICreditNoteService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly ISeriesService _seriesService;


        public CreditNoteService(
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
        private ICreditNoteCommandRepository _commands => _accountUoW.CreditNote;
        private ICreditNoteQueryRepository _queries => _queriesManager.CreditNote;

        public async Task<ReturnBase<CreditNoteDto>> Create(CreditNoteCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<CreditNote>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // Series
                const string SCREEN_CODE = "Credit Note";

                var series = await _queriesManager.Series.GetByScreen_IDAsync(SCREEN_CODE);

                if (series == null || !series.IsActive)
                    return ReturnBase<CreditNoteDto>.Fail(
                        new Exception($"No active series configured for screen '{SCREEN_CODE}'"),
                        _exceptionManager);

                entity.SeriesId = series.Id;

                var seriesResult = await _seriesService
                    .GetSeriesCodeWithCustomDateUsingSeriesDetails(series.Id, entity.CreditNoteDate);

                if (!seriesResult.Succeeded || seriesResult.Result == null)
                    return ReturnBase<CreditNoteDto>.Fail(seriesResult.Errors);

                entity.CreditNoteNumber = seriesResult.Result["FinelSeriesCodeAndSeriesNumber"];
                entity.RunningNumber = int.Parse(seriesResult.Result["RunningNumber"]);

                CreateCreditNoteLines(entity, dto);
                CreateCreditNoteAdjustments(entity, dto);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<CreditNoteDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<CreditNoteDto>.Fail(saveResult.Errors);

                return ReturnBase<CreditNoteDto>.Success(_mapper.Map<CreditNoteDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<CreditNoteDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<CreditNoteDto>> Update(CreditNoteUpdateDto dto)
        {
            try
            {
                var entity = await _queriesManager.CreditNote.GetById(dto.Id);

                if (entity == null)
                    return ReturnBase<CreditNoteDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404", ErrorMessage = $"Credit Note with Id {dto.Id} was not found" }
            });

                _mapper.Map(dto, entity);

                await UpdateCreditNoteLines(entity, dto);
                await UpdateCreditNoteAdjustments(entity, dto);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<CreditNoteDto>.Fail(saveResult.Errors);

                return ReturnBase<CreditNoteDto>.Success(_mapper.Map<CreditNoteDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<CreditNoteDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<CreditNoteDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.CreditNote.GetById(id);
                if (entity == null)
                    return ReturnBase<CreditNoteDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = $"Credit Note with Id {id} was not found" }
                    });


                var updateResult = await _commands.DeleteAsync(id);
                if (!updateResult.Succeeded) return ReturnBase<CreditNoteDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded) return ReturnBase<CreditNoteDto>.Fail(saveResult.Errors);

                return ReturnBase<CreditNoteDto>.Success(_mapper.Map<CreditNoteDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<CreditNoteDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<CreditNoteDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.CreditNote.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = $" Credit Note with Id '{id}' was not found."
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<CreditNoteDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<CreditNoteDto>(entity);

                return ReturnBase<CreditNoteDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<CreditNoteDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<CreditNoteReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult =
                    await _queriesManager.CreditNote.Search(sqlQueryOptions);

                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<CreditNoteReturnSearchDto>>
                        .Fail(getResult.Errors);

                return ReturnBase<IEnumerable<CreditNoteReturnSearchDto>>
                    .Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CreditNoteReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }


        // Create && Update  Any Detail For Credit Note (Lines, Adjustments, Allocations) should be handled in these methods to make sure that all operations will be in the same transaction scope

        // CreditNoteLines
        private void CreateCreditNoteLines(CreditNote entity, CreditNoteCreateDto dto)
        {
            if (dto.CreditNoteLines == null || !dto.CreditNoteLines.Any())
            {
                entity.CreditNoteLines = new List<CreditNoteLine>();
                return;
            }

            entity.CreditNoteLines = _mapper.Map<List<CreditNoteLine>>(dto.CreditNoteLines);

            foreach (var line in entity.CreditNoteLines)
            {
                line.CreditNote = entity;
            }
        }

        private async Task UpdateCreditNoteLines(CreditNote entity, CreditNoteUpdateDto dto)
        {
            var existing = entity.CreditNoteLines.ToList();

            if (dto.CreditNoteLines == null || !dto.CreditNoteLines.Any())
            {
                var allIds = existing.Select(x => x.Id).ToList();

                if (allIds.Any())
                    await _commands.DeleteCreditNoteLinesByCreditNoteIds(allIds);
                return;
            }

            var dtoIds = dto.CreditNoteLines
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            foreach (var lineDto in dto.CreditNoteLines)
            {
                if (lineDto.Id == 0)
                {
                    var newEntity = _mapper.Map<CreditNoteLine>(lineDto);
                    newEntity.CreditNoteId = entity.Id;
                    entity.CreditNoteLines.Add(newEntity);
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
                await _commands.DeleteCreditNoteLinesByCreditNoteIds(removed);
        }

        // CreditNoteAdjustments
        private void CreateCreditNoteAdjustments(CreditNote entity, CreditNoteCreateDto dto)
        {
            if (dto.CreditNoteAdjustments == null || !dto.CreditNoteAdjustments.Any())
            {
                entity.CreditNoteAdjustments = new List<CreditNoteAdjustment>();
                return;
            }

            entity.CreditNoteAdjustments = _mapper.Map<List<CreditNoteAdjustment>>(dto.CreditNoteAdjustments);

            foreach (var adj in entity.CreditNoteAdjustments)
            {
                adj.CreditNote = entity;
            }
        }

        private async Task UpdateCreditNoteAdjustments(CreditNote entity, CreditNoteUpdateDto dto)
        {
            var existing = entity.CreditNoteAdjustments.ToList();

            if (dto.CreditNoteAdjustments == null || !dto.CreditNoteAdjustments.Any())
            {
                var allIds = existing.Select(x => x.Id).ToList();

                if (allIds.Any())
                    await _commands.DeleteCreditNoteAdjustmentsByCreditNoteIds(allIds);
                return;
            }

            var dtoIds = dto.CreditNoteAdjustments
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            foreach (var adjDto in dto.CreditNoteAdjustments)
            {
                if (adjDto.Id == 0)
                {
                    var newEntity = _mapper.Map<CreditNoteAdjustment>(adjDto);
                    newEntity.CreditNoteId = entity.Id;
                    entity.CreditNoteAdjustments.Add(newEntity);
                }
                else
                {
                    var existingEntity = existing.FirstOrDefault(x => x.Id == adjDto.Id);

                    if (existingEntity != null)
                        _mapper.Map(adjDto, existingEntity);
                }
            }

            var removed = existing
                .Where(x => !dtoIds.Contains(x.Id))
                .Select(x => x.Id)
                .ToList();

            if (removed.Any())
                await _commands.DeleteCreditNoteAdjustmentsByCreditNoteIds(removed);
        }
    }
}