using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.DebitNoteDTOs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.Payments.DebitNotes;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Payments.DebitNotes;
using Inspection.Application.Contracts.Services.Accounting.Payments.DebitNotes;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Accounting.Payment.DebitNotes;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.Payments.DebitNotes
{
    internal class DebitNoteService : AccountsServiceBase, IDebitNoteService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly ISeriesService _seriesService;


        public DebitNoteService(
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
        private IDebitNoteCommandRepository _commands => _accountUoW.DebitNote;
        private IDebitNoteQueryRepository _queries => _queriesManager.DebitNote;

        public async Task<ReturnBase<DebitNoteDto>> Create(DebitNoteCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<DebitNote>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // Series
                const string SCREEN_CODE = "Debit Note";

                var series = await _queriesManager.Series.GetByScreen_IDAsync(SCREEN_CODE);

                if (series == null || !series.IsActive)
                    return ReturnBase<DebitNoteDto>.Fail(
                        new Exception($"No active series configured for screen '{SCREEN_CODE}'"),
                        _exceptionManager);

                entity.SeriesId = series.Id;

                var seriesResult = await _seriesService
                    .GetSeriesCodeWithCustomDateUsingSeriesDetails(series.Id, entity.DebitNoteDate);

                if (!seriesResult.Succeeded || seriesResult.Result == null)
                    return ReturnBase<DebitNoteDto>.Fail(seriesResult.Errors);

                entity.DebitNoteNumber = seriesResult.Result["FinelSeriesCodeAndSeriesNumber"];
                entity.RunningNumber = int.Parse(seriesResult.Result["RunningNumber"]);

                CreateDebitNoteLines(entity, dto);
                CreateDebitNoteAdjustments(entity, dto);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<DebitNoteDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<DebitNoteDto>.Fail(saveResult.Errors);

                return ReturnBase<DebitNoteDto>.Success(_mapper.Map<DebitNoteDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<DebitNoteDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<DebitNoteDto>> Update(DebitNoteUpdateDto dto)
        {
            try
            {
                var entity = await _queriesManager.DebitNote.GetById(dto.Id);

                if (entity == null)
                    return ReturnBase<DebitNoteDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404", ErrorMessage = $"Debit Note with Id {dto.Id} was not found" }
            });

                _mapper.Map(dto, entity);

                await UpdateDebitNoteLines(entity, dto);
                await UpdateDebitNoteAdjustments(entity, dto);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<DebitNoteDto>.Fail(saveResult.Errors);

                return ReturnBase<DebitNoteDto>.Success(_mapper.Map<DebitNoteDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<DebitNoteDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<DebitNoteDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.DebitNote.GetById(id);
                if (entity == null)
                    return ReturnBase<DebitNoteDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = $"Debit Note with Id {id} was not found" }
                    });


                var updateResult = await _commands.DeleteAsync(id);
                if (!updateResult.Succeeded) return ReturnBase<DebitNoteDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded) return ReturnBase<DebitNoteDto>.Fail(saveResult.Errors);

                return ReturnBase<DebitNoteDto>.Success(_mapper.Map<DebitNoteDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<DebitNoteDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<DebitNoteDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.DebitNote.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = $" Debit Note with Id '{id}' was not found."
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<DebitNoteDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<DebitNoteDto>(entity);

                return ReturnBase<DebitNoteDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<DebitNoteDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<DebitNoteReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult =
                    await _queriesManager.DebitNote.Search(sqlQueryOptions);

                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<DebitNoteReturnSearchDto>>
                        .Fail(getResult.Errors);

                return ReturnBase<IEnumerable<DebitNoteReturnSearchDto>>
                    .Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<DebitNoteReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }


        // Create && Update  Any Detail For Debit Note (Lines, Adjustments) should be handled in these methods to make sure that all operations will be in the same transaction scope

        // DebitNoteLines
        private void CreateDebitNoteLines(DebitNote entity, DebitNoteCreateDto dto)
        {
            if (dto.DebitNoteLines == null || !dto.DebitNoteLines.Any())
            {
                entity.DebitNoteLines = new List<DebitNoteLine>();
                return;
            }

            entity.DebitNoteLines = _mapper.Map<List<DebitNoteLine>>(dto.DebitNoteLines);

            foreach (var line in entity.DebitNoteLines)
            {
                line.DebitNote = entity;
            }
        }

        private async Task UpdateDebitNoteLines(DebitNote entity, DebitNoteUpdateDto dto)
        {
            var existing = entity.DebitNoteLines.ToList();

            if (dto.DebitNoteLines == null || !dto.DebitNoteLines.Any())
            {
                var allIds = existing.Select(x => x.Id).ToList();

                if (allIds.Any())
                    await _commands.DeleteDebitNoteLinesByDebitNoteIds(allIds);
                return;
            }

            var dtoIds = dto.DebitNoteLines
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            foreach (var lineDto in dto.DebitNoteLines)
            {
                if (lineDto.Id == 0)
                {
                    var newEntity = _mapper.Map<DebitNoteLine>(lineDto);
                    newEntity.DebitNoteId = entity.Id;
                    entity.DebitNoteLines.Add(newEntity);
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
                await _commands.DeleteDebitNoteLinesByDebitNoteIds(removed);
        }

        // DebitNoteAdjustments
        private void CreateDebitNoteAdjustments(DebitNote entity, DebitNoteCreateDto dto)
        {
            if (dto.DebitNoteAdjustments == null || !dto.DebitNoteAdjustments.Any())
            {
                entity.DebitNoteAdjustments = new List<DebitNoteAdjustment>();
                return;
            }

            entity.DebitNoteAdjustments = _mapper.Map<List<DebitNoteAdjustment>>(dto.DebitNoteAdjustments);
            foreach (var adj in entity.DebitNoteAdjustments)
            {
                adj.DebitNote = entity;
            }
        }

        private async Task UpdateDebitNoteAdjustments(DebitNote entity, DebitNoteUpdateDto dto)
        {
            var existing = entity.DebitNoteAdjustments.ToList();

            if (dto.DebitNoteAdjustments == null || !dto.DebitNoteAdjustments.Any())
            {
                var allIds = existing.Select(x => x.Id).ToList();

                if (allIds.Any())
                    await _commands.DeleteDebitNoteAdjustmentsByDebitNoteIds(allIds);
                return;
            }

            var dtoIds = dto.DebitNoteAdjustments
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            foreach (var adjDto in dto.DebitNoteAdjustments)
            {
                if (adjDto.Id == 0)
                {
                    var newEntity = _mapper.Map<DebitNoteAdjustment>(adjDto);
                    newEntity.DebitNoteId = entity.Id;
                    entity.DebitNoteAdjustments.Add(newEntity);
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
                await _commands.DeleteDebitNoteAdjustmentsByDebitNoteIds(removed);
        }
    }
}