using AutoMapper;
using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.BOQDTOs;
using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.BOQDTOs.BOQLineDTOs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Contracting.Setup.IBOQs;
using Inspection.Application.Contracts.Repositories.Query.Contracting.Setup.IBOQs;
using Inspection.Application.Contracts.Services.Contracting.Setup.IBOQs;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Contracting.Setup.BOQs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Contracting.Setup.BOQs
{
    internal class BOQService : AccountsServiceBase, IBOQService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly ISeriesService _seriesService;


        public BOQService(
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
        private IBOQCommandRepository _commands => _accountUoW.BOQ;
        private IBOQQueryRepository _queries => _queriesManager.BOQ;

        public async Task<ReturnBase<BOQDto>> Create(BOQCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<BOQ>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                CreateBOQLines(entity, dto);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<BOQDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<BOQDto>.Fail(saveResult.Errors);

                return ReturnBase<BOQDto>.Success(_mapper.Map<BOQDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<BOQDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<BOQDto>> Update(BOQUpdateDto dto)
        {
            try
            {
                var entity = await _queriesManager.BOQ.GetById(dto.Id);

                if (entity == null)
                    return ReturnBase<BOQDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404", ErrorMessage = $"BOQ with Id {dto.Id} was not found" }
            });

                _mapper.Map(dto, entity);

                await UpdateBOQLines(entity, dto);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<BOQDto>.Fail(saveResult.Errors);

                return ReturnBase<BOQDto>.Success(_mapper.Map<BOQDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<BOQDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<BOQDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.BOQ.GetById(id);
                if (entity == null)
                    return ReturnBase<BOQDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = $"BOQ with Id {id} was not found" }
                    });


                var updateResult = await _commands.DeleteAsync(id);
                if (!updateResult.Succeeded) return ReturnBase<BOQDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded) return ReturnBase<BOQDto>.Fail(saveResult.Errors);

                return ReturnBase<BOQDto>.Success(_mapper.Map<BOQDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<BOQDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<BOQDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.BOQ.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = $"BOQ with Id '{id}' was not found."
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<BOQDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<BOQDto>(entity);

                return ReturnBase<BOQDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<BOQDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<BOQReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult =
                    await _queriesManager.BOQ.Search(sqlQueryOptions);

                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<BOQReturnSearchDto>>
                        .Fail(getResult.Errors);

                return ReturnBase<IEnumerable<BOQReturnSearchDto>>
                    .Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<BOQReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<BOQLineDto>>> SearchBOQLines(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult =
                    await _queriesManager.BOQ.SearchBOQLines(sqlQueryOptions);

                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<BOQLineDto>>
                        .Fail(getResult.Errors);

                return ReturnBase<IEnumerable<BOQLineDto>>
                    .Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<BOQLineDto>>
                    .Fail(ex, _exceptionManager);
            }
        }

        // Create && Update  Any Detail For BOQ (Lines) should be handled in these methods to make sure that all operations will be in the same transaction scope

        // BOQLines
        private void CreateBOQLines(BOQ entity, BOQCreateDto dto)
        {
            if (dto.BOQLines == null || !dto.BOQLines.Any())
            {
                entity.BOQLines = new List<BOQLine>();
                return;
            }

            entity.BOQLines = _mapper.Map<List<BOQLine>>(dto.BOQLines);
            foreach (var line in entity.BOQLines)
            {
                line.BOQ = entity;
            }
        }

        private async Task UpdateBOQLines(BOQ entity, BOQUpdateDto dto)
        {
            var existing = entity.BOQLines.ToList();

            if (dto.BOQLines == null || !dto.BOQLines.Any())
            {
                var allIds = existing.Select(x => x.Id).ToList();

                if (allIds.Any())
                    await _commands.DeleteBOQLinesByBOQIds(allIds);
                return;
            }

            var dtoIds = dto.BOQLines
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            foreach (var lineDto in dto.BOQLines)
            {
                if (lineDto.Id == 0)
                {
                    var newEntity = _mapper.Map<BOQLine>(lineDto);
                    newEntity.BOQId = entity.Id;
                    entity.BOQLines.Add(newEntity);
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
                await _commands.DeleteBOQLinesByBOQIds(removed);
        }

    }
}