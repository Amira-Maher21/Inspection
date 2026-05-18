using AutoMapper;
using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentSoftwares;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentSoftwares;
using Inspection.Application.Contracts.Services.EquipmentManagement.EquipmentSoftwares;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.EquipmentManagement.EquipmentSoftwares;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Services.EquipmentManagement.EquipmentSoftwares
{
 

    public class EquipmentSoftwareService : AccountsServiceBase, IEquipmentSoftwareService
    {
        private readonly ITenantResolver tenantResolver;

        public EquipmentSoftwareService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            this.tenantResolver = tenantResolver;
        }
        public async Task<List<EquipmentSoftwareDtoByInclude>> GetListAsync()
        {

            var list = await _queriesManager.EquipmentSoftwareQueryRepository.GetAllAsync();
            return _mapper.Map<List<EquipmentSoftwareDtoByInclude>>(list.Result);
        }
        public async Task<ReturnBase<UpdateEquipmentSoftwareDto>> InsertEquipmentSoftwareAsync(CreateEquipmentSoftwareDto insertDto)
        {
            try
            {
                var entity = _mapper.Map<EquipmentSoftware>(insertDto);
                var TenantName = tenantResolver.GetTenantName();
                entity.Tenant_ID = TenantName;
                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<UpdateEquipmentSoftwareDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<UpdateEquipmentSoftwareDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<UpdateEquipmentSoftwareDto>(entity);

                return ReturnBase<UpdateEquipmentSoftwareDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateEquipmentSoftwareDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateEquipmentSoftwareDto>> UpdateEquipmentSoftwareAsync(UpdateEquipmentSoftwareDto updateDto, long id)
        {
            try
            {
                var entity = await _queriesManager.EquipmentSoftwareQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "EquipmentSoftware Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateEquipmentSoftwareDto>.Fail(listOfErrors);
                }

                //if (updateDto.ServiceTypeId is 0)
                //    entity.ServiceTypeId = updateDto.ServiceTypeId;

                //if (updateDto.Notes is not null)
                //    entity.Notes = updateDto.Notes;
                entity = _mapper.Map<EquipmentSoftware>(updateDto);
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<UpdateEquipmentSoftwareDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateEquipmentSoftwareDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateEquipmentSoftwareDto>(entity);

                return ReturnBase<UpdateEquipmentSoftwareDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateEquipmentSoftwareDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateEquipmentSoftwareDto>> DeleteEquipmentSoftwareAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.EquipmentSoftwareQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "EquipmentSoftware Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateEquipmentSoftwareDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteByIdAsync(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<UpdateEquipmentSoftwareDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateEquipmentSoftwareDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateEquipmentSoftwareDto>(entity);

                return ReturnBase<UpdateEquipmentSoftwareDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateEquipmentSoftwareDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<EquipmentSoftwareDtoByInclude>>> GetEquipmentSoftwareListAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.EquipmentSoftwareQueryRepository.GetListAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<EquipmentSoftwareDtoByInclude>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<EquipmentSoftwareDtoByInclude>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<EquipmentSoftwareDtoByInclude>>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<EquipmentSoftwareDto>> GetEquipmentSoftwareByIdAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.EquipmentSoftwareQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "EquipmentSoftware Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<EquipmentSoftwareDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<EquipmentSoftwareDto>(entity);

                return ReturnBase<EquipmentSoftwareDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<EquipmentSoftwareDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<EquipmentSoftwareDtoByInclude>>> GetEquipmentSoftwareListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.EquipmentSoftwareQueryRepository.GetListIncludeNameAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<EquipmentSoftwareDtoByInclude>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<EquipmentSoftwareDtoByInclude>>.Success(_mapper.Map<IEnumerable<EquipmentSoftwareDtoByInclude>>(getResult.Result));
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<EquipmentSoftwareDtoByInclude>>.Fail(ex, _exceptionManager);
            }

        }
        //public async Task<ReturnBase<IEnumerable<EquipmentSoftwareDtoLookUpForNames>>> GetLookUpEquipmentSoftwareForNamesAsync(SqlQueryOptions queryOptions)
        //{
        //    var result = await this._queriesManager.EquipmentSoftwares.GetLookUpEquipmentSoftwareForNamesAsync(queryOptions);

        //    var mappedResult = _mapper.Map<IEnumerable<EquipmentSoftwareDtoLookUpForNames>>(result.Result);

        //    return ReturnBase<IEnumerable<EquipmentSoftwareDtoLookUpForNames>>.Success(mappedResult);

        //}

        private IEquipmentSoftwareCommandRepository _commands
        {
            get { return _accountUoW.EquipmentSoftwareCommandRepository; }
        }


    }
}

