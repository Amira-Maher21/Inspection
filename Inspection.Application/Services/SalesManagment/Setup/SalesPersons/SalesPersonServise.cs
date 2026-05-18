using AutoMapper;
using Inspection.Application.Contracts.Dto.SalesManagment.Setup.SalesPerson;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.SalesManagment.Setup.SalesPersons;
using Inspection.Application.Contracts.Services.SalesManagment.Setup.SalesPersons;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.SharedValidaion;
using Inspection.Application.Shared.SharedValidation;
using Inspection.Domain.Models.SalesManagment.Setup.SalesPersons;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.SalesManagment.Setup.SalesPersons
{
    internal class SalesPersonServise : AccountsServiceBase, ISalesPersonServise
    {
        private readonly ITenantResolver _tenantResolver;

        public SalesPersonServise(
            IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper,
            IExceptionManager exceptionManager,
            ITenantResolver tenantResolver)
            : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
        }

        #region Create

        public async Task<ReturnBase<SalesPersonDto>> Create(SalesPersonCreateDto dto)
        {
            try
            {
                EmailValidator.Validate(dto.Email);

                dto.Code.ValidateAsCode();
                dto.Name.ValidateAsName();
                var entity = _mapper.Map<SalesPerson>(dto);

                // Set Tenant_ID in service layer
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // User_CodeID comes from DTO
                entity.User_CodeId = dto.User_CodeId; // AutoMapper already set this

                // Do not set entity.User_Code; EF will link via FK
                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<SalesPersonDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<SalesPersonDto>.Fail(saveResult.Errors);

                return ReturnBase<SalesPersonDto>.Success(_mapper.Map<SalesPersonDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<SalesPersonDto>.Fail(ex, _exceptionManager);
            }
        }



        public async Task<ReturnBase<SalesPersonDto>> Update(SalesPersonUpdateDto dto)
        {
            try
            {
                EmailValidator.Validate(dto.Email);

                dto.Code.ValidateAsCode();
                dto.Name.ValidateAsName();
                var entity = await _queriesManager.SalesPerson.GetById(dto.Id);
                if (entity is null)
                {
                    return ReturnBase<SalesPersonDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = "SalesPerson Not Found" }
                    });
                }

                _mapper.Map(dto, entity);
                entity.Tenant_ID = _tenantResolver.GetTenantName();
                entity.User_CodeId = dto.User_CodeId;

                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)
                    return ReturnBase<SalesPersonDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<SalesPersonDto>.Fail(saveResult.Errors);

                return ReturnBase<SalesPersonDto>.Success(_mapper.Map<SalesPersonDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<SalesPersonDto>.Fail(ex, _exceptionManager);
            }
        }

        #endregion

        #region Delete

        public async Task<ReturnBase<SalesPersonDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.SalesPerson.GetById(id);
                if (entity is null)
                {
                    return ReturnBase<SalesPersonDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = "SalesPerson Not Found" }
                    });
                }

                var mappedResult = _mapper.Map<SalesPersonDto>(entity);

                var deleteResult = await _commands.DeleteById(id);
                if (!deleteResult.Succeeded)
                    return ReturnBase<SalesPersonDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<SalesPersonDto>.Fail(saveResult.Errors);

                return ReturnBase<SalesPersonDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<SalesPersonDto>.Fail(ex, _exceptionManager);
            }
        }

        #endregion

        #region Get

        public async Task<ReturnBase<SalesPersonDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.SalesPerson.GetById(id);
                if (entity is null)
                {
                    return ReturnBase<SalesPersonDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = "SalesPerson Not Found" }
                    });
                }

                return ReturnBase<SalesPersonDto>.Success(_mapper.Map<SalesPersonDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<SalesPersonDto>.Fail(ex, _exceptionManager);
            }
        }


        #endregion

        #region Search

        public async Task<ReturnBase<IEnumerable<SalesPersonSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var result = await _queriesManager.SalesPerson.Search(sqlQueryOptions);

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<SalesPersonSearchDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<SalesPersonSearchDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<SalesPersonSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        #endregion

        private ISalesPersonCommandRepository _commands
            => _accountUoW.SalesPerson;
    }
}
