using AutoMapper;
using Inspection.Application.Contracts.Dto.SystemDto.TaxCategorys;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.System.TaxCategorys;
using Inspection.Application.Contracts.Services.System.TaxCategorys;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.System.Taxestegories;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.System.TaxCategorys
{

    public class TaxCategoryServise : AccountsServiceBase, ITaxCategoryServise
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public TaxCategoryServise(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }




        public async Task<ReturnBase<TaxCategoryDto>> Create(TaxCategoryCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<TaxCategory>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                if (entity is null)
                {
                    return ReturnBase<TaxCategoryDto>.Fail(new List<ReturnBaseError>
            {
                new ReturnBaseError
                {
                    ErrorCode = "404",
                    ErrorMessage = "TaxCategory Not Found"
                }
            });
                }


                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<TaxCategoryDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<TaxCategoryDto>.Fail(saveResult.Errors);

                return ReturnBase<TaxCategoryDto>.Success(_mapper.Map<TaxCategoryDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<TaxCategoryDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<TaxCategoryDto>> Update(TaxCategoryUpdateDto dto)
        {
            try
            {
                var entity = await _queriesManager.TaxCategoryQueryRepository.GetById(dto.Id);
                if (entity is null)
                {
                    return ReturnBase<TaxCategoryDto>.Fail(new List<ReturnBaseError>
            {
                new ReturnBaseError
                {
                    ErrorCode = "404",
                    ErrorMessage = "TaxCategory Not Found"
                }
            });
                }
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(dto, entity);



                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)
                    return ReturnBase<TaxCategoryDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<TaxCategoryDto>.Fail(saveResult.Errors);

                return ReturnBase<TaxCategoryDto>.Success(_mapper.Map<TaxCategoryDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<TaxCategoryDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<TaxCategoryDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.TaxCategoryQueryRepository.GetById(id);
                if (entity is null)
                {
                    return ReturnBase<TaxCategoryDto>.Fail(new List<ReturnBaseError>
                    {
                        new()
                        {
                            ErrorCode = "404",
                            ErrorMessage = "TaxCategory Not Found"
                        }
                    });
                }


                var deleteResult = await _commands.DeleteById(id);
                if (!deleteResult.Succeeded)
                    return ReturnBase<TaxCategoryDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<TaxCategoryDto>.Fail(saveResult.Errors);

                return ReturnBase<TaxCategoryDto>.Success(_mapper.Map<TaxCategoryDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<TaxCategoryDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<TaxCategoryDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.TaxCategoryQueryRepository.GetById(id);
                if (entity is null)
                {
                    return ReturnBase<TaxCategoryDto>.Fail(new List<ReturnBaseError>
            {
                new ReturnBaseError
                {
                    ErrorCode = "404",
                    ErrorMessage = "TaxCategory Not Found"
                }
            });
                }

                var mappedResult = _mapper.Map<TaxCategoryDto>(entity);
                return ReturnBase<TaxCategoryDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<TaxCategoryDto>.Fail(ex, _exceptionManager);
            }
        }





        public async Task<ReturnBase<IEnumerable<TaxCategoryDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.TaxCategoryQueryRepository.Search(sqlQueryOptions);

                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<TaxCategoryDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<TaxCategoryDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<TaxCategoryDto>>.Fail(ex, _exceptionManager);
            }
        }



        private ITaxCategoryCommandRepository _commands
    => _accountUoW.TaxCategory;

    }

}
