using AutoMapper;
using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.OperationDTOs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.SystemConfigurations.Operations;
using Inspection.Application.Contracts.Services.SystemConfigurations.Operations;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.SystemConfigurations.Operations;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.SystemConfigurations.Operations
{
    public class OperationService : AccountsServiceBase, IOperationService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public OperationService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }

        private async Task<ReturnBase> ValidateCloseOperation(Operation entity)
        {
            if (!entity.IsClosed)
                return ReturnBase.Success();

            var hasOpenTransactions =
                await _queriesManager.OperationQueryRepository.HasOpenTransactions(entity.Id);

            if (hasOpenTransactions)
                return ReturnBase.Fail(new List<ReturnBaseError>
                {
                    new()
                    {
                        ErrorCode = "400",
                        ErrorMessage = "Cannot close operation with open transactions"
                    }
                });

            return ReturnBase.Success();
        }


        private async Task<ReturnBase> ValidateOperationCodeChange(
                Operation entity,
                OperationUpdateDto dto)
        {
            if (dto.Code == entity.Code)
                return ReturnBase.Success();

            var hasTransactions =
                await _queriesManager.OperationQueryRepository.HasAnyTransactions(entity.Id);

            if (hasTransactions)
                return ReturnBase.Fail(new List<ReturnBaseError>
                {
                new()
                {
                    ErrorCode = "400",
                    ErrorMessage = "Cannot close operation with open transactions"
                }
                 });

            return ReturnBase.Success();
        }


        public async Task<ReturnBase<OperationDto>> Update(OperationUpdateDto dto)
        {
            try
            {
                var entity = await _queriesManager.OperationQueryRepository.GetById(dto.Id);
                if (entity is null)
                {
                    return ReturnBase<OperationDto>.Fail(new List<ReturnBaseError>
                    {
                        new()
                        {
                            ErrorCode = "404",
                            ErrorMessage = "Operation Not Found"
                        }
                    });
                }

                var codeValidation = await ValidateOperationCodeChange(entity, dto);
                if (!codeValidation.Succeeded)
                    return ReturnBase<OperationDto>.Fail(codeValidation.Errors);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(dto, entity);

                var closeValidation = await ValidateCloseOperation(entity);
                if (!closeValidation.Succeeded)
                    return ReturnBase<OperationDto>.Fail(closeValidation.Errors);

                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)
                    return ReturnBase<OperationDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<OperationDto>.Fail(saveResult.Errors);

                return ReturnBase<OperationDto>.Success(_mapper.Map<OperationDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<OperationDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<OperationDto>> Create(OperationCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<Operation>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<OperationDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<OperationDto>.Fail(saveResult.Errors);

                return ReturnBase<OperationDto>.Success(_mapper.Map<OperationDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<OperationDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<OperationDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.OperationQueryRepository.GetById(id);
                if (entity is null)
                {
                    return ReturnBase<OperationDto>.Fail(new List<ReturnBaseError>
                    {
                        new()
                        {
                            ErrorCode = "404",
                            ErrorMessage = "Operation Not Found"
                        }
                    });
                }


                var deleteResult = await _commands.DeleteById(id);
                if (!deleteResult.Succeeded)
                    return ReturnBase<OperationDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<OperationDto>.Fail(saveResult.Errors);

                return ReturnBase<OperationDto>.Success(_mapper.Map<OperationDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<OperationDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<OperationDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.OperationQueryRepository.GetById(id); // استخدام الـ Query Repository
                if (entity is null)
                {
                    return ReturnBase<OperationDto>.Fail(new List<ReturnBaseError>
            {
                new ReturnBaseError
                {
                    ErrorCode = "404",
                    ErrorMessage = "Operation Not Found"
                }
            });
                }

                var mappedResult = _mapper.Map<OperationDto>(entity);
                return ReturnBase<OperationDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<OperationDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<OperationDto>>> GetList(SqlQueryOptions? sqlQueryOptions = null)
        {
            try
            {
                var entities = await _queriesManager.OperationQueryRepository.GetList(sqlQueryOptions);
                var mappedResult = _mapper.Map<IEnumerable<OperationDto>>(entities);
                return ReturnBase<IEnumerable<OperationDto>>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<OperationDto>>.Fail(ex, _exceptionManager);
            }
        }



        private IOperationCommandRepository _commands
    => _accountUoW.Operations;

    }


}

