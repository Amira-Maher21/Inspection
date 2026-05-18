using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.PR.MasterData.SupplierGroups;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.PR.MasterData.SupplierGroups;
using Inspection.Application.Contracts.Services.Accounting.PR.MasterData.SupplierGroups;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Application.Shared.SharedValidation;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.PR.MasterData.SupplierGroup
{
    internal class SupplierGroupService : AccountsServiceBase, ISupplierGroupService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public SupplierGroupService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }
        //done
        public async Task<ReturnBase<SupplierGroupDto>> Create(
            SupplierGroupCreateDto createDto)
        {
            try
            {
                createDto.Code.ValidateAsCode();
                createDto.Name.ValidateAsName();
                var entity = _mapper.Map<Domain.Models.Accounting.PR.MasterData.Suppliers.SupplierGroup>(createDto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();
                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<SupplierGroupDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<SupplierGroupDto>.Fail(saveResult.Errors);

                var resultDto = _mapper.Map<SupplierGroupDto>(entity);
                return ReturnBase<SupplierGroupDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<SupplierGroupDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<SupplierGroupDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.SupplierGroups.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Supplier Group Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<SupplierGroupDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<SupplierGroupDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<SupplierGroupDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<SupplierGroupDto>(entity);

                return ReturnBase<SupplierGroupDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<SupplierGroupDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<List<SupplierGroupDto>>> GetAll()
        {
            try
            {
                var result = await _queriesManager.SupplierGroups.GetAll();

                if (!result.Succeeded)
                {
                    return ReturnBase<List<SupplierGroupDto>>.Fail(result.Errors);
                }

                var mapped = _mapper.Map<List<SupplierGroupDto>>(result.Result);

                return ReturnBase<List<SupplierGroupDto>>.Success(mapped);
            }
            catch (Exception ex)
            {
                return ReturnBase<List<SupplierGroupDto>>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<SupplierGroupDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.SupplierGroups.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Supplier Group not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<SupplierGroupDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<SupplierGroupDto>(entity);

                return ReturnBase<SupplierGroupDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<SupplierGroupDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<IEnumerable<SupplierGroupReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.SupplierGroups.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<SupplierGroupReturnSearchDto>>.Fail(getResult.Errors);

                var mappedResult = _mapper.Map<IEnumerable<SupplierGroupReturnSearchDto>>(getResult.Result);

                return ReturnBase<IEnumerable<SupplierGroupReturnSearchDto>>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<SupplierGroupReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<SupplierGroupDto>> Update(SupplierGroupUpdateDto updateDto)
        {
            try
            {
                updateDto.Code.ValidateAsCode();
                updateDto.Name.ValidateAsName();
                var entity = await _queriesManager.SupplierGroups.GetById(updateDto.Id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Supplier Group Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<SupplierGroupDto>.Fail(listOfErrors);
                }
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(updateDto, entity);
                //entity.Tenant_ID = _tenantResolver.GetTenantName();

                //entity = _mapper.Map<Inspection.Domain.Models.Accounting.PR.MasterData.Suppliers.SupplierGroup.SupplierGroup>(updateDto);
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<SupplierGroupDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<SupplierGroupDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<SupplierGroupDto>(entity);

                return ReturnBase<SupplierGroupDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<SupplierGroupDto>.Fail(ex, _exceptionManager);
            }
        }


        private ISupplierGroupCommandRepository _commands
        {
            get { return _accountUoW.SupplierGroup; }
        }
    }
}