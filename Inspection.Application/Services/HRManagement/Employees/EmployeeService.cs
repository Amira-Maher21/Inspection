using AutoMapper;
using Inspection.Application.Contracts.Dto.HRManagement.Employees;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.HRManagement.Employees;
using Inspection.Application.Contracts.Services.HRManagement.Employees;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.HRManagement.Employees;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.HRManagement.Employees
{
    internal class EmployeeService : AccountsServiceBase, IEmployeeService
    {
        public EmployeeService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
        }

        public async Task<ReturnBase<EmployeeDto>> DeleteEmployeeTypeAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.EmployeeQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "department Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<EmployeeDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteByIdAsync(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<EmployeeDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<EmployeeDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<EmployeeDto>(entity);

                return ReturnBase<EmployeeDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<EmployeeDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<EmployeeDto>> GetEmployeeTypeByIdAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.EmployeeQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Company Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<EmployeeDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<EmployeeDto>(entity);

                return ReturnBase<EmployeeDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<EmployeeDto>.Fail(ex, _exceptionManager);
            }

        }
        public async Task<ReturnBase<EmployeeDto>> GetByCode(string code)
        {
            try
            {
                var entity = await _queriesManager.EmployeeQueryRepository.GetByCode(code);
                if (entity == null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Employee Not Found"
                    };
                    return ReturnBase<EmployeeDto>.Fail(new List<ReturnBaseError> { error });
                }

                var mappedResult = _mapper.Map<EmployeeDto>(entity);
                return ReturnBase<EmployeeDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<EmployeeDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<EmployeeDto>>> GetEmployeeTypeListAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.EmployeeQueryRepository.GetListAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<EmployeeDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<EmployeeDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<EmployeeDto>>.Fail(ex, _exceptionManager);
            }
        }

        //public async Task<ReturnBase<UpdateEmployeeDto>> InsertEmployeeTypeAsync(CreateEmployeeDto insertDto)
        //{
        //    try
        //    {
        //        var entity = _mapper.Map<Employee>(insertDto);

        //        var insertResult = await _commands.InsertAsync(entity);
        //        if (!insertResult.Succeeded)
        //        {
        //            return ReturnBase<UpdateEmployeeDto>.Fail(insertResult.Errors);
        //        }

        //        var saveResult = await _accountUoW.SaveAsync();
        //        if (!saveResult.Succeeded)
        //        {
        //            return ReturnBase<UpdateEmployeeDto>.Fail(saveResult.Errors);
        //        }

        //        var resultDto = _mapper.Map<UpdateEmployeeDto>(entity);

        //        return ReturnBase<UpdateEmployeeDto>.Success(resultDto);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ReturnBase<UpdateEmployeeDto>.Fail(ex, _exceptionManager);
        //    }
        //}
        public async Task<ReturnBase<EmployeeDto>> InsertEmployeeTypeAsync(CreateEmployeeDto insertDto)
        {
            try
            {
                var entity = _mapper.Map<Employee>(insertDto);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<EmployeeDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<EmployeeDto>.Fail(saveResult.Errors);

                var resultDto = _mapper.Map<EmployeeDto>(entity);
                return ReturnBase<EmployeeDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<EmployeeDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<EmployeeDto>> UpdateEmployeeTypeAsync(UpdateEmployeeDto updateDto, long id)
        {
            try
            {
                // جلب الـ Entity
                var entity = await _queriesManager.EmployeeQueryRepository.GetEntityByIdAsync(id);
                if (entity == null)
                    return ReturnBase<EmployeeDto>.Fail(new List<ReturnBaseError>
            {
                new ReturnBaseError { ErrorCode = "404", ErrorMessage = "Employee Not Found" }
            });

                // ✅ تحديث الحقول المطلوبة فقط
                // اختار أي حقل عايز تحدثه، مثال:
                if (!string.IsNullOrWhiteSpace(updateDto.EmployeeCode))
                    entity.EmployeeCode = updateDto.EmployeeCode;

                if (!string.IsNullOrWhiteSpace(updateDto.FullName))
                    entity.FullName = updateDto.FullName;

                if (updateDto.CVId.HasValue)
                    entity.CVId = updateDto.CVId;

                if (updateDto.JobTitleId != 0)
                    entity.JobTitleId = updateDto.JobTitleId;

                if (updateDto.DepartmentId != 0)
                    entity.DepartmentId = updateDto.DepartmentId;

                if (!string.IsNullOrWhiteSpace(updateDto.PhotoUrl))
                    entity.PhotoUrl = updateDto.PhotoUrl;

                if (!string.IsNullOrWhiteSpace(updateDto.NationalId))
                    entity.NationalId = updateDto.NationalId;

                if (!string.IsNullOrWhiteSpace(updateDto.Qualifications))
                    entity.Qualifications = updateDto.Qualifications;

                if (updateDto.HireDate != default)
                    entity.HireDate = updateDto.HireDate;

                // تنفيذ التحديث باستخدام UpdateAsync كما هو عندك
                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)
                    return ReturnBase<EmployeeDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<EmployeeDto>.Fail(saveResult.Errors);

                // تحويل Entity إلى DTO للعرض
                var resultDto = _mapper.Map<EmployeeDto>(entity);
                return ReturnBase<EmployeeDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<EmployeeDto>.Fail(ex, _exceptionManager);
            }
        }






        //public async Task<ReturnBase<UpdateEmployeeDto>> UpdateEmployeeTypeAsync(UpdateEmployeeDto updateDto, long id)
        //{

        //    try
        //    {
        //        var entity = await _queriesManager.EmployeeQueryRepository.GetByIdAsync(id);
        //        if (entity is null)
        //        {
        //            var error = new ReturnBaseError
        //            {
        //                ErrorCode = "404",
        //                ErrorMessage = "Employee Not Found"
        //            };
        //            return ReturnBase<UpdateEmployeeDto>.Fail(new List<ReturnBaseError> { error });
        //        }

        //        entity.FullName = updateDto.FullName;

        //        var updateResult = await _commands.UpdateAsync(entity);
        //        if (!updateResult.Succeeded)
        //            return ReturnBase<UpdateEmployeeDto>.Fail(updateResult.Errors);

        //        var saveResult = await _accountUoW.SaveAsync();
        //        if (!saveResult.Succeeded)
        //            return ReturnBase<UpdateEmployeeDto>.Fail(saveResult.Errors);

        //        var mappedResult = _mapper.Map<UpdateEmployeeDto>(entity);

        //        return ReturnBase<UpdateEmployeeDto>.Success(mappedResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ReturnBase<UpdateEmployeeDto>.Fail(ex, _exceptionManager);
        //    }
        //}
        private IEmployeeCommandRepository _commands
        {
            get { return _accountUoW.EmployeeCommandRepository; }
        }
    }
}
