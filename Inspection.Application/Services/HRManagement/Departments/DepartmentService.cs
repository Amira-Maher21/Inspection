using AutoMapper;
using Inspection.Application.Contracts.Dto.HRManagement.ApplicantCVs;
using Inspection.Application.Contracts.Dto.HRManagement.Departments;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.HRManagement.ApplicantCVs;
using Inspection.Application.Contracts.Repositories.Command.HRManagement.Departments;
using Inspection.Application.Contracts.Services.HRManagement.ApplicantCVs;
using Inspection.Application.Contracts.Services.HRManagement.Department;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.HRManagement.ApplicantCVs;
using Inspection.Domain.Models.HRManagement.Departments;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Services.HRManagement.Departments
{
    internal class DepartmentService : AccountsServiceBase, IDepartmentService
    {
        public DepartmentService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
        }

        public async Task<ReturnBase<UpdateDepartmentDto>> DeleteDepartmentTypeAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.DepartmentQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "department Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateDepartmentDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteByIdAsync(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<UpdateDepartmentDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateDepartmentDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateDepartmentDto>(entity);

                return ReturnBase<UpdateDepartmentDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateDepartmentDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<DepartmentDto>> GetDepartmentTypeByIdAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.DepartmentQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Company Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<DepartmentDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<DepartmentDto>(entity);

                return ReturnBase<DepartmentDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<DepartmentDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<DepartmentDto>>> GetDepartmentTypeListAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.DepartmentQueryRepository.GetListAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<DepartmentDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<DepartmentDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<DepartmentDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<UpdateDepartmentDto>> InsertDepartmentTypeAsync(CreateDepartmentDto insertDto)
        {
            try
            {
                var entity = _mapper.Map<Department>(insertDto);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<UpdateDepartmentDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<UpdateDepartmentDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<UpdateDepartmentDto>(entity);

                return ReturnBase<UpdateDepartmentDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateDepartmentDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<UpdateDepartmentDto>> UpdateDepartmentTypeAsync(UpdateDepartmentDto updateDto, long id)
        {
           
            try
            {
                var entity = await _queriesManager.DepartmentQueryRepository.GetByIdAsync(id);
                if (entity == null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Department Not Found"
                    };
                    return ReturnBase<UpdateDepartmentDto>.Fail(new List<ReturnBaseError> { error });
                }

                _mapper.Map(updateDto, entity);

                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)
                    return ReturnBase<UpdateDepartmentDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateDepartmentDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateDepartmentDto>(entity);

                return ReturnBase<UpdateDepartmentDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                var realException = ex.InnerException ?? ex;
                return ReturnBase<UpdateDepartmentDto>.Fail(realException, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<DepartmentDtoLookUpForNames>>> GetLookUpCompanyForNamesAsync(SqlQueryOptions queryOptions)
        {
            //var result = await this._queriesManager.DepartmentQueryRepository.GetLookUpCompanyForNamesAsync(queryOptions);

            //var mappedResult = _mapper.Map<IEnumerable<DepartmentDtoLookUpForNames>>(result.Result);

            //return ReturnBase<IEnumerable<DepartmentDtoLookUpForNames>>.Success(mappedResult);
            var result = await this._queriesManager.DepartmentQueryRepository.GetLookUpCompanyForNamesAsync(queryOptions);

            var mappedResult = result.Result.Select(d => new DepartmentDtoLookUpForNames
            {
                Id = d.Id,
                Name = d.Name
            });

            return ReturnBase<IEnumerable<DepartmentDtoLookUpForNames>>.Success(mappedResult);

        }
        private IDepartmentCommandRepository _commands
        {
            get { return _accountUoW.DepartmentCommandRepository; }
        }
    }
}
