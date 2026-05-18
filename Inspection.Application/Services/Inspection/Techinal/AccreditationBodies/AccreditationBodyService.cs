using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.AccreditationBodyDTOs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Inspection.Techinal.AccreditationBodies;
using Inspection.Application.Contracts.Repositories.Query.Inspection.Techinal.AccreditationBodies;
using Inspection.Application.Contracts.Services.Inspection.Techinal.AccreditationBodies;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Inspection.Techinal.AccreditationBodies;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Inspection.Techinal.AccreditationBodies
{
    internal class AccreditationBodyService : AccountsServiceBase, IAccreditationBodyService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public AccreditationBodyService(
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

        private IAccreditationBodyCommandRepository _commands => _accountUoW.AccreditationBody;
        private IAccreditationBodyQueryRepository _queries => _queriesManager.AccreditationBody;


        public async Task<ReturnBase<AccreditationBodyDto>> Create(AccreditationBodyCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<AccreditationBody>(dto);

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                if (dto.AccreditationBodyLines != null && dto.AccreditationBodyLines.Any())
                {
                    entity.AccreditationBodyLines = _mapper.Map<List<AccreditationBodyLine>>(dto.AccreditationBodyLines);

                    foreach (var line in entity.AccreditationBodyLines)
                    {
                        line.AccreditationBody = entity;
                    }
                }
                else
                {
                    entity.AccreditationBodyLines = new List<AccreditationBodyLine>();
                }

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<AccreditationBodyDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (saveResult == null)
                    return ReturnBase<AccreditationBodyDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "500", ErrorMessage = "SaveAsync returned null" }
            });

                if (!saveResult.Succeeded)
                    return ReturnBase<AccreditationBodyDto>.Fail(
                        saveResult.Errors?.ToList() ??
                        new List<ReturnBaseError>
                        {
                    new() { ErrorCode = "500", ErrorMessage = "Save failed" }
                        });

                return ReturnBase<AccreditationBodyDto>.Success(_mapper.Map<AccreditationBodyDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<AccreditationBodyDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<AccreditationBodyDto>> Update(AccreditationBodyUpdateDto dto)
        {
            try
            {
                var entity = await _queriesManager.AccreditationBody.GetById(dto.Id);
                if (entity == null)
                {
                    return ReturnBase<AccreditationBodyDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = $"Accreditation Body with Id {dto.Id} was not found" }
                    });
                }

                // Update Accreditation Body main fields
                _mapper.Map(dto, entity);

                var existingLines = entity.AccreditationBodyLines.ToList();

                // Case 1: User sent NO variants → HARD DELETE ALL
                if (dto.AccreditationBodyLines == null || !dto.AccreditationBodyLines.Any())
                {
                    await _commands.DeleteLinesByAccreditationBodyId(entity.Id);
                }
                else
                {
                    var dtoLineIds = dto.AccreditationBodyLines
                        .Where(v => v.Id > 0)
                        .Select(v => v.Id)
                        .ToHashSet();

                    // CREATE & UPDATE
                    foreach (var lineDto in dto.AccreditationBodyLines)
                    {
                        // CREATE
                        if (lineDto.Id == 0)
                        {
                            var newLine = _mapper.Map<AccreditationBodyLine>(lineDto);
                            newLine.AccreditationBodyId = entity.Id;
                            entity.AccreditationBodyLines.Add(newLine);
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

                // Save
                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<AccreditationBodyDto>.Fail(saveResult.Errors);

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                return ReturnBase<AccreditationBodyDto>.Success(_mapper.Map<AccreditationBodyDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<AccreditationBodyDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<AccreditationBodyDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.AccreditationBody.GetById(id);
                if (entity == null)
                    return ReturnBase<AccreditationBodyDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = $"Accreditation Body with Id {id} was not found" }
                    });


                var updateResult = await _commands.DeleteAsync(id);
                if (!updateResult.Succeeded) return ReturnBase<AccreditationBodyDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded) return ReturnBase<AccreditationBodyDto>.Fail(saveResult.Errors);

                return ReturnBase<AccreditationBodyDto>.Success(_mapper.Map<AccreditationBodyDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<AccreditationBodyDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<AccreditationBodyDto>> GetById(long id)
        {
            try
            {
                var entity = await _queries.GetById(id);
                if (entity == null)
                    return ReturnBase<AccreditationBodyDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = $"Accreditation Body with Id {id} was not found" }
                    });

                return ReturnBase<AccreditationBodyDto>.Success(_mapper.Map<AccreditationBodyDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<AccreditationBodyDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<AccreditationBodyReturnSearchDto>>> Search(
            SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult =
                    await _queriesManager.AccreditationBody.Search(sqlQueryOptions);

                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<AccreditationBodyReturnSearchDto>>
                        .Fail(getResult.Errors);

                return ReturnBase<IEnumerable<AccreditationBodyReturnSearchDto>>
                    .Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<AccreditationBodyReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }
    }
}