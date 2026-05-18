using AutoMapper;
using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.CommitmentDTOs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Constracting.Setup.Commitments;
using Inspection.Application.Contracts.Repositories.Query.Constracting.Setup.Commitments;
using Inspection.Application.Contracts.Services.Constracting.Setup.Commitment;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Contracting.Setup.Commitment;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Contracting.Setup.Commitments
{
    internal class CommitmentService : AccountsServiceBase, ICommitmentService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;


        public CommitmentService(
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
        private ICommitmentCommandRepository _commands => _accountUoW.Commitment;
        private ICommitmentQueryRepository _queries => _queriesManager.Commitment;

        public async Task<ReturnBase<CommitmentDto>> Create(CommitmentCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<Commitment>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                CreateCommitmentLines(entity, dto);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<CommitmentDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<CommitmentDto>.Fail(saveResult.Errors);

                return ReturnBase<CommitmentDto>.Success(_mapper.Map<CommitmentDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<CommitmentDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<CommitmentDto>> Update(CommitmentUpdateDto dto)
        {
            try
            {
                var entity = await _queriesManager.Commitment.GetById(dto.Id);

                if (entity == null)
                    return ReturnBase<CommitmentDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404", ErrorMessage = $"Commitment with Id {dto.Id} was not found" }
            });

                _mapper.Map(dto, entity);

                await UpdateCommitmentLines(entity, dto);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<CommitmentDto>.Fail(saveResult.Errors);

                return ReturnBase<CommitmentDto>.Success(_mapper.Map<CommitmentDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<CommitmentDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<CommitmentDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.Commitment.GetById(id);
                if (entity == null)
                    return ReturnBase<CommitmentDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = $"Commitment with Id {id} was not found" }
                    });


                var updateResult = await _commands.DeleteAsync(id);
                if (!updateResult.Succeeded) return ReturnBase<CommitmentDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded) return ReturnBase<CommitmentDto>.Fail(saveResult.Errors);

                return ReturnBase<CommitmentDto>.Success(_mapper.Map<CommitmentDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<CommitmentDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<CommitmentDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.Commitment.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = $"Commitment with Id '{id}' was not found."
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<CommitmentDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<CommitmentDto>(entity);

                return ReturnBase<CommitmentDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<CommitmentDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<CommitmentReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult =
                    await _queriesManager.Commitment.Search(sqlQueryOptions);

                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<CommitmentReturnSearchDto>>
                        .Fail(getResult.Errors);

                return ReturnBase<IEnumerable<CommitmentReturnSearchDto>>
                    .Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CommitmentReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }



        // CommitmentLines
        private void CreateCommitmentLines(Commitment entity, CommitmentCreateDto dto)
        {
            if (dto.CommitmentLines == null || !dto.CommitmentLines.Any())
            {
                entity.CommitmentLines = new List<CommitmentLine>();
                return;
            }

            entity.CommitmentLines = _mapper.Map<List<CommitmentLine>>(dto.CommitmentLines);
            foreach (var line in entity.CommitmentLines)
            {
                line.Commitment = entity;
            }
        }

        private async Task UpdateCommitmentLines(Commitment entity, CommitmentUpdateDto dto)
        {
            var existing = entity.CommitmentLines.ToList();

            if (dto.CommitmentLines == null || !dto.CommitmentLines.Any())
            {
                var allIds = existing.Select(x => x.Id).ToList();

                if (allIds.Any())
                    await _commands.DeleteCommitmentLinesByCommitmentIds(allIds);
                return;
            }

            var dtoIds = dto.CommitmentLines
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            foreach (var lineDto in dto.CommitmentLines)
            {
                if (lineDto.Id == 0)
                {
                    var newEntity = _mapper.Map<CommitmentLine>(lineDto);
                    newEntity.CommitmentId = entity.Id;
                    entity.CommitmentLines.Add(newEntity);
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
                await _commands.DeleteCommitmentLinesByCommitmentIds(removed);
        }

    }
}