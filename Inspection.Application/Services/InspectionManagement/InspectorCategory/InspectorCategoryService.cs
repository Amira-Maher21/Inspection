using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionManagement.InspectorCategory;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectorCategory;
using Inspection.Application.Contracts.Services.InspectionManagement.InspectorCategory;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.InspectionManagement.InspectorCategory
{
    public class InspectorCategoryService : AccountsServiceBase, IInspectorCategoryService
    {
        private readonly ITenantResolver _tenantResolver;
        public InspectorCategoryService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
        }

        public async Task<ReturnBase<InspectorCategoryDto>> Create(InspectorCategoryCreateDto createDto)
        {
            try
            {
                var entity = _mapper.Map<Domain.Models.InspectionManagement.InspectorCategories.InspectorCategory>(createDto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<InspectorCategoryDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<InspectorCategoryDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<InspectorCategoryDto>(entity);

                return ReturnBase<InspectorCategoryDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<InspectorCategoryDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<InspectorCategoryDto>> Update(InspectorCategoryUpdateDto updateDto)
        {
            try
            {
                var entity = await _queriesManager.InspectorCategory.GetById(updateDto.Id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Inspector Category Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<InspectorCategoryDto>.Fail(listOfErrors);
                }

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(updateDto, entity);
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<InspectorCategoryDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<InspectorCategoryDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<InspectorCategoryDto>(entity);

                return ReturnBase<InspectorCategoryDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<InspectorCategoryDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<InspectorCategoryDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.InspectorCategory.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Inspector Category Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<InspectorCategoryDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<InspectorCategoryDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<InspectorCategoryDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<InspectorCategoryDto>(entity);

                return ReturnBase<InspectorCategoryDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<InspectorCategoryDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<InspectorCategoryDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.InspectorCategory.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<InspectorCategoryDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<InspectorCategoryDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InspectorCategoryDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<InspectorCategoryDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.InspectorCategory.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Inspector Category Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<InspectorCategoryDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<InspectorCategoryDto>(entity);

                return ReturnBase<InspectorCategoryDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<InspectorCategoryDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<List<InspectorCategoryGetListDto>>> GetInspectorCategoryGetListAsync()
        {
            try
            {
                var list = await _queriesManager.InspectorCategory.GetListAsync();

                return ReturnBase<List<InspectorCategoryGetListDto>>
                    .Success(list.ToList());
            }
            catch (Exception ex)
            {
                return ReturnBase<List<InspectorCategoryGetListDto>>
                    .Fail(ex, _exceptionManager);
            }
        }


        private IInspectorCategoryCommandRepository _commands
        {
            get { return _accountUoW.InspectorCategory; }
        }
    }
}