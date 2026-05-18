using Inspection.Application.Contracts.Dto.HRManagement.Employees;
using Inspection.Application.Contracts.Repositories.Query.HRManagement.Employees;
using Inspection.Domain.Models.HRManagement.Employees;
using Inspection.Infrastructure.QueryObjects.HRManagement.Employees;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.HRManagement.Employees
{
    internal class EmployeeQueryRepository : QueryRepositoryBase<Employee>, IEmployeeQueryRepository
    {
        public EmployeeQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        //public async Task<Employee?> GetByIdAsync(long id)
        //{
        //    return await _context.Set<Employee>().Where(x => x.Id == id).FirstOrDefaultAsync();
        //}
        public async Task<Employee?> GetByCode(string code)
        {
            return await _context.Set<Employee>().Where(x => x.EmployeeCode == code).FirstOrDefaultAsync();
        }
        public async Task<Employee?> GetEntityByIdAsync(long id)
        {
            return await _context.Set<Employee>().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<EmployeeDto?> GetByIdAsync(long id)
        {
            string sql = @"
        SELECT 
            E.Id,
            E.CVId,
            E.FullName AS EmployeeFullName,
            ACV.FullName AS ApplicantFullName,
            E.EmployeeCode,
            E.JobTitleId,
            JT.Title AS JobTitleName,
            E.DepartmentId,
            D.Name AS DepartmentName,
            E.PhotoUrl,
            E.NationalId,
            E.Qualifications,
            E.HireDate
        FROM Employees E
        LEFT JOIN JobTitles JT ON JT.Id = E.JobTitleId
        LEFT JOIN Departments D ON D.Id = E.DepartmentId
        LEFT JOIN ApplicantCVs ACV ON ACV.Id = E.CVId
        WHERE E.Id = @Id;
    ";

            var parameters = new Dictionary<string, object>
            {
                ["Id"] = id
            };

            var result = await _dapper.QueryList<EmployeeDto>(sql, parameters);

            if (!result.Succeeded)
                return null;

            return result.Result.FirstOrDefault();
        }



        public async Task<ReturnBase<IEnumerable<EmployeeDto>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        {
            var CompanyQueryRepository = new EmployeeQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await CompanyQueryRepository.Query(sqlQueryOptions);//Query(CompanyDto, sqlQueryOptions);
        }
        public async Task<ReturnBase<IEnumerable<EmployeeDto>>> GetLookUpCompanyForNamesAsync(SqlQueryOptions queryOptions)
        {
            var CompanyQueryRepository = new EmployeeQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);

            return await CompanyQueryRepository.Query(queryOptions);

        }
    }
}