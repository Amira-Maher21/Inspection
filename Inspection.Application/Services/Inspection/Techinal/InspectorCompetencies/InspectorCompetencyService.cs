using AutoMapper;
using ClosedXML.Excel;
using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectorCompetencyDTOs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Inspection.Techinal.InspectorCompetencies;
using Inspection.Application.Contracts.Repositories.Query.Inspection.Techinal.InspectorCompetencies;
using Inspection.Application.Contracts.Services.Inspection.Techinal.InspectorCompetencies;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Inspection.Techinal.InspectorCompetencies;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Inspection.Techinal.InspectorCompetencies
{
    internal class InspectorCompetencyService : AccountsServiceBase, IInspectorCompetencyService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public InspectorCompetencyService(
            IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper,
            IExceptionManager exceptionManager,
            ITenantResolver tenantResolver,
            IExcelTemplateGenerator templateGenerator) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }

        private IInspectorCompetencyCommandRepository _commands => _accountUoW.InspectorCompetency;
        private IInspectorCompetencyQueryRepository _queries => _queriesManager.InspectorCompetency;


        public async Task<ReturnBase<InspectorCompetencyDto>> Create(InspectorCompetencyCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<InspectorCompetency>(dto);

                entity.Tenant_ID = _tenantResolver.GetTenantName();


                // =====  CompetencyLines =====

                if (dto.InspectorCompetencyLines != null && dto.InspectorCompetencyLines.Any())
                {
                    entity.InspectorCompetencyLines = _mapper.Map<List<InspectorCompetencyLine>>(dto.InspectorCompetencyLines);

                    foreach (var line in entity.InspectorCompetencyLines)
                    {
                        line.InspectorCompetency = entity;
                    }
                }
                else
                {
                    entity.InspectorCompetencyLines = new List<InspectorCompetencyLine>();
                }




                // ===== Accreditation =====
                if (dto.InspectorAccreditation != null && dto.InspectorAccreditation.Any())
                {
                    entity.InspectorAccreditation =
                        _mapper.Map<List<InspectorAccreditation>>(dto.InspectorAccreditation);

                    foreach (var acc in entity.InspectorAccreditation)
                    {
                        acc.InspectorCompetency = entity;
                    }
                }
                else
                {
                    entity.InspectorAccreditation = new List<InspectorAccreditation>();
                }

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<InspectorCompetencyDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (saveResult == null)
                    return ReturnBase<InspectorCompetencyDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "500", ErrorMessage = "SaveAsync returned null" }
            });

                if (!saveResult.Succeeded)
                    return ReturnBase<InspectorCompetencyDto>.Fail(
                        saveResult.Errors?.ToList() ??
                        new List<ReturnBaseError>
                        {
                    new() { ErrorCode = "500", ErrorMessage = "Save failed" }
                        });

                return ReturnBase<InspectorCompetencyDto>.Success(_mapper.Map<InspectorCompetencyDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<InspectorCompetencyDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<InspectorCompetencyDto>> Update(InspectorCompetencyUpdateDto dto)
        {
            try
            {
                var entity = await _queriesManager.InspectorCompetency.GetById(dto.Id);
                if (entity == null)
                {
                    return ReturnBase<InspectorCompetencyDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = "Inspector Competency Not Found" }
                    });
                }

                // Update Inspector Competency main fields
                _mapper.Map(dto, entity);

                var existingLines = entity.InspectorCompetencyLines.ToList();

                // Case 1: User sent NO variants → HARD DELETE ALL
                if (dto.InspectorCompetencyLines == null || !dto.InspectorCompetencyLines.Any())
                {
                    await _commands.DeleteLinesByInspectorCompetencyId(entity.Id);
                }
                else
                {
                    var dtoLineIds = dto.InspectorCompetencyLines
                        .Where(v => v.Id > 0)
                        .Select(v => v.Id)
                        .ToHashSet();

                    // CREATE & UPDATE
                    foreach (var lineDto in dto.InspectorCompetencyLines)
                    {
                        // CREATE
                        if (lineDto.Id == 0)
                        {
                            var newLine = _mapper.Map<InspectorCompetencyLine>(lineDto);
                            newLine.InspectorCompetencyId = entity.Id;
                            entity.InspectorCompetencyLines.Add(newLine);
                        }
                        else
                        {
                            // UPDATE
                            var existingVariant =
                                existingLines.FirstOrDefault(v => v.Id == lineDto.Id);

                            if (existingVariant != null)
                            {
                                _mapper.Map(lineDto, existingVariant);
                            }
                        }
                    }

                    // HARD DELETE removed lines
                    var removedLines = existingLines
                        .Where(v => !dtoLineIds.Contains(v.Id))
                        .Select(v => v.Id)
                        .ToList();

                    if (removedLines.Any())
                    {
                        await _commands.DeleteLinesByIds(removedLines);
                    }
                }

                // ===== Accreditation =====

                var existingAccreditations = entity.InspectorAccreditation.ToList();

                if (dto.InspectorAccreditation == null || !dto.InspectorAccreditation.Any())
                {
                    await _commands.DeleteAccreditationsByInspectorCompetencyId(entity.Id);
                }
                else
                {
                    var dtoAccIds = dto.InspectorAccreditation
                        .Where(a => a.Id > 0)
                        .Select(a => a.Id)
                        .ToHashSet();

                    foreach (var accDto in dto.InspectorAccreditation)
                    {
                        // CREATE
                        if (accDto.Id == 0)
                        {
                            var newAcc = _mapper.Map<InspectorAccreditation>(accDto);
                            newAcc.InspectorCompetencyId = entity.Id;
                            entity.InspectorAccreditation.Add(newAcc);
                        }
                        else
                        {
                            // UPDATE
                            var existingAcc =
                                existingAccreditations.FirstOrDefault(a => a.Id == accDto.Id);

                            if (existingAcc != null)
                            {
                                _mapper.Map(accDto, existingAcc);
                            }
                        }
                    }

                    // HARD DELETE removed accreditations
                    var removedAccreditations = existingAccreditations
                        .Where(a => !dtoAccIds.Contains(a.Id))
                        .Select(a => a.Id)
                        .ToList();

                    if (removedAccreditations.Any())
                    {
                        await _commands.DeleteAccreditationsByIds(removedAccreditations);
                    }
                }


                // Save
                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<InspectorCompetencyDto>.Fail(saveResult.Errors);

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                return ReturnBase<InspectorCompetencyDto>.Success(_mapper.Map<InspectorCompetencyDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<InspectorCompetencyDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<InspectorCompetencyDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.InspectorCompetency.GetById(id);
                if (entity == null)
                    return ReturnBase<InspectorCompetencyDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = "Inspector Competency Not Found" }
                    });


                var updateResult = await _commands.DeleteAsync(id);
                if (!updateResult.Succeeded) return ReturnBase<InspectorCompetencyDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded) return ReturnBase<InspectorCompetencyDto>.Fail(saveResult.Errors);

                return ReturnBase<InspectorCompetencyDto>.Success(_mapper.Map<InspectorCompetencyDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<InspectorCompetencyDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<InspectorCompetencyDto>> GetById(long id)
        {
            try
            {
                var entity = await _queries.GetById(id);
                if (entity == null)
                    return ReturnBase<InspectorCompetencyDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = "Inspector Competency Not Found" }
                    });

                return ReturnBase<InspectorCompetencyDto>.Success(_mapper.Map<InspectorCompetencyDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<InspectorCompetencyDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<InspectorCompetencyReturnSearchDto>>> Search(
            SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult =
                    await _queriesManager.InspectorCompetency.Search(sqlQueryOptions);

                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<InspectorCompetencyReturnSearchDto>>
                        .Fail(getResult.Errors);

                return ReturnBase<IEnumerable<InspectorCompetencyReturnSearchDto>>
                    .Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InspectorCompetencyReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }
    }
}