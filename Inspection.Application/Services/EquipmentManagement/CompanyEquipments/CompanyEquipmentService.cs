using AutoMapper;
using Inspection.Application.Contracts.Dto.EquipmentManagement.CompanyEquipments;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.CompanyEquipments;
using Inspection.Application.Contracts.Services.EquipmentManagement.CompanyEquipments;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.EquipmentManagement.CompanyEquipments;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.EquipmentManagement.CompanyEquipments
{


    public class CompanyEquipmentService : AccountsServiceBase, ICompanyEquipmentService
    {
        private readonly ITenantResolver tenantResolver;

        public CompanyEquipmentService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            this.tenantResolver = tenantResolver;
        }
        public async Task<List<CompanyEquipmentDtoByInclude>> GetListAsync()
        {

            var list = await _queriesManager.CompanyEquipmentsQueryRepository.GetAllAsync();
            return _mapper.Map<List<CompanyEquipmentDtoByInclude>>(list.Result);
        }
        public async Task<ReturnBase<UpdateCompanyEquipmentDto>> InsertCompanyEquipmentAsync(CreateCompanyEquipmentDto insertDto)
        {
            try
            {

                var entity = _mapper.Map<CompanyEquipment>(insertDto);
                var TenantName = tenantResolver.GetTenantName();
                entity.Tenant_ID = TenantName;
                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<UpdateCompanyEquipmentDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<UpdateCompanyEquipmentDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<UpdateCompanyEquipmentDto>(entity);

                return ReturnBase<UpdateCompanyEquipmentDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateCompanyEquipmentDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateCompanyEquipmentDto>> UpdateCompanyEquipmentAsync(UpdateCompanyEquipmentDto updateDto, long id)
        {
            try
            {
                var entity = await _queriesManager.CompanyEquipmentsQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Company Equipment Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateCompanyEquipmentDto>.Fail(listOfErrors);
                }

                //if (updateDto.ServiceTypeId is 0)
                //    entity.ServiceTypeId = updateDto.ServiceTypeId;

                //if (updateDto.Notes is not null)
                //    entity.Notes = updateDto.Notes;
                var TenantName = tenantResolver.GetTenantName();
                entity.Tenant_ID = TenantName;
                entity = _mapper.Map<CompanyEquipment>(updateDto);
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<UpdateCompanyEquipmentDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateCompanyEquipmentDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateCompanyEquipmentDto>(entity);

                return ReturnBase<UpdateCompanyEquipmentDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateCompanyEquipmentDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateCompanyEquipmentDto>> DeleteCompanyEquipmentAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.CompanyEquipmentsQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Company Equipment Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateCompanyEquipmentDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteByIdAsync(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<UpdateCompanyEquipmentDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateCompanyEquipmentDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateCompanyEquipmentDto>(entity);

                return ReturnBase<UpdateCompanyEquipmentDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateCompanyEquipmentDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<CompanyEquipmentDtoByInclude>>> GetCompanyEquipmentListAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.CompanyEquipmentsQueryRepository.GetListAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<CompanyEquipmentDtoByInclude>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<CompanyEquipmentDtoByInclude>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CompanyEquipmentDtoByInclude>>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<CompanyEquipmentDto>> GetCompanyEquipmentByIdAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.CompanyEquipmentsQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Company Equipment Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<CompanyEquipmentDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<CompanyEquipmentDto>(entity);

                return ReturnBase<CompanyEquipmentDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<CompanyEquipmentDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<CompanyEquipmentDtoByInclude>>> GetCompanyEquipmentListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.CompanyEquipmentsQueryRepository.GetListIncludeNameAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<CompanyEquipmentDtoByInclude>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<CompanyEquipmentDtoByInclude>>.Success(_mapper.Map<IEnumerable<CompanyEquipmentDtoByInclude>>(getResult.Result));
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CompanyEquipmentDtoByInclude>>.Fail(ex, _exceptionManager);
            }

        }
        //public async Task<ReturnBase<IEnumerable<CompanyEquipmentDtoLookUpForNames>>> GetLookUpCompanyEquipmentForNamesAsync(SqlQueryOptions queryOptions)
        //{
        //    var result = await this._queriesManager.CompanyEquipments.GetLookUpCompanyEquipmentForNamesAsync(queryOptions);

        //    var mappedResult = _mapper.Map<IEnumerable<CompanyEquipmentDtoLookUpForNames>>(result.Result);

        //    return ReturnBase<IEnumerable<CompanyEquipmentDtoLookUpForNames>>.Success(mappedResult);

        //}

        private ICompanyEquipmentCommandRepository _commands
        {
            get { return _accountUoW.CompanyEquipmentCommandRepository; }
        }


    }
}

