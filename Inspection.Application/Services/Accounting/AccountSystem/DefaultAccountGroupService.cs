using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.AccountSystemDto.DefaultAccountGroup;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSystem;
using Inspection.Application.Contracts.Services.Accounting.AccountSystem;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Accounting.AccountingSystem;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.AccountSystem
{
    internal class DefaultAccountGroupService : AccountsServiceBase, IDefaultAccountGroupService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public DefaultAccountGroupService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }
        //done
        public async Task<ReturnBase<DefaultAccountGroupDto>> Create(
            DefaultAccountGroupCreateDto createDto)
        {
            try
            {

                var entity = _mapper.Map<DefaultAccountGroup>(createDto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();
                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<DefaultAccountGroupDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<DefaultAccountGroupDto>.Fail(saveResult.Errors);

                var resultDto = _mapper.Map<DefaultAccountGroupDto>(entity);
                return ReturnBase<DefaultAccountGroupDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<DefaultAccountGroupDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<DefaultAccountGroupDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.DefaultAccountGroups.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Default Account Group Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<DefaultAccountGroupDto>.Fail(listOfErrors);
                }




                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<DefaultAccountGroupDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<DefaultAccountGroupDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<DefaultAccountGroupDto>(entity);

                return ReturnBase<DefaultAccountGroupDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<DefaultAccountGroupDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<List<DefaultAccountGroupDto>>> GetAll()
        {
            try
            {
                var result = await _queriesManager.DefaultAccountGroups.GetAll();

                if (!result.Succeeded)
                {
                    return ReturnBase<List<DefaultAccountGroupDto>>.Fail(result.Errors);
                }

                var mapped = _mapper.Map<List<DefaultAccountGroupDto>>(result.Result);

                return ReturnBase<List<DefaultAccountGroupDto>>.Success(mapped);
            }
            catch (Exception ex)
            {
                return ReturnBase<List<DefaultAccountGroupDto>>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<DefaultAccountGroupDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.DefaultAccountGroups.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Default Account Group not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<DefaultAccountGroupDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<DefaultAccountGroupDto>(entity);

                return ReturnBase<DefaultAccountGroupDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<DefaultAccountGroupDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<IEnumerable<DefaultAccountGroupDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.DefaultAccountGroups.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<DefaultAccountGroupDto>>.Fail(getResult.Errors);

                var mappedResult = _mapper.Map<IEnumerable<DefaultAccountGroupDto>>(getResult.Result);

                return ReturnBase<IEnumerable<DefaultAccountGroupDto>>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<DefaultAccountGroupDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<DefaultAccountGroupDto>> Update(DefaultAccountGroupUpdateDto updateDto)
        {
            try
            {
                var entity = await _queriesManager.DefaultAccountGroups.GetById(updateDto.Id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Default Account Group Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<DefaultAccountGroupDto>.Fail(listOfErrors);
                }
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(updateDto, entity);

                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<DefaultAccountGroupDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<DefaultAccountGroupDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<DefaultAccountGroupDto>(entity);

                return ReturnBase<DefaultAccountGroupDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<DefaultAccountGroupDto>.Fail(ex, _exceptionManager);
            }
        }

        private IDefaultAccountGroupCommandRepository _commands
        {
            get { return _accountUoW.DefaultAccountGroup; }
        }
    }
}