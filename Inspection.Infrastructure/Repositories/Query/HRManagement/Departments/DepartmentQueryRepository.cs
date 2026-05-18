using Inspection.Application.Contracts.Dto.HRManagement.ApplicantCVs;
using Inspection.Application.Contracts.Dto.HRManagement.Departments;
using Inspection.Application.Contracts.Dto.HRManagement.Employees;
using Inspection.Application.Contracts.Repositories.Query.HRManagement.Departments;
using Inspection.Application.Contracts.Repositories.Query.HRManagement.Employees;
using Inspection.Domain.Models.HRManagement.Departments;
using Inspection.Domain.Models.HRManagement.Employees;
using Inspection.Infrastructure.QueryObjects.HRManagement.ApplicantCVs;
using Inspection.Infrastructure.QueryObjects.HRManagement.Departments;
using Inspection.Infrastructure.QueryObjects.HRManagement.Employees;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Infrastructure.Repositories.Query.HRManagement.Departments
{
    internal class DepartmentQueryRepository : QueryRepositoryBase<Department>, IDepartmentQueryRepository
    {
        public DepartmentQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }
        public async Task<Department?> GetByIdAsync(long id)
        {
            return await _context.Set<Department>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ReturnBase<IEnumerable<DepartmentDto>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        {
            var CompanyQueryRepository = new DepartmentQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await CompanyQueryRepository.Query(sqlQueryOptions);//Query(CompanyDto, sqlQueryOptions);
        }
        public async Task<ReturnBase<IEnumerable<DepartmentDto>>> GetLookUpCompanyForNamesAsync(SqlQueryOptions queryOptions)
        {
            var CompanyQueryRepository = new DepartmentQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);

            return await CompanyQueryRepository.Query(queryOptions);


        }
    }
}
