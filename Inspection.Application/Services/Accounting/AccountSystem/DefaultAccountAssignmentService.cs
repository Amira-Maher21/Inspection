using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.AccountSystemDto.DefaultAccountAssignment;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSystem;
using Inspection.Application.Contracts.Services.Accounting.AccountSystem;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Accounting.AccountingSystem.DefaultAccountAssignment;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.AccountSystem
{
    internal class DefaultAccountAssignmentService : AccountsServiceBase, IDefaultAccountAssignmentService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public DefaultAccountAssignmentService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }
        //done
        public async Task<ReturnBase<DefaultAccountAssignmentDto>> Create(
            DefaultAccountAssignmentCreateDto createDto)
        {
            try
            {

                var entity = _mapper.Map<DefaultAccountAssignment>(createDto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();
                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<DefaultAccountAssignmentDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<DefaultAccountAssignmentDto>.Fail(saveResult.Errors);

                var resultDto = _mapper.Map<DefaultAccountAssignmentDto>(entity);
                return ReturnBase<DefaultAccountAssignmentDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<DefaultAccountAssignmentDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<DefaultAccountAssignmentDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.DefaultAccountAssignments.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Default Account Assignment Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<DefaultAccountAssignmentDto>.Fail(listOfErrors);
                }




                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<DefaultAccountAssignmentDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<DefaultAccountAssignmentDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<DefaultAccountAssignmentDto>(entity);

                return ReturnBase<DefaultAccountAssignmentDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<DefaultAccountAssignmentDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<List<DefaultAccountAssignmentDto>>> GetAll()
        {
            try
            {
                var result = await _queriesManager.DefaultAccountAssignments.GetAll();

                if (!result.Succeeded)
                {
                    return ReturnBase<List<DefaultAccountAssignmentDto>>.Fail(result.Errors);
                }

                var mapped = _mapper.Map<List<DefaultAccountAssignmentDto>>(result.Result);

                return ReturnBase<List<DefaultAccountAssignmentDto>>.Success(mapped);
            }
            catch (Exception ex)
            {
                return ReturnBase<List<DefaultAccountAssignmentDto>>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<DefaultAccountAssignmentDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.DefaultAccountAssignments.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Default Account Assignment not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<DefaultAccountAssignmentDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<DefaultAccountAssignmentDto>(entity);

                return ReturnBase<DefaultAccountAssignmentDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<DefaultAccountAssignmentDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<IEnumerable<DefaultAccountAssignmentReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.DefaultAccountAssignments.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<DefaultAccountAssignmentReturnSearchDto>>.Fail(getResult.Errors);

                var mappedResult = _mapper.Map<IEnumerable<DefaultAccountAssignmentReturnSearchDto>>(getResult.Result);

                return ReturnBase<IEnumerable<DefaultAccountAssignmentReturnSearchDto>>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<DefaultAccountAssignmentReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<DefaultAccountAssignmentDto>> Update(DefaultAccountAssignmentUpdateDto updateDto)
        {
            try
            {
                var entity = await _queriesManager.DefaultAccountAssignments.GetById(updateDto.Id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Default Account Assignment Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<DefaultAccountAssignmentDto>.Fail(listOfErrors);
                }

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(updateDto, entity);

                //entity.Tenant_ID = _tenantResolver.GetTenantName();


                //entity = _mapper.Map<DefaultAccountAssignment>(updateDto);
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<DefaultAccountAssignmentDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<DefaultAccountAssignmentDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<DefaultAccountAssignmentDto>(entity);

                return ReturnBase<DefaultAccountAssignmentDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<DefaultAccountAssignmentDto>.Fail(ex, _exceptionManager);
            }
        }


        private IDefaultAccountAssignmentCommandRepository _commands
        {
            get { return _accountUoW.DefaultAccountAssignment; }
        }
    }
}