using AutoMapper;
using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CurrencyExchangRateDtos;
using Inspection.Application.Contracts.Dtos.CurrencyExchange;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.SystemConfigurations.CurrencyExchangeRates;
using Inspection.Application.Contracts.Repositories.Query.SystemConfigurations.CurrencyExchangeRates;
using Inspection.Application.Contracts.Services.SystemConfigurations.CurrencyExchangeRateMasters;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.SystemConfigurations.CurrencyExchangRates;
using Inspection.Domain.Models.SystemConfigurations.DetailTables;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.SystemConfigurations.CurrencyExchangeRateMastes
{

    public class CurrencyExchangeRateMasteService : AccountsServiceBase, ICurrencyExchangeRateMasteService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IAccountsQueriesManager _queriesManager;
        private readonly IAccountUnitOfWork _accountUoW;

        private readonly IExcelTemplateGenerator _templateGenerator;

        public CurrencyExchangeRateMasteService(
            IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper,
            IExceptionManager exceptionManager,
            ITenantResolver tenantResolver,
            IExcelTemplateGenerator templateGenerator
        ) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _queriesManager = queriesManager ?? throw new ArgumentNullException(nameof(queriesManager));
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
            _accountUoW = accountUoW ?? throw new ArgumentNullException(nameof(accountUoW));


        }
        private ICurrencyExchangeRateCommandRepository _commands => _accountUoW.CurrencyExchangeRate;
        private ICurrencyExchangeRateQueryRepository _queries => _queriesManager.CurrencyExchangeRateQueryRepository;

        public async Task<ReturnBase<CurrencyExchangeRateMasterDto>> Create(CurrencyExchangeRateMasterCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<CurrencyExchangRate>(dto);

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                if (dto.Details != null && dto.Details.Any())
                {

                    entity.Details = dto.Details?.Select(d => _mapper.Map<DetailTable>(d)).ToList() ?? new List<DetailTable>();
                    foreach (var contact in entity.Details)
                    {
                        contact.CurrencyExchangRate = entity;
                    }
                }
                else
                {
                    entity.Details = new List<DetailTable>();
                }



                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<CurrencyExchangeRateMasterDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (saveResult == null)
                    return ReturnBase<CurrencyExchangeRateMasterDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "500", ErrorMessage = "SaveAsync returned null" }
            });

                if (!saveResult.Succeeded)
                    return ReturnBase<CurrencyExchangeRateMasterDto>.Fail(
                        saveResult.Errors?.ToList() ??
                        new List<ReturnBaseError>
                        {
                    new() { ErrorCode = "500", ErrorMessage = "Save failed" }
                        });

                return ReturnBase<CurrencyExchangeRateMasterDto>.Success(_mapper.Map<CurrencyExchangeRateMasterDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<CurrencyExchangeRateMasterDto>.Fail(ex, _exceptionManager);
            }
        }


        //   public async Task<ReturnBase<CurrencyExchangeRateMasterDto>> Update(
        //CurrencyExchangeRateMasterUpdateDto dto, long id)
        //   {
        //       try
        //       {
        //           var entity = await _queries.GetById(id);

        //           if (entity == null)
        //               return ReturnBase<CurrencyExchangeRateMasterDto>.Fail(
        //                   new List<ReturnBaseError>
        //                   {
        //               new() { ErrorCode = "404", ErrorMessage = "Currency Exchange Rate Not Found" }
        //                   });

        //           // 1️⃣ Update Master
        //           _mapper.Map(dto, entity);
        //           entity.Tenant_ID = _tenantResolver.GetTenantName();
        //           entity.Mod_Date = DateTime.UtcNow;

        //           if (dto.Details != null)
        //           {
        //               foreach (var detailDto in dto.Details)
        //               {
        //                   if (detailDto.Id == 0)
        //                   {
        //                       // INSERT جديد
        //                       var newDetail = _mapper.Map<DetailTable>(detailDto);
        //                       newDetail.CurrencyExchangRateId = entity.Id;
        //                       newDetail.Mod_Date = DateTime.UtcNow;
        //                       entity.Details.Add(newDetail);
        //                   }
        //                   else
        //                   {
        //                       // UPDATE موجود
        //                       var existingDetail = entity.Details.FirstOrDefault(x => x.Id == detailDto.Id);
        //                       if (existingDetail != null)
        //                       {
        //                           _mapper.Map(detailDto, existingDetail);
        //                           existingDetail.Mod_Date = DateTime.UtcNow;
        //                       }
        //                       else
        //                       {
        //                           // لو الـ Id غير موجود في Details الحالية
        //                           return ReturnBase<CurrencyExchangeRateMasterDto>.Fail(
        //                               new List<ReturnBaseError>
        //                               {
        //                           new() { ErrorCode = "404", ErrorMessage = $"Detail Id {detailDto.Id} Not Found" }
        //                               });
        //                       }
        //                   }
        //               }
        //           }

        //           var updateResult = await _commands.UpdateAsync(entity);
        //           if (!updateResult.Succeeded)
        //               return ReturnBase<CurrencyExchangeRateMasterDto>.Fail(updateResult.Errors);

        //           var saveResult = await _accountUoW.SaveAsync();
        //           if (!saveResult.Succeeded)
        //               return ReturnBase<CurrencyExchangeRateMasterDto>.Fail(saveResult.Errors);

        //           return ReturnBase<CurrencyExchangeRateMasterDto>
        //               .Success(_mapper.Map<CurrencyExchangeRateMasterDto>(entity));
        //       }
        //       catch (Exception ex)
        //       {
        //           return ReturnBase<CurrencyExchangeRateMasterDto>
        //               .Fail(ex, _exceptionManager);
        //       }
        //   }


        public async Task<ReturnBase<CurrencyExchangeRateMasterDto>> Update(CurrencyExchangeRateMasterUpdateDto dto)
        {
            try
            {
                var entity = await _queriesManager.CurrencyExchangeRateQueryRepository.GetById(dto.Id);
                if (entity == null)
                {
                    return ReturnBase<CurrencyExchangeRateMasterDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404", ErrorMessage = "Item Not Found" }
            });
                }


                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // Update Item main fields
                _mapper.Map(dto, entity);

                var existingVariants = entity.Details.ToList();

                // Case 1: User sent NO variants → HARD DELETE ALL
                if (dto.Details == null || !dto.Details.Any())
                {
                    await _commands.DeleteCurrencyExchangeRateByItemId(entity.Id);
                }
                else
                {
                    var dtoVariantIds = dto.Details
                        .Where(v => v.Id > 0)
                        .Select(v => v.Id)
                        .ToHashSet();

                    // CREATE & UPDATE
                    foreach (var variantDto in dto.Details)
                    {
                        // CREATE
                        if (variantDto.Id == 0)
                        {
                            var newVariant = _mapper.Map<DetailTable>(variantDto);
                            newVariant.CurrencyExchangRateId = entity.Id;
                            entity.Details.Add(newVariant);
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
                        await _commands.DeleteCurrencyExchangeRateByIds(removedVariants);
                    }
                }

                // Save
                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<CurrencyExchangeRateMasterDto>.Fail(saveResult.Errors);

                return ReturnBase<CurrencyExchangeRateMasterDto>.Success(_mapper.Map<CurrencyExchangeRateMasterDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<CurrencyExchangeRateMasterDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<CurrencyExchangeRateMasterDto>> Delete(long id)
        {
            try
            {
                var entity = await _queries.GetById(id);

                if (entity == null)
                {
                    return ReturnBase<CurrencyExchangeRateMasterDto>.Fail(
                        new List<ReturnBaseError>
                        {
                    new() { ErrorCode = "404", ErrorMessage = "Currency Exchange Rate Not Found" }
                        });
                }

                await _commands.DeleteCurrencyExchangeRateByItemId(entity.Id);

                await _commands.HardDeleteCurrencyExchangeRate(entity.Id);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<CurrencyExchangeRateMasterDto>.Fail(
                        new List<ReturnBaseError>
                        {
                    new() { ErrorCode = "500", ErrorMessage = "Failed to delete Currency Exchange Rate" }
                        });
                }

                return ReturnBase<CurrencyExchangeRateMasterDto>.Success(
                    _mapper.Map<CurrencyExchangeRateMasterDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<CurrencyExchangeRateMasterDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<CurrencyExchangeRateMasterDto>> GetById(long id)
        {
            try
            {
                var entity = await _queries.GetById(id);
                if (entity == null)
                    return ReturnBase<CurrencyExchangeRateMasterDto>.Fail(new List<ReturnBaseError> { new() { ErrorCode = "404", ErrorMessage = "CurrencyExchangeRateMaster Not Found" } });

                return ReturnBase<CurrencyExchangeRateMasterDto>.Success(_mapper.Map<CurrencyExchangeRateMasterDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<CurrencyExchangeRateMasterDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<CurrencyExchangeRateReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var result = await _queries.Search(sqlQueryOptions);
                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<CurrencyExchangeRateReturnSearchDto>>.Fail(result.Errors);

                var mapped = result.Result.Select(c => _mapper.Map<CurrencyExchangeRateReturnSearchDto>(c)).ToList();
                return ReturnBase<IEnumerable<CurrencyExchangeRateReturnSearchDto>>.Success(mapped);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CurrencyExchangeRateReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }
    }






}
