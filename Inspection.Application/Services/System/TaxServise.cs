using AutoMapper;
using Inspection.Application.Contracts.Dto.SystemDto.Taxs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.System;
using Inspection.Application.Contracts.Services.System;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.System;
using Inspection.Domain.Models.System.Taxes;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.System
{
    public class TaxTypeServise : AccountsServiceBase, ITaxTypeServise
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public TaxTypeServise(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }




        public async Task<ReturnBase<TaxDto>> Create(TaxCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<TaxType>(dto);
                var TenantName = _tenantResolver.GetTenantName();
                entity.Tenant_ID = TenantName;

                if (!entity.IsActive)
                {
                    return ReturnBase<TaxDto>.Fail(new List<ReturnBaseError>
            {
                new ReturnBaseError
                {
                    ErrorCode = "400",
                    ErrorMessage = "Cannot create an inactive tax."
                }
            });
                }

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<TaxDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<TaxDto>.Fail(saveResult.Errors);

                return ReturnBase<TaxDto>.Success(_mapper.Map<TaxDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<TaxDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<TaxDto>> Update(TaxUpdateDto dto)
        {
            try
            {
                var entity = await _queriesManager.TaxTypeQueryRepository.GetById(dto.Id);
                if (entity is null)
                {
                    return ReturnBase<TaxDto>.Fail(new List<ReturnBaseError>
            {
                new ReturnBaseError
                {
                    ErrorCode = "404",
                    ErrorMessage = "Tax Not Found"
                }
            });
                }
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(dto, entity);

                if (!entity.IsActive)
                {
                    return ReturnBase<TaxDto>.Fail(new List<ReturnBaseError>
            {
                new ReturnBaseError
                {
                    ErrorCode = "400",
                    ErrorMessage = "Cannot update a tax to be inactive."
                }
            });
                }




                if (dto.TaxTypeLine
                     .GroupBy(x => x.DocumentDirection)
                     .Any(g => g.Count() > 1))
                {
                    return ReturnBase<TaxDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "400", ErrorMessage = "Duplicate DocumentDirection is not allowed." }
                    });
                }

                entity.TaxTypeLine.Clear();

                foreach (var lineDto in dto.TaxTypeLine)
                {
                    entity.TaxTypeLine.Add(_mapper.Map<TaxTypeLine>(lineDto));
                }

                var updateResult = await _commands.UpdateAsync(entity);


                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<TaxDto>.Fail(saveResult.Errors);

                return ReturnBase<TaxDto>.Success(_mapper.Map<TaxDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<TaxDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<TaxDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.TaxTypeQueryRepository.GetById(id);
                if (entity is null)
                {
                    return ReturnBase<TaxDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404", ErrorMessage = "Tax Not Found" }
            });
                }

                var mappedResult = _mapper.Map<TaxDto>(entity);
                mappedResult.IsActive = true;
                if (entity.IsSystem)
                {
                    return ReturnBase<TaxDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "400", ErrorMessage = "System tax cannot be deleted." }
                    });
                }
                // Hard delete
                var deleteResult = await _commands.DeleteById(id);
                if (!deleteResult.Succeeded)
                    return ReturnBase<TaxDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<TaxDto>.Fail(saveResult.Errors);

                mappedResult.IsActive = false;

                return ReturnBase<TaxDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<TaxDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<TaxDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.TaxTypeQueryRepository.GetById(id);
                if (entity is null)
                {
                    return ReturnBase<TaxDto>.Fail(new List<ReturnBaseError>
            {
                new ReturnBaseError
                {
                    ErrorCode = "404",
                    ErrorMessage = "Tax Not Found"
                }
            });
                }

                var mappedResult = _mapper.Map<TaxDto>(entity);
                return ReturnBase<TaxDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<TaxDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<TaxDto>>> GetList(SqlQueryOptions? sqlQueryOptions = null)
        {
            try
            {
                var entities = await _queriesManager.TaxTypeQueryRepository.GetList(sqlQueryOptions);
                var mappedResult = _mapper.Map<IEnumerable<TaxDto>>(entities);
                return ReturnBase<IEnumerable<TaxDto>>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<TaxDto>>.Fail(ex, _exceptionManager);
            }
        }




        public async Task<ReturnBase<IEnumerable<TaxReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.TaxTypeQueryRepository.Search(sqlQueryOptions);

                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<TaxReturnSearchDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<TaxReturnSearchDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<TaxReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }



        private ITaxTypeCommandRepository _commands
    => _accountUoW.Taxes;

    }
}

