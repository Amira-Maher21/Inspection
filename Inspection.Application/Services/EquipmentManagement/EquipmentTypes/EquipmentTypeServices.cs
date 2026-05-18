//using AutoMapper;
//using Inspection.Application.Contracts.Dto.InspectionManagement.EquipmentTypes;
//using Inspection.Application.Contracts.Managers;
//using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.EquipmentTypes;
//using Inspection.Application.Contracts.Services.InspectionManagement.EquipmentTypes;
//using Inspection.Application.Contracts.UnitOfWork;
//using Inspection.Application.Services.ServicesBase;
//using Inspection.Domain.Models.InspectionManagement.EquipmentTypes;
//using NDS.Shared.Application.DataQuery;
//using NDS.Shared.Kernel.BaseReturnTypes;
//using NDS.Shared.Kernel.Exceptions;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Inspection.Application.Services.EquipmentManagement.EquipmentTypes
//{
//    internal class EquipmentTypeServices
//    {
//    }
//}

using AutoMapper;
using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentTypes;
//using Inspection.Application.Contracts.Dto.InspectionManagement.EquipmentTypes;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentTypes;
//using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.EquipmentTypes;
//using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.EquipmentTypes;
using Inspection.Application.Contracts.Services.EquipmentManagement.EquipmentTypes;
//using Inspection.Application.Contracts.Services.InspectionManagement.EquipmentTypes;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.EquipmentManagement.EquipmentTypes;

//using Inspection.Domain.Models.InspectionManagement.EquipmentTypes;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.SharedModels;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.InspectionManagement.EquipmentTypes
{
    public class EquipmentTypeServices : AccountsServiceBase, IEquipmentTypeService
    {

        private readonly ITenantResolver _tenantResolver;
        public EquipmentTypeServices(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
        }
        public async Task<List<EquipmentTypeDtoByInclude>> GetListAsync()
        {

            var list = await _queriesManager.EquipmentTypes.GetAllAsync();
            return _mapper.Map<List<EquipmentTypeDtoByInclude>>(list.Result);
        }
        public async Task<ReturnBase<UpdateEquipmentTypeDto>> InsertEquipmentTypeAsync(CreateEquipmentTypeDto insertDto)
        {
            try
            {
                var entity = _mapper.Map<EquipmentType>(insertDto);
                var TenantName = _tenantResolver.GetTenantName();
                entity.Tenant_ID = TenantName;
                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<UpdateEquipmentTypeDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<UpdateEquipmentTypeDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<UpdateEquipmentTypeDto>(entity);

                return ReturnBase<UpdateEquipmentTypeDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateEquipmentTypeDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateEquipmentTypeDto>> UpdateEquipmentTypeAsync(UpdateEquipmentTypeDto updateDto, long id)
        {
            try
            {
                var entity = await _queriesManager.EquipmentTypes.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Equipment Type Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateEquipmentTypeDto>.Fail(listOfErrors);
                }

                //if (updateDto.ServiceTypeId is 0)
                //    entity.ServiceTypeId = updateDto.ServiceTypeId;

                //if (updateDto.Notes is not null)
                //    entity.Notes = updateDto.Notes;

                _mapper.Map(updateDto, entity);
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<UpdateEquipmentTypeDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateEquipmentTypeDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateEquipmentTypeDto>(entity);

                return ReturnBase<UpdateEquipmentTypeDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateEquipmentTypeDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<bool>> DeleteEquipmentTypeAsync(long id)
        {
            try
            {
                var keys = new EntityKeyValueDictionary();
                keys.Add(new KeyValuePair<string, object>("Id", id));

                var deleteResult = await _accountUoW.EquipmentType.DeleteAsync(keys);
                if (!deleteResult.Succeeded)
                {
                    return ReturnBase<bool>.Fail(deleteResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<bool>.Fail(saveResult.Errors);
                }

                return ReturnBase<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return ReturnBase<bool>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<EquipmentTypeDtoByInclude>>> GetEquipmentTypeListAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.EquipmentTypes.GetListAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<EquipmentTypeDtoByInclude>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<EquipmentTypeDtoByInclude>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<EquipmentTypeDtoByInclude>>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<EquipmentTypeDto>> GetEquipmentTypeByIdAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.EquipmentTypes.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Equipment Type Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<EquipmentTypeDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<EquipmentTypeDto>(entity);

                return ReturnBase<EquipmentTypeDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<EquipmentTypeDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<EquipmentTypeDtoByInclude>>> GetEquipmentTypeListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.EquipmentTypes.GetListIncludeNameAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<EquipmentTypeDtoByInclude>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<EquipmentTypeDtoByInclude>>.Success(_mapper.Map<IEnumerable<EquipmentTypeDtoByInclude>>(getResult.Result));
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<EquipmentTypeDtoByInclude>>.Fail(ex, _exceptionManager);
            }

        }
        public async Task<ReturnBase<IEnumerable<EquipmentTypeDtoLookUpForNames>>> GetLookUpEquipmentTypeForNamesAsync(SqlQueryOptions queryOptions)
        {
            var result = await this._queriesManager.EquipmentTypes.GetLookUpEquipmentTypeForNamesAsync(queryOptions);

            var mappedResult = _mapper.Map<IEnumerable<EquipmentTypeDtoLookUpForNames>>(result.Result);

            return ReturnBase<IEnumerable<EquipmentTypeDtoLookUpForNames>>.Success(mappedResult);

        }

        public async Task<EquipmentType> GetByCode(string code)
        {
            var result = await _queriesManager.EquipmentTypes.GetByCode(code);
            return result;
        }

        private IEquipmentTypeCommandRepository _commands
        {
            get { return _accountUoW.EquipmentType; }
        }


    }
}
