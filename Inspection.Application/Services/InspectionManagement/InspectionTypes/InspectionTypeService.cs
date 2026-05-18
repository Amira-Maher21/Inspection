using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionTypes;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionTypes;
using Inspection.Application.Contracts.Services.InspectionManagement.InspectionTypes;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.InspectionManagement.InspectionTypes;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.InspectionManagement.InspectionTypes
{
    internal class InspectionTypeService : AccountsServiceBase, IInspectionTypeService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public InspectionTypeService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }

        public async Task<ReturnBase<InspectionTypeDto>> Create(InspectionTypeCreateDto createDto)
        {
            try
            {
                var entity = _mapper.Map<InspectionType>(createDto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<InspectionTypeDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<InspectionTypeDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<InspectionTypeDto>(entity);

                return ReturnBase<InspectionTypeDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<InspectionTypeDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<InspectionTypeDto>> Update(InspectionTypeUpdateDto updateDto)
        {
            try
            {
                var entity = await _queriesManager.InspectionTypes.GetById(updateDto.Id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Inspection Type Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<InspectionTypeDto>.Fail(listOfErrors);
                }

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(updateDto, entity);
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<InspectionTypeDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<InspectionTypeDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<InspectionTypeDto>(entity);

                return ReturnBase<InspectionTypeDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<InspectionTypeDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<InspectionTypeDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.InspectionTypes.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Inspection Type Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<InspectionTypeDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<InspectionTypeDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<InspectionTypeDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<InspectionTypeDto>(entity);

                return ReturnBase<InspectionTypeDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<InspectionTypeDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<InspectionTypeDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.InspectionTypes.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<InspectionTypeDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<InspectionTypeDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InspectionTypeDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<InspectionTypeDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.InspectionTypes.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Inspection Type Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<InspectionTypeDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<InspectionTypeDto>(entity);

                return ReturnBase<InspectionTypeDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<InspectionTypeDto>.Fail(ex, _exceptionManager);
            }
        }
        private IInspectionTypeCommandRepository _commands
        {
            get { return _accountUoW.InspectionTypesCommandRepository; }
        }
    }
}