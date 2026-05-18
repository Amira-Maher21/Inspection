using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectionStandards;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Inspection.Techinal.InspectionStandards;
using Inspection.Application.Contracts.Repositories.Query.Inspection.Techinal.InspectionStandards;
using Inspection.Application.Contracts.Services.Inspection.Techinal.InspectionStandards;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Inspection.Techinal.InspectionStandardApplicabilityRules;
using Inspection.Domain.Models.Inspection.Techinal.InspectionStandards;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Inspection.Techinal.InspectionStandards
{
    internal class InspectionStandardService : AccountsServiceBase, IInspectionStandardService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IAccountsQueriesManager _queriesManager;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public InspectionStandardService(
            IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper,
            IExceptionManager exceptionManager,
            ITenantResolver tenantResolver,
            IExcelTemplateGenerator templateGenerator) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _queriesManager = queriesManager ?? throw new ArgumentNullException(nameof(queriesManager));
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }

        private IInspectionStandardCommandRepository _commands => _accountUoW.InspectionStandard;
        private IInspectionStandardQueryRepository _queries => _queriesManager.InspectionStandards;


        public async Task<ReturnBase<InspectionStandardDto>> Create(InspectionStandardCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<InspectionStandard>(dto);

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                if (dto.InspectionStandardApplicabilityRules != null && dto.InspectionStandardApplicabilityRules.Any())
                {
                    entity.InspectionStandardApplicabilityRules = _mapper.Map<List<InspectionStandardApplicabilityRule>>(dto.InspectionStandardApplicabilityRules);

                    foreach (var varient in entity.InspectionStandardApplicabilityRules)
                    {
                        varient.Standard = entity;
                    }
                }
                else
                {
                    entity.InspectionStandardApplicabilityRules = new List<InspectionStandardApplicabilityRule>();
                }

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<InspectionStandardDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (saveResult == null)
                    return ReturnBase<InspectionStandardDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "500", ErrorMessage = "SaveAsync returned null" }
            });

                if (!saveResult.Succeeded)
                    return ReturnBase<InspectionStandardDto>.Fail(
                        saveResult.Errors?.ToList() ??
                        new List<ReturnBaseError>
                        {
                    new() { ErrorCode = "500", ErrorMessage = "Save failed" }
                        });

                return ReturnBase<InspectionStandardDto>.Success(_mapper.Map<InspectionStandardDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<InspectionStandardDto>.Fail(ex, _exceptionManager);
            }
        }
        //public async Task<ReturnBase<InspectionStandardDto>> Update(InspectionStandardUpdateDto dto, long id)
        //{
        //    try
        //    {
        //        var entity = await _queriesManager.InspectionStandards.GetById(id);
        //        if (entity == null)
        //            return ReturnBase<InspectionStandardDto>.Fail(new List<ReturnBaseError>
        //    {
        //        new() { ErrorCode = "404", ErrorMessage = "InspectionStandard Not Found" }
        //    });

        //        // Update InspectionStandard
        //        _mapper.Map(dto, entity);

        //        // Update Variants
        //        var existingVariants = entity.InspectionStandardVariants.ToList();

        //        foreach (var variantDto in dto.InspectionStandardVariants)
        //        {
        //            var existingVariant =
        //                existingVariants.FirstOrDefault(v => v.Id == variantDto.Id);

        //            if (existingVariant != null)
        //            {
        //                // UPDATE
        //                _mapper.Map(variantDto, existingVariant);
        //            }
        //            else
        //            {
        //                // ADD
        //                var newVariant = _mapper.Map<InspectionStandardVariant>(variantDto);
        //                newVariant.InspectionStandard = entity;
        //                entity.InspectionStandardVariants.Add(newVariant);
        //            }
        //        }

        //        // Remove Deleted Variants 
        //        var dtoVariantIds = dto.InspectionStandardVariants.Select(v => v.Id).ToHashSet();

        //        var removedVariants = existingVariants
        //            .Where(v => !dtoVariantIds.Contains(v.Id))
        //            .ToList();

        //        foreach (var variant in removedVariants)
        //            entity.InspectionStandardVariants.Remove(variant);

        //        // Save
        //        var saveResult = await _accountUoW.SaveAsync();
        //        if (!saveResult.Succeeded)
        //            return ReturnBase<InspectionStandardDto>.Fail(saveResult.Errors);

        //        entity.Tenant_ID = _tenantResolver.GetTenantName();

        //        return ReturnBase<InspectionStandardDto>.Success(_mapper.Map<InspectionStandardDto>(entity));
        //    }
        //    catch (Exception ex)
        //    {
        //        return ReturnBase<InspectionStandardDto>.Fail(ex, _exceptionManager);
        //    }
        //}

        public async Task<ReturnBase<InspectionStandardDto>> Update(InspectionStandardUpdateDto dto)
        {
            try
            {
                var tenantId = _tenantResolver.GetTenantName();

                var entity = await _queriesManager.InspectionStandards.GetById(dto.Id);
                if (entity == null)
                {
                    return ReturnBase<InspectionStandardDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = "InspectionStandard Not Found" }
                    });
                }

                // Update InspectionStandard main fields
                _mapper.Map(dto, entity);

                var existingVariants = entity.InspectionStandardApplicabilityRules.ToList();

                // Case 1: User sent NO variants → HARD DELETE ALL
                if (dto.InspectionStandardApplicabilityRules == null || !dto.InspectionStandardApplicabilityRules.Any())
                {
                    await _commands.DeleteDetailsByInspectionStandardId(entity.Id);
                }
                else
                {
                    var dtoVariantIds = dto.InspectionStandardApplicabilityRules
                        .Where(v => v.Id > 0)
                        .Select(v => v.Id)
                        .ToHashSet();

                    // CREATE & UPDATE
                    foreach (var variantDto in dto.InspectionStandardApplicabilityRules)
                    {
                        // CREATE
                        if (variantDto.Id == 0)
                        {
                            var newVariant = _mapper.Map<InspectionStandardApplicabilityRule>(variantDto);
                            newVariant.StandardId = entity.Id;
                            entity.InspectionStandardApplicabilityRules.Add(newVariant);
                        }
                        else
                        {
                            // UPDATE
                            var existingVariant =
                                existingVariants.FirstOrDefault(v => v.Id == variantDto.Id);

                            if (existingVariant != null)
                            {
                                _mapper.Map(variantDto, existingVariant);
                            }
                        }
                    }

                    // HARD DELETE removed variants
                    var removedVariants = existingVariants
                        .Where(v => !dtoVariantIds.Contains(v.Id))
                        .Select(v => v.Id)
                        .ToList();

                    if (removedVariants.Any())
                    {
                        await _commands.DeleteDetailsByIds(removedVariants);
                    }
                }

                // Save
                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<InspectionStandardDto>.Fail(saveResult.Errors);

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                return ReturnBase<InspectionStandardDto>.Success(_mapper.Map<InspectionStandardDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<InspectionStandardDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<InspectionStandardDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.InspectionStandards.GetById(id);
                if (entity == null)
                    return ReturnBase<InspectionStandardDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = "InspectionStandard Not Found" }
                    });


                var updateResult = await _commands.DeleteAsync(id);
                if (!updateResult.Succeeded) return ReturnBase<InspectionStandardDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded) return ReturnBase<InspectionStandardDto>.Fail(saveResult.Errors);

                return ReturnBase<InspectionStandardDto>.Success(_mapper.Map<InspectionStandardDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<InspectionStandardDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<InspectionStandardDto>> GetById(long id)
        {
            try
            {
                var entity = await _queries.GetById(id);
                if (entity == null)
                    return ReturnBase<InspectionStandardDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = "InspectionStandard Not Found" }
                    });

                return ReturnBase<InspectionStandardDto>.Success(_mapper.Map<InspectionStandardDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<InspectionStandardDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<InspectionStandardReturnSearchDto>>> Search(
            SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult =
                    await _queriesManager.InspectionStandards.Search(sqlQueryOptions);

                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<InspectionStandardReturnSearchDto>>
                        .Fail(getResult.Errors);

                return ReturnBase<IEnumerable<InspectionStandardReturnSearchDto>>
                    .Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InspectionStandardReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }
        public async Task<InspectionStandard> GetByCode(string code)
        {
            var standard = await _queries.GetByCode(code);

            return standard;
        }

    }
}
