using AutoMapper;
using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.SubcontractBOQDTOs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Contracting.Setup.ISubcontractBOQs;
using Inspection.Application.Contracts.Repositories.Query.Contracting.Setup.ISubcontractBOQs;
using Inspection.Application.Contracts.Services.Contracting.Setup.ISubcontractBOQs;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Contracting.Setup.SubcontractBOQs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Contracting.Setup.SubcontractSubcontractBOQs
{
    internal class SubcontractBOQService : AccountsServiceBase, ISubcontractBOQService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly ISeriesService _seriesService;


        public SubcontractBOQService(
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
        private ISubcontractBOQCommandRepository _commands => _accountUoW.SubcontractBOQ;
        private ISubcontractBOQQueryRepository _queries => _queriesManager.SubcontractBOQ;

        public async Task<ReturnBase<SubcontractBOQDto>> Create(SubcontractBOQCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<SubcontractBOQ>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                CreateSubcontractBOQLines(entity, dto);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<SubcontractBOQDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<SubcontractBOQDto>.Fail(saveResult.Errors);

                return ReturnBase<SubcontractBOQDto>.Success(_mapper.Map<SubcontractBOQDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<SubcontractBOQDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<SubcontractBOQDto>> Update(SubcontractBOQUpdateDto dto)
        {
            try
            {
                var entity = await _queriesManager.SubcontractBOQ.GetById(dto.Id);

                if (entity == null)
                    return ReturnBase<SubcontractBOQDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404", ErrorMessage = $"Subcontract BOQ with Id {dto.Id} was not found" }
            });

                _mapper.Map(dto, entity);

                await UpdateSubcontractBOQLines(entity, dto);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<SubcontractBOQDto>.Fail(saveResult.Errors);

                return ReturnBase<SubcontractBOQDto>.Success(_mapper.Map<SubcontractBOQDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<SubcontractBOQDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<SubcontractBOQDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.SubcontractBOQ.GetById(id);
                if (entity == null)
                    return ReturnBase<SubcontractBOQDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = $"Subcontract BOQ with Id {id} was not found" }
                    });


                var updateResult = await _commands.DeleteAsync(id);
                if (!updateResult.Succeeded) return ReturnBase<SubcontractBOQDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded) return ReturnBase<SubcontractBOQDto>.Fail(saveResult.Errors);

                return ReturnBase<SubcontractBOQDto>.Success(_mapper.Map<SubcontractBOQDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<SubcontractBOQDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<SubcontractBOQDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.SubcontractBOQ.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = $"Subcontract BOQ with Id '{id}' was not found."
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<SubcontractBOQDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<SubcontractBOQDto>(entity);

                return ReturnBase<SubcontractBOQDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<SubcontractBOQDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<SubcontractBOQReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult =
                    await _queriesManager.SubcontractBOQ.Search(sqlQueryOptions);

                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<SubcontractBOQReturnSearchDto>>
                        .Fail(getResult.Errors);

                return ReturnBase<IEnumerable<SubcontractBOQReturnSearchDto>>
                    .Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<SubcontractBOQReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }


        // Create && Update  Any Detail For SubcontractBOQ (Lines) should be handled in these methods to make sure that all operations will be in the same transaction scope

        // SubcontractBOQLines
        private void CreateSubcontractBOQLines(SubcontractBOQ entity, SubcontractBOQCreateDto dto)
        {
            if (dto.SubcontractBOQLines == null || !dto.SubcontractBOQLines.Any())
            {
                entity.SubcontractBOQLines = new List<SubcontractBOQLine>();
                return;
            }

            entity.SubcontractBOQLines = _mapper.Map<List<SubcontractBOQLine>>(dto.SubcontractBOQLines);
            foreach (var line in entity.SubcontractBOQLines)
            {
                line.SubcontractBOQ = entity;
            }
        }

        private async Task UpdateSubcontractBOQLines(SubcontractBOQ entity, SubcontractBOQUpdateDto dto)
        {
            var existing = entity.SubcontractBOQLines.ToList();

            if (dto.SubcontractBOQLines == null || !dto.SubcontractBOQLines.Any())
            {
                var allIds = existing.Select(x => x.Id).ToList();

                if (allIds.Any())
                    await _commands.DeleteSubcontractBOQLinesBySubcontractBOQIds(allIds);
                return;
            }

            var dtoIds = dto.SubcontractBOQLines
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            foreach (var lineDto in dto.SubcontractBOQLines)
            {
                if (lineDto.Id == 0)
                {
                    var newEntity = _mapper.Map<SubcontractBOQLine>(lineDto);
                    newEntity.SubcontractBOQId = entity.Id;
                    entity.SubcontractBOQLines.Add(newEntity);
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
                await _commands.DeleteSubcontractBOQLinesBySubcontractBOQIds(removed);
        }

    }
}