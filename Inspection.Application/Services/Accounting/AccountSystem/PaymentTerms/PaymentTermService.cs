using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.AccountSystemDto.PaymentTermDto;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSystem.PaymentTerm;
using Inspection.Application.Contracts.Services.Accounting.AccountSystem.PaymentTerms;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Application.Shared.SharedValidation;
using Inspection.Domain.Models.Accounting.AccountingSystem.PaymentTerms;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.AccountSystem.PaymentTerms
{
    internal class PaymentTermService : AccountsServiceBase, IPaymentTermService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public PaymentTermService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }
        //done
        public async Task<ReturnBase<PaymentTermDto>> Create(
            PaymentTermCreateDto createDto)
        {
            try
            {
                createDto.Code.ValidateAsCode();
                createDto.Name.ValidateAsName();
                var entity = _mapper.Map<PaymentTerm>(createDto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();
                var validationErrors = ValidatePaymentTerm(entity);
                if (validationErrors.Any())
                    return ReturnBase<PaymentTermDto>.Fail(validationErrors);
                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<PaymentTermDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<PaymentTermDto>.Fail(saveResult.Errors);

                var resultDto = _mapper.Map<PaymentTermDto>(entity);
                return ReturnBase<PaymentTermDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<PaymentTermDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<PaymentTermDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.PaymentTerms.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Payment Term Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<PaymentTermDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<PaymentTermDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<PaymentTermDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<PaymentTermDto>(entity);

                return ReturnBase<PaymentTermDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<PaymentTermDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<List<PaymentTermDto>>> GetAll()
        {
            try
            {
                var result = await _queriesManager.PaymentTerms.GetAll();

                if (!result.Succeeded)
                {
                    return ReturnBase<List<PaymentTermDto>>.Fail(result.Errors);
                }

                var mapped = _mapper.Map<List<PaymentTermDto>>(result.Result);

                return ReturnBase<List<PaymentTermDto>>.Success(mapped);
            }
            catch (Exception ex)
            {
                return ReturnBase<List<PaymentTermDto>>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<PaymentTermDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.PaymentTerms.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Default Account Group not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<PaymentTermDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<PaymentTermDto>(entity);

                return ReturnBase<PaymentTermDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<PaymentTermDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<IEnumerable<PaymentTermDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.PaymentTerms.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<PaymentTermDto>>.Fail(getResult.Errors);

                var mappedResult = _mapper.Map<IEnumerable<PaymentTermDto>>(getResult.Result);

                return ReturnBase<IEnumerable<PaymentTermDto>>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<PaymentTermDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<PaymentTermDto>> Update(PaymentTermUpdateDto updateDto)
        {
            try
            {
                updateDto.Code.ValidateAsCode();
                updateDto.Name.ValidateAsName();
                var entity = await _queriesManager.PaymentTerms.GetById(updateDto.Id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Payment Term Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<PaymentTermDto>.Fail(listOfErrors);
                }




                var validationErrors = ValidatePaymentTerm(entity);
                if (validationErrors.Any())
                    return ReturnBase<PaymentTermDto>.Fail(validationErrors);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(updateDto, entity);

                //entity = _mapper.Map<PaymentTerm>(updateDto);
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<PaymentTermDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<PaymentTermDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<PaymentTermDto>(entity);

                return ReturnBase<PaymentTermDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<PaymentTermDto>.Fail(ex, _exceptionManager);
            }
        }


        private IPaymentTermCommandRepository _commands
        {
            get { return _accountUoW.PaymentTerm; }
        }
        private List<ReturnBaseError> ValidatePaymentTerm(PaymentTerm entity)
        {
            var errors = new List<ReturnBaseError>();

            if (entity.DaysDue < 0)
            {
                errors.Add(new ReturnBaseError
                {
                    ErrorCode = "PT_001",
                    ErrorMessage = "Days Due must be greater than or equal to 0"
                });
            }

            if (entity.DiscountPercentage.HasValue &&
                (entity.DiscountPercentage < 0 || entity.DiscountPercentage > 100))
            {
                errors.Add(new ReturnBaseError
                {
                    ErrorCode = "PT_002",
                    ErrorMessage = "Discount Percentage must be between 0 and 100"
                });
            }

            if (entity.DaysDiscount.HasValue && entity.DaysDiscount < 0)
            {
                errors.Add(new ReturnBaseError
                {
                    ErrorCode = "PT_003",
                    ErrorMessage = "Discount Days must be greater than or equal to 0"
                });
            }

            return errors;
        }

    }
}