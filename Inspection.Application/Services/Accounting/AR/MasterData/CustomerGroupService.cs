using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.AR.MasterData.CustomerGroup;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AR.MasterData;
using Inspection.Application.Contracts.Services.Accounting.AR.MasterData;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Accounting.AR.MasterData;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.AR.MasterData
{
    internal class CustomerGroupService : AccountsServiceBase, ICustomerGroupService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public CustomerGroupService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }
        //done
        public async Task<ReturnBase<CustomerGroupDto>> Create(
            CustomerGroupCreateDto createDto)
        {
            try
            {

                var entity = _mapper.Map<CustomerGroup>(createDto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();
                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<CustomerGroupDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<CustomerGroupDto>.Fail(saveResult.Errors);

                var resultDto = _mapper.Map<CustomerGroupDto>(entity);
                return ReturnBase<CustomerGroupDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<CustomerGroupDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<CustomerGroupDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.CustomerGroups.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Customer Group Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<CustomerGroupDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<CustomerGroupDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<CustomerGroupDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<CustomerGroupDto>(entity);

                return ReturnBase<CustomerGroupDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<CustomerGroupDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<List<CustomerGroupDto>>> GetAll()
        {
            try
            {
                var result = await _queriesManager.CustomerGroups.GetAll();

                if (!result.Succeeded)
                {
                    return ReturnBase<List<CustomerGroupDto>>.Fail(result.Errors);
                }

                var mapped = _mapper.Map<List<CustomerGroupDto>>(result.Result);

                return ReturnBase<List<CustomerGroupDto>>.Success(mapped);
            }
            catch (Exception ex)
            {
                return ReturnBase<List<CustomerGroupDto>>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<CustomerGroupDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.CustomerGroups.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Customer Group not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<CustomerGroupDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<CustomerGroupDto>(entity);

                return ReturnBase<CustomerGroupDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<CustomerGroupDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<IEnumerable<CustomerGroupReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.CustomerGroups.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<CustomerGroupReturnSearchDto>>.Fail(getResult.Errors);

                var mappedResult = _mapper.Map<IEnumerable<CustomerGroupReturnSearchDto>>(getResult.Result);

                return ReturnBase<IEnumerable<CustomerGroupReturnSearchDto>>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CustomerGroupReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<CustomerGroupDto>> Update(CustomerGroupUpdateDto updateDto)
        {
            try
            {
                var entity = await _queriesManager.CustomerGroups.GetById(updateDto.Id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Customer Group Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<CustomerGroupDto>.Fail(listOfErrors);
                }

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(updateDto, entity);
                //entity.Tenant_ID = _tenantResolver.GetTenantName();


                //entity = _mapper.Map<CustomerGroup>(updateDto);
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<CustomerGroupDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<CustomerGroupDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<CustomerGroupDto>(entity);

                return ReturnBase<CustomerGroupDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<CustomerGroupDto>.Fail(ex, _exceptionManager);
            }
        }


        private ICustomerGroupCommandRepository _commands
        {
            get { return _accountUoW.CustomerGroup; }
        }
    }
}