using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.Branches;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup.Branches;
using Inspection.Application.Contracts.Services.Accounting.AccountSetup.Branches;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Application.Shared.SharedValidaion;
using Inspection.Application.Shared.SharedValidation;
using Inspection.Domain.Models.Accounting.AccountingSetup.Branches;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.AccountSetup.Branches
{
    internal class BranchService : AccountsServiceBase, IBranchService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public BranchService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }
        //done
        public async Task<ReturnBase<BranchDto>> Create(
            BranchCreateDto createDto)
        {
            try
            {


                createDto.Code.ValidateAsCode();
                createDto.Name.ValidateAsName();
                EmailValidator.Validate(createDto.Email);

                var tenant = _tenantResolver.GetTenantName();

                var branch = new Branch(
                    createDto.CompanyId,
                    tenant,
                    createDto.Name,
                    createDto.Code,
                    createDto.Description,
                    createDto.CountryId,
                    createDto.CityId,
                    createDto.Address,
                    createDto.Phone,
                    createDto.Email
                );


                await _commands.InsertAsync(branch);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<BranchDto>.Fail(saveResult.Errors);

                var resultDto = _mapper.Map<BranchDto>(branch);
                resultDto.Tenant_ID = _tenantResolver.GetTenantName();
                return ReturnBase<BranchDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<BranchDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<BranchDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.Branches.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Branch Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<BranchDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<BranchDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<BranchDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<BranchDto>(entity);

                return ReturnBase<BranchDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<BranchDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<List<BranchDto>>> GetAll()
        {
            try
            {
                var result = await _queriesManager.Branches.GetAll();

                if (!result.Succeeded)
                {
                    return ReturnBase<List<BranchDto>>.Fail(result.Errors);
                }

                var mapped = _mapper.Map<List<BranchDto>>(result.Result);

                return ReturnBase<List<BranchDto>>.Success(mapped);
            }
            catch (Exception ex)
            {
                return ReturnBase<List<BranchDto>>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<BranchDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.Branches.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Branch not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<BranchDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<BranchDto>(entity);

                return ReturnBase<BranchDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<BranchDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<IEnumerable<BranchReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.Branches.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<BranchReturnSearchDto>>.Fail(getResult.Errors);

                var mappedResult = _mapper.Map<IEnumerable<BranchReturnSearchDto>>(getResult.Result);

                return ReturnBase<IEnumerable<BranchReturnSearchDto>>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<BranchReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<BranchDto>> Update(BranchUpdateDto dto)
        {
            try
            {
                dto.Code.ValidateAsCode();
                dto.Name.ValidateAsName();
                EmailValidator.Validate(dto.Email);


                var entity = await _queriesManager.Branches.GetById(dto.Id);
                if (entity is null)
                {
                    return ReturnBase<BranchDto>.Fail(new List<ReturnBaseError>
            {
                new ReturnBaseError
                {
                    ErrorCode = "404",
                    ErrorMessage = "Branch Not Found"
                }
            });
                }


                entity.Tenant_ID = _tenantResolver.GetTenantName();




                entity.UpdateInfo(
                    dto.Name,
                    dto.Code,
                    dto.Description,
                    dto.CountryId,
                    dto.CityId,
                    dto.Address,
                    dto.Phone,
                    dto.Email
                );




                entity.Mod_Date = DateTime.UtcNow;

                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)
                    return ReturnBase<BranchDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<BranchDto>.Fail(saveResult.Errors);
                var resultDto = _mapper.Map<BranchDto>(entity);
                return ReturnBase<BranchDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<BranchDto>.Fail(ex, _exceptionManager);
            }
        }




        private IBranchCommandRepository _commands
        {
            get { return _accountUoW.Branch; }
        }
    }
}